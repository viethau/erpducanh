using DucAnhERP.ViewModel;
using DucAnhERP.Models;

namespace DucAnhERP.Repository
{
    public interface IPermissionRepository : IBaseRepository<MPermission>
    {
        Task<List<PermissionModel>> GetAllCorePermission(string majorId, string companyId);
        Task<List<MPermission>> GetAllMPermissions();
        Task<List<PermissionModel>> GetAllByVM(PermissionModel permissionModel);
        Task<List<MPermission>> GetExist(MPermission input);
    }
}
