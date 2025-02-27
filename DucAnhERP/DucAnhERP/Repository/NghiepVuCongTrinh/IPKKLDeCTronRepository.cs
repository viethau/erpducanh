﻿using DucAnhERP.Models.NghiepVuCongTrinh;
using DucAnhERP.ViewModel.NghiepVuCongTrinh;
using Microsoft.EntityFrameworkCore;

namespace DucAnhERP.Repository.NghiepVuCongTrinh
{
    public interface IPKKLDeCTronRepository :IBaseRepository<PKKLDeCTron>        
    {
        Task<string> InsertLaterFlag(PKKLDeCTron entity, int FlagLast, bool insertBefore);
        Task<List<PKKLModel>> GetAllByVM(PKKLModel mModel);
        Task<List<PKKLDeCTron>> GetExist(PKKLDeCTron searchData);
        Task<PKKLDeCTron> GetTKLCK_SauCCByLCK(string id);
        Task<double> GetSumTKLCK_SauCCByLCK(string id);
        Task<List<THKLModel>> GetTHKLDeCongTron();
        Task<List<THKLModel>> GetTHKLByTuyenDuong(List<NuocMuaModel> nuocMua);
        double KTHH_KL1CK(PKKLDeCTron obj);
        double TTCDT_KL(PKKLDeCTron obj);
        double KL1CK_ChuaTruCC(PKKLDeCTron obj);
    }
}
