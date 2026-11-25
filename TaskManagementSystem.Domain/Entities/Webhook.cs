using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManagementSystem.Domain.Entities;

public class Webhook
{
    public int Id { get; set; }

    public int ProjectId { get; set; }

    public string Name { get; set; } = string.Empty;

    public string TargetUrl { get; set; } = string.Empty;

    public bool IsActive { get; set; }

    [ForeignKey(nameof(ProjectId))]
    public Project Project { get; set; } = null!;

    public ICollection<WebhookEvent> WebhookEvents { get; set; }
        = new List<WebhookEvent>();

    public ICollection<AutomationRule> AutomationRules { get; set; }
        = new List<AutomationRule>();
}