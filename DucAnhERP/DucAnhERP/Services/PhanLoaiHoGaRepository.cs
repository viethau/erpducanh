using DucAnhERP.Data;
using DucAnhERP.Models;
using DucAnhERP.Repository;
using DucAnhERP.ViewModel;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace DucAnhERP.Services
{
    public class PhanLoaiHoGaRepository : IPhanLoaiHoGaRepository
    {
      
        private readonly IDbContextFactory<ApplicationDbContext> _context;

        public PhanLoaiHoGaRepository(IDbContextFactory<ApplicationDbContext> context)
            {
                _context = context;
            }

        public async Task<List<PhanLoaiHoGa>> GetAll()
            {
                try
                {
                    using var context = _context.CreateDbContext();
                    var entity = await context.PhanLoaiHoGas.ToListAsync();
                    return entity;
                }
                catch (Exception ex)
                {
                    // Log the exception
                    Console.Error.WriteLine($"An error occurred: {ex.Message}");
                    throw; // Optionally rethrow the exception
                }
            }
        public async Task<List<PhanLoaiHoGaModel>> GetAllByVM()
        {
            try
            {
                using var context = _context.CreateDbContext();
                var query = from plhg in context.PhanLoaiHoGas
                            join hinhThucHoGa  in context.DSDanhMuc
                                on plhg.ThongTinChungHoGa_HinhThucHoGa equals hinhThucHoGa.Id
                            join ketCauMuMo in context.DSDanhMuc
                                on plhg.ThongTinChungHoGa_KetCauMuMo equals ketCauMuMo.Id
                            join ketCauTuong in context.DSDanhMuc
                                on plhg.ThongTinChungHoGa_KetCauTuong equals ketCauTuong.Id
                            join hinhThucMongHoGa in context.DSDanhMuc
                                on plhg.ThongTinChungHoGa_HinhThucMongHoGa equals hinhThucMongHoGa.Id
                            join ketCauMong in context.DSDanhMuc
                                on plhg.ThongTinChungHoGa_KetCauMong equals ketCauMong.Id

                            join chatMatTrong in context.DSDanhMuc
                                on plhg.ThongTinChungHoGa_ChatMatTrong equals chatMatTrong.Id into gj2
                            from chatMatTrong in gj2.DefaultIfEmpty() // Left join
                            join chatMatNgoai in context.DSDanhMuc
                                on plhg.ThongTinChungHoGa_ChatMatNgoai equals chatMatNgoai.Id into gj3
                            from chatMatNgoai in gj3.DefaultIfEmpty() // Left join

                            orderby plhg.Flag
                            select new PhanLoaiHoGaModel
                            {
                                Id = plhg.Id,
                                ThongTinChungHoGa_TenHoGaSauPhanLoai = plhg.ThongTinChungHoGa_TenHoGaSauPhanLoai ?? "",
                                ThongTinChungHoGa_HinhThucHoGa = plhg.ThongTinChungHoGa_HinhThucHoGa ?? "",
                                ThongTinChungHoGa_HinhThucHoGa_Name = hinhThucHoGa.Ten ?? "",
                                ThongTinChungHoGa_KetCauMuMo = plhg.ThongTinChungHoGa_KetCauMuMo ?? "",
                                ThongTinChungHoGa_KetCauMuMo_Name = ketCauMuMo.Ten ?? "",
                                ThongTinChungHoGa_KetCauTuong = plhg.ThongTinChungHoGa_KetCauTuong ?? "",
                                ThongTinChungHoGa_KetCauTuong_Name = ketCauTuong.Ten ?? "",
                                ThongTinChungHoGa_HinhThucMongHoGa = plhg.ThongTinChungHoGa_HinhThucMongHoGa ?? "",
                                ThongTinChungHoGa_HinhThucMongHoGa_Name = hinhThucMongHoGa.Ten ?? "",
                                ThongTinChungHoGa_KetCauMong = plhg.ThongTinChungHoGa_KetCauMong ?? "",
                                ThongTinChungHoGa_KetCauMong_Name = ketCauMong.Ten ?? "",
                                ThongTinChungHoGa_ChatMatTrong = plhg.ThongTinChungHoGa_ChatMatTrong ?? "",
                                ThongTinChungHoGa_ChatMatTrong_Name = chatMatTrong.Ten ?? "",
                                ThongTinChungHoGa_ChatMatNgoai = plhg.ThongTinChungHoGa_ChatMatNgoai ?? "",
                                ThongTinChungHoGa_ChatMatNgoai_Name = chatMatNgoai.Ten ?? "",
                                PhuBiHoGa_CDai = plhg.PhuBiHoGa_CDai ?? 0,
                                PhuBiHoGa_CRong = plhg.PhuBiHoGa_CRong ?? 0,
                                BeTongLotMong_D = plhg.BeTongLotMong_D ?? 0,
                                BeTongLotMong_R = plhg.BeTongLotMong_R ?? 0,
                                BeTongLotMong_C = plhg.BeTongLotMong_C ?? 0,
                                BeTongMongHoGa_D = plhg.BeTongMongHoGa_D ?? 0,
                                BeTongMongHoGa_R = plhg.BeTongMongHoGa_R ?? 0,
                                BeTongMongHoGa_C = plhg.BeTongMongHoGa_C ?? 0,
                                DeHoGa_D = plhg.DeHoGa_D ?? 0,
                                DeHoGa_R = plhg.DeHoGa_R ?? 0,
                                DeHoGa_C = plhg.DeHoGa_C ?? 0,
                                TuongHoGa_D = plhg.TuongHoGa_D ?? 0,
                                TuongHoGa_R = plhg.TuongHoGa_R ?? 0,
                                TuongHoGa_C = plhg.TuongHoGa_C ?? 0,
                                TuongHoGa_CdTuong = plhg.TuongHoGa_CdTuong ?? 0,
                                DamGiuaHoGa_D = plhg.DamGiuaHoGa_D ?? 0,
                                DamGiuaHoGa_R = plhg.DamGiuaHoGa_R ?? 0,
                                DamGiuaHoGa_C = plhg.DamGiuaHoGa_C ?? 0,
                                DamGiuaHoGa_CdDam = plhg.DamGiuaHoGa_CdDam ?? 0,
                                DamGiuaHoGa_CCaoDamGiuaTuongSoVoiDayHoGa = plhg.DamGiuaHoGa_CCaoDamGiuaTuongSoVoiDayHoGa ?? 0,
                                ChatMatTrong_D = plhg.ChatMatTrong_D ?? 0,
                                ChatMatTrong_R = plhg.ChatMatTrong_R ?? 0,
                                ChatMatTrong_C = plhg.ChatMatTrong_C ?? 0,
                                ChatMatNgoaiCanh_D = plhg.ChatMatNgoaiCanh_D ?? 0,
                                ChatMatNgoaiCanh_R = plhg.ChatMatNgoaiCanh_R ?? 0,
                                ChatMatNgoaiCanh_C = plhg.ChatMatNgoaiCanh_C ?? 0,
                                MuMoThotDuoi_D = plhg.MuMoThotDuoi_D ?? 0,
                                MuMoThotDuoi_R = plhg.MuMoThotDuoi_R ?? 0,
                                MuMoThotDuoi_C = plhg.MuMoThotDuoi_C ?? 0,
                                MuMoThotDuoi_CdTuong = plhg.MuMoThotDuoi_CdTuong ?? 0,
                                MuMoThotTren_D = plhg.MuMoThotTren_D ?? 0,
                                MuMoThotTren_R = plhg.MuMoThotTren_R ?? 0,
                                MuMoThotTren_C = plhg.MuMoThotTren_C ?? 0,
                                MuMoThotTren_CdTuong = plhg.MuMoThotTren_CdTuong ?? 0,
                                HinhThucDauNoi1_Loai = plhg.HinhThucDauNoi1_Loai ?? 0,
                                HinhThucDauNoi1_CanhDai = plhg.HinhThucDauNoi1_CanhDai ?? 0,
                                HinhThucDauNoi1_CanhRong = plhg.HinhThucDauNoi1_CanhRong ?? 0,
                                HinhThucDauNoi1_CanhCheo = plhg.HinhThucDauNoi1_CanhCheo ?? 0,
                                HinhThucDauNoi2_Loai = plhg.HinhThucDauNoi2_Loai ?? 0,
                                HinhThucDauNoi2_CanhDai = plhg.HinhThucDauNoi2_CanhDai ?? 0,
                                HinhThucDauNoi2_CanhRong = plhg.HinhThucDauNoi2_CanhRong ?? 0,
                                HinhThucDauNoi2_CanhCheo = plhg.HinhThucDauNoi2_CanhCheo ?? 0,
                                HinhThucDauNoi3_Loai = plhg.HinhThucDauNoi3_Loai ?? 0,
                                HinhThucDauNoi3_CanhDai = plhg.HinhThucDauNoi3_CanhDai ?? 0,
                                HinhThucDauNoi3_CanhRong = plhg.HinhThucDauNoi3_CanhRong ?? 0,
                                HinhThucDauNoi3_CanhCheo = plhg.HinhThucDauNoi3_CanhCheo ?? 0,
                                HinhThucDauNoi4_Loai = plhg.HinhThucDauNoi4_Loai ?? 0,
                                HinhThucDauNoi4_CanhDai = plhg.HinhThucDauNoi4_CanhDai ?? 0,
                                HinhThucDauNoi4_CanhRong = plhg.HinhThucDauNoi4_CanhRong ?? 0,
                                HinhThucDauNoi4_CanhCheo = plhg.HinhThucDauNoi4_CanhCheo ?? 0,
                                HinhThucDauNoi5_Loai = plhg.HinhThucDauNoi5_Loai ?? 0,
                                HinhThucDauNoi5_CanhDai = plhg.HinhThucDauNoi5_CanhDai ?? 0,
                                HinhThucDauNoi5_CanhRong = plhg.HinhThucDauNoi5_CanhRong ?? 0,
                                HinhThucDauNoi5_CanhCheo = plhg.HinhThucDauNoi5_CanhCheo ?? 0,
                                HinhThucDauNoi6_Loai = plhg.HinhThucDauNoi6_Loai ?? 0,
                                HinhThucDauNoi6_CanhDai = plhg.HinhThucDauNoi6_CanhDai ?? 0,
                                HinhThucDauNoi6_CanhRong = plhg.HinhThucDauNoi6_CanhRong ?? 0,
                                HinhThucDauNoi6_CanhCheo = plhg.HinhThucDauNoi6_CanhCheo ?? 0,
                                HinhThucDauNoi7_Loai = plhg.HinhThucDauNoi7_Loai ?? 0,
                                HinhThucDauNoi7_CanhDai = plhg.HinhThucDauNoi7_CanhDai ?? 0,
                                HinhThucDauNoi7_CanhRong = plhg.HinhThucDauNoi7_CanhRong ?? 0,
                                HinhThucDauNoi7_CanhCheo = plhg.HinhThucDauNoi7_CanhCheo ?? 0,
                                HinhThucDauNoi8_Loai = plhg.HinhThucDauNoi8_Loai ?? 0,
                                HinhThucDauNoi8_CanhDai = plhg.HinhThucDauNoi8_CanhDai ?? 0,
                                HinhThucDauNoi8_CanhRong = plhg.HinhThucDauNoi8_CanhRong ?? 0,
                                HinhThucDauNoi8_CanhCheo = plhg.HinhThucDauNoi8_CanhCheo ?? 0,
                                Flag=plhg.Flag,
                                CreateAt=plhg.CreateAt ,
                                CreateBy=plhg.CreateBy,
                                IsActive = plhg.IsActive,

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
                         .Where(hrt => (hrt.ThongTinChungHoGa_TenHoGaSauPhanLoai == id));

            var data = await query.ToListAsync();

            // Kiểm tra nếu danh sách kết quả rỗng hoặc không có dữ liệu khớp
            isSuccess = data.Any();
            return (isSuccess);
        }
        public async Task<bool> CheckUsingName(string name)
        {
            bool isSuccess = false;
            using var context = _context.CreateDbContext();
            var query = context.PhanLoaiHoGas
                         .Where(item => (item.ThongTinChungHoGa_TenHoGaSauPhanLoai.ToUpper().Trim() == name.ToUpper().Trim()));

            var data = await query.ToListAsync();

            // Kiểm tra nếu danh sách kết quả rỗng hoặc không có dữ liệu khớp
            isSuccess = data.Any();
            return (isSuccess);
        }
        public async Task<PhanLoaiHoGa> GetPhanLoaiHoGaByDetail(PhanLoaiHoGa searchData)
        {
            try
            {
                using var context = _context.CreateDbContext();

                // Thực hiện lọc dữ liệu dựa trên các thuộc tính của searchData
                var query = context.PhanLoaiHoGas
                             .Where(plhg => (
                                        plhg.G == searchData.G &&
                                        plhg.ThongTinChungHoGa_HinhThucHoGa == searchData.ThongTinChungHoGa_HinhThucHoGa &&
                                        plhg.ThongTinChungHoGa_KetCauMuMo == searchData.ThongTinChungHoGa_KetCauMuMo &&
                                        plhg.ThongTinChungHoGa_KetCauTuong == searchData.ThongTinChungHoGa_KetCauTuong &&
                                        plhg.ThongTinChungHoGa_HinhThucMongHoGa == searchData.ThongTinChungHoGa_HinhThucMongHoGa &&
                                        plhg.ThongTinChungHoGa_KetCauMong == searchData.ThongTinChungHoGa_KetCauMong &&
                                        plhg.ThongTinChungHoGa_ChatMatTrong == searchData.ThongTinChungHoGa_ChatMatTrong &&
                                        plhg.ThongTinChungHoGa_ChatMatNgoai == searchData.ThongTinChungHoGa_ChatMatNgoai &&
                                        plhg.PhuBiHoGa_CDai == searchData.PhuBiHoGa_CDai &&
                                        plhg.PhuBiHoGa_CRong == searchData.PhuBiHoGa_CRong &&
                                        plhg.BeTongLotMong_D == searchData.BeTongLotMong_D &&
                                        plhg.BeTongLotMong_R == searchData.BeTongLotMong_R &&
                                        plhg.BeTongLotMong_C == searchData.BeTongLotMong_C &&
                                        plhg.BeTongMongHoGa_D == searchData.BeTongMongHoGa_D &&
                                        plhg.BeTongMongHoGa_R == searchData.BeTongMongHoGa_R &&
                                        plhg.BeTongMongHoGa_C == searchData.BeTongMongHoGa_C &&
                                        plhg.DeHoGa_D == searchData.DeHoGa_D &&
                                        plhg.DeHoGa_R == searchData.DeHoGa_R &&
                                        plhg.DeHoGa_C == searchData.DeHoGa_C &&
                                        plhg.TuongHoGa_D == searchData.TuongHoGa_D &&
                                        plhg.TuongHoGa_R == searchData.TuongHoGa_R &&
                                        plhg.TuongHoGa_C == searchData.TuongHoGa_C &&
                                        plhg.TuongHoGa_CdTuong == searchData.TuongHoGa_CdTuong &&
                                        plhg.DamGiuaHoGa_D == searchData.DamGiuaHoGa_D &&
                                        plhg.DamGiuaHoGa_R == searchData.DamGiuaHoGa_R &&
                                        plhg.DamGiuaHoGa_C == searchData.DamGiuaHoGa_C &&
                                        plhg.DamGiuaHoGa_CdDam == searchData.DamGiuaHoGa_CdDam &&
                                        plhg.DamGiuaHoGa_CCaoDamGiuaTuongSoVoiDayHoGa == searchData.DamGiuaHoGa_CCaoDamGiuaTuongSoVoiDayHoGa &&
                                        plhg.ChatMatTrong_D == searchData.ChatMatTrong_D &&
                                        plhg.ChatMatTrong_R == searchData.ChatMatTrong_R &&
                                        plhg.ChatMatTrong_C == searchData.ChatMatTrong_C &&
                                        plhg.ChatMatNgoaiCanh_D == searchData.ChatMatNgoaiCanh_D &&
                                        plhg.ChatMatNgoaiCanh_R == searchData.ChatMatNgoaiCanh_R &&
                                        plhg.ChatMatNgoaiCanh_C == searchData.ChatMatNgoaiCanh_C &&
                                        plhg.MuMoThotDuoi_D == searchData.MuMoThotDuoi_D &&
                                        plhg.MuMoThotDuoi_R == searchData.MuMoThotDuoi_R &&
                                        plhg.MuMoThotDuoi_C == searchData.MuMoThotDuoi_C &&
                                        plhg.MuMoThotDuoi_CdTuong == searchData.MuMoThotDuoi_CdTuong &&
                                        plhg.MuMoThotTren_D == searchData.MuMoThotTren_D &&
                                        plhg.MuMoThotTren_R == searchData.MuMoThotTren_R &&
                                        plhg.MuMoThotTren_C == searchData.MuMoThotTren_C &&
                                        plhg.MuMoThotTren_CdTuong == searchData.MuMoThotTren_CdTuong &&
                                        plhg.HinhThucDauNoi1_Loai == searchData.HinhThucDauNoi1_Loai &&
                                        plhg.HinhThucDauNoi1_CanhDai == searchData.HinhThucDauNoi1_CanhDai &&
                                        plhg.HinhThucDauNoi1_CanhRong == searchData.HinhThucDauNoi1_CanhRong &&
                                        plhg.HinhThucDauNoi1_CanhCheo == searchData.HinhThucDauNoi1_CanhCheo &&
                                        plhg.HinhThucDauNoi2_Loai == searchData.HinhThucDauNoi2_Loai &&
                                        plhg.HinhThucDauNoi2_CanhDai == searchData.HinhThucDauNoi2_CanhDai &&
                                        plhg.HinhThucDauNoi2_CanhRong == searchData.HinhThucDauNoi2_CanhRong &&
                                        plhg.HinhThucDauNoi2_CanhCheo == searchData.HinhThucDauNoi2_CanhCheo &&
                                        plhg.HinhThucDauNoi3_Loai == searchData.HinhThucDauNoi3_Loai &&
                                        plhg.HinhThucDauNoi3_CanhDai == searchData.HinhThucDauNoi3_CanhDai &&
                                        plhg.HinhThucDauNoi3_CanhRong == searchData.HinhThucDauNoi3_CanhRong &&
                                        plhg.HinhThucDauNoi3_CanhCheo == searchData.HinhThucDauNoi3_CanhCheo &&
                                        plhg.HinhThucDauNoi4_Loai == searchData.HinhThucDauNoi4_Loai &&
                                        plhg.HinhThucDauNoi4_CanhDai == searchData.HinhThucDauNoi4_CanhDai &&
                                        plhg.HinhThucDauNoi4_CanhRong == searchData.HinhThucDauNoi4_CanhRong &&
                                        plhg.HinhThucDauNoi4_CanhCheo == searchData.HinhThucDauNoi4_CanhCheo &&
                                        plhg.HinhThucDauNoi5_Loai == searchData.HinhThucDauNoi5_Loai &&
                                        plhg.HinhThucDauNoi5_CanhDai == searchData.HinhThucDauNoi5_CanhDai &&
                                        plhg.HinhThucDauNoi5_CanhRong == searchData.HinhThucDauNoi5_CanhRong &&
                                        plhg.HinhThucDauNoi5_CanhCheo == searchData.HinhThucDauNoi5_CanhCheo &&
                                        plhg.HinhThucDauNoi6_Loai == searchData.HinhThucDauNoi6_Loai &&
                                        plhg.HinhThucDauNoi6_CanhDai == searchData.HinhThucDauNoi6_CanhDai &&
                                        plhg.HinhThucDauNoi6_CanhRong == searchData.HinhThucDauNoi6_CanhRong &&
                                        plhg.HinhThucDauNoi6_CanhCheo == searchData.HinhThucDauNoi6_CanhCheo &&
                                        plhg.HinhThucDauNoi7_Loai == searchData.HinhThucDauNoi7_Loai &&
                                        plhg.HinhThucDauNoi7_CanhDai == searchData.HinhThucDauNoi7_CanhDai &&
                                        plhg.HinhThucDauNoi7_CanhRong == searchData.HinhThucDauNoi7_CanhRong &&
                                        plhg.HinhThucDauNoi7_CanhCheo == searchData.HinhThucDauNoi7_CanhCheo &&
                                        plhg.HinhThucDauNoi8_Loai == searchData.HinhThucDauNoi8_Loai &&
                                        plhg.HinhThucDauNoi8_CanhDai == searchData.HinhThucDauNoi8_CanhDai &&
                                        plhg.HinhThucDauNoi8_CanhRong == searchData.HinhThucDauNoi8_CanhRong &&
                                        plhg.HinhThucDauNoi8_CanhCheo == searchData.HinhThucDauNoi8_CanhCheo

                                          ));
                var sqlQuery = query.ToQueryString();
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
        public async Task<PhanLoaiHoGa> GetPhanLoaiHoGaExist(PhanLoaiHoGa searchData)
        {
            try
            {
                using var context = _context.CreateDbContext();

                // Thực hiện lọc dữ liệu dựa trên các thuộc tính của searchData
                var query = context.PhanLoaiHoGas
                             .Where(plhg => (
                                        plhg.ThongTinChungHoGa_TenHoGaSauPhanLoai == searchData.ThongTinChungHoGa_TenHoGaSauPhanLoai ||
                                        plhg.G == searchData.G &&
                                        plhg.ThongTinChungHoGa_HinhThucHoGa == searchData.ThongTinChungHoGa_HinhThucHoGa &&
                                        plhg.ThongTinChungHoGa_KetCauMuMo == searchData.ThongTinChungHoGa_KetCauMuMo &&
                                        plhg.ThongTinChungHoGa_KetCauTuong == searchData.ThongTinChungHoGa_KetCauTuong &&
                                        plhg.ThongTinChungHoGa_HinhThucMongHoGa == searchData.ThongTinChungHoGa_HinhThucMongHoGa &&
                                        plhg.ThongTinChungHoGa_KetCauMong == searchData.ThongTinChungHoGa_KetCauMong &&
                                        plhg.ThongTinChungHoGa_ChatMatTrong == searchData.ThongTinChungHoGa_ChatMatTrong &&
                                        plhg.ThongTinChungHoGa_ChatMatNgoai == searchData.ThongTinChungHoGa_ChatMatNgoai &&
                                        plhg.PhuBiHoGa_CDai == searchData.PhuBiHoGa_CDai &&
                                        plhg.PhuBiHoGa_CRong == searchData.PhuBiHoGa_CRong &&
                                        plhg.BeTongLotMong_D == searchData.BeTongLotMong_D &&
                                        plhg.BeTongLotMong_R == searchData.BeTongLotMong_R &&
                                        plhg.BeTongLotMong_C == searchData.BeTongLotMong_C &&
                                        plhg.BeTongMongHoGa_D == searchData.BeTongMongHoGa_D &&
                                        plhg.BeTongMongHoGa_R == searchData.BeTongMongHoGa_R &&
                                        plhg.BeTongMongHoGa_C == searchData.BeTongMongHoGa_C &&
                                        plhg.DeHoGa_D == searchData.DeHoGa_D &&
                                        plhg.DeHoGa_R == searchData.DeHoGa_R &&
                                        plhg.DeHoGa_C == searchData.DeHoGa_C &&
                                        plhg.TuongHoGa_D == searchData.TuongHoGa_D &&
                                        plhg.TuongHoGa_R == searchData.TuongHoGa_R &&
                                        plhg.TuongHoGa_C == searchData.TuongHoGa_C &&
                                        plhg.TuongHoGa_CdTuong == searchData.TuongHoGa_CdTuong &&
                                        plhg.DamGiuaHoGa_D == searchData.DamGiuaHoGa_D &&
                                        plhg.DamGiuaHoGa_R == searchData.DamGiuaHoGa_R &&
                                        plhg.DamGiuaHoGa_C == searchData.DamGiuaHoGa_C &&
                                        plhg.DamGiuaHoGa_CdDam == searchData.DamGiuaHoGa_CdDam &&
                                        plhg.DamGiuaHoGa_CCaoDamGiuaTuongSoVoiDayHoGa == searchData.DamGiuaHoGa_CCaoDamGiuaTuongSoVoiDayHoGa &&
                                        plhg.ChatMatTrong_D == searchData.ChatMatTrong_D &&
                                        plhg.ChatMatTrong_R == searchData.ChatMatTrong_R &&
                                        plhg.ChatMatTrong_C == searchData.ChatMatTrong_C &&
                                        plhg.ChatMatNgoaiCanh_D == searchData.ChatMatNgoaiCanh_D &&
                                        plhg.ChatMatNgoaiCanh_R == searchData.ChatMatNgoaiCanh_R &&
                                        plhg.ChatMatNgoaiCanh_C == searchData.ChatMatNgoaiCanh_C &&
                                        plhg.MuMoThotDuoi_D == searchData.MuMoThotDuoi_D &&
                                        plhg.MuMoThotDuoi_R == searchData.MuMoThotDuoi_R &&
                                        plhg.MuMoThotDuoi_C == searchData.MuMoThotDuoi_C &&
                                        plhg.MuMoThotDuoi_CdTuong == searchData.MuMoThotDuoi_CdTuong &&
                                        plhg.MuMoThotTren_D == searchData.MuMoThotTren_D &&
                                        plhg.MuMoThotTren_R == searchData.MuMoThotTren_R &&
                                        plhg.MuMoThotTren_C == searchData.MuMoThotTren_C &&
                                        plhg.MuMoThotTren_CdTuong == searchData.MuMoThotTren_CdTuong &&
                                        plhg.HinhThucDauNoi1_Loai == searchData.HinhThucDauNoi1_Loai &&
                                        plhg.HinhThucDauNoi1_CanhDai == searchData.HinhThucDauNoi1_CanhDai &&
                                        plhg.HinhThucDauNoi1_CanhRong == searchData.HinhThucDauNoi1_CanhRong &&
                                        plhg.HinhThucDauNoi1_CanhCheo == searchData.HinhThucDauNoi1_CanhCheo &&
                                        plhg.HinhThucDauNoi2_Loai == searchData.HinhThucDauNoi2_Loai &&
                                        plhg.HinhThucDauNoi2_CanhDai == searchData.HinhThucDauNoi2_CanhDai &&
                                        plhg.HinhThucDauNoi2_CanhRong == searchData.HinhThucDauNoi2_CanhRong &&
                                        plhg.HinhThucDauNoi2_CanhCheo == searchData.HinhThucDauNoi2_CanhCheo &&
                                        plhg.HinhThucDauNoi3_Loai == searchData.HinhThucDauNoi3_Loai &&
                                        plhg.HinhThucDauNoi3_CanhDai == searchData.HinhThucDauNoi3_CanhDai &&
                                        plhg.HinhThucDauNoi3_CanhRong == searchData.HinhThucDauNoi3_CanhRong &&
                                        plhg.HinhThucDauNoi3_CanhCheo == searchData.HinhThucDauNoi3_CanhCheo &&
                                        plhg.HinhThucDauNoi4_Loai == searchData.HinhThucDauNoi4_Loai &&
                                        plhg.HinhThucDauNoi4_CanhDai == searchData.HinhThucDauNoi4_CanhDai &&
                                        plhg.HinhThucDauNoi4_CanhRong == searchData.HinhThucDauNoi4_CanhRong &&
                                        plhg.HinhThucDauNoi4_CanhCheo == searchData.HinhThucDauNoi4_CanhCheo &&
                                        plhg.HinhThucDauNoi5_Loai == searchData.HinhThucDauNoi5_Loai &&
                                        plhg.HinhThucDauNoi5_CanhDai == searchData.HinhThucDauNoi5_CanhDai &&
                                        plhg.HinhThucDauNoi5_CanhRong == searchData.HinhThucDauNoi5_CanhRong &&
                                        plhg.HinhThucDauNoi5_CanhCheo == searchData.HinhThucDauNoi5_CanhCheo &&
                                        plhg.HinhThucDauNoi6_Loai == searchData.HinhThucDauNoi6_Loai &&
                                        plhg.HinhThucDauNoi6_CanhDai == searchData.HinhThucDauNoi6_CanhDai &&
                                        plhg.HinhThucDauNoi6_CanhRong == searchData.HinhThucDauNoi6_CanhRong &&
                                        plhg.HinhThucDauNoi6_CanhCheo == searchData.HinhThucDauNoi6_CanhCheo &&
                                        plhg.HinhThucDauNoi7_Loai == searchData.HinhThucDauNoi7_Loai &&
                                        plhg.HinhThucDauNoi7_CanhDai == searchData.HinhThucDauNoi7_CanhDai &&
                                        plhg.HinhThucDauNoi7_CanhRong == searchData.HinhThucDauNoi7_CanhRong &&
                                        plhg.HinhThucDauNoi7_CanhCheo == searchData.HinhThucDauNoi7_CanhCheo &&
                                        plhg.HinhThucDauNoi8_Loai == searchData.HinhThucDauNoi8_Loai &&
                                        plhg.HinhThucDauNoi8_CanhDai == searchData.HinhThucDauNoi8_CanhDai &&
                                        plhg.HinhThucDauNoi8_CanhRong == searchData.HinhThucDauNoi8_CanhRong &&
                                        plhg.HinhThucDauNoi8_CanhCheo == searchData.HinhThucDauNoi8_CanhCheo
                                          ));
                var sqlQuery = query.ToQueryString();
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
        public async Task Update(PhanLoaiHoGa phanloaihoga)
         {
            try { 
                using var context = _context.CreateDbContext();
                var entity = GetById(phanloaihoga.Id);

                if (entity == null)
                {
                    throw new Exception($"Không tìm thấy bản ghi theo ID: {phanloaihoga.Id}");
                }

                context.PhanLoaiHoGas.Update(phanloaihoga);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public async Task UpdateMulti(PhanLoaiHoGa[] phanloaihoga)
            {
                using var context = _context.CreateDbContext();
                string[] ids = phanloaihoga.Select(x => x.Id).ToArray();
                var listEntities = await context.PhanLoaiHoGas.Where(x => ids.Contains(x.Id)).ToListAsync();
                foreach (var entity in listEntities)
                {
                    context.PhanLoaiHoGas.Update(entity);
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

                context.Set<PhanLoaiHoGa>().Remove(entity);
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
       public async Task<PhanLoaiHoGa> GetById(string id)
            {
                using var context = _context.CreateDbContext();
                var entity = await context.PhanLoaiHoGas.Where(x => x.Id.Equals(id)).FirstOrDefaultAsync();

                if (entity == null)
                {
                    throw new Exception($"Không tìm thấy bản ghi theo ID: {id}");
                }

                return entity;
            }
       public async Task Insert(PhanLoaiHoGa entity)
        {
            try
            {
                using var context = _context.CreateDbContext();
                if (entity == null)
                {
                    throw new Exception("Không có bản ghi nào để thêm!");
                }

                // Kiểm tra xem bảng có bản ghi nào không
                var maxFlag = await context.PhanLoaiHoGas.AnyAsync()
                              ? await context.PhanLoaiHoGas.MaxAsync(x => x.Flag)
                              : 0;

                // Tăng giá trị Flag lên 1
                entity.Flag = maxFlag + 1;
                if (string.IsNullOrEmpty(entity.ThongTinChungHoGa_TenHoGaSauPhanLoai))
                {
                    entity.ThongTinChungHoGa_TenHoGaSauPhanLoai = "GML" + entity.Flag;
                }
                

                // Chèn bản ghi mới vào bảng
                context.PhanLoaiHoGas.Add(entity);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
       public async Task<string> InsertId(PhanLoaiHoGa entity ,string ThongTinChungHoGa_KetCauTuong)
        {
            try
            {
                using var context = _context.CreateDbContext();

                if (entity == null)
                {
                    throw new Exception("Không có bản ghi nào để thêm!");
                }

                // Kiểm tra xem bảng có bản ghi nào không
                var maxFlag = await context.PhanLoaiHoGas.AnyAsync()
                              ? await context.PhanLoaiHoGas.MaxAsync(x => x.Flag)
                              : 0;

                // Tăng giá trị Flag lên 1
                entity.Flag = maxFlag + 1;
                ThongTinChungHoGa_KetCauTuong = ThongTinChungHoGa_KetCauTuong.ToUpper().Trim();
                if (entity.G == "=G")
                {
                    if(ThongTinChungHoGa_KetCauTuong == "Tường bê tông".ToUpper().Trim()  || ThongTinChungHoGa_KetCauTuong == "Tường bê tông cốt thép".ToUpper().Trim())
                    {
                        entity.ThongTinChungHoGa_TenHoGaSauPhanLoai = "GML" + entity.Flag  + "(BT)" + "=G";
                    }
                    else
                    {
                        entity.ThongTinChungHoGa_TenHoGaSauPhanLoai = "GML" + entity.Flag + "=G";
                    }
                }
                else
                {
                    if (ThongTinChungHoGa_KetCauTuong == "Tường bê tông".ToUpper().Trim() || ThongTinChungHoGa_KetCauTuong == "Tường bê tông cốt thép".ToUpper().Trim())
                    {
                        entity.ThongTinChungHoGa_TenHoGaSauPhanLoai = "GML" + entity.Flag + "(BT)";
                    }
                    else
                    {
                        entity.ThongTinChungHoGa_TenHoGaSauPhanLoai = "GML" + entity.Flag;
                    }
                    
                }
                

                // Chèn bản ghi mới vào bảng
                context.PhanLoaiHoGas.Add(entity);
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

        public async Task<string> InsertLaterFlag(PhanLoaiHoGa entity, int FlagLast)
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
                var recordsToUpdate = await context.PhanLoaiHoGas
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
                    var maxFlag = await context.PhanLoaiHoGas.AnyAsync()
                                  ? await context.PhanLoaiHoGas.MaxAsync(x => x.Flag)
                                  : 0;

                    // Tăng giá trị Flag lên 1
                    entity.Flag = maxFlag + 1;
                }
                else
                {
                    entity.Flag = FlagLast + 1;
                }


                // Kiểm tra và gán giá trị nếu trường ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop rỗng
                if (string.IsNullOrEmpty(entity.ThongTinChungHoGa_TenHoGaSauPhanLoai))
                {
                    entity.ThongTinChungHoGa_TenHoGaSauPhanLoai = "loại " + entity.Flag;
                }

                // Bước 4: Chèn bản ghi mới vào bảng
                context.PhanLoaiHoGas.Add(entity);

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
