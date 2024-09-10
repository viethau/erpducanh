using DucAnhERP.Models;
using DucAnhERP.ViewModel;

namespace DucAnhERP.Repository
{
    public interface IPhanLoaiTDHoGaRepository : IBaseRepository<PhanLoaiTDHoGa>
    {
        Task<List<PhanLoaiTDHoGaModel>> GetAllByVM();
        Task<bool> CheckUsingId(string id);
        Task<PhanLoaiTDHoGa> GetMPhanLoaiTDHoGaByDetail(PhanLoaiTDHoGa pltdhg);
        Task<string> InsertId(PhanLoaiTDHoGa entity, string HinhThucDayHoGa);
    }
}
