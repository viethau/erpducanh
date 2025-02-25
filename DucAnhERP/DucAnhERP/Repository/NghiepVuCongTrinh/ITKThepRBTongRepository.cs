using DucAnhERP.Helpers;
using DucAnhERP.Models.NghiepVuCongTrinh;
using DucAnhERP.ViewModel.NghiepVuCongTrinh;

namespace DucAnhERP.Repository.NghiepVuCongTrinh
{
    public interface ITKThepRBTongRepository :IBaseRepository<TKThepRBTong>
    {
        Task<string> InsertLaterFlag(TKThepRBTong entity, int FlagLast, bool insertBefore);
        Task<List<TKThepRBTongModel>> GetAllByVM(TKThepRBTongModel mModel);
        Task<List<TKThepRBTong>> GetExist(TKThepRBTong searchData);
        Task<List<SelectedItem>> GetDistinctTenCongTacByPL(string ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai);

    }
}
