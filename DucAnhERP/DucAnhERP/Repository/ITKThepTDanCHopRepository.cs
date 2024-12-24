using DucAnhERP.Helpers;
using DucAnhERP.Models;
using DucAnhERP.ViewModel;

namespace DucAnhERP.Repository
{
    public interface ITKThepTDanCHopRepository :IBaseRepository<TKThepTDanCHop>
    {
        Task<string> InsertLaterFlag(TKThepTDanCHop entity, int FlagLast, bool insertBefore);
        Task<List<TKThepTDanCHopModel>> GetAllByVM(TKThepTDanCHopModel mModel);
        Task<List<TKThepTDanCHop>> GetExist(TKThepTDanCHop searchData);
        Task<List<SelectedItem>> GetDistinctTenCongTacByPL(string TTTDCongHoRanh_TenLoaiTamDanTieuChuan);
    }
}
