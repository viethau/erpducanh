using DucAnhERP.Models;
using DucAnhERP.ViewModel;

namespace DucAnhERP.Repository
{
    public interface ITKThepHoGaRepository :IBaseRepository<TKThepHGa>
    {
        Task<string> InsertLaterFlag(TKThepHGa entity, int FlagLast);
        //Task<List<TKThepHGaModel>> GetAllByVM(TKThepHGaModel mModel);
    }
}
