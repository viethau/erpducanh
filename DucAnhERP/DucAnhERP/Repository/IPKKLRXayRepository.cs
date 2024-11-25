using DucAnhERP.Models;
using DucAnhERP.ViewModel;

namespace DucAnhERP.Repository
{
    public interface IPKKLRXayRepository : IBaseRepository<PKKLRXay>
    {
        Task<string> InsertLaterFlag(PKKLRXay entity, int FlagLast);
        Task<List<PKKLModel>> GetAllByVM(PKKLModel mModel);
        Task<List<PKKLRXay>> GetExist(PKKLRXay searchData);
        Task<Double> GetTKLCK_SauCCByLCK(string id);
        Task<List<THKLModel>> GetTHKLRanhXay();
        Task<List<THKLModel>> GetTHKLByTuyenDuong(List<NuocMuaModel> nuocMua);
    }
}
