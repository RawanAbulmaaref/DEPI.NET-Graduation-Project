using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagementSystem.Domain.Entities;

namespace TaskManagementSystem.DAL.Configurations;

public class ProjectTemplateColumnConfiguration : IEntityTypeConfiguration<ProjectTemplateColumn>
{
    public void Configure(EntityTypeBuilder<ProjectTemplateColumn> builder)
    {
        builder.ToTable("ProjectTemplateColumns");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
        builder.Property(x => x.Position).IsRequired();

        builder.HasOne(x => x.Template)
               .WithMany(t => t.Columns)
               .HasForeignKey(x => x.TemplateId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
