using Contracts.Views;
using Domain.Models;
using Persistence;
using Services.Abstractions;
using Services.Extension;
using System.Linq;

namespace Services
{
    internal sealed class OrderService : IOrderService
    {
        private readonly ApplicationDbContext _db;

        public OrderService(ApplicationDbContext dbContext) => _db = dbContext;

        public Order ValidateAndGetCart(string userId)
        {
            var carts = _db.Orders
                .Where(e => e.CustomerId == userId)
                .Where(e => e.Status == OrderStatus.Cart);

            if (carts.Count() != 1)
            {
                _db.Orders.RemoveRange(carts);
                _db.Orders.Add(new Order() { CustomerId = userId, Status = OrderStatus.Cart });
                _db.SaveChanges();
            }

            return _db.Orders.Single(e => e.Status == OrderStatus.Cart);
        }

        public CartFullView GetMyCart(string userId)
        {
            var order = ValidateAndGetCart(userId);
            var productOrderViews = _db.GetProductOrderViews(order.Id);
            var cartFullView = new CartFullView()
            {
                ProductOrders = productOrderViews,
            };
            return cartFullView;
        }

        public OrderView[] GetMyOrders(string userId)
        {
            var orders = _db.Orders
                .Where(e => e.CustomerId == userId)
                .Where(e => e.Status != OrderStatus.Cart);

            var orderViews = orders
                .Select(e => new OrderView()
                {
                    Id = e.Id,
                    Status = e.Status,
                    ProductOrders = _db.GetProductOrderViews(e.Id),
                })
                .ToArray();

            foreach (var orderView in orderViews)
            {
                orderView.ProductCount = orderView.ProductOrders.Sum(po => po.Count);
                orderView.Price = orderView.ProductOrders.Sum(po => po.Price);
                orderView.OrderAcceptDate = System.DateTime.UtcNow;
            }

            return orderViews;
        }

        public OrderFullView GetOrder(string userId, int orderId)
        {
            var order = _db.Orders
                .Where(e => e.CustomerId == userId)
                .Single(e => e.Id == orderId);

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
                ProductOrders = _db.GetProductOrderViews(order.Id),
                StatusHistory = statuses,
            };

            orderFullView.Price = orderFullView.ProductOrders.Sum(po => po.Price);

            return orderFullView;
        }
    }
}
