using DucAnhERP.Helpers;
using DucAnhERP.Models.NghiepVuCongTrinh;
using DucAnhERP.ViewModel.NghiepVuCongTrinh;

namespace DucAnhERP.Repository.NghiepVuCongTrinh
{
    public interface ITKThepRXayRepository :IBaseRepository<TKThepRXay>
    {
        Task<string> InsertLaterFlag(TKThepRXay entity, int FlagLast, bool insertBefore);
        Task<List<TKThepRXayModel>> GetAllByVM(TKThepRXayModel mModel);
        Task<List<TKThepRXay>> GetExist(TKThepRXay searchData);
        Task<List<SelectedItem>> GetDistinctTenCongTacByPL(string ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai);
    }
}
