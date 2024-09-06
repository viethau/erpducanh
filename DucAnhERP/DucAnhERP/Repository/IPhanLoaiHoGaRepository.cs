using DucAnhERP.Models;
using DucAnhERP.ViewModel;

namespace DucAnhERP.Repository
{
    public interface IPhanLoaiHoGaRepository : IBaseRepository<PhanLoaiHoGa>
    {
        Task<List<PhanLoaiHoGaModel>> GetAllByVM();
        Task<bool> CheckUsingId(string id);
    }
}
