using DucAnhERP.Models;
using DucAnhERP.ViewModel;

namespace DucAnhERP.Repository
{
    public interface IPKKLCHopRepository : IBaseRepository<PKKLCHop>
    {   
        Task<string> InsertLaterFlag(PKKLCHop entity, int FlagLast);
        Task<List<PKKLModel>> GetAllByVM(PKKLModel mModel);
        Task<List<PKKLCHop>> GetExist(PKKLCHop searchData);
        Task<PKKLCHop> GetTKLCK_SauCCByLCK(string id);
        Task<double> GetSumTKLCK_SauCCByLCK(string id);
        Task<List<THKLModel>> GetTHKLCongHop();
        Task<List<THKLModel>> GetTHKLByTuyenDuong(List<NuocMuaModel> nuocMua);

        double KTHH_KL1CK(PKKLCHop obj);
        double TTCDT_KL(PKKLCHop obj);
        double KL1CK_ChuaTruCC(PKKLCHop obj);

    }
}
