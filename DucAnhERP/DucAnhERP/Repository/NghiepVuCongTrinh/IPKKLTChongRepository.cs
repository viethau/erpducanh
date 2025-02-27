﻿using DucAnhERP.Models.NghiepVuCongTrinh;
using DucAnhERP.ViewModel.NghiepVuCongTrinh;

namespace DucAnhERP.Repository.NghiepVuCongTrinh
{
    public interface IPKKLTChongRepository : IBaseRepository<PKKLTChong>
    {
        Task<string> InsertLaterFlag(PKKLTChong entity, int FlagLast, bool insertBefore);
        Task<List<PKKLModel>> GetAllByVM(PKKLModel mModel);
        Task<List<PKKLTChong>> GetExist(PKKLTChong searchData);
        Task<PKKLTChong> GetTKLCK_SauCCByLCK(string id);
        Task<double> GetSumTKLCK_SauCCByLCK(string id);
        Task<List<THKLModel>> GetTHKLThanhChong();
        Task<List<THKLModel>> GetTHKLByTuyenDuong(List<NuocMuaModel> nuocMua);
        double KTHH_KL1CK(PKKLTChong obj);
        double TTCDT_KL(PKKLTChong obj);
        double KL1CK_ChuaTruCC(PKKLTChong obj);
    }
}
