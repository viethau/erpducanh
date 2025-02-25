using DucAnhERP.Models.NghiepVuCongTrinh;
using DucAnhERP.ViewModel.NghiepVuCongTrinh;

namespace DucAnhERP.Repository.NghiepVuCongTrinh
{
    public interface INhomDanhMucRepository : IBaseRepository<NhomDanhMuc>
    {
        Task<List<NhomDanhMucModel>> GetAllNDM();
        Task<bool> DeleteByIdResult(string id);
        Task<bool> GetNDMByTen(string Ten);
    }
}
