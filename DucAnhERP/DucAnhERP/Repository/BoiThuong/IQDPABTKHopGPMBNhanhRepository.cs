using DucAnhERP.ViewModel.BoiThuong;

namespace DucAnhERP.Repository.BoiThuong
{
    public interface IQDPABTKHopGPMBNhanhRepository : IBaseRepository<BT_QDPABTKHopGPMBNhanh>
    {
        Task<List<PABTKetHopGPMBModel>> GetByVM(string groupId, PABTKetHopGPMBModel input);
        Task<bool> CheckExist(string id, BT_QDPABTKHopGPMBNhanh input);
        Task<bool> IsIdInUse(string id);
    }
}
