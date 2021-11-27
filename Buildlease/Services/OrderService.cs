using Contracts.Views;
using Domain.Models;
using Persistence;
using Services.Abstractions;
using System.Linq;

namespace Services
{
    internal sealed class OrderService : IOrderService
    {
        private readonly ApplicationDbContext _db;

        public OrderService(ApplicationDbContext dbContext) => _db = dbContext;

        public CartFullView GetMyCart(string userId)
        {
            var order = _db.Orders.SingleOrDefault(e => e.Status == OrderStatus.Cart);
            var productOrders = _db.ProductOrders.Where(e => e.OrderId == order.Id);
            // ...
            throw new System.NotImplementedException();
        }

        public OrderView[] GetMyOrders(string userId)
        {
            throw new System.NotImplementedException();
        }

        public OrderFullView GetOrder(string userId, int orderId)
        {
            throw new System.NotImplementedException();
        }
    }
}
