using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagementSystem.Domain.Entities;

namespace TaskManagementSystem.DAL.Configurations;

public class AutomationRuleColumnConfiguration : IEntityTypeConfiguration<AutomationRuleColumn>
{
    public void Configure(EntityTypeBuilder<AutomationRuleColumn> builder)
    {
        builder.ToTable("AutomationRuleColumns");
        builder.HasKey(x => new { x.RuleId, x.ColumnId });

        builder.HasOne(x => x.AutomationRule)
               .WithMany(r => r.AutomationRuleColumns)
               .HasForeignKey(x => x.RuleId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.BoardColumn)
               .WithMany()
               .HasForeignKey(x => x.ColumnId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
