using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagementSystem.Domain.Entities;

namespace TaskManagementSystem.DAL.Configurations;

public class SwimlaneConfiguration : IEntityTypeConfiguration<Swimlane>
{
    public void Configure(EntityTypeBuilder<Swimlane> builder)
    {
        builder.ToTable("Swimlanes");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
        builder.Property(x => x.Position).IsRequired();
        builder.Property(x => x.CategorizationCriterion).HasMaxLength(50);

        builder.HasIndex(x => new { x.BoardId, x.Name }).IsUnique();

        builder.HasOne(x => x.Board)
               .WithMany(b => b.Swimlanes)
               .HasForeignKey(x => x.BoardId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
