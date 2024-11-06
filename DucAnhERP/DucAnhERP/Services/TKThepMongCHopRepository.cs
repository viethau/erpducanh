using DucAnhERP.Data;
using DucAnhERP.Models;
using DucAnhERP.Repository;
using DucAnhERP.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace DucAnhERP.Services
{
    public class TKThepMongCHopRepository : ITKThepMongCHopRepository
    {
        private readonly IDbContextFactory<ApplicationDbContext> _context;

        public TKThepMongCHopRepository(IDbContextFactory<ApplicationDbContext> context)
        {
            _context = context;
        }
        public async Task<List<TKThepMongCHop>> GetAll()
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
                             .Where(item => (
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
        public async Task Update(TKThepMongCHop TKThepMongCHop)
        {
            using var context = _context.CreateDbContext();
            var entity = GetById(TKThepMongCHop.Id);

            if (entity == null)
            {
                throw new Exception($"Không tìm thấy bản ghi theo ID: {TKThepMongCHop.Id}");
            }

            context.TKThepMongCHops.Update(TKThepMongCHop);
            await context.SaveChangesAsync();
        }
        public async Task UpdateMulti(TKThepMongCHop[] TKThepMongCHop)
        {
            using var context = _context.CreateDbContext();
            string[] ids = TKThepMongCHop.Select(x => x.Id).ToArray();
            var listEntities = await context.TKThepMongCHops.Where(x => ids.Contains(x.Id)).ToListAsync();
            foreach (var entity in listEntities)
            {
                context.TKThepMongCHops.Update(entity);
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

            context.Set<TKThepMongCHop>().Remove(entity);
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
        public async Task Insert(TKThepMongCHop entity)
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
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public async Task<string> InsertLaterFlag(TKThepMongCHop entity, int FlagLast)
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
                    .Where(x => x.Flag > FlagLast && x.ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop == entity.ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop)
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
                    var maxFlag = await context.TKThepMongCHops.AnyAsync()
                                  ? await context.TKThepMongCHops.MaxAsync(x => x.Flag)
                                  : 0;

                    // Tăng giá trị Flag lên 1
                    entity.Flag = maxFlag + 1;
                }
                else
                {
                    entity.Flag = FlagLast + 1;
                }

                // Bước 4: Chèn bản ghi mới vào bảng
                context.TKThepMongCHops.Add(entity);

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
