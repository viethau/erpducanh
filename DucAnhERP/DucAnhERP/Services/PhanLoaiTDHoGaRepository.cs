﻿using DucAnhERP.Data;
using DucAnhERP.Models;
using DucAnhERP.Repository;
using DucAnhERP.ViewModel;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace DucAnhERP.Services
{
    public class PhanLoaiTDHoGaRepository : IPhanLoaiTDHoGaRepository
    {

        private readonly IDbContextFactory<ApplicationDbContext> _context;

        public PhanLoaiTDHoGaRepository(IDbContextFactory<ApplicationDbContext> context)
        {
            _context = context;
        }

        public async Task<List<PhanLoaiTDHoGa>> GetAll()
        {
            try
            {
                using var context = _context.CreateDbContext();
                var entity = await context.PhanLoaiTDHoGas.ToListAsync();
                return entity;
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.Error.WriteLine($"An error occurred: {ex.Message}");
                throw; // Optionally rethrow the exception
            }
        }

        public async Task<List<PhanLoaiTDHoGaModel>> GetAllByVM()
        {
            try
            {
                using var context = _context.CreateDbContext();
                var query = from pltdhg in context.PhanLoaiTDHoGas
                            orderby pltdhg.CreateAt
                            select new PhanLoaiTDHoGaModel
                            {
                                Id = pltdhg.Id,
                                ThongTinTamDanHoGa2_PhanLoaiDayHoGa = pltdhg.ThongTinTamDanHoGa2_PhanLoaiDayHoGa,
                                ThongTinTamDanHoGa2_HinhThucDayHoGa = pltdhg.ThongTinTamDanHoGa2_HinhThucDayHoGa,
                                ThongTinTamDanHoGa2_DuongKinh = pltdhg.ThongTinTamDanHoGa2_DuongKinh,
                                ThongTinTamDanHoGa2_ChieuDay = pltdhg.ThongTinTamDanHoGa2_ChieuDay,
                                ThongTinTamDanHoGa2_D = pltdhg.ThongTinTamDanHoGa2_D,
                                ThongTinTamDanHoGa2_R = pltdhg.ThongTinTamDanHoGa2_R,
                                ThongTinTamDanHoGa2_C = pltdhg.ThongTinTamDanHoGa2_C,
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

        public async Task<PhanLoaiTDHoGa> GetMPhanLoaiTDHoGaByDetail(PhanLoaiTDHoGa searchData)
        {
            try
            {
                using var context = _context.CreateDbContext();

                // Thực hiện lọc dữ liệu dựa trên các thuộc tính của searchData
                var query = context.PhanLoaiTDHoGas
                             .Where(pltdhg => (
                                    pltdhg.ThongTinTamDanHoGa2_HinhThucDayHoGa == searchData.ThongTinTamDanHoGa2_HinhThucDayHoGa &&
                                    pltdhg.ThongTinTamDanHoGa2_DuongKinh == searchData.ThongTinTamDanHoGa2_DuongKinh &&
                                    pltdhg.ThongTinTamDanHoGa2_ChieuDay == searchData.ThongTinTamDanHoGa2_ChieuDay &&
                                    pltdhg.ThongTinTamDanHoGa2_D == searchData.ThongTinTamDanHoGa2_D &&
                                    pltdhg.ThongTinTamDanHoGa2_R == searchData.ThongTinTamDanHoGa2_R &&
                                    pltdhg.ThongTinTamDanHoGa2_C == searchData.ThongTinTamDanHoGa2_C
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

        public async Task Update(PhanLoaiTDHoGa PhanLoaiTDHoGa)
        {
            using var context = _context.CreateDbContext();
            var entity = GetById(PhanLoaiTDHoGa.Id);

            if (entity == null)
            {
                throw new Exception($"Không tìm thấy bản ghi theo ID: {PhanLoaiTDHoGa.Id}");
            }

            context.PhanLoaiTDHoGas.Update(PhanLoaiTDHoGa);
            await context.SaveChangesAsync();
        }

        public async Task UpdateMulti(PhanLoaiTDHoGa[] PhanLoaiTDHoGa)
        {
            using var context = _context.CreateDbContext();
            string[] ids = PhanLoaiTDHoGa.Select(x => x.Id).ToArray();
            var listEntities = await context.PhanLoaiTDHoGas.Where(x => ids.Contains(x.Id)).ToListAsync();
            foreach (var entity in listEntities)
            {
                context.PhanLoaiTDHoGas.Update(entity);
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

            context.Set<PhanLoaiTDHoGa>().Remove(entity);
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

        public async Task<PhanLoaiTDHoGa> GetById(string id)
        {
            using var context = _context.CreateDbContext();
            var entity = await context.PhanLoaiTDHoGas.Where(x => x.Id.Equals(id)).FirstOrDefaultAsync();

            if (entity == null)
            {
                throw new Exception($"Không tìm thấy bản ghi theo ID: {id}");
            }

            return entity;
        }

        public async Task Insert(PhanLoaiTDHoGa entity)
        {
            try
            {
                using var context = _context.CreateDbContext();
                if (entity == null)
                {
                    throw new Exception("Không có bản ghi nào để thêm!");
                }

                // Kiểm tra xem bảng có bản ghi nào không
                var maxFlag = await context.PhanLoaiTDHoGas.AnyAsync()
                              ? await context.PhanLoaiTDHoGas.MaxAsync(x => x.Flag)
                              : 0;

                // Tăng giá trị Flag lên 1
                entity.Flag = maxFlag + 1;
                entity.ThongTinTamDanHoGa2_PhanLoaiDayHoGa = " loại " + entity.Flag;

                // Chèn bản ghi mới vào bảng
                context.PhanLoaiTDHoGas.Add(entity);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public async Task<string> InsertId(PhanLoaiTDHoGa entity,string HinhThucDayHoGa)
        {
            try
            {
                using var context = _context.CreateDbContext();

                if (entity == null)
                {
                    throw new Exception("Không có bản ghi nào để thêm!");
                }

                // Kiểm tra xem bảng có bản ghi nào không
                var maxFlag = await context.PhanLoaiTDHoGas.AnyAsync()
                              ? await context.PhanLoaiTDHoGas.MaxAsync(x => x.Flag)
                              : 0;

                // Tăng giá trị Flag lên 1
                entity.Flag = maxFlag + 1;
                entity.ThongTinTamDanHoGa2_PhanLoaiDayHoGa = HinhThucDayHoGa + " hố ga loại " + entity.Flag;

                // Chèn bản ghi mới vào bảng
                context.PhanLoaiTDHoGas.Add(entity);
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