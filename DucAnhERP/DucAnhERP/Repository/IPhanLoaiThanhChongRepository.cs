using DucAnhERP.Models;
using DucAnhERP.ViewModel;

namespace DucAnhERP.Repository
{
    public interface IPhanLoaiThanhChongRepository : IBaseRepository<PhanLoaiThanhChong>
    {
        Task<List<PhanLoaiThanhChongModel>> GetAllByVM();
        Task<bool> CheckUsingId(string id);
        Task<PhanLoaiThanhChong> GetMPhanLoaiThanhChongByDetail(PhanLoaiThanhChong plmc);
        Task<string> InsertId(PhanLoaiThanhChong entity, string CTTC);
    }
}
