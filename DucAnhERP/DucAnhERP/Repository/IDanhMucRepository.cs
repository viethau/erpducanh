using DucAnhERP.Models;
using DucAnhERP.ViewModel;

namespace DucAnhERP.Repository
{
    public interface IDanhMucRepository : IBaseRepository<MDanhMuc>
    {
        Task<List<DanhMucModel>> GetAllDM();

        Task<List<MDanhMuc>> GetDMByIdNhomDanhMuc(string idNhomDanhMuc);

        Task<bool> GetDMByTenNhomDanhMuc(string ten);
    }
}


