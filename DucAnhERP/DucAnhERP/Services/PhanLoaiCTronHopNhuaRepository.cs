﻿using DucAnhERP.Data;
using DucAnhERP.Models;
using DucAnhERP.Repository;
using DucAnhERP.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace DucAnhERP.Services
{
    public class PhanLoaiCTronHopNhuaRepository : IPhanLoaiCTronHopNhuaRepository
    {
        private readonly IDbContextFactory<ApplicationDbContext> _context;

        public PhanLoaiCTronHopNhuaRepository(IDbContextFactory<ApplicationDbContext> context)
        {
            _context = context;
        }

        public async Task<List<PhanLoaiCTronHopNhua>> GetAll()
        {
            try
            {
                using var context = _context.CreateDbContext();
                var entity = await context.PhanLoaiCTronHopNhuas.ToListAsync();
                return entity;
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.Error.WriteLine($"An error occurred: {ex.Message}");
                throw; // Optionally rethrow the exception
            }
        }

        public async Task<List<PhanLoaiCTronHopNhuaModel>> GetAllByVM()
        {
            try
            {
                using var context = _context.CreateDbContext();
                var query = from pltdhg in context.PhanLoaiCTronHopNhuas
                            orderby pltdhg.CreateAt
                            select new PhanLoaiCTronHopNhuaModel
                            {
                                Id = pltdhg.Id,
                                ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai = pltdhg.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai,
                                ThongTinDuongTruyenDan_HinhThucTruyenDan = pltdhg.ThongTinDuongTruyenDan_HinhThucTruyenDan,
                                ThongTinDuongTruyenDan_LoaiTruyenDan = pltdhg.ThongTinDuongTruyenDan_LoaiTruyenDan,
                                TTCDSLCauKienDuongTruyenDan_ChieuDai01CauKien = pltdhg.TTCDSLCauKienDuongTruyenDan_ChieuDai01CauKien,
                                ThongTinCauTaoCongTron_CDayPhuBi = pltdhg.ThongTinCauTaoCongTron_CDayPhuBi,
                                TTKTHHCongHopRanh_CauTaoTuong = pltdhg.TTKTHHCongHopRanh_CauTaoTuong,
                                TTKTHHCongHopRanh_ChatMatTrong = pltdhg.TTKTHHCongHopRanh_ChatMatTrong,
                                TTKTHHCongHopRanh_ChatMatNgoai = pltdhg.TTKTHHCongHopRanh_ChatMatNgoai,
                                TTKTHHCongHopRanh_CCaoDe = pltdhg.TTKTHHCongHopRanh_CCaoDe,
                                TTKTHHCongHopRanh_CRongDe = pltdhg.TTKTHHCongHopRanh_CRongDe,
                                TTKTHHCongHopRanh_CDayTuong01Ben = pltdhg.TTKTHHCongHopRanh_CDayTuong01Ben,
                                TTKTHHCongHopRanh_SoLuongTuong = pltdhg.TTKTHHCongHopRanh_SoLuongTuong,
                                TTKTHHCongHopRanh_CRongLongSuDung = pltdhg.TTKTHHCongHopRanh_CRongLongSuDung,
                                TTKTHHCongHopRanh_CCaoTuongGop = pltdhg.TTKTHHCongHopRanh_CCaoTuongGop,
                                TTKTHHCongHopRanh_CCaoMuMoThotDuoi = pltdhg.TTKTHHCongHopRanh_CCaoMuMoThotDuoi,
                                TTKTHHCongHopRanh_CRongMuMoDuoi = pltdhg.TTKTHHCongHopRanh_CRongMuMoDuoi,
                                TTKTHHCongHopRanh_CCaoMuMoThotTren = pltdhg.TTKTHHCongHopRanh_CCaoMuMoThotTren,
                                TTKTHHCongHopRanh_CRongMuMoTren = pltdhg.TTKTHHCongHopRanh_CRongMuMoTren,
                                TTKTHHCongHopRanh_CCaoChatMatTrong = pltdhg.TTKTHHCongHopRanh_CCaoChatMatTrong,
                                ThongTinKichThuocHinhHocOngNhua_CDayPhuBi = pltdhg.ThongTinKichThuocHinhHocOngNhua_CDayPhuBi,
                                CreateAt = pltdhg.CreateAt,
                                CreateBy = pltdhg.CreateBy,
                                IsActive = pltdhg.IsActive,

                            };

                var data = await query
                    .ToListAsync();
                return data;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }

        }
        public async Task<bool> CheckUsingId(string id)
        {
            bool isSuccess = false;
            using var context = _context.CreateDbContext();
            var query = context.DSHopRanhThang
                         .Where(hrt => (hrt.ThongTinChungHoGa_TenHoGaSauPhanLoai == id));

            var data = await query.ToListAsync();

            // Kiểm tra nếu danh sách kết quả rỗng hoặc không có dữ liệu khớp
            isSuccess = data.Any();
            return (isSuccess);
        }

        public async Task<PhanLoaiCTronHopNhua> GetMPhanLoaiCTronHopNhuaByDetail(PhanLoaiCTronHopNhua searchData)
        {
            try
            {
                using var context = _context.CreateDbContext();

                // Thực hiện lọc dữ liệu dựa trên các thuộc tính của searchData
                var query = context.PhanLoaiCTronHopNhuas
                             .Where(pltdhg => (
                                 pltdhg.ThongTinDuongTruyenDan_HinhThucTruyenDan == searchData.ThongTinDuongTruyenDan_HinhThucTruyenDan &&
                                 pltdhg.ThongTinDuongTruyenDan_LoaiTruyenDan == searchData.ThongTinDuongTruyenDan_LoaiTruyenDan &&
                                 pltdhg.TTCDSLCauKienDuongTruyenDan_ChieuDai01CauKien == searchData.TTCDSLCauKienDuongTruyenDan_ChieuDai01CauKien &&
                                 pltdhg.ThongTinCauTaoCongTron_CDayPhuBi == searchData.ThongTinCauTaoCongTron_CDayPhuBi &&
                                 pltdhg.TTKTHHCongHopRanh_CauTaoTuong == searchData.TTKTHHCongHopRanh_CauTaoTuong &&
                                 pltdhg.TTKTHHCongHopRanh_ChatMatTrong == searchData.TTKTHHCongHopRanh_ChatMatTrong &&
                                 pltdhg.TTKTHHCongHopRanh_ChatMatNgoai == searchData.TTKTHHCongHopRanh_ChatMatNgoai &&
                                 pltdhg.TTKTHHCongHopRanh_CCaoDe == searchData.TTKTHHCongHopRanh_CCaoDe &&
                                 pltdhg.TTKTHHCongHopRanh_CRongDe == searchData.TTKTHHCongHopRanh_CRongDe &&
                                 pltdhg.TTKTHHCongHopRanh_CDayTuong01Ben == searchData.TTKTHHCongHopRanh_CDayTuong01Ben &&
                                 pltdhg.TTKTHHCongHopRanh_SoLuongTuong == searchData.TTKTHHCongHopRanh_SoLuongTuong &&
                                 pltdhg.TTKTHHCongHopRanh_CRongLongSuDung == searchData.TTKTHHCongHopRanh_CRongLongSuDung &&
                                 pltdhg.TTKTHHCongHopRanh_CCaoTuongGop == searchData.TTKTHHCongHopRanh_CCaoTuongGop &&
                                 pltdhg.TTKTHHCongHopRanh_CCaoMuMoThotDuoi == searchData.TTKTHHCongHopRanh_CCaoMuMoThotDuoi &&
                                 pltdhg.TTKTHHCongHopRanh_CRongMuMoDuoi == searchData.TTKTHHCongHopRanh_CRongMuMoDuoi &&
                                 pltdhg.TTKTHHCongHopRanh_CCaoMuMoThotTren == searchData.TTKTHHCongHopRanh_CCaoMuMoThotTren &&
                                 pltdhg.TTKTHHCongHopRanh_CRongMuMoTren == searchData.TTKTHHCongHopRanh_CRongMuMoTren &&
                                 pltdhg.TTKTHHCongHopRanh_CCaoChatMatTrong == searchData.TTKTHHCongHopRanh_CCaoChatMatTrong &&
                                 pltdhg.ThongTinKichThuocHinhHocOngNhua_CDayPhuBi == searchData.ThongTinKichThuocHinhHocOngNhua_CDayPhuBi
                                          ));

                var result = await query.FirstOrDefaultAsync();
                return result;
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.Error.WriteLine($"An error occurred: {ex.Message}");
                throw; // Optionally rethrow the exception
            }
        }

        public async Task Update(PhanLoaiCTronHopNhua PhanLoaiCTronHopNhua)
        {
            using var context = _context.CreateDbContext();
            var entity = GetById(PhanLoaiCTronHopNhua.Id);

            if (entity == null)
            {
                throw new Exception($"Không tìm thấy bản ghi theo ID: {PhanLoaiCTronHopNhua.Id}");
            }

            context.PhanLoaiCTronHopNhuas.Update(PhanLoaiCTronHopNhua);
            await context.SaveChangesAsync();
        }

        public async Task UpdateMulti(PhanLoaiCTronHopNhua[] PhanLoaiCTronHopNhua)
        {
            using var context = _context.CreateDbContext();
            string[] ids = PhanLoaiCTronHopNhua.Select(x => x.Id).ToArray();
            var listEntities = await context.PhanLoaiCTronHopNhuas.Where(x => ids.Contains(x.Id)).ToListAsync();
            foreach (var entity in listEntities)
            {
                context.PhanLoaiCTronHopNhuas.Update(entity);
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

            context.Set<PhanLoaiCTronHopNhua>().Remove(entity);
            await context.SaveChangesAsync();
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

        public async Task<PhanLoaiCTronHopNhua> GetById(string id)
        {
            using var context = _context.CreateDbContext();
            var entity = await context.PhanLoaiCTronHopNhuas.Where(x => x.Id.Equals(id)).FirstOrDefaultAsync();

            if (entity == null)
            {
                throw new Exception($"Không tìm thấy bản ghi theo ID: {id}");
            }

            return entity;
        }

        public async Task Insert(PhanLoaiCTronHopNhua entity)
        {
            try
            {
                using var context = _context.CreateDbContext();
                if (entity == null)
                {
                    throw new Exception("Không có bản ghi nào để thêm!");
                }

                // Kiểm tra xem bảng có bản ghi nào không
                var maxFlag = await context.PhanLoaiCTronHopNhuas.AnyAsync()
                              ? await context.PhanLoaiCTronHopNhuas.MaxAsync(x => x.Flag)
                              : 0;

                // Tăng giá trị Flag lên 1
                entity.Flag = maxFlag + 1;
                entity.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai = " loại " + entity.Flag;

                // Chèn bản ghi mới vào bảng
                context.PhanLoaiCTronHopNhuas.Add(entity);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public async Task<string> InsertId(PhanLoaiCTronHopNhua entity, string HinhThucTD, string LoaiTD)
        {
            try
            {
                using var context = _context.CreateDbContext();

                if (entity == null)
                {
                    throw new Exception("Không có bản ghi nào để thêm!");
                }

                // Kiểm tra xem bảng có bản ghi nào không
                var maxFlag = await context.PhanLoaiCTronHopNhuas.AnyAsync()
                              ? await context.PhanLoaiCTronHopNhuas.MaxAsync(x => x.Flag)
                              : 0;

                // Tăng giá trị Flag lên 1
                entity.Flag = maxFlag + 1;
                entity.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai = HinhThucTD +" "+ LoaiTD + " loại " + entity.Flag;

                // Chèn bản ghi mới vào bảng
                context.PhanLoaiCTronHopNhuas.Add(entity);
                await context.SaveChangesAsync();

                // Trả về Id của bản ghi vừa chèn
                return entity.Id;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw; // Đảm bảo exception được ném ra ngoài nếu cần thiết
            }
        }
    }
}