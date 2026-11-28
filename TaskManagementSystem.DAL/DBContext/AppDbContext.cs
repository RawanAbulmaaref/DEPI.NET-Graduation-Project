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

    // Tasks
    public DbSet<CustomFieldAllowedValue> CustomFieldAllowedValues => Set<CustomFieldAllowedValue>();
    public DbSet<TaskTemplate> TaskTemplates => Set<TaskTemplate>();
    public DbSet<TaskTemplateChecklistItem> TaskTemplateChecklistItems => Set<TaskTemplateChecklistItem>();
    public DbSet<TaskItem> Tasks => Set<TaskItem>();
    public DbSet<ChecklistItem> ChecklistItems => Set<ChecklistItem>();
    public DbSet<TaskAssignee> TaskAssignees => Set<TaskAssignee>();
    public DbSet<TaskLabel> TaskLabels => Set<TaskLabel>();
    public DbSet<TaskDependency> TaskDependencies => Set<TaskDependency>();
    public DbSet<TaskCustomFieldValue> TaskCustomFieldValues => Set<TaskCustomFieldValue>();

    // Collaboration
    public DbSet<Comment> Comments => Set<Comment>();
    public DbSet<CommentMention> CommentMentions => Set<CommentMention>();
    public DbSet<Attachment> Attachments => Set<Attachment>();
    public DbSet<TimeEntry> TimeEntries => Set<TimeEntry>();

    // Notifications & Logs
    public DbSet<Notification> Notifications => Set<Notification>();
    public DbSet<NotificationChannel> NotificationChannels => Set<NotificationChannel>();
    public DbSet<NotificationPreference> NotificationPreferences => Set<NotificationPreference>();
    public DbSet<ActivityLogEntry> ActivityLogEntries => Set<ActivityLogEntry>();

    // Filters, Automation, Admin
    public DbSet<SavedFilter> SavedFilters => Set<SavedFilter>();
    public DbSet<Webhook> Webhooks => Set<Webhook>();
    public DbSet<WebhookEvent> WebhookEvents => Set<WebhookEvent>();
    public DbSet<AutomationRule> AutomationRules => Set<AutomationRule>();
    public DbSet<AutomationRuleLabel> AutomationRuleLabels => Set<AutomationRuleLabel>();
    public DbSet<AutomationRuleColumn> AutomationRuleColumns => Set<AutomationRuleColumn>();
    public DbSet<DashboardWidget> DashboardWidgets => Set<DashboardWidget>();
    public DbSet<SystemSetting> SystemSettings => Set<SystemSetting>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}
