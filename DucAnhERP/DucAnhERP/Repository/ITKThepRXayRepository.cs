using DucAnhERP.Models;
using DucAnhERP.ViewModel;

namespace DucAnhERP.Repository
{
    public interface ITKThepRXayRepository :IBaseRepository<TKThepRXay>
    {
        Task<string> InsertLaterFlag(TKThepRXay entity, int FlagLast);
        Task<List<TKThepRXayModel>> GetAllByVM(TKThepRXayModel mModel);
        Task<List<TKThepRXay>> GetExist(TKThepRXay searchData);
    }
}
