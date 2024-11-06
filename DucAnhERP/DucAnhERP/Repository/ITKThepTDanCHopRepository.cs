using DucAnhERP.Models;
using DucAnhERP.ViewModel;

namespace DucAnhERP.Repository
{
    public interface ITKThepTDanCHopRepository :IBaseRepository<TKThepTDanCHop>
    {
        Task<string> InsertLaterFlag(TKThepTDanCHop entity, int FlagLast);
        Task<List<TKThepTDanCHopModel>> GetAllByVM(TKThepTDanCHopModel mModel);
        Task<List<TKThepTDanCHop>> GetExist(TKThepTDanCHop searchData);
    }
}
