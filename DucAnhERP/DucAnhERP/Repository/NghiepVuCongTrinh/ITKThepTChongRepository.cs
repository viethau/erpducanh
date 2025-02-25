using DucAnhERP.Helpers;
using DucAnhERP.Models.NghiepVuCongTrinh;
using DucAnhERP.ViewModel.NghiepVuCongTrinh;

namespace DucAnhERP.Repository.NghiepVuCongTrinh
{
    public interface ITKThepTChongRepository : IBaseRepository<TKThepTChong>
    {
        Task<string> InsertLaterFlag(TKThepTChong entity, int FlagLast, bool insertBefore);
        Task<List<TKThepTChongModel>> GetAllByVM(TKThepTChongModel mModel);
        Task<List<TKThepTChong>> GetExist(TKThepTChong searchData);
        Task<List<SelectedItem>> GetDistinctTenCongTacByPL(string TTKTHHCongHopRanh_LoaiThanhChong);
    }
}
