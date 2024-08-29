using DucAnhERP.Models;
using DucAnhERP.ViewModel;

namespace DucAnhERP.Repository
{
    public interface IDanhMucRepository : IBaseRepository<MDanhMuc>
    {
        Task<List<DanhMucModel>> GetAllDM();

        Task<List<MDanhMuc>> GetDMByIdNhomDanhMuc(string idNhomDanhMuc);
        Task<string> GetIdDMByTen(string Ten);

        Task<bool> GetDMByTenNhomDanhMuc(string ten);

        Task<bool> CheckUsingId(string id);

        Task<bool> CheckExistId(string id);
    }
}


