using DucAnhERP.Helpers;
using DucAnhERP.Models.NghiepVuCongTrinh;
using DucAnhERP.ViewModel.NghiepVuCongTrinh;

namespace DucAnhERP.Repository.NghiepVuCongTrinh
{
    public interface ITKThepDeCongRepository :IBaseRepository<TKThepDCong>
    {
        Task<string> InsertLaterFlag(TKThepDCong entity, int FlagLast, bool insertBefore);
        Task<List<TKThepDCongModel>> GetAllByVM(TKThepDCongModel mModel);
        Task<List<TKThepDCong>> GetExist(TKThepDCong searchData);
        Task<List<SelectedItem>> GetDistinctTenCongTacByPL(string ThongTinDeCong_TenLoaiDeCong);
    }
}
