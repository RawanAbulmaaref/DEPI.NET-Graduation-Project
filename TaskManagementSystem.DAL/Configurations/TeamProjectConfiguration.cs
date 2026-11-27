using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagementSystem.Domain.Entities;

namespace TaskManagementSystem.DAL.Configurations;

public class TeamProjectConfiguration : IEntityTypeConfiguration<TeamProject>
{
    public void Configure(EntityTypeBuilder<TeamProject> builder)
    {
        builder.ToTable("TeamProjects");
        builder.HasKey(x => new { x.TeamId, x.ProjectId });

        builder.HasOne(x => x.Team)
               .WithMany(t => t.TeamProjects)
               .HasForeignKey(x => x.TeamId)
               .OnDelete(DeleteBehavior.Cascade);

        // Restrict: avoids SQL Server "multiple cascade paths"
        // (Workspace -> Team -> TeamProject and Workspace -> Project -> TeamProject).
        // Delete the TeamProjects rows in code before deleting a Project.
        builder.HasOne(x => x.Project)
               .WithMany(p => p.TeamProjects)
               .HasForeignKey(x => x.ProjectId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
