using Persistence;
using Services.Abstractions;
using System;

namespace Services
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<IDatabaseTestService> _lazyDatabaseTestService;
        private readonly Lazy<ITestService> _lazyTestService;
        private readonly Lazy<ICatalogueService> _lazyCatalogueService;
        private readonly Lazy<IOrderService> _lazyOrderService;

        public ServiceManager(ApplicationDbContext dbContext)
        {
            _lazyDatabaseTestService = new Lazy<IDatabaseTestService>(() => new DatabaseTestService(dbContext, OrderService));
            _lazyTestService = new Lazy<ITestService>(() => new TestService());
            _lazyCatalogueService = new Lazy<ICatalogueService>(() => new CatalogueService(dbContext));
            _lazyOrderService = new Lazy<IOrderService>(() => new OrderService(dbContext));
        }

        public IDatabaseTestService DatabaseTestService => _lazyDatabaseTestService.Value;
        public ITestService TestService => _lazyTestService.Value;
        public ICatalogueService CatalogueService => _lazyCatalogueService.Value;
        public IOrderService OrderService => _lazyOrderService.Value;
    }
}
