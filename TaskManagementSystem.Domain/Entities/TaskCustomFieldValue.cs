using System.ComponentModel.DataAnnotations.Schema;
namespace TaskManagementSystem.Domain.Entities;

public class TaskCustomFieldValue
{
    public int TaskId { get; set; }
    public int CustomFieldId { get; set; }
    public string? Value { get; set; }

    [ForeignKey(nameof(TaskId))]
    public TaskItem Task { get; set; } = null!;

    [ForeignKey(nameof(CustomFieldId))]
    public CustomField CustomField { get; set; } = null!;
}