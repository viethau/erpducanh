using DucAnhERP.ViewModel;
using DucAnhERP.Models;

namespace DucAnhERP.Repository
{
    public interface IMajorRepository : IBaseRepository<Major>
    {
        Task<List<Major>> GetAllParentMajor();

        Task<Major> AddMajor(Major mMajor);

        Task<Major> GetMajorByName(string majorName);
            
        Task<List<Major>> GetMajorByParentId(string id);
        List<Major> GetMajorByParentId1(string id);
        Task<List<Major>> GetParentMajor();

        Task<List<MajorModel>> GetAll(MajorModel majorModel);
    }
}
