using DucAnhERP.Data;
using DucAnhERP.Models.ThongKeDien;
using DucAnhERP.Repository.BoiThuong;
using DucAnhERP.ViewModel.ThongKeDien;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DucAnhERP.Services.BoiThuong
{
    public class D_XDungCDienRepository : ID_XDungCDienRepository
    {
        private readonly IDbContextFactory<ApplicationDbContext> _context;
        public D_XDungCDienRepository(IDbContextFactory<ApplicationDbContext> context)
        {
            _context = context;
        }
        public async Task<List<D_XDungCDienModel>> GetByVM(string groupId, D_XDungCDienModel input)
        {
            using var context = _context.CreateDbContext();
            var query = from p1 in context.D_XDungCDiens
                        where p1.IsActive != 100
                        select p1;

            var result = from p1 in query
                              join chinhanh in context.ChiNhanhs on p1.CompanyId equals chinhanh.Id
                             join tuyenduong in context.D_DM_TuyenDuongs on p1.Id_DM_TuyenDuong equals tuyenduong.Id
                             join kllm_hm in context.D_DM_HangMucKLs on p1.Id_DM_HangMucLotMong equals kllm_hm.Id
                             join klm_hm in context.D_DM_HangMucKLs on p1.ID_DM_HangMucMong equals klm_hm.Id

                             join LoaiKL_LMXD in context.D_DM_LoaiKLs on p1.Id_DM_LoaiKL_LMXD equals LoaiKL_LMXD.Id
                             join LoaiKLLotMong_VK in context.D_DM_LoaiKLs on p1.Id_DM_LoaiKLLotMong_VK equals LoaiKLLotMong_VK.Id
                             join LoaiKL_MXD in context.D_DM_LoaiKLs on p1.Id_DM_LoaiKL_MXD equals LoaiKL_MXD.Id
                             join LoaiKL_VK in context.D_DM_LoaiKLs on p1.Id_DM_LoaiKL_VK equals LoaiKL_VK.Id
                         where p1.CompanyId == groupId
                              orderby p1.CreateAt descending
                              select new D_XDungCDienModel
                              {
                                  Id = p1.Id,
                                  CompanyId = p1.CompanyId,
                                  CompanyName = chinhanh.TenChiNhanh,
                                  TuyenDuong = tuyenduong.TuyenDuong,
                                  TuCot = tuyenduong.TuCot,
                                  DenCot = tuyenduong.DenCot,
                                  TuLyTrinh = tuyenduong.TuLyTrinh,
                                  DenLyTrinh = tuyenduong.DenLyTrinh,

                                  Id_DM_HangMucLotMong = p1.Id_DM_HangMucLotMong,
                                  DM_HangMucLotMong = kllm_hm.Ten,
                                  Id_DM_LoaiKL_LMXD = p1.Id_DM_LoaiKL_LMXD,
                                  DM_LoaiKL_LMXD = LoaiKL_LMXD.LoaiKhoiLuong,
                                  KLLM_XD_Dai = p1.KLLM_XD_Dai,
                                  KLLM_XD_Rong = p1.KLLM_XD_Rong,
                                  KLLM_XD_Cao = p1.KLLM_XD_Cao,
                                  KLLM_XD_KL = p1.KLLM_XD_KL,

                                  Id_DM_LoaiKLLotMong_VK = p1.Id_DM_LoaiKLLotMong_VK,
                                  DM_LoaiKLLotMong_VK = LoaiKLLotMong_VK.LoaiKhoiLuong,
                                  KLLM_VK_SLCD = p1.KLLM_VK_SLCD,
                                  KLLM_VK_SLCR =p1.KLLM_VK_SLCR,
                                  KLLM_VK_KL = p1.KLLM_VK_KL,

                                  ID_DM_HangMucMong = p1.ID_DM_HangMucMong,
                                  DM_HangMucMong = klm_hm.Ten,
                                  Id_DM_LoaiKL_MXD = p1.Id_DM_LoaiKL_MXD,
                                  DM_LoaiKL_MXD = LoaiKL_MXD.LoaiKhoiLuong,
                                  KLM_XD_Dai = p1.KLM_XD_Dai,
                                  KLM_XD_Rong = p1.KLM_XD_Rong,
                                  KLM_XD_Cao =p1.KLM_XD_Cao,
                                  KLM_XD_KL = p1.KLM_XD_KL,

                                  Id_DM_LoaiKL_VK =p1.Id_DM_LoaiKL_VK,
                                  DM_LoaiKL_VK = LoaiKL_VK.LoaiKhoiLuong,
                                  KLM_VK_SLCD = p1.KLM_VK_SLCD,
                                  KLM_VK_SLCR = p1.KLM_VK_SLCR,
                                  KLM_VK_KL =p1.KLM_VK_KL,

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
            var data = await result.ToListAsync();
            return data;
        }
        public async Task<List<D_XDungCDien>> GetAll(string groupId)
        {
            try
            {
                using var context = _context.CreateDbContext();
                var entity = await context.D_XDungCDiens.Where(p => p.IsActive != 100).ToListAsync();
                return entity;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"An error occurred: {ex.Message}");
                throw;
            }
        }
        public async Task<D_XDungCDien> GetById(string id)
        {
            using var context = _context.CreateDbContext();
            var entity = await context.D_XDungCDiens.Where(x => x.Id.Equals(id) && x.IsActive != 100).FirstOrDefaultAsync();
            if (entity == null)
            {
                throw new Exception($"Không tìm thấy Id");
            }
            return entity;
        }
        public async Task<bool> CheckExist(string id, D_XDungCDien input)
        {
            using var context = _context.CreateDbContext();
            return await context.D_XDungCDiens
                .AnyAsync(x => x.Id != id &&
                               x.CompanyId == input.CompanyId &&
                               x.Id_DM_TuyenDuong == input.Id_DM_TuyenDuong &&
                               x.Id_DM_HangMucLotMong == input.Id_DM_HangMucLotMong &&
                               x.Id_DM_LoaiKL_LMXD == input.Id_DM_LoaiKL_LMXD &&
                               x.KLLM_XD_Dai == input.KLLM_XD_Dai &&
                               x.KLLM_XD_Rong == input.KLLM_XD_Rong &&
                               x.KLLM_XD_Cao == input.KLLM_XD_Cao &&
                               x.KLLM_XD_KL == input.KLLM_XD_KL &&
                               x.Id_DM_LoaiKLLotMong_VK == input.Id_DM_LoaiKLLotMong_VK &&
                               x.KLLM_VK_SLCD == input.KLLM_VK_SLCD &&
                               x.KLLM_VK_KL == input.KLLM_VK_KL &&
                               x.ID_DM_HangMucMong == input.ID_DM_HangMucMong &&
                               x.Id_DM_LoaiKL_MXD == input.Id_DM_LoaiKL_MXD &&
                               x.KLM_XD_Dai == input.KLM_XD_Dai &&
                               x.KLM_XD_Rong == input.KLM_XD_Rong &&
                               x.KLM_XD_Cao == input.KLM_XD_Cao &&
                               x.KLM_XD_KL == input.KLM_XD_KL &&
                               x.Id_DM_LoaiKL_VK == input.Id_DM_LoaiKL_VK &&
                               x.KLM_VK_SLCD == input.KLM_VK_SLCD &&
                               x.KLM_VK_SLCR == input.KLM_VK_SLCR &&
                               x.KLM_VK_KL == input.KLM_VK_KL
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
        public async Task Insert(D_XDungCDien entity, string userId)
        {
            try
            {
                using var context = _context.CreateDbContext();
                if (entity == null)
                {
                    throw new Exception("Thêm không thành công!");
                }
                context.D_XDungCDiens.Add(entity);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        public async Task Update(D_XDungCDien data, string userId)
        {
            using var context = _context.CreateDbContext();
            var entity = GetById(data.Id);
            if (entity == null)
            {
                throw new Exception($"Không tìm thấy Id !");
            }
            context.D_XDungCDiens.Update(data);
            await context.SaveChangesAsync();
        }
        public async Task UpdateMulti(D_XDungCDien[] D_XDungCDiens)
        {
            using var context = _context.CreateDbContext();
            string[] ids = D_XDungCDiens.Select(x => x.Id).ToArray();
            var listEntities = await context.D_XDungCDiens.Where(x => ids.Contains(x.Id)).ToListAsync();
            foreach (var entity in listEntities)
            {
                context.D_XDungCDiens.Update(entity);
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
            context.Set<D_XDungCDien>().Remove(entity);
            await context.SaveChangesAsync();
        }
        public async Task<bool> CheckStatus(string ids, string name)
        {
            using var context = _context.CreateDbContext();
            var model = await context.D_XDungCDiens.Where(p => p.Id == ids).FirstOrDefaultAsync();
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
