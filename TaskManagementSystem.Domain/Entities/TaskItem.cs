using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace TaskManagementSystem.Domain.Entities;

public class TaskItem
{
    public int Id { get; set; }
    public int ColumnId { get; set; }
    public int? SwimlaneId { get; set; }
    public int? SprintId { get; set; }
    public int? MilestoneId { get; set; }
    public int? TaskTemplateId { get; set; }
    public string CreatedById { get; set; } = string.Empty;

    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string Priority { get; set; } = "Medium";
    public DateTime? StartDate { get; set; }
    public DateTime? DueDate { get; set; }
    public double? EstimatedHours { get; set; }
    public int BoardPosition { get; set; }
    public bool IsArchived { get; set; }
    public DateTime? ArchivedAt { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? CompletedAt { get; set; }
    public DateTime LastModifiedAt { get; set; } = DateTime.UtcNow;

    [Timestamp]
    public byte[] RowVersion { get; set; } = null!;

    [ForeignKey(nameof(ColumnId))]
    public BoardColumn Column { get; set; } = null!;

    [ForeignKey(nameof(SwimlaneId))]
    public Swimlane? Swimlane { get; set; }

    [ForeignKey(nameof(SprintId))]
    public Sprint? Sprint { get; set; }

    [ForeignKey(nameof(MilestoneId))]
    public Milestone? Milestone { get; set; }

    [ForeignKey(nameof(TaskTemplateId))]
    public TaskTemplate? TaskTemplate { get; set; }

    [ForeignKey(nameof(CreatedById))]
    public ApplicationUser CreatedBy { get; set; } = null!;

    public ICollection<ChecklistItem> ChecklistItems { get; set; } = new List<ChecklistItem>();
    public ICollection<TaskAssignee> Assignees { get; set; } = new List<TaskAssignee>();
    public ICollection<TaskLabel> Labels { get; set; } = new List<TaskLabel>();
    public ICollection<TaskCustomFieldValue> CustomFieldValues { get; set; } = new List<TaskCustomFieldValue>();
    public ICollection<TaskDependency> Predecessors { get; set; } = new List<TaskDependency>();
    public ICollection<TaskDependency> Successors { get; set; } = new List<TaskDependency>();
}