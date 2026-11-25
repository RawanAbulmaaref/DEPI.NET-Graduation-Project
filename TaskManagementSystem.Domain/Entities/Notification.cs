
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManagementSystem.Domain.Entities;

public class Notification
{
    public int Id { get; set; }

    public string UserId { get; set; } = string.Empty;

    public int? TaskId { get; set; }
    public int? CommentId { get; set; }

    public string Type { get; set; } = string.Empty;
    public string MessageText { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public bool IsRead { get; set; }

    [ForeignKey(nameof(UserId))]
    public ApplicationUser User { get; set; } = null!;

    [ForeignKey(nameof(TaskId))]
    public TaskItem? Task { get; set; }

    [ForeignKey(nameof(CommentId))]
    public Comment? Comment { get; set; }

    public ICollection<NotificationChannel> Channels { get; set; }
        = new List<NotificationChannel>();
}
