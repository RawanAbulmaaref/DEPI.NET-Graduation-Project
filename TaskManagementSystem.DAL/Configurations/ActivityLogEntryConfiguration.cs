using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagementSystem.Domain.Entities;

namespace TaskManagementSystem.DAL.Configurations;

public class ActivityLogEntryConfiguration
    : IEntityTypeConfiguration<ActivityLogEntry>
{
    public void Configure(EntityTypeBuilder<ActivityLogEntry> builder)
    {
        // Table
        builder.ToTable("ActivityLogEntries");

        // Primary Key
        builder.HasKey(a => a.Id);

        // Properties
        builder.Property(a => a.UserId)
               .IsRequired(false)
               .HasMaxLength(450);

        builder.Property(a => a.ActionType)
               .IsRequired()
               .HasMaxLength(50);

        builder.Property(a => a.Timestamp)
               .IsRequired()
               .HasColumnType("datetime2");

        builder.Property(a => a.Description)
               .IsRequired(false)
               .HasMaxLength(500);

        builder.Property(a => a.EntityName)
               .IsRequired(false)
               .HasMaxLength(100);

        builder.Property(a => a.EntityId)
               .IsRequired(false);

        builder.Property(a => a.OldValues)
               .IsRequired(false)
               .HasColumnType("nvarchar(max)");

        builder.Property(a => a.NewValues)
               .IsRequired(false)
               .HasColumnType("nvarchar(max)");

        // User Relationship
        builder.HasOne(a => a.User)
               .WithMany()
               .HasForeignKey(a => a.UserId)
               .IsRequired(false);

        // Task Relationship
        builder.HasOne(a => a.Task)
               .WithMany()
               .HasForeignKey(a => a.TaskId)
               .IsRequired(false);

        // Project Relationship
        builder.HasOne(a => a.Project)
               .WithMany()
               .HasForeignKey(a => a.ProjectId)
               .IsRequired(false);
    }
}