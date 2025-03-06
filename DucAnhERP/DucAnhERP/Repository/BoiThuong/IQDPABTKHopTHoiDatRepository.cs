using DucAnhERP.ViewModel.BoiThuong;

namespace DucAnhERP.Repository.BoiThuong
{
    public interface IQDPABTKHopTHoiDatRepository : IBaseRepository<BT_QDPABTKHopTHoiDat>
    {
        Task<List<PABTKetHopGPMBModel>> GetByVM(string groupId, PABTKetHopGPMBModel input);
        Task<bool> CheckExist(string id, BT_QDPABTKHopTHoiDat input);
        Task<bool> IsIdInUse(string id);
    }
}
