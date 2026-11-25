using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManagementSystem.Domain.Entities;

public class Project
{
    public int Id { get; set; }
    public int WorkspaceId { get; set; }
    public string CreatedById { get; set; } = string.Empty;
    public int? TemplateId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public DateOnly? PlannedStartDate { get; set; }
    public DateOnly? PlannedEndDate { get; set; }
    public string? SettingsJson { get; set; }
    public bool IsArchived { get; set; }
    public DateTime? ArchivedAt { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [ForeignKey(nameof(WorkspaceId))]
    public Workspace Workspace { get; set; } = null!;

    [ForeignKey(nameof(CreatedById))]
    public ApplicationUser CreatedBy { get; set; } = null!;

    [ForeignKey(nameof(TemplateId))]
    public ProjectTemplate? Template { get; set; }

    public ICollection<TeamProject> TeamProjects { get; set; } = new List<TeamProject>();
    public ICollection<Board> Boards { get; set; } = new List<Board>();
    public ICollection<Sprint> Sprints { get; set; } = new List<Sprint>();
    public ICollection<Milestone> Milestones { get; set; } = new List<Milestone>();
    public ICollection<Label> Labels { get; set; } = new List<Label>();
    public ICollection<CustomField> CustomFields { get; set; } = new List<CustomField>();
}
