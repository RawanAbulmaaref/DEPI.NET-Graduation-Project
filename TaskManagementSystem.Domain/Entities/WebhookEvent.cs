using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManagementSystem.Domain.Entities;

public class WebhookEvent
{
    public int Id { get; set; }

    public int WebhookId { get; set; }

    public string EventName { get; set; } = string.Empty;

    [ForeignKey(nameof(WebhookId))]
    public Webhook Webhook { get; set; } = null!;
}