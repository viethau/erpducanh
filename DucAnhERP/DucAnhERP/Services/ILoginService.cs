using DucAnhERP.Models;

namespace DucAnhERP.Services
{
    public interface ILoginService
    {
        string GenerateVerificationCode(string email);

        bool VerifyCode (string email, string code);

        void ClearVerificationCode(string email);

        Task<bool> CheckLogin();
    }
}
