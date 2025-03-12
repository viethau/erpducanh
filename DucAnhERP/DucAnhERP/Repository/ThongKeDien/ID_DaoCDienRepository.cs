using DucAnhERP.ViewModel;
using DucAnhERP.Models;
using DucAnhERP.ViewModel.BoiThuong;
using DucAnhERP.Models.BoiThuong;
using DucAnhERP.ViewModel.ThongKeDien;
using DucAnhERP.Models.ThongKeDien;

namespace DucAnhERP.Repository.BoiThuong
{
    public interface ID_DaoCDienRepository : IBaseRepository<D_DaoCDien>
    {
        public Task<List<D_DaoCDienModel>> GetByVM(string groupId , D_DaoCDienModel input);
        public Task<bool> CheckExist(string id, D_DaoCDien input );
        public Task<bool> IsIdInUse(string id);
    }
}
