using DucAnhERP.Data;
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
                            join hinhThucDayHoGa in context.DSDanhMuc
                            on pltdhg.ThongTinTamDanHoGa2_HinhThucDayHoGa equals hinhThucDayHoGa.Id
                            orderby pltdhg.Flag
                            select new PhanLoaiTDHoGaModel
                            {
                                Id = pltdhg.Id,
                                ThongTinTamDanHoGa2_PhanLoaiDayHoGa = pltdhg.ThongTinTamDanHoGa2_PhanLoaiDayHoGa,
                                ThongTinTamDanHoGa2_HinhThucDayHoGa = pltdhg.ThongTinTamDanHoGa2_HinhThucDayHoGa,
                                ThongTinTamDanHoGa2_HinhThucDayHoGa_Name = hinhThucDayHoGa.Ten,
                                ThongTinTamDanHoGa2_DuongKinh = pltdhg.ThongTinTamDanHoGa2_DuongKinh,
                                ThongTinTamDanHoGa2_ChieuDay = pltdhg.ThongTinTamDanHoGa2_ChieuDay,
                                ThongTinTamDanHoGa2_D = pltdhg.ThongTinTamDanHoGa2_D,
                                ThongTinTamDanHoGa2_R = pltdhg.ThongTinTamDanHoGa2_R,
                                ThongTinTamDanHoGa2_C = pltdhg.ThongTinTamDanHoGa2_C,
                                CreateAt = pltdhg.CreateAt,
                                CreateBy = pltdhg.CreateBy,
                                IsActive = pltdhg.IsActive,
                                Flag=pltdhg.Flag,
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
                         .Where(hrt => (hrt.ThongTinTamDanHoGa2_PhanLoaiDayHoGa == id));

            var data = await query.ToListAsync();

            // Kiểm tra nếu danh sách kết quả rỗng hoặc không có dữ liệu khớp
            isSuccess = data.Any();
            return (isSuccess);
        }
        public async Task<bool> CheckUsingName(string name)
        {
            bool isSuccess = false;
            using var context = _context.CreateDbContext();
            var query = context.PhanLoaiTDHoGas
                         .Where(item => (item.ThongTinTamDanHoGa2_PhanLoaiDayHoGa.ToUpper().Trim() == name.ToUpper().Trim()));

            var data = await query.ToListAsync();

            // Kiểm tra nếu danh sách kết quả rỗng hoặc không có dữ liệu khớp
            isSuccess = data.Any();
            return (isSuccess);
        }
        public async Task<PhanLoaiTDHoGa> GetPhanLoaiTDHoGaByDetail(PhanLoaiTDHoGa searchData)
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
        public async Task<PhanLoaiTDHoGa> GetPhanLoaiTDHoGaExist(PhanLoaiTDHoGa searchData)
        {
            try
            {
                using var context = _context.CreateDbContext();

                // Thực hiện lọc dữ liệu dựa trên các thuộc tính của searchData
                var query = context.PhanLoaiTDHoGas
                             .Where(pltdhg => (
                                    pltdhg.ThongTinTamDanHoGa2_PhanLoaiDayHoGa == searchData.ThongTinTamDanHoGa2_PhanLoaiDayHoGa ||
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
                if (string.IsNullOrEmpty(entity.ThongTinTamDanHoGa2_PhanLoaiDayHoGa))
                {
                    entity.ThongTinTamDanHoGa2_PhanLoaiDayHoGa = " loại " + entity.Flag;
                }
               
              

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
        public async Task<string> InsertLaterFlag(PhanLoaiTDHoGa entity, int FlagLast)
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
                var recordsToUpdate = await context.PhanLoaiTDHoGas
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
                    var maxFlag = await context.PhanLoaiTDHoGas.AnyAsync()
                                  ? await context.PhanLoaiTDHoGas.MaxAsync(x => x.Flag)
                                  : 0;

                    // Tăng giá trị Flag lên 1
                    entity.Flag = maxFlag + 1;
                }
                else
                {
                    entity.Flag = FlagLast + 1;
                }


                // Kiểm tra và gán giá trị nếu trường ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop rỗng
                if (string.IsNullOrEmpty(entity.ThongTinTamDanHoGa2_PhanLoaiDayHoGa))
                {
                    entity.ThongTinTamDanHoGa2_PhanLoaiDayHoGa = "loại " + entity.Flag;
                }

                // Bước 4: Chèn bản ghi mới vào bảng
                context.PhanLoaiTDHoGas.Add(entity);

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

        //báo cáo 
        public async Task<List<PhanLoaiTDHoGaModel>> GetBaoCaoKTHHTDanHGa(PhanLoaiTDHoGaModel pltdhgaModel)
        {
            try
            {
                using var context = _context.CreateDbContext();
                var query = from pltdhg in context.PhanLoaiTDHoGas
                            join hinhThucDayHoGa in context.DSDanhMuc
                            on pltdhg.ThongTinTamDanHoGa2_HinhThucDayHoGa equals hinhThucDayHoGa.Id
                            orderby pltdhg.Flag
                            select new PhanLoaiTDHoGaModel
                            {
                                Id = pltdhg.Id,
                                ThongTinTamDanHoGa2_PhanLoaiDayHoGa = pltdhg.ThongTinTamDanHoGa2_PhanLoaiDayHoGa,
                                ThongTinTamDanHoGa2_HinhThucDayHoGa = pltdhg.ThongTinTamDanHoGa2_HinhThucDayHoGa,
                                ThongTinTamDanHoGa2_HinhThucDayHoGa_Name = hinhThucDayHoGa.Ten,
                                ThongTinTamDanHoGa2_DuongKinh = pltdhg.ThongTinTamDanHoGa2_DuongKinh,
                                ThongTinTamDanHoGa2_ChieuDay = pltdhg.ThongTinTamDanHoGa2_ChieuDay,
                                ThongTinTamDanHoGa2_D = pltdhg.ThongTinTamDanHoGa2_D,
                                ThongTinTamDanHoGa2_R = pltdhg.ThongTinTamDanHoGa2_R,
                                ThongTinTamDanHoGa2_C = pltdhg.ThongTinTamDanHoGa2_C,
                                CreateAt = pltdhg.CreateAt,
                                CreateBy = pltdhg.CreateBy,
                                IsActive = pltdhg.IsActive,
                                Flag = pltdhg.Flag,
                            };
                if (!string.IsNullOrEmpty(pltdhgaModel.ThongTinTamDanHoGa2_HinhThucDayHoGa))
                {
                    query = query.Where(x => x.ThongTinTamDanHoGa2_HinhThucDayHoGa == pltdhgaModel.ThongTinTamDanHoGa2_HinhThucDayHoGa);
                }
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
    }

}
