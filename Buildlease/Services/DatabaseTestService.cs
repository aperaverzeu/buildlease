using Contracts.Requests;
using Contracts.Views;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Services.Abstractions;
using System;
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
            /*
            TestCatalogueService(userId);
            TestOrderService(userId);
            TestCustomerInfoService(userId);
            TestMakingOrderService(userId);
            */
            TestCategoryInfoService(userId);
            TestProductInfoService(userId);
        }

        private void TestCatalogueService(string userId)
        {
            var service = _manager.CatalogueService;

            var GetAllCategories = service.GetAllCategories();

            var GetCategoryFilters = service.GetCategoryFilters(-1);
            GetCategoryFilters = service.GetCategoryFilters(-3);

            var GetProduct = service.GetProduct(-1, userId);
            GetProduct = service.GetProduct(-13, userId);

            var GetProducts = service.GetProducts(new GetProductsRequest()
            {
                CategoryId = 1,
                OrderByRule = SortRule.Default,
                SkipCount = 10,
                TakeCount = 10,
            }, userId);
            GetProducts = service.GetProducts(new GetProductsRequest()
            {
                CategoryId = 2,
                OrderByRule = SortRule.PriceAscending,
                SkipCount = 0,
                TakeCount = 1,
            }, userId);
        }
        private void TestOrderService(string userId)
        {
            var service = _manager.OrderService;

            var GetMyOrders = service.GetMyOrders(userId);

            var GetMyCart = service.GetMyCart(userId);

            var myOrdersIds = Domain.EntitiesExample.OrderEntities.Get().Where(o => o.CustomerId == userId).Select(o => o.Id);
            foreach (var orderId in myOrdersIds)
            {
                var GetOrder = service.GetOrder(userId, orderId);
            }
        }
        private void TestCustomerInfoService(string userId)
        {
            var service = _manager.CustomerInfoService;

            var info = service.GetCustomerInfo(userId);

            var addresses = info.DeliveryAddresses
                .Append(info.JuridicalAddress ??
                new Contracts.DTOs.AddressInfo()
                {
                    PostalCode = "PostalCode",
                    Building = "Building",
                    City = "City",
                    Office = "Office",
                    Street = "Street"
                })
                .ToArray();
            info.JuridicalAddress = addresses.First();
            info.DeliveryAddresses = addresses.Skip(1).ToArray();

            service.SaveCustomerInfo(info);
            info = service.GetCustomerInfo(userId);
        }
        private void TestMakingOrderService(string userId)
        {
            var service = _manager.MakingOrderService;

            service.SetProductOrderCount(userId, -1, 42);

            try { service.MakeOrderFromCart(userId, DateTime.UtcNow.AddMonths(1), DateTime.UtcNow.AddYears(1)); } 
            catch (InvalidOperationException) 
            { }

            foreach (var orderId in _manager.OrderService.GetMyOrders(userId).Select(e => e.Id))
            {
                try { service.DeclineOrder(userId, orderId); } 
                catch (InvalidOperationException) 
                { }
            }
        }

        private void TestCategoryInfoService(string userId)
        {
            /*
            var service = _manager.CategoryInfoService;
            var info = service.GetCategoryInfo(4);
            service.SaveCategoryInfo(info);
            info = service.GetCategoryInfo(4);
            */
        }

        private void TestProductInfoService(string userId)
        {
            var service = _manager.ProductInfoService;
            var info = service.GetProductInfo(-13);
            service.SaveProductInfo(info);
            info = service.GetProductInfo(-13);
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
