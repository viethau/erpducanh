using DucAnhERP.ViewModel;
using DucAnhERP.Models;
using DucAnhERP.ViewModel.BoiThuong;

namespace DucAnhERP.Repository.BoiThuong
{
    public interface IDM_HangMucChiRepository : IBaseRepository<BT_DM_HMChi>
    {
        public Task<List<DMThuChiModel>> GetByVM(string groupId);
        public Task<bool> CheckExist(string id, string loaiChungTu);
        public Task<bool> IsIdInUse(string id);
    }
}
