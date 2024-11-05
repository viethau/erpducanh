using DucAnhERP.Data;
using DucAnhERP.Models;
using DucAnhERP.Repository;
using DucAnhERP.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace DucAnhERP.Services
{
    public class TKThepTamDanRepository : ITKThepTamDanRepository
    {
        private readonly IDbContextFactory<ApplicationDbContext> _context;

        public TKThepTamDanRepository(IDbContextFactory<ApplicationDbContext> context)
        {
            _context = context;
        }
        public async Task<List<TKThepTamDan>> GetAll()
        {
            try
            {
                using var context = _context.CreateDbContext();
                var entity = await context.TKThepTamDans.ToListAsync();
                return entity;
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.Error.WriteLine($"An error occurred: {ex.Message}");
                throw; // Optionally rethrow the exception
            }
        }
        public async Task<TKThepTamDan> GetById(string id)
        {
            using var context = _context.CreateDbContext();
            var entity = await context.TKThepTamDans.Where(x => x.Id.Equals(id)).FirstOrDefaultAsync();

            if (entity == null)
            {
                throw new Exception($"Không tìm thấy bản ghi theo ID: {id}");
            }

            return entity;
        }
        public async Task<List<TKThepTamDanModel>> GetAllByVM(TKThepTamDanModel mModel)
        {
            try
            {
                using var context = _context.CreateDbContext();
                var query = from tk in context.TKThepTamDans
                            join plTDHG in context.PhanLoaiTDHoGas
                            on tk.ThongTinTamDanHoGa2_PhanLoaiDayHoGa equals plTDHG.Id
                            join dm in context.DSDanhMuc
                            on tk.LoaiThep equals dm.Id
                            join c in context.DMTLTheps
                            on new { tk.LoaiThep, DKCD = tk.DKCD.ToString() } equals new { LoaiThep = c.ChungLoaiThep, DKCD = c.DuongKinh } into dmThepGroup
                            from c in dmThepGroup.DefaultIfEmpty()
                            orderby tk.SoHieu
                            select new TKThepTamDanModel
                            {
                                Id = tk.Id,
                                Flag = tk.Flag,

                                ThongTinTamDanHoGa2_PhanLoaiDayHoGa = tk.ThongTinTamDanHoGa2_PhanLoaiDayHoGa,
                                ThongTinTamDanHoGa2_PhanLoaiDayHoGa_Name = plTDHG.ThongTinTamDanHoGa2_PhanLoaiDayHoGa,
                                TenCongTac = tk.TenCongTac,
                                VTLayKhoiLuong = tk.VTLayKhoiLuong,
                                LoaiThep = tk.LoaiThep,
                                LoaiThep_Name = dm.Ten,
                                SoHieu = tk.SoHieu,
                                DKCD = tk.DKCD,
                                SoThanh = tk.SoThanh,
                                SoCK = tk.SoCK,
                                TongSoThanh = tk.TongSoThanh,
                                ChieuDai1Thanh = tk.ChieuDai1Thanh,
                                TongChieuDai = tk.TongChieuDai,
                                TrongLuong = c.TrongLuong,
                                TongTrongLuong = tk.TongTrongLuong,

                                CreateAt = tk.CreateAt,
                                CreateBy = tk.CreateBy,
                                IsActive = tk.IsActive,
                            };
                if (!string.IsNullOrEmpty(mModel.ThongTinTamDanHoGa2_PhanLoaiDayHoGa))
                {
                    query = query.Where(x => x.ThongTinTamDanHoGa2_PhanLoaiDayHoGa == mModel.ThongTinTamDanHoGa2_PhanLoaiDayHoGa);
                }
                if (!string.IsNullOrEmpty(mModel.LoaiThep))
                {
                    query = query.Where(x => x.LoaiThep == mModel.LoaiThep);
                }
                var data = await query.Distinct().OrderBy(x=>x.ThongTinTamDanHoGa2_PhanLoaiDayHoGa_Name).ThenBy(x=>x.SoHieu).ToListAsync();
                return data;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }

        }
        public async Task<List<TKThepTamDan>> GetExist(TKThepTamDan searchData)
        {
            try
            {
                using var context = _context.CreateDbContext();

                // Thực hiện lọc dữ liệu dựa trên các thuộc tính của searchData
                var query = context.TKThepTamDans
                             .Where(item => (
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
        public async Task Update(TKThepTamDan TKThepTamDan)
        {
            using var context = _context.CreateDbContext();
            var entity = GetById(TKThepTamDan.Id);

            if (entity == null)
            {
                throw new Exception($"Không tìm thấy bản ghi theo ID: {TKThepTamDan.Id}");
            }

            context.TKThepTamDans.Update(TKThepTamDan);
            await context.SaveChangesAsync();
        }
        public async Task UpdateMulti(TKThepTamDan[] TKThepTamDan)
        {
            using var context = _context.CreateDbContext();
            string[] ids = TKThepTamDan.Select(x => x.Id).ToArray();
            var listEntities = await context.TKThepTamDans.Where(x => ids.Contains(x.Id)).ToListAsync();
            foreach (var entity in listEntities)
            {
                context.TKThepTamDans.Update(entity);
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

            context.Set<TKThepTamDan>().Remove(entity);
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
        public async Task Insert(TKThepTamDan entity)
        {
            try
            {
                using var context = _context.CreateDbContext();
                if (entity == null)
                {
                    throw new Exception("Không có bản ghi nào để thêm!");
                }

                // Lấy tất cả các bản ghi phù hợp và thực hiện xử lý trên client-side
                var maxFlagValue = await context.TKThepTamDans
                    .Where(x => x.ThongTinTamDanHoGa2_PhanLoaiDayHoGa == entity.ThongTinTamDanHoGa2_PhanLoaiDayHoGa)
                    .Select(x => x.Flag)
                    .ToListAsync(); // Lấy danh sách các giá trị Flag

                // Kiểm tra nếu danh sách không có giá trị nào, trả về 0, ngược lại lấy giá trị lớn nhất
                var maxFlag = maxFlagValue.Any() ? maxFlagValue.Max() : 0;


                // Tăng giá trị Flag lên 1
                entity.Flag = maxFlag + 1;

                // Chèn bản ghi mới vào bảng
                context.TKThepTamDans.Add(entity);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public async Task<string> InsertLaterFlag(TKThepTamDan entity, int FlagLast)
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
                var recordsToUpdate = await context.TKThepTamDans
                    .Where(x => x.Flag > FlagLast && x.ThongTinTamDanHoGa2_PhanLoaiDayHoGa == entity.ThongTinTamDanHoGa2_PhanLoaiDayHoGa)
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
                    var maxFlag = await context.TKThepTamDans.AnyAsync()
                                  ? await context.TKThepTamDans.MaxAsync(x => x.Flag)
                                  : 0;

                    // Tăng giá trị Flag lên 1
                    entity.Flag = maxFlag + 1;
                }
                else
                {
                    entity.Flag = FlagLast + 1;
                }

                // Bước 4: Chèn bản ghi mới vào bảng
                context.TKThepTamDans.Add(entity);

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
