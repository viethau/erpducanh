using DucAnhERP.Data;
using DucAnhERP.Models;
using DucAnhERP.Repository;
using DucAnhERP.ViewModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Runtime.InteropServices;

namespace DucAnhERP.Services
{
    public class PhanLoaiTDanTDanRepository : IPhanLoaiTDanTDanRepository
    {
        private readonly IDbContextFactory<ApplicationDbContext> _context;

        public PhanLoaiTDanTDanRepository(IDbContextFactory<ApplicationDbContext> context)
        {
            _context = context;
        }
        public async Task<bool> CheckStatus(string ids, string name)
        {
            return true;
        }

        public async Task<List<PhanLoaiTDanTDan>> GetAll(string groupId)
        {
            try
            {
                using var context = _context.CreateDbContext();
                var entity = await context.PhanLoaiTDanTDans.ToListAsync();
                return entity;
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.Error.WriteLine($"An error occurred: {ex.Message}");
                throw; // Optionally rethrow the exception
            }
        }
        public async Task<List<PhanLoaiTDanTDanModel>> GetAllByVM(PhanLoaiTDanTDanModel pltdtdModel)
        {
            try
            {
                using var context = _context.CreateDbContext();
                var query = from pltdtd in context.PhanLoaiTDanTDans
                            join hinhThucTruyenDan in context.DSDanhMuc
                                on pltdtd.ThongTinDuongTruyenDan_HinhThucTruyenDan equals hinhThucTruyenDan.Id into gj1
                            from hinhThucTruyenDan in gj1.DefaultIfEmpty() // Left join for HinhThucTruyenDan
                            join loaiTruyenDan in context.DSDanhMuc
                                on pltdtd.ThongTinDuongTruyenDan_LoaiTruyenDan equals loaiTruyenDan.Id into gj2
                            from loaiTruyenDan in gj2.DefaultIfEmpty() // Left join for LoaiTruyenDan
                            join cauTaoTamDanTruyenDanTamDanTieuChuan in context.DSDanhMuc
                                on pltdtd.TTTDCongHoRanh_CauTaoTamDanTruyenDanTamDanTieuChuan equals cauTaoTamDanTruyenDanTamDanTieuChuan.Id into gj3
                            from cauTaoTamDanTruyenDanTamDanTieuChuan in gj3.DefaultIfEmpty() // Left join for CauTaoTamDanTruyenDanTamDanTieuChuan
                            orderby pltdtd.Flag
                            select new PhanLoaiTDanTDanModel
                            {
                                Id = pltdtd.Id,
                                IsEdit = context.DSNuocMua.Any(ds => ds.TTTDCongHoRanh_TenLoaiTamDanTieuChuan == pltdtd.Id || ds.TTTDCongHoRanh_TenLoaiTamDanLoai02 == pltdtd.Id) ? 1 : 0,
                                TTTDCongHoRanh_TenLoaiTamDanTieuChuan = pltdtd.TTTDCongHoRanh_TenLoaiTamDanTieuChuan,
                                ThongTinLyTrinhTruyenDan_TuLyTrinh = pltdtd.ThongTinLyTrinhTruyenDan_TuLyTrinh,
                                ThongTinLyTrinhTruyenDan_DenLyTrinh = pltdtd.ThongTinLyTrinhTruyenDan_DenLyTrinh,
                                ThongTinDuongTruyenDan_HinhThucTruyenDan = pltdtd.ThongTinDuongTruyenDan_HinhThucTruyenDan,
                                ThongTinDuongTruyenDan_HinhThucTruyenDan_Name = hinhThucTruyenDan.Ten,
                                ThongTinDuongTruyenDan_LoaiTruyenDan = pltdtd.ThongTinDuongTruyenDan_LoaiTruyenDan,
                                ThongTinDuongTruyenDan_LoaiTruyenDan_Name = loaiTruyenDan.Ten,
                                TTTDCongHoRanh_CauTaoTamDanTruyenDanTamDanTieuChuan = pltdtd.TTTDCongHoRanh_CauTaoTamDanTruyenDanTamDanTieuChuan,
                                TTTDCongHoRanh_CauTaoTamDanTruyenDanTamDanTieuChuan_Name = cauTaoTamDanTruyenDanTamDanTieuChuan.Ten,
                                TTTDCongHoRanh_CDai = pltdtd.TTTDCongHoRanh_CDai,
                                TTTDCongHoRanh_CRong = pltdtd.TTTDCongHoRanh_CRong,
                                TTTDCongHoRanh_CCao = pltdtd.TTTDCongHoRanh_CCao,
                                CreateAt = pltdtd.CreateAt,
                                CreateBy = pltdtd.CreateBy,
                                IsActive = pltdtd.IsActive,
                                Flag = pltdtd.Flag,
                            };
                if (!string.IsNullOrEmpty(pltdtdModel.ThongTinDuongTruyenDan_HinhThucTruyenDan))
                {
                    query = query.Where(x => x.ThongTinDuongTruyenDan_HinhThucTruyenDan == pltdtdModel.ThongTinDuongTruyenDan_HinhThucTruyenDan);
                }
                if (!string.IsNullOrEmpty(pltdtdModel.ThongTinDuongTruyenDan_LoaiTruyenDan))
                {
                    query = query.Where(x => x.ThongTinDuongTruyenDan_LoaiTruyenDan == pltdtdModel.ThongTinDuongTruyenDan_LoaiTruyenDan);
                }
                if (!string.IsNullOrEmpty(pltdtdModel.TTTDCongHoRanh_CauTaoTamDanTruyenDanTamDanTieuChuan))
                {
                    query = query.Where(x => x.TTTDCongHoRanh_CauTaoTamDanTruyenDanTamDanTieuChuan == pltdtdModel.TTTDCongHoRanh_CauTaoTamDanTruyenDanTamDanTieuChuan);
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
        public async Task<bool> CheckUsingId(string id)
        {
            bool isSuccess = false;
            using var context = _context.CreateDbContext();
            var query = context.DSNuocMua
                         .Where(hrt => (hrt.TTTDCongHoRanh_TenLoaiTamDanTieuChuan == id || hrt.TTTDCongHoRanh_TenLoaiTamDanLoai02 == id));

            var data = await query.ToListAsync();

            // Kiểm tra nếu danh sách kết quả rỗng hoặc không có dữ liệu khớp
            isSuccess = data.Any();
            return (isSuccess);
        }
        public async Task<bool> CheckUsingName(string name)
        {
            bool isSuccess = false;
            using var context = _context.CreateDbContext();
            var query = context.PhanLoaiTDanTDans
                         .Where(item => (item.TTTDCongHoRanh_TenLoaiTamDanTieuChuan.ToUpper().Trim() == name.ToUpper().Trim()));

            var data = await query.ToListAsync();

            // Kiểm tra nếu danh sách kết quả rỗng hoặc không có dữ liệu khớp
            isSuccess = data.Any();
            return (isSuccess);
        }
        public async Task<PhanLoaiTDanTDan> GetPhanLoaiTDanTDanByDetail(PhanLoaiTDanTDan searchData)
        {
            try
            {
                using var context = _context.CreateDbContext();

                // Thực hiện lọc dữ liệu dựa trên các thuộc tính của searchData
                var query = context.PhanLoaiTDanTDans
                             .Where(pltdtd => (
                                    //pltdtd.ThongTinLyTrinhTruyenDan_TuLyTrinh == searchData.ThongTinLyTrinhTruyenDan_TuLyTrinh &&
                                    //pltdtd.ThongTinLyTrinhTruyenDan_DenLyTrinh == searchData.ThongTinLyTrinhTruyenDan_DenLyTrinh &&
                                   
                                    pltdtd.ThongTinDuongTruyenDan_HinhThucTruyenDan == searchData.ThongTinDuongTruyenDan_HinhThucTruyenDan &&
                                    pltdtd.ThongTinDuongTruyenDan_LoaiTruyenDan == searchData.ThongTinDuongTruyenDan_LoaiTruyenDan &&
                                    pltdtd.TTTDCongHoRanh_CauTaoTamDanTruyenDanTamDanTieuChuan == searchData.TTTDCongHoRanh_CauTaoTamDanTruyenDanTamDanTieuChuan &&
                                    pltdtd.TTTDCongHoRanh_CDai == searchData.TTTDCongHoRanh_CDai &&
                                    pltdtd.TTTDCongHoRanh_CRong == searchData.TTTDCongHoRanh_CRong &&
                                    pltdtd.TTTDCongHoRanh_CCao == searchData.TTTDCongHoRanh_CCao
                                          ));
                var abc = query.ToQueryString(); 
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
        public async Task<PhanLoaiTDanTDan> GetNumberPhanLoai(PhanLoaiTDanTDan searchData)
        {
            try
            {
                using var context = _context.CreateDbContext();

                // Thực hiện lọc dữ liệu dựa trên các thuộc tính của searchData
                var query = context.PhanLoaiTDanTDans
                             .Where(pltdtd => (
                                    //pltdtd.ThongTinLyTrinhTruyenDan_TuLyTrinh == searchData.ThongTinLyTrinhTruyenDan_TuLyTrinh &&
                                    //pltdtd.ThongTinLyTrinhTruyenDan_DenLyTrinh == searchData.ThongTinLyTrinhTruyenDan_DenLyTrinh &&

                                    pltdtd.ThongTinDuongTruyenDan_HinhThucTruyenDan == searchData.ThongTinDuongTruyenDan_HinhThucTruyenDan &&
                                    pltdtd.ThongTinDuongTruyenDan_LoaiTruyenDan == searchData.ThongTinDuongTruyenDan_LoaiTruyenDan &&
                                    pltdtd.TTTDCongHoRanh_CauTaoTamDanTruyenDanTamDanTieuChuan == searchData.TTTDCongHoRanh_CauTaoTamDanTruyenDanTamDanTieuChuan 
                                          )).OrderByDescending(pltdtd => pltdtd.Loai);
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
        public async Task<PhanLoaiTDanTDan> GetPhanLoaiTDanTDanExist(PhanLoaiTDanTDan searchData)
        {
            try
            {
                using var context = _context.CreateDbContext();

                // Thực hiện lọc dữ liệu dựa trên các thuộc tính của searchData
                var query = context.PhanLoaiTDanTDans
                             .Where(pltdtd => (
                                    //pltdtd.ThongTinLyTrinhTruyenDan_TuLyTrinh == searchData.ThongTinLyTrinhTruyenDan_TuLyTrinh &&
                                    //pltdtd.ThongTinLyTrinhTruyenDan_DenLyTrinh == searchData.ThongTinLyTrinhTruyenDan_DenLyTrinh &&
                                    pltdtd.TTTDCongHoRanh_TenLoaiTamDanTieuChuan == searchData.TTTDCongHoRanh_TenLoaiTamDanTieuChuan ||
                                    pltdtd.ThongTinDuongTruyenDan_HinhThucTruyenDan == searchData.ThongTinDuongTruyenDan_HinhThucTruyenDan &&
                                    pltdtd.ThongTinDuongTruyenDan_LoaiTruyenDan == searchData.ThongTinDuongTruyenDan_LoaiTruyenDan &&
                                    pltdtd.TTTDCongHoRanh_CauTaoTamDanTruyenDanTamDanTieuChuan == searchData.TTTDCongHoRanh_CauTaoTamDanTruyenDanTamDanTieuChuan &&
                                    pltdtd.TTTDCongHoRanh_CDai == searchData.TTTDCongHoRanh_CDai &&
                                    pltdtd.TTTDCongHoRanh_CRong == searchData.TTTDCongHoRanh_CRong &&
                                    pltdtd.TTTDCongHoRanh_CCao == searchData.TTTDCongHoRanh_CCao
                                          ));
                var abc = query.ToQueryString();
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

        public async Task Update(PhanLoaiTDanTDan PhanLoaiTDanTDan,string userId)
        {
            using var context = _context.CreateDbContext();
            var entity = GetById(PhanLoaiTDanTDan.Id);

            if (entity == null)
            {
                throw new Exception($"Không tìm thấy bản ghi theo ID: {PhanLoaiTDanTDan.Id}");
            }

            context.PhanLoaiTDanTDans.Update(PhanLoaiTDanTDan);
            await context.SaveChangesAsync();
        }
        public async Task UpdateMulti(PhanLoaiTDanTDan[] PhanLoaiTDanTDan)
        {
            using var context = _context.CreateDbContext();
            string[] ids = PhanLoaiTDanTDan.Select(x => x.Id).ToArray();
            var listEntities = await context.PhanLoaiTDanTDans.Where(x => ids.Contains(x.Id)).ToListAsync();
            foreach (var entity in listEntities)
            {
                context.PhanLoaiTDanTDans.Update(entity);
            }
            await context.SaveChangesAsync();
        }
        public async Task DeleteById(string id, string userId)
        {
            using var context = _context.CreateDbContext();
            var entity = await GetById(id);

            if (entity == null)
            {
                throw new Exception($"Không tìm thấy bản ghi theo ID: {id}");
            }

            context.Set<PhanLoaiTDanTDan>().Remove(entity);
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
        public async Task<PhanLoaiTDanTDan> GetById(string id)
        {
            using var context = _context.CreateDbContext();
            var entity = await context.PhanLoaiTDanTDans.Where(x => x.Id.Equals(id)).FirstOrDefaultAsync();

            if (entity == null)
            {
                throw new Exception($"Không tìm thấy bản ghi theo ID: {id}");
            }

            return entity;
        }
        public async Task Insert(PhanLoaiTDanTDan entity, string userId)
        {
            try
            {
                using var context = _context.CreateDbContext();
                if (entity == null)
                {
                    throw new Exception("Không có bản ghi nào để thêm!");
                }

                // Kiểm tra xem bảng có bản ghi nào không
                var maxFlag = await context.PhanLoaiTDanTDans.AnyAsync()
                              ? await context.PhanLoaiTDanTDans.MaxAsync(x => x.Flag)
                              : 0;

                // Tăng giá trị Flag lên 1
                entity.Flag = maxFlag + 1;
                if (string.IsNullOrEmpty(entity.TTTDCongHoRanh_TenLoaiTamDanTieuChuan))
                {
                    entity.TTTDCongHoRanh_TenLoaiTamDanTieuChuan = "Tấm đan tiêu chuẩn loại  " + entity.Flag;
                }
              

                // Chèn bản ghi mới vào bảng
                context.PhanLoaiTDanTDans.Add(entity);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public async Task<string> InsertId(PhanLoaiTDanTDan entity, string HTTD , string LTD,string CTTDTC, string PhanLoai)
        {
            try
            {
                using var context = _context.CreateDbContext();

                if (entity == null)
                {
                    throw new Exception("Không có bản ghi nào để thêm!");
                }

                // Kiểm tra xem bảng có bản ghi nào không
                var maxFlag = await context.PhanLoaiTDanTDans.AnyAsync()
                              ? await context.PhanLoaiTDanTDans.MaxAsync(x => x.Flag)
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
                if (PhanLoai == "Tấm đan tiêu chuẩn")
                {
                    entity.TTTDCongHoRanh_TenLoaiTamDanTieuChuan = "Tấm đan tiêu chuẩn loại " + entity.Loai + " " + HTTD + " " + LTD + " " + CTTDTC;
                }
                else
                {
                    entity.TTTDCongHoRanh_TenLoaiTamDanTieuChuan = "Tấm đan bổ sung loại " + entity.Loai + " " + HTTD + " " + LTD + " " + CTTDTC;
                }
                

                // Chèn bản ghi mới vào bảng
                context.PhanLoaiTDanTDans.Add(entity);
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
        public async Task<string> InsertLaterFlag(PhanLoaiTDanTDan entity, int FlagLast)
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
                var recordsToUpdate = await context.PhanLoaiTDanTDans
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
                    var maxFlag = await context.PhanLoaiTDanTDans.AnyAsync()
                                  ? await context.PhanLoaiTDanTDans.MaxAsync(x => x.Flag)
                                  : 0;

                    // Tăng giá trị Flag lên 1
                    entity.Flag = maxFlag + 1;
                }
                else
                {
                    entity.Flag = FlagLast + 1;
                }


                // Kiểm tra và gán giá trị nếu trường ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop rỗng
                if (string.IsNullOrEmpty(entity.TTTDCongHoRanh_TenLoaiTamDanTieuChuan))
                {
                    entity.TTTDCongHoRanh_TenLoaiTamDanTieuChuan = "Tấm đan tiêu chuẩn loại " + entity.Flag;
                }

                // Bước 4: Chèn bản ghi mới vào bảng
                context.PhanLoaiTDanTDans.Add(entity);

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
