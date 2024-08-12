using DucAnhERP.ViewModel;
using DucAnhERP.Models;

namespace DucAnhERP.Repository
{
    public interface IPermissionControlRepository : IBaseRepository<MPermissionControl>
    {
        Task<MPermissionControl> IsExistPermission(string companyId, string majorId, string userId);

        Task<bool> InsertPermission(MajorUserPermissionModel majorUserPermission, List<PermissionModel> corePermission);
    }
}
