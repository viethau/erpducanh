using DucAnhERP.Models;
using DucAnhERP.ViewModel;

namespace DucAnhERP.Repository
{
    public interface IPKKLCTietHoGaRepository :IBaseRepository<PKKLCTietHoGa>
    {
        Task<string> InsertLaterFlag(PKKLCTietHoGa entity, int FlagLast, bool insertBefore);
        Task<List<PKKLCTietHoGaModel>> GetAllByVM(PKKLCTietHoGaModel mModel);
        Task<List<PKKLCTietHoGa>> GetExist(PKKLCTietHoGa searchData);
        Task<PKKLCTietHoGa> GetTKLCK_SauCCByLCK(string id);
        Task<double> GetSumTKLCK_SauCCByLCK(string id);
        Task<List<THKLModel>> GetTHKL1HoGa();
        Task<List<THKL1HGModel>> GetTHKL1HoGa1();
        Task<List<THKLModel>> GetTHKLByTuyenDuong(List<NuocMuaModel> nuocMua);
        Task<List<THKL1HGModel>> GetTHKLByTuyenDuong1(List<NuocMuaModel> nuocMua);
        double KTHH_KL1CK(PKKLCTietHoGa obj);
        double TTCDT_KL(PKKLCTietHoGa obj);
        double KL1CK_ChuaTruCC(PKKLCTietHoGa obj);
        Task<double> TKLCK_SauCC(PKKLCTietHoGa obj);
    }
}
