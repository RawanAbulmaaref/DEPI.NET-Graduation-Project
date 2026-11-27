using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagementSystem.Domain.Entities;

namespace TaskManagementSystem.DAL.Configurations;

public class AutomationRuleConfiguration : IEntityTypeConfiguration<AutomationRule>
{
    public void Configure(EntityTypeBuilder<AutomationRule> builder)
    {
        builder.ToTable("AutomationRules");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
        builder.Property(x => x.TriggerType).IsRequired().HasMaxLength(50);
        builder.Property(x => x.ActionType).IsRequired().HasMaxLength(50);
        builder.Property(x => x.IsEnabled).IsRequired();
        builder.Property(x => x.CreatedAt).IsRequired();

        builder.HasOne(x => x.Project)
               .WithMany()
               .HasForeignKey(x => x.ProjectId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Webhook)
               .WithMany(w => w.AutomationRules)
               .HasForeignKey(x => x.WebhookId)
               .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(x => x.AutoAssignUser)
               .WithMany()
               .HasForeignKey(x => x.AutoAssignUserId)
               .OnDelete(DeleteBehavior.SetNull);
    }
}
