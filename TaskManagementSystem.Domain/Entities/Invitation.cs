using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManagementSystem.Domain.Entities;

public class Invitation
{
    public int Id { get; set; }
    public int TeamId { get; set; }
    public int RoleId { get; set; }
    public string SentById { get; set; } = string.Empty;
    public string InviteeEmail { get; set; } = string.Empty;
    public DateTime SentAt { get; set; } = DateTime.UtcNow;
    public DateTime ExpiresAt { get; set; }
    public string Status { get; set; } = "Pending";

    [ForeignKey(nameof(TeamId))]
    public Team Team { get; set; } = null!;

    [ForeignKey(nameof(RoleId))]
    public TeamRole Role { get; set; } = null!;

    [ForeignKey(nameof(SentById))]
    public ApplicationUser SentBy { get; set; } = null!;
}
