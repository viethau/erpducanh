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
        Task<List<THKLModel>> GetTHKLCongHop();
        Task<List<THKLModel>> GetTHKLByTuyenDuong(List<NuocMuaModel> nuocMua);
       
    }
}
