using DucAnhERP.ViewModel.QLNV;
using DucAnhERP.Models.QLNV;

namespace DucAnhERP.Repository.QLNV
{
    public interface IQLNV_NhanVienRepository : IBaseRepository<QLNV_NhanVien>
    {
        public Task<List<QLNV_NhanVienModel>> GetByVM(QLNV_NhanVienModel input);
        public Task<List<QLNV_NhanVien>> GetNhanVienIsQuanLy(bool isQuanLy);
        public Task<List<QLNV_NhanVien>> GetNhanVienByNhom(string Id_NhomNhanVien);
        public Task<List<QLNV_NhanVien>> GetNhanVienNotQL(string Id_NhomNhanVien);
        public Task<bool> CheckExist(string id, QLNV_NhanVien input );
        public Task<bool> IsIdInUse(string id);
    }
}
