using Contracts.Views;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Services.Abstractions;
using Services.Extension;
using System;
using System.Linq;

namespace Services
{
    internal sealed class OrderService : IOrderService
    {
        private readonly ApplicationDbContext _db;

        public OrderService(ApplicationDbContext dbContext, IServiceManager manager) => _db = dbContext;

        private void ValidateUser(string userId)
        {
            if (userId is null) throw new UnauthorizedAccessException("You must login first");
        }

        public CartFullView GetMyCart(string userId)
        {
            ValidateUser(userId);

            var cart = _db.ValidateAndGetCart(userId);
            var cartFullView = new CartFullView()
            {
                ProductOrders = cart.ExtractProductOrderView().ToArray(),
            };
            return cartFullView;
        }

        public OrderView[] GetMyOrders(string userId)
        {
            ValidateUser(userId);

            var orders = _db.Orders
                .IncludeProductOrderView()
                .Where(e => e.CustomerId == userId)
                .Where(e => e.Status != OrderStatus.Cart);

            var orderViews = orders
                .Select(e => new OrderView()
                {
                    Id = e.Id,
                    Status = e.Status,
                    ProductOrders = e.ExtractProductOrderView().ToArray(),
                })
                .ToArray();

            foreach (var orderView in orderViews)
            {
                orderView.ProductCount = orderView.ProductOrders.Sum(po => po.Count);
                orderView.Price = orderView.ProductOrders.Sum(po => po.Price);

                // TODO: Remove after testing
                if (!_db.HistoryOfOrderStatus.Where(e => e.OrderId == orderView.Id).Any())
                    orderView.OrderAcceptDate = DateTime.UtcNow;
                else

                orderView.OrderAcceptDate =
                    _db.HistoryOfOrderStatus
                    .Where(e => e.OrderId == orderView.Id)
                    .Min(e => e.Date);
            }

            return orderViews;
        }

        public OrderFullView GetOrder(string userId, int orderId)
        {
            ValidateUser(userId);

            var order = _db.Orders
                .IncludeProductOrderView()
                .Where(e => e.CustomerId == userId)
                .SingleOrDefault(e => e.Id == orderId);

            if (order is null) throw new UnauthorizedAccessException("It's not your order");

            var statuses = _db.HistoryOfOrderStatus
                .Where(e => e.OrderId == order.Id)
                .OrderBy(e => e.Date)
                .Select(e => new StatusChangeView()
                {
                    Date = e.Date,
                    NewStatus = e.NewStatus,
                })
                .ToArray();

            var orderFullView = new OrderFullView()
            {
                Id = order.Id,
                Status = order.Status,
                ProductOrders = order.ExtractProductOrderView().ToArray(),
                StatusHistory = statuses,
            };

            orderFullView.Price = orderFullView.ProductOrders.Sum(po => po.Price);

            return orderFullView;
        }

        public ProductFullView GetHistoryProduct(string userId, int productOrderId)
        {
            ValidateUser(userId);

            var productOrder = _db.ProductOrders
                .Where(e => e.Order.CustomerId == userId)
                .Single(e => e.Id == productOrderId);

            var productFullView = Newtonsoft.Json.JsonConvert.DeserializeObject<ProductFullView>(productOrder.SerializedProductFullView);

            return productFullView;
        }
    }
}
