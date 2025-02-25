using DucAnhERP.Models.NghiepVuCongTrinh;
using DucAnhERP.ViewModel.NghiepVuCongTrinh;

namespace DucAnhERP.Repository.NghiepVuCongTrinh
{
    public interface IDanhMucRepository : IBaseRepository<DanhMuc1>
    {
        Task<List<DanhMucModel>> GetAllDM(DanhMucModel dm);

        Task<List<DanhMuc1>> GetDMByIdNhomDanhMuc(string idNhomDanhMuc);
        Task<string> GetIdDMByTen(string Ten ,string ?IdNhomDanhMuc=null);

        Task<bool> GetDMByTenNhomDanhMuc(string ten);

        Task<List<DanhMuc1>> GetDMisExist(string idNhomDanhMuc, string Ten);
        Task<List<DanhMuc1>> GetDMisExistEdit(string Id, string idNhomDanhMuc, string Ten);

        Task<bool> CheckUsingId(string id);

        Task<bool> CheckExistId(string id);
    }
}


