using DucAnhERP.Models;
using DucAnhERP.ViewModel;

namespace DucAnhERP.Repository
{
    public interface ITKThepMongCTronRepository :IBaseRepository<TKThepMongCTron>
    {
        Task<string> InsertLaterFlag(TKThepMongCTron entity, int FlagLast);
        Task<List<TKThepMongCTronModel>> GetAllByVM(TKThepMongCTronModel mModel);
        Task<List<TKThepMongCTron>> GetExist(TKThepMongCTron searchData);
    }
}
