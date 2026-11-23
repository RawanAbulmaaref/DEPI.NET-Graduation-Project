namespace TaskManagementSystem.Domain.Entities;

// Unique: Name
public class ProjectTemplate
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }

    public ICollection<ProjectTemplateColumn> Columns { get; set; } = new List<ProjectTemplateColumn>();
    public ICollection<Project> Projects { get; set; } = new List<Project>();
}
