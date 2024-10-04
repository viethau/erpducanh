using DucAnhERP.Data;
using DucAnhERP.Models;
using DucAnhERP.ViewModel;
using Microsoft.EntityFrameworkCore;
using DucAnhERP.Repository;
using System.Security;
namespace DucAnhERP.Services
{
    public class MPermissionRepository : IPermissionRepository
    {
        private readonly IDbContextFactory<ApplicationDbContext> _context;
        public MPermissionRepository(IDbContextFactory<ApplicationDbContext> context)
        {
            _context = context;
        }

        public async Task<List<MPermission>> GetExist(MPermission input)
        {
            using var context = _context.CreateDbContext();

            if (input.PermissionType == 6)
            {
                var query = context.MPermissions
                    .Where(permission =>
                        permission.MajorId == input.MajorId &&
                        permission.PermissionName == input.PermissionName)
                    .OrderByDescending(permission => permission.CreateAt);
                // Lấy kết quả dưới dạng danh sách
                var data = await query.ToListAsync();
                return data;
            }
            else
            {
                var query = context.MPermissions
                    .Where(permission =>
                        permission.MajorId == input.MajorId &&
                        permission.PermissionType == input.PermissionType)
                    .OrderByDescending(permission => permission.CreateAt);

                // Lấy kết quả dưới dạng danh sách
                var data = await query.ToListAsync();
                return data;
            }


            
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
            context.Set<MPermission>().Remove(entity);
            await context.SaveChangesAsync();
        }
        public async Task<List<PermissionModel>> GetAllByVM(PermissionModel permissionModel)
        {
            using var context = _context.CreateDbContext();
            var query = from permission in context.MPermissions
                        join major in context.MMajors
                        on permission.MajorId equals major.Id into majorGroup
                        from major in majorGroup.DefaultIfEmpty()


                        orderby permission.CreateAt descending
                        select new PermissionModel
                        {
                            Id = permission.Id,
                            MajorId = permission.MajorId,
                            MajorName = major.MajorName,
                            PermissionType = permission.PermissionType,
                            PermissionName = permission.PermissionName,
                            CreateAt = permission.CreateAt,
                            CreateBy = permission.CreateBy,
                            IsActive = permission.IsActive
                        };

            if (!string.IsNullOrEmpty(permissionModel.MajorId))
            {
                query = query.Where(m => m.MajorId == permissionModel.MajorId);
            }

            if (!string.IsNullOrEmpty(permissionModel.PermissionName))
            {
                query = query.Where(m => m.PermissionName == permissionModel.PermissionName);
            }

            var data = await query.ToListAsync();
            return data;
        }


        public async Task<List<PermissionModel>> GetAllCorePermission(string screenId, string companyId)
        {
            using var context = _context.CreateDbContext();
            var query = from permission in context.MPermissions
                        join major in context.MMajors
                        on permission.MajorId equals major.Id into majorGroup
                        from major in majorGroup.DefaultIfEmpty()
                       
                        select new PermissionModel
                        {
                            Id = permission.Id,
                            MajorId = permission.MajorId,
                            PermissionType = permission.PermissionType,
                            PermissionName = permission.PermissionName,
                        };

            return await query.OrderBy(p => p.PermissionType).ToListAsync();
        }
        public async Task<List<MPermission>> GetAllMPermissions()
        {
            using var context = _context.CreateDbContext();
            var query = context.MPermissions.Where(x => x.IsActive == 1);
            return await query.ToListAsync();
        }

        public async Task<List<MPermission>> GetAll()
        {
            try
            {
                using var context = _context.CreateDbContext();
                var entity = await context.MPermissions.ToListAsync();
                return entity;
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.Error.WriteLine($"An error occurred: {ex.Message}");
                throw; // Optionally rethrow the exception
            }
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
            try
            {
                using var context = _context.CreateDbContext();
                if (entity == null)
                {
                    throw new Exception("Không có bản ghi nào để thêm!");
                }
                context.MPermissions.Add(entity);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        public async Task Update(MPermission mpermission)
        {
            using var context = _context.CreateDbContext();
            var entity = GetById(mpermission.Id);
            if (entity == null)
            {
                throw new Exception($"Không tìm thấy bản ghi theo ID: {mpermission.Id}");
            }
            context.MPermissions.Update(mpermission);
            await context.SaveChangesAsync();
        }
        public async Task UpdateMulti(MPermission[] MPermissions)
        {
            using var context = _context.CreateDbContext();
            string[] ids = MPermissions.Select(x => x.Id).ToArray();
            var listEntities = await context.MPermissions.Where(x => ids.Contains(x.Id)).ToListAsync();
            foreach (var entity in listEntities)
            {
                context.MPermissions.Update(entity);
            }
            await context.SaveChangesAsync();
        }
    }
}
