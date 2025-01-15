using DucAnhERP.Data;
using DucAnhERP.Models;
using DucAnhERP.ViewModel;
using Microsoft.EntityFrameworkCore;
using DucAnhERP.Repository;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace DucAnhERP.Services
{
    public class ApprovalDeptSettingRepository : IApprovalDeptSettingRepository
    {
        private readonly IDbContextFactory<ApplicationDbContext> _context;
        public ApprovalDeptSettingRepository(IDbContextFactory<ApplicationDbContext> context)
        {
            _context = context;
        }
        public async Task<List<ChiNhanh>> CheckChoDuyet(string id)
        {
            try
            {
                using var context = _context.CreateDbContext();
                SqlParameter param1 = new SqlParameter("@id", id);
                string sql = "EXEC dbo.proc_ApprovalDeptSettings_CheckDuyet @id";
                var entity = await context.ChiNhanhs.FromSqlRaw<ChiNhanh>(sql, param1).ToListAsync();
                return entity;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"An error occurred: {ex.Message}");
                throw;
            }
        }
        public async Task<List<ApprovalDeptSettingModel>> GetAllByVM(ApprovalDeptSettingModel dataModel, string groupId)
        {
            using var context = _context.CreateDbContext();
            var query = from p1 in context.ApprovalDeptSettings
                        where p1.GroupId == groupId
                        select p1;
            if (!string.IsNullOrEmpty(dataModel.CompanyId))
            {
                query = query.Where(m => m.CompanyId == dataModel.CompanyId);
            }
            if (!string.IsNullOrEmpty(dataModel.DeptId))
            {
                query = query.Where(m => m.DeptId == dataModel.DeptId);
            }
            if (!string.IsNullOrEmpty(dataModel.ParentMajorId))
            {
                query = query.Where(m => m.ParentMajorId == dataModel.ParentMajorId);
            }
            if (!string.IsNullOrEmpty(dataModel.MajorId))
            {
                query = query.Where(m => m.MajorId == dataModel.MajorId);
            }
            var data = await (from p1 in query
                              join ChiNhanhs1 in context.ChiNhanhs on p1.CompanyId equals ChiNhanhs1.Id
                              join Departments1 in context.Departments on p1.DeptId equals Departments1.Id
                              join MMajors1 in context.Majors on p1.ParentMajorId equals MMajors1.Id
                              join MMajors2 in context.Majors on p1.MajorId equals MMajors2.Id
                              where p1.GroupId == groupId
                              orderby p1.CreateAt descending
                              select new ApprovalDeptSettingModel
                              {
                                  Id = p1.Id,
                                  CompanyId = ChiNhanhs1.TenChiNhanh,
                                  DeptId = Departments1.DeptName,
                                  ParentMajorId = MMajors1.MajorName,
                                  MajorId = MMajors2.MajorName,
                                  ApprovalStep = p1.ApprovalStep,
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
        public async Task<List<ApprovalDeptSetting>> GetAll(string groupId)
        {
            try
            {
                using var context = _context.CreateDbContext();
                var entity = await context.ApprovalDeptSettings.Where(p => p.IsActive != 100 && p.GroupId == groupId).ToListAsync();
                return entity;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"An error occurred: {ex.Message}");
                throw;
            }
        }
        public async Task<List<ApprovalDeptSetting>> GetByMainId(string MainId)
        {
            try
            {
                using var context = _context.CreateDbContext();
                var entity = await context.ApprovalDeptSettings.Where(p => p.IsActive != 100 && p.IdMain == MainId).OrderBy(p => p.ApprovalStep).ToListAsync();
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
                var entity = await (from p1 in context.ApprovalDeptSettings
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
        public async Task<List<DepartmentModel>> GetDepartments(string groupId)
        {
            try
            {
                using var context = _context.CreateDbContext();
                var entity = await (from p1 in context.ApprovalDeptSettings
                                    join p2 in context.Departments on p1.DeptId equals p2.Id
                                    where p1.GroupId == groupId
                                    orderby p1.CreateAt descending
                                    select new DepartmentModel
                                    {
                                        Id = p2.Id,
                                        DeptName = p2.DeptName
                                    }).Distinct().ToListAsync();
                return entity;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"An error occurred: {ex.Message}");
                throw;
            }
        }
        public async Task<List<MajorModel>> GetMajors(string groupId)
        {
            try
            {
                using var context = _context.CreateDbContext();
                var entity = await (from p1 in context.ApprovalDeptSettings
                                    join p2 in context.Majors on p1.ParentMajorId equals p2.Id
                                    where p1.GroupId == groupId
                                    orderby p1.CreateAt descending
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
        public async Task<List<MajorModel>> GetMajorsByParentId(string parentId)
        {
            try
            {
                using var context = _context.CreateDbContext();
                var entity = await (from p1 in context.ApprovalDeptSettings
                                    join p2 in context.Majors on p1.MajorId equals p2.Id
                                    where p1.ParentMajorId == parentId
                                    orderby p1.CreateAt descending
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

        public async Task<ApprovalDeptSetting> GetById(string id)
        {
            using var context = _context.CreateDbContext();
            var entity = await context.ApprovalDeptSettings.Where(x => x.Id.Equals(id) && x.IsActive != 100).FirstOrDefaultAsync();
            if (entity == null)
            {
                throw new Exception($"Không tìm thấy cài đặt duyệt phòng ban đã chọn.");
            }
            return entity;
        }
        public async Task Insert(ApprovalDeptSetting entity, string userId)
        {
            try
            {
                using var context = _context.CreateDbContext();
                if (entity == null)
                {
                    throw new Exception("Không có cài đặt duyệt phòng ban nào được thêm!");
                }
                context.ApprovalDeptSettings.Add(entity);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        public async Task Update(ApprovalDeptSetting data, string userId)
        {
            using var context = _context.CreateDbContext();
            var entity = GetById(data.Id);
            if (entity == null)
            {
                throw new Exception($"Không tìm thấy cài đặt duyệt phòng ban đã chọn");
            }
            context.ApprovalDeptSettings.Update(data);
            await context.SaveChangesAsync();
        }
        public async Task UpdateMulti(ApprovalDeptSetting[] ApprovalDeptSettings)
        {
            using var context = _context.CreateDbContext();
            string[] ids = ApprovalDeptSettings.Select(x => x.Id).ToArray();
            var listEntities = await context.ApprovalDeptSettings.Where(x => ids.Contains(x.Id)).ToListAsync();
            foreach (var entity in listEntities)
            {
                context.ApprovalDeptSettings.Update(entity);
            }
            await context.SaveChangesAsync();
        }
        public async Task DeleteById(string id, string userId)
        {
            using var context = _context.CreateDbContext();
            var entity = await GetById(id);
            if (entity == null)
            {
                throw new Exception($"Không tìm thấy cài đặt duyệt phòng ban đã chọn");
            }
            context.Set<ApprovalDeptSetting>().Remove(entity);
            await context.SaveChangesAsync();
        }
        public async Task<bool> CheckStatus(string ids, string name)
        {
            using var context = _context.CreateDbContext();
            var model = await context.ApprovalDeptSettings.Where(p => p.Id == ids).FirstOrDefaultAsync();
            if (model == null)
            {
                throw new Exception($"Không tìm thấy cài đặt duyệt phòng ban đã chọn");
            }
            if (model != null && model.IsActive == 0)
            {
                throw new Exception($"Cài đặt duyệt phòng ban đang chờ duyệt thêm mới.");
            }
            if (model != null && model.IsActive == 1)
            {
                throw new Exception($"Cài đặt duyệt phòng ban đang chờ duyệt sửa.");
            }
            if (model != null && model.IsActive == 2)
            {
                throw new Exception($"Cài đặt duyệt phòng ban đang chờ duyệt xóa.");
            }
            return true;
        }
        public async Task<bool> CheckSave(string companyId, string majorId, string mainId, bool loai)
        {
            using var context = _context.CreateDbContext();
            if (loai)
            {
                var query = await (from p in context.ApprovalDeptSettings
                                   where p.CompanyId.Equals(companyId)
                                   && p.MajorId.Equals(majorId)
                                   && p.IdMain != mainId
                                   && p.IsActive != 100
                                   select p).CountAsync();
                if (query > 0)
                {
                    throw new Exception($"Nghiệp vụ này đã được cài đặt duyệt phòng ban theo chi nhánh đã chọn.");
                }
            }
            else
            {
                var query = await (from p in context.ApprovalDeptSettings
                                   where p.CompanyId.Equals(companyId)
                                   && p.MajorId.Equals(majorId)
                                   && p.IsActive != 100
                                   select p).CountAsync();
                if (query > 0)
                {
                    throw new Exception($"Nghiệp vụ này đã được cài đặt duyệt phòng ban theo chi nhánh đã chọn.");
                }
            }
            return true;
        }
        public async Task<bool> CheckDelete(string companyId, string majorId)
        {
            using var context = _context.CreateDbContext();
            var query = await (from p in context.ApprovalDeptSettings
                               where p.CompanyId.Equals(companyId)
                               && p.MajorId.Equals(majorId)
                               && p.IsActive != 100
                               select p).CountAsync();
            if (query > 0)
            {
                throw new Exception($"Nghiệp vụ này đã được cài đặt duyệt phòng ban theo chi nhánh đã chọn.");
            }
            return true;
        }
        //public async Task<bool> CheckDelete(string ids, string name)
        //{
        //    using var context = _context.CreateDbContext();
        //    var model = await context.ApprovalDeptSettings.Where(p => p.Id == ids).FirstOrDefaultAsync();
        //    if (model == null)
        //    {
        //        throw new Exception($"Không tìm thấy cài đặt duyệt phòng ban đã chọn");
        //    }
        //    if (model != null && model.IsActive == 0)
        //    {
        //        throw new Exception($"Cài đặt duyệt phòng ban đang chờ duyệt thêm mới.");
        //    }
        //    if (model != null && model.IsActive == 1)
        //    {
        //        throw new Exception($"Cài đặt duyệt phòng ban đang chờ duyệt sửa.");
        //    }
        //    if (model != null && model.IsActive == 2)
        //    {
        //        throw new Exception($"Cài đặt duyệt phòng ban đang chờ duyệt xóa.");
        //    }
        //    return true;
        //}

        public async Task<bool> CheckExclusive(string[] ids, DateTime baseTime)
        {
            foreach (var id in ids)
            {
                var model = await GetById(id);
                if (model == null)
                {
                    throw new Exception($"Không tìm thấy cài đặt duyệt phòng ban đã chọn");
                }
                if (model.CreateAt > baseTime)
                {
                    throw new Exception($"Thông tin đã bị thay đổi bởi người dùng khác. Vui lòng tải lại trang!");
                }
            }
            return true;
        }
        public async Task<bool> CreateApprovalDeptSetting(List<ApprovalDeptWrapper> approvalRowWrappers, DateTime baseTime)
        {
            if (approvalRowWrappers.Count == 0)
            {
                return false;
            }
            using var context = _context.CreateDbContext();
            var companyId = approvalRowWrappers.First().ApprovalRow.CompanyId;
            var parentId = approvalRowWrappers.First().ApprovalRow.ParentMajorId;
            var majorId = approvalRowWrappers.First().ApprovalRow.MajorId;
            var mainId = approvalRowWrappers.First().ApprovalRow.IdMain;

            // Xóa cài đặt cũ
            var listToDelete = await GetByMainId(mainId);
            listToDelete.ForEach(item => item.IsActive = 100);
            context.ApprovalDeptSettings.UpdateRange(listToDelete);
            await context.SaveChangesAsync();
            //var listId = listToDelete.Select(x => x.Id).ToArray();
            //await CheckExclusive(listToDelete.ToArray(), baseTime);

            //await DeleteById(item.Id, "");

            // Đăng ký cài đặt mới
            foreach (var row in approvalRowWrappers)
            {
                await Insert(row.ApprovalRow);
            }

            return true;
        }
        public async Task<List<ApprovalDeptSettingModel>> GetSetApprovalDept(string companyId, string parentId, string majorId)
        {
            using var context = _context.CreateDbContext();
            var query = from settings in context.ApprovalDeptSettings
                        join company in context.ChiNhanhs on settings.CompanyId equals company.Id into companyGroup
                        from company in companyGroup.DefaultIfEmpty()
                        where company.IsActive == 1
                        join major in context.Majors on settings.MajorId equals major.Id into majorGroup
                        from major in majorGroup.DefaultIfEmpty()
                        where major.IsActive == 1
                        join parent in context.Majors on settings.ParentMajorId equals parent.Id into parentGroup
                        from parent in parentGroup.DefaultIfEmpty()
                        where parent.IsActive == 1
                        join dept in context.Departments on settings.DeptId equals dept.Id into deptGroup
                        from dept in deptGroup.DefaultIfEmpty()
                        where dept.IsActive == 1 && settings.IsActive == 1
                        select new ApprovalDeptSettingModel
                        {
                            Id = settings.Id,
                            CompanyId = settings.CompanyId,
                            DeptId = settings.DeptId,
                            MajorId = settings.MajorId,
                            ParentMajorId = settings.ParentMajorId,
                            ApprovalStep = settings.ApprovalStep,
                            CreateAt = settings.CreateAt,
                            CreateBy = settings.CreateBy,
                            CompanyName = company.TenChiNhanh,
                            MajorName = major.MajorName,
                            ParentName = parent.MajorName,
                            DeptName = dept.DeptName
                        };
            if (companyId != "")
            {
                query = query.Where(p => p.CompanyId.Equals(companyId));
            }

            if (parentId != "")
            {
                query = query.Where(p => p.ParentMajorId.Equals(parentId));
            }

            if (majorId != "")
            {
                query = query.Where(p => p.MajorId.Equals(majorId));
            }

            var listSetting = await query.OrderBy(x => x.ApprovalStep).ToListAsync();
            return listSetting;
        }
        public async Task Insert(ApprovalDeptSetting entity)
        {
            using var context = _context.CreateDbContext();
            if (entity == null)
            {
                throw new Exception("Không có bản ghi nào để thêm!");
            }

            context.ApprovalDeptSettings.Add(entity);
            await context.SaveChangesAsync();
        }
        public async Task<List<ApprovalDeptSettingData>> GetData(string groupId)
        {
            using var context = _context.CreateDbContext();
            var query = from p1 in context.ApprovalDeptSettings
                        where p1.GroupId == groupId && p1.IsActive != 100
                        orderby p1.ApprovalStep
                        select p1;
            //if (!string.IsNullOrEmpty(dataModel.CompanyId))
            //{
            //    query = query.Where(m => m.CompanyId == dataModel.CompanyId);
            //}
            //if (!string.IsNullOrEmpty(dataModel.DeptId))
            //{
            //    query = query.Where(m => m.DeptId == dataModel.DeptId);
            //}
            //if (!string.IsNullOrEmpty(dataModel.ParentMajorId))
            //{
            //    query = query.Where(m => m.ParentMajorId == dataModel.ParentMajorId);
            //}
            //if (!string.IsNullOrEmpty(dataModel.MajorId))
            //{
            //    query = query.Where(m => m.MajorId == dataModel.MajorId);
            //}
            var data = await (from p1 in query
                              join ChiNhanhs1 in context.ChiNhanhs on p1.CompanyId equals ChiNhanhs1.Id
                              join Departments1 in context.Departments on p1.DeptId equals Departments1.Id
                              join MMajors1 in context.Majors on p1.ParentMajorId equals MMajors1.Id
                              join MMajors2 in context.Majors on p1.MajorId equals MMajors2.Id
                              where p1.GroupId == groupId
                              select new ApprovalDeptSettingModel
                              {
                                  Id = p1.Id,
                                  IdMain = p1.IdMain,
                                  CompanyId = ChiNhanhs1.TenChiNhanh,
                                  DeptId = p1.ApprovalStep + ". " + Departments1.DeptName,
                                  ParentMajorId = MMajors1.MajorName,
                                  MajorId = MMajors2.MajorName,
                                  ApprovalStep = p1.ApprovalStep,
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
                              }).OrderBy(p => p.IdMain).OrderBy(p => p.ApprovalStep).ToListAsync();

            var result = data.GroupBy(p => new { p.IdMain, p.CompanyId, p.ParentMajorId, p.MajorId }).Select(g => new
            {
                g.Key.IdMain,
                g.Key.CompanyId,
                g.Key.ParentMajorId,
                g.Key.MajorId,
                DeptId = string.Join(" => ", g.Select(i => i.DeptId))
            });

            var vlus = new List<ApprovalDeptSettingData>();
            foreach (var item in result)
            {
                var additem = new ApprovalDeptSettingData()
                {
                    IdMain = item.IdMain,
                    CompanyId = item.CompanyId,
                    DeptId = item.DeptId,
                    ParentMajorId = item.ParentMajorId,
                    MajorId = item.MajorId
                };
                vlus.Add(additem);
            }
            return vlus;
        }
        public async Task<bool> DeleteApprovalDeptSetting(string mainId)
        {
            try
            {
                using var context = _context.CreateDbContext();
                var listToDelete = await GetByMainId(mainId);
                listToDelete.ForEach(item => item.IsActive = 100);
                context.ApprovalDeptSettings.UpdateRange(listToDelete);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"An error occurred: {ex.Message}");
                throw;
            }
        }
    }
}
