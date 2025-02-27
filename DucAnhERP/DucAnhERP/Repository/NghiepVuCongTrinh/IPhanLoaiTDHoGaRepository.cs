﻿using DucAnhERP.Models.NghiepVuCongTrinh;
using DucAnhERP.ViewModel.NghiepVuCongTrinh;

namespace DucAnhERP.Repository.NghiepVuCongTrinh
{
    public interface IPhanLoaiTDHoGaRepository : IBaseRepository<PhanLoaiTDHoGa>
    {
        Task<List<PhanLoaiTDHoGaModel>> GetAllByVM(PhanLoaiTDHoGaModel pltdhgModel);
        Task<bool> CheckUsingId(string id);
        Task<bool> CheckUsingName(string name);
        Task<PhanLoaiTDHoGa> GetPhanLoaiTDHoGaByDetail(PhanLoaiTDHoGa pltdhg);
        Task<PhanLoaiTDHoGa> GetPhanLoaiTDHoGaExist(PhanLoaiTDHoGa searchData);
        Task<string> InsertId(PhanLoaiTDHoGa entity, string HinhThucDayHoGa);
        Task<string> InsertLaterFlag(PhanLoaiTDHoGa entity, int FlagLast);
        Task<List<PhanLoaiTDHoGaModel>> GetBaoCaoKTHHTDanHGa(PhanLoaiTDHoGaModel pltdhgaModel);
        Task<List<PhanLoaiTDHoGaModel>> GetBaoCaoTDanHGaSDThep(PhanLoaiTDHoGaModel pltdhgaModel);
    }
}
