using DucAnhERP.Models;
using DucAnhERP.ViewModel;

namespace DucAnhERP.Repository
{
    public interface IPhanLoaiTDHoGaRepository : IBaseRepository<PhanLoaiTDHoGa>
    {
        Task<List<PhanLoaiTDHoGaModel>> GetAllByVM();
        Task<bool> CheckUsingId(string id);
        Task<bool> CheckUsingName(string name);
        Task<PhanLoaiTDHoGa> GetPhanLoaiTDHoGaByDetail(PhanLoaiTDHoGa pltdhg);
        Task<PhanLoaiTDHoGa> GetPhanLoaiTDHoGaExist(PhanLoaiTDHoGa searchData);
        Task<string> InsertId(PhanLoaiTDHoGa entity, string HinhThucDayHoGa);
        Task<string> InsertLaterFlag(PhanLoaiTDHoGa entity, int FlagLast);
    }
}
