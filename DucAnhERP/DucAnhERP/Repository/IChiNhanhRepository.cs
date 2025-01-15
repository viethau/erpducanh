using DucAnhERP.ViewModel;
using DucAnhERP.Models;
using DucAnhERP.Components.Pages.CaiDatHeThong;

namespace DucAnhERP.Repository
{
    public interface IChiNhanhRepository : IBaseRepository<ChiNhanh>
    {
        Task<List<ChiNhanhModel>> GetAllByVM(ChiNhanhModel dataModel, string groupId);
        Task<List<ChiNhanhModel>> GetChiNhanhs(string groupId);
        Task<List<CompanyTypeModel>> GetCompanyTypes(string groupId);
        Task<List<ChiNhanh>> GetChiNhanhByPermission(string groupId, string majorId, string userId);
        ChiNhanhModel GetChiNhanhModelByInput(ChiNhanh list);
        ChiNhanhModel GetChiNhanhLogModelById(string id);
    }
}