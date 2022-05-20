using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Models;

namespace Persistence.Configurations
{
    class ExceptionLogBuilder : IEntityTypeConfiguration<ExceptionLog>
    {
        public void Configure(EntityTypeBuilder<ExceptionLog> builder)
        {
            builder .ToTable("ExceptionLog")
                    .HasKey(e => e.Id);

            builder .Property(e => e.Id)
                    .ValueGeneratedNever()
                    .IsRequired();
        }
    }
}
