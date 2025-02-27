﻿using DucAnhERP.Models.NghiepVuCongTrinh;
using DucAnhERP.ViewModel;
using DucAnhERP.ViewModel.NghiepVuCongTrinh;

namespace DucAnhERP.Repository.NghiepVuCongTrinh
{
    public interface IChatMaTuongRepository: IBaseRepository<MaTuong>
    {
        Task<string> InsertLaterFlag(MaTuong entity, int FlagLast, bool insertBefore);
        Task<List<MaTuongModel>> GetAllByVM(MaTuongModel mModel);
        Task<List<MaTuong>> GetExist(MaTuong searchData);
        Task<MaTuongModel> GetDetailByIdPLHoGa(string id);
    }
}
