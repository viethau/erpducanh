using DucAnhERP.Models;
using DucAnhERP.ViewModel;

namespace DucAnhERP.Repository
{
    public interface INhomDanhMucRepository : IBaseRepository<MNhomDanhMuc>
    {
        Task<List<NhomDanhMucModel>> GetAllNDM();
        Task<bool> DeleteByIdResult(string id);
    }
}
