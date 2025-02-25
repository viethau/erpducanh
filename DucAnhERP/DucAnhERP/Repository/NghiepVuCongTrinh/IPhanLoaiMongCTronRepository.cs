using DucAnhERP.Models.NghiepVuCongTrinh;
using DucAnhERP.ViewModel.NghiepVuCongTrinh;

namespace DucAnhERP.Repository.NghiepVuCongTrinh
{
    public interface IPhanLoaiMongCTronRepository : IBaseRepository<PhanLoaiMongCTron>
    {
        Task<List<PhanLoaiMongCongModel>> GetAllByVM(PhanLoaiMongCongModel plmModel);
        Task<bool> CheckUsingId(string id);
        Task<bool> CheckUsingName(string name);
        Task<PhanLoaiMongCTron> GetPhanLoaiMongCTronByDetail(PhanLoaiMongCTron pltdhg);
        Task<PhanLoaiMongCTron> GetPhanLoaiMongCTronExist(PhanLoaiMongCTron searchData);
        Task<string> InsertId(PhanLoaiMongCTron entity, string LoaiTD, string LoaiM, string HTM);
        Task<string> InsertLaterFlag(PhanLoaiMongCTron entity, int FlagLast);
    }
}
