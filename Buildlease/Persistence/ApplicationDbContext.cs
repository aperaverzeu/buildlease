using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<ApplicationUser> Users { get; set; }

        public DbSet<Attribute> Attributes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Address> CustomerAddresses { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductAttribute> ProductAttributes { get; set; }
        public DbSet<ProductOrder> ProductOrders { get; set; }
        public DbSet<HistoryOfOrderStatus> HistoryOfOrderStatus { get; set; }

        public DbSet<Language> Languages { get; set; }
        public DbSet<ProductDescription> ProductDescriptions { get; set; }

        public DbSet<ExceptionLog> ExceptionLogs { get; set; }

        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {
            Database.Migrate();
        }

        /// <summary> This method is called only once after program start </summary>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            foreach (var asm in System.AppDomain.CurrentDomain.GetAssemblies())
            {
                builder.ApplyConfigurationsFromAssembly(asm);
            }

            builder .Entity<Category>()
                    .HasData(new Category 
                    { 
                        Id = -42,
                        ParentId = -42,
                        Name = "All",
                    });

            builder.Entity<Language>()
                    .HasData(new Language
                    {
                        Id = -1,
                        Name = "English",
                    });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(options => options.MigrationsAssembly("Buildlease"));
        }
    }
}