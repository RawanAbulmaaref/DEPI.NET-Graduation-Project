
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagementSystem.Domain.Entities;

namespace TaskManagementSystem.DAL.Configurations;

public class CommentConfiguration : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        // Table
        builder.ToTable("Comments");

        // Primary Key
        builder.HasKey(c => c.Id);

        // Properties
        builder.Property(c => c.TaskId)
               .IsRequired();

        builder.Property(c => c.AuthorId)
               .IsRequired()
               .HasMaxLength(450);

        builder.Property(c => c.ParentCommentId)
               .IsRequired(false);

        builder.Property(c => c.Content)
               .IsRequired()
               .HasColumnType("nvarchar(max)");

        builder.Property(c => c.PostedAt)
               .IsRequired()
               .HasColumnType("datetime2");

        builder.Property(c => c.EditedAt)
               .IsRequired(false)
               .HasColumnType("datetime2");

        // Task Relationship
        builder.HasOne(c => c.Task)
               .WithMany()
               .HasForeignKey(c => c.TaskId);

        // Author Relationship
        builder.HasOne(c => c.Author)
               .WithMany()
               .HasForeignKey(c => c.AuthorId);

        // Self-Referencing Relationship
        builder.HasOne(c => c.ParentComment)
               .WithMany(c => c.Replies)
               .HasForeignKey(c => c.ParentCommentId)
               .IsRequired(false);
    }
}
