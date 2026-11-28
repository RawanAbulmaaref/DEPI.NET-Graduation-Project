using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManagementSystem.Domain.Entities;

public class AutomationRule
{
    public int Id { get; set; }

    public int ProjectId { get; set; }

    public int? WebhookId { get; set; }

    public string? AutoAssignUserId { get; set; }

    public string Name { get; set; } = string.Empty;

    public string TriggerType { get; set; } = string.Empty;

    public string ActionType { get; set; } = string.Empty;

    public int? DueDateLeadMinutes { get; set; }

    public bool IsEnabled { get; set; }

    public DateTime CreatedAt { get; set; }

    [ForeignKey(nameof(ProjectId))]
    public Project Project { get; set; } = null!;

    [ForeignKey(nameof(WebhookId))]
    public Webhook? Webhook { get; set; }

    [ForeignKey(nameof(AutoAssignUserId))]
    public ApplicationUser? AutoAssignUser { get; set; }

    public ICollection<AutomationRuleLabel> AutomationRuleLabels { get; set; }
        = new List<AutomationRuleLabel>();

    public ICollection<AutomationRuleColumn> AutomationRuleColumns { get; set; }
        = new List<AutomationRuleColumn>();
}
