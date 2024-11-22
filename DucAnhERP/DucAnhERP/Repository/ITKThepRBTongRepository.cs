using DucAnhERP.Helpers;
using DucAnhERP.Models;
using DucAnhERP.ViewModel;

namespace DucAnhERP.Repository
{
    public interface ITKThepRBTongRepository :IBaseRepository<TKThepRBTong>
    {
        Task<string> InsertLaterFlag(TKThepRBTong entity, int FlagLast);
        Task<List<TKThepRBTongModel>> GetAllByVM(TKThepRBTongModel mModel);
        Task<List<TKThepRBTong>> GetExist(TKThepRBTong searchData);
        Task<List<SelectedItem>> GetDistinctTenCongTacByPL(string ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai);

    }
}
