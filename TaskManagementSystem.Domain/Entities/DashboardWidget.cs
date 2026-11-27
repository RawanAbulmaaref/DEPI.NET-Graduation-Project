using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManagementSystem.Domain.Entities;

public class DashboardWidget
{
    public int Id { get; set; }

    public string UserId { get; set; } = string.Empty;

    public string WidgetType { get; set; } = string.Empty;

    public int DisplayPosition { get; set; }

    public bool IsVisible { get; set; }

    [ForeignKey(nameof(UserId))]
    public ApplicationUser User { get; set; } = null!;
}