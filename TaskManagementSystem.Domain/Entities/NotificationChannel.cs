
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManagementSystem.Domain.Entities;

public class NotificationChannel
{
    public int Id { get; set; }

    public int NotificationId { get; set; }

    public string Channel { get; set; } = string.Empty;

    [ForeignKey(nameof(NotificationId))]
    public Notification Notification { get; set; } = null!;
}
