using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManagementSystem.Domain.Entities;

public class Label
{
    public int Id { get; set; }
    public int ProjectId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Color { get; set; } = "#000000";
    public string? Description { get; set; }

    [ForeignKey(nameof(ProjectId))]
    public Project Project { get; set; } = null!;
}
