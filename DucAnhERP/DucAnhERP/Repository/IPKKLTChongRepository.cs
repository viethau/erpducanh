using DucAnhERP.Models;
using DucAnhERP.ViewModel;

namespace DucAnhERP.Repository
{
    public interface IPKKLTChongRepository : IBaseRepository<PKKLTChong>
    {
        Task<string> InsertLaterFlag(PKKLTChong entity, int FlagLast);
        Task<List<PKKLModel>> GetAllByVM(PKKLModel mModel);
        Task<List<PKKLTChong>> GetExist(PKKLTChong searchData);
        Task<PKKLTChong> GetTKLCK_SauCCByLCK(string id);
        Task<List<THKLModel>> GetTHKLThanhChong();
        Task<List<THKLModel>> GetTHKLByTuyenDuong(List<NuocMuaModel> nuocMua);
    }
}
