using DucAnhERP.Data;
using DucAnhERP.Helpers;
using DucAnhERP.Models;
using DucAnhERP.Repository;
using DucAnhERP.ViewModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DucAnhERP.Services
{
    public class TKThepDeCongRepository :ITKThepDeCongRepository
    {
        private readonly IDbContextFactory<ApplicationDbContext> _context;
        private readonly PKKLDeCTronRepository _pKKLDeCTronRepository;
        public TKThepDeCongRepository(IDbContextFactory<ApplicationDbContext> context)
        {
            _context = context;
            _pKKLDeCTronRepository = new PKKLDeCTronRepository(context);
        }
        public async Task<bool> CheckStatus(string ids, string name)
        {
            return true;
        }

        public async Task<List<TKThepDCong>> GetAll(string groupId)
        {
            try
            {
                using var context = _context.CreateDbContext();
                var entity = await context.TKThepDeCongs.ToListAsync();
                return entity;
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.Error.WriteLine($"An error occurred: {ex.Message}");
                throw; // Optionally rethrow the exception
            }
        }
        public async Task<TKThepDCong> GetById(string id)
        {
            using var context = _context.CreateDbContext();
            var entity = await context.TKThepDeCongs.Where(x => x.Id.Equals(id)).FirstOrDefaultAsync();

            if (entity == null)
            {
                throw new Exception($"Không tìm thấy bản ghi theo ID: {id}");
            }

            return entity;
        }
        public async Task<List<TKThepDCongModel>> GetAllByVM(TKThepDCongModel mModel)
        {
            try
            {
                using var context = _context.CreateDbContext();
                var query = from a in context.TKThepDeCongs
                            join b in context.PhanLoaiDeCongs
                            on a.ThongTinDeCong_TenLoaiDeCong equals b.Id into plc
                            from b in plc.DefaultIfEmpty()
                            join dm in context.DSDanhMuc
                            on a.LoaiThep equals dm.Id
                            join c in context.DMTLTheps
                            on new { a.LoaiThep, DKCD = a.DKCD.ToString() } equals new { LoaiThep = c.ChungLoaiThep, DKCD = c.DuongKinh } into dmThepGroup
                            from c in dmThepGroup.DefaultIfEmpty()
                            orderby a.SoHieu
                            select new TKThepDCongModel
                            {
                                Id = a.Id,
                                Flag = a.Flag,

                                ThongTinDeCong_TenLoaiDeCong = a.ThongTinDeCong_TenLoaiDeCong,
                                PhanLoaiDeCong_TenLoaiDeCong = b.ThongTinDeCong_TenLoaiDeCong ??"",

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

                if (!string.IsNullOrEmpty(mModel.ThongTinDeCong_TenLoaiDeCong))
                {
                    query = query.Where(x => x.ThongTinDeCong_TenLoaiDeCong == mModel.ThongTinDeCong_TenLoaiDeCong);
                }
                if (!string.IsNullOrEmpty(mModel.LoaiThep))
                {
                    query = query.Where(x => x.LoaiThep == mModel.LoaiThep);
                }
                var data = await query.Distinct().OrderBy(x => x.PhanLoaiDeCong_TenLoaiDeCong).ThenBy(x => x.SoHieu).ToListAsync();
                return data;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }

        }
        public async Task<List<TKThepDCong>> GetExist(TKThepDCong searchData)
        {
            try
            {
                using var context = _context.CreateDbContext();

                // Thực hiện lọc dữ liệu dựa trên các thuộc tính của searchData
                var query = context.TKThepDeCongs
                             .Where(item => (
                                    item.ThongTinDeCong_TenLoaiDeCong == searchData.ThongTinDeCong_TenLoaiDeCong &&
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
        public async Task<List<SelectedItem>> GetDistinctTenCongTacByPL(string ThongTinDeCong_TenLoaiDeCong)
        {
            try
            {
                using var context = _context.CreateDbContext();
                var data = context.TKThepDeCongs
                 .Where(item => item.ThongTinDeCong_TenLoaiDeCong == ThongTinDeCong_TenLoaiDeCong)
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
        public async Task<SelectedItem> GetSumTenCongTacByPL(string ThongTinDeCong_TenLoaiDeCong, string TenCongTac)
        {
            try
            {
                using var context = _context.CreateDbContext();
                var data = await context.TKThepDeCongs
                .Where(item =>
                    item.ThongTinDeCong_TenLoaiDeCong == ThongTinDeCong_TenLoaiDeCong &&
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
        public async Task Update(TKThepDCong TKThepDeCong, string userId)
        {
            using var context = _context.CreateDbContext();
            var entity = GetById(TKThepDeCong.Id);

            if (entity == null)
            {
                throw new Exception($"Không tìm thấy bản ghi theo ID: {TKThepDeCong.Id}");
            }

            context.TKThepDeCongs.Update(TKThepDeCong);
            await SaveChanges(context);
        }
        //public async Task UpdateMulti(TKThepDCong[] TKThepDeCong)
        //{
        //    using var context = _context.CreateDbContext();
        //    string[] ids = TKThepDeCong.Select(x => x.Id).ToArray();
        //    var listEntities = await context.TKThepDeCongs.Where(x => ids.Contains(x.Id)).ToListAsync();
        //    foreach (var entity in listEntities)
        //    {
        //        context.TKThepDeCongs.Update(entity);
        //    }
        //    await context.SaveChangesAsync();
        //}

        public async Task UpdateMulti(TKThepDCong[] tKThepDeCongArray)
        {
            using var context = _context.CreateDbContext();

            // Lấy danh sách ID từ mảng đầu vào
            var ids = tKThepDeCongArray.Select(x => x.Id).ToArray();

            // Lấy danh sách thực thể từ cơ sở dữ liệu
            var listEntities = await context.TKThepDeCongs
                .Where(x => ids.Contains(x.Id))
                .ToListAsync();

            // Cập nhật các giá trị thay đổi
            foreach (var entity in listEntities)
            {
                var updatedEntity = tKThepDeCongArray.FirstOrDefault(x => x.Id == entity.Id);
                if (updatedEntity != null)
                {
                    // Chỉ cập nhật các trường thay đổi
                    context.Entry(entity).CurrentValues.SetValues(updatedEntity);
                }
            }

            await SaveChanges(context);
        }
        public async Task DeleteById(string id, string userId)
        {
            using var context = _context.CreateDbContext();
            var entity = await GetById(id);

            if (entity == null)
            {
                throw new Exception($"Không tìm thấy bản ghi theo ID: {id}");
            }
            // Bước 1: Cập nhật trực tiếp các bản ghi có flag > FlagLast
            await context.TKThepDeCongs
                .Where(x => x.Flag > entity.Flag &&
                            x.ThongTinDeCong_TenLoaiDeCong == entity.ThongTinDeCong_TenLoaiDeCong)
                .ExecuteUpdateAsync(x => x
                    .SetProperty(r => r.Flag, r => r.Flag - 1)
                    .SetProperty(r => r.SoHieu, r => r.SoHieu - 1));

            context.TKThepDeCongs.Remove(entity);

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
        public async Task Insert(TKThepDCong entity, string userId)
        {
            try
            {
                using var context = _context.CreateDbContext();
                if (entity == null)
                {
                    throw new Exception("Không có bản ghi nào để thêm!");
                }

                // Lấy tất cả các bản ghi phù hợp và thực hiện xử lý trên client-side
                var maxFlagValue = await context.TKThepDeCongs
                    .Where(x => x.ThongTinDeCong_TenLoaiDeCong == entity.ThongTinDeCong_TenLoaiDeCong)
                    .Select(x => x.Flag)
                    .ToListAsync(); // Lấy danh sách các giá trị Flag

                // Kiểm tra nếu danh sách không có giá trị nào, trả về 0, ngược lại lấy giá trị lớn nhất
                var maxFlag = maxFlagValue.Any() ? maxFlagValue.Max() : 0;


                // Tăng giá trị Flag lên 1
                entity.Flag = maxFlag + 1;

                // Chèn bản ghi mới vào bảng
                context.TKThepDeCongs.Add(entity);
                await SaveChanges(context);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public async Task<string> InsertLaterFlag(TKThepDCong entity, int FlagLast, bool insertBefore)
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
                var recordsToUpdate = await context.TKThepDeCongs
                    .Where(x => (insertBefore ? x.Flag >= FlagLast : x.Flag > FlagLast)
                    && x.ThongTinDeCong_TenLoaiDeCong == entity.ThongTinDeCong_TenLoaiDeCong)
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
                    var maxFlag = await context.TKThepDeCongs.AnyAsync()
                                  ? await context.TKThepDeCongs.MaxAsync(x => x.Flag)
                                  : 0;

                    // Tăng giá trị Flag lên 1
                    entity.Flag = maxFlag + 1;
                }
                else
                {
                    entity.Flag = insertBefore ? FlagLast : FlagLast + 1;
                }

                // Bước 4: Chèn bản ghi mới vào bảng
                context.TKThepDeCongs.Add(entity);

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
            var addedEntity = entityEntry.Entity as TKThepDCong;
            if (addedEntity != null)
            {
                PKKLModel pkklModel = new PKKLModel { HangMuc = "III.Gia công, lắp dựng cốt thép", TenCongTac = addedEntity.TenCongTac ?? "", LoaiCauKienId = addedEntity.ThongTinDeCong_TenLoaiDeCong };
                List<PKKLModel> result = await _pKKLDeCTronRepository.GetAllByVM(pkklModel);
                if (result != null)
                {
                    List<PKKLDeCTron> pKKLDeCTrons = new List<PKKLDeCTron>();
                    foreach (var record in result)
                    {
                        PKKLDeCTron pKKLDeCTron = new PKKLDeCTron();
                        if (!string.IsNullOrEmpty(record.TenCongTac))
                        {
                            pKKLDeCTron.Id = record.Id;
                            pKKLDeCTron.Flag = record.Flag;
                            pKKLDeCTron.ThongTinDeCong_TenLoaiDeCong = record.LoaiCauKienId;
                            pKKLDeCTron.LoaiBeTong = record.LoaiBeTong;
                            pKKLDeCTron.HangMuc = record.HangMuc;
                            pKKLDeCTron.HangMucCongTac = record.HangMucCongTac;
                            pKKLDeCTron.TenCongTac = record.TenCongTac;
                            pKKLDeCTron.DonVi = record.DonVi;
                            pKKLDeCTron.KTHH_D = record.KTHH_D;
                            pKKLDeCTron.KTHH_R = record.KTHH_R;
                            pKKLDeCTron.KTHH_C = record.KTHH_C;
                            pKKLDeCTron.KTHH_DienTich = record.KTHH_DienTich;
                            pKKLDeCTron.KTHH_GhiChu = record.KTHH_GhiChu;
                            pKKLDeCTron.KTHH_SLCauKien = record.KTHH_SLCauKien;
                            pKKLDeCTron.TTCDT_CDai = record.TTCDT_CDai;
                            pKKLDeCTron.TTCDT_CRong = record.TTCDT_CRong;
                            pKKLDeCTron.TTCDT_CDay = record.TTCDT_CDay;
                            pKKLDeCTron.TTCDT_DienTich = record.TTCDT_DienTich;
                            pKKLDeCTron.TTCDT_SLCK = record.TTCDT_SLCK;
                            pKKLDeCTron.KLKP_Sl = record.KLKP_Sl;
                            pKKLDeCTron.KLCC1CK = record.KLCC1CK;
                            pKKLDeCTron.CreateAt = record.CreateAt;
                            pKKLDeCTron.CreateBy = record.CreateBy;
                            // Xử lý khi giá trị không thể chuyển đổi thành số
                            pKKLDeCTron.KLKP_KL = addedEntity.TongTrongLuong ?? 0;

                            var SumTenCongTacByPL = await GetSumTenCongTacByPL(addedEntity.ThongTinDeCong_TenLoaiDeCong, addedEntity.TenCongTac ?? "");
                            if (SumTenCongTacByPL != null && SumTenCongTacByPL.Value != null)
                            {
                                if (double.TryParse(SumTenCongTacByPL.Value, out double parsedValue))
                                {
                                    pKKLDeCTron.KLKP_KL = parsedValue + addedEntity.TongTrongLuong ?? 0;
                                }
                                
                            }
                            pKKLDeCTron.KTHH_KL1CK = _pKKLDeCTronRepository.KTHH_KL1CK(pKKLDeCTron);
                            pKKLDeCTron.TTCDT_KL = _pKKLDeCTronRepository.TTCDT_KL(pKKLDeCTron);
                            pKKLDeCTron.KL1CK_ChuaTruCC = _pKKLDeCTronRepository.KL1CK_ChuaTruCC(pKKLDeCTron);
                            pKKLDeCTron.TKLCK_SauCC = pKKLDeCTron.KL1CK_ChuaTruCC - pKKLDeCTron.KLCC1CK;
                            pKKLDeCTrons.Add(pKKLDeCTron);
                        }

                    }
                    await _pKKLDeCTronRepository.UpdateMulti(pKKLDeCTrons.ToArray());
                }
            }
        }
        private async Task HandleEntityDelete(EntityEntry entityEntry)
        {
            var deletedEntity = entityEntry.Entity as TKThepDCong;
            if (deletedEntity != null)
            {
                TKThepDCong entity = await GetById(deletedEntity.Id);

                if (entity == null)
                {
                    throw new Exception($"Không tìm thấy bản ghi theo ID: {deletedEntity.Id}");
                }
                PKKLModel pkklModel = new PKKLModel { HangMuc = "III.Gia công, lắp dựng cốt thép", TenCongTac = entity.TenCongTac ?? "", LoaiCauKienId = entity.ThongTinDeCong_TenLoaiDeCong };
                List<PKKLModel> result = await _pKKLDeCTronRepository.GetAllByVM(pkklModel);
                if (result != null)
                {
                    List<PKKLDeCTron> pKKLDeCTrons = new List<PKKLDeCTron>();
                    foreach (var record in result)
                    {
                        PKKLDeCTron pKKLDeCTron = new PKKLDeCTron();
                        if (!string.IsNullOrEmpty(record.TenCongTac))
                        {
                            pKKLDeCTron.Id = record.Id;
                            pKKLDeCTron.Flag = record.Flag;
                            pKKLDeCTron.ThongTinDeCong_TenLoaiDeCong = record.LoaiCauKienId;
                            pKKLDeCTron.LoaiBeTong = record.LoaiBeTong;
                            pKKLDeCTron.HangMuc = record.HangMuc;
                            pKKLDeCTron.HangMucCongTac = record.HangMucCongTac;
                            pKKLDeCTron.DonVi = record.DonVi;
                            pKKLDeCTron.KTHH_D = record.KTHH_D;
                            pKKLDeCTron.KTHH_R = record.KTHH_R;
                            pKKLDeCTron.KTHH_C = record.KTHH_C;
                            pKKLDeCTron.KTHH_DienTich = record.KTHH_DienTich;
                            pKKLDeCTron.KTHH_GhiChu = record.KTHH_GhiChu;
                            pKKLDeCTron.KTHH_SLCauKien = record.KTHH_SLCauKien;
                            pKKLDeCTron.TTCDT_CDai = record.TTCDT_CDai;
                            pKKLDeCTron.TTCDT_CRong = record.TTCDT_CRong;
                            pKKLDeCTron.TTCDT_CDay = record.TTCDT_CDay;
                            pKKLDeCTron.TTCDT_DienTich = record.TTCDT_DienTich;
                            pKKLDeCTron.TTCDT_SLCK = record.TTCDT_SLCK;
                            pKKLDeCTron.KLKP_Sl = record.KLKP_Sl;
                            pKKLDeCTron.KLCC1CK = record.KLCC1CK;
                            pKKLDeCTron.CreateAt = record.CreateAt;
                            pKKLDeCTron.CreateBy = record.CreateBy;
                            // Xử lý khi giá trị không thể chuyển đổi thành số
                            pKKLDeCTron.KLKP_KL = deletedEntity.TongTrongLuong - entity.TongTrongLuong ?? 0;
                            pKKLDeCTron.TenCongTac = "";

                            var SumTenCongTacByPL = await GetSumTenCongTacByPL(entity.ThongTinDeCong_TenLoaiDeCong, entity.TenCongTac ?? "");
                            if (SumTenCongTacByPL != null && SumTenCongTacByPL.Value != null)
                            {
                                if (double.TryParse(SumTenCongTacByPL.Value, out double parsedValue))
                                {
                                    pKKLDeCTron.KLKP_KL = parsedValue - deletedEntity.TongTrongLuong ?? 0;
                                    pKKLDeCTron.TenCongTac = record.TenCongTac;
                                }
                               
                            }
                            pKKLDeCTron.KTHH_KL1CK = _pKKLDeCTronRepository.KTHH_KL1CK(pKKLDeCTron);
                            pKKLDeCTron.TTCDT_KL = _pKKLDeCTronRepository.TTCDT_KL(pKKLDeCTron);
                            pKKLDeCTron.KL1CK_ChuaTruCC = _pKKLDeCTronRepository.KL1CK_ChuaTruCC(pKKLDeCTron);
                            pKKLDeCTron.TKLCK_SauCC = pKKLDeCTron.KL1CK_ChuaTruCC - pKKLDeCTron.KLCC1CK;
                            pKKLDeCTrons.Add(pKKLDeCTron);
                        }

                    }
                    await _pKKLDeCTronRepository.UpdateMulti(pKKLDeCTrons.ToArray());
                }
            }
        }
        private async Task HandleEntityUpdate(EntityEntry entityEntry)
        {
            try
            {

                var modifiedEntity = entityEntry.Entity as TKThepDCong;

                if (modifiedEntity != null)
                {
                    TKThepDCong entity = await GetById(modifiedEntity.Id);

                    if (entity == null)
                    {
                        throw new Exception($"Không tìm thấy bản ghi theo ID: {modifiedEntity.Id}");
                    }
                    PKKLModel pkklModel = new PKKLModel { HangMuc = "III.Gia công, lắp dựng cốt thép", TenCongTac = entity.TenCongTac ?? "", LoaiCauKienId = entity.ThongTinDeCong_TenLoaiDeCong };
                    List<PKKLModel> result = await _pKKLDeCTronRepository.GetAllByVM(pkklModel);
                    if (result != null)
                    {
                        List<PKKLDeCTron> pKKLDeCTrons = new List<PKKLDeCTron>();
                        foreach (var record in result)
                        {
                            PKKLDeCTron pKKLDeCTron = new PKKLDeCTron();
                            if (!string.IsNullOrEmpty(record.TenCongTac))
                            {
                                pKKLDeCTron.Id = record.Id;
                                pKKLDeCTron.Flag = record.Flag;
                                pKKLDeCTron.ThongTinDeCong_TenLoaiDeCong = record.LoaiCauKienId;
                                pKKLDeCTron.LoaiBeTong = record.LoaiBeTong;
                                pKKLDeCTron.HangMuc = record.HangMuc;
                                pKKLDeCTron.HangMucCongTac = record.HangMucCongTac;
                                pKKLDeCTron.TenCongTac = record.TenCongTac;
                                pKKLDeCTron.DonVi = record.DonVi;
                                pKKLDeCTron.KTHH_D = record.KTHH_D;
                                pKKLDeCTron.KTHH_R = record.KTHH_R;
                                pKKLDeCTron.KTHH_C = record.KTHH_C;
                                pKKLDeCTron.KTHH_DienTich = record.KTHH_DienTich;
                                pKKLDeCTron.KTHH_GhiChu = record.KTHH_GhiChu;
                                pKKLDeCTron.KTHH_SLCauKien = record.KTHH_SLCauKien;
                                pKKLDeCTron.TTCDT_CDai = record.TTCDT_CDai;
                                pKKLDeCTron.TTCDT_CRong = record.TTCDT_CRong;
                                pKKLDeCTron.TTCDT_CDay = record.TTCDT_CDay;
                                pKKLDeCTron.TTCDT_DienTich = record.TTCDT_DienTich;
                                pKKLDeCTron.TTCDT_SLCK = record.TTCDT_SLCK;
                                pKKLDeCTron.KLKP_Sl = record.KLKP_Sl;
                                pKKLDeCTron.KLCC1CK = record.KLCC1CK;
                                pKKLDeCTron.CreateAt = record.CreateAt;
                                pKKLDeCTron.CreateBy = record.CreateBy;
                                // Xử lý khi giá trị không thể chuyển đổi thành số
                                pKKLDeCTron.KLKP_KL = modifiedEntity.TongTrongLuong - entity.TongTrongLuong ?? 0;

                                var SumTenCongTacByPL = await GetSumTenCongTacByPL(entity.ThongTinDeCong_TenLoaiDeCong, entity.TenCongTac ?? "");
                                if (SumTenCongTacByPL != null && SumTenCongTacByPL.Value != null)
                                {
                                    if (double.TryParse(SumTenCongTacByPL.Value, out double parsedValue))
                                    {
                                        pKKLDeCTron.KLKP_KL = (parsedValue - entity.TongTrongLuong) + modifiedEntity.TongTrongLuong ?? 0;
                                    }
                                }

                                pKKLDeCTron.KTHH_KL1CK = _pKKLDeCTronRepository.KTHH_KL1CK(pKKLDeCTron);
                                pKKLDeCTron.TTCDT_KL = _pKKLDeCTronRepository.TTCDT_KL(pKKLDeCTron);
                                pKKLDeCTron.KL1CK_ChuaTruCC = _pKKLDeCTronRepository.KL1CK_ChuaTruCC(pKKLDeCTron);
                                pKKLDeCTron.TKLCK_SauCC = pKKLDeCTron.KL1CK_ChuaTruCC - pKKLDeCTron.KLCC1CK;
                                pKKLDeCTrons.Add(pKKLDeCTron);
                            }

                        }
                        await _pKKLDeCTronRepository.UpdateMulti(pKKLDeCTrons.ToArray());
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
