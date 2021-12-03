using Persistence;
using Services.Abstractions;
using System;

namespace Services
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<IAdminService> _lazyAdminService;
        private readonly Lazy<ICatalogueService> _lazyCatalogueService;
        private readonly Lazy<IOrderService> _lazyOrderService;
        private readonly Lazy<IMakingOrderService> _lazyMakingOrderService;
        private readonly Lazy<ICustomerInfoService> _lazyCustomerInfoService;
        private readonly Lazy<ICategoryInfoService> _lazyCategoryInfoService;
        private readonly Lazy<IProductInfoService> _lazyProductInfoService;

        public ServiceManager(ApplicationDbContext dbContext)
        {
            _lazyAdminService = new Lazy<IAdminService>(() => new AdminService(dbContext, this));
            _lazyCatalogueService = new Lazy<ICatalogueService>(() => new CatalogueService(dbContext, this));
            _lazyOrderService = new Lazy<IOrderService>(() => new OrderService(dbContext, this));
            _lazyMakingOrderService = new Lazy<IMakingOrderService>(() => new MakingOrderService(dbContext, this));
            _lazyCustomerInfoService = new Lazy<ICustomerInfoService>(() => new CustomerInfoService(dbContext, this));
            _lazyCategoryInfoService = new Lazy<ICategoryInfoService>(() => new CategoryInfoService(dbContext, this));
            _lazyProductInfoService = new Lazy<IProductInfoService>(() => new ProductInfoService(dbContext, this));
        }

        public IAdminService AdminService => _lazyAdminService.Value;
        public ICatalogueService CatalogueService => _lazyCatalogueService.Value;
        public IOrderService OrderService => _lazyOrderService.Value;
        public IMakingOrderService MakingOrderService => _lazyMakingOrderService.Value;
        public ICustomerInfoService CustomerInfoService => _lazyCustomerInfoService.Value;
        public ICategoryInfoService CategoryInfoService => _lazyCategoryInfoService.Value;
        public IProductInfoService ProductInfoService => _lazyProductInfoService.Value;
    }
}
