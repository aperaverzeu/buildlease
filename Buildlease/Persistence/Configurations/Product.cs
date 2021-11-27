using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Persistence.Configurations
{
    class ProductBuilder : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product")
                    .HasKey(e => e.Id);

            builder.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .IsRequired();

            builder.Property(e => e.CategoryId)
                    .IsRequired()
                    .HasDefaultValue(1);

            builder.Property(e => e.Name)
                   .IsRequired();

            builder.Property(e => e.CategoryId)
                    .IsRequired();

            builder.HasOne<Category>(e => e.Category)
                    .WithMany(e => e.Products)
                    .HasForeignKey(e => e.CategoryId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
