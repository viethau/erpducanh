using DucAnhERP.Models;
using DucAnhERP.ViewModel;

namespace DucAnhERP.Repository
{
    public interface ITKThepTChongRepository : IBaseRepository<TKThepTChong>
    {
        Task<string> InsertLaterFlag(TKThepTChong entity, int FlagLast);
        Task<List<TKThepTChongModel>> GetAllByVM(TKThepTChongModel mModel);
        Task<List<TKThepTChong>> GetExist(TKThepTChong searchData);
    }
}
