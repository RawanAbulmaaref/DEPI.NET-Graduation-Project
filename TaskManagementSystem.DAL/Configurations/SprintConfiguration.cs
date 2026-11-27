using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagementSystem.Domain.Entities;

namespace TaskManagementSystem.DAL.Configurations;

public class SprintConfiguration : IEntityTypeConfiguration<Sprint>
{
    public void Configure(EntityTypeBuilder<Sprint> builder)
    {
        builder.ToTable("Sprints");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
        builder.Property(x => x.StartDate).IsRequired().HasColumnType("date");
        builder.Property(x => x.EndDate).IsRequired().HasColumnType("date");
        builder.Property(x => x.Goal).HasMaxLength(500);

        builder.HasOne(x => x.Project)
               .WithMany(p => p.Sprints)
               .HasForeignKey(x => x.ProjectId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
