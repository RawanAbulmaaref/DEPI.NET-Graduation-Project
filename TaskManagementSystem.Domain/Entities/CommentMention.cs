using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManagementSystem.Domain.Entities;

public class CommentMention
{
    public int CommentId { get; set; }

    public string UserId { get; set; } = string.Empty;

    [ForeignKey(nameof(CommentId))]
    public Comment Comment { get; set; } = null!;

    [ForeignKey(nameof(UserId))]
    public ApplicationUser User { get; set; } = null!;
}
