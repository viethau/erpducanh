using DucAnhERP.Models;
using DucAnhERP.ViewModel;

namespace DucAnhERP.Repository
{
    public interface IApprovalStepSettingRepository : IBaseRepository<ApprovalStepSetting>
    {
        Task<bool> CreateApprovalStepSetting(List<ApprovalStepWrapper> approvalRowWrappers, DateTime baseTime);

        Task<List<ApprovalStepSettingModel>> GetSetApprovalStep(string companyId, string majorId, string deptId, int operation, string screenId);
    }
}
