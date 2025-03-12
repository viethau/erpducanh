using DucAnhERP.ViewModel;
using DucAnhERP.Models;
using DucAnhERP.ViewModel.BoiThuong;
using DucAnhERP.Models.BoiThuong;
using DucAnhERP.ViewModel.ThongKeDien;
using DucAnhERP.Models.ThongKeDien;

namespace DucAnhERP.Repository.BoiThuong
{
    public interface ID_TTLDienCDienRepository : IBaseRepository<D_TTLDienCDien>
    {
        public Task<List<D_TTLDienCDienModel>> GetByVM(string groupId , D_TTLDienCDienModel input);
        public Task<bool> CheckExist(string id, D_TTLDienCDien input );
        public Task<bool> IsIdInUse(string id);
    }
}
