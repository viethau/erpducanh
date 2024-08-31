using DucAnhERP.Data;
using DucAnhERP.Models;
using DucAnhERP.Repository;
using DucAnhERP.ViewModel;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace DucAnhERP.Services
{
    public class NhomNhomDanhMucRepository : INhomDanhMucRepository
    {
        private readonly IDbContextFactory<ApplicationDbContext> _context;

        public NhomNhomDanhMucRepository(IDbContextFactory<ApplicationDbContext> context)
        {
            _context = context;
        }
        public async Task<List<MNhomDanhMuc>> GetAll()
        {
            using var context = _context.CreateDbContext();
            var entity = await context.DSNhomDanhMuc.ToListAsync();
            return entity;
        }
        public async Task<List<NhomDanhMucModel>> GetAllNDM()
        {
            using var context = _context.CreateDbContext();
            var query = from ndm in context.DSNhomDanhMuc
                        orderby ndm.Ten
                        select new NhomDanhMucModel
                        {
                            Id = ndm.Id,
                            Ten = ndm.Ten,
                          
                        };

            var data = await query.ToListAsync();
            return data;
        }


        public async Task Update(MNhomDanhMuc NhomDanhMuc)
        {
            using var context = _context.CreateDbContext();
            var entity = GetById(NhomDanhMuc.Id);

            if (entity == null)
            {
                throw new Exception($"Không tìm thấy bản ghi theo ID: {NhomDanhMuc.Id}");
            }

            context.DSNhomDanhMuc.Update(NhomDanhMuc);
            await context.SaveChangesAsync();
        }

        public async Task UpdateMulti(MNhomDanhMuc[] NhomDanhMuc)
        {
            using var context = _context.CreateDbContext();
            string[] ids = NhomDanhMuc.Select(x => x.Id).ToArray();
            var listEntities = await context.DSNhomDanhMuc.Where(x => ids.Contains(x.Id)).ToListAsync();
            foreach (var entity in listEntities)
            {
                context.DSNhomDanhMuc.Update(entity);
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

        public async Task<bool> DeleteByIdResult(string id)
        {
            
            try
            {
                using var context = _context.CreateDbContext();
                var entity = await GetById(id);

                if (entity == null)
                {
                    return false;
                }

                // Xóa bản ghi
                context.DSNhomDanhMuc.Remove(entity);
                int affectedRows = await context.SaveChangesAsync();
                if (affectedRows > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
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



            }
            return true;
        }


        public async Task<MNhomDanhMuc> GetById(string id)
        {
            using var context = _context.CreateDbContext();
            var entity = await context.DSNhomDanhMuc.Where(x => x.Id.Equals(id)).FirstOrDefaultAsync();

            if (entity == null)
            {
                throw new Exception($"Không tìm thấy bản ghi theo ID: {id}");
            }

            return entity;
        }


        public async Task Insert(MNhomDanhMuc entity)
        {
            using var context = _context.CreateDbContext();
            if (entity == null)
            {
                throw new Exception("Không có bản ghi nào để thêm!");
            }

            context.DSNhomDanhMuc.Add(entity);
            await context.SaveChangesAsync();
        }


    }
}
