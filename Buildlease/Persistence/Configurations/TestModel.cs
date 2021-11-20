using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configurations
{
    public class TestModelBuilder : IEntityTypeConfiguration<TestModel>
    {
        public void Configure(EntityTypeBuilder<TestModel> builder)
        {
            builder .ToTable("TestModel")
                    .HasKey(e => e.Id);

            builder .Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .IsRequired();

            builder .Property(e => e.ParentId)
                    .IsRequired()
                    .HasDefaultValue(1);

            builder .HasOne<TestModel>()
                    .WithMany()
                    .HasForeignKey(e => e.ParentId);
        }
    }
}
