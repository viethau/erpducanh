using DucAnhERP.Data;
using DucAnhERP.Models;
using DucAnhERP.Models.BoiThuong;
using DucAnhERP.Repository.BoiThuong;
using DucAnhERP.ViewModel;
using DucAnhERP.ViewModel.BoiThuong;

using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DucAnhERP.Services.BoiThuong
{
    public class DM_QDTGPMBNhanhGocRepository : IDM_QDTGPMBNhanhGocRepository
    {
        private readonly IDbContextFactory<ApplicationDbContext> _context;
        public DM_QDTGPMBNhanhGocRepository(IDbContextFactory<ApplicationDbContext> context)
        {
            _context = context;
        }
        public async Task<List<DMPABTModel>> GetByVM(string groupId)
        {
            using var context = _context.CreateDbContext();
            var query = from p1 in context.BT_DM_QDTGPMBNhanhGocs
                        where p1.IsActive != 100
                        select p1;

            var data = await (from p1 in query
                              join chinhanh in context.ChiNhanhs on p1.CompanyId equals chinhanh.Id
                              where p1.CompanyId == groupId
                              orderby p1.CreateAt descending
                              select new DMPABTModel
                              {
                                  Id = p1.Id,
                                  CompanyId = p1.CompanyId,
                                  CompanyName = chinhanh.TenChiNhanh,
                                  SoQD = p1.SoQDThuongGPMBNhanhGoc,
                                  NTN = p1.NTNGPMBNhanhGoc.HasValue ? p1.NTNGPMBNhanhGoc.Value : DateTime.MinValue,
                                  CreateAt = p1.CreateAt,
                                  CreateBy = p1.CreateBy,
                                  IsActive = p1.IsActive,
                              }).ToListAsync();
            return data;
        }
        public async Task<List<BT_DM_QDTGPMBNhanhGoc>> GetAll(string groupId)
        {
            try
            {
                using var context = _context.CreateDbContext();
                var entity = await context.BT_DM_QDTGPMBNhanhGocs.Where(p => p.IsActive != 100).ToListAsync();
                return entity;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"An error occurred: {ex.Message}");
                throw;
            }
        }
        public async Task<BT_DM_QDTGPMBNhanhGoc> GetById(string id)
        {
            using var context = _context.CreateDbContext();
            var entity = await context.BT_DM_QDTGPMBNhanhGocs.Where(x => x.Id.Equals(id) && x.IsActive != 100).FirstOrDefaultAsync();
            if (entity == null)
            {
                throw new Exception($"Không tìm thấy Id");
            }
            return entity;
        }

        public async Task<bool> CheckExist(string id, string loaiChungTu)
        {
            using var context = _context.CreateDbContext();
            return await context.BT_DM_QDTGPMBNhanhGocs
                .AnyAsync(x => x.SoQDThuongGPMBNhanhGoc.ToLower() == loaiChungTu.ToLower() && x.Id != id);
        }
        public async Task<bool> IsIdInUse(string id)
        {
            using var context = _context.CreateDbContext();
            // Kiểm tra xem Id có đang được sử dụng trong bảng khác hay không
            // Ví dụ: kiểm tra trong bảng `SomeOtherTable`
            //bool isInUse = await context.SomeOtherTable.AnyAsync(x => x.QDBoiThuongGocId == id);
            return false;
        }


        public async Task Insert(BT_DM_QDTGPMBNhanhGoc entity, string userId)
        {
            try
            {
                using var context = _context.CreateDbContext();
                if (entity == null)
                {
                    throw new Exception("Thêm không thành công!");
                }
                context.BT_DM_QDTGPMBNhanhGocs.Add(entity);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        public async Task Update(BT_DM_QDTGPMBNhanhGoc data, string userId)
        {
            using var context = _context.CreateDbContext();
            var entity = GetById(data.Id);
            if (entity == null)
            {
                throw new Exception($"Không tìm thấy Id !");
            }
            context.BT_DM_QDTGPMBNhanhGocs.Update(data);
            await context.SaveChangesAsync();
        }
        public async Task UpdateMulti(BT_DM_QDTGPMBNhanhGoc[] BT_DM_QDTGPMBNhanhGocs)
        {
            using var context = _context.CreateDbContext();
            string[] ids = BT_DM_QDTGPMBNhanhGocs.Select(x => x.Id).ToArray();
            var listEntities = await context.BT_DM_QDTGPMBNhanhGocs.Where(x => ids.Contains(x.Id)).ToListAsync();
            foreach (var entity in listEntities)
            {
                context.BT_DM_QDTGPMBNhanhGocs.Update(entity);
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
            context.Set<BT_DM_QDTGPMBNhanhGoc>().Remove(entity);
            await context.SaveChangesAsync();
        }
        public async Task<bool> CheckStatus(string ids, string name)
        {
            using var context = _context.CreateDbContext();
            var model = await context.BT_DM_QDTGPMBNhanhGocs.Where(p => p.Id == ids).FirstOrDefaultAsync();
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
