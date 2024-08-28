using DucAnhERP.Data;
using DucAnhERP.Models;
using DucAnhERP.Repository;
using DucAnhERP.ViewModel;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace DucAnhERP.Services
{
    public class DanhMucRepository : IDanhMucRepository
    {
        private readonly IDbContextFactory<ApplicationDbContext> _context;

        public DanhMucRepository(IDbContextFactory<ApplicationDbContext> context)
        {
            _context = context;
        }

        public async Task<List<DanhMucModel>> GetAllDM()
        {
            using var context = _context.CreateDbContext();
            var query = from danhMuc in context.DSDanhMuc
                        join nhomDanhMuc in context.DSNhomDanhMuc
                        on danhMuc.IdNhomDanhMuc equals nhomDanhMuc.Id into nhomDanhMucGroup
                        from nhomDanhMuc in nhomDanhMucGroup.DefaultIfEmpty()
                        select new DanhMucModel
                        {
                            Id = danhMuc.Id,
                            IdNhomDanhMuc = danhMuc.IdNhomDanhMuc,
                            Ten = danhMuc.Ten,
                            TenNhom = nhomDanhMuc != null ? nhomDanhMuc.Ten : "Không xác định" // Tên từ bảng NhomDanhMuc
                        };

            var data = await query.ToListAsync();
            return data;
        }

        public async Task<List<MDanhMuc>> GetDMByIdNhomDanhMuc(string idNhomDanhMuc)
        {
            using var context = _context.CreateDbContext();
            var query = context.DSDanhMuc
                         .Where(danhMuc => danhMuc.IdNhomDanhMuc == idNhomDanhMuc)
                         .Select(danhMuc => new MDanhMuc
                         {
                             Id = danhMuc.Id,
                             IdNhomDanhMuc = danhMuc.IdNhomDanhMuc,
                             Ten = danhMuc.Ten
                         });

            var data = await query.ToListAsync();
            return data;
        }

        public async Task<bool> GetDMByTenNhomDanhMuc(string Ten)
        {
            bool isSuccess =false;      
            using var context = _context.CreateDbContext();
            var query = context.DSDanhMuc
                         .Where(danhMuc => danhMuc.Ten.ToUpper() == Ten.ToUpper())
                         .Select(danhMuc => new MDanhMuc
                         {
                             Id = danhMuc.Id,
                             IdNhomDanhMuc = danhMuc.IdNhomDanhMuc,
                             Ten = danhMuc.Ten
                         });

            var data = await query.ToListAsync();

            // Kiểm tra nếu danh sách kết quả rỗng hoặc không có dữ liệu khớp
             isSuccess = data.Any();
            return (isSuccess);
        }

        public async Task<string> GetIdDMByTen(string Ten)
        {
            using var context = _context.CreateDbContext();

            var id = await context.DSDanhMuc
                        .Where(danhMuc => danhMuc.Ten.ToUpper().Trim() == Ten.ToUpper().Trim())
                        .Select(danhMuc => danhMuc.Id)
                        .FirstOrDefaultAsync();
            return id ?? string.Empty;
        }


        public async Task<List<MDanhMuc>> GetAll()
        {
            try
            {
                using var context = _context.CreateDbContext();
                var entity = await context.DSDanhMuc.ToListAsync();
                return entity;
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.Error.WriteLine($"An error occurred: {ex.Message}");
                throw; // Optionally rethrow the exception
            }
        }

        public async Task Update(MDanhMuc danhmuc)
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

        public async Task UpdateMulti(MDanhMuc[] danhmuc)
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

            context.Set<MDanhMuc>().Remove(entity);
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

        public async Task<MDanhMuc> GetById(string id)
        {
            using var context = _context.CreateDbContext();
            var entity = await context.DSDanhMuc.Where(x => x.Id.Equals(id)).FirstOrDefaultAsync();

            if (entity == null)
            {
                throw new Exception($"Không tìm thấy bản ghi theo ID: {id}");
            }

            return entity;
        }

        public async Task Insert(MDanhMuc entity)
        {
            try
            {
                using var context = _context.CreateDbContext();
                if (entity == null)
                {
                    throw new Exception("Không có bản ghi nào để thêm!");
                }

                context.DSDanhMuc.Add(entity);
                await context.SaveChangesAsync();
            }
            catch (Exception ex) { 
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
