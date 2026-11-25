using System.ComponentModel.DataAnnotations.Schema;
namespace TaskManagementSystem.Domain.Entities;

public class TaskAssignee
{
    public int TaskId { get; set; }
    public string UserId { get; set; } = string.Empty;
    public DateTime AssignedAt { get; set; } = DateTime.UtcNow;

    [ForeignKey(nameof(TaskId))]
    public TaskItem Task { get; set; } = null!;

    [ForeignKey(nameof(UserId))]
    public ApplicationUser User { get; set; } = null!;
}