using DucAnhERP.ViewModel;
using DucAnhERP.Models;
using DucAnhERP.ViewModel.BoiThuong;
using DucAnhERP.Models.BoiThuong;
using DucAnhERP.ViewModel.ThongKeDien;
using DucAnhERP.Models.ThongKeDien;

namespace DucAnhERP.Repository.BoiThuong
{
    public interface ID_DM_LoaiKLRepository : IBaseRepository<D_DM_LoaiKL>
    {
        public Task<List<DM_LoaiKLModel>> GetByVM(string groupId , DM_LoaiKLModel input);
        public Task<bool> CheckExist(string id, D_DM_LoaiKL input );
        public Task<bool> IsIdInUse(string id);
    }
}
