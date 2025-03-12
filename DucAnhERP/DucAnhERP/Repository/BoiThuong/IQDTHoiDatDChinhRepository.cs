using DucAnhERP.ViewModel;
using DucAnhERP.Models;
using DucAnhERP.ViewModel.BoiThuong;
using DucAnhERP.Models.BoiThuong;

namespace DucAnhERP.Repository.BoiThuong
{
    public interface IQDGPMBNhanhDChinhRepository : IBaseRepository<BT_QDGPMBNhanhDChinh>
    {
        public Task<List<QDPABTModel>> GetByVM(string groupId , QDPABTModel input);
        public Task<bool> CheckExist(string id, BT_QDGPMBNhanhDChinh input );
        public Task<bool> IsIdInUse(string id);
    }
}
