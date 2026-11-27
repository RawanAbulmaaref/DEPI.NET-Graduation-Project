
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManagementSystem.Domain.Entities;

public class ActivityLogEntry
{
    public int Id { get; set; }

    public string? UserId { get; set; }

    public int? TaskId { get; set; }

    public int? ProjectId { get; set; }

    public string ActionType { get; set; } = string.Empty;

    public DateTime Timestamp { get; set; } = DateTime.UtcNow;

    public string? Description { get; set; }

    public string? EntityName { get; set; }

    public int? EntityId { get; set; }

    public string? OldValues { get; set; }

    public string? NewValues { get; set; }

    [ForeignKey(nameof(UserId))]
    public ApplicationUser? User { get; set; }

    [ForeignKey(nameof(TaskId))]
    public TaskItem? Task { get; set; }

    [ForeignKey(nameof(ProjectId))]
    public Project? Project { get; set; }
}
