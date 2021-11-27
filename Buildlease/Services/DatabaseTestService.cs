using Contracts.Requests;
using Contracts.Views;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Services.Abstractions;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    internal sealed class DatabaseTestService : IDatabaseTestService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IOrderService _service;

        public DatabaseTestService(ApplicationDbContext dbContext, IOrderService service)
        {
            _dbContext = dbContext;
            _service = service;
        }

        public void DoTest(string userId)
        {
            var GetMyOrders = _service.GetMyOrders(userId);

            var GetMyCart = _service.GetMyCart(userId);

            var myOrdersIds = Domain.EntitiesExample.OrderEntities.Get().Where(o => o.CustomerId == userId).Select(o => o.Id);
            foreach (var orderId in myOrdersIds)
            {
                var GetOrder = _service.GetOrder(userId, orderId);
            }
        }

        public void RestartDatabase()
        {
            _dbContext.Database.EnsureDeleted();
            _dbContext.Database.EnsureCreated();
            FillDatabaseWithExampleEntities();
        }

        private void FillDatabaseWithExampleEntities()
        {
            _dbContext.Database.BeginTransaction();

            _dbContext.Categories.AddRange(Domain.EntitiesExample.CategoryEntities.Get());
            _dbContext.Products.AddRange(Domain.EntitiesExample.ProductEntities.Get());
            _dbContext.Attributes.AddRange(Domain.EntitiesExample.AttributeEntities.Get());
            _dbContext.ProductAttributes.AddRange(Domain.EntitiesExample.ProductAttributeEntities.Get());

            _dbContext.Users.AddRange(Domain.EntitiesExample.UserEntities.Get());

            _dbContext.Orders.AddRange(Domain.EntitiesExample.OrderEntities.Get());
            _dbContext.ProductOrders.AddRange(Domain.EntitiesExample.ProductOrderEntities.Get());
            _dbContext.HistoryOfOrderStatus.AddRange(Domain.EntitiesExample.OrderStatusHistoryEntities.Get());

            _dbContext.SaveChanges();
            _dbContext.Database.CommitTransaction();
        }
    }
}
