using DucAnhERP.Data;
using DucAnhERP.Models.ThongKeDien;
using DucAnhERP.Repository.BoiThuong;
using DucAnhERP.ViewModel.ThongKeDien;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DucAnhERP.Services.BoiThuong
{
    public class D_TTLDienCDienRepository : ID_TTLDienCDienRepository
    {
        private readonly IDbContextFactory<ApplicationDbContext> _context;
        public D_TTLDienCDienRepository(IDbContextFactory<ApplicationDbContext> context)
        {
            _context = context;
        }
        public async Task<List<D_TTLDienCDienModel>> GetByVM(string groupId, D_TTLDienCDienModel input)
        {
            List<D_TTLDienCDienModel> data = new();
            try
            {
                using var context = _context.CreateDbContext();
                var query = from p1 in context.D_TTLDienCDiens
                            where p1.IsActive != 100
                            select p1;

                var result = from p1 in query
                             join chinhanh in context.ChiNhanhs on p1.CompanyId equals chinhanh.Id
                             join tuyenduong in context.D_DM_TuyenDuongs on p1.Id_DM_TuyenDuong equals tuyenduong.Id
                             join tudien in context.D_DM_LoaiKLs on p1.Id_DM_TuDien equals tudien.Id
                             join bulong in context.D_DM_LoaiKLs on p1.Id_DM_BuLong equals bulong.Id
                             join tiepdia in context.D_DM_LoaiKLs on p1.Id_DM_TiepDia equals tiepdia.Id
                             join bongden in context.D_DM_LoaiKLs on p1.Id_DM_BongDen equals bongden.Id
                             join dayden in context.D_DM_LoaiKLs on p1.Id_DM_DayDen equals dayden.Id
                             where p1.CompanyId == groupId
                             orderby p1.CreateAt descending
                             select new D_TTLDienCDienModel
                             {
                                 Id = p1.Id,
                                 CompanyId = p1.CompanyId,
                                 CompanyName = chinhanh.TenChiNhanh,

                                 Id_DM_TuyenDuong = p1.Id_DM_TuyenDuong,
                                 TuyenDuong = tuyenduong.TuyenDuong,
                                 TuCot = tuyenduong.TuCot,
                                 DenCot = tuyenduong.DenCot,
                                 TuLyTrinh = tuyenduong.TuLyTrinh,
                                 DenLyTrinh = tuyenduong.DenLyTrinh,
                                 Id_DM_TuDien = p1.Id_DM_TuDien,
                                 DM_TuDien = tudien.LoaiKhoiLuong,
                                 LoaiCotTu = p1.LoaiCotTu,
                                 Id_DM_BuLong = p1.Id_DM_BuLong,
                                 DM_BuLong = bulong.LoaiKhoiLuong,
                                 LoaiBulong = p1.LoaiBulong,
                                 Id_DM_TiepDia = p1.Id_DM_TiepDia,
                                 DM_TiepDia = tiepdia.LoaiKhoiLuong,
                                 TiepDiaCot = p1.TiepDiaCot,
                                 Id_DM_BongDen = p1.Id_DM_BongDen,
                                 DM_BongDen = bongden.LoaiKhoiLuong,
                                 LoaiBongDen = p1.LoaiBongDen,
                                 SLBongDen = p1.SLBongDen,
                                 Id_DM_DayDen = p1.Id_DM_DayDen,
                                 DM_DayDen = dayden.LoaiKhoiLuong,
                                 LoaiDayDien = p1.LoaiDayDien,
                                 CDaiDay = p1.CDaiDay,

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
                if (!string.IsNullOrEmpty(input.TuLyTrinh))
                {
                    result = result.Where(x => x.TuLyTrinh == input.TuLyTrinh);
                }

                if (!string.IsNullOrEmpty(input.Id_DM_TuDien))
                {
                    result = result.Where(x => x.Id_DM_TuDien == input.Id_DM_TuDien);
                }
                if (!string.IsNullOrEmpty(input.Id_DM_BuLong))
                {
                    result = result.Where(x => x.Id_DM_BuLong == input.Id_DM_BuLong);
                }
                if (!string.IsNullOrEmpty(input.Id_DM_BongDen))
                {
                    result = result.Where(x => x.Id_DM_BongDen == input.Id_DM_BongDen);
                }
                if (!string.IsNullOrEmpty(input.Id_DM_DayDen))
                {
                    result = result.Where(x => x.Id_DM_DayDen == input.Id_DM_DayDen);
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
        public async Task<List<D_TTLDienCDien>> GetAll(string groupId)
        {
            try
            {
                using var context = _context.CreateDbContext();
                var entity = await context.D_TTLDienCDiens.Where(p => p.IsActive != 100).ToListAsync();
                return entity;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"An error occurred: {ex.Message}");
                throw;
            }
        }
        public async Task<D_TTLDienCDien> GetById(string id)
        {
            using var context = _context.CreateDbContext();
            var entity = await context.D_TTLDienCDiens.Where(x => x.Id.Equals(id) && x.IsActive != 100).FirstOrDefaultAsync();
            if (entity == null)
            {
                throw new Exception($"Không tìm thấy Id");
            }
            return entity;
        }
        public async Task<bool> CheckExist(string id, D_TTLDienCDien input)
        {
            using var context = _context.CreateDbContext();
            return await context.D_TTLDienCDiens
                .AnyAsync(x => x.Id != id &&
                               x.CompanyId == input.CompanyId &&
                               x.Id_DM_TuyenDuong == input.Id_DM_TuyenDuong &&
                               x.Id_DM_TuDien == input.Id_DM_TuDien &&
                               x.LoaiCotTu == input.LoaiCotTu &&
                               x.Id_DM_BuLong == input.Id_DM_BuLong &&
                               x.LoaiBulong == input.LoaiBulong &&
                               x.Id_DM_TiepDia == input.Id_DM_TiepDia &&
                               x.TiepDiaCot == input.TiepDiaCot &&
                               x.Id_DM_BongDen == input.Id_DM_BongDen &&
                               x.LoaiBongDen == input.LoaiBongDen &&
                               x.SLBongDen == input.SLBongDen &&
                               x.Id_DM_DayDen == input.Id_DM_DayDen &&
                               x.LoaiDayDien == input.LoaiDayDien &&
                               x.CDaiDay == input.CDaiDay &&
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
        public async Task Insert(D_TTLDienCDien entity, string userId)
        {
            try
            {
                using var context = _context.CreateDbContext();
                if (entity == null)
                {
                    throw new Exception("Thêm không thành công!");
                }
                context.D_TTLDienCDiens.Add(entity);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        public async Task Update(D_TTLDienCDien data, string userId)
        {
            using var context = _context.CreateDbContext();
            var entity = GetById(data.Id);
            if (entity == null)
            {
                throw new Exception($"Không tìm thấy Id !");
            }
            context.D_TTLDienCDiens.Update(data);
            await context.SaveChangesAsync();
        }
        public async Task UpdateMulti(D_TTLDienCDien[] D_TTLDienCDiens)
        {
            using var context = _context.CreateDbContext();
            string[] ids = D_TTLDienCDiens.Select(x => x.Id).ToArray();
            var listEntities = await context.D_TTLDienCDiens.Where(x => ids.Contains(x.Id)).ToListAsync();
            foreach (var entity in listEntities)
            {
                context.D_TTLDienCDiens.Update(entity);
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
            context.Set<D_TTLDienCDien>().Remove(entity);
            await context.SaveChangesAsync();
        }
        public async Task<bool> CheckStatus(string ids, string name)
        {
            using var context = _context.CreateDbContext();
            var model = await context.D_TTLDienCDiens.Where(p => p.Id == ids).FirstOrDefaultAsync();
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
