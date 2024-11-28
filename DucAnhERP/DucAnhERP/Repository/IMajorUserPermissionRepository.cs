using DucAnhERP.Models;
using DucAnhERP.ViewModel;

namespace DucAnhERP.Repository
{
    public interface IMajorUserPermissionRepository : IBaseRepository<MMajorUserPermission>
    {
        Task<List<MMajorUserPermission>> GetByCompanyUser(string companyId, string screenId, string userId);
        Task<MMajorUserPermission> GetMUPById(string id);
        Task DeleteExistPermission(string companyId, string majorId, string userId);

        Task<bool> CheckPermission(string majorId, string screenId, int permissionType);

        Task<List<MajorUserPermissionModel>> GetAllByVM(MajorUserPermissionModel mModel);
        Task<List<MMajorUserPermission>> GetExist(MMajorUserPermission input);

        Task<string> InsertById(MMajorUserPermission entity);
    }
}
