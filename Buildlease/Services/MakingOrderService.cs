using Domain.Models;
using Persistence;
using Services.Abstractions;
using Services.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    internal sealed class MakingOrderService : IMakingOrderService
    {
        private readonly ApplicationDbContext _db;
        private readonly IServiceManager _manager;

        public MakingOrderService(ApplicationDbContext dbContext, IServiceManager manager)
        {
            _db = dbContext;
            _manager = manager;
        }

        public const int NecessaryPeriodBetweenCreatingAndSigningOrderInDays = 2;
        public const int MinimumLeasePeriodInDays = 1;

        public void SetProductOrderCount(string userId, int productId, int count)
        {
            var cart = _db.ValidateAndGetCart(userId);

            var productOrder = _db.ProductOrders
                .Where(e => e.OrderId == cart.Id)
                .SingleOrDefault(e => e.ProductId == productId);

            if (productOrder is null)
            {
                _db.ProductOrders.Add(new ProductOrder()
                {
                    OrderId = cart.Id,
                    ProductId = productId,
                    Count = count,
                });
            }
            else
            {
                if (count == 0) 
                    _db.ProductOrders.Remove(productOrder);
                else
                    productOrder.Count = count;
            }

            _db.SaveChanges();
        }

        public void MakeOrderFromCart(string userId, DateTime startDate, DateTime finishDate)
        {
            if (startDate.AddDays(NecessaryPeriodBetweenCreatingAndSigningOrderInDays) <= DateTime.UtcNow || 
                startDate.AddDays(MinimumLeasePeriodInDays) > finishDate)
                throw new InvalidOperationException(
                    $"Invalid lease period");

            _db.Database.BeginTransaction();

            var order = _db.ValidateAndGetCart(userId);

            var productOrders = _db.ProductOrders.Where(e => e.OrderId == order.Id).ToArray();

            if (!productOrders.Any())
                throw new InvalidOperationException(
                    $"Your cart is empty");

            if (productOrders.First(po => po.Count > _db.GetProductAvailableCount(po.ProductId.Value)) is ProductOrder error)
                throw new InvalidOperationException(
                    $"There's only {_db.GetProductAvailableCount(error.ProductId.Value)} available items of {_db.Products.Single(e => e.Id == error.ProductId).Name}");

            order.Status = OrderStatus.WaitingForApproval;

            // TODO: implement
            order.SerializedCustomerInfo = userId;

            foreach (var productOrder in productOrders)
            {
                productOrder.SerializedProductFullView = 
                    Newtonsoft.Json.JsonConvert.SerializeObject(
                        _manager.CatalogueService.GetProduct(productOrder.ProductId.Value, userId));
            }

            _db.SaveChanges();
            _db.Database.CommitTransaction();

            _db.ValidateAndGetCart(userId);
        }

        public void DeclineOrder(string userId, int orderId)
        {
            var order = _db.Orders
                .Where(e => e.CustomerId == userId)
                .Single(e => e.Id == orderId);

            if (!OrderStatusMetadata.DeclinableStatuses.Contains(order.Status))
                throw new InvalidOperationException(
                    $"You can't decline order with status {order.Status}");

            order.Status = OrderStatus.DeclinedByCustomer;
            _db.SaveChanges();
        }
    }
}
