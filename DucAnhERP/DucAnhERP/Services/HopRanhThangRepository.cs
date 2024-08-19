using DucAnhERP.Data;
using DucAnhERP.Models;
using DucAnhERP.Repository;
using DucAnhERP.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace DucAnhERP.Services
{
    public class HopRanhThangRepository : IMHopRanhThangRepository
    {
        private readonly IDbContextFactory<ApplicationDbContext> _context;

        public HopRanhThangRepository(IDbContextFactory<ApplicationDbContext> context)
        {
            _context = context;
        }

        public async Task<List<MHopRanhThang>> GetAll()
        {
            try
            {
                using var context = _context.CreateDbContext();
                var entity = await context.DSHopRanhThang.ToListAsync();
                return entity;
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.Error.WriteLine($"An error occurred: {ex.Message}");
                throw; // Optionally rethrow the exception
            }
        }

        public async Task Update(MHopRanhThang hopRanhThang)
        {
            using var context = _context.CreateDbContext();
            var entity = GetById(hopRanhThang.Id);

            if (entity == null)
            {
                throw new Exception($"Không tìm thấy bản ghi theo ID: {hopRanhThang.Id}");
            }

            context.DSHopRanhThang.Update(hopRanhThang);
            await context.SaveChangesAsync();
        }

        public async Task UpdateMulti(MHopRanhThang[] hopRanhThang)
        {
            using var context = _context.CreateDbContext();
            string[] ids = hopRanhThang.Select(x => x.Id).ToArray();
            var listEntities = await context.DSHopRanhThang.Where(x => ids.Contains(x.Id)).ToListAsync();
            foreach (var entity in listEntities)
            {
                context.DSHopRanhThang.Update(entity);
            }
            await context.SaveChangesAsync();
        }

        public async Task DeleteById(string id)
        {
            using var context = _context.CreateDbContext();
            var entity = await GetById(id);

            if (entity == null)
            {
                throw new Exception($"Không tìm thấy bản ghi theo ID: {id}");
            }

            await context.SaveChangesAsync();
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

            }
            return true;
        }

        public async Task<MHopRanhThang> GetById(string id)
        {
            using var context = _context.CreateDbContext();
            var entity = await context.DSHopRanhThang.Where(x => x.Id.Equals(id)).FirstOrDefaultAsync();

            if (entity == null)
            {
                throw new Exception($"Không tìm thấy bản ghi theo ID: {id}");
            }

            return entity;
        }

        public async Task Insert(MHopRanhThang entity)
        {
            try
            {
                using var context = _context.CreateDbContext();
                if (entity == null)
                {
                    throw new Exception("Không có bản ghi nào để thêm!");
                }

                entity.Id = Guid.NewGuid().ToString();
                context.DSHopRanhThang.Add(entity);
                await context.SaveChangesAsync();
            }
            catch (Exception ex) {
                Console.WriteLine(ex);
            }
        }


    }
}
