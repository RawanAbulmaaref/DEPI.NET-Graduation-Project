using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManagementSystem.Domain.Entities;

// Composite PK: (RoleId, PermissionId)
public class RolePermission
{
    public int RoleId { get; set; }
    public int PermissionId { get; set; }

    [ForeignKey(nameof(RoleId))]
    public TeamRole Role { get; set; } = null!;

    [ForeignKey(nameof(PermissionId))]
    public Permission Permission { get; set; } = null!;
}
