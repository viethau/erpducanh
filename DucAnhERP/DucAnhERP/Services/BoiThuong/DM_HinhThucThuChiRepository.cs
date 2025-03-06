using DucAnhERP.Data;
using DucAnhERP.Models;
using DucAnhERP.Repository.BoiThuong;
using DucAnhERP.ViewModel;
using DucAnhERP.ViewModel.BoiThuong;

using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace DucAnhERP.Services.BoiThuong
{
    public class DM_HinhThucThuChiRepository : IDM_HinhThucThuChiRepository
    {
        private readonly IDbContextFactory<ApplicationDbContext> _context;
        public DM_HinhThucThuChiRepository(IDbContextFactory<ApplicationDbContext> context)
        {
            _context = context;
        }
        public async Task<List<DMThuChiModel>> GetByVM(string groupId)
        {
            using var context = _context.CreateDbContext();
            var query = from p1 in context.BT_DM_HTThuChis
                        where p1.IsActive != 100
                        select p1;

            var data = await(from p1 in query
                             join chinhanh in context.ChiNhanhs on p1.CompanyId equals chinhanh.Id
                             where p1.CompanyId == groupId
                             orderby p1.CreateAt descending
                             select new DMThuChiModel
                             {
                                 Id = p1.Id,
                                 CompanyId = p1.CompanyId,
                                 CompanyName = chinhanh.TenChiNhanh,
                                 Ten = p1.HinhThucThuChi,
                                 CreateAt = p1.CreateAt,
                                 CreateBy = p1.CreateBy,
                                 IsActive = p1.IsActive,
                             }).ToListAsync();
                return data;
        }
        public async Task<List<BT_DM_HTThuChi>> GetAll(string groupId)
        {
            try
            {
                using var context = _context.CreateDbContext();
                var entity = await context.BT_DM_HTThuChis.Where(p => p.IsActive != 100).ToListAsync();
                return entity;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"An error occurred: {ex.Message}");
                throw;
            }
        }
        public async Task<BT_DM_HTThuChi> GetById(string id)
        {
            using var context = _context.CreateDbContext();
            var entity = await context.BT_DM_HTThuChis.Where(x => x.Id.Equals(id) && x.IsActive != 100).FirstOrDefaultAsync();
            if (entity == null)
            {
                throw new Exception($"Không tìm thấy Id");
            }
            return entity;
        }

        public async Task<bool> CheckExist(string id, string HinhThucThuChi)
        {
            using var context = _context.CreateDbContext();
            return await context.BT_DM_HTThuChis
                .AnyAsync(x => x.HinhThucThuChi.ToLower() == HinhThucThuChi.ToLower() && x.Id != id);
        }
        public async Task<bool> IsIdInUse(string id)
        {
            using var context = _context.CreateDbContext();
            // Kiểm tra xem Id có đang được sử dụng trong bảng khác hay không
            // Ví dụ: kiểm tra trong bảng `SomeOtherTable`
            //bool isInUse = await context.SomeOtherTable.AnyAsync(x => x.HinhThucThuChiId == id);
            return false;
        }


        public async Task Insert(BT_DM_HTThuChi entity, string userId)
        {
            try
            {
                using var context = _context.CreateDbContext();
                if (entity == null)
                {
                    throw new Exception("Thêm không thành công!");
                }
                context.BT_DM_HTThuChis.Add(entity);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        public async Task Update(BT_DM_HTThuChi data, string userId)
        {
            using var context = _context.CreateDbContext();
            var entity = GetById(data.Id);
            if (entity == null)
            {
                throw new Exception($"Không tìm thấy Id !");
            }
            context.BT_DM_HTThuChis.Update(data);
            await context.SaveChangesAsync();
        }
        public async Task UpdateMulti(BT_DM_HTThuChi[] BT_DM_HTThuChis)
        {
            using var context = _context.CreateDbContext();
            string[] ids = BT_DM_HTThuChis.Select(x => x.Id).ToArray();
            var listEntities = await context.BT_DM_HTThuChis.Where(x => ids.Contains(x.Id)).ToListAsync();
            foreach (var entity in listEntities)
            {
                context.BT_DM_HTThuChis.Update(entity);
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
            context.Set<BT_DM_HTThuChi>().Remove(entity);
            await context.SaveChangesAsync();
        }
        public async Task<bool> CheckStatus(string ids, string name)
        {
            using var context = _context.CreateDbContext();
            var model = await context.BT_DM_HTThuChis.Where(p => p.Id == ids).FirstOrDefaultAsync();
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
