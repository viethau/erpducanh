using DucAnhERP.Data;
using DucAnhERP.Helpers;
using DucAnhERP.Models;
using DucAnhERP.Repository;
using DucAnhERP.ViewModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DucAnhERP.Services
{
    public class TKThepCHopRepository : ITKThepCHopRepository
    {
        private readonly IDbContextFactory<ApplicationDbContext> _context;
        private readonly PKKLCHopRepository _pKKLCHopRepository;

        public TKThepCHopRepository(IDbContextFactory<ApplicationDbContext> context)
        {
            _context = context;
            _pKKLCHopRepository =  new PKKLCHopRepository(context);
        }
        public async Task<List<TKThepCHop>> GetAll()
        {
            try
            {
                using var context = _context.CreateDbContext();
                var entity = await context.TKThepCHops.ToListAsync();
                return entity;
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.Error.WriteLine($"An error occurred: {ex.Message}");
                throw; // Optionally rethrow the exception
            }
        }
        public async Task<TKThepCHop> GetById(string id)
        {
            using var context = _context.CreateDbContext();
            var entity = await context.TKThepCHops.Where(x => x.Id.Equals(id)).FirstOrDefaultAsync();

            if (entity == null)
            {
                throw new Exception($"Không tìm thấy bản ghi theo ID: {id}");
            }

            return entity;
        }
        public async Task<List<TKThepCHopModel>> GetAllByVM(TKThepCHopModel mModel)
        {
            try
            {
                using var context = _context.CreateDbContext();
                var query = from a in context.TKThepCHops
                            join b in context.PhanLoaiCTronHopNhuas
                            on a.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai equals b.Id into plc
                            from b in plc.DefaultIfEmpty()
                            join dm in context.DSDanhMuc
                            on a.LoaiThep equals dm.Id
                            join c in context.DMTLTheps
                            on new { a.LoaiThep, DKCD = a.DKCD.ToString() } equals new { LoaiThep = c.ChungLoaiThep, DKCD = c.DuongKinh } into dmThepGroup
                            from c in dmThepGroup.DefaultIfEmpty()
                            orderby a.SoHieu
                            select new TKThepCHopModel
                            {
                                Id = a.Id,
                                Flag = a.Flag,

                                ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai = a.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai??"",
                                PhanLoaiCTronHopNhua_TenLoaiTruyenDanSauPhanLoai = b.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai ?? "",

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
        public async Task<List<TKThepCHop>> GetExist(TKThepCHop searchData)
        {
            try
            {
                using var context = _context.CreateDbContext();

                // Thực hiện lọc dữ liệu dựa trên các thuộc tính của searchData
                var query = context.TKThepCHops
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

        public async Task<List<SelectedItem>> GetDistinctTenCongTacByPL(string ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai)
        {
            try
            {
                using var context = _context.CreateDbContext();
                var data = context.TKThepCHops
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
                var data = await context.TKThepCHops
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
        public async Task Update(TKThepCHop TKThepDeCong)
        {
            using var context = _context.CreateDbContext();
            var entity = GetById(TKThepDeCong.Id);

            if (entity == null)
            {
                throw new Exception($"Không tìm thấy bản ghi theo ID: {TKThepDeCong.Id}");
            }

            context.TKThepCHops.Update(TKThepDeCong);
            await SaveChanges(context);
        }
        //public async Task UpdateMulti(TKThepCHop[] TKThepDeCong)
        //{
        //    using var context = _context.CreateDbContext();
        //    string[] ids = TKThepDeCong.Select(x => x.Id).ToArray();
        //    var listEntities = await context.TKThepCHops.Where(x => ids.Contains(x.Id)).ToListAsync();
        //    foreach (var entity in listEntities)
        //    {
        //        context.TKThepCHops.Update(entity);
        //    }
        //    await context.SaveChangesAsync();
        //}

        public async Task UpdateMulti(TKThepCHop[] tKThepCHopArray)
        {
            using var context = _context.CreateDbContext();

            // Lấy danh sách ID từ mảng đầu vào
            var ids = tKThepCHopArray.Select(x => x.Id).ToArray();

            // Lấy danh sách thực thể từ cơ sở dữ liệu dựa trên ID
            var listEntities = await context.TKThepCHops
                .Where(x => ids.Contains(x.Id))
                .ToListAsync();

            // Cập nhật giá trị cho các thực thể
            foreach (var entity in listEntities)
            {
                var updatedEntity = tKThepCHopArray.FirstOrDefault(x => x.Id == entity.Id);
                if (updatedEntity != null)
                {
                    // Chỉ cập nhật các giá trị thay đổi
                    context.Entry(entity).CurrentValues.SetValues(updatedEntity);
                }
            }
            await SaveChanges(context);
        }


        public async Task DeleteById(string id)
        {
            using var context = _context.CreateDbContext();
            var entity = await GetById(id);

            // Bước 1: Cập nhật trực tiếp các bản ghi có flag > FlagLast
            await context.TKThepCHops
                .Where(x => x.Flag > entity.Flag &&
                            x.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai == entity.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai)
                .ExecuteUpdateAsync(x => x
                    .SetProperty(r => r.Flag, r => r.Flag - 1)
                    .SetProperty(r => r.SoHieu, r => r.SoHieu - 1));

            // Bước 2: Xóa bản ghi
            context.TKThepCHops.Remove(entity);

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
        public async Task Insert(TKThepCHop entity)
        {
            try
            {
                using var context = _context.CreateDbContext();
                if (entity == null)
                {
                    throw new Exception("Không có bản ghi nào để thêm!");
                }

                // Lấy tất cả các bản ghi phù hợp và thực hiện xử lý trên client-side
                var maxFlagValue = await context.TKThepCHops
                    .Where(x => x.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai == entity.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai)
                    .Select(x => x.Flag)
                    .ToListAsync(); // Lấy danh sách các giá trị Flag

                // Kiểm tra nếu danh sách không có giá trị nào, trả về 0, ngược lại lấy giá trị lớn nhất
                var maxFlag = maxFlagValue.Any() ? maxFlagValue.Max() : 0;


                // Tăng giá trị Flag lên 1
                entity.Flag = maxFlag + 1;

                // Chèn bản ghi mới vào bảng
                context.TKThepCHops.Add(entity);
                await SaveChanges(context);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public async Task<string> InsertLaterFlag(TKThepCHop entity, int FlagLast, bool insertBefore)
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
                var recordsToUpdate = await context.TKThepCHops
                    .Where(x => (insertBefore ? x.Flag >= FlagLast : x.Flag > FlagLast)
                    && x.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai == entity.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai)
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
                    var maxFlag = await context.TKThepCHops.AnyAsync()
                                  ? await context.TKThepCHops.MaxAsync(x => x.Flag)
                                  : 0;

                    // Tăng giá trị Flag lên 1
                    entity.Flag = maxFlag + 1;
                }
                else
                {
                    entity.Flag = insertBefore ? FlagLast : FlagLast + 1;
                }

                // Bước 4: Chèn bản ghi mới vào bảng
                context.TKThepCHops.Add(entity);

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
            var addedEntity = entityEntry.Entity as TKThepCHop;
            if (addedEntity != null)
            {
                PKKLModel pkklModel = new PKKLModel { HangMuc = "III.Gia công, lắp dựng cốt thép", TenCongTac = addedEntity.TenCongTac ?? "", LoaiCauKienId = addedEntity.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai };
                List<PKKLModel> result = await _pKKLCHopRepository.GetAllByVM(pkklModel);
                if (result != null)
                {
                    List<PKKLCHop> pKKLCTrons = new List<PKKLCHop>();
                    foreach (var record in result)
                    {
                        PKKLCHop pKKLCTron = new PKKLCHop();
                        if (!string.IsNullOrEmpty(record.TenCongTac))
                        {
                            pKKLCTron.Id = record.Id;
                            pKKLCTron.Flag = record.Flag;
                            pKKLCTron.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai = record.LoaiCauKienId;
                            pKKLCTron.LoaiBeTong = record.LoaiBeTong;
                            pKKLCTron.HangMuc = record.HangMuc;
                            pKKLCTron.HangMucCongTac = record.HangMucCongTac;
                            pKKLCTron.TenCongTac = record.TenCongTac;
                            pKKLCTron.DonVi = record.DonVi;
                            pKKLCTron.KTHH_D = record.KTHH_D;
                            pKKLCTron.KTHH_R = record.KTHH_R;
                            pKKLCTron.KTHH_C = record.KTHH_C;
                            pKKLCTron.KTHH_DienTich = record.KTHH_DienTich;
                            pKKLCTron.KTHH_GhiChu = record.KTHH_GhiChu;
                            pKKLCTron.KTHH_SLCauKien = record.KTHH_SLCauKien;
                            pKKLCTron.TTCDT_CDai = record.TTCDT_CDai;
                            pKKLCTron.TTCDT_CRong = record.TTCDT_CRong;
                            pKKLCTron.TTCDT_CDay = record.TTCDT_CDay;
                            pKKLCTron.TTCDT_DienTich = record.TTCDT_DienTich;
                            pKKLCTron.TTCDT_SLCK = record.TTCDT_SLCK;
                            pKKLCTron.KLKP_Sl = record.KLKP_Sl;
                            pKKLCTron.KLCC1CK = record.KLCC1CK;
                            pKKLCTron.CreateAt = record.CreateAt;
                            pKKLCTron.CreateBy = record.CreateBy;
                            pKKLCTron.KLKP_KL = addedEntity.TongTrongLuong ?? 0;

                            var SumTenCongTacByPL = await GetSumTenCongTacByPL(addedEntity.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai, addedEntity.TenCongTac ?? "");
                            if (SumTenCongTacByPL != null && SumTenCongTacByPL.Value != null)
                            {
                                if (double.TryParse(SumTenCongTacByPL.Value, out double parsedValue))
                                {
                                    pKKLCTron.KLKP_KL = parsedValue + addedEntity.TongTrongLuong ?? 0;
                                }
                                
                            }
                            pKKLCTron.KTHH_KL1CK = _pKKLCHopRepository.KTHH_KL1CK(pKKLCTron);
                            pKKLCTron.TTCDT_KL = _pKKLCHopRepository.TTCDT_KL(pKKLCTron);
                            pKKLCTron.KL1CK_ChuaTruCC = _pKKLCHopRepository.KL1CK_ChuaTruCC(pKKLCTron);
                            pKKLCTron.TKLCK_SauCC = pKKLCTron.KL1CK_ChuaTruCC - pKKLCTron.KLCC1CK;
                            pKKLCTrons.Add(pKKLCTron);
                        }

                    }
                    await _pKKLCHopRepository.UpdateMulti(pKKLCTrons.ToArray());
                }
            }
        }
        private async Task HandleEntityDelete(EntityEntry entityEntry)
        {
            var deletedEntity = entityEntry.Entity as TKThepCHop;
            if (deletedEntity != null)
            {
                TKThepCHop entity = await GetById(deletedEntity.Id);

                if (entity == null)
                {
                    throw new Exception($"Không tìm thấy bản ghi theo ID: {deletedEntity.Id}");
                }
                PKKLModel pkklModel = new PKKLModel { HangMuc = "III.Gia công, lắp dựng cốt thép", TenCongTac = entity.TenCongTac ?? "", LoaiCauKienId = entity.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai };
                List<PKKLModel> result = await _pKKLCHopRepository.GetAllByVM(pkklModel);
                if (result != null)
                {
                    List<PKKLCHop> pKKLCTrons = new List<PKKLCHop>();
                    foreach (var record in result)
                    {
                        PKKLCHop pKKLCTron = new PKKLCHop();
                        if (!string.IsNullOrEmpty(record.TenCongTac))
                        {
                            pKKLCTron.Id = record.Id;
                            pKKLCTron.Flag = record.Flag;
                            pKKLCTron.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai = record.LoaiCauKienId;
                            pKKLCTron.LoaiBeTong = record.LoaiBeTong;
                            pKKLCTron.HangMuc = record.HangMuc;
                            pKKLCTron.HangMucCongTac = record.HangMucCongTac;
                            pKKLCTron.DonVi = record.DonVi;
                            pKKLCTron.KTHH_D = record.KTHH_D;
                            pKKLCTron.KTHH_R = record.KTHH_R;
                            pKKLCTron.KTHH_C = record.KTHH_C;
                            pKKLCTron.KTHH_DienTich = record.KTHH_DienTich;
                            pKKLCTron.KTHH_GhiChu = record.KTHH_GhiChu;
                            pKKLCTron.KTHH_SLCauKien = record.KTHH_SLCauKien;
                            pKKLCTron.TTCDT_CDai = record.TTCDT_CDai;
                            pKKLCTron.TTCDT_CRong = record.TTCDT_CRong;
                            pKKLCTron.TTCDT_CDay = record.TTCDT_CDay;
                            pKKLCTron.TTCDT_DienTich = record.TTCDT_DienTich;
                            pKKLCTron.TTCDT_SLCK = record.TTCDT_SLCK;
                            pKKLCTron.KLKP_Sl = record.KLKP_Sl;
                            pKKLCTron.KLCC1CK = record.KLCC1CK;
                            pKKLCTron.CreateAt = record.CreateAt;
                            pKKLCTron.CreateBy = record.CreateBy;
                            // Xử lý khi giá trị không thể chuyển đổi thành số
                            pKKLCTron.KLKP_KL = deletedEntity.TongTrongLuong - entity.TongTrongLuong ?? 0;
                            pKKLCTron.TenCongTac = "";

                            var SumTenCongTacByPL = await GetSumTenCongTacByPL(entity.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai, entity.TenCongTac ?? "");
                            if (SumTenCongTacByPL != null && SumTenCongTacByPL.Value != null)
                            {
                                if (double.TryParse(SumTenCongTacByPL.Value, out double parsedValue))
                                {
                                    pKKLCTron.KLKP_KL = parsedValue - deletedEntity.TongTrongLuong ?? 0;
                                    pKKLCTron.TenCongTac = record.TenCongTac;
                                }
                                
                            }
                            pKKLCTron.KTHH_KL1CK = _pKKLCHopRepository.KTHH_KL1CK(pKKLCTron);
                            pKKLCTron.TTCDT_KL = _pKKLCHopRepository.TTCDT_KL(pKKLCTron);
                            pKKLCTron.KL1CK_ChuaTruCC = _pKKLCHopRepository.KL1CK_ChuaTruCC(pKKLCTron);
                            pKKLCTron.TKLCK_SauCC = pKKLCTron.KL1CK_ChuaTruCC - pKKLCTron.KLCC1CK;
                            pKKLCTrons.Add(pKKLCTron);
                        }

                    }
                    await _pKKLCHopRepository.UpdateMulti(pKKLCTrons.ToArray());
                }
            }
        }
        private async Task HandleEntityUpdate(EntityEntry entityEntry)
        {
            try
            {

                var modifiedEntity = entityEntry.Entity as TKThepCHop;

                if (modifiedEntity != null)
                {
                    TKThepCHop entity = await GetById(modifiedEntity.Id);

                    if (entity == null)
                    {
                        throw new Exception($"Không tìm thấy bản ghi theo ID: {modifiedEntity.Id}");
                    }
                    PKKLModel pkklModel = new PKKLModel { HangMuc = "III.Gia công, lắp dựng cốt thép", TenCongTac = entity.TenCongTac ?? "", LoaiCauKienId = entity.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai };
                    List<PKKLModel> result = await _pKKLCHopRepository.GetAllByVM(pkklModel);
                    if (result != null)
                    {
                        List<PKKLCHop> pKKLCTrons = new List<PKKLCHop>();
                        foreach (var record in result)
                        {
                            PKKLCHop pKKLCTron = new PKKLCHop();
                            if (!string.IsNullOrEmpty(record.TenCongTac))
                            {
                                pKKLCTron.Id = record.Id;
                                pKKLCTron.Flag = record.Flag;
                                pKKLCTron.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai = record.LoaiCauKienId;
                                pKKLCTron.LoaiBeTong = record.LoaiBeTong;
                                pKKLCTron.HangMuc = record.HangMuc;
                                pKKLCTron.HangMucCongTac = record.HangMucCongTac;
                                pKKLCTron.TenCongTac = record.TenCongTac;
                                pKKLCTron.DonVi = record.DonVi;
                                pKKLCTron.KTHH_D = record.KTHH_D;
                                pKKLCTron.KTHH_R = record.KTHH_R;
                                pKKLCTron.KTHH_C = record.KTHH_C;
                                pKKLCTron.KTHH_DienTich = record.KTHH_DienTich;
                                pKKLCTron.KTHH_GhiChu = record.KTHH_GhiChu;
                                pKKLCTron.KTHH_SLCauKien = record.KTHH_SLCauKien;
                                pKKLCTron.TTCDT_CDai = record.TTCDT_CDai;
                                pKKLCTron.TTCDT_CRong = record.TTCDT_CRong;
                                pKKLCTron.TTCDT_CDay = record.TTCDT_CDay;
                                pKKLCTron.TTCDT_DienTich = record.TTCDT_DienTich;
                                pKKLCTron.TTCDT_SLCK = record.TTCDT_SLCK;
                                pKKLCTron.KLKP_Sl = record.KLKP_Sl;
                                pKKLCTron.KLCC1CK = record.KLCC1CK;
                                pKKLCTron.CreateAt = record.CreateAt;
                                pKKLCTron.CreateBy = record.CreateBy;
                                // Xử lý khi giá trị không thể chuyển đổi thành số
                                pKKLCTron.KLKP_KL = modifiedEntity.TongTrongLuong - entity.TongTrongLuong ?? 0;

                                var SumTenCongTacByPL = await GetSumTenCongTacByPL(entity.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai, entity.TenCongTac ?? "");
                                if (SumTenCongTacByPL != null && SumTenCongTacByPL.Value != null)
                                {
                                    if (double.TryParse(SumTenCongTacByPL.Value, out double parsedValue))
                                    {
                                        pKKLCTron.KLKP_KL = (parsedValue - entity.TongTrongLuong) + modifiedEntity.TongTrongLuong ?? 0;
                                    }
                                    
                                }

                                pKKLCTron.KTHH_KL1CK = _pKKLCHopRepository.KTHH_KL1CK(pKKLCTron);
                                pKKLCTron.TTCDT_KL = _pKKLCHopRepository.TTCDT_KL(pKKLCTron);
                                pKKLCTron.KL1CK_ChuaTruCC = _pKKLCHopRepository.KL1CK_ChuaTruCC(pKKLCTron);
                                pKKLCTron.TKLCK_SauCC = pKKLCTron.KL1CK_ChuaTruCC - pKKLCTron.KLCC1CK;
                                pKKLCTrons.Add(pKKLCTron);
                            }

                        }
                        await _pKKLCHopRepository.UpdateMulti(pKKLCTrons.ToArray());
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
