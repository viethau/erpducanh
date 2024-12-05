using DucAnhERP.Models;
using DucAnhERP.ViewModel;

namespace DucAnhERP.Repository
{
    public interface IPKKLMongCHopRepository : IBaseRepository<PKKLMongCHop>
    {
        Task<string> InsertLaterFlag(PKKLMongCHop entity, int FlagLast);
        Task<List<PKKLModel>> GetAllByVM(PKKLModel mModel);
        Task<List<PKKLMongCHop>> GetExist(PKKLMongCHop searchData);
        Task<Double> GetSumTKLCK_SauCC(PKKLMongCHop input);
        Task<double> GetSumTKLCK_SauCCByLCK(string id);
        Task<List<THKLModel>> GetTHKLMongCongHop();
        Task<List<THKLModel>> GetTHKLByTuyenDuong(List<NuocMuaModel> nuocMua);
        Task<PKKLMongCHop> GetTKLCK_SauCCByLCK(string id);

        double KTHH_KL1CK(PKKLMongCHop obj);
        double TTCDT_KL(PKKLMongCHop obj);
        double KL1CK_ChuaTruCC(PKKLMongCHop obj);
    }
}
