using DucAnhERP.Data;
using DucAnhERP.Models;
using DucAnhERP.Repository;
using DucAnhERP.ViewModel;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace DucAnhERP.Services
{
    public class DanhMucRepository : IDanhMucRepository
    {
        private readonly IDbContextFactory<ApplicationDbContext> _context;

        public DanhMucRepository(IDbContextFactory<ApplicationDbContext> context)
        {
            _context = context;
        }
        public async Task<bool> CheckStatus(string ids, string name)
        {
            return true;

        }
        public async Task<List<DanhMucModel>> GetAllDM(DanhMucModel dm)
        {
            using var context = _context.CreateDbContext();
            var query = from danhMuc in context.DSDanhMuc
                        join nhomDanhMuc in context.DSNhomDanhMuc
                        on danhMuc.IdNhomDanhMuc equals nhomDanhMuc.Id into nhomDanhMucGroup
                        from nhomDanhMuc in nhomDanhMucGroup.DefaultIfEmpty()
                        orderby danhMuc.CreateAt descending
                        select new DanhMucModel
                        {
                            Id = danhMuc.Id,
                            IdNhomDanhMuc = danhMuc.IdNhomDanhMuc,
                            Ten = danhMuc.Ten,
                            TenNhom = nhomDanhMuc != null ? nhomDanhMuc.Ten : "Không xác định", // Tên từ bảng NhomDanhMuc
                            GhiChu = danhMuc.GhiChu != null ? danhMuc.GhiChu : ""
                        };

            if (!string.IsNullOrEmpty(dm.IdNhomDanhMuc))
            {
                query = query.Where(m => m.IdNhomDanhMuc == dm.IdNhomDanhMuc);
            }


            var data = await query
                .OrderBy(dm => dm.Ten)
                .ToListAsync();
            return data;
        }
        public async Task<List<DanhMuc1>> GetDMByIdNhomDanhMuc(string idNhomDanhMuc)
        {
            using var context = _context.CreateDbContext();
            var query = context.DSDanhMuc
                         .Where(danhMuc => danhMuc.IdNhomDanhMuc == idNhomDanhMuc)
                         .Select(danhMuc => new DanhMuc1
                         {
                             Id = danhMuc.Id,
                             IdNhomDanhMuc = danhMuc.IdNhomDanhMuc,
                             Ten = danhMuc.Ten,
                             GhiChu = danhMuc.GhiChu != null ? danhMuc.GhiChu : ""
                         });

            var data = await query.ToListAsync();
            return data;
        }
        public async Task<List<DanhMuc1>> GetDMisExist(string idNhomDanhMuc ,string Ten)
        {
            using var context = _context.CreateDbContext();
            var query = context.DSDanhMuc
                         .Where(danhMuc => danhMuc.IdNhomDanhMuc.ToUpper() == idNhomDanhMuc.ToUpper() && danhMuc.Ten.ToUpper() == Ten.ToUpper())
                         .Select(danhMuc => new DanhMuc1
                         {
                             Id = danhMuc.Id,
                             IdNhomDanhMuc = danhMuc.IdNhomDanhMuc,
                             Ten = danhMuc.Ten,
                             GhiChu = danhMuc.GhiChu != null ? danhMuc.GhiChu : ""
                         });

            var data = await query.ToListAsync();
            return data;
        }
        public async Task<List<DanhMuc1>> GetDMisExistEdit(string Id ,string idNhomDanhMuc, string Ten)
        {
            using var context = _context.CreateDbContext();
            var query = context.DSDanhMuc
                         .Where(danhMuc => danhMuc.Id==Id && danhMuc.IdNhomDanhMuc.ToUpper() == idNhomDanhMuc.ToUpper() && danhMuc.Ten.ToUpper() == Ten.ToUpper())
                         .Select(danhMuc => new DanhMuc1
                         {
                             Id = danhMuc.Id,
                             IdNhomDanhMuc = danhMuc.IdNhomDanhMuc,
                             Ten = danhMuc.Ten,
                             GhiChu = danhMuc.GhiChu != null ? danhMuc.GhiChu : ""
                         });

            var data = await query.ToListAsync();
            return data;
        }
        public async Task<bool> GetDMByTenNhomDanhMuc(string Ten)
        {
            bool isSuccess =false;      
            using var context = _context.CreateDbContext();
            var query = context.DSDanhMuc
                         .Where(danhMuc => danhMuc.Ten.ToUpper() == Ten.ToUpper())
                         .Select(danhMuc => new DanhMuc1
                         {
                             Id = danhMuc.Id,
                             IdNhomDanhMuc = danhMuc.IdNhomDanhMuc,
                             Ten = danhMuc.Ten,
                             GhiChu = danhMuc.GhiChu != null ? danhMuc.GhiChu : ""
                         });

            var data = await query.ToListAsync();

            // Kiểm tra nếu danh sách kết quả rỗng hoặc không có dữ liệu khớp
             isSuccess = data.Any();
            return (isSuccess);
        }
        public async Task<string> GetIdDMByTen(string Ten , string? IdNhomDanhMuc)
        {
            using var context = _context.CreateDbContext();

            if (string.IsNullOrEmpty(IdNhomDanhMuc))
            {
                var id = await context.DSDanhMuc
                      .Where(danhMuc => danhMuc.Ten.ToUpper().Trim() == Ten.ToUpper().Trim())
                      .Select(danhMuc => danhMuc.Id)
                      .FirstOrDefaultAsync();
                return id ?? string.Empty;
            }
            else
            {
                var id = await context.DSDanhMuc
                 .Where(danhMuc =>
                     EF.Functions.Like(danhMuc.Ten.ToLower().Trim(), Ten.ToLower().Trim()) &&
                     EF.Functions.Like(danhMuc.IdNhomDanhMuc.ToLower().Trim(), IdNhomDanhMuc.ToLower().Trim())
                 )
                 .Select(danhMuc => danhMuc.Id)
                 .FirstOrDefaultAsync();
                return id ?? string.Empty;
            }
            
          
            
        }
        public async Task<bool> CheckUsingId(string id)
        {
            bool isSuccess = false;
            using var context = _context.CreateDbContext();
            var query = context.DSHopRanhThang
                         .Where(hrt => (hrt.ThongTinChungHoGa_HinhThucHoGa == id || hrt.ThongTinChungHoGa_KetCauMuMo == id || hrt.ThongTinChungHoGa_KetCauTuong == id || hrt.ThongTinChungHoGa_HinhThucMongHoGa == id ||
                         hrt.ThongTinChungHoGa_KetCauMong == id || hrt.ThongTinChungHoGa_ChatMatTrong == id || hrt.ThongTinChungHoGa_ChatMatNgoai == id || hrt.ThongTinTamDanHoGa2_HinhThucDayHoGa == id ||
                         hrt.ThongTinVatLieuDaoHoGa_LoaiVatLieuDao == id || hrt.ThongTinDuongTruyenDan_HinhThucTruyenDan == id || hrt.ThongTinDuongTruyenDan_LoaiTruyenDan == id || hrt.ThongTinMongDuongTruyenDan_LoaiMong == id ||
                         hrt.ThongTinDeCong_TenLoaiDeCong == id || hrt.ThongTinDeCong_CauTaoDeCong == id || hrt.TTKTHHCongHopRanh_CauTaoTuong == id || hrt.TTKTHHCongHopRanh_CauTaoMuMo == id || hrt.TTKTHHCongHopRanh_ChatMatTrong == id ||
                         hrt.TTKTHHCongHopRanh_ChatMatNgoai == id || hrt.TTKTHHCongHopRanh_CauTaoThanhChong == id || hrt.TTTDCongHoRanh_CauTaoTamDanTruyenDanTamDanTieuChuan == id || hrt.TTTDCongHoRanh_CauTaoTamDanTruyenDan == id ||
                         hrt.TTVLDCongRanh_LoaiVatLieuDao == id));

            var data = await query.ToListAsync();

            // Kiểm tra nếu danh sách kết quả rỗng hoặc không có dữ liệu khớp
            isSuccess = data.Any();
            return (isSuccess);
        }
        public async Task<bool> CheckExistId(string id)
        {
            bool isSuccess = false;
            using var context = _context.CreateDbContext();
            var query = context.DSDanhMuc
                         .Where(danhMuc => danhMuc.Id == id);

            var data = await query.ToListAsync();

            // Kiểm tra nếu danh sách kết quả rỗng hoặc không có dữ liệu khớp
            isSuccess = data.Any();
            return (isSuccess);
        }
        public async Task<List<DanhMuc1>> GetAll(string groupId)
        {
            try
            {
                using var context = _context.CreateDbContext();
                var entity = await context.DSDanhMuc.ToListAsync();
                return entity;
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.Error.WriteLine($"An error occurred: {ex.Message}");
                throw; // Optionally rethrow the exception
            }
        }
        public async Task Update(DanhMuc1 danhmuc, string userId)
        {
            using var context = _context.CreateDbContext();
            var entity = GetById(danhmuc.Id);

            if (entity == null)
            {
                throw new Exception($"Không tìm thấy bản ghi theo ID: {danhmuc.Id}");
            }

            context.DSDanhMuc.Update(danhmuc);
            await context.SaveChangesAsync();
        }
        public async Task UpdateMulti(DanhMuc1[] danhmuc)
        {
            using var context = _context.CreateDbContext();
            string[] ids = danhmuc.Select(x => x.Id).ToArray();
            var listEntities = await context.DSDanhMuc.Where(x => ids.Contains(x.Id)).ToListAsync();
            foreach (var entity in listEntities)
            {
                context.DSDanhMuc.Update(entity);
            }
            await context.SaveChangesAsync();
        }
        public async Task DeleteById(string id, string userId)
        {
            try
            {
                using var context = _context.CreateDbContext();
                var entity = await GetById(id);

                if (entity == null)
                {
                    throw new Exception($"Không tìm thấy bản ghi theo ID: {id}");
                }

                context.Set<DanhMuc1>().Remove(entity);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        public async Task<bool> CheckExclusive(string[] ids, DateTime baseTime)
        {
            foreach (var id in ids)
            {
                var model = await GetById(id);
                if (model == null)
                {
                    throw new Exception($"Không tìm thấy bản ghi theo ID: {id}");
                }
            }
            return true;
        }
        public async Task<DanhMuc1> GetById(string id)
        {
            using var context = _context.CreateDbContext();
            var entity = await context.DSDanhMuc.Where(x => x.Id.Equals(id)).FirstOrDefaultAsync();

            if (entity == null)
            {
                throw new Exception($"Không tìm thấy bản ghi theo ID: {id}");
            }

            return entity;
        }
        public async Task Insert(DanhMuc1 entity, string userId)
        {
            try
            {
                using var context = _context.CreateDbContext();
                if (entity == null)
                {
                    throw new Exception("Không có bản ghi nào để thêm!");
                }

                context.DSDanhMuc.Add(entity);
                await context.SaveChangesAsync();
            }
            catch (Exception ex) { 
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
