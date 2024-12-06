using DucAnhERP.Models;
using DucAnhERP.ViewModel;

namespace DucAnhERP.Repository
{
    public interface IPKKLTDanRBTRepository : IBaseRepository<PKKLTDanRBT>
    {
        Task<string> InsertLaterFlag(PKKLTDanRBT entity, int FlagLast);
        Task<List<PKKLModel>> GetAllByVM(PKKLModel mModel);
        Task<List<PKKLTDanRBT>> GetExist(PKKLTDanRBT searchData);
        Task<PKKLTDanRBT> GetTKLCK_SauCCByLCK(string id);
        Task<List<THKLModel>> GetTHKLTDanRBT();
        Task<List<THKLModel>> GetTHKLByTuyenDuong(List<NuocMuaModel> nuocMua);

        double KTHH_KL1CK(PKKLTDanRBT obj);
        double TTCDT_KL(PKKLTDanRBT obj);
        double KL1CK_ChuaTruCC(PKKLTDanRBT obj);
    }
}
