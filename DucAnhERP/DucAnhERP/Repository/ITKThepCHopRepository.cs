using DucAnhERP.Models;
using DucAnhERP.ViewModel;

namespace DucAnhERP.Repository
{
    public interface ITKThepCHopRepository : IBaseRepository<TKThepCHop>
    {
        Task<string> InsertLaterFlag(TKThepCHop entity, int FlagLast);
        Task<List<TKThepCHopModel>> GetAllByVM(TKThepCHopModel mModel);
        Task<List<TKThepCHop>> GetExist(TKThepCHop searchData);
    }
}
