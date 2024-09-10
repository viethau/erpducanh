using DucAnhERP.Models;
using DucAnhERP.ViewModel;

namespace DucAnhERP.Repository
{
    public interface IPhanLoaiCTronHopNhuaRepository : IBaseRepository<PhanLoaiCTronHopNhua>
    {
        Task<List<PhanLoaiCTronHopNhuaModel>> GetAllByVM();
        Task<bool> CheckUsingId(string id);
        Task<PhanLoaiCTronHopNhua> GetMPhanLoaiCTronHopNhuaByDetail(PhanLoaiCTronHopNhua pltdhg);
        Task<string> InsertId(PhanLoaiCTronHopNhua entity, string HinhThucTD, string LoaiTD);
    }
}
