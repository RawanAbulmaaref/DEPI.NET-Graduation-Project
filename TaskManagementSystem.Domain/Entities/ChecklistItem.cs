using System.ComponentModel.DataAnnotations.Schema;
namespace TaskManagementSystem.Domain.Entities;

public class ChecklistItem
{
    public int Id { get; set; }
    public int TaskId { get; set; }
    public string Title { get; set; } = string.Empty;
    public bool IsCompleted { get; set; }
    public int Position { get; set; }
    public DateTime? CompletedAt { get; set; }

    [ForeignKey(nameof(TaskId))]
    public TaskItem Task { get; set; } = null!;
}