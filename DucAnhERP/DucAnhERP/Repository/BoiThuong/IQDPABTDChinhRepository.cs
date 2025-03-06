using DucAnhERP.ViewModel.BoiThuong;

namespace DucAnhERP.Repository.BoiThuong
{
    public interface IQDPABTDChinhRepository : IBaseRepository<BT_QDPABTDChinh>
    {
        Task<List<QDPABTModel>> GetByVM(string groupId, QDPABTModel input);
        Task<bool> CheckExist(string id, BT_QDPABTDChinh input);
        Task<bool> IsIdInUse(string id);
    }
}
