using DucAnhERP.Models;

namespace DucAnhERP.Repository
{
    public interface IUserSessionRepository : IBaseRepository<UserSession>
    {
        Task<UserSession> GetByUserName(string userName);
    }
}
