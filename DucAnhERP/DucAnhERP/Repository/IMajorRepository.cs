using DucAnhERP.ViewModel;
using DucAnhERP.Models;

namespace DucAnhERP.Repository
{
    public interface IMajorRepository : IBaseRepository<MMajor>
    {
        Task<List<MMajor>> GetAllParentMajor();
        Task<List<MMajor>> GetAllChildMajor();

        Task<MMajor> AddMajor(MMajor mMajor);

        Task<MMajor> GetMajorByName(string majorName);

        Task<List<MMajor>> GetMajorByParentId(string id);

        Task<List<MajorModel>> GetAll(MajorModel majorModel);
    }
}
