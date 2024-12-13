using DucAnhERP.Models;
using DucAnhERP.ViewModel;

namespace DucAnhERP.Repository
{
    public interface IPhanLoaiCTronHopNhuaRepository : IBaseRepository<PhanLoaiCTronHopNhua>
    {
        Task<List<PhanLoaiCTronHopNhuaModel>> GetAllByVM(PhanLoaiCTronHopNhuaModel input);
        Task<bool> CheckUsingId(string id);
        Task<bool> CheckUsingName(string name);
        Task<PhanLoaiCTronHopNhua> GetPhanLoaiCTronHopNhuaByDetail(PhanLoaiCTronHopNhua pltdhg);
        Task<PhanLoaiCTronHopNhua> GetPhanLoaiCTronHopNhuaExist(PhanLoaiCTronHopNhua searchData);
        Task<string> InsertId(PhanLoaiCTronHopNhua entity, string HinhThucTD, string LoaiTD);

        Task<string> InsertLaterFlag(PhanLoaiCTronHopNhua entity, int FlagLast);
    }
}
