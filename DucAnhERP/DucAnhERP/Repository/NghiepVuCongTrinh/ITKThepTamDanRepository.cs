using DucAnhERP.Helpers;
using DucAnhERP.Models.NghiepVuCongTrinh;
using DucAnhERP.ViewModel.NghiepVuCongTrinh;

namespace DucAnhERP.Repository.NghiepVuCongTrinh
{
    public interface ITKThepTamDanRepository : IBaseRepository<TKThepTamDan>
    {
        Task<string> InsertLaterFlag(TKThepTamDan entity, int FlagLast, bool insertBefore);
        Task<List<TKThepTamDanModel>> GetAllByVM(TKThepTamDanModel mModel);
        Task<List<TKThepTamDan>> GetExist(TKThepTamDan searchData);
        Task<List<SelectedItem>> GetDistinctTenCongTacByPL(string ThongTinTamDanHoGa2_PhanLoaiDayHoGa);
    }
}
