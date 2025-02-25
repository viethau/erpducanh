using DucAnhERP.Helpers;
using DucAnhERP.Models.NghiepVuCongTrinh;
using DucAnhERP.ViewModel.NghiepVuCongTrinh;

namespace DucAnhERP.Repository.NghiepVuCongTrinh
{
    public interface ITKThepTDanRXayRepository :IBaseRepository<TKThepTDanRXay>
    {
        Task<string> InsertLaterFlag(TKThepTDanRXay entity, int FlagLast, bool insertBefore);
        Task<List<TKThepTDanRXayModel>> GetAllByVM(TKThepTDanRXayModel mModel);
        Task<List<TKThepTDanRXay>> GetExist(TKThepTDanRXay searchData);
        Task<List<SelectedItem>> GetDistinctTenCongTacByPL(string TTTDCongHoRanh_TenLoaiTamDanTieuChuan);
    }
}
