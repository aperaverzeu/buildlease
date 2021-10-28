using Contracts.Views;

namespace Services.Abstractions
{
    public interface ICatalogueService
    {
        CategoryFullView[] GetAllCategories();
        CategoryFilterView[] GetCategoryFilters(int categoryId);
        ProductView[] GetProducts();
        ProductFullView GetProduct(int productId);
    }
}
