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
        private readonly Lazy<IMakingOrderService> _lazyMakingOrderService;
        private readonly Lazy<ICustomerInfoService> _lazyCustomerInfoService;

        public ServiceManager(ApplicationDbContext dbContext)
        {
            _lazyDatabaseTestService = new Lazy<IDatabaseTestService>(() => new DatabaseTestService(dbContext, this));
            _lazyTestService = new Lazy<ITestService>(() => new TestService());
            _lazyCatalogueService = new Lazy<ICatalogueService>(() => new CatalogueService(dbContext, this));
            _lazyOrderService = new Lazy<IOrderService>(() => new OrderService(dbContext, this));
            _lazyMakingOrderService = new Lazy<IMakingOrderService>(() => new MakingOrderService(dbContext, this));
            _lazyCustomerInfoService = new Lazy<ICustomerInfoService>(() => new CustomerInfoService(dbContext, this));
        }

        public IDatabaseTestService DatabaseTestService => _lazyDatabaseTestService.Value;
        public ITestService TestService => _lazyTestService.Value;
        public ICatalogueService CatalogueService => _lazyCatalogueService.Value;
        public IOrderService OrderService => _lazyOrderService.Value;
        public IMakingOrderService MakingOrderService => _lazyMakingOrderService.Value;
        public ICustomerInfoService CustomerInfoService => _lazyCustomerInfoService.Value;
    }
}
