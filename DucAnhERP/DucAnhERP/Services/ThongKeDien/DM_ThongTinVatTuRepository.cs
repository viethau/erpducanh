using DucAnhERP.Data;
using DucAnhERP.Models.ThongKeDien;
using DucAnhERP.Repository.BoiThuong;
using DucAnhERP.ViewModel.ThongKeDien;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DucAnhERP.Services.BoiThuong
{
    public class DM_ThongTinVatTuRepository : ID_DM_ThongTinVatTuRepository
    {
        private readonly IDbContextFactory<ApplicationDbContext> _context;
        public DM_ThongTinVatTuRepository(IDbContextFactory<ApplicationDbContext> context)
        {
            _context = context;
        }
        public async Task<List<DM_ThongTinVatTuModel>> GetByVM(string groupId, DM_ThongTinVatTuModel input)
        {
            using var context = _context.CreateDbContext();
            var query = from p1 in context.D_DM_ThongTinVatTus
                        where p1.IsActive != 100
                        select p1;

            var result = from p1 in query
                              join chinhanh in context.ChiNhanhs on p1.CompanyId equals chinhanh.Id
                              where p1.CompanyId == groupId
                              orderby p1.CreateAt descending
                              select new DM_ThongTinVatTuModel
                              {
                                  Id = p1.Id,
                                  CompanyId = p1.CompanyId,
                                  CompanyName = chinhanh.TenChiNhanh,
                                  TenLoaiVatTu = p1.TenLoaiVatTu,
                                  DonVi = p1.DonVi,
                                  ThongTinLoaiVatTuDien = p1.ThongTinLoaiVatTuDien,
                                  HinhAnh = p1.HinhAnh,
                                  CreateAt = p1.CreateAt,
                                  CreateBy = p1.CreateBy,
                                  IsActive = p1.IsActive,
                              };
            if (!string.IsNullOrEmpty(input.TenLoaiVatTu))
            {
                result = result.Where(x => x.TenLoaiVatTu == input.TenLoaiVatTu);
            }
            if (!string.IsNullOrEmpty(input.DonVi))
            {
                result = result.Where(x => x.DonVi == input.DonVi);
            }
            if (!string.IsNullOrEmpty(input.ThongTinLoaiVatTuDien))
            {
                result = result.Where(x => x.ThongTinLoaiVatTuDien == input.ThongTinLoaiVatTuDien);
            }
            if (!string.IsNullOrEmpty(input.HinhAnh))
            {
                result = result.Where(x => x.HinhAnh == input.HinhAnh);
            }

            var data = await result.ToListAsync();
            return data;
        }
        public async Task<List<D_DM_ThongTinVatTu>> GetAll(string groupId)
        {
            try
            {
                using var context = _context.CreateDbContext();
                var entity = await context.D_DM_ThongTinVatTus.Where(p => p.IsActive != 100).ToListAsync();
                return entity;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"An error occurred: {ex.Message}");
                throw;
            }
        }
        public async Task<D_DM_ThongTinVatTu> GetById(string id)
        {
            using var context = _context.CreateDbContext();
            var entity = await context.D_DM_ThongTinVatTus.Where(x => x.Id.Equals(id) && x.IsActive != 100).FirstOrDefaultAsync();
            if (entity == null)
            {
                throw new Exception($"Không tìm thấy Id");
            }
            return entity;
        }
        public async Task<bool> CheckExist(string id, D_DM_ThongTinVatTu input)
        {
            using var context = _context.CreateDbContext();
            return await context.D_DM_ThongTinVatTus
                .AnyAsync(x => x.Id != id &&
                               x.CompanyId == input.CompanyId &&
                               x.TenLoaiVatTu == input.TenLoaiVatTu &&
                               x.DonVi == input.DonVi &&
                               x.ThongTinLoaiVatTuDien == input.ThongTinLoaiVatTuDien &&
                               x.HinhAnh == input.HinhAnh 
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
        public async Task Insert(D_DM_ThongTinVatTu entity, string userId)
        {
            try
            {
                using var context = _context.CreateDbContext();
                if (entity == null)
                {
                    throw new Exception("Thêm không thành công!");
                }
                context.D_DM_ThongTinVatTus.Add(entity);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        public async Task Update(D_DM_ThongTinVatTu data, string userId)
        {
            using var context = _context.CreateDbContext();
            var entity = GetById(data.Id);
            if (entity == null)
            {
                throw new Exception($"Không tìm thấy Id !");
            }
            context.D_DM_ThongTinVatTus.Update(data);
            await context.SaveChangesAsync();
        }
        public async Task UpdateMulti(D_DM_ThongTinVatTu[] D_DM_ThongTinVatTus)
        {
            using var context = _context.CreateDbContext();
            string[] ids = D_DM_ThongTinVatTus.Select(x => x.Id).ToArray();
            var listEntities = await context.D_DM_ThongTinVatTus.Where(x => ids.Contains(x.Id)).ToListAsync();
            foreach (var entity in listEntities)
            {
                context.D_DM_ThongTinVatTus.Update(entity);
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
            context.Set<D_DM_ThongTinVatTu>().Remove(entity);
            await context.SaveChangesAsync();
        }
        public async Task<bool> CheckStatus(string ids, string name)
        {
            using var context = _context.CreateDbContext();
            var model = await context.D_DM_ThongTinVatTus.Where(p => p.Id == ids).FirstOrDefaultAsync();
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
