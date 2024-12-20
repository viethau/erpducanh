using DucAnhERP.Models;
using DucAnhERP.ViewModel;

namespace DucAnhERP.Repository
{
    public interface IPKKLCTietTDHGRepository :IBaseRepository<PKKLCTietTDHG>
    {
        Task<string> InsertLaterFlag(PKKLCTietTDHG entity, int FlagLast, bool insertBefore);
        Task<List<PKKLModel>> GetAllByVM(PKKLModel mModel);
        Task<List<PKKLCTietTDHG>> GetExist(PKKLCTietTDHG searchData);
        Task<PKKLCTietTDHG> GetTKLCK_SauCCByLCK(string id);
        Task<double> GetSumTKLCK_SauCCByLCK(string id);
        Task<List<THKLModel>> GetTHKLCTietTDHG();
        Task<List<THKLModel>> GetTHKLByTuyenDuong(List<NuocMuaModel> nuocMua);
        double KTHH_KL1CK(PKKLCTietTDHG obj);
        double TTCDT_KL(PKKLCTietTDHG obj);
        double KL1CK_ChuaTruCC(PKKLCTietTDHG obj);
    }
}
