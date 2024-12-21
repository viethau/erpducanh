using DucAnhERP.Models;
using DucAnhERP.ViewModel;

namespace DucAnhERP.Repository
{
    public interface IPKKLTDanCHopRepository :IBaseRepository<PKKLTDanCHop>
    {
        Task<string> InsertLaterFlag(PKKLTDanCHop entity, int FlagLast, bool insertBefore);
        Task<List<PKKLModel>> GetAllByVM(PKKLModel mModel);
        Task<List<PKKLTDanCHop>> GetExist(PKKLTDanCHop searchData);
        Task<PKKLTDanCHop> GetTKLCK_SauCCByLCK(string id);
        Task<List<THKLModel>> GetTHKLTDanCHop();
        Task<List<THKLModel>> GetTHKLByTuyenDuong(List<NuocMuaModel> nuocMua);

        double KTHH_KL1CK(PKKLTDanCHop obj);
        double TTCDT_KL(PKKLTDanCHop obj);
        double KL1CK_ChuaTruCC(PKKLTDanCHop obj);
    }
}
