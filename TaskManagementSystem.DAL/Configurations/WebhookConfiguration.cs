using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagementSystem.Domain.Entities;

namespace TaskManagementSystem.DAL.Configurations;

public class WebhookConfiguration : IEntityTypeConfiguration<Webhook>
{
    public void Configure(EntityTypeBuilder<Webhook> builder)
    {
        builder.ToTable("Webhooks");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
        builder.Property(x => x.TargetUrl).IsRequired().HasMaxLength(2048);
        builder.Property(x => x.IsActive).IsRequired();

        builder.HasOne(x => x.Project)
               .WithMany()
               .HasForeignKey(x => x.ProjectId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
