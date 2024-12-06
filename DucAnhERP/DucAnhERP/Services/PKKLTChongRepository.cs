using DucAnhERP.Data;
using DucAnhERP.Models;
using DucAnhERP.ViewModel;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using DucAnhERP.Repository;

namespace DucAnhERP.Services
{
    public class PKKLTChongRepository : IPKKLTChongRepository
    {
        private readonly IDbContextFactory<ApplicationDbContext> _context;

        public PKKLTChongRepository(IDbContextFactory<ApplicationDbContext> context)
        {
            _context = context;
        }
        public async Task<List<PKKLTChong>> GetAll()
        {
            try
            {
                using var context = _context.CreateDbContext();
                var entity = await context.PKKLTChongs.ToListAsync();
                return entity;
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.Error.WriteLine($"An error occurred: {ex.Message}");
                throw; // Optionally rethrow the exception
            }
        }
        public async Task<PKKLTChong> GetById(string id)
        {
            using var context = _context.CreateDbContext();
            var entity = await context.PKKLTChongs.Where(x => x.Id.Equals(id)).FirstOrDefaultAsync();

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
                var query = from a in context.PKKLTChongs
                            join b in context.PhanLoaiThanhChongs
                            on a.TTKTHHCongHopRanh_LoaiThanhChong equals b.Id
                            orderby b.TTKTHHCongHopRanh_LoaiThanhChong ascending, a.HangMuc ascending, a.LoaiBeTong descending, a.CreateAt ascending
                            select new PKKLModel
                            {
                                Id = a.Id,
                                Flag = a.Flag,
                                LoaiCauKien = b.TTKTHHCongHopRanh_LoaiThanhChong ?? "",
                                LoaiCauKienId = a.TTKTHHCongHopRanh_LoaiThanhChong,
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
        public async Task<List<THKLModel>> GetTHKLThanhChong()
        {
            try
            {
                using var context = _context.CreateDbContext();
                var query = (from a in context.PKKLTChongs
                             join b in context.PhanLoaiThanhChongs
                             on a.TTKTHHCongHopRanh_LoaiThanhChong equals b.Id
                             let kl1Dv = context.PKKLTChongs
                                 .Where(x => x.TTKTHHCongHopRanh_LoaiThanhChong == a.TTKTHHCongHopRanh_LoaiThanhChong
                                          && x.LoaiBeTong == a.LoaiBeTong
                                          && x.HangMuc == a.HangMuc
                                          && x.HangMucCongTac == a.HangMucCongTac
                                          && x.TenCongTac == a.TenCongTac)
                                 .Sum(x => x.TKLCK_SauCC)
                             orderby b.TTKTHHCongHopRanh_LoaiThanhChong, a.HangMuc, a.CreateAt
                             select new THKLModel
                             {
                                 PhanLoaiCTronHopNhua_TenLoaiTruyenDanSauPhanLoai = b.TTKTHHCongHopRanh_LoaiThanhChong ?? "",
                                 ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai = a.TTKTHHCongHopRanh_LoaiThanhChong,
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
                var query = (from a in context.PKKLTChongs
                             join b in context.PhanLoaiThanhChongs on a.TTKTHHCongHopRanh_LoaiThanhChong equals b.Id
                             join c in context.DSNuocMua on a.TTKTHHCongHopRanh_LoaiThanhChong
                             equals c.TTKTHHCongHopRanh_LoaiThanhChong into cGroup
                             from c in cGroup.DefaultIfEmpty()
                             where c.ThongTinLyTrinh_TuyenDuong == TuyenDuong
                             group new { a, c } by new
                             {
                                 a.Id,
                                 b.TTKTHHCongHopRanh_LoaiThanhChong,
                                 PhanLoaiCTronHopNhua_TenLoaiTruyenDanSauPhanLoai = b.TTKTHHCongHopRanh_LoaiThanhChong,
                                 a.TenCongTac,
                                 a.DonVi,
                                 a.TKLCK_SauCC,
                                 a.HangMuc,
                                 a.CreateAt
                             } into g
                             orderby g.Key.PhanLoaiCTronHopNhua_TenLoaiTruyenDanSauPhanLoai, g.Key.HangMuc, g.Key.CreateAt
                             select new THKLModel
                             {
                                 Id = g.Key.Id,
                                 ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai = g.Key.TTKTHHCongHopRanh_LoaiThanhChong,
                                 PhanLoaiCTronHopNhua_TenLoaiTruyenDanSauPhanLoai = g.Key.PhanLoaiCTronHopNhua_TenLoaiTruyenDanSauPhanLoai,
                                 TenCongTac = g.Key.TenCongTac,
                                 DonVi = g.Key.DonVi,
                                 KL1DonVi = g.Key.TKLCK_SauCC,
                                 SLTrai = g.Sum(x => x.c != null && x.c.TraiPhai == 0 ? x.c.TTKTHHCongHopRanh_SoLuongThanhChong : 0) ?? 0,
                                 SLPhai = g.Sum(x => x.c != null && x.c.TraiPhai == 1 ? x.c.TTKTHHCongHopRanh_SoLuongThanhChong : 0) ?? 0,
                                 SLTong = g.Sum(x => x.c != null && (x.c.TraiPhai == 0 || x.c.TraiPhai == 1) ? x.c.TTKTHHCongHopRanh_SoLuongThanhChong : 0) ?? 0,
                                 KLTrai = g.Sum(x => x.c != null && x.c.TraiPhai == 0 ? x.c.TTKTHHCongHopRanh_SoLuongThanhChong : 0) * g.Key.TKLCK_SauCC ?? 0,
                                 KLPhai = g.Sum(x => x.c != null && x.c.TraiPhai == 1 ? x.c.TTKTHHCongHopRanh_SoLuongThanhChong : 0) * g.Key.TKLCK_SauCC ?? 0,
                                 KLTong = g.Sum(x => x.c != null && (x.c.TraiPhai == 0 || x.c.TraiPhai == 1) ? x.c.TTKTHHCongHopRanh_SoLuongThanhChong : 0) * g.Key.TKLCK_SauCC ?? 0
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

                    var query = await (from a in context.PKKLTChongs
                                       join b in context.PhanLoaiThanhChongs
                                           on a.TTKTHHCongHopRanh_LoaiThanhChong equals b.Id
                                       join c in context.DSNuocMua
                                           on a.TTKTHHCongHopRanh_LoaiThanhChong equals c.TTKTHHCongHopRanh_LoaiThanhChong into cGroup
                                       from c in cGroup.Where(c => c.ThongTinLyTrinh_TuyenDuong == item.ThongTinLyTrinh_TuyenDuong).DefaultIfEmpty()

                                       group new { a, b, c } by new
                                       {
                                           a.Id,
                                           a.TTKTHHCongHopRanh_LoaiThanhChong,
                                           PhanLoaiCTronHopNhua_TenLoaiTruyenDanSauPhanLoai = b.TTKTHHCongHopRanh_LoaiThanhChong ?? "",
                                           a.TenCongTac,
                                           a.DonVi,
                                           a.TKLCK_SauCC,
                                           a.HangMuc,
                                           a.CreateAt
                                       } into g
                                       orderby g.Key.PhanLoaiCTronHopNhua_TenLoaiTruyenDanSauPhanLoai, g.Key.HangMuc, g.Key.CreateAt
                                       select new THKLModel
                                       {
                                           Id = g.Key.Id,
                                           ThongTinLyTrinh_TuyenDuong = item.ThongTinLyTrinh_TuyenDuong,  // Thông tin cố định từ SQL
                                           ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai = g.Key.TTKTHHCongHopRanh_LoaiThanhChong,
                                           PhanLoaiCTronHopNhua_TenLoaiTruyenDanSauPhanLoai = g.Key.PhanLoaiCTronHopNhua_TenLoaiTruyenDanSauPhanLoai, // Cố định tên loại từ SQL
                                           TenCongTac = g.Key.TenCongTac,
                                           DonVi = g.Key.DonVi,
                                           KL1DonVi = g.Key.TKLCK_SauCC,
                                           SLTrai = g.Sum(x => x.c != null && x.c.TraiPhai == 0 ? x.c.TTKTHHCongHopRanh_SoLuongThanhChong : 0) ?? 0,
                                           SLPhai = g.Sum(x => x.c != null && x.c.TraiPhai == 1 ? x.c.TTKTHHCongHopRanh_SoLuongThanhChong : 0) ?? 0,
                                           SLTong = g.Sum(x => x.c != null ? x.c.TTKTHHCongHopRanh_SoLuongThanhChong : 0) ?? 0,
                                           KLTrai = g.Sum(x => x.c != null && x.c.TraiPhai == 0 ? x.c.TTKTHHCongHopRanh_SoLuongThanhChong : 0) * g.Key.TKLCK_SauCC ?? 0,
                                           KLPhai = g.Sum(x => x.c != null && x.c.TraiPhai == 1 ? x.c.TTKTHHCongHopRanh_SoLuongThanhChong : 0) * g.Key.TKLCK_SauCC ?? 0,
                                           KLTong = g.Sum(x => x.c != null ? x.c.TTKTHHCongHopRanh_SoLuongThanhChong : 0) * g.Key.TKLCK_SauCC ?? 0
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

        public async Task<PKKLTChong> GetTKLCK_SauCCByLCK(string id)
        {
            using var context = _context.CreateDbContext();
            var result = context.PKKLTChongs
                .Where(a => a.TTKTHHCongHopRanh_LoaiThanhChong == id &&
                 a.HangMuc == "I.Bê tông, vận chuyển, lắp đặt" &&
                 a.LoaiBeTong == "Bê tông thương phẩm").OrderBy(a => a.CreateAt)
                 .FirstOrDefault();

            return result;
        }
        public async Task<double> GetSumTKLCK_SauCCByLCK(string id)
        {
            using var context = _context.CreateDbContext();
            var result = context.PKKLTChongs
                .Where(a => a.TTKTHHCongHopRanh_LoaiThanhChong == id &&
                 a.HangMuc == "I.Bê tông, vận chuyển, lắp đặt" &&
                 a.LoaiBeTong == "Bê tông thương phẩm")
                 .Sum(x => x.TKLCK_SauCC);

            return result;
        }

        public async Task<List<PKKLTChong>> GetExist(PKKLTChong searchData)
        {
            try
            {
                using var context = _context.CreateDbContext();

                // Thực hiện lọc dữ liệu dựa trên các thuộc tính của searchData
                var query = context.PKKLTChongs
                             .Where(item => 
                                    item.TTKTHHCongHopRanh_LoaiThanhChong == searchData.TTKTHHCongHopRanh_LoaiThanhChong &&
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
                                          );
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
        public async Task Update(PKKLTChong TKThepDeCong)
        {
            using var context = _context.CreateDbContext();
            var entity = GetById(TKThepDeCong.Id);

            if (entity == null)
            {
                throw new Exception($"Không tìm thấy bản ghi theo ID: {TKThepDeCong.Id}");
            }

            context.PKKLTChongs.Update(TKThepDeCong);
            await SaveChanges(context);
        }
        public async Task UpdateMulti(PKKLTChong[] PKKLTChong)
        {


            try
            {
                using var context = _context.CreateDbContext();

                string[] ids = PKKLTChong.Select(x => x.Id).ToArray();

                // Lấy danh sách các bản ghi từ database có ID nằm trong danh sách ids
                var listEntities = await context.PKKLTChongs
                    .Where(x => ids.Contains(x.Id))
                    .ToListAsync();
                foreach (var entity in listEntities)
                {
                    var updatedEntity = PKKLTChong.FirstOrDefault(x => x.Id == entity.Id);
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

            context.Set<PKKLTChong>().Remove(entity);
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
        public async Task Insert(PKKLTChong entity)
        {
            try
            {
                using var context = _context.CreateDbContext();
                if (entity == null)
                {
                    throw new Exception("Không có bản ghi nào để thêm!");
                }

                // Tìm giá trị Flag lớn nhất dựa trên điều kiện
                var maxFlag = await context.PKKLTChongs
                    .Where(x => x.TTKTHHCongHopRanh_LoaiThanhChong == entity.TTKTHHCongHopRanh_LoaiThanhChong && x.HangMuc == entity.HangMuc)
                    .Select(x => (int?)x.Flag)
                    .MaxAsync() ?? 0;

                // Tăng giá trị Flag và thêm bản ghi
                entity.Flag = maxFlag + 1;
                context.PKKLTChongs.Add(entity);

                await SaveChanges(context);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public async Task<string> InsertLaterFlag(PKKLTChong entity, int FlagLast)
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
                var recordsToUpdate = await context.PKKLTChongs
                    .Where(x => x.Flag > FlagLast && x.TTKTHHCongHopRanh_LoaiThanhChong == entity.TTKTHHCongHopRanh_LoaiThanhChong && x.HangMuc == entity.HangMuc)
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
                    var maxFlag = await context.PKKLTChongs.AnyAsync()
                                  ? await context.PKKLTChongs.MaxAsync(x => x.Flag)
                                  : 0;

                    // Tăng giá trị Flag lên 1
                    entity.Flag = maxFlag + 1;
                }
                else
                {
                    entity.Flag = FlagLast + 1;
                }

                // Bước 4: Chèn bản ghi mới vào bảng
                context.PKKLTChongs.Add(entity);

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

        //cập nhật lại số liệu
        public async Task SaveChanges(ApplicationDbContext context)
        {
            try
            {
                // Xử lý các thay đổi trong DbContext
                var entries = context.ChangeTracker.Entries<PKKLTChong>();

                foreach (var entry in entries)
                {
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            await HandleEntityAdd(entry);
                            break;

                        case EntityState.Modified:
                            await HandleEntityUpdate(entry);
                            break;

                        case EntityState.Deleted:
                            await HandleEntityDelete(entry);
                            break;
                    }
                }

                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error while saving changes: {ex.Message}");
                throw;
            }
        }
        private async Task HandleEntityAdd(EntityEntry<PKKLTChong> entry)
        {
            var entity = entry.Entity;
            if (entity.HangMuc == "I.Bê tông, vận chuyển, lắp đặt")
            {
                using var context = _context.CreateDbContext();

                if (entity.LoaiBeTong.ToUpper().Trim() == "Bê tông thương phẩm".ToUpper().Trim() 
                    && entity.HangMucCongTac.Trim().ToLower() == "thanh chống".Trim().ToLower())
                {
                    //Cập nhật I.
                    var recordsToUpdate = await context.PKKLTChongs
                    .Where(x => x.TTKTHHCongHopRanh_LoaiThanhChong == entity.TTKTHHCongHopRanh_LoaiThanhChong &&
                                x.HangMuc == "I.Bê tông, vận chuyển, lắp đặt" &&
                                x.HangMucCongTac == "Vận chuyển từ bãi đúc đến công trường")
                    .ToListAsync();

                    foreach (var record in recordsToUpdate)
                    {
                        UpdateRecordWithCalculations(record, entity.TKLCK_SauCC);
                    }
                    await UpdateMulti(recordsToUpdate.ToArray());
                }

                //Cập nhật II.
                var recordsToUpdate1 = await context.PKKLTChongs
                    .Where(x => x.TTKTHHCongHopRanh_LoaiThanhChong == entity.TTKTHHCongHopRanh_LoaiThanhChong
                               && x.HangMuc == "II.Sản xuất + V.Chuyển B.Tông T.Phẩm"
                               && x.LoaiBeTong == "Bê tông thương phẩm")
                    .ToListAsync();

                foreach (var record in recordsToUpdate1)
                {
                    if (!string.IsNullOrEmpty(record.TTKTHHCongHopRanh_LoaiThanhChong))
                    {
                        var TKLCK_SauCC1 = await GetSumTKLCK_SauCCByLCK(entity.TTKTHHCongHopRanh_LoaiThanhChong);
                        record.TKLCK_SauCC = TKLCK_SauCC1 + entity.TKLCK_SauCC;
                    }
                }

                await UpdateMulti(recordsToUpdate1.ToArray());
            }
        }
        private async Task HandleEntityUpdate(EntityEntry<PKKLTChong> entry)
        {
            var entity = entry.Entity;
            if (entity != null)
            {
                // Kiểm tra điều kiện một lần duy nhất
                if (entity.HangMuc == "I.Bê tông, vận chuyển, lắp đặt")
                {
                    // Lưu trữ giá trị TKLCK_SauCC để sử dụng nhiều lần
                    using var context = _context.CreateDbContext();

                    if (entity.LoaiBeTong.ToUpper().Trim() == "Bê tông thương phẩm".ToUpper().Trim()
                    && entity.HangMucCongTac.Trim().ToLower() == "thanh chống".Trim().ToLower())
                    {
                        //Cập nhật I.
                        var recordsToUpdate = await context.PKKLTChongs
                        .Where(x => x.TTKTHHCongHopRanh_LoaiThanhChong == entity.TTKTHHCongHopRanh_LoaiThanhChong &&
                                    x.HangMuc == "I.Bê tông, vận chuyển, lắp đặt" &&
                                    x.HangMucCongTac == "Vận chuyển từ bãi đúc đến công trường")
                        .ToListAsync();

                        foreach (var record in recordsToUpdate)
                        {
                            UpdateRecordWithCalculations(record, entity.TKLCK_SauCC);
                        }
                        await UpdateMulti(recordsToUpdate.ToArray());
                    }

                    //Cập nhật II.
                    var recordsToUpdate1 = await context.PKKLTChongs
                        .Where(x => x.TTKTHHCongHopRanh_LoaiThanhChong == entity.TTKTHHCongHopRanh_LoaiThanhChong
                                   && x.HangMuc == "II.Sản xuất + V.Chuyển B.Tông T.Phẩm"
                                   && x.LoaiBeTong == "Bê tông thương phẩm")
                        .ToListAsync();

                    foreach (var record in recordsToUpdate1)
                    {
                        if (!string.IsNullOrEmpty(record.TTKTHHCongHopRanh_LoaiThanhChong))
                        {
                            var getOld = await GetById(entity.Id);
                            var TKLCK_SauCC1 = await GetSumTKLCK_SauCCByLCK(entity.TTKTHHCongHopRanh_LoaiThanhChong);
                            record.TKLCK_SauCC = (TKLCK_SauCC1 - getOld.TKLCK_SauCC) + entity.TKLCK_SauCC;
                        }
                    }

                    await UpdateMulti(recordsToUpdate1.ToArray());

                    // In thông tin của entity đã được sửa
                    Console.WriteLine($"Entity updated: {entity}");
                }
            }
        }
        private async Task HandleEntityDelete(EntityEntry<PKKLTChong> entry)
        {
            var entity = entry.Entity;
            if (entity.HangMuc == "I.Bê tông, vận chuyển, lắp đặt")
            {
                using var context = _context.CreateDbContext();
                if (entity.LoaiBeTong.ToUpper().Trim() == "Bê tông thương phẩm".ToUpper().Trim()
                    && entity.HangMucCongTac.Trim().ToLower() == "thanh chống".Trim().ToLower())
                {
                    //Cập nhật I.
                    var recordsToUpdate = await context.PKKLTChongs
                    .Where(x => x.TTKTHHCongHopRanh_LoaiThanhChong == entity.TTKTHHCongHopRanh_LoaiThanhChong &&
                                x.HangMuc == "I.Bê tông, vận chuyển, lắp đặt" &&
                                x.HangMucCongTac == "Vận chuyển từ bãi đúc đến công trường")
                    .ToListAsync();

                    foreach (var record in recordsToUpdate)
                    {
                        UpdateRecordWithCalculations(record, 0);
                    }
                    await UpdateMulti(recordsToUpdate.ToArray());
                }
                //Cập nhật II.
                var recordsToUpdate1 = await context.PKKLTChongs
                    .Where(x => x.TTKTHHCongHopRanh_LoaiThanhChong == entity.TTKTHHCongHopRanh_LoaiThanhChong
                               && x.HangMuc == "II.Sản xuất + V.Chuyển B.Tông T.Phẩm"
                               && x.LoaiBeTong == "Bê tông thương phẩm")
                    .ToListAsync();

                foreach (var record in recordsToUpdate1)
                {
                    if (!string.IsNullOrEmpty(record.TTKTHHCongHopRanh_LoaiThanhChong))
                    {
                        var TKLCK_SauCC1 = await GetSumTKLCK_SauCCByLCK(entity.TTKTHHCongHopRanh_LoaiThanhChong);
                        record.TKLCK_SauCC = TKLCK_SauCC1 - entity.TKLCK_SauCC;
                    }
                }

                await UpdateMulti(recordsToUpdate1.ToArray());

            }
        }
        
        //tính toán
        private void UpdateRecordWithCalculations(PKKLTChong record, double tklckSauCc)
        {
            record.KTHH_KL1CK = KTHH_KL1CK(record);
            record.TTCDT_KL = TTCDT_KL(record);
            record.KLKP_KL = Math.Round((tklckSauCc * 2.4), 4);
            record.KL1CK_ChuaTruCC = KL1CK_ChuaTruCC(record);
            record.TKLCK_SauCC = Math.Round((record.KL1CK_ChuaTruCC - record.KLCC1CK), 4);
        }
        public double KTHH_KL1CK(PKKLTChong obj)
        {
            double result = 0;
            if (obj.DonVi == "M3")
            {
                if (string.IsNullOrEmpty(obj.KTHH_GhiChu) || obj.KTHH_GhiChu == "0")
                {
                    result = obj.KTHH_D * obj.KTHH_R * obj.KTHH_C;
                }
                else if (obj.KTHH_GhiChu == "Rộng*Cao")
                {
                    result = obj.KTHH_DienTich * obj.KTHH_D;
                }
                else if (obj.KTHH_GhiChu == "Dài*Cao")
                {
                    result = obj.KTHH_DienTich * obj.KTHH_R;
                }
                else if (obj.KTHH_GhiChu == "Dài*Rộng")
                {
                    result = obj.KTHH_DienTich * obj.KTHH_C;
                }

            }
            return Math.Round(result, 4);
        }
        public double TTCDT_KL(PKKLTChong obj)
        {
            double result = 0;
            if (obj.DonVi.ToUpper().Trim() == "M2")
            {
                if (string.IsNullOrEmpty(obj.TTCDT_DienTich.ToString()) || obj.TTCDT_DienTich == 0)
                {
                    result = obj.KTHH_D * obj.KTHH_C * obj.TTCDT_CDai + obj.KTHH_R * obj.KTHH_C * obj.TTCDT_CRong + obj.KTHH_D * obj.KTHH_R * obj.TTCDT_CDay;
                }
                else
                {
                    result = obj.TTCDT_DienTich;
                }
            }
            return Math.Round(result, 4);
        }
        public double KL1CK_ChuaTruCC(PKKLTChong obj)
        {
            double result = 0;
            if (obj.KTHH_KL1CK > 0)
            {
                result = obj.KTHH_KL1CK * obj.KTHH_SLCauKien;
            }
            else if (obj.TTCDT_KL > 0)
            {
                result = obj.TTCDT_KL * obj.TTCDT_SLCK;
            }
            else
            {
                result = obj.KLKP_KL * obj.KLKP_Sl;
            }
            return Math.Round(result, 4);
        }

    }
}
