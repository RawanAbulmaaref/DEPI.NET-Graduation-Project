using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagementSystem.Domain.Entities;

namespace TaskManagementSystem.DAL.Configurations;

public class AutomationRuleLabelConfiguration : IEntityTypeConfiguration<AutomationRuleLabel>
{
    public void Configure(EntityTypeBuilder<AutomationRuleLabel> builder)
    {
        builder.ToTable("AutomationRuleLabels");
        builder.HasKey(x => new { x.RuleId, x.LabelId });

        builder.HasOne(x => x.AutomationRule)
               .WithMany(r => r.AutomationRuleLabels)
               .HasForeignKey(x => x.RuleId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Label)
               .WithMany()
               .HasForeignKey(x => x.LabelId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
