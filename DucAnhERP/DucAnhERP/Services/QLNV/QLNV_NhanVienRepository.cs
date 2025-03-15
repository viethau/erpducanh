using DucAnhERP.Data;
using DucAnhERP.Models.QLNV;
using DucAnhERP.Repository.QLNV;
using DucAnhERP.ViewModel.QLNV;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace DucAnhERP.Services.QLNV
{
    public class QLNV_NhanVienRepository : IQLNV_NhanVienRepository
    {
        private readonly IDbContextFactory<ApplicationDbContext> _context;
        public QLNV_NhanVienRepository(IDbContextFactory<ApplicationDbContext> context)
        {
            _context = context;
        }
        public async Task<List<QLNV_NhanVienModel>> GetByVM(QLNV_NhanVienModel input)
        {
            List<QLNV_NhanVienModel> data = new();
            try
            {
                using var context = _context.CreateDbContext();
                var query = from p1 in context.QLNV_NhanViens
                            where p1.IsActive != 100
                            select p1;

                var result = from p1 in query
                             orderby p1.CreateAt descending
                             select new QLNV_NhanVienModel
                             {
                                 Id = p1.Id,
                                 
                                 TenNhanVien = p1.TenNhanVien,
                                 TaiKhoan = p1.TaiKhoan,
                                 GroupId = p1.GroupId,

                                 CreateAt = p1.CreateAt,
                                 CreateBy = p1.CreateBy,
                                 IsActive = p1.IsActive,
                             };

                if (!string.IsNullOrEmpty(input.GroupId))
                {
                    result = result.Where(x => x.GroupId == input.GroupId);
                }
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
        public async Task<List<QLNV_NhanVien>> GetAll(string groupId)
        {
            try
            {
                using var context = _context.CreateDbContext();
                var entity = await context.QLNV_NhanViens.Where(p => p.IsActive != 100).ToListAsync();
                return entity;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"An error occurred: {ex.Message}");
                throw;
            }
        }
        public async Task<List<QLNV_NhanVien>> GetNhanVienIsQuanLy(bool isQuanLy)
        {
            List<QLNV_NhanVien> data = new();
            try
            {
                using var context = _context.CreateDbContext();

                var result = from p1 in context.QLNV_NhanViens
                             join nv in context.QLNV_NhomNhanViens on p1.Id equals nv.Id_QuanLy into gj
                             from subnv in gj.DefaultIfEmpty()
                             where p1.IsActive != 100 &&
                                   ((isQuanLy == true && subnv != null) || (isQuanLy == false && subnv == null))
                             orderby p1.CreateAt descending
                             select new QLNV_NhanVien
                             {
                                 Id = p1.Id,
                                 TenNhanVien = p1.TenNhanVien,
                                 TaiKhoan = p1.TaiKhoan,
                                 CreateAt = p1.CreateAt,
                                 CreateBy = p1.CreateBy,
                                 IsActive = p1.IsActive,
                             };

                data = await result.ToListAsync();
                return data;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"An error occurred: {ex.Message}");
                return data;
            }
        }
        public async Task<List<QLNV_NhanVien>> GetNhanVienByNhom(string Id_NhomNhanVien)
        {
            List<QLNV_NhanVien> data = new();
            try
            {
                using var context = _context.CreateDbContext();

                var result = from a in context.QLNV_QuanLyNhanViens
                             join b in context.QLNV_NhanViens on a.Id_NhanVien equals b.Id
                             join n in context.QLNV_NhomNhanViens on a.Id_NhomNhanVien equals n.Id
                             where a.Id_NhomNhanVien == Id_NhomNhanVien
                             select new QLNV_NhanVien
                             {
                                 Id = a.Id_NhanVien,
                                 TenNhanVien = b.TenNhanVien,
                                 TaiKhoan = b.TaiKhoan
                             };

                data = await result.ToListAsync();
                return data;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"An error occurred: {ex.Message}");
                return data;
            }
        }
        public async Task<List<QLNV_NhanVien>> GetNhanVienNotQL(string Id_NhomNhanVien)
        {
            try
            {
                using var context = _context.CreateDbContext();

                var result = await context.QLNV_NhanViens
                    .Where(nv => !context.QLNV_NhomNhanViens
                        .Where(nnv => nnv.Id == Id_NhomNhanVien)
                        .Select(nnv => nnv.Id_QuanLy)
                        .Contains(nv.Id))
                    .ToListAsync();

                return result;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"An error occurred: {ex.Message}");
                return new List<QLNV_NhanVien>();
            }
        }




        public async Task<QLNV_NhanVien> GetById(string id)
        {
            using var context = _context.CreateDbContext();
            var entity = await context.QLNV_NhanViens.Where(x => x.Id.Equals(id) && x.IsActive != 100).FirstOrDefaultAsync();
            if (entity == null)
            {
                throw new Exception($"Không tìm thấy Id");
            }
            return entity;
        }
        public async Task<bool> CheckExist(string id, QLNV_NhanVien input)
        {
            using var context = _context.CreateDbContext();

            if (string.IsNullOrEmpty(id))
            {
             
                bool a = await context.QLNV_NhanViens
                    .AnyAsync(x => x.TaiKhoan.ToLower() == input.TaiKhoan.ToLower());
                return a;
            }
            return await context.QLNV_NhanViens
                .AnyAsync(x => x.Id != id &&
                               x.TenNhanVien.ToLower() == input.TenNhanVien.ToLower() &&
                               x.TaiKhoan.ToLower() == input.TaiKhoan.ToLower());
        }

        public async Task<bool> IsIdInUse(string id)
        {
            using var context = _context.CreateDbContext();

            bool isInUse = await context.QLNV_CongViecs.AnyAsync(x => x.Id_NguoiThucHien == id) ||
                           await context.QLNV_NhomNhanViens.AnyAsync(x => x.Id_QuanLy == id);

            return isInUse;
        }

        public async Task Insert(QLNV_NhanVien entity, string userId)
        {
            try
            {
                using var context = _context.CreateDbContext();
                if (entity == null)
                {
                    throw new Exception("Thêm không thành công!");
                }
                context.QLNV_NhanViens.Add(entity);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        public async Task Update(QLNV_NhanVien data, string userId)
        {
            using var context = _context.CreateDbContext();
            var entity = GetById(data.Id);
            if (entity == null)
            {
                throw new Exception($"Không tìm thấy Id !");
            }
            context.QLNV_NhanViens.Update(data);
            await context.SaveChangesAsync();
        }
        public async Task UpdateMulti(QLNV_NhanVien[] QLNV_NhanViens)
        {
            using var context = _context.CreateDbContext();
            string[] ids = QLNV_NhanViens.Select(x => x.Id).ToArray();
            var listEntities = await context.QLNV_NhanViens.Where(x => ids.Contains(x.Id)).ToListAsync();
            foreach (var entity in listEntities)
            {
                context.QLNV_NhanViens.Update(entity);
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
            context.Set<QLNV_NhanVien>().Remove(entity);
            await context.SaveChangesAsync();
        }
        public async Task<bool> CheckStatus(string ids, string name)
        {
            using var context = _context.CreateDbContext();
            var model = await context.QLNV_NhanViens.Where(p => p.Id == ids).FirstOrDefaultAsync();
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
