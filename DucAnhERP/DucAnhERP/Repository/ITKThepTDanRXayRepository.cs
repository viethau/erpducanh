using DucAnhERP.Models;
using DucAnhERP.ViewModel;

namespace DucAnhERP.Repository
{
    public interface ITKThepTDanRXayRepository :IBaseRepository<TKThepTDanRXay>
    {
        Task<string> InsertLaterFlag(TKThepTDanRXay entity, int FlagLast);
        Task<List<TKThepTDanRXayModel>> GetAllByVM(TKThepTDanRXayModel mModel);
        Task<List<TKThepTDanRXay>> GetExist(TKThepTDanRXay searchData);
    }
}
