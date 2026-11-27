using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManagementSystem.Domain.Entities;

public class SavedFilter
{
    public int Id { get; set; }

    public string UserId { get; set; } = string.Empty;

    public int? ProjectId { get; set; }

    public string Name { get; set; } = string.Empty;

    public string CriteriaJson { get; set; } = string.Empty;

    public string SharingScope { get; set; } = string.Empty;

    [ForeignKey(nameof(UserId))]
    public ApplicationUser User { get; set; } = null!;

    [ForeignKey(nameof(ProjectId))]
    public Project? Project { get; set; }
}