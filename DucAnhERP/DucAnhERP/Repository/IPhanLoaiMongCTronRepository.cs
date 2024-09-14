using DucAnhERP.Models;
using DucAnhERP.Repository;
using DucAnhERP.ViewModel;

namespace DucAnhERP.Repository
{
    public interface IPhanLoaiMongCTronRepository : IBaseRepository<PhanLoaiMongCTron>
    {
        Task<List<PhanLoaiMongCongModel>> GetAllByVM();
        Task<bool> CheckUsingId(string id);
        Task<PhanLoaiMongCTron> GetMPhanLoaiMongCTronByDetail(PhanLoaiMongCTron pltdhg);
        Task<string> InsertId(PhanLoaiMongCTron entity, string LoaiTD, string LoaiM, string HTM);
        Task<string> InsertLaterFlag(PhanLoaiMongCTron entity, int FlagLast);
    }
}
