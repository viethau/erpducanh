﻿using DucAnhERP.Models.NghiepVuCongTrinh;
using DucAnhERP.ViewModel.NghiepVuCongTrinh;

namespace DucAnhERP.Repository.NghiepVuCongTrinh
{
    public interface IPhanLoaiDeCongRepository : IBaseRepository<PhanLoaiDeCong>
    {
        Task<List<PhanLoaiDeCongModel>> GetAllByVM(PhanLoaiDeCongModel pldcModel);
        Task<bool> CheckUsingId(string id);
        Task<bool> CheckUsingName(string name);
        Task<PhanLoaiDeCong> GetPhanLoaiDeCongByDetail(PhanLoaiDeCong plmc);
        Task<PhanLoaiDeCong> GetPhanLoaiDeCongExist(PhanLoaiDeCong searchData);
        Task<string> InsertId(PhanLoaiDeCong entity, string CTDC, string LoaiTD);
        Task<string> InsertLaterFlag(PhanLoaiDeCong entity, int FlagLast);
    }
}
