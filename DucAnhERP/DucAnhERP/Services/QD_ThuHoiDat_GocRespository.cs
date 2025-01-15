using DucAnhERP.Data;
using DucAnhERP.Models;
using DucAnhERP.ViewModel;
using Microsoft.EntityFrameworkCore;
using DucAnhERP.Repository;
using System.Data;
namespace DucAnhERP.Services
{
    public class QD_ThuHoiDat_GocRepository : IQD_ThuHoiDat_GocRepository
    {
        private readonly IDbContextFactory<ApplicationDbContext> _context;
        public QD_ThuHoiDat_GocRepository(IDbContextFactory<ApplicationDbContext> context)
        {
            _context = context;
        }
        public async Task<List<QD_ThuHoiDat_GocModel>> GetAllByVM(QD_ThuHoiDat_GocModel dataModel, string groupId)
        {
            using var context = _context.CreateDbContext();
            var query = from p1 in context.QD_ThuHoiDat_Gocs
                        where p1.GroupId == groupId
                        select p1;
            if (!string.IsNullOrEmpty(dataModel.CompanyId))
            {
                query = query.Where(m => m.CompanyId == dataModel.CompanyId);
            }
            var data = await (from p1 in query
                              join ChiNhanhs1 in context.ChiNhanhs on p1.CompanyId equals ChiNhanhs1.Id
                              where p1.GroupId == groupId
                              orderby p1.CreateAt descending
                              select new QD_ThuHoiDat_GocModel
                              {
                                  Id = p1.Id,
                                  CompanyId = ChiNhanhs1.TenChiNhanh,
                                  SoQD_ThuHoiDat_Goc = p1.SoQD_ThuHoiDat_Goc,
                                  Ngay = p1.Ngay,
                                  Stt = p1.Stt,
                                  GroupId = p1.GroupId,
                                  Ordinarily = p1.Ordinarily,
                                  CreateAt = p1.CreateAt,
                                  CreateBy = p1.CreateBy,
                                  IsActive = p1.IsActive,
                                  ApprovalUserId = p1.ApprovalUserId,
                                  DateApproval = p1.DateApproval,
                                  DepartmentId = p1.DepartmentId,
                                  DepartmentOrder = p1.DepartmentOrder,
                                  ApprovalOrder = p1.ApprovalOrder,
                                  ApprovalId = p1.ApprovalId,
                                  LastApprovalId = p1.LastApprovalId,
                                  IsStatus = p1.IsStatus
                              }).ToListAsync();
            return data;
        }
        public async Task<List<QD_ThuHoiDat_GocModel>> GetHistoryIsValidEdit(string id)
        {
            using var context = _context.CreateDbContext();
            var data = await (from p1 in context.QD_ThuHoiDat_Goc_Logs
                              join ChiNhanhs1 in context.ChiNhanhs on p1.CompanyId equals ChiNhanhs1.Id
                              where p1.IdChung == id
                              orderby p1.CreateAt
                              select new QD_ThuHoiDat_GocModel
                              {
                                  Id = p1.Id,
                                  CompanyId = ChiNhanhs1.TenChiNhanh,
                                  SoQD_ThuHoiDat_Goc = p1.SoQD_ThuHoiDat_Goc,
                                  Ngay = p1.Ngay,
                                  Stt = p1.Stt,
                                  GroupId = p1.GroupId,
                                  Ordinarily = p1.Ordinarily,
                                  CreateAt = p1.CreateAt,
                                  CreateBy = p1.CreateBy,
                                  IsActive = p1.IsActive,
                                  ApprovalUserId = p1.ApprovalUserId,
                                  DateApproval = p1.DateApproval,
                                  DepartmentId = p1.DepartmentId,
                                  DepartmentOrder = p1.DepartmentOrder,
                                  ApprovalOrder = p1.ApprovalOrder,
                                  ApprovalId = p1.ApprovalId,
                                  LastApprovalId = p1.LastApprovalId,
                                  IsStatus = p1.IsStatus
                              }).ToListAsync();
            return data;
        }
        public async Task<QD_ThuHoiDat_GocModel> GetDetails(string id)
        {
            using var context = _context.CreateDbContext();
            var data = await (from p1 in context.QD_ThuHoiDat_Gocs
                              join ChiNhanhs1 in context.ChiNhanhs on p1.CompanyId equals ChiNhanhs1.Id
                              where p1.Id == id
                              select new QD_ThuHoiDat_GocModel
                              {
                                  Id = p1.Id,
                                  CompanyId = ChiNhanhs1.TenChiNhanh,
                                  SoQD_ThuHoiDat_Goc = p1.SoQD_ThuHoiDat_Goc,
                                  Ngay = p1.Ngay,
                                  Stt = p1.Stt,
                                  GroupId = p1.GroupId,
                                  Ordinarily = p1.Ordinarily,
                                  CreateAt = p1.CreateAt,
                                  CreateBy = p1.CreateBy,
                                  IsActive = p1.IsActive,
                                  ApprovalUserId = p1.ApprovalUserId,
                                  DateApproval = p1.DateApproval,
                                  DepartmentId = p1.DepartmentId,
                                  DepartmentOrder = p1.DepartmentOrder,
                                  ApprovalOrder = p1.ApprovalOrder,
                                  ApprovalId = p1.ApprovalId,
                                  LastApprovalId = p1.LastApprovalId,
                                  IsStatus = p1.IsStatus
                              }).FirstOrDefaultAsync();
            return data;
        }
        public async Task<List<QD_ThuHoiDat_Goc>> GetAll(string groupId)
        {
            try
            {
                using var context = _context.CreateDbContext();
                var entity = await context.QD_ThuHoiDat_Gocs.Where(p => p.IsActive != 100 && p.GroupId == groupId).ToListAsync();
                return entity;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"An error occurred: {ex.Message}");
                throw;
            }
        }
        public async Task<List<ChiNhanhModel>> GetChiNhanhs(string groupId)
        {
            try
            {
                using var context = _context.CreateDbContext();
                var entity = await (from p1 in context.QD_ThuHoiDat_Gocs
                                    join p2 in context.ChiNhanhs on p1.CompanyId equals p2.Id
                                    where p1.GroupId == groupId
                                    orderby p1.CreateAt descending
                                    select new ChiNhanhModel
                                    {
                                        Id = p2.Id,
                                        TenChiNhanh = p2.TenChiNhanh
                                    }).Distinct().ToListAsync();
                return entity;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"An error occurred: {ex.Message}");
                throw;
            }
        }
        public async Task<QD_ThuHoiDat_Goc> GetById(string id)
        {
            using var context = _context.CreateDbContext();
            var entity = await context.QD_ThuHoiDat_Gocs.Where(x => x.Id.Equals(id) && x.IsActive != 100).FirstOrDefaultAsync();
            if (entity == null)
            {
                throw new Exception($"Không tìm thấy số qđ thu hồi đất gốc đã chọn.");
            }
            return entity;
        }
        public async Task Insert(QD_ThuHoiDat_Goc entity, string userId)
        {
            try
            {
                using var context = _context.CreateDbContext();
                if (entity == null)
                {
                    throw new Exception("Không có số qđ thu hồi đất gốc nào được thêm!");
                }
                context.QD_ThuHoiDat_Gocs.Add(entity);
                var addLog = new QD_ThuHoiDat_Goc_Log()
                {
                    Id = entity.Id,
                    CompanyId = entity.CompanyId,
                    SoQD_ThuHoiDat_Goc = entity.SoQD_ThuHoiDat_Goc,
                    Ngay = entity.Ngay,
                    Stt = entity.Stt,
                    GroupId = entity.GroupId,
                    Ordinarily = entity.Ordinarily,
                    CreateAt = entity.CreateAt,
                    CreateBy = entity.CreateBy,
                    IsActive = entity.IsActive,
                    ApprovalUserId = entity.ApprovalUserId,
                    DateApproval = entity.DateApproval,
                    DepartmentId = entity.DepartmentId,
                    DepartmentOrder = entity.DepartmentOrder,
                    ApprovalOrder = entity.ApprovalOrder,
                    ApprovalId = entity.ApprovalId,
                    LastApprovalId = entity.LastApprovalId,
                    IsStatus = entity.IsStatus,
                    IdChung = entity.Id,
                    IsValid = true
                };
                context.QD_ThuHoiDat_Goc_Logs.Add(addLog);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        public async Task Update(QD_ThuHoiDat_Goc data, string userId)
        {
            using var context = _context.CreateDbContext();
            var entity = await GetById(data.Id);
            if (entity == null)
            {
                throw new Exception($"Không tìm thấy số qđ thu hồi đất gốc đã chọn");
            }
            context.QD_ThuHoiDat_Gocs.Update(data);
            if (data.IsActive == 3)
            {
                var updateLog = await (from p in context.QD_ThuHoiDat_Goc_Logs
                                       where p.IdChung == entity.Id && p.IsValid == true
                                       select p).ToListAsync();
                updateLog.ForEach(p => p.IsValid = false);
                context.QD_ThuHoiDat_Goc_Logs.UpdateRange(updateLog);
            }
            else if (entity.IsActive != 3)
            {
                var updateLog = await (from p in context.QD_ThuHoiDat_Goc_Logs
                                       where p.IdChung == entity.Id
                                       select p).OrderByDescending(p => p.CreateAt)
                .FirstOrDefaultAsync();
                if (updateLog != null)
                {
                    updateLog.IsValid = false;
                    context.QD_ThuHoiDat_Goc_Logs.Update(updateLog);
                }
            }
            var addLog = new QD_ThuHoiDat_Goc_Log()
            {
                Id = Guid.NewGuid().ToString(),
                CompanyId = data.CompanyId,
                SoQD_ThuHoiDat_Goc = data.SoQD_ThuHoiDat_Goc,
                Ngay = data.Ngay,
                Stt = data.Stt,
                GroupId = data.GroupId,
                Ordinarily = data.Ordinarily,
                CreateAt = data.CreateAt,
                CreateBy = data.CreateBy,
                IsActive = data.IsActive,
                ApprovalUserId = data.ApprovalUserId,
                DateApproval = data.DateApproval,
                DepartmentId = data.DepartmentId,
                DepartmentOrder = data.DepartmentOrder,
                ApprovalOrder = data.ApprovalOrder,
                ApprovalId = data.ApprovalId,
                LastApprovalId = data.LastApprovalId,
                IsStatus = data.IsStatus,
                IdChung = data.Id,
                IsValid = true
            };
            context.QD_ThuHoiDat_Goc_Logs.Add(addLog);
            await context.SaveChangesAsync();
        }
        public async Task UpdateMulti(QD_ThuHoiDat_Goc[] QD_ThuHoiDat_Gocs)
        {
            using var context = _context.CreateDbContext();
            string[] ids = QD_ThuHoiDat_Gocs.Select(x => x.Id).ToArray();
            var listEntities = await context.QD_ThuHoiDat_Gocs.Where(x => ids.Contains(x.Id)).ToListAsync();
            foreach (var entity in listEntities)
            {
                context.QD_ThuHoiDat_Gocs.Update(entity);
            }
            await context.SaveChangesAsync();
        }
        public async Task DeleteById(string id, string userId)
        {
            using var context = _context.CreateDbContext();
            var entity = await GetById(id);
            if (entity == null)
            {
                throw new Exception($"Không tìm thấy số qđ thu hồi đất gốc đã chọn");
            }
            context.Set<QD_ThuHoiDat_Goc>().Remove(entity);
            await context.SaveChangesAsync();
        }
        public async Task<bool> CheckStatus(string ids, string name)
        {
            using var context = _context.CreateDbContext();
            var model = await context.QD_ThuHoiDat_Gocs.Where(p => p.Id == ids).FirstOrDefaultAsync();
            if (model == null)
            {
                throw new Exception($"Không tìm thấy số qđ thu hồi đất gốc đã chọn");
            }
            if (model != null && model.IsActive == 0)
            {
                throw new Exception($"Số QĐ thu hồi đất gốc đang chờ duyệt thêm mới.");
            }
            if (model != null && model.IsActive == 1)
            {
                throw new Exception($"Số QĐ thu hồi đất gốc đang chờ duyệt sửa.");
            }
            if (model != null && model.IsActive == 2)
            {
                throw new Exception($"Số QĐ thu hồi đất gốc đang chờ duyệt xóa.");
            }
            if (model != null && model.SoQD_ThuHoiDat_Goc.ToUpper() != name.ToUpper() && name != "")
            {
                throw new Exception($"Tên số qđ thu hồi đất gốc đã bị thay đổi.");
            }
            return true;
        }
        public async Task<bool> CheckSave(QD_ThuHoiDat_Goc input)
        {
            try
            {
                using var context = _context.CreateDbContext();
                var model = await (from p in context.QD_ThuHoiDat_Goc_Logs
                                   where p.Id != input.Id && p.IsValid == true
                                   && p.CompanyId == input.CompanyId
                                   && p.SoQD_ThuHoiDat_Goc == input.SoQD_ThuHoiDat_Goc
                                   select p).CountAsync();
                if (model > 0)
                {
                    throw new Exception($"Thông tin bạn nhập đã tồn tại.");
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: " + ex.Message);
            }
        }
        public async Task<bool> CheckEdit(QD_ThuHoiDat_Goc input)
        {
            try
            {
                using var context = _context.CreateDbContext();
                var model = await (from p in context.QD_ThuHoiDat_Goc_Logs
                                   where p.Id != input.Id && p.IsValid == true
                                   && p.CompanyId == input.CompanyId
                                   && p.SoQD_ThuHoiDat_Goc == input.SoQD_ThuHoiDat_Goc
                                   select p).CountAsync();
                if (model > 0)
                {
                    throw new Exception($"Thông tin bạn nhập đã tồn tại.");
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: " + ex.Message);
            }
        }
        public async Task<bool> CheckDelete(QD_ThuHoiDat_Goc input)
        {
            try
            {
                using var context = _context.CreateDbContext();
                if (1 == 0)
                {
                    throw new Exception($"");
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: " + ex.Message);
            }
        }
        public async Task<bool> CheckExclusive(string[] ids, DateTime baseTime)
        {
            foreach (var id in ids)
            {
                var model = await GetById(id);
                if (model == null)
                {
                    throw new Exception($"Không tìm thấy số qđ thu hồi đất gốc đã chọn");
                }
                if (model.CreateAt > baseTime)
                {
                    throw new Exception($"Thông tin đã bị thay đổi bởi người dùng khác. Vui lòng tải lại trang!");
                }
            }
            return true;
        }
    }
}
