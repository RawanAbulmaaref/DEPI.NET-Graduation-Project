using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagementSystem.Domain.Entities;

namespace TaskManagementSystem.DAL.Configurations;

public class NotificationChannelConfiguration : IEntityTypeConfiguration<NotificationChannel>
{
    public void Configure(EntityTypeBuilder<NotificationChannel> builder)
    {
        // Table
        builder.ToTable("NotificationChannels");

        // Primary Key
        builder.HasKey(nc => nc.Id);

        // Properties
        builder.Property(nc => nc.NotificationId)
               .IsRequired();

        builder.Property(nc => nc.Channel)
               .IsRequired()
               .HasMaxLength(20);

        // Relationship
        builder.HasOne(nc => nc.Notification)
               .WithMany(n => n.Channels)
               .HasForeignKey(nc => nc.NotificationId);
    }
}