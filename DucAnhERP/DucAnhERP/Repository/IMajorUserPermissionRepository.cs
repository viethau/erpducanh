using DucAnhERP.ViewModel;
using DucAnhERP.Models;

namespace DucAnhERP.Repository
{
    public interface IMajorUserPermissionRepository : IBaseRepository<MajorUserPermission>
    {
        MajorUserPermissionModel GetToEdit(string id);
        Task<List<MajorUserPermissionModel>> GetAllByVM(MajorUserPermissionModel dataModel, string groupId);
        Task<List<MajorUserPermissionModel>> GetHistoryIsValidEdit(string id);
        Task<MajorUserPermissionModel> GetDetails(string id);
        Task<List<MajorUserPermissionModel>> GetHistory(string id);
        Task<List<MajorUserPermission>> GetByIdMain(string id);
        Task UpdateMulti(List<MajorUserPermission> MajorUserPermissions, string idMain);
        Task InsertMulti(List<MajorUserPermission> MajorUserPermissions);
        Task<List<ChiNhanhModel>>? GetChiNhanhsForCompanyId(string groupId);
        Task<List<MajorModel>>? GetMajorsForParentMajorId(string groupId);
        Task<List<MajorModel>>? GetMajorsForMajorId(string groupId);
        Task<List<ApplicationUserModel>>? GetApplicationUsersForUserId(string groupId);
        Task<List<PermissionModel>>? GetPermissionsForPermissionId(string groupId);
        Task<bool> CheckSave(MajorUserPermission input);
        Task<bool> CheckEdit(MajorUserPermission input);
        Task<bool> CheckDelete(MajorUserPermission input);
    }
}
