using DucAnhERP.Data;
using DucAnhERP.Models;
using DucAnhERP.Repository;
using DucAnhERP.ViewModel;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;

namespace DucAnhERP.Services
{
    public class PKKLTDanRBTRepository :IPKKLTDanRBTRepository
    {
        private readonly IDbContextFactory<ApplicationDbContext> _context;
        public PKKLTDanRBTRepository(IDbContextFactory<ApplicationDbContext> context)
        {
            _context = context;
        }
        public async Task<List<PKKLTDanRBT>> GetAll()
        {
            try
            {
                using var context = _context.CreateDbContext();
                var entity = await context.PKKLTDanRBTs.ToListAsync();
                return entity;
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.Error.WriteLine($"An error occurred: {ex.Message}");
                throw; // Optionally rethrow the exception
            }
        }
        public async Task<PKKLTDanRBT> GetById(string id)
        {
            using var context = _context.CreateDbContext();
            var entity = await context.PKKLTDanRBTs.Where(x => x.Id.Equals(id)).FirstOrDefaultAsync();

            if (entity == null)
            {
                throw new Exception($"Không tìm thấy bản ghi theo ID: {id}");
            }

            return entity;
        }
        public async Task<List<PKKLModel>> GetAllByVM(PKKLModel mModel)
        {
            try
            {
                using var context = _context.CreateDbContext();
                List<PKKLModel> data = new();
                var query = from a in context.PKKLTDanRBTs
                            join b in context.PhanLoaiTDanTDans
                            on a.TTTDCongHoRanh_TenLoaiTamDanTieuChuan equals b.Id
                            orderby a.HangMuc ascending, a.CreateAt ascending
                            select new PKKLModel
                            {
                                Id = a.Id,
                                LoaiCauKien = b.TTTDCongHoRanh_TenLoaiTamDanTieuChuan ?? "",
                                LoaiCauKienId = a.TTTDCongHoRanh_TenLoaiTamDanTieuChuan,
                                LoaiBeTong = a.LoaiBeTong,
                                HangMuc = a.HangMuc,
                                HangMucCongTac = a.HangMucCongTac,
                                TenCongTac = a.TenCongTac,
                                DonVi = a.DonVi,
                                KTHH_D = a.KTHH_D,
                                KTHH_R = a.KTHH_R,
                                KTHH_C = a.KTHH_C,
                                KTHH_DienTich = a.KTHH_DienTich,
                                KTHH_GhiChu = a.KTHH_GhiChu,
                                KTHH_SLCauKien = a.KTHH_SLCauKien,
                                KTHH_KL1CK = a.KTHH_KL1CK,
                                TTCDT_CDai = a.TTCDT_CDai,
                                TTCDT_CRong = a.TTCDT_CRong,
                                TTCDT_CDay = a.TTCDT_CDay,
                                TTCDT_DienTich = a.TTCDT_DienTich,
                                TTCDT_SLCK = a.TTCDT_SLCK,
                                TTCDT_KL = a.TTCDT_KL,
                                KLKP_Sl = a.KLKP_Sl,
                                KL1CK_ChuaTruCC = a.KL1CK_ChuaTruCC,
                                KLCC1CK = a.KLCC1CK,
                                TKLCK_SauCC = a.TKLCK_SauCC
                            };

                data = query.ToList();
                return data;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }

        }
        public async Task<Double> GetSumTKLCK_SauCC(PKKLTDanRBT input)
        {
            try
            {
                double sumTKLCK_SauCC = 0;
                using var context = _context.CreateDbContext();
                sumTKLCK_SauCC = context.PKKLTDanRBTs.Where(item => item.TTTDCongHoRanh_TenLoaiTamDanTieuChuan == input.TTTDCongHoRanh_TenLoaiTamDanTieuChuan
                          && item.HangMuc == "I.Móng cống tròn"
                          && item.LoaiBeTong == input.LoaiBeTong).Sum(item => item.TKLCK_SauCC);
                return sumTKLCK_SauCC;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }
        public async Task<List<THKLModel>> GetTHKLTDanRBT()
        {
            try
            {
                using var context = _context.CreateDbContext();
                var query = (from a in context.PKKLTDanRBTs
                             join b in context.PhanLoaiTDanTDans
                             on a.TTTDCongHoRanh_TenLoaiTamDanTieuChuan equals b.Id
                             let kl1Dv = context.PKKLTDanRBTs
                                 .Where(x => x.TTTDCongHoRanh_TenLoaiTamDanTieuChuan == a.TTTDCongHoRanh_TenLoaiTamDanTieuChuan
                                          && x.LoaiBeTong == a.LoaiBeTong
                                          && x.HangMuc == a.HangMuc
                                          && x.HangMucCongTac == a.HangMucCongTac
                                          && x.TenCongTac == a.TenCongTac)
                                 .Sum(x => x.TKLCK_SauCC)
                             orderby b.TTTDCongHoRanh_TenLoaiTamDanTieuChuan, a.HangMuc, a.CreateAt
                             select new THKLModel
                             {
                                 PhanLoaiCTronHopNhua_TenLoaiTruyenDanSauPhanLoai = b.TTTDCongHoRanh_TenLoaiTamDanTieuChuan ?? "",
                                 ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai = a.TTTDCongHoRanh_TenLoaiTamDanTieuChuan,
                                 HangMucCongTac = a.HangMucCongTac,
                                 TenCongTac = a.TenCongTac,
                                 DonVi = a.DonVi,
                                 KL1DonVi = kl1Dv,

                             }).ToList();
                return query;
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.Error.WriteLine($"An error occurred: {ex.Message}");
                throw; // Optionally rethrow the exception
            }

        }
        public async Task<List<THKLModel>> GetTHKLByTuyenDuong(string TuyenDuong)
        {
            try
            {
                using var context = _context.CreateDbContext();
                var query = (from a in context.PKKLTDanRBTs
                             join b in context.PhanLoaiTDanTDans on a.TTTDCongHoRanh_TenLoaiTamDanTieuChuan equals b.Id
                             join c in context.DSNuocMua on a.TTTDCongHoRanh_TenLoaiTamDanTieuChuan
                             equals c.TTTDCongHoRanh_TenLoaiTamDanTieuChuan into cGroup
                             from c in cGroup.DefaultIfEmpty()
                             where c.ThongTinLyTrinh_TuyenDuong == TuyenDuong
                             group new { a, c } by new
                             {
                                 a.Id,
                                 b.TTTDCongHoRanh_TenLoaiTamDanTieuChuan,
                                 PhanLoaiCTronHopNhua_TenLoaiTruyenDanSauPhanLoai = c.TTTDCongHoRanh_TenLoaiTamDanTieuChuan,
                                 a.TenCongTac,
                                 a.DonVi,
                                 a.TKLCK_SauCC,
                                 a.HangMuc,
                                 a.CreateAt
                             } into g
                             orderby g.Key.PhanLoaiCTronHopNhua_TenLoaiTruyenDanSauPhanLoai, g.Key.HangMuc, g.Key.CreateAt
                             select new THKLModel
                             {
                                 Id = g.Key.Id,
                                 ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai = g.Key.TTTDCongHoRanh_TenLoaiTamDanTieuChuan,
                                 PhanLoaiCTronHopNhua_TenLoaiTruyenDanSauPhanLoai = g.Key.PhanLoaiCTronHopNhua_TenLoaiTruyenDanSauPhanLoai,
                                 TenCongTac = g.Key.TenCongTac,
                                 DonVi = g.Key.DonVi,
                                 KL1DonVi = g.Key.TKLCK_SauCC,
                                 SLTrai = g.Sum(x => x.c != null && x.c.TraiPhai == 0 ? x.c.TTCDSLCauKienDuongTruyenDan_SlCauKienTinhKl : 0) ?? 0,
                                 SLPhai = g.Sum(x => x.c != null && x.c.TraiPhai == 1 ? x.c.TTCDSLCauKienDuongTruyenDan_SlCauKienTinhKl : 0) ?? 0,
                                 SLTong = g.Sum(x => x.c != null && (x.c.TraiPhai == 0 || x.c.TraiPhai == 1) ? x.c.TTCDSLCauKienDuongTruyenDan_SlCauKienTinhKl : 0) ?? 0,
                                 KLTrai = g.Sum(x => x.c != null && x.c.TraiPhai == 0 ? x.c.TTCDSLCauKienDuongTruyenDan_SlCauKienTinhKl : 0) * g.Key.TKLCK_SauCC ?? 0,
                                 KLPhai = g.Sum(x => x.c != null && x.c.TraiPhai == 1 ? x.c.TTCDSLCauKienDuongTruyenDan_SlCauKienTinhKl : 0) * g.Key.TKLCK_SauCC ?? 0,
                                 KLTong = g.Sum(x => x.c != null && (x.c.TraiPhai == 0 || x.c.TraiPhai == 1) ? x.c.TTCDSLCauKienDuongTruyenDan_SlCauKienTinhKl : 0) * g.Key.TKLCK_SauCC ?? 0
                             }).ToList();
                return query;
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.Error.WriteLine($"An error occurred: {ex.Message}");
                throw; // Optionally rethrow the exception
            }

        }
        public async Task<List<THKLModel>> GetTHKLByTuyenDuong(List<NuocMuaModel> nuocMua)
        {
            try
            {
                using var context = _context.CreateDbContext();

                // Khởi tạo một danh sách để lưu kết quả
                List<THKLModel> finalResult = new List<THKLModel>();

                // Duyệt qua từng tuyến đường trong danh sách `nuocMua`
                foreach (var item in nuocMua)
                {

                    var query = await (from a in context.PKKLTDanRBTs
                                       join b in context.PhanLoaiTDanTDans
                                           on a.TTTDCongHoRanh_TenLoaiTamDanTieuChuan equals b.Id
                                       join c in context.DSNuocMua
                                           on a.TTTDCongHoRanh_TenLoaiTamDanTieuChuan equals c.TTTDCongHoRanh_TenLoaiTamDanTieuChuan into cGroup
                                       from c in cGroup.Where(c => c.ThongTinLyTrinh_TuyenDuong == item.ThongTinLyTrinh_TuyenDuong).DefaultIfEmpty()

                                       group new { a, b, c } by new
                                       {
                                           a.Id,
                                           a.TTTDCongHoRanh_TenLoaiTamDanTieuChuan,
                                           PhanLoaiCTronHopNhua_TenLoaiTruyenDanSauPhanLoai = b.TTTDCongHoRanh_TenLoaiTamDanTieuChuan,
                                           a.TenCongTac,
                                           a.DonVi,
                                           a.TKLCK_SauCC,
                                           a.HangMuc,
                                           a.CreateAt
                                       } into g
                                       orderby g.Key.PhanLoaiCTronHopNhua_TenLoaiTruyenDanSauPhanLoai, g.Key.HangMuc, g.Key.CreateAt
                                       select new THKLModel
                                       {
                                           Id = g.Key.Id,
                                           ThongTinLyTrinh_TuyenDuong = item.ThongTinLyTrinh_TuyenDuong,  // Thông tin cố định từ SQL
                                           ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai = g.Key.TTTDCongHoRanh_TenLoaiTamDanTieuChuan,
                                           PhanLoaiCTronHopNhua_TenLoaiTruyenDanSauPhanLoai = g.Key.PhanLoaiCTronHopNhua_TenLoaiTruyenDanSauPhanLoai, // Cố định tên loại từ SQL
                                           TenCongTac = g.Key.TenCongTac,
                                           DonVi = g.Key.DonVi,
                                           KL1DonVi = g.Key.TKLCK_SauCC,
                                           SLTrai = g.Sum(x => x.c != null && x.c.TraiPhai == 0 ? x.c.TTTDCongHoRanh_SoLuong : 0) ?? 0,
                                           SLPhai = g.Sum(x => x.c != null && x.c.TraiPhai == 1 ? x.c.TTTDCongHoRanh_SoLuong : 0) ?? 0,
                                           SLTong = g.Sum(x => x.c != null ? x.c.TTTDCongHoRanh_SoLuong : 0) ?? 0,
                                           KLTrai = g.Sum(x => x.c != null && x.c.TraiPhai == 0 ? x.c.TTTDCongHoRanh_SoLuong : 0) * g.Key.TKLCK_SauCC ?? 0,
                                           KLPhai = g.Sum(x => x.c != null && x.c.TraiPhai == 1 ? x.c.TTTDCongHoRanh_SoLuong : 0) * g.Key.TKLCK_SauCC ?? 0,
                                           KLTong = g.Sum(x => x.c != null ? x.c.TTTDCongHoRanh_SoLuong : 0) * g.Key.TKLCK_SauCC ?? 0
                                       }).ToListAsync();

                    var query1 = await (from a in context.PKKLTDanRBTs
                                        join b in context.PhanLoaiTDanTDans
                                            on a.TTTDCongHoRanh_TenLoaiTamDanTieuChuan equals b.Id
                                        join c in context.DSNuocMua
                                            on a.TTTDCongHoRanh_TenLoaiTamDanTieuChuan equals c.TTTDCongHoRanh_TenLoaiTamDanLoai02 into cGroup
                                        from c in cGroup.Where(c => c.ThongTinLyTrinh_TuyenDuong == item.ThongTinLyTrinh_TuyenDuong).DefaultIfEmpty()

                                        group new { a, b, c } by new
                                        {
                                            a.Id,
                                            a.TTTDCongHoRanh_TenLoaiTamDanTieuChuan,
                                            PhanLoaiCTronHopNhua_TenLoaiTruyenDanSauPhanLoai = b.TTTDCongHoRanh_TenLoaiTamDanTieuChuan,
                                            a.TenCongTac,
                                            a.DonVi,
                                            a.TKLCK_SauCC,
                                            a.HangMuc,
                                            a.CreateAt
                                        } into g
                                        orderby g.Key.PhanLoaiCTronHopNhua_TenLoaiTruyenDanSauPhanLoai, g.Key.HangMuc, g.Key.CreateAt
                                        select new THKLModel
                                        {
                                            Id = g.Key.Id,
                                            ThongTinLyTrinh_TuyenDuong = item.ThongTinLyTrinh_TuyenDuong,  // Thông tin cố định từ SQL
                                            ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai = g.Key.TTTDCongHoRanh_TenLoaiTamDanTieuChuan,
                                            PhanLoaiCTronHopNhua_TenLoaiTruyenDanSauPhanLoai = g.Key.PhanLoaiCTronHopNhua_TenLoaiTruyenDanSauPhanLoai, // Cố định tên loại từ SQL
                                            TenCongTac = g.Key.TenCongTac,
                                            DonVi = g.Key.DonVi,
                                            KL1DonVi = g.Key.TKLCK_SauCC,
                                            SLTrai = g.Sum(x => x.c != null && x.c.TraiPhai == 0 ? x.c.TTTDCongHoRanh_SoLuong1 : 0) ?? 0,
                                            SLPhai = g.Sum(x => x.c != null && x.c.TraiPhai == 1 ? x.c.TTTDCongHoRanh_SoLuong1 : 0) ?? 0,
                                            SLTong = g.Sum(x => x.c != null ? x.c.TTTDCongHoRanh_SoLuong1 : 0) ?? 0,
                                            KLTrai = g.Sum(x => x.c != null && x.c.TraiPhai == 0 ? x.c.TTTDCongHoRanh_SoLuong1 : 0) * g.Key.TKLCK_SauCC ?? 0,
                                            KLPhai = g.Sum(x => x.c != null && x.c.TraiPhai == 1 ? x.c.TTTDCongHoRanh_SoLuong1 : 0) * g.Key.TKLCK_SauCC ?? 0,
                                            KLTong = g.Sum(x => x.c != null ? x.c.TTTDCongHoRanh_SoLuong1 : 0) * g.Key.TKLCK_SauCC ?? 0
                                        }).ToListAsync();

                    if (query != null)
                    {
                        if (query1 != null)
                        {

                            foreach (var obj in query)
                            {
                                var matchingItem = query1.FirstOrDefault(x => x.Id == obj.Id);

                                if (matchingItem != null)
                                {
                                    obj.SLTrai += matchingItem.SLTrai;
                                    obj.SLPhai += matchingItem.SLPhai;
                                    obj.SLTong += matchingItem.SLTong;
                                    obj.KLTrai += matchingItem.KLTrai;
                                    obj.KLPhai += matchingItem.KLPhai;
                                    obj.KLTong += matchingItem.KLTong;
                                }
                            }
                            finalResult.AddRange(query);
                        }
                        else
                        {

                            finalResult.AddRange(query);
                        }

                    }
                    else
                    {

                        finalResult.AddRange(query1);
                    }

                }

                // Trả về danh sách kết quả cuối cùng
                return finalResult;
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.Error.WriteLine($"An error occurred: {ex.Message}");
                throw; // Optionally rethrow the exception
            }
        }
        public async Task<PKKLTDanRBT> GetTKLCK_SauCCByLCK(string id)
        {
            using var context = _context.CreateDbContext();
            var result = context.PKKLTDanRBTs
                .Where(a => a.TTTDCongHoRanh_TenLoaiTamDanTieuChuan == id &&
                 a.HangMuc == "I.Sản xuất, vận chuyển, lắp đặt" &&
                 a.LoaiBeTong == "Bê tông thương phẩm")
                 .FirstOrDefault();

            return result;
        }
        

        public async Task<List<PKKLTDanRBT>> GetExist(PKKLTDanRBT searchData)
        {
            try
            {
                using var context = _context.CreateDbContext();

                // Thực hiện lọc dữ liệu dựa trên các thuộc tính của searchData
                var query = context.PKKLTDanRBTs
                             .Where(item => (
                                    item.TTTDCongHoRanh_TenLoaiTamDanTieuChuan == searchData.TTTDCongHoRanh_TenLoaiTamDanTieuChuan &&
                                    item.LoaiBeTong == searchData.LoaiBeTong &&
                                    item.HangMuc == searchData.HangMuc &&
                                    item.HangMucCongTac == searchData.HangMucCongTac &&
                                    item.TenCongTac == searchData.TenCongTac &&
                                    item.DonVi == searchData.DonVi &&
                                    item.KTHH_D == searchData.KTHH_D &&
                                    item.KTHH_R == searchData.KTHH_R &&
                                    item.KTHH_C == searchData.KTHH_C &&
                                    item.KTHH_DienTich == searchData.KTHH_DienTich &&
                                    item.KTHH_GhiChu == searchData.KTHH_GhiChu &&
                                    item.KTHH_SLCauKien == searchData.KTHH_SLCauKien &&
                                    item.KTHH_KL1CK == searchData.KTHH_KL1CK &&
                                    item.TTCDT_CDai == searchData.TTCDT_CDai &&
                                    item.TTCDT_CRong == searchData.TTCDT_CRong &&
                                    item.TTCDT_CDay == searchData.TTCDT_CDay &&
                                    item.TTCDT_DienTich == searchData.TTCDT_DienTich &&
                                    item.TTCDT_SLCK == searchData.TTCDT_SLCK &&
                                    item.TTCDT_KL == searchData.TTCDT_KL &&
                                    item.KLKP_KL == searchData.KLKP_KL &&
                                    item.KLKP_Sl == searchData.KLKP_Sl &&
                                    item.KL1CK_ChuaTruCC == searchData.KL1CK_ChuaTruCC &&
                                    item.KLCC1CK == searchData.KLCC1CK &&
                                    item.TKLCK_SauCC == searchData.TKLCK_SauCC
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
        public async Task Update(PKKLTDanRBT TKThepDeCong)
        {
            using var context = _context.CreateDbContext();
            var entity = GetById(TKThepDeCong.Id);

            if (entity == null)
            {
                throw new Exception($"Không tìm thấy bản ghi theo ID: {TKThepDeCong.Id}");
            }

            context.PKKLTDanRBTs.Update(TKThepDeCong);
            await SaveChanges(context);

        }

        public async Task UpdateMulti(PKKLTDanRBT[] PKKLTDanRBT)
        {
            try
            {
                using var context = _context.CreateDbContext();

                string[] ids = PKKLTDanRBT.Select(x => x.Id).ToArray();

                // Lấy danh sách các bản ghi từ database có ID nằm trong danh sách ids
                var listEntities = await context.PKKLTDanRBTs
                    .Where(x => ids.Contains(x.Id))
                    .ToListAsync();
                foreach (var entity in listEntities)
                {
                    var updatedEntity = PKKLTDanRBT.FirstOrDefault(x => x.Id == entity.Id);
                    if (updatedEntity != null)
                    {
                        context.Entry(entity).CurrentValues.SetValues(updatedEntity);
                    }
                }
                await SaveChanges(context);
                // Lưu các thay đổi vào database
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task DeleteById(string id)
        {
            using var context = _context.CreateDbContext();
            var entity = await GetById(id);

            if (entity == null)
            {
                throw new Exception($"Không tìm thấy bản ghi theo ID: {id}");
            }

            context.Set<PKKLTDanRBT>().Remove(entity);
            await SaveChanges(context);
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
        public async Task Insert(PKKLTDanRBT entity)
        {
            try
            {
                using var context = _context.CreateDbContext();
                if (entity == null)
                {
                    throw new Exception("Không có bản ghi nào để thêm!");
                }

                // Lấy tất cả các bản ghi phù hợp và thực hiện xử lý trên client-side
                var maxFlagValue = await context.PKKLTDanRBTs
                    .Where(x => x.TTTDCongHoRanh_TenLoaiTamDanTieuChuan == entity.TTTDCongHoRanh_TenLoaiTamDanTieuChuan && x.HangMuc == entity.HangMuc)
                    .Select(x => x.Flag)
                    .ToListAsync(); // Lấy danh sách các giá trị Flag

                // Kiểm tra nếu danh sách không có giá trị nào, trả về 0, ngược lại lấy giá trị lớn nhất
                var maxFlag = maxFlagValue.Any() ? maxFlagValue.Max() : 0;


                // Tăng giá trị Flag lên 1
                entity.Flag = maxFlag + 1;

                // Chèn bản ghi mới vào bảng
                context.PKKLTDanRBTs.Add(entity);

                await SaveChanges(context);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public async Task<string> InsertLaterFlag(PKKLTDanRBT entity, int FlagLast)
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
                var recordsToUpdate = await context.PKKLTDanRBTs
                    .Where(x => x.Flag > FlagLast && x.TTTDCongHoRanh_TenLoaiTamDanTieuChuan == entity.TTTDCongHoRanh_TenLoaiTamDanTieuChuan && x.HangMuc == entity.HangMuc)
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
                    var maxFlag = await context.PKKLTDanRBTs.AnyAsync()
                                  ? await context.PKKLTDanRBTs.MaxAsync(x => x.Flag)
                                  : 0;

                    // Tăng giá trị Flag lên 1
                    entity.Flag = maxFlag + 1;
                }
                else
                {
                    entity.Flag = FlagLast + 1;
                }

                // Bước 4: Chèn bản ghi mới vào bảng
                context.PKKLTDanRBTs.Add(entity);

                await SaveChanges(context);

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

        // Thêm phương thức SaveChanges() để lưu các thay đổi vào cơ sở dữ liệu
        public async Task SaveChanges(ApplicationDbContext context)
        {
            try
            {
                // Kiểm tra và xử lý các thay đổi trong DbContext
                var addedEntities = context.ChangeTracker.Entries()
                    .Where(e => e.State == EntityState.Added)
                    .ToList();

                var modifiedEntities = context.ChangeTracker.Entries()
                    .Where(e => e.State == EntityState.Modified)
                    .ToList();

                var deletedEntities = context.ChangeTracker.Entries()
                    .Where(e => e.State == EntityState.Deleted)
                    .ToList();

                // Xử lý thay đổi khi thêm
                if (addedEntities.Any())
                {
                    foreach (var addedEntity in addedEntities)
                    {
                        await HandleEntityAdd(addedEntity);
                    }
                }

                // Xử lý thay đổi khi sửa
                if (modifiedEntities.Any())
                {
                    foreach (var modifiedEntity in modifiedEntities)
                    {
                        await HandleEntityUpdate(modifiedEntity);
                    }
                }

                // Xử lý thay đổi khi xóa
                if (deletedEntities.Any())
                {
                    foreach (var deletedEntity in deletedEntities)
                    {
                        await HandleEntityDelete(deletedEntity);
                    }
                }

                // Lưu các thay đổi vào cơ sở dữ liệu
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"An error occurred while saving changes: {ex.Message}");
                throw;
            }
        }

        // Xử lý khi thêm mới entity
        private async Task HandleEntityAdd(EntityEntry entityEntry)
        {
            var addedEntity = entityEntry.Entity as PKKLTDanRBT;
            if (addedEntity != null)
            {
                // Kiểm tra điều kiện HangMuc và PhanLoaiMongCongTronCongHop
                if (addedEntity.HangMuc == "I.Móng cống tròn")
                {
                    using var context = _context.CreateDbContext();

                    // Lọc tất cả các bản ghi có TTTDCongHoRanh_TenLoaiTamDanTieuChuan giống với addedEntity
                    var recordsToUpdate = await context.PKKLTDanRBTs
                        .Where(x => x.TTTDCongHoRanh_TenLoaiTamDanTieuChuan == addedEntity.TTTDCongHoRanh_TenLoaiTamDanTieuChuan
                        && x.HangMuc == "II.Sản xuất + V.Chuyển B.Tông T.Phẩm móng cống tròn")
                        .ToListAsync();


                    // Cập nhật các cột TKLCK_SauCC cho từng bản ghi
                    foreach (var record in recordsToUpdate)
                    {
                        record.TKLCK_SauCC = await GetSumTKLCK_SauCC(addedEntity) + addedEntity.TKLCK_SauCC;
                    }

                    // Gọi phương thức UpdateMulti để cập nhật nhiều bản ghi
                    await UpdateMulti(recordsToUpdate.ToArray());


                    // In thông tin của entity mới
                    Console.WriteLine($"Entity added: {addedEntity}");
                }
            }
        }
        // Xử lý khi sửa entity
        private async Task HandleEntityUpdate(EntityEntry entityEntry)
        {
            var modifiedEntity = entityEntry.Entity as PKKLTDanRBT;
            if (modifiedEntity != null)
            {
                // Kiểm tra điều kiện HangMuc và PhanLoaiMongCongTronCongHop
                if (modifiedEntity.HangMuc == "I.Móng cống tròn")
                {
                    using var context = _context.CreateDbContext();

                    // Lọc tất cả các bản ghi có TTTDCongHoRanh_TenLoaiTamDanTieuChuan giống với addedEntity
                    var recordsToUpdate = await context.PKKLTDanRBTs
                        .Where(x => x.TTTDCongHoRanh_TenLoaiTamDanTieuChuan == modifiedEntity.TTTDCongHoRanh_TenLoaiTamDanTieuChuan
                        && x.HangMuc == "II.Sản xuất + V.Chuyển B.Tông T.Phẩm móng cống tròn")
                        .ToListAsync();


                    // Cập nhật các cột TKLCK_SauCC cho từng bản ghi
                    foreach (var record in recordsToUpdate)
                    {
                        record.TKLCK_SauCC = await GetSumTKLCK_SauCC(modifiedEntity) + modifiedEntity.TKLCK_SauCC;
                    }

                    // Gọi phương thức UpdateMulti để cập nhật nhiều bản ghi
                    await UpdateMulti(recordsToUpdate.ToArray());

                    // In thông tin của entity mới
                    Console.WriteLine($"Entity added: {modifiedEntity}");
                }
            }
        }

        // Xử lý khi xóa entity
        private async Task HandleEntityDelete(EntityEntry entityEntry)
        {
            var deletedEntity = entityEntry.Entity as PKKLTDanRBT;
            if (deletedEntity != null)
            {
                // Kiểm tra điều kiện HangMuc và PhanLoaiMongCongTronCongHop
                if (deletedEntity.HangMuc == "I.Móng cống tròn")
                {
                    using var context = _context.CreateDbContext();

                    // Lọc tất cả các bản ghi có TTTDCongHoRanh_TenLoaiTamDanTieuChuan giống với addedEntity
                    var recordsToUpdate = await context.PKKLTDanRBTs
                        .Where(x => x.TTTDCongHoRanh_TenLoaiTamDanTieuChuan == deletedEntity.TTTDCongHoRanh_TenLoaiTamDanTieuChuan
                        && x.HangMuc == "II.Sản xuất + V.Chuyển B.Tông T.Phẩm móng cống tròn")
                        .ToListAsync();


                    // Cập nhật các cột TKLCK_SauCC cho từng bản ghi
                    foreach (var record in recordsToUpdate)
                    {
                        record.TKLCK_SauCC = await GetSumTKLCK_SauCC(deletedEntity) - deletedEntity.TKLCK_SauCC;
                    }

                    // Gọi phương thức UpdateMulti để cập nhật nhiều bản ghi
                    await UpdateMulti(recordsToUpdate.ToArray());

                    // In thông tin của entity mới
                    Console.WriteLine($"Entity added: {deletedEntity}");
                }
            }
        }

        public double KTHH_KL1CK(string DonVi, double KTHH_D, double KTHH_R, double KTHH_C, double KTHH_DienTich, string KTHH_GhiChu)
        {
            double result = 0;
            if (DonVi == "M3")
            {
                if (string.IsNullOrEmpty(KTHH_GhiChu) || KTHH_GhiChu == "0")
                {
                    result = KTHH_D * KTHH_R * KTHH_C;
                }
                else if (KTHH_GhiChu == "Rộng*Cao")
                {
                    result = KTHH_DienTich * KTHH_D;
                }
                else if (KTHH_GhiChu == "Dài*Cao")
                {
                    result = KTHH_DienTich * KTHH_R;
                }
                else if (KTHH_GhiChu == "Dài*Rộng")
                {
                    result = KTHH_DienTich * KTHH_C;
                }

            }
            return Math.Round(result, 4);
        }

        public double TTCDT_KL(string DonVi, double KTHH_D, double KTHH_R, double KTHH_C, double TTCDT_CDai, double TTCDT_CRong, double TTCDT_CDay, double TTCDT_DienTich)
        {
            double result = 0;
            if (DonVi.ToUpper().Trim() == "M2")
            {
                if (string.IsNullOrEmpty(TTCDT_DienTich.ToString()) || TTCDT_DienTich == 0)
                {
                    result = (KTHH_D * KTHH_C * TTCDT_CDai) + (KTHH_R * KTHH_C * TTCDT_CRong) + (KTHH_D * KTHH_R * TTCDT_CDay);
                }
                else
                {
                    result = TTCDT_DienTich;
                }
            }
            return Math.Round(result, 4);
        }

        public double KL1CK_ChuaTruCC(double KTHH_KL1CK, double KTHH_SLCauKien, double TTCDT_KL, double TTCDT_SLCK, double KLKP_KL, double KLKP_Sl)
        {
            double result = 0;
            if (KTHH_KL1CK > 0)
            {
                result = KTHH_KL1CK * KTHH_SLCauKien;
            }
            else if (TTCDT_KL > 0)
            {
                result = TTCDT_KL * TTCDT_SLCK;
            }
            else
            {
                result = KLKP_KL * KLKP_Sl;
            }
            return Math.Round(result, 4);
        }

    }
}
