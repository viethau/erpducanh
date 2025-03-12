using DucAnhERP.ViewModel;
using DucAnhERP.Models;
using DucAnhERP.ViewModel.BoiThuong;
using DucAnhERP.Models.BoiThuong;

namespace DucAnhERP.Repository.BoiThuong
{
    public interface ICTietPAnBThuongRepository : IBaseRepository<BT_CTietPAnBThuong>
    {
        public Task<List<BT_CTietPAnBThuongModel>> GetByVM(string groupId);
        public Task<bool> CheckExist(string id, string soQD);
        public Task<bool> IsIdInUse(string id);
    }
}
