using DucAnhERP.ViewModel.QLNV;
using DucAnhERP.Models.QLNV;

namespace DucAnhERP.Repository.QLNV
{
    public interface IQLNV_QuanLyNhanVienRepository : IBaseRepository<QLNV_QuanLyNhanVien>
    {
        public Task<List<QLNV_QuanLyNhanVienModel>> GetByVM(QLNV_QuanLyNhanVienModel input);
        Task<List<QLNV_QuanLyNhanVienModel>> GetQuanLyNhanVienByNhomAsync(string Id_NhomNhanVien);
        public Task<bool> CheckExist(string id, QLNV_QuanLyNhanVien input );
        public Task<bool> IsIdInUse(string id);
    }
}
