﻿using DucAnhERP.Data;
using DucAnhERP.Models;
using DucAnhERP.Repository;
using DucAnhERP.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace DucAnhERP.Services
{

    public class PhanLoaiMongCTronRepository : IPhanLoaiMongCTronRepository
    {
        private readonly IDbContextFactory<ApplicationDbContext> _context;

        public PhanLoaiMongCTronRepository(IDbContextFactory<ApplicationDbContext> context)
        {
            _context = context;
        }

        public async Task<List<PhanLoaiMongCTron>> GetAll()
        {
            try
            {
                using var context = _context.CreateDbContext();
                var entity = await context.PhanLoaiMongCTrons.ToListAsync();
                return entity;
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.Error.WriteLine($"An error occurred: {ex.Message}");
                throw; // Optionally rethrow the exception
            }
        }

        public async Task<List<PhanLoaiMongCongModel>> GetAllByVM()
        {
            try
            {
                using var context = _context.CreateDbContext();
                var query = from plmc in context.PhanLoaiMongCTrons
                            orderby plmc.CreateAt
                            select new PhanLoaiMongCongModel
                            {
                                Id = plmc.Id,
                                Flag = plmc.Flag,
                                ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop = plmc.ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop,
                                ThongTinDuongTruyenDan_HinhThucTruyenDan = plmc.ThongTinDuongTruyenDan_HinhThucTruyenDan,
                                ThongTinDuongTruyenDan_LoaiTruyenDan = plmc.ThongTinDuongTruyenDan_LoaiTruyenDan,
                                ThongTinMongDuongTruyenDan_LoaiMong = plmc.ThongTinMongDuongTruyenDan_LoaiMong,
                                ThongTinMongDuongTruyenDan_HinhThucMong = plmc.ThongTinMongDuongTruyenDan_HinhThucMong,
                                ThongTinCauTaoCongTron_CCaoLotMong = plmc.ThongTinCauTaoCongTron_CCaoLotMong,
                                ThongTinCauTaoCongTron_CRongLotMong = plmc.ThongTinCauTaoCongTron_CRongLotMong,
                                ThongTinCauTaoCongTron_CCaoMong = plmc.ThongTinCauTaoCongTron_CCaoMong,
                                ThongTinCauTaoCongTron_CRongMong = plmc.ThongTinCauTaoCongTron_CRongMong,
                                CreateAt = plmc.CreateAt,
                                CreateBy = plmc.CreateBy,
                                IsActive = plmc.IsActive,
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

        public async Task<PhanLoaiMongCTron> GetMPhanLoaiMongCTronByDetail(PhanLoaiMongCTron searchData)
        {
            try
            {
                using var context = _context.CreateDbContext();

                // Thực hiện lọc dữ liệu dựa trên các thuộc tính của searchData
                var query = context.PhanLoaiMongCTrons
                             .Where(plmct => (
                                    plmct.ThongTinDuongTruyenDan_HinhThucTruyenDan == searchData.ThongTinDuongTruyenDan_HinhThucTruyenDan &&
                                    plmct.ThongTinDuongTruyenDan_LoaiTruyenDan == searchData.ThongTinDuongTruyenDan_LoaiTruyenDan &&
                                    plmct.ThongTinMongDuongTruyenDan_LoaiMong == searchData.ThongTinMongDuongTruyenDan_LoaiMong &&
                                    plmct.ThongTinMongDuongTruyenDan_HinhThucMong == searchData.ThongTinMongDuongTruyenDan_HinhThucMong &&
                                    plmct.ThongTinCauTaoCongTron_CCaoLotMong == searchData.ThongTinCauTaoCongTron_CCaoLotMong &&
                                    plmct.ThongTinCauTaoCongTron_CRongLotMong == searchData.ThongTinCauTaoCongTron_CRongLotMong &&
                                    plmct.ThongTinCauTaoCongTron_CCaoMong == searchData.ThongTinCauTaoCongTron_CCaoMong &&
                                    plmct.ThongTinCauTaoCongTron_CRongMong == searchData.ThongTinCauTaoCongTron_CRongMong
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

        public async Task Update(PhanLoaiMongCTron PhanLoaiMongCTron)
        {
            using var context = _context.CreateDbContext();
            var entity = GetById(PhanLoaiMongCTron.Id);

            if (entity == null)
            {
                throw new Exception($"Không tìm thấy bản ghi theo ID: {PhanLoaiMongCTron.Id}");
            }

            context.PhanLoaiMongCTrons.Update(PhanLoaiMongCTron);
            await context.SaveChangesAsync();
        }

        public async Task UpdateMulti(PhanLoaiMongCTron[] PhanLoaiMongCTron)
        {
            using var context = _context.CreateDbContext();
            string[] ids = PhanLoaiMongCTron.Select(x => x.Id).ToArray();
            var listEntities = await context.PhanLoaiMongCTrons.Where(x => ids.Contains(x.Id)).ToListAsync();
            foreach (var entity in listEntities)
            {
                context.PhanLoaiMongCTrons.Update(entity);
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

            context.Set<PhanLoaiMongCTron>().Remove(entity);
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

        public async Task<PhanLoaiMongCTron> GetById(string id)
        {
            using var context = _context.CreateDbContext();
            var entity = await context.PhanLoaiMongCTrons.Where(x => x.Id.Equals(id)).FirstOrDefaultAsync();

            if (entity == null)
            {
                throw new Exception($"Không tìm thấy bản ghi theo ID: {id}");
            }

            return entity;
        }

        public async Task Insert(PhanLoaiMongCTron entity)
        {
            try
            {
                using var context = _context.CreateDbContext();
                if (entity == null)
                {
                    throw new Exception("Không có bản ghi nào để thêm!");
                }

                // Kiểm tra xem bảng có bản ghi nào không
                var maxFlag = await context.PhanLoaiMongCTrons.AnyAsync()
                              ? await context.PhanLoaiMongCTrons.MaxAsync(x => x.Flag)
                              : 0;

                // Tăng giá trị Flag lên 1
                entity.Flag = maxFlag + 1;
                entity.ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop = " loại " + entity.Flag;

                // Chèn bản ghi mới vào bảng
                context.PhanLoaiMongCTrons.Add(entity);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public async Task<string> InsertId(PhanLoaiMongCTron entity, string LoaiTD , string LoaiM ,string HTM)
        {
            try
            {
                using var context = _context.CreateDbContext();

                if (entity == null)
                {
                    throw new Exception("Không có bản ghi nào để thêm!");
                }

                // Kiểm tra xem bảng có bản ghi nào không
                var maxFlag = await context.PhanLoaiMongCTrons.AnyAsync()
                              ? await context.PhanLoaiMongCTrons.MaxAsync(x => x.Flag)
                              : 0;

                // Tăng giá trị Flag lên 1
                entity.Flag = maxFlag + 1;
                entity.ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop = LoaiTD + " " + LoaiM +" "+HTM+ " loại " + entity.Flag;

                // Chèn bản ghi mới vào bảng
                context.PhanLoaiMongCTrons.Add(entity);
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