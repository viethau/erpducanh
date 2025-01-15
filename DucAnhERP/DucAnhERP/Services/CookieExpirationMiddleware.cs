using DucAnhERP.Data;
using DucAnhERP.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DucAnhERP.Services
{

    public class CookieExpirationMiddleware
    {
        private readonly RequestDelegate _next;

        private readonly IDbContextFactory<ApplicationDbContext> _dbContext;

        public CookieExpirationMiddleware(RequestDelegate next, IDbContextFactory<ApplicationDbContext> dbContextFactory)
        {
            _next = next;
            _dbContext = dbContextFactory;
        }

        public async Task Invoke(HttpContext context)
        {
            context.Response.Cookies.Delete("AspNetCore.Identity.Application");
            // Kiểm tra trạng thái đăng nhập
            if (!context.Request.Path.StartsWithSegments("/Account"))
            {
                var sessionId = context.Session.GetString("sessionId");
                var userName = context.Session.GetString("userName");

                if (!string.IsNullOrEmpty(sessionId) && !string.IsNullOrEmpty(userName))
                {
                    using var userSessionContext = _dbContext.CreateDbContext();
                    var userSession = userSessionContext.UserSessions.FirstOrDefault(s => s.UserName == userName && s.Id == sessionId && s.IsActive == 1);

                    // Cập nhật thời gian hoạt động
                    if (userSession != null)
                    {
                        userSession.LastActive = DateTime.UtcNow;
                        userSessionContext.Update(userSession);
                        await userSessionContext.SaveChangesAsync();
                    }

                }
            }

            // Kiểm tra cookie và xóa nếu cần thiết
            if (context.Request.Cookies.TryGetValue("AspNetCore.Identity.Application", out string cookieValue))
            {
                // Thời gian hiện tại
                var currentTime = DateTimeOffset.UtcNow;

                // Thời gian hết hạn của cookie (tính từ thời điểm tạo cookie)
                var cookieExpirationTime = context.Response.Headers["Set-Cookie"].ToString();
                var expirationTime = DateTimeOffset.Parse(cookieExpirationTime.Substring(cookieExpirationTime.IndexOf("Expires=") + 8, 29));

                // Xóa cookie nếu đã hết hạn
                if (expirationTime <= currentTime)
                {
                    context.Response.Cookies.Delete("AspNetCore.Identity.Application");
                }
            }

            // Chuyển xử lý tiếp theo
            await _next(context);
        }
    }

    public static class CookieExpirationMiddlewareExtensions
    {
        public static IApplicationBuilder UseCookieExpirationMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CookieExpirationMiddleware>();
        }
    }

}
