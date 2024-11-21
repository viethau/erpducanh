using DucAnhERP.Models;
using DucAnhERP.ViewModel;

namespace DucAnhERP.Repository
{
    public interface IPKKLRanhBTRepository :IBaseRepository<PKKLRanhBT>
    {
        Task<string> InsertLaterFlag(PKKLRanhBT entity, int FlagLast);
        Task<List<PKKLModel>> GetAllByVM(PKKLModel mModel);
        Task<List<PKKLRanhBT>> GetExist(PKKLRanhBT searchData);
        Task<PKKLRanhBT> GetTKLCK_SauCCByLCK(string id);
        Task<List<THKLModel>> GetTHKLRanhBT();
        Task<List<THKLModel>> GetTHKLByTuyenDuong(List<NuocMuaModel> nuocMua);
    }
}
