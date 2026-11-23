using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManagementSystem.Domain.Entities;

public class Board
{
    public int Id { get; set; }
    public int ProjectId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public int DisplayOrder { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [ForeignKey(nameof(ProjectId))]
    public Project Project { get; set; } = null!;

    public ICollection<BoardColumn> Columns { get; set; } = new List<BoardColumn>();
    public ICollection<Swimlane> Swimlanes { get; set; } = new List<Swimlane>();
}
