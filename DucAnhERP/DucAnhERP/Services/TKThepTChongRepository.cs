using DucAnhERP.Data;
using DucAnhERP.Helpers;
using DucAnhERP.Models;
using DucAnhERP.Repository;
using DucAnhERP.ViewModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DucAnhERP.Services
{
    public class TKThepTChongRepository : ITKThepTChongRepository
    {
        private readonly IDbContextFactory<ApplicationDbContext> _context;
        private readonly PKKLTChongRepository _pPKKLTChongRepository;
        public TKThepTChongRepository(IDbContextFactory<ApplicationDbContext> context)
        {
            _context = context;
            _pPKKLTChongRepository =  new PKKLTChongRepository(context);
        }
        public async Task<List<TKThepTChong>> GetAll()
        {
            try
            {
                using var context = _context.CreateDbContext();
                var entity = await context.TKThepTChongs.ToListAsync();
                return entity;
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.Error.WriteLine($"An error occurred: {ex.Message}");
                throw; // Optionally rethrow the exception
            }
        }
        public async Task<TKThepTChong> GetById(string id)
        {
            using var context = _context.CreateDbContext();
            var entity = await context.TKThepTChongs.Where(x => x.Id.Equals(id)).FirstOrDefaultAsync();

            if (entity == null)
            {
                throw new Exception($"Không tìm thấy bản ghi theo ID: {id}");
            }

            return entity;
        }
        public async Task<List<TKThepTChongModel>> GetAllByVM(TKThepTChongModel mModel)
        {
            try
            {
                using var context = _context.CreateDbContext();
                var query = from a in context.TKThepTChongs
                            join b in context.PhanLoaiThanhChongs
                            on a.TTKTHHCongHopRanh_LoaiThanhChong equals b.Id into plc
                            from b in plc.DefaultIfEmpty()
                            join dm in context.DSDanhMuc
                            on a.LoaiThep equals dm.Id
                            join c in context.DMTLTheps
                            on new { a.LoaiThep, DKCD = a.DKCD.ToString() } equals new { LoaiThep = c.ChungLoaiThep, DKCD = c.DuongKinh } into dmThepGroup
                            from c in dmThepGroup.DefaultIfEmpty()
                            orderby a.SoHieu
                            select new TKThepTChongModel
                            {
                                Id = a.Id,
                                Flag = a.Flag,

                                TTKTHHCongHopRanh_LoaiThanhChong = a.TTKTHHCongHopRanh_LoaiThanhChong ?? "",
                                PhanLoaiThanhChong_LoaiThanhChong = b.TTKTHHCongHopRanh_LoaiThanhChong ?? "",

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

                if (!string.IsNullOrEmpty(mModel.TTKTHHCongHopRanh_LoaiThanhChong))
                {
                    query = query.Where(x => x.TTKTHHCongHopRanh_LoaiThanhChong == mModel.TTKTHHCongHopRanh_LoaiThanhChong);
                }
                if (!string.IsNullOrEmpty(mModel.LoaiThep))
                {
                    query = query.Where(x => x.LoaiThep == mModel.LoaiThep);
                }
                var data = await query.Distinct().OrderBy(x => x.PhanLoaiThanhChong_LoaiThanhChong).ThenBy(x => x.SoHieu).ToListAsync();
                return data;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }

        }
        public async Task<List<TKThepTChong>> GetExist(TKThepTChong searchData)
        {
            try
            {
                using var context = _context.CreateDbContext();

                // Thực hiện lọc dữ liệu dựa trên các thuộc tính của searchData
                var query = context.TKThepTChongs
                             .Where(item => (
                                    item.TTKTHHCongHopRanh_LoaiThanhChong == searchData.TTKTHHCongHopRanh_LoaiThanhChong &&
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
        public async Task<List<SelectedItem>> GetDistinctTenCongTacByPL(string TTKTHHCongHopRanh_LoaiThanhChong)
        {
            try
            {
                using var context = _context.CreateDbContext();
                var data = context.TKThepTChongs
                 .Where(item => item.TTKTHHCongHopRanh_LoaiThanhChong == TTKTHHCongHopRanh_LoaiThanhChong)
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
        public async Task<SelectedItem> GetSumTenCongTacByPL(string TTKTHHCongHopRanh_LoaiThanhChong, string TenCongTac)
        {
            try
            {
                using var context = _context.CreateDbContext();
                var data = await context.TKThepTChongs
                .Where(item =>
                    item.TTKTHHCongHopRanh_LoaiThanhChong == TTKTHHCongHopRanh_LoaiThanhChong &&
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
        public async Task Update(TKThepTChong TKThepDeCong)
        {
            using var context = _context.CreateDbContext();
            var entity = GetById(TKThepDeCong.Id);

            if (entity == null)
            {
                throw new Exception($"Không tìm thấy bản ghi theo ID: {TKThepDeCong.Id}");
            }

            context.TKThepTChongs.Update(TKThepDeCong);
            await SaveChanges(context);
        }
        public async Task UpdateMulti(TKThepTChong[] TKThepDeCong)
        {
            using var context = _context.CreateDbContext();
            string[] ids = TKThepDeCong.Select(x => x.Id).ToArray();
            var listEntities = await context.TKThepTChongs.Where(x => ids.Contains(x.Id)).ToListAsync();
            foreach (var entity in listEntities)
            {
                context.TKThepTChongs.Update(entity);
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

            context.Set<TKThepTChong>().Remove(entity);
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
        public async Task Insert(TKThepTChong entity)
        {
            try
            {
                using var context = _context.CreateDbContext();
                if (entity == null)
                {
                    throw new Exception("Không có bản ghi nào để thêm!");
                }

                // Lấy tất cả các bản ghi phù hợp và thực hiện xử lý trên client-side
                var maxFlagValue = await context.TKThepTChongs
                    .Where(x => x.TTKTHHCongHopRanh_LoaiThanhChong == entity.TTKTHHCongHopRanh_LoaiThanhChong)
                    .Select(x => x.Flag)
                    .ToListAsync(); // Lấy danh sách các giá trị Flag

                // Kiểm tra nếu danh sách không có giá trị nào, trả về 0, ngược lại lấy giá trị lớn nhất
                var maxFlag = maxFlagValue.Any() ? maxFlagValue.Max() : 0;


                // Tăng giá trị Flag lên 1
                entity.Flag = maxFlag + 1;

                // Chèn bản ghi mới vào bảng
                context.TKThepTChongs.Add(entity);
                await SaveChanges(context);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public async Task<string> InsertLaterFlag(TKThepTChong entity, int FlagLast)
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
                var recordsToUpdate = await context.TKThepTChongs
                    .Where(x => x.Flag > FlagLast && x.TTKTHHCongHopRanh_LoaiThanhChong == entity.TTKTHHCongHopRanh_LoaiThanhChong)
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
                    var maxFlag = await context.TKThepTChongs.AnyAsync()
                                  ? await context.TKThepTChongs.MaxAsync(x => x.Flag)
                                  : 0;

                    // Tăng giá trị Flag lên 1
                    entity.Flag = maxFlag + 1;
                }
                else
                {
                    entity.Flag = FlagLast + 1;
                }

                // Bước 4: Chèn bản ghi mới vào bảng
                context.TKThepTChongs.Add(entity);

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
            var addedEntity = entityEntry.Entity as TKThepTChong;
            if (addedEntity != null)
            {
                PKKLModel pkklModel = new PKKLModel { HangMuc = "III.Gia công, lắp dựng cốt thép", TenCongTac = addedEntity.TenCongTac ?? "", LoaiCauKienId = addedEntity.TTKTHHCongHopRanh_LoaiThanhChong };
                List<PKKLModel> result = await _pPKKLTChongRepository.GetAllByVM(pkklModel);
                if (result != null)
                {
                    List<PKKLTChong> PKKLTChongs = new List<PKKLTChong>();
                    foreach (var record in result)
                    {
                        PKKLTChong PKKLTChong = new PKKLTChong();
                        if (!string.IsNullOrEmpty(record.TenCongTac))
                        {
                            PKKLTChong.Id = record.Id;
                            PKKLTChong.Flag = record.Flag;
                            PKKLTChong.TTKTHHCongHopRanh_LoaiThanhChong = record.LoaiCauKienId;
                            PKKLTChong.LoaiBeTong = record.LoaiBeTong;
                            PKKLTChong.HangMuc = record.HangMuc;
                            PKKLTChong.HangMucCongTac = record.HangMucCongTac;
                            PKKLTChong.TenCongTac = record.TenCongTac;
                            PKKLTChong.DonVi = record.DonVi;
                            PKKLTChong.KTHH_D = record.KTHH_D;
                            PKKLTChong.KTHH_R = record.KTHH_R;
                            PKKLTChong.KTHH_C = record.KTHH_C;
                            PKKLTChong.KTHH_DienTich = record.KTHH_DienTich;
                            PKKLTChong.KTHH_GhiChu = record.KTHH_GhiChu;
                            PKKLTChong.KTHH_SLCauKien = record.KTHH_SLCauKien;
                            PKKLTChong.TTCDT_CDai = record.TTCDT_CDai;
                            PKKLTChong.TTCDT_CRong = record.TTCDT_CRong;
                            PKKLTChong.TTCDT_CDay = record.TTCDT_CDay;
                            PKKLTChong.TTCDT_DienTich = record.TTCDT_DienTich;
                            PKKLTChong.TTCDT_SLCK = record.TTCDT_SLCK;
                            PKKLTChong.KLKP_Sl = record.KLKP_Sl;
                            PKKLTChong.KLCC1CK = record.KLCC1CK;
                            PKKLTChong.CreateAt = record.CreateAt;
                            PKKLTChong.CreateBy = record.CreateBy;
                            PKKLTChong.KLKP_KL = addedEntity.TongTrongLuong ?? 0;

                            var SumTenCongTacByPL = await GetSumTenCongTacByPL(addedEntity.TTKTHHCongHopRanh_LoaiThanhChong, addedEntity.TenCongTac ?? "");
                            if (SumTenCongTacByPL != null && SumTenCongTacByPL.Value != null)
                            {
                                if (double.TryParse(SumTenCongTacByPL.Value, out double parsedValue))
                                {
                                    PKKLTChong.KLKP_KL = parsedValue + addedEntity.TongTrongLuong ?? 0;
                                }

                            }
                            PKKLTChong.KTHH_KL1CK = _pPKKLTChongRepository.KTHH_KL1CK(PKKLTChong);
                            PKKLTChong.TTCDT_KL = _pPKKLTChongRepository.TTCDT_KL(PKKLTChong);
                            PKKLTChong.KL1CK_ChuaTruCC = _pPKKLTChongRepository.KL1CK_ChuaTruCC(PKKLTChong);
                            PKKLTChong.TKLCK_SauCC = PKKLTChong.KL1CK_ChuaTruCC - PKKLTChong.KLCC1CK;
                            PKKLTChongs.Add(PKKLTChong);
                        }

                    }
                    await _pPKKLTChongRepository.UpdateMulti(PKKLTChongs.ToArray());
                }
            }
        }
        private async Task HandleEntityDelete(EntityEntry entityEntry)
        {
            var deletedEntity = entityEntry.Entity as TKThepTChong;
            if (deletedEntity != null)
            {
                TKThepTChong entity = await GetById(deletedEntity.Id);

                if (entity == null)
                {
                    throw new Exception($"Không tìm thấy bản ghi theo ID: {deletedEntity.Id}");
                }
                PKKLModel pkklModel = new PKKLModel { HangMuc = "III.Gia công, lắp dựng cốt thép", TenCongTac = entity.TenCongTac ?? "", LoaiCauKienId = entity.TTKTHHCongHopRanh_LoaiThanhChong };
                List<PKKLModel> result = await _pPKKLTChongRepository.GetAllByVM(pkklModel);
                if (result != null)
                {
                    List<PKKLTChong> PKKLTChongs = new List<PKKLTChong>();
                    foreach (var record in result)
                    {
                        PKKLTChong PKKLTChong = new PKKLTChong();
                        if (!string.IsNullOrEmpty(record.TenCongTac))
                        {
                            PKKLTChong.Id = record.Id;
                            PKKLTChong.Flag = record.Flag;
                            PKKLTChong.TTKTHHCongHopRanh_LoaiThanhChong = record.LoaiCauKienId;
                            PKKLTChong.LoaiBeTong = record.LoaiBeTong;
                            PKKLTChong.HangMuc = record.HangMuc;
                            PKKLTChong.HangMucCongTac = record.HangMucCongTac;
                            PKKLTChong.DonVi = record.DonVi;
                            PKKLTChong.KTHH_D = record.KTHH_D;
                            PKKLTChong.KTHH_R = record.KTHH_R;
                            PKKLTChong.KTHH_C = record.KTHH_C;
                            PKKLTChong.KTHH_DienTich = record.KTHH_DienTich;
                            PKKLTChong.KTHH_GhiChu = record.KTHH_GhiChu;
                            PKKLTChong.KTHH_SLCauKien = record.KTHH_SLCauKien;
                            PKKLTChong.TTCDT_CDai = record.TTCDT_CDai;
                            PKKLTChong.TTCDT_CRong = record.TTCDT_CRong;
                            PKKLTChong.TTCDT_CDay = record.TTCDT_CDay;
                            PKKLTChong.TTCDT_DienTich = record.TTCDT_DienTich;
                            PKKLTChong.TTCDT_SLCK = record.TTCDT_SLCK;
                            PKKLTChong.KLKP_Sl = record.KLKP_Sl;
                            PKKLTChong.KLCC1CK = record.KLCC1CK;
                            PKKLTChong.CreateAt = record.CreateAt;
                            PKKLTChong.CreateBy = record.CreateBy;
                            PKKLTChong.KLKP_KL = deletedEntity.TongTrongLuong - entity.TongTrongLuong ?? 0;
                            PKKLTChong.TenCongTac = "";

                            var SumTenCongTacByPL = await GetSumTenCongTacByPL(entity.TTKTHHCongHopRanh_LoaiThanhChong, entity.TenCongTac ?? "");
                            if (SumTenCongTacByPL != null && SumTenCongTacByPL.Value != null)
                            {
                                if (double.TryParse(SumTenCongTacByPL.Value, out double parsedValue))
                                {
                                    PKKLTChong.KLKP_KL = parsedValue - deletedEntity.TongTrongLuong ?? 0;
                                    PKKLTChong.TenCongTac = record.TenCongTac;
                                }

                            }
                            PKKLTChong.KTHH_KL1CK = _pPKKLTChongRepository.KTHH_KL1CK(PKKLTChong);
                            PKKLTChong.TTCDT_KL = _pPKKLTChongRepository.TTCDT_KL(PKKLTChong);
                            PKKLTChong.KL1CK_ChuaTruCC = _pPKKLTChongRepository.KL1CK_ChuaTruCC(PKKLTChong);
                            PKKLTChong.TKLCK_SauCC = PKKLTChong.KL1CK_ChuaTruCC - PKKLTChong.KLCC1CK;
                            PKKLTChongs.Add(PKKLTChong);
                        }

                    }
                    await _pPKKLTChongRepository.UpdateMulti(PKKLTChongs.ToArray());
                }
            }
        }
        private async Task HandleEntityUpdate(EntityEntry entityEntry)
        {
            try
            {

                var modifiedEntity = entityEntry.Entity as TKThepTChong;

                if (modifiedEntity != null)
                {
                    TKThepTChong entity = await GetById(modifiedEntity.Id);

                    if (entity == null)
                    {
                        throw new Exception($"Không tìm thấy bản ghi theo ID: {modifiedEntity.Id}");
                    }
                    PKKLModel pkklModel = new PKKLModel { HangMuc = "III.Gia công, lắp dựng cốt thép", TenCongTac = entity.TenCongTac ?? "", LoaiCauKienId = entity.TTKTHHCongHopRanh_LoaiThanhChong };
                    List<PKKLModel> result = await _pPKKLTChongRepository.GetAllByVM(pkklModel);
                    if (result != null)
                    {
                        List<PKKLTChong> PKKLTChongs = new List<PKKLTChong>();
                        foreach (var record in result)
                        {
                            PKKLTChong PKKLTChong = new PKKLTChong();
                            if (!string.IsNullOrEmpty(record.TenCongTac))
                            {
                                PKKLTChong.Id = record.Id;
                                PKKLTChong.Flag = record.Flag;
                                PKKLTChong.TTKTHHCongHopRanh_LoaiThanhChong = record.LoaiCauKienId;
                                PKKLTChong.LoaiBeTong = record.LoaiBeTong;
                                PKKLTChong.HangMuc = record.HangMuc;
                                PKKLTChong.HangMucCongTac = record.HangMucCongTac;
                                PKKLTChong.TenCongTac = record.TenCongTac;
                                PKKLTChong.DonVi = record.DonVi;
                                PKKLTChong.KTHH_D = record.KTHH_D;
                                PKKLTChong.KTHH_R = record.KTHH_R;
                                PKKLTChong.KTHH_C = record.KTHH_C;
                                PKKLTChong.KTHH_DienTich = record.KTHH_DienTich;
                                PKKLTChong.KTHH_GhiChu = record.KTHH_GhiChu;
                                PKKLTChong.KTHH_SLCauKien = record.KTHH_SLCauKien;
                                PKKLTChong.TTCDT_CDai = record.TTCDT_CDai;
                                PKKLTChong.TTCDT_CRong = record.TTCDT_CRong;
                                PKKLTChong.TTCDT_CDay = record.TTCDT_CDay;
                                PKKLTChong.TTCDT_DienTich = record.TTCDT_DienTich;
                                PKKLTChong.TTCDT_SLCK = record.TTCDT_SLCK;
                                PKKLTChong.KLKP_Sl = record.KLKP_Sl;
                                PKKLTChong.KLCC1CK = record.KLCC1CK;
                                PKKLTChong.CreateAt = record.CreateAt;
                                PKKLTChong.CreateBy = record.CreateBy;
                                PKKLTChong.KLKP_KL = modifiedEntity.TongTrongLuong - entity.TongTrongLuong ?? 0;

                                var SumTenCongTacByPL = await GetSumTenCongTacByPL(entity.TTKTHHCongHopRanh_LoaiThanhChong, entity.TenCongTac ?? "");
                                if (SumTenCongTacByPL != null && SumTenCongTacByPL.Value != null)
                                {
                                    if (double.TryParse(SumTenCongTacByPL.Value, out double parsedValue))
                                    {
                                        PKKLTChong.KLKP_KL = (parsedValue - entity.TongTrongLuong) + modifiedEntity.TongTrongLuong ?? 0;
                                    }

                                }

                                PKKLTChong.KTHH_KL1CK = _pPKKLTChongRepository.KTHH_KL1CK(PKKLTChong);
                                PKKLTChong.TTCDT_KL = _pPKKLTChongRepository.TTCDT_KL(PKKLTChong);
                                PKKLTChong.KL1CK_ChuaTruCC = _pPKKLTChongRepository.KL1CK_ChuaTruCC(PKKLTChong);
                                PKKLTChong.TKLCK_SauCC = PKKLTChong.KL1CK_ChuaTruCC - PKKLTChong.KLCC1CK;
                                PKKLTChongs.Add(PKKLTChong);
                            }

                        }
                        await _pPKKLTChongRepository.UpdateMulti(PKKLTChongs.ToArray());
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
