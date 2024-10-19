using DucAnhERP.Models;
using DucAnhERP.ViewModel;

namespace DucAnhERP.Repository
{
    public interface ITKThepHoGaRepository :IBaseRepository<TKThepHoGa>
    {
        Task<string> InsertLaterFlag(TKThepHoGa entity, int FlagLast);
        Task<List<TKThepHoGaModel>> GetAllByVM(TKThepHoGaModel mModel);
        Task<List<TKThepHoGa>> GetExist(TKThepHoGa searchData);
    }
}
