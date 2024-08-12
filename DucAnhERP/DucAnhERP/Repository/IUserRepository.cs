using DucAnhERP.Models;

namespace DucAnhERP.Repository
{
    public interface IUserRepository : IBaseRepository<ApplicationUser>
    {
        ApplicationUser GetByUserName(string userName);

        bool IsExistByPhoneNumber(string phoneNumber);

        Task<ApplicationUser> GetById(string id, int isActive);

    }
}
