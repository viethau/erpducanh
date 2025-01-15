using DucAnhERP.ViewModel;
using DucAnhERP.Models;

namespace DucAnhERP.Repository
{
    public interface IDepartmentRepository : IBaseRepository<Department>
    {
        DepartmentModel GetToEdit(string id);
        Task<List<DepartmentModel>> GetAllByVM(DepartmentModel dataModel, string groupId);
        Task<List<DepartmentModel>> GetHistoryIsValidEdit(string id);
        Task<DepartmentModel> GetDetails(string id);
        Task<List<DepartmentModel>> GetHistory(string id);
        Task<List<ChiNhanhModel>>? GetChiNhanhsForCompanyId(string groupId);
        Task<bool> CheckSave(Department input);
        Task<bool> CheckEdit(Department input);
        Task<bool> CheckDelete(Department input);
        Task<List<Department>> GetByChiNhanhs(string companyId);
    }
}