using DucAnhERP.Models.NghiepVuCongTrinh;
using DucAnhERP.ViewModel.NghiepVuCongTrinh;

namespace DucAnhERP.Repository.NghiepVuCongTrinh
{
    public interface IMangThuRepository : IBaseRepository<MangThu>
    {
            Task<List<MangThuModel>> GetAllByVM();
            Task<int> MultiInsert(List<MangThu> entities);
            Task<string> InsertLaterFlag(MangThu entity, int FlagLast);
        
    }
}
