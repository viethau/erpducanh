﻿using DucAnhERP.Data;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using DucAnhERP.Models.NghiepVuCongTrinh;
using DucAnhERP.ViewModel.NghiepVuCongTrinh;
using DucAnhERP.Repository.NghiepVuCongTrinh;

namespace DucAnhERP.Services.NghiepVuCongTrinh
{
    public class PKKLRXayRepository : IPKKLRXayRepository
    {
        private readonly IDbContextFactory<ApplicationDbContext> _context;
        public PKKLRXayRepository(IDbContextFactory<ApplicationDbContext> context)
        {
            _context = context;
        }
        public async Task<bool> CheckStatus(string ids, string name)
        {
            return true;
        }

        public async Task<List<PKKLRXay>> GetAll(string groupId)
        {
            try
            {
                using var context = _context.CreateDbContext();
                var entity = await context.PKKLRXays.ToListAsync();
                return entity;
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.Error.WriteLine($"An error occurred: {ex.Message}");
                throw; // Optionally rethrow the exception
            }
        }
        public async Task<PKKLRXay> GetById(string id)
        {
            using var context = _context.CreateDbContext();
            var entity = await context.PKKLRXays.Where(x => x.Id.Equals(id)).FirstOrDefaultAsync();

            if (entity == null)
            {
                throw new Exception($"Không tìm thấy bản ghi theo ID: {id}");
            }

            return entity;
        }
        public async Task<List<PKKLModel>> GetAllByVM(PKKLModel mModel)
        {
            try
            {
                using var context = _context.CreateDbContext();
                List<PKKLModel> data = new();
                var query = from a in context.PKKLRXays
                            join b in context.PhanLoaiCTronHopNhuas
                            on a.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai equals b.Id
                            orderby b.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai ascending, a.HangMuc ascending, a.Flag descending, a.CreateAt ascending
                            select new PKKLModel
                            {
                                Id = a.Id,
                                Flag = a.Flag,
                                LoaiCauKien = b.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai,
                                LoaiCauKienId = a.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai,
                                LoaiBeTong = a.LoaiBeTong,
                                HangMuc = a.HangMuc,
                                HangMucCongTac = a.HangMucCongTac,
                                TenCongTac = a.TenCongTac,
                                DonVi = a.DonVi,
                                KTHH_D = a.KTHH_D,
                                KTHH_R = a.KTHH_R,
                                KTHH_C = a.KTHH_C,
                                KTHH_DienTich = a.KTHH_DienTich,
                                KTHH_GhiChu = a.KTHH_GhiChu,
                                KTHH_SLCauKien = a.KTHH_SLCauKien,
                                KTHH_KL1CK = a.KTHH_KL1CK,
                                TTCDT_CDai = a.TTCDT_CDai,
                                TTCDT_CRong = a.TTCDT_CRong,
                                TTCDT_CDay = a.TTCDT_CDay,
                                TTCDT_DienTich = a.TTCDT_DienTich,
                                TTCDT_SLCK = a.TTCDT_SLCK,
                                TTCDT_KL = a.TTCDT_KL,
                                KLKP_Sl = a.KLKP_Sl,
                                KLKP_KL = a.KLKP_KL,
                                KL1CK_ChuaTruCC = a.KL1CK_ChuaTruCC,
                                KLCC1CK = a.KLCC1CK,
                                TKLCK_SauCC = a.TKLCK_SauCC
                            };

                if (!string.IsNullOrEmpty(mModel.HangMuc))
                {
                    query = query.Where(x => x.HangMuc == mModel.HangMuc);
                }
                if (!string.IsNullOrEmpty(mModel.TenCongTac))
                {
                    query = query.Where(x => x.TenCongTac == mModel.TenCongTac);
                }
                if (!string.IsNullOrEmpty(mModel.LoaiCauKienId))
                {
                    query = query.Where(x => x.LoaiCauKienId == mModel.LoaiCauKienId);
                }

                data = await query.ToListAsync();

                return data;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }

        }
        public async Task<List<THKLModel>> GetTHKLRanhXay()
        {
            try
            {
                using var context = _context.CreateDbContext();
                var query = (from a in context.PKKLRXays
                             join b in context.PhanLoaiCTronHopNhuas
                             on a.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai equals b.Id
                             let kl1Dv = context.PKKLRXays
                                 .Where(x => x.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai == a.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai
                                          && x.LoaiBeTong == a.LoaiBeTong
                                          && x.HangMuc == a.HangMuc
                                          && x.HangMucCongTac == a.HangMucCongTac
                                          && x.TenCongTac == a.TenCongTac)
                                 .Sum(x => x.TKLCK_SauCC)
                             orderby b.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai, a.HangMuc
                             select new THKLModel
                             {
                                 Flag = a.Flag,
                                 HangMuc = a.HangMuc,
                                 PhanLoaiCTronHopNhua_TenLoaiTruyenDanSauPhanLoai = b.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai,
                                 ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai = a.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai,
                                 HangMucCongTac = a.HangMucCongTac,
                                 TenCongTac = a.TenCongTac,
                                 DonVi = a.DonVi,
                                 KL1DonVi = Math.Round(kl1Dv, 4),

                             }).ToList();

                var newList = query.GroupBy(item => item.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai)
                    .SelectMany(group => group.GroupBy(item => item.HangMuc)
                    .SelectMany(groupChild => groupChild.OrderBy(item => item.Flag)
                    .Select((item, index) => {
                        return item;
                    }))).ToList();

                var result = newList
                .GroupBy(item => new
                {
                    item.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai,
                    item.TenCongTac,
                    item.DonVi,
                    item.HangMuc
                })
                .Select(group => group.First())
                .ToList();
                return result;
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.Error.WriteLine($"An error occurred: {ex.Message}");
                throw; // Optionally rethrow the exception
            }

        }
        public async Task<List<THKLModel>> GetTHKLByTuyenDuong(string TuyenDuong)
        {
            try
            {
                using var context = _context.CreateDbContext();
                var query = (from a in context.PKKLRXays
                             join b in context.PhanLoaiCTronHopNhuas on a.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai equals b.Id
                             join c in context.DSNuocMua on a.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai
                             equals c.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai into cGroup
                             from c in cGroup.DefaultIfEmpty()
                             where c.ThongTinLyTrinh_TuyenDuong == TuyenDuong
                             group new { a, c } by new
                             {
                                 a.Id,
                                 b.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai,
                                 PhanLoaiCTronHopNhua_TenLoaiTruyenDanSauPhanLoai = b.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai,
                                 a.TenCongTac,
                                 a.DonVi,
                                 a.TKLCK_SauCC,
                                 a.HangMuc,
                                 a.Flag
                             } into g
                             orderby g.Key.PhanLoaiCTronHopNhua_TenLoaiTruyenDanSauPhanLoai, g.Key.HangMuc, g.Key.Flag
                             select new THKLModel
                             {
                                 Id = g.Key.Id,
                                 ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai = g.Key.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai,
                                 PhanLoaiCTronHopNhua_TenLoaiTruyenDanSauPhanLoai = g.Key.PhanLoaiCTronHopNhua_TenLoaiTruyenDanSauPhanLoai,
                                 TenCongTac = g.Key.TenCongTac,
                                 DonVi = g.Key.DonVi,
                                 KL1DonVi = g.Key.TKLCK_SauCC,
                                 SLTrai = g.Sum(x => x.c != null && x.c.TraiPhai == 0 ? x.c.TTCDSLCauKienDuongTruyenDan_TongChieuDai : 0) ?? 0,
                                 SLPhai = g.Sum(x => x.c != null && x.c.TraiPhai == 1 ? x.c.TTCDSLCauKienDuongTruyenDan_TongChieuDai : 0) ?? 0,
                                 SLTong = g.Sum(x => x.c != null && (x.c.TraiPhai == 0 || x.c.TraiPhai == 1) ? x.c.TTCDSLCauKienDuongTruyenDan_TongChieuDai : 0) ?? 0,
                                 KLTrai = g.Sum(x => x.c != null && x.c.TraiPhai == 0 ? x.c.TTCDSLCauKienDuongTruyenDan_TongChieuDai : 0) * g.Key.TKLCK_SauCC ?? 0,
                                 KLPhai = g.Sum(x => x.c != null && x.c.TraiPhai == 1 ? x.c.TTCDSLCauKienDuongTruyenDan_TongChieuDai : 0) * g.Key.TKLCK_SauCC ?? 0,
                                 KLTong = g.Sum(x => x.c != null && (x.c.TraiPhai == 0 || x.c.TraiPhai == 1) ? x.c.TTCDSLCauKienDuongTruyenDan_TongChieuDai : 0) * g.Key.TKLCK_SauCC ?? 0
                             }).ToList();
                return query;
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.Error.WriteLine($"An error occurred: {ex.Message}");
                throw; // Optionally rethrow the exception
            }

        }
        public async Task<List<THKLModel>> GetTHKLByTuyenDuong(List<NuocMuaModel> nuocMua)
        {
            try
            {
                using var context = _context.CreateDbContext();

                // Khởi tạo một danh sách để lưu kết quả
                List<THKLModel> finalResult = new List<THKLModel>();

                // Duyệt qua từng tuyến đường trong danh sách `nuocMua`
                foreach (var item in nuocMua)
                {

                    var query = await (from a in context.PKKLRXays
                                       join b in context.PhanLoaiCTronHopNhuas
                                           on a.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai equals b.Id
                                       join c in context.DSNuocMua
                                           on a.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai equals c.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai into cGroup
                                       from c in cGroup.Where(c => c.ThongTinLyTrinh_TuyenDuong == item.ThongTinLyTrinh_TuyenDuong).DefaultIfEmpty()

                                       group new { a, b, c } by new
                                       {
                                           a.Id,
                                           a.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai,
                                           PhanLoaiCTronHopNhua_TenLoaiTruyenDanSauPhanLoai = b.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai ?? "",
                                           a.TenCongTac,
                                           a.DonVi,
                                           a.TKLCK_SauCC,
                                           a.HangMuc,
                                           a.Flag
                                       } into g
                                       orderby g.Key.PhanLoaiCTronHopNhua_TenLoaiTruyenDanSauPhanLoai, g.Key.HangMuc, g.Key.Flag
                                       select new THKLModel
                                       {
                                           Id = g.Key.Id,
                                           Flag = g.Key.Flag,
                                           HangMuc = g.Key.HangMuc,
                                           ThongTinLyTrinh_TuyenDuong = item.ThongTinLyTrinh_TuyenDuong,  // Thông tin cố định từ SQL
                                           ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai = g.Key.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai,
                                           PhanLoaiCTronHopNhua_TenLoaiTruyenDanSauPhanLoai = g.Key.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai, // Cố định tên loại từ SQL
                                           TenCongTac = g.Key.TenCongTac,
                                           DonVi = g.Key.DonVi,
                                           KL1DonVi = g.Key.TKLCK_SauCC,
                                           SLTrai = g.Sum(x => x.c != null && x.c.TraiPhai == 0 ? x.c.TTCDSLCauKienDuongTruyenDan_TongChieuDai : 0) ?? 0,
                                           SLPhai = g.Sum(x => x.c != null && x.c.TraiPhai == 1 ? x.c.TTCDSLCauKienDuongTruyenDan_TongChieuDai : 0) ?? 0,
                                           SLTong = g.Sum(x => x.c != null ? x.c.TTCDSLCauKienDuongTruyenDan_TongChieuDai : 0) ?? 0,
                                           KLTrai = g.Sum(x => x.c != null && x.c.TraiPhai == 0 ? x.c.TTCDSLCauKienDuongTruyenDan_TongChieuDai : 0) * g.Key.TKLCK_SauCC ?? 0,
                                           KLPhai = g.Sum(x => x.c != null && x.c.TraiPhai == 1 ? x.c.TTCDSLCauKienDuongTruyenDan_TongChieuDai : 0) * g.Key.TKLCK_SauCC ?? 0,
                                           KLTong = g.Sum(x => x.c != null ? x.c.TTCDSLCauKienDuongTruyenDan_TongChieuDai : 0) * g.Key.TKLCK_SauCC ?? 0
                                       }).ToListAsync();


                    var newList = query.GroupBy(item => item.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai)
                   .SelectMany(group => group.GroupBy(item => item.HangMuc)
                   .SelectMany(groupChild => groupChild.OrderBy(item => item.Flag)
                   .Select((item, index) => {
                       return item;
                   }))).ToList();

                    var newList1 = newList
                    .GroupBy(item => new
                    {
                        item.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai,
                        item.TenCongTac,
                        item.DonVi,
                        item.HangMuc
                    })
                    .Select(group => group.First())
                    .ToList();
                    // Thêm kết quả của truy vấn vào danh sách `finalResult`
                    finalResult.AddRange(newList1);
                }

                // Trả về danh sách kết quả cuối cùng
                return finalResult;
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.Error.WriteLine($"An error occurred: {ex.Message}");
                throw; // Optionally rethrow the exception
            }
        }
        public async Task<PKKLRXay> GetTKLCK_SauCCByLCK(string id)
        {
            using var context = _context.CreateDbContext();
            var result = context.PKKLRXays.
                Where(x => new[] { "I.Móng", "II.Tường", "III.Mũ mố" }.Contains(x.HangMuc) &&
                x.LoaiBeTong == "Bê tông thương phẩm" &&
                x.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai == id).OrderBy(a => a.CreateAt).FirstOrDefault();

            return result;
        }
        public async Task<double> GetSumTKLCK_SauCCByLCK(string id)
        {
            using var context = _context.CreateDbContext();
            var result = context.PKKLRXays
                .Where(x => new[] { "I.Móng", "II.Tường", "III.Mũ mố" }.Contains(x.HangMuc) &&
                x.LoaiBeTong == "Bê tông thương phẩm" &&
                x.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai == id)
                 .Sum(x => x.TKLCK_SauCC);

            return result;
        }
        public async Task<List<PKKLRXay>> GetExist(PKKLRXay searchData)
        {
            try
            {
                using var context = _context.CreateDbContext();

                // Thực hiện lọc dữ liệu dựa trên các thuộc tính của searchData
                var query = context.PKKLRXays
                             .Where(item => 
                                    item.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai == searchData.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai &&
                                    item.LoaiBeTong == searchData.LoaiBeTong &&
                                    item.HangMuc == searchData.HangMuc &&
                                    item.HangMucCongTac == searchData.HangMucCongTac &&
                                    item.TenCongTac == searchData.TenCongTac &&
                                    item.DonVi == searchData.DonVi &&
                                    item.KTHH_D == searchData.KTHH_D &&
                                    item.KTHH_R == searchData.KTHH_R &&
                                    item.KTHH_C == searchData.KTHH_C &&
                                    item.KTHH_DienTich == searchData.KTHH_DienTich &&
                                    item.KTHH_GhiChu == searchData.KTHH_GhiChu &&
                                    item.KTHH_SLCauKien == searchData.KTHH_SLCauKien &&
                                    item.KTHH_KL1CK == searchData.KTHH_KL1CK &&
                                    item.TTCDT_CDai == searchData.TTCDT_CDai &&
                                    item.TTCDT_CRong == searchData.TTCDT_CRong &&
                                    item.TTCDT_CDay == searchData.TTCDT_CDay &&
                                    item.TTCDT_DienTich == searchData.TTCDT_DienTich &&
                                    item.TTCDT_SLCK == searchData.TTCDT_SLCK &&
                                    item.TTCDT_KL == searchData.TTCDT_KL &&
                                    item.KLKP_KL == searchData.KLKP_KL &&
                                    item.KLKP_Sl == searchData.KLKP_Sl &&
                                    item.KL1CK_ChuaTruCC == searchData.KL1CK_ChuaTruCC &&
                                    item.KLCC1CK == searchData.KLCC1CK &&
                                    item.TKLCK_SauCC == searchData.TKLCK_SauCC
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
        public async Task Update(PKKLRXay TKThepDeCong,string userId)
        {
            using var context = _context.CreateDbContext();
            var entity = GetById(TKThepDeCong.Id);

            if (entity == null)
            {
                throw new Exception($"Không tìm thấy bản ghi theo ID: {TKThepDeCong.Id}");
            }

            context.PKKLRXays.Update(TKThepDeCong);
            await SaveChanges(context);
        }
        public async Task UpdateMulti(PKKLRXay[] PKKLRXay)
        {
            try
            {
                using var context = _context.CreateDbContext();

                string[] ids = PKKLRXay.Select(x => x.Id).ToArray();

                // Lấy danh sách các bản ghi từ database có ID nằm trong danh sách ids
                var listEntities = await context.PKKLRXays
                    .Where(x => ids.Contains(x.Id))
                    .ToListAsync();
                foreach (var entity in listEntities)
                {
                    var updatedEntity = PKKLRXay.FirstOrDefault(x => x.Id == entity.Id);
                    if (updatedEntity != null)
                    {
                        context.Entry(entity).CurrentValues.SetValues(updatedEntity);
                    }
                }

                // Lưu các thay đổi vào database
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        public async Task DeleteById(string id,string userId)
        {
            using var context = _context.CreateDbContext();
            var entity = await GetById(id);

            if (entity == null)
            {
                throw new Exception($"Không tìm thấy bản ghi theo ID: {id}");
            }

            context.Set<PKKLRXay>().Remove(entity);
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
        public async Task Insert(PKKLRXay entity, string userId)
        {
            try
            {
                using var context = _context.CreateDbContext();
                if (entity == null)
                {
                    throw new Exception("Không có bản ghi nào để thêm!");
                }

                // Lấy tất cả các bản ghi phù hợp và thực hiện xử lý trên client-side
                var maxFlagValue = await context.PKKLRXays
                    .Where(x => x.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai == entity.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai && x.HangMuc == entity.HangMuc)
                    .Select(x => x.Flag)
                    .ToListAsync(); // Lấy danh sách các giá trị Flag

                // Kiểm tra nếu danh sách không có giá trị nào, trả về 0, ngược lại lấy giá trị lớn nhất
                var maxFlag = maxFlagValue.Any() ? maxFlagValue.Max() : 0;


                // Tăng giá trị Flag lên 1
                entity.Flag = maxFlag + 1;

                // Chèn bản ghi mới vào bảng
                context.PKKLRXays.Add(entity);
                await SaveChanges(context);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public async Task<string> InsertLaterFlag(PKKLRXay entity, int FlagLast, bool insertBefore)
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
                var recordsToUpdate = await context.PKKLRXays
                    .Where(x => (insertBefore ? x.Flag >= FlagLast : x.Flag > FlagLast)
                    && x.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai == entity.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai 
                    && x.HangMuc == entity.HangMuc)
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
                    var maxFlag = await context.PKKLRXays.AnyAsync()
                                  ? await context.PKKLRXays.MaxAsync(x => x.Flag)
                                  : 0;
                    // Tăng giá trị Flag lên 1
                    entity.Flag = maxFlag + 1;
                }
                else
                {
                    entity.Flag = insertBefore ? FlagLast : FlagLast + 1;
                }

                // Bước 4: Chèn bản ghi mới vào bảng
                context.PKKLRXays.Add(entity);

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
                var entries = context.ChangeTracker.Entries<PKKLRXay>();

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
        // Xử lý khi thêm mới entity
        private async Task HandleEntityAdd(EntityEntry<PKKLRXay> entry)
        {
            var entity = entry.Entity;
           
            if (entity != null)
            {
                // Kiểm tra điều kiện HangMuc và PhanLoaiMongCongTronCongHop
                if (entity.HangMuc == "I.Móng" && entity.LoaiBeTong == "Bê tông thương phẩm")
                {
                    using var context = _context.CreateDbContext();

                    var recordsToUpdate1 = await context.PKKLRXays
                        .Where(x => x.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai == entity.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai
                        && x.HangMuc == "IV.Sản xuất + V.Chuyển B.Tông T.Phẩm" && x.LoaiBeTong == "Bê tông thương phẩm")
                        .ToListAsync();

                    // Cập nhật các cột TKLCK_SauCC cho từng bản ghi
                    foreach (var record in recordsToUpdate1)
                    {
                        if (!string.IsNullOrEmpty(record.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai))
                        {
                            var TKLCK_SauCC1 = await GetSumTKLCK_SauCCByLCK(record.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai);
                            record.TKLCK_SauCC = Math.Round(TKLCK_SauCC1 + entity.TKLCK_SauCC, 4);
                        }
                    }

                    // Gọi phương thức UpdateMulti để cập nhật nhiều bản ghi
                    await UpdateMulti(recordsToUpdate1.ToArray());

                }
            }
        }
        // Xử lý khi sửa entity
        private async Task HandleEntityUpdate(EntityEntry<PKKLRXay> entry)
        {
            var entity = entry.Entity;
            if (entity != null)
            {
                // Kiểm tra điều kiện HangMuc và PhanLoaiMongCongTronCongHop
                if (entity.HangMuc == "I.Móng")
                {
                    using var context = _context.CreateDbContext();
                    
                    var recordsToUpdate1 = await context.PKKLRXays
                        .Where(x => x.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai == entity.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai
                        && x.HangMuc == "IV.Sản xuất + V.Chuyển B.Tông T.Phẩm" && x.LoaiBeTong == "Bê tông thương phẩm")
                        .ToListAsync();

                    // Cập nhật các cột TKLCK_SauCC cho từng bản ghi
                    foreach (var record in recordsToUpdate1)
                    {
                        if (!string.IsNullOrEmpty(record.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai))
                        {
                            var getOld = await GetById(entity.Id);
                          

                            if (getOld.LoaiBeTong == "Bê tông thương phẩm")
                            {
                                if (entity.LoaiBeTong == "Bê tông thương phẩm")
                                {
                                    var TKLCK_SauCC1 = await GetSumTKLCK_SauCCByLCK(entity.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai);
                                    record.TKLCK_SauCC = Math.Round(TKLCK_SauCC1 - getOld.TKLCK_SauCC + entity.TKLCK_SauCC, 4);
                                }
                                else
                                {
                                    var TKLCK_SauCC1 = await GetSumTKLCK_SauCCByLCK(entity.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai);
                                    record.TKLCK_SauCC = Math.Round(TKLCK_SauCC1 - getOld.TKLCK_SauCC, 4);
                                }
                            }
                            else
                            {
                                if (entity.LoaiBeTong == "Bê tông thương phẩm")
                                {
                                    var TKLCK_SauCC1 = await GetSumTKLCK_SauCCByLCK(entity.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai);
                                    record.TKLCK_SauCC = Math.Round(TKLCK_SauCC1 + entity.TKLCK_SauCC, 4);
                                }

                            }
                        }
                    }

                    // Gọi phương thức UpdateMulti để cập nhật nhiều bản ghi
                    await UpdateMulti(recordsToUpdate1.ToArray());

                }
            }
        }

        // Xử lý khi xóa entity
        private async Task HandleEntityDelete(EntityEntry<PKKLRXay> entry)
        {
            var entity = entry.Entity;
            if (entity != null)
            {
                // Kiểm tra điều kiện HangMuc và PhanLoaiMongCongTronCongHop
                if (entity.HangMuc == "I.Móng" && entity.LoaiBeTong == "Bê tông thương phẩm")
                {
                    using var context = _context.CreateDbContext();

                    var recordsToUpdate1 = await context.PKKLRXays
                        .Where(x => x.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai == entity.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai
                        && x.HangMuc == "IV.Sản xuất + V.Chuyển B.Tông T.Phẩm" && x.LoaiBeTong == "Bê tông thương phẩm")
                        .ToListAsync();

                    // Cập nhật các cột TKLCK_SauCC cho từng bản ghi
                    foreach (var record in recordsToUpdate1)
                    {
                        if (!string.IsNullOrEmpty(record.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai))
                        {
                            var TKLCK_SauCC1 = await GetSumTKLCK_SauCCByLCK(record.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai);
                            record.TKLCK_SauCC = Math.Round(TKLCK_SauCC1 - entity.TKLCK_SauCC, 4);
                        }
                    }

                    // Gọi phương thức UpdateMulti để cập nhật nhiều bản ghi
                    await UpdateMulti(recordsToUpdate1.ToArray());

                }
            }
        }

        //tính toán
        private void UpdateRecordWithCalculations(PKKLRXay record, double tklckSauCc)
        {
            record.KTHH_KL1CK = KTHH_KL1CK(record);
            record.TTCDT_KL = TTCDT_KL(record);
            record.KLKP_KL = Math.Round(tklckSauCc * 2.4, 4);
            record.KL1CK_ChuaTruCC = KL1CK_ChuaTruCC(record);
            record.TKLCK_SauCC = Math.Round(record.KL1CK_ChuaTruCC - record.KLCC1CK, 4);
        }
        public double KTHH_KL1CK(PKKLRXay obj)
        {
            double result = 0;
            if (obj.DonVi == "M3")
            {
                if (string.IsNullOrEmpty(obj.KTHH_GhiChu) || obj.KTHH_GhiChu == "0")
                {
                    result = obj.KTHH_D * obj.KTHH_R * obj.KTHH_C;
                }
                else if (obj.KTHH_GhiChu == "Rộng*Cao")
                {
                    result = obj.KTHH_DienTich * obj.KTHH_D;
                }
                else if (obj.KTHH_GhiChu == "Dài*Cao")
                {
                    result = obj.KTHH_DienTich * obj.KTHH_R;
                }
                else if (obj.KTHH_GhiChu == "Dài*Rộng")
                {
                    result = obj.KTHH_DienTich * obj.KTHH_C;
                }

            }
            return Math.Round(result, 4);
        }
        public double TTCDT_KL(PKKLRXay obj)
        {
            double result = 0;
            if (obj.DonVi.ToUpper().Trim() == "M2")
            {
                if (string.IsNullOrEmpty(obj.TTCDT_DienTich.ToString()) || obj.TTCDT_DienTich == 0)
                {
                    result = obj.KTHH_D * obj.KTHH_C * obj.TTCDT_CDai + obj.KTHH_R * obj.KTHH_C * obj.TTCDT_CRong + obj.KTHH_D * obj.KTHH_R * obj.TTCDT_CDay;
                }
                else
                {
                    result = obj.TTCDT_DienTich;
                }
            }
            return Math.Round(result, 4);
        }
        public double KL1CK_ChuaTruCC(PKKLRXay obj)
        {
            double result = 0;
            if (obj.KTHH_KL1CK > 0)
            {
                result = obj.KTHH_KL1CK * obj.KTHH_SLCauKien;
            }
            else if (obj.TTCDT_KL > 0)
            {
                result = obj.TTCDT_KL * obj.TTCDT_SLCK;
            }
            else
            {
                result = obj.KLKP_KL * obj.KLKP_Sl;
            }
            return Math.Round(result, 4);
        }

    }
}
