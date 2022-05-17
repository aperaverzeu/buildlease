using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Persistence.Configurations
{
    class HistoryOfOrderStatusBuilder : IEntityTypeConfiguration<HistoryOfOrderStatus>
    {
        public void Configure(EntityTypeBuilder<HistoryOfOrderStatus> builder)
        {
            builder .ToTable("HistoryOfOrderStatus")
                    .HasKey(e => e.Id);

            builder .Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .IsRequired();

            builder .Property(e => e.OrderId)
                    .IsRequired();

            builder .Property(e => e.Date)
                    .IsRequired();

            builder .Property(e => e.NewStatus)
                    .IsRequired();

            builder .HasOne<Order>(h => h.Order)
                    .WithMany(o => o.HistoryOfOrderStatus)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}
