﻿using DucAnhERP.Models.NghiepVuCongTrinh;
using DucAnhERP.ViewModel.NghiepVuCongTrinh;

namespace DucAnhERP.Repository.NghiepVuCongTrinh
{
    public interface IPKKLMongCTronRepository :IBaseRepository<PKKLMongCTron>
    {
        Task<string> InsertLaterFlag(PKKLMongCTron entity, int FlagLast, bool insertBefore);
        Task<List<PKKLModel>> GetAllByVM(PKKLModel mModel);
        Task<List<PKKLMongCTron>> GetExist(PKKLMongCTron searchData);
        Task<double> GetSumTKLCK_SauCC(PKKLMongCTron input);

        Task<List<THKLModel>> GetTHKLMongCongTron();
        Task<List<THKLModel>> GetTHKLByTuyenDuong(List<NuocMuaModel> nuocMua);
        Task<PKKLMongCTron> GetTKLCK_SauCCByLCK(string id);
        double KTHH_KL1CK(PKKLMongCTron obj);
        double TTCDT_KL(PKKLMongCTron obj);
        double KL1CK_ChuaTruCC(PKKLMongCTron obj);
        //Task<List<THKLModel>> GetTHKLCongTron();
        //Task<List<THKLModel>> GetTHKLByTuyenDuong(List<NuocMuaModel> nuocMua);
    }
}
