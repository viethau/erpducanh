using DucAnhERP.Models;
using DucAnhERP.ViewModel;
using Microsoft.AspNetCore.Identity;

namespace DucAnhERP.Repository
{
    public interface IPhanQuyenRepository
    {
        Task<bool> CheckPermission(string groupId, string companyId, ApplicationUser user, string permissionId);
        Task<bool> CheckApproval(string companyId, string deptId, ApplicationUser user, string approvalId);
        Task<ApprovalStepSetting> GetApprovalStepSettingById(string id);
        Task<ApprovalStepSetting> GetFirstApprovalStep(string companyId, string majorId, string permissionId);
        Task<ApprovalStepSetting> GetNextApprovalStep(string companyId, string majorId, string permissionId, string departmentId, int departmentOrder, int approvalOrder);
        Task<ApprovalStepSetting> GetLastApprovalStep(string companyId, string majorId, string permissionId);
        Task<List<ApprovalStaffSetting>> GetApprovalStaffByApprovalStepId(string approvalStepId);
    }
}
