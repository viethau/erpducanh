using DucAnhERP.ViewModel;
using DucAnhERP.Models;
using DucAnhERP.ViewModel.BoiThuong;
using DucAnhERP.Models.BoiThuong;
using DucAnhERP.ViewModel.ThongKeDien;
using DucAnhERP.Models.ThongKeDien;

namespace DucAnhERP.Repository.BoiThuong
{
    public interface ID_CDoCDienRepository : IBaseRepository<D_CDoCDien>
    {
        public Task<List<D_CDoCDienModel>> GetByVM(string groupId , D_CDoCDienModel input);
        Task<D_DaoCDien> GetSumDaoCDien(string id_DM_TuyenDuong);
        public Task<bool> CheckExist(string id, D_CDoCDien input );
        public Task<bool> IsIdInUse(string id);
    }
}
