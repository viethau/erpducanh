using DucAnhERP.Data;
using DucAnhERP.Helpers;
using DucAnhERP.Models;
using DucAnhERP.Repository;
using DucAnhERP.ViewModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DucAnhERP.Services
{
    public class TKThepRXayRepository : ITKThepRXayRepository
    {
        private readonly IDbContextFactory<ApplicationDbContext> _context;
        private readonly PKKLRXayRepository _pKKLRXayRepository;
        public TKThepRXayRepository(IDbContextFactory<ApplicationDbContext> context)
        {
            _context = context;
            _pKKLRXayRepository = new PKKLRXayRepository(context);
        }
        public async Task<List<TKThepRXay>> GetAll()
        {
            try
            {
                using var context = _context.CreateDbContext();
                var entity = await context.TKThepRXays.ToListAsync();
                return entity;
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.Error.WriteLine($"An error occurred: {ex.Message}");
                throw; // Optionally rethrow the exception
            }
        }
        public async Task<TKThepRXay> GetById(string id)
        {
            using var context = _context.CreateDbContext();
            var entity = await context.TKThepRXays.Where(x => x.Id.Equals(id)).FirstOrDefaultAsync();

            if (entity == null)
            {
                throw new Exception($"Không tìm thấy bản ghi theo ID: {id}");
            }

            return entity;
        }
        public async Task<List<TKThepRXayModel>> GetAllByVM(TKThepRXayModel mModel)
        {
            try
            {
                using var context = _context.CreateDbContext();
                var query = from a in context.TKThepRXays
                            join b in context.PhanLoaiCTronHopNhuas
                            on a.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai equals b.Id into plc
                            from b in plc.DefaultIfEmpty()
                            join dm in context.DSDanhMuc
                            on a.LoaiThep equals dm.Id
                            join c in context.DMTLTheps
                            on new { a.LoaiThep, DKCD = a.DKCD.ToString() } equals new { LoaiThep = c.ChungLoaiThep, DKCD = c.DuongKinh } into dmThepGroup
                            from c in dmThepGroup.DefaultIfEmpty()
                            orderby a.SoHieu
                            select new TKThepRXayModel
                            {
                                Id = a.Id,
                                Flag = a.Flag,

                                ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai = a.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai,
                                PhanLoaiCTronHopNhua_TenLoaiTruyenDanSauPhanLoai = b.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai,

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

                if (!string.IsNullOrEmpty(mModel.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai))
                {
                    query = query.Where(x => x.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai == mModel.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai);
                }
                if (!string.IsNullOrEmpty(mModel.LoaiThep))
                {
                    query = query.Where(x => x.LoaiThep == mModel.LoaiThep);
                }
                var data = await query.Distinct().OrderBy(x => x.PhanLoaiCTronHopNhua_TenLoaiTruyenDanSauPhanLoai).ThenBy(x => x.SoHieu).ToListAsync();
                return data;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }

        }
        public async Task<List<SelectedItem>> GetDistinctTenCongTacByPL(string ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai)
        {
            try
            {
                using var context = _context.CreateDbContext();
                var data = context.TKThepRXays
                 .Where(item => item.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai == ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai)
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
        public async Task<SelectedItem> GetSumTenCongTacByPL(string ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai, string TenCongTac)
        {
            try
            {
                using var context = _context.CreateDbContext();
                var data = await context.TKThepRXays
                .Where(item =>
                    item.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai == ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai &&
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
        public async Task<List<TKThepRXay>> GetExist(TKThepRXay searchData)
        {
            try
            {
                using var context = _context.CreateDbContext();

                // Thực hiện lọc dữ liệu dựa trên các thuộc tính của searchData
                var query = context.TKThepRXays
                             .Where(item => (
                                    item.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai == searchData.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai &&
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
        public async Task Update(TKThepRXay TKThepRXay)
        {
            using var context = _context.CreateDbContext();
            var entity = GetById(TKThepRXay.Id);

            if (entity == null)
            {
                throw new Exception($"Không tìm thấy bản ghi theo ID: {TKThepRXay.Id}");
            }

            context.TKThepRXays.Update(TKThepRXay);
            await SaveChanges(context);
        }
        //public async Task UpdateMulti(TKThepRXay[] TKThepRXay)
        //{
        //    using var context = _context.CreateDbContext();
        //    string[] ids = TKThepRXay.Select(x => x.Id).ToArray();
        //    var listEntities = await context.TKThepRXays.Where(x => ids.Contains(x.Id)).ToListAsync();
        //    foreach (var entity in listEntities)
        //    {
        //        context.TKThepRXays.Update(entity);
        //    }
        //    await context.SaveChangesAsync();
        //}

        public async Task UpdateMulti(TKThepRXay[] tKThepRXayArray)
        {
            using var context = _context.CreateDbContext();

            // Lấy danh sách ID từ mảng đầu vào
            var ids = tKThepRXayArray.Select(x => x.Id).ToArray();

            // Lấy danh sách thực thể từ cơ sở dữ liệu
            var listEntities = await context.TKThepRXays
                .Where(x => ids.Contains(x.Id))
                .ToListAsync();

            // Cập nhật các thực thể
            foreach (var entity in listEntities)
            {
                // Tìm thực thể cần cập nhật từ mảng đầu vào
                var updatedEntity = tKThepRXayArray.FirstOrDefault(x => x.Id == entity.Id);
                if (updatedEntity != null)
                {
                    // Cập nhật chỉ các giá trị thay đổi
                    context.Entry(entity).CurrentValues.SetValues(updatedEntity);
                }
            }
            await SaveChanges(context);
        }

        public async Task DeleteById(string id)
        {
            using var context = _context.CreateDbContext();
            var entity = await GetById(id);

            if (entity == null)
            {
                throw new Exception($"Không tìm thấy bản ghi theo ID: {id}");
            }
            // Bước 1: Cập nhật trực tiếp các bản ghi có flag > FlagLast
            await context.TKThepRXays
                .Where(x => x.Flag > entity.Flag &&
                            x.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai == entity.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai)
                .ExecuteUpdateAsync(x => x
                    .SetProperty(r => r.Flag, r => r.Flag - 1)
                    .SetProperty(r => r.SoHieu, r => r.SoHieu - 1));

            // Bước 2: Xóa bản ghi
            context.TKThepRXays.Remove(entity);
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
        public async Task Insert(TKThepRXay entity)
        {
            try
            {
                using var context = _context.CreateDbContext();
                if (entity == null)
                {
                    throw new Exception("Không có bản ghi nào để thêm!");
                }

                // Lấy tất cả các bản ghi phù hợp và thực hiện xử lý trên client-side
                var maxFlagValue = await context.TKThepRXays
                    .Where(x => x.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai == entity.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai)
                    .Select(x => x.Flag)
                    .ToListAsync(); // Lấy danh sách các giá trị Flag

                // Kiểm tra nếu danh sách không có giá trị nào, trả về 0, ngược lại lấy giá trị lớn nhất
                var maxFlag = maxFlagValue.Any() ? maxFlagValue.Max() : 0;


                // Tăng giá trị Flag lên 1
                entity.Flag = maxFlag + 1;

                // Chèn bản ghi mới vào bảng
                context.TKThepRXays.Add(entity);
                await SaveChanges(context);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public async Task<string> InsertLaterFlag(TKThepRXay entity, int FlagLast, bool insertBefore)
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
                var recordsToUpdate = await context.TKThepRXays
                    .Where(x => (insertBefore ? x.Flag >= FlagLast : x.Flag > FlagLast)
                    && x.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai == entity.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai)
                    .ToListAsync();

                // Bước 2: Tăng giá trị flag của các bản ghi đó thêm 1
                foreach (var record in recordsToUpdate)
                {
                    record.Flag += 1;
                    record.SoHieu += 1;
                }

                // Lưu các thay đổi cập nhật flag
                await context.SaveChangesAsync();

                // Bước 3: Đặt flag cho bản ghi mới bằng 3
                if (recordsToUpdate.Count() == 0)
                {
                    // Kiểm tra xem bảng có bản ghi nào không
                    var maxFlag = await context.TKThepRXays.AnyAsync()
                                  ? await context.TKThepRXays.MaxAsync(x => x.Flag)
                                  : 0;

                    // Tăng giá trị Flag lên 1
                    entity.Flag = maxFlag + 1;
                }
                else
                {
                    entity.Flag = insertBefore ? FlagLast : FlagLast + 1;
                }

                // Bước 4: Chèn bản ghi mới vào bảng
                context.TKThepRXays.Add(entity);

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
            var addedEntity = entityEntry.Entity as TKThepRXay;
            if (addedEntity != null)
            {
                PKKLModel pkklModel = new PKKLModel { HangMuc = "V.Gia công, lắp dựng cốt thép", TenCongTac = addedEntity.TenCongTac ?? "", LoaiCauKienId = addedEntity.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai };
                List<PKKLModel> result = await _pKKLRXayRepository.GetAllByVM(pkklModel);
                if (result != null)
                {
                    List<PKKLRXay> PKKLRXays = new List<PKKLRXay>();
                    foreach (var record in result)
                    {
                        PKKLRXay PKKLRXay = new PKKLRXay();
                        if (!string.IsNullOrEmpty(record.TenCongTac))
                        {
                            PKKLRXay.Id = record.Id;
                            PKKLRXay.Flag = record.Flag;
                            PKKLRXay.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai = record.LoaiCauKienId;
                            PKKLRXay.LoaiBeTong = record.LoaiBeTong;
                            PKKLRXay.HangMuc = record.HangMuc;
                            PKKLRXay.HangMucCongTac = record.HangMucCongTac;
                            PKKLRXay.TenCongTac = record.TenCongTac;
                            PKKLRXay.DonVi = record.DonVi;
                            PKKLRXay.KTHH_D = record.KTHH_D;
                            PKKLRXay.KTHH_R = record.KTHH_R;
                            PKKLRXay.KTHH_C = record.KTHH_C;
                            PKKLRXay.KTHH_DienTich = record.KTHH_DienTich;
                            PKKLRXay.KTHH_GhiChu = record.KTHH_GhiChu;
                            PKKLRXay.KTHH_SLCauKien = record.KTHH_SLCauKien;
                            PKKLRXay.TTCDT_CDai = record.TTCDT_CDai;
                            PKKLRXay.TTCDT_CRong = record.TTCDT_CRong;
                            PKKLRXay.TTCDT_CDay = record.TTCDT_CDay;
                            PKKLRXay.TTCDT_DienTich = record.TTCDT_DienTich;
                            PKKLRXay.TTCDT_SLCK = record.TTCDT_SLCK;
                            PKKLRXay.KLKP_Sl = record.KLKP_Sl;
                            PKKLRXay.KLCC1CK = record.KLCC1CK;
                            PKKLRXay.CreateAt = record.CreateAt;
                            PKKLRXay.CreateBy = record.CreateBy;
                            PKKLRXay.KLKP_KL = addedEntity.TongTrongLuong ?? 0;

                            var SumTenCongTacByPL = await GetSumTenCongTacByPL(addedEntity.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai, addedEntity.TenCongTac ?? "");
                            if (SumTenCongTacByPL != null && SumTenCongTacByPL.Value != null)
                            {
                                if (double.TryParse(SumTenCongTacByPL.Value, out double parsedValue))
                                {
                                    PKKLRXay.KLKP_KL = parsedValue + addedEntity.TongTrongLuong ?? 0;
                                }

                            }
                            PKKLRXay.KTHH_KL1CK = _pKKLRXayRepository.KTHH_KL1CK(PKKLRXay);
                            PKKLRXay.TTCDT_KL = _pKKLRXayRepository.TTCDT_KL(PKKLRXay);
                            PKKLRXay.KL1CK_ChuaTruCC = _pKKLRXayRepository.KL1CK_ChuaTruCC(PKKLRXay);
                            PKKLRXay.TKLCK_SauCC = Math.Round((PKKLRXay.KL1CK_ChuaTruCC - PKKLRXay.KLCC1CK),4);
                            PKKLRXays.Add(PKKLRXay);
                        }

                    }
                    await _pKKLRXayRepository.UpdateMulti(PKKLRXays.ToArray());
                }
            }
        }
        private async Task HandleEntityDelete(EntityEntry entityEntry)
        {
            var deletedEntity = entityEntry.Entity as TKThepRXay;
            if (deletedEntity != null)
            {
                TKThepRXay entity = await GetById(deletedEntity.Id);

                if (entity == null)
                {
                    throw new Exception($"Không tìm thấy bản ghi theo ID: {deletedEntity.Id}");
                }
                PKKLModel pkklModel = new PKKLModel { HangMuc = "V.Gia công, lắp dựng cốt thép", TenCongTac = entity.TenCongTac ?? "", LoaiCauKienId = entity.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai };
                List<PKKLModel> result = await _pKKLRXayRepository.GetAllByVM(pkklModel);
                if (result != null)
                {
                    List<PKKLRXay> PKKLRXays = new List<PKKLRXay>();
                    foreach (var record in result)
                    {
                        PKKLRXay PKKLRXay = new PKKLRXay();
                        if (!string.IsNullOrEmpty(record.TenCongTac))
                        {
                            PKKLRXay.Id = record.Id;
                            PKKLRXay.Flag = record.Flag;
                            PKKLRXay.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai = record.LoaiCauKienId;
                            PKKLRXay.LoaiBeTong = record.LoaiBeTong;
                            PKKLRXay.HangMuc = record.HangMuc;
                            PKKLRXay.HangMucCongTac = record.HangMucCongTac;
                            PKKLRXay.DonVi = record.DonVi;
                            PKKLRXay.KTHH_D = record.KTHH_D;
                            PKKLRXay.KTHH_R = record.KTHH_R;
                            PKKLRXay.KTHH_C = record.KTHH_C;
                            PKKLRXay.KTHH_DienTich = record.KTHH_DienTich;
                            PKKLRXay.KTHH_GhiChu = record.KTHH_GhiChu;
                            PKKLRXay.KTHH_SLCauKien = record.KTHH_SLCauKien;
                            PKKLRXay.TTCDT_CDai = record.TTCDT_CDai;
                            PKKLRXay.TTCDT_CRong = record.TTCDT_CRong;
                            PKKLRXay.TTCDT_CDay = record.TTCDT_CDay;
                            PKKLRXay.TTCDT_DienTich = record.TTCDT_DienTich;
                            PKKLRXay.TTCDT_SLCK = record.TTCDT_SLCK;
                            PKKLRXay.KLKP_Sl = record.KLKP_Sl;
                            PKKLRXay.KLCC1CK = record.KLCC1CK;
                            PKKLRXay.CreateAt = record.CreateAt;
                            PKKLRXay.CreateBy = record.CreateBy;
                            PKKLRXay.KLKP_KL = deletedEntity.TongTrongLuong - entity.TongTrongLuong ?? 0;
                            PKKLRXay.TenCongTac = "";

                            var SumTenCongTacByPL = await GetSumTenCongTacByPL(entity.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai, entity.TenCongTac ?? "");
                            if (SumTenCongTacByPL != null && SumTenCongTacByPL.Value != null)
                            {
                                if (double.TryParse(SumTenCongTacByPL.Value, out double parsedValue))
                                {
                                    PKKLRXay.KLKP_KL = parsedValue - deletedEntity.TongTrongLuong ?? 0;
                                    PKKLRXay.TenCongTac = record.TenCongTac;
                                }

                            }
                            PKKLRXay.KTHH_KL1CK = _pKKLRXayRepository.KTHH_KL1CK(PKKLRXay);
                            PKKLRXay.TTCDT_KL = _pKKLRXayRepository.TTCDT_KL(PKKLRXay);
                            PKKLRXay.KL1CK_ChuaTruCC = _pKKLRXayRepository.KL1CK_ChuaTruCC(PKKLRXay);
                            PKKLRXay.TKLCK_SauCC = Math.Round((PKKLRXay.KL1CK_ChuaTruCC - PKKLRXay.KLCC1CK),4);
                            PKKLRXays.Add(PKKLRXay);
                        }

                    }
                    await _pKKLRXayRepository.UpdateMulti(PKKLRXays.ToArray());
                }
            }
        }
        private async Task HandleEntityUpdate(EntityEntry entityEntry)
        {
            try
            {

                var modifiedEntity = entityEntry.Entity as TKThepRXay;

                if (modifiedEntity != null)
                {
                    TKThepRXay entity = await GetById(modifiedEntity.Id);

                    if (entity == null)
                    {
                        throw new Exception($"Không tìm thấy bản ghi theo ID: {modifiedEntity.Id}");
                    }
                    PKKLModel pkklModel = new PKKLModel { HangMuc = "V.Gia công, lắp dựng cốt thép", TenCongTac = entity.TenCongTac ?? "", LoaiCauKienId = entity.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai };
                    List<PKKLModel> result = await _pKKLRXayRepository.GetAllByVM(pkklModel);
                    if (result != null)
                    {
                        List<PKKLRXay> PKKLRXays = new List<PKKLRXay>();
                        foreach (var record in result)
                        {
                            PKKLRXay PKKLRXay = new PKKLRXay();
                            if (!string.IsNullOrEmpty(record.TenCongTac))
                            {
                                PKKLRXay.Id = record.Id;
                                PKKLRXay.Flag = record.Flag;
                                PKKLRXay.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai = record.LoaiCauKienId;
                                PKKLRXay.LoaiBeTong = record.LoaiBeTong;
                                PKKLRXay.HangMuc = record.HangMuc;
                                PKKLRXay.HangMucCongTac = record.HangMucCongTac;
                                PKKLRXay.TenCongTac = record.TenCongTac;
                                PKKLRXay.DonVi = record.DonVi;
                                PKKLRXay.KTHH_D = record.KTHH_D;
                                PKKLRXay.KTHH_R = record.KTHH_R;
                                PKKLRXay.KTHH_C = record.KTHH_C;
                                PKKLRXay.KTHH_DienTich = record.KTHH_DienTich;
                                PKKLRXay.KTHH_GhiChu = record.KTHH_GhiChu;
                                PKKLRXay.KTHH_SLCauKien = record.KTHH_SLCauKien;
                                PKKLRXay.TTCDT_CDai = record.TTCDT_CDai;
                                PKKLRXay.TTCDT_CRong = record.TTCDT_CRong;
                                PKKLRXay.TTCDT_CDay = record.TTCDT_CDay;
                                PKKLRXay.TTCDT_DienTich = record.TTCDT_DienTich;
                                PKKLRXay.TTCDT_SLCK = record.TTCDT_SLCK;
                                PKKLRXay.KLKP_Sl = record.KLKP_Sl;
                                PKKLRXay.KLCC1CK = record.KLCC1CK;
                                PKKLRXay.CreateAt = record.CreateAt;
                                PKKLRXay.CreateBy = record.CreateBy;
                                PKKLRXay.KLKP_KL = modifiedEntity.TongTrongLuong - entity.TongTrongLuong ?? 0;

                                var SumTenCongTacByPL = await GetSumTenCongTacByPL(entity.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai, entity.TenCongTac ?? "");
                                if (SumTenCongTacByPL != null && SumTenCongTacByPL.Value != null)
                                {
                                    if (double.TryParse(SumTenCongTacByPL.Value, out double parsedValue))
                                    {
                                        PKKLRXay.KLKP_KL = (parsedValue - entity.TongTrongLuong) + modifiedEntity.TongTrongLuong ?? 0;
                                    }

                                }

                                PKKLRXay.KTHH_KL1CK = _pKKLRXayRepository.KTHH_KL1CK(PKKLRXay);
                                PKKLRXay.TTCDT_KL = _pKKLRXayRepository.TTCDT_KL(PKKLRXay);
                                PKKLRXay.KL1CK_ChuaTruCC = _pKKLRXayRepository.KL1CK_ChuaTruCC(PKKLRXay);
                                PKKLRXay.TKLCK_SauCC = Math.Round((PKKLRXay.KL1CK_ChuaTruCC - PKKLRXay.KLCC1CK),4);
                                PKKLRXays.Add(PKKLRXay);
                            }

                        }
                        await _pKKLRXayRepository.UpdateMulti(PKKLRXays.ToArray());
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
