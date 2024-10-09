using DucAnhERP.Repository;
using DucAnhERP.Data;
using DucAnhERP.Models;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using DucAnhERP.ViewModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.Json;
using DucAnhERP.Helpers;
using System.ComponentModel.Design;

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
                                          //a.ScreenId.Equals(screenId) &&
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
            await DeleteByIdDetail(entity.Id);
            context.Set<MMajorUserPermission>().Remove(entity);
            await context.SaveChangesAsync();
        }

        public async Task DeleteExistPermission(string companyId, string majorId, string userId)
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
                        p.IsActive == 1);

                var permissionsToDelete = await result.ToListAsync();

                // Xóa logic các record truy vấn được
                if (permissionsToDelete != null && permissionsToDelete.Any())
                {
                    foreach (var permission in permissionsToDelete)
                    {
                        permission.IsActive = 0;
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

        public async Task<List<MMajorUserPermission>> GetAll()
        {
            try
            {
                using var context = _context.CreateDbContext();
                var entity = await context.MMajorUserPermissions.ToListAsync();
                return entity;
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.Error.WriteLine($"An error occurred: {ex.Message}");
                throw; // Optionally rethrow the exception
            }
        }

        public async Task<List<MMajorUserPermission>> GetExist(MMajorUserPermission input)
        {
            try
            {
                using var context = _context.CreateDbContext();

                var query = context.MMajorUserPermissions
                         .Where(item =>
                         item.CompanyId == input.CompanyId &&
                             item.MajorId == input.MajorId &&
                            item.UserId == input.UserId)
                         ;

                // Lấy kết quả dưới dạng danh sách
                var data = await query.ToListAsync();
                return data;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
          

        }

        public async Task<List<MajorUserPermissionModel>> GetAllByVM(MajorUserPermissionModel majorUserPermissionModel)
        {
            using var context = _context.CreateDbContext();
            var query = from perContr in context.MMajorUserPermissions
                        join company in context.MCompanies
                        on perContr.CompanyId equals company.Id into gr1
                        from company in gr1.DefaultIfEmpty()
                        join major in context.MMajors
                       on perContr.MajorId equals major.Id into gr2
                        from major in gr2.DefaultIfEmpty()
                        join user in context.ApplicationUsers
                      on perContr.UserId equals user.Id into gr3
                        from user in gr3.DefaultIfEmpty()


                        orderby perContr.CreateAt descending
                        select new MajorUserPermissionModel
                        {
                            Id = perContr.Id,
                            CompanyId = perContr.CompanyId,
                            CompanyName = company.CompanyName,
                            MajorId = perContr.MajorId,
                            MajorName = major.MajorName,
                            PermissionId = perContr.PermissionId,
                            PermissionName = "",
                            UserId = perContr.Id,
                            UserName = user.UserName,
                            DayinWeek = perContr.DayinWeek,
                            CreateAt = perContr.CreateAt,
                            CreateBy = perContr.CreateBy,
                            IsActive = perContr.IsActive
                        };

            if (!string.IsNullOrEmpty(majorUserPermissionModel.CompanyId))
            {
                query = query.Where(m => m.CompanyId == majorUserPermissionModel.CompanyId);
            }

            if (!string.IsNullOrEmpty(majorUserPermissionModel.MajorId))
            {
                query = query.Where(m => m.MajorId == majorUserPermissionModel.MajorId);
            }

            if (!string.IsNullOrEmpty(majorUserPermissionModel.UserId))
            {
                query = query.Where(m => m.UserId == majorUserPermissionModel.UserId);
            }

            var data = await query.ToListAsync();
            return data;
        }


        public async Task<List<MMajorUserPermission>> GetByCompanyUser(string companyId, string screenId, string userId)
        {
            using var context = _context.CreateDbContext();
            var major = await context.MMajorUserPermissions.Where(x => x.CompanyId == companyId && x.UserId == userId && x.IsActive == 1).ToListAsync();
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
            await DeleteByIdDetail(entity.Id);
            context.MMajorUserPermissions.Update(mMajorUserPermission);
            if (!string.IsNullOrEmpty(entity.PermissionId))
            {
                // Chuyển đổi PermissionId từ JSON thành danh sách SelectedItem
                List<SelectedItem> list = JsonSerializer.Deserialize<List<SelectedItem>>(entity.PermissionId);
                List<MMajorUserPermissionDetail> listDetails = new();

                // Duyệt qua danh sách SelectedItem và tạo danh sách MMajorUserPermissionDetail
                foreach (var item in list)
                {
                    listDetails.Add(new MMajorUserPermissionDetail
                    {
                        Id = Guid.NewGuid().ToString(),
                        CompanyId = entity.CompanyId,
                        MajorId = entity.MajorId,
                        UserId = entity.UserId,
                        PermissionId = item.Value,
                        Id_MMajorUserPermission = entity.Id,
                        DayinWeek = entity.DayinWeek,
                        CreateAt = entity.CreateAt,
                        CreateBy = entity.CreateBy,
                        IsActive = entity.IsActive
                    });
                }

                // Gọi hàm InsertMultiple để thêm các chi tiết quyền
                await InsertMultiple(listDetails);
            }
            
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


        public async Task<string> InsertById(MMajorUserPermission entity)
        {
            try
            {
                using var context = _context.CreateDbContext();

                if (entity == null)
                {
                    throw new Exception("Không có bản ghi nào để thêm!");
                }

                // Thêm đối tượng vào DbContext
                context.MMajorUserPermissions.Add(entity);

                // Lưu thay đổi vào cơ sở dữ liệu
                await context.SaveChangesAsync();
                var id  = entity.Id;
                // Trả về Id của đối tượng đã được thêm
                if (!string.IsNullOrEmpty(entity.PermissionId))
                {
                    // Chuyển đổi PermissionId từ JSON thành danh sách SelectedItem
                    List<SelectedItem> list = JsonSerializer.Deserialize<List<SelectedItem>>(entity.PermissionId);
                    List<MMajorUserPermissionDetail> listDetails = new();

                    // Duyệt qua danh sách SelectedItem và tạo danh sách MMajorUserPermissionDetail
                    foreach (var item in list)
                    {
                        listDetails.Add(new MMajorUserPermissionDetail
                        {
                            Id = Guid.NewGuid().ToString(),
                            CompanyId = entity.CompanyId,
                            MajorId = entity.MajorId,
                            UserId = entity.UserId,
                            PermissionId = item.Value,
                            Id_MMajorUserPermission = id,
                            DayinWeek  = entity.DayinWeek,
                            CreateAt = entity.CreateAt,
                            CreateBy = entity.CreateBy,
                            IsActive = entity.IsActive
                        });
                    }

                    // Gọi hàm InsertMultiple để thêm các chi tiết quyền
                    await InsertMultiple(listDetails);
                }

                return id;
            } 
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
           
        }

        public async Task DeleteByIdDetail(string id_MMajorUserPermission)
        {
            using var context = _context.CreateDbContext();

            // Tìm các bản ghi chi tiết theo Id_MMajorUserPermission
            var entities = context.MMajorUserPermissionDetails
                .Where(detail => detail.Id_MMajorUserPermission == id_MMajorUserPermission).ToList();

            // Nếu không tìm thấy bản ghi nào, ném ra ngoại lệ
            if (entities == null || !entities.Any())
            {
                throw new Exception($"Không tìm thấy bản ghi nào theo Id_MMajorUserPermission: {id_MMajorUserPermission}");
            }

            // Xóa các bản ghi tìm được
            context.MMajorUserPermissionDetails.RemoveRange(entities);

            // Lưu thay đổi vào cơ sở dữ liệu
            await context.SaveChangesAsync();
        }
        public async Task<List<string>> InsertMultiple(List<MMajorUserPermissionDetail> entities)
        {
            using var context = _context.CreateDbContext();

            if (entities == null || entities.Count == 0)
            {
                throw new Exception("Không có bản ghi nào để thêm!");
            }

            // Thêm danh sách các đối tượng vào DbContext
            context.MMajorUserPermissionDetails.AddRange(entities);

            // Lưu thay đổi vào cơ sở dữ liệu
            await context.SaveChangesAsync();

            // Trả về danh sách Id của các đối tượng đã thêm
            return entities.Select(e => e.Id).ToList();
        }


       

    }
}
