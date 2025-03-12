using DucAnhERP.ViewModel;
using DucAnhERP.Models;
using DucAnhERP.ViewModel.BoiThuong;
using DucAnhERP.Models.BoiThuong;
using DucAnhERP.ViewModel.ThongKeDien;
using DucAnhERP.Models.ThongKeDien;

namespace DucAnhERP.Repository.BoiThuong
{
    public interface ID_XDungCDienRepository : IBaseRepository<D_XDungCDien>
    {
        public Task<List<D_XDungCDienModel>> GetByVM(string groupId , D_XDungCDienModel input);
        public Task<bool> CheckExist(string id, D_XDungCDien input );
        public Task<bool> IsIdInUse(string id);
    }
}
