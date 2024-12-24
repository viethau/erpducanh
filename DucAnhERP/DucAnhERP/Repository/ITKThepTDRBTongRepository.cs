using DucAnhERP.Helpers;
using DucAnhERP.Models;
using DucAnhERP.ViewModel;

namespace DucAnhERP.Repository
{
    public interface ITKThepTDRBTongRepository : IBaseRepository<TKThepTDRBTong>
    {
        Task<string> InsertLaterFlag(TKThepTDRBTong entity, int FlagLast, bool insertBefore);
        Task<List<TKThepTDRBTongModel>> GetAllByVM(TKThepTDRBTongModel mModel);
        Task<List<TKThepTDRBTong>> GetExist(TKThepTDRBTong searchData);
        Task<List<SelectedItem>> GetDistinctTenCongTacByPL(string ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai);
    }
}
