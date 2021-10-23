using Contracts.Views;

namespace Services.Abstractions
{
    public interface ICatalogueService
    {
        CaregoryView[] GetAllCategories();
        CategoryFilterView[] GetCategoryFilters(int categoryId);
        ProductView[] GetProducts();
        ProductFullView GetProduct(int productId);
    }
}
