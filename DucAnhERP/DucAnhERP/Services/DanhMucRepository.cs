using DucAnhERP.Data;
using DucAnhERP.Models;
using DucAnhERP.Repository;
using Microsoft.EntityFrameworkCore;

namespace DucAnhERP.Services
{
    public class DanhMucRepository : IDanhMucRepository
    {
        private readonly IDbContextFactory<ApplicationDbContext> _context;

        public DanhMucRepository(IDbContextFactory<ApplicationDbContext> context)
        {
            _context = context;
        }
        public async Task<List<DanhMuc>> GetAll()
        {
            using var context = _context.CreateDbContext();
            var entity = await context.DSDanhMuc.ToListAsync();
            return entity;
        }

        public async Task Update(DanhMuc danhmuc)
        {
            using var context = _context.CreateDbContext();
            var entity = GetById(danhmuc.Id);

            if (entity == null)
            {
                throw new Exception($"Không tìm thấy bản ghi theo ID: {danhmuc.Id}");
            }

            context.DSDanhMuc.Update(danhmuc);
            await context.SaveChangesAsync();
        }

        public async Task UpdateMulti(DanhMuc[] danhmuc)
        {
            using var context = _context.CreateDbContext();
            string[] ids = danhmuc.Select(x => x.Id).ToArray();
            var listEntities = await context.DSDanhMuc.Where(x => ids.Contains(x.Id)).ToListAsync();
            foreach (var entity in listEntities)
            {
                context.DSDanhMuc.Update(entity);
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


        public async Task<DanhMuc> GetById(string id)
        {
            using var context = _context.CreateDbContext();
            var entity = await context.DSDanhMuc.Where(x => x.Id.Equals(id)).FirstOrDefaultAsync();

            if (entity == null)
            {
                throw new Exception($"Không tìm thấy bản ghi theo ID: {id}");
            }

            return entity;
        }


        public async Task Insert(DanhMuc entity)
        {
            using var context = _context.CreateDbContext();
            if (entity == null)
            {
                throw new Exception("Không có bản ghi nào để thêm!");
            }

            entity.Id = Guid.NewGuid().ToString();
            context.DSDanhMuc.Add(entity);
            await context.SaveChangesAsync();
        }


    }
}
