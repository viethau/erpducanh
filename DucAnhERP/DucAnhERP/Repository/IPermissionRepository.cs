using DucAnhERP.ViewModel;
using DucAnhERP.Models;

namespace DucAnhERP.Repository
{
    public interface IPermissionRepository : IBaseRepository<MPermission>
    {
        Task<List<PermissionModel>> GetAllCorePermission(string majorId, string companyId);

    }
}
