using DucAnhERP.Helpers;
using DucAnhERP.Models.NghiepVuCongTrinh;
using DucAnhERP.ViewModel.NghiepVuCongTrinh;

namespace DucAnhERP.Repository.NghiepVuCongTrinh
{
    public interface ITKThepTDRBTongRepository : IBaseRepository<TKThepTDRBTong>
    {
        Task<string> InsertLaterFlag(TKThepTDRBTong entity, int FlagLast, bool insertBefore);
        Task<List<TKThepTDRBTongModel>> GetAllByVM(TKThepTDRBTongModel mModel);
        Task<List<TKThepTDRBTong>> GetExist(TKThepTDRBTong searchData);
        Task<List<SelectedItem>> GetDistinctTenCongTacByPL(string ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai);
    }
}
