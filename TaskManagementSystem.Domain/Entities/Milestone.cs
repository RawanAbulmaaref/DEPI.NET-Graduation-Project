using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManagementSystem.Domain.Entities;

public class Milestone
{
    public int Id { get; set; }
    public int ProjectId { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateOnly MilestoneDate { get; set; }
    public string? Description { get; set; }
    public string Status { get; set; } = "Pending";

    [ForeignKey(nameof(ProjectId))]
    public Project Project { get; set; } = null!;
}
