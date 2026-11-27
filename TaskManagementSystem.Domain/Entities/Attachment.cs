
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManagementSystem.Domain.Entities;

public class Attachment
{
    public int Id { get; set; }

    public int? TaskId { get; set; }
    public int? CommentId { get; set; }

    public string UploadedById { get; set; } = string.Empty;

    public string FileName { get; set; } = string.Empty;
    public string ContentType { get; set; } = string.Empty;
    public long FileSizeBytes { get; set; }
    public byte[] FileContent { get; set; } = null!;

    public DateTime UploadedAt { get; set; } = DateTime.UtcNow;

    [ForeignKey(nameof(TaskId))]
    public TaskItem? Task { get; set; }

    [ForeignKey(nameof(CommentId))]
    public Comment? Comment { get; set; }

    [ForeignKey(nameof(UploadedById))]
    public ApplicationUser UploadedBy { get; set; } = null!;
}
