using DucAnhERP.Helpers;
using DucAnhERP.Models;
using DucAnhERP.ViewModel;

namespace DucAnhERP.Repository
{
    public interface ITKThepTamDanRepository : IBaseRepository<TKThepTamDan>
    {
        Task<string> InsertLaterFlag(TKThepTamDan entity, int FlagLast);
        Task<List<TKThepTamDanModel>> GetAllByVM(TKThepTamDanModel mModel);
        Task<List<TKThepTamDan>> GetExist(TKThepTamDan searchData);
        Task<List<SelectedItem>> GetDistinctTenCongTacByPL(string ThongTinTamDanHoGa2_PhanLoaiDayHoGa);
    }
}
