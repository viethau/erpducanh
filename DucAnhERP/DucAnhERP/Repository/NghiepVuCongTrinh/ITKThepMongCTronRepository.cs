﻿using DucAnhERP.Helpers;
using DucAnhERP.Models.NghiepVuCongTrinh;
using DucAnhERP.ViewModel.NghiepVuCongTrinh;

namespace DucAnhERP.Repository.NghiepVuCongTrinh
{
    public interface ITKThepMongCTronRepository :IBaseRepository<TKThepMongCTron>
    {
        Task<string> InsertLaterFlag(TKThepMongCTron entity, int FlagLast);
        Task<List<TKThepMongCTronModel>> GetAllByVM(TKThepMongCTronModel mModel);
        Task<List<TKThepMongCTron>> GetExist(TKThepMongCTron searchData);
        Task<List<SelectedItem>> GetDistinctTenCongTacByPL(string ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai);

    }
}
