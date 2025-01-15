using DucAnhERP.ViewModel;
using DucAnhERP.Models;
namespace DucAnhERP.Repository
{
    public interface IQD_BoiThuong_GocRepository : IBaseRepository<QD_BoiThuong_Goc>
    {
        Task<List<QD_BoiThuong_GocModel>> GetAllByVM(QD_BoiThuong_GocModel dataModel, string groupId);
        Task<List<QD_BoiThuong_GocModel>> GetHistoryIsValidEdit(string id);
        Task<QD_BoiThuong_GocModel> GetDetails(string id);
        Task<List<QD_BoiThuong_GocModel>> GetHistory(string id);
        Task<List<ChiNhanhModel>>? GetChiNhanhsForCompanyId(string groupId);
        Task<bool> CheckSave(QD_BoiThuong_Goc input);
        Task<bool> CheckEdit(QD_BoiThuong_Goc input);
        Task<bool> CheckDelete(QD_BoiThuong_Goc input);
    }
}
