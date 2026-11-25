using System.ComponentModel.DataAnnotations.Schema;
namespace TaskManagementSystem.Domain.Entities;

// The successor cannot start/finish until the predecessor does
// Composite key (SuccessorTaskId, PredecessorTaskId)
// 
public class TaskDependency
{
    public int SuccessorTaskId { get; set; }
    public int PredecessorTaskId { get; set; }
    public string DependencyType { get; set; } = "FinishToStart";
    public int LagMinutes { get; set; }

    [ForeignKey(nameof(SuccessorTaskId))]
    public TaskItem SuccessorTask { get; set; } = null!;

    [ForeignKey(nameof(PredecessorTaskId))]
    public TaskItem PredecessorTask { get; set; } = null!;
}