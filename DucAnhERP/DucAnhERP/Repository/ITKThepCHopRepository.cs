using DucAnhERP.Helpers;
using DucAnhERP.Models;
using DucAnhERP.ViewModel;

namespace DucAnhERP.Repository
{
    public interface ITKThepCHopRepository : IBaseRepository<TKThepCHop>
    {
        Task<string> InsertLaterFlag(TKThepCHop entity, int FlagLast, bool insertBefore);
        Task<List<TKThepCHopModel>> GetAllByVM(TKThepCHopModel mModel);
        Task<List<TKThepCHop>> GetExist(TKThepCHop searchData);
        Task<List<SelectedItem>> GetDistinctTenCongTacByPL(string ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai);

        
    }
}
