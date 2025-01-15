using DucAnhERP.ViewModel;
using DucAnhERP.Models;

namespace DucAnhERP.Repository
{
    public interface IPermissionRepository : IBaseRepository<Permission>
    {
        Task<List<PermissionModel>> GetAllCorePermission(string majorId, string companyId);
        Task<List<Permission>> GetAllMPermissions();
        Task<List<PermissionModel>> GetAllByVM(PermissionModel permissionModel);
        Task<List<Permission>> GetExist(Permission input);
        Task<List<Permission>> LoadByMajor(string majorId);
        List<Permission> LoadByMajor1(string majorId);
        Task<List<Permission>> LoadToApproval(string majorId); 
    }
}
