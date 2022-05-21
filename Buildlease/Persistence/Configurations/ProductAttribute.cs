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

            builder .Property(e => e.ValueNumber)
                    .IsRequired(false)
                    .HasDefaultValue(null)
                    .HasPrecision(10, 5)
                    .HasConversion(new 
                        Microsoft.EntityFrameworkCore.Storage.ValueConversion.
                        ValueConverter<decimal, decimal> (
                            (x) => decimal.Parse(x.ToString("G29")),
                            (x) => decimal.Parse(x.ToString("G29"))
                    ));

            builder .Property(e => e.ValueString)
                    .IsRequired(false)
                    .HasDefaultValue(null)
                    .HasMaxLength(100);

            builder .HasOne<Attribute>(pa => pa.Attribute)
                    .WithMany(a => a.ProductAttributes)
                    .HasForeignKey(pa => pa.AttributeId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Cascade);

            builder .HasOne<Product>(pa => pa.Product)
                    .WithMany(p => p.ProductAttributes)
                    .HasForeignKey(pa => pa.ProductId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}
