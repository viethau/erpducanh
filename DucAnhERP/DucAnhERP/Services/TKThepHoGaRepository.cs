
using DucAnhERP.Data;
using DucAnhERP.Models;
using DucAnhERP.Repository;
using DucAnhERP.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace DucAnhERP.Services
{

    public class TKThepHoGaRepository : ITKThepHoGaRepository
    {
        private readonly IDbContextFactory<ApplicationDbContext> _context;

        public TKThepHoGaRepository(IDbContextFactory<ApplicationDbContext> context)
        {
            _context = context;
        }
        public async Task<List<TKThepHGa>> GetAll()
        {
            try
            {
                using var context = _context.CreateDbContext();
                var entity = await context.TKThepHGas.ToListAsync();
                return entity;
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.Error.WriteLine($"An error occurred: {ex.Message}");
                throw; // Optionally rethrow the exception
            }
        }
        public async Task<TKThepHGa> GetById(string id)
        {
            using var context = _context.CreateDbContext();
            var entity = await context.TKThepHGas.Where(x => x.Id.Equals(id)).FirstOrDefaultAsync();

            if (entity == null)
            {
                throw new Exception($"Không tìm thấy bản ghi theo ID: {id}");
            }

            return entity;
        }
        public async Task<List<TKThepHGaModel>> GetAllByVM()
        {
            try
            {
                using var context = _context.CreateDbContext();
                var query = from tk in context.TKThepHGas
                            join plHoGa in context.PhanLoaiHoGas
                            on tk.ThongTinChungHoGa_TenHoGaSauPhanLoai equals plHoGa.Id
                            orderby tk.CreateAt
                            select new TKThepHGaModel
                            {
                                Id = tk.Id,
                                Flag = tk.Flag,

                                ThongTinChungHoGa_TenHoGaSauPhanLoai = tk.ThongTinChungHoGa_TenHoGaSauPhanLoai,
                                ThongTinChungHoGa_TenHoGaSauPhanLoai_Name = plHoGa.ThongTinChungHoGa_TenHoGaSauPhanLoai,
                                TenCongTac = tk.TenCongTac,
                                VTLayKhoiLuong = tk.VTLayKhoiLuong,
                                LoaiThep = tk.LoaiThep,
                                DKCD = tk.DKCD,
                                SoThanh = tk.SoThanh,
                                SoCK = tk.SoCK,
                                TongSoThanh = tk.TongSoThanh,
                                ChieuDai1Thanh = tk.ChieuDai1Thanh,
                                TongChieuDai = tk.TongChieuDai,
                                TrongLuong = tk.TrongLuong,
                                TongTrongLuong = tk.TongTrongLuong,

                                CreateAt = tk.CreateAt,
                                CreateBy = tk.CreateBy,
                                IsActive = tk.IsActive,
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
        public async Task Update(TKThepHGa TKThepHGa)
        {
            using var context = _context.CreateDbContext();
            var entity = GetById(TKThepHGa.Id);

            if (entity == null)
            {
                throw new Exception($"Không tìm thấy bản ghi theo ID: {TKThepHGa.Id}");
            }

            context.TKThepHGas.Update(TKThepHGa);
            await context.SaveChangesAsync();
        }
        public async Task UpdateMulti(TKThepHGa[] TKThepHGa)
        {
            using var context = _context.CreateDbContext();
            string[] ids = TKThepHGa.Select(x => x.Id).ToArray();
            var listEntities = await context.TKThepHGas.Where(x => ids.Contains(x.Id)).ToListAsync();
            foreach (var entity in listEntities)
            {
                context.TKThepHGas.Update(entity);
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

            context.Set<TKThepHGa>().Remove(entity);
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
        public async Task Insert(TKThepHGa entity)
        {
            try
            {
                using var context = _context.CreateDbContext();
                if (entity == null)
                {
                    throw new Exception("Không có bản ghi nào để thêm!");
                }

                // Kiểm tra xem bảng có bản ghi nào không
                var maxFlag = await context.TKThepHGas.AnyAsync()
                              ? await context.TKThepHGas.MaxAsync(x => x.Flag)
                              : 0;

                // Tăng giá trị Flag lên 1
                entity.Flag = maxFlag + 1;

                entity.TenCongTac = "Gia công lắp dựng thép " + entity.VTLayKhoiLuong + " " + entity.LoaiThep + " " + entity.DKCD;

                // Chèn bản ghi mới vào bảng
                context.TKThepHGas.Add(entity);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public async Task<string> InsertLaterFlag(TKThepHGa entity, int FlagLast)
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
                var recordsToUpdate = await context.TKThepHGas
                    .Where(x => x.Flag > FlagLast && x.ThongTinChungHoGa_TenHoGaSauPhanLoai == entity.ThongTinChungHoGa_TenHoGaSauPhanLoai)
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
                    var maxFlag = await context.TKThepHGas.AnyAsync()
                                  ? await context.TKThepHGas.MaxAsync(x => x.Flag)
                                  : 0;

                    // Tăng giá trị Flag lên 1
                    entity.Flag = maxFlag + 1;
                }
                else
                {
                    entity.Flag = FlagLast + 1;
                }



                entity.TenCongTac = "Gia công lắp dựng thép " + entity.VTLayKhoiLuong + " " + entity.LoaiThep + " " + entity.DKCD;


                // Bước 4: Chèn bản ghi mới vào bảng
                context.TKThepHGas.Add(entity);

                // Lưu bản ghi mới vào cơ sở dữ liệu
                await context.SaveChangesAsync();
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
    }
}
