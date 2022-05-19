namespace Services.Abstractions
{
    public interface IServiceManager
    {
        IAuthService AuthService { get; }
        IAdminService AdminService { get; }
        ICatalogueService CatalogueService { get; }
        IOrderService OrderService { get; }
        IMakingOrderService MakingOrderService { get; }
        ICustomerInfoService CustomerInfoService { get; }
        ICategoryInfoService CategoryInfoService { get; }
        IProductInfoService ProductInfoService { get; }
    }
}
