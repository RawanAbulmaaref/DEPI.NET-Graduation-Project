
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManagementSystem.Domain.Entities;

public class TimeEntry
{
    public int Id { get; set; }

    public int TaskId { get; set; }
    public string UserId { get; set; } = string.Empty;

    public DateTime StartedAt { get; set; }
    public DateTime? EndedAt { get; set; }

    public int DurationMinutes { get; set; }

    public string EntryMethod { get; set; } = string.Empty;
    public string? WorkNote { get; set; }

    [ForeignKey(nameof(TaskId))]
    public TaskItem Task { get; set; } = null!;

    [ForeignKey(nameof(UserId))]
    public ApplicationUser User { get; set; } = null!;
}
