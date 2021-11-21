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
        private readonly ICatalogueService _catalogue;

        public DatabaseTestService(ApplicationDbContext dbContext, ICatalogueService catalogue)
        {
            _dbContext = dbContext;
            _catalogue = catalogue;
        }

        public void DoTest()
        {
            var GetAllCategories = _catalogue.GetAllCategories();

            var GetCategoryFilters = _catalogue.GetCategoryFilters(1);
            GetCategoryFilters = _catalogue.GetCategoryFilters(3);

            var GetProduct = _catalogue.GetProduct(1);
            GetProduct = _catalogue.GetProduct(13);

            var GetProducts = _catalogue.GetProducts(new GetProductsRequest() 
            {
                CategoryId = 1,
                OrderByRule = SortRule.Default,
                SkipCount = 10,
                TakeCount = 10,
            });
            GetProducts = _catalogue.GetProducts(new GetProductsRequest()
            {
                CategoryId = 2,
                OrderByRule = SortRule.PriceAscending,
                SkipCount = 0,
                TakeCount = 1,
            });
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

            _dbContext.SaveChanges();
            _dbContext.Database.CommitTransaction();
        }
    }
}
