
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManagementSystem.Domain.Entities;

public class Comment
{
    public int Id { get; set; }

    public int TaskId { get; set; }

    public string AuthorId { get; set; } = string.Empty;

    public int? ParentCommentId { get; set; }

    public string Content { get; set; } = string.Empty;

    public DateTime PostedAt { get; set; } = DateTime.UtcNow;

    public DateTime? EditedAt { get; set; }


    // Relationships

    [ForeignKey(nameof(TaskId))]
    public TaskItem Task { get; set; } = null!;

    [ForeignKey(nameof(AuthorId))]
    public ApplicationUser Author { get; set; } = null!;

    [ForeignKey(nameof(ParentCommentId))]
    public Comment? ParentComment { get; set; }

    public ICollection<Comment> Replies { get; set; }
        = new List<Comment>();
}
