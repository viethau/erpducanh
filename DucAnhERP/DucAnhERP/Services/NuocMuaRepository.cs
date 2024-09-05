
using DucAnhERP.Data;
using DucAnhERP.Models;
using DucAnhERP.Repository;
using DucAnhERP.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace DucAnhERP.Services
{
    public class NuocMuaRepository : INuocMuaRepository
    {
        private readonly IDbContextFactory<ApplicationDbContext> _context;

        public NuocMuaRepository(IDbContextFactory<ApplicationDbContext> context)
        {
            _context = context;
        }

        public async Task<List<MNuocMua>> GetAll()
        {
            try
            {
                using var context = _context.CreateDbContext();
                var entity = await context.DSNuocMua.ToListAsync();
                return entity;
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.Error.WriteLine($"An error occurred: {ex.Message}");
                throw; // Optionally rethrow the exception
            }
        }

        public async Task<List<NuocMuaModel>> GetData()
        {

            using var context = _context.CreateDbContext();
            var query = from MNuocMua in context.DSNuocMua
                        .OrderBy(m => m.CreateAt)
                        select new NuocMuaModel
                        {
                            Id = MNuocMua.Id ,
                            ThongTinLyTrinh_TuyenDuong = MNuocMua.ThongTinLyTrinh_TuyenDuong ?? "",
                            ThongTinLyTrinh_LyTrinhTaiTimHoGa = MNuocMua.ThongTinLyTrinh_LyTrinhTaiTimHoGa ?? "",
                            ThongTinChungHoGa_TenHoGaSauPhanLoai = MNuocMua.ThongTinChungHoGa_TenHoGaSauPhanLoai ?? "",
                            ThongTinChungHoGa_TenHoGaTheoBanVe = MNuocMua.ThongTinChungHoGa_TenHoGaTheoBanVe ?? "",
                            ThongTinChungHoGa_HinhThucHoGa = MNuocMua.ThongTinChungHoGa_HinhThucHoGa ?? "",
                            ThongTinChungHoGa_KetCauMuMo = MNuocMua.ThongTinChungHoGa_KetCauMuMo ?? "",
                            ThongTinChungHoGa_KetCauTuong = MNuocMua.ThongTinChungHoGa_KetCauTuong ?? "",
                            ThongTinChungHoGa_HinhThucMongHoGa = MNuocMua.ThongTinChungHoGa_HinhThucMongHoGa ?? "",
                            ThongTinChungHoGa_KetCauMong = MNuocMua.ThongTinChungHoGa_KetCauMong ?? "",
                            ThongTinChungHoGa_ChatMatTrong = MNuocMua.ThongTinChungHoGa_ChatMatTrong ?? "",
                            ThongTinChungHoGa_ChatMatNgoai = MNuocMua.ThongTinChungHoGa_ChatMatNgoai ?? "",
                            PhuBiHoGa_CDai = MNuocMua.PhuBiHoGa_CDai ?? 0,
                            PhuBiHoGa_CRong = MNuocMua.PhuBiHoGa_CRong ?? 0,
                            BeTongLotMong_D = MNuocMua.BeTongLotMong_D ?? 0,
                            BeTongLotMong_R = MNuocMua.BeTongLotMong_R ?? 0,
                            BeTongLotMong_C = MNuocMua.BeTongLotMong_C ?? 0,
                            BeTongMongHoGa_D = MNuocMua.BeTongMongHoGa_D ?? 0,
                            BeTongMongHoGa_R = MNuocMua.BeTongMongHoGa_R ?? 0,
                            BeTongMongHoGa_C = MNuocMua.BeTongMongHoGa_C ?? 0,
                            DeHoGa_D = MNuocMua.DeHoGa_D ?? 0,
                            DeHoGa_R = MNuocMua.DeHoGa_R ?? 0,
                            DeHoGa_C = MNuocMua.DeHoGa_C ?? 0,
                            TuongHoGa_D = MNuocMua.TuongHoGa_D ?? 0,
                            TuongHoGa_R = MNuocMua.TuongHoGa_R ?? 0,
                            TuongHoGa_C = MNuocMua.TuongHoGa_C ?? 0,
                            TuongHoGa_CdTuong = MNuocMua.TuongHoGa_CdTuong ?? 0,
                            DamGiuaHoGa_D = MNuocMua.DamGiuaHoGa_D ?? 0,
                            DamGiuaHoGa_R = MNuocMua.DamGiuaHoGa_R ?? 0,
                            DamGiuaHoGa_C = MNuocMua.DamGiuaHoGa_C ?? 0,
                            DamGiuaHoGa_CdDam = MNuocMua.DamGiuaHoGa_CdDam ?? 0,
                            DamGiuaHoGa_CCaoDamGiuaTuongSoVoiDayHoGa = MNuocMua.DamGiuaHoGa_CCaoDamGiuaTuongSoVoiDayHoGa ?? 0,
                            ChatMatTrong_D = MNuocMua.ChatMatTrong_D ?? 0,
                            ChatMatTrong_R = MNuocMua.ChatMatTrong_R ?? 0,
                            ChatMatTrong_C = MNuocMua.ChatMatTrong_C ?? 0,
                            ChatMatNgoaiCanh_D = MNuocMua.ChatMatNgoaiCanh_D ?? 0,
                            ChatMatNgoaiCanh_R = MNuocMua.ChatMatNgoaiCanh_R ?? 0,
                            ChatMatNgoaiCanh_C = MNuocMua.ChatMatNgoaiCanh_C ?? 0,
                            MuMoThotDuoi_D = MNuocMua.MuMoThotDuoi_D ?? 0,
                            MuMoThotDuoi_R = MNuocMua.MuMoThotDuoi_R ?? 0,
                            MuMoThotDuoi_C = MNuocMua.MuMoThotDuoi_C ?? 0,
                            MuMoThotDuoi_CdTuong = MNuocMua.MuMoThotDuoi_CdTuong ?? 0,
                            MuMoThotTren_D = MNuocMua.MuMoThotTren_D ?? 0,
                            MuMoThotTren_R = MNuocMua.MuMoThotTren_R ?? 0,
                            MuMoThotTren_C = MNuocMua.MuMoThotTren_C ?? 0,
                            MuMoThotTren_CdTuong = MNuocMua.MuMoThotTren_CdTuong ?? 0,
                            HinhThucDauNoi1_Loai = MNuocMua.HinhThucDauNoi1_Loai ?? 0,
                            HinhThucDauNoi1_CanhDai = MNuocMua.HinhThucDauNoi1_CanhDai ?? 0,
                            HinhThucDauNoi1_CanhRong = MNuocMua.HinhThucDauNoi1_CanhRong ?? 0,
                            HinhThucDauNoi1_CanhCheo = MNuocMua.HinhThucDauNoi1_CanhCheo ?? 0,
                            HinhThucDauNoi2_Loai = MNuocMua.HinhThucDauNoi2_Loai ?? 0,
                            HinhThucDauNoi2_CanhDai = MNuocMua.HinhThucDauNoi2_CanhDai ?? 0,
                            HinhThucDauNoi2_CanhRong = MNuocMua.HinhThucDauNoi2_CanhRong ?? 0,
                            HinhThucDauNoi2_CanhCheo = MNuocMua.HinhThucDauNoi2_CanhCheo ?? 0,
                            HinhThucDauNoi3_Loai = MNuocMua.HinhThucDauNoi3_Loai ?? 0,
                            HinhThucDauNoi3_CanhDai = MNuocMua.HinhThucDauNoi3_CanhDai ?? 0,
                            HinhThucDauNoi3_CanhRong = MNuocMua.HinhThucDauNoi3_CanhRong ?? 0,
                            HinhThucDauNoi3_CanhCheo = MNuocMua.HinhThucDauNoi3_CanhCheo ?? 0,
                            HinhThucDauNoi4_Loai = MNuocMua.HinhThucDauNoi4_Loai ?? 0,
                            HinhThucDauNoi4_CanhDai = MNuocMua.HinhThucDauNoi4_CanhDai ?? 0,
                            HinhThucDauNoi4_CanhRong = MNuocMua.HinhThucDauNoi4_CanhRong ?? 0,
                            HinhThucDauNoi4_CanhCheo = MNuocMua.HinhThucDauNoi4_CanhCheo ?? 0,
                            HinhThucDauNoi5_Loai = MNuocMua.HinhThucDauNoi5_Loai ?? 0,
                            HinhThucDauNoi5_CanhDai = MNuocMua.HinhThucDauNoi5_CanhDai ?? 0,
                            HinhThucDauNoi5_CanhRong = MNuocMua.HinhThucDauNoi5_CanhRong ?? 0,
                            HinhThucDauNoi5_CanhCheo = MNuocMua.HinhThucDauNoi5_CanhCheo ?? 0,
                            HinhThucDauNoi6_Loai = MNuocMua.HinhThucDauNoi6_Loai ?? 0,
                            HinhThucDauNoi6_CanhDai = MNuocMua.HinhThucDauNoi6_CanhDai ?? 0,
                            HinhThucDauNoi6_CanhRong = MNuocMua.HinhThucDauNoi6_CanhRong ?? 0,
                            HinhThucDauNoi6_CanhCheo = MNuocMua.HinhThucDauNoi6_CanhCheo ?? 0,
                            HinhThucDauNoi7_Loai = MNuocMua.HinhThucDauNoi7_Loai ?? 0,
                            HinhThucDauNoi7_CanhDai = MNuocMua.HinhThucDauNoi7_CanhDai ?? 0,
                            HinhThucDauNoi7_CanhRong = MNuocMua.HinhThucDauNoi7_CanhRong ?? 0,
                            HinhThucDauNoi7_CanhCheo = MNuocMua.HinhThucDauNoi7_CanhCheo ?? 0,
                            HinhThucDauNoi8_Loai = MNuocMua.HinhThucDauNoi8_Loai ?? 0,
                            HinhThucDauNoi8_CanhDai = MNuocMua.HinhThucDauNoi8_CanhDai ?? 0,
                            HinhThucDauNoi8_CanhRong = MNuocMua.HinhThucDauNoi8_CanhRong ?? 0,
                            HinhThucDauNoi8_CanhCheo = MNuocMua.HinhThucDauNoi8_CanhCheo ?? 0,
                            ThongTinTamDanHoGa2_PhanLoaiDayHoGa = MNuocMua.ThongTinTamDanHoGa2_PhanLoaiDayHoGa ?? "",
                            ThongTinTamDanHoGa2_HinhThucDayHoGa = MNuocMua.ThongTinTamDanHoGa2_HinhThucDayHoGa ?? "",
                            ThongTinTamDanHoGa2_DuongKinh = MNuocMua.ThongTinTamDanHoGa2_DuongKinh ?? 0,
                            ThongTinTamDanHoGa2_ChieuDay = MNuocMua.ThongTinTamDanHoGa2_ChieuDay ?? 0,
                            ThongTinTamDanHoGa2_D = MNuocMua.ThongTinTamDanHoGa2_D ?? 0,
                            ThongTinTamDanHoGa2_R = MNuocMua.ThongTinTamDanHoGa2_R ?? 0,
                            ThongTinTamDanHoGa2_C = MNuocMua.ThongTinTamDanHoGa2_C ?? 0,
                            ThongTinTamDanHoGa2_SoLuongNapDay = MNuocMua.ThongTinTamDanHoGa2_SoLuongNapDay ?? 0,
                            ThongTinVatLieuDaoHoGa_LoaiVatLieuDao = MNuocMua.ThongTinVatLieuDaoHoGa_LoaiVatLieuDao ?? "",
                            ThongTinVatLieuDaoHoGa_ChieuCaoDaoDa = MNuocMua.ThongTinVatLieuDaoHoGa_ChieuCaoDaoDa ?? 0,
                            ThongTinVatLieuDaoHoGa_ChieuCaoDaoDat = MNuocMua.ThongTinVatLieuDaoHoGa_ChieuCaoDaoDat ?? 0,
                            ThongTinVatLieuDaoHoGa_TongChieuCaoDao = MNuocMua.ThongTinVatLieuDaoHoGa_TongChieuCaoDao ?? 0,
                            ThongTinCaoDoHoGa_CaoDoTuNhien = MNuocMua.ThongTinCaoDoHoGa_CaoDoTuNhien ?? 0,
                            ThongTinCaoDoHoGa_CdDinhViaHeHoanThien = MNuocMua.ThongTinCaoDoHoGa_CdDinhViaHeHoanThien ?? 0,
                            ThongTinCaoDoHoGa_CaoDoDinhK98 = MNuocMua.ThongTinCaoDoHoGa_CaoDoDinhK98 ?? 0,
                            ThongTinCaoDoHoGa_CaoDoHienTrangTruocKhiDao = MNuocMua.ThongTinCaoDoHoGa_CaoDoHienTrangTruocKhiDao ?? 0,
                            ThongTinCaoDoHoGa_DayDao = MNuocMua.ThongTinCaoDoHoGa_DayDao ?? 0,
                            ThongTinCaoDoHoGa_CSauDao = MNuocMua.ThongTinCaoDoHoGa_CSauDao ?? 0,
                            ThongTinCaoDoHoGa_DinhLotMong = MNuocMua.ThongTinCaoDoHoGa_DinhLotMong ?? 0,
                            ThongTinCaoDoHoGa_CdDinhMong = MNuocMua.ThongTinCaoDoHoGa_CdDinhMong ?? 0,
                            ThongTinCaoDoHoGa_CdDayHoGa = MNuocMua.ThongTinCaoDoHoGa_CdDayHoGa ?? 0,
                            ThongTinCaoDoHoGa_CCaoTuong = MNuocMua.ThongTinCaoDoHoGa_CCaoTuong ?? 0,
                            ThongTinCaoDoHoGa_DinhTuongDuoiDamGiuaTuong = MNuocMua.ThongTinCaoDoHoGa_DinhTuongDuoiDamGiuaTuong ?? 0,
                            ThongTinCaoDoHoGa_DinhDamGiuaTuong = MNuocMua.ThongTinCaoDoHoGa_DinhDamGiuaTuong ?? 0,
                            ThongTinCaoDoHoGa_DinhTuong = MNuocMua.ThongTinCaoDoHoGa_DinhTuong ?? 0,
                            ThongTinCaoDoHoGa_DinhMuMoThotDuoi = MNuocMua.ThongTinCaoDoHoGa_DinhMuMoThotDuoi ?? 0,
                            ThongTinCaoDoHoGa_CdDinhHoGa = MNuocMua.ThongTinCaoDoHoGa_CdDinhHoGa ?? 0,
                            ThongTinCaoDoHoGa_TongChieuCaoHoGa = MNuocMua.ThongTinCaoDoHoGa_TongChieuCaoHoGa ?? 0,
                            ThongTinCaoDoHoGa_ChenhCaoDinhHoGaVaHienTrangDao = MNuocMua.ThongTinCaoDoHoGa_ChenhCaoDinhHoGaVaHienTrangDao ?? 0,
                            ThongTinCaoDoHoGa_TongChieuCaoChiemChoDapTra = MNuocMua.ThongTinCaoDoHoGa_TongChieuCaoChiemChoDapTra ?? 0,
                            TTCCCCDTHT_ChieuCaoLotDat = MNuocMua.TTCCCCDTHT_ChieuCaoLotDat ?? 0,
                            TTCCCCDTHT_ChieuCaoMongDat = MNuocMua.TTCCCCDTHT_ChieuCaoMongDat ?? 0,
                            TTCCCCDTHT_ChieuCaoTuongDat = MNuocMua.TTCCCCDTHT_ChieuCaoTuongDat ?? 0,
                            TTCCCCDTHT_ChieuCaoLotDa = MNuocMua.TTCCCCDTHT_ChieuCaoLotDa ?? 0,
                            TTCCCCDTHT_ChieuCaoMongDa = MNuocMua.TTCCCCDTHT_ChieuCaoMongDa ?? 0,
                            TTCCCCDTHT_ChieuCaoTuongDa = MNuocMua.TTCCCCDTHT_ChieuCaoTuongDa ?? 0,
                            TTCCCCDTHT_TongCieuCaoDat = MNuocMua.TTCCCCDTHT_TongCieuCaoDat ?? 0,
                            TTCCCCDTHT_TongChieuCaoDa = MNuocMua.TTCCCCDTHT_TongChieuCaoDa ?? 0,
                            TTCCCCDTHT_ChenhDatSoVoiTK = MNuocMua.TTCCCCDTHT_ChenhDatSoVoiTK ?? 0,
                            TTCCCCDTHT_ChenhDaSoVoiTK = MNuocMua.TTCCCCDTHT_ChenhDaSoVoiTK ?? 0,
                            ThongTinMaiDao_ChieuRongDayDaoNho = MNuocMua.ThongTinMaiDao_ChieuRongDayDaoNho ?? 0,
                            ThongTinMaiDao_TyLeMoMai = MNuocMua.ThongTinMaiDao_TyLeMoMai ?? 0,
                            ThongTinMaiDao_SoCanhMaiTrai = MNuocMua.ThongTinMaiDao_SoCanhMaiTrai ?? 0,
                            ThongTinMaiDao_SoCanhMaiPhai = MNuocMua.ThongTinMaiDao_SoCanhMaiPhai ?? 0,
                            TTKLD_CRongDaoDayLonDat = MNuocMua.TTKLD_CRongDaoDayLonDat ?? 0,
                            TTKLD_CRongDaoDayLonDa = MNuocMua.TTKLD_CRongDaoDayLonDa ?? 0,
                            TTKLD_DienTichDaoDat = MNuocMua.TTKLD_DienTichDaoDat ?? 0,
                            TTKLD_DienTichDaoDa = MNuocMua.TTKLD_DienTichDaoDa ?? 0,
                            TTKLD_TongDtDao = MNuocMua.TTKLD_TongDtDao ?? 0,
                            TTKLD_KlDaoDat = MNuocMua.TTKLD_KlDaoDat ?? 0,
                            TTKLD_KlDaoDa = MNuocMua.TTKLD_KlDaoDa ?? 0,
                            TTKLD_TongKlDao = MNuocMua.TTKLD_TongKlDao ?? 0,
                            TTKLD_KlChiemChoDat = MNuocMua.TTKLD_KlChiemChoDat ?? 0,
                            TTKLD_KlChiemChoDa = MNuocMua.TTKLD_KlChiemChoDa ?? 0,
                            TTKLD_TongChiemCho = MNuocMua.TTKLD_TongChiemCho ?? 0,
                            TTKLD_KlDapTraDat = MNuocMua.TTKLD_KlDapTraDat ?? 0,
                            TTKLD_KlDapTraDa = MNuocMua.TTKLD_KlDapTraDa ?? 0,
                            TTKLD_TongDapTra = MNuocMua.TTKLD_TongDapTra ?? 0,
                            TTKLD_KlThuaDat = MNuocMua.TTKLD_KlThuaDat ?? 0,
                            TTKLD_KlThuaDa = MNuocMua.TTKLD_KlThuaDa ?? 0,
                            TTKLD_TongThua = MNuocMua.TTKLD_TongThua ?? 0,
                            ThongTinLyTrinhTruyenDan_TuLyTrinh = MNuocMua.ThongTinLyTrinhTruyenDan_TuLyTrinh ?? 0,
                            ThongTinLyTrinhTruyenDan_DenLyTrinh = MNuocMua.ThongTinLyTrinhTruyenDan_DenLyTrinh ?? 0,
                            ThongTinLyTrinhTruyenDan_TuHoGa = MNuocMua.ThongTinLyTrinhTruyenDan_TuHoGa ?? "",
                            ThongTinLyTrinhTruyenDan_DenHoGa = MNuocMua.ThongTinLyTrinhTruyenDan_DenHoGa ?? "",
                            ThongTinDuongTruyenDan_HinhThucTruyenDan = MNuocMua.ThongTinDuongTruyenDan_HinhThucTruyenDan ?? "",
                            ThongTinDuongTruyenDan_LoaiTruyenDan = MNuocMua.ThongTinDuongTruyenDan_LoaiTruyenDan ?? "",
                            ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai = MNuocMua.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai ?? "",
                            TTCDSLCauKienDuongTruyenDan_TongChieuDai = MNuocMua.TTCDSLCauKienDuongTruyenDan_TongChieuDai ?? 0,
                            TTCDSLCauKienDuongTruyenDan_ChieuDai01CauKien = MNuocMua.TTCDSLCauKienDuongTruyenDan_ChieuDai01CauKien ?? 0,
                            TTCDSLCauKienDuongTruyenDan_SlCauKienTinhKl = MNuocMua.TTCDSLCauKienDuongTruyenDan_SlCauKienTinhKl ?? 0,
                            ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop = MNuocMua.ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop ?? "",
                            ThongTinMongDuongTruyenDan_LoaiMong = MNuocMua.ThongTinMongDuongTruyenDan_LoaiMong ?? "",
                            ThongTinMongDuongTruyenDan_HinhThucMong = MNuocMua.ThongTinMongDuongTruyenDan_HinhThucMong ?? "",
                            ThongTinDeCong_TenLoaiDeCong = MNuocMua.ThongTinDeCong_TenLoaiDeCong ?? "",
                            ThongTinDeCong_CauTaoDeCong = MNuocMua.ThongTinDeCong_CauTaoDeCong ?? "",
                            ThongTinDeCong_D = MNuocMua.ThongTinDeCong_D ?? 0,
                            ThongTinDeCong_R = MNuocMua.ThongTinDeCong_R ?? 0,
                            ThongTinDeCong_C = MNuocMua.ThongTinDeCong_C ?? 0,
                            ThongTinDeCong_SlDeCong01CauKienTruyenDan = MNuocMua.ThongTinDeCong_SlDeCong01CauKienTruyenDan ?? 0,
                            ThongTinDeCong_Kl01DeCong = MNuocMua.ThongTinDeCong_Kl01DeCong ?? 0,
                            ThongTinDeCong_TongSoLuongDC = MNuocMua.ThongTinDeCong_TongSoLuongDC ?? 0,
                            ThongTinDeCong_TongKLDeCong = MNuocMua.ThongTinDeCong_TongKLDeCong ?? 0,
                            ThongTinCauTaoCongTron_CDayPhuBi = MNuocMua.ThongTinCauTaoCongTron_CDayPhuBi ?? 0,
                            ThongTinCauTaoCongTron_SoCanh = MNuocMua.ThongTinCauTaoCongTron_SoCanh ?? 0,
                            ThongTinCauTaoCongTron_LongSuDung = MNuocMua.ThongTinCauTaoCongTron_LongSuDung ?? 0,
                            ThongTinCauTaoCongTron_CCaoCauKien = MNuocMua.ThongTinCauTaoCongTron_CCaoCauKien ?? 0,
                            ThongTinCauTaoCongTron_CCaoLotMong = MNuocMua.ThongTinCauTaoCongTron_CCaoLotMong ?? 0,
                            ThongTinCauTaoCongTron_CRongLotMong = MNuocMua.ThongTinCauTaoCongTron_CRongLotMong ?? 0,
                            ThongTinCauTaoCongTron_CCaoMong = MNuocMua.ThongTinCauTaoCongTron_CCaoMong ?? 0,
                            ThongTinCauTaoCongTron_CRongMong = MNuocMua.ThongTinCauTaoCongTron_CRongMong ?? 0,
                            ThongTinCauTaoCongTron_CCaoDe = MNuocMua.ThongTinCauTaoCongTron_CCaoDe ?? 0,
                            ThongTinCauTaoCongTron_TongCCaoCong = MNuocMua.ThongTinCauTaoCongTron_TongCCaoCong ?? 0,
                            TTTKLCKCTCH_CDMoiNoiCKien = MNuocMua.TTTKLCKCTCH_CDMoiNoiCKien ?? 0,
                            TTTKLCKCTCH_SLCKDungDeTinhCD = MNuocMua.TTTKLCKCTCH_SLCKDungDeTinhCD ?? 0,
                            TTTKLCKCTCH_SLCKNguyen = MNuocMua.TTTKLCKCTCH_SLCKNguyen ?? 0,
                            TTTKLCKCTCH_CDCanLapDat = MNuocMua.TTTKLCKCTCH_CDCanLapDat ?? 0,
                            TTTKLCKCTCH_TongCD = MNuocMua.TTTKLCKCTCH_TongCD ?? 0,
                            TTTKLCKCTCH_CDThucTeThuaThieu = MNuocMua.TTTKLCKCTCH_CDThucTeThuaThieu ?? "",
                            TTTKLCKCTCH_XDOngCongCanThem = MNuocMua.TTTKLCKCTCH_XDOngCongCanThem ?? "",
                            TTTKLCKCTCH_CDThuaThieuSauTinhKL = MNuocMua.TTTKLCKCTCH_CDThuaThieuSauTinhKL ?? "",
                            TTKTHHCongHopRanh_CauTaoTuong = MNuocMua.TTKTHHCongHopRanh_CauTaoTuong ?? "",
                            TTKTHHCongHopRanh_CauTaoMuMo = MNuocMua.TTKTHHCongHopRanh_CauTaoMuMo ?? "",
                            TTKTHHCongHopRanh_ChatMatTrong = MNuocMua.TTKTHHCongHopRanh_ChatMatTrong ?? "",
                            TTKTHHCongHopRanh_ChatMatNgoai = MNuocMua.TTKTHHCongHopRanh_ChatMatNgoai ?? "",
                            TTKTHHCongHopRanh_CCaoLotMong = MNuocMua.TTKTHHCongHopRanh_CCaoLotMong ?? 0,
                            TTKTHHCongHopRanh_CRongLotMong = MNuocMua.TTKTHHCongHopRanh_CRongLotMong ?? 0,
                            TTKTHHCongHopRanh_CCaoMong = MNuocMua.TTKTHHCongHopRanh_CCaoMong ?? 0,
                            TTKTHHCongHopRanh_CRongMong = MNuocMua.TTKTHHCongHopRanh_CRongMong ?? 0,
                            TTKTHHCongHopRanh_CCaoDe = MNuocMua.TTKTHHCongHopRanh_CCaoDe ?? 0,
                            TTKTHHCongHopRanh_CRongDe = MNuocMua.TTKTHHCongHopRanh_CRongDe ?? 0,
                            TTKTHHCongHopRanh_CDayTuong01Ben = MNuocMua.TTKTHHCongHopRanh_CDayTuong01Ben ?? 0,
                            TTKTHHCongHopRanh_SoLuongTuong = MNuocMua.TTKTHHCongHopRanh_SoLuongTuong ?? 0,
                            TTKTHHCongHopRanh_CRongLongSuDung = MNuocMua.TTKTHHCongHopRanh_CRongLongSuDung ?? 0,
                            TTKTHHCongHopRanh_CCaoTuongCongHop = MNuocMua.TTKTHHCongHopRanh_CCaoTuongCongHop ?? 0,
                            TTKTHHCongHopRanh_CCaoTuongRanh = MNuocMua.TTKTHHCongHopRanh_CCaoTuongRanh ?? 0,
                            TTKTHHCongHopRanh_CCaoTuongGop = MNuocMua.TTKTHHCongHopRanh_CCaoTuongGop ?? 0,
                            TTKTHHCongHopRanh_CCaoMuMoThotDuoi = MNuocMua.TTKTHHCongHopRanh_CCaoMuMoThotDuoi ?? 0,
                            TTKTHHCongHopRanh_CRongMuMoDuoi = MNuocMua.TTKTHHCongHopRanh_CRongMuMoDuoi ?? 0,
                            TTKTHHCongHopRanh_CCaoMuMoThotTren = MNuocMua.TTKTHHCongHopRanh_CCaoMuMoThotTren ?? 0,
                            TTKTHHCongHopRanh_CRongMuMoTren = MNuocMua.TTKTHHCongHopRanh_CRongMuMoTren ?? 0,
                            TTKTHHCongHopRanh_LoaiThanhChong = MNuocMua.TTKTHHCongHopRanh_LoaiThanhChong ?? "",
                            TTKTHHCongHopRanh_CauTaoThanhChong = MNuocMua.TTKTHHCongHopRanh_CauTaoThanhChong ?? "",
                            TTKTHHCongHopRanh_CCaoThanhChong = MNuocMua.TTKTHHCongHopRanh_CCaoThanhChong ?? 0,
                            TTKTHHCongHopRanh_CRongThanhChong = MNuocMua.TTKTHHCongHopRanh_CRongThanhChong ?? 0,
                            TTKTHHCongHopRanh_CDai = MNuocMua.TTKTHHCongHopRanh_CDai ?? 0,
                            TTKTHHCongHopRanh_SoLuongThanhChong = MNuocMua.TTKTHHCongHopRanh_SoLuongThanhChong ?? 0,
                            TTKTHHCongHopRanh_CCaoChatMatTrong = MNuocMua.TTKTHHCongHopRanh_CCaoChatMatTrong ?? 0,
                            TTKTHHCongHopRanh_CCaoChatmatNgoai = MNuocMua.TTKTHHCongHopRanh_CCaoChatmatNgoai ?? 0,
                            TTKTHHCongHopRanh_TongChieuCao = MNuocMua.TTKTHHCongHopRanh_TongChieuCao ?? 0,
                            TTTDCongHoRanh_TenLoaiTamDanTieuChuan = MNuocMua.TTTDCongHoRanh_TenLoaiTamDanTieuChuan ?? "",
                            TTTDCongHoRanh_CauTaoTamDanTruyenDanTamDanTieuChuan = MNuocMua.TTTDCongHoRanh_CauTaoTamDanTruyenDanTamDanTieuChuan ?? "",
                            TTTDCongHoRanh_SoLuong = MNuocMua.TTTDCongHoRanh_SoLuong ?? 0,
                            TTTDCongHoRanh_CDai = MNuocMua.TTTDCongHoRanh_CDai ?? 0,
                            TTTDCongHoRanh_CRong = MNuocMua.TTTDCongHoRanh_CRong ?? 0,
                            TTTDCongHoRanh_CCao = MNuocMua.TTTDCongHoRanh_CCao ?? 0,
                            TTTDCongHoRanh_TenLoaiTamDanLoai02 = MNuocMua.TTTDCongHoRanh_TenLoaiTamDanLoai02 ?? "",
                            TTTDCongHoRanh_CauTaoTamDanTruyenDan = MNuocMua.TTTDCongHoRanh_CauTaoTamDanTruyenDan ?? "",
                            TTTDCongHoRanh_SoLuong1 = MNuocMua.TTTDCongHoRanh_SoLuong1 ?? 0,
                            TTTDCongHoRanh_CDai1 = MNuocMua.TTTDCongHoRanh_CDai1 ?? 0,
                            TTTDCongHoRanh_CRong1 = MNuocMua.TTTDCongHoRanh_CRong1 ?? 0,
                            TTTDCongHoRanh_CCao1 = MNuocMua.TTTDCongHoRanh_CCao1 ?? 0,
                            TTTDCongHoRanh_ChieuDaiMoiNoi = MNuocMua.TTTDCongHoRanh_ChieuDaiMoiNoi ?? 0,
                            TTTDCongHoRanh_SoLuongTDanDungDeTinhChieuDaiBoSung = MNuocMua.TTTDCongHoRanh_SoLuongTDanDungDeTinhChieuDaiBoSung ?? 0,
                            TTTDCongHoRanh_SLCauKienNguyen = MNuocMua.TTTDCongHoRanh_SLCauKienNguyen ?? 0,
                            TTTDCongHoRanh_ChieuDaiTheoSoCKNguyen = MNuocMua.TTTDCongHoRanh_ChieuDaiTheoSoCKNguyen ?? 0,
                            TTTDCongHoRanh_TongChieuDaiTheoCKNguyen = MNuocMua.TTTDCongHoRanh_TongChieuDaiTheoCKNguyen ?? 0,
                            TTTDCongHoRanh_ChieuDaiThucTe = MNuocMua.TTTDCongHoRanh_ChieuDaiThucTe ?? 0,
                            TTTDCongHoRanh_XacDinhOngCongCanThem = MNuocMua.TTTDCongHoRanh_XacDinhOngCongCanThem ?? 0,
                            ThongTinKichThuocHinhHocOngNhua_CDayPhuBi = MNuocMua.ThongTinKichThuocHinhHocOngNhua_CDayPhuBi ?? 0,
                            ThongTinKichThuocHinhHocOngNhua_SoCanh = MNuocMua.ThongTinKichThuocHinhHocOngNhua_SoCanh ?? 0,
                            ThongTinKichThuocHinhHocOngNhua_LongSuDung = MNuocMua.ThongTinKichThuocHinhHocOngNhua_LongSuDung ?? 0,
                            ThongTinKichThuocHinhHocOngNhua_TongCCaoOng = MNuocMua.ThongTinKichThuocHinhHocOngNhua_TongCCaoOng ?? 0,
                            ThongTinKichThuocHinhHocOngNhua_CCaoDemCat = MNuocMua.ThongTinKichThuocHinhHocOngNhua_CCaoDemCat ?? 0,
                            ThongTinKichThuocHinhHocOngNhua_CCaoDapCat = MNuocMua.ThongTinKichThuocHinhHocOngNhua_CCaoDapCat ?? 0,
                            CDThuongLuu_HienTrangTruocKhiDaoThuongLuu = MNuocMua.CDThuongLuu_HienTrangTruocKhiDaoThuongLuu ?? 0,
                            CDThuongLuu_DayDaoGop = MNuocMua.CDThuongLuu_DayDaoGop ?? 0,
                            CDThuongLuu_ChieuSauDao = MNuocMua.CDThuongLuu_ChieuSauDao ?? 0,
                            CDThuongLuu_DayDaoCongTron = MNuocMua.CDThuongLuu_DayDaoCongTron ?? 0,
                            CDThuongLuu_DayDaoCongHop = MNuocMua.CDThuongLuu_DayDaoCongHop ?? 0,
                            CDThuongLuu_DayDaoRanh = MNuocMua.CDThuongLuu_DayDaoRanh ?? 0,
                            CDThuongLuu_DayDaoOngNhua = MNuocMua.CDThuongLuu_DayDaoOngNhua ?? 0,
                            CDThuongLuu_DinhLotGop = MNuocMua.CDThuongLuu_DinhLotGop ?? 0,
                            CDThuongLuu_DinhLotOngNhua = MNuocMua.CDThuongLuu_DinhLotOngNhua ?? 0,
                            CDThuongLuu_DinhLotCongTron = MNuocMua.CDThuongLuu_DinhLotCongTron ?? 0,
                            CDThuongLuu_DinhLotCongHop = MNuocMua.CDThuongLuu_DinhLotCongHop ?? 0,
                            CDThuongLuu_DinhLotRanh = MNuocMua.CDThuongLuu_DinhLotRanh ?? 0,
                            CDThuongLuu_DinhMongGop = MNuocMua.CDThuongLuu_DinhMongGop ?? 0,
                            CDThuongLuu_DinhMongCongTron = MNuocMua.CDThuongLuu_DinhMongCongTron ?? 0,
                            CDThuongLuu_DinhMongCongHop = MNuocMua.CDThuongLuu_DinhMongCongHop ?? 0,
                            CDThuongLuu_DinhMongRanh = MNuocMua.CDThuongLuu_DinhMongRanh ?? 0,
                            CDThuongLuu_DinhDeCong = MNuocMua.CDThuongLuu_DinhDeCong ?? 0,
                            CDThuongLuu_DayDongChay = MNuocMua.CDThuongLuu_DayDongChay ?? 0,
                            CDThuongLuu_CCaoTuongCongRanh = MNuocMua.CDThuongLuu_CCaoTuongCongRanh ?? 0,
                            CDThuongLuu_DinhTuongCHopRanh = MNuocMua.CDThuongLuu_DinhTuongCHopRanh ?? 0,
                            CDThuongLuu_DinhMuMoThotDuoiCongHopRanh = MNuocMua.CDThuongLuu_DinhMuMoThotDuoiCongHopRanh ?? 0,
                            CDThuongLuu_DinhGop = MNuocMua.CDThuongLuu_DinhGop ?? 0,
                            CDThuongLuu_DinhTrongLongSuDung = MNuocMua.CDThuongLuu_DinhTrongLongSuDung ?? 0,
                            CDThuongLuu_DinhCongTron = MNuocMua.CDThuongLuu_DinhCongTron ?? 0,
                            CDThuongLuu_DinhCongHop = MNuocMua.CDThuongLuu_DinhCongHop ?? 0,
                            CDThuongLuu_DinhRanh = MNuocMua.CDThuongLuu_DinhRanh ?? 0,
                            CDThuongLuu_DinhOngNhua = MNuocMua.CDThuongLuu_DinhOngNhua ?? 0,
                            CDThuongLuu_DinhDapCat = MNuocMua.CDThuongLuu_DinhDapCat ?? 0,
                            CDHaLu_HienTrangTruocKhiDaoHaLuu = MNuocMua.CDHaLu_HienTrangTruocKhiDaoHaLuu ?? 0,
                            CDHaLu_DayDaoGop = MNuocMua.CDHaLu_DayDaoGop ?? 0,
                            CDHaLu_ChieuSauDao = MNuocMua.CDHaLu_ChieuSauDao ?? 0,
                            CDHaLu_DayDaoCongTron = MNuocMua.CDHaLu_DayDaoCongTron ?? 0,
                            CDHaLu_DayDaoCongHop = MNuocMua.CDHaLu_DayDaoCongHop ?? 0,
                            CDHaLu_DayDaoRanh = MNuocMua.CDHaLu_DayDaoRanh ?? 0,
                            CDHaLu_DayDaoOngNhua = MNuocMua.CDHaLu_DayDaoOngNhua ?? 0,
                            CDHaLu_DinhLotGop = MNuocMua.CDHaLu_DinhLotGop ?? 0,
                            CDHaLu_DinhLotOngNhua = MNuocMua.CDHaLu_DinhLotOngNhua ?? 0,
                            CDHaLu_DinhLotCongTron = MNuocMua.CDHaLu_DinhLotCongTron ?? 0,
                            CDHaLu_DinhLotCongHop = MNuocMua.CDHaLu_DinhLotCongHop ?? 0,
                            CDHaLu_DinhLotRanh = MNuocMua.CDHaLu_DinhLotRanh ?? 0,
                            CDHaLu_DinhMongGop = MNuocMua.CDHaLu_DinhMongGop ?? 0,
                            CDHaLu_DinhMongCongTron = MNuocMua.CDHaLu_DinhMongCongTron ?? 0,
                            CDHaLu_DinhMongCongHop = MNuocMua.CDHaLu_DinhMongCongHop ?? 0,
                            CDHaLu_DinhMongRanh = MNuocMua.CDHaLu_DinhMongRanh ?? 0,
                            CDHaLu_DinhDeCong = MNuocMua.CDHaLu_DinhDeCong ?? 0,
                            CDHaLu_DayDongChay = MNuocMua.CDHaLu_DayDongChay ?? 0,
                            CDHaLu_CCaoTuongCongRanh = MNuocMua.CDHaLu_CCaoTuongCongRanh ?? 0,
                            CDHaLu_DinhTuongCHopRanh = MNuocMua.CDHaLu_DinhTuongCHopRanh ?? 0,
                            CDHaLu_DinhMuMoThotDuoiCongHopRanh = MNuocMua.CDHaLu_DinhMuMoThotDuoiCongHopRanh ?? 0,
                            CDHaLu_DinhGop = MNuocMua.CDHaLu_DinhGop ?? 0,
                            CDHaLu_DinhTrongLongSuDung = MNuocMua.CDHaLu_DinhTrongLongSuDung ?? 0,
                            CDHaLu_DinhCongTron = MNuocMua.CDHaLu_DinhCongTron ?? 0,
                            CDHaLu_DinhCongHop = MNuocMua.CDHaLu_DinhCongHop ?? 0,
                            CDHaLu_DinhRanh = MNuocMua.CDHaLu_DinhRanh ?? 0,
                            CDHaLu_DinhOngNhua = MNuocMua.CDHaLu_DinhOngNhua ?? 0,
                            CDHaLu_DinhDapCat = MNuocMua.CDHaLu_DinhDapCat ?? 0,
                            TTVLDCongRanh_LoaiVatLieuDao = MNuocMua.TTVLDCongRanh_LoaiVatLieuDao ?? "",
                            TTVLDCongRanh_TLChieuCaoDaoDa = MNuocMua.TTVLDCongRanh_TLChieuCaoDaoDa ?? 0,
                            TTVLDCongRanh_TLChieuCaoDaoDat = MNuocMua.TTVLDCongRanh_TLChieuCaoDaoDat ?? 0,
                            TTVLDCongRanh_TLTongChieuSauDao = MNuocMua.TTVLDCongRanh_TLTongChieuSauDao ?? 0,
                            TTVLDCongRanh_HLChieuCaoDaoDa = MNuocMua.TTVLDCongRanh_HLChieuCaoDaoDa ?? 0,
                            TTVLDCongRanh_HLChieuCaoDaoDat = MNuocMua.TTVLDCongRanh_HLChieuCaoDaoDat ?? 0,
                            TTVLDCongRanh_HLTongChieuSauDao = MNuocMua.TTVLDCongRanh_HLTongChieuSauDao ?? 0,
                            TTCCCCT_CCaoLotDatTLuu = MNuocMua.TTCCCCT_CCaoLotDatTLuu ?? 0,
                            TTCCCCT_CCaoLotDatHLuu = MNuocMua.TTCCCCT_CCaoLotDatHLuu ?? 0,
                            TTCCCCT_CCaoLotDatMongTBinh = MNuocMua.TTCCCCT_CCaoLotDatMongTBinh ?? 0,
                            TTCCCCT_CCaoLotDaTLuu = MNuocMua.TTCCCCT_CCaoLotDaTLuu ?? 0,
                            TTCCCCT_CCaoLotDaHLuu = MNuocMua.TTCCCCT_CCaoLotDaHLuu ?? 0,
                            TTCCCCT_CCaoLotDaMongTBinh = MNuocMua.TTCCCCT_CCaoLotDaMongTBinh ?? 0,
                            TTCCCCT_CCaoMongDatTLuu = MNuocMua.TTCCCCT_CCaoMongDatTLuu ?? 0,
                            TTCCCCT_CCaoMongDatHLuu = MNuocMua.TTCCCCT_CCaoMongDatHLuu ?? 0,
                            TTCCCCT_CCaoMongDatTBinh = MNuocMua.TTCCCCT_CCaoMongDatTBinh ?? 0,
                            TTCCCCT_CCaoMongDaTLuu = MNuocMua.TTCCCCT_CCaoMongDaTLuu ?? 0,
                            TTCCCCT_CCaoMongDaHLuu = MNuocMua.TTCCCCT_CCaoMongDaHLuu ?? 0,
                            TTCCCCT_CCaoMongDaTBinh = MNuocMua.TTCCCCT_CCaoMongDaTBinh ?? 0,
                            TTCCCCT_CCaoDeDatTLuu = MNuocMua.TTCCCCT_CCaoDeDatTLuu ?? 0,
                            TTCCCCT_CCaoDeDatHLuu = MNuocMua.TTCCCCT_CCaoDeDatHLuu ?? 0,
                            TTCCCCT_CCaoDeDatTBinh = MNuocMua.TTCCCCT_CCaoDeDatTBinh ?? 0,
                            TTCCCCT_CCaoDeDaTLuu = MNuocMua.TTCCCCT_CCaoDeDaTLuu ?? 0,
                            TTCCCCT_CCaoDeDaHLuu = MNuocMua.TTCCCCT_CCaoDeDaHLuu ?? 0,
                            TTCCCCT_CCaoDeDaTBinh = MNuocMua.TTCCCCT_CCaoDeDaTBinh ?? 0,
                            TTCCCCT_CCaoCongDatTLuu = MNuocMua.TTCCCCT_CCaoCongDatTLuu ?? 0,
                            TTCCCCT_CCaoCongDatHLuu = MNuocMua.TTCCCCT_CCaoCongDatHLuu ?? 0,
                            TTCCCCT_CCongCongDatTBinh = MNuocMua.TTCCCCT_CCongCongDatTBinh ?? 0,
                            TTCCCCT_CCaoCongDaTLuu = MNuocMua.TTCCCCT_CCaoCongDaTLuu ?? 0,
                            TTCCCCT_CCaoCongDaHLuu = MNuocMua.TTCCCCT_CCaoCongDaHLuu ?? 0,
                            TTCCCCT_CCongCongDaTBinh = MNuocMua.TTCCCCT_CCongCongDaTBinh ?? 0,
                            TTCCCCCHR_CCaoLotDatTLuu = MNuocMua.TTCCCCCHR_CCaoLotDatTLuu ?? 0,
                            TTCCCCCHR_CCaoLotDatHLuu = MNuocMua.TTCCCCCHR_CCaoLotDatHLuu ?? 0,
                            TTCCCCCHR_CCaoLotDatTBinh = MNuocMua.TTCCCCCHR_CCaoLotDatTBinh ?? 0,
                            TTCCCCCHR_CCaoLotDaTLuu = MNuocMua.TTCCCCCHR_CCaoLotDaTLuu ?? 0,
                            TTCCCCCHR_CCaoLotDaHLuu = MNuocMua.TTCCCCCHR_CCaoLotDaHLuu ?? 0,
                            TTCCCCCHR_CCaoLotDaTBinh = MNuocMua.TTCCCCCHR_CCaoLotDaTBinh ?? 0,
                            TTCCCCCHR_CCaoMongDatTLuu = MNuocMua.TTCCCCCHR_CCaoMongDatTLuu ?? 0,
                            TTCCCCCHR_CCaoMongDatHLuu = MNuocMua.TTCCCCCHR_CCaoMongDatHLuu ?? 0,
                            TTCCCCCHR_CCaoMongDatTBinh = MNuocMua.TTCCCCCHR_CCaoMongDatTBinh ?? 0,
                            TTCCCCCHR_CCaoMongDaTLuu = MNuocMua.TTCCCCCHR_CCaoMongDaTLuu ?? 0,
                            TTCCCCCHR_CCaoMongDaHLuu = MNuocMua.TTCCCCCHR_CCaoMongDaHLuu ?? 0,
                            TTCCCCCHR_CCaoMongDaTBinh = MNuocMua.TTCCCCCHR_CCaoMongDaTBinh ?? 0,
                            TTCCCCCHR_CCaoTuongDatTLuu = MNuocMua.TTCCCCCHR_CCaoTuongDatTLuu ?? 0,
                            TTCCCCCHR_CCaoTuongDatHLuu = MNuocMua.TTCCCCCHR_CCaoTuongDatHLuu ?? 0,
                            TTCCCCCHR_CCaoTuongDatTBinh = MNuocMua.TTCCCCCHR_CCaoTuongDatTBinh ?? 0,
                            TTCCCCCHR_CCaoTuongDaTLuu = MNuocMua.TTCCCCCHR_CCaoTuongDaTLuu ?? 0,
                            TTCCCCCHR_CCaoTuongDaHLuu = MNuocMua.TTCCCCCHR_CCaoTuongDaHLuu ?? 0,
                            TTCCCCCHR_CCaoTuongDaTBinh = MNuocMua.TTCCCCCHR_CCaoTuongDaTBinh ?? 0,
                            TTCCCCON_CCaoDemCatDatTLuu = MNuocMua.TTCCCCON_CCaoDemCatDatTLuu ?? 0,
                            TTCCCCON_CCaoDemCatDatHLuu = MNuocMua.TTCCCCON_CCaoDemCatDatHLuu ?? 0,
                            TTCCCCON_CCaoDemCatDatTBinh = MNuocMua.TTCCCCON_CCaoDemCatDatTBinh ?? 0,
                            TTCCCCON_CCaoDemCatDaTLuu = MNuocMua.TTCCCCON_CCaoDemCatDaTLuu ?? 0,
                            TTCCCCON_CCaoDemCatDaHLuu = MNuocMua.TTCCCCON_CCaoDemCatDaHLuu ?? 0,
                            TTCCCCON_CCaoDemCatDaTBinh = MNuocMua.TTCCCCON_CCaoDemCatDaTBinh ?? 0,
                            TTCCCCON_CCaoOngDatTLuu = MNuocMua.TTCCCCON_CCaoOngDatTLuu ?? 0,
                            TTCCCCON_CCaoOngDatHLuu = MNuocMua.TTCCCCON_CCaoOngDatHLuu ?? 0,
                            TTCCCCON_CCaoDatTBinh = MNuocMua.TTCCCCON_CCaoDatTBinh ?? 0,
                            TTCCCCON_CCaoOngDaTLuu = MNuocMua.TTCCCCON_CCaoOngDaTLuu ?? 0,
                            TTCCCCON_CCaoOngDaHLuu = MNuocMua.TTCCCCON_CCaoOngDaHLuu ?? 0,
                            TTCCCCON_CCaoDaTBinh = MNuocMua.TTCCCCON_CCaoDaTBinh ?? 0,
                            TTCCCCON_CCaoDapCatDatTLuu = MNuocMua.TTCCCCON_CCaoDapCatDatTLuu ?? 0,
                            TTCCCCON_CCaoDapCatDatHLuu = MNuocMua.TTCCCCON_CCaoDapCatDatHLuu ?? 0,
                            TTCCCCON_CCaoDapCatDatTBinh = MNuocMua.TTCCCCON_CCaoDapCatDatTBinh ?? 0,
                            TTCCCCON_CCaoDapCatDaTLuu = MNuocMua.TTCCCCON_CCaoDapCatDaTLuu ?? 0,
                            TTCCCCON_CCaoDapCatDaHLuu = MNuocMua.TTCCCCON_CCaoDapCatDaHLuu ?? 0,
                            TTCCCCON_CCaoDapCatDaTBinh = MNuocMua.TTCCCCON_CCaoDapCatDaTBinh ?? 0,
                            TTMDRanhOngThang_ChieuRongDayDaoNho = MNuocMua.TTMDRanhOngThang_ChieuRongDayDaoNho ?? 0,
                            TTMDRanhOngThang_TyLeMoMai = MNuocMua.TTMDRanhOngThang_TyLeMoMai ?? 0,
                            TTMDRanhOngThang_SoCanhMaiTrai = MNuocMua.TTMDRanhOngThang_SoCanhMaiTrai ?? 0,
                            TTMDRanhOngThang_SoCanhMaiPhai = MNuocMua.TTMDRanhOngThang_SoCanhMaiPhai ?? 0,
                            DTDTLCRONRT_CRongDaoDatDayLon = MNuocMua.DTDTLCRONRT_CRongDaoDatDayLon ?? 0,
                            DTDTLCRONRT_DTichDaoDat = MNuocMua.DTDTLCRONRT_DTichDaoDat ?? 0,
                            DTDTLCRONRT_CRongDaoDaDayLon = MNuocMua.DTDTLCRONRT_CRongDaoDaDayLon ?? 0,
                            DTDTLCRONRT_DTichDaoDa = MNuocMua.DTDTLCRONRT_DTichDaoDa ?? 0,
                            DTDHLCRONRT_CRongDaoDatDayLon = MNuocMua.DTDHLCRONRT_CRongDaoDatDayLon ?? 0,
                            DTDHLCRONRT_DTichDaoDat = MNuocMua.DTDHLCRONRT_DTichDaoDat ?? 0,
                            DTDHLCRONRT_CRongDaoDaDayLon = MNuocMua.DTDHLCRONRT_CRongDaoDaDayLon ?? 0,
                            DTDHLCRONRT_DTichDaoDa = MNuocMua.DTDHLCRONRT_DTichDaoDa ?? 0,
                            DTDTB_DaoDatCRDaoDayLon = MNuocMua.DTDTB_DaoDatCRDaoDayLon ?? 0,
                            DTDTB_DaoDatDTDao = MNuocMua.DTDTB_DaoDatDTDao ?? 0,
                            DTDTB_DaoDaCRDaoDayLon = MNuocMua.DTDTB_DaoDaCRDaoDayLon ?? 0,
                            DTDTB_DaoDaDTDao = MNuocMua.DTDTB_DaoDaDTDao ?? 0,
                            TKLD_KlDaoDat = MNuocMua.TKLD_KlDaoDat ?? 0,
                            TKLD_KlDaoDa = MNuocMua.TKLD_KlDaoDa ?? 0,
                            TKLD_TongKlDaoCongRanhOngNhuaRanhThang = MNuocMua.TKLD_TongKlDaoCongRanhOngNhuaRanhThang ?? 0,
                            TKLD_KlCChoDatCongTron = MNuocMua.TKLD_KlCChoDatCongTron ?? 0,
                            TKLD_KlCChoDaCongTron = MNuocMua.TKLD_KlCChoDaCongTron ?? 0,
                            TKLD_TongKlChiemChoCTron = MNuocMua.TKLD_TongKlChiemChoCTron ?? 0,
                            TKLD_KlCChoDatCongHop = MNuocMua.TKLD_KlCChoDatCongHop ?? 0,
                            TKLD_KlCChoDaCongHop = MNuocMua.TKLD_KlCChoDaCongHop ?? 0,
                            TKLD_TongKlCChoCongHop = MNuocMua.TKLD_TongKlCChoCongHop ?? 0,
                            TKLD_KlCChoDatRanh = MNuocMua.TKLD_KlCChoDatRanh ?? 0,
                            TKLD_KlCChoDaRanh = MNuocMua.TKLD_KlCChoDaRanh ?? 0,
                            TKLD_TongKlCChoRanh = MNuocMua.TKLD_TongKlCChoRanh ?? 0,
                            TKLD_KlCChoDatOngNhua = MNuocMua.TKLD_KlCChoDatOngNhua ?? 0,
                            TKLD_KlCChoDaOngNhua = MNuocMua.TKLD_KlCChoDaOngNhua ?? 0,
                            TKLD_TongKlCChoOngNhua = MNuocMua.TKLD_TongKlCChoOngNhua ?? 0,
                            TKLD_KlCChoDat = MNuocMua.TKLD_KlCChoDat ?? 0,
                            TKLD_KlCChoDa = MNuocMua.TKLD_KlCChoDa ?? 0,
                            TKLD_TongChiemCho = MNuocMua.TKLD_TongChiemCho ?? 0,
                            TKLD_KlDapTraDat = MNuocMua.TKLD_KlDapTraDat ?? 0,
                            TKLD_KlDapTraDa = MNuocMua.TKLD_KlDapTraDa ?? 0,
                            TKLD_TongKlDapTra = MNuocMua.TKLD_TongKlDapTra ?? 0,
                            TKLD_KlThuaDat = MNuocMua.TKLD_KlThuaDat ?? 0,
                            TKLD_KlThuaDa = MNuocMua.TKLD_KlThuaDa ?? 0,
                            TKLD_TongKLThua = MNuocMua.TKLD_TongKLThua ?? 0,
                            DTDC_TLCSauDap = MNuocMua.DTDC_TLCSauDap ?? 0,
                            DTDC_TLCRongDapDayLon = MNuocMua.DTDC_TLCRongDapDayLon ?? 0,
                            DTDC_TLDTichDap = MNuocMua.DTDC_TLDTichDap ?? 0,
                            DTDC_HLCSauDap = MNuocMua.DTDC_HLCSauDap ?? 0,
                            DTDC_HLCRongDapDayLon = MNuocMua.DTDC_HLCRongDapDayLon ?? 0,
                            DTDC_HLDTichDap = MNuocMua.DTDC_HLDTichDap ?? 0,
                            DTTB_CSDap = MNuocMua.DTTB_CSDap ?? 0,
                            DTTB_CRDapDayLon = MNuocMua.DTTB_CRDapDayLon ?? 0,
                            DTTB_DTichDap = MNuocMua.DTTB_DTichDap ?? 0,
                            TTKLDC_KlDapCatTruocChiemCho = MNuocMua.TTKLDC_KlDapCatTruocChiemCho ?? 0,
                            TTKLDC_KlChiemCho = MNuocMua.TTKLDC_KlChiemCho ?? 0,
                            TTKLDC_KlDapCatSauChiemCho = MNuocMua.TTKLDC_KlDapCatSauChiemCho ?? 0,
                            ToaDoX = MNuocMua.ToaDoX ?? 0,
                            ToaDoY = MNuocMua.ToaDoY ?? 0,

                        };
            var data = await query.ToListAsync();
            return data;
        }


        public async Task Update(MNuocMua mNuocMua)
        {
            using var context = _context.CreateDbContext();
            var entity = GetById(mNuocMua.Id);

            if (entity == null)
            {
                throw new Exception($"Không tìm thấy bản ghi theo ID: {mNuocMua.Id}");
            }

            context.DSNuocMua.Update(mNuocMua);
            await context.SaveChangesAsync();
        }

        public async Task UpdateMulti(MNuocMua[] mNuocMua)
        {
            using var context = _context.CreateDbContext();
            string[] ids = mNuocMua.Select(x => x.Id).ToArray();
            var listEntities = await context.DSNuocMua.Where(x => ids.Contains(x.Id)).ToListAsync();
            foreach (var entity in listEntities)
            {
                context.DSNuocMua.Update(entity);
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
            context.Set<MNuocMua>().Remove(entity);
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

        public async Task<MNuocMua> GetById(string id)
        {
            try
            {
                using var context = _context.CreateDbContext();
                // Tìm kiếm bản ghi theo ID
                var entity = await context.DSNuocMua
                    .FirstOrDefaultAsync(x => x.Id.Equals(id));

                if (entity == null)
                {
                    throw new Exception($"Không tìm thấy bản ghi theo ID: {id}");
                }

                return entity;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

        }

        public async Task Insert(MNuocMua entity)
        {
            try
            {
                using var context = _context.CreateDbContext();
                if (entity == null)
                {
                    throw new Exception("Không có bản ghi nào để thêm!");
                }
                context.DSNuocMua.Add(entity);
                var row = await context.SaveChangesAsync();
                Console.WriteLine(row);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task<int> MultiInsert(List<MNuocMua> entities)
        {
            try
            {
                using var context = _context.CreateDbContext();

                if (entities == null || entities.Count == 0)
                {
                    throw new Exception("Không có bản ghi nào để thêm!");
                }

                foreach (var entity in entities)
                {
                    context.DSNuocMua.Add(entity);
                }

                int rowsInserted = await context.SaveChangesAsync();
                return rowsInserted;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0; // Trả về 0 nếu có lỗi xảy ra
            }
        }
    }
}
