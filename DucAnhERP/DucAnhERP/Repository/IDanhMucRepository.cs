using DucAnhERP.Models;
using DucAnhERP.ViewModel;

namespace DucAnhERP.Repository
{
    public interface IDanhMucRepository : IBaseRepository<DanhMuc>
    {
        Task<List<DanhMucModel>> GetAllDM();

        Task<List<DanhMuc>> GetDMByIdNhomDanhMuc(string idNhomDanhMuc);
        Task<string> GetIdDMByTen(string Ten ,string ?IdNhomDanhMuc=null);

        Task<bool> GetDMByTenNhomDanhMuc(string ten);

        Task<List<DanhMuc>> GetDMisExist(string idNhomDanhMuc, string Ten);
        Task<List<DanhMuc>> GetDMisExistEdit(string Id, string idNhomDanhMuc, string Ten);

        Task<bool> CheckUsingId(string id);

        Task<bool> CheckExistId(string id);
    }
}


