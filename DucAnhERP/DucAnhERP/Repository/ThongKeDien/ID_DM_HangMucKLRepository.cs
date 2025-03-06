using DucAnhERP.ViewModel;
using DucAnhERP.Models;
using DucAnhERP.ViewModel.BoiThuong;
using DucAnhERP.Models.BoiThuong;
using DucAnhERP.ViewModel.ThongKeDien;
using DucAnhERP.Models.ThongKeDien;

namespace DucAnhERP.Repository.BoiThuong
{
    public interface ID_DM_HangMucKLRepository : IBaseRepository<D_DM_HangMucKL>
    {
        public Task<List<DM_HangMucKLModel>> GetByVM(string groupId , DM_HangMucKLModel input);
        public Task<bool> CheckExist(string id, D_DM_HangMucKL input );
        public Task<bool> IsIdInUse(string id);
    }
}
