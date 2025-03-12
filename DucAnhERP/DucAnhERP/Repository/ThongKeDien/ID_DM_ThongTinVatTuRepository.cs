using DucAnhERP.ViewModel;
using DucAnhERP.Models;
using DucAnhERP.ViewModel.BoiThuong;
using DucAnhERP.Models.BoiThuong;
using DucAnhERP.ViewModel.ThongKeDien;
using DucAnhERP.Models.ThongKeDien;

namespace DucAnhERP.Repository.BoiThuong
{
    public interface ID_DM_ThongTinVatTuRepository : IBaseRepository<D_DM_ThongTinVatTu>
    {
        public Task<List<DM_ThongTinVatTuModel>> GetByVM(string groupId , DM_ThongTinVatTuModel input);
        public Task<bool> CheckExist(string id, D_DM_ThongTinVatTu input );
        public Task<bool> IsIdInUse(string id);
    }
}
