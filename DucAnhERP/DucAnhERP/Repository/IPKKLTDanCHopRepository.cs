using DucAnhERP.Models;
using DucAnhERP.ViewModel;

namespace DucAnhERP.Repository
{
    public interface IPKKLTDanCHopRepository :IBaseRepository<PKKLTDanCHop>
    {
        Task<string> InsertLaterFlag(PKKLTDanCHop entity, int FlagLast);
        Task<List<PKKLModel>> GetAllByVM(PKKLModel mModel);
        Task<List<PKKLTDanCHop>> GetExist(PKKLTDanCHop searchData);
        Task<PKKLTDanCHop> GetTKLCK_SauCCByLCK(string id);
        Task<List<THKLModel>> GetTHKLTDanCHop();
        Task<List<THKLModel>> GetTHKLByTuyenDuong(List<NuocMuaModel> nuocMua);
    }
}
