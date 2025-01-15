using DucAnhERP.ViewModel;
using DucAnhERP.Models;

namespace DucAnhERP.Repository
{
    public interface ICompanyRepository : IBaseRepository<MCompany>
    {
        Task<List<MCompany>> GetAllCompanies();
        string CheckCondition(MCompany mcompanie, int InputSave);
        Task<List<MCompanyModel>> GetAllByVM();
    }
}
