using DucAnhERP.Models;
using DucAnhERP.ViewModel;

namespace DucAnhERP.Repository
{
    public interface IPKKLCTronRepository :IBaseRepository<PKKLCTron>
    {
        Task<string> InsertLaterFlag(PKKLCTron entity, int FlagLast);
        Task<List<PKKLCTronModel>> GetAllByVM(PKKLCTronModel mModel);
        Task<List<PKKLCTron>> GetExist(PKKLCTron searchData);
        Task<PKKLCTron> GetTKLCK_SauCCByLCK(string id);
    }
}
