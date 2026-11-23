using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManagementSystem.Domain.Entities;

// Unique index: (BoardId, Name)
public class Swimlane
{
    public int Id { get; set; }
    public int BoardId { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Position { get; set; }
    public string? CategorizationCriterion { get; set; }

    [ForeignKey(nameof(BoardId))]
    public Board Board { get; set; } = null!;
}
