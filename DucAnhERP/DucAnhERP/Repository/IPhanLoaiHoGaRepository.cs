using DucAnhERP.Helpers;
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
        Task<PhanLoaiHoGaModel> GetIdByVM(PhanLoaiHoGaModel Input);
        Task<List<SelectedItem>> GetDSPhanLoaiHoGa();

        //bảng detail
        Task<List<NuocMuaModel>> GetPhanLoaiHoGaByTenHGTBV(string ThongTinChungHoGa_TenHoGaTheoBanVe);
        Task<List<PhanLoaiHoGaDetail>> GetAllDetailsG(string? G);
        Task<PhanLoaiHoGaDetail> GetByIdDetails(string id);
        Task<bool> CheckExclusiveDetails(string[] ids, DateTime baseTime);
        Task<List<PhanLoaiHoGaDetail>> SelectInsertPLHGDetail();
        Task<List<PhanLoaiHoGaDetail>> InsertMissingPhanLoaiHoGaDetails();
        Task<PhanLoaiHoGaModel> GetIdByVMDetails(PhanLoaiHoGaModel Input);

    }
}
