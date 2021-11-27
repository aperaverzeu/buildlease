using Domain.Models;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Persistence
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public DbSet<TestModel> TestModels { get; set; }

        public DbSet<Attribute> Attributes { get; set; }
        public DbSet<Category> Categories { get; set; }
        //public DbSet<Address> CustomerAddresses { get; set; }
        //public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductAttribute> ProductAttributes { get; set; }
        public DbSet<ProductOrder> ProductOrders { get; set; }

        public DbSet<HistoryOfOrderStatus> HistoryOfOrderStatus { get; set; }

        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions)
            : base(options, operationalStoreOptions)
        {
        }

        /// <summary> This method is called only once after program start </summary>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            foreach (var asm in System.AppDomain.CurrentDomain.GetAssemblies())
            {
                builder.ApplyConfigurationsFromAssembly(asm);
            }
        }
    }
}