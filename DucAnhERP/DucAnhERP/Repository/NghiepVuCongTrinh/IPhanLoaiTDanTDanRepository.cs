using DucAnhERP.Models.NghiepVuCongTrinh;
using DucAnhERP.ViewModel.NghiepVuCongTrinh;

namespace DucAnhERP.Repository.NghiepVuCongTrinh
{
    public interface IPhanLoaiTDanTDanRepository : IBaseRepository<PhanLoaiTDanTDan>
    {
        Task<List<PhanLoaiTDanTDanModel>> GetAllByVM(PhanLoaiTDanTDanModel pltdtdModel);
        Task<bool> CheckUsingId(string id);
        Task<bool> CheckUsingName(string name);
        Task<PhanLoaiTDanTDan> GetPhanLoaiTDanTDanByDetail(PhanLoaiTDanTDan pltdtd);
        Task<PhanLoaiTDanTDan> GetPhanLoaiTDanTDanExist(PhanLoaiTDanTDan searchData);
        Task<string> InsertId(PhanLoaiTDanTDan entity, string HTTD, string LTD, string CTTDTC, string PhanLoai);
        Task<string> InsertLaterFlag(PhanLoaiTDanTDan entity, int FlagLast);
    }
}
