using DucAnhERP.Data;
using DucAnhERP.Models;
using DucAnhERP.ViewModel;
using Microsoft.EntityFrameworkCore;
using DucAnhERP.Repository;
using System.Data;
namespace DucAnhERP.Services
{
    public class TinhRepository : ITinhRepository
    {
        private readonly IDbContextFactory<ApplicationDbContext> _context;
        public TinhRepository(IDbContextFactory<ApplicationDbContext> context)
        {
            _context = context;
        }
        public async Task<List<TinhModel>> GetAllByVM(TinhModel dataModel, string groupId)
        {
            using var context = _context.CreateDbContext();
            var query = from p1 in context.Tinhs
                        where p1.GroupId == groupId
                        select p1;
            var data = await (from p1 in query
                              where p1.GroupId == groupId
                              orderby p1.CreateAt descending
                              select new TinhModel
                              {
                                  Id = p1.Id,
                                  TenTinh = p1.TenTinh,
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
        public async Task<List<Tinh>> GetAll(string groupId)
        {
            try
            {
                using var context = _context.CreateDbContext();
                var entity = await context.Tinhs.Where(p => p.IsActive != 100 && p.GroupId == groupId).ToListAsync();
                return entity;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"An error occurred: {ex.Message}");
                throw;
            }
        }
        public async Task<Tinh> GetById(string id)
        {
            using var context = _context.CreateDbContext();
            var entity = await context.Tinhs.Where(x => x.Id.Equals(id) && x.IsActive != 100).FirstOrDefaultAsync();
            if (entity == null)
            {
                throw new Exception($"Không tìm thấy tỉnh đã chọn.");
            }
            return entity;
        }
        public async Task Insert(Tinh entity, string userId)
        {
            try
            {
                using var context = _context.CreateDbContext();
                if (entity == null)
                {
                    throw new Exception("Không có tỉnh nào được thêm!");
                }
                context.Tinhs.Add(entity);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        public async Task Update(Tinh data, string userId)
        {
            using var context = _context.CreateDbContext();
            var entity = GetById(data.Id);
            if (entity == null)
            {
                throw new Exception($"Không tìm thấy tỉnh đã chọn");
            }
            context.Tinhs.Update(data);
            await context.SaveChangesAsync();
        }
        public async Task UpdateMulti(Tinh[] Tinhs)
        {
            using var context = _context.CreateDbContext();
            string[] ids = Tinhs.Select(x => x.Id).ToArray();
            var listEntities = await context.Tinhs.Where(x => ids.Contains(x.Id)).ToListAsync();
            foreach (var entity in listEntities)
            {
                context.Tinhs.Update(entity);
            }
            await context.SaveChangesAsync();
        }
        public async Task DeleteById(string id, string userId)
        {
            using var context = _context.CreateDbContext();
            var entity = await GetById(id);
            if (entity == null)
            {
                throw new Exception($"Không tìm thấy tỉnh đã chọn");
            }
            context.Set<Tinh>().Remove(entity);
            await context.SaveChangesAsync();
        }
        public async Task<bool> CheckStatus(string ids, string name)
        {
            using var context = _context.CreateDbContext();
            var model = await context.Tinhs.Where(p => p.Id == ids).FirstOrDefaultAsync();
            if (model == null)
            {
                throw new Exception($"Không tìm thấy tỉnh đã chọn");
            }
            if (model != null && model.IsActive == 0)
            {
                throw new Exception($"Tỉnh đang chờ duyệt thêm mới.");
            }
            if (model != null && model.IsActive == 1)
            {
                throw new Exception($"Tỉnh đang chờ duyệt sửa.");
            }
            if (model != null && model.IsActive == 2)
            {
                throw new Exception($"Tỉnh đang chờ duyệt xóa.");
            }
            if (model != null && model.TenTinh.ToUpper() != name.ToUpper() && name != "")
            {
                throw new Exception($"Tên tỉnh đã bị thay đổi.");
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
                    throw new Exception($"Không tìm thấy tỉnh đã chọn");
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
