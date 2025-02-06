using DucAnhERP.Models;
using DucAnhERP.ViewModel;

namespace DucAnhERP.Repository
{
    public interface IApprovalStepSettingRepository : IBaseRepository<ApprovalStepSetting>
    {
        Task<List<ApprovalStepSettingModel>> GetAllByVM(ApprovalStepSettingModel dataModel, string groupId);
        Task<List<ChiNhanhModel>> GetChiNhanhs(string groupId);
        Task<List<DepartmentModel>> GetDepartments(string groupId);
        Task<List<MajorModel>> GetMajors(string groupId);
        Task<List<MajorModel>> GetMajorsByParentId(string parentId);
        Task<bool> CreateApprovalStepSetting(List<ApprovalStepWrapper> approvalRowWrappers, DateTime baseTime);
        Task<List<ApprovalStepSettingModel>> GetSetApprovalStep(string companyId, string majorId, string screenId);

        Task<List<ApprovalStepSettingData>> GetData(string groupId);
        Task<List<ApprovalStepSetting>> GetByMainId(string mainId);
        ApprovalDeptSetting GetIdApprodeptSetting(string companyId, string majorId, string deptId);
        Task<bool> DeleteApprovalStepSetting(string mainId);
        Task<bool> CheckSave(string companyId, string majorId, string deptId, string permissionId, string mainId, bool loai);
        Task<bool> CheckDelete(string companyId, string majorId);
        Task<List<ChiNhanh>> CheckChoDuyet(string id);
        Task<List<Major>> LoadParentMajors(string companyId);
        Task<List<Major>> LoadMajors(string companyId, string parentMajorId);
        Task<List<Department>> LoadDepartments(string companyId, string parentMajorId, string majorId);

        Task<List<Major>> LoadParentMajorsByMajorUserApproval(string companyId, string[] parentMajorIds);
        Task<List<Major>> LoadMajorsByMajorUserApproval(string companyId, string parentMajorId, string[] majors);
        Task<List<Permission>> LoadPermissionsByApprovalControl(ApprovalControl input);
        Task<List<ApprovalStepSetting>> LoadStepByApprovalControl(ApprovalControl input);

        Task<List<ApprovalStepSetting>> LoadStepByMajorUserApproval(MajorUserApproval input);
        Task<List<Permission>> LoadPermissionsByMajorUserApproval(MajorUserApproval input);
    }
}
