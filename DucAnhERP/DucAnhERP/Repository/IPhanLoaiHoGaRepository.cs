using DucAnhERP.Models;
using DucAnhERP.ViewModel;

namespace DucAnhERP.Repository
{
    public interface IPhanLoaiHoGaRepository : IBaseRepository<MPhanLoaiHoGa>
    {
        Task<List<PhanLoaiHoGaModel>> GetAllByVM();
    }
}
