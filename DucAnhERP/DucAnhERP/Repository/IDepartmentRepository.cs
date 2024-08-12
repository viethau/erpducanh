using DucAnhERP.Models;

namespace DucAnhERP.Repository
{
    public interface IDepartmentRepository : IBaseRepository<MDepartment>
    {
        Task<List<MDepartment>> GetDepartmentsByCompany(string companyId);
    }
}
