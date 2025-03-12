using DucAnhERP.Data;
using DucAnhERP.Models.ThongKeDien;
using DucAnhERP.Repository.BoiThuong;
using DucAnhERP.ViewModel.ThongKeDien;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;

namespace DucAnhERP.Services.BoiThuong
{
    public class D_DaoCDienRepository : ID_DaoCDienRepository
    {
        private readonly IDbContextFactory<ApplicationDbContext> _context;
        public D_DaoCDienRepository(IDbContextFactory<ApplicationDbContext> context)
        {
            _context = context;
        }
        public async Task<List<D_DaoCDienModel>> GetByVM(string groupId, D_DaoCDienModel input)
        {
            List<D_DaoCDienModel> data = new();
            try
            {
                using var context = _context.CreateDbContext();
                var query = from p1 in context.D_DaoCDiens
                            where p1.IsActive != 100
                            select p1;

                var result = from p1 in query
                             join chinhanh in context.ChiNhanhs on p1.CompanyId equals chinhanh.Id
                             join tuyenduong in context.D_DM_TuyenDuongs on p1.Id_DM_TuyenDuong.ToString() equals tuyenduong.Id
                             where p1.CompanyId == groupId
                             orderby p1.CreateAt descending
                             select new D_DaoCDienModel
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

                                 HTTKDao = p1.HTTKDao,
                                 DayDao = p1.DayDao,
                                 CSauDao = p1.CSauDao,
                                 TiLeMoMai = p1.TiLeMoMai,
                                 SoMaiTrai = p1.SoMaiTrai,
                                 SoMaiPhai = p1.SoMaiPhai,
                                 CDaiDao = p1.CDaiDao,
                                 CRongDayNho = p1.CRongDayNho,
                                 CRongDayLon = p1.CRongDayLon,
                                 DienTich = p1.DienTich,
                                 KLDao = p1.KLDao,

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

                data = await result.ToListAsync();
                return data;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return data;
            }
        }
        public async Task<List<D_DaoCDien>> GetAll(string groupId)
        {
            try
            {
                using var context = _context.CreateDbContext();
                var entity = await context.D_DaoCDiens.Where(p => p.IsActive != 100).ToListAsync();
                return entity;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"An error occurred: {ex.Message}");
                throw;
            }
        }
        public async Task<D_DaoCDien> GetById(string id)
        {
            using var context = _context.CreateDbContext();
            var entity = await context.D_DaoCDiens.Where(x => x.Id.Equals(id) && x.IsActive != 100).FirstOrDefaultAsync();
            if (entity == null)
            {
                throw new Exception($"Không tìm thấy Id");
            }
            return entity;
        }
        public async Task<bool> CheckExist(string id, D_DaoCDien input)
        {
            using var context = _context.CreateDbContext();
            return await context.D_DaoCDiens
                .AnyAsync(x => x.Id != id &&
                               x.CompanyId == input.CompanyId &&
                               x.Id_DM_TuyenDuong == input.Id_DM_TuyenDuong &&
                               x.HTTKDao == input.HTTKDao &&
                                x.DayDao == input.DayDao &&
                                x.CSauDao == input.CSauDao &&
                                x.TiLeMoMai == input.TiLeMoMai &&
                                x.SoMaiTrai == input.SoMaiTrai &&
                                x.SoMaiPhai == input.SoMaiPhai &&
                                x.CDaiDao == input.CDaiDao &&
                                x.CRongDayNho == input.CRongDayNho &&
                                x.CRongDayLon == input.CRongDayLon &&
                                x.DienTich == input.DienTich &&
                                x.KLDao == input.KLDao
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
        public async Task Insert(D_DaoCDien entity, string userId)
        {
            try
            {
                using var context = _context.CreateDbContext();
                if (entity == null)
                {
                    throw new Exception("Thêm không thành công!");
                }
                context.D_DaoCDiens.Add(entity);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        public async Task Update(D_DaoCDien data, string userId)
        {
            using var context = _context.CreateDbContext();
            var entity = GetById(data.Id);
            if (entity == null)
            {
                throw new Exception($"Không tìm thấy Id !");
            }
            context.D_DaoCDiens.Update(data);
            await context.SaveChangesAsync();
        }
        public async Task UpdateMulti(D_DaoCDien[] D_DaoCDiens)
        {
            using var context = _context.CreateDbContext();
            string[] ids = D_DaoCDiens.Select(x => x.Id).ToArray();
            var listEntities = await context.D_DaoCDiens.Where(x => ids.Contains(x.Id)).ToListAsync();
            foreach (var entity in listEntities)
            {
                context.D_DaoCDiens.Update(entity);
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
            context.Set<D_DaoCDien>().Remove(entity);
            await context.SaveChangesAsync();
        }
        public async Task<bool> CheckStatus(string ids, string name)
        {
            using var context = _context.CreateDbContext();
            var model = await context.D_DaoCDiens.Where(p => p.Id == ids).FirstOrDefaultAsync();
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
