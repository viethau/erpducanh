using DucAnhERP.ViewModel;
using DucAnhERP.Models;

namespace DucAnhERP.Repository
{
    public interface IQD_ThuHoiDat_GocRepository : IBaseRepository<QD_ThuHoiDat_Goc>
    {
        Task<List<QD_ThuHoiDat_GocModel>> GetAllByVM(QD_ThuHoiDat_GocModel dataModel, string groupId);
        Task<List<QD_ThuHoiDat_GocModel>> GetHistoryIsValidEdit(string id);
        Task<QD_ThuHoiDat_GocModel> GetDetails(string id);
        Task<List<ChiNhanhModel>> GetChiNhanhs(string groupId);
        Task<bool> CheckSave(QD_ThuHoiDat_Goc input);
        Task<bool> CheckEdit(QD_ThuHoiDat_Goc input);
        Task<bool> CheckDelete(QD_ThuHoiDat_Goc input);
    }
}
