
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManagementSystem.Domain.Entities;

public class NotificationPreference
{
    public int Id { get; set; }

    public string UserId { get; set; } = string.Empty;

    public string NotificationType { get; set; } = string.Empty;

    public bool InAppEnabled { get; set; }

    public bool EmailEnabled { get; set; }

    public string DigestFrequency { get; set; } = string.Empty;

    public int? ReminderLeadMinutes { get; set; }

    [ForeignKey(nameof(UserId))]
    public ApplicationUser User { get; set; } = null!;
}
