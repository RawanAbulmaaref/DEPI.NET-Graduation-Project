namespace TaskManagementSystem.Domain.Entities;

public class SystemSetting
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Value { get; set; } = string.Empty;

    public string? Description { get; set; }

    public DateTime LastModifiedAt { get; set; }
}