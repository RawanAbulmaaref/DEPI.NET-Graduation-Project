using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagementSystem.Domain.Entities;

namespace TaskManagementSystem.DAL.Configurations;

public class TaskItemConfiguration : IEntityTypeConfiguration<TaskItem>
{
    public void Configure(EntityTypeBuilder<TaskItem> builder)
    {
        builder.ToTable("Tasks");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Title).IsRequired().HasMaxLength(200);
        builder.Property(x => x.Priority).IsRequired().HasMaxLength(20);
        builder.Property(x => x.StartDate).HasColumnType("date");
        builder.Property(x => x.DueDate).HasColumnType("date");
        builder.Property(x => x.BoardPosition).IsRequired();

        builder.Property(x => x.RowVersion).IsRowVersion();

        builder.HasOne(x => x.Column)
               .WithMany()
               .HasForeignKey(x => x.ColumnId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Swimlane)
               .WithMany()
               .HasForeignKey(x => x.SwimlaneId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Sprint)
               .WithMany()
               .HasForeignKey(x => x.SprintId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Milestone)
               .WithMany()
               .HasForeignKey(x => x.MilestoneId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.TaskTemplate)
               .WithMany(t => t.Tasks)
               .HasForeignKey(x => x.TaskTemplateId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.CreatedBy)
               .WithMany()
               .HasForeignKey(x => x.CreatedById)
               .OnDelete(DeleteBehavior.Restrict);
    }
}