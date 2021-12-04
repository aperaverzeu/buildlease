using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Persistence.Configurations
{
    class CategoryBuilder : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder .ToTable("Category")
                    .HasKey(e => e.Id);

            builder .Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .IsRequired();

            builder .Property(e => e.ParentId)
                    .IsRequired();

            builder .Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

            builder .Property(e => e.DefaultImagePath)
                    .IsRequired(false)
                    .HasDefaultValue(null)
                    .HasMaxLength(500);

            builder .HasOne<Category>(sc => sc.ParentCategory)
                    .WithMany(c => c.SubCategories)
                    .HasForeignKey(sc => sc.ParentId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
