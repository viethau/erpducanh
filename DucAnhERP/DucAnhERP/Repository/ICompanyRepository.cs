using DucAnhERP.ViewModel;
using DucAnhERP.Models;

namespace DucAnhERP.Repository
{
    public interface ICompanyRepository : IBaseRepository<MCompany>
    {
        Task<List<MCompany>> GetAllCompanies();

    }
}
