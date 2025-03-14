using DucAnhERP.ViewModel.QLNV;
using DucAnhERP.Models.QLNV;

namespace DucAnhERP.Repository.QLNV
{
    public interface IQLNV_NhomNhanVienRepository : IBaseRepository<QLNV_NhomNhanVien>
    {
        public Task<List<QLNV_NhomNhanVienModel>> GetByVM(QLNV_NhomNhanVienModel input);
        Task<List<QLNV_NhomNhanVienModel>> GetNhomNhanVienByTaiKhoanAsync(string taiKhoan);
        Task<List<QLNV_NhomNhanVienModel>> GetNhomNhanVienByCVDGAsync(string taiKhoan);
        public Task<bool> CheckExist(string id, QLNV_NhomNhanVien input );
        public Task<bool> IsIdInUse(string id);
    }
}
