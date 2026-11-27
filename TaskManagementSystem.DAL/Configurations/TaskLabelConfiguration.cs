using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagementSystem.Domain.Entities;

namespace TaskManagementSystem.DAL.Configurations;

public class TaskLabelConfiguration : IEntityTypeConfiguration<TaskLabel>
{
    public void Configure(EntityTypeBuilder<TaskLabel> builder)
    {
        builder.ToTable("TaskLabels");
        builder.HasKey(x => new { x.TaskId, x.LabelId });

        builder.HasOne(x => x.Task)
               .WithMany(t => t.Labels)
               .HasForeignKey(x => x.TaskId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Label)
               .WithMany()
               .HasForeignKey(x => x.LabelId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}