using DucAnhERP.ViewModel.QLNV;
using DucAnhERP.Models.QLNV;

namespace DucAnhERP.Repository.QLNV
{
    public interface IQLNV_DanhGiaRepository : IBaseRepository<QLNV_DanhGia>
    {
        public Task<List<QLNV_DanhGiaModel>> GetByVM(QLNV_DanhGiaModel input, string Id_NguoiGiaoViec);
        public Task<bool> CheckExist(string id, QLNV_DanhGia input );
        public Task<bool> IsIdInUse(string id);
    }
}
