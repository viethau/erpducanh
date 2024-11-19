using DucAnhERP.Data;
using DucAnhERP.Models;
using DucAnhERP.ViewModel;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using DucAnhERP.Repository;

namespace DucAnhERP.Services
{
    public class PKKLCHopRepository : IPKKLCHopRepository
    {
        private readonly IDbContextFactory<ApplicationDbContext> _context;

        public PKKLCHopRepository(IDbContextFactory<ApplicationDbContext> context)
        {
            _context = context;
        }
        public async Task<List<PKKLCHop>> GetAll()
        {
            try
            {
                using var context = _context.CreateDbContext();
                var entity = await context.PKKLCHops.ToListAsync();
                return entity;
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.Error.WriteLine($"An error occurred: {ex.Message}");
                throw; // Optionally rethrow the exception
            }
        }
        public async Task<PKKLCHop> GetById(string id)
        {
            using var context = _context.CreateDbContext();
            var entity = await context.PKKLCHops.Where(x => x.Id.Equals(id)).FirstOrDefaultAsync();

            if (entity == null)
            {
                throw new Exception($"Không tìm thấy bản ghi theo ID: {id}");
            }

            return entity;
        }
        public async Task<List<PKKLModel>> GetAllByVM(PKKLModel mModel)
        {
            try
            {
                using var context = _context.CreateDbContext();
                List<PKKLModel> data = new();
                var query = from a in context.PKKLCHops
                            join b in context.PhanLoaiCTronHopNhuas
                            on a.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai equals b.Id
                            orderby a.HangMuc ascending, a.LoaiBeTong descending, a.CreateAt ascending
                            select new PKKLModel
                            {
                                Id = a.Id,
                                LoaiCauKien = b.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai,
                                LoaiCauKienId = a.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai,
                                LoaiBeTong = a.LoaiBeTong,
                                HangMuc = a.HangMuc,
                                HangMucCongTac = a.HangMucCongTac,
                                TenCongTac = a.TenCongTac,
                                DonVi = a.DonVi,
                                KTHH_D = a.KTHH_D,
                                KTHH_R = a.KTHH_R,
                                KTHH_C = a.KTHH_C,
                                KTHH_DienTich = a.KTHH_DienTich,
                                KTHH_GhiChu = a.KTHH_GhiChu,
                                KTHH_SLCauKien = a.KTHH_SLCauKien,
                                KTHH_KL1CK = a.KTHH_KL1CK,
                                TTCDT_CDai = a.TTCDT_CDai,
                                TTCDT_CRong = a.TTCDT_CRong,
                                TTCDT_CDay = a.TTCDT_CDay,
                                TTCDT_DienTich = a.TTCDT_DienTich,
                                TTCDT_SLCK = a.TTCDT_SLCK,
                                TTCDT_KL = a.TTCDT_KL,
                                KLKP_Sl = a.KLKP_Sl,
                                KLKP_KL = a.KLKP_KL,
                                KL1CK_ChuaTruCC = a.KL1CK_ChuaTruCC,
                                KLCC1CK = a.KLCC1CK,
                                TKLCK_SauCC = a.TKLCK_SauCC
                            };

                if (!string.IsNullOrEmpty(mModel.HangMuc))
                {
                    query = query.Where(x => x.HangMuc == mModel.HangMuc);
                }
                if (!string.IsNullOrEmpty(mModel.TenCongTac))
                {
                    query = query.Where(x => x.TenCongTac == mModel.TenCongTac);
                }
                if (!string.IsNullOrEmpty(mModel.LoaiCauKienId))
                {
                    query = query.Where(x => x.LoaiCauKienId == mModel.LoaiCauKienId);
                }

                data = await query.ToListAsync();

                return data;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }

        }
        public async Task<List<THKLModel>> GetTHKLCongHop()
        {
            try
            {
                using var context = _context.CreateDbContext();
                var query = (from a in context.PKKLCHops
                             join b in context.PhanLoaiCTronHopNhuas
                             on a.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai equals b.Id
                             let kl1Dv = context.PKKLCHops
                                 .Where(x => x.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai == a.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai
                                          && x.LoaiBeTong == a.LoaiBeTong
                                          && x.HangMuc == a.HangMuc
                                          && x.HangMucCongTac == a.HangMucCongTac
                                          && x.TenCongTac == a.TenCongTac)
                                 .Sum(x => x.TKLCK_SauCC)
                             orderby a.HangMuc, a.CreateAt
                             select new THKLModel
                             {
                                 PhanLoaiCTronHopNhua_TenLoaiTruyenDanSauPhanLoai = b.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai,
                                 ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai = a.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai,
                                 HangMucCongTac = a.HangMucCongTac,
                                 TenCongTac = a.TenCongTac,
                                 DonVi = a.DonVi,
                                 KL1DonVi = kl1Dv,

                             }).ToList();
                return query;
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.Error.WriteLine($"An error occurred: {ex.Message}");
                throw; // Optionally rethrow the exception
            }

        }
        public async Task<List<THKLModel>> GetTHKLByTuyenDuong(string TuyenDuong)
        {
            try
            {
                using var context = _context.CreateDbContext();
                var query = (from a in context.PKKLCHops
                             join b in context.PhanLoaiCTronHopNhuas on a.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai equals b.Id
                             join c in context.DSNuocMua on a.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai
                             equals c.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai into cGroup
                             from c in cGroup.DefaultIfEmpty()
                             where c.ThongTinLyTrinh_TuyenDuong == TuyenDuong
                             group new { a, c } by new
                             {
                                 a.Id,
                                 b.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai,
                                 PhanLoaiCTronHopNhua_TenLoaiTruyenDanSauPhanLoai = c.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai,
                                 a.TenCongTac,
                                 a.DonVi,
                                 a.TKLCK_SauCC,
                                 a.HangMuc,
                                 a.CreateAt
                             } into g
                             orderby g.Key.HangMuc, g.Key.CreateAt
                             select new THKLModel
                             {
                                 Id = g.Key.Id,
                                 ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai = g.Key.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai,
                                 PhanLoaiCTronHopNhua_TenLoaiTruyenDanSauPhanLoai = g.Key.PhanLoaiCTronHopNhua_TenLoaiTruyenDanSauPhanLoai,
                                 TenCongTac = g.Key.TenCongTac,
                                 DonVi = g.Key.DonVi,
                                 KL1DonVi = g.Key.TKLCK_SauCC,
                                 SLTrai = g.Sum(x => x.c != null && x.c.TraiPhai == 0 ? x.c.TTCDSLCauKienDuongTruyenDan_SlCauKienTinhKl : 0) ?? 0,
                                 SLPhai = g.Sum(x => x.c != null && x.c.TraiPhai == 1 ? x.c.TTCDSLCauKienDuongTruyenDan_SlCauKienTinhKl : 0) ?? 0,
                                 SLTong = g.Sum(x => x.c != null && (x.c.TraiPhai == 0 || x.c.TraiPhai == 1) ? x.c.TTCDSLCauKienDuongTruyenDan_SlCauKienTinhKl : 0) ?? 0,
                                 KLTrai = g.Sum(x => x.c != null && x.c.TraiPhai == 0 ? x.c.TTCDSLCauKienDuongTruyenDan_SlCauKienTinhKl : 0) * g.Key.TKLCK_SauCC ?? 0,
                                 KLPhai = g.Sum(x => x.c != null && x.c.TraiPhai == 1 ? x.c.TTCDSLCauKienDuongTruyenDan_SlCauKienTinhKl : 0) * g.Key.TKLCK_SauCC ?? 0,
                                 KLTong = g.Sum(x => x.c != null && (x.c.TraiPhai == 0 || x.c.TraiPhai == 1) ? x.c.TTCDSLCauKienDuongTruyenDan_SlCauKienTinhKl : 0) * g.Key.TKLCK_SauCC ?? 0
                             }).ToList();
                return query;
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.Error.WriteLine($"An error occurred: {ex.Message}");
                throw; // Optionally rethrow the exception
            }

        }
        public async Task<List<THKLModel>> GetTHKLByTuyenDuong(List<NuocMuaModel> nuocMua)
        {
            try
            {
                using var context = _context.CreateDbContext();

                // Khởi tạo một danh sách để lưu kết quả
                List<THKLModel> finalResult = new List<THKLModel>();

                // Duyệt qua từng tuyến đường trong danh sách `nuocMua`
                foreach (var item in nuocMua)
                {

                    var query = await (from a in context.PKKLCHops
                                       join b in context.PhanLoaiCTronHopNhuas
                                           on a.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai equals b.Id
                                       join c in context.DSNuocMua
                                           on a.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai equals c.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai into cGroup
                                       from c in cGroup.Where(c => c.ThongTinLyTrinh_TuyenDuong == item.ThongTinLyTrinh_TuyenDuong).DefaultIfEmpty()

                                       group new { a, b, c } by new
                                       {
                                           a.Id,
                                           a.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai,
                                           PhanLoaiCTronHopNhua_TenLoaiTruyenDanSauPhanLoai = c.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai,
                                           a.TenCongTac,
                                           a.DonVi,
                                           a.TKLCK_SauCC,
                                           a.HangMuc,
                                           a.CreateAt
                                       } into g
                                       orderby g.Key.HangMuc, g.Key.CreateAt
                                       select new THKLModel
                                       {
                                           Id = g.Key.Id,
                                           ThongTinLyTrinh_TuyenDuong = item.ThongTinLyTrinh_TuyenDuong,  // Thông tin cố định từ SQL
                                           ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai = g.Key.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai,
                                           PhanLoaiCTronHopNhua_TenLoaiTruyenDanSauPhanLoai = g.Key.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai, // Cố định tên loại từ SQL
                                           TenCongTac = g.Key.TenCongTac,
                                           DonVi = g.Key.DonVi,
                                           KL1DonVi = g.Key.TKLCK_SauCC,
                                           SLTrai = g.Sum(x => x.c != null && x.c.TraiPhai == 0 ? x.c.TTCDSLCauKienDuongTruyenDan_SlCauKienTinhKl : 0) ?? 0,
                                           SLPhai = g.Sum(x => x.c != null && x.c.TraiPhai == 1 ? x.c.TTCDSLCauKienDuongTruyenDan_SlCauKienTinhKl : 0) ?? 0,
                                           SLTong = g.Sum(x => x.c != null ? x.c.TTCDSLCauKienDuongTruyenDan_SlCauKienTinhKl : 0) ?? 0,
                                           KLTrai = g.Sum(x => x.c != null && x.c.TraiPhai == 0 ? x.c.TTCDSLCauKienDuongTruyenDan_SlCauKienTinhKl : 0) * g.Key.TKLCK_SauCC ?? 0,
                                           KLPhai = g.Sum(x => x.c != null && x.c.TraiPhai == 1 ? x.c.TTCDSLCauKienDuongTruyenDan_SlCauKienTinhKl : 0) * g.Key.TKLCK_SauCC ?? 0,
                                           KLTong = g.Sum(x => x.c != null ? x.c.TTCDSLCauKienDuongTruyenDan_SlCauKienTinhKl : 0) * g.Key.TKLCK_SauCC ?? 0
                                       }).ToListAsync();



                    // Thêm kết quả của truy vấn vào danh sách `finalResult`
                    finalResult.AddRange(query);
                }

                // Trả về danh sách kết quả cuối cùng
                return finalResult;
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.Error.WriteLine($"An error occurred: {ex.Message}");
                throw; // Optionally rethrow the exception
            }
        }
        public async Task<PKKLCHop> GetTKLCK_SauCCByLCK(string id)
        {
            using var context = _context.CreateDbContext();
            var result = context.PKKLCHops
                .Where(a => a.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai == id &&
                 a.HangMuc == "I.Sản xuất, vận chuyển, lắp đặt" &&
                 a.LoaiBeTong == "Bê tông thương phẩm" &&
                 a.KTHH_GhiChu == "Rộng*Cao")
                 .FirstOrDefault();

            return result;
        }
        public async Task<List<PKKLCHop>> GetExist(PKKLCHop searchData)
        {
            try
            {
                using var context = _context.CreateDbContext();

                // Thực hiện lọc dữ liệu dựa trên các thuộc tính của searchData
                var query = context.PKKLCHops
                             .Where(item => (
                                    item.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai == searchData.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai &&
                                    item.LoaiBeTong == searchData.LoaiBeTong &&
                                    item.HangMuc == searchData.HangMuc &&
                                    item.HangMucCongTac == searchData.HangMucCongTac &&
                                    item.TenCongTac == searchData.TenCongTac &&
                                    item.DonVi == searchData.DonVi &&
                                    item.KTHH_D == searchData.KTHH_D &&
                                    item.KTHH_R == searchData.KTHH_R &&
                                    item.KTHH_C == searchData.KTHH_C &&
                                    item.KTHH_DienTich == searchData.KTHH_DienTich &&
                                    item.KTHH_GhiChu == searchData.KTHH_GhiChu &&
                                    item.KTHH_SLCauKien == searchData.KTHH_SLCauKien &&
                                    item.KTHH_KL1CK == searchData.KTHH_KL1CK &&
                                    item.TTCDT_CDai == searchData.TTCDT_CDai &&
                                    item.TTCDT_CRong == searchData.TTCDT_CRong &&
                                    item.TTCDT_CDay == searchData.TTCDT_CDay &&
                                    item.TTCDT_DienTich == searchData.TTCDT_DienTich &&
                                    item.TTCDT_SLCK == searchData.TTCDT_SLCK &&
                                    item.TTCDT_KL == searchData.TTCDT_KL &&
                                    item.KLKP_KL == searchData.KLKP_KL &&
                                    item.KLKP_Sl == searchData.KLKP_Sl &&
                                    item.KL1CK_ChuaTruCC == searchData.KL1CK_ChuaTruCC &&
                                    item.KLCC1CK == searchData.KLCC1CK &&
                                    item.TKLCK_SauCC == searchData.TKLCK_SauCC
                                          ));
                var result = await query.ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.Error.WriteLine($"An error occurred: {ex.Message}");
                throw; // Optionally rethrow the exception
            }
        }
        public async Task Update(PKKLCHop TKThepDeCong)
        {
            using var context = _context.CreateDbContext();
            var entity = GetById(TKThepDeCong.Id);

            if (entity == null)
            {
                throw new Exception($"Không tìm thấy bản ghi theo ID: {TKThepDeCong.Id}");
            }

            context.PKKLCHops.Update(TKThepDeCong);
            await SaveChanges(context);
        }
        public async Task UpdateMulti(PKKLCHop[] PKKLCHop)
        {
            try
            {
                using var context = _context.CreateDbContext();

                string[] ids = PKKLCHop.Select(x => x.Id).ToArray();

                // Lấy danh sách các bản ghi từ database có ID nằm trong danh sách ids
                var listEntities = await context.PKKLCHops
                    .Where(x => ids.Contains(x.Id))
                    .ToListAsync();
                foreach (var entity in listEntities)
                {
                    var updatedEntity = PKKLCHop.FirstOrDefault(x => x.Id == entity.Id);
                    if (updatedEntity != null)
                    {
                        context.Entry(entity).CurrentValues.SetValues(updatedEntity);
                    }
                }

                // Lưu các thay đổi vào database
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }


        public async Task DeleteById(string id)
        {
            using var context = _context.CreateDbContext();
            var entity = await GetById(id);

            if (entity == null)
            {
                throw new Exception($"Không tìm thấy bản ghi theo ID: {id}");
            }

            context.Set<PKKLCHop>().Remove(entity);
            await SaveChanges(context);
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
        public async Task Insert(PKKLCHop entity)
        {
            try
            {
                using var context = _context.CreateDbContext();
                if (entity == null)
                {
                    throw new Exception("Không có bản ghi nào để thêm!");
                }

                // Lấy tất cả các bản ghi phù hợp và thực hiện xử lý trên client-side
                var maxFlagValue = await context.PKKLCHops
                    .Where(x => x.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai == entity.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai && x.HangMuc == entity.HangMuc)
                    .Select(x => x.Flag)
                    .ToListAsync(); // Lấy danh sách các giá trị Flag

                // Kiểm tra nếu danh sách không có giá trị nào, trả về 0, ngược lại lấy giá trị lớn nhất
                var maxFlag = maxFlagValue.Any() ? maxFlagValue.Max() : 0;


                // Tăng giá trị Flag lên 1
                entity.Flag = maxFlag + 1;

                // Chèn bản ghi mới vào bảng
                context.PKKLCHops.Add(entity);
                await SaveChanges(context);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public async Task<string> InsertLaterFlag(PKKLCHop entity, int FlagLast)
        {
            string id = "";
            try
            {
                using var context = _context.CreateDbContext();

                if (entity == null)
                {
                    throw new Exception("Không có bản ghi nào để thêm!");
                }

                // Bước 1: Lấy danh sách các bản ghi có flag > FlagLast
                var recordsToUpdate = await context.PKKLCHops
                    .Where(x => x.Flag > FlagLast && x.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai == entity.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai && x.HangMuc == entity.HangMuc)
                    .ToListAsync();

                // Bước 2: Tăng giá trị flag của các bản ghi đó thêm 1
                foreach (var record in recordsToUpdate)
                {
                    record.Flag += 1;
                }

                // Lưu các thay đổi cập nhật flag
                await context.SaveChangesAsync();

                // Bước 3: Đặt flag cho bản ghi mới bằng 3
                if (recordsToUpdate.Count() == 0)
                {
                    // Kiểm tra xem bảng có bản ghi nào không
                    var maxFlag = await context.PKKLCHops.AnyAsync()
                                  ? await context.PKKLCHops.MaxAsync(x => x.Flag)
                                  : 0;

                    // Tăng giá trị Flag lên 1
                    entity.Flag = maxFlag + 1;
                }
                else
                {
                    entity.Flag = FlagLast + 1;
                }

                // Bước 4: Chèn bản ghi mới vào bảng
                context.PKKLCHops.Add(entity);

                // Lưu bản ghi mới vào cơ sở dữ liệu
                await SaveChanges(context);
                // Trả về Id của bản ghi mới được thêm
                id = entity.Id ?? "";
                return id;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return id;
            }
        }


        public async Task SaveChanges(ApplicationDbContext context)
        {
            try
            {
                // Kiểm tra và xử lý các thay đổi trong DbContext
                var addedEntities = context.ChangeTracker.Entries()
                    .Where(e => e.State == EntityState.Added)
                    .ToList();

                var modifiedEntities = context.ChangeTracker.Entries()
                    .Where(e => e.State == EntityState.Modified)
                    .ToList();

                var deletedEntities = context.ChangeTracker.Entries()
                    .Where(e => e.State == EntityState.Deleted)
                    .ToList();

                // Xử lý thay đổi khi thêm
                if (addedEntities.Any())
                {
                    foreach (var addedEntity in addedEntities)
                    {
                        await HandleEntityAdd(addedEntity);
                    }
                }

                // Xử lý thay đổi khi sửa
                if (modifiedEntities.Any())
                {
                    foreach (var modifiedEntity in modifiedEntities)
                    {
                        await HandleEntityUpdate(modifiedEntity);
                    }
                }

                // Xử lý thay đổi khi xóa
                if (deletedEntities.Any())
                {
                    foreach (var deletedEntity in deletedEntities)
                    {
                        await HandleEntityDelete(deletedEntity);
                    }
                }

                // Lưu các thay đổi vào cơ sở dữ liệu
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"An error occurred while saving changes: {ex.Message}");
                throw;
            }
        }

        // Xử lý khi thêm mới entity
        private async Task HandleEntityAdd(EntityEntry entityEntry)
        {
            var addedEntity = entityEntry.Entity as PKKLCHop;
            if (addedEntity != null)
            {
                // Kiểm tra điều kiện HangMuc và PhanLoaiMongCongTronCongHop
                if (addedEntity.HangMuc == "I.Sản xuất, vận chuyển, lắp đặt"
                    && addedEntity.KTHH_GhiChu == "Rộng*Cao"
                    && addedEntity.HangMucCongTac.Trim().ToLower() == "Bê tông cống hộp".Trim().ToLower())
                {
                    using var context = _context.CreateDbContext();
                    var TKLCK_SauCC = addedEntity.TKLCK_SauCC;
                    // Lọc tất cả các bản ghi có ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai giống với addedEntity
                    var recordsToUpdate = await context.PKKLCHops
                        .Where(x => x.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai == addedEntity.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai
                        && x.HangMuc == "I.Sản xuất, vận chuyển, lắp đặt" && x.HangMucCongTac == "Vận chuyển từ bãi đúc đến công trường")
                        .ToListAsync();


                    // Cập nhật các cột KLKP_KL cho từng bản ghi
                    foreach (var record in recordsToUpdate)
                    {

                        record.KTHH_KL1CK = KTHH_KL1CK(record.DonVi, record.KTHH_D, record.KTHH_R, record.KTHH_C, record.KTHH_DienTich, record.KTHH_GhiChu);
                        record.TTCDT_KL = TTCDT_KL(record.DonVi, record.KTHH_D, record.KTHH_R, record.KTHH_C, record.TTCDT_CDai, record.TTCDT_CRong, record.TTCDT_CDay, record.TTCDT_DienTich);
                        record.KL1CK_ChuaTruCC = KL1CK_ChuaTruCC(record.KTHH_KL1CK, record.KTHH_SLCauKien, record.TTCDT_KL, record.TTCDT_SLCK, record.KLKP_KL, record.KLKP_Sl);
                        record.KLKP_KL = TKLCK_SauCC * 2.4;
                        record.TKLCK_SauCC = record.KL1CK_ChuaTruCC - record.KLCC1CK;
                    }

                    // Gọi phương thức UpdateMulti để cập nhật nhiều bản ghi
                    await UpdateMulti(recordsToUpdate.ToArray());

                    var recordsToUpdate1 = await context.PKKLCHops
                        .Where(x => x.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai == addedEntity.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai
                        && x.HangMuc == "II.Sản xuất + V.Chuyển B.Tông T.Phẩm" && x.LoaiBeTong == "Bê tông thương phẩm")
                        .ToListAsync();


                    // Cập nhật các cột TKLCK_SauCC cho từng bản ghi
                    foreach (var record in recordsToUpdate1)
                    {

                        if (!string.IsNullOrEmpty(record.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai))
                        {
                            var TKLCK_SauCC1 = await GetTKLCK_SauCCByLCK(record.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai);
                            if (TKLCK_SauCC1 != null)
                            {
                                record.TKLCK_SauCC = TKLCK_SauCC1.TKLCK_SauCC + TKLCK_SauCC;
                            }
                            else
                            {
                                record.TKLCK_SauCC = TKLCK_SauCC;
                            }
                        }

                    }

                    // Gọi phương thức UpdateMulti để cập nhật nhiều bản ghi
                    await UpdateMulti(recordsToUpdate1.ToArray());


                    // In thông tin của entity mới
                    Console.WriteLine($"Entity added: {addedEntity}");
                }
            }
        }
        // Xử lý khi sửa entity
        private async Task HandleEntityUpdate(EntityEntry entityEntry)
        {
            var modifiedEntity = entityEntry.Entity as PKKLCHop;
            if (modifiedEntity != null)
            {

            }
        }

        // Xử lý khi xóa entity
        private async Task HandleEntityDelete(EntityEntry entityEntry)
        {
            var deletedEntity = entityEntry.Entity as PKKLCHop;
            if (deletedEntity != null)
            {
                // Kiểm tra điều kiện HangMuc và PhanLoaiMongCongTronCongHop
                if (deletedEntity.HangMuc == "I.Sản xuất, vận chuyển, lắp đặt")
                {
                    using var context = _context.CreateDbContext();
                    var TKLCK_SauCC = 0;
                    if (deletedEntity.KTHH_GhiChu == "Rộng*Cao"
                    && deletedEntity.HangMucCongTac.Trim().ToLower() == "Bê tông cống hộp".Trim().ToLower())
                    {
                        // Lọc tất cả các bản ghi có ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai giống với addedEntity
                        var recordsToUpdate = await context.PKKLCHops
                            .Where(x => x.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai == deletedEntity.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai
                            && x.HangMuc == "I.Sản xuất, vận chuyển, lắp đặt" && x.HangMucCongTac == "Vận chuyển từ bãi đúc đến công trường")
                            .ToListAsync();


                        // Cập nhật các cột TKLCK_SauCC cho từng bản ghi
                        foreach (var record in recordsToUpdate)
                        {
                            record.KLKP_KL = TKLCK_SauCC * 2.4;
                            record.KTHH_KL1CK = KTHH_KL1CK(record.DonVi, record.KTHH_D, record.KTHH_R, record.KTHH_C, record.KTHH_DienTich, record.KTHH_GhiChu);
                            record.TTCDT_KL = TTCDT_KL(record.DonVi, record.KTHH_D, record.KTHH_R, record.KTHH_C, record.TTCDT_CDai, record.TTCDT_CRong, record.TTCDT_CDay, record.TTCDT_DienTich);
                            record.KL1CK_ChuaTruCC = KL1CK_ChuaTruCC(record.KTHH_KL1CK, record.KTHH_SLCauKien, record.TTCDT_KL, record.TTCDT_SLCK, record.KLKP_KL, record.KLKP_Sl);
                            record.TKLCK_SauCC = record.KL1CK_ChuaTruCC - record.KLCC1CK;
                        }
                        // Gọi phương thức UpdateMulti để cập nhật nhiều bản ghi
                        await UpdateMulti(recordsToUpdate.ToArray());
                    }


                    var recordsToUpdate1 = await context.PKKLCHops
                        .Where(x => x.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai == deletedEntity.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai
                        && x.HangMuc == "II.Sản xuất + V.Chuyển B.Tông T.Phẩm" && x.LoaiBeTong == "Bê tông thương phẩm")
                        .ToListAsync();


                    // Cập nhật các cột TKLCK_SauCC cho từng bản ghi
                    foreach (var record in recordsToUpdate1)
                    {

                        if (!string.IsNullOrEmpty(record.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai))
                        {
                            var TKLCK_SauCC1 = await GetTKLCK_SauCCByLCK(record.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai);
                            if (TKLCK_SauCC1 != null)
                            {
                                record.TKLCK_SauCC = TKLCK_SauCC1.TKLCK_SauCC - deletedEntity.TKLCK_SauCC;
                            }
                            else
                            {
                                record.TKLCK_SauCC = TKLCK_SauCC;
                            }
                        }

                    }

                    // Gọi phương thức UpdateMulti để cập nhật nhiều bản ghi
                    await UpdateMulti(recordsToUpdate1.ToArray());

                }
            }
        }

        public  double KTHH_KL1CK(string DonVi, double KTHH_D, double KTHH_R, double KTHH_C, double KTHH_DienTich, string KTHH_GhiChu)
        {
            double result = 0;
            if (DonVi == "M3")
            {
                if (string.IsNullOrEmpty(KTHH_GhiChu) || KTHH_GhiChu == "0")
                {
                    result = KTHH_D * KTHH_R * KTHH_C;
                }
                else if (KTHH_GhiChu == "Rộng*Cao")
                {
                    result = KTHH_DienTich * KTHH_D;
                }
                else if (KTHH_GhiChu == "Dài*Cao")
                {
                    result = KTHH_DienTich * KTHH_R;
                }
                else if (KTHH_GhiChu == "Dài*Rộng")
                {
                    result = KTHH_DienTich * KTHH_C;
                }

            }
            return Math.Round(result, 4);
        }

        public  double TTCDT_KL(string DonVi, double KTHH_D, double KTHH_R, double KTHH_C, double TTCDT_CDai, double TTCDT_CRong, double TTCDT_CDay, double TTCDT_DienTich)
        {
            double result = 0;
            if (DonVi.ToUpper().Trim() == "M2")
            {
                if (string.IsNullOrEmpty(TTCDT_DienTich.ToString()) || TTCDT_DienTich == 0)
                {
                    result = (KTHH_D * KTHH_C * TTCDT_CDai) + (KTHH_R * KTHH_C * TTCDT_CRong) + (KTHH_D * KTHH_R * TTCDT_CDay);
                }
                else
                {
                    result = TTCDT_DienTich;
                }
            }
            return Math.Round(result, 4);
        }

        public  double KL1CK_ChuaTruCC(double KTHH_KL1CK, double KTHH_SLCauKien, double TTCDT_KL, double TTCDT_SLCK, double KLKP_KL, double KLKP_Sl)
        {
            double result = 0;
            if (KTHH_KL1CK > 0)
            {
                result = KTHH_KL1CK * KTHH_SLCauKien;
            }
            else if (TTCDT_KL > 0)
            {
                result = TTCDT_KL * TTCDT_SLCK;
            }
            else
            {
                result = KLKP_KL * KLKP_Sl;
            }
            return Math.Round(result, 4);
        }


    }
}
