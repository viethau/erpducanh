using DucAnhERP.Models.NghiepVuCongTrinh;
using DucAnhERP.ViewModel;

namespace DucAnhERP.Repository.NghiepVuCongTrinh
{
    public interface IHopRanhThangRepository : IBaseRepository<MHopRanhThang>
    {
        //Task<bool> InsertHopRanhThang(MHopRanhThang hopRanhThang);
         Task<List<HopRanhThangModel>> GetData();
        Task<int> MultiInsert(List<MHopRanhThang> entities);
    }
}
