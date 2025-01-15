using DucAnhERP.ViewModel;
using DucAnhERP.Models;
namespace DucAnhERP.Repository
{
public interface ICompanyTypeRepository : IBaseRepository<CompanyType>
{
Task<List<CompanyTypeModel>> GetAllByVM(CompanyTypeModel dataModel, string groupId);
}
}
