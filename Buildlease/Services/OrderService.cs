using Contracts.Views;
using Persistence;
using Services.Abstractions;

namespace Services
{
    internal sealed class OrderService : IOrderService
    {
        private readonly ApplicationDbContext _dbContext;

        public OrderService(ApplicationDbContext dbContext) => _dbContext = dbContext;

        public CartFullView GetMyCart()
        {
            throw new System.NotImplementedException();
        }

        public OrderView[] GetMyOrders()
        {
            throw new System.NotImplementedException();
        }

        public OrderFullView GetOrder(int orderId)
        {
            throw new System.NotImplementedException();
        }
    }
}
