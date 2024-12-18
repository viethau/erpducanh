using DucAnhERP.Components.Pages.NghiepVuCongTrinh.PKKL;
using DucAnhERP.Data;
using DucAnhERP.Helpers;
using DucAnhERP.Models;
using DucAnhERP.Repository;
using DucAnhERP.ViewModel;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Text;

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
                var entity = await context.PhanLoaiHoGas.OrderBy(x=>x.Flag).ToListAsync();
                return entity;
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.Error.WriteLine($"An error occurred: {ex.Message}");
                throw; // Optionally rethrow the exception
            }
        }
        public async Task<List<PhanLoaiHoGaModel>> GetAllByVM(PhanLoaiHoGaModel Input)
        {
            try
            {
                using var context = _context.CreateDbContext();
                var query = from plhg in context.PhanLoaiHoGas
                            
                            join hinhThucHoGa in context.DSDanhMuc
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
                                Flag = plhg.Flag,
                                IsEdit = context.DSNuocMua.Any(ds => ds.ThongTinChungHoGa_TenHoGaSauPhanLoai == plhg.Id) ? 1 : 0,
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
                                CreateAt = plhg.CreateAt,
                                CreateBy = plhg.CreateBy,
                                IsActive = plhg.IsActive,

                            };

                if (!string.IsNullOrEmpty(Input.ThongTinChungHoGa_HinhThucHoGa))
                {
                    query = query.Where(x => x.ThongTinChungHoGa_HinhThucHoGa == Input.ThongTinChungHoGa_HinhThucHoGa);
                }
                if (!string.IsNullOrEmpty(Input.ThongTinChungHoGa_KetCauMuMo))
                {
                    query = query.Where(x => x.ThongTinChungHoGa_KetCauMuMo == Input.ThongTinChungHoGa_KetCauMuMo);
                }
                if (!string.IsNullOrEmpty(Input.ThongTinChungHoGa_KetCauTuong))
                {
                    query = query.Where(x => x.ThongTinChungHoGa_KetCauTuong == Input.ThongTinChungHoGa_KetCauTuong);
                }
                if (!string.IsNullOrEmpty(Input.ThongTinChungHoGa_HinhThucMongHoGa))
                {
                    query = query.Where(x => x.ThongTinChungHoGa_HinhThucMongHoGa == Input.ThongTinChungHoGa_HinhThucMongHoGa);
                }
                if (!string.IsNullOrEmpty(Input.ThongTinChungHoGa_KetCauMong))
                {
                    query = query.Where(x => x.ThongTinChungHoGa_KetCauMong == Input.ThongTinChungHoGa_KetCauMong);
                }
                var data = await query.ToListAsync();
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi load dữ liệu :"+ex.Message);
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
        public async Task<List<PhanLoaiHoGa>> GetPhanLoaiHoGaByDetails(PhanLoaiHoGa searchData)
        {
            try
            {
                using var context = _context.CreateDbContext();

                // Thực hiện lọc dữ liệu dựa trên các thuộc tính của searchData
                var query = context.PhanLoaiHoGas
                             .Where(plhg => (
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
        public async Task<PhanLoaiHoGa> GetPhanLoaiHoGaExist(PhanLoaiHoGa searchData)
        {
            try
            {
                using var context = _context.CreateDbContext();

                // Thực hiện lọc dữ liệu dựa trên các thuộc tính của searchData
                var query = context.PhanLoaiHoGas
                             .Where(plhg => (
                                        plhg.ThongTinChungHoGa_TenHoGaSauPhanLoai == searchData.ThongTinChungHoGa_TenHoGaSauPhanLoai ||
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

        public async Task<List<SelectedItem>> GetDSPhanLoaiHoGa()
        {
            try
            {
                using var context = _context.CreateDbContext();
                var data = (from a in context.PhanLoaiHoGas
                              join b in context.DSNuocMua on a.Id equals b.ThongTinChungHoGa_TenHoGaSauPhanLoai
                              select new SelectedItem
                              {
                                  Value = a.Id,
                                  Text = a.ThongTinChungHoGa_TenHoGaSauPhanLoai
                              }).Distinct().OrderBy(x => x.Text).ToList();
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi load dữ liệu :" + ex.Message);
            }
        }
        public async Task Update(PhanLoaiHoGa phanloaihoga)
        {
            try
            {
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
        public async Task<PhanLoaiHoGaModel> GetIdByVM(PhanLoaiHoGaModel Input)
        {
            try
            {
                using var context = _context.CreateDbContext();
                var query = from plhg in context.PhanLoaiHoGas
                            join hinhThucHoGa in context.DSDanhMuc
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
                                Flag = plhg.Flag,
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
                                CreateAt = plhg.CreateAt,
                                CreateBy = plhg.CreateBy,
                                IsActive = plhg.IsActive,

                            };
                if (!string.IsNullOrEmpty(Input.Id))
                {
                    query = query.Where(x => x.Id == Input.Id);
                }
                if (!string.IsNullOrEmpty(Input.ThongTinChungHoGa_HinhThucHoGa))
                {
                    query = query.Where(x => x.ThongTinChungHoGa_HinhThucHoGa == Input.ThongTinChungHoGa_HinhThucHoGa);
                }
                if (!string.IsNullOrEmpty(Input.ThongTinChungHoGa_KetCauMuMo))
                {
                    query = query.Where(x => x.ThongTinChungHoGa_KetCauMuMo == Input.ThongTinChungHoGa_KetCauMuMo);
                }
                if (!string.IsNullOrEmpty(Input.ThongTinChungHoGa_KetCauTuong))
                {
                    query = query.Where(x => x.ThongTinChungHoGa_KetCauTuong == Input.ThongTinChungHoGa_KetCauTuong);
                }
                if (!string.IsNullOrEmpty(Input.ThongTinChungHoGa_HinhThucMongHoGa))
                {
                    query = query.Where(x => x.ThongTinChungHoGa_HinhThucMongHoGa == Input.ThongTinChungHoGa_HinhThucMongHoGa);
                }
                if (!string.IsNullOrEmpty(Input.ThongTinChungHoGa_KetCauMong))
                {
                    query = query.Where(x => x.ThongTinChungHoGa_KetCauMong == Input.ThongTinChungHoGa_KetCauMong);
                }
                var data = await query.FirstOrDefaultAsync();
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi load dữ liệu :" + ex.Message);
            }
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
        public async Task<string> InsertId(PhanLoaiHoGa entity, string ThongTinChungHoGa_KetCauTuong ,string TenPL)
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
                if (string.IsNullOrEmpty(TenPL))
                {
                    string formattedFlag = entity.Flag < 10 ? "0" + entity.Flag : entity.Flag.ToString();

                    if (ThongTinChungHoGa_KetCauTuong == "Tường bê tông".ToUpper().Trim() || ThongTinChungHoGa_KetCauTuong == "Tường bê tông cốt thép".ToUpper().Trim())
                    {
                        entity.ThongTinChungHoGa_TenHoGaSauPhanLoai = "GML" + formattedFlag + "(BT)" ;
                    }
                    else
                    {
                        entity.ThongTinChungHoGa_TenHoGaSauPhanLoai = "GML" + formattedFlag;
                    }

                }
                else
                {
                    entity.ThongTinChungHoGa_TenHoGaSauPhanLoai = TenPL ;

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

        //bảng detail
        public async Task<List<NuocMuaModel>> GetPhanLoaiHoGaByTenHGTBV(string ThongTinChungHoGa_TenHoGaTheoBanVe)
        {
            try
            {
                using var context = _context.CreateDbContext();

                var query = from nuocMua in context.DSNuocMua
                                // Left join với bảng PhanLoaiHoGas
                            join phanLoaiHoGa in context.PhanLoaiHoGas
                            on nuocMua.ThongTinChungHoGa_TenHoGaSauPhanLoai equals phanLoaiHoGa.Id into phanLoaiHoGaJoin
                            from phanLoaiHoGa in phanLoaiHoGaJoin.DefaultIfEmpty()
                            where nuocMua.ThongTinChungHoGa_TenHoGaTheoBanVe.StartsWith(ThongTinChungHoGa_TenHoGaTheoBanVe)
                            // Sắp xếp theo Flag của DSNuocMua
                            orderby nuocMua.Flag
                            select new NuocMuaModel
                            {
                                Id = nuocMua.Id,
                                ThongTinLyTrinh_TuyenDuong = nuocMua.ThongTinLyTrinh_TuyenDuong ?? "",
                                ThongTinLyTrinh_LyTrinhTaiTimHoGa = nuocMua.ThongTinLyTrinh_LyTrinhTaiTimHoGa ?? "",
                                ThongTinChungHoGa_TenHoGaSauPhanLoai = phanLoaiHoGa.Id,
                                PhanLoaiHoGas_TenHoGaSauPhanLoai = nuocMua.ThongTinChungHoGa_TenHoGaTheoBanVe != null &&
                                        nuocMua.ThongTinChungHoGa_TenHoGaTheoBanVe.EndsWith("=G")
                                        ? (
                                            (from dsSub in context.DSNuocMua
                                             join plSub in context.PhanLoaiHoGas
                                                 on dsSub.ThongTinChungHoGa_TenHoGaSauPhanLoai equals plSub.Id
                                             where nuocMua.ThongTinChungHoGa_TenHoGaTheoBanVe.Replace("=G", "") == dsSub.ThongTinChungHoGa_TenHoGaTheoBanVe &&
                                                   !dsSub.ThongTinChungHoGa_TenHoGaTheoBanVe.EndsWith("=G")
                                             select plSub.ThongTinChungHoGa_TenHoGaSauPhanLoai)
                                            .FirstOrDefault() ?? phanLoaiHoGa.ThongTinChungHoGa_TenHoGaSauPhanLoai
                                        ) + "=G"
                                        : phanLoaiHoGa.ThongTinChungHoGa_TenHoGaSauPhanLoai,
                                ThongTinChungHoGa_TenHoGaTheoBanVe = nuocMua.ThongTinChungHoGa_TenHoGaTheoBanVe ?? "",
                                
                            };
                var data = await query.ToListAsync();
                return data;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
        public async Task<List<PhanLoaiHoGaDetail>> GetAllDetailsG(string? G="")
        {
            try
            {
                using var context = _context.CreateDbContext();
                var entity = await context.PhanLoaiHoGaDetails.Where(x=>x.G == G).OrderBy(x => x.ThongTinChungHoGa_TenHoGaSauPhanLoai).ToListAsync();
                return entity;
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.Error.WriteLine($"An error occurred: {ex.Message}");
                throw; // Optionally rethrow the exception
            }
        }
        public async Task<PhanLoaiHoGaDetail> GetByIdDetails(string id)
        {
            using var context = _context.CreateDbContext();
            var entity = await context.PhanLoaiHoGaDetails.Where(x => x.Id.Equals(id)).FirstOrDefaultAsync();

            if (entity == null)
            {
                throw new Exception($"Không tìm thấy bản ghi theo ID: {id}");
            }

            return entity;
        }
        public async Task<bool> CheckExclusiveDetails(string[] ids, DateTime baseTime)
        {
            foreach (var id in ids)
            {
                var model = await GetByIdDetails(id);
                if (model == null)
                {
                    throw new Exception($"Không tìm thấy bản ghi theo ID: {id}");
                }
            }
            return true;
        }
        public async Task<PhanLoaiHoGaModel> GetIdByVMDetails(PhanLoaiHoGaModel Input)
        {
            try
            {
                using var context = _context.CreateDbContext();
                var query = from plhg in context.PhanLoaiHoGaDetails
                            join hinhThucHoGa in context.DSDanhMuc
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

                            orderby plhg.ThongTinChungHoGa_TenHoGaSauPhanLoai
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
                            };
                if (!string.IsNullOrEmpty(Input.Id))
                {
                    query = query.Where(x => x.Id == Input.Id);
                }
                if (!string.IsNullOrEmpty(Input.ThongTinChungHoGa_HinhThucHoGa))
                {
                    query = query.Where(x => x.ThongTinChungHoGa_HinhThucHoGa == Input.ThongTinChungHoGa_HinhThucHoGa);
                }
                if (!string.IsNullOrEmpty(Input.ThongTinChungHoGa_KetCauMuMo))
                {
                    query = query.Where(x => x.ThongTinChungHoGa_KetCauMuMo == Input.ThongTinChungHoGa_KetCauMuMo);
                }
                if (!string.IsNullOrEmpty(Input.ThongTinChungHoGa_KetCauTuong))
                {
                    query = query.Where(x => x.ThongTinChungHoGa_KetCauTuong == Input.ThongTinChungHoGa_KetCauTuong);
                }
                if (!string.IsNullOrEmpty(Input.ThongTinChungHoGa_HinhThucMongHoGa))
                {
                    query = query.Where(x => x.ThongTinChungHoGa_HinhThucMongHoGa == Input.ThongTinChungHoGa_HinhThucMongHoGa);
                }
                if (!string.IsNullOrEmpty(Input.ThongTinChungHoGa_KetCauMong))
                {
                    query = query.Where(x => x.ThongTinChungHoGa_KetCauMong == Input.ThongTinChungHoGa_KetCauMong);
                }
                var data = await query.FirstOrDefaultAsync();
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi load dữ liệu :" + ex.Message);
            }
        }
        public async Task<List<PhanLoaiHoGaDetail>> SelectInsertPLHGDetail()
        {
            List<PhanLoaiHoGaDetail> result = new();
            try
            {
                using var context = _context.CreateDbContext();
                var query = (from ds in context.DSNuocMua
                             join pl in context.PhanLoaiHoGas
                                 on ds.ThongTinChungHoGa_TenHoGaSauPhanLoai equals pl.Id into dsJoin
                             from pl in dsJoin.DefaultIfEmpty() // RIGHT JOIN
                             let TenHoGaTheoBanVeNoSuffix = ds.ThongTinChungHoGa_TenHoGaTheoBanVe != null
                                                             ? ds.ThongTinChungHoGa_TenHoGaTheoBanVe.Replace("=G", "")
                                                             : null
                             select new PhanLoaiHoGaDetail
                             {
                                 Id_PhanLoaiHoGa = pl.Id,
                                 ThongTinChungHoGa_TenHoGaSauPhanLoai =
                                     ds.ThongTinChungHoGa_TenHoGaTheoBanVe != null &&
                                     ds.ThongTinChungHoGa_TenHoGaTheoBanVe.Contains("=G")
                                     ? (
                                         (from subDs in context.DSNuocMua
                                          join subPl in context.PhanLoaiHoGas on subDs.ThongTinChungHoGa_TenHoGaSauPhanLoai equals subPl.Id
                                          where subDs.ThongTinChungHoGa_TenHoGaTheoBanVe == TenHoGaTheoBanVeNoSuffix &&
                                                !subDs.ThongTinChungHoGa_TenHoGaTheoBanVe.Contains("=G")
                                          select subPl.ThongTinChungHoGa_TenHoGaSauPhanLoai)
                                         .FirstOrDefault() + "=G"
                                       )
                                     : pl.ThongTinChungHoGa_TenHoGaSauPhanLoai,
                                 G = ds.ThongTinChungHoGa_TenHoGaTheoBanVe != null && ds.ThongTinChungHoGa_TenHoGaTheoBanVe.Contains("=G") ? "=G" : "",
                                 ThongTinChungHoGa_HinhThucHoGa = pl.ThongTinChungHoGa_HinhThucHoGa,
                                 ThongTinChungHoGa_KetCauMuMo = pl.ThongTinChungHoGa_KetCauMuMo,
                                 ThongTinChungHoGa_KetCauTuong = pl.ThongTinChungHoGa_KetCauTuong,
                                 ThongTinChungHoGa_HinhThucMongHoGa = pl.ThongTinChungHoGa_HinhThucMongHoGa,
                                 ThongTinChungHoGa_KetCauMong = pl.ThongTinChungHoGa_KetCauMong,
                                 ThongTinChungHoGa_ChatMatTrong = pl.ThongTinChungHoGa_ChatMatTrong,
                                 ThongTinChungHoGa_ChatMatNgoai = pl.ThongTinChungHoGa_ChatMatNgoai,
                                 PhuBiHoGa_CDai = pl.PhuBiHoGa_CDai,
                                 PhuBiHoGa_CRong = pl.PhuBiHoGa_CRong,
                                 BeTongLotMong_D = pl.BeTongLotMong_D,
                                 BeTongLotMong_R = pl.BeTongLotMong_R,
                                 BeTongLotMong_C = pl.BeTongLotMong_C,
                                 BeTongMongHoGa_D = pl.BeTongMongHoGa_D,
                                 BeTongMongHoGa_R = pl.BeTongMongHoGa_R,
                                 BeTongMongHoGa_C = pl.BeTongMongHoGa_C,
                                 DeHoGa_D = pl.DeHoGa_D,
                                 DeHoGa_R = pl.DeHoGa_R,
                                 DeHoGa_C = pl.DeHoGa_C,
                                 TuongHoGa_D = pl.TuongHoGa_D,
                                 TuongHoGa_R = pl.TuongHoGa_R,
                                 TuongHoGa_C = pl.TuongHoGa_C,
                                 TuongHoGa_CdTuong = pl.TuongHoGa_CdTuong,
                                 DamGiuaHoGa_D = pl.DamGiuaHoGa_D,
                                 DamGiuaHoGa_R = pl.DamGiuaHoGa_R,
                                 DamGiuaHoGa_C = pl.DamGiuaHoGa_C,
                                 DamGiuaHoGa_CdDam = pl.DamGiuaHoGa_CdDam,
                                 DamGiuaHoGa_CCaoDamGiuaTuongSoVoiDayHoGa = pl.DamGiuaHoGa_CCaoDamGiuaTuongSoVoiDayHoGa,
                                 ChatMatTrong_D = pl.ChatMatTrong_D,
                                 ChatMatTrong_R = pl.ChatMatTrong_R,
                                 ChatMatTrong_C = pl.ChatMatTrong_C,
                                 ChatMatNgoaiCanh_D = pl.ChatMatNgoaiCanh_D,
                                 ChatMatNgoaiCanh_R = pl.ChatMatNgoaiCanh_R,
                                 ChatMatNgoaiCanh_C = pl.ChatMatNgoaiCanh_C,
                                 MuMoThotDuoi_D = pl.MuMoThotDuoi_D,
                                 MuMoThotDuoi_R = pl.MuMoThotDuoi_R,
                                 MuMoThotDuoi_C = pl.MuMoThotDuoi_C,
                                 MuMoThotDuoi_CdTuong = pl.MuMoThotDuoi_CdTuong,
                                 MuMoThotTren_D = pl.MuMoThotTren_D,
                                 MuMoThotTren_R = pl.MuMoThotTren_R,
                                 MuMoThotTren_C = pl.MuMoThotTren_C,
                                 MuMoThotTren_CdTuong = pl.MuMoThotTren_CdTuong,
                                 HinhThucDauNoi1_Loai = pl.HinhThucDauNoi1_Loai,
                                 HinhThucDauNoi1_CanhDai = pl.HinhThucDauNoi1_CanhDai,
                                 HinhThucDauNoi1_CanhRong = pl.HinhThucDauNoi1_CanhRong,
                                 HinhThucDauNoi1_CanhCheo = pl.HinhThucDauNoi1_CanhCheo,
                                 HinhThucDauNoi2_Loai = pl.HinhThucDauNoi2_Loai,
                                 HinhThucDauNoi2_CanhDai = pl.HinhThucDauNoi2_CanhDai,
                                 HinhThucDauNoi2_CanhRong = pl.HinhThucDauNoi2_CanhRong,
                                 HinhThucDauNoi2_CanhCheo = pl.HinhThucDauNoi2_CanhCheo,
                                 HinhThucDauNoi3_Loai = pl.HinhThucDauNoi3_Loai,
                                 HinhThucDauNoi3_CanhDai = pl.HinhThucDauNoi3_CanhDai,
                                 HinhThucDauNoi3_CanhRong = pl.HinhThucDauNoi3_CanhRong,
                                 HinhThucDauNoi3_CanhCheo = pl.HinhThucDauNoi3_CanhCheo,
                                 HinhThucDauNoi4_Loai = pl.HinhThucDauNoi4_Loai,
                                 HinhThucDauNoi4_CanhDai = pl.HinhThucDauNoi4_CanhDai,
                                 HinhThucDauNoi4_CanhRong = pl.HinhThucDauNoi4_CanhRong,
                                 HinhThucDauNoi4_CanhCheo = pl.HinhThucDauNoi4_CanhCheo,
                                 HinhThucDauNoi5_Loai = pl.HinhThucDauNoi5_Loai,
                                 HinhThucDauNoi5_CanhDai = pl.HinhThucDauNoi5_CanhDai,
                                 HinhThucDauNoi5_CanhRong = pl.HinhThucDauNoi5_CanhRong,
                                 HinhThucDauNoi5_CanhCheo = pl.HinhThucDauNoi5_CanhCheo,
                                 HinhThucDauNoi6_Loai = pl.HinhThucDauNoi6_Loai,
                                 HinhThucDauNoi6_CanhDai = pl.HinhThucDauNoi6_CanhDai,
                                 HinhThucDauNoi6_CanhRong = pl.HinhThucDauNoi6_CanhRong,
                                 HinhThucDauNoi6_CanhCheo = pl.HinhThucDauNoi6_CanhCheo,
                                 HinhThucDauNoi7_Loai = pl.HinhThucDauNoi7_Loai,
                                 HinhThucDauNoi7_CanhDai = pl.HinhThucDauNoi7_CanhDai,
                                 HinhThucDauNoi7_CanhRong = pl.HinhThucDauNoi7_CanhRong,
                                 HinhThucDauNoi7_CanhCheo = pl.HinhThucDauNoi7_CanhCheo,
                                 HinhThucDauNoi8_Loai = pl.HinhThucDauNoi8_Loai,
                                 HinhThucDauNoi8_CanhDai = pl.HinhThucDauNoi8_CanhDai,
                                 HinhThucDauNoi8_CanhRong = pl.HinhThucDauNoi8_CanhRong,
                                 HinhThucDauNoi8_CanhCheo = pl.HinhThucDauNoi8_CanhCheo
                             })
                             .Distinct().Where(x => x.Id_PhanLoaiHoGa != null)
                             .OrderBy(x => x.ThongTinChungHoGa_TenHoGaSauPhanLoai).ToList();
                result = query;
                // INSERT 
                context.PhanLoaiHoGaDetails.AddRange(query);
                context.SaveChanges();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi select insert PhanLoaiHoGaDetails " + ex.Message);
                throw;
            }

            return result;
        }
        public async Task<List<PhanLoaiHoGaDetail>> InsertMissingPhanLoaiHoGaDetails()
        {
            List<PhanLoaiHoGaDetail> result = new();
            try
            {
                using var context = _context.CreateDbContext();
                var query = (from ds in context.DSNuocMua
                             join pl in context.PhanLoaiHoGas
                                 on ds.ThongTinChungHoGa_TenHoGaSauPhanLoai equals pl.Id into dsJoin
                             from pl in dsJoin.DefaultIfEmpty() // RIGHT JOIN
                             let TenHoGaTheoBanVeNoSuffix = ds.ThongTinChungHoGa_TenHoGaTheoBanVe != null
                                                             ? ds.ThongTinChungHoGa_TenHoGaTheoBanVe.Replace("=G", "")
                                                             : null
                             select new PhanLoaiHoGaDetail
                             {
                                 Id_PhanLoaiHoGa = pl.Id,
                                 ThongTinChungHoGa_TenHoGaSauPhanLoai =
                                     ds.ThongTinChungHoGa_TenHoGaTheoBanVe != null &&
                                     ds.ThongTinChungHoGa_TenHoGaTheoBanVe.Contains("=G")
                                     ? (
                                         (from subDs in context.DSNuocMua
                                          join subPl in context.PhanLoaiHoGas on subDs.ThongTinChungHoGa_TenHoGaSauPhanLoai equals subPl.Id
                                          where subDs.ThongTinChungHoGa_TenHoGaTheoBanVe == TenHoGaTheoBanVeNoSuffix &&
                                                !subDs.ThongTinChungHoGa_TenHoGaTheoBanVe.Contains("=G")
                                          select subPl.ThongTinChungHoGa_TenHoGaSauPhanLoai)
                                         .FirstOrDefault() + "=G"
                                       )
                                     : pl.ThongTinChungHoGa_TenHoGaSauPhanLoai,
                                    G = ds.ThongTinChungHoGa_TenHoGaTheoBanVe != null &&
                                     ds.ThongTinChungHoGa_TenHoGaTheoBanVe.Contains("=G") ? "=G" : "",
                                 ThongTinChungHoGa_HinhThucHoGa = pl.ThongTinChungHoGa_HinhThucHoGa,
                                 ThongTinChungHoGa_KetCauMuMo = pl.ThongTinChungHoGa_KetCauMuMo,
                                 ThongTinChungHoGa_KetCauTuong = pl.ThongTinChungHoGa_KetCauTuong,
                                 ThongTinChungHoGa_HinhThucMongHoGa = pl.ThongTinChungHoGa_HinhThucMongHoGa,
                                 ThongTinChungHoGa_KetCauMong = pl.ThongTinChungHoGa_KetCauMong,
                                 ThongTinChungHoGa_ChatMatTrong = pl.ThongTinChungHoGa_ChatMatTrong,
                                 ThongTinChungHoGa_ChatMatNgoai = pl.ThongTinChungHoGa_ChatMatNgoai,
                                 PhuBiHoGa_CDai = pl.PhuBiHoGa_CDai,
                                 PhuBiHoGa_CRong = pl.PhuBiHoGa_CRong,
                                 BeTongLotMong_D = pl.BeTongLotMong_D,
                                 BeTongLotMong_R = pl.BeTongLotMong_R,
                                 BeTongLotMong_C = pl.BeTongLotMong_C,
                                 BeTongMongHoGa_D = pl.BeTongMongHoGa_D,
                                 BeTongMongHoGa_R = pl.BeTongMongHoGa_R,
                                 BeTongMongHoGa_C = pl.BeTongMongHoGa_C,
                                 DeHoGa_D = pl.DeHoGa_D,
                                 DeHoGa_R = pl.DeHoGa_R,
                                 DeHoGa_C = pl.DeHoGa_C,
                                 TuongHoGa_D = pl.TuongHoGa_D,
                                 TuongHoGa_R = pl.TuongHoGa_R,
                                 TuongHoGa_C = pl.TuongHoGa_C,
                                 TuongHoGa_CdTuong = pl.TuongHoGa_CdTuong,
                                 DamGiuaHoGa_D = pl.DamGiuaHoGa_D,
                                 DamGiuaHoGa_R = pl.DamGiuaHoGa_R,
                                 DamGiuaHoGa_C = pl.DamGiuaHoGa_C,
                                 DamGiuaHoGa_CdDam = pl.DamGiuaHoGa_CdDam,
                                 DamGiuaHoGa_CCaoDamGiuaTuongSoVoiDayHoGa = pl.DamGiuaHoGa_CCaoDamGiuaTuongSoVoiDayHoGa,
                                 ChatMatTrong_D = pl.ChatMatTrong_D,
                                 ChatMatTrong_R = pl.ChatMatTrong_R,
                                 ChatMatTrong_C = pl.ChatMatTrong_C,
                                 ChatMatNgoaiCanh_D = pl.ChatMatNgoaiCanh_D,
                                 ChatMatNgoaiCanh_R = pl.ChatMatNgoaiCanh_R,
                                 ChatMatNgoaiCanh_C = pl.ChatMatNgoaiCanh_C,
                                 MuMoThotDuoi_D = pl.MuMoThotDuoi_D,
                                 MuMoThotDuoi_R = pl.MuMoThotDuoi_R,
                                 MuMoThotDuoi_C = pl.MuMoThotDuoi_C,
                                 MuMoThotDuoi_CdTuong = pl.MuMoThotDuoi_CdTuong,
                                 MuMoThotTren_D = pl.MuMoThotTren_D,
                                 MuMoThotTren_R = pl.MuMoThotTren_R,
                                 MuMoThotTren_C = pl.MuMoThotTren_C,
                                 MuMoThotTren_CdTuong = pl.MuMoThotTren_CdTuong,
                                 HinhThucDauNoi1_Loai = pl.HinhThucDauNoi1_Loai,
                                 HinhThucDauNoi1_CanhDai = pl.HinhThucDauNoi1_CanhDai,
                                 HinhThucDauNoi1_CanhRong = pl.HinhThucDauNoi1_CanhRong,
                                 HinhThucDauNoi1_CanhCheo = pl.HinhThucDauNoi1_CanhCheo,
                                 HinhThucDauNoi2_Loai = pl.HinhThucDauNoi2_Loai,
                                 HinhThucDauNoi2_CanhDai = pl.HinhThucDauNoi2_CanhDai,
                                 HinhThucDauNoi2_CanhRong = pl.HinhThucDauNoi2_CanhRong,
                                 HinhThucDauNoi2_CanhCheo = pl.HinhThucDauNoi2_CanhCheo,
                                 HinhThucDauNoi3_Loai = pl.HinhThucDauNoi3_Loai,
                                 HinhThucDauNoi3_CanhDai = pl.HinhThucDauNoi3_CanhDai,
                                 HinhThucDauNoi3_CanhRong = pl.HinhThucDauNoi3_CanhRong,
                                 HinhThucDauNoi3_CanhCheo = pl.HinhThucDauNoi3_CanhCheo,
                                 HinhThucDauNoi4_Loai = pl.HinhThucDauNoi4_Loai,
                                 HinhThucDauNoi4_CanhDai = pl.HinhThucDauNoi4_CanhDai,
                                 HinhThucDauNoi4_CanhRong = pl.HinhThucDauNoi4_CanhRong,
                                 HinhThucDauNoi4_CanhCheo = pl.HinhThucDauNoi4_CanhCheo,
                                 HinhThucDauNoi5_Loai = pl.HinhThucDauNoi5_Loai,
                                 HinhThucDauNoi5_CanhDai = pl.HinhThucDauNoi5_CanhDai,
                                 HinhThucDauNoi5_CanhRong = pl.HinhThucDauNoi5_CanhRong,
                                 HinhThucDauNoi5_CanhCheo = pl.HinhThucDauNoi5_CanhCheo,
                                 HinhThucDauNoi6_Loai = pl.HinhThucDauNoi6_Loai,
                                 HinhThucDauNoi6_CanhDai = pl.HinhThucDauNoi6_CanhDai,
                                 HinhThucDauNoi6_CanhRong = pl.HinhThucDauNoi6_CanhRong,
                                 HinhThucDauNoi6_CanhCheo = pl.HinhThucDauNoi6_CanhCheo,
                                 HinhThucDauNoi7_Loai = pl.HinhThucDauNoi7_Loai,
                                 HinhThucDauNoi7_CanhDai = pl.HinhThucDauNoi7_CanhDai,
                                 HinhThucDauNoi7_CanhRong = pl.HinhThucDauNoi7_CanhRong,
                                 HinhThucDauNoi7_CanhCheo = pl.HinhThucDauNoi7_CanhCheo,
                                 HinhThucDauNoi8_Loai = pl.HinhThucDauNoi8_Loai,
                                 HinhThucDauNoi8_CanhDai = pl.HinhThucDauNoi8_CanhDai,
                                 HinhThucDauNoi8_CanhRong = pl.HinhThucDauNoi8_CanhRong,
                                 HinhThucDauNoi8_CanhCheo = pl.HinhThucDauNoi8_CanhCheo
                             })
                             .Distinct().Where(x => x.Id_PhanLoaiHoGa != null)
                             .OrderBy(x => x.ThongTinChungHoGa_TenHoGaSauPhanLoai).ToList();

                // Kiểm tra sự tồn tại trước khi thêm
                foreach (var item in query)
                {
                    bool exists = context.PhanLoaiHoGaDetails.Any(plhg => plhg.Id_PhanLoaiHoGa == item.Id_PhanLoaiHoGa &&
                                                plhg.ThongTinChungHoGa_TenHoGaSauPhanLoai == item.ThongTinChungHoGa_TenHoGaSauPhanLoai &&
                                                plhg.G == item.G &&
                                                plhg.ThongTinChungHoGa_HinhThucHoGa == item.ThongTinChungHoGa_HinhThucHoGa &&
                                                plhg.ThongTinChungHoGa_KetCauMuMo == item.ThongTinChungHoGa_KetCauMuMo &&
                                                plhg.ThongTinChungHoGa_KetCauTuong == item.ThongTinChungHoGa_KetCauTuong &&
                                                plhg.ThongTinChungHoGa_HinhThucMongHoGa == item.ThongTinChungHoGa_HinhThucMongHoGa &&
                                                plhg.ThongTinChungHoGa_KetCauMong == item.ThongTinChungHoGa_KetCauMong &&
                                                plhg.ThongTinChungHoGa_ChatMatTrong == item.ThongTinChungHoGa_ChatMatTrong &&
                                                plhg.ThongTinChungHoGa_ChatMatNgoai == item.ThongTinChungHoGa_ChatMatNgoai &&
                                                plhg.PhuBiHoGa_CDai == item.PhuBiHoGa_CDai &&
                                                plhg.PhuBiHoGa_CRong == item.PhuBiHoGa_CRong &&
                                                plhg.BeTongLotMong_D == item.BeTongLotMong_D &&
                                                plhg.BeTongLotMong_R == item.BeTongLotMong_R &&
                                                plhg.BeTongLotMong_C == item.BeTongLotMong_C &&
                                                plhg.BeTongMongHoGa_D == item.BeTongMongHoGa_D &&
                                                plhg.BeTongMongHoGa_R == item.BeTongMongHoGa_R &&
                                                plhg.BeTongMongHoGa_C == item.BeTongMongHoGa_C &&
                                                plhg.DeHoGa_D == item.DeHoGa_D &&
                                                plhg.DeHoGa_R == item.DeHoGa_R &&
                                                plhg.DeHoGa_C == item.DeHoGa_C &&
                                                plhg.TuongHoGa_D == item.TuongHoGa_D &&
                                                plhg.TuongHoGa_R == item.TuongHoGa_R &&
                                                plhg.TuongHoGa_C == item.TuongHoGa_C &&
                                                plhg.TuongHoGa_CdTuong == item.TuongHoGa_CdTuong &&
                                                plhg.DamGiuaHoGa_D == item.DamGiuaHoGa_D &&
                                                plhg.DamGiuaHoGa_R == item.DamGiuaHoGa_R &&
                                                plhg.DamGiuaHoGa_C == item.DamGiuaHoGa_C &&
                                                plhg.DamGiuaHoGa_CdDam == item.DamGiuaHoGa_CdDam &&
                                                plhg.DamGiuaHoGa_CCaoDamGiuaTuongSoVoiDayHoGa == item.DamGiuaHoGa_CCaoDamGiuaTuongSoVoiDayHoGa &&
                                                plhg.ChatMatTrong_D == item.ChatMatTrong_D &&
                                                plhg.ChatMatTrong_R == item.ChatMatTrong_R &&
                                                plhg.ChatMatTrong_C == item.ChatMatTrong_C &&
                                                plhg.ChatMatNgoaiCanh_D == item.ChatMatNgoaiCanh_D &&
                                                plhg.ChatMatNgoaiCanh_R == item.ChatMatNgoaiCanh_R &&
                                                plhg.ChatMatNgoaiCanh_C == item.ChatMatNgoaiCanh_C &&
                                                plhg.MuMoThotDuoi_D == item.MuMoThotDuoi_D &&
                                                plhg.MuMoThotDuoi_R == item.MuMoThotDuoi_R &&
                                                plhg.MuMoThotDuoi_C == item.MuMoThotDuoi_C &&
                                                plhg.MuMoThotDuoi_CdTuong == item.MuMoThotDuoi_CdTuong &&
                                                plhg.MuMoThotTren_D == item.MuMoThotTren_D &&
                                                plhg.MuMoThotTren_R == item.MuMoThotTren_R &&
                                                plhg.MuMoThotTren_C == item.MuMoThotTren_C &&
                                                plhg.MuMoThotTren_CdTuong == item.MuMoThotTren_CdTuong &&
                                                plhg.HinhThucDauNoi1_Loai == item.HinhThucDauNoi1_Loai &&
                                                plhg.HinhThucDauNoi1_CanhDai == item.HinhThucDauNoi1_CanhDai &&
                                                plhg.HinhThucDauNoi1_CanhRong == item.HinhThucDauNoi1_CanhRong &&
                                                plhg.HinhThucDauNoi1_CanhCheo == item.HinhThucDauNoi1_CanhCheo &&
                                                plhg.HinhThucDauNoi2_Loai == item.HinhThucDauNoi2_Loai &&
                                                plhg.HinhThucDauNoi2_CanhDai == item.HinhThucDauNoi2_CanhDai &&
                                                plhg.HinhThucDauNoi2_CanhRong == item.HinhThucDauNoi2_CanhRong &&
                                                plhg.HinhThucDauNoi2_CanhCheo == item.HinhThucDauNoi2_CanhCheo &&
                                                plhg.HinhThucDauNoi3_Loai == item.HinhThucDauNoi3_Loai &&
                                                plhg.HinhThucDauNoi3_CanhDai == item.HinhThucDauNoi3_CanhDai &&
                                                plhg.HinhThucDauNoi3_CanhRong == item.HinhThucDauNoi3_CanhRong &&
                                                plhg.HinhThucDauNoi3_CanhCheo == item.HinhThucDauNoi3_CanhCheo &&
                                                plhg.HinhThucDauNoi4_Loai == item.HinhThucDauNoi4_Loai &&
                                                plhg.HinhThucDauNoi4_CanhDai == item.HinhThucDauNoi4_CanhDai &&
                                                plhg.HinhThucDauNoi4_CanhRong == item.HinhThucDauNoi4_CanhRong &&
                                                plhg.HinhThucDauNoi4_CanhCheo == item.HinhThucDauNoi4_CanhCheo &&
                                                plhg.HinhThucDauNoi5_Loai == item.HinhThucDauNoi5_Loai &&
                                                plhg.HinhThucDauNoi5_CanhDai == item.HinhThucDauNoi5_CanhDai &&
                                                plhg.HinhThucDauNoi5_CanhRong == item.HinhThucDauNoi5_CanhRong &&
                                                plhg.HinhThucDauNoi5_CanhCheo == item.HinhThucDauNoi5_CanhCheo &&
                                                plhg.HinhThucDauNoi6_Loai == item.HinhThucDauNoi6_Loai &&
                                                plhg.HinhThucDauNoi6_CanhDai == item.HinhThucDauNoi6_CanhDai &&
                                                plhg.HinhThucDauNoi6_CanhRong == item.HinhThucDauNoi6_CanhRong &&
                                                plhg.HinhThucDauNoi6_CanhCheo == item.HinhThucDauNoi6_CanhCheo &&
                                                plhg.HinhThucDauNoi7_Loai == item.HinhThucDauNoi7_Loai &&
                                                plhg.HinhThucDauNoi7_CanhDai == item.HinhThucDauNoi7_CanhDai &&
                                                plhg.HinhThucDauNoi7_CanhRong == item.HinhThucDauNoi7_CanhRong &&
                                                plhg.HinhThucDauNoi7_CanhCheo == item.HinhThucDauNoi7_CanhCheo &&
                                                plhg.HinhThucDauNoi8_Loai == item.HinhThucDauNoi8_Loai &&
                                                plhg.HinhThucDauNoi8_CanhDai == item.HinhThucDauNoi8_CanhDai &&
                                                plhg.HinhThucDauNoi8_CanhRong == item.HinhThucDauNoi8_CanhRong &&
                                                plhg.HinhThucDauNoi8_CanhCheo == item.HinhThucDauNoi8_CanhCheo);
                    if (!exists)
                    {
                        result.Add(item);
                    }
                }

                // Thêm các bản ghi mới
                if (result.Any())
                {
                    context.PhanLoaiHoGaDetails.AddRange(result);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi select insert PhanLoaiHoGaDetails " + ex.Message);
                throw;
            }

            return result;
        }

        //báo cáo
        //public async Task<List<PhanLoaiHoGaModel>> GetBaoCaoCTaoCHungHGa(PhanLoaiHoGaModel plhgModel)
        //{
        //    try
        //    {
        //        using var context = _context.CreateDbContext();

        //        var query = from plhg in context.PhanLoaiHoGaDetails
        //                    join hinhThucHoGa in context.DSDanhMuc
        //                        on plhg.ThongTinChungHoGa_HinhThucHoGa equals hinhThucHoGa.Id
        //                    join ketCauMuMo in context.DSDanhMuc
        //                        on plhg.ThongTinChungHoGa_KetCauMuMo equals ketCauMuMo.Id
        //                    join ketCauTuong in context.DSDanhMuc
        //                        on plhg.ThongTinChungHoGa_KetCauTuong equals ketCauTuong.Id
        //                    join hinhThucMongHoGa in context.DSDanhMuc
        //                        on plhg.ThongTinChungHoGa_HinhThucMongHoGa equals hinhThucMongHoGa.Id
        //                    join ketCauMong in context.DSDanhMuc
        //                        on plhg.ThongTinChungHoGa_KetCauMong equals ketCauMong.Id

        //                    join chatMatTrong in context.DSDanhMuc
        //                        on plhg.ThongTinChungHoGa_ChatMatTrong equals chatMatTrong.Id into gj2
        //                    from chatMatTrong in gj2.DefaultIfEmpty() // Left join
        //                    join chatMatNgoai in context.DSDanhMuc
        //                        on plhg.ThongTinChungHoGa_ChatMatNgoai equals chatMatNgoai.Id into gj3
        //                    from chatMatNgoai in gj3.DefaultIfEmpty() // Left join

        //                    select new PhanLoaiHoGaModel
        //                    {
        //                        Id = plhg.Id,
        //                        ThongTinChungHoGa_TenHoGaSauPhanLoai = plhg.ThongTinChungHoGa_TenHoGaSauPhanLoai ?? "",
        //                        ThongTinChungHoGa_HinhThucHoGa = plhg.ThongTinChungHoGa_HinhThucHoGa ?? "",
        //                        ThongTinChungHoGa_HinhThucHoGa_Name = hinhThucHoGa.Ten ?? "",
        //                        ThongTinChungHoGa_KetCauMuMo = plhg.ThongTinChungHoGa_KetCauMuMo ?? "",
        //                        ThongTinChungHoGa_KetCauMuMo_Name = ketCauMuMo.Ten ?? "",
        //                        ThongTinChungHoGa_KetCauTuong = plhg.ThongTinChungHoGa_KetCauTuong ?? "",
        //                        ThongTinChungHoGa_KetCauTuong_Name = ketCauTuong.Ten ?? "",
        //                        ThongTinChungHoGa_HinhThucMongHoGa = plhg.ThongTinChungHoGa_HinhThucMongHoGa ?? "",
        //                        ThongTinChungHoGa_HinhThucMongHoGa_Name = hinhThucMongHoGa.Ten ?? "",
        //                        ThongTinChungHoGa_KetCauMong = plhg.ThongTinChungHoGa_KetCauMong ?? "",
        //                        ThongTinChungHoGa_KetCauMong_Name = ketCauMong.Ten ?? "",
        //                        ThongTinChungHoGa_ChatMatTrong = plhg.ThongTinChungHoGa_ChatMatTrong ?? "",
        //                        ThongTinChungHoGa_ChatMatTrong_Name = chatMatTrong.Ten ?? "",
        //                        ThongTinChungHoGa_ChatMatNgoai = plhg.ThongTinChungHoGa_ChatMatNgoai ?? "",
        //                        ThongTinChungHoGa_ChatMatNgoai_Name = chatMatNgoai.Ten ?? "",
        //                        PhuBiHoGa_CDai = plhg.PhuBiHoGa_CDai ?? 0,
        //                        PhuBiHoGa_CRong = plhg.PhuBiHoGa_CRong ?? 0,

        //                    };

        //        if (!string.IsNullOrEmpty(plhgModel.ThongTinChungHoGa_HinhThucHoGa))
        //        {
        //            query = query.Where(x => x.ThongTinChungHoGa_HinhThucHoGa == plhgModel.ThongTinChungHoGa_HinhThucHoGa);
        //        }
        //        if (!string.IsNullOrEmpty(plhgModel.ThongTinChungHoGa_KetCauMuMo))
        //        {
        //            query = query.Where(x => x.ThongTinChungHoGa_KetCauMuMo == plhgModel.ThongTinChungHoGa_KetCauMuMo);
        //        }
        //        if (!string.IsNullOrEmpty(plhgModel.ThongTinChungHoGa_KetCauTuong))
        //        {
        //            query = query.Where(x => x.ThongTinChungHoGa_KetCauTuong == plhgModel.ThongTinChungHoGa_KetCauTuong);
        //        }
        //        if (!string.IsNullOrEmpty(plhgModel.ThongTinChungHoGa_HinhThucMongHoGa))
        //        {
        //            query = query.Where(x => x.ThongTinChungHoGa_HinhThucMongHoGa == plhgModel.ThongTinChungHoGa_HinhThucMongHoGa);
        //        }
        //        if (!string.IsNullOrEmpty(plhgModel.ThongTinChungHoGa_KetCauMong))
        //        {
        //            query = query.Where(x => x.ThongTinChungHoGa_KetCauMong == plhgModel.ThongTinChungHoGa_KetCauMong);
        //        }
        //        var data = await query
        //            .ToListAsync();
        //        return data;
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.ToString());
        //        throw;
        //    }

        //}

        //public async Task<List<PhanLoaiHoGaModel>> GetBaoCaoHGaSDThep(PhanLoaiHoGaModel plhgModel)
        //{
        //    try
        //    {
        //        using var context = _context.CreateDbContext();
        //        var query = from plhg in context.PhanLoaiHoGas
        //                    join hinhThucHoGa in context.DSDanhMuc
        //                        on plhg.ThongTinChungHoGa_HinhThucHoGa equals hinhThucHoGa.Id
        //                    join ketCauMuMo in context.DSDanhMuc
        //                        on plhg.ThongTinChungHoGa_KetCauMuMo equals ketCauMuMo.Id
        //                    join ketCauTuong in context.DSDanhMuc
        //                        on plhg.ThongTinChungHoGa_KetCauTuong equals ketCauTuong.Id
        //                    join hinhThucMongHoGa in context.DSDanhMuc
        //                        on plhg.ThongTinChungHoGa_HinhThucMongHoGa equals hinhThucMongHoGa.Id
        //                    join ketCauMong in context.DSDanhMuc
        //                        on plhg.ThongTinChungHoGa_KetCauMong equals ketCauMong.Id

        //                    orderby plhg.Flag
        //                    select new PhanLoaiHoGaModel
        //                    {
        //                        Id = plhg.Id,
        //                        Flag = plhg.Flag,
        //                        ThongTinChungHoGa_TenHoGaSauPhanLoai = plhg.ThongTinChungHoGa_TenHoGaSauPhanLoai ?? "",
        //                        ThongTinChungHoGa_HinhThucHoGa = plhg.ThongTinChungHoGa_HinhThucHoGa ?? "",
        //                        ThongTinChungHoGa_HinhThucHoGa_Name = hinhThucHoGa.Ten ?? "",
        //                        ThongTinChungHoGa_KetCauMuMo = plhg.ThongTinChungHoGa_KetCauMuMo ?? "",
        //                        ThongTinChungHoGa_KetCauMuMo_Name = ketCauMuMo.Ten ?? "",
        //                        ThongTinChungHoGa_KetCauTuong = plhg.ThongTinChungHoGa_KetCauTuong ?? "",
        //                        ThongTinChungHoGa_KetCauTuong_Name = ketCauTuong.Ten ?? "",
        //                        ThongTinChungHoGa_KetCauMong = plhg.ThongTinChungHoGa_KetCauMong ?? "",
        //                        ThongTinChungHoGa_KetCauMong_Name = ketCauMong.Ten ?? "",
        //                        CreateAt = plhg.CreateAt,
        //                        CreateBy = plhg.CreateBy,
        //                        IsActive = plhg.IsActive,

        //                    };
        //        if (!string.IsNullOrEmpty(plhgModel.ThongTinChungHoGa_KetCauMuMo))
        //        {
        //            query = query.Where(x => x.ThongTinChungHoGa_KetCauMuMo == plhgModel.ThongTinChungHoGa_KetCauMuMo);
        //        }
        //        if (!string.IsNullOrEmpty(plhgModel.ThongTinChungHoGa_KetCauTuong))
        //        {
        //            query = query.Where(x => x.ThongTinChungHoGa_KetCauTuong == plhgModel.ThongTinChungHoGa_KetCauTuong);
        //        }
        //        if (!string.IsNullOrEmpty(plhgModel.ThongTinChungHoGa_KetCauMong))
        //        {
        //            query = query.Where(x => x.ThongTinChungHoGa_KetCauMong == plhgModel.ThongTinChungHoGa_KetCauMong);
        //        }
        //        var data = await query
        //            .ToListAsync();
        //        return data;
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.ToString());
        //        throw;
        //    }
        //}

        public async Task<List<PhanLoaiHoGaModel>> GetBaoCaoCTaoCHungHGa(PhanLoaiHoGaModel plhgModel)
        {
            List<PhanLoaiHoGaModel> result = new();
            try
            {
                using var context = _context.CreateDbContext();
                var query = (from ds in context.DSNuocMua
                             join pl in context.PhanLoaiHoGas
                                 on ds.ThongTinChungHoGa_TenHoGaSauPhanLoai equals pl.Id into dsJoin
                             from pl in dsJoin.DefaultIfEmpty() // RIGHT JOIN
                             join hinhThucHoGa in context.DSDanhMuc
                                on pl.ThongTinChungHoGa_HinhThucHoGa equals hinhThucHoGa.Id
                             join ketCauMuMo in context.DSDanhMuc
                                 on pl.ThongTinChungHoGa_KetCauMuMo equals ketCauMuMo.Id
                             join ketCauTuong in context.DSDanhMuc
                                 on pl.ThongTinChungHoGa_KetCauTuong equals ketCauTuong.Id
                             join hinhThucMongHoGa in context.DSDanhMuc
                                 on pl.ThongTinChungHoGa_HinhThucMongHoGa equals hinhThucMongHoGa.Id
                             join ketCauMong in context.DSDanhMuc
                                 on pl.ThongTinChungHoGa_KetCauMong equals ketCauMong.Id

                             join chatMatTrong in context.DSDanhMuc
                                 on pl.ThongTinChungHoGa_ChatMatTrong equals chatMatTrong.Id into gj2
                             from chatMatTrong in gj2.DefaultIfEmpty() // Left join
                             join chatMatNgoai in context.DSDanhMuc
                                 on pl.ThongTinChungHoGa_ChatMatNgoai equals chatMatNgoai.Id into gj3
                             from chatMatNgoai in gj3.DefaultIfEmpty() // Left join

                             let TenHoGaTheoBanVeNoSuffix = ds.ThongTinChungHoGa_TenHoGaTheoBanVe != null
                                                             ? ds.ThongTinChungHoGa_TenHoGaTheoBanVe.Replace("=G", "")
                                                             : null
                             select new PhanLoaiHoGaModel
                             {
                                Id = pl.Id,
                                 ThongTinChungHoGa_TenHoGaSauPhanLoai =
                                     ds.ThongTinChungHoGa_TenHoGaTheoBanVe != null &&
                                     ds.ThongTinChungHoGa_TenHoGaTheoBanVe.Contains("=G")
                                     ? (
                                         (from subDs in context.DSNuocMua
                                          join subPl in context.PhanLoaiHoGas on subDs.ThongTinChungHoGa_TenHoGaSauPhanLoai equals subPl.Id
                                          where subDs.ThongTinChungHoGa_TenHoGaTheoBanVe == TenHoGaTheoBanVeNoSuffix &&
                                                !subDs.ThongTinChungHoGa_TenHoGaTheoBanVe.Contains("=G")
                                          select subPl.ThongTinChungHoGa_TenHoGaSauPhanLoai)
                                         .FirstOrDefault() + "=G"
                                       )
                                     : pl.ThongTinChungHoGa_TenHoGaSauPhanLoai,
                                 ThongTinChungHoGa_HinhThucHoGa = pl.ThongTinChungHoGa_HinhThucHoGa ?? "",
                                 ThongTinChungHoGa_HinhThucHoGa_Name = hinhThucHoGa.Ten ?? "",
                                 ThongTinChungHoGa_KetCauMuMo = pl.ThongTinChungHoGa_KetCauMuMo ?? "",
                                 ThongTinChungHoGa_KetCauMuMo_Name = ketCauMuMo.Ten ?? "",
                                 ThongTinChungHoGa_KetCauTuong = pl.ThongTinChungHoGa_KetCauTuong ?? "",
                                 ThongTinChungHoGa_KetCauTuong_Name = ketCauTuong.Ten ?? "",
                                 ThongTinChungHoGa_HinhThucMongHoGa = pl.ThongTinChungHoGa_HinhThucMongHoGa ?? "",
                                 ThongTinChungHoGa_HinhThucMongHoGa_Name = hinhThucMongHoGa.Ten ?? "",
                                 ThongTinChungHoGa_KetCauMong = pl.ThongTinChungHoGa_KetCauMong ?? "",
                                 ThongTinChungHoGa_KetCauMong_Name = ketCauMong.Ten ?? "",
                                 ThongTinChungHoGa_ChatMatTrong = pl.ThongTinChungHoGa_ChatMatTrong ?? "",
                                 ThongTinChungHoGa_ChatMatTrong_Name = chatMatTrong.Ten ?? "",
                                 ThongTinChungHoGa_ChatMatNgoai = pl.ThongTinChungHoGa_ChatMatNgoai ?? "",
                                 ThongTinChungHoGa_ChatMatNgoai_Name = chatMatNgoai.Ten ?? "",
                                 PhuBiHoGa_CDai = pl.PhuBiHoGa_CDai ?? 0,
                                 PhuBiHoGa_CRong = pl.PhuBiHoGa_CRong ?? 0,
                                 
                             });
                            if (!string.IsNullOrEmpty(plhgModel.ThongTinChungHoGa_HinhThucHoGa))
                            {
                                query = query.Where(x => x.ThongTinChungHoGa_HinhThucHoGa == plhgModel.ThongTinChungHoGa_HinhThucHoGa);
                            }
                            if (!string.IsNullOrEmpty(plhgModel.ThongTinChungHoGa_KetCauMuMo))
                            {
                                query = query.Where(x => x.ThongTinChungHoGa_KetCauMuMo == plhgModel.ThongTinChungHoGa_KetCauMuMo);
                            }
                            if (!string.IsNullOrEmpty(plhgModel.ThongTinChungHoGa_KetCauTuong))
                            {
                                query = query.Where(x => x.ThongTinChungHoGa_KetCauTuong == plhgModel.ThongTinChungHoGa_KetCauTuong);
                            }
                            if (!string.IsNullOrEmpty(plhgModel.ThongTinChungHoGa_HinhThucMongHoGa))
                            {
                                query = query.Where(x => x.ThongTinChungHoGa_HinhThucMongHoGa == plhgModel.ThongTinChungHoGa_HinhThucMongHoGa);
                            }
                            if (!string.IsNullOrEmpty(plhgModel.ThongTinChungHoGa_KetCauMong))
                            {
                                query = query.Where(x => x.ThongTinChungHoGa_KetCauMong == plhgModel.ThongTinChungHoGa_KetCauMong);
                            }
                var data = await query.Distinct().OrderBy(x=> x.ThongTinChungHoGa_TenHoGaSauPhanLoai)
                      .Where(x => x.Id != null)
                      .ToListAsync();
                return data;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi select insert PhanLoaiHoGaDetails " + ex.Message);
                throw;
            }

            return result;
        }
        public async Task<List<PhanLoaiHoGaModel>> GetBaoCaoKTHHHGa(PhanLoaiHoGaModel Input)
        {
            try
            {
                using var context = _context.CreateDbContext();
                var query = from plhg in context.PhanLoaiHoGaDetails
                            join hinhThucHoGa in context.DSDanhMuc
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
                            orderby plhg.ThongTinChungHoGa_TenHoGaSauPhanLoai
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
                            };

                if (!string.IsNullOrEmpty(Input.ThongTinChungHoGa_HinhThucHoGa))
                {
                    query = query.Where(x => x.ThongTinChungHoGa_HinhThucHoGa == Input.ThongTinChungHoGa_HinhThucHoGa);
                }
                if (!string.IsNullOrEmpty(Input.ThongTinChungHoGa_KetCauMuMo))
                {
                    query = query.Where(x => x.ThongTinChungHoGa_KetCauMuMo == Input.ThongTinChungHoGa_KetCauMuMo);
                }
                if (!string.IsNullOrEmpty(Input.ThongTinChungHoGa_KetCauTuong))
                {
                    query = query.Where(x => x.ThongTinChungHoGa_KetCauTuong == Input.ThongTinChungHoGa_KetCauTuong);
                }
                if (!string.IsNullOrEmpty(Input.ThongTinChungHoGa_HinhThucMongHoGa))
                {
                    query = query.Where(x => x.ThongTinChungHoGa_HinhThucMongHoGa == Input.ThongTinChungHoGa_HinhThucMongHoGa);
                }
                if (!string.IsNullOrEmpty(Input.ThongTinChungHoGa_KetCauMong))
                {
                    query = query.Where(x => x.ThongTinChungHoGa_KetCauMong == Input.ThongTinChungHoGa_KetCauMong);
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
        public async Task<List<PhanLoaiHoGaModel>> GetBaoCaoHGaSDThep(PhanLoaiHoGaModel plhgModel)
        {
            try
            {
                using var context = _context.CreateDbContext();

                var query = (from ds in context.DSNuocMua
                             join pl in context.PhanLoaiHoGas
                                 on ds.ThongTinChungHoGa_TenHoGaSauPhanLoai equals pl.Id into dsJoin
                             from pl in dsJoin.DefaultIfEmpty() // RIGHT JOIN
                             join hinhThucHoGa in context.DSDanhMuc
                                on pl.ThongTinChungHoGa_HinhThucHoGa equals hinhThucHoGa.Id
                             join ketCauMuMo in context.DSDanhMuc
                                 on pl.ThongTinChungHoGa_KetCauMuMo equals ketCauMuMo.Id
                             join ketCauTuong in context.DSDanhMuc
                                 on pl.ThongTinChungHoGa_KetCauTuong equals ketCauTuong.Id
                             join hinhThucMongHoGa in context.DSDanhMuc
                                 on pl.ThongTinChungHoGa_HinhThucMongHoGa equals hinhThucMongHoGa.Id
                             join ketCauMong in context.DSDanhMuc
                                 on pl.ThongTinChungHoGa_KetCauMong equals ketCauMong.Id

                             join chatMatTrong in context.DSDanhMuc
                                 on pl.ThongTinChungHoGa_ChatMatTrong equals chatMatTrong.Id into gj2
                             from chatMatTrong in gj2.DefaultIfEmpty() // Left join
                             join chatMatNgoai in context.DSDanhMuc
                                 on pl.ThongTinChungHoGa_ChatMatNgoai equals chatMatNgoai.Id into gj3
                             from chatMatNgoai in gj3.DefaultIfEmpty() // Left join

                             let TenHoGaTheoBanVeNoSuffix = ds.ThongTinChungHoGa_TenHoGaTheoBanVe != null
                                                             ? ds.ThongTinChungHoGa_TenHoGaTheoBanVe.Replace("=G", "")
                                                             : null
                             select new PhanLoaiHoGaModel
                             {
                                 Id = pl.Id,
                                 ThongTinChungHoGa_TenHoGaSauPhanLoai =
                                     ds.ThongTinChungHoGa_TenHoGaTheoBanVe != null &&
                                     ds.ThongTinChungHoGa_TenHoGaTheoBanVe.Contains("=G")
                                     ? (
                                         (from subDs in context.DSNuocMua
                                          join subPl in context.PhanLoaiHoGas on subDs.ThongTinChungHoGa_TenHoGaSauPhanLoai equals subPl.Id
                                          where subDs.ThongTinChungHoGa_TenHoGaTheoBanVe == TenHoGaTheoBanVeNoSuffix &&
                                                !subDs.ThongTinChungHoGa_TenHoGaTheoBanVe.Contains("=G")
                                          select subPl.ThongTinChungHoGa_TenHoGaSauPhanLoai)
                                         .FirstOrDefault() + "=G"
                                       )
                                     : pl.ThongTinChungHoGa_TenHoGaSauPhanLoai,
                                 ThongTinChungHoGa_HinhThucHoGa = pl.ThongTinChungHoGa_HinhThucHoGa ?? "",
                                 ThongTinChungHoGa_HinhThucHoGa_Name = hinhThucHoGa.Ten ?? "",
                                 ThongTinChungHoGa_KetCauMuMo = pl.ThongTinChungHoGa_KetCauMuMo ?? "",
                                 ThongTinChungHoGa_KetCauMuMo_Name = ketCauMuMo.Ten ?? "",
                                 ThongTinChungHoGa_KetCauTuong = pl.ThongTinChungHoGa_KetCauTuong ?? "",
                                 ThongTinChungHoGa_KetCauTuong_Name = ketCauTuong.Ten ?? "",
                                 ThongTinChungHoGa_HinhThucMongHoGa = pl.ThongTinChungHoGa_HinhThucMongHoGa ?? "",
                                 ThongTinChungHoGa_HinhThucMongHoGa_Name = hinhThucMongHoGa.Ten ?? "",
                                 ThongTinChungHoGa_KetCauMong = pl.ThongTinChungHoGa_KetCauMong ?? "",
                                 ThongTinChungHoGa_KetCauMong_Name = ketCauMong.Ten ?? "",
                             });


                if (!string.IsNullOrEmpty(plhgModel.ThongTinChungHoGa_KetCauMuMo))
                {
                    query = query.Where(x => x.ThongTinChungHoGa_KetCauMuMo == plhgModel.ThongTinChungHoGa_KetCauMuMo);
                }
                if (!string.IsNullOrEmpty(plhgModel.ThongTinChungHoGa_KetCauTuong))
                {
                    query = query.Where(x => x.ThongTinChungHoGa_KetCauTuong == plhgModel.ThongTinChungHoGa_KetCauTuong);
                }
                if (!string.IsNullOrEmpty(plhgModel.ThongTinChungHoGa_KetCauMong))
                {
                    query = query.Where(x => x.ThongTinChungHoGa_KetCauMong == plhgModel.ThongTinChungHoGa_KetCauMong);
                }

                var data = await query.Distinct().OrderBy(x => x.ThongTinChungHoGa_TenHoGaSauPhanLoai)
                      .Where(x => x.Id != null)
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
