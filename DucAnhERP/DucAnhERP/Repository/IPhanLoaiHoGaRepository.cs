using DucAnhERP.Models;
using DucAnhERP.ViewModel;

namespace DucAnhERP.Repository
{
    public interface IPhanLoaiHoGaRepository : IBaseRepository<PhanLoaiHoGa>
    {
        Task<List<PhanLoaiHoGaModel>> GetAllByVM();
        Task<bool> CheckUsingId(string id);
        Task<bool> CheckUsingName(string name);
        Task<PhanLoaiHoGa> GetPhanLoaiHoGaByDetail(PhanLoaiHoGa pltdhg);
        Task<PhanLoaiHoGa> GetPhanLoaiHoGaExist(PhanLoaiHoGa searchData );
        Task<string> InsertId(PhanLoaiHoGa entity, string HoGa_KetCauTuong);
        Task<string> InsertLaterFlag(PhanLoaiHoGa entity, int FlagLast);
    }
}
