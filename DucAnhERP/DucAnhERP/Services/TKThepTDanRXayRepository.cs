using DucAnhERP.Data;
using DucAnhERP.Helpers;
using DucAnhERP.Models;
using DucAnhERP.Repository;
using DucAnhERP.ViewModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DucAnhERP.Services
{
    public class TKThepTDanRXayRepository : ITKThepTDanRXayRepository
    {
        private readonly IDbContextFactory<ApplicationDbContext> _context;
        private readonly PKKLTDanRXayRepository _pKKLTDanRXayRepository;
        public TKThepTDanRXayRepository(IDbContextFactory<ApplicationDbContext> context)
        {
            _context = context;
            _pKKLTDanRXayRepository = new PKKLTDanRXayRepository(_context); 
        }
        public async Task<List<TKThepTDanRXay>> GetAll()
        {
            try
            {
                using var context = _context.CreateDbContext();
                var entity = await context.TKThepTDanRXays.ToListAsync();
                return entity;
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.Error.WriteLine($"An error occurred: {ex.Message}");
                throw; // Optionally rethrow the exception
            }
        }
        public async Task<TKThepTDanRXay> GetById(string id)
        {
            using var context = _context.CreateDbContext();
            var entity = await context.TKThepTDanRXays.Where(x => x.Id.Equals(id)).FirstOrDefaultAsync();

            if (entity == null)
            {
                throw new Exception($"Không tìm thấy bản ghi theo ID: {id}");
            }

            return entity;
        }
        public async Task<List<TKThepTDanRXayModel>> GetAllByVM(TKThepTDanRXayModel mModel)
        {
            try
            {
                using var context = _context.CreateDbContext();
                var query = from a in context.TKThepTDanRXays
                            join b in context.PhanLoaiTDanTDans
                            on a.TTTDCongHoRanh_TenLoaiTamDanTieuChuan equals b.Id into plc
                            from b in plc.DefaultIfEmpty()
                            join dm in context.DSDanhMuc
                            on a.LoaiThep equals dm.Id
                            join c in context.DMTLTheps
                            on new { a.LoaiThep, DKCD = a.DKCD.ToString() } equals new { LoaiThep = c.ChungLoaiThep, DKCD = c.DuongKinh } into dmThepGroup
                            from c in dmThepGroup.DefaultIfEmpty()
                            orderby a.SoHieu
                            select new TKThepTDanRXayModel
                            {
                                Id = a.Id,
                                Flag = a.Flag,

                                TTTDCongHoRanh_TenLoaiTamDanTieuChuan = a.TTTDCongHoRanh_TenLoaiTamDanTieuChuan ?? "",
                                PhanLoaiTDanTDan_TenLoaiTamDanTieuChuan = b.TTTDCongHoRanh_TenLoaiTamDanTieuChuan??"",

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

                if (!string.IsNullOrEmpty(mModel.TTTDCongHoRanh_TenLoaiTamDanTieuChuan))
                {
                    query = query.Where(x => x.TTTDCongHoRanh_TenLoaiTamDanTieuChuan == mModel.TTTDCongHoRanh_TenLoaiTamDanTieuChuan);
                }
                if (!string.IsNullOrEmpty(mModel.LoaiThep))
                {
                    query = query.Where(x => x.LoaiThep == mModel.LoaiThep);
                }
                var data = await query.Distinct().OrderBy(x => x.PhanLoaiTDanTDan_TenLoaiTamDanTieuChuan).ThenBy(x => x.SoHieu).ToListAsync();
                return data;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }

        }
        public async Task<List<TKThepTDanRXay>> GetExist(TKThepTDanRXay searchData)
        {
            try
            {
                using var context = _context.CreateDbContext();

                // Thực hiện lọc dữ liệu dựa trên các thuộc tính của searchData
                var query = context.TKThepTDanRXays
                             .Where(item => (
                                    item.TTTDCongHoRanh_TenLoaiTamDanTieuChuan == searchData.TTTDCongHoRanh_TenLoaiTamDanTieuChuan &&
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
        public async Task<List<SelectedItem>> GetDistinctTenCongTacByPL(string TTTDCongHoRanh_TenLoaiTamDanTieuChuan)
        {
            try
            {
                using var context = _context.CreateDbContext();
                var data = context.TKThepTDanRXays
                 .Where(item => item.TTTDCongHoRanh_TenLoaiTamDanTieuChuan == TTTDCongHoRanh_TenLoaiTamDanTieuChuan)
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
        public async Task<SelectedItem> GetSumTenCongTacByPL(string TTTDCongHoRanh_TenLoaiTamDanTieuChuan, string TenCongTac)
        {
            try
            {
                using var context = _context.CreateDbContext();
                var data = await context.TKThepTDanRXays
                .Where(item =>
                    item.TTTDCongHoRanh_TenLoaiTamDanTieuChuan == TTTDCongHoRanh_TenLoaiTamDanTieuChuan &&
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
        public async Task Update(TKThepTDanRXay TKThepTDanRXay)
        {
            using var context = _context.CreateDbContext();
            var entity = GetById(TKThepTDanRXay.Id);

            if (entity == null)
            {
                throw new Exception($"Không tìm thấy bản ghi theo ID: {TKThepTDanRXay.Id}");
            }

            context.TKThepTDanRXays.Update(TKThepTDanRXay);
            await SaveChanges(context);
        }
        public async Task UpdateMulti(TKThepTDanRXay[] TKThepTDanRXay)
        {
            using var context = _context.CreateDbContext();
            string[] ids = TKThepTDanRXay.Select(x => x.Id).ToArray();
            var listEntities = await context.TKThepTDanRXays.Where(x => ids.Contains(x.Id)).ToListAsync();
            foreach (var entity in listEntities)
            {
                context.TKThepTDanRXays.Update(entity);
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

            context.Set<TKThepTDanRXay>().Remove(entity);
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
        public async Task Insert(TKThepTDanRXay entity)
        {
            try
            {
                using var context = _context.CreateDbContext();
                if (entity == null)
                {
                    throw new Exception("Không có bản ghi nào để thêm!");
                }

                // Lấy tất cả các bản ghi phù hợp và thực hiện xử lý trên client-side
                var maxFlagValue = await context.TKThepTDanRXays
                    .Where(x => x.TTTDCongHoRanh_TenLoaiTamDanTieuChuan == entity.TTTDCongHoRanh_TenLoaiTamDanTieuChuan)
                    .Select(x => x.Flag)
                    .ToListAsync(); // Lấy danh sách các giá trị Flag

                // Kiểm tra nếu danh sách không có giá trị nào, trả về 0, ngược lại lấy giá trị lớn nhất
                var maxFlag = maxFlagValue.Any() ? maxFlagValue.Max() : 0;


                // Tăng giá trị Flag lên 1
                entity.Flag = maxFlag + 1;

                // Chèn bản ghi mới vào bảng
                context.TKThepTDanRXays.Add(entity);
                await SaveChanges(context);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public async Task<string> InsertLaterFlag(TKThepTDanRXay entity, int FlagLast)
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
                var recordsToUpdate = await context.TKThepTDanRXays
                    .Where(x => x.Flag > FlagLast && x.TTTDCongHoRanh_TenLoaiTamDanTieuChuan == entity.TTTDCongHoRanh_TenLoaiTamDanTieuChuan)
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
                    var maxFlag = await context.TKThepTDanRXays.AnyAsync()
                                  ? await context.TKThepTDanRXays.MaxAsync(x => x.Flag)
                                  : 0;

                    // Tăng giá trị Flag lên 1
                    entity.Flag = maxFlag + 1;
                }
                else
                {
                    entity.Flag = FlagLast + 1;
                }

                // Bước 4: Chèn bản ghi mới vào bảng
                context.TKThepTDanRXays.Add(entity);

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
            var addedEntity = entityEntry.Entity as TKThepTDanRXay;
            if (addedEntity != null)
            {
                PKKLModel pkklModel = new PKKLModel { HangMuc = "III.Gia công, lắp dựng cốt thép", TenCongTac = addedEntity.TenCongTac ?? "", LoaiCauKienId = addedEntity.TTTDCongHoRanh_TenLoaiTamDanTieuChuan };
                List<PKKLModel> result = await _pKKLTDanRXayRepository.GetAllByVM(pkklModel);
                if (result != null)
                {
                    List<PKKLTDanRXay> PKKLTDanRXays = new List<PKKLTDanRXay>();
                    foreach (var record in result)
                    {
                        PKKLTDanRXay PKKLTDanRXay = new PKKLTDanRXay();
                        if (!string.IsNullOrEmpty(record.TenCongTac))
                        {
                            PKKLTDanRXay.Id = record.Id;
                            PKKLTDanRXay.Flag = record.Flag;
                            PKKLTDanRXay.TTTDCongHoRanh_TenLoaiTamDanTieuChuan = record.LoaiCauKienId;
                            PKKLTDanRXay.LoaiBeTong = record.LoaiBeTong;
                            PKKLTDanRXay.HangMuc = record.HangMuc;
                            PKKLTDanRXay.HangMucCongTac = record.HangMucCongTac;
                            PKKLTDanRXay.TenCongTac = record.TenCongTac;
                            PKKLTDanRXay.DonVi = record.DonVi;
                            PKKLTDanRXay.KTHH_D = record.KTHH_D;
                            PKKLTDanRXay.KTHH_R = record.KTHH_R;
                            PKKLTDanRXay.KTHH_C = record.KTHH_C;
                            PKKLTDanRXay.KTHH_DienTich = record.KTHH_DienTich;
                            PKKLTDanRXay.KTHH_GhiChu = record.KTHH_GhiChu;
                            PKKLTDanRXay.KTHH_SLCauKien = record.KTHH_SLCauKien;
                            PKKLTDanRXay.TTCDT_CDai = record.TTCDT_CDai;
                            PKKLTDanRXay.TTCDT_CRong = record.TTCDT_CRong;
                            PKKLTDanRXay.TTCDT_CDay = record.TTCDT_CDay;
                            PKKLTDanRXay.TTCDT_DienTich = record.TTCDT_DienTich;
                            PKKLTDanRXay.TTCDT_SLCK = record.TTCDT_SLCK;
                            PKKLTDanRXay.KLKP_Sl = record.KLKP_Sl;
                            PKKLTDanRXay.KLCC1CK = record.KLCC1CK;
                            PKKLTDanRXay.CreateAt = record.CreateAt;
                            PKKLTDanRXay.CreateBy = record.CreateBy;
                            PKKLTDanRXay.KLKP_KL = addedEntity.TongTrongLuong ?? 0;

                            var SumTenCongTacByPL = await GetSumTenCongTacByPL(addedEntity.TTTDCongHoRanh_TenLoaiTamDanTieuChuan, addedEntity.TenCongTac ?? "");
                            if (SumTenCongTacByPL != null && SumTenCongTacByPL.Value != null)
                            {
                                if (double.TryParse(SumTenCongTacByPL.Value, out double parsedValue))
                                {
                                    PKKLTDanRXay.KLKP_KL = Math.Round(parsedValue + addedEntity.TongTrongLuong ?? 0, 4);
                                }

                            }
                            PKKLTDanRXay.KTHH_KL1CK = _pKKLTDanRXayRepository.KTHH_KL1CK(record.DonVi, record.KTHH_D, record.KTHH_R, record.KTHH_C, record.KTHH_DienTich, record.KTHH_GhiChu);
                            PKKLTDanRXay.TTCDT_KL = _pKKLTDanRXayRepository.TTCDT_KL(record.DonVi, record.KTHH_D, record.KTHH_R, record.KTHH_C, record.TTCDT_CDai, record.TTCDT_CRong, record.TTCDT_CDay, record.TTCDT_DienTich);
                            PKKLTDanRXay.KL1CK_ChuaTruCC = _pKKLTDanRXayRepository.KL1CK_ChuaTruCC(record.KTHH_KL1CK, record.KTHH_SLCauKien, record.TTCDT_KL, record.TTCDT_SLCK, PKKLTDanRXay.KLKP_KL, record.KLKP_Sl);
                            PKKLTDanRXay.TKLCK_SauCC = PKKLTDanRXay.KL1CK_ChuaTruCC - PKKLTDanRXay.KLCC1CK;
                            PKKLTDanRXays.Add(PKKLTDanRXay);
                        }

                    }
                    await _pKKLTDanRXayRepository.UpdateMulti(PKKLTDanRXays.ToArray());
                }
            }
        }
        private async Task HandleEntityDelete(EntityEntry entityEntry)
        {
            var deletedEntity = entityEntry.Entity as TKThepTDanRXay;
            if (deletedEntity != null)
            {
                TKThepTDanRXay entity = await GetById(deletedEntity.Id);

                if (entity == null)
                {
                    throw new Exception($"Không tìm thấy bản ghi theo ID: {deletedEntity.Id}");
                }
                PKKLModel pkklModel = new PKKLModel { HangMuc = "III.Gia công, lắp dựng cốt thép", TenCongTac = entity.TenCongTac ?? "", LoaiCauKienId = entity.TTTDCongHoRanh_TenLoaiTamDanTieuChuan };
                List<PKKLModel> result = await _pKKLTDanRXayRepository.GetAllByVM(pkklModel);
                if (result != null)
                {
                    List<PKKLTDanRXay> PKKLTDanRXays = new List<PKKLTDanRXay>();
                    foreach (var record in result)
                    {
                        PKKLTDanRXay PKKLTDanRXay = new PKKLTDanRXay();
                        if (!string.IsNullOrEmpty(record.TenCongTac))
                        {
                            PKKLTDanRXay.Id = record.Id;
                            PKKLTDanRXay.Flag = record.Flag;
                            PKKLTDanRXay.TTTDCongHoRanh_TenLoaiTamDanTieuChuan = record.LoaiCauKienId;
                            PKKLTDanRXay.LoaiBeTong = record.LoaiBeTong;
                            PKKLTDanRXay.HangMuc = record.HangMuc;
                            PKKLTDanRXay.HangMucCongTac = record.HangMucCongTac;
                            PKKLTDanRXay.DonVi = record.DonVi;
                            PKKLTDanRXay.KTHH_D = record.KTHH_D;
                            PKKLTDanRXay.KTHH_R = record.KTHH_R;
                            PKKLTDanRXay.KTHH_C = record.KTHH_C;
                            PKKLTDanRXay.KTHH_DienTich = record.KTHH_DienTich;
                            PKKLTDanRXay.KTHH_GhiChu = record.KTHH_GhiChu;
                            PKKLTDanRXay.KTHH_SLCauKien = record.KTHH_SLCauKien;
                            PKKLTDanRXay.TTCDT_CDai = record.TTCDT_CDai;
                            PKKLTDanRXay.TTCDT_CRong = record.TTCDT_CRong;
                            PKKLTDanRXay.TTCDT_CDay = record.TTCDT_CDay;
                            PKKLTDanRXay.TTCDT_DienTich = record.TTCDT_DienTich;
                            PKKLTDanRXay.TTCDT_SLCK = record.TTCDT_SLCK;
                            PKKLTDanRXay.KLKP_Sl = record.KLKP_Sl;
                            PKKLTDanRXay.KLCC1CK = record.KLCC1CK;
                            PKKLTDanRXay.CreateAt = record.CreateAt;
                            PKKLTDanRXay.CreateBy = record.CreateBy;
                            PKKLTDanRXay.KLKP_KL = deletedEntity.TongTrongLuong - entity.TongTrongLuong ?? 0;
                            PKKLTDanRXay.TenCongTac = "";

                            var SumTenCongTacByPL = await GetSumTenCongTacByPL(entity.TTTDCongHoRanh_TenLoaiTamDanTieuChuan, entity.TenCongTac ?? "");
                            if (SumTenCongTacByPL != null && SumTenCongTacByPL.Value != null)
                            {
                                if (double.TryParse(SumTenCongTacByPL.Value, out double parsedValue))
                                {
                                    PKKLTDanRXay.KLKP_KL = Math.Round(parsedValue - deletedEntity.TongTrongLuong ?? 0, 4);
                                    PKKLTDanRXay.TenCongTac = record.TenCongTac;
                                }

                            }
                            PKKLTDanRXay.KTHH_KL1CK = _pKKLTDanRXayRepository.KTHH_KL1CK(record.DonVi, record.KTHH_D, record.KTHH_R, record.KTHH_C, record.KTHH_DienTich, record.KTHH_GhiChu);
                            PKKLTDanRXay.TTCDT_KL = _pKKLTDanRXayRepository.TTCDT_KL(record.DonVi, record.KTHH_D, record.KTHH_R, record.KTHH_C, record.TTCDT_CDai, record.TTCDT_CRong, record.TTCDT_CDay, record.TTCDT_DienTich);
                            PKKLTDanRXay.KL1CK_ChuaTruCC = _pKKLTDanRXayRepository.KL1CK_ChuaTruCC(record.KTHH_KL1CK, record.KTHH_SLCauKien, record.TTCDT_KL, record.TTCDT_SLCK, PKKLTDanRXay.KLKP_KL, record.KLKP_Sl);
                            PKKLTDanRXay.TKLCK_SauCC = PKKLTDanRXay.KL1CK_ChuaTruCC - PKKLTDanRXay.KLCC1CK;
                            PKKLTDanRXays.Add(PKKLTDanRXay);
                        }

                    }
                    await _pKKLTDanRXayRepository.UpdateMulti(PKKLTDanRXays.ToArray());
                }
            }
        }
        private async Task HandleEntityUpdate(EntityEntry entityEntry)
        {
            try
            {

                var modifiedEntity = entityEntry.Entity as TKThepTDanRXay;

                if (modifiedEntity != null)
                {
                    TKThepTDanRXay entity = await GetById(modifiedEntity.Id);

                    if (entity == null)
                    {
                        throw new Exception($"Không tìm thấy bản ghi theo ID: {modifiedEntity.Id}");
                    }
                    PKKLModel pkklModel = new PKKLModel { HangMuc = "III.Gia công, lắp dựng cốt thép", TenCongTac = entity.TenCongTac ?? "", LoaiCauKienId = entity.TTTDCongHoRanh_TenLoaiTamDanTieuChuan };
                    List<PKKLModel> result = await _pKKLTDanRXayRepository.GetAllByVM(pkklModel);
                    if (result != null)
                    {
                        List<PKKLTDanRXay> PKKLTDanRXays = new List<PKKLTDanRXay>();
                        foreach (var record in result)
                        {
                            PKKLTDanRXay PKKLTDanRXay = new PKKLTDanRXay();
                            if (!string.IsNullOrEmpty(record.TenCongTac))
                            {
                                PKKLTDanRXay.Id = record.Id;
                                PKKLTDanRXay.Flag = record.Flag;
                                PKKLTDanRXay.TTTDCongHoRanh_TenLoaiTamDanTieuChuan = record.LoaiCauKienId;
                                PKKLTDanRXay.LoaiBeTong = record.LoaiBeTong;
                                PKKLTDanRXay.HangMuc = record.HangMuc;
                                PKKLTDanRXay.HangMucCongTac = record.HangMucCongTac;
                                PKKLTDanRXay.TenCongTac = record.TenCongTac;
                                PKKLTDanRXay.DonVi = record.DonVi;
                                PKKLTDanRXay.KTHH_D = record.KTHH_D;
                                PKKLTDanRXay.KTHH_R = record.KTHH_R;
                                PKKLTDanRXay.KTHH_C = record.KTHH_C;
                                PKKLTDanRXay.KTHH_DienTich = record.KTHH_DienTich;
                                PKKLTDanRXay.KTHH_GhiChu = record.KTHH_GhiChu;
                                PKKLTDanRXay.KTHH_SLCauKien = record.KTHH_SLCauKien;
                                PKKLTDanRXay.TTCDT_CDai = record.TTCDT_CDai;
                                PKKLTDanRXay.TTCDT_CRong = record.TTCDT_CRong;
                                PKKLTDanRXay.TTCDT_CDay = record.TTCDT_CDay;
                                PKKLTDanRXay.TTCDT_DienTich = record.TTCDT_DienTich;
                                PKKLTDanRXay.TTCDT_SLCK = record.TTCDT_SLCK;
                                PKKLTDanRXay.KLKP_Sl = record.KLKP_Sl;
                                PKKLTDanRXay.KLCC1CK = record.KLCC1CK;
                                PKKLTDanRXay.CreateAt = record.CreateAt;
                                PKKLTDanRXay.CreateBy = record.CreateBy;
                                PKKLTDanRXay.KLKP_KL = modifiedEntity.TongTrongLuong - entity.TongTrongLuong ?? 0;

                                var SumTenCongTacByPL = await GetSumTenCongTacByPL(entity.TTTDCongHoRanh_TenLoaiTamDanTieuChuan, entity.TenCongTac ?? "");
                                if (SumTenCongTacByPL != null && SumTenCongTacByPL.Value != null)
                                {
                                    if (double.TryParse(SumTenCongTacByPL.Value, out double parsedValue))
                                    {
                                        PKKLTDanRXay.KLKP_KL = (parsedValue - entity.TongTrongLuong) + modifiedEntity.TongTrongLuong ?? 0;
                                        PKKLTDanRXay.KLKP_KL = Math.Round(PKKLTDanRXay.KLKP_KL, 4);
                                    }
                                }
                                PKKLTDanRXay.KTHH_KL1CK = _pKKLTDanRXayRepository.KTHH_KL1CK(record.DonVi, record.KTHH_D, record.KTHH_R, record.KTHH_C, record.KTHH_DienTich, record.KTHH_GhiChu);
                                PKKLTDanRXay.TTCDT_KL = _pKKLTDanRXayRepository.TTCDT_KL(record.DonVi, record.KTHH_D, record.KTHH_R, record.KTHH_C, record.TTCDT_CDai, record.TTCDT_CRong, record.TTCDT_CDay, record.TTCDT_DienTich);
                                PKKLTDanRXay.KL1CK_ChuaTruCC = _pKKLTDanRXayRepository.KL1CK_ChuaTruCC(record.KTHH_KL1CK, record.KTHH_SLCauKien, record.TTCDT_KL, record.TTCDT_SLCK, PKKLTDanRXay.KLKP_KL, record.KLKP_Sl);
                                PKKLTDanRXay.TKLCK_SauCC = PKKLTDanRXay.KL1CK_ChuaTruCC - PKKLTDanRXay.KLCC1CK;
                                PKKLTDanRXays.Add(PKKLTDanRXay);
                            }

                        }
                        await _pKKLTDanRXayRepository.UpdateMulti(PKKLTDanRXays.ToArray());
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
