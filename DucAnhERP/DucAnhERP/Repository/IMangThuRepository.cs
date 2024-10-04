using DucAnhERP.Models;
using DucAnhERP.ViewModel;

namespace DucAnhERP.Repository
{
    public interface IMangThuRepository : IBaseRepository<MangThu>
    {
            Task<List<MangThuModel>> GetAllByVM();
            Task<int> MultiInsert(List<MangThu> entities);
            Task<string> InsertLaterFlag(MangThu entity, int FlagLast);
        
    }
}
