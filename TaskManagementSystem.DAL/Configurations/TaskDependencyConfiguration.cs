using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagementSystem.Domain.Entities;

namespace TaskManagementSystem.DAL.Configurations;

public class TaskDependencyConfiguration : IEntityTypeConfiguration<TaskDependency>
{
    public void Configure(EntityTypeBuilder<TaskDependency> builder)
    {
        builder.ToTable("TaskDependencies");
        builder.HasKey(x => new { x.SuccessorTaskId, x.PredecessorTaskId });

        builder.Property(x => x.DependencyType).IsRequired().HasMaxLength(30);

        builder.HasOne(x => x.SuccessorTask)
               .WithMany(t => t.Predecessors)
               .HasForeignKey(x => x.SuccessorTaskId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.PredecessorTask)
               .WithMany(t => t.Successors)
               .HasForeignKey(x => x.PredecessorTaskId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}