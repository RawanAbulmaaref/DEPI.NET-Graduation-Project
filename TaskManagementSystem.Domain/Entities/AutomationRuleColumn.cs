using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManagementSystem.Domain.Entities;

public class AutomationRuleColumn
{
    public int RuleId { get; set; }

    public int ColumnId { get; set; }

    [ForeignKey(nameof(RuleId))]
    public AutomationRule AutomationRule { get; set; } = null!;

    [ForeignKey(nameof(ColumnId))]
    public BoardColumn BoardColumn { get; set; } = null!;
}