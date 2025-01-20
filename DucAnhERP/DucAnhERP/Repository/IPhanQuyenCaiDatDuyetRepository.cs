using DucAnhERP.Models;
using DucAnhERP.ViewModel;

namespace DucAnhERP.Repository
{
    public interface IPhanQuyenCaiDatDuyetRepository : IBaseRepository<PhanQuyenCaiDatDuyet>
    {
        Task<List<PhanQuyenCaiDatDuyetModel>> GetAllByVM(PhanQuyenCaiDatDuyetModel dataModel, string groupId);
        Task<List<PhanQuyenCaiDatDuyetModel>> GetHistoryIsValidEdit(string id);
        Task<PhanQuyenCaiDatDuyetModel> GetDetails(string id);
        Task<List<PhanQuyenCaiDatDuyetModel>> GetHistory(string id);
        Task<List<ChiNhanhModel>>? GetChiNhanhsForCompanyId(string groupId);
        Task<List<MajorModel>>? GetMajorsForParentMajorId(string groupId);
        Task<List<MajorModel>>? GetMajorsForMajorId(string groupId);
        Task<List<ApplicationUserModel>>? GetApplicationUsersForUserId(string groupId);
        Task<bool> CheckSave(PhanQuyenCaiDatDuyet input);
        Task<bool> CheckEdit(PhanQuyenCaiDatDuyet input);
        Task<bool> CheckDelete(PhanQuyenCaiDatDuyet input);
    }
}
