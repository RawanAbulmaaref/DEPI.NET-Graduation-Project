using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagementSystem.Domain.Entities;

namespace TaskManagementSystem.DAL.Configurations;

public class BoardColumnConfiguration : IEntityTypeConfiguration<BoardColumn>
{
    public void Configure(EntityTypeBuilder<BoardColumn> builder)
    {
        builder.ToTable("BoardColumns");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
        builder.Property(x => x.Position).IsRequired();
        builder.Property(x => x.IsCompletionColumn).IsRequired();

        builder.HasIndex(x => new { x.BoardId, x.Name }).IsUnique();

        builder.HasOne(x => x.Board)
               .WithMany(b => b.Columns)
               .HasForeignKey(x => x.BoardId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
