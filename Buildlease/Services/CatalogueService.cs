using Contracts.Requests;
using Contracts.Views;
using Persistence;
using Services.Abstractions;

namespace Services
{
    internal sealed class CatalogueService : ICatalogueService
    {
        private readonly ApplicationDbContext _dbContext;

        public CatalogueService(ApplicationDbContext dbContext) => _dbContext = dbContext;

        public CategoryFullView[] GetAllCategories()
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

        public ProductView[] GetProducts(GetProductsRequest request)
        {
            throw new System.NotImplementedException();
        }
    }
}
