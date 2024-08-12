using DucAnhERP.Repository;
using DucAnhERP.ViewModel;
using DucAnhERP.Data;
using DucAnhERP.Models;
using Microsoft.EntityFrameworkCore;

namespace DucAnhERP.Services
{
    public class PermissionRepository : IPermissionRepository
    {
        private readonly IDbContextFactory<ApplicationDbContext> _context;

        public PermissionRepository(IDbContextFactory<ApplicationDbContext> context)
        {
            _context = context;
        }

        public async Task<bool> CheckExclusive(string[] ids, DateTime baseTime)
        {
            foreach (var id in ids)
            {
                var model = await GetById(id);
                if (model == null)
                {
                    throw new Exception($"Không tìm thấy bản ghi theo ID: {id}");
                }

                if (model.CreateAt > baseTime)
                {
                    throw new Exception($"ID: {id} đã bị thay đổi bởi người dùng khác. Vui lòng tải lại trang!");
                }

            }
            return true;
        }

        public async Task DeleteById(string id)
        {
            using var context = _context.CreateDbContext();
            var entity = await GetById(id);

            if (entity == null)
            {
                throw new Exception($"Không tìm thấy bản ghi theo ID: {id}");
            }
            entity.IsActive = 0;
            context.MPermissions.Update(entity);
            await context.SaveChangesAsync();
        }

        public Task<List<MPermission>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<List<PermissionModel>> GetAllCorePermission(string screenId, string companyId)
        {
            using var context = _context.CreateDbContext();
            var query = from permission in context.MPermissions
                        join major in context.MMajors.Where(m => m.IsActive == 1)
                        on permission.ScreenId equals major.Id into majorGroup
                        from major in majorGroup.DefaultIfEmpty()
                        where permission.ScreenId == screenId && permission.IsActive == 1 && permission.CompanyId == companyId
                        select new PermissionModel
                        {
                            Id = permission.Id,
                            MajorId = permission.MajorId,
                            ScreenId = permission.ScreenId,
                            PermissionType = permission.PermissionType,
                            PermissionName = permission.PermissionName,
                            ScreenName = major.MajorName,
                            CompanyId = permission.CompanyId,
                        };

            return await query.OrderBy(p => p.PermissionType).ToListAsync();
        }

        public async Task<MPermission> GetById(string id)
        {
            using var context = _context.CreateDbContext();
            var entity = await context.MPermissions.Where(x => x.Id.Equals(id) && x.IsActive == 1).FirstOrDefaultAsync();

            if (entity == null)
            {
                throw new Exception($"Không tìm thấy bản ghi theo ID: {id}");
            }

            return entity;
        }

        public async Task Insert(MPermission entity)
        {
            using var context = _context.CreateDbContext();
            if (entity == null)
            {
                throw new Exception("Không có bản ghi nào để thêm!");
            }

            context.MPermissions.Add(entity);
            await context.SaveChangesAsync();
        }

        public async Task Update(MPermission mPermission)
        {
            using var context = _context.CreateDbContext();
            var entity = GetById(mPermission.Id);

            if (entity == null)
            {
                throw new Exception($"Không tìm thấy bản ghi theo ID: {mPermission.Id}");
            }

            context.MPermissions.Update(mPermission);
            await context.SaveChangesAsync();
        }

        public async Task UpdateMulti(MPermission[] entities)
        {
            using var context = _context.CreateDbContext();
            string[] ids = entities.Select(x => x.Id).ToArray();
            var listEntities = await context.MPermissions.Where(x => ids.Contains(x.Id)).ToListAsync();
            foreach (var entity in listEntities)
            {
                context.MPermissions.Update(entity);
            }
            await context.SaveChangesAsync();
        }
    }
}
