using DucAnhERP.Data;
using DucAnhERP.Helpers;
using DucAnhERP.Models;
using DucAnhERP.Repository;
using DucAnhERP.ViewModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DucAnhERP.Services
{
    public class TKThepTamDanRepository : ITKThepTamDanRepository
    {
        private readonly IDbContextFactory<ApplicationDbContext> _context;
        private readonly PKKLCTietTDHGRepository _pPKKLCTietTDHGRepository;
        public TKThepTamDanRepository(IDbContextFactory<ApplicationDbContext> context)
        {
            _context = context;
            _pPKKLCTietTDHGRepository = new PKKLCTietTDHGRepository(context);
        }
        public async Task<bool> CheckStatus(string ids, string name)
        {
            return true;
        }

        public async Task<List<TKThepTamDan>> GetAll(string groupId)
        {
            try
            {
                using var context = _context.CreateDbContext();
                var entity = await context.TKThepTamDans.ToListAsync();
                return entity;
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.Error.WriteLine($"An error occurred: {ex.Message}");
                throw; // Optionally rethrow the exception
            }
        }
        public async Task<TKThepTamDan> GetById(string id)
        {
            using var context = _context.CreateDbContext();
            var entity = await context.TKThepTamDans.Where(x => x.Id.Equals(id)).FirstOrDefaultAsync();

            if (entity == null)
            {
                throw new Exception($"Không tìm thấy bản ghi theo ID: {id}");
            }

            return entity;
        }
        public async Task<List<TKThepTamDanModel>> GetAllByVM(TKThepTamDanModel mModel)
        {
            try
            {
                using var context = _context.CreateDbContext();
                var query = from tk in context.TKThepTamDans
                            join plTDHG in context.PhanLoaiTDHoGas
                            on tk.ThongTinTamDanHoGa2_PhanLoaiDayHoGa equals plTDHG.Id
                            join dm in context.DSDanhMuc
                            on tk.LoaiThep equals dm.Id
                            join c in context.DMTLTheps
                            on new { tk.LoaiThep, DKCD = tk.DKCD.ToString() } equals new { LoaiThep = c.ChungLoaiThep, DKCD = c.DuongKinh } into dmThepGroup
                            from c in dmThepGroup.DefaultIfEmpty()
                            orderby tk.SoHieu
                            select new TKThepTamDanModel
                            {
                                Id = tk.Id,
                                Flag = tk.Flag,
                                ThongTinTamDanHoGa2_PhanLoaiDayHoGa = tk.ThongTinTamDanHoGa2_PhanLoaiDayHoGa,
                                ThongTinTamDanHoGa2_PhanLoaiDayHoGa_Name = plTDHG.ThongTinTamDanHoGa2_PhanLoaiDayHoGa,
                                TenCongTac = tk.TenCongTac,
                                VTLayKhoiLuong = tk.VTLayKhoiLuong,
                                LoaiThep = tk.LoaiThep,
                                LoaiThep_Name = dm.Ten,
                                SoHieu = tk.SoHieu,
                                DKCD = tk.DKCD,
                                SoThanh = tk.SoThanh,
                                SoCK = tk.SoCK,
                                TongSoThanh = tk.TongSoThanh,
                                ChieuDai1Thanh = tk.ChieuDai1Thanh,
                                TongChieuDai = tk.TongChieuDai,
                                TrongLuong = c.TrongLuong,
                                TongTrongLuong = tk.TongTrongLuong,

                                CreateAt = tk.CreateAt,
                                CreateBy = tk.CreateBy,
                                IsActive = tk.IsActive,
                            };
                if (!string.IsNullOrEmpty(mModel.ThongTinTamDanHoGa2_PhanLoaiDayHoGa))
                {
                    query = query.Where(x => x.ThongTinTamDanHoGa2_PhanLoaiDayHoGa == mModel.ThongTinTamDanHoGa2_PhanLoaiDayHoGa);
                }
                if (!string.IsNullOrEmpty(mModel.LoaiThep))
                {
                    query = query.Where(x => x.LoaiThep == mModel.LoaiThep);
                }
                if (mModel.DKCD >0)
                {
                    query = query.Where(x => x.DKCD == mModel.DKCD);
                }
                var data = await query.Distinct().OrderBy(x=>x.ThongTinTamDanHoGa2_PhanLoaiDayHoGa_Name).ThenBy(x=>x.SoHieu).ToListAsync();
                return data;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }

        }
        public async Task<List<TKThepTamDan>> GetExist(TKThepTamDan searchData)
        {
            try
            {
                using var context = _context.CreateDbContext();

                // Thực hiện lọc dữ liệu dựa trên các thuộc tính của searchData
                var query = context.TKThepTamDans
                             .Where(item => (
                                    item.ThongTinTamDanHoGa2_PhanLoaiDayHoGa ==searchData.ThongTinTamDanHoGa2_PhanLoaiDayHoGa&&
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
        public async Task<List<SelectedItem>> GetDistinctTenCongTacByPL(string ThongTinTamDanHoGa2_PhanLoaiDayHoGa)
        {
            try
            {
                using var context = _context.CreateDbContext();
                var data = context.TKThepTamDans
                 .Where(item => item.ThongTinTamDanHoGa2_PhanLoaiDayHoGa == ThongTinTamDanHoGa2_PhanLoaiDayHoGa)
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
        public async Task<SelectedItem> GetSumTenCongTacByPL(string ThongTinTamDanHoGa2_PhanLoaiDayHoGa, string TenCongTac)
        {
            try
            {
                using var context = _context.CreateDbContext();
                var data = await context.TKThepTamDans
                .Where(item =>
                    item.ThongTinTamDanHoGa2_PhanLoaiDayHoGa == ThongTinTamDanHoGa2_PhanLoaiDayHoGa &&
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
        public async Task Update(TKThepTamDan TKThepTamDan, string userId)
        {
            using var context = _context.CreateDbContext();
            var entity = GetById(TKThepTamDan.Id);

            if (entity == null)
            {
                throw new Exception($"Không tìm thấy bản ghi theo ID: {TKThepTamDan.Id}");
            }

            context.TKThepTamDans.Update(TKThepTamDan);
            await SaveChanges(context);
        }
        //public async Task UpdateMulti(TKThepTamDan[] TKThepTamDan)
        //{
        //    using var context = _context.CreateDbContext();
        //    string[] ids = TKThepTamDan.Select(x => x.Id).ToArray();
        //    var listEntities = await context.TKThepTamDans.Where(x => ids.Contains(x.Id)).ToListAsync();
        //    foreach (var entity in listEntities)
        //    {
        //        context.TKThepTamDans.Update(entity);
        //    }
        //    await context.SaveChangesAsync();
        //}
        public async Task UpdateMulti(TKThepTamDan[] tKThepTamDanArray)
        {
            using var context = _context.CreateDbContext();

            // Lấy danh sách ID từ mảng đầu vào
            var ids = tKThepTamDanArray.Select(x => x.Id).ToArray();

            // Lấy danh sách các thực thể từ cơ sở dữ liệu
            var listEntities = await context.TKThepTamDans
                .Where(x => ids.Contains(x.Id))
                .ToListAsync();

            // Duyệt qua các thực thể đã lấy được và cập nhật các giá trị thay đổi
            foreach (var entity in listEntities)
            {
                // Tìm thực thể tương ứng trong mảng đầu vào
                var updatedEntity = tKThepTamDanArray.FirstOrDefault(x => x.Id == entity.Id);
                if (updatedEntity != null)
                {
                    // Cập nhật chỉ các trường có thay đổi từ thực thể đầu vào
                    context.Entry(entity).CurrentValues.SetValues(updatedEntity);
                }
            }
            // Lưu thay đổi vào cơ sở dữ liệu
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
            await context.TKThepTamDans
                .Where(x => x.Flag > entity.Flag &&
                            x.ThongTinTamDanHoGa2_PhanLoaiDayHoGa == entity.ThongTinTamDanHoGa2_PhanLoaiDayHoGa)
                .ExecuteUpdateAsync(x => x
                    .SetProperty(r => r.Flag, r => r.Flag - 1)
                    .SetProperty(r => r.SoHieu, r => r.SoHieu - 1));

            // Bước 2: Xóa bản ghi
            context.TKThepTamDans.Remove(entity);

            // Lưu tất cả các thay đổi
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
        public async Task Insert(TKThepTamDan entity, string userId)
        {
            try
            {
                using var context = _context.CreateDbContext();
                if (entity == null)
                {
                    throw new Exception("Không có bản ghi nào để thêm!");
                }

                // Lấy tất cả các bản ghi phù hợp và thực hiện xử lý trên client-side
                var maxFlagValue = await context.TKThepTamDans
                    .Where(x => x.ThongTinTamDanHoGa2_PhanLoaiDayHoGa == entity.ThongTinTamDanHoGa2_PhanLoaiDayHoGa)
                    .Select(x => x.Flag)
                    .ToListAsync(); // Lấy danh sách các giá trị Flag

                // Kiểm tra nếu danh sách không có giá trị nào, trả về 0, ngược lại lấy giá trị lớn nhất
                var maxFlag = maxFlagValue.Any() ? maxFlagValue.Max() : 0;


                // Tăng giá trị Flag lên 1
                entity.Flag = maxFlag + 1;

                // Chèn bản ghi mới vào bảng
                context.TKThepTamDans.Add(entity);
                await SaveChanges(context);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public async Task<string> InsertLaterFlag(TKThepTamDan entity, int FlagLast, bool insertBefore)
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
                var recordsToUpdate = await context.TKThepTamDans
                    .Where(x => (insertBefore ? x.Flag >= FlagLast : x.Flag > FlagLast)
                    && x.ThongTinTamDanHoGa2_PhanLoaiDayHoGa == entity.ThongTinTamDanHoGa2_PhanLoaiDayHoGa)
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
                    var maxFlag = await context.TKThepTamDans.AnyAsync()
                                  ? await context.TKThepTamDans.MaxAsync(x => x.Flag)
                                  : 0;

                    // Tăng giá trị Flag lên 1
                    entity.Flag = maxFlag + 1;
                }
                else
                {
                    entity.Flag = insertBefore ? FlagLast : FlagLast + 1;
                }

                // Bước 4: Chèn bản ghi mới vào bảng
                context.TKThepTamDans.Add(entity);

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
            var addedEntity = entityEntry.Entity as TKThepTamDan;
            if (addedEntity != null)
            {
                PKKLModel pkklModel = new PKKLModel { HangMuc = "III.Gia công, lắp dựng cốt thép", TenCongTac = addedEntity.TenCongTac ?? "", LoaiCauKienId = addedEntity.ThongTinTamDanHoGa2_PhanLoaiDayHoGa };
                List<PKKLModel> result = await _pPKKLCTietTDHGRepository.GetAllByVM(pkklModel);
                if (result != null)
                {
                    List<PKKLCTietTDHG> PKKLCTietTDHGs = new List<PKKLCTietTDHG>();
                    foreach (var record in result)
                    {
                        PKKLCTietTDHG PKKLCTietTDHG = new PKKLCTietTDHG();
                        if (!string.IsNullOrEmpty(record.TenCongTac))
                        {
                            PKKLCTietTDHG.Id = record.Id;
                            PKKLCTietTDHG.Flag = record.Flag;
                            PKKLCTietTDHG.ThongTinTamDanHoGa2_PhanLoaiDayHoGa = record.LoaiCauKienId;
                            PKKLCTietTDHG.LoaiBeTong = record.LoaiBeTong;
                            PKKLCTietTDHG.HangMuc = record.HangMuc;
                            PKKLCTietTDHG.HangMucCongTac = record.HangMucCongTac;
                            PKKLCTietTDHG.TenCongTac = record.TenCongTac;
                            PKKLCTietTDHG.DonVi = record.DonVi;
                            PKKLCTietTDHG.KTHH_D = record.KTHH_D;
                            PKKLCTietTDHG.KTHH_R = record.KTHH_R;
                            PKKLCTietTDHG.KTHH_C = record.KTHH_C;
                            PKKLCTietTDHG.KTHH_DienTich = record.KTHH_DienTich;
                            PKKLCTietTDHG.KTHH_GhiChu = record.KTHH_GhiChu;
                            PKKLCTietTDHG.KTHH_SLCauKien = record.KTHH_SLCauKien;
                            PKKLCTietTDHG.TTCDT_CDai = record.TTCDT_CDai;
                            PKKLCTietTDHG.TTCDT_CRong = record.TTCDT_CRong;
                            PKKLCTietTDHG.TTCDT_CDay = record.TTCDT_CDay;
                            PKKLCTietTDHG.TTCDT_DienTich = record.TTCDT_DienTich;
                            PKKLCTietTDHG.TTCDT_SLCK = record.TTCDT_SLCK;
                            PKKLCTietTDHG.KLKP_Sl = record.KLKP_Sl;
                            PKKLCTietTDHG.KLCC1CK = record.KLCC1CK;
                            PKKLCTietTDHG.CreateAt = record.CreateAt;
                            PKKLCTietTDHG.CreateBy = record.CreateBy;
                            PKKLCTietTDHG.KLKP_KL = addedEntity.TongTrongLuong ?? 0;

                            var SumTenCongTacByPL = await GetSumTenCongTacByPL(addedEntity.ThongTinTamDanHoGa2_PhanLoaiDayHoGa, addedEntity.TenCongTac ?? "");
                            if (SumTenCongTacByPL != null && SumTenCongTacByPL.Value != null)
                            {
                                if (double.TryParse(SumTenCongTacByPL.Value, out double parsedValue))
                                {
                                    PKKLCTietTDHG.KLKP_KL = parsedValue + addedEntity.TongTrongLuong ?? 0;
                                }

                            }
                            PKKLCTietTDHG.KTHH_KL1CK = _pPKKLCTietTDHGRepository.KTHH_KL1CK(PKKLCTietTDHG);
                            PKKLCTietTDHG.TTCDT_KL = _pPKKLCTietTDHGRepository.TTCDT_KL(PKKLCTietTDHG);
                            PKKLCTietTDHG.KL1CK_ChuaTruCC = _pPKKLCTietTDHGRepository.KL1CK_ChuaTruCC(PKKLCTietTDHG);
                            PKKLCTietTDHG.TKLCK_SauCC = PKKLCTietTDHG.KL1CK_ChuaTruCC - PKKLCTietTDHG.KLCC1CK;
                            PKKLCTietTDHGs.Add(PKKLCTietTDHG);
                        }

                    }
                    await _pPKKLCTietTDHGRepository.UpdateMulti(PKKLCTietTDHGs.ToArray());
                }
            }
        }
        private async Task HandleEntityDelete(EntityEntry entityEntry)
        {
            var deletedEntity = entityEntry.Entity as TKThepTamDan;
            if (deletedEntity != null)
            {
                TKThepTamDan entity = await GetById(deletedEntity.Id);

                if (entity == null)
                {
                    throw new Exception($"Không tìm thấy bản ghi theo ID: {deletedEntity.Id}");
                }
                PKKLModel pkklModel = new PKKLModel { HangMuc = "III.Gia công, lắp dựng cốt thép", TenCongTac = entity.TenCongTac ?? "", LoaiCauKienId = entity.ThongTinTamDanHoGa2_PhanLoaiDayHoGa };
                List<PKKLModel> result = await _pPKKLCTietTDHGRepository.GetAllByVM(pkklModel);
                if (result != null)
                {
                    List<PKKLCTietTDHG> PKKLCTietTDHGs = new List<PKKLCTietTDHG>();
                    foreach (var record in result)
                    {
                        PKKLCTietTDHG PKKLCTietTDHG = new PKKLCTietTDHG();
                        if (!string.IsNullOrEmpty(record.TenCongTac))
                        {
                            PKKLCTietTDHG.Id = record.Id;
                            PKKLCTietTDHG.Flag = record.Flag;
                            PKKLCTietTDHG.ThongTinTamDanHoGa2_PhanLoaiDayHoGa = record.LoaiCauKienId;
                            PKKLCTietTDHG.LoaiBeTong = record.LoaiBeTong;
                            PKKLCTietTDHG.HangMuc = record.HangMuc;
                            PKKLCTietTDHG.HangMucCongTac = record.HangMucCongTac;
                            PKKLCTietTDHG.DonVi = record.DonVi;
                            PKKLCTietTDHG.KTHH_D = record.KTHH_D;
                            PKKLCTietTDHG.KTHH_R = record.KTHH_R;
                            PKKLCTietTDHG.KTHH_C = record.KTHH_C;
                            PKKLCTietTDHG.KTHH_DienTich = record.KTHH_DienTich;
                            PKKLCTietTDHG.KTHH_GhiChu = record.KTHH_GhiChu;
                            PKKLCTietTDHG.KTHH_SLCauKien = record.KTHH_SLCauKien;
                            PKKLCTietTDHG.TTCDT_CDai = record.TTCDT_CDai;
                            PKKLCTietTDHG.TTCDT_CRong = record.TTCDT_CRong;
                            PKKLCTietTDHG.TTCDT_CDay = record.TTCDT_CDay;
                            PKKLCTietTDHG.TTCDT_DienTich = record.TTCDT_DienTich;
                            PKKLCTietTDHG.TTCDT_SLCK = record.TTCDT_SLCK;
                            PKKLCTietTDHG.KLKP_Sl = record.KLKP_Sl;
                            PKKLCTietTDHG.KLCC1CK = record.KLCC1CK;
                            PKKLCTietTDHG.CreateAt = record.CreateAt;
                            PKKLCTietTDHG.CreateBy = record.CreateBy;
                            PKKLCTietTDHG.KLKP_KL = deletedEntity.TongTrongLuong - entity.TongTrongLuong ?? 0;
                            PKKLCTietTDHG.TenCongTac = "";

                            var SumTenCongTacByPL = await GetSumTenCongTacByPL(entity.ThongTinTamDanHoGa2_PhanLoaiDayHoGa, entity.TenCongTac ?? "");
                            if (SumTenCongTacByPL != null && SumTenCongTacByPL.Value != null)
                            {
                                if (double.TryParse(SumTenCongTacByPL.Value, out double parsedValue))
                                {
                                    PKKLCTietTDHG.KLKP_KL = parsedValue - deletedEntity.TongTrongLuong ?? 0;
                                    PKKLCTietTDHG.TenCongTac = record.TenCongTac;
                                }

                            }
                            PKKLCTietTDHG.KTHH_KL1CK = _pPKKLCTietTDHGRepository.KTHH_KL1CK(PKKLCTietTDHG);
                            PKKLCTietTDHG.TTCDT_KL = _pPKKLCTietTDHGRepository.TTCDT_KL(PKKLCTietTDHG);
                            PKKLCTietTDHG.KL1CK_ChuaTruCC = _pPKKLCTietTDHGRepository.KL1CK_ChuaTruCC(PKKLCTietTDHG);
                            PKKLCTietTDHG.TKLCK_SauCC = PKKLCTietTDHG.KL1CK_ChuaTruCC - PKKLCTietTDHG.KLCC1CK;
                            PKKLCTietTDHGs.Add(PKKLCTietTDHG);
                        }

                    }
                    await _pPKKLCTietTDHGRepository.UpdateMulti(PKKLCTietTDHGs.ToArray());
                }
            }
        }
        private async Task HandleEntityUpdate(EntityEntry entityEntry)
        {
            try
            {

                var modifiedEntity = entityEntry.Entity as TKThepTamDan;

                if (modifiedEntity != null)
                {
                    TKThepTamDan entity = await GetById(modifiedEntity.Id);

                    if (entity == null)
                    {
                        throw new Exception($"Không tìm thấy bản ghi theo ID: {modifiedEntity.Id}");
                    }
                    PKKLModel pkklModel = new PKKLModel { HangMuc = "III.Gia công, lắp dựng cốt thép", TenCongTac = entity.TenCongTac ?? "", LoaiCauKienId = entity.ThongTinTamDanHoGa2_PhanLoaiDayHoGa };
                    List<PKKLModel> result = await _pPKKLCTietTDHGRepository.GetAllByVM(pkklModel);
                    if (result != null)
                    {
                        List<PKKLCTietTDHG> PKKLCTietTDHGs = new List<PKKLCTietTDHG>();
                        foreach (var record in result)
                        {
                            PKKLCTietTDHG PKKLCTietTDHG = new PKKLCTietTDHG();
                            if (!string.IsNullOrEmpty(record.TenCongTac))
                            {
                                PKKLCTietTDHG.Id = record.Id;
                                PKKLCTietTDHG.Flag = record.Flag;
                                PKKLCTietTDHG.ThongTinTamDanHoGa2_PhanLoaiDayHoGa = record.LoaiCauKienId;
                                PKKLCTietTDHG.LoaiBeTong = record.LoaiBeTong;
                                PKKLCTietTDHG.HangMuc = record.HangMuc;
                                PKKLCTietTDHG.HangMucCongTac = record.HangMucCongTac;
                                PKKLCTietTDHG.TenCongTac = record.TenCongTac;
                                PKKLCTietTDHG.DonVi = record.DonVi;
                                PKKLCTietTDHG.KTHH_D = record.KTHH_D;
                                PKKLCTietTDHG.KTHH_R = record.KTHH_R;
                                PKKLCTietTDHG.KTHH_C = record.KTHH_C;
                                PKKLCTietTDHG.KTHH_DienTich = record.KTHH_DienTich;
                                PKKLCTietTDHG.KTHH_GhiChu = record.KTHH_GhiChu;
                                PKKLCTietTDHG.KTHH_SLCauKien = record.KTHH_SLCauKien;
                                PKKLCTietTDHG.TTCDT_CDai = record.TTCDT_CDai;
                                PKKLCTietTDHG.TTCDT_CRong = record.TTCDT_CRong;
                                PKKLCTietTDHG.TTCDT_CDay = record.TTCDT_CDay;
                                PKKLCTietTDHG.TTCDT_DienTich = record.TTCDT_DienTich;
                                PKKLCTietTDHG.TTCDT_SLCK = record.TTCDT_SLCK;
                                PKKLCTietTDHG.KLKP_Sl = record.KLKP_Sl;
                                PKKLCTietTDHG.KLCC1CK = record.KLCC1CK;
                                PKKLCTietTDHG.CreateAt = record.CreateAt;
                                PKKLCTietTDHG.CreateBy = record.CreateBy;
                                PKKLCTietTDHG.KLKP_KL = modifiedEntity.TongTrongLuong - entity.TongTrongLuong ?? 0;

                                var SumTenCongTacByPL = await GetSumTenCongTacByPL(entity.ThongTinTamDanHoGa2_PhanLoaiDayHoGa, entity.TenCongTac ?? "");
                                if (SumTenCongTacByPL != null && SumTenCongTacByPL.Value != null)
                                {
                                    if (double.TryParse(SumTenCongTacByPL.Value, out double parsedValue))
                                    {
                                        PKKLCTietTDHG.KLKP_KL = (parsedValue - entity.TongTrongLuong) + modifiedEntity.TongTrongLuong ?? 0;
                                    }

                                }

                                PKKLCTietTDHG.KTHH_KL1CK = _pPKKLCTietTDHGRepository.KTHH_KL1CK(PKKLCTietTDHG);
                                PKKLCTietTDHG.TTCDT_KL = _pPKKLCTietTDHGRepository.TTCDT_KL(PKKLCTietTDHG);
                                PKKLCTietTDHG.KL1CK_ChuaTruCC = _pPKKLCTietTDHGRepository.KL1CK_ChuaTruCC(PKKLCTietTDHG);
                                PKKLCTietTDHG.TKLCK_SauCC = PKKLCTietTDHG.KL1CK_ChuaTruCC - PKKLCTietTDHG.KLCC1CK;
                                PKKLCTietTDHGs.Add(PKKLCTietTDHG);
                            }

                        }
                        await _pPKKLCTietTDHGRepository.UpdateMulti(PKKLCTietTDHGs.ToArray());
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
