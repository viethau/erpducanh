﻿using DucAnhERP.Data;
using DucAnhERP.Models;
using DucAnhERP.Repository;
using DucAnhERP.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace DucAnhERP.Services
{
    public class PhanLoaiThanhChongRepository : IPhanLoaiThanhChongRepository
    {
        private readonly IDbContextFactory<ApplicationDbContext> _context;

        public PhanLoaiThanhChongRepository(IDbContextFactory<ApplicationDbContext> context)
        {
            _context = context;
        }

        public async Task<List<PhanLoaiThanhChong>> GetAll()
        {
            try
            {
                using var context = _context.CreateDbContext();
                var entity = await context.PhanLoaiThanhChongs.ToListAsync();
                return entity;
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.Error.WriteLine($"An error occurred: {ex.Message}");
                throw; // Optionally rethrow the exception
            }
        }

        public async Task<List<PhanLoaiThanhChongModel>> GetAllByVM()
        {
            try
            {
                using var context = _context.CreateDbContext();
                var query = from pltc in context.PhanLoaiThanhChongs
                            orderby pltc.CreateAt
                            select new PhanLoaiThanhChongModel
                            {
                                Id = pltc.Id,
                                Flag = pltc.Flag,
                                TTKTHHCongHopRanh_LoaiThanhChong = pltc.TTKTHHCongHopRanh_LoaiThanhChong,
                                TTKTHHCongHopRanh_CauTaoThanhChong = pltc.TTKTHHCongHopRanh_CauTaoThanhChong,
                                TTKTHHCongHopRanh_CCaoThanhChong = pltc.TTKTHHCongHopRanh_CCaoThanhChong,
                                TTKTHHCongHopRanh_CRongThanhChong = pltc.TTKTHHCongHopRanh_CRongThanhChong,
                                TTKTHHCongHopRanh_CDai = pltc.TTKTHHCongHopRanh_CDai,
                                CreateAt = pltc.CreateAt,
                                CreateBy = pltc.CreateBy,
                                IsActive = pltc.IsActive,
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

        public async Task<PhanLoaiThanhChong> GetMPhanLoaiThanhChongByDetail(PhanLoaiThanhChong searchData)
        {
            try
            {
                using var context = _context.CreateDbContext();

                // Thực hiện lọc dữ liệu dựa trên các thuộc tính của searchData
                var query = context.PhanLoaiThanhChongs
                             .Where(pltc => (
                                    pltc.TTKTHHCongHopRanh_CauTaoThanhChong == searchData.TTKTHHCongHopRanh_CauTaoThanhChong &&
                                    pltc.TTKTHHCongHopRanh_CCaoThanhChong == searchData.TTKTHHCongHopRanh_CCaoThanhChong &&
                                    pltc.TTKTHHCongHopRanh_CRongThanhChong == searchData.TTKTHHCongHopRanh_CRongThanhChong &&
                                    pltc.TTKTHHCongHopRanh_CDai == searchData.TTKTHHCongHopRanh_CDai
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

        public async Task Update(PhanLoaiThanhChong PhanLoaiThanhChong)
        {
            using var context = _context.CreateDbContext();
            var entity = GetById(PhanLoaiThanhChong.Id);

            if (entity == null)
            {
                throw new Exception($"Không tìm thấy bản ghi theo ID: {PhanLoaiThanhChong.Id}");
            }

            context.PhanLoaiThanhChongs.Update(PhanLoaiThanhChong);
            await context.SaveChangesAsync();
        }

        public async Task UpdateMulti(PhanLoaiThanhChong[] PhanLoaiThanhChong)
        {
            using var context = _context.CreateDbContext();
            string[] ids = PhanLoaiThanhChong.Select(x => x.Id).ToArray();
            var listEntities = await context.PhanLoaiThanhChongs.Where(x => ids.Contains(x.Id)).ToListAsync();
            foreach (var entity in listEntities)
            {
                context.PhanLoaiThanhChongs.Update(entity);
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

            context.Set<PhanLoaiThanhChong>().Remove(entity);
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

        public async Task<PhanLoaiThanhChong> GetById(string id)
        {
            using var context = _context.CreateDbContext();
            var entity = await context.PhanLoaiThanhChongs.Where(x => x.Id.Equals(id)).FirstOrDefaultAsync();

            if (entity == null)
            {
                throw new Exception($"Không tìm thấy bản ghi theo ID: {id}");
            }

            return entity;
        }

        public async Task Insert(PhanLoaiThanhChong entity)
        {
            try
            {
                using var context = _context.CreateDbContext();
                if (entity == null)
                {
                    throw new Exception("Không có bản ghi nào để thêm!");
                }

                // Kiểm tra xem bảng có bản ghi nào không
                var maxFlag = await context.PhanLoaiThanhChongs.AnyAsync()
                              ? await context.PhanLoaiThanhChongs.MaxAsync(x => x.Flag)
                              : 0;

                // Tăng giá trị Flag lên 1
                entity.Flag = maxFlag + 1;
                entity.TTKTHHCongHopRanh_LoaiThanhChong = "Đế cống loại " + entity.Flag;

                // Chèn bản ghi mới vào bảng
                context.PhanLoaiThanhChongs.Add(entity);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public async Task<string> InsertId(PhanLoaiThanhChong entity, string CTTC)
        {
            try
            {
                using var context = _context.CreateDbContext();

                if (entity == null)
                {
                    throw new Exception("Không có bản ghi nào để thêm!");
                }

                // Kiểm tra xem bảng có bản ghi nào không
                var maxFlag = await context.PhanLoaiThanhChongs.AnyAsync()
                              ? await context.PhanLoaiThanhChongs.MaxAsync(x => x.Flag)
                              : 0;

                // Tăng giá trị Flag lên 1
                entity.Flag = maxFlag + 1;
                entity.TTKTHHCongHopRanh_LoaiThanhChong = "Thanh chống loại " + entity.Flag+ CTTC;

                // Chèn bản ghi mới vào bảng
                context.PhanLoaiThanhChongs.Add(entity);
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