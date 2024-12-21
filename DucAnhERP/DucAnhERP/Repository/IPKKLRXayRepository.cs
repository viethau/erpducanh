using DucAnhERP.Models;
using DucAnhERP.ViewModel;

namespace DucAnhERP.Repository
{
    public interface IPKKLRXayRepository : IBaseRepository<PKKLRXay>
    {
        Task<string> InsertLaterFlag(PKKLRXay entity, int FlagLast, bool insertBefore);
        Task<List<PKKLModel>> GetAllByVM(PKKLModel mModel);
        Task<List<PKKLRXay>> GetExist(PKKLRXay searchData);

        Task<PKKLRXay> GetTKLCK_SauCCByLCK(string id);
        Task<double> GetSumTKLCK_SauCCByLCK(string id);
        Task<List<THKLModel>> GetTHKLRanhXay();
        Task<List<THKLModel>> GetTHKLByTuyenDuong(List<NuocMuaModel> nuocMua);

        double KTHH_KL1CK(PKKLRXay obj);
        double TTCDT_KL(PKKLRXay obj);
        double KL1CK_ChuaTruCC(PKKLRXay obj);
    }
}
