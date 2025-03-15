using DucAnhERP.Data;
using Microsoft.EntityFrameworkCore;
using DucAnhERP.Models.QLNV;
using DucAnhERP.ViewModel.QLNV;
using DucAnhERP.Repository.QLNV;

namespace DucAnhERP.Services.QLNV
{
    public class QLNV_CongViecRepository : IQLNV_CongViecRepository
    {
        private readonly IDbContextFactory<ApplicationDbContext> _context;
        public QLNV_CongViecRepository(IDbContextFactory<ApplicationDbContext> context)
        {
            _context = context;
        }
        public async Task<List<QLNV_CongViecModel>> GetByVM(QLNV_CongViecModel input)
        {
            List<QLNV_CongViecModel> data = new();
            try
            {
                using var context = _context.CreateDbContext();
                var query = from p1 in context.QLNV_CongViecs
                            where p1.IsActive != 100
                            select p1;

                var result = from p1 in query
                             join nv in context.QLNV_NhanViens on p1.Id_NguoiThucHien equals nv.Id
                             join nhom in context.QLNV_NhomNhanViens on p1.NhomCongViec equals nhom.Id

                             orderby p1.CreateAt descending
                             select new QLNV_CongViecModel
                             {
                                 Id = p1.Id,
                                 Id_Task = p1.Id_Task,
                                 Id_NguoiGiaoViec =p1.Id_NguoiGiaoViec,
                                 Id_NguoiThucHien = p1.Id_NguoiThucHien,
                                 NguoiThucHien = nv.TenNhanVien,
                                 NhomCongViec = p1.NhomCongViec,
                                 TenNhom = nhom.TenNhom,
                                 NgayBatDau =p1.NgayBatDau,
                                 NgayKetThuc = p1.NgayKetThuc,
                                 MucDoUuTien = p1.MucDoUuTien??"",
                                 TienDo = p1.TienDo,
                                 TuDanhGia=p1.TuDanhGia ??"",
                                 LapLai=p1.LapLai,
                                 NoiDungCongViec = p1.NoiDungCongViec,
                                 FileDinhKem =p1.FileDinhKem??"",
                                 GroupId = p1.GroupId,
                                 CreateAt = p1.CreateAt,
                                 CreateBy = p1.CreateBy,
                                 IsActive = p1.IsActive,
                             };

                if (!string.IsNullOrEmpty(input.GroupId))
                {
                    result = result.Where(x => x.GroupId == input.GroupId);
                }
                if (!string.IsNullOrEmpty(input.Id_NguoiGiaoViec))
                {
                    result = result.Where(x => x.Id_NguoiGiaoViec == input.Id_NguoiGiaoViec);
                }
                if (!string.IsNullOrEmpty(input.Id_NguoiThucHien))
                {
                    result = result.Where(x => x.Id_NguoiThucHien == input.Id_NguoiThucHien);
                }
                if (!string.IsNullOrEmpty(input.NhomCongViec))
                {
                    result = result.Where(x => x.NhomCongViec == input.NhomCongViec);
                }
                if (!string.IsNullOrEmpty(input.MucDoUuTien))
                {
                    result = result.Where(x => x.MucDoUuTien == input.MucDoUuTien);
                }
               
                if (!string.IsNullOrEmpty(input.NoiDungCongViec))
                {
                    result = result.Where(x => x.NoiDungCongViec == input.NoiDungCongViec);
                }

                data = await result.ToListAsync();
                return data;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return data;
            }
        }
        public async Task<List<QLNV_CongViec>> GetAll(string groupId)
        {
            try
            {
                using var context = _context.CreateDbContext();
                var entity = await context.QLNV_CongViecs.Where(p => p.IsActive != 100).ToListAsync();
                return entity;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"An error occurred: {ex.Message}");
                throw;
            }
        }
        public async Task<QLNV_CongViec> GetById(string id)
        {
            try
            {
                using var context = _context.CreateDbContext();
                var entity = await context.QLNV_CongViecs.Where(x => x.Id.Equals(id) && x.IsActive != 100).FirstOrDefaultAsync();
                if (entity == null)
                {
                    throw new Exception($"Không tìm thấy Id");
                }
                return entity;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"An error occurred: {ex.Message}");
                return new QLNV_CongViec();
            }
        }
        public async Task<List<QLNV_CongViec>> GetByIdTask(string id)
        {
            try
            {
                using var context = _context.CreateDbContext();
                var entity = await context.QLNV_CongViecs.Where(x => x.Id_Task.Equals(id) && x.IsActive != 100).ToListAsync();
                if (entity == null)
                {
                    throw new Exception($"Không tìm thấy Id_Task");
                }
                return entity;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"An error occurred: {ex.Message}");
                return new List<QLNV_CongViec>();
            }
        }
        public async Task<bool> CheckExist(string id, QLNV_CongViec input)
        {
            using var context = _context.CreateDbContext();
            return await context.QLNV_CongViecs
                .AnyAsync(x => x.Id_Task != input.Id_Task &&
                               x.Id_NguoiGiaoViec == input.Id_NguoiGiaoViec &&
                               x.Id_NguoiThucHien == input.Id_NguoiThucHien &&
                               x.NhomCongViec == input.NhomCongViec &&
                               x.NgayBatDau == input.NgayBatDau &&
                               x.NgayKetThuc == input.NgayKetThuc &&
                               x.MucDoUuTien == input.MucDoUuTien &&
                               x.TienDo == input.TienDo &&
                               x.TuDanhGia == input.TuDanhGia && 
                               x.LapLai == input.LapLai && 
                               x.NoiDungCongViec == input.NoiDungCongViec && 
                               x.FileDinhKem == input.FileDinhKem  
                               );
        }
        public async Task<bool> IsIdInUse(string id)
        {
            using var context = _context.CreateDbContext();
            // Kiểm tra xem Id có đang được sử dụng trong bảng khác hay không
            // Ví dụ: kiểm tra trong bảng `SomeOtherTable`
            //bool isInUse = await context.SomeOtherTable.AnyAsync(x => x.QDBoiThuongGocId == id);
            return false;
        }
        public async Task Insert(QLNV_CongViec entity, string userId)
        {
            try
            {
                using var context = _context.CreateDbContext();
                if (entity == null)
                {
                    throw new Exception("Thêm không thành công!");
                }
                context.QLNV_CongViecs.Add(entity);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        public async Task Update(QLNV_CongViec data, string userId)
        {
            using var context = _context.CreateDbContext();
            var entity = GetById(data.Id);
            if (entity == null)
            {
                throw new Exception($"Không tìm thấy Id !");
            }
            context.QLNV_CongViecs.Update(data);
            await context.SaveChangesAsync();
        }
        public async Task UpdateMulti(QLNV_CongViec[] QLNV_CongViecs)
        {
            using var context = _context.CreateDbContext();
            string[] ids = QLNV_CongViecs.Select(x => x.Id).ToArray();
            var listEntities = await context.QLNV_CongViecs.Where(x => ids.Contains(x.Id)).ToListAsync();
            foreach (var entity in listEntities)
            {
                context.QLNV_CongViecs.Update(entity);
            }
            await context.SaveChangesAsync();
        }
        public async Task DeleteById(string id, string userId)
        {
            using var context = _context.CreateDbContext();
            var entity = await GetById(id);
            if (entity == null)
            {
                throw new Exception($"Không tìm thấy Id !");
            }
            context.Set<QLNV_CongViec>().Remove(entity);
            await context.SaveChangesAsync();
        }
        public async Task DeleteByIdTask(string Id_Task, string userId)
        {
            using var context = _context.CreateDbContext();

            // Lấy tất cả các bản ghi có Id_Task giống nhau
            var entities = await context.Set<QLNV_CongViec>()
                .Where(e => e.Id_Task == Id_Task)
                .ToListAsync();

            if (entities == null || entities.Count == 0)
            {
                throw new Exception("Không tìm thấy Id_Task !");
            }

            // Xóa tất cả các bản ghi đã tìm thấy
            context.Set<QLNV_CongViec>().RemoveRange(entities);
            await context.SaveChangesAsync();
        }
        public async Task<bool> CheckStatus(string ids, string name)
        {
            using var context = _context.CreateDbContext();
            var model = await context.QLNV_CongViecs.Where(p => p.Id == ids).FirstOrDefaultAsync();
            if (model == null)
            {
                throw new Exception($"Không tìm thấy Id !");
            }
            if (model != null && model.IsActive == 0)
            {
                throw new Exception($"Đang chờ duyệt thêm mới.");
            }
            if (model != null && model.IsActive == 1)
            {
                throw new Exception($"Đang chờ duyệt sửa.");
            }
            if (model != null && model.IsActive == 2)
            {
                throw new Exception($"Đang chờ duyệt xóa.");
            }

            return true;
        }
        public async Task<bool> CheckExclusive(string[] ids, DateTime baseTime)
        {
            foreach (var id in ids)
            {
                var model = await GetById(id);
                if (model == null)
                {
                    throw new Exception($"Không tìm thấy Id !");
                }
                if (model.CreateAt > baseTime)
                {
                    throw new Exception($"Thông tin đã bị thay đổi bởi người dùng khác. Vui lòng tải lại trang!");
                }
            }
            return true;
        }

        //Công việc con
        public async Task InsertCVC(QLNV_CongViecCon entity, string userId)
        {
            try
            {
                using var context = _context.CreateDbContext();
                if (entity == null)
                {
                    throw new Exception("Thêm không thành công!");
                }
                context.QLNV_CongViecCons.Add(entity);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        public async Task<List<QLNV_CongViecCon>> GetAllCVC()
        {
            try
            {
                using var context = _context.CreateDbContext();
                var entity = await context.QLNV_CongViecCons.Where(p => p.IsActive != 100).OrderBy(p =>p.CreateAt).ToListAsync();
                return entity;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"An error occurred: {ex.Message}");
                return new List<QLNV_CongViecCon>();
            }
        }
        public async Task<QLNV_CongViecCon> GetByIdCVC(string id)
        {
            try
            {
                using var context = _context.CreateDbContext();
                var entity = await context.QLNV_CongViecCons.Where(x => x.Id.Equals(id) && x.IsActive != 100).FirstOrDefaultAsync();
                if (entity == null)
                {
                    throw new Exception($"Không tìm thấy Id");
                }
                return entity;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"An error occurred: {ex.Message}");
                return new QLNV_CongViecCon();
            }
        }
        public async Task<List<QLNV_CongViecCon>> GetByIdTaskCVC(string id_task)
        {
            try
            {
                using var context = _context.CreateDbContext();
                var entity = await context.QLNV_CongViecCons.Where(x => x.Id_Task.Equals(id_task) && x.IsActive != 100).ToListAsync();
                if (entity == null)
                {
                    throw new Exception($"Không tìm thấy Id_Task");
                }
                return entity;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"An error occurred: {ex.Message}");
                return new List<QLNV_CongViecCon>();
            }
        }
        public async Task DeleteByIdCVC(string id, string userId)
        {
            using var context = _context.CreateDbContext();
            var entity = await GetByIdCVC(id);
            if (entity == null)
            {
                throw new Exception($"Không tìm thấy Id !");
            }
            context.Set<QLNV_CongViecCon>().Remove(entity);
            await context.SaveChangesAsync();
        }
        public async Task DeleteByIdTaskCVC(string Id_Task, string userId)
        {
            using var context = _context.CreateDbContext();

            // Lấy tất cả các bản ghi có Id_Task giống nhau
            var entities = await GetByIdTaskCVC(Id_Task);

            if (entities == null || entities.Count == 0)
            {
                return;
            }
            // Xóa tất cả các bản ghi đã tìm thấy
            context.Set<QLNV_CongViecCon>().RemoveRange(entities);
            await context.SaveChangesAsync();
        }
        public async Task UpdateCVC(QLNV_CongViecCon data, string userId)
        {
            using var context = _context.CreateDbContext();
            var entity = GetByIdCVC(data.Id);
            if (entity == null)
            {
                throw new Exception($"Không tìm thấy Id !");
            }
            context.QLNV_CongViecCons.Update(data);
            await context.SaveChangesAsync();
        }
        public async Task<bool> CheckExistCVC(string id, QLNV_CongViecCon input)
        {
            using var context = _context.CreateDbContext();
            return await context.QLNV_CongViecs
                .AnyAsync(x => x.Id != input.Id &&
                               x.Id_Task == input.Id_Task &&
                               x.NoiDungCongViec == input.NoiDungCongViec &&
                               x.FileDinhKem == input.FileDinhKem
                               );
        }
        public async Task<bool> CheckExclusiveCVC(string[] ids, DateTime baseTime)
        {
            foreach (var id in ids)
            {
                var model = await GetByIdCVC(id);
                if (model == null)
                {
                    throw new Exception($"Không tìm thấy Id !");
                }
                if (model.CreateAt > baseTime)
                {
                    throw new Exception($"Thông tin đã bị thay đổi bởi người dùng khác. Vui lòng tải lại trang!");
                }
            }
            return true;
        }
    }
}
