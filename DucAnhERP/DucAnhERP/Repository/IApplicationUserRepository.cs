using DucAnhERP.ViewModel;
using DucAnhERP.Models;

namespace DucAnhERP.Repository
{
    public interface IApplicationUserRepository : IBaseRepository<ApplicationUser>
    {
        Task<List<ApplicationUserModel>> GetAllByVM(ApplicationUserModel dataModel, string groupId);
        Task<List<ChiNhanhModel>> GetChiNhanhs(string groupId);
        Task<List<DepartmentModel>> GetDepartments(string groupId);
        ApplicationUser GetByUserName(string userName);
        bool IsExistByPhoneNumber(string phoneNumber);
    }
}

//GetByUserName
//IsExistByPhoneNumber
//            Insert
