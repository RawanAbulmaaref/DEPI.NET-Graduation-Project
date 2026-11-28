using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagementSystem.Domain.Entities;

namespace TaskManagementSystem.DAL.Configurations;

public class NotificationPreferenceConfiguration
    : IEntityTypeConfiguration<NotificationPreference>
{
    public void Configure(EntityTypeBuilder<NotificationPreference> builder)
    {
        // Table
        builder.ToTable("NotificationPreferences");

        // Primary Key
        builder.HasKey(np => np.Id);

        // Properties
        builder.Property(np => np.UserId)
               .IsRequired()
               .HasMaxLength(450);

        builder.Property(np => np.NotificationType)
               .IsRequired()
               .HasMaxLength(50);

        builder.Property(np => np.InAppEnabled)
               .IsRequired();

        builder.Property(np => np.EmailEnabled)
               .IsRequired();

        builder.Property(np => np.DigestFrequency)
               .IsRequired()
               .HasMaxLength(20);

        builder.Property(np => np.ReminderLeadMinutes)
               .IsRequired(false);

        // Unique Index
        builder.HasIndex(np => new { np.UserId, np.NotificationType })
               .IsUnique();

        // User Relationship
        builder.HasOne(np => np.User)
               .WithMany()
               .HasForeignKey(np => np.UserId);
    }
}