using DucAnhERP.Models;
using DucAnhERP.ViewModel;

namespace DucAnhERP.Repository
{
    public interface IPhanLoaiDeCongRepository : IBaseRepository<PhanLoaiDeCong>
    {
        Task<List<PhanLoaiDeCongModel>> GetAllByVM();
        Task<bool> CheckUsingId(string id);
        Task<bool> CheckUsingName(string name);
        Task<PhanLoaiDeCong> GetPhanLoaiDeCongByDetail(PhanLoaiDeCong plmc);
        Task<PhanLoaiDeCong> GetPhanLoaiDeCongExist(PhanLoaiDeCong searchData);
        Task<string> InsertId(PhanLoaiDeCong entity, string CTDC, string LoaiTD);
        Task<string> InsertLaterFlag(PhanLoaiDeCong entity, int FlagLast);
    }
}
