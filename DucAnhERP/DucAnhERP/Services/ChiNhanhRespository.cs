using DucAnhERP.Data;
using DucAnhERP.Models;
using DucAnhERP.ViewModel;
using Microsoft.EntityFrameworkCore;
using DucAnhERP.Repository;
using System.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Text.RegularExpressions;
namespace DucAnhERP.Services
{
    public class ChiNhanhRepository : IChiNhanhRepository
    {
        private readonly IDbContextFactory<ApplicationDbContext> _context;
        public ChiNhanhRepository(IDbContextFactory<ApplicationDbContext> context)
        {
            _context = context;
        }
        public async Task<List<ChiNhanhModel>> GetAllByVM(ChiNhanhModel dataModel, string groupId)
        {
            using var context = _context.CreateDbContext();
            var query = from p1 in context.ChiNhanhs
                        where p1.GroupId == groupId
                        select p1;
            if (!string.IsNullOrEmpty(dataModel.ParentId))
            {
                query = query.Where(m => m.ParentId == dataModel.ParentId);
            }
            if (!string.IsNullOrEmpty(dataModel.CompanyType))
            {
                query = query.Where(m => m.CompanyType == dataModel.CompanyType);
            }
            var data = await (from p1 in query
                              join p2 in context.ChiNhanhs on p1.ParentId equals p2.Id
                              join p3 in context.CompanyTypes on p1.CompanyType equals p3.Id
                              where p1.GroupId == groupId
                              orderby p1.CreateAt descending
                              select new ChiNhanhModel
                              {
                                  Id = p1.Id,
                                  ParentId = p2.TenChiNhanh,
                                  TenChiNhanh = p1.TenChiNhanh,
                                  CompanyType = p3.TenLoaiChiNhanh,
                                  Phone = p1.Phone,
                                  Email = p1.Email,
                                  Address = p1.Address,
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
                                  IsStatus = p1.IsStatus,
                              }).ToListAsync();
            return data;
        }
        public async Task<List<ChiNhanh>> GetAll(string groupId)
        {
            try
            {
                using var context = _context.CreateDbContext();
                var entity = await context.ChiNhanhs.Where(p => p.IsActive != 100 && p.GroupId == groupId).ToListAsync();
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
                var entity = await (from p1 in context.ChiNhanhs
                                    join p2 in context.ChiNhanhs on p1.ParentId equals p2.Id
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
        public async Task<List<CompanyTypeModel>> GetCompanyTypes(string groupId)
        {
            try
            {
                using var context = _context.CreateDbContext();
                var entity = await (from p1 in context.ChiNhanhs
                                    join p2 in context.CompanyTypes on p1.CompanyType equals p2.Id
                                    where p1.GroupId == groupId
                                    orderby p1.CreateAt descending
                                    select new CompanyTypeModel
                                    {
                                        Id = p2.Id,
                                        TenLoaiChiNhanh = p2.TenLoaiChiNhanh
                                    }).Distinct().ToListAsync();
                return entity;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"An error occurred: {ex.Message}");
                throw;
            }
        }
        public async Task<ChiNhanh> GetById(string id)
        {
            using var context = _context.CreateDbContext();
            var entity = await context.ChiNhanhs.Where(x => x.Id.Equals(id) && x.IsActive != 100).FirstOrDefaultAsync();
            if (entity == null)
            {
                throw new Exception($"Không tìm thấy chi nhánh đã chọn.");
            }
            return entity;
        }
        public ChiNhanhModel GetChiNhanhModelByInput(ChiNhanh list)
        {
            var listchinhanh = new List<ChiNhanh>
            {
                list
            };

            using var context = _context.CreateDbContext();
            var entity = (from p1 in listchinhanh
                          join p2 in context.ChiNhanhs on p1.ParentId equals p2.Id
                          join p3 in context.CompanyTypes on p1.CompanyType equals p3.Id
                          select new ChiNhanhModel
                          {
                              Id = p1.Id,
                              ParentId = p2.TenChiNhanh,
                              TenChiNhanh = p1.TenChiNhanh,
                              CompanyType = p3.TenLoaiChiNhanh,
                              Phone = p1.Phone,
                              Email = p1.Email,
                              Address = p1.Address,
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
                              IsStatus = p1.IsStatus,
                          }).FirstOrDefault();
            return entity;
        }
        public ChiNhanhModel GetChiNhanhLogModelById(string id)
        {
            using var context = _context.CreateDbContext();
            var entity = (from p1 in context.ChiNhanh_Logs
                          join p2 in context.ChiNhanhs on p1.ParentId equals p2.Id
                          join p3 in context.CompanyTypes on p1.CompanyType equals p3.Id
                          where p1.IdChung == id && p1.IsActive == 3
                          select new ChiNhanhModel
                          {
                              Id = p1.Id,
                              ParentId = p2.TenChiNhanh,
                              TenChiNhanh = p1.TenChiNhanh,
                              CompanyType = p3.TenLoaiChiNhanh,
                              Phone = p1.Phone,
                              Email = p1.Email,
                              Address = p1.Address,
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
                              IsStatus = p1.IsStatus,
                          }).OrderByDescending(p1 => p1.CreateAt).FirstOrDefault();
            return entity;
        }
        public async Task Insert(ChiNhanh entity, string userId)
        {
            try
            {
                using var context = _context.CreateDbContext();
                if (entity == null)
                {
                    throw new Exception("Không có chi nhánh nào được thêm!");
                }
                context.ChiNhanhs.Add(entity);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        public async Task Update(ChiNhanh data, string userId)
        {
            using var context = _context.CreateDbContext();
            var entity = GetById(data.Id);
            if (entity == null)
            {
                throw new Exception($"Không tìm thấy chi nhánh đã chọn");
            }
            context.ChiNhanhs.Update(data);
            await context.SaveChangesAsync();
        }
        public async Task UpdateMulti(ChiNhanh[] ChiNhanhs)
        {
            using var context = _context.CreateDbContext();
            string[] ids = ChiNhanhs.Select(x => x.Id).ToArray();
            var listEntities = await context.ChiNhanhs.Where(x => ids.Contains(x.Id)).ToListAsync();
            foreach (var entity in listEntities)
            {
                context.ChiNhanhs.Update(entity);
            }
            await context.SaveChangesAsync();
        }
        public async Task DeleteById(string id, string userId)
        {
            using var context = _context.CreateDbContext();
            var entity = await GetById(id);
            if (entity == null)
            {
                throw new Exception($"Không tìm thấy chi nhánh đã chọn");
            }
            context.Set<ChiNhanh>().Remove(entity);
            await context.SaveChangesAsync();
        }
        public async Task<bool> CheckStatus(string ids, string name)
        {
            using var context = _context.CreateDbContext();
            var model = await context.ChiNhanhs.Where(p => p.Id == ids).FirstOrDefaultAsync();
            if (model == null)
            {
                throw new Exception($"Không tìm thấy chi nhánh đã chọn");
            }
            if (model != null && model.IsActive == 0)
            {
                throw new Exception($"Chi nhánh đang chờ duyệt thêm mới.");
            }
            if (model != null && model.IsActive == 1)
            {
                throw new Exception($"Chi nhánh đang chờ duyệt sửa.");
            }
            if (model != null && model.IsActive == 2)
            {
                throw new Exception($"Chi nhánh đang chờ duyệt xóa.");
            }
            if (model != null && model.TenChiNhanh.ToUpper() != name.ToUpper() && name != "")
            {
                throw new Exception($"Tên chi nhánh đã bị thay đổi.");
            }
            return true;
        }
        public async Task<bool> CheckExclusive(string[] ids, DateTime baseTime)
        {
            foreach (var id in ids)
            {
                var model = await GetById(id);
                if (model == null)
                {
                    throw new Exception($"Không tìm thấy chi nhánh đã chọn");
                }
                if (model.CreateAt > baseTime)
                {
                    throw new Exception($"Thông tin đã bị thay đổi bởi người dùng khác. Vui lòng tải lại trang!");
                }
            }
            return true;
        }
        public async Task<List<ChiNhanh>> GetChiNhanhByPermission(string groupId, string majorId, string userId)
        {
            try
            {
                using var context = _context.CreateDbContext();
                var entity = await (from p in context.ChiNhanhs
                                    join q in context.MajorUserPermissions on p.GroupId equals q.GroupId
                                    where q.MajorId == majorId
                                    && q.UserId == userId
                                    select p).ToListAsync();
                return entity;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"An error occurred: {ex.Message}");
                throw;
            }
        }
    }
}
