using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagementSystem.Domain.Entities;

namespace TaskManagementSystem.DAL.Configurations;

// Id, Email, PasswordHash, etc. come from IdentityUser (table AspNetUsers by default).
// We only configure the extra columns here.
public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        // builder.ToTable("Users"); // uncomment if you want the table named Users instead of AspNetUsers

        builder.Property(x => x.FirstName).IsRequired().HasMaxLength(100);
        builder.Property(x => x.LastName).IsRequired().HasMaxLength(100);
        builder.Property(x => x.ThemePreference).IsRequired().HasMaxLength(20);
        builder.Property(x => x.AccountStatus).IsRequired().HasMaxLength(20);
        builder.Property(x => x.RegisteredAt).IsRequired();

        builder.HasMany(x => x.RefreshTokens)
               .WithOne(t => t.User)
               .HasForeignKey(t => t.UserId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
