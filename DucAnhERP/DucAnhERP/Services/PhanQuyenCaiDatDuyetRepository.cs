using DucAnhERP.Data;
using DucAnhERP.Models;
using DucAnhERP.Repository;
using DucAnhERP.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace DucAnhERP.Services
{
    public class PhanQuyenCaiDatDuyetRepository : IPhanQuyenCaiDatDuyetRepository
    {
        private readonly IDbContextFactory<ApplicationDbContext> _context;
        public PhanQuyenCaiDatDuyetRepository(IDbContextFactory<ApplicationDbContext> context)
        {
            _context = context;
        }
        public async Task<List<PhanQuyenCaiDatDuyetModel>> GetAllByVM(PhanQuyenCaiDatDuyetModel dataModel, string groupId)
        {
            using var context = _context.CreateDbContext();
            var query = from p1 in context.PhanQuyenCaiDatDuyets
                        where p1.GroupId == groupId && p1.IsActive != 100
                        select p1;
            if (!string.IsNullOrEmpty(dataModel.CompanyId))
            {
                query = query.Where(m => m.CompanyId == dataModel.CompanyId);
            }
            if (!string.IsNullOrEmpty(dataModel.ParentMajorId))
            {
                query = query.Where(m => m.ParentMajorId == dataModel.ParentMajorId);
            }
            if (!string.IsNullOrEmpty(dataModel.MajorId))
            {
                query = query.Where(m => m.MajorId == dataModel.MajorId);
            }
            if (!string.IsNullOrEmpty(dataModel.UserId))
            {
                query = query.Where(m => m.UserId == dataModel.UserId);
            }
            var data = await (from p1 in query
                              join ChiNhanhs1 in context.ChiNhanhs on p1.CompanyId equals ChiNhanhs1.Id
                              join Majors1 in context.Majors on p1.ParentMajorId equals Majors1.Id
                              join Majors2 in context.Majors on p1.MajorId equals Majors2.Id
                              join ApplicationUsers1 in context.ApplicationUsers on p1.UserId equals ApplicationUsers1.Id
                              join Department1 in context.Departments on ApplicationUsers1.DeptId equals Department1.Id
                              where p1.GroupId == groupId
                              orderby p1.CreateAt descending
                              select new PhanQuyenCaiDatDuyetModel
                              {
                                  Id = p1.Id,
                                  CompanyId = ChiNhanhs1.TenChiNhanh,
                                  ParentMajorId = Majors1.MajorName,
                                  MajorId = Majors2.MajorName,
                                  DeptId = Department1.DeptName,
                                  UserId = ApplicationUsers1.UserName,
                                  CreateAt = p1.CreateAt,
                                  CreateBy = p1.CreateBy,
                                  IsActive = p1.IsActive,
                                 
                              }).ToListAsync();
            return data;
        }
        public async Task<List<PhanQuyenCaiDatDuyetModel>> GetHistoryIsValidEdit(string id)
        {
            using var context = _context.CreateDbContext();
            var data = await (from p1 in context.PhanQuyenCaiDatDuyet_Logs
                              join ChiNhanhs1 in context.ChiNhanhs on p1.CompanyId equals ChiNhanhs1.Id
                              join Majors1 in context.Majors on p1.ParentMajorId equals Majors1.Id
                              join Majors2 in context.Majors on p1.MajorId equals Majors2.Id
                              join ApplicationUsers1 in context.ApplicationUsers on p1.UserId equals ApplicationUsers1.Id
                              join Department1 in context.Departments on ApplicationUsers1.DepartmentId equals Department1.Id
                              where p1.IdChung == id && p1.IsValid == true
                              orderby p1.CreateAt
                              select new PhanQuyenCaiDatDuyetModel
                              {
                                  Id = p1.Id,
                                  CompanyId = ChiNhanhs1.TenChiNhanh,
                                  ParentMajorId = Majors1.MajorName,
                                  MajorId = Majors2.MajorName,
                                  UserId = ApplicationUsers1.UserName,
                                  DeptId = Department1.DeptName,
                                  CreateAt = p1.CreateAt,
                                  CreateBy = p1.CreateBy,
                                  IsActive = p1.IsActive
                              }).ToListAsync();
            return data;
        }
        public async Task<PhanQuyenCaiDatDuyetModel> GetDetails(string id)
        {
            using var context = _context.CreateDbContext();
            var data = await (from p1 in context.PhanQuyenCaiDatDuyets
                              join ChiNhanhs1 in context.ChiNhanhs on p1.CompanyId equals ChiNhanhs1.Id
                              join Majors1 in context.Majors on p1.ParentMajorId equals Majors1.Id
                              join Majors2 in context.Majors on p1.MajorId equals Majors2.Id
                              join ApplicationUsers1 in context.ApplicationUsers on p1.UserId equals ApplicationUsers1.Id
                              join createBy in context.ApplicationUsers on p1.CreateBy equals createBy.Id
                              
                              join b in context.Departments on ApplicationUsers1.DepartmentId equals b.Id into b1
                              from departmentId in b1.DefaultIfEmpty()
                              where p1.Id == id
                              select new PhanQuyenCaiDatDuyetModel
                              {
                                  Id = p1.Id,
                                  CompanyId = ChiNhanhs1.TenChiNhanh,
                                  ParentMajorId = Majors1.MajorName,
                                  MajorId = Majors2.MajorName,
                                  UserId = ApplicationUsers1.UserName,
                                  DeptId = p1.Id,
                                  CreateAt = p1.CreateAt,
                                  CreateBy = createBy.Email,
                                  IsActive = p1.IsActive,
                                  
                              }).FirstOrDefaultAsync();
            return data;
        }
        public async Task<List<PhanQuyenCaiDatDuyetModel>> GetHistory(string id)
        {
            using var context = _context.CreateDbContext();
            var data = await (from p1 in context.PhanQuyenCaiDatDuyet_Logs
                              join ChiNhanhs1 in context.ChiNhanhs on p1.CompanyId equals ChiNhanhs1.Id
                              join Majors1 in context.Majors on p1.ParentMajorId equals Majors1.Id
                              join Majors2 in context.Majors on p1.MajorId equals Majors2.Id
                              join ApplicationUsers1 in context.ApplicationUsers on p1.UserId equals ApplicationUsers1.Id
                              join createBy in context.ApplicationUsers on p1.CreateBy equals createBy.Id
                              join Department1 in context.Departments on ApplicationUsers1.DeptId equals Department1.Id into b1
                              from departmentId in b1.DefaultIfEmpty()
                              where p1.IdChung == id
                              orderby p1.CreateAt
                              select new PhanQuyenCaiDatDuyetModel
                              {
                                  Id = p1.Id,
                                  CompanyId = ChiNhanhs1.TenChiNhanh,
                                  ParentMajorId = Majors1.MajorName,
                                  MajorId = Majors2.MajorName,
                                  UserId = ApplicationUsers1.UserName,
                                  DeptId = departmentId.DeptName,
                                  CreateAt = p1.CreateAt,
                                  CreateBy = createBy.Email,
                                  IsActive = p1.IsActive,
                                  
                              }).ToListAsync();
            return data;
        }
        public async Task<List<PhanQuyenCaiDatDuyet>> GetAll(string groupId)
        {
            try
            {
                using var context = _context.CreateDbContext();
                var entity = await context.PhanQuyenCaiDatDuyets.Where(p => p.IsActive != 100 && p.GroupId == groupId).ToListAsync();
                return entity;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"An error occurred: {ex.Message}");
                throw;
            }
        }
        public async Task<List<ChiNhanhModel>>? GetChiNhanhsForCompanyId(string groupId)
        {
            try
            {
                using var context = _context.CreateDbContext();
                var entity = await (from p1 in context.PhanQuyenCaiDatDuyets
                                    join p2 in context.ChiNhanhs on p1.CompanyId equals p2.Id
                                    where p1.GroupId == groupId && p1.IsActive != 100
                                    orderby p2.TenChiNhanh
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
        public async Task<List<MajorModel>>? GetMajorsForParentMajorId(string groupId)
        {
            try
            {
                using var context = _context.CreateDbContext();
                var entity = await (from p1 in context.PhanQuyenCaiDatDuyets
                                    join p2 in context.Majors on p1.ParentMajorId equals p2.Id
                                    where p1.GroupId == groupId && p1.IsActive != 100
                                    orderby p2.MajorName
                                    select new MajorModel
                                    {
                                        Id = p2.Id,
                                        MajorName = p2.MajorName
                                    }).Distinct().ToListAsync();
                return entity;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"An error occurred: {ex.Message}");
                throw;
            }
        }
        public async Task<List<MajorModel>>? GetMajorsForMajorId(string groupId)
        {
            try
            {
                using var context = _context.CreateDbContext();
                var entity = await (from p1 in context.PhanQuyenCaiDatDuyets
                                    join p2 in context.Majors on p1.MajorId equals p2.Id
                                    where p1.GroupId == groupId && p1.IsActive != 100
                                    orderby p2.MajorName
                                    select new MajorModel
                                    {
                                        Id = p2.Id,
                                        MajorName = p2.MajorName
                                    }).Distinct().ToListAsync();
                return entity;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"An error occurred: {ex.Message}");
                throw;
            }
        }
        public async Task<List<ApplicationUserModel>>? GetApplicationUsersForUserId(string groupId)
        {
            try
            {
                using var context = _context.CreateDbContext();
                var entity = await (from p1 in context.PhanQuyenCaiDatDuyets
                                    join p2 in context.ApplicationUsers on p1.UserId equals p2.Id
                                    where p1.GroupId == groupId && p1.IsActive != 100
                                    orderby p2.UserName
                                    select new ApplicationUserModel
                                    {
                                        Id = p2.Id,
                                        UserName = p2.UserName
                                    }).Distinct().ToListAsync();
                return entity;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"An error occurred: {ex.Message}");
                throw;
            }
        }
        public async Task<PhanQuyenCaiDatDuyet> GetById(string id)
        {
            using var context = _context.CreateDbContext();
            var entity = await context.PhanQuyenCaiDatDuyets.Where(x => x.Id.Equals(id) && x.IsActive != 100).FirstOrDefaultAsync();
            if (entity == null)
            {
                throw new Exception($"Không tìm thấy phân quyền cài đặt đã chọn.");
            }
            return entity;
        }
        public async Task Insert(PhanQuyenCaiDatDuyet entity, string userId)
        {
            try
            {
                using var context = _context.CreateDbContext();
                if (entity == null)
                {
                    throw new Exception("Không có phân quyền cài đặt nào được thêm!");
                }
                context.PhanQuyenCaiDatDuyets.Add(entity);
                var addLog = new PhanQuyenCaiDatDuyet_Log()
                {
                    Id = entity.Id,
                    CompanyId = entity.CompanyId,
                    ParentMajorId = entity.ParentMajorId,
                    MajorId = entity.MajorId,
                    DeptId = entity.DeptId,
                    UserId = entity.UserId,
                    GroupId = entity.GroupId,
                    CreateAt = DateTime.Now,
                    CreateBy = entity.CreateBy,
                    IsActive = entity.IsActive,

                    IdChung = entity.Id,
                    IsValid = true
                };
                context.PhanQuyenCaiDatDuyet_Logs.Add(addLog);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        public async Task Update(PhanQuyenCaiDatDuyet data, string userId)
        {
            using var context = _context.CreateDbContext();
            var entity = await GetById(data.Id);
            if (entity == null)
            {
                throw new Exception($"Không tìm thấy phân quyền cài đặt đã chọn");
            }
            context.PhanQuyenCaiDatDuyets.Update(data);
            if (data.IsActive == 3)
            {
                var updateLog = await (from p in context.PhanQuyenCaiDatDuyet_Logs
                                       where p.IdChung == entity.Id && p.IsValid == true
                                       select p).ToListAsync();
                updateLog.ForEach(p => p.IsValid = false);
                context.PhanQuyenCaiDatDuyet_Logs.UpdateRange(updateLog);
            }
            else if (data.IsActive == 100)
            {
                var updateLog = await (from p in context.PhanQuyenCaiDatDuyet_Logs
                                       where p.IdChung == entity.Id && p.IsValid == true
                                       select p).ToListAsync();
                updateLog.ForEach(p => p.IsValid = false);
                context.PhanQuyenCaiDatDuyet_Logs.UpdateRange(updateLog);
            }
            else if (entity.IsActive != 3)
            {
                var updateLog = await (from p in context.PhanQuyenCaiDatDuyet_Logs
                                       where p.IdChung == entity.Id
                                       select p).OrderByDescending(p => p.CreateAt)
                .FirstOrDefaultAsync();
                if (updateLog != null)
                {
                    updateLog.IsValid = false;
                    context.PhanQuyenCaiDatDuyet_Logs.Update(updateLog);
                }
            }
            var addLog = new PhanQuyenCaiDatDuyet_Log()
            {
                Id = Guid.NewGuid().ToString(),
                CompanyId = entity.CompanyId,
                ParentMajorId = entity.ParentMajorId,
                MajorId = entity.MajorId,
                DeptId = entity.DeptId,
                UserId = entity.UserId,
                GroupId = entity.GroupId,
                
                CreateAt = DateTime.Now,
                CreateBy = entity.CreateBy,
                IsActive = entity.IsActive,
               
                IdChung = data.Id,
                IsValid = data.IsActive == 100 ? false : true
            };
            context.PhanQuyenCaiDatDuyet_Logs.Add(addLog);
            await context.SaveChangesAsync();
        }
        public async Task UpdateMulti(PhanQuyenCaiDatDuyet[] PhanQuyenCaiDatDuyets)
        {
            using var context = _context.CreateDbContext();
            string[] ids = PhanQuyenCaiDatDuyets.Select(x => x.Id).ToArray();
            var listEntities = await context.PhanQuyenCaiDatDuyets.Where(x => ids.Contains(x.Id)).ToListAsync();
            foreach (var entity in listEntities)
            {
                context.PhanQuyenCaiDatDuyets.Update(entity);
            }
            await context.SaveChangesAsync();
        }
        public async Task DeleteById(string id, string userId)
        {
            using var context = _context.CreateDbContext();
            var entity = await GetById(id);
            if (entity == null)
            {
                throw new Exception($"Không tìm thấy phân quyền cài đặt đã chọn");
            }
            context.Set<PhanQuyenCaiDatDuyet>().Remove(entity);
            await context.SaveChangesAsync();
        }
        public async Task<bool> CheckStatus(string ids, string name)
        {
            using var context = _context.CreateDbContext();
            var model = await context.PhanQuyenCaiDatDuyets.Where(p => p.Id == ids && p.IsActive != 100).FirstOrDefaultAsync();
            if (model == null)
            {
                throw new Exception($"Không tìm thấy phân quyền cài đặt đã chọn");
            }
            if (model != null && model.IsActive == 0)
            {
                throw new Exception($"Phân quyền cài đặt đang chờ duyệt thêm mới.");
            }
            if (model != null && model.IsActive == 1)
            {
                throw new Exception($"Phân quyền cài đặt đang chờ duyệt sửa.");
            }
            if (model != null && model.IsActive == 2)
            {
                throw new Exception($"Phân quyền cài đặt đang chờ duyệt xóa.");
            }
            //if (model != null && model.TenPhanQuyenCaiDatDuyet.ToUpper() != name.ToUpper() && name != "")
            //{
            //throw new Exception($"Tên phân quyền cài đặt đã bị thay đổi.");
            //}
            return true;
        }
        public async Task<bool> CheckSave(PhanQuyenCaiDatDuyet input)
        {
            try
            {
                using var context = _context.CreateDbContext();
                var model = await (from p in context.PhanQuyenCaiDatDuyet_Logs
                                   where p.IdChung != input.Id && p.IsValid == true && p.IsActive != 100
                                   && p.CompanyId == input.CompanyId
                                   && p.ParentMajorId == input.ParentMajorId
                                   && p.MajorId == input.MajorId
                                   && p.UserId == input.UserId
                                   //&& p.SoPhanQuyenCaiDatDuyet == input.SoPhanQuyenCaiDatDuyet
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
        public async Task<bool> CheckEdit(PhanQuyenCaiDatDuyet input)
        {
            try
            {
                using var context = _context.CreateDbContext();
                var model = await (from p in context.PhanQuyenCaiDatDuyet_Logs
                                   where p.IdChung != input.Id && p.IsValid == true && p.IsActive != 100
                                   && p.CompanyId == input.CompanyId
                                   && p.ParentMajorId == input.ParentMajorId
                                   && p.MajorId == input.MajorId
                                   && p.UserId == input.UserId
                                   //&& p.SoPhanQuyenCaiDatDuyet == input.SoPhanQuyenCaiDatDuyet
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
        public async Task<bool> CheckDelete(PhanQuyenCaiDatDuyet input)
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
                    throw new Exception($"Không tìm thấy phân quyền cài đặt đã chọn");
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
