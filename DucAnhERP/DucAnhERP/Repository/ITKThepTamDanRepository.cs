using DucAnhERP.Models;
using DucAnhERP.ViewModel;

namespace DucAnhERP.Repository
{
    public interface ITKThepTamDanRepository : IBaseRepository<TKThepTamDan>
    {
        Task<string> InsertLaterFlag(TKThepTamDan entity, int FlagLast);
        Task<List<TKThepTamDanModel>> GetAllByVM(TKThepTamDanModel mModel);
        Task<List<TKThepTamDan>> GetExist(TKThepTamDan searchData);
    }
}
