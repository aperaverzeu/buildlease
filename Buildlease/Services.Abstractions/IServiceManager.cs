namespace Services.Abstractions
{
    public interface IServiceManager
    {
        ITestService TestService { get; }
        ICatalogueService CatalogueService { get; }
        IOrderService OrderService { get; }
    }
}
