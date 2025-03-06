using DucAnhERP.ViewModel;
using DucAnhERP.Models;
using DucAnhERP.ViewModel.BoiThuong;
using DucAnhERP.Models.BoiThuong;
using DucAnhERP.ViewModel.ThongKeDien;
using DucAnhERP.Models.ThongKeDien;

namespace DucAnhERP.Repository.BoiThuong
{
    public interface ID_DM_TuyenDuongRepository : IBaseRepository<D_DM_TuyenDuong>
    {
        public Task<List<DM_TuyenDuongModel>> GetByVM(string groupId , DM_TuyenDuongModel input);
        public Task<bool> CheckExist(string id, D_DM_TuyenDuong input );
        public Task<bool> IsIdInUse(string id);
    }
}
