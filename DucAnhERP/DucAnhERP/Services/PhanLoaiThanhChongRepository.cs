using DucAnhERP.Data;
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
                            join cauTaoThanhChong in context.DSDanhMuc 
                            on pltc.TTKTHHCongHopRanh_CauTaoThanhChong equals cauTaoThanhChong.Id
                            orderby pltc.Flag
                            select new PhanLoaiThanhChongModel
                            {
                                Id = pltc.Id,
                                Flag = pltc.Flag,
                                TTKTHHCongHopRanh_LoaiThanhChong = pltc.TTKTHHCongHopRanh_LoaiThanhChong,
                                TTKTHHCongHopRanh_CauTaoThanhChong = pltc.TTKTHHCongHopRanh_CauTaoThanhChong,
                                TTKTHHCongHopRanh_CauTaoThanhChong_Name = cauTaoThanhChong.Ten,
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
            var query = context.DSNuocMua
                         .Where(hrt => (hrt.TTKTHHCongHopRanh_LoaiThanhChong == id));

            var data = await query.ToListAsync();

            // Kiểm tra nếu danh sách kết quả rỗng hoặc không có dữ liệu khớp
            isSuccess = data.Any();
            return (isSuccess);
        }
        public async Task<bool> CheckUsingName(string name)
        {
            bool isSuccess = false;
            using var context = _context.CreateDbContext();
            var query = context.PhanLoaiThanhChongs
                         .Where(item => (item.TTKTHHCongHopRanh_LoaiThanhChong.ToUpper().Trim() == name.ToUpper().Trim()));

            var data = await query.ToListAsync();

            // Kiểm tra nếu danh sách kết quả rỗng hoặc không có dữ liệu khớp
            isSuccess = data.Any();
            return (isSuccess);
        }
        public async Task<PhanLoaiThanhChong> GetPhanLoaiThanhChongByDetail(PhanLoaiThanhChong searchData)
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

        public async Task<PhanLoaiThanhChong> GetNumberPhanLoai(PhanLoaiThanhChong searchData)
        {
            try
            {
                using var context = _context.CreateDbContext();

                // Thực hiện lọc dữ liệu dựa trên các thuộc tính của searchData
                var query = context.PhanLoaiThanhChongs
                             .Where(pltc => (
                                    pltc.TTKTHHCongHopRanh_CauTaoThanhChong == searchData.TTKTHHCongHopRanh_CauTaoThanhChong
                                          )).OrderByDescending(pltc => pltc.Loai);

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


        public async Task<PhanLoaiThanhChong> GetPhanLoaiThanhChongExist(PhanLoaiThanhChong searchData)
        {
            try
            {
                using var context = _context.CreateDbContext();

                // Thực hiện lọc dữ liệu dựa trên các thuộc tính của searchData
                var query = context.PhanLoaiThanhChongs
                             .Where(pltc => (
                                    pltc.TTKTHHCongHopRanh_LoaiThanhChong == searchData.TTKTHHCongHopRanh_LoaiThanhChong ||
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
            try
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
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
                if (string.IsNullOrEmpty(entity.TTKTHHCongHopRanh_LoaiThanhChong))
                {
                    entity.TTKTHHCongHopRanh_LoaiThanhChong = "Đế cống loại " + entity.Flag;
                }


                // Chèn bản ghi mới vào bảng
                context.PhanLoaiThanhChongs.Add(entity);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public async Task<string> InsertLaterFlag(PhanLoaiThanhChong entity, int FlagLast)
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
                var recordsToUpdate = await context.PhanLoaiThanhChongs
                    .Where(x => x.Flag > FlagLast)
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
                    var maxFlag = await context.PhanLoaiThanhChongs.AnyAsync()
                                  ? await context.PhanLoaiThanhChongs.MaxAsync(x => x.Flag)
                                  : 0;

                    // Tăng giá trị Flag lên 1
                    entity.Flag = maxFlag + 1;
                }
                else
                {
                    entity.Flag = FlagLast + 1;
                }


                // Kiểm tra và gán giá trị nếu trường ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop rỗng
                if (string.IsNullOrEmpty(entity.TTKTHHCongHopRanh_LoaiThanhChong))
                {
                    entity.TTKTHHCongHopRanh_LoaiThanhChong = "loại " + entity.Flag;
                }

                // Bước 4: Chèn bản ghi mới vào bảng
                context.PhanLoaiThanhChongs.Add(entity);

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
                
                var maxLoai = await GetNumberPhanLoai(entity);
                if (maxLoai != null)
                {
                    // Tăng giá trị Flag lên 1
                    entity.Loai = (maxLoai.Loai ?? 0) + 1;
                }
                else
                {
                    entity.Loai = 1;
                }
                if (string.IsNullOrEmpty(entity.TTKTHHCongHopRanh_LoaiThanhChong))
                {
                    entity.TTKTHHCongHopRanh_LoaiThanhChong = "Thanh chống loại " + entity.Loai + " " + CTTC;
                }
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
