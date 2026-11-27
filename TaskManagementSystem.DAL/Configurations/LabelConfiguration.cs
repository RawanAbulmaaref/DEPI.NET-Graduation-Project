using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagementSystem.Domain.Entities;

namespace TaskManagementSystem.DAL.Configurations;

public class LabelConfiguration : IEntityTypeConfiguration<Label>
{
    public void Configure(EntityTypeBuilder<Label> builder)
    {
        builder.ToTable("Labels");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
        builder.Property(x => x.Color).IsRequired().HasMaxLength(7);   // e.g. #FF5733
        builder.Property(x => x.Description).HasMaxLength(200);

        builder.HasOne(x => x.Project)
               .WithMany(p => p.Labels)
               .HasForeignKey(x => x.ProjectId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
