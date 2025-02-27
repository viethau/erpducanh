﻿using DucAnhERP.Models.NghiepVuCongTrinh;
using DucAnhERP.ViewModel.NghiepVuCongTrinh;

namespace DucAnhERP.Repository.NghiepVuCongTrinh
{
    public interface IPKKLRanhBTRepository :IBaseRepository<PKKLRanhBT>
    {
        Task<string> InsertLaterFlag(PKKLRanhBT entity, int FlagLast, bool insertBefore);
        Task<List<PKKLModel>> GetAllByVM(PKKLModel mModel);
        Task<List<PKKLRanhBT>> GetExist(PKKLRanhBT searchData);
        Task<PKKLRanhBT> GetTKLCK_SauCCByLCK(string id);
        Task<double> GetSumTKLCK_SauCCByLCK(string id);
        Task<List<THKLModel>> GetTHKLRanhBT();
        Task<List<THKLModel>> GetTHKLByTuyenDuong(List<NuocMuaModel> nuocMua);
        double KTHH_KL1CK(PKKLRanhBT obj);
        double TTCDT_KL(PKKLRanhBT obj);
        double KL1CK_ChuaTruCC(PKKLRanhBT obj);
    }
}
