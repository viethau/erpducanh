using DucAnhERP.Repository;
using DucAnhERP.Data;
using DucAnhERP.Models;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DucAnhERP.Services
{
    public class MajorUserPermissionRepository : IMajorUserPermissionRepository
    {
        private readonly IDbContextFactory<ApplicationDbContext> _context;

        private readonly AuthenticationStateProvider _authenticationState;

        private readonly UserManager<IdentityUser> _userManager;

        public MajorUserPermissionRepository(IDbContextFactory<ApplicationDbContext> context, AuthenticationStateProvider authenticationState, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _authenticationState = authenticationState;
            _userManager = userManager;
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

        public async Task<bool> CheckPermission(string majorId, string screenId, int permissionType)
        {
            using var context = _context.CreateDbContext();
            // Get login user
            try
            {
                var authState = await _authenticationState.GetAuthenticationStateAsync();
                var loginUserName = authState.User.Identity.Name;
                var user = await _userManager.FindByNameAsync(loginUserName);

                // Nếu không có công ty và phòng ban thì là tài khoản admin
                //if (user.CompanyId is null && user.DeptId is null)
                //{
                //    return true;
                //}


                // Thực hiện truy vấn SQL
                var result = await (from a in context.MMajorUserPermissions
                                    join b in context.MPermissions on a.PermissionId equals b.Id
                                    where a.UserId.Equals(user.Id) &&
                                          a.MajorId.Equals(majorId) &&
                                          a.ScreenId.Equals(screenId) &&
                                          //a.CompanyId.Equals(user.CompanyId) &&
                                          b.PermissionType == permissionType &&
                                          a.IsActive == 1 &&
                                          b.IsActive == 1
                                    select a.Id).CountAsync();

                // Kiểm tra độ dài của danh sách kết quả và trả về true nếu có 1 bản ghi, ngược lại trả về false
                return result == 1;
            }
            catch (Exception)
            {
                throw new Exception($"Bạn không có quyền để thực hiện hành động này");
            }

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
            entity.UpdateAt = DateTime.Now;
            entity.UpdateBy = "anhtuan.vp98@gmail.com";
            context.MMajorUserPermissions.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task DeleteExistPermission(string companyId, string majorId, string userId, string screenId)
        {
            using var context = _context.CreateDbContext();
            try
            {
                // Truy vấn các bản ghi dựa trên các điều kiện tham số
                var result = context.MMajorUserPermissions
                    .Where(p =>
                        p.CompanyId == companyId &&
                        p.MajorId == majorId &&
                        p.UserId == userId &&
                        p.ScreenId == screenId &&
                        p.IsActive == 1);

                var permissionsToDelete = await result.ToListAsync();

                // Xóa logic các record truy vấn được
                if (permissionsToDelete != null && permissionsToDelete.Any())
                {
                    foreach (var permission in permissionsToDelete)
                    {
                        permission.IsActive = 0;
                        permission.UpdateAt = DateTime.Now;
                        permission.UpdateBy = "anhtuan.vp98@gmai.com";
                        context.MMajorUserPermissions.Update(permission);

                    }
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task<List<MMajorUserPermission>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<List<MMajorUserPermission>> GetByCompanyUser(string companyId, string screenId, string userId)
        {
            using var context = _context.CreateDbContext();
            var major = await context.MMajorUserPermissions.Where(x => x.CompanyId == companyId && x.ScreenId == screenId && x.UserId == userId && x.IsActive == 1).ToListAsync();
            return major;
        }

        public async Task<MMajorUserPermission> GetById(string id)
        {
            using var context = _context.CreateDbContext();
            var entity = await context.MMajorUserPermissions.Where(x => x.Id.Equals(id) && x.IsActive == 1).FirstOrDefaultAsync();

            if (entity == null)
            {
                throw new Exception($"Không tìm thấy bản ghi theo ID: {id}");
            }

            return entity;
        }

        public async Task Insert(MMajorUserPermission entity)
        {
            using var context = _context.CreateDbContext();
            if (entity == null)
            {
                throw new Exception("Không có bản ghi nào để thêm!");
            }

            context.MMajorUserPermissions.Add(entity);
            await context.SaveChangesAsync();
        }

        public async Task Update(MMajorUserPermission mMajorUserPermission)
        {
            using var context = _context.CreateDbContext();
            var entity = await GetById(mMajorUserPermission.Id);

            if (entity == null)
            {
                throw new Exception($"Không tìm thấy bản ghi theo ID: {mMajorUserPermission.Id}");
            }

            context.MMajorUserPermissions.Update(mMajorUserPermission);
            await context.SaveChangesAsync();
        }

        public async Task UpdateMulti(MMajorUserPermission[] entities)
        {
            using var context = _context.CreateDbContext();
            string[] ids = entities.Select(x => x.Id).ToArray();
            var listEntities = await context.MMajorUserPermissions.Where(x => ids.Contains(x.Id)).ToListAsync();
            foreach (var entity in listEntities)
            {
                context.MMajorUserPermissions.Update(entity);
            }
            await context.SaveChangesAsync();
        }
    }
}
