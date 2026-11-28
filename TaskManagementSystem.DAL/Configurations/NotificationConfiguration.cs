using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagementSystem.Domain.Entities;

namespace TaskManagementSystem.DAL.Configurations;

public class NotificationConfiguration : IEntityTypeConfiguration<Notification>
{
    public void Configure(EntityTypeBuilder<Notification> builder)
    {
        // Table
        builder.ToTable("Notifications");

        // Primary Key
        builder.HasKey(n => n.Id);

        // Properties
        builder.Property(n => n.UserId)
               .IsRequired()
               .HasMaxLength(450);

        builder.Property(n => n.Type)
               .IsRequired()
               .HasMaxLength(50);

        builder.Property(n => n.MessageText)
               .IsRequired()
               .HasMaxLength(500);

        builder.Property(n => n.CreatedAt)
               .IsRequired()
               .HasColumnType("datetime2");

        builder.Property(n => n.IsRead)
               .IsRequired();

        // Relationships
        builder.HasOne(n => n.User)
               .WithMany()
               .HasForeignKey(n => n.UserId);

        builder.HasOne(n => n.Task)
               .WithMany()
               .HasForeignKey(n => n.TaskId)
               .IsRequired(false);

        builder.HasOne(n => n.Comment)
               .WithMany()
               .HasForeignKey(n => n.CommentId)
               .IsRequired(false);

        builder.HasMany(n => n.Channels)
               .WithOne(nc => nc.Notification)
               .HasForeignKey(nc => nc.NotificationId);
    }
}