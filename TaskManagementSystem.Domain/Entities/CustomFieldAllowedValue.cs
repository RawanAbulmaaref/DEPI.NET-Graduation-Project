using System.ComponentModel.DataAnnotations.Schema;
namespace TaskManagementSystem.Domain.Entities;

public class CustomFieldAllowedValue
{
    public int Id { get; set; }
    public int CustomFieldId { get; set; }
    public string Value { get; set; } = string.Empty;

    [ForeignKey(nameof(CustomFieldId))]
    public CustomField CustomField { get; set; } = null!;
}