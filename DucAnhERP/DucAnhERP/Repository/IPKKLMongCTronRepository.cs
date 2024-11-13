using DucAnhERP.Models;
using DucAnhERP.ViewModel;

namespace DucAnhERP.Repository
{
    public interface IPKKLMongCTronRepository :IBaseRepository<PKKLMongCTron>
    {
        Task<string> InsertLaterFlag(PKKLMongCTron entity, int FlagLast);
        Task<List<PKKLModel>> GetAllByVM(PKKLModel mModel);
        Task<List<PKKLMongCTron>> GetExist(PKKLMongCTron searchData);
        Task<Double> GetSumTKLCK_SauCC(PKKLMongCTron input);
        //Task<PKKLMongCTron> GetTKLCK_SauCCByLCK(string id);
        //Task<List<THKLModel>> GetTHKLCongTron();
        //Task<List<THKLModel>> GetTHKLByTuyenDuong(List<NuocMuaModel> nuocMua);
    }
}
