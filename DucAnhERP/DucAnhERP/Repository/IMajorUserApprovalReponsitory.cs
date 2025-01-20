using DucAnhERP.Models;
using DucAnhERP.ViewModel;

namespace DucAnhERP.Repository
{
    public interface IMajorUserApprovalReponsitory  : IBaseRepository<MajorUserApproval>
    {
        Task<List<MajorUserApprovalModel>> GetAllByVM(MajorUserApprovalModel dataModel, string groupId);
        Task<List<MajorUserApproval>> GetByIdMain(string id);
        MajorUserApprovalModel GetToEdit(string id);
        Task<List<MajorUserApprovalModel>> GetHistory(string id);
        Task UpdateMulti(List<MajorUserApproval> majorUserApprovals, string idMain);
        Task<bool> CheckSave(MajorUserApproval input);
        Task<bool> CheckEdit(MajorUserApproval input);
        Task<bool> CheckDelete(MajorUserApproval input);
        Task<bool> CheckExclusive(string[] ids, DateTime baseTime);
    }
}
