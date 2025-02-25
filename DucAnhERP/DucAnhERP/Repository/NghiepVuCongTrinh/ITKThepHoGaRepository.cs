using DucAnhERP.Helpers;
using DucAnhERP.Models.NghiepVuCongTrinh;
using DucAnhERP.ViewModel.NghiepVuCongTrinh;

namespace DucAnhERP.Repository.NghiepVuCongTrinh
{
    public interface ITKThepHoGaRepository :IBaseRepository<TKThepHoGa>
    {
        Task<string> InsertLaterFlag(TKThepHoGa entity, int FlagLast, bool insertBefore);
        Task<List<TKThepHoGaModel>> GetAllByVM(TKThepHoGaModel mModel);
        Task<List<TKThepHoGa>> GetExist(TKThepHoGa searchData);
        Task<List<SelectedItem>> GetDistinctTenCongTacByPL(string ThongTinChungHoGa_TenHoGaSauPhanLoai);
    }
}
