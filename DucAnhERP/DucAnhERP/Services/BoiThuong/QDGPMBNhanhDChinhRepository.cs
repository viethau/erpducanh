using DucAnhERP.Components.Pages.BoiThuong;
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
    public class QDGPMBNhanhDChinhRepository : IQDGPMBNhanhDChinhRepository
    {
        private readonly IDbContextFactory<ApplicationDbContext> _context;
        public QDGPMBNhanhDChinhRepository(IDbContextFactory<ApplicationDbContext> context)
        {
            _context = context;
        }
        public async Task<List<QDPABTModel>> GetByVM(string groupId , QDPABTModel input)
        {
            using var context = _context.CreateDbContext();
            var query = from p1 in context.BT_QDGPMBNhanhDChinhs
                        where p1.IsActive != 100
                        select p1;

            var result = from p1 in query
                         join chinhanh in context.ChiNhanhs on p1.CompanyId equals chinhanh.Id
                         join dmbt in context.BT_DM_QDTGPMBNhanhGocs on p1.Id_DM_QDTGPMBNhanhGoc equals dmbt.Id
                         where p1.CompanyId == groupId
                         orderby p1.CreateAt descending
                         select new QDPABTModel
                         {
                             Id = p1.Id,
                             CompanyId = p1.CompanyId,
                             CompanyName = chinhanh.TenChiNhanh,
                             Id_DM_QD = p1.Id_DM_QDTGPMBNhanhGoc,
                             SoQD = dmbt.SoQDThuongGPMBNhanhGoc,
                             NTN = dmbt.NTNGPMBNhanhGoc,
                             SoQDDC = p1.SoQDThuongGPMBNhanhDC,
                             NTNDC = p1.NTNDieuChinh,
                             CreateAt = p1.CreateAt,
                             CreateBy = p1.CreateBy,
                             IsActive = p1.IsActive,
                         };
           
            if (!string.IsNullOrEmpty(input.Id_DM_QD))
            {
                result = result.Where(x => x.Id_DM_QD == input.Id_DM_QD);
            }
            if (input.NTN.HasValue && input.NTN.Value != DateTime.MinValue)
            {
                result = result.Where(x => x.NTN == input.NTN);
            }

            if (!string.IsNullOrEmpty(input.SoQDDC))
            {
                result = result.Where(x => x.SoQDDC == input.SoQDDC);
            }
            if (input.NTNDC.HasValue && input.NTNDC.Value != DateTime.MinValue)
            {
                result = result.Where(x => x.NTNDC == input.NTNDC);
            }
            var data = await result.ToListAsync();
            return data;
        }
        public async Task<List<BT_QDGPMBNhanhDChinh>> GetAll(string groupId)
        {
            try
            {
                using var context = _context.CreateDbContext();
                var entity = await context.BT_QDGPMBNhanhDChinhs.Where(p => p.IsActive != 100).ToListAsync();
                return entity;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"An error occurred: {ex.Message}");
                throw;
            }
        }
        public async Task<BT_QDGPMBNhanhDChinh> GetById(string id)
        {
            using var context = _context.CreateDbContext();
            var entity = await context.BT_QDGPMBNhanhDChinhs.Where(x => x.Id.Equals(id) && x.IsActive != 100).FirstOrDefaultAsync();
            if (entity == null)
            {
                throw new Exception($"Không tìm thấy Id");
            }
            return entity;
        }
        public async Task<bool> CheckExist(string id, BT_QDGPMBNhanhDChinh input)
        {
            using var context = _context.CreateDbContext();
            return await context.BT_QDGPMBNhanhDChinhs
                .AnyAsync(x => x.Id != id &&
                               x.CompanyId == input.CompanyId &&
                               x.Id_DM_QDTGPMBNhanhGoc == input.Id_DM_QDTGPMBNhanhGoc &&
                               x.SoQDThuongGPMBNhanhDC == input.SoQDThuongGPMBNhanhDC &&
                               x.NTNDieuChinh == input.NTNDieuChinh
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
        public async Task Insert(BT_QDGPMBNhanhDChinh entity, string userId)
        {
            try
            {
                using var context = _context.CreateDbContext();
                if (entity == null)
                {
                    throw new Exception("Thêm không thành công!");
                }
                context.BT_QDGPMBNhanhDChinhs.Add(entity);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        public async Task Update(BT_QDGPMBNhanhDChinh data, string userId)
        {
            using var context = _context.CreateDbContext();
            var entity = GetById(data.Id);
            if (entity == null)
            {
                throw new Exception($"Không tìm thấy Id !");
            }
            context.BT_QDGPMBNhanhDChinhs.Update(data);
            await context.SaveChangesAsync();
        }
        public async Task UpdateMulti(BT_QDGPMBNhanhDChinh[] BT_QDGPMBNhanhDChinhs)
        {
            using var context = _context.CreateDbContext();
            string[] ids = BT_QDGPMBNhanhDChinhs.Select(x => x.Id).ToArray();
            var listEntities = await context.BT_QDGPMBNhanhDChinhs.Where(x => ids.Contains(x.Id)).ToListAsync();
            foreach (var entity in listEntities)
            {
                context.BT_QDGPMBNhanhDChinhs.Update(entity);
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
            context.Set<BT_QDGPMBNhanhDChinh>().Remove(entity);
            await context.SaveChangesAsync();
        }
        public async Task<bool> CheckStatus(string ids, string name)
        {
            using var context = _context.CreateDbContext();
            var model = await context.BT_QDGPMBNhanhDChinhs.Where(p => p.Id == ids).FirstOrDefaultAsync();
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
