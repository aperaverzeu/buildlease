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

        public DatabaseTestService(ApplicationDbContext dbContext) => _dbContext = dbContext;

        public void DoTest()
        {
            var test0 = _dbContext.TestModels.ToList();
            _dbContext.Database.BeginTransaction();
            _dbContext.TestModels.AddRange(new List<TestModel>() {
                new()
                {
                    Id = 1,
                    ParentId = 1,
                    Value = "42",
                },
                new()
                {
                    Id = 42,
                    ParentId = 1,
                    Value = "42",
                },
            });
            _dbContext.SaveChanges();
            _dbContext.Database.CommitTransaction();
            var test = _dbContext.TestModels.ToList();
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

            _dbContext.Categories.AddRange(Domain.Models.EntitiesExample.CategoryEntities.Get());
            _dbContext.Products.AddRange(Domain.Models.EntitiesExample.ProductEntities.Get());
            _dbContext.Attributes.AddRange(Domain.Models.EntitiesExample.AttributeEntities.Get());
            _dbContext.ProductAttributes.AddRange(Domain.Models.EntitiesExample.ProductAttributeEntities.Get());

            _dbContext.SaveChanges();
            _dbContext.Database.CommitTransaction();
        }
    }
}
