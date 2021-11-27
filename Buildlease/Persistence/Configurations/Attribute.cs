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
            builder.ToTable("Attribute")
                    .HasKey(e => e.Id);

            builder.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .IsRequired();

            builder.Property(e => e.CategoryId)
                    .IsRequired()
                    .HasDefaultValue(1);

            builder.HasOne<Category>(e => e.Category)
                    .WithMany(e => e.Attributes)
                    .HasForeignKey(e => e.CategoryId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
