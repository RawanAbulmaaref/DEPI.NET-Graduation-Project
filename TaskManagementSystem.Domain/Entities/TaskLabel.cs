using System.ComponentModel.DataAnnotations.Schema;
namespace TaskManagementSystem.Domain.Entities;

//Composite key (TaskId, LabelId)
//Task,Label >> M:N 
public class TaskLabel
{
    public int TaskId { get; set; }
    public int LabelId { get; set; }

    [ForeignKey(nameof(TaskId))]
    public TaskItem Task { get; set; } = null!;

    [ForeignKey(nameof(LabelId))]
    public Label Label { get; set; } = null!;
}