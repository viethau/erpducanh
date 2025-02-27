﻿using DucAnhERP.Models.NghiepVuCongTrinh;
using DucAnhERP.ViewModel.NghiepVuCongTrinh;

namespace DucAnhERP.Repository.NghiepVuCongTrinh
{
    public interface IPKKLTDanRXayRepository :IBaseRepository<PKKLTDanRXay>
    {
        Task<string> InsertLaterFlag(PKKLTDanRXay entity, int FlagLast, bool insertBefore);
        Task<List<PKKLModel>> GetAllByVM(PKKLModel mModel);
        Task<List<PKKLTDanRXay>> GetExist(PKKLTDanRXay searchData);
        Task<PKKLTDanRXay> GetTKLCK_SauCCByLCK(string id);
        Task<double> GetSumTKLCK_SauCCByLCK(string id);
        Task<List<THKLModel>> GetTHKLTDanRXay();
        Task<List<THKLModel>> GetTHKLByTuyenDuong(List<NuocMuaModel> nuocMua);
        double KTHH_KL1CK(PKKLTDanRXay obj);
        double TTCDT_KL(PKKLTDanRXay obj);
        double KL1CK_ChuaTruCC(PKKLTDanRXay obj);
    }
}
