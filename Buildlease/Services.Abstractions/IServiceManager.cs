namespace Services.Abstractions
{
    public interface IServiceManager
    {
        IAdminService AdminService { get; }
        IDatabaseTestService DatabaseTestService { get; }
        ITestService TestService { get; }
        ICatalogueService CatalogueService { get; }
        IOrderService OrderService { get; }
        IMakingOrderService MakingOrderService { get; }
        ICustomerInfoService CustomerInfoService { get; }
        ICategoryInfoService CategoryInfoService { get; }
        IProductInfoService ProductInfoService { get; }
    }
}
