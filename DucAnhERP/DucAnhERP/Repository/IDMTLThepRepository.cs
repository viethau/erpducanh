using DucAnhERP.Models;
using DucAnhERP.ViewModel;

namespace DucAnhERP.Repository
{
    public interface IDMTLThepRepository :IBaseRepository<DMThep>
    {
        Task<string> InsertLaterFlag(DMThep entity, int FlagLast);
        Task<List<DMTLThepModel>> GetAllByVM(DMTLThepModel mModel);
        Task<List<DMThep>> GetExist(DMThep searchData);
        Task<bool> CheckUsingId(string LoaiThep, string KichThuoc);
        Task<DMThep> GetTrongLuong(string LoaiThep, string DKCD);
        
    }
}
