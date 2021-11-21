namespace Services.Abstractions
{
    public interface IServiceManager
    {
        IDatabaseTestService DatabaseTestService { get; }
        ITestService TestService { get; }
        ICatalogueService CatalogueService { get; }
        IOrderService OrderService { get; }
    }
}
