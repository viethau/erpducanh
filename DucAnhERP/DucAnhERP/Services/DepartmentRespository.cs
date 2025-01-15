using DucAnhERP.Data;
using DucAnhERP.Models;
using DucAnhERP.ViewModel;
using Microsoft.EntityFrameworkCore;
using DucAnhERP.Repository;
using System.Data;
namespace DucAnhERP.Services
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly IDbContextFactory<ApplicationDbContext> _context;
        public DepartmentRepository(IDbContextFactory<ApplicationDbContext> context)
        {
            _context = context;
        }
        public DepartmentModel GetToEdit(string id)
        {
            using var context = _context.CreateDbContext();
            var query = (from p1 in context.Departments
                         join ChiNhanhs1 in context.ChiNhanhs on p1.CompanyId equals ChiNhanhs1.Id
                         where p1.Id == id && p1.IsActive != 100
                         select new DepartmentModel
                         {
                             Id = p1.Id,
                             CompanyId = ChiNhanhs1.TenChiNhanh,
                             DeptName = p1.DeptName,
                             Phone = p1.Phone,
                             Email = p1.Email,
                             GroupId = p1.GroupId,
                             Ordinarily = p1.Ordinarily,
                             CreateAt = (DateTime)p1.CreateAt,
                             CreateBy = p1.CreateBy,
                             IsActive = p1.IsActive,
                             ApprovalUserId = p1.ApprovalUserId,
                             DateApproval = (DateTime)p1.DateApproval,
                             DepartmentId = p1.DepartmentId,
                             DepartmentOrder = p1.DepartmentOrder,
                             ApprovalOrder = p1.ApprovalOrder,
                             ApprovalId = p1.ApprovalId,
                             LastApprovalId = p1.LastApprovalId,
                             IsStatus = p1.IsStatus
                         }).FirstOrDefault();
            return query;
        }
        public async Task<List<DepartmentModel>> GetAllByVM(DepartmentModel dataModel, string groupId)
        {
            using var context = _context.CreateDbContext();
            var query = from p1 in context.Departments
                        where p1.GroupId == groupId && p1.IsActive != 100
                        select p1;
            if (!string.IsNullOrEmpty(dataModel.CompanyId))
            {
                query = query.Where(m => m.CompanyId == dataModel.CompanyId);
            }
            var data = await (from p1 in query
                              join ChiNhanhs1 in context.ChiNhanhs on p1.CompanyId equals ChiNhanhs1.Id
                              where p1.GroupId == groupId
                              orderby p1.CreateAt descending
                              select new DepartmentModel
                              {
                                  Id = p1.Id,
                                  CompanyId = ChiNhanhs1.TenChiNhanh,
                                  DeptName = p1.DeptName,
                                  Phone = p1.Phone,
                                  Email = p1.Email,
                                  GroupId = p1.GroupId,
                                  Ordinarily = p1.Ordinarily,
                                  CreateAt = (DateTime)p1.CreateAt,
                                  CreateBy = p1.CreateBy,
                                  IsActive = p1.IsActive,
                                  ApprovalUserId = p1.ApprovalUserId,
                                  DateApproval = (DateTime)p1.DateApproval,
                                  DepartmentId = p1.DepartmentId,
                                  DepartmentOrder = p1.DepartmentOrder,
                                  ApprovalOrder = p1.ApprovalOrder,
                                  ApprovalId = p1.ApprovalId,
                                  LastApprovalId = p1.LastApprovalId,
                                  IsStatus = p1.IsStatus
                              }).ToListAsync();
            return data;
        }
        public async Task<List<DepartmentModel>> GetHistoryIsValidEdit(string id)
        {
            using var context = _context.CreateDbContext();
            var data = await (from p1 in context.Department_Logs
                              join ChiNhanhs1 in context.ChiNhanhs on p1.CompanyId equals ChiNhanhs1.Id
                              where p1.IdChung == id && p1.IsValid == true
                              orderby p1.CreateAt
                              select new DepartmentModel
                              {
                                  Id = p1.Id,
                                  CompanyId = ChiNhanhs1.TenChiNhanh,
                                  DeptName = p1.DeptName,
                                  Phone = p1.Phone,
                                  Email = p1.Email,
                                  GroupId = p1.GroupId,
                                  Ordinarily = p1.Ordinarily,
                                  CreateAt = (DateTime)p1.CreateAt,
                                  CreateBy = p1.CreateBy,
                                  IsActive = p1.IsActive,
                                  ApprovalUserId = p1.ApprovalUserId,
                                  DateApproval = (DateTime)p1.DateApproval,
                                  DepartmentId = p1.DepartmentId,
                                  DepartmentOrder = p1.DepartmentOrder,
                                  ApprovalOrder = p1.ApprovalOrder,
                                  ApprovalId = p1.ApprovalId,
                                  LastApprovalId = p1.LastApprovalId,
                                  IsStatus = p1.IsStatus
                              }).ToListAsync();
            return data;
        }
        public async Task<DepartmentModel> GetDetails(string id)
        {
            using var context = _context.CreateDbContext();
            var data = await (from p1 in context.Departments
                              join ChiNhanhs1 in context.ChiNhanhs on p1.CompanyId equals ChiNhanhs1.Id
                              join createBy in context.ApplicationUsers on p1.CreateBy equals createBy.Id
                              join a in context.ApplicationUsers on p1.ApprovalUserId equals a.Id into a1
                              from approvalUserId in a1.DefaultIfEmpty()
                              join b in context.Departments on p1.DepartmentId equals b.Id into b1
                              from departmentId in b1.DefaultIfEmpty()
                              where p1.Id == id
                              select new DepartmentModel
                              {
                                  Id = p1.Id,
                                  CompanyId = ChiNhanhs1.TenChiNhanh,
                                  DeptName = p1.DeptName,
                                  Phone = p1.Phone,
                                  Email = p1.Email,
                                  GroupId = p1.GroupId,
                                  Ordinarily = p1.Ordinarily,
                                  CreateAt = (DateTime)p1.CreateAt,
                                  CreateBy = createBy.Email,
                                  IsActive = p1.IsActive,
                                  ApprovalUserId = approvalUserId.Email,
                                  DateApproval = (DateTime)p1.DateApproval,
                                  DepartmentId = departmentId.DeptName,
                                  DepartmentOrder = p1.DepartmentOrder,
                                  ApprovalOrder = p1.ApprovalOrder,
                                  ApprovalId = p1.ApprovalId,
                                  LastApprovalId = p1.LastApprovalId,
                                  IsStatus = p1.IsStatus
                              }).FirstOrDefaultAsync();
            return data;
        }
        public async Task<List<DepartmentModel>> GetHistory(string id)
        {
            using var context = _context.CreateDbContext();
            var data = await (from p1 in context.Department_Logs
                              join ChiNhanhs1 in context.ChiNhanhs on p1.CompanyId equals ChiNhanhs1.Id
                              join createBy in context.ApplicationUsers on p1.CreateBy equals createBy.Id
                              join a in context.ApplicationUsers on p1.ApprovalUserId equals a.Id into a1
                              from approvalUserId in a1.DefaultIfEmpty()
                              join b in context.Departments on p1.DepartmentId equals b.Id into b1
                              from departmentId in b1.DefaultIfEmpty()
                              where p1.IdChung == id
                              orderby p1.CreateAt
                              select new DepartmentModel
                              {
                                  Id = p1.Id,
                                  CompanyId = ChiNhanhs1.TenChiNhanh,
                                  DeptName = p1.DeptName,
                                  Phone = p1.Phone,
                                  Email = p1.Email,
                                  GroupId = p1.GroupId,
                                  Ordinarily = p1.Ordinarily,
                                  CreateAt = (DateTime)p1.CreateAt,
                                  CreateBy = createBy.Email,
                                  IsActive = p1.IsActive,
                                  ApprovalUserId = approvalUserId.Email,
                                  DateApproval = (DateTime)p1.DateApproval,
                                  DepartmentId = departmentId.DeptName,
                                  DepartmentOrder = p1.DepartmentOrder,
                                  ApprovalOrder = p1.ApprovalOrder,
                                  ApprovalId = p1.ApprovalId,
                                  LastApprovalId = p1.LastApprovalId,
                                  IsStatus = p1.IsStatus
                              }).ToListAsync();
            return data;
        }
        public async Task<List<Department>> GetAll(string groupId)
        {
            try
            {
                using var context = _context.CreateDbContext();
                var entity = await context.Departments.Where(p => p.IsActive != 100 && p.GroupId == groupId).ToListAsync();
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
                var entity = await (from p1 in context.Departments
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
        public async Task<Department> GetById(string id)
        {
            using var context = _context.CreateDbContext();
            var entity = await context.Departments.Where(x => x.Id.Equals(id) && x.IsActive != 100).FirstOrDefaultAsync();
            if (entity == null)
            {
                throw new Exception($"Không tìm thấy phòng ban đã chọn.");
            }
            return entity;
        }
        public async Task Insert(Department entity, string userId)
        {
            try
            {
                using var context = _context.CreateDbContext();
                if (entity == null)
                {
                    throw new Exception("Không có phòng ban nào được thêm!");
                }
                context.Departments.Add(entity);
                var addLog = new Department_Log()
                {
                    Id = entity.Id,
                    CompanyId = entity.CompanyId,
                    DeptName = entity.DeptName,
                    Phone = entity.Phone,
                    Email = entity.Email,
                    GroupId = entity.GroupId,
                    Ordinarily = entity.Ordinarily,
                    CreateAt = DateTime.Now,
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
                context.Department_Logs.Add(addLog);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        public async Task Update(Department data, string userId)
        {
            using var context = _context.CreateDbContext();
            var entity = await GetById(data.Id);
            if (entity == null)
            {
                throw new Exception($"Không tìm thấy phòng ban đã chọn");
            }
            context.Departments.Update(data);
            if (data.IsActive == 3)
            {
                var updateLog = await (from p in context.Department_Logs
                                       where p.IdChung == entity.Id && p.IsValid == true
                                       select p).ToListAsync();
                updateLog.ForEach(p => p.IsValid = false);
                context.Department_Logs.UpdateRange(updateLog);
            }
            else if (data.IsActive == 100)
            {
                var updateLog = await (from p in context.Department_Logs
                                       where p.IdChung == entity.Id && p.IsValid == true
                                       select p).ToListAsync();
                updateLog.ForEach(p => p.IsValid = false);
                context.Department_Logs.UpdateRange(updateLog);
            }
            else if (entity.IsActive != 3)
            {
                var updateLog = await (from p in context.Department_Logs
                                       where p.IdChung == entity.Id
                                       select p).OrderByDescending(p => p.CreateAt)
                .FirstOrDefaultAsync();
                if (updateLog != null)
                {
                    updateLog.IsValid = false;
                    context.Department_Logs.Update(updateLog);
                }
            }
            var addLog = new Department_Log()
            {
                Id = Guid.NewGuid().ToString(),
                CompanyId = entity.CompanyId,
                DeptName = entity.DeptName,
                Phone = entity.Phone,
                Email = entity.Email,
                GroupId = entity.GroupId,
                Ordinarily = entity.Ordinarily,
                CreateAt = DateTime.Now,
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
                IdChung = data.Id,
                IsValid = data.IsActive == 100 ? false : true
            };
            context.Department_Logs.Add(addLog);
            await context.SaveChangesAsync();
        }
        public async Task UpdateMulti(Department[] Departments)
        {
            using var context = _context.CreateDbContext();
            string[] ids = Departments.Select(x => x.Id).ToArray();
            var listEntities = await context.Departments.Where(x => ids.Contains(x.Id)).ToListAsync();
            foreach (var entity in listEntities)
            {
                context.Departments.Update(entity);
            }
            await context.SaveChangesAsync();
        }
        public async Task Delete(Department data, string userId)
        {
            using var context = _context.CreateDbContext();
            var entity = await GetById(data.Id);
            if (entity == null)
            {
                throw new Exception($"Không tìm thấy phòng ban đã chọn");
            }
            else
            {
                if (entity.IsActive == 0)
                {
                    data.IsActive = 100;
                    data.IsStatus = "Đã xóa";
                    data.ApprovalUserId = userId;
                }
                else if (entity.IsActive == 1)
                {
                    var logdata = (from p in context.Department_Logs
                                   where p.IdChung == entity.Id && p.IsValid == true
                                   orderby p.CreateAt ascending
                                   select p).Take(1).FirstOrDefault();
                    if (logdata != null)
                    {
                        data.CompanyId = logdata.CompanyId;
                        data.DeptName = logdata.DeptName;
                        data.Phone = logdata.Phone;
                        data.Email = logdata.Email;
                        data.Ordinarily = logdata.Ordinarily;
                        data.ApprovalUserId = "";
                        data.DateApproval = null;

                        logdata.IsValid = true;
                        context.Department_Logs.Update(logdata);

                        var logupdate = (from p in context.Department_Logs
                                         where p.IdChung == entity.Id && p.IsValid == true && p.CreateAt > logdata.CreateAt
                                         select p).ToList();
                        if (logupdate != null)
                        {
                            logupdate.ForEach(p => p.IsValid = false);
                            context.Department_Logs.UpdateRange(logupdate);
                        }
                    }

                    var addLog = new Department_Log()
                    {
                        Id = Guid.NewGuid().ToString(),
                        CompanyId = data.CompanyId,
                        DeptName = data.DeptName,
                        Phone = data.Phone,
                        Email = data.Email,
                        GroupId = data.GroupId,
                        Ordinarily = data.Ordinarily,
                        CreateAt = (DateTime)data.CreateAt,
                        CreateBy = data.CreateBy,
                        IsActive = data.IsActive,
                        ApprovalUserId = data.ApprovalUserId,
                        DateApproval = (DateTime)data.DateApproval,
                        DepartmentId = data.DepartmentId,
                        DepartmentOrder = data.DepartmentOrder,
                        ApprovalOrder = data.ApprovalOrder,
                        ApprovalId = data.ApprovalId,
                        LastApprovalId = data.LastApprovalId,
                        IsStatus = data.IsStatus,
                        IsValid = false,
                        IdChung = data.Id
                    };
                    addLog.Ordinarily = logdata.Ordinarily;
                    context.Department_Logs.Add(addLog);
                }
                else if (entity.IsActive == 2)
                {
                    throw new Exception($"Thông tin bạn xóa đang chờ duyệt xóa.");
                }
                else if (entity.IsActive == 3)
                {
                    var addLog = new Department_Log()
                    {
                        Id = Guid.NewGuid().ToString(),
                        CompanyId = data.CompanyId,
                        DeptName = data.DeptName,
                        Phone = data.Phone,
                        Email = data.Email,
                        GroupId = data.GroupId,
                        Ordinarily = data.Ordinarily,
                        CreateAt = DateTime.Now,
                        CreateBy = data.CreateBy,
                        IsActive = data.IsActive,
                        ApprovalUserId = data.ApprovalUserId,
                        DateApproval = (DateTime)data.DateApproval,
                        DepartmentId = data.DepartmentId,
                        DepartmentOrder = data.DepartmentOrder,
                        ApprovalOrder = data.ApprovalOrder,
                        ApprovalId = data.ApprovalId,
                        LastApprovalId = data.LastApprovalId,
                        IsStatus = data.IsStatus,
                        IdChung = data.Id,
                        IsValid = false
                    };
                    context.Department_Logs.Add(addLog);
                }
                else if (entity.IsActive == 90)
                {
                    data.IsActive = 100;
                    data.IsStatus = "Đã xóa không duyệt";
                }
            }
            context.Departments.Update(data);
            await context.SaveChangesAsync();
        }
        public async Task NoApproval(Department_Log data, string userId)
        {
            using var context = _context.CreateDbContext();
            var entity = await GetById(data.Id);
            if (entity == null)
            {
                throw new Exception($"Không tìm thấy phòng ban đã chọn");
            }
            else
            {
                if (entity.IsActive == 0)
                {
                    entity.IsActive = 90;
                    entity.IsStatus = "Không duyệt";
                    entity.ApprovalUserId = data.ApprovalUserId;
                }
                else if (entity.IsActive == 1)
                {
                    var logdata = (from p in context.Department_Logs
                                   where p.IdChung == entity.Id && p.IsValid == true
                                   orderby p.CreateAt ascending
                                   select p).Take(1).FirstOrDefault();
                    if (logdata != null)
                    {
                        entity.CompanyId = logdata.CompanyId;
                        entity.DeptName = logdata.DeptName;
                        entity.Phone = logdata.Phone;
                        entity.Email = logdata.Email;
                        entity.GroupId = logdata.GroupId;
                        entity.Ordinarily = logdata.Ordinarily;
                        entity.CreateAt = logdata.CreateAt;
                        entity.CreateBy = logdata.CreateBy;
                        entity.IsActive = logdata.IsActive;
                        entity.ApprovalUserId = logdata.ApprovalUserId;
                        entity.DateApproval = logdata.DateApproval;
                        entity.DepartmentId = logdata.DepartmentId;
                        entity.DepartmentOrder = logdata.DepartmentOrder;
                        entity.ApprovalOrder = logdata.ApprovalOrder;
                        entity.ApprovalId = logdata.ApprovalId;
                        entity.LastApprovalId = logdata.LastApprovalId;
                        entity.IsStatus = logdata.IsStatus;

                        var logupdate = (from p in context.Department_Logs
                                         where p.IdChung == entity.Id && p.IsValid == true && p.CreateAt > logdata.CreateAt
                                         select p).ToList();
                        if (logupdate != null)
                        {
                            logupdate.ForEach(p => p.IsValid = false);
                            context.Department_Logs.UpdateRange(logupdate);
                        }

                        var addLog = new Department_Log()
                        {
                            Id = Guid.NewGuid().ToString(),
                            CompanyId = entity.CompanyId,
                            DeptName = entity.DeptName,
                            Phone = entity.Phone,
                            Email = entity.Email,
                            GroupId = entity.GroupId,
                            Ordinarily = entity.Ordinarily,
                            CreateAt = DateTime.Now,
                            CreateBy = entity.CreateBy,
                            IsActive = entity.IsActive,
                            ApprovalUserId = entity.ApprovalUserId,
                            DateApproval = (DateTime)entity.DateApproval,
                            DepartmentId = entity.DepartmentId,
                            DepartmentOrder = entity.DepartmentOrder,
                            ApprovalOrder = entity.ApprovalOrder,
                            ApprovalId = entity.ApprovalId,
                            LastApprovalId = entity.LastApprovalId,
                            IsStatus = "Không duyệt sửa",
                            IdChung = entity.Id,
                            IsValid = false
                        };
                        context.Department_Logs.Add(addLog);
                    }

                    entity.IsActive = 3;
                    entity.IsStatus = "Đã duyệt";

                }
                else if (entity.IsActive == 2)
                {
                    var logdata = (from p in context.Department_Logs
                                   where p.IdChung == entity.Id && p.IsValid == true
                                   select p).Take(1).FirstOrDefault();
                    if (logdata != null)
                    {
                        entity.CompanyId = logdata.CompanyId;
                        entity.DeptName = logdata.DeptName;
                        entity.Phone = logdata.Phone;
                        entity.Email = logdata.Email;
                        entity.GroupId = logdata.GroupId;
                        entity.Ordinarily = logdata.Ordinarily;
                        entity.CreateAt = logdata.CreateAt;
                        entity.CreateBy = logdata.CreateBy;
                        entity.IsActive = logdata.IsActive;
                        entity.ApprovalUserId = logdata.ApprovalUserId;
                        entity.DateApproval = logdata.DateApproval;
                        entity.DepartmentId = logdata.DepartmentId;
                        entity.DepartmentOrder = logdata.DepartmentOrder;
                        entity.ApprovalOrder = logdata.ApprovalOrder;
                        entity.ApprovalId = logdata.ApprovalId;
                        entity.LastApprovalId = logdata.LastApprovalId;
                        entity.IsStatus = logdata.IsStatus;

                        var addLog = new Department_Log()
                        {
                            Id = Guid.NewGuid().ToString(),
                            CompanyId = entity.CompanyId,
                            DeptName = entity.DeptName,
                            Phone = entity.Phone,
                            Email = entity.Email,
                            GroupId = entity.GroupId,
                            Ordinarily = entity.Ordinarily,
                            CreateAt = DateTime.Now,
                            CreateBy = entity.CreateBy,
                            IsActive = entity.IsActive,
                            ApprovalUserId = entity.ApprovalUserId,
                            DateApproval = (DateTime)entity.DateApproval,
                            DepartmentId = entity.DepartmentId,
                            DepartmentOrder = entity.DepartmentOrder,
                            ApprovalOrder = entity.ApprovalOrder,
                            ApprovalId = entity.ApprovalId,
                            LastApprovalId = entity.LastApprovalId,
                            IsStatus = "Không duyệt sửa",
                            IdChung = entity.Id,
                            IsValid = false
                        };
                        context.Department_Logs.Add(addLog);
                    }
                    entity.IsActive = 3;
                    entity.IsStatus = "Đã duyệt";
                }
                else if (entity.IsActive == 3)
                {
                    throw new Exception($"Thông tin hủy duyệt không tồn tại.");
                }
            }
            context.Department_Logs.Add(data);
            context.Departments.Update(entity);
            await context.SaveChangesAsync();
        }
        public async Task DeleteById(string id, string userId)
        {
            using var context = _context.CreateDbContext();
            var entity = await GetById(id);
            if (entity == null)
            {
                throw new Exception($"Không tìm thấy phòng ban đã chọn");
            }
            context.Set<Department>().Remove(entity);
            await context.SaveChangesAsync();
        }
        public async Task<bool> CheckStatus(string ids, string name)
        {
            using var context = _context.CreateDbContext();
            var model = await context.Departments.Where(p => p.Id == ids && p.IsActive != 100).FirstOrDefaultAsync();
            if (model == null)
            {
                throw new Exception($"Không tìm thấy phòng ban đã chọn");
            }
            if (model != null && model.IsActive == 0)
            {
                throw new Exception($"Phòng ban đang chờ duyệt thêm mới.");
            }
            if (model != null && model.IsActive == 1)
            {
                throw new Exception($"Phòng ban đang chờ duyệt sửa.");
            }
            if (model != null && model.IsActive == 2)
            {
                throw new Exception($"Phòng ban đang chờ duyệt xóa.");
            }
            //if (model != null && model.TenDepartment.ToUpper() != name.ToUpper() && name != "")
            //{
            //throw new Exception($"Tên phòng ban đã bị thay đổi.");
            //}
            return true;
        }
        public async Task<bool> CheckSave(Department input)
        {
            try
            {
                using var context = _context.CreateDbContext();
                var model = await (from p in context.Department_Logs
                                   where p.IdChung != input.Id && p.IsValid == true && p.IsActive != 100
                                   && p.CompanyId == input.CompanyId
                                   //&& p.SoDepartment == input.SoDepartment
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
        public async Task<bool> CheckEdit(Department input)
        {
            try
            {
                using var context = _context.CreateDbContext();
                var model = await (from p in context.Department_Logs
                                   where p.IdChung != input.Id && p.IsValid == true && p.IsActive != 100
                                   && p.CompanyId == input.CompanyId
                                   //&& p.SoDepartment == input.SoDepartment
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
        public async Task<bool> CheckDelete(Department input)
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
                    throw new Exception($"Không tìm thấy phòng ban đã chọn");
                }
                if (model.CreateAt > baseTime)
                {
                    throw new Exception($"Thông tin đã bị thay đổi bởi người dùng khác. Vui lòng tải lại trang!");
                }
            }
            return true;
        }
        public async Task<List<Department>> GetByChiNhanhs(string companyId)
        {
            using var context = _context.CreateDbContext();
            var entity = await context.Departments.Where(x => x.CompanyId.Equals(companyId) && x.IsActive != 100).ToListAsync();
            if (entity == null)
            {
                throw new Exception($"Không tìm thấy phòng ban đã chọn.");
            }
            return entity;
        }
    }
}
