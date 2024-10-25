using DucAnhERP.Models;
using DucAnhERP.ViewModel;

namespace DucAnhERP.Repository
{
    public interface IChatMaTuongRepository: IBaseRepository<MaTuong>
    {
        Task<string> InsertLaterFlag(MaTuong entity, int FlagLast);
        Task<List<MaTuongModel>> GetAllByVM(MaTuongModel mModel);
        Task<List<MaTuong>> GetExist(MaTuong searchData);
        Task<MaTuongModel> GetDetailByIdPLHoGa(string id);
    }
}
