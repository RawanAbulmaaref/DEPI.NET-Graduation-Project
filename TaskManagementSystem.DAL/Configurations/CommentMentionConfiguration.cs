using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagementSystem.Domain.Entities;

namespace TaskManagementSystem.DAL.Configurations;

public class CommentMentionConfiguration : IEntityTypeConfiguration<CommentMention>
{
    public void Configure(EntityTypeBuilder<CommentMention> builder)
    {
        builder.ToTable("CommentMentions");
        builder.HasKey(x => new { x.CommentId, x.UserId });

        builder.HasOne(x => x.Comment)
               .WithMany()
               .HasForeignKey(x => x.CommentId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.User)
               .WithMany()
               .HasForeignKey(x => x.UserId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}