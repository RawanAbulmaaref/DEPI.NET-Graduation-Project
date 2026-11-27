using Microsoft.AspNetCore.Identity;

namespace TaskManagementSystem.Domain.Entities;

// Id, Email, PasswordHash come from IdentityUser; maps to the Identity users table
public class ApplicationUser : IdentityUser
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string ThemePreference { get; set; } = "System";
    public string AccountStatus { get; set; } = "Active";
    public DateTime RegisteredAt { get; set; } = DateTime.UtcNow;

    public ICollection<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();

    public ICollection<Workspace> OwnedWorkspaces { get; set; } = new List<Workspace>();
    public ICollection<TeamMembership> TeamMemberships { get; set; } = new List<TeamMembership>();
}
