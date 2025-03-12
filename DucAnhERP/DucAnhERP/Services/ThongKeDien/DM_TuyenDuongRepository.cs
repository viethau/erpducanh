using DucAnhERP.Data;
using DucAnhERP.Models.ThongKeDien;
using DucAnhERP.Repository.BoiThuong;
using DucAnhERP.ViewModel.ThongKeDien;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DucAnhERP.Services.BoiThuong
{
    public class DM_TuyenDuongRepository : ID_DM_TuyenDuongRepository
    {
        private readonly IDbContextFactory<ApplicationDbContext> _context;
        public DM_TuyenDuongRepository(IDbContextFactory<ApplicationDbContext> context)
        {
            _context = context;
        }
        public async Task<List<DM_TuyenDuongModel>> GetByVM(string groupId, DM_TuyenDuongModel input)
        {
            using var context = _context.CreateDbContext();
            var query = from p1 in context.D_DM_TuyenDuongs
                        where p1.IsActive != 100
                        select p1;

            var result = from p1 in query
                              join chinhanh in context.ChiNhanhs on p1.CompanyId equals chinhanh.Id
                              where p1.CompanyId == groupId
                              orderby p1.CreateAt descending
                              select new DM_TuyenDuongModel
                              {
                                  Id = p1.Id,
                                  CompanyId = p1.CompanyId,
                                  CompanyName = chinhanh.TenChiNhanh,
                                  TuyenDuong =p1.TuyenDuong,
                                  TuCot = p1.TuCot,
                                  DenCot = p1.DenCot,
                                  TuLyTrinh = p1.TuLyTrinh,
                                  DenLyTrinh = p1.DenLyTrinh,
                                  ToaDoX = p1.ToaDoX,
                                  ToaDoY = p1.ToaDoY,
                                  CreateAt = p1.CreateAt,
                                  CreateBy = p1.CreateBy,
                                  IsActive = p1.IsActive,
                              };
            if (!string.IsNullOrEmpty(input.TuyenDuong))
            {
                result = result.Where(x => x.TuyenDuong == input.TuyenDuong);
            }
            if (!string.IsNullOrEmpty(input.TuCot))
            {
                result = result.Where(x => x.TuCot == input.TuCot);
            }
            if (!string.IsNullOrEmpty(input.DenCot))
            {
                result = result.Where(x => x.DenCot == input.DenCot);
            }
            if (!string.IsNullOrEmpty(input.TuLyTrinh))
            {
                result = result.Where(x => x.TuLyTrinh == input.TuLyTrinh);
            }
            if (!string.IsNullOrEmpty(input.DenLyTrinh))
            {
                result = result.Where(x => x.DenLyTrinh == input.DenLyTrinh);
            } 
            if (!string.IsNullOrEmpty(input.ToaDoX))
            {
                result = result.Where(x => x.ToaDoX == input.ToaDoX);
            }
            if (!string.IsNullOrEmpty(input.ToaDoY))
            {
                result = result.Where(x => x.ToaDoY == input.ToaDoY);
            }

            var data = await result.ToListAsync();
            return data;
        }
        public async Task<List<D_DM_TuyenDuong>> GetAll(string groupId)
        {
            try
            {
                using var context = _context.CreateDbContext();
                var entity = await context.D_DM_TuyenDuongs.Where(p => p.IsActive != 100).ToListAsync();
                return entity;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"An error occurred: {ex.Message}");
                throw;
            }
        }
        public async Task<D_DM_TuyenDuong> GetById(string id)
        {
            using var context = _context.CreateDbContext();
            var entity = await context.D_DM_TuyenDuongs.Where(x => x.Id.Equals(id) && x.IsActive != 100).FirstOrDefaultAsync();
            if (entity == null)
            {
                throw new Exception($"Không tìm thấy Id");
            }
            return entity;
        }
        public async Task<bool> CheckExist(string id, D_DM_TuyenDuong input)
        {
            using var context = _context.CreateDbContext();
            return await context.D_DM_TuyenDuongs
                .AnyAsync(x => x.Id != id &&
                               x.CompanyId == input.CompanyId &&
                               x.TuyenDuong == input.TuyenDuong &&
                               x.TuCot == input.TuCot &&
                               x.DenCot == input.DenCot &&
                               x.TuLyTrinh == input.TuLyTrinh &&
                               x.DenLyTrinh == input.DenLyTrinh &&
                               x.ToaDoX == input.ToaDoX &&
                               x.ToaDoY == input.ToaDoY
                               );
        }
        public async Task<bool> IsIdInUse(string id)
        {
            using var context = _context.CreateDbContext();
            // Kiểm tra xem Id có đang được sử dụng trong bảng khác hay không
            // Ví dụ: kiểm tra trong bảng `SomeOtherTable`
            //bool isInUse = await context.SomeOtherTable.AnyAsync(x => x.QDBoiThuongGocId == id);
            return false;
        }
        public async Task Insert(D_DM_TuyenDuong entity, string userId)
        {
            try
            {
                using var context = _context.CreateDbContext();
                if (entity == null)
                {
                    throw new Exception("Thêm không thành công!");
                }
                context.D_DM_TuyenDuongs.Add(entity);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        public async Task Update(D_DM_TuyenDuong data, string userId)
        {
            using var context = _context.CreateDbContext();
            var entity = GetById(data.Id);
            if (entity == null)
            {
                throw new Exception($"Không tìm thấy Id !");
            }
            context.D_DM_TuyenDuongs.Update(data);
            await context.SaveChangesAsync();
        }
        public async Task UpdateMulti(D_DM_TuyenDuong[] D_DM_TuyenDuongs)
        {
            using var context = _context.CreateDbContext();
            string[] ids = D_DM_TuyenDuongs.Select(x => x.Id).ToArray();
            var listEntities = await context.D_DM_TuyenDuongs.Where(x => ids.Contains(x.Id)).ToListAsync();
            foreach (var entity in listEntities)
            {
                context.D_DM_TuyenDuongs.Update(entity);
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
            context.Set<D_DM_TuyenDuong>().Remove(entity);
            await context.SaveChangesAsync();
        }
        public async Task<bool> CheckStatus(string ids, string name)
        {
            using var context = _context.CreateDbContext();
            var model = await context.D_DM_TuyenDuongs.Where(p => p.Id == ids).FirstOrDefaultAsync();
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
