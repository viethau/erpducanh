﻿using DucAnhERP.Models;
using DucAnhERP.ViewModel;

namespace DucAnhERP.Repository
{
    public interface IPhanLoaiTDanTDanRepository : IBaseRepository<PhanLoaiTDanTDan>
    {
        Task<List<PhanLoaiTDanTDanModel>> GetAllByVM();
        Task<bool> CheckUsingId(string id);
        Task<PhanLoaiTDanTDan> GetPhanLoaiTDanTDanByDetail(PhanLoaiTDanTDan pltdtd);
        Task<string> InsertId(PhanLoaiTDanTDan entity, string HTTD, string LTD, string CTTDTC);
    }
}