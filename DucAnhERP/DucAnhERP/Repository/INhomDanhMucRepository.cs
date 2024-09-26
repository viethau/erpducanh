using DucAnhERP.Models;
using DucAnhERP.ViewModel;

namespace DucAnhERP.Repository
{
    public interface INhomDanhMucRepository : IBaseRepository<NhomDanhMuc>
    {
        Task<List<NhomDanhMucModel>> GetAllNDM();
        Task<bool> DeleteByIdResult(string id);
        Task<bool> GetNDMByTen(string Ten);
    }
}
