using DucAnhERP.Models;
using DucAnhERP.ViewModel;

namespace DucAnhERP.Repository
{
    public interface IPhanLoaiDeCongRepository : IBaseRepository<PhanLoaiDeCong>
    {
        Task<List<PhanLoaiDeCongModel>> GetAllByVM();
        Task<bool> CheckUsingId(string id);
        Task<PhanLoaiDeCong> GetMPhanLoaiDeCongByDetail(PhanLoaiDeCong plmc);
        Task<string> InsertId(PhanLoaiDeCong entity, string CTDC, string LoaiTD);
    }
}
