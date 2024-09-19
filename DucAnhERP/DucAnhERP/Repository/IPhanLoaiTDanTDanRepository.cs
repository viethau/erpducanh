using DucAnhERP.Models;
using DucAnhERP.ViewModel;

namespace DucAnhERP.Repository
{
    public interface IPhanLoaiTDanTDanRepository : IBaseRepository<PhanLoaiTDanTDan>
    {
        Task<List<PhanLoaiTDanTDanModel>> GetAllByVM();
        Task<bool> CheckUsingId(string id);
        Task<bool> CheckUsingName(string name);
        Task<PhanLoaiTDanTDan> GetPhanLoaiTDanTDanByDetail(PhanLoaiTDanTDan pltdtd);
        Task<PhanLoaiTDanTDan> GetPhanLoaiTDanTDanExist(PhanLoaiTDanTDan searchData);
        Task<string> InsertId(PhanLoaiTDanTDan entity, string HTTD, string LTD, string CTTDTC);
        Task<string> InsertLaterFlag(PhanLoaiTDanTDan entity, int FlagLast);
    }
}
