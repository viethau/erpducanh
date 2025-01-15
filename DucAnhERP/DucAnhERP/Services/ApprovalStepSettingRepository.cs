using DucAnhERP.Data;
using DucAnhERP.Models;
using DucAnhERP.ViewModel;
using Microsoft.EntityFrameworkCore;
using DucAnhERP.Repository;
using System.Data;
using Microsoft.Data.SqlClient;
namespace DucAnhERP.Services
{
    public class ApprovalStepSettingRepository : IApprovalStepSettingRepository
    {
        private readonly IDbContextFactory<ApplicationDbContext> _context;
        public ApprovalStepSettingRepository(IDbContextFactory<ApplicationDbContext> context)
        {
            _context = context;
        }
        public async Task<List<ChiNhanh>> CheckChoDuyet(string id)
        {
            try
            {
                using var context = _context.CreateDbContext();
                SqlParameter param1 = new SqlParameter("@id", id);
                string sql = "EXEC dbo.proc_ApprovalStepSettings_CheckDuyet @id";
                var entity = await context.ChiNhanhs.FromSqlRaw<ChiNhanh>(sql, param1).ToListAsync();
                return entity;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"An error occurred: {ex.Message}");
                throw;
            }
        }
        public async Task<List<ApprovalStepSettingModel>> GetAllByVM(ApprovalStepSettingModel dataModel, string groupId)
        {
            using var context = _context.CreateDbContext();
            var query = from p1 in context.ApprovalStepSettings
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
                              select new ApprovalStepSettingModel
                              {
                                  Id = p1.Id,
                                  CompanyId = ChiNhanhs1.TenChiNhanh,
                                  DeptId = Departments1.DeptName,
                                  DeptOrder = p1.DeptOrder,
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
        public async Task<List<ApprovalStepSetting>> GetAll(string groupId)
        {
            try
            {
                using var context = _context.CreateDbContext();
                var entity = await context.ApprovalStepSettings.Where(p => p.IsActive != 100 && p.GroupId == groupId).ToListAsync();
                return entity;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"An error occurred: {ex.Message}");
                throw;
            }
        }
        public async Task<List<ApprovalStepSetting>> GetByMainId(string MainId)
        {
            try
            {
                using var context = _context.CreateDbContext();
                var entity = await context.ApprovalStepSettings.Where(p => p.IsActive != 100 && p.IdMain == MainId).OrderBy(p => p.ApprovalStep).ToListAsync();
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
                var entity = await (from p1 in context.ApprovalStepSettings
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
                var entity = await (from p1 in context.ApprovalStepSettings
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
                var entity = await (from p1 in context.ApprovalStepSettings
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

        public async Task<List<Major>> LoadParentMajors(string companyId)
        {
            try
            {
                using var context = _context.CreateDbContext();
                var entity = await (from p1 in context.ApprovalDeptSettings
                                    join p2 in context.Majors on p1.ParentMajorId equals p2.Id
                                    where p1.CompanyId == companyId && p1.IsActive != 100
                                    orderby p2.Order descending
                                    select new Major
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
        public async Task<List<Major>> LoadMajors(string companyId, string parentMajorId)
        {
            try
            {
                using var context = _context.CreateDbContext();
                var entity = await (from p1 in context.ApprovalDeptSettings
                                    join p2 in context.Majors on p1.MajorId equals p2.Id
                                    where p1.ParentMajorId == parentMajorId && p1.CompanyId == companyId && p1.IsActive != 100
                                    orderby p2.Order descending
                                    select new Major
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
        public async Task<List<Department>> LoadDepartments(string companyId, string parentMajorId, string majorId)
        {
            try
            {
                using var context = _context.CreateDbContext();
                var entity = await (from p1 in context.ApprovalDeptSettings
                                    join p2 in context.Departments on p1.DeptId equals p2.Id
                                    where p1.MajorId == majorId && p1.ParentMajorId == parentMajorId && p1.CompanyId == companyId && p1.IsActive != 100
                                    orderby p2.Ordinarily descending
                                    select new Department
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
        public async Task<List<MajorModel>> GetMajorsByParentId(string parentId)
        {
            try
            {
                using var context = _context.CreateDbContext();
                var entity = await (from p1 in context.ApprovalStepSettings
                                    join p2 in context.Majors on p1.MajorId equals p2.Id
                                    where p1.ParentMajorId == parentId && p1.IsActive != 100
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
        public async Task<ApprovalStepSetting> GetById(string id)
        {
            using var context = _context.CreateDbContext();
            var entity = await context.ApprovalStepSettings.Where(x => x.Id.Equals(id) && x.IsActive != 100).FirstOrDefaultAsync();
            if (entity == null)
            {
                throw new Exception($"Không tìm thấy cài đặt duyệt phòng ban đã chọn.");
            }
            return entity;
        }
        public ApprovalDeptSetting GetIdApprodeptSetting(string companyId, string majorId, string deptId)
        {
            using var context = _context.CreateDbContext();
            var entity = (from p in context.ApprovalDeptSettings
                          where p.CompanyId.Equals(companyId)
                          && p.MajorId.Equals(majorId)
                          && p.DeptId.Equals(deptId)
                          && p.IsActive != 100
                          select p).FirstOrDefault();
            return entity;
        }
        public async Task Insert(ApprovalStepSetting entity, string userId)
        {
            try
            {
                using var context = _context.CreateDbContext();
                if (entity == null)
                {
                    throw new Exception("Không có cài đặt duyệt phòng ban nào được thêm!");
                }
                context.ApprovalStepSettings.Add(entity);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        public async Task Update(ApprovalStepSetting data, string userId)
        {
            using var context = _context.CreateDbContext();
            var entity = GetById(data.Id);
            if (entity == null)
            {
                throw new Exception($"Không tìm thấy cài đặt duyệt phòng ban đã chọn");
            }
            context.ApprovalStepSettings.Update(data);
            await context.SaveChangesAsync();
        }
        public async Task UpdateMulti(ApprovalStepSetting[] ApprovalStepSettings)
        {
            using var context = _context.CreateDbContext();
            string[] ids = ApprovalStepSettings.Select(x => x.Id).ToArray();
            var listEntities = await context.ApprovalStepSettings.Where(x => ids.Contains(x.Id)).ToListAsync();
            foreach (var entity in listEntities)
            {
                context.ApprovalStepSettings.Update(entity);
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
            context.Set<ApprovalStepSetting>().Remove(entity);
            await context.SaveChangesAsync();
        }
        public async Task<bool> CheckStatus(string ids, string name)
        {
            using var context = _context.CreateDbContext();
            var model = await context.ApprovalStepSettings.Where(p => p.Id == ids).FirstOrDefaultAsync();
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
        public async Task<bool> CheckSave(string companyId, string majorId, string deptId, string permissionId, string mainId, bool loai)
        {
            using var context = _context.CreateDbContext();
            if (loai)
            {
                var query = await (from p in context.ApprovalStepSettings
                                   where p.CompanyId.Equals(companyId)
                                   && p.MajorId.Equals(majorId)
                                   && p.DeptId.Equals(deptId)
                                   && p.PermissionId.Equals(permissionId)
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
                var query = await (from p in context.ApprovalStepSettings
                                   where p.CompanyId.Equals(companyId)
                                   && p.MajorId.Equals(majorId)
                                   && p.DeptId.Equals(deptId)
                                   && p.PermissionId.Equals(permissionId)
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
            var query = await (from p in context.ApprovalStepSettings
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
        //    var model = await context.ApprovalStepSettings.Where(p => p.Id == ids).FirstOrDefaultAsync();
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
        public async Task<bool> CreateApprovalStepSetting(List<ApprovalStepWrapper> approvalRowWrappers, DateTime baseTime)
        {
            if (approvalRowWrappers.Count == 0)
            {
                return false;
            }
            using var context = _context.CreateDbContext();
            var mainId = approvalRowWrappers.First().ApprovalRow.IdMain;

            // Xóa cài đặt cũ
            var listToDelete = await GetByMainId(mainId);
            listToDelete.ForEach(item => item.IsActive = 100);
            context.ApprovalStepSettings.UpdateRange(listToDelete);
            await context.SaveChangesAsync();

            // Đăng ký cài đặt mới
            var listInsert = new List<ApprovalStaffSetting>();
            foreach (var row in approvalRowWrappers)
            {
                await Insert(row.ApprovalRow);
            }

            return true;
        }
        public async Task<List<ApprovalStepSettingModel>> GetSetApprovalStep(string companyId, string parentId, string majorId)
        {
            using var context = _context.CreateDbContext();
            var query = from settings in context.ApprovalStepSettings
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
                        select new ApprovalStepSettingModel
                        {
                            Id = settings.Id,
                            CompanyId = settings.CompanyId,
                            DeptId = settings.DeptId,
                            DeptOrder = settings.DeptOrder,
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
        public async Task Insert(ApprovalStepSetting entity)
        {
            using var context = _context.CreateDbContext();
            if (entity == null)
            {
                throw new Exception("Không có bản ghi nào để thêm!");
            }

            context.ApprovalStepSettings.Add(entity);
            await context.SaveChangesAsync();
        }
        public async Task<List<ApprovalStepSettingData>> GetData(string groupId)
        {
            using var context = _context.CreateDbContext();
            var query = from p1 in context.ApprovalStepSettings
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
                              join MPermissions1 in context.Permissions on p1.PermissionId equals MPermissions1.Id
                              where p1.GroupId == groupId
                              select new ApprovalStepSettingModel
                              {
                                  Id = p1.Id,
                                  IdMain = p1.IdMain,
                                  CompanyId = ChiNhanhs1.TenChiNhanh,
                                  DeptId = Departments1.DeptName,
                                  DeptOrder = p1.DeptOrder,
                                  ParentMajorId = MMajors1.MajorName,
                                  MajorId = MMajors2.MajorName,
                                  PermissionId = MPermissions1.PermissionName,
                                  Content = p1.ApprovalStep + ". " + p1.Content,
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

            var result = data.GroupBy(p => new { p.IdMain, p.CompanyId, p.ParentMajorId, p.MajorId, p.DeptId, p.DeptOrder, p.PermissionId }).Select(g => new
            {
                g.Key.IdMain,
                g.Key.CompanyId,
                g.Key.ParentMajorId,
                g.Key.MajorId,
                g.Key.DeptId,
                g.Key.DeptOrder,
                g.Key.PermissionId,
                Content = string.Join(" => ", g.Select(i => i.Content))
            });

            var vlus = new List<ApprovalStepSettingData>();
            foreach (var item in result)
            {
                var additem = new ApprovalStepSettingData()
                {
                    IdMain = item.IdMain,
                    CompanyId = item.CompanyId,
                    ParentMajorId = item.ParentMajorId,
                    DeptOrder = item.DeptOrder,
                    MajorId = item.MajorId,
                    DeptId = item.DeptId,
                    PermissionId = item.PermissionId,
                    Content = item.Content
                };
                vlus.Add(additem);
            }
            return vlus;
        }
        public async Task<bool> DeleteApprovalStepSetting(string mainId)
        {
            try
            {
                using var context = _context.CreateDbContext();
                var listToDelete = await GetByMainId(mainId);
                listToDelete.ForEach(item => item.IsActive = 100);
                context.ApprovalStepSettings.UpdateRange(listToDelete);
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
