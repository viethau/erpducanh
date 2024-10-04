using DucAnhERP.ViewModel;
using DucAnhERP.Models;

namespace DucAnhERP.Repository
{
    public interface IPermissionControlRepository : IBaseRepository<MPermissionControl>
    {
        Task<List<PermissionControlModel>> GetAllByVM(PermissionControlModel mModel);
        Task<List<MPermissionControl>> GetExist(MPermissionControl input);
    }
}
