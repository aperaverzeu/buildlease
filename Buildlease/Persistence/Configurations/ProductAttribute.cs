using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Persistence.Configurations
{
    class ProductAttributeBuilder : IEntityTypeConfiguration<ProductAttribute>
    {
        public void Configure(EntityTypeBuilder<ProductAttribute> builder)
        {
            builder.ToTable("ProductAttribute")
                    .HasKey(e => e.Id);

            builder.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .IsRequired();

            builder.Property(e => e.ProductId)
                    .IsRequired()
                    .HasDefaultValue(1);

            builder.Property(e => e.AttributeId)
                    .IsRequired()
                    .HasDefaultValue(1);

            builder.HasOne<Attribute>(e => e.Attribute)
                    .WithOne(e => e.ProductAttribute)
                    .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne<Product>(e => e.Product)
                    .WithOne(e => e.ProductAttribute)
                    .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
