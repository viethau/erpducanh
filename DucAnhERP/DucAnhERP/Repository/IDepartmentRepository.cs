using DucAnhERP.Models;

namespace DucAnhERP.Repository
{
    public interface IDepartmentRepository : IBaseRepository<Department>
    {
        Task<List<Department>> GetDepartmentsByCompany(string companyId);
    }
}
