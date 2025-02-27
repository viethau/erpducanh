﻿using DucAnhERP.Components.Pages.NghiepVuCongTrinh.DanhMuc;
using DucAnhERP.Components.Pages.NghiepVuCongTrinh.PKKL;
using DucAnhERP.Models;
using DucAnhERP.Models.NghiepVuCongTrinh;
using DucAnhERP.Services.SignalR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

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


        public DbSet<NhomDanhMuc> DSNhomDanhMuc { get; set; }
        public DbSet<DanhMuc1> DSDanhMuc { get; set; }
        public DbSet<MHopRanhThang> DSHopRanhThang { get; set; }
        public DbSet<NuocMua> DSNuocMua { get; set; }
        public DbSet<PhanLoaiHoGa> PhanLoaiHoGas { get; set; }
        public DbSet<PhanLoaiHoGaDetail> PhanLoaiHoGaDetails { get; set; }
        public DbSet<PhanLoaiTDHoGa> PhanLoaiTDHoGas { get; set; }
        public DbSet<PhanLoaiCTronHopNhua> PhanLoaiCTronHopNhuas { get; set; }
        public DbSet<PhanLoaiMongCTron> PhanLoaiMongCTrons { get; set; }
        public DbSet<PhanLoaiDeCong> PhanLoaiDeCongs { get; set; }
        public DbSet<PhanLoaiThanhChong> PhanLoaiThanhChongs { get; set; }
        public DbSet<PhanLoaiTDanTDan> PhanLoaiTDanTDans { get; set; }
        public DbSet<MangThu> MangThus { get; set; }
        public DbSet<TKThepHoGa> TKThepHoGas { get; set; }
        public DbSet<TKThepTamDan> TKThepTamDans { get; set; }
        public DbSet<DMThep> DMTLTheps { get; set; }
        public DbSet<MaTuong> MaTuongs { get; set; }
        public DbSet<TKThepCTron> TKThepCTrons { get; set; }
        public DbSet<TKThepMongCTron> TKThepMongCTrons { get; set; }
        public DbSet<TKThepDCong> TKThepDeCongs { get; set; }
        public DbSet<TKThepCHop> TKThepCHops { get; set; }
        public DbSet<TKThepMongCHop> TKThepMongCHops { get; set; }
        public DbSet<TKThepTDanCHop> TKThepTDanCHops { get; set; }
        public DbSet<TKThepRXay> TKThepRXays { get; set; }
        public DbSet<TKThepTDanRXay> TKThepTDanRXays { get; set; }
        public DbSet<TKThepTChong> TKThepTChongs { get; set; }
        public DbSet<TKThepRBTong> TKThepRBTongs { get; set; }
        public DbSet<TKThepTDRBTong> TKThepTDRBTongs { get; set; }
        public DbSet<PKKLCTron> PKKLCTrons { get; set; }
        public DbSet<PKKLMongCTron> PKKLMongCTrons { get; set; }
        public DbSet<PKKLDeCTron> PKKLDeCTrons { get; set; }
        public DbSet<PKKLCHop> PKKLCHops { get; set; }
        public DbSet<PKKLMongCHop> PKKLMongCHops { get; set; }
        public DbSet<PKKLTDanCHop> PKKLTDanCHops { get; set; }
        public DbSet<PKKLRanhBT> PKKLRanhBTs { get; set; }
        public DbSet<PKKLTDanRBT> PKKLTDanRBTs { get; set; }
        public DbSet<PKKLRXay> PKKLRXays { get; set; }
        public DbSet<PKKLTDanRXay> PKKLTDanRXays { get; set; }
        public DbSet<PKKLTChong> PKKLTChongs { get; set; }
        public DbSet<PKKLCTietHoGa> PKKLCTietHoGas { get; set; }
        public DbSet<PKKLCTietTDHG> PKKLCTietTDHGs { get; set; }

        //BoiThuong
        public DbSet<BT_DM_LoaiChungTu> BT_DM_LoaiChungTus { get; set; }

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


                modelBuilder.Entity<NuocMua>()
                .ToTable(tb => tb.UseSqlOutputClause(false));
                modelBuilder.Entity<PhanLoaiHoGa>()
               .ToTable(tb => tb.UseSqlOutputClause(false));
                modelBuilder.Entity<PhanLoaiCTronHopNhua>()
               .ToTable(tb => tb.UseSqlOutputClause(false));
                modelBuilder.Entity<PhanLoaiMongCTron>()
               .ToTable(tb => tb.UseSqlOutputClause(false));
                modelBuilder.Entity<PhanLoaiDeCong>()
               .ToTable(tb => tb.UseSqlOutputClause(false));
                modelBuilder.Entity<PhanLoaiThanhChong>()
               .ToTable(tb => tb.UseSqlOutputClause(false));
                modelBuilder.Entity<PhanLoaiTDHoGa>()
               .ToTable(tb => tb.UseSqlOutputClause(false));
                modelBuilder.Entity<PhanLoaiTDanTDan>()
               .ToTable(tb => tb.UseSqlOutputClause(false));
                modelBuilder.Entity<DanhMuc1>()
               .ToTable(tb => tb.UseSqlOutputClause(false));
                modelBuilder.Entity<NhomDanhMuc>()
                .ToTable(tb => tb.UseSqlOutputClause(false));
                modelBuilder.Entity<DMThep>()
               .ToTable(tb => tb.UseSqlOutputClause(false));
                modelBuilder.Entity<PKKLCHop>()
               .ToTable(tb => tb.UseSqlOutputClause(false));
                modelBuilder.Entity<PKKLCTietHoGa>()
               .ToTable(tb => tb.UseSqlOutputClause(false));
                modelBuilder.Entity<PKKLCTietTDHG>()
                .ToTable(tb => tb.UseSqlOutputClause(false));
                modelBuilder.Entity<PKKLCTron>()
                .ToTable(tb => tb.UseSqlOutputClause(false));
                modelBuilder.Entity<PKKLDeCTron>()
                .ToTable(tb => tb.UseSqlOutputClause(false));
                modelBuilder.Entity<PKKLMongCHop>()
                .ToTable(tb => tb.UseSqlOutputClause(false));
                modelBuilder.Entity<PKKLMongCTron>()
                .ToTable(tb => tb.UseSqlOutputClause(false));
                modelBuilder.Entity<PKKLRanhBT>()
                .ToTable(tb => tb.UseSqlOutputClause(false));
                modelBuilder.Entity<PKKLRXay>()
                .ToTable(tb => tb.UseSqlOutputClause(false));
                modelBuilder.Entity<PKKLTChong>()
                .ToTable(tb => tb.UseSqlOutputClause(false));
                modelBuilder.Entity<PKKLTDanCHop>()
                .ToTable(tb => tb.UseSqlOutputClause(false));
                modelBuilder.Entity<PKKLTDanRBT>()
                .ToTable(tb => tb.UseSqlOutputClause(false));
                modelBuilder.Entity<PKKLTDanRXay>()
                .ToTable(tb => tb.UseSqlOutputClause(false));

                modelBuilder.Entity<TKThepCHop>()
                .ToTable(tb => tb.UseSqlOutputClause(false));
                modelBuilder.Entity<TKThepCTron>()
                .ToTable(tb => tb.UseSqlOutputClause(false));
                modelBuilder.Entity<TKThepDCong>()
                .ToTable(tb => tb.UseSqlOutputClause(false));
                modelBuilder.Entity<TKThepHoGa>()
                .ToTable(tb => tb.UseSqlOutputClause(false));
                modelBuilder.Entity<TKThepMongCHop>()
                .ToTable(tb => tb.UseSqlOutputClause(false));
                modelBuilder.Entity<TKThepMongCTron>()
                .ToTable(tb => tb.UseSqlOutputClause(false));
                modelBuilder.Entity<TKThepRBTong>()
                .ToTable(tb => tb.UseSqlOutputClause(false));
                modelBuilder.Entity<TKThepRXay>()
                .ToTable(tb => tb.UseSqlOutputClause(false));
                modelBuilder.Entity<TKThepTamDan>()
                .ToTable(tb => tb.UseSqlOutputClause(false));
                modelBuilder.Entity<TKThepTChong>()
                .ToTable(tb => tb.UseSqlOutputClause(false));
                modelBuilder.Entity<TKThepCHop>()
                .ToTable(tb => tb.UseSqlOutputClause(false));
                modelBuilder.Entity<TKThepTDanRXay>()
                .ToTable(tb => tb.UseSqlOutputClause(false));
                modelBuilder.Entity<TKThepTDRBTong>()
               .ToTable(tb => tb.UseSqlOutputClause(false));
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
