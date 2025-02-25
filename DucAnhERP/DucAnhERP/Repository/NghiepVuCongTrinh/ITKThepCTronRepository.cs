using DucAnhERP.Helpers;
using DucAnhERP.Models.NghiepVuCongTrinh;
using DucAnhERP.ViewModel.NghiepVuCongTrinh;

namespace DucAnhERP.Repository.NghiepVuCongTrinh
{
    public interface ITKThepCTronRepository :IBaseRepository<TKThepCTron>
    {
        Task<string> InsertLaterFlag(TKThepCTron entity, int FlagLast, bool insertBefore);
        Task<List<TKThepCTronModel>> GetAllByVM(TKThepCTronModel mModel);
        Task<List<TKThepCTron>> GetExist(TKThepCTron searchData);
        Task<List<SelectedItem>> GetDistinctTenCongTacByPL(string ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai);
    }
}
