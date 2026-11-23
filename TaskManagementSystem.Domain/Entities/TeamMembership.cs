using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManagementSystem.Domain.Entities;

// Unique index: (TeamId, UserId)
public class TeamMembership
{
    public int Id { get; set; }
    public int TeamId { get; set; }
    public string UserId { get; set; } = string.Empty;
    public int RoleId { get; set; }
    public DateTime JoinedAt { get; set; } = DateTime.UtcNow;
    public string Status { get; set; } = "Active";

    [ForeignKey(nameof(TeamId))]
    public Team Team { get; set; } = null!;

    [ForeignKey(nameof(UserId))]
    public ApplicationUser User { get; set; } = null!;

    [ForeignKey(nameof(RoleId))]
    public TeamRole Role { get; set; } = null!;
}
