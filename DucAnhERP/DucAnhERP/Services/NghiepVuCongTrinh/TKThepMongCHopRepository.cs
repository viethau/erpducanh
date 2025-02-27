﻿using DucAnhERP.Data;
using DucAnhERP.Helpers;
using DucAnhERP.Models.NghiepVuCongTrinh;
using DucAnhERP.Repository.NghiepVuCongTrinh;
using DucAnhERP.ViewModel.NghiepVuCongTrinh;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DucAnhERP.Services.NghiepVuCongTrinh
{
    public class TKThepMongCHopRepository : ITKThepMongCHopRepository
    {
        private readonly PKKLMongCHopRepository _pKKLMongCHopRepository;
        private readonly IDbContextFactory<ApplicationDbContext> _context;

        public TKThepMongCHopRepository(IDbContextFactory<ApplicationDbContext> context)
        {
            _context = context;
            _pKKLMongCHopRepository = new PKKLMongCHopRepository(context);
        }
        public async Task<bool> CheckStatus(string ids, string name)
        {
            return true;
        }
        public async Task<List<TKThepMongCHop>> GetAll(string groupId)
        {
            try
            {
                using var context = _context.CreateDbContext();
                var entity = await context.TKThepMongCHops.ToListAsync();
                return entity;
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.Error.WriteLine($"An error occurred: {ex.Message}");
                throw; // Optionally rethrow the exception
            }
        }
        public async Task<TKThepMongCHop> GetById(string id)
        {
            using var context = _context.CreateDbContext();
            var entity = await context.TKThepMongCHops.Where(x => x.Id.Equals(id)).FirstOrDefaultAsync();

            if (entity == null)
            {
                throw new Exception($"Không tìm thấy bản ghi theo ID: {id}");
            }

            return entity;
        }
        public async Task<List<TKThepMongCHopModel>> GetAllByVM(TKThepMongCHopModel mModel)
        {
            try
            {
                using var context = _context.CreateDbContext();
                var query = from a in context.TKThepMongCHops
                            join b in context.PhanLoaiMongCTrons
                            on a.ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop equals b.Id into plc
                            from b in plc.DefaultIfEmpty()
                            join dm in context.DSDanhMuc
                            on a.LoaiThep equals dm.Id
                            join c in context.DMTLTheps
                            on new { a.LoaiThep, DKCD = a.DKCD.ToString() } equals new { LoaiThep = c.ChungLoaiThep, DKCD = c.DuongKinh } into dmThepGroup
                            from c in dmThepGroup.DefaultIfEmpty()
                            orderby a.SoHieu
                            select new TKThepMongCHopModel
                            {
                                Id = a.Id,
                                Flag = a.Flag,
                                ThongTinLyTrinh_TuyenDuong = a.ThongTinLyTrinh_TuyenDuong,
                                ThongTinLyTrinhTruyenDan_TuLyTrinh = a.ThongTinLyTrinhTruyenDan_TuLyTrinh,
                                ThongTinLyTrinhTruyenDan_DenLyTrinh = a.ThongTinLyTrinhTruyenDan_DenLyTrinh,

                                ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop = a.ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop,
                                PhanLoaiMongCTron_PhanLoaiMongCongTronCongHop = b.ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop ?? "",

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
        public async Task<List<TKThepMongCHop>> GetExist(TKThepMongCHop searchData)
        {
            try
            {
                using var context = _context.CreateDbContext();

                // Thực hiện lọc dữ liệu dựa trên các thuộc tính của searchData
                var query = context.TKThepMongCHops
                             .Where(item => 
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
        public async Task<List<SelectedItem>> GetDistinctTenCongTacByPL(string ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop)
        {
            try
            {
                using var context = _context.CreateDbContext();
                var data = context.TKThepMongCHops
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
                var data = await context.TKThepMongCHops
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

        public async Task Update(TKThepMongCHop TKThepMongCHop, string userId)
        {
            using var context = _context.CreateDbContext();
            var entity = GetById(TKThepMongCHop.Id);

            if (entity == null)
            {
                throw new Exception($"Không tìm thấy bản ghi theo ID: {TKThepMongCHop.Id}");
            }

            context.TKThepMongCHops.Update(TKThepMongCHop);
            await SaveChanges(context);
        }

        //public async Task UpdateMulti(TKThepMongCHop[] TKThepMongCHop)
        //{
        //    using var context = _context.CreateDbContext();
        //    string[] ids = TKThepMongCHop.Select(x => x.Id).ToArray();
        //    var listEntities = await context.TKThepMongCHops.Where(x => ids.Contains(x.Id)).ToListAsync();
        //    foreach (var entity in listEntities)
        //    {
        //        context.TKThepMongCHops.Update(entity);
        //    }
        //    await context.SaveChangesAsync();
        //}
        public async Task UpdateMulti(TKThepMongCHop[] tKThepMongCHopArray)
        {
            using var context = _context.CreateDbContext();

            // Lấy danh sách ID từ mảng đầu vào
            var ids = tKThepMongCHopArray.Select(x => x.Id).ToArray();

            // Lấy danh sách thực thể từ cơ sở dữ liệu
            var listEntities = await context.TKThepMongCHops
                .Where(x => ids.Contains(x.Id))
                .ToListAsync();

            // Cập nhật từng thực thể
            foreach (var entity in listEntities)
            {
                // Tìm thực thể cần cập nhật từ mảng đầu vào
                var updatedEntity = tKThepMongCHopArray.FirstOrDefault(x => x.Id == entity.Id);
                if (updatedEntity != null)
                {
                    // Cập nhật chỉ các giá trị thay đổi
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
            await context.TKThepMongCHops
                .Where(x => x.Flag > entity.Flag &&
                            x.ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop == entity.ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop)
                .ExecuteUpdateAsync(x => x
                    .SetProperty(r => r.Flag, r => r.Flag - 1)
                    .SetProperty(r => r.SoHieu, r => r.SoHieu - 1));

            // Bước 2: Xóa bản ghi
            context.TKThepMongCHops.Remove(entity);

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
        public async Task Insert(TKThepMongCHop entity, string userId)
        {
            try
            {
                using var context = _context.CreateDbContext();
                if (entity == null)
                {
                    throw new Exception("Không có bản ghi nào để thêm!");
                }

                // Lấy tất cả các bản ghi phù hợp và thực hiện xử lý trên client-side
                var maxFlagValue = await context.TKThepMongCHops
                    .Where(x => x.ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop == entity.ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop)
                    .Select(x => x.Flag)
                    .ToListAsync(); // Lấy danh sách các giá trị Flag

                // Kiểm tra nếu danh sách không có giá trị nào, trả về 0, ngược lại lấy giá trị lớn nhất
                var maxFlag = maxFlagValue.Any() ? maxFlagValue.Max() : 0;


                // Tăng giá trị Flag lên 1
                entity.Flag = maxFlag + 1;

                // Chèn bản ghi mới vào bảng
                context.TKThepMongCHops.Add(entity);
                await SaveChanges(context);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public async Task<string> InsertLaterFlag(TKThepMongCHop entity, int FlagLast, bool insertBefore)
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
                var recordsToUpdate = await context.TKThepMongCHops
                    .Where(x => (insertBefore ? x.Flag >= FlagLast : x.Flag > FlagLast)
                    && x.ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop == entity.ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop)
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
                    var maxFlag = await context.TKThepMongCHops.AnyAsync()
                                  ? await context.TKThepMongCHops.MaxAsync(x => x.Flag)
                                  : 0;

                    // Tăng giá trị Flag lên 1
                    entity.Flag = maxFlag + 1;
                }
                else
                {
                    entity.Flag = insertBefore ? FlagLast : FlagLast + 1;
                }

                // Bước 4: Chèn bản ghi mới vào bảng
                context.TKThepMongCHops.Add(entity);

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

        //cập nhật lại số liệu
        public async Task SaveChanges(ApplicationDbContext context)
        {
            try
            {
                // Xử lý các thay đổi trong DbContext
                var entries = context.ChangeTracker.Entries<TKThepMongCHop>();

                foreach (var entry in entries)
                {
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            await HandleEntityAdd(entry);
                            break;

                        case EntityState.Modified:
                            await HandleEntityUpdate(entry);
                            break;

                        case EntityState.Deleted:
                            await HandleEntityDelete(entry);
                            break;
                    }
                }

                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error while saving changes: {ex.Message}");
                throw;
            }
        }
        private async Task HandleEntityAdd(EntityEntry<TKThepMongCHop> entry)
        {
            var entity = entry.Entity;
            if (entity != null)
            {
                PKKLModel pkklModel = new PKKLModel { HangMuc = "III.Gia công, lắp dựng cốt thép móng cống hộp", TenCongTac = entity.TenCongTac ?? "", LoaiCauKienId = entity.ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop };
                List<PKKLModel> result = await _pKKLMongCHopRepository.GetAllByVM(pkklModel);
                if (result != null)
                {
                    List<PKKLMongCHop> PKKLMongCHops = new List<PKKLMongCHop>();
                    foreach (var record in result)
                    {
                        PKKLMongCHop PKKLMongCHop = new PKKLMongCHop();
                        if (!string.IsNullOrEmpty(record.TenCongTac))
                        {
                            PKKLMongCHop.Id = record.Id;
                            PKKLMongCHop.Flag = record.Flag;
                            PKKLMongCHop.ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop = record.LoaiCauKienId;
                            PKKLMongCHop.LoaiBeTong = record.LoaiBeTong;
                            PKKLMongCHop.HangMuc = record.HangMuc;
                            PKKLMongCHop.HangMucCongTac = record.HangMucCongTac;
                            PKKLMongCHop.TenCongTac = record.TenCongTac;
                            PKKLMongCHop.DonVi = record.DonVi;
                            PKKLMongCHop.KTHH_D = record.KTHH_D;
                            PKKLMongCHop.KTHH_R = record.KTHH_R;
                            PKKLMongCHop.KTHH_C = record.KTHH_C;
                            PKKLMongCHop.KTHH_DienTich = record.KTHH_DienTich;
                            PKKLMongCHop.KTHH_GhiChu = record.KTHH_GhiChu;
                            PKKLMongCHop.KTHH_SLCauKien = record.KTHH_SLCauKien;
                            PKKLMongCHop.TTCDT_CDai = record.TTCDT_CDai;
                            PKKLMongCHop.TTCDT_CRong = record.TTCDT_CRong;
                            PKKLMongCHop.TTCDT_CDay = record.TTCDT_CDay;
                            PKKLMongCHop.TTCDT_DienTich = record.TTCDT_DienTich;
                            PKKLMongCHop.TTCDT_SLCK = record.TTCDT_SLCK;
                            PKKLMongCHop.KLKP_Sl = record.KLKP_Sl;
                            PKKLMongCHop.KLCC1CK = record.KLCC1CK;
                            PKKLMongCHop.CreateAt = record.CreateAt;
                            PKKLMongCHop.CreateBy = record.CreateBy;
                            PKKLMongCHop.KLKP_KL = entity.TongTrongLuong ?? 0;

                            var SumTenCongTacByPL = await GetSumTenCongTacByPL(entity.ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop, entity.TenCongTac ?? "");
                            if (SumTenCongTacByPL != null && SumTenCongTacByPL.Value != null)
                            {
                                if (double.TryParse(SumTenCongTacByPL.Value, out double parsedValue))
                                {
                                    PKKLMongCHop.KLKP_KL = parsedValue + entity.TongTrongLuong ?? 0;
                                }

                            }
                            PKKLMongCHop.KTHH_KL1CK = _pKKLMongCHopRepository.KTHH_KL1CK(PKKLMongCHop);
                            PKKLMongCHop.TTCDT_KL = _pKKLMongCHopRepository.TTCDT_KL(PKKLMongCHop);
                            PKKLMongCHop.KL1CK_ChuaTruCC = _pKKLMongCHopRepository.KL1CK_ChuaTruCC(PKKLMongCHop);
                            PKKLMongCHop.TKLCK_SauCC = PKKLMongCHop.KL1CK_ChuaTruCC - PKKLMongCHop.KLCC1CK;
                            PKKLMongCHops.Add(PKKLMongCHop);
                        }

                    }
                    await _pKKLMongCHopRepository.UpdateMulti(PKKLMongCHops.ToArray());
                }
            }
        }
        private async Task HandleEntityDelete(EntityEntry<TKThepMongCHop> entry)
        {
            var deletedEntity = entry.Entity;
            if (deletedEntity != null)
            {
                TKThepMongCHop entity = await GetById(deletedEntity.Id);

                if (entity == null)
                {
                    throw new Exception($"Không tìm thấy bản ghi theo ID: {deletedEntity.Id}");
                }
                PKKLModel pkklModel = new PKKLModel { HangMuc = "III.Gia công, lắp dựng cốt thép móng cống hộp", TenCongTac = entity.TenCongTac ?? "", LoaiCauKienId = entity.ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop };
                List<PKKLModel> result = await _pKKLMongCHopRepository.GetAllByVM(pkklModel);
                if (result != null)
                {
                    List<PKKLMongCHop> PKKLMongCHops = new List<PKKLMongCHop>();
                    foreach (var record in result)
                    {
                        PKKLMongCHop PKKLMongCHop = new PKKLMongCHop();
                        if (!string.IsNullOrEmpty(record.TenCongTac))
                        {
                            PKKLMongCHop.Id = record.Id;
                            PKKLMongCHop.Flag = record.Flag;
                            PKKLMongCHop.ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop = record.LoaiCauKienId;
                            PKKLMongCHop.LoaiBeTong = record.LoaiBeTong;
                            PKKLMongCHop.HangMuc = record.HangMuc;
                            PKKLMongCHop.HangMucCongTac = record.HangMucCongTac;
                            PKKLMongCHop.DonVi = record.DonVi;
                            PKKLMongCHop.KTHH_D = record.KTHH_D;
                            PKKLMongCHop.KTHH_R = record.KTHH_R;
                            PKKLMongCHop.KTHH_C = record.KTHH_C;
                            PKKLMongCHop.KTHH_DienTich = record.KTHH_DienTich;
                            PKKLMongCHop.KTHH_GhiChu = record.KTHH_GhiChu;
                            PKKLMongCHop.KTHH_SLCauKien = record.KTHH_SLCauKien;
                            PKKLMongCHop.TTCDT_CDai = record.TTCDT_CDai;
                            PKKLMongCHop.TTCDT_CRong = record.TTCDT_CRong;
                            PKKLMongCHop.TTCDT_CDay = record.TTCDT_CDay;
                            PKKLMongCHop.TTCDT_DienTich = record.TTCDT_DienTich;
                            PKKLMongCHop.TTCDT_SLCK = record.TTCDT_SLCK;
                            PKKLMongCHop.KLKP_Sl = record.KLKP_Sl;
                            PKKLMongCHop.KLCC1CK = record.KLCC1CK;
                            PKKLMongCHop.CreateAt = record.CreateAt;
                            PKKLMongCHop.CreateBy = record.CreateBy;
                            PKKLMongCHop.KLKP_KL = deletedEntity.TongTrongLuong - entity.TongTrongLuong ?? 0;
                            PKKLMongCHop.TenCongTac = "";

                            var SumTenCongTacByPL = await GetSumTenCongTacByPL(entity.ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop, entity.TenCongTac ?? "");
                            if (SumTenCongTacByPL != null && SumTenCongTacByPL.Value != null)
                            {
                                if (double.TryParse(SumTenCongTacByPL.Value, out double parsedValue))
                                {
                                    PKKLMongCHop.KLKP_KL = parsedValue - deletedEntity.TongTrongLuong ?? 0;
                                    PKKLMongCHop.TenCongTac = record.TenCongTac;
                                }

                            }
                            PKKLMongCHop.KTHH_KL1CK = _pKKLMongCHopRepository.KTHH_KL1CK(PKKLMongCHop);
                            PKKLMongCHop.TTCDT_KL = _pKKLMongCHopRepository.TTCDT_KL(PKKLMongCHop);
                            PKKLMongCHop.KL1CK_ChuaTruCC = _pKKLMongCHopRepository.KL1CK_ChuaTruCC(PKKLMongCHop);
                            PKKLMongCHop.TKLCK_SauCC = PKKLMongCHop.KL1CK_ChuaTruCC - PKKLMongCHop.KLCC1CK;
                            PKKLMongCHops.Add(PKKLMongCHop);
                        }

                    }
                    await _pKKLMongCHopRepository.UpdateMulti(PKKLMongCHops.ToArray());
                }
            }
        }
        private async Task HandleEntityUpdate(EntityEntry<TKThepMongCHop> entry)
        {
            try
            {
                var modifiedEntity = entry.Entity;

                if (modifiedEntity != null)
                {
                    TKThepMongCHop entity = await GetById(modifiedEntity.Id);

                    if (entity == null)
                    {
                        throw new Exception($"Không tìm thấy bản ghi theo ID: {modifiedEntity.Id}");
                    }
                    PKKLModel pkklModel = new PKKLModel { HangMuc = "III.Gia công, lắp dựng cốt thép móng cống hộp", TenCongTac = entity.TenCongTac ?? "", LoaiCauKienId = entity.ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop };
                    List<PKKLModel> result = await _pKKLMongCHopRepository.GetAllByVM(pkklModel);
                    if (result != null)
                    {
                        List<PKKLMongCHop> PKKLMongCHops = new List<PKKLMongCHop>();
                        foreach (var record in result)
                        {
                            PKKLMongCHop PKKLMongCHop = new PKKLMongCHop();
                            if (!string.IsNullOrEmpty(record.TenCongTac))
                            {
                                PKKLMongCHop.Id = record.Id;
                                PKKLMongCHop.Flag = record.Flag;
                                PKKLMongCHop.ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop = record.LoaiCauKienId;
                                PKKLMongCHop.LoaiBeTong = record.LoaiBeTong;
                                PKKLMongCHop.HangMuc = record.HangMuc;
                                PKKLMongCHop.HangMucCongTac = record.HangMucCongTac;
                                PKKLMongCHop.TenCongTac = record.TenCongTac;
                                PKKLMongCHop.DonVi = record.DonVi;
                                PKKLMongCHop.KTHH_D = record.KTHH_D;
                                PKKLMongCHop.KTHH_R = record.KTHH_R;
                                PKKLMongCHop.KTHH_C = record.KTHH_C;
                                PKKLMongCHop.KTHH_DienTich = record.KTHH_DienTich;
                                PKKLMongCHop.KTHH_GhiChu = record.KTHH_GhiChu;
                                PKKLMongCHop.KTHH_SLCauKien = record.KTHH_SLCauKien;
                                PKKLMongCHop.TTCDT_CDai = record.TTCDT_CDai;
                                PKKLMongCHop.TTCDT_CRong = record.TTCDT_CRong;
                                PKKLMongCHop.TTCDT_CDay = record.TTCDT_CDay;
                                PKKLMongCHop.TTCDT_DienTich = record.TTCDT_DienTich;
                                PKKLMongCHop.TTCDT_SLCK = record.TTCDT_SLCK;
                                PKKLMongCHop.KLKP_Sl = record.KLKP_Sl;
                                PKKLMongCHop.KLCC1CK = record.KLCC1CK;
                                PKKLMongCHop.CreateAt = record.CreateAt;
                                PKKLMongCHop.CreateBy = record.CreateBy;
                                PKKLMongCHop.KLKP_KL = modifiedEntity.TongTrongLuong - entity.TongTrongLuong ?? 0;

                                var SumTenCongTacByPL = await GetSumTenCongTacByPL(entity.ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop, entity.TenCongTac ?? "");
                                if (SumTenCongTacByPL != null && SumTenCongTacByPL.Value != null)
                                {
                                    if (double.TryParse(SumTenCongTacByPL.Value, out double parsedValue))
                                    {
                                        PKKLMongCHop.KLKP_KL = parsedValue - entity.TongTrongLuong + modifiedEntity.TongTrongLuong ?? 0;
                                    }

                                }

                                PKKLMongCHop.KTHH_KL1CK = _pKKLMongCHopRepository.KTHH_KL1CK(PKKLMongCHop);
                                PKKLMongCHop.TTCDT_KL = _pKKLMongCHopRepository.TTCDT_KL(PKKLMongCHop);
                                PKKLMongCHop.KL1CK_ChuaTruCC = _pKKLMongCHopRepository.KL1CK_ChuaTruCC(PKKLMongCHop);
                                PKKLMongCHop.TKLCK_SauCC = PKKLMongCHop.KL1CK_ChuaTruCC - PKKLMongCHop.KLCC1CK;
                                PKKLMongCHops.Add(PKKLMongCHop);
                            }

                        }
                        await _pKKLMongCHopRepository.UpdateMulti(PKKLMongCHops.ToArray());
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
