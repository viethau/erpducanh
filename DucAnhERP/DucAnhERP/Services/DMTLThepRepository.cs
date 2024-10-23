
using DucAnhERP.Data;
using DucAnhERP.Models;
using DucAnhERP.Repository;
using DucAnhERP.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace DucAnhERP.Services
{

    public class DMTLThepRepository : IDMTLThepRepository
    {
        private readonly IDbContextFactory<ApplicationDbContext> _context;
        public DMTLThepRepository(IDbContextFactory<ApplicationDbContext> context)
        {
            _context = context;
        }
        public async Task<List<DMThep>> GetAll()
        {
            try
            {
                using var context = _context.CreateDbContext();
                var entity = await context.DMTLTheps.ToListAsync();
                return entity;
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.Error.WriteLine($"An error occurred: {ex.Message}");
                throw; // Optionally rethrow the exception
            }
        }
        public async Task<DMThep> GetById(string id)
        {
            using var context = _context.CreateDbContext();
            var entity = await context.DMTLTheps.Where(x => x.Id.Equals(id)).FirstOrDefaultAsync();

            if (entity == null)
            {
                throw new Exception($"Không tìm thấy bản ghi theo ID: {id}");
            }

            return entity;
        }
        public async Task<List<DMTLThepModel>> GetAllByVM(DMTLThepModel mModel)
        {
            try
            {
                using var context = _context.CreateDbContext();
                var query = from tb1 in context.DMTLTheps
                            join tb2 in context.DSDanhMuc
                            on tb1.ChungLoaiThep equals tb2.Id

                            orderby tb1.CreateAt
                            select new DMTLThepModel
                            {
                                Id = tb1.Id,
                                Flag = tb1.Flag,
                                ChungLoaiThep = tb1.ChungLoaiThep,
                                ChungLoaiThep_Name = tb2.Ten,
                                DuongKinh = tb1.DuongKinh,
                                DonVi = tb1.DonVi,
                                TrongLuong = tb1.TrongLuong,

                                CreateAt = tb1.CreateAt,
                                CreateBy = tb1.CreateBy,
                                IsActive = tb1.IsActive,
                            };
                if (!string.IsNullOrEmpty(mModel.ChungLoaiThep))
                {
                    query = query.Where(x => x.ChungLoaiThep == mModel.ChungLoaiThep);
                }

                var data = await query.ToListAsync();
                return data;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }

        }
        public async Task<List<DMThep>> GetExist(DMThep searchData)
        {
            try
            {
                using var context = _context.CreateDbContext();

                // Thực hiện lọc dữ liệu dựa trên các thuộc tính của searchData
                var query = context.DMTLTheps
                             .Where(item => (
                                    item.ChungLoaiThep == searchData.ChungLoaiThep &&
                                    item.DuongKinh == searchData.DuongKinh &&
                                    item.DonVi == searchData.DonVi &&
                                    item.TrongLuong == searchData.TrongLuong

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
        public async Task<DMThep?> GetTrongLuong(string LoaiThep, string DKCD)
        {
            using var context = _context.CreateDbContext();
            var result = await context.DMTLTheps
                .FirstOrDefaultAsync(x => x.ChungLoaiThep == LoaiThep && x.DuongKinh == DKCD);
            return result;
        }
        public async Task<bool> CheckUsingId(string LoaiThep, string KichThuoc)
        {
            bool isSuccess = false;
            using var context = _context.CreateDbContext();
            var query = context.TKThepHoGas
                         .Where(x => (x.LoaiThep == LoaiThep && x.DKCD.ToString() == KichThuoc));

            var data = await query.ToListAsync();
            isSuccess = data.Any();
            if (isSuccess) {
                return (isSuccess);
            }
            else
            {
                var query1 = context.TKThepTamDans
                      .Where(x => (x.LoaiThep == LoaiThep && x.DKCD.ToString() == KichThuoc));
                var data1 = await query.ToListAsync();
                // Kiểm tra nếu danh sách kết quả rỗng hoặc không có dữ liệu khớp
                isSuccess = data1.Any();
                return (isSuccess);
            }
        }

        public async Task Update(DMThep DMThep)
        {
            using var context = _context.CreateDbContext();
            var entity = GetById(DMThep.Id);

            if (entity == null)
            {
                throw new Exception($"Không tìm thấy bản ghi theo ID: {DMThep.Id}");
            }

            context.DMTLTheps.Update(DMThep);
            await context.SaveChangesAsync();
        }
        public async Task UpdateMulti(DMThep[] DMThep)
        {
            using var context = _context.CreateDbContext();
            string[] ids = DMThep.Select(x => x.Id).ToArray();
            var listEntities = await context.DMTLTheps.Where(x => ids.Contains(x.Id)).ToListAsync();
            foreach (var entity in listEntities)
            {
                context.DMTLTheps.Update(entity);
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

            context.Set<DMThep>().Remove(entity);
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
        public async Task Insert(DMThep entity)
        {
            try
            {
                using var context = _context.CreateDbContext();
                if (entity == null)
                {
                    throw new Exception("Không có bản ghi nào để thêm!");
                }

                // Lấy tất cả các bản ghi phù hợp và thực hiện xử lý trên client-side
                var maxFlagValue = await context.DMTLTheps
                    .Where(x => x.ChungLoaiThep == entity.ChungLoaiThep)
                    .Select(x => x.Flag)
                    .ToListAsync(); // Lấy danh sách các giá trị Flag

                // Kiểm tra nếu danh sách không có giá trị nào, trả về 0, ngược lại lấy giá trị lớn nhất
                var maxFlag = maxFlagValue.Any() ? maxFlagValue.Max() : 0;


                // Tăng giá trị Flag lên 1
                entity.Flag = maxFlag + 1;

                // Chèn bản ghi mới vào bảng
                context.DMTLTheps.Add(entity);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public async Task<string> InsertLaterFlag(DMThep entity, int FlagLast)
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
                var recordsToUpdate = await context.DMTLTheps
                    .Where(x => x.Flag > FlagLast && x.ChungLoaiThep == entity.ChungLoaiThep)
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
                    var maxFlag = await context.DMTLTheps.AnyAsync()
                                  ? await context.DMTLTheps.MaxAsync(x => x.Flag)
                                  : 0;

                    // Tăng giá trị Flag lên 1
                    entity.Flag = maxFlag + 1;
                }
                else
                {
                    entity.Flag = FlagLast + 1;
                }

                // Bước 4: Chèn bản ghi mới vào bảng
                context.DMTLTheps.Add(entity);

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
