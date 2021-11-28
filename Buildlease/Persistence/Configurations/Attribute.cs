using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Persistence.Configurations
{
    class AttributeBuilder : IEntityTypeConfiguration<Attribute>
    {
        public void Configure(EntityTypeBuilder<Attribute> builder)
        {
            builder .ToTable("Attribute")
                    .HasKey(e => e.Id);

            builder .Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .IsRequired();

            builder .Property(e => e.CategoryId)
                    .IsRequired();

            builder .Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

            builder .Property(e => e.ValueType)
                    .IsRequired()
                    .HasConversion<byte>();

            builder .Property(e => e.UnitName)
                    .IsRequired(false)
                    .HasDefaultValue(null)
                    .HasMaxLength(50);

            builder .HasOne<Category>(a => a.Category)
                    .WithMany(c => c.Attributes)
                    .HasForeignKey(a => a.CategoryId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
