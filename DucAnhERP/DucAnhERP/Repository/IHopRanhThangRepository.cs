using DucAnhERP.Models;
using DucAnhERP.ViewModel;

namespace DucAnhERP.Repository
{
    public interface IHopRanhThangRepository : IBaseRepository<MHopRanhThang>
    {
        //Task<bool> InsertHopRanhThang(MHopRanhThang hopRanhThang);
         Task<List<HopRanhThangModel>> GetData();
        Task<int> MultiInsert(List<MHopRanhThang> entities);
    }
}
