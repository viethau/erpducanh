using DucAnhERP.Data;
using DucAnhERP.Models;
using DucAnhERP.Repository.BoiThuong;
using DucAnhERP.ViewModel;
using DucAnhERP.ViewModel.BoiThuong;
using DucAnhERP.ViewModel.NghiepVuCongTrinh;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DucAnhERP.Services.BoiThuong
{
    public class LoaiChungTuRepository : ILoaiChungTuRepository
    {
        private readonly IDbContextFactory<ApplicationDbContext> _context;
        public LoaiChungTuRepository(IDbContextFactory<ApplicationDbContext> context)
        {
            _context = context;
        }
        public async Task<List<DMThuChiModel>> GetByVM()
        {
            List<DMThuChiModel> result = new();
            using var context = _context.CreateDbContext();
            var query = from dm in context.BT_DM_LoaiChungTus
                        orderby dm.CreateAt descending
                        select new DMThuChiModel
                        {
                            Id = dm.Id,
                            Ten = dm.LoaiChungTu,
                            CreateAt = dm.CreateAt,
                            CreateBy = dm.CreateBy,
                            IsActive = dm.IsActive,
                        };

            result = await query.ToListAsync();
            return result;
        }
        public async Task<List<BT_DM_LoaiChungTu>> GetAll(string groupId)
        {
            try
            {
                using var context = _context.CreateDbContext();
                var entity = await context.BT_DM_LoaiChungTus.Where(p => p.IsActive != 100).ToListAsync();
                return entity;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"An error occurred: {ex.Message}");
                throw;
            }
        }
        public async Task<BT_DM_LoaiChungTu> GetById(string id)
        {
            using var context = _context.CreateDbContext();
            var entity = await context.BT_DM_LoaiChungTus.Where(x => x.Id.Equals(id) && x.IsActive != 100).FirstOrDefaultAsync();
            if (entity == null)
            {
                throw new Exception($"Không tìm thấy xã đã chọn.");
            }
            return entity;
        }
        public async Task Insert(BT_DM_LoaiChungTu entity, string userId)
        {
            try
            {
                using var context = _context.CreateDbContext();
                if (entity == null)
                {
                    throw new Exception("Không có xã nào được thêm!");
                }
                context.BT_DM_LoaiChungTus.Add(entity);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        public async Task Update(BT_DM_LoaiChungTu data, string userId)
        {
            using var context = _context.CreateDbContext();
            var entity = GetById(data.Id);
            if (entity == null)
            {
                throw new Exception($"Không tìm thấy xã đã chọn");
            }
            context.BT_DM_LoaiChungTus.Update(data);
            await context.SaveChangesAsync();
        }
        public async Task UpdateMulti(BT_DM_LoaiChungTu[] BT_DM_LoaiChungTus)
        {
            using var context = _context.CreateDbContext();
            string[] ids = BT_DM_LoaiChungTus.Select(x => x.Id).ToArray();
            var listEntities = await context.BT_DM_LoaiChungTus.Where(x => ids.Contains(x.Id)).ToListAsync();
            foreach (var entity in listEntities)
            {
                context.BT_DM_LoaiChungTus.Update(entity);
            }
            await context.SaveChangesAsync();
        }
        public async Task DeleteById(string id, string userId)
        {
            using var context = _context.CreateDbContext();
            var entity = await GetById(id);
            if (entity == null)
            {
                throw new Exception($"Không tìm thấy xã đã chọn");
            }
            context.Set<BT_DM_LoaiChungTu>().Remove(entity);
            await context.SaveChangesAsync();
        }
        public async Task<bool> CheckStatus(string ids, string name)
        {
            using var context = _context.CreateDbContext();
            var model = await context.BT_DM_LoaiChungTus.Where(p => p.Id == ids).FirstOrDefaultAsync();
            if (model == null)
            {
                throw new Exception($"Không tìm thấy xã đã chọn");
            }
            if (model != null && model.IsActive == 0)
            {
                throw new Exception($"Xã đang chờ duyệt thêm mới.");
            }
            if (model != null && model.IsActive == 1)
            {
                throw new Exception($"Xã đang chờ duyệt sửa.");
            }
            if (model != null && model.IsActive == 2)
            {
                throw new Exception($"Xã đang chờ duyệt xóa.");
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
                    throw new Exception($"Không tìm thấy xã đã chọn");
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
