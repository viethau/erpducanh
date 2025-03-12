using DucAnhERP.Data;
using Microsoft.EntityFrameworkCore;
using DucAnhERP.Models.QLNV;
using DucAnhERP.ViewModel.QLNV;
using DucAnhERP.Repository.QLNV;

namespace DucAnhERP.Services.QLNV
{
    public class QLNV_QuanLyNhanVienRepository : IQLNV_QuanLyNhanVienRepository
    {
        private readonly IDbContextFactory<ApplicationDbContext> _context;
        public QLNV_QuanLyNhanVienRepository(IDbContextFactory<ApplicationDbContext> context)
        {
            _context = context;
        }
        public async Task<List<QLNV_QuanLyNhanVienModel>> GetByVM(QLNV_QuanLyNhanVienModel input)
        {
            List<QLNV_QuanLyNhanVienModel> data = new();
            try
            {
                using var context = _context.CreateDbContext();
                var query = from p1 in context.QLNV_QuanLyNhanViens
                            where p1.IsActive != 100
                            select p1;

                var result = from p1 in query
                             join nv in context.QLNV_NhanViens on p1.Id_NhanVien equals nv.Id
                             join nhom in context.QLNV_NhomNhanViens on p1.Id_NhomNhanVien equals nhom.Id
                             where p1.IsActive != 100
                             orderby p1.CreateAt descending
                             select new QLNV_QuanLyNhanVienModel
                             {
                                 Id = p1.Id,

                                 Id_NhomNhanVien = p1.Id_NhomNhanVien,
                                 TenNhom = nhom.TenNhom,

                                 Id_NhanVien = p1.Id_NhanVien,
                                 TenNhanVien = nv.TenNhanVien,
                                 TaiKhoan = nv.TaiKhoan,
                                 
                                 CreateAt = p1.CreateAt,
                                 CreateBy = p1.CreateBy,
                                 IsActive = p1.IsActive,
                             };

                if (!string.IsNullOrEmpty(input.Id_NhanVien))
                {
                    result = result.Where(x => x.Id_NhanVien == input.Id_NhanVien);
                }
                if (!string.IsNullOrEmpty(input.Id_NhomNhanVien))
                {
                    result = result.Where(x => x.Id_NhomNhanVien == input.Id_NhomNhanVien);
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
        public async Task<List<QLNV_QuanLyNhanVien>> GetAll(string groupId)
        {
            try
            {
                using var context = _context.CreateDbContext();
                var entity = await context.QLNV_QuanLyNhanViens.Where(p => p.IsActive != 100).ToListAsync();
                return entity;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"An error occurred: {ex.Message}");
                throw;
            }
        }
        public async Task<QLNV_QuanLyNhanVien> GetById(string id)
        {
            using var context = _context.CreateDbContext();
            var entity = await context.QLNV_QuanLyNhanViens.Where(x => x.Id.Equals(id) && x.IsActive != 100).FirstOrDefaultAsync();
            if (entity == null)
            {
                throw new Exception($"Không tìm thấy Id");
            }
            return entity;
        }
        public async Task<List<QLNV_QuanLyNhanVienModel>> GetQuanLyNhanVienByNhomAsync(string Id_NhomNhanVien)
        {
            List<QLNV_QuanLyNhanVienModel> data = new();
            try
            {
                using var context = _context.CreateDbContext();

                var result = from qlnv in context.QLNV_QuanLyNhanViens
                             join nhom in context.QLNV_NhomNhanViens on qlnv.Id_NhomNhanVien equals nhom.Id
                             join nv in context.QLNV_NhanViens on qlnv.Id_NhanVien equals nv.Id
                             where  qlnv.Id_NhomNhanVien == Id_NhomNhanVien
                             select new QLNV_QuanLyNhanVienModel
                             {
                                 Id = qlnv.Id,
                                 Id_NhomNhanVien = qlnv.Id_NhomNhanVien,
                                 TenNhom = nhom.TenNhom,
                                 Id_NhanVien = qlnv.Id_NhanVien,
                                 TenNhanVien = nv.TenNhanVien,
                                 TaiKhoan = nv.TaiKhoan,
                                 CreateAt = qlnv.CreateAt,
                                 CreateBy = qlnv.CreateBy,
                                 IsActive = qlnv.IsActive
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



        public async Task<bool> CheckExist(string id, QLNV_QuanLyNhanVien input)
        {
            using var context = _context.CreateDbContext();
            return await context.QLNV_QuanLyNhanViens
                .AnyAsync(x => x.Id != id &&
                               x.Id_NhomNhanVien == input.Id_NhomNhanVien &&
                               x.Id_NhanVien == input.Id_NhanVien
                               );
        }
        public async Task<bool> IsIdInUse(string id)
        {
            using var context = _context.CreateDbContext();
            var item = await GetById(id);
            bool isInUse = await context.QLNV_CongViecs.AnyAsync(x => x.Id_NguoiThucHien == item.Id_NhanVien && x.NhomCongViec == item.Id_NhomNhanVien);
            return isInUse;
        }
        public async Task Insert(QLNV_QuanLyNhanVien entity, string userId)
        {
            try
            {
                using var context = _context.CreateDbContext();
                if (entity == null)
                {
                    throw new Exception("Thêm không thành công!");
                }
                context.QLNV_QuanLyNhanViens.Add(entity);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        public async Task Update(QLNV_QuanLyNhanVien data, string userId)
        {
            using var context = _context.CreateDbContext();
            var entity = GetById(data.Id);
            if (entity == null)
            {
                throw new Exception($"Không tìm thấy Id !");
            }
            context.QLNV_QuanLyNhanViens.Update(data);
            await context.SaveChangesAsync();
        }
        public async Task UpdateMulti(QLNV_QuanLyNhanVien[] QLNV_QuanLyNhanViens)
        {
            using var context = _context.CreateDbContext();
            string[] ids = QLNV_QuanLyNhanViens.Select(x => x.Id).ToArray();
            var listEntities = await context.QLNV_QuanLyNhanViens.Where(x => ids.Contains(x.Id)).ToListAsync();
            foreach (var entity in listEntities)
            {
                context.QLNV_QuanLyNhanViens.Update(entity);
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
            context.Set<QLNV_QuanLyNhanVien>().Remove(entity);
            await context.SaveChangesAsync();
        }
        public async Task<bool> CheckStatus(string ids, string name)
        {
            using var context = _context.CreateDbContext();
            var model = await context.QLNV_QuanLyNhanViens.Where(p => p.Id == ids).FirstOrDefaultAsync();
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
