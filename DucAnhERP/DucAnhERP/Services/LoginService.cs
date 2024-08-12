using DucAnhERP.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DucAnhERP.Services
{
    public class LoginService : ILoginService
    {

        private readonly Dictionary<string, (string Code, DateTime CreatedAt)> verificationCodes = new Dictionary<string, (string Code, DateTime CreatedAt)>();
        private readonly Random random = new Random();
        private readonly TimeSpan codeExpiryDuration = TimeSpan.FromMinutes(1); // Thời hạn hiệu lực của mã là 5 phút
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IDbContextFactory<ApplicationDbContext> _dbContext;

        public LoginService(IHttpContextAccessor context, IDbContextFactory<ApplicationDbContext> dbContextFactory)
        {
            _contextAccessor = context;
            _dbContext = dbContextFactory;
        }

        public string GenerateVerificationCode(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return null;
            }
            var code = new string(Enumerable.Range(0, 6).Select(_ => random.Next(0, 10).ToString()[0]).ToArray());
            verificationCodes[email] = (code, DateTime.UtcNow);
            return code;
        }

        public bool VerifyCode(string email, string code)
        {
            //if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(code))
            //{
            //    return false;
            //}

            //if (verificationCodes.TryGetValue(email, out var storedCode))
            //{
            //    // Kiểm tra thời hạn hiệu lực của mã
            //    if (DateTime.UtcNow - storedCode.CreatedAt <= codeExpiryDuration)
            //    {
            //        return storedCode.Code == code;
            //    }
            //    else
            //    {
            //        // Xóa mã nếu hết hạn
            //        verificationCodes.Remove(email);
            //    }
            //}
            //return false;
            return true;
        }

        public void ClearVerificationCode(string email)
        {
            verificationCodes.Remove(email);
        }

        public async Task<bool> CheckLogin()
        {
            var _context = _contextAccessor.HttpContext;
            if (_context != null)
            {
                var sessionId = _context.Session.GetString("sessionId");
                var userName = _context.Session.GetString("userName");


                if (!string.IsNullOrEmpty(sessionId) && !string.IsNullOrEmpty(userName))
                {
                    using var userSessionContext = _dbContext.CreateDbContext();
                    var userSession = userSessionContext.UserSessions.FirstOrDefault(s => s.UserName == userName && s.Id == sessionId && s.IsActive == 1);

                    // Phiên làm việc không hợp lệ
                    if (userSession == null)
                    {
                        _context.Session.Clear();
                        //_navigationManager.NavigateToLogin("/Account/Login");
                        return false;
                    }

                    // Thời gian hết hạn là 2 phút
                    if (DateTime.UtcNow - userSession.LastActive > TimeSpan.FromMinutes(30))
                    {
                        _context.Session.Clear();
                        //_navigationManager.NavigateToLogin("/Account/Login");
                        return false;
                    }

                    // Cập nhật thời gian hoạt động
                    userSession.LastActive = DateTime.UtcNow;
                    userSessionContext.Update(userSession);
                    await userSessionContext.SaveChangesAsync();
                }
            } 
            return true;
        }
    }
}
