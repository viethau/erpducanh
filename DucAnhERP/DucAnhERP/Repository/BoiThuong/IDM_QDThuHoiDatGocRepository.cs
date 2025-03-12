using DucAnhERP.ViewModel;
using DucAnhERP.Models;
using DucAnhERP.ViewModel.BoiThuong;
using DucAnhERP.Models.BoiThuong;

namespace DucAnhERP.Repository.BoiThuong
{
    public interface IDM_QDThuHoiDatGocRepository : IBaseRepository<BT_DM_QDThuHoiDatGoc>
    {
        public Task<List<DMPABTModel>> GetByVM(string groupId);
        public Task<bool> CheckExist(string id, string soQD);
        public Task<bool> IsIdInUse(string id);
    }
}
