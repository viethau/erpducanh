using DucAnhERP.Models;
using DucAnhERP.ViewModel;

namespace DucAnhERP.Repository
{
    public interface IPKKLCTietHoGaRepository :IBaseRepository<PKKLCTietHoGa>
    {
        Task<string> InsertLaterFlag(PKKLCTietHoGa entity, int FlagLast);
        Task<List<PKKLModel>> GetAllByVM(PKKLModel mModel);
        Task<List<PKKLCTietHoGa>> GetExist(PKKLCTietHoGa searchData);
        Task<PKKLCTietHoGa> GetTKLCK_SauCCByLCK(string id);
        Task<double> GetSumTKLCK_SauCCByLCK(string id);
        Task<List<THKLModel>> GetTHKL1HoGa();
        Task<List<THKLModel>> GetTHKLByTuyenDuong(List<NuocMuaModel> nuocMua);
        double KTHH_KL1CK(PKKLCTietHoGa obj);
        double TTCDT_KL(PKKLCTietHoGa obj);
        double KL1CK_ChuaTruCC(PKKLCTietHoGa obj);
    }
}
