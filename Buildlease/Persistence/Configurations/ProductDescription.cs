using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Persistence.Configurations
{
    class ProductDescriptionBuilder : IEntityTypeConfiguration<ProductDescription>
    {
        public void Configure(EntityTypeBuilder<ProductDescription> builder)
        {
            builder .ToTable("ProductDescription")
                    .HasKey(e => e.Id);

            builder .Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .IsRequired();

            builder .Property(e => e.ProductId)
                    .IsRequired();

            builder .Property(e => e.LanguageId)
                    .IsRequired();

            builder .Property(e => e.Description)
                    .IsRequired()
                    .HasDefaultValue(string.Empty)
                    .HasMaxLength(int.MaxValue);

            builder.HasOne<Product>(pd => pd.Product)
                    .WithMany(p => p.ProductDescriptions)
                    .HasForeignKey(pd => pd.ProductId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.ClientCascade);

            builder .HasOne<Language>(pd => pd.Language)
                    .WithMany()
                    .HasForeignKey(pd => pd.LanguageId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}
