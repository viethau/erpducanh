using DucAnhERP.Repository;
using DucAnhERP.Data;
using DucAnhERP.Models;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace DucAnhERP.Services
{
    public class DepartmentRepository : IDepartmentRepository
    {

        private readonly IDbContextFactory<ApplicationDbContext> _context;

        public DepartmentRepository(IDbContextFactory<ApplicationDbContext> context)
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
            context.MDepartments.Update(entity);
            await context.SaveChangesAsync();
        }

        public Task<List<MDepartment>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<MDepartment> GetById(string id)
        {
            using var context = _context.CreateDbContext();
            var entity = await context.MDepartments.Where(x => x.Id.Equals(id) && x.IsActive == 1).FirstOrDefaultAsync();
            return entity;
        }

        public async Task<List<MDepartment>> GetDepartmentsByCompany(string companyId)
        {
            using var context = _context.CreateDbContext();
            var query = context.MDepartments.Where(x => x.CompanyId == companyId && x.IsActive == 1);
            return await query.ToListAsync();
        }

        public async Task Insert(MDepartment entity)
        {
            using var context = _context.CreateDbContext();
            if (entity == null)
            {
                throw new Exception("Không có bản ghi nào để thêm!");
            }

            context.MDepartments.Add(entity);
            await context.SaveChangesAsync();
        }

        public async Task Update(MDepartment department)
        {
            using var context = _context.CreateDbContext();
            var entity = GetById(department.Id);

            if (entity == null)
            {
                throw new Exception($"Không tìm thấy bản ghi theo ID: {department.Id}");
            }

            context.MDepartments.Update(department);
            await context.SaveChangesAsync();
        }

        public Task UpdateMulti(MDepartment[] entities)
        {
            throw new NotImplementedException();
        }
    }
}
