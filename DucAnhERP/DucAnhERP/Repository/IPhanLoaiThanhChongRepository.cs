using DucAnhERP.Models;
using DucAnhERP.ViewModel;

namespace DucAnhERP.Repository
{
    public interface IPhanLoaiThanhChongRepository : IBaseRepository<PhanLoaiThanhChong>
    {
        Task<List<PhanLoaiThanhChongModel>> GetAllByVM();
        Task<bool> CheckUsingId(string id);
        Task<bool> CheckUsingName(string name);
        Task<PhanLoaiThanhChong> GetPhanLoaiThanhChongByDetail(PhanLoaiThanhChong plmc);
        Task<PhanLoaiThanhChong> GetPhanLoaiThanhChongExist(PhanLoaiThanhChong plmc);
        Task<string> InsertId(PhanLoaiThanhChong entity, string CTTC);
        Task<string> InsertLaterFlag(PhanLoaiThanhChong entity, int FlagLast);
    }
}
