using DucAnhERP.Models;
using DucAnhERP.ViewModel;

namespace DucAnhERP.Repository
{
    public interface IPKKLHoGaRepository :IBaseRepository<PKKLHoGa>
    {
        Task<string> InsertLaterFlag(PKKLHoGa entity, int FlagLast);
        Task<List<PKKLHoGaModel>> GetAllByVM(PKKLHoGaModel mModel);
        Task<List<PKKLHoGa>> GetExist(PKKLHoGa searchData);
    }
}
