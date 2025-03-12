using DucAnhERP.Models;
using DucAnhERP.Models.BoiThuong;
using DucAnhERP.Models.QLNV;
using DucAnhERP.Models.ThongKeDien;
using DucAnhERP.Services.SignalR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using static DucAnhERP.ViewModel.BoiThuong.BT_CTietPAnBThuongModel;

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

        public DbSet<Permission> Permissions { get; set; }

        public DbSet<Major> Majors { get; set; }
        public DbSet<MajorUserPermission> MajorUserPermissions { get; set; }
        public DbSet<MajorUserPermission_Log> MajorUserPermission_Logs { get; set; }
        public DbSet<PermissionControl> PermissionControls { get; set; }
        public DbSet<PermissionControl_Log> PermissionControl_Logs { get; set; }
        public DbSet<MCompany> MCompanies { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Department_Log> Department_Logs { get; set; }
        public DbSet<EmailHistory> EmailHistories { get; set; }
        public DbSet<UserSession> UserSessions { get; set; }

        public DbSet<ApprovalRequest> ApprovalRequests { get; set; }
        public DbSet<ApprovalDeptSetting> ApprovalDeptSettings { get; set; }
        public DbSet<ApprovalStepSetting> ApprovalStepSettings { get; set; }
        public DbSet<ApprovalStaffSetting> ApprovalStaffSettings { get; set; }

        public DbSet<MajorUserApproval> MajorUserApprovals { get; set; }
        public DbSet<MajorUserApproval_Log> MajorUserApproval_Logs { get; set; }
        public DbSet<ApprovalControl> ApprovalControls { get; set; }
        public DbSet<ApprovalControl_Log> ApprovalControl_Logs { get; set; }

        public DbSet<ChiNhanh> ChiNhanhs { get; set; }
        public DbSet<ChiNhanh_Log> ChiNhanh_Logs { get; set; }
       
        public DbSet<CompanyType> CompanyTypes { get; set; }
        public DbSet<MajorUserApprovalDetail> MajorUserApprovalDetails { get; set; }
        public DbSet<Tinh> Tinhs { get; set; }
        public DbSet<Huyen> Huyens { get; set; }
        public DbSet<Huyen_Log> Huyen_Logs { get; set; }
        public DbSet<Xa> Xas { get; set; }
        public DbSet<KhuHanhChinh> KhuHanhChinhs { get; set; }
        public DbSet<QD_BoiThuong_Goc> QD_BoiThuong_Gocs { get; set; }
        public DbSet<QD_BoiThuong_Goc_Log> QD_BoiThuong_Goc_Logs { get; set; }
        public DbSet<QD_ThuHoiDat_Goc> QD_ThuHoiDat_Gocs { get; set; }
        public DbSet<QD_ThuHoiDat_Goc_Log> QD_ThuHoiDat_Goc_Logs { get; set; }

        //QLNV
        public DbSet<QLNV_NhanVien> QLNV_NhanViens { get; set; }
        public DbSet<QLNV_NhomNhanVien> QLNV_NhomNhanViens { get; set; }
        public DbSet<QLNV_QuanLyNhanVien> QLNV_QuanLyNhanViens { get; set; }
        public DbSet<QLNV_CongViec> QLNV_CongViecs { get; set; }
        public DbSet<QLNV_CongViecCon> QLNV_CongViecCons { get; set; }
        public DbSet<QLNV_DanhGia> QLNV_DanhGias { get; set; }

        //BoiThuong
        public DbSet<BT_DM_LoaiChungTu> BT_DM_LoaiChungTus { get; set; }
        public DbSet<BT_DM_HTThuChi> BT_DM_HTThuChis { get; set; }
        public DbSet<BT_DM_HMChi> BT_DM_HMChis { get; set; }
        public DbSet<BT_DM_QDBoiThuongGoc> BT_DM_QDBoiThuongGocs { get; set; }
        public DbSet<BT_DM_QDThuHoiDatGoc> BT_DM_QDThuHoiDatGocs { get; set; }
        public DbSet<BT_DM_QDTGPMBNhanhGoc> BT_DM_QDTGPMBNhanhGocs { get; set; }
        public DbSet<BT_DM_QDCVChiPhiHoiDong> BT_DM_QDCVChiPhiHoiDongs { get; set; }
        public DbSet<BT_CTietPAnBThuong> BT_CTietPAnBThuongs { get; set; }
        public DbSet<BT_QDPABTDChinh> BT_QDPABTDChinhs { get; set; }
        public DbSet<BT_QDGPMBNhanhDChinh> BT_QDGPMBNhanhDChinhs { get; set; }
        public DbSet<BT_QDTHoiDatDChinh> BT_QDTHoiDatDChinhs { get; set; }
        public DbSet<BT_QDPABTKHopGPMBNhanh> BT_QDPABTKHopGPMBNhanhs { get; set; }
        public DbSet<BT_QDPABTKHopTHoiDat> BT_QDPABTKHopTHoiDats { get; set; }

        //Thống kê điện
        public DbSet<D_DM_TuyenDuong> D_DM_TuyenDuongs { get; set; }
        public DbSet<D_DM_HangMucKL> D_DM_HangMucKLs { get; set; }
        public DbSet<D_DM_LoaiKL> D_DM_LoaiKLs { get; set; }
        public DbSet<D_DM_ThongTinVatTu> D_DM_ThongTinVatTus { get; set; }
        public DbSet<D_TTLDienCDien> D_TTLDienCDiens { get; set; }
        public DbSet<D_XDungCDien> D_XDungCDiens { get; set; }
        public DbSet<D_CDoCDien> D_CDoCDiens { get; set; }
        public DbSet<D_DaoCDien> D_DaoCDiens { get; set; }


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
                entity.Property(e => e.MajorId)
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
