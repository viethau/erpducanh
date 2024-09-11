using DucAnhERP.Data;
using DucAnhERP.Models;
using DucAnhERP.Repository;
using DucAnhERP.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace DucAnhERP.Services
{
   

    public class PhanLoaiDeCongRepository : IPhanLoaiDeCongRepository
    {
        private readonly IDbContextFactory<ApplicationDbContext> _context;

        public PhanLoaiDeCongRepository(IDbContextFactory<ApplicationDbContext> context)
        {
            _context = context;
        }

        public async Task<List<PhanLoaiDeCong>> GetAll()
        {
            try
            {
                using var context = _context.CreateDbContext();
                var entity = await context.PhanLoaiDeCongs.ToListAsync();
                return entity;
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.Error.WriteLine($"An error occurred: {ex.Message}");
                throw; // Optionally rethrow the exception
            }
        }

        public async Task<List<PhanLoaiDeCongModel>> GetAllByVM()
        {
            try
            {
                using var context = _context.CreateDbContext();
                var query = from pldc in context.PhanLoaiDeCongs
                            orderby pldc.CreateAt
                            select new PhanLoaiDeCongModel
                            {
                                Id = pldc.Id,
                                Flag = pldc.Flag,
                                ThongTinDeCong_TenLoaiDeCong = pldc.ThongTinDeCong_TenLoaiDeCong,
                                ThongTinDuongTruyenDan_LoaiTruyenDan = pldc.ThongTinDuongTruyenDan_LoaiTruyenDan,
                                ThongTinDeCong_CauTaoDeCong = pldc.ThongTinDeCong_CauTaoDeCong,
                                ThongTinDeCong_D = pldc.ThongTinDeCong_D,
                                ThongTinDeCong_R = pldc.ThongTinDeCong_R,
                                ThongTinDeCong_C = pldc.ThongTinDeCong_C,
                                CreateAt = pldc.CreateAt,
                                CreateBy = pldc.CreateBy,
                                IsActive = pldc.IsActive,
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

        public async Task<PhanLoaiDeCong> GetMPhanLoaiDeCongByDetail(PhanLoaiDeCong searchData)
        {
            try
            {
                using var context = _context.CreateDbContext();

                // Thực hiện lọc dữ liệu dựa trên các thuộc tính của searchData
                var query = context.PhanLoaiDeCongs
                             .Where(pldc => (
                                     pldc.ThongTinDuongTruyenDan_LoaiTruyenDan == searchData.ThongTinDuongTruyenDan_LoaiTruyenDan &&
                                     pldc.ThongTinDeCong_CauTaoDeCong == searchData.ThongTinDeCong_CauTaoDeCong &&
                                     pldc.ThongTinDeCong_D == searchData.ThongTinDeCong_D &&
                                     pldc.ThongTinDeCong_R == searchData.ThongTinDeCong_R &&
                                     pldc.ThongTinDeCong_C == searchData.ThongTinDeCong_C
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

        public async Task Update(PhanLoaiDeCong PhanLoaiDeCong)
        {
            using var context = _context.CreateDbContext();
            var entity = GetById(PhanLoaiDeCong.Id);

            if (entity == null)
            {
                throw new Exception($"Không tìm thấy bản ghi theo ID: {PhanLoaiDeCong.Id}");
            }

            context.PhanLoaiDeCongs.Update(PhanLoaiDeCong);
            await context.SaveChangesAsync();
        }

        public async Task UpdateMulti(PhanLoaiDeCong[] PhanLoaiDeCong)
        {
            using var context = _context.CreateDbContext();
            string[] ids = PhanLoaiDeCong.Select(x => x.Id).ToArray();
            var listEntities = await context.PhanLoaiDeCongs.Where(x => ids.Contains(x.Id)).ToListAsync();
            foreach (var entity in listEntities)
            {
                context.PhanLoaiDeCongs.Update(entity);
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

            context.Set<PhanLoaiDeCong>().Remove(entity);
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

        public async Task<PhanLoaiDeCong> GetById(string id)
        {
            using var context = _context.CreateDbContext();
            var entity = await context.PhanLoaiDeCongs.Where(x => x.Id.Equals(id)).FirstOrDefaultAsync();

            if (entity == null)
            {
                throw new Exception($"Không tìm thấy bản ghi theo ID: {id}");
            }

            return entity;
        }

        public async Task Insert(PhanLoaiDeCong entity)
        {
            try
            {
                using var context = _context.CreateDbContext();
                if (entity == null)
                {
                    throw new Exception("Không có bản ghi nào để thêm!");
                }

                // Kiểm tra xem bảng có bản ghi nào không
                var maxFlag = await context.PhanLoaiDeCongs.AnyAsync()
                              ? await context.PhanLoaiDeCongs.MaxAsync(x => x.Flag)
                              : 0;

                // Tăng giá trị Flag lên 1
                entity.Flag = maxFlag + 1;
                entity.ThongTinDeCong_TenLoaiDeCong = "Đế cống loại " + entity.Flag;

                // Chèn bản ghi mới vào bảng
                context.PhanLoaiDeCongs.Add(entity);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public async Task<string> InsertId(PhanLoaiDeCong entity, string CTDC, string LoaiTD)
        {
            try
            {
                using var context = _context.CreateDbContext();

                if (entity == null)
                {
                    throw new Exception("Không có bản ghi nào để thêm!");
                }

                // Kiểm tra xem bảng có bản ghi nào không
                var maxFlag = await context.PhanLoaiDeCongs.AnyAsync()
                              ? await context.PhanLoaiDeCongs.MaxAsync(x => x.Flag)
                              : 0;

                // Tăng giá trị Flag lên 1
                entity.Flag = maxFlag + 1;
                entity.ThongTinDeCong_TenLoaiDeCong = "Đế cống " + CTDC + " " + LoaiTD + " loại " + entity.Flag;

                // Chèn bản ghi mới vào bảng
                context.PhanLoaiDeCongs.Add(entity);
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
