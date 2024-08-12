using DucAnhERP.ViewModel;
using DucAnhERP.Models;

namespace DucAnhERP.Repository
{
    public interface IMajorUserPermissionRepository : IBaseRepository<MMajorUserPermission>
    {
        Task<List<MMajorUserPermission>> GetByCompanyUser(string companyId, string screenId, string userId);

        Task DeleteExistPermission(string companyId, string majorId, string userId, string screenId);

        Task<bool> CheckPermission(string majorId, string screenId, int permissionType);
    }
}
