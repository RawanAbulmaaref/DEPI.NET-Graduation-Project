using System.ComponentModel.DataAnnotations.Schema;
namespace TaskManagementSystem.Domain.Entities;

public class TaskTemplate
{
    public int Id { get; set; }
    public int ProjectId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? DefaultTitle { get; set; }
    public string? DefaultDescription { get; set; }
    public string? DefaultPriority { get; set; }
    public double? DefaultEstimatedHours { get; set; }
    public string? RecurrenceType { get; set; }
    public int? RecurrenceInterval { get; set; }

    [ForeignKey(nameof(ProjectId))]
    public Project Project { get; set; } = null!;

    public ICollection<TaskTemplateChecklistItem> ChecklistItems { get; set; } = new List<TaskTemplateChecklistItem>();
    public ICollection<TaskItem> Tasks { get; set; } = new List<TaskItem>();
}