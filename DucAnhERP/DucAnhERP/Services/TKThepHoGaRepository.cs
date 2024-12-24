
using DucAnhERP.Data;
using DucAnhERP.Helpers;
using DucAnhERP.Models;
using DucAnhERP.Repository;
using DucAnhERP.ViewModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.IdentityModel.Tokens;
using System.Text.RegularExpressions;

namespace DucAnhERP.Services
{

    public class TKThepHoGaRepository : ITKThepHoGaRepository
    {
        private readonly IDbContextFactory<ApplicationDbContext> _context;
        private readonly PKKLCTietHoGaRepository _pPKKLCTietHoGaRepository;
        public TKThepHoGaRepository(IDbContextFactory<ApplicationDbContext> context)
        {
            _context = context;
            _pPKKLCTietHoGaRepository =  new PKKLCTietHoGaRepository(context);
        }
        public async Task<List<TKThepHoGa>> GetAll()
        {
            try
            {
                using var context = _context.CreateDbContext();
                var entity = await context.TKThepHoGas.ToListAsync();
                return entity;
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.Error.WriteLine($"An error occurred: {ex.Message}");
                throw; // Optionally rethrow the exception
            }
        }
        public async Task<TKThepHoGa> GetById(string id)
        {
            using var context = _context.CreateDbContext();
            var entity = await context.TKThepHoGas.Where(x => x.Id.Equals(id)).FirstOrDefaultAsync();

            if (entity == null)
            {
                throw new Exception($"Không tìm thấy bản ghi theo ID: {id}");
            }

            return entity;
        }
        public async Task<List<TKThepHoGaModel>> GetAllByVM(TKThepHoGaModel mModel)
        {
            try
            {
                using var context = _context.CreateDbContext();
                var query = (from a in context.TKThepHoGas
                            join b in context.PhanLoaiHoGaDetails
                            on a.ThongTinChungHoGa_TenHoGaSauPhanLoai equals b.Id into plHoGaGroup
                            from b in plHoGaGroup.DefaultIfEmpty()
                            join dm in context.DSDanhMuc
                            on a.LoaiThep equals dm.Id
                            join c in context.DMTLTheps
                            on new { a.LoaiThep, DKCD = a.DKCD.ToString() } equals new { LoaiThep = c.ChungLoaiThep, DKCD = c.DuongKinh } into dmThepGroup
                            from c in dmThepGroup.DefaultIfEmpty()
                            orderby a.SoHieu
                            select new TKThepHoGaModel
                            {
                                Id = a.Id,
                                Flag = a.Flag,
                                ThongTinChungHoGa_TenHoGaSauPhanLoai = a.ThongTinChungHoGa_TenHoGaSauPhanLoai,
                                ThongTinChungHoGa_TenHoGaSauPhanLoai_Name = b.ThongTinChungHoGa_TenHoGaSauPhanLoai,
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
                            });

                if (!string.IsNullOrEmpty(mModel.ThongTinChungHoGa_TenHoGaSauPhanLoai))
                {
                    query = query.Where(x => x.ThongTinChungHoGa_TenHoGaSauPhanLoai == mModel.ThongTinChungHoGa_TenHoGaSauPhanLoai);
                }
                if (!string.IsNullOrEmpty(mModel.LoaiThep))
                {
                    query = query.Where(x => x.LoaiThep == mModel.LoaiThep);
                }
                var data = await query.Distinct().OrderBy(x => x.ThongTinChungHoGa_TenHoGaSauPhanLoai_Name).ThenBy(x => x.SoHieu).ToListAsync();
                return data;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }

        }
        public async Task<List<TKThepHoGa>> GetExist(TKThepHoGa searchData)
        {
            try
            {
                using var context = _context.CreateDbContext();

                // Thực hiện lọc dữ liệu dựa trên các thuộc tính của searchData
                var query = context.TKThepHoGas
                             .Where(item => (
                                    item.ThongTinChungHoGa_TenHoGaSauPhanLoai == searchData.ThongTinChungHoGa_TenHoGaSauPhanLoai &&
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
        public async Task<List<SelectedItem>> GetDistinctTenCongTacByPL(string ThongTinChungHoGa_TenHoGaSauPhanLoai)
        {
            try
            {
                using var context = _context.CreateDbContext();
                var data = context.TKThepHoGas
                 .Where(item => item.ThongTinChungHoGa_TenHoGaSauPhanLoai == ThongTinChungHoGa_TenHoGaSauPhanLoai)
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
        public async Task<SelectedItem> GetSumTenCongTacByPL(string ThongTinChungHoGa_TenHoGaSauPhanLoai, string TenCongTac)
        {
            try
            {
                using var context = _context.CreateDbContext();
                var data = await context.TKThepHoGas
                .Where(item =>
                    item.ThongTinChungHoGa_TenHoGaSauPhanLoai == ThongTinChungHoGa_TenHoGaSauPhanLoai &&
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
        public async Task Update(TKThepHoGa TKThepHoGa)
        {
            using var context = _context.CreateDbContext();
            var entity = GetById(TKThepHoGa.Id);

            if (entity == null)
            {
                throw new Exception($"Không tìm thấy bản ghi theo ID: {TKThepHoGa.Id}");
            }

            context.TKThepHoGas.Update(TKThepHoGa);
            await SaveChanges(context);
        }
        public async Task UpdateMulti(TKThepHoGa[] TKThepHoGa)
        {
            using var context = _context.CreateDbContext();
            string[] ids = TKThepHoGa.Select(x => x.Id).ToArray();
            var listEntities = await context.TKThepHoGas.Where(x => ids.Contains(x.Id)).ToListAsync();
            foreach (var entity in listEntities)
            {
                context.TKThepHoGas.Update(entity);
            }
            await context.SaveChangesAsync();
        }
        public async Task DeleteById(string id)
        {
            using var context = _context.CreateDbContext();
            var entity = await context.TKThepHoGas.FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null)
            {
                throw new Exception($"Không tìm thấy bản ghi theo ID: {id}");
            }

            // Bước 1: Cập nhật trực tiếp các bản ghi có flag > FlagLast
            await context.TKThepHoGas
                .Where(x => x.Flag > entity.Flag &&
                            x.ThongTinChungHoGa_TenHoGaSauPhanLoai == entity.ThongTinChungHoGa_TenHoGaSauPhanLoai)
                .ExecuteUpdateAsync(x => x
                    .SetProperty(r => r.Flag, r => r.Flag - 1)
                    .SetProperty(r => r.SoHieu, r => r.SoHieu - 1));

            // Bước 2: Xóa bản ghi
            context.TKThepHoGas.Remove(entity);

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
        public async Task Insert(TKThepHoGa entity)
        {
            try
            {
                using var context = _context.CreateDbContext();
                if (entity == null)
                {
                    throw new Exception("Không có bản ghi nào để thêm!");
                }

                // Lấy tất cả các bản ghi phù hợp và thực hiện xử lý trên client-side
                var maxFlagValue = await context.TKThepHoGas
                    .Where(x => x.ThongTinChungHoGa_TenHoGaSauPhanLoai == entity.ThongTinChungHoGa_TenHoGaSauPhanLoai)
                    .Select(x => x.Flag)
                    .ToListAsync(); // Lấy danh sách các giá trị Flag

                // Kiểm tra nếu danh sách không có giá trị nào, trả về 0, ngược lại lấy giá trị lớn nhất
                var maxFlag = maxFlagValue.Any() ? maxFlagValue.Max() : 0;


                // Tăng giá trị Flag lên 1
                entity.Flag = maxFlag + 1;

                // Chèn bản ghi mới vào bảng
                context.TKThepHoGas.Add(entity);
                await SaveChanges(context);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public async Task<string> InsertLaterFlag(TKThepHoGa entity, int FlagLast, bool insertBefore)
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
                var recordsToUpdate = await context.TKThepHoGas
                    .Where(x => (insertBefore ? x.Flag >= FlagLast : x.Flag > FlagLast)
                    && x.ThongTinChungHoGa_TenHoGaSauPhanLoai == entity.ThongTinChungHoGa_TenHoGaSauPhanLoai)
                    .ToListAsync();

                // Bước 2: Tăng giá trị flag,SoHieu của các bản ghi đó thêm 1
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
                    var maxFlag = await context.TKThepHoGas.AnyAsync()
                                  ? await context.TKThepHoGas.MaxAsync(x => x.Flag)
                                  : 0;

                    // Tăng giá trị Flag lên 1
                    entity.Flag = maxFlag + 1;
                }
                else
                {
                    entity.Flag = insertBefore ? FlagLast : FlagLast + 1;
                }

                // Bước 4: Chèn bản ghi mới vào bảng
                context.TKThepHoGas.Add(entity);

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
            var addedEntity = entityEntry.Entity as TKThepHoGa;
            if (addedEntity != null)
            {
                PKKLCTietHoGaModel pKKLHoGaModel = new PKKLCTietHoGaModel { HangMuc = "VII.Gia công, lắp dựng cốt thép hố ga", TenCongTac = addedEntity.TenCongTac ?? "", LoaiCauKienId = addedEntity.ThongTinChungHoGa_TenHoGaSauPhanLoai??"" };
                List<PKKLCTietHoGaModel> result = await _pPKKLCTietHoGaRepository.GetAllByVM(pKKLHoGaModel);
                if (result != null)
                {
                    List<PKKLCTietHoGa> PKKLCTietHoGas = new List<PKKLCTietHoGa>();
                    foreach (var record in result)
                    {
                        PKKLCTietHoGa PKKLCTietHoGa = new PKKLCTietHoGa();
                        if (!string.IsNullOrEmpty(record.TenCongTac))
                        {
                            PKKLCTietHoGa.Id = record.Id;
                            PKKLCTietHoGa.Flag = record.Flag;
                            PKKLCTietHoGa.ThongTinChungHoGa_HinhThucHoGa = record.ThongTinChungHoGa_HinhThucHoGa;
                            PKKLCTietHoGa.ThongTinChungHoGa_KetCauMuMo = record.ThongTinChungHoGa_KetCauMuMo;
                            PKKLCTietHoGa.ThongTinChungHoGa_TenHoGaSauPhanLoai = record.LoaiCauKienId;
                            PKKLCTietHoGa.LoaiBeTong = record.LoaiBeTong;
                            PKKLCTietHoGa.HangMuc = record.HangMuc;
                            PKKLCTietHoGa.HangMucCongTac = record.HangMucCongTac;
                            PKKLCTietHoGa.TenCongTac = record.TenCongTac;
                            PKKLCTietHoGa.DonVi = record.DonVi;
                            PKKLCTietHoGa.KTHH_D = record.KTHH_D;
                            PKKLCTietHoGa.KTHH_R = record.KTHH_R;
                            PKKLCTietHoGa.KTHH_C = record.KTHH_C;
                            PKKLCTietHoGa.KTHH_DienTich = record.KTHH_DienTich;
                            PKKLCTietHoGa.KTHH_GhiChu = record.KTHH_GhiChu;
                            PKKLCTietHoGa.KTHH_SLCauKien = record.KTHH_SLCauKien;
                            PKKLCTietHoGa.TTCDT_CDai = record.TTCDT_CDai;
                            PKKLCTietHoGa.TTCDT_CRong = record.TTCDT_CRong;
                            PKKLCTietHoGa.TTCDT_CDay = record.TTCDT_CDay;
                            PKKLCTietHoGa.TTCDT_DienTich = record.TTCDT_DienTich;
                            PKKLCTietHoGa.TTCDT_SLCK = record.TTCDT_SLCK;
                            PKKLCTietHoGa.KLKP_Sl = record.KLKP_Sl;
                            PKKLCTietHoGa.KLCC1CK = record.KLCC1CK;
                            PKKLCTietHoGa.CreateAt = record.CreateAt;
                            PKKLCTietHoGa.CreateBy = record.CreateBy;
                            PKKLCTietHoGa.KLKP_KL = addedEntity.TongTrongLuong ?? 0;

                            var SumTenCongTacByPL = await GetSumTenCongTacByPL(addedEntity.ThongTinChungHoGa_TenHoGaSauPhanLoai??"", addedEntity.TenCongTac ?? "");
                            if (SumTenCongTacByPL != null && SumTenCongTacByPL.Value != null)
                            {
                                if (double.TryParse(SumTenCongTacByPL.Value, out double parsedValue))
                                {
                                    PKKLCTietHoGa.KLKP_KL =Math.Round((parsedValue + addedEntity.TongTrongLuong ?? 0),4);
                                }

                            }
                            PKKLCTietHoGa.KTHH_KL1CK = _pPKKLCTietHoGaRepository.KTHH_KL1CK(PKKLCTietHoGa);
                            PKKLCTietHoGa.TTCDT_KL = _pPKKLCTietHoGaRepository.TTCDT_KL(PKKLCTietHoGa);
                            PKKLCTietHoGa.KL1CK_ChuaTruCC = _pPKKLCTietHoGaRepository.KL1CK_ChuaTruCC(PKKLCTietHoGa);
                            PKKLCTietHoGa.TKLCK_SauCC = PKKLCTietHoGa.KL1CK_ChuaTruCC - PKKLCTietHoGa.KLCC1CK;
                            PKKLCTietHoGas.Add(PKKLCTietHoGa);
                        }

                    }
                    await _pPKKLCTietHoGaRepository.UpdateMulti(PKKLCTietHoGas.ToArray());
                }
            }
        }
        private async Task HandleEntityDelete(EntityEntry entityEntry)
        {
            var deletedEntity = entityEntry.Entity as TKThepHoGa;
            if (deletedEntity != null)
            {
                TKThepHoGa entity = await GetById(deletedEntity.Id);

                if (entity == null)
                {
                    throw new Exception($"Không tìm thấy bản ghi theo ID: {deletedEntity.Id}");
                }
                PKKLCTietHoGaModel pKKLHoGaModel = new PKKLCTietHoGaModel { HangMuc = "VII.Gia công, lắp dựng cốt thép hố ga", TenCongTac = entity.TenCongTac ?? "", LoaiCauKienId = entity.ThongTinChungHoGa_TenHoGaSauPhanLoai ?? "" };
                List<PKKLCTietHoGaModel> result = await _pPKKLCTietHoGaRepository.GetAllByVM(pKKLHoGaModel);
                if (result != null)
                {
                    List<PKKLCTietHoGa> PKKLCTietHoGas = new List<PKKLCTietHoGa>();
                    foreach (var record in result)
                    {
                        PKKLCTietHoGa PKKLCTietHoGa = new PKKLCTietHoGa();
                        if (!string.IsNullOrEmpty(record.TenCongTac))
                        {
                            PKKLCTietHoGa.Id = record.Id;
                            PKKLCTietHoGa.Flag = record.Flag;
                            PKKLCTietHoGa.ThongTinChungHoGa_HinhThucHoGa = record.ThongTinChungHoGa_HinhThucHoGa;
                            PKKLCTietHoGa.ThongTinChungHoGa_KetCauMuMo = record.ThongTinChungHoGa_KetCauMuMo;
                            PKKLCTietHoGa.ThongTinChungHoGa_TenHoGaSauPhanLoai = record.LoaiCauKienId;
                            PKKLCTietHoGa.LoaiBeTong = record.LoaiBeTong;
                            PKKLCTietHoGa.HangMuc = record.HangMuc;
                            PKKLCTietHoGa.HangMucCongTac = record.HangMucCongTac;
                            PKKLCTietHoGa.DonVi = record.DonVi;
                            PKKLCTietHoGa.KTHH_D = record.KTHH_D;
                            PKKLCTietHoGa.KTHH_R = record.KTHH_R;
                            PKKLCTietHoGa.KTHH_C = record.KTHH_C;
                            PKKLCTietHoGa.KTHH_DienTich = record.KTHH_DienTich;
                            PKKLCTietHoGa.KTHH_GhiChu = record.KTHH_GhiChu;
                            PKKLCTietHoGa.KTHH_SLCauKien = record.KTHH_SLCauKien;
                            PKKLCTietHoGa.TTCDT_CDai = record.TTCDT_CDai;
                            PKKLCTietHoGa.TTCDT_CRong = record.TTCDT_CRong;
                            PKKLCTietHoGa.TTCDT_CDay = record.TTCDT_CDay;
                            PKKLCTietHoGa.TTCDT_DienTich = record.TTCDT_DienTich;
                            PKKLCTietHoGa.TTCDT_SLCK = record.TTCDT_SLCK;
                            PKKLCTietHoGa.KLKP_Sl = record.KLKP_Sl;
                            PKKLCTietHoGa.KLCC1CK = record.KLCC1CK;
                            PKKLCTietHoGa.CreateAt = record.CreateAt;
                            PKKLCTietHoGa.CreateBy = record.CreateBy;
                            PKKLCTietHoGa.KLKP_KL = deletedEntity.TongTrongLuong - entity.TongTrongLuong ?? 0;
                            PKKLCTietHoGa.TenCongTac = "";

                            var SumTenCongTacByPL = await GetSumTenCongTacByPL(entity.ThongTinChungHoGa_TenHoGaSauPhanLoai ?? "", entity.TenCongTac ?? "");
                            if (SumTenCongTacByPL != null && SumTenCongTacByPL.Value != null)
                            {
                                if (double.TryParse(SumTenCongTacByPL.Value, out double parsedValue))
                                {
                                    PKKLCTietHoGa.KLKP_KL = Math.Round((parsedValue - deletedEntity.TongTrongLuong ?? 0),4);
                                    PKKLCTietHoGa.TenCongTac = record.TenCongTac;
                                }

                            }
                            PKKLCTietHoGa.KTHH_KL1CK = _pPKKLCTietHoGaRepository.KTHH_KL1CK(PKKLCTietHoGa);
                            PKKLCTietHoGa.TTCDT_KL = _pPKKLCTietHoGaRepository.TTCDT_KL(PKKLCTietHoGa);
                            PKKLCTietHoGa.KL1CK_ChuaTruCC = _pPKKLCTietHoGaRepository.KL1CK_ChuaTruCC(PKKLCTietHoGa);
                            PKKLCTietHoGa.TKLCK_SauCC = PKKLCTietHoGa.KL1CK_ChuaTruCC - PKKLCTietHoGa.KLCC1CK;
                            PKKLCTietHoGas.Add(PKKLCTietHoGa);
                        }

                    }
                    await _pPKKLCTietHoGaRepository.UpdateMulti(PKKLCTietHoGas.ToArray());
                }
            }
        }
        private async Task HandleEntityUpdate(EntityEntry entityEntry)
        {
            try
            {

                var modifiedEntity = entityEntry.Entity as TKThepHoGa;

                if (modifiedEntity != null)
                {
                    TKThepHoGa entity = await GetById(modifiedEntity.Id);

                    if (entity == null)
                    {
                        throw new Exception($"Không tìm thấy bản ghi theo ID: {modifiedEntity.Id}");
                    }
                    PKKLCTietHoGaModel pKKLHoGaModel = new PKKLCTietHoGaModel { HangMuc = "VII.Gia công, lắp dựng cốt thép hố ga", TenCongTac = entity.TenCongTac ?? "", LoaiCauKienId = entity.ThongTinChungHoGa_TenHoGaSauPhanLoai??"" };
                    List<PKKLCTietHoGaModel> result = await _pPKKLCTietHoGaRepository.GetAllByVM(pKKLHoGaModel);
                    if (result != null)
                    {
                        List<PKKLCTietHoGa> PKKLCTietHoGas = new List<PKKLCTietHoGa>();
                        foreach (var record in result)
                        {
                            PKKLCTietHoGa PKKLCTietHoGa = new PKKLCTietHoGa();
                            if (!string.IsNullOrEmpty(record.TenCongTac))
                            {
                                PKKLCTietHoGa.Id = record.Id;
                                PKKLCTietHoGa.Flag = record.Flag;
                                PKKLCTietHoGa.ThongTinChungHoGa_HinhThucHoGa = record.ThongTinChungHoGa_HinhThucHoGa;
                                PKKLCTietHoGa.ThongTinChungHoGa_KetCauMuMo = record.ThongTinChungHoGa_KetCauMuMo;
                                PKKLCTietHoGa.ThongTinChungHoGa_TenHoGaSauPhanLoai = record.LoaiCauKienId;
                                PKKLCTietHoGa.LoaiBeTong = record.LoaiBeTong;
                                PKKLCTietHoGa.HangMuc = record.HangMuc;
                                PKKLCTietHoGa.HangMucCongTac = record.HangMucCongTac;
                                PKKLCTietHoGa.TenCongTac = record.TenCongTac;
                                PKKLCTietHoGa.DonVi = record.DonVi;
                                PKKLCTietHoGa.KTHH_D = record.KTHH_D;
                                PKKLCTietHoGa.KTHH_R = record.KTHH_R;
                                PKKLCTietHoGa.KTHH_C = record.KTHH_C;
                                PKKLCTietHoGa.KTHH_DienTich = record.KTHH_DienTich;
                                PKKLCTietHoGa.KTHH_GhiChu = record.KTHH_GhiChu;
                                PKKLCTietHoGa.KTHH_SLCauKien = record.KTHH_SLCauKien;
                                PKKLCTietHoGa.TTCDT_CDai = record.TTCDT_CDai;
                                PKKLCTietHoGa.TTCDT_CRong = record.TTCDT_CRong;
                                PKKLCTietHoGa.TTCDT_CDay = record.TTCDT_CDay;
                                PKKLCTietHoGa.TTCDT_DienTich = record.TTCDT_DienTich;
                                PKKLCTietHoGa.TTCDT_SLCK = record.TTCDT_SLCK;
                                PKKLCTietHoGa.KLKP_Sl = record.KLKP_Sl;
                                PKKLCTietHoGa.KLCC1CK = record.KLCC1CK;
                                PKKLCTietHoGa.CreateAt = record.CreateAt;
                                PKKLCTietHoGa.CreateBy = record.CreateBy;
                                PKKLCTietHoGa.KLKP_KL = modifiedEntity.TongTrongLuong - entity.TongTrongLuong ?? 0;

                                var SumTenCongTacByPL = await GetSumTenCongTacByPL(entity.ThongTinChungHoGa_TenHoGaSauPhanLoai??"", entity.TenCongTac ?? "");
                                if (SumTenCongTacByPL != null && SumTenCongTacByPL.Value != null)
                                {
                                    if (double.TryParse(SumTenCongTacByPL.Value, out double parsedValue))
                                    {
                                        PKKLCTietHoGa.KLKP_KL = Math.Round((parsedValue - entity.TongTrongLuong) + modifiedEntity.TongTrongLuong ?? 0, 4);
                                    }
                                }

                                PKKLCTietHoGa.KTHH_KL1CK = _pPKKLCTietHoGaRepository.KTHH_KL1CK(PKKLCTietHoGa);
                                PKKLCTietHoGa.TTCDT_KL = _pPKKLCTietHoGaRepository.TTCDT_KL(PKKLCTietHoGa);
                                PKKLCTietHoGa.KL1CK_ChuaTruCC = _pPKKLCTietHoGaRepository.KL1CK_ChuaTruCC(PKKLCTietHoGa);
                                PKKLCTietHoGa.TKLCK_SauCC = PKKLCTietHoGa.KL1CK_ChuaTruCC - PKKLCTietHoGa.KLCC1CK;
                                PKKLCTietHoGas.Add(PKKLCTietHoGa);
                            }

                        }
                        await _pPKKLCTietHoGaRepository.UpdateMulti(PKKLCTietHoGas.ToArray());
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
