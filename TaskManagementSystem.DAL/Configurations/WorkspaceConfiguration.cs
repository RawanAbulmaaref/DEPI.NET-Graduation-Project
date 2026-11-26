using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagementSystem.Domain.Entities;

namespace TaskManagementSystem.DAL.Configurations;

public class WorkspaceConfiguration : IEntityTypeConfiguration<Workspace>
{
    public void Configure(EntityTypeBuilder<Workspace> builder)
    {
        builder.ToTable("Workspaces");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name).IsRequired().HasMaxLength(200);
        builder.Property(x => x.Description).HasMaxLength(1000);
        builder.Property(x => x.SettingsJson);              // nvarchar(max)
        builder.Property(x => x.CreatedAt).IsRequired();

        builder.HasOne(x => x.Owner)
               .WithMany(u => u.OwnedWorkspaces)
               .HasForeignKey(x => x.OwnerId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
