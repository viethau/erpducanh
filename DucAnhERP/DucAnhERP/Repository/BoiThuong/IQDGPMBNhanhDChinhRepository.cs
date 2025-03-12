using DucAnhERP.ViewModel;
using DucAnhERP.Models;
using DucAnhERP.ViewModel.BoiThuong;
using DucAnhERP.Models.BoiThuong;

namespace DucAnhERP.Repository.BoiThuong
{
    public interface IQDTHoiDatDChinhRepository : IBaseRepository<BT_QDTHoiDatDChinh>
    {
        public Task<List<QDPABTModel>> GetByVM(string groupId);
        public Task<bool> CheckExist(string id, BT_QDTHoiDatDChinh input );
        public Task<bool> IsIdInUse(string id);
    }
}
