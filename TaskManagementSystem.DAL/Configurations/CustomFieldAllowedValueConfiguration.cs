using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagementSystem.Domain.Entities;

namespace TaskManagementSystem.DAL.Configurations;

public class CustomFieldAllowedValueConfiguration : IEntityTypeConfiguration<CustomFieldAllowedValue>
{
    public void Configure(EntityTypeBuilder<CustomFieldAllowedValue> builder)
    {
        builder.ToTable("CustomFieldAllowedValues");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Value).IsRequired().HasMaxLength(200);

        builder.HasOne(x => x.CustomField)
               .WithMany()
               .HasForeignKey(x => x.CustomFieldId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}