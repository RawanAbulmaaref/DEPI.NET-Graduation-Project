using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagementSystem.Domain.Entities;

namespace TaskManagementSystem.DAL.Configurations;

public class TaskCustomFieldValueConfiguration : IEntityTypeConfiguration<TaskCustomFieldValue>
{
    public void Configure(EntityTypeBuilder<TaskCustomFieldValue> builder)
    {
        builder.ToTable("TaskCustomFieldValues");
        builder.HasKey(x => new { x.TaskId, x.CustomFieldId });

        builder.Property(x => x.Value).HasMaxLength(500);

        builder.HasOne(x => x.Task)
               .WithMany(t => t.CustomFieldValues)
               .HasForeignKey(x => x.TaskId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.CustomField)
               .WithMany()
               .HasForeignKey(x => x.CustomFieldId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}