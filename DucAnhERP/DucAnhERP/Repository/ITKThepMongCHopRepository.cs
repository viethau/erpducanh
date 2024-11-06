using DucAnhERP.Models;
using DucAnhERP.ViewModel;

namespace DucAnhERP.Repository
{
    public interface ITKThepMongCHopRepository : IBaseRepository<TKThepMongCHop>
    {
        Task<string> InsertLaterFlag(TKThepMongCHop entity, int FlagLast);
        Task<List<TKThepMongCHopModel>> GetAllByVM(TKThepMongCHopModel mModel);
        Task<List<TKThepMongCHop>> GetExist(TKThepMongCHop searchData);
    }
}
