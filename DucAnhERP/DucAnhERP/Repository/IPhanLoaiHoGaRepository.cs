using DucAnhERP.Models;
using DucAnhERP.ViewModel;

namespace DucAnhERP.Repository
{
    public interface IPhanLoaiHoGaRepository : IBaseRepository<PhanLoaiHoGa>
    {
        Task<List<PhanLoaiHoGaModel>> GetAllByVM(PhanLoaiHoGaModel Input);
        Task<bool> CheckUsingId(string id);
        Task<bool> CheckUsingName(string name);
        Task<PhanLoaiHoGa> GetPhanLoaiHoGaByDetail(PhanLoaiHoGa pltdhg);
        Task<PhanLoaiHoGa> GetPhanLoaiHoGaExist(PhanLoaiHoGa searchData );
        Task<string> InsertId(PhanLoaiHoGa entity, string HoGa_KetCauTuong,string TenPL);
        Task<string> InsertLaterFlag(PhanLoaiHoGa entity, int FlagLast);
        Task<List<PhanLoaiHoGaModel>> GetBaoCaoCTaoCHungHGa(PhanLoaiHoGaModel plhgModel);
        Task<List<PhanLoaiHoGaModel>> GetBaoCaoKTHHHGa(PhanLoaiHoGaModel plhgMode);
        Task<List<PhanLoaiHoGaModel>> GetBaoCaoHGaSDThep(PhanLoaiHoGaModel plhgMode);
        Task<List<PhanLoaiHoGa>> GetPhanLoaiHoGaByDetails(PhanLoaiHoGa searchData);
    }
}
