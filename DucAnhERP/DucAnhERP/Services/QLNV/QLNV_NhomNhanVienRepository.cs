using DucAnhERP.Data;
using DucAnhERP.Models.QLNV;
using DucAnhERP.Repository.QLNV;
using DucAnhERP.ViewModel.QLNV;
using Microsoft.EntityFrameworkCore;

namespace DucAnhERP.Services.QLNV
{
    public class QLNV_NhomNhanVienRepository : IQLNV_NhomNhanVienRepository
    {
        private readonly IDbContextFactory<ApplicationDbContext> _context;
        public QLNV_NhomNhanVienRepository(IDbContextFactory<ApplicationDbContext> context)
        {
            _context = context;
        }
        public async Task<List<QLNV_NhomNhanVienModel>> GetByVM(QLNV_NhomNhanVienModel input)
        {
            List<QLNV_NhomNhanVienModel> data = new();
            try
            {
                using var context = _context.CreateDbContext();
                var query = from p1 in context.QLNV_NhomNhanViens
                            where p1.IsActive != 100
                            select p1;

                var result = from p1 in query
                             join nv in context.QLNV_NhanViens on p1.Id_QuanLy equals nv.Id
                             where p1.IsActive != 100
                             orderby p1.CreateAt descending
                             select new QLNV_NhomNhanVienModel
                             {
                                 Id = p1.Id,

                                 Id_QuanLy = p1.Id_QuanLy,
                                 TenNhanVien = nv.TenNhanVien,
                                 TaiKhoan = nv.TaiKhoan,
                                 TenNhom = p1.TenNhom,

                                 CreateAt = p1.CreateAt,
                                 CreateBy = p1.CreateBy,
                                 IsActive = p1.IsActive,
                             };

                if (!string.IsNullOrEmpty(input.TenNhanVien))
                {
                    result = result.Where(x => x.TenNhanVien == input.TenNhanVien);
                }
                if (!string.IsNullOrEmpty(input.TaiKhoan))
                {
                    result = result.Where(x => x.TaiKhoan == input.TaiKhoan);
                }

                data = await result.ToListAsync();
                return data;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return data;
            }
        }
        public async Task<List<QLNV_NhomNhanVien>> GetAll(string groupId)
        {
            try
            {
                using var context = _context.CreateDbContext();
                var entity = await context.QLNV_NhomNhanViens.Where(p => p.IsActive != 100).ToListAsync();
                return entity;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"An error occurred: {ex.Message}");
                throw;
            }
        }
        public async Task<QLNV_NhomNhanVien> GetById(string id)
        {
            using var context = _context.CreateDbContext();
            var entity = await context.QLNV_NhomNhanViens.Where(x => x.Id.Equals(id) && x.IsActive != 100).FirstOrDefaultAsync();
            if (entity == null)
            {
                throw new Exception($"Không tìm thấy Id");
            }
            return entity;
        }
        public async Task<List<QLNV_NhomNhanVien>> GetNhomNhanVienByTaiKhoanAsync(string taiKhoan)
        {
            List<QLNV_NhomNhanVien> data = new();
            try
            {
                using var context = _context.CreateDbContext();

                var result = from a in context.QLNV_NhanViens
                             join nnv in context.QLNV_NhomNhanViens on a.Id equals nnv.Id_QuanLy
                             where a.TaiKhoan.ToUpper() == taiKhoan.ToUpper().Trim()
                                   && a.IsActive != 100
                                   && nnv.IsActive != 100
                             select nnv;

                data = await result.ToListAsync();
                return data;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"An error occurred: {ex.Message}");
                return data;
            }
        }

        public async Task<bool> CheckExist(string id, QLNV_NhomNhanVien input)
        {
            using var context = _context.CreateDbContext();
            return await context.QLNV_NhomNhanViens
                .AnyAsync(x => x.Id != id &&
                               x.TenNhom == input.TenNhom 
                               );
        }
        public async Task<bool> IsIdInUse(string id)
        {
            using var context = _context.CreateDbContext();

            bool isInUse = await context.QLNV_QuanLyNhanViens.AnyAsync(x => x.Id_NhomNhanVien == id) ||
                           await context.QLNV_CongViecs.AnyAsync(x => x.NhomCongViec == id);

            return isInUse;
        }
        public async Task Insert(QLNV_NhomNhanVien entity, string userId)
        {
            try
            {
                using var context = _context.CreateDbContext();
                if (entity == null)
                {
                    throw new Exception("Thêm không thành công!");
                }
                context.QLNV_NhomNhanViens.Add(entity);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        public async Task Update(QLNV_NhomNhanVien data, string userId)
        {
            using var context = _context.CreateDbContext();
            var entity = GetById(data.Id);
            if (entity == null)
            {
                throw new Exception($"Không tìm thấy Id !");
            }
            context.QLNV_NhomNhanViens.Update(data);
            await context.SaveChangesAsync();
        }
        public async Task UpdateMulti(QLNV_NhomNhanVien[] QLNV_NhomNhanViens)
        {
            using var context = _context.CreateDbContext();
            string[] ids = QLNV_NhomNhanViens.Select(x => x.Id).ToArray();
            var listEntities = await context.QLNV_NhomNhanViens.Where(x => ids.Contains(x.Id)).ToListAsync();
            foreach (var entity in listEntities)
            {
                context.QLNV_NhomNhanViens.Update(entity);
            }
            await context.SaveChangesAsync();
        }
        public async Task DeleteById(string id, string userId)
        {
            using var context = _context.CreateDbContext();
            var entity = await GetById(id);
            if (entity == null)
            {
                throw new Exception($"Không tìm thấy Id !");
            }
            context.Set<QLNV_NhomNhanVien>().Remove(entity);
            await context.SaveChangesAsync();
        }
        public async Task<bool> CheckStatus(string ids, string name)
        {
            using var context = _context.CreateDbContext();
            var model = await context.QLNV_NhomNhanViens.Where(p => p.Id == ids).FirstOrDefaultAsync();
            if (model == null)
            {
                throw new Exception($"Không tìm thấy Id !");
            }
            if (model != null && model.IsActive == 0)
            {
                throw new Exception($"Đang chờ duyệt thêm mới.");
            }
            if (model != null && model.IsActive == 1)
            {
                throw new Exception($"Đang chờ duyệt sửa.");
            }
            if (model != null && model.IsActive == 2)
            {
                throw new Exception($"Đang chờ duyệt xóa.");
            }

            return true;
        }
        public async Task<bool> CheckExclusive(string[] ids, DateTime baseTime)
        {
            foreach (var id in ids)
            {
                var model = await GetById(id);
                if (model == null)
                {
                    throw new Exception($"Không tìm thấy Id !");
                }
                if (model.CreateAt > baseTime)
                {
                    throw new Exception($"Thông tin đã bị thay đổi bởi người dùng khác. Vui lòng tải lại trang!");
                }
            }
            return true;
        }
    }
}
