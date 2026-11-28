using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagementSystem.Domain.Entities;

namespace TaskManagementSystem.DAL.Configurations;

public class CommentMentionConfiguration : IEntityTypeConfiguration<CommentMention>
{
    public void Configure(EntityTypeBuilder<CommentMention> builder)
    {
        // Table
        builder.ToTable("CommentMentions");

        // Composite Primary Key
        builder.HasKey(cm => new { cm.CommentId, cm.UserId });

        // Properties
        builder.Property(cm => cm.CommentId)
               .IsRequired();

        builder.Property(cm => cm.UserId)
               .IsRequired()
               .HasMaxLength(450);

        // Comment Relationship
        builder.HasOne(cm => cm.Comment)
               .WithMany()
               .HasForeignKey(cm => cm.CommentId);

        // User Relationship
        builder.HasOne(cm => cm.User)
               .WithMany()
               .HasForeignKey(cm => cm.UserId);
    }
}