using DucAnhERP.Helpers;
using DucAnhERP.Models;
using DucAnhERP.ViewModel;

namespace DucAnhERP.Repository
{
    public interface ITKThepDeCongRepository :IBaseRepository<TKThepDCong>
    {
        Task<string> InsertLaterFlag(TKThepDCong entity, int FlagLast);
        Task<List<TKThepDCongModel>> GetAllByVM(TKThepDCongModel mModel);
        Task<List<TKThepDCong>> GetExist(TKThepDCong searchData);
        Task<List<SelectedItem>> GetDistinctTenCongTacByPL(string ThongTinDeCong_TenLoaiDeCong);
    }
}
