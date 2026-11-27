using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManagementSystem.Domain.Entities;

public class ProjectTemplateColumn
{
    public int Id { get; set; }
    public int TemplateId { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Position { get; set; }

    [ForeignKey(nameof(TemplateId))]
    public ProjectTemplate Template { get; set; } = null!;
}
