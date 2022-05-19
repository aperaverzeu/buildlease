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
            builder .ToTable("Product")
                    .HasKey(e => e.Id);

            builder .Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .IsRequired();

            builder .Property(e => e.CategoryId)
                    .IsRequired();

            builder .Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(500);

            builder .Property(e => e.Description)
                    .IsRequired()
                    .HasDefaultValue(string.Empty)
                    .HasMaxLength(int.MaxValue);

            builder .Property(e => e.ImagePath)
                    .IsRequired(false)
                    .HasDefaultValue(null)
                    .HasMaxLength(500);

            builder .Property(e => e.TotalCount)
                    .IsRequired();

            builder .Property(e => e.Price)
                    .IsRequired(false)
                    .HasPrecision(10, 2);

            builder .HasOne<Category>(p => p.Category)
                    .WithMany(c => c.Products)
                    .HasForeignKey(p => p.CategoryId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}
