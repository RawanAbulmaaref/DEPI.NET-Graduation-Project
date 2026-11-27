using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagementSystem.Domain.Entities;

namespace TaskManagementSystem.DAL.Configurations;

public class InvitationConfiguration : IEntityTypeConfiguration<Invitation>
{
    public void Configure(EntityTypeBuilder<Invitation> builder)
    {
        builder.ToTable("Invitations");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.InviteeEmail).IsRequired().HasMaxLength(256);
        builder.Property(x => x.Status).IsRequired().HasMaxLength(20);
        builder.Property(x => x.SentAt).IsRequired();
        builder.Property(x => x.ExpiresAt).IsRequired();

        builder.HasOne(x => x.Team)
               .WithMany(t => t.Invitations)
               .HasForeignKey(x => x.TeamId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Role)
               .WithMany(r => r.Invitations)
               .HasForeignKey(x => x.RoleId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.SentBy)
               .WithMany()
               .HasForeignKey(x => x.SentById)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
