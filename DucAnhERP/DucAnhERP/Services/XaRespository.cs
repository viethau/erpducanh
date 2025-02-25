using DucAnhERP.Data;
using DucAnhERP.Models;
using DucAnhERP.ViewModel;
using Microsoft.EntityFrameworkCore;
using DucAnhERP.Repository;
using System.Data;
namespace DucAnhERP.Services
{
    public class XaRepository : IXaRepository
    {
        private readonly IDbContextFactory<ApplicationDbContext> _context;
        public XaRepository(IDbContextFactory<ApplicationDbContext> context)
        {
            _context = context;
        }
        public async Task<List<XaModel>> GetAllByVM(XaModel dataModel, string groupId)
        {
            using var context = _context.CreateDbContext();
            var query = from p1 in context.Xas
                        where p1.GroupId == groupId
                        select p1;
            if (!string.IsNullOrEmpty(dataModel.IdTinh))
            {
                query = query.Where(m => m.IdTinh == dataModel.IdTinh);
            }
            if (!string.IsNullOrEmpty(dataModel.IdHuyen))
            {
                query = query.Where(m => m.IdHuyen == dataModel.IdHuyen);
            }
            var data = await (from p1 in query
                              join Tinhs1 in context.Tinhs on p1.IdTinh equals Tinhs1.Id
                              join Huyens1 in context.Huyens on p1.IdHuyen equals Huyens1.Id
                              where p1.GroupId == groupId
                              orderby p1.CreateAt descending
                              select new XaModel
                              {
                                  Id = p1.Id,
                                  IdTinh = Tinhs1.TenTinh,
                                  IdHuyen = Huyens1.TenHuyen,
                                  TenXa = p1.TenXa,
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
        public async Task<List<Xa>> GetAll(string groupId)
        {
            try
            {
                using var context = _context.CreateDbContext();
                var entity = await context.Xas.Where(p => p.IsActive != 100 && p.GroupId == groupId).ToListAsync();
                return entity;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"An error occurred: {ex.Message}");
                throw;
            }
        }
        public async Task<List<TinhModel>> GetTinhs(string groupId)
        {
            try
            {
                using var context = _context.CreateDbContext();
                var entity = await (from p1 in context.Xas
                                    join p2 in context.Tinhs on p1.IdTinh equals p2.Id
                                    where p1.GroupId == groupId
                                    orderby p1.CreateAt descending
                                    select new TinhModel
                                    {
                                        Id = p2.Id,
                                        TenTinh = p2.TenTinh
                                    }).Distinct().ToListAsync();
                return entity;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"An error occurred: {ex.Message}");
                throw;
            }
        }
        public async Task<List<HuyenModel>> GetHuyens(string groupId)
        {
            try
            {
                using var context = _context.CreateDbContext();
                var entity = await (from p1 in context.Xas
                                    join p2 in context.Huyens on p1.IdHuyen equals p2.Id
                                    where p1.GroupId == groupId
                                    orderby p1.CreateAt descending
                                    select new HuyenModel
                                    {
                                        Id = p2.Id,
                                        TenHuyen = p2.TenHuyen
                                    }).Distinct().ToListAsync();
                return entity;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"An error occurred: {ex.Message}");
                throw;
            }
        }
        public async Task<Xa> GetById(string id)
        {
            using var context = _context.CreateDbContext();
            var entity = await context.Xas.Where(x => x.Id.Equals(id) && x.IsActive != 100).FirstOrDefaultAsync();
            if (entity == null)
            {
                throw new Exception($"Không tìm thấy xã đã chọn.");
            }
            return entity;
        }
        public async Task Insert(Xa entity, string userId)
        {
            try
            {
                using var context = _context.CreateDbContext();
                if (entity == null)
                {
                    throw new Exception("Không có xã nào được thêm!");
                }
                context.Xas.Add(entity);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        public async Task Update(Xa data, string userId)
        {
            using var context = _context.CreateDbContext();
            var entity = GetById(data.Id);
            if (entity == null)
            {
                throw new Exception($"Không tìm thấy xã đã chọn");
            }
            context.Xas.Update(data);
            await context.SaveChangesAsync();
        }
        public async Task UpdateMulti(Xa[] Xas)
        {
            using var context = _context.CreateDbContext();
            string[] ids = Xas.Select(x => x.Id).ToArray();
            var listEntities = await context.Xas.Where(x => ids.Contains(x.Id)).ToListAsync();
            foreach (var entity in listEntities)
            {
                context.Xas.Update(entity);
            }
            await context.SaveChangesAsync();
        }
        public async Task DeleteById(string id, string userId)
        {
            using var context = _context.CreateDbContext();
            var entity = await GetById(id);
            if (entity == null)
            {
                throw new Exception($"Không tìm thấy xã đã chọn");
            }
            context.Set<Xa>().Remove(entity);
            await context.SaveChangesAsync();
        }
        public async Task<bool> CheckStatus(string ids, string name)
        {
            using var context = _context.CreateDbContext();
            var model = await context.Xas.Where(p => p.Id == ids).FirstOrDefaultAsync();
            if (model == null)
            {
                throw new Exception($"Không tìm thấy xã đã chọn");
            }
            if (model != null && model.IsActive == 0)
            {
                throw new Exception($"Xã đang chờ duyệt thêm mới.");
            }
            if (model != null && model.IsActive == 1)
            {
                throw new Exception($"Xã đang chờ duyệt sửa.");
            }
            if (model != null && model.IsActive == 2)
            {
                throw new Exception($"Xã đang chờ duyệt xóa.");
            }
            if (model != null && model.TenXa.ToUpper() != name.ToUpper() && name != "")
            {
                throw new Exception($"Tên xã đã bị thay đổi.");
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
                    throw new Exception($"Không tìm thấy xã đã chọn");
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
