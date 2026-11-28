using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagementSystem.Domain.Entities;

namespace TaskManagementSystem.DAL.Configurations;

public class TimeEntryConfiguration : IEntityTypeConfiguration<TimeEntry>
{
    public void Configure(EntityTypeBuilder<TimeEntry> builder)
    {
        // Table
        builder.ToTable("TimeEntries");

        // Primary Key
        builder.HasKey(te => te.Id);

        // Properties
        builder.Property(te => te.UserId)
               .IsRequired()
               .HasMaxLength(450);

        builder.Property(te => te.StartedAt)
               .IsRequired()
               .HasColumnType("datetime2");

        builder.Property(te => te.EndedAt)
               .IsRequired(false)
               .HasColumnType("datetime2");

        builder.Property(te => te.DurationMinutes)
               .IsRequired();

        builder.Property(te => te.EntryMethod)
               .IsRequired()
               .HasMaxLength(20);

        builder.Property(te => te.WorkNote)
               .IsRequired(false)
               .HasMaxLength(500);

        // Relationships
        builder.HasOne(te => te.Task)
               .WithMany()
               .HasForeignKey(te => te.TaskId);

        builder.HasOne(te => te.User)
               .WithMany()
               .HasForeignKey(te => te.UserId);
    }
}