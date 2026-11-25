using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManagementSystem.Domain.Entities;

public class AutomationRuleLabel
{
    public int RuleId { get; set; }

    public int LabelId { get; set; }

    [ForeignKey(nameof(RuleId))]
    public AutomationRule AutomationRule { get; set; } = null!;

    [ForeignKey(nameof(LabelId))]
    public Label Label { get; set; } = null!;
}
