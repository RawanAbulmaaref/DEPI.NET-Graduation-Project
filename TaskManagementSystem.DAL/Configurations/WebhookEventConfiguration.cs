using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagementSystem.Domain.Entities;

namespace TaskManagementSystem.DAL.Configurations;

public class WebhookEventConfiguration : IEntityTypeConfiguration<WebhookEvent>
{
    public void Configure(EntityTypeBuilder<WebhookEvent> builder)
    {
        builder.ToTable("WebhookEvents");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.EventName)
               .IsRequired()
               .HasMaxLength(100);

        builder.HasOne(x => x.Webhook)
               .WithMany(w => w.WebhookEvents)
               .HasForeignKey(x => x.WebhookId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
