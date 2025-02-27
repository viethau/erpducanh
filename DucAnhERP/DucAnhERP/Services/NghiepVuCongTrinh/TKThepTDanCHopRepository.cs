﻿using DucAnhERP.Data;
using DucAnhERP.Helpers;
using DucAnhERP.Models.NghiepVuCongTrinh;
using DucAnhERP.Repository.NghiepVuCongTrinh;
using DucAnhERP.ViewModel.NghiepVuCongTrinh;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DucAnhERP.Services.NghiepVuCongTrinh
{
    public class TKThepTDanCHopRepository :ITKThepTDanCHopRepository
    {
        private readonly PKKLTDanCHopRepository _pKKLTDanCHopRepository;
        private readonly IDbContextFactory<ApplicationDbContext> _context;

        public TKThepTDanCHopRepository(IDbContextFactory<ApplicationDbContext> context)
        {
            _context = context;
            _pKKLTDanCHopRepository = new PKKLTDanCHopRepository(_context);
        }
        public async Task<bool> CheckStatus(string ids, string name)
        {
            return true;
        }

        public async Task<List<TKThepTDanCHop>> GetAll(string groupId)
        {
            try
            {
                using var context = _context.CreateDbContext();
                var entity = await context.TKThepTDanCHops.ToListAsync();
                return entity;
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.Error.WriteLine($"An error occurred: {ex.Message}");
                throw; // Optionally rethrow the exception
            }
        }
        public async Task<TKThepTDanCHop> GetById(string id)
        {
            using var context = _context.CreateDbContext();
            var entity = await context.TKThepTDanCHops.Where(x => x.Id.Equals(id)).FirstOrDefaultAsync();

            if (entity == null)
            {
                throw new Exception($"Không tìm thấy bản ghi theo ID: {id}");
            }

            return entity;
        }
        public async Task<List<TKThepTDanCHopModel>> GetAllByVM(TKThepTDanCHopModel mModel)
        {
            try
            {
                using var context = _context.CreateDbContext();
                var query = from a in context.TKThepTDanCHops
                            join b in context.PhanLoaiTDanTDans
                            on a.TTTDCongHoRanh_TenLoaiTamDanTieuChuan equals b.Id into plc
                            from b in plc.DefaultIfEmpty()
                            join dm in context.DSDanhMuc
                            on a.LoaiThep equals dm.Id
                            join c in context.DMTLTheps
                            on new { a.LoaiThep, DKCD = a.DKCD.ToString() } equals new { LoaiThep = c.ChungLoaiThep, DKCD = c.DuongKinh } into dmThepGroup
                            from c in dmThepGroup.DefaultIfEmpty()
                            orderby a.SoHieu
                            select new TKThepTDanCHopModel
                            {
                                Id = a.Id,
                                Flag = a.Flag,

                                TTTDCongHoRanh_TenLoaiTamDanTieuChuan = a.TTTDCongHoRanh_TenLoaiTamDanTieuChuan ?? "",
                                PhanLoaiTDanTDan_TenLoaiTamDanTieuChuan = b.TTTDCongHoRanh_TenLoaiTamDanTieuChuan ?? "",

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
        public async Task<List<TKThepTDanCHop>> GetExist(TKThepTDanCHop searchData)
        {
            try
            {
                using var context = _context.CreateDbContext();

                // Thực hiện lọc dữ liệu dựa trên các thuộc tính của searchData
                var query = context.TKThepTDanCHops
                             .Where(item => 
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
        public async Task<List<SelectedItem>> GetDistinctTenCongTacByPL(string TTTDCongHoRanh_TenLoaiTamDanTieuChuan)
        {
            try
            {
                using var context = _context.CreateDbContext();
                var data = context.TKThepTDanCHops
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
                var data = await context.TKThepTDanCHops
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
        public async Task Update(TKThepTDanCHop TKThepDeCong, string userId)
        {
            using var context = _context.CreateDbContext();
            var entity = GetById(TKThepDeCong.Id);

            if (entity == null)
            {
                throw new Exception($"Không tìm thấy bản ghi theo ID: {TKThepDeCong.Id}");
            }

            context.TKThepTDanCHops.Update(TKThepDeCong);
            await SaveChanges(context);
        }
        //public async Task UpdateMulti(TKThepTDanCHop[] TKThepDeCong)
        //{
        //    using var context = _context.CreateDbContext();
        //    string[] ids = TKThepDeCong.Select(x => x.Id).ToArray();
        //    var listEntities = await context.TKThepTDanCHops.Where(x => ids.Contains(x.Id)).ToListAsync();
        //    foreach (var entity in listEntities)
        //    {
        //        context.TKThepTDanCHops.Update(entity);
        //    }
        //    await context.SaveChangesAsync();
        //}
        public async Task UpdateMulti(TKThepTDanCHop[] TKThepDeCong)
        {
            using var context = _context.CreateDbContext();

            // Lấy danh sách ID từ mảng đầu vào
            var ids = TKThepDeCong.Select(x => x.Id).ToArray();

            // Lấy danh sách các thực thể từ cơ sở dữ liệu
            var listEntities = await context.TKThepTDanCHops
                .Where(x => ids.Contains(x.Id))
                .ToListAsync();

            // Duyệt qua các thực thể đã lấy được và cập nhật các giá trị thay đổi
            foreach (var entity in listEntities)
            {
                // Tìm thực thể tương ứng trong mảng đầu vào
                var updatedEntity = TKThepDeCong.FirstOrDefault(x => x.Id == entity.Id);
                if (updatedEntity != null)
                {
                    // Cập nhật chỉ các trường có thay đổi từ thực thể đầu vào
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
            await context.TKThepTDanCHops
                .Where(x => x.Flag > entity.Flag &&
                            x.TTTDCongHoRanh_TenLoaiTamDanTieuChuan == entity.TTTDCongHoRanh_TenLoaiTamDanTieuChuan)
                .ExecuteUpdateAsync(x => x
                    .SetProperty(r => r.Flag, r => r.Flag - 1)
                    .SetProperty(r => r.SoHieu, r => r.SoHieu - 1));

            // Bước 2: Xóa bản ghi
            context.TKThepTDanCHops.Remove(entity);

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
        public async Task Insert(TKThepTDanCHop entity, string userId)
        {
            try
            {
                using var context = _context.CreateDbContext();
                if (entity == null)
                {
                    throw new Exception("Không có bản ghi nào để thêm!");
                }

                // Lấy tất cả các bản ghi phù hợp và thực hiện xử lý trên client-side
                var maxFlagValue = await context.TKThepTDanCHops
                    .Where(x => x.TTTDCongHoRanh_TenLoaiTamDanTieuChuan == entity.TTTDCongHoRanh_TenLoaiTamDanTieuChuan)
                    .Select(x => x.Flag)
                    .ToListAsync(); // Lấy danh sách các giá trị Flag

                // Kiểm tra nếu danh sách không có giá trị nào, trả về 0, ngược lại lấy giá trị lớn nhất
                var maxFlag = maxFlagValue.Any() ? maxFlagValue.Max() : 0;


                // Tăng giá trị Flag lên 1
                entity.Flag = maxFlag + 1;

                // Chèn bản ghi mới vào bảng
                context.TKThepTDanCHops.Add(entity);
                await SaveChanges(context);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public async Task<string> InsertLaterFlag(TKThepTDanCHop entity, int FlagLast, bool insertBefore)
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
                var recordsToUpdate = await context.TKThepTDanCHops
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
                    var maxFlag = await context.TKThepTDanCHops.AnyAsync()
                                  ? await context.TKThepTDanCHops.MaxAsync(x => x.Flag)
                                  : 0;

                    // Tăng giá trị Flag lên 1
                    entity.Flag = maxFlag + 1;
                }
                else
                {
                    entity.Flag = insertBefore ? FlagLast : FlagLast + 1;
                }

                // Bước 4: Chèn bản ghi mới vào bảng
                context.TKThepTDanCHops.Add(entity);

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
            var addedEntity = entityEntry.Entity as TKThepTDanCHop;
            if (addedEntity != null)
            {
                PKKLModel pkklModel = new PKKLModel { HangMuc = "III.Gia công, lắp dựng cốt thép", TenCongTac = addedEntity.TenCongTac ?? "", LoaiCauKienId = addedEntity.TTTDCongHoRanh_TenLoaiTamDanTieuChuan };
                List<PKKLModel> result = await _pKKLTDanCHopRepository.GetAllByVM(pkklModel);
                if (result != null)
                {
                    List<PKKLTDanCHop> PKKLTDanCHops = new List<PKKLTDanCHop>();
                    foreach (var record in result)
                    {
                        PKKLTDanCHop PKKLTDanCHop = new PKKLTDanCHop();
                        if (!string.IsNullOrEmpty(record.TenCongTac))
                        {
                            PKKLTDanCHop.Id = record.Id;
                            PKKLTDanCHop.Flag = record.Flag;
                            PKKLTDanCHop.TTTDCongHoRanh_TenLoaiTamDanTieuChuan = record.LoaiCauKienId;
                            PKKLTDanCHop.LoaiBeTong = record.LoaiBeTong;
                            PKKLTDanCHop.HangMuc = record.HangMuc;
                            PKKLTDanCHop.HangMucCongTac = record.HangMucCongTac;
                            PKKLTDanCHop.TenCongTac = record.TenCongTac;
                            PKKLTDanCHop.DonVi = record.DonVi;
                            PKKLTDanCHop.KTHH_D = record.KTHH_D;
                            PKKLTDanCHop.KTHH_R = record.KTHH_R;
                            PKKLTDanCHop.KTHH_C = record.KTHH_C;
                            PKKLTDanCHop.KTHH_DienTich = record.KTHH_DienTich;
                            PKKLTDanCHop.KTHH_GhiChu = record.KTHH_GhiChu;
                            PKKLTDanCHop.KTHH_SLCauKien = record.KTHH_SLCauKien;
                            PKKLTDanCHop.TTCDT_CDai = record.TTCDT_CDai;
                            PKKLTDanCHop.TTCDT_CRong = record.TTCDT_CRong;
                            PKKLTDanCHop.TTCDT_CDay = record.TTCDT_CDay;
                            PKKLTDanCHop.TTCDT_DienTich = record.TTCDT_DienTich;
                            PKKLTDanCHop.TTCDT_SLCK = record.TTCDT_SLCK;
                            PKKLTDanCHop.KLKP_Sl = record.KLKP_Sl;
                            PKKLTDanCHop.KLCC1CK = record.KLCC1CK;
                            PKKLTDanCHop.CreateAt = record.CreateAt;
                            PKKLTDanCHop.CreateBy = record.CreateBy;
                            PKKLTDanCHop.KLKP_KL = addedEntity.TongTrongLuong ?? 0;

                            var SumTenCongTacByPL = await GetSumTenCongTacByPL(addedEntity.TTTDCongHoRanh_TenLoaiTamDanTieuChuan, addedEntity.TenCongTac ?? "");
                            if (SumTenCongTacByPL != null && SumTenCongTacByPL.Value != null)
                            {
                                if (double.TryParse(SumTenCongTacByPL.Value, out double parsedValue))
                                {
                                    PKKLTDanCHop.KLKP_KL = parsedValue + addedEntity.TongTrongLuong ?? 0;
                                }

                            }
                            PKKLTDanCHop.KTHH_KL1CK = _pKKLTDanCHopRepository.KTHH_KL1CK(PKKLTDanCHop);
                            PKKLTDanCHop.TTCDT_KL = _pKKLTDanCHopRepository.TTCDT_KL(PKKLTDanCHop);
                            PKKLTDanCHop.KL1CK_ChuaTruCC = _pKKLTDanCHopRepository.KL1CK_ChuaTruCC(PKKLTDanCHop);
                            PKKLTDanCHop.TKLCK_SauCC = PKKLTDanCHop.KL1CK_ChuaTruCC - PKKLTDanCHop.KLCC1CK;
                            PKKLTDanCHops.Add(PKKLTDanCHop);
                        }

                    }
                    await _pKKLTDanCHopRepository.UpdateMulti(PKKLTDanCHops.ToArray());
                }
            }
        }
        private async Task HandleEntityDelete(EntityEntry entityEntry)
        {
            var deletedEntity = entityEntry.Entity as TKThepTDanCHop;
            if (deletedEntity != null)
            {
                TKThepTDanCHop entity = await GetById(deletedEntity.Id);

                if (entity == null)
                {
                    throw new Exception($"Không tìm thấy bản ghi theo ID: {deletedEntity.Id}");
                }
                PKKLModel pkklModel = new PKKLModel { HangMuc = "III.Gia công, lắp dựng cốt thép", TenCongTac = entity.TenCongTac ?? "", LoaiCauKienId = entity.TTTDCongHoRanh_TenLoaiTamDanTieuChuan };
                List<PKKLModel> result = await _pKKLTDanCHopRepository.GetAllByVM(pkklModel);
                if (result != null)
                {
                    List<PKKLTDanCHop> PKKLTDanCHops = new List<PKKLTDanCHop>();
                    foreach (var record in result)
                    {
                        PKKLTDanCHop PKKLTDanCHop = new PKKLTDanCHop();
                        if (!string.IsNullOrEmpty(record.TenCongTac))
                        {
                            PKKLTDanCHop.Id = record.Id;
                            PKKLTDanCHop.Flag = record.Flag;
                            PKKLTDanCHop.TTTDCongHoRanh_TenLoaiTamDanTieuChuan = record.LoaiCauKienId;
                            PKKLTDanCHop.LoaiBeTong = record.LoaiBeTong;
                            PKKLTDanCHop.HangMuc = record.HangMuc;
                            PKKLTDanCHop.HangMucCongTac = record.HangMucCongTac;
                            PKKLTDanCHop.DonVi = record.DonVi;
                            PKKLTDanCHop.KTHH_D = record.KTHH_D;
                            PKKLTDanCHop.KTHH_R = record.KTHH_R;
                            PKKLTDanCHop.KTHH_C = record.KTHH_C;
                            PKKLTDanCHop.KTHH_DienTich = record.KTHH_DienTich;
                            PKKLTDanCHop.KTHH_GhiChu = record.KTHH_GhiChu;
                            PKKLTDanCHop.KTHH_SLCauKien = record.KTHH_SLCauKien;
                            PKKLTDanCHop.TTCDT_CDai = record.TTCDT_CDai;
                            PKKLTDanCHop.TTCDT_CRong = record.TTCDT_CRong;
                            PKKLTDanCHop.TTCDT_CDay = record.TTCDT_CDay;
                            PKKLTDanCHop.TTCDT_DienTich = record.TTCDT_DienTich;
                            PKKLTDanCHop.TTCDT_SLCK = record.TTCDT_SLCK;
                            PKKLTDanCHop.KLKP_Sl = record.KLKP_Sl;
                            PKKLTDanCHop.KLCC1CK = record.KLCC1CK;
                            PKKLTDanCHop.CreateAt = record.CreateAt;
                            PKKLTDanCHop.CreateBy = record.CreateBy;
                            PKKLTDanCHop.KLKP_KL = deletedEntity.TongTrongLuong - entity.TongTrongLuong ?? 0;
                            PKKLTDanCHop.TenCongTac = "";

                            var SumTenCongTacByPL = await GetSumTenCongTacByPL(entity.TTTDCongHoRanh_TenLoaiTamDanTieuChuan, entity.TenCongTac ?? "");
                            if (SumTenCongTacByPL != null && SumTenCongTacByPL.Value != null)
                            {
                                if (double.TryParse(SumTenCongTacByPL.Value, out double parsedValue))
                                {
                                    PKKLTDanCHop.KLKP_KL = parsedValue - deletedEntity.TongTrongLuong ?? 0;
                                    PKKLTDanCHop.TenCongTac = record.TenCongTac;
                                }

                            }
                            PKKLTDanCHop.KTHH_KL1CK = _pKKLTDanCHopRepository.KTHH_KL1CK(PKKLTDanCHop);
                            PKKLTDanCHop.TTCDT_KL = _pKKLTDanCHopRepository.TTCDT_KL(PKKLTDanCHop);
                            PKKLTDanCHop.KL1CK_ChuaTruCC = _pKKLTDanCHopRepository.KL1CK_ChuaTruCC(PKKLTDanCHop);
                            PKKLTDanCHop.TKLCK_SauCC = PKKLTDanCHop.KL1CK_ChuaTruCC - PKKLTDanCHop.KLCC1CK;
                            PKKLTDanCHops.Add(PKKLTDanCHop);
                        }

                    }
                    await _pKKLTDanCHopRepository.UpdateMulti(PKKLTDanCHops.ToArray());
                }
            }
        }
        private async Task HandleEntityUpdate(EntityEntry entityEntry)
        {
            try
            {

                var modifiedEntity = entityEntry.Entity as TKThepTDanCHop;

                if (modifiedEntity != null)
                {
                    TKThepTDanCHop entity = await GetById(modifiedEntity.Id);

                    if (entity == null)
                    {
                        throw new Exception($"Không tìm thấy bản ghi theo ID: {modifiedEntity.Id}");
                    }
                    PKKLModel pkklModel = new PKKLModel { HangMuc = "III.Gia công, lắp dựng cốt thép", TenCongTac = entity.TenCongTac ?? "", LoaiCauKienId = entity.TTTDCongHoRanh_TenLoaiTamDanTieuChuan };
                    List<PKKLModel> result = await _pKKLTDanCHopRepository.GetAllByVM(pkklModel);
                    if (result != null)
                    {
                        List<PKKLTDanCHop> PKKLTDanCHops = new List<PKKLTDanCHop>();
                        foreach (var record in result)
                        {
                            PKKLTDanCHop PKKLTDanCHop = new PKKLTDanCHop();
                            if (!string.IsNullOrEmpty(record.TenCongTac))
                            {
                                PKKLTDanCHop.Id = record.Id;
                                PKKLTDanCHop.Flag = record.Flag;
                                PKKLTDanCHop.TTTDCongHoRanh_TenLoaiTamDanTieuChuan = record.LoaiCauKienId;
                                PKKLTDanCHop.LoaiBeTong = record.LoaiBeTong;
                                PKKLTDanCHop.HangMuc = record.HangMuc;
                                PKKLTDanCHop.HangMucCongTac = record.HangMucCongTac;
                                PKKLTDanCHop.TenCongTac = record.TenCongTac;
                                PKKLTDanCHop.DonVi = record.DonVi;
                                PKKLTDanCHop.KTHH_D = record.KTHH_D;
                                PKKLTDanCHop.KTHH_R = record.KTHH_R;
                                PKKLTDanCHop.KTHH_C = record.KTHH_C;
                                PKKLTDanCHop.KTHH_DienTich = record.KTHH_DienTich;
                                PKKLTDanCHop.KTHH_GhiChu = record.KTHH_GhiChu;
                                PKKLTDanCHop.KTHH_SLCauKien = record.KTHH_SLCauKien;
                                PKKLTDanCHop.TTCDT_CDai = record.TTCDT_CDai;
                                PKKLTDanCHop.TTCDT_CRong = record.TTCDT_CRong;
                                PKKLTDanCHop.TTCDT_CDay = record.TTCDT_CDay;
                                PKKLTDanCHop.TTCDT_DienTich = record.TTCDT_DienTich;
                                PKKLTDanCHop.TTCDT_SLCK = record.TTCDT_SLCK;
                                PKKLTDanCHop.KLKP_Sl = record.KLKP_Sl;
                                PKKLTDanCHop.KLCC1CK = record.KLCC1CK;
                                PKKLTDanCHop.CreateAt = record.CreateAt;
                                PKKLTDanCHop.CreateBy = record.CreateBy;
                                PKKLTDanCHop.KLKP_KL = modifiedEntity.TongTrongLuong - entity.TongTrongLuong ?? 0;

                                var SumTenCongTacByPL = await GetSumTenCongTacByPL(entity.TTTDCongHoRanh_TenLoaiTamDanTieuChuan, entity.TenCongTac ?? "");
                                if (SumTenCongTacByPL != null && SumTenCongTacByPL.Value != null)
                                {
                                    if (double.TryParse(SumTenCongTacByPL.Value, out double parsedValue))
                                    {
                                        PKKLTDanCHop.KLKP_KL = parsedValue - entity.TongTrongLuong + modifiedEntity.TongTrongLuong ?? 0;
                                    }

                                }

                                PKKLTDanCHop.KTHH_KL1CK = _pKKLTDanCHopRepository.KTHH_KL1CK(PKKLTDanCHop);
                                PKKLTDanCHop.TTCDT_KL = _pKKLTDanCHopRepository.TTCDT_KL(PKKLTDanCHop);
                                PKKLTDanCHop.KL1CK_ChuaTruCC = _pKKLTDanCHopRepository.KL1CK_ChuaTruCC(PKKLTDanCHop);
                                PKKLTDanCHop.TKLCK_SauCC = PKKLTDanCHop.KL1CK_ChuaTruCC - PKKLTDanCHop.KLCC1CK;
                                PKKLTDanCHops.Add(PKKLTDanCHop);
                            }

                        }
                        await _pKKLTDanCHopRepository.UpdateMulti(PKKLTDanCHops.ToArray());
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
