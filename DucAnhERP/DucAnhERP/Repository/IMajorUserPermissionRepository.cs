using DucAnhERP.ViewModel;
using DucAnhERP.Models;

namespace DucAnhERP.Repository
{
    public interface IMajorUserPermissionRepository : IBaseRepository<MMajorUserPermission>
    {
        Task<List<MMajorUserPermission>> GetByCompanyUser(string companyId, string screenId, string userId);

        Task DeleteExistPermission(string companyId, string majorId, string userId);

        Task<bool> CheckPermission(string majorId, string screenId, int permissionType);

        Task<List<MajorUserPermissionModel>> GetAllByVM(MajorUserPermissionModel mModel);
        Task<List<MMajorUserPermission>> GetExist(MMajorUserPermission input);
    }
}
