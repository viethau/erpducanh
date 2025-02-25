using DucAnhERP.ViewModel;
using DucAnhERP.Models;
using DucAnhERP.ViewModel.BoiThuong;

namespace DucAnhERP.Repository.BoiThuong
{
    public interface ILoaiChungTuRepository : IBaseRepository<BT_DM_LoaiChungTu>
    {
        public Task<List<DMThuChiModel>> GetByVM();
    }
}
