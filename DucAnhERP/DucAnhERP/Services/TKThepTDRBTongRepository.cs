using DucAnhERP.Data;
using DucAnhERP.Helpers;
using DucAnhERP.Models;
using DucAnhERP.Repository;
using DucAnhERP.ViewModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DucAnhERP.Services
{
    public class TKThepTDRBTongRepository : ITKThepTDRBTongRepository
    {
        private readonly IDbContextFactory<ApplicationDbContext> _context;
        private readonly PKKLTDanRBTRepository _pKKLTDanRBTRepository;

        public TKThepTDRBTongRepository(IDbContextFactory<ApplicationDbContext> context)
        {
            _context = context;
            _pKKLTDanRBTRepository= new PKKLTDanRBTRepository(context);
        }
        public async Task<bool> CheckStatus(string ids, string name)
        {
            return true;
        }
        public async Task<List<TKThepTDRBTong>> GetAll(string groupId)
        {
            try
            {
                using var context = _context.CreateDbContext();
                var entity = await context.TKThepTDRBTongs.ToListAsync();
                return entity;
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.Error.WriteLine($"An error occurred: {ex.Message}");
                throw; // Optionally rethrow the exception
            }
        }
        public async Task<TKThepTDRBTong> GetById(string id)
        {
            using var context = _context.CreateDbContext();
            var entity = await context.TKThepTDRBTongs.Where(x => x.Id.Equals(id)).FirstOrDefaultAsync();

            if (entity == null)
            {
                throw new Exception($"Không tìm thấy bản ghi theo ID: {id}");
            }

            return entity;
        }
        public async Task<List<TKThepTDRBTongModel>> GetAllByVM(TKThepTDRBTongModel mModel)
        {
            try
            {
                using var context = _context.CreateDbContext();
                var query = from a in context.TKThepTDRBTongs
                            join b in context.PhanLoaiTDanTDans
                            on a.TTTDCongHoRanh_TenLoaiTamDanTieuChuan equals b.Id into plc
                            from b in plc.DefaultIfEmpty()
                            join dm in context.DSDanhMuc
                            on a.LoaiThep equals dm.Id
                            join c in context.DMTLTheps
                            on new { a.LoaiThep, DKCD = a.DKCD.ToString() } equals new { LoaiThep = c.ChungLoaiThep, DKCD = c.DuongKinh } into dmThepGroup
                            from c in dmThepGroup.DefaultIfEmpty()
                            orderby a.SoHieu
                            select new TKThepTDRBTongModel
                            {
                                Id = a.Id,
                                Flag = a.Flag,

                                TTTDCongHoRanh_TenLoaiTamDanTieuChuan = a.TTTDCongHoRanh_TenLoaiTamDanTieuChuan??"",
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
        public async Task<List<TKThepTDRBTong>> GetExist(TKThepTDRBTong searchData)
        {
            try
            {
                using var context = _context.CreateDbContext();

                // Thực hiện lọc dữ liệu dựa trên các thuộc tính của searchData
                var query = context.TKThepTDRBTongs
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
                var data = context.TKThepTDRBTongs
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
                var data = await context.TKThepTDRBTongs
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
        public async Task Update(TKThepTDRBTong TKThepTDRBTong, string userId)
        {
            using var context = _context.CreateDbContext();
            var entity = GetById(TKThepTDRBTong.Id);

            if (entity == null)
            {
                throw new Exception($"Không tìm thấy bản ghi theo ID: {TKThepTDRBTong.Id}");
            }

            context.TKThepTDRBTongs.Update(TKThepTDRBTong);
            await SaveChanges(context);
        }
        //public async Task UpdateMulti(TKThepTDRBTong[] TKThepTDRBTong)
        //{
        //    using var context = _context.CreateDbContext();
        //    string[] ids = TKThepTDRBTong.Select(x => x.Id).ToArray();
        //    var listEntities = await context.TKThepTDRBTongs.Where(x => ids.Contains(x.Id)).ToListAsync();
        //    foreach (var entity in listEntities)
        //    {
        //        context.TKThepTDRBTongs.Update(entity);
        //    }
        //    await context.SaveChangesAsync();
        //}

        public async Task UpdateMulti(TKThepTDRBTong[] TKThepTDRBTong)
        {
            using var context = _context.CreateDbContext();

            // Lấy danh sách ID từ mảng đầu vào
            var ids = TKThepTDRBTong.Select(x => x.Id).ToArray();

            // Lấy danh sách các thực thể từ cơ sở dữ liệu dựa trên các ID
            var listEntities = await context.TKThepTDRBTongs
                .Where(x => ids.Contains(x.Id))
                .ToListAsync();

            // Duyệt qua các thực thể đã lấy được và cập nhật giá trị
            foreach (var entity in listEntities)
            {
                // Tìm đối tượng cập nhật trong mảng đầu vào theo ID
                var updatedEntity = TKThepTDRBTong.FirstOrDefault(x => x.Id == entity.Id);

                if (updatedEntity != null)
                {
                    // Cập nhật các giá trị của thực thể hiện tại từ thực thể đầu vào
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
            await context.TKThepTDRBTongs
                .Where(x => x.Flag > entity.Flag &&
                            x.TTTDCongHoRanh_TenLoaiTamDanTieuChuan == entity.TTTDCongHoRanh_TenLoaiTamDanTieuChuan)
                .ExecuteUpdateAsync(x => x
                    .SetProperty(r => r.Flag, r => r.Flag - 1)
                    .SetProperty(r => r.SoHieu, r => r.SoHieu - 1));

            // Bước 2: Xóa bản ghi
            context.TKThepTDRBTongs.Remove(entity);
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
        public async Task Insert(TKThepTDRBTong entity, string userId)
        {
            try
            {
                using var context = _context.CreateDbContext();
                if (entity == null)
                {
                    throw new Exception("Không có bản ghi nào để thêm!");
                }

                // Lấy tất cả các bản ghi phù hợp và thực hiện xử lý trên client-side
                var maxFlagValue = await context.TKThepTDRBTongs
                    .Where(x => x.TTTDCongHoRanh_TenLoaiTamDanTieuChuan == entity.TTTDCongHoRanh_TenLoaiTamDanTieuChuan)
                    .Select(x => x.Flag)
                    .ToListAsync(); // Lấy danh sách các giá trị Flag

                // Kiểm tra nếu danh sách không có giá trị nào, trả về 0, ngược lại lấy giá trị lớn nhất
                var maxFlag = maxFlagValue.Any() ? maxFlagValue.Max() : 0;


                // Tăng giá trị Flag lên 1
                entity.Flag = maxFlag + 1;

                // Chèn bản ghi mới vào bảng
                context.TKThepTDRBTongs.Add(entity);
                await SaveChanges(context);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public async Task<string> InsertLaterFlag(TKThepTDRBTong entity, int FlagLast, bool insertBefore)
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
                var recordsToUpdate = await context.TKThepTDRBTongs
                    .Where(x => (insertBefore ? x.Flag >= FlagLast : x.Flag > FlagLast)
                    && x.TTTDCongHoRanh_TenLoaiTamDanTieuChuan == entity.TTTDCongHoRanh_TenLoaiTamDanTieuChuan)
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
                    var maxFlag = await context.TKThepTDRBTongs.AnyAsync()
                                  ? await context.TKThepTDRBTongs.MaxAsync(x => x.Flag)
                                  : 0;

                    // Tăng giá trị Flag lên 1
                    entity.Flag = maxFlag + 1;
                }
                else
                {
                    entity.Flag = insertBefore ? FlagLast : FlagLast + 1;
                }

                // Bước 4: Chèn bản ghi mới vào bảng
                context.TKThepTDRBTongs.Add(entity);

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
            var addedEntity = entityEntry.Entity as TKThepTDRBTong;
            if (addedEntity != null)
            {
                PKKLModel pkklModel = new PKKLModel { HangMuc = "III.Gia công, lắp dựng cốt thép", TenCongTac = addedEntity.TenCongTac ?? "", LoaiCauKienId = addedEntity.TTTDCongHoRanh_TenLoaiTamDanTieuChuan };
                List<PKKLModel> result = await _pKKLTDanRBTRepository.GetAllByVM(pkklModel);
                if (result != null)
                {
                    List<PKKLTDanRBT> pKKLRanhBTs = new List<PKKLTDanRBT>();
                    foreach (var record in result)
                    {
                        PKKLTDanRBT pKKLRanhBT = new PKKLTDanRBT();
                        if (!string.IsNullOrEmpty(record.TenCongTac))
                        {
                            pKKLRanhBT.Id = record.Id;
                            pKKLRanhBT.Flag = record.Flag;
                            pKKLRanhBT.TTTDCongHoRanh_TenLoaiTamDanTieuChuan = record.LoaiCauKienId;
                            pKKLRanhBT.LoaiBeTong = record.LoaiBeTong;
                            pKKLRanhBT.HangMuc = record.HangMuc;
                            pKKLRanhBT.HangMucCongTac = record.HangMucCongTac;
                            pKKLRanhBT.TenCongTac = record.TenCongTac;
                            pKKLRanhBT.DonVi = record.DonVi;
                            pKKLRanhBT.KTHH_D = record.KTHH_D;
                            pKKLRanhBT.KTHH_R = record.KTHH_R;
                            pKKLRanhBT.KTHH_C = record.KTHH_C;
                            pKKLRanhBT.KTHH_DienTich = record.KTHH_DienTich;
                            pKKLRanhBT.KTHH_GhiChu = record.KTHH_GhiChu;
                            pKKLRanhBT.KTHH_SLCauKien = record.KTHH_SLCauKien;
                            pKKLRanhBT.TTCDT_CDai = record.TTCDT_CDai;
                            pKKLRanhBT.TTCDT_CRong = record.TTCDT_CRong;
                            pKKLRanhBT.TTCDT_CDay = record.TTCDT_CDay;
                            pKKLRanhBT.TTCDT_DienTich = record.TTCDT_DienTich;
                            pKKLRanhBT.TTCDT_SLCK = record.TTCDT_SLCK;
                            pKKLRanhBT.KLKP_Sl = record.KLKP_Sl;
                            pKKLRanhBT.KLCC1CK = record.KLCC1CK;
                            pKKLRanhBT.CreateAt = record.CreateAt;
                            pKKLRanhBT.CreateBy = record.CreateBy;
                            pKKLRanhBT.KLKP_KL = addedEntity.TongTrongLuong ?? 0;

                            var SumTenCongTacByPL = await GetSumTenCongTacByPL(addedEntity.TTTDCongHoRanh_TenLoaiTamDanTieuChuan??"", addedEntity.TenCongTac ?? "");
                            if (SumTenCongTacByPL != null && SumTenCongTacByPL.Value != null)
                            {
                                if (double.TryParse(SumTenCongTacByPL.Value, out double parsedValue))
                                {
                                    pKKLRanhBT.KLKP_KL = parsedValue + addedEntity.TongTrongLuong ?? 0;
                                }

                            }
                            pKKLRanhBT.KTHH_KL1CK = _pKKLTDanRBTRepository.KTHH_KL1CK(pKKLRanhBT);
                            pKKLRanhBT.TTCDT_KL = _pKKLTDanRBTRepository.TTCDT_KL(pKKLRanhBT);
                            pKKLRanhBT.KL1CK_ChuaTruCC = _pKKLTDanRBTRepository.KL1CK_ChuaTruCC(pKKLRanhBT);
                            pKKLRanhBT.TKLCK_SauCC = Math.Round((pKKLRanhBT.KL1CK_ChuaTruCC - pKKLRanhBT.KLCC1CK),4);
                            pKKLRanhBTs.Add(pKKLRanhBT);
                        }

                    }
                    await _pKKLTDanRBTRepository.UpdateMulti(pKKLRanhBTs.ToArray());
                }
            }
        }
        private async Task HandleEntityDelete(EntityEntry entityEntry)
        {
            var deletedEntity = entityEntry.Entity as TKThepTDRBTong;
            if (deletedEntity != null)
            {
                TKThepTDRBTong entity = await GetById(deletedEntity.Id);

                if (entity == null)
                {
                    throw new Exception($"Không tìm thấy bản ghi theo ID: {deletedEntity.Id}");
                }
                PKKLModel pkklModel = new PKKLModel { HangMuc = "III.Gia công, lắp dựng cốt thép", TenCongTac = entity.TenCongTac ?? "", LoaiCauKienId = entity.TTTDCongHoRanh_TenLoaiTamDanTieuChuan };
                List<PKKLModel> result = await _pKKLTDanRBTRepository.GetAllByVM(pkklModel);
                if (result != null)
                {
                    List<PKKLTDanRBT> pKKLRanhBTs = new List<PKKLTDanRBT>();
                    foreach (var record in result)
                    {
                        PKKLTDanRBT pKKLRanhBT = new PKKLTDanRBT();
                        if (!string.IsNullOrEmpty(record.TenCongTac))
                        {
                            pKKLRanhBT.Id = record.Id;
                            pKKLRanhBT.Flag = record.Flag;
                            pKKLRanhBT.TTTDCongHoRanh_TenLoaiTamDanTieuChuan = record.LoaiCauKienId;
                            pKKLRanhBT.LoaiBeTong = record.LoaiBeTong;
                            pKKLRanhBT.HangMuc = record.HangMuc;
                            pKKLRanhBT.HangMucCongTac = record.HangMucCongTac;
                            pKKLRanhBT.DonVi = record.DonVi;
                            pKKLRanhBT.KTHH_D = record.KTHH_D;
                            pKKLRanhBT.KTHH_R = record.KTHH_R;
                            pKKLRanhBT.KTHH_C = record.KTHH_C;
                            pKKLRanhBT.KTHH_DienTich = record.KTHH_DienTich;
                            pKKLRanhBT.KTHH_GhiChu = record.KTHH_GhiChu;
                            pKKLRanhBT.KTHH_SLCauKien = record.KTHH_SLCauKien;
                            pKKLRanhBT.TTCDT_CDai = record.TTCDT_CDai;
                            pKKLRanhBT.TTCDT_CRong = record.TTCDT_CRong;
                            pKKLRanhBT.TTCDT_CDay = record.TTCDT_CDay;
                            pKKLRanhBT.TTCDT_DienTich = record.TTCDT_DienTich;
                            pKKLRanhBT.TTCDT_SLCK = record.TTCDT_SLCK;
                            pKKLRanhBT.KLKP_Sl = record.KLKP_Sl;
                            pKKLRanhBT.KLCC1CK = record.KLCC1CK;
                            pKKLRanhBT.CreateAt = record.CreateAt;
                            pKKLRanhBT.CreateBy = record.CreateBy;
                            pKKLRanhBT.KLKP_KL = deletedEntity.TongTrongLuong - entity.TongTrongLuong ?? 0;
                            pKKLRanhBT.TenCongTac = "";

                            var SumTenCongTacByPL = await GetSumTenCongTacByPL(entity.TTTDCongHoRanh_TenLoaiTamDanTieuChuan, entity.TenCongTac ?? "");
                            if (SumTenCongTacByPL != null && SumTenCongTacByPL.Value != null)
                            {
                                if (double.TryParse(SumTenCongTacByPL.Value, out double parsedValue))
                                {
                                    pKKLRanhBT.KLKP_KL = parsedValue - deletedEntity.TongTrongLuong ?? 0;
                                    pKKLRanhBT.TenCongTac = record.TenCongTac;
                                }

                            }
                            pKKLRanhBT.KTHH_KL1CK = _pKKLTDanRBTRepository.KTHH_KL1CK(pKKLRanhBT);
                            pKKLRanhBT.TTCDT_KL = _pKKLTDanRBTRepository.TTCDT_KL(pKKLRanhBT);
                            pKKLRanhBT.KL1CK_ChuaTruCC = _pKKLTDanRBTRepository.KL1CK_ChuaTruCC(pKKLRanhBT);
                            pKKLRanhBT.TKLCK_SauCC = Math.Round((pKKLRanhBT.KL1CK_ChuaTruCC - pKKLRanhBT.KLCC1CK),4);
                            pKKLRanhBTs.Add(pKKLRanhBT);
                        }

                    }
                    await _pKKLTDanRBTRepository.UpdateMulti(pKKLRanhBTs.ToArray());
                }
            }
        }
        private async Task HandleEntityUpdate(EntityEntry entityEntry)
        {
            try
            {

                var modifiedEntity = entityEntry.Entity as TKThepTDRBTong;

                if (modifiedEntity != null)
                {
                    TKThepTDRBTong entity = await GetById(modifiedEntity.Id);

                    if (entity == null)
                    {
                        throw new Exception($"Không tìm thấy bản ghi theo ID: {modifiedEntity.Id}");
                    }
                    PKKLModel pkklModel = new PKKLModel { HangMuc = "III.Gia công, lắp dựng cốt thép", TenCongTac = entity.TenCongTac ?? "", LoaiCauKienId = entity.TTTDCongHoRanh_TenLoaiTamDanTieuChuan };
                    List<PKKLModel> result = await _pKKLTDanRBTRepository.GetAllByVM(pkklModel);
                    if (result != null)
                    {
                        List<PKKLTDanRBT> pKKLRanhBTs = new List<PKKLTDanRBT>();
                        foreach (var record in result)
                        {
                            PKKLTDanRBT pKKLRanhBT = new PKKLTDanRBT();
                            if (!string.IsNullOrEmpty(record.TenCongTac))
                            {
                                pKKLRanhBT.Id = record.Id;
                                pKKLRanhBT.Flag = record.Flag;
                                pKKLRanhBT.TTTDCongHoRanh_TenLoaiTamDanTieuChuan = record.LoaiCauKienId;
                                pKKLRanhBT.LoaiBeTong = record.LoaiBeTong;
                                pKKLRanhBT.HangMuc = record.HangMuc;
                                pKKLRanhBT.HangMucCongTac = record.HangMucCongTac;
                                pKKLRanhBT.TenCongTac = record.TenCongTac;
                                pKKLRanhBT.DonVi = record.DonVi;
                                pKKLRanhBT.KTHH_D = record.KTHH_D;
                                pKKLRanhBT.KTHH_R = record.KTHH_R;
                                pKKLRanhBT.KTHH_C = record.KTHH_C;
                                pKKLRanhBT.KTHH_DienTich = record.KTHH_DienTich;
                                pKKLRanhBT.KTHH_GhiChu = record.KTHH_GhiChu;
                                pKKLRanhBT.KTHH_SLCauKien = record.KTHH_SLCauKien;
                                pKKLRanhBT.TTCDT_CDai = record.TTCDT_CDai;
                                pKKLRanhBT.TTCDT_CRong = record.TTCDT_CRong;
                                pKKLRanhBT.TTCDT_CDay = record.TTCDT_CDay;
                                pKKLRanhBT.TTCDT_DienTich = record.TTCDT_DienTich;
                                pKKLRanhBT.TTCDT_SLCK = record.TTCDT_SLCK;
                                pKKLRanhBT.KLKP_Sl = record.KLKP_Sl;
                                pKKLRanhBT.KLCC1CK = record.KLCC1CK;
                                pKKLRanhBT.CreateAt = record.CreateAt;
                                pKKLRanhBT.CreateBy = record.CreateBy;
                                pKKLRanhBT.KLKP_KL = modifiedEntity.TongTrongLuong - entity.TongTrongLuong ?? 0;

                                var SumTenCongTacByPL = await GetSumTenCongTacByPL(entity.TTTDCongHoRanh_TenLoaiTamDanTieuChuan, entity.TenCongTac ?? "");
                                if (SumTenCongTacByPL != null && SumTenCongTacByPL.Value != null)
                                {
                                    if (double.TryParse(SumTenCongTacByPL.Value, out double parsedValue))
                                    {
                                        pKKLRanhBT.KLKP_KL = (parsedValue - entity.TongTrongLuong) + modifiedEntity.TongTrongLuong ?? 0;
                                    }

                                }

                                pKKLRanhBT.KTHH_KL1CK = _pKKLTDanRBTRepository.KTHH_KL1CK(pKKLRanhBT);
                                pKKLRanhBT.TTCDT_KL = _pKKLTDanRBTRepository.TTCDT_KL(pKKLRanhBT);
                                pKKLRanhBT.KL1CK_ChuaTruCC = _pKKLTDanRBTRepository.KL1CK_ChuaTruCC(pKKLRanhBT);
                                pKKLRanhBT.TKLCK_SauCC = Math.Round((pKKLRanhBT.KL1CK_ChuaTruCC - pKKLRanhBT.KLCC1CK),4);
                                pKKLRanhBTs.Add(pKKLRanhBT);
                            }

                        }
                        await _pKKLTDanRBTRepository.UpdateMulti(pKKLRanhBTs.ToArray());
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
