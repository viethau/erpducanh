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
builder.Services.AddScoped<IMajorRepository, MajorRepository>();
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
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
builder.Services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();
builder.Services.AddScoped<IDanhMucRepository, DanhMucRepository>();
builder.Services.AddScoped<INhomDanhMucRepository, NhomNhomDanhMucRepository>();
builder.Services.AddScoped<IHopRanhThangRepository, HopRanhThangRepository>();
builder.Services.AddScoped<IExcelRepository, ExcelRepository>();
builder.Services.AddScoped<INuocMuaRepository, NuocMuaRepository>();
builder.Services.AddScoped<IPhanLoaiHoGaRepository, PhanLoaiHoGaRepository>();
builder.Services.AddScoped<IPhanLoaiTDHoGaRepository, PhanLoaiTDHoGaRepository>();
builder.Services.AddScoped<IPhanLoaiCTronHopNhuaRepository, PhanLoaiCTronHopNhuaRepository>();
builder.Services.AddScoped<IPhanLoaiMongCTronRepository, PhanLoaiMongCTronRepository>();
builder.Services.AddScoped<IPhanLoaiDeCongRepository, PhanLoaiDeCongRepository>();
builder.Services.AddScoped<IPhanLoaiThanhChongRepository, PhanLoaiThanhChongRepository>();
builder.Services.AddScoped<IPhanLoaiTDanTDanRepository, PhanLoaiTDanTDanRepository>();
builder.Services.AddScoped<IMangThuRepository, MangThuRepository>();
builder.Services.AddScoped<ITKThepHoGaRepository, TKThepHoGaRepository>();
builder.Services.AddScoped<ITKThepTamDanRepository, TKThepTamDanRepository>();
builder.Services.AddScoped<IDMTLThepRepository, DMTLThepRepository>();




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
