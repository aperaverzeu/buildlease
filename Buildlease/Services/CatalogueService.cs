using Contracts.Views;
using Persistence;
using Services.Abstractions;

namespace Services
{
    internal sealed class CatalogueService : ICatalogueService
    {
        private readonly ApplicationDbContext _dbContext;

        public CatalogueService(ApplicationDbContext dbContext) => _dbContext = dbContext;

        public CategoryView[] GetAllCategories()
        {
            throw new System.NotImplementedException();
        }

        public CategoryFilterView[] GetCategoryFilters(int categoryId)
        {
            throw new System.NotImplementedException();
        }

        public ProductFullView GetProduct(int productId)
        {
            throw new System.NotImplementedException();
        }

        public ProductView[] GetProducts()
        {
            throw new System.NotImplementedException();
        }
    }
}
