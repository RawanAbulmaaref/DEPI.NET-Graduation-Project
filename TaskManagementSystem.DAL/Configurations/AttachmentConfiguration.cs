using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagementSystem.Domain.Entities;

namespace TaskManagementSystem.DAL.Configurations;

public class AttachmentConfiguration : IEntityTypeConfiguration<Attachment>
{
    public void Configure(EntityTypeBuilder<Attachment> builder)
    {
        // Table
        builder.ToTable("Attachments", table =>
        {
            table.HasCheckConstraint(
                "CK_Attachments_TaskOrComment",
                "([TaskId] IS NOT NULL AND [CommentId] IS NULL) OR " +
                "([TaskId] IS NULL AND [CommentId] IS NOT NULL)");
        });

        // Primary Key
        builder.HasKey(a => a.Id);

        // Properties
        builder.Property(a => a.UploadedById)
               .IsRequired()
               .HasMaxLength(450);

        builder.Property(a => a.FileName)
               .IsRequired()
               .HasMaxLength(260);

        builder.Property(a => a.ContentType)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(a => a.FileSizeBytes)
               .IsRequired();

        builder.Property(a => a.FileContent)
               .IsRequired()
               .HasColumnType("varbinary(max)");

        builder.Property(a => a.UploadedAt)
               .IsRequired()
               .HasColumnType("datetime2");

        // Relationships
        builder.HasOne(a => a.Task)
               .WithMany()
               .HasForeignKey(a => a.TaskId)
               .IsRequired(false);

        builder.HasOne(a => a.Comment)
               .WithMany()
               .HasForeignKey(a => a.CommentId)
               .IsRequired(false);

        builder.HasOne(a => a.UploadedBy)
               .WithMany()
               .HasForeignKey(a => a.UploadedById);
    }
}