using DucAnhERP.ViewModel;
using DucAnhERP.Models;
using System.ComponentModel.Design;
namespace DucAnhERP.Repository
{
    public interface IApprovalDeptSettingRepository : IBaseRepository<ApprovalDeptSetting>
    {
        Task<List<ApprovalDeptSettingModel>> GetAllByVM(ApprovalDeptSettingModel dataModel, string groupId);
        Task<List<ChiNhanhModel>> GetChiNhanhs(string groupId);
        Task<List<DepartmentModel>> GetDepartments(string groupId);
        Task<List<MajorModel>> GetMajors(string groupId);
        Task<List<MajorModel>> GetMajorsByParentId(string parentId);
        Task<bool> CreateApprovalDeptSetting(List<ApprovalDeptWrapper> approvalRowWrappers, DateTime baseTime);
        Task<List<ApprovalDeptSettingModel>> GetSetApprovalDept(string companyId, string majorId, string screenId);

        Task<List<ApprovalDeptSettingData>> GetData(string groupId);
        Task<List<ApprovalDeptSetting>> GetByMainId(string mainId);
        Task<bool> DeleteApprovalDeptSetting(string mainId);
        Task<bool> CheckSave(string companyId, string majorId, string mainId, bool loai);
        Task<bool> CheckDelete(string companyId, string majorId);
        Task<List<ChiNhanh>> CheckChoDuyet(string id);
    }
}
