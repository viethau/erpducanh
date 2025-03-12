using DucAnhERP.Repository;
using DucAnhERP.Services;
using DucAnhERP.Services.SignalR;
using DucAnhERP.Components;
using DucAnhERP.Components.Account;
using DucAnhERP.Data;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using DucAnhERP.Models;
using OfficeOpenXml;
using Microsoft.AspNetCore.Http.Features;
using DucAnhERP.Repository.BoiThuong;
using DucAnhERP.Repository.QLNV;
using DucAnhERP.Services.BoiThuong;
using DucAnhERP.Components.Pages.BoiThuong;
using DucAnhERP.Services.QLNV;

var builder = WebApplication.CreateBuilder(args);


// Đặt LicenseContext cho EPPlus
ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
// Thiết định middleware của SignalR
builder.Services.AddResponseCompression(opts =>
{
    opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
          new[] { "application/octet-stream" });
});

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddSingleton<DucAnhERP.Services.ToastService>();
builder.Services.Configure<FormOptions>(options =>
{
    options.MultipartBodyLengthLimit = 10 * 1024 * 1024; // 10MB (Thay đổi giá trị nếu cần)
});

builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<IdentityUserAccessor>();
builder.Services.AddScoped<IdentityRedirectManager>();
builder.Services.AddScoped<ToastService>();
builder.Services.AddScoped<PermissionService>();

builder.Services.AddScoped<IMajorRepository, MajorRepository>();
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<IPermissionRepository, MPermissionRepository>();
builder.Services.AddScoped<IPermissionControlRepository, PermissionControlRepository>();
builder.Services.AddScoped<IMajorUserPermissionRepository, MajorUserPermissionRepository>();
builder.Services.AddScoped<ISortService, SortService>();
builder.Services.AddScoped<IEmailHistoryRepository, EmailHistoryRepository>();
builder.Services.AddScoped<IHelperService, HelperService>();
builder.Services.AddScoped<IUserSessionRepository, UserSessionRepository>();
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddScoped<IApprovalDeptSettingRepository, ApprovalDeptSettingRepository>();
builder.Services.AddScoped<IApprovalStepSettingRepository, ApprovalStepSettingRepository>();
builder.Services.AddSingleton<UserState>();
builder.Services.AddSingleton<ILoginService, LoginService>();
builder.Services.AddSingleton<ExportExcelService>();
builder.Services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();

builder.Services.AddScoped<IPhanQuyenRepository, PhanQuyenRepository>();
builder.Services.AddScoped<PhanQuyenRepository>();
builder.Services.AddScoped<IChiNhanhRepository, ChiNhanhRepository>();

builder.Services.AddScoped<IMajorUserApprovalReponsitory, MajorUserApprovalReponsitory>();
builder.Services.AddScoped<IApprovalControlRepository, ApprovalControlRepository>();

builder.Services.AddScoped<ICompanyTypeRepository, CompanyTypeRepository>();
builder.Services.AddScoped<IApplicationUserRepository, ApplicationUserRepository>();
builder.Services.AddScoped<IApprovalControlRepository, ApprovalControlRepository>();
builder.Services.AddScoped<ITinhRepository, TinhRepository>();
builder.Services.AddScoped<IHuyenRepository, HuyenRepository>();
builder.Services.AddScoped<IXaRepository, XaRepository>();
builder.Services.AddScoped<IKhuHanhChinhRepository, KhuHanhChinhRepository>();
builder.Services.AddScoped<IQD_BoiThuong_GocRepository, QD_BoiThuong_GocRepository>();
builder.Services.AddScoped<IQD_ThuHoiDat_GocRepository, QD_ThuHoiDat_GocRepository>();

builder.Services.AddScoped<IExcelRepository, ExcelRepository>();

//BoiThuong
builder.Services.AddScoped<IDM_LoaiChungTuRepository, DM_LoaiChungTuRepository>();
builder.Services.AddScoped<IDM_HinhThucThuChiRepository, DM_HinhThucThuChiRepository>();
builder.Services.AddScoped<IDM_HangMucChiRepository, DM_HangMucChiRepository>();
builder.Services.AddScoped<IDM_QDBoiThuongGocRepository, DM_QDBoiThuongGocRepository>();
builder.Services.AddScoped<IDM_QDThuHoiDatGocRepository, DM_QDThuHoiDatGocRepository>();
builder.Services.AddScoped<IDM_QDTGPMBNhanhGocRepository, DM_QDTGPMBNhanhGocRepository>();
builder.Services.AddScoped<IDM_QDCVChiPhiHoiDongRepository, DM_QDCVChiPhiHoiDongRepository>();
builder.Services.AddScoped<ICTietPAnBThuongRepository, CTietPAnBThuongRepository>();
builder.Services.AddScoped<IQDPABTDChinhRepository, QDPABTDChinhRepository>();
builder.Services.AddScoped<IQDGPMBNhanhDChinhRepository, QDGPMBNhanhDChinhRepository>();
builder.Services.AddScoped<IQDTHoiDatDChinhRepository, QDTHoiDatDChinhRepository>();
builder.Services.AddScoped<IQDPABTKHopGPMBNhanhRepository, QDPABTKHopGPMBNhanhRepository>();
builder.Services.AddScoped<IQDPABTKHopTHoiDatRepository, QDPABTKHopTHoiDatRepository>();

//ThongKeDien
builder.Services.AddScoped<ID_DM_TuyenDuongRepository, DM_TuyenDuongRepository>();
builder.Services.AddScoped<ID_DM_HangMucKLRepository, DM_HangMucKLRepository>();
builder.Services.AddScoped<ID_DM_LoaiKLRepository, DM_LoaiKLRepository>();
builder.Services.AddScoped<ID_DM_ThongTinVatTuRepository, DM_ThongTinVatTuRepository>();
builder.Services.AddScoped<ID_TTLDienCDienRepository, D_TTLDienCDienRepository>();
builder.Services.AddScoped<ID_XDungCDienRepository, D_XDungCDienRepository>();
builder.Services.AddScoped<ID_CDoCDienRepository, D_CDoCDienRepository>();
builder.Services.AddScoped<ID_DaoCDienRepository, D_DaoCDienRepository>();

//QLNV
builder.Services.AddScoped<IQLNV_NhanVienRepository, QLNV_NhanVienRepository>();
builder.Services.AddScoped<IQLNV_NhomNhanVienRepository, QLNV_NhomNhanVienRepository>();
builder.Services.AddScoped<IQLNV_QuanLyNhanVienRepository, QLNV_QuanLyNhanVienRepository>();
builder.Services.AddScoped<IQLNV_CongViecRepository, QLNV_CongViecRepository>();
builder.Services.AddScoped<IQLNV_DanhGiaRepository, QLNV_DanhGiaRepository>();


builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = IdentityConstants.ApplicationScheme;
    options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
})
    .AddIdentityCookies();

//builder.Services.ConfigureApplicationCookie(options =>
//{
//    // Thiết lập thời gian hết hạn của cookie
//    options.ExpireTimeSpan = TimeSpan.FromHours(5);
//    // Cấu hình để cookie được truyền qua kênh HTTPS nếu được sử dụng trong môi trường production
//    options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
//    // Cấu hình cài đặt bảo mật khác nếu cần thiết
//});

// Thiết định thời gian hết hạn của tất cả các token trong hệ thống
builder.Services.Configure<DataProtectionTokenProviderOptions>(o =>
       o.TokenLifespan = TimeSpan.FromMinutes(30));


// Thiết định sesion
builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);  //you can change the session expired time.  
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});



//var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//    options.UseSqlServer(connectionString));
//builder.Services.AddDatabaseDeveloperPageExceptionFilter();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContextFactory<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// Thiết định khóa tài khoản khi đăng nhập sai nhiều lần
builder.Services.Configure<IdentityOptions>(options =>
{
    // Default Lockout settings.
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.AllowedForNewUsers = true;
});


builder.Services.AddIdentityCore<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();

builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7273") });

var app = builder.Build();

// Thiết định cài đặt timeout cookie
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

//Thiết định Session 
app.UseSession();

// Thiết định middleware tự động xóa cookie sau khi timeout
// Áp dụng middleware chỉ cho các yêu cầu không bắt đầu từ /Account

app.UseCookieExpirationMiddleware();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

// Thiết định SignalR
app.UseResponseCompression();
app.MapHub<NotificationHub>("/notificationHub");

// Add additional endpoints required by the Identity /Account Razor components.
//app.MapAdditionalIdentityEndpoints();

app.Run();