using DucAnhERP.Data;
using DucAnhERP.Models;
using DucAnhERP.Repository;
using DucAnhERP.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace DucAnhERP.Services
{
    public class PhanLoaiCTronHopNhuaRepository : IPhanLoaiCTronHopNhuaRepository
    {
        private readonly IDbContextFactory<ApplicationDbContext> _context;

        public PhanLoaiCTronHopNhuaRepository(IDbContextFactory<ApplicationDbContext> context)
        {
            _context = context;
        }

        public async Task<List<PhanLoaiCTronHopNhua>> GetAll()
        {
            try
            {
                using var context = _context.CreateDbContext();
                var entity = await context.PhanLoaiCTronHopNhuas.ToListAsync();
                return entity;
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.Error.WriteLine($"An error occurred: {ex.Message}");
                throw; // Optionally rethrow the exception
            }
        }
        public async Task<List<PhanLoaiCTronHopNhuaModel>> GetAllByVM()
        {
            try
            {
                using var context = _context.CreateDbContext();
               
                var query = from plCong in context.PhanLoaiCTronHopNhuas
                            join ds in context.DSNuocMua
                                on plCong.Id equals ds.ThongTinDuongTruyenDan_HinhThucTruyenDan into dsJoin
                            from ds in dsJoin.DefaultIfEmpty()
                            join hinhThucTruyenDan in context.DSDanhMuc
                                on plCong.ThongTinDuongTruyenDan_HinhThucTruyenDan equals hinhThucTruyenDan.Id
                            join danhmucLoaiTruyenDan in context.DSDanhMuc
                                on plCong.ThongTinDuongTruyenDan_LoaiTruyenDan equals danhmucLoaiTruyenDan.Id
                            join danhmucCauTaoTuong in context.DSDanhMuc
                                on plCong.TTKTHHCongHopRanh_CauTaoTuong equals danhmucCauTaoTuong.Id into gj1
                            from danhmucCauTaoTuong in gj1.DefaultIfEmpty() // Left join

                            join danhmucCauTaoMuMo in context.DSDanhMuc
                                on plCong.TTKTHHCongHopRanh_CauTaoMuMo equals danhmucCauTaoMuMo.Id into mm
                            from danhmucCauTaoMuMo in mm.DefaultIfEmpty() // Left join

                            join danhmucChatMatTrong in context.DSDanhMuc
                                on plCong.TTKTHHCongHopRanh_ChatMatTrong equals danhmucChatMatTrong.Id into gj2
                            from danhmucChatMatTrong in gj2.DefaultIfEmpty() // Left join
                            join danhmucChatMatNgoai in context.DSDanhMuc
                                on plCong.TTKTHHCongHopRanh_ChatMatNgoai equals danhmucChatMatNgoai.Id into gj3
                            from danhmucChatMatNgoai in gj3.DefaultIfEmpty() // Left join
                            orderby plCong.Flag
                            select new PhanLoaiCTronHopNhuaModel
                            {
                                Id = plCong.Id,
                                IsEdit = ds != null && ds.ThongTinDuongTruyenDan_HinhThucTruyenDan != null ? 1 : 0,
                                ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai = plCong.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai,
                                ThongTinDuongTruyenDan_HinhThucTruyenDan = plCong.ThongTinDuongTruyenDan_HinhThucTruyenDan,
                                ThongTinDuongTruyenDan_HinhThucTruyenDan_Name = hinhThucTruyenDan.Ten,
                                ThongTinDuongTruyenDan_LoaiTruyenDan = plCong.ThongTinDuongTruyenDan_LoaiTruyenDan,
                                ThongTinDuongTruyenDan_LoaiTruyenDan_Name = danhmucLoaiTruyenDan.Ten,
                                TTCDSLCauKienDuongTruyenDan_ChieuDai01CauKien = plCong.TTCDSLCauKienDuongTruyenDan_ChieuDai01CauKien,
                                ThongTinCauTaoCongTron_CDayPhuBi = plCong.ThongTinCauTaoCongTron_CDayPhuBi,
                                TTKTHHCongHopRanh_CauTaoTuong = plCong.TTKTHHCongHopRanh_CauTaoTuong,
                                TTKTHHCongHopRanh_CauTaoTuong_Name = danhmucCauTaoTuong != null ? danhmucCauTaoTuong.Ten : string.Empty,
                                TTKTHHCongHopRanh_CauTaoMuMo = plCong.TTKTHHCongHopRanh_CauTaoMuMo ,
                                TTKTHHCongHopRanh_CauTaoMuMo_Name = danhmucCauTaoMuMo != null ? danhmucCauTaoMuMo.Ten : string.Empty,
                                TTKTHHCongHopRanh_ChatMatTrong = plCong.TTKTHHCongHopRanh_ChatMatTrong,
                                TTKTHHCongHopRanh_ChatMatTrong_Name = danhmucChatMatTrong != null ? danhmucChatMatTrong.Ten : string.Empty,
                                TTKTHHCongHopRanh_ChatMatNgoai = plCong.TTKTHHCongHopRanh_ChatMatNgoai,
                                TTKTHHCongHopRanh_ChatMatNgoai_Name = danhmucChatMatNgoai != null ? danhmucChatMatNgoai.Ten : string.Empty,
                                TTKTHHCongHopRanh_CCaoDe = plCong.TTKTHHCongHopRanh_CCaoDe,
                                TTKTHHCongHopRanh_CRongDe = plCong.TTKTHHCongHopRanh_CRongDe,
                                TTKTHHCongHopRanh_CDayTuong01Ben = plCong.TTKTHHCongHopRanh_CDayTuong01Ben,
                                TTKTHHCongHopRanh_SoLuongTuong = plCong.TTKTHHCongHopRanh_SoLuongTuong,
                                TTKTHHCongHopRanh_CRongLongSuDung = plCong.TTKTHHCongHopRanh_CRongLongSuDung,
                                TTKTHHCongHopRanh_CCaoTuongGop = plCong.TTKTHHCongHopRanh_CCaoTuongGop,
                                TTKTHHCongHopRanh_CCaoMuMoThotDuoi = plCong.TTKTHHCongHopRanh_CCaoMuMoThotDuoi,
                                TTKTHHCongHopRanh_CRongMuMoDuoi = plCong.TTKTHHCongHopRanh_CRongMuMoDuoi,
                                TTKTHHCongHopRanh_CCaoMuMoThotTren = plCong.TTKTHHCongHopRanh_CCaoMuMoThotTren,
                                TTKTHHCongHopRanh_CRongMuMoTren = plCong.TTKTHHCongHopRanh_CRongMuMoTren,
                                TTKTHHCongHopRanh_CCaoChatMatTrong = plCong.TTKTHHCongHopRanh_CCaoChatMatTrong,
                                TTKTHHCongHopRanh_CCaoChatMatNgoai = plCong.TTKTHHCongHopRanh_CCaoChatMatNgoai,
                                ThongTinKichThuocHinhHocOngNhua_CDayPhuBi = plCong.ThongTinKichThuocHinhHocOngNhua_CDayPhuBi,
                                Flag=plCong.Flag,
                                CreateAt = plCong.CreateAt,
                                CreateBy = plCong.CreateBy,
                                IsActive = plCong.IsActive,
                            };


                var data = await query
                    .ToListAsync();
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi tải dữ liệu: {ex.Message}");
            }

        }
        public async Task<bool> CheckUsingId(string id)
        {
            bool isSuccess = false;
            using var context = _context.CreateDbContext();
            var query = context.DSNuocMua
                         .Where(hrt => (hrt.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai == id));

            var data = await query.ToListAsync();

            // Kiểm tra nếu danh sách kết quả rỗng hoặc không có dữ liệu khớp
            isSuccess = data.Any();
            return (isSuccess);
        }
        public async Task<bool> CheckUsingName(string name)
        {
            bool isSuccess = false;
            using var context = _context.CreateDbContext();
            var query = context.PhanLoaiCTronHopNhuas
                         .Where(item => (item.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai.ToUpper().Trim() == name.ToUpper().Trim()));

            var data = await query.ToListAsync();

            // Kiểm tra nếu danh sách kết quả rỗng hoặc không có dữ liệu khớp
            isSuccess = data.Any();
            return (isSuccess);
        }
        public async Task<PhanLoaiCTronHopNhua> GetPhanLoaiCTronHopNhuaByDetail(PhanLoaiCTronHopNhua searchData)
        {
            try
            {
                using var context = _context.CreateDbContext();

                // Thực hiện lọc dữ liệu dựa trên các thuộc tính của searchData
                var query = context.PhanLoaiCTronHopNhuas
                             .Where(plCong => (
                                 plCong.ThongTinDuongTruyenDan_HinhThucTruyenDan == searchData.ThongTinDuongTruyenDan_HinhThucTruyenDan &&
                                 plCong.ThongTinDuongTruyenDan_LoaiTruyenDan == searchData.ThongTinDuongTruyenDan_LoaiTruyenDan &&
                                 plCong.TTCDSLCauKienDuongTruyenDan_ChieuDai01CauKien == searchData.TTCDSLCauKienDuongTruyenDan_ChieuDai01CauKien &&
                                 plCong.ThongTinCauTaoCongTron_CDayPhuBi == searchData.ThongTinCauTaoCongTron_CDayPhuBi &&
                                 plCong.TTKTHHCongHopRanh_CauTaoTuong == searchData.TTKTHHCongHopRanh_CauTaoTuong &&
                                 plCong.TTKTHHCongHopRanh_ChatMatTrong == searchData.TTKTHHCongHopRanh_ChatMatTrong &&
                                 plCong.TTKTHHCongHopRanh_ChatMatNgoai == searchData.TTKTHHCongHopRanh_ChatMatNgoai &&
                                 plCong.TTKTHHCongHopRanh_CCaoDe == searchData.TTKTHHCongHopRanh_CCaoDe &&
                                 plCong.TTKTHHCongHopRanh_CRongDe == searchData.TTKTHHCongHopRanh_CRongDe &&
                                 plCong.TTKTHHCongHopRanh_CDayTuong01Ben == searchData.TTKTHHCongHopRanh_CDayTuong01Ben &&
                                 plCong.TTKTHHCongHopRanh_SoLuongTuong == searchData.TTKTHHCongHopRanh_SoLuongTuong &&
                                 plCong.TTKTHHCongHopRanh_CRongLongSuDung == searchData.TTKTHHCongHopRanh_CRongLongSuDung &&
                                 plCong.TTKTHHCongHopRanh_CCaoTuongGop == searchData.TTKTHHCongHopRanh_CCaoTuongGop &&
                                 plCong.TTKTHHCongHopRanh_CCaoMuMoThotDuoi == searchData.TTKTHHCongHopRanh_CCaoMuMoThotDuoi &&
                                 plCong.TTKTHHCongHopRanh_CRongMuMoDuoi == searchData.TTKTHHCongHopRanh_CRongMuMoDuoi &&
                                 plCong.TTKTHHCongHopRanh_CCaoMuMoThotTren == searchData.TTKTHHCongHopRanh_CCaoMuMoThotTren &&
                                 plCong.TTKTHHCongHopRanh_CRongMuMoTren == searchData.TTKTHHCongHopRanh_CRongMuMoTren &&
                                 plCong.TTKTHHCongHopRanh_CCaoChatMatTrong == searchData.TTKTHHCongHopRanh_CCaoChatMatTrong &&
                                 plCong.TTKTHHCongHopRanh_CCaoChatMatNgoai == searchData.TTKTHHCongHopRanh_CCaoChatMatNgoai &&
                                 plCong.ThongTinKichThuocHinhHocOngNhua_CDayPhuBi == searchData.ThongTinKichThuocHinhHocOngNhua_CDayPhuBi
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
        public async Task<PhanLoaiCTronHopNhua> GetNumberPhanLoai(PhanLoaiCTronHopNhua searchData)
        {
            try
            {
                using var context = _context.CreateDbContext();

                // Thực hiện lọc dữ liệu dựa trên các thuộc tính của searchData
                var query = context.PhanLoaiCTronHopNhuas
                 .Where(plCong => (
                     plCong.ThongTinDuongTruyenDan_HinhThucTruyenDan == searchData.ThongTinDuongTruyenDan_HinhThucTruyenDan &&
                     plCong.ThongTinDuongTruyenDan_LoaiTruyenDan == searchData.ThongTinDuongTruyenDan_LoaiTruyenDan &&
                     plCong.TTCDSLCauKienDuongTruyenDan_ChieuDai01CauKien == searchData.TTCDSLCauKienDuongTruyenDan_ChieuDai01CauKien
                              ))
                 .OrderByDescending(plCong => plCong.Loai);


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
        public async Task<PhanLoaiCTronHopNhua> GetPhanLoaiCTronHopNhuaExist(PhanLoaiCTronHopNhua searchData)
        {
            try
            {
                using var context = _context.CreateDbContext();

                // Thực hiện lọc dữ liệu dựa trên các thuộc tính của searchData
                var query = context.PhanLoaiCTronHopNhuas
                             .Where(plCong => (
                                plCong.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai == searchData.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai ||
                                 plCong.ThongTinDuongTruyenDan_HinhThucTruyenDan == searchData.ThongTinDuongTruyenDan_HinhThucTruyenDan &&
                                 plCong.ThongTinDuongTruyenDan_LoaiTruyenDan == searchData.ThongTinDuongTruyenDan_LoaiTruyenDan &&
                                 plCong.TTCDSLCauKienDuongTruyenDan_ChieuDai01CauKien == searchData.TTCDSLCauKienDuongTruyenDan_ChieuDai01CauKien &&
                                 plCong.ThongTinCauTaoCongTron_CDayPhuBi == searchData.ThongTinCauTaoCongTron_CDayPhuBi &&
                                 plCong.TTKTHHCongHopRanh_CauTaoTuong == searchData.TTKTHHCongHopRanh_CauTaoTuong &&
                                 plCong.TTKTHHCongHopRanh_ChatMatTrong == searchData.TTKTHHCongHopRanh_ChatMatTrong &&
                                 plCong.TTKTHHCongHopRanh_ChatMatNgoai == searchData.TTKTHHCongHopRanh_ChatMatNgoai &&
                                 plCong.TTKTHHCongHopRanh_CCaoDe == searchData.TTKTHHCongHopRanh_CCaoDe &&
                                 plCong.TTKTHHCongHopRanh_CRongDe == searchData.TTKTHHCongHopRanh_CRongDe &&
                                 plCong.TTKTHHCongHopRanh_CDayTuong01Ben == searchData.TTKTHHCongHopRanh_CDayTuong01Ben &&
                                 plCong.TTKTHHCongHopRanh_SoLuongTuong == searchData.TTKTHHCongHopRanh_SoLuongTuong &&
                                 plCong.TTKTHHCongHopRanh_CRongLongSuDung == searchData.TTKTHHCongHopRanh_CRongLongSuDung &&
                                 plCong.TTKTHHCongHopRanh_CCaoTuongGop == searchData.TTKTHHCongHopRanh_CCaoTuongGop &&
                                 plCong.TTKTHHCongHopRanh_CCaoMuMoThotDuoi == searchData.TTKTHHCongHopRanh_CCaoMuMoThotDuoi &&
                                 plCong.TTKTHHCongHopRanh_CRongMuMoDuoi == searchData.TTKTHHCongHopRanh_CRongMuMoDuoi &&
                                 plCong.TTKTHHCongHopRanh_CCaoMuMoThotTren == searchData.TTKTHHCongHopRanh_CCaoMuMoThotTren &&
                                 plCong.TTKTHHCongHopRanh_CRongMuMoTren == searchData.TTKTHHCongHopRanh_CRongMuMoTren &&
                                 plCong.TTKTHHCongHopRanh_CCaoChatMatTrong == searchData.TTKTHHCongHopRanh_CCaoChatMatTrong &&
                                 plCong.TTKTHHCongHopRanh_CCaoChatMatNgoai == searchData.TTKTHHCongHopRanh_CCaoChatMatNgoai &&
                                 plCong.ThongTinKichThuocHinhHocOngNhua_CDayPhuBi == searchData.ThongTinKichThuocHinhHocOngNhua_CDayPhuBi
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
        public async Task Update(PhanLoaiCTronHopNhua PhanLoaiCTronHopNhua)
        {
            using var context = _context.CreateDbContext();
            var entity = GetById(PhanLoaiCTronHopNhua.Id);

            if (entity == null)
            {
                throw new Exception($"Không tìm thấy bản ghi theo ID: {PhanLoaiCTronHopNhua.Id}");
            }

            context.PhanLoaiCTronHopNhuas.Update(PhanLoaiCTronHopNhua);
            await context.SaveChangesAsync();
        }
        public async Task UpdateMulti(PhanLoaiCTronHopNhua[] PhanLoaiCTronHopNhua)
        {
            using var context = _context.CreateDbContext();
            string[] ids = PhanLoaiCTronHopNhua.Select(x => x.Id).ToArray();
            var listEntities = await context.PhanLoaiCTronHopNhuas.Where(x => ids.Contains(x.Id)).ToListAsync();
            foreach (var entity in listEntities)
            {
                context.PhanLoaiCTronHopNhuas.Update(entity);
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

            context.Set<PhanLoaiCTronHopNhua>().Remove(entity);
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
        public async Task<PhanLoaiCTronHopNhua> GetById(string id)
        {
            using var context = _context.CreateDbContext();
            var entity = await context.PhanLoaiCTronHopNhuas.Where(x => x.Id.Equals(id)).FirstOrDefaultAsync();

            if (entity == null)
            {
                throw new Exception($"Không tìm thấy bản ghi theo ID: {id}");
            }

            return entity;
        }
        public async Task Insert(PhanLoaiCTronHopNhua entity)
        {
            try
            {
                using var context = _context.CreateDbContext();
                if (entity == null)
                {
                    throw new Exception("Không có bản ghi nào để thêm!");
                }

                // Kiểm tra xem bảng có bản ghi nào không
                var maxFlag = await context.PhanLoaiCTronHopNhuas.AnyAsync()
                              ? await context.PhanLoaiCTronHopNhuas.MaxAsync(x => x.Flag)
                              : 0;

                // Tăng giá trị Flag lên 1
                entity.Flag = maxFlag + 1;
                if (string.IsNullOrEmpty(entity.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai))
                {
                    entity.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai = " loại " + entity.Flag;
                }
                

                // Chèn bản ghi mới vào bảng
                context.PhanLoaiCTronHopNhuas.Add(entity);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public async Task<string> InsertLaterFlag(PhanLoaiCTronHopNhua entity, int FlagLast)
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
                var recordsToUpdate = await context.PhanLoaiCTronHopNhuas
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
                    var maxFlag = await context.PhanLoaiCTronHopNhuas.AnyAsync()
                                  ? await context.PhanLoaiCTronHopNhuas.MaxAsync(x => x.Flag)
                                  : 0;

                    // Tăng giá trị Flag lên 1
                    entity.Flag = maxFlag + 1;
                }
                else
                {
                    entity.Flag = FlagLast + 1;
                }


                // Kiểm tra và gán giá trị nếu trường ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop rỗng
                if (string.IsNullOrEmpty(entity.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai))
                {
                    entity.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai = "loại " + entity.Flag;
                }

                // Bước 4: Chèn bản ghi mới vào bảng
                context.PhanLoaiCTronHopNhuas.Add(entity);

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
        public async Task<string> InsertId(PhanLoaiCTronHopNhua entity, string HinhThucTD, string LoaiTD)
        {
            try
            {
                using var context = _context.CreateDbContext();

                if (entity == null)
                {
                    throw new Exception("Không có bản ghi nào để thêm!");
                }

                // Kiểm tra xem bảng có bản ghi nào không
                var maxFlag = await context.PhanLoaiCTronHopNhuas.AnyAsync()
                              ? await context.PhanLoaiCTronHopNhuas.MaxAsync(x => x.Flag)
                              : 0;

                // Tăng giá trị Flag lên 1
                entity.Flag = maxFlag + 1;

                // Kiểm tra xem bảng có bản ghi nào không
                var maxLoai =  await GetNumberPhanLoai(entity);
                if (maxLoai != null) {
                    // Tăng giá trị Flag lên 1
                    entity.Loai = (maxLoai.Loai??0 ) + 1;
                }
                else
                {
                    entity.Loai = 1;
                }
                if(entity.TTCDSLCauKienDuongTruyenDan_ChieuDai01CauKien > 0)
                {
                    entity.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai = HinhThucTD + " " + LoaiTD + " loại " + entity.Loai + " ,L=" + entity.TTCDSLCauKienDuongTruyenDan_ChieuDai01CauKien + "m";
                }
                else
                {
                    entity.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai = HinhThucTD + " " + LoaiTD + " loại " + entity.Loai ;
                }
                

                // Chèn bản ghi mới vào bảng
                context.PhanLoaiCTronHopNhuas.Add(entity);
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
