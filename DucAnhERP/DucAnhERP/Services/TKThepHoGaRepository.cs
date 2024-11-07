
using DucAnhERP.Components.Pages.NghiepVuCongTrinh.BaoCao;
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
        public async Task<List<TKThepHoGa>> GetAll()
        {
            try
            {
                using var context = _context.CreateDbContext();
                var entity = await context.TKThepHoGas.ToListAsync();
                return entity;
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.Error.WriteLine($"An error occurred: {ex.Message}");
                throw; // Optionally rethrow the exception
            }
        }
        public async Task<TKThepHoGa> GetById(string id)
        {
            using var context = _context.CreateDbContext();
            var entity = await context.TKThepHoGas.Where(x => x.Id.Equals(id)).FirstOrDefaultAsync();

            if (entity == null)
            {
                throw new Exception($"Không tìm thấy bản ghi theo ID: {id}");
            }

            return entity;
        }
        public async Task<List<TKThepHoGaModel>> GetAllByVM(TKThepHoGaModel mModel)
        {
            try
            {
                using var context = _context.CreateDbContext();
                var query = (from a in context.TKThepHoGas
                            join b in context.PhanLoaiHoGas
                            on a.ThongTinChungHoGa_TenHoGaSauPhanLoai equals b.Id into plHoGaGroup
                            from b in plHoGaGroup.DefaultIfEmpty()
                            join dm in context.DSDanhMuc
                            on a.LoaiThep equals dm.Id
                            join c in context.DMTLTheps
                            on new { a.LoaiThep, DKCD = a.DKCD.ToString() } equals new { LoaiThep = c.ChungLoaiThep, DKCD = c.DuongKinh } into dmThepGroup
                            from c in dmThepGroup.DefaultIfEmpty()
                            orderby a.SoHieu
                            select new TKThepHoGaModel
                            {
                                Id = a.Id,
                                Flag = a.Flag,

                                ThongTinChungHoGa_TenHoGaSauPhanLoai = a.ThongTinChungHoGa_TenHoGaSauPhanLoai,
                                ThongTinChungHoGa_TenHoGaSauPhanLoai_Name = b.ThongTinChungHoGa_TenHoGaSauPhanLoai,

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
                            });

                if (!string.IsNullOrEmpty(mModel.ThongTinChungHoGa_TenHoGaSauPhanLoai))
                {
                    query = query.Where(x => x.ThongTinChungHoGa_TenHoGaSauPhanLoai == mModel.ThongTinChungHoGa_TenHoGaSauPhanLoai);
                }
                if (!string.IsNullOrEmpty(mModel.LoaiThep))
                {
                    query = query.Where(x => x.LoaiThep == mModel.LoaiThep);
                }
                var data = await query.Distinct().OrderBy(x => x.ThongTinChungHoGa_TenHoGaSauPhanLoai_Name).ThenBy(x => x.SoHieu).ToListAsync();
                return data;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }

        }
        public async Task<List<TKThepHoGa>> GetExist(TKThepHoGa searchData)
        {
            try
            {
                using var context = _context.CreateDbContext();

                // Thực hiện lọc dữ liệu dựa trên các thuộc tính của searchData
                var query = context.TKThepHoGas
                             .Where(item => (
                                    item.ThongTinChungHoGa_TenHoGaSauPhanLoai == searchData.ThongTinChungHoGa_TenHoGaSauPhanLoai &&
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
        public async Task Update(TKThepHoGa TKThepHoGa)
        {
            using var context = _context.CreateDbContext();
            var entity = GetById(TKThepHoGa.Id);

            if (entity == null)
            {
                throw new Exception($"Không tìm thấy bản ghi theo ID: {TKThepHoGa.Id}");
            }

            context.TKThepHoGas.Update(TKThepHoGa);
            await context.SaveChangesAsync();
        }
        public async Task UpdateMulti(TKThepHoGa[] TKThepHoGa)
        {
            using var context = _context.CreateDbContext();
            string[] ids = TKThepHoGa.Select(x => x.Id).ToArray();
            var listEntities = await context.TKThepHoGas.Where(x => ids.Contains(x.Id)).ToListAsync();
            foreach (var entity in listEntities)
            {
                context.TKThepHoGas.Update(entity);
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

            context.Set<TKThepHoGa>().Remove(entity);
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
        public async Task Insert(TKThepHoGa entity)
        {
            try
            {
                using var context = _context.CreateDbContext();
                if (entity == null)
                {
                    throw new Exception("Không có bản ghi nào để thêm!");
                }

                // Lấy tất cả các bản ghi phù hợp và thực hiện xử lý trên client-side
                var maxFlagValue = await context.TKThepHoGas
                    .Where(x => x.ThongTinChungHoGa_TenHoGaSauPhanLoai == entity.ThongTinChungHoGa_TenHoGaSauPhanLoai)
                    .Select(x => x.Flag)
                    .ToListAsync(); // Lấy danh sách các giá trị Flag

                // Kiểm tra nếu danh sách không có giá trị nào, trả về 0, ngược lại lấy giá trị lớn nhất
                var maxFlag = maxFlagValue.Any() ? maxFlagValue.Max() : 0;


                // Tăng giá trị Flag lên 1
                entity.Flag = maxFlag + 1;

                // Chèn bản ghi mới vào bảng
                context.TKThepHoGas.Add(entity);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public async Task<string> InsertLaterFlag(TKThepHoGa entity, int FlagLast)
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
                var recordsToUpdate = await context.TKThepHoGas
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
                    var maxFlag = await context.TKThepHoGas.AnyAsync()
                                  ? await context.TKThepHoGas.MaxAsync(x => x.Flag)
                                  : 0;

                    // Tăng giá trị Flag lên 1
                    entity.Flag = maxFlag + 1;
                }
                else
                {
                    entity.Flag = FlagLast + 1;
                }

                // Bước 4: Chèn bản ghi mới vào bảng
                context.TKThepHoGas.Add(entity);

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
