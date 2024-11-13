using DucAnhERP.Models;
using DucAnhERP.ViewModel;

namespace DucAnhERP.Repository
{
    public interface IPKKLCTronRepository :IBaseRepository<PKKLCTron>
    {
        Task<string> InsertLaterFlag(PKKLCTron entity, int FlagLast);
        Task<List<PKKLModel>> GetAllByVM(PKKLModel mModel);
        Task<List<PKKLCTron>> GetExist(PKKLCTron searchData);
        Task<PKKLCTron> GetTKLCK_SauCCByLCK(string id);
        Task<List<THKLModel>> GetTHKLCongTron();
        Task<List<THKLModel>> GetTHKLByTuyenDuong(List<NuocMuaModel> nuocMua);
    }
}
