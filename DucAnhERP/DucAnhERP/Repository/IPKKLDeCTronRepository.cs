using DucAnhERP.Models;
using DucAnhERP.ViewModel;

namespace DucAnhERP.Repository
{
    public interface IPKKLDeCTronRepository :IBaseRepository<PKKLDeCTron>        
    {
        Task<string> InsertLaterFlag(PKKLDeCTron entity, int FlagLast);
        Task<List<PKKLModel>> GetAllByVM(PKKLModel mModel);
        Task<List<PKKLDeCTron>> GetExist(PKKLDeCTron searchData);
        Task<PKKLDeCTron> GetTKLCK_SauCCByLCK(string id);
        Task<List<THKLModel>> GetTHKLDeCongTron();
        Task<List<THKLModel>> GetTHKLByTuyenDuong(List<NuocMuaModel> nuocMua);
    }
}
