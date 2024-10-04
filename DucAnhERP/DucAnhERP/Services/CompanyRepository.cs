using DucAnhERP.Repository;
using DucAnhERP.Data;
using DucAnhERP.Models;
using Microsoft.EntityFrameworkCore;

namespace DucAnhERP.Services
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly IDbContextFactory<ApplicationDbContext> _context;

        public CompanyRepository(IDbContextFactory<ApplicationDbContext> context)
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
            context.MCompanies.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task<List<MCompany>> GetAll()
        {
            try
            {
                using var context = _context.CreateDbContext();
                var entity = await context.MCompanies.ToListAsync();
                return entity;
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.Error.WriteLine($"An error occurred: {ex.Message}");
                throw; // Optionally rethrow the exception
            }
        }

        public async Task<List<MCompany>> GetAllCompanies()
        {
            using var context = _context.CreateDbContext();
            var query =  context.MCompanies.Where(x => x.IsActive == 1);
            return await query.ToListAsync();
        }

        public async Task<MCompany> GetById(string id)
        {
            using var context = _context.CreateDbContext();
            var entity = await context.MCompanies.Where(x => x.Id.Equals(id) && x.IsActive == 1).FirstOrDefaultAsync();

            if (entity == null)
            {
                throw new Exception($"Không tìm thấy bản ghi theo ID: {id}");
            }

            return entity;
        }

        public async Task Insert(MCompany entity)
        {
            using var context = _context.CreateDbContext();
            if (entity == null)
            {
                throw new Exception("Không có bản ghi nào để thêm!");
            }

            context.MCompanies.Add(entity);
            await context.SaveChangesAsync();
        }

        public async Task Update(MCompany company)
        {
            using var context = _context.CreateDbContext();
            var entity = GetById(company.Id);

            if (entity == null)
            {
                throw new Exception($"Không tìm thấy bản ghi theo ID: {company.Id}");
            }

            context.MCompanies.Update(company);
            await context.SaveChangesAsync();
        }

        public async Task UpdateMulti(MCompany[] companies)
        {
            using var context = _context.CreateDbContext();
            string[] ids = companies.Select(x => x.Id).ToArray();
            var listEntities = await context.MCompanies.Where(x => ids.Contains(x.Id)).ToListAsync();
            foreach (var entity in listEntities)
            {
                context.MCompanies.Update(entity);
            }
            await context.SaveChangesAsync();
        }
    }
}
