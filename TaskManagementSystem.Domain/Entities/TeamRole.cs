namespace TaskManagementSystem.Domain.Entities;

// Unique: Name
public class TeamRole
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int HierarchyLevel { get; set; }
    public string? Description { get; set; }

    public ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();
    public ICollection<TeamMembership> Memberships { get; set; } = new List<TeamMembership>();
    public ICollection<Invitation> Invitations { get; set; } = new List<Invitation>();
}
