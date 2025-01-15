using DucAnhERP.ViewModel;
using DucAnhERP.Models;
namespace DucAnhERP.Repository
{
    public interface IApprovalControlRepository : IBaseRepository<ApprovalControl>
    {
        Task<List<ApprovalControlModel>> GetAllByVM(ApprovalControlModel dataModel, string groupId);
        Task<List<ChiNhanhModel>> GetChiNhanhs(string groupId);
        Task<List<MajorModel>> GetParentMajors(string groupId);
        Task<List<MajorModel>> GetMMajors(string groupId);
        Task<List<ApplicationUserModel>> GetApplicationUsers(string groupId);
    }
}
