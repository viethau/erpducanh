using DucAnhERP.Repository;
using DucAnhERP.Data;
using DucAnhERP.Models;
using Microsoft.EntityFrameworkCore;

namespace DucAnhERP.Services
{
    public class UserRepository : IUserRepository
    {
        private readonly IDbContextFactory<ApplicationDbContext> _context;

        public UserRepository(IDbContextFactory<ApplicationDbContext> context)
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
            context.ApplicationUsers.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task<ApplicationUser> GetById(string id)
        {
            using var context = _context.CreateDbContext();
            var entity = await (from user in context.Users
                          join appUser in context.ApplicationUsers on user.Id equals appUser.UserId
                          where user.Id.Equals(id) && appUser.IsActive == 1
                          select new ApplicationUser
                          {
                              // Chọn các trường mà bạn muốn lấy từ bảng ApplicationUsers
                              Id = appUser.Id,
                              UserName = user.UserName,
                              FirstName = appUser.FirstName,
                              LastName = appUser.LastName,
                              Dob = appUser.Dob,
                              ContractId = appUser.ContractId,
                              CompanyId = appUser.CompanyId,
                              DeptId = appUser.DeptId,
                              IsFirstLogin = appUser.IsFirstLogin,
                              IsActive = appUser.IsActive,
                              CreateAt = appUser.CreateAt,
                              CreateBy = appUser.CreateBy,
                              UpdateAt = appUser.UpdateAt,
                              UpdateBy = appUser.UpdateBy,
                              UserId = user.Id,
                              Email = user.Email,
                              PhoneNumber = user.PhoneNumber,
                              Address = appUser.Address
                              // Ví dụ: UserId, IsActive, và các trường khác
                          }).FirstOrDefaultAsync();

            return entity;
        }

        public ApplicationUser GetByUserName(string userName)
        {
            using var context = _context.CreateDbContext();
            var query =  (from user in context.Users
                          join appUser in context.ApplicationUsers on user.Id equals appUser.UserId
                          where user.UserName.Equals(userName) && appUser.IsActive == 1
                          select new ApplicationUser
                          {
                              // Chọn các trường mà bạn muốn lấy từ bảng ApplicationUsers
                              Id = appUser.Id,
                              UserName = user.UserName,
                              FirstName = appUser.FirstName,
                              LastName = appUser.LastName,
                              Dob = appUser.Dob,
                              ContractId = appUser.ContractId,
                              CompanyId = appUser.CompanyId,
                              DeptId = appUser.DeptId,
                              IsFirstLogin = appUser.IsFirstLogin,
                              IsActive = appUser.IsActive,
                              CreateAt = appUser.CreateAt,
                              CreateBy = appUser.CreateBy,
                              UpdateAt = appUser.UpdateAt,
                              UpdateBy = appUser.UpdateBy,
                              UserId = user.Id,
                              Email = user.Email,
                              PhoneNumber = user.PhoneNumber,
                              Address = appUser.Address
                              // Ví dụ: UserId, IsActive, và các trường khác
                          });
            var entity = query.FirstOrDefault();
            return entity;
        }

        public async Task Insert(ApplicationUser entity)
        {
            using var context = _context.CreateDbContext();
            if (entity == null)
            {
                throw new Exception("Không có bản ghi nào để thêm!");
            }

            context.ApplicationUsers.Add(entity);
            await context.SaveChangesAsync();
        }

        public bool IsExistByPhoneNumber(string phoneNumber)
        {
            using var context = _context.CreateDbContext();
            var entity = (from user in context.Users
                          join appUser in context.ApplicationUsers on user.Id equals appUser.UserId
                          where user.PhoneNumber.Equals(phoneNumber) && appUser.IsActive == 1
                          select new ApplicationUser
                          {
                              // Chọn các trường mà bạn muốn lấy từ bảng ApplicationUsers
                              Id = appUser.Id,
                              UserName = user.UserName,
                              FirstName = appUser.FirstName,
                              LastName = appUser.LastName,
                              Dob = appUser.Dob,
                              ContractId = appUser.ContractId,
                              CompanyId = appUser.CompanyId,
                              DeptId = appUser.DeptId,
                              IsFirstLogin = appUser.IsFirstLogin,
                              IsActive = appUser.IsActive,
                              CreateAt = appUser.CreateAt,
                              CreateBy = appUser.CreateBy,
                              UpdateAt = appUser.UpdateAt,
                              UpdateBy = appUser.UpdateBy,
                              UserId = user.Id,
                              Email = user.Email,
                              PhoneNumber = user.PhoneNumber,
                              Address = appUser.Address
                              // Ví dụ: UserId, IsActive, và các trường khác
                          }).FirstOrDefault();
            return entity != null;
        }

        public async Task Update(ApplicationUser user)
        {
            using var context = _context.CreateDbContext();
            var entity = GetById(user.Id);

            if (entity == null)
            {
                throw new Exception($"Không tìm thấy bản ghi theo ID: {user.Id}");
            }

            context.ApplicationUsers.Update(user);
            await context.SaveChangesAsync();
        }

        public Task UpdateMulti(ApplicationUser[] entities)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ApplicationUser>> GetAll()
        {
            using var context = _context.CreateDbContext();
            var listUser = await (from user in context.Users
                            join appUser in context.ApplicationUsers on user.Id equals appUser.UserId
                            where appUser.IsActive == 1
                            select new ApplicationUser
                            {
                                Id = appUser.Id,
                                UserName = user.UserName,
                                FirstName = appUser.FirstName,
                                LastName = appUser.LastName,
                                Dob = appUser.Dob,
                                ContractId = appUser.ContractId,
                                CompanyId = appUser.CompanyId,
                                DeptId = appUser.DeptId,
                                IsFirstLogin = appUser.IsFirstLogin,
                                IsActive = appUser.IsActive,
                                CreateAt = appUser.CreateAt,
                                CreateBy = appUser.CreateBy,
                                UpdateAt = appUser.UpdateAt,
                                UpdateBy = appUser.UpdateBy,
                                UserId = user.Id,
                                Email = user.Email,
                                PhoneNumber = user.PhoneNumber,
                                Address = appUser.Address
                            }).ToListAsync();
            return listUser;
        }

        public async Task<ApplicationUser> GetById(string id, int isActive)
        {
            using var context = _context.CreateDbContext();
            var entity = await(from user in context.Users
                               join appUser in context.ApplicationUsers on user.Id equals appUser.UserId
                               where user.Id.Equals(id) && appUser.IsActive == isActive
                               select new ApplicationUser
                               {
                                   // Chọn các trường mà bạn muốn lấy từ bảng ApplicationUsers
                                   Id = appUser.Id,
                                   UserName = user.UserName,
                                   FirstName = appUser.FirstName,
                                   LastName = appUser.LastName,
                                   Dob = appUser.Dob,
                                   ContractId = appUser.ContractId,
                                   CompanyId = appUser.CompanyId,
                                   DeptId = appUser.DeptId,
                                   IsFirstLogin = appUser.IsFirstLogin,
                                   IsActive = appUser.IsActive,
                                   CreateAt = appUser.CreateAt,
                                   CreateBy = appUser.CreateBy,
                                   UpdateAt = appUser.UpdateAt,
                                   UpdateBy = appUser.UpdateBy,
                                   UserId = user.Id,
                                   Email = user.Email,
                                   PhoneNumber = user.PhoneNumber,
                                   Address = appUser.Address
                                   // Ví dụ: UserId, IsActive, và các trường khác
                               }).FirstOrDefaultAsync();

            return entity;
        }
    }
}
