using DucAnhERP.Data;
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
                            join hinhThucTruyenDan in context.DSDanhMuc
                               on plmc.ThongTinDuongTruyenDan_HinhThucTruyenDan equals hinhThucTruyenDan.Id
                            join loaiTruyenDan in context.DSDanhMuc
                                on plmc.ThongTinDuongTruyenDan_LoaiTruyenDan equals loaiTruyenDan.Id
                            join loaiMong in context.DSDanhMuc
                                on plmc.ThongTinMongDuongTruyenDan_LoaiMong equals loaiMong.Id
                            join hinhThucMong in context.DSDanhMuc
                               on plmc.ThongTinMongDuongTruyenDan_HinhThucMong equals hinhThucMong.Id

                            orderby plmc.Flag
                            select new PhanLoaiMongCongModel
                            {
                                Id = plmc.Id,
                                Flag = plmc.Flag,
                                ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop = plmc.ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop,
                                ThongTinDuongTruyenDan_HinhThucTruyenDan = plmc.ThongTinDuongTruyenDan_HinhThucTruyenDan,
                                ThongTinDuongTruyenDan_HinhThucTruyenDan_Name = hinhThucTruyenDan.Ten,
                                ThongTinDuongTruyenDan_LoaiTruyenDan = plmc.ThongTinDuongTruyenDan_LoaiTruyenDan,
                                ThongTinDuongTruyenDan_LoaiTruyenDan_Name = loaiTruyenDan.Ten,
                                ThongTinMongDuongTruyenDan_LoaiMong = plmc.ThongTinMongDuongTruyenDan_LoaiMong,
                                ThongTinMongDuongTruyenDan_LoaiMong_Name = loaiMong.Ten,
                                ThongTinMongDuongTruyenDan_HinhThucMong = plmc.ThongTinMongDuongTruyenDan_HinhThucMong,
                                ThongTinMongDuongTruyenDan_HinhThucMong_Name = hinhThucMong.Ten,
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

        public async Task<PhanLoaiMongCTron> GetPhanLoaiMongCTronByDetail(PhanLoaiMongCTron searchData)
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
        public async Task<PhanLoaiMongCTron> GetPhanLoaiMongCTronExist(PhanLoaiMongCTron searchData)
        {
            try
            {
                using var context = _context.CreateDbContext();

                // Thực hiện lọc dữ liệu dựa trên các thuộc tính của searchData
                var query = context.PhanLoaiMongCTrons
                             .Where(plmct => (
                                    plmct.ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop == searchData.ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop ||
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
                if (string.IsNullOrEmpty(entity.ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop))
                {
                    entity.ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop = " loại " + entity.Flag;
                }
                

                // Chèn bản ghi mới vào bảng
                context.PhanLoaiMongCTrons.Add(entity);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public async Task<string> InsertLaterFlag(PhanLoaiMongCTron entity ,int FlagLast)
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
                var recordsToUpdate = await context.PhanLoaiMongCTrons
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
                if(recordsToUpdate.Count() == 0)
                {
                    // Kiểm tra xem bảng có bản ghi nào không
                    var maxFlag = await context.PhanLoaiMongCTrons.AnyAsync()
                                  ? await context.PhanLoaiMongCTrons.MaxAsync(x => x.Flag)
                                  : 0;

                    // Tăng giá trị Flag lên 1
                    entity.Flag = maxFlag + 1;
                }
                else
                {
                    entity.Flag = FlagLast+1;
                }
                

                // Kiểm tra và gán giá trị nếu trường ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop rỗng
                if (string.IsNullOrEmpty(entity.ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop))
                {
                    entity.ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop = "loại " + entity.Flag;
                }

                // Bước 4: Chèn bản ghi mới vào bảng
                context.PhanLoaiMongCTrons.Add(entity);

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
