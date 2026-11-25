using System.ComponentModel.DataAnnotations.Schema;
namespace TaskManagementSystem.Domain.Entities;

public class TaskTemplateChecklistItem
{
    public int Id { get; set; }
    public int TaskTemplateId { get; set; }
    public string Title { get; set; } = string.Empty;
    public int Position { get; set; }

    [ForeignKey(nameof(TaskTemplateId))]
    public TaskTemplate TaskTemplate { get; set; } = null!;
}