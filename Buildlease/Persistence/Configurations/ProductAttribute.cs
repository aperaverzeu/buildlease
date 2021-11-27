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
            builder .ToTable("ProductAttribute")
                    .HasKey(e => e.Id);

            builder .Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .IsRequired();

            builder .Property(e => e.ProductId)
                    .IsRequired();

            builder .Property(e => e.AttributeId)
                    .IsRequired();

            builder.Property(e => e.ValueString)
                    .HasMaxLength(100);

            builder .HasOne<Attribute>(pa => pa.Attribute)
                    .WithMany(a => a.ProductAttributes)
                    .IsRequired()
                    .HasForeignKey(e => e.AttributeId)
                    .OnDelete(DeleteBehavior.Cascade);

            builder .HasOne<Product>(pa => pa.Product)
                    .WithMany(p => p.ProductAttributes)
                    .IsRequired()
                    .HasForeignKey(e => e.ProductId)
                    .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
