namespace TaskManagementSystem.Domain.Entities;

// Unique: Name
public class ProjectTemplate
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
}
