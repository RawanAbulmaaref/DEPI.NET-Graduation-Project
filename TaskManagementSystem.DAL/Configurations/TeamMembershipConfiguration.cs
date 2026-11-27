using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagementSystem.Domain.Entities;

namespace TaskManagementSystem.DAL.Configurations;

public class TeamMembershipConfiguration : IEntityTypeConfiguration<TeamMembership>
{
    public void Configure(EntityTypeBuilder<TeamMembership> builder)
    {
        builder.ToTable("TeamMemberships");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.JoinedAt).IsRequired();
        builder.Property(x => x.Status).IsRequired().HasMaxLength(20);

        // a user can join a team only once
        builder.HasIndex(x => new { x.TeamId, x.UserId }).IsUnique();

        builder.HasOne(x => x.Team)
               .WithMany(t => t.Memberships)
               .HasForeignKey(x => x.TeamId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.User)
               .WithMany(u => u.TeamMemberships)
               .HasForeignKey(x => x.UserId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Role)
               .WithMany(r => r.Memberships)
               .HasForeignKey(x => x.RoleId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
