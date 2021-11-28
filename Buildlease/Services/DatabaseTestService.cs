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
        private readonly IServiceManager _manager;

        public DatabaseTestService(ApplicationDbContext dbContext, IServiceManager manager)
        {
            _dbContext = dbContext;
            _manager = manager;
        }

        public void DoTest(string userId)
        {
            var service = _manager.CustomerService;

            var info = service.GetMyCustomerInfo(userId);

            var addresses = info.DeliveryAddresses
                .Append(info.JuridicalAddress ?? 
                new Contracts.DTOs.AddressInfo()
                {
                    PostalCode = "42",
                })
                .ToArray();
            info.JuridicalAddress = addresses.First();
            info.DeliveryAddresses = addresses.Skip(1).ToArray();

            service.SaveMyCustomerInfo(info);
            info = service.GetMyCustomerInfo(userId);
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

            _dbContext.Customers.AddRange(Domain.EntitiesExample.CustomerEntities.Get());
            _dbContext.CustomerAddresses.AddRange(Domain.EntitiesExample.AddressEntities.Get());

            _dbContext.SaveChanges();
            _dbContext.Database.CommitTransaction();
        }
    }
}
