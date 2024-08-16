using DucAnhERP.Models;
using DucAnhERP.Services.SignalR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace DucAnhERP.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser> 
    {
        private readonly IHubContext<NotificationHub> _hubContext;


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IHubContext<NotificationHub> hubContext) : base(options)
        {
            _hubContext = hubContext;
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public DbSet<MPermission> MPermissions { get; set; }

        public DbSet<MMajor> MMajors { get; set; }

        public DbSet<MMajorUserPermission> MMajorUserPermissions { get; set; }

        public DbSet<MPermissionControl> MPermissionControls { get; set; }

        public DbSet<MCompany> MCompanies { get; set; }

        public DbSet<MDepartment> MDepartments { get; set; }

        public DbSet<EmailHistory> EmailHistories { get; set; }

        public DbSet<UserSession> UserSessions { get; set; }

        public DbSet<ApprovalRequest> ApprovalRequests { get; set; }
        public DbSet<ApprovalDeptSetting> ApprovalDeptSettings { get; set; }
        public DbSet<ApprovalStepSetting> ApprovalStepSettings { get; set; }
        public DbSet<ApprovalStaffSetting> ApprovalStaffSettings { get; set; }
        public DbSet<MNhomDanhMuc> DSNhomDanhMuc { get; set; }
        public DbSet<MDanhMuc> DSDanhMuc { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmailHistory>(entity =>
            {
                entity.ToTable(tb => tb.HasTrigger("EmailHistories_SentMail"));

                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.CompanyId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Content).IsRequired();
                entity.Property(e => e.CreateBy).IsRequired();
                entity.Property(e => e.MajorId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Receiver)
                    .IsRequired()
                    .IsUnicode(false);
                entity.Property(e => e.ScreenId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Subject).IsRequired();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        private void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        // Thiết định SignalR
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries<EmailHistory>()
                 .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);
            var result = base.SaveChangesAsync(cancellationToken);


            if (entries.Any())
            {
                _hubContext.Clients.All.SendAsync("ReceiveMessage", "A new email record has been added.");
            }

            return result;
        }
    }
}
