using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TaskManagementSystem.Domain.Entities;

namespace TaskManagementSystem.DAL.DBContext;

public class AppDbContext : IdentityDbContext<ApplicationUser>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<RefreshToken> RefreshTokens => Set<RefreshToken>();
    public DbSet<TeamRole> TeamRoles => Set<TeamRole>();
    public DbSet<Permission> Permissions => Set<Permission>();
    public DbSet<RolePermission> RolePermissions => Set<RolePermission>();
    public DbSet<Workspace> Workspaces => Set<Workspace>();
    public DbSet<Team> Teams => Set<Team>();
    public DbSet<TeamMembership> TeamMemberships => Set<TeamMembership>();
    public DbSet<Invitation> Invitations => Set<Invitation>();
    public DbSet<ProjectTemplate> ProjectTemplates => Set<ProjectTemplate>();
    public DbSet<ProjectTemplateColumn> ProjectTemplateColumns => Set<ProjectTemplateColumn>();
    public DbSet<Project> Projects => Set<Project>();
    public DbSet<TeamProject> TeamProjects => Set<TeamProject>();
    public DbSet<Board> Boards => Set<Board>();
    public DbSet<BoardColumn> BoardColumns => Set<BoardColumn>();
    public DbSet<Swimlane> Swimlanes => Set<Swimlane>();
    public DbSet<Sprint> Sprints => Set<Sprint>();
    public DbSet<Milestone> Milestones => Set<Milestone>();
    public DbSet<Label> Labels => Set<Label>();
    public DbSet<CustomField> CustomFields => Set<CustomField>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}
