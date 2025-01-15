using DucAnhERP.Data;
using DucAnhERP.Models;
using DucAnhERP.Repository;
using DucAnhERP.ViewModel;
using Microsoft.EntityFrameworkCore;
using System.Runtime.Intrinsics.Arm;
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
        public async Task<bool> CheckStatus(string ids, string name)
        {
            return true;
        }

        public async Task<List<NhomDanhMuc>> GetAll(string groupId)
        {
            using var context = _context.CreateDbContext();
            var entity = await context.DSNhomDanhMuc.ToListAsync();
            return entity;
        }
        public async Task<List<NhomDanhMucModel>> GetAllNDM()
        {
            using var context = _context.CreateDbContext();
            var query = from ndm in context.DSNhomDanhMuc
                        orderby ndm.CreateAt descending
                        select new NhomDanhMucModel
                        {
                            Id = ndm.Id,
                            Ten = ndm.Ten,
                            CreateAt = ndm.CreateAt,
                            CreateBy = ndm.CreateBy,
                            IsActive = ndm.IsActive,
                        };

            var data = await query.ToListAsync();
            return data;
        }

        public async Task<bool> GetNDMByTen(string Ten)
        {
            bool isSuccess = false;
            using var context = _context.CreateDbContext();
            var query = context.DSNhomDanhMuc
                         .Where(ndm => ndm.Ten.ToUpper() == Ten.ToUpper())
                         .Select(ndm => new NhomDanhMucModel
                         {
                             Id = ndm.Id,
                             Ten = ndm.Ten,
                             CreateAt = ndm.CreateAt,
                             CreateBy = ndm.CreateBy,
                             IsActive = ndm.IsActive,
                         });

            var data = await query.ToListAsync();

            // Kiểm tra nếu danh sách kết quả rỗng hoặc không có dữ liệu khớp
            isSuccess = data.Any();
            return (isSuccess);
        }

        public async Task Update(NhomDanhMuc NhomDanhMuc, string userId)
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

        public async Task UpdateMulti(NhomDanhMuc[] NhomDanhMuc)
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

        public async Task DeleteById(string id, string userId)
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


        public async Task<NhomDanhMuc> GetById(string id)
        {
            using var context = _context.CreateDbContext();
            var entity = await context.DSNhomDanhMuc.Where(x => x.Id.Equals(id)).FirstOrDefaultAsync();

            if (entity == null)
            {
                throw new Exception($"Không tìm thấy bản ghi theo ID: {id}");
            }

            return entity;
        }


        public async Task Insert(NhomDanhMuc entity, string userId)
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
