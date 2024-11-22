using DucAnhERP.Components.Pages.NghiepVuCongTrinh.PKKL;
using DucAnhERP.Data;
using DucAnhERP.Helpers;
using DucAnhERP.Models;
using DucAnhERP.Repository;
using DucAnhERP.ViewModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DucAnhERP.Services
{
    public class TKThepMongCTronRepository :ITKThepMongCTronRepository
    {
        private readonly IDbContextFactory<ApplicationDbContext> _context;
        private readonly PKKLMongCTronRepository _pKKLMongCTronRepository;
        public TKThepMongCTronRepository(IDbContextFactory<ApplicationDbContext> context)
        {
            _context = context;
            _pKKLMongCTronRepository = new PKKLMongCTronRepository(context);
        }
        public async Task<List<TKThepMongCTron>> GetAll()
        {
            try
            {
                using var context = _context.CreateDbContext();
                var entity = await context.TKThepMongCTrons.ToListAsync();
                return entity;
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.Error.WriteLine($"An error occurred: {ex.Message}");
                throw; // Optionally rethrow the exception
            }
        }
        public async Task<TKThepMongCTron> GetById(string id)
        {
            using var context = _context.CreateDbContext();
            var entity = await context.TKThepMongCTrons.Where(x => x.Id.Equals(id)).FirstOrDefaultAsync();

            if (entity == null)
            {
                throw new Exception($"Không tìm thấy bản ghi theo ID: {id}");
            }

            return entity;
        }
        public async Task<List<TKThepMongCTronModel>> GetAllByVM(TKThepMongCTronModel mModel)
        {
            try
            {
                using var context = _context.CreateDbContext();
                var query = from a in context.TKThepMongCTrons
                            join b in context.PhanLoaiMongCTrons
                            on a.ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop equals b.Id into plc
                            from b in plc.DefaultIfEmpty()
                            join dm in context.DSDanhMuc
                            on a.LoaiThep equals dm.Id
                            join c in context.DMTLTheps
                            on new { a.LoaiThep, DKCD = a.DKCD.ToString() } equals new { LoaiThep = c.ChungLoaiThep, DKCD = c.DuongKinh } into dmThepGroup
                            from c in dmThepGroup.DefaultIfEmpty()
                            orderby a.SoHieu
                            select new TKThepMongCTronModel
                            {
                                Id = a.Id,
                                Flag = a.Flag,
                                ThongTinLyTrinh_TuyenDuong = a.ThongTinLyTrinh_TuyenDuong,
                                ThongTinLyTrinhTruyenDan_TuLyTrinh = a.ThongTinLyTrinhTruyenDan_TuLyTrinh,
                                ThongTinLyTrinhTruyenDan_DenLyTrinh = a.ThongTinLyTrinhTruyenDan_DenLyTrinh,

                                ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop = a.ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop,
                                PhanLoaiMongCTron_PhanLoaiMongCongTronCongHop = b.ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop??"",

                                TenCongTac = a.TenCongTac,
                                VTLayKhoiLuong = a.VTLayKhoiLuong,
                                LoaiThep = a.LoaiThep,
                                LoaiThep_Name = dm.Ten,

                                SoHieu = a.SoHieu,
                                DKCD = a.DKCD,
                                SoThanh = a.SoThanh,
                                SoCK = a.SoCK,
                                TongSoThanh = a.TongSoThanh,
                                ChieuDai1Thanh = a.ChieuDai1Thanh,
                                TongChieuDai = a.TongChieuDai,
                                TrongLuong = c.TrongLuong,
                                TongTrongLuong = a.TongTrongLuong,

                                CreateAt = a.CreateAt,
                                CreateBy = a.CreateBy,
                                IsActive = a.IsActive,
                            };

                if (!string.IsNullOrEmpty(mModel.ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop))
                {
                    query = query.Where(x => x.ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop == mModel.ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop);
                }
                if (!string.IsNullOrEmpty(mModel.LoaiThep))
                {
                    query = query.Where(x => x.LoaiThep == mModel.LoaiThep);
                }
                var data = await query.Distinct().OrderBy(x => x.PhanLoaiMongCTron_PhanLoaiMongCongTronCongHop).ThenBy(x => x.SoHieu).ToListAsync();
                return data;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }

        }
        public async Task<List<TKThepMongCTron>> GetExist(TKThepMongCTron searchData)
        {
            try
            {
                using var context = _context.CreateDbContext();

                // Thực hiện lọc dữ liệu dựa trên các thuộc tính của searchData
                var query = context.TKThepMongCTrons
                             .Where(item => (
                                     item.ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop == searchData.ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop &&
                                    item.ThongTinLyTrinh_TuyenDuong == searchData.ThongTinLyTrinh_TuyenDuong &&
                                    item.ThongTinLyTrinhTruyenDan_TuLyTrinh == searchData.ThongTinLyTrinhTruyenDan_TuLyTrinh &&
                                    item.ThongTinLyTrinhTruyenDan_DenLyTrinh == searchData.ThongTinLyTrinhTruyenDan_DenLyTrinh &&
                                    item.VTLayKhoiLuong == searchData.VTLayKhoiLuong &&
                                    item.LoaiThep == searchData.LoaiThep &&
                                    item.DKCD == searchData.DKCD &&
                                    item.SoThanh == searchData.SoThanh &&
                                    item.SoCK == searchData.SoCK &&
                                    item.TongSoThanh == searchData.TongSoThanh &&
                                    item.ChieuDai1Thanh == searchData.ChieuDai1Thanh &&
                                    item.TongChieuDai == searchData.TongChieuDai &&
                                    item.TrongLuong == searchData.TrongLuong &&
                                    item.TongTrongLuong == searchData.TongTrongLuong
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
        public async Task<List<SelectedItem>> GetDistinctTenCongTacByPL(string ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop)
        {
            try
            {
                using var context = _context.CreateDbContext();
                var data = context.TKThepMongCTrons
                 .Where(item => item.ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop == ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop)
                 .GroupBy(item => item.TenCongTac)
                 .Select(group => new SelectedItem
                 {
                     Text = group.Key,
                     Value = group.Sum(item => item.TongTrongLuong).ToString()
                 })
                 .Distinct()
                 .ToList();

                return data;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }

        }
        public async Task<SelectedItem> GetSumTenCongTacByPL(string ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop, string TenCongTac)
        {
            try
            {
                using var context = _context.CreateDbContext();
                var data = await context.TKThepMongCTrons
                .Where(item =>
                    item.ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop == ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop &&
                    item.TenCongTac == TenCongTac)
                .GroupBy(item => item.TenCongTac)
                .Select(group => new SelectedItem
                {
                    Text = group.Key,
                    Value = group.Sum(item => item.TongTrongLuong).ToString()
                }).FirstOrDefaultAsync();
                return data;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }

        }
        public async Task Update(TKThepMongCTron TKThepMongCTron)
        {
            using var context = _context.CreateDbContext();
            var entity = GetById(TKThepMongCTron.Id);

            if (entity == null)
            {
                throw new Exception($"Không tìm thấy bản ghi theo ID: {TKThepMongCTron.Id}");
            }

            context.TKThepMongCTrons.Update(TKThepMongCTron);
            await SaveChanges(context);
        }
        public async Task UpdateMulti(TKThepMongCTron[] TKThepMongCTron)
        {
            using var context = _context.CreateDbContext();
            string[] ids = TKThepMongCTron.Select(x => x.Id).ToArray();
            var listEntities = await context.TKThepMongCTrons.Where(x => ids.Contains(x.Id)).ToListAsync();
            foreach (var entity in listEntities)
            {
                context.TKThepMongCTrons.Update(entity);
            }
            await context.SaveChangesAsync();
        }
        public async Task DeleteById(string id)
        {
            using var context = _context.CreateDbContext();
            var entity = await GetById(id);

            if (entity == null)
            {
                throw new Exception($"Không tìm thấy bản ghi theo ID: {id}");
            }

            context.Set<TKThepMongCTron>().Remove(entity);
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
        public async Task Insert(TKThepMongCTron entity)
        {
            try
            {
                using var context = _context.CreateDbContext();
                if (entity == null)
                {
                    throw new Exception("Không có bản ghi nào để thêm!");
                }

                // Lấy tất cả các bản ghi phù hợp và thực hiện xử lý trên client-side
                var maxFlagValue = await context.TKThepMongCTrons
                    .Where(x => x.ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop == entity.ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop)
                    .Select(x => x.Flag)
                    .ToListAsync(); // Lấy danh sách các giá trị Flag

                // Kiểm tra nếu danh sách không có giá trị nào, trả về 0, ngược lại lấy giá trị lớn nhất
                var maxFlag = maxFlagValue.Any() ? maxFlagValue.Max() : 0;


                // Tăng giá trị Flag lên 1
                entity.Flag = maxFlag + 1;

                // Chèn bản ghi mới vào bảng
                context.TKThepMongCTrons.Add(entity);
                await SaveChanges(context);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public async Task<string> InsertLaterFlag(TKThepMongCTron entity, int FlagLast)
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
                var recordsToUpdate = await context.TKThepMongCTrons
                    .Where(x => x.Flag > FlagLast && x.ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop == entity.ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop)
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
                    var maxFlag = await context.TKThepMongCTrons.AnyAsync()
                                  ? await context.TKThepMongCTrons.MaxAsync(x => x.Flag)
                                  : 0;

                    // Tăng giá trị Flag lên 1
                    entity.Flag = maxFlag + 1;
                }
                else
                {
                    entity.Flag = FlagLast + 1;
                }

                // Bước 4: Chèn bản ghi mới vào bảng
                context.TKThepMongCTrons.Add(entity);

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
        private async Task HandleEntityAdd(EntityEntry entityEntry)
        {
            var addedEntity = entityEntry.Entity as TKThepMongCTron;
            if (addedEntity != null)
            {
                PKKLModel pkklModel = new PKKLModel { HangMuc = "III.Sản xuất + V.Chuyển B.Tông T.Phẩm móng cống tròn", TenCongTac = addedEntity.TenCongTac ?? "", LoaiCauKienId = addedEntity.ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop };
                List<PKKLModel> result = await _pKKLMongCTronRepository.GetAllByVM(pkklModel);
                if (result != null)
                {
                    List<PKKLMongCTron> pKKLMongCTrons = new List<PKKLMongCTron>();
                    foreach (var record in result)
                    {
                        PKKLMongCTron pKKLMongCTron = new PKKLMongCTron();
                        if (!string.IsNullOrEmpty(record.TenCongTac))
                        {
                            pKKLMongCTron.Id = record.Id;
                            pKKLMongCTron.Flag = record.Flag;
                            pKKLMongCTron.ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop = record.LoaiCauKienId;
                            pKKLMongCTron.LoaiBeTong = record.LoaiBeTong;
                            pKKLMongCTron.HangMuc = record.HangMuc;
                            pKKLMongCTron.HangMucCongTac = record.HangMucCongTac;
                            pKKLMongCTron.TenCongTac = record.TenCongTac;
                            pKKLMongCTron.DonVi = record.DonVi;
                            pKKLMongCTron.KTHH_D = record.KTHH_D;
                            pKKLMongCTron.KTHH_R = record.KTHH_R;
                            pKKLMongCTron.KTHH_C = record.KTHH_C;
                            pKKLMongCTron.KTHH_DienTich = record.KTHH_DienTich;
                            pKKLMongCTron.KTHH_GhiChu = record.KTHH_GhiChu;
                            pKKLMongCTron.KTHH_SLCauKien = record.KTHH_SLCauKien;
                            pKKLMongCTron.TTCDT_CDai = record.TTCDT_CDai;
                            pKKLMongCTron.TTCDT_CRong = record.TTCDT_CRong;
                            pKKLMongCTron.TTCDT_CDay = record.TTCDT_CDay;
                            pKKLMongCTron.TTCDT_DienTich = record.TTCDT_DienTich;
                            pKKLMongCTron.TTCDT_SLCK = record.TTCDT_SLCK;
                            pKKLMongCTron.KLKP_Sl = record.KLKP_Sl;
                            pKKLMongCTron.KLCC1CK = record.KLCC1CK;
                            pKKLMongCTron.CreateAt = record.CreateAt;
                            pKKLMongCTron.CreateBy = record.CreateBy;
                            // Xử lý khi giá trị không thể chuyển đổi thành số
                            pKKLMongCTron.KLKP_KL = addedEntity.TongTrongLuong ?? 0;

                            var SumTenCongTacByPL = await GetSumTenCongTacByPL(addedEntity.ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop, addedEntity.TenCongTac ?? "");
                            if (SumTenCongTacByPL != null && SumTenCongTacByPL.Value != null)
                            {
                                if (double.TryParse(SumTenCongTacByPL.Value, out double parsedValue))
                                {
                                    pKKLMongCTron.KLKP_KL = parsedValue + addedEntity.TongTrongLuong ?? 0;
                                }
                               
                            }
                            pKKLMongCTron.KTHH_KL1CK = _pKKLMongCTronRepository.KTHH_KL1CK(record.DonVi, record.KTHH_D, record.KTHH_R, record.KTHH_C, record.KTHH_DienTich, record.KTHH_GhiChu);
                            pKKLMongCTron.TTCDT_KL = _pKKLMongCTronRepository.TTCDT_KL(record.DonVi, record.KTHH_D, record.KTHH_R, record.KTHH_C, record.TTCDT_CDai, record.TTCDT_CRong, record.TTCDT_CDay, record.TTCDT_DienTich);
                            pKKLMongCTron.KL1CK_ChuaTruCC = _pKKLMongCTronRepository.KL1CK_ChuaTruCC(record.KTHH_KL1CK, record.KTHH_SLCauKien, record.TTCDT_KL, record.TTCDT_SLCK, pKKLMongCTron.KLKP_KL, record.KLKP_Sl);
                            pKKLMongCTron.TKLCK_SauCC = pKKLMongCTron.KL1CK_ChuaTruCC - pKKLMongCTron.KLCC1CK;
                            pKKLMongCTrons.Add(pKKLMongCTron);
                        }

                    }
                    await _pKKLMongCTronRepository.UpdateMulti(pKKLMongCTrons.ToArray());
                }
            }
        }

        private async Task HandleEntityDelete(EntityEntry entityEntry)
        {
            var deletedEntity = entityEntry.Entity as TKThepMongCTron;
            if (deletedEntity != null)
            {
                TKThepMongCTron entity = await GetById(deletedEntity.Id);

                if (entity == null)
                {
                    throw new Exception($"Không tìm thấy bản ghi theo ID: {deletedEntity.Id}");
                }
                PKKLModel pkklModel = new PKKLModel { HangMuc = "III.Gia công, lắp dựng cốt thép", TenCongTac = entity.TenCongTac ?? "", LoaiCauKienId = entity.ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop };
                List<PKKLModel> result = await _pKKLMongCTronRepository.GetAllByVM(pkklModel);
                if (result != null)
                {
                    List<PKKLMongCTron> pKKLMongCTrons = new List<PKKLMongCTron>();
                    foreach (var record in result)
                    {
                        PKKLMongCTron pKKLMongCTron = new PKKLMongCTron();
                        if (!string.IsNullOrEmpty(record.TenCongTac))
                        {
                            pKKLMongCTron.Id = record.Id;
                            pKKLMongCTron.Flag = record.Flag;
                            pKKLMongCTron.ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop = record.LoaiCauKienId;
                            pKKLMongCTron.LoaiBeTong = record.LoaiBeTong;
                            pKKLMongCTron.HangMuc = record.HangMuc;
                            pKKLMongCTron.HangMucCongTac = record.HangMucCongTac;
                            pKKLMongCTron.DonVi = record.DonVi;
                            pKKLMongCTron.KTHH_D = record.KTHH_D;
                            pKKLMongCTron.KTHH_R = record.KTHH_R;
                            pKKLMongCTron.KTHH_C = record.KTHH_C;
                            pKKLMongCTron.KTHH_DienTich = record.KTHH_DienTich;
                            pKKLMongCTron.KTHH_GhiChu = record.KTHH_GhiChu;
                            pKKLMongCTron.KTHH_SLCauKien = record.KTHH_SLCauKien;
                            pKKLMongCTron.TTCDT_CDai = record.TTCDT_CDai;
                            pKKLMongCTron.TTCDT_CRong = record.TTCDT_CRong;
                            pKKLMongCTron.TTCDT_CDay = record.TTCDT_CDay;
                            pKKLMongCTron.TTCDT_DienTich = record.TTCDT_DienTich;
                            pKKLMongCTron.TTCDT_SLCK = record.TTCDT_SLCK;
                            pKKLMongCTron.KLKP_Sl = record.KLKP_Sl;
                            pKKLMongCTron.KLCC1CK = record.KLCC1CK;
                            pKKLMongCTron.CreateAt = record.CreateAt;
                            pKKLMongCTron.CreateBy = record.CreateBy;
                            // Xử lý khi giá trị không thể chuyển đổi thành số
                            pKKLMongCTron.KLKP_KL = deletedEntity.TongTrongLuong - entity.TongTrongLuong ?? 0;
                            pKKLMongCTron.TenCongTac = "";

                            var SumTenCongTacByPL = await GetSumTenCongTacByPL(entity.ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop, entity.TenCongTac ?? "");
                            if (SumTenCongTacByPL != null && SumTenCongTacByPL.Value != null)
                            {
                                if (double.TryParse(SumTenCongTacByPL.Value, out double parsedValue))
                                {
                                    pKKLMongCTron.KLKP_KL = parsedValue - deletedEntity.TongTrongLuong ?? 0;
                                    pKKLMongCTron.TenCongTac = record.TenCongTac;
                                }
                                
                            }
                            pKKLMongCTron.KTHH_KL1CK = _pKKLMongCTronRepository.KTHH_KL1CK(record.DonVi, record.KTHH_D, record.KTHH_R, record.KTHH_C, record.KTHH_DienTich, record.KTHH_GhiChu);
                            pKKLMongCTron.TTCDT_KL = _pKKLMongCTronRepository.TTCDT_KL(record.DonVi, record.KTHH_D, record.KTHH_R, record.KTHH_C, record.TTCDT_CDai, record.TTCDT_CRong, record.TTCDT_CDay, record.TTCDT_DienTich);
                            pKKLMongCTron.KL1CK_ChuaTruCC = _pKKLMongCTronRepository.KL1CK_ChuaTruCC(record.KTHH_KL1CK, record.KTHH_SLCauKien, record.TTCDT_KL, record.TTCDT_SLCK, pKKLMongCTron.KLKP_KL, record.KLKP_Sl);
                            pKKLMongCTron.TKLCK_SauCC = pKKLMongCTron.KL1CK_ChuaTruCC - pKKLMongCTron.KLCC1CK;
                            pKKLMongCTrons.Add(pKKLMongCTron);
                        }

                    }
                    await _pKKLMongCTronRepository.UpdateMulti(pKKLMongCTrons.ToArray());
                }
            }
        }
        private async Task HandleEntityUpdate(EntityEntry entityEntry)
        {
            try
            {

                var modifiedEntity = entityEntry.Entity as TKThepMongCTron;

                if (modifiedEntity != null)
                {
                    TKThepMongCTron entity = await GetById(modifiedEntity.Id);

                    if (entity == null)
                    {
                        throw new Exception($"Không tìm thấy bản ghi theo ID: {modifiedEntity.Id}");
                    }
                    PKKLModel pkklModel = new PKKLModel { HangMuc = "III.Gia công, lắp dựng cốt thép", TenCongTac = entity.TenCongTac ?? "", LoaiCauKienId = entity.ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop };
                    List<PKKLModel> result = await _pKKLMongCTronRepository.GetAllByVM(pkklModel);
                    if (result != null) 
                    {
                        List<PKKLMongCTron> pKKLMongCTrons = new List<PKKLMongCTron>();
                        foreach (var record in result)
                        {
                            PKKLMongCTron pKKLMongCTron = new PKKLMongCTron();
                            if (!string.IsNullOrEmpty(record.TenCongTac))
                            {
                                pKKLMongCTron.Id = record.Id;
                                pKKLMongCTron.Flag = record.Flag;
                                pKKLMongCTron.ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop = record.LoaiCauKienId;
                                pKKLMongCTron.LoaiBeTong = record.LoaiBeTong;
                                pKKLMongCTron.HangMuc = record.HangMuc;
                                pKKLMongCTron.HangMucCongTac = record.HangMucCongTac;
                                pKKLMongCTron.TenCongTac = record.TenCongTac;
                                pKKLMongCTron.DonVi = record.DonVi;
                                pKKLMongCTron.KTHH_D = record.KTHH_D;
                                pKKLMongCTron.KTHH_R = record.KTHH_R;
                                pKKLMongCTron.KTHH_C = record.KTHH_C;
                                pKKLMongCTron.KTHH_DienTich = record.KTHH_DienTich;
                                pKKLMongCTron.KTHH_GhiChu = record.KTHH_GhiChu;
                                pKKLMongCTron.KTHH_SLCauKien = record.KTHH_SLCauKien;
                                pKKLMongCTron.TTCDT_CDai = record.TTCDT_CDai;
                                pKKLMongCTron.TTCDT_CRong = record.TTCDT_CRong;
                                pKKLMongCTron.TTCDT_CDay = record.TTCDT_CDay;
                                pKKLMongCTron.TTCDT_DienTich = record.TTCDT_DienTich;
                                pKKLMongCTron.TTCDT_SLCK = record.TTCDT_SLCK;
                                pKKLMongCTron.KLKP_Sl = record.KLKP_Sl;
                                pKKLMongCTron.KLCC1CK = record.KLCC1CK;
                                pKKLMongCTron.CreateAt = record.CreateAt;
                                pKKLMongCTron.CreateBy = record.CreateBy;
                                // Xử lý khi giá trị không thể chuyển đổi thành số
                                pKKLMongCTron.KLKP_KL = modifiedEntity.TongTrongLuong - entity.TongTrongLuong ?? 0;

                                var SumTenCongTacByPL = await GetSumTenCongTacByPL(entity.ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop, entity.TenCongTac ?? "");
                                if (SumTenCongTacByPL != null && SumTenCongTacByPL.Value != null)
                                {
                                    if (double.TryParse(SumTenCongTacByPL.Value, out double parsedValue))
                                    {
                                        pKKLMongCTron.KLKP_KL = (parsedValue - entity.TongTrongLuong) + modifiedEntity.TongTrongLuong ?? 0;
                                    }
                                   
                                }

                                pKKLMongCTron.KTHH_KL1CK = _pKKLMongCTronRepository.KTHH_KL1CK(record.DonVi, record.KTHH_D, record.KTHH_R, record.KTHH_C, record.KTHH_DienTich, record.KTHH_GhiChu);
                                pKKLMongCTron.TTCDT_KL = _pKKLMongCTronRepository.TTCDT_KL(record.DonVi, record.KTHH_D, record.KTHH_R, record.KTHH_C, record.TTCDT_CDai, record.TTCDT_CRong, record.TTCDT_CDay, record.TTCDT_DienTich);
                                pKKLMongCTron.KL1CK_ChuaTruCC = _pKKLMongCTronRepository.KL1CK_ChuaTruCC(record.KTHH_KL1CK, record.KTHH_SLCauKien, record.TTCDT_KL, record.TTCDT_SLCK, pKKLMongCTron.KLKP_KL, record.KLKP_Sl);
                                pKKLMongCTron.TKLCK_SauCC = pKKLMongCTron.KL1CK_ChuaTruCC - pKKLMongCTron.KLCC1CK;
                                pKKLMongCTrons.Add(pKKLMongCTron);
                            }

                        }
                        await _pKKLMongCTronRepository.UpdateMulti(pKKLMongCTrons.ToArray());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
