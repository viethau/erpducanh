using DucAnhERP.ViewModel.QLNV;
using DucAnhERP.Models.QLNV;

namespace DucAnhERP.Repository.QLNV
{
    public interface IQLNV_CongViecRepository : IBaseRepository<QLNV_CongViec>
    {
        public Task<List<QLNV_CongViecModel>> GetByVM(QLNV_CongViecModel input);
        public Task DeleteByIdTask(string Id_Task, string userId);
        public Task<List<QLNV_CongViec>> GetByIdTask(string id);
        public Task<bool> CheckExist(string id, QLNV_CongViec input );
        public Task<bool> IsIdInUse(string id);
        //cvc
        public Task InsertCVC(QLNV_CongViecCon entity, string userId);
        public Task<List<QLNV_CongViecCon>> GetAllCVC();
        public Task<QLNV_CongViecCon> GetByIdCVC(string id);
        public  Task<List<QLNV_CongViecCon>> GetByIdTaskCVC(string id_task);
        public  Task DeleteByIdCVC(string id, string userId);
        public  Task DeleteByIdTaskCVC(string Id_Task, string userId);
        public  Task UpdateCVC(QLNV_CongViecCon data, string userId);
        public Task<bool> CheckExistCVC(string id, QLNV_CongViecCon input);
        public Task<bool> CheckExclusiveCVC(string[] ids, DateTime baseTime);
    }
}
