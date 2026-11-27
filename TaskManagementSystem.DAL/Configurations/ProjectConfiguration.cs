using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagementSystem.Domain.Entities;

namespace TaskManagementSystem.DAL.Configurations;

public class ProjectConfiguration : IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> builder)
    {
        builder.ToTable("Projects");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name).IsRequired().HasMaxLength(200);
        builder.Property(x => x.Description).HasMaxLength(2000);

        builder.Property(x => x.PlannedStartDate).HasColumnType("date");
        builder.Property(x => x.PlannedEndDate).HasColumnType("date");

        builder.Property(x => x.SettingsJson);              // nvarchar(max)
        builder.Property(x => x.IsArchived).IsRequired();
        builder.Property(x => x.CreatedAt).IsRequired();

        builder.HasOne(x => x.Workspace)
               .WithMany(w => w.Projects)
               .HasForeignKey(x => x.WorkspaceId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.CreatedBy)
               .WithMany()
               .HasForeignKey(x => x.CreatedById)
               .OnDelete(DeleteBehavior.Restrict);

        // optional: project may be created without a template
        builder.HasOne(x => x.Template)
               .WithMany(t => t.Projects)
               .HasForeignKey(x => x.TemplateId)
               .OnDelete(DeleteBehavior.SetNull);
    }
}
