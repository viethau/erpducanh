using DucAnhERP.ViewModel;
using DucAnhERP.Models;

namespace DucAnhERP.Repository
{
    public interface IApprovalDeptSettingRepository : IBaseRepository<ApprovalDeptSetting>
    {
        Task<bool> CreateApprovalDeptSetting(List<ApprovalDeptWrapper> approvalRowWrappers, DateTime baseTime);

        Task<List<ApprovalDeptSettingModel>> GetSetApprovalDept(string companyId, string majorId, string screenId);
    }
}
