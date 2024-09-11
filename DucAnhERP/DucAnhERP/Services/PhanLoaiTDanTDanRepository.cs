using DucAnhERP.Data;
using DucAnhERP.Models;
using DucAnhERP.Repository;
using DucAnhERP.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace DucAnhERP.Services
{
    public class PhanLoaiTDanTDanRepository : IPhanLoaiTDanTDanRepository
    {
        private readonly IDbContextFactory<ApplicationDbContext> _context;

        public PhanLoaiTDanTDanRepository(IDbContextFactory<ApplicationDbContext> context)
        {
            _context = context;
        }

        public async Task<List<PhanLoaiTDanTDan>> GetAll()
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

        public async Task<List<PhanLoaiTDanTDanModel>> GetAllByVM()
        {
            try
            {
                using var context = _context.CreateDbContext();
                var query = from pltdtd in context.PhanLoaiTDanTDans
                            orderby pltdtd.CreateAt
                            select new PhanLoaiTDanTDanModel
                            {
                                Id = pltdtd.Id,
                                TTTDCongHoRanh_TenLoaiTamDanTieuChuan = pltdtd.TTTDCongHoRanh_TenLoaiTamDanTieuChuan,
                                ThongTinLyTrinhTruyenDan_TuLyTrinh = pltdtd.ThongTinLyTrinhTruyenDan_TuLyTrinh,
                                ThongTinLyTrinhTruyenDan_DenLyTrinh = pltdtd.ThongTinLyTrinhTruyenDan_DenLyTrinh,
                                ThongTinDuongTruyenDan_HinhThucTruyenDan = pltdtd.ThongTinDuongTruyenDan_HinhThucTruyenDan,
                                ThongTinDuongTruyenDan_LoaiTruyenDan = pltdtd.ThongTinDuongTruyenDan_LoaiTruyenDan,
                                TTTDCongHoRanh_CauTaoTamDanTruyenDanTamDanTieuChuan = pltdtd.TTTDCongHoRanh_CauTaoTamDanTruyenDanTamDanTieuChuan,
                                TTTDCongHoRanh_CDai = pltdtd.TTTDCongHoRanh_CDai,
                                TTTDCongHoRanh_CRong = pltdtd.TTTDCongHoRanh_CRong,
                                TTTDCongHoRanh_CCao = pltdtd.TTTDCongHoRanh_CCao,
                                CreateAt = pltdtd.CreateAt,
                                CreateBy = pltdtd.CreateBy,
                                IsActive = pltdtd.IsActive,
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

        public async Task<PhanLoaiTDanTDan> GetPhanLoaiTDanTDanByDetail(PhanLoaiTDanTDan searchData)
        {
            try
            {
                using var context = _context.CreateDbContext();

                // Thực hiện lọc dữ liệu dựa trên các thuộc tính của searchData
                var query = context.PhanLoaiTDanTDans
                             .Where(pltdtd => (
                                    pltdtd.ThongTinLyTrinhTruyenDan_TuLyTrinh == pltdtd.ThongTinLyTrinhTruyenDan_TuLyTrinh &&
                                    pltdtd.ThongTinLyTrinhTruyenDan_DenLyTrinh == pltdtd.ThongTinLyTrinhTruyenDan_DenLyTrinh &&
                                    pltdtd.ThongTinDuongTruyenDan_HinhThucTruyenDan == pltdtd.ThongTinDuongTruyenDan_HinhThucTruyenDan &&
                                    pltdtd.ThongTinDuongTruyenDan_LoaiTruyenDan == pltdtd.ThongTinDuongTruyenDan_LoaiTruyenDan &&
                                    pltdtd.TTTDCongHoRanh_CauTaoTamDanTruyenDanTamDanTieuChuan == pltdtd.TTTDCongHoRanh_CauTaoTamDanTruyenDanTamDanTieuChuan &&
                                    pltdtd.TTTDCongHoRanh_CDai == pltdtd.TTTDCongHoRanh_CDai &&
                                    pltdtd.TTTDCongHoRanh_CRong == pltdtd.TTTDCongHoRanh_CRong &&
                                    pltdtd.TTTDCongHoRanh_CCao == pltdtd.TTTDCongHoRanh_CCao
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

        public async Task Update(PhanLoaiTDanTDan PhanLoaiTDanTDan)
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

        public async Task DeleteById(string id)
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

        public async Task Insert(PhanLoaiTDanTDan entity)
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
                entity.TTTDCongHoRanh_TenLoaiTamDanTieuChuan = "Tấm đan tiêu chuẩn loại  " + entity.Flag;

                // Chèn bản ghi mới vào bảng
                context.PhanLoaiTDanTDans.Add(entity);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public async Task<string> InsertId(PhanLoaiTDanTDan entity, string HTTD , string LTD,string CTTDTC)
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
                entity.TTTDCongHoRanh_TenLoaiTamDanTieuChuan = "Tấm đan tiêu chuẩn loại " + entity.Flag + HTTD +" "+ LTD+" "+ CTTDTC;

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
    }
}
