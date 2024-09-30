using DucAnhERP.Data;
using DucAnhERP.Models;
using DucAnhERP.Repository;
using DucAnhERP.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace DucAnhERP.Services
{
    public class MangThuRepository :IMangThuRepository
    {
        private readonly IDbContextFactory<ApplicationDbContext> _context;

        public MangThuRepository(IDbContextFactory<ApplicationDbContext> context)
        {
            _context = context;
        }

        public async Task<List<MangThu>> GetAll()
        {
            try
            {
                using var context = _context.CreateDbContext();
                var entity = await context.MangThus.ToListAsync();
                return entity;
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.Error.WriteLine($"An error occurred: {ex.Message}");
                throw; // Optionally rethrow the exception
            }
        }

        public async Task<List<MangThuModel>> GetData()
        {

            try
            {
                using var context = _context.CreateDbContext();
                var query = from MangThu in context.MangThus
                                // Left join với bảng PhanLoaiHoGas
                                //join phanLoaiHoGa in context.PhanLoaiHoGas
                                //on MangThu.ThongTinChungHoGa_TenHoGaSauPhanLoai equals phanLoaiHoGa.Id into phanLoaiHoGaJoin
                                //from phanLoaiHoGa in phanLoaiHoGaJoin.DefaultIfEmpty()

                                // Sắp xếp theo Flag của MangThus
                            orderby MangThu.Flag
                            select new MangThuModel
                            {
                                Id = MangThu.Id ?? "",
                                TTLT_TuyenDuong = MangThu.TTLT_TuyenDuong ?? "",
                                TTLT_LyTrinhTaiTimHoGa = MangThu.TTLT_LyTrinhTaiTimHoGa ?? "",
                                TTLT_TenHoGaSauPhanLoai = MangThu.TTLT_TenHoGaSauPhanLoai ?? "",
                                TTLT_TenHoGaTheoBanVe = MangThu.TTLT_TenHoGaTheoBanVe ?? "",
                                TTCMT_TenMangThuTheoBanVe = MangThu.TTCMT_TenMangThuTheoBanVe ?? "",
                                TTCMT_MangThuNuocSauPhanLoai = MangThu.TTCMT_MangThuNuocSauPhanLoai ?? "",
                                TTCMT_HinhThucThuNuoc = MangThu.TTCMT_HinhThucThuNuoc ?? "",
                                TTBVHE_CauTao = MangThu.TTBVHE_CauTao ?? "",
                                TTBVHE_CRongCuaThu = MangThu.TTBVHE_CRongCuaThu ?? 0,
                                TTBVHE_Lot_D = MangThu.TTBVHE_Lot_D ?? 0,
                                TTBVHE_Lot_R = MangThu.TTBVHE_Lot_R ?? 0,
                                TTBVHE_Lot_C = MangThu.TTBVHE_Lot_C ?? 0,
                                TTBVHE_Mong_D = MangThu.TTBVHE_Mong_D ?? 0,
                                TTBVHE_Mong_R = MangThu.TTBVHE_Mong_R ?? 0,
                                TTBVHE_Mong_C = MangThu.TTBVHE_Mong_C ?? 0,
                                TTBVHE_HamEch_D = MangThu.TTBVHE_HamEch_D ?? 0,
                                TTBVHE_HamEch_R = MangThu.TTBVHE_HamEch_R ?? 0,
                                TTBVHE_HamEch_C = MangThu.TTBVHE_HamEch_C ?? 0,
                                KTHHHT_HinhThucHoThu = MangThu.KTHHHT_HinhThucHoThu ?? "",
                                KTHHHT_KetCauMuMo = MangThu.KTHHHT_KetCauMuMo ?? "",
                                KTHHHT_KetCauTuong = MangThu.KTHHHT_KetCauTuong ?? "",
                                KTHHHT_HinhThucMongHoThu = MangThu.KTHHHT_HinhThucMongHoThu ?? "",
                                KTHHHT_KetCauMong = MangThu.KTHHHT_KetCauMong ?? "",
                                KTHHHT_ChatMatTrong = MangThu.KTHHHT_ChatMatTrong ?? "",
                                KTHHHT_ChatMatNgoai = MangThu.KTHHHT_ChatMatNgoai ?? "",
                                KTHHHT_PhuBi_CDai = MangThu.KTHHHT_PhuBi_CDai ?? 0,
                                KTHHHT_PhuBi_CRong = MangThu.KTHHHT_PhuBi_CRong ?? 0,
                                KTHHHT_Lot_D = MangThu.KTHHHT_Lot_D ?? 0,
                                KTHHHT_Lot_R = MangThu.KTHHHT_Lot_R ?? 0,
                                KTHHHT_Lot_C = MangThu.KTHHHT_Lot_C ?? 0,
                                KTHHHT_Mong_D = MangThu.KTHHHT_Mong_D ?? 0,
                                KTHHHT_Mong_R = MangThu.KTHHHT_Mong_R ?? 0,
                                KTHHHT_Mong_C = MangThu.KTHHHT_Mong_C ?? 0,
                                KTHHHT_De_D = MangThu.KTHHHT_De_D ?? 0,
                                KTHHHT_De_R = MangThu.KTHHHT_De_R ?? 0,
                                KTHHHT_De_C = MangThu.KTHHHT_De_C ?? 0,
                                KTHHHT_Tuong_D = MangThu.KTHHHT_Tuong_D ?? 0,
                                KTHHHT_Tuong_R = MangThu.KTHHHT_Tuong_R ?? 0,
                                KTHHHT_Tuong_C = MangThu.KTHHHT_Tuong_C ?? 0,
                                KTHHHT_Tuong_CdTuong = MangThu.KTHHHT_Tuong_CdTuong ?? 0,
                                KTHHHT_Dam_D = MangThu.KTHHHT_Dam_D ?? 0,
                                KTHHHT_Dam_R = MangThu.KTHHHT_Dam_R ?? 0,
                                KTHHHT_Dam_C = MangThu.KTHHHT_Dam_C ?? 0,
                                KTHHHT_Dam_CdDam = MangThu.KTHHHT_Dam_CdDam ?? 0,
                                KTHHHT_Dam_CCaoTuong = MangThu.KTHHHT_Dam_CCaoTuong ?? 0,
                                KTHHHT_ChatTrong_D = MangThu.KTHHHT_ChatTrong_D ?? 0,
                                KTHHHT_ChatTrong_R = MangThu.KTHHHT_ChatTrong_R ?? 0,
                                KTHHHT_ChatTrong_C = MangThu.KTHHHT_ChatTrong_C ?? 0,
                                KTHHHT_ChatNgoai_D = MangThu.KTHHHT_ChatNgoai_D ?? 0,
                                KTHHHT_ChatNgoai_R = MangThu.KTHHHT_ChatNgoai_R ?? 0,
                                KTHHHT_ChatNgoai_C = MangThu.KTHHHT_ChatNgoai_C ?? 0,
                                KTHHHT_MMTD_D = MangThu.KTHHHT_MMTD_D ?? 0,
                                KTHHHT_MMTD_R = MangThu.KTHHHT_MMTD_R ?? 0,
                                KTHHHT_MMTD_C = MangThu.KTHHHT_MMTD_C ?? 0,
                                KTHHHT_MMTD_CdTuong = MangThu.KTHHHT_MMTD_CdTuong ?? 0,
                                KTHHHT_MMTT_D = MangThu.KTHHHT_MMTT_D ?? 0,
                                KTHHHT_MMTT_R = MangThu.KTHHHT_MMTT_R ?? 0,
                                KTHHHT_MMTT_C = MangThu.KTHHHT_MMTT_C ?? 0,
                                KTHHHT_MMTT_CdTuong = MangThu.KTHHHT_MMTT_CdTuong ?? 0,
                                HMCCHT_1_Loai = MangThu.HMCCHT_1_Loai ?? 0,
                                HMCCHT_1_CanhDai = MangThu.HMCCHT_1_CanhDai ?? 0,
                                HMCCHT_1_CanhRong = MangThu.HMCCHT_1_CanhRong ?? 0,
                                HMCCHT_1_CanhCheo = MangThu.HMCCHT_1_CanhCheo ?? 0,
                                HMCCHT_2_Loai = MangThu.HMCCHT_2_Loai ?? 0,
                                HMCCHT_2_CanhDai = MangThu.HMCCHT_2_CanhDai ?? 0,
                                HMCCHT_2_CanhRong = MangThu.HMCCHT_2_CanhRong ?? 0,
                                HMCCHT_2_CanhCheo = MangThu.HMCCHT_2_CanhCheo ?? 0,
                                HMCCHT_3_Loai = MangThu.HMCCHT_3_Loai ?? 0,
                                HMCCHT_3_CanhDai = MangThu.HMCCHT_3_CanhDai ?? 0,
                                HMCCHT_3_CanhRong = MangThu.HMCCHT_3_CanhRong ?? 0,
                                HMCCHT_3_CanhCheo = MangThu.HMCCHT_3_CanhCheo ?? 0,
                                HMCCHT_4_Loai = MangThu.HMCCHT_4_Loai ?? 0,
                                HMCCHT_4_CanhDai = MangThu.HMCCHT_4_CanhDai ?? 0,
                                HMCCHT_4_CanhRong = MangThu.HMCCHT_4_CanhRong ?? 0,
                                HMCCHT_4_CanhCheo = MangThu.HMCCHT_4_CanhCheo ?? 0,
                                HMCCHT_5_Loai = MangThu.HMCCHT_5_Loai ?? 0,
                                HMCCHT_5_CanhDai = MangThu.HMCCHT_5_CanhDai ?? 0,
                                HMCCHT_5_CanhRong = MangThu.HMCCHT_5_CanhRong ?? 0,
                                HMCCHT_5_CanhCheo = MangThu.HMCCHT_5_CanhCheo ?? 0,
                                HMCCHT_6_Loai = MangThu.HMCCHT_6_Loai ?? 0,
                                HMCCHT_6_CanhDai = MangThu.HMCCHT_6_CanhDai ?? 0,
                                HMCCHT_6_CanhRong = MangThu.HMCCHT_6_CanhRong ?? 0,
                                HMCCHT_6_CanhCheo = MangThu.HMCCHT_6_CanhCheo ?? 0,
                                HMCCHT_7_Loai = MangThu.HMCCHT_7_Loai ?? 0,
                                HMCCHT_7_CanhDai = MangThu.HMCCHT_7_CanhDai ?? 0,
                                HMCCHT_7_CanhRong = MangThu.HMCCHT_7_CanhRong ?? 0,
                                HMCCHT_7_CanhCheo = MangThu.HMCCHT_7_CanhCheo ?? 0,
                                HMCCHT_8_Loai = MangThu.HMCCHT_8_Loai ?? 0,
                                HMCCHT_8_CanhDai = MangThu.HMCCHT_8_CanhDai ?? 0,
                                HMCCHT_8_CanhRong = MangThu.HMCCHT_8_CanhRong ?? 0,
                                HMCCHT_8_CanhCheo = MangThu.HMCCHT_8_CanhCheo ?? 0,
                                TTTDHT_PhanLoaiDayHoThu = MangThu.TTTDHT_PhanLoaiDayHoThu ?? "",
                                TTTDHT_HinhThucDayHoThu = MangThu.TTTDHT_HinhThucDayHoThu ?? "",
                                TTTDHT_Tron_DuongKinh = MangThu.TTTDHT_Tron_DuongKinh ?? 0,
                                TTTDHT_Tron_ChieuDay = MangThu.TTTDHT_Tron_ChieuDay ?? 0,
                                TTTDHT_VCN_D = MangThu.TTTDHT_VCN_D ?? 0,
                                TTTDHT_VCN_R = MangThu.TTTDHT_VCN_R ?? 0,
                                TTTDHT_VCN_C = MangThu.TTTDHT_VCN_C ?? 0,
                                TTTDHT_VCN_SoLuongNapDay = MangThu.TTTDHT_VCN_SoLuongNapDay ?? 0,
                                TTDN_CauTaoDamNgang = MangThu.TTDN_CauTaoDamNgang ?? "",
                                TTDN_DN_D = MangThu.TTDN_DN_D ?? 0,
                                TTDN_DN_R = MangThu.TTDN_DN_R ?? 0,
                                TTDN_DN_C = MangThu.TTDN_DN_C ?? 0,
                                TTVLDHT_LoaiVatLieuDao = MangThu.TTVLDHT_LoaiVatLieuDao ?? "",
                                TTVLDHT_ChieuCaoDaoDa = MangThu.TTVLDHT_ChieuCaoDaoDa ?? 0,
                                TTVLDHT_ChieuCaoDaoDat = MangThu.TTVLDHT_ChieuCaoDaoDat ?? 0,
                                TTVLDHT_TongChieuCaoDao = MangThu.TTVLDHT_TongChieuCaoDao ?? 0,
                                TTCD_HE_CaoDoHienTrangTruocKhiDao = MangThu.TTCD_HE_CaoDoHienTrangTruocKhiDao ?? 0,
                                TTCD_HE_DayDao = MangThu.TTCD_HE_DayDao ?? 0,
                                TTCD_HE_CSauDao = MangThu.TTCD_HE_CSauDao ?? 0,
                                TTCD_HE_DinhLot = MangThu.TTCD_HE_DinhLot ?? 0,
                                TTCD_HE_DinhMong = MangThu.TTCD_HE_DinhMong ?? 0,
                                TTCD_HE_DinhBoViaHamEch = MangThu.TTCD_HE_DinhBoViaHamEch ?? 0,
                                TTCD_HE_TongChieuCaoBoVia = MangThu.TTCD_HE_TongChieuCaoBoVia ?? 0,
                                TTCD_HE_ChenhCaoDinh = MangThu.TTCD_HE_ChenhCaoDinh ?? 0,
                                TTCD_HE_TongChieuCao = MangThu.TTCD_HE_TongChieuCao ?? 0,
                                TTCD_DN_CdDinhDamNgang = MangThu.TTCD_DN_CdDinhDamNgang ?? 0,
                                TTCD_DN_CdHienTrang = MangThu.TTCD_DN_CdHienTrang ?? 0,
                                TTCD_HT_CaoDoHienTrang = MangThu.TTCD_HT_CaoDoHienTrang ?? 0,
                                TTCD_HT_DayDao = MangThu.TTCD_HT_DayDao ?? 0,
                                TTCD_HT_CSauDao = MangThu.TTCD_HT_CSauDao ?? 0,
                                TTCD_HT_DinhLotMong = MangThu.TTCD_HT_DinhLotMong ?? 0,
                                TTCD_HT_CdDinhMong = MangThu.TTCD_HT_CdDinhMong ?? 0,
                                TTCD_HT_CdDayHoThu = MangThu.TTCD_HT_CdDayHoThu ?? 0,
                                TTCD_HT_CCaoTuong = MangThu.TTCD_HT_CCaoTuong ?? 0,
                                TTCD_HT_DinhTuongDuoi = MangThu.TTCD_HT_DinhTuongDuoi ?? 0,
                                TTCD_HT_DinhDamGiuaTuong = MangThu.TTCD_HT_DinhDamGiuaTuong ?? 0,
                                TTCD_HT_DinhTuong = MangThu.TTCD_HT_DinhTuong ?? 0,
                                TTCD_HT_DinhMuMoThotDuoi = MangThu.TTCD_HT_DinhMuMoThotDuoi ?? 0,
                                TTCD_HT_CdDinhHoThu = MangThu.TTCD_HT_CdDinhHoThu ?? 0,
                                TTCD_HT_TongChieuCaoHoThu = MangThu.TTCD_HT_TongChieuCaoHoThu ?? 0,
                                TTCD_HT_ChenhCaoDinh = MangThu.TTCD_HT_ChenhCaoDinh ?? 0,
                                TTCD_HT_TongChieuCao = MangThu.TTCD_HT_TongChieuCao ?? 0,
                                TTCCDT_BV_CCaoLotBoViaCChoDat = MangThu.TTCCDT_BV_CCaoLotBoViaCChoDat ?? 0,
                                TTCCDT_BV_CCaoMongBoViaCChoDat = MangThu.TTCCDT_BV_CCaoMongBoViaCChoDat ?? 0,
                                TTCCDT_BV_CCaoBoViaCChoDat = MangThu.TTCCDT_BV_CCaoBoViaCChoDat ?? 0,
                                TTCCDT_BV_CCaoLotBoViaCChoDa = MangThu.TTCCDT_BV_CCaoLotBoViaCChoDa ?? 0,
                                TTCCDT_BV_CCaoMongBoViaCChoDa = MangThu.TTCCDT_BV_CCaoMongBoViaCChoDa ?? 0,
                                TTCCDT_BV_CCaoBoViaCChoDa = MangThu.TTCCDT_BV_CCaoBoViaCChoDa ?? 0,
                                TTCCDT_BV_TongCCaoCChoDat = MangThu.TTCCDT_BV_TongCCaoCChoDat ?? 0,
                                TTCCDT_BV_TongCCaoCChoDa = MangThu.TTCCDT_BV_TongCCaoCChoDa ?? 0,
                                TTCCDT_BV_ChenhDatSoVoiThietKe = MangThu.TTCCDT_BV_ChenhDatSoVoiThietKe ?? 0,
                                TTCCDT_BV_ChenhDaSoVoiThietKe = MangThu.TTCCDT_BV_ChenhDaSoVoiThietKe ?? 0,
                                TTCCDT_HT_ChieuCaoLotCChoDat = MangThu.TTCCDT_HT_ChieuCaoLotCChoDat ?? 0,
                                TTCCDT_HT_ChieuCaoMongCChoDat = MangThu.TTCCDT_HT_ChieuCaoMongCChoDat ?? 0,
                                TTCCDT_HT_ChieuCaoTuongCChoDat = MangThu.TTCCDT_HT_ChieuCaoTuongCChoDat ?? 0,
                                TTCCDT_HT_ChieuCaoLotCChoDa = MangThu.TTCCDT_HT_ChieuCaoLotCChoDa ?? 0,
                                TTCCDT_HT_ChieuCaoMongCChoDa = MangThu.TTCCDT_HT_ChieuCaoMongCChoDa ?? 0,
                                TTCCDT_HT_ChieuCaoTuongCChoDa = MangThu.TTCCDT_HT_ChieuCaoTuongCChoDa ?? 0,
                                TTCCDT_HT_TongCCaoDatCCho = MangThu.TTCCDT_HT_TongCCaoDatCCho ?? 0,
                                TTCCDT_HT_TongCCaoDaCCho = MangThu.TTCCDT_HT_TongCCaoDaCCho ?? 0,
                                TTCCDT_HT_ChenhDatSoVoiThietKe = MangThu.TTCCDT_HT_ChenhDatSoVoiThietKe ?? 0,
                                TTCCDT_HT_ChenhDaSoVoiThietKe = MangThu.TTCCDT_HT_ChenhDaSoVoiThietKe ?? 0,
                                TTMD_ChieuRongDayDaoNho = MangThu.TTMD_ChieuRongDayDaoNho ?? 0,
                                TTMD_TyLeMoMai = MangThu.TTMD_TyLeMoMai ?? 0,
                                TTMD_SoCanhMaiTrai = MangThu.TTMD_SoCanhMaiTrai ?? 0,
                                TTMD_SoCanhMaiPhai = MangThu.TTMD_SoCanhMaiPhai ?? 0,
                                TTDTD_BV_CRongDaoDayLonDat = MangThu.TTDTD_BV_CRongDaoDayLonDat ?? 0,
                                TTDTD_BV_CRongDaoDayLonDa = MangThu.TTDTD_BV_CRongDaoDayLonDa ?? 0,
                                TTDTD_BV_DienTichDaoDat = MangThu.TTDTD_BV_DienTichDaoDat ?? 0,
                                TTDTD_BV_DienTichDaoDa = MangThu.TTDTD_BV_DienTichDaoDa ?? 0,
                                TTDTD_BV_TongDtDao = MangThu.TTDTD_BV_TongDtDao ?? 0,
                                TTDTD_HT_CRongDaoDayLonDat = MangThu.TTDTD_HT_CRongDaoDayLonDat ?? 0,
                                TTDTD_HT_CRongDaoDayLonDa = MangThu.TTDTD_HT_CRongDaoDayLonDa ?? 0,
                                TTDTD_HT_DienTichDaoDat = MangThu.TTDTD_HT_DienTichDaoDat ?? 0,
                                TTDTD_HT_DienTichDaoDa = MangThu.TTDTD_HT_DienTichDaoDa ?? 0,
                                TTDTD_HT_TongDtDao = MangThu.TTDTD_HT_TongDtDao ?? 0,
                                DTDTB_CRongDaoDayLonDat = MangThu.DTDTB_CRongDaoDayLonDat ?? 0,
                                DTDTB_CRongDaoDayLonDa = MangThu.DTDTB_CRongDaoDayLonDa ?? 0,
                                DTDTB_DienTichDaoDat = MangThu.DTDTB_DienTichDaoDat ?? 0,
                                DTDTB_DienTichDaoDa = MangThu.DTDTB_DienTichDaoDa ?? 0,
                                DTDTB_TongDtDao = MangThu.DTDTB_TongDtDao ?? 0,
                                TTKLD_BV_KlDaoDat = MangThu.TTKLD_BV_KlDaoDat ?? 0,
                                TTKLD_BV_KlDaoDa = MangThu.TTKLD_BV_KlDaoDa ?? 0,
                                TTKLD_BV_TongKlDao = MangThu.TTKLD_BV_TongKlDao ?? 0,
                                TTKLD_BV_KlChiemChoDat = MangThu.TTKLD_BV_KlChiemChoDat ?? 0,
                                TTKLD_BV_KlChiemChoDa = MangThu.TTKLD_BV_KlChiemChoDa ?? 0,
                                TTKLD_BV_TongChiemCho = MangThu.TTKLD_BV_TongChiemCho ?? 0,
                                TTKLD_BV_KlDapTraDat = MangThu.TTKLD_BV_KlDapTraDat ?? 0,
                                TTKLD_BV_KlDapTraDa = MangThu.TTKLD_BV_KlDapTraDa ?? 0,
                                TTKLD_BV_TongDapTra = MangThu.TTKLD_BV_TongDapTra ?? 0,
                                TTKLD_BV_KlThuaDat = MangThu.TTKLD_BV_KlThuaDat ?? 0,
                                TTKLD_BV_KlThuaDa = MangThu.TTKLD_BV_KlThuaDa ?? 0,
                                TTKLD_BV_TongThua = MangThu.TTKLD_BV_TongThua ?? 0,
                                TTKLD_HT_KlDaoDat = MangThu.TTKLD_HT_KlDaoDat ?? 0,
                                TTKLD_HT_KlDaoDa = MangThu.TTKLD_HT_KlDaoDa ?? 0,
                                TTKLD_HT_TongKlDao = MangThu.TTKLD_HT_TongKlDao ?? 0,
                                TTKLD_HT_KlChiemChoDat = MangThu.TTKLD_HT_KlChiemChoDat ?? 0,
                                TTKLD_HT_KlChiemChoDa = MangThu.TTKLD_HT_KlChiemChoDa ?? 0,
                                TTKLD_HT_TongChiemCho = MangThu.TTKLD_HT_TongChiemCho ?? 0,
                                TTKLD_HT_KlDapTraDat = MangThu.TTKLD_HT_KlDapTraDat ?? 0,
                                TTKLD_HT_KlDapTraDa = MangThu.TTKLD_HT_KlDapTraDa ?? 0,
                                TTKLD_HT_TongDapTra = MangThu.TTKLD_HT_TongDapTra ?? 0,
                                TTKLD_HT_KlThuaDat = MangThu.TTKLD_HT_KlThuaDat ?? 0,
                                TTKLD_HT_KlThuaDa = MangThu.TTKLD_HT_KlThuaDa ?? 0,
                                TTKLD_HT_TongThua = MangThu.TTKLD_HT_TongThua ?? 0,
                                TTKLDTB_KlDaoDat = MangThu.TTKLDTB_KlDaoDat ?? 0,
                                TTKLDTB_KlDaoDa = MangThu.TTKLDTB_KlDaoDa ?? 0,
                                TTKLDTB_TongKlDao = MangThu.TTKLDTB_TongKlDao ?? 0,
                                TTKLDTB_KlChiemChoDat = MangThu.TTKLDTB_KlChiemChoDat ?? 0,
                                TTKLDTB_KlChiemChoDa = MangThu.TTKLDTB_KlChiemChoDa ?? 0,
                                TTKLDTB_TongChiemCho = MangThu.TTKLDTB_TongChiemCho ?? 0,
                                TTKLDTB_KlDapTraDat = MangThu.TTKLDTB_KlDapTraDat ?? 0,
                                TTKLDTB_KlDapTraDa = MangThu.TTKLDTB_KlDapTraDa ?? 0,
                                TTKLDTB_TongDapTra = MangThu.TTKLDTB_TongDapTra ?? 0,
                                TTKLDTB_KlThuaDat = MangThu.TTKLDTB_KlThuaDat ?? 0,
                                TTKLDTB_KlThuaDa = MangThu.TTKLDTB_KlThuaDa ?? 0,
                                TTKLDTB_TongThua = MangThu.TTKLDTB_TongThua ?? 0,
                                TTDTD_HinhThucTruyenDan = MangThu.TTDTD_HinhThucTruyenDan ?? "",
                                TTDTD_LoaiTruyenDan = MangThu.TTDTD_LoaiTruyenDan ?? "",
                                TTDTD_TenLoaiTruyenDanSauPhanLoai = MangThu.TTDTD_TenLoaiTruyenDanSauPhanLoai ?? "",
                                TTCD_TongChieuDai = MangThu.TTCD_TongChieuDai ?? 0,
                                TTCD_ChieuDai01CauKien = MangThu.TTCD_ChieuDai01CauKien ?? 0,
                                TTCD_SlCauKienTinhKl = MangThu.TTCD_SlCauKienTinhKl ?? 0,
                                TTMDTD_PhanLoaiMong = MangThu.TTMDTD_PhanLoaiMong ?? "",
                                TTMDTD_LoaiMong = MangThu.TTMDTD_LoaiMong ?? "",
                                TTMDTD_HinhThucMong = MangThu.TTMDTD_HinhThucMong ?? "",
                                TTDC_TenLoaiDeCong = MangThu.TTDC_TenLoaiDeCong ?? "",
                                TTDC_CauTaoDeCong = MangThu.TTDC_CauTaoDeCong ?? "",
                                TTDC_DC_D = MangThu.TTDC_DC_D ?? 0,
                                TTDC_DC_R = MangThu.TTDC_DC_R ?? 0,
                                TTDC_DC_C = MangThu.TTDC_DC_C ?? 0,
                                TTDC_KL_SlDeCong = MangThu.TTDC_KL_SlDeCong ?? 0,
                                TTDC_KL_Kl01DeCong = MangThu.TTDC_KL_Kl01DeCong ?? 0,
                                TTDC_KL_TongSoLuongDeCong = MangThu.TTDC_KL_TongSoLuongDeCong ?? 0,
                                TTDC_KL_TongKlDeCong = MangThu.TTDC_KL_TongKlDeCong ?? 0,
                                TTCTCT_CDayPhuBi = MangThu.TTCTCT_CDayPhuBi ?? 0,
                                TTCTCT_SoCanh = MangThu.TTCTCT_SoCanh ?? 0,
                                TTCTCT_LongSuDung = MangThu.TTCTCT_LongSuDung ?? 0,
                                TTCTCT_CCaoCauKien = MangThu.TTCTCT_CCaoCauKien ?? 0,
                                TTCTCT_CCaoLotMong = MangThu.TTCTCT_CCaoLotMong ?? 0,
                                TTCTCT_CRongLotMong = MangThu.TTCTCT_CRongLotMong ?? 0,
                                TTCTCT_CCaoMong = MangThu.TTCTCT_CCaoMong ?? 0,
                                TTCTCT_CRongMong = MangThu.TTCTCT_CRongMong ?? 0,
                                TTCTCT_CCaoDe = MangThu.TTCTCT_CCaoDe ?? 0,
                                TTCTCT_TongCCaoCong = MangThu.TTCTCT_TongCCaoCong ?? 0,
                                TTTKLCKCTH_ChieuDaiMoiNoi = MangThu.TTTKLCKCTH_ChieuDaiMoiNoi ?? 0,
                                TTTKLCKCTH_SoLuong = MangThu.TTTKLCKCTH_SoLuong ?? 0,
                                TTTKLCKCTH_SlCauKienNguyen = MangThu.TTTKLCKCTH_SlCauKienNguyen ?? 0,
                                TTTKLCKCTH_CDaiCan = MangThu.TTTKLCKCTH_CDaiCan ?? 0,
                                TTTKLCKCTH_TongCDai = MangThu.TTTKLCKCTH_TongCDai ?? 0,
                                TTTKLCKCTH_CDaiThucTe = MangThu.TTTKLCKCTH_CDaiThucTe ?? 0,
                                TTTKLCKCTH_OngCongCanThem = MangThu.TTTKLCKCTH_OngCongCanThem ?? 0,
                                TTTKLCKCTH_CDaiConThua = MangThu.TTTKLCKCTH_CDaiConThua ?? 0,
                                TTKTHHCHR_CauTaoTuong = MangThu.TTKTHHCHR_CauTaoTuong ?? "",
                                TTKTHHCHR_CauTaoMuMo = MangThu.TTKTHHCHR_CauTaoMuMo ?? "",
                                TTKTHHCHR_ChatMatTrong = MangThu.TTKTHHCHR_ChatMatTrong ?? "",
                                TTKTHHCHR_ChatMatNgoai = MangThu.TTKTHHCHR_ChatMatNgoai ?? "",
                                TTKTHHCHR_Lot_CCaoLotMong = MangThu.TTKTHHCHR_Lot_CCaoLotMong ?? 0,
                                TTKTHHCHR_Lot_CRongLotMong = MangThu.TTKTHHCHR_Lot_CRongLotMong ?? 0,
                                TTKTHHCHR_Mong_CCaoMong = MangThu.TTKTHHCHR_Mong_CCaoMong ?? 0,
                                TTKTHHCHR_Mong_CRongMong = MangThu.TTKTHHCHR_Mong_CRongMong ?? 0,
                                TTKTHHCHR_De_CCaoDe = MangThu.TTKTHHCHR_De_CCaoDe ?? 0,
                                TTKTHHCHR_De_CRongDe = MangThu.TTKTHHCHR_De_CRongDe ?? 0,
                                TTKTHHCHR_Than_CDayTuong01Ben = MangThu.TTKTHHCHR_Than_CDayTuong01Ben ?? 0,
                                TTKTHHCHR_Than_SoLuongTuong = MangThu.TTKTHHCHR_Than_SoLuongTuong ?? 0,
                                TTKTHHCHR_Than_CRongLongSuDung = MangThu.TTKTHHCHR_Than_CRongLongSuDung ?? 0,
                                TTKTHHCHR_Than_CCaoTuongCongHop = MangThu.TTKTHHCHR_Than_CCaoTuongCongHop ?? 0,
                                TTKTHHCHR_Than_CCaoTuongRanh = MangThu.TTKTHHCHR_Than_CCaoTuongRanh ?? 0,
                                TTKTHHCHR_Than_CCaoTuongGop = MangThu.TTKTHHCHR_Than_CCaoTuongGop ?? 0,
                                TTKTHHCHR_MMD_CCaoMuMoThotDuoi = MangThu.TTKTHHCHR_MMD_CCaoMuMoThotDuoi ?? 0,
                                TTKTHHCHR_MMD_CRongMuMoDuoi = MangThu.TTKTHHCHR_MMD_CRongMuMoDuoi ?? 0,
                                TTKTHHCHR_MMT_CCaoMuMoThotTren = MangThu.TTKTHHCHR_MMT_CCaoMuMoThotTren ?? 0,
                                TTKTHHCHR_MMT_CRongMuMoTren = MangThu.TTKTHHCHR_MMT_CRongMuMoTren ?? 0,
                                TTKTHHCHR_TC_LoaiThanhChong = MangThu.TTKTHHCHR_TC_LoaiThanhChong ?? "",
                                TTKTHHCHR_TC_CauTaoThanhChong = MangThu.TTKTHHCHR_TC_CauTaoThanhChong ?? "",
                                TTKTHHCHR_TC_CCaoThanhChong = MangThu.TTKTHHCHR_TC_CCaoThanhChong ?? 0,
                                TTKTHHCHR_TC_CRongThanhChong = MangThu.TTKTHHCHR_TC_CRongThanhChong ?? 0,
                                TTKTHHCHR_TC_CDai = MangThu.TTKTHHCHR_TC_CDai ?? 0,
                                TTKTHHCHR_TC_SoLuongThanhChong = MangThu.TTKTHHCHR_TC_SoLuongThanhChong ?? 0,
                                TTKTHHCHR_Chat_CCaoChatMatTrong = MangThu.TTKTHHCHR_Chat_CCaoChatMatTrong ?? 0,
                                TTKTHHCHR_Chat_CCaoChatMatNgoai = MangThu.TTKTHHCHR_Chat_CCaoChatMatNgoai ?? 0,
                                TTKTHHCHR_TongChieuCao = MangThu.TTKTHHCHR_TongChieuCao ?? 0,
                                TTTDCHR_1_TenLoaiTamDanTieuChuan = MangThu.TTTDCHR_1_TenLoaiTamDanTieuChuan ?? "",
                                TTTDCHR_1_CauTaoTamDanTruyenDan = MangThu.TTTDCHR_1_CauTaoTamDanTruyenDan ?? "",
                                TTTDCHR_1_SoLuong = MangThu.TTTDCHR_1_SoLuong ?? 0,
                                TTTDCHR_1_CDai = MangThu.TTTDCHR_1_CDai ?? 0,
                                TTTDCHR_1_CRong = MangThu.TTTDCHR_1_CRong ?? 0,
                                TTTDCHR_1_CCao = MangThu.TTTDCHR_1_CCao ?? 0,
                                TTTDCHR_2_TenLoaiTamDanLoai02 = MangThu.TTTDCHR_2_TenLoaiTamDanLoai02 ?? "",
                                TTTDCHR_2_CauTaoTamDanTruyenDan = MangThu.TTTDCHR_2_CauTaoTamDanTruyenDan ?? "",
                                TTTDCHR_2_SoLuong = MangThu.TTTDCHR_2_SoLuong ?? 0,
                                TTTDCHR_2_CDai = MangThu.TTTDCHR_2_CDai ?? 0,
                                TTTDCHR_2_CRong = MangThu.TTTDCHR_2_CRong ?? 0,
                                TTTDCHR_2_CCao = MangThu.TTTDCHR_2_CCao ?? 0,
                                TTTDCHR_BS_ChieuDaiMoiNoi = MangThu.TTTDCHR_BS_ChieuDaiMoiNoi ?? 0,
                                TTTDCHR_BS_SoLuongTD = MangThu.TTTDCHR_BS_SoLuongTD ?? 0,
                                TTTDCHR_BS_SlCauKienNguyen = MangThu.TTTDCHR_BS_SlCauKienNguyen ?? 0,
                                TTTDCHR_BS_ChieuDaiCan = MangThu.TTTDCHR_BS_ChieuDaiCan ?? 0,
                                TTTDCHR_BS_TongChieuDai = MangThu.TTTDCHR_BS_TongChieuDai ?? 0,
                                TTTDCHR_BS_ChieuDaiThucTe = MangThu.TTTDCHR_BS_ChieuDaiThucTe ?? 0,
                                TTTDCHR_BS_OngCongCanThem = MangThu.TTTDCHR_BS_OngCongCanThem ?? 0,
                                TTKTHHON_CDayPhuBi = MangThu.TTKTHHON_CDayPhuBi ?? 0,
                                TTKTHHON_SoCanh = MangThu.TTKTHHON_SoCanh ?? 0,
                                TTKTHHON_LongSuDung = MangThu.TTKTHHON_LongSuDung ?? 0,
                                TTKTHHON_TongCCaoOng = MangThu.TTKTHHON_TongCCaoOng ?? 0,
                                TTKTHHON_CCaoDemCat = MangThu.TTKTHHON_CCaoDemCat ?? 0,
                                TTKTHHON_CCaoDapCat = MangThu.TTKTHHON_CCaoDapCat ?? 0,
                                CDTL_HienTrangTruocKhiDaoThuongLuu = MangThu.CDTL_HienTrangTruocKhiDaoThuongLuu ?? 0,
                                CDTL_Day_DayDaoGop = MangThu.CDTL_Day_DayDaoGop ?? 0,
                                CDTL_Day_ChieuSauDao = MangThu.CDTL_Day_ChieuSauDao ?? 0,
                                CDTL_Day_DayDaoCongTron = MangThu.CDTL_Day_DayDaoCongTron ?? 0,
                                CDTL_Day_DayDaoCongHop = MangThu.CDTL_Day_DayDaoCongHop ?? 0,
                                CDTL_Day_DayDaoRanh = MangThu.CDTL_Day_DayDaoRanh ?? 0,
                                CDTL_Day_DayDaoOngNhua = MangThu.CDTL_Day_DayDaoOngNhua ?? 0,
                                CDTL_Lot_DinhLotGop = MangThu.CDTL_Lot_DinhLotGop ?? 0,
                                CDTL_Lot_DinhLotOngNhua = MangThu.CDTL_Lot_DinhLotOngNhua ?? 0,
                                CDTL_Lot_DinhLotCongTron = MangThu.CDTL_Lot_DinhLotCongTron ?? 0,
                                CDTL_Lot_DinhLotCongHop = MangThu.CDTL_Lot_DinhLotCongHop ?? 0,
                                CDTL_Lot_DinhLotRanh = MangThu.CDTL_Lot_DinhLotRanh ?? 0,
                                CDTL_Mong_DinhMongGop = MangThu.CDTL_Mong_DinhMongGop ?? 0,
                                CDTL_Mong_DinhMongCongTron = MangThu.CDTL_Mong_DinhMongCongTron ?? 0,
                                CDTL_Mong_DinhMongCongHop = MangThu.CDTL_Mong_DinhMongCongHop ?? 0,
                                CDTL_Mong_DinhMongRanh = MangThu.CDTL_Mong_DinhMongRanh ?? 0,
                                CDTL_Mong_DinhDeCong = MangThu.CDTL_Mong_DinhDeCong ?? 0,
                                CDTL_Mong_DayDongChay = MangThu.CDTL_Mong_DayDongChay ?? 0,
                                CDTL_Tuong_CCaoTuongCongRanh = MangThu.CDTL_Tuong_CCaoTuongCongRanh ?? 0,
                                CDTL_Tuong_DinhTuongCHopRanh = MangThu.CDTL_Tuong_DinhTuongCHopRanh ?? 0,
                                CDTL_Tuong_DinhMuMo = MangThu.CDTL_Tuong_DinhMuMo ?? 0,
                                CDTL_HT_DinhGop = MangThu.CDTL_HT_DinhGop ?? 0,
                                CDTL_HT_DinhTrongLongSuDung = MangThu.CDTL_HT_DinhTrongLongSuDung ?? 0,
                                CDTL_HT_DinhCongTron = MangThu.CDTL_HT_DinhCongTron ?? 0,
                                CDTL_HT_DinhCongHop = MangThu.CDTL_HT_DinhCongHop ?? 0,
                                CDTL_HT_DinhRanh = MangThu.CDTL_HT_DinhRanh ?? 0,
                                CDTL_HT_DinhOngNhua = MangThu.CDTL_HT_DinhOngNhua ?? 0,
                                CDTL_HT_DinhDapCat = MangThu.CDTL_HT_DinhDapCat ?? 0,
                                CDHL_HienTrangTruocKhiDaoHaLuu = MangThu.CDHL_HienTrangTruocKhiDaoHaLuu ?? 0,
                                CDHL_Day_DayDaoGop = MangThu.CDHL_Day_DayDaoGop ?? 0,
                                CDHL_Day_ChieuSauDao = MangThu.CDHL_Day_ChieuSauDao ?? 0,
                                CDHL_Day_DayDaoCongTron = MangThu.CDHL_Day_DayDaoCongTron ?? 0,
                                CDHL_Day_DayDaoCongHop = MangThu.CDHL_Day_DayDaoCongHop ?? 0,
                                CDHL_Day_DayDaoRanh = MangThu.CDHL_Day_DayDaoRanh ?? 0,
                                CDHL_Day_DayDaoOngNhua = MangThu.CDHL_Day_DayDaoOngNhua ?? 0,
                                CDHL_Lot_DinhLotGop = MangThu.CDHL_Lot_DinhLotGop ?? 0,
                                CDHL_Lot_DinhLotOngNhua = MangThu.CDHL_Lot_DinhLotOngNhua ?? 0,
                                CDHL_Lot_DinhLotCongTron = MangThu.CDHL_Lot_DinhLotCongTron ?? 0,
                                CDHL_Lot_DinhLotCongHop = MangThu.CDHL_Lot_DinhLotCongHop ?? 0,
                                CDHL_Lot_DinhLotRanh = MangThu.CDHL_Lot_DinhLotRanh ?? 0,
                                CDHL_Mong_DinhMongGop = MangThu.CDHL_Mong_DinhMongGop ?? 0,
                                CDHL_Mong_DinhMongCongTron = MangThu.CDHL_Mong_DinhMongCongTron ?? 0,
                                CDHL_Mong_DinhMongCongHop = MangThu.CDHL_Mong_DinhMongCongHop ?? 0,
                                CDHL_Mong_DinhMongRanh = MangThu.CDHL_Mong_DinhMongRanh ?? 0,
                                CDHL_Mong_DinhDeCong = MangThu.CDHL_Mong_DinhDeCong ?? 0,
                                CDHL_Mong_DayDongChay = MangThu.CDHL_Mong_DayDongChay ?? 0,
                                CDHL_Tuong_CCaoTuong = MangThu.CDHL_Tuong_CCaoTuong ?? 0,
                                CDHL_Tuong_DinhTuong = MangThu.CDHL_Tuong_DinhTuong ?? 0,
                                CDHL_Tuong_DinhMuMo = MangThu.CDHL_Tuong_DinhMuMo ?? 0,
                                CDHL_HT_DinhGop = MangThu.CDHL_HT_DinhGop ?? 0,
                                CDHL_HT_DinhTrongLongSuDung = MangThu.CDHL_HT_DinhTrongLongSuDung ?? 0,
                                CDHL_HT_DinhCongTron = MangThu.CDHL_HT_DinhCongTron ?? 0,
                                CDHL_HT_DinhCongHop = MangThu.CDHL_HT_DinhCongHop ?? 0,
                                CDHL_HT_DinhRanh = MangThu.CDHL_HT_DinhRanh ?? 0,
                                CDHL_HT_DinhOngNhua = MangThu.CDHL_HT_DinhOngNhua ?? 0,
                                CDHL_HT_DinhDapCat = MangThu.CDHL_HT_DinhDapCat ?? 0,
                                TTVLDCR_LoaiVatLieuDao = MangThu.TTVLDCR_LoaiVatLieuDao ?? "",
                                TTVLDCR_TL_ChieuCaoDaoDa = MangThu.TTVLDCR_TL_ChieuCaoDaoDa ?? 0,
                                TTVLDCR_TL_ChieuCaoDaoDat = MangThu.TTVLDCR_TL_ChieuCaoDaoDat ?? 0,
                                TTVLDCR_TL_TongChieuSauDao = MangThu.TTVLDCR_TL_TongChieuSauDao ?? 0,
                                TTVLDCR_HL_ChieuCaoDaoDa = MangThu.TTVLDCR_HL_ChieuCaoDaoDa ?? 0,
                                TTVLDCR_HL_ChieuCaoDaoDat = MangThu.TTVLDCR_HL_ChieuCaoDaoDat ?? 0,
                                TTVLDCR_HL_TongChieuSauDao = MangThu.TTVLDCR_HL_TongChieuSauDao ?? 0,
                                TTCCCCCT_LDat_CCaoLotTLuu = MangThu.TTCCCCCT_LDat_CCaoLotTLuu ?? 0,
                                TTCCCCCT_LDat_CCaoLotHLuu = MangThu.TTCCCCCT_LDat_CCaoLotHLuu ?? 0,
                                TTCCCCCT_LDat_CCaoLotMongTBinh = MangThu.TTCCCCCT_LDat_CCaoLotMongTBinh ?? 0,
                                TTCCCCCT_LDa_CCaoLotTLuu = MangThu.TTCCCCCT_LDa_CCaoLotTLuu ?? 0,
                                TTCCCCCT_LDa_CCaoLotHLuu = MangThu.TTCCCCCT_LDa_CCaoLotHLuu ?? 0,
                                TTCCCCCT_LDa_CCaoLotMongTBinh = MangThu.TTCCCCCT_LDa_CCaoLotMongTBinh ?? 0,
                                TTCCCCCT_MDat_CCaoMongTLuu = MangThu.TTCCCCCT_MDat_CCaoMongTLuu ?? 0,
                                TTCCCCCT_MDat_CCaoMongHLuu = MangThu.TTCCCCCT_MDat_CCaoMongHLuu ?? 0,
                                TTCCCCCT_MDat_CCaoMongTBinh = MangThu.TTCCCCCT_MDat_CCaoMongTBinh ?? 0,
                                TTCCCCCT_MDa_CCaoMongTLuu = MangThu.TTCCCCCT_MDa_CCaoMongTLuu ?? 0,
                                TTCCCCCT_MDa_CCaoMongHLuu = MangThu.TTCCCCCT_MDa_CCaoMongHLuu ?? 0,
                                TTCCCCCT_MDa_CCaoMongTBinh = MangThu.TTCCCCCT_MDa_CCaoMongTBinh ?? 0,
                                TTCCCCCT_DDat_CCaoDeTLuu = MangThu.TTCCCCCT_DDat_CCaoDeTLuu ?? 0,
                                TTCCCCCT_DDat_CCaoDeHLuu = MangThu.TTCCCCCT_DDat_CCaoDeHLuu ?? 0,
                                TTCCCCCT_DDat_CCaoDeTBinh = MangThu.TTCCCCCT_DDat_CCaoDeTBinh ?? 0,
                                TTCCCCCT_DDa_CCaoDeTLuu = MangThu.TTCCCCCT_DDa_CCaoDeTLuu ?? 0,
                                TTCCCCCT_DDa_CCaoDeHLuu = MangThu.TTCCCCCT_DDa_CCaoDeHLuu ?? 0,
                                TTCCCCCT_DDa_CCaoDeTBinh = MangThu.TTCCCCCT_DDa_CCaoDeTBinh ?? 0,
                                TTCCCCCT_CDat_CCaoCongTLuu = MangThu.TTCCCCCT_CDat_CCaoCongTLuu ?? 0,
                                TTCCCCCT_CDat_CCaoCongHLuu = MangThu.TTCCCCCT_CDat_CCaoCongHLuu ?? 0,
                                TTCCCCCT_CDat_CCongCongTBinh = MangThu.TTCCCCCT_CDat_CCongCongTBinh ?? 0,
                                TTCCCCCT_CDa_CCaoCongTLuu = MangThu.TTCCCCCT_CDa_CCaoCongTLuu ?? 0,
                                TTCCCCCT_CDa_CCaoCongHLuu = MangThu.TTCCCCCT_CDa_CCaoCongHLuu ?? 0,
                                TTCCCCCT_CDa_CCongCongTBinh = MangThu.TTCCCCCT_CDa_CCongCongTBinh ?? 0,
                                TTCCCCCHR_LDat_CCaoLotTLuu = MangThu.TTCCCCCHR_LDat_CCaoLotTLuu ?? 0,
                                TTCCCCCHR_LDat_CCaoLotHLuu = MangThu.TTCCCCCHR_LDat_CCaoLotHLuu ?? 0,
                                TTCCCCCHR_LDat_CCaoLotTBinh = MangThu.TTCCCCCHR_LDat_CCaoLotTBinh ?? 0,
                                TTCCCCCHR_LDa_CCaoLotTLuu = MangThu.TTCCCCCHR_LDa_CCaoLotTLuu ?? 0,
                                TTCCCCCHR_LDa_CCaoLotHLuu = MangThu.TTCCCCCHR_LDa_CCaoLotHLuu ?? 0,
                                TTCCCCCHR_LDa_CCaoLotTBinh = MangThu.TTCCCCCHR_LDa_CCaoLotTBinh ?? 0,
                                TTCCCCCHR_MDat_CCaoMongTLuu = MangThu.TTCCCCCHR_MDat_CCaoMongTLuu ?? 0,
                                TTCCCCCHR_MDat_CCaoMongHLuu = MangThu.TTCCCCCHR_MDat_CCaoMongHLuu ?? 0,
                                TTCCCCCHR_MDat_CCaoMongTBinh = MangThu.TTCCCCCHR_MDat_CCaoMongTBinh ?? 0,
                                TTCCCCCHR_MDa_CCaoMongTLuu = MangThu.TTCCCCCHR_MDa_CCaoMongTLuu ?? 0,
                                TTCCCCCHR_MDa_CCaoMongHLuu = MangThu.TTCCCCCHR_MDa_CCaoMongHLuu ?? 0,
                                TTCCCCCHR_MDa_CCaoMongTBinh = MangThu.TTCCCCCHR_MDa_CCaoMongTBinh ?? 0,
                                TTCCCCCHR_TDat_CCaoTuongTLuu = MangThu.TTCCCCCHR_TDat_CCaoTuongTLuu ?? 0,
                                TTCCCCCHR_TDat_CCaoTuongHLuu = MangThu.TTCCCCCHR_TDat_CCaoTuongHLuu ?? 0,
                                TTCCCCCHR_TDat_CCaoTuongTBinh = MangThu.TTCCCCCHR_TDat_CCaoTuongTBinh ?? 0,
                                TTCCCCCHR_TDa_CCaoTuongTLuu = MangThu.TTCCCCCHR_TDa_CCaoTuongTLuu ?? 0,
                                TTCCCCCHR_TDa_CCaoTuongHLuu = MangThu.TTCCCCCHR_TDa_CCaoTuongHLuu ?? 0,
                                TTCCCCCHR_TDa_CCaoTuongTBinh = MangThu.TTCCCCCHR_TDa_CCaoTuongTBinh ?? 0,
                                TTCCCCON_DDat_CCaoDemCatTLuu = MangThu.TTCCCCON_DDat_CCaoDemCatTLuu ?? 0,
                                TTCCCCON_DDat_CCaoDemCatHLuu = MangThu.TTCCCCON_DDat_CCaoDemCatHLuu ?? 0,
                                TTCCCCON_DDat_CCaoDemCatTBinh = MangThu.TTCCCCON_DDat_CCaoDemCatTBinh ?? 0,
                                TTCCCCON_DDa_CCaoDemCatTLuu = MangThu.TTCCCCON_DDa_CCaoDemCatTLuu ?? 0,
                                TTCCCCON_DDa_CCaoDemCatHLuu = MangThu.TTCCCCON_DDa_CCaoDemCatHLuu ?? 0,
                                TTCCCCON_DDa_CCaoDemCatTBinh = MangThu.TTCCCCON_DDa_CCaoDemCatTBinh ?? 0,
                                TTCCCCON_ODat_CCaoOngTLuu = MangThu.TTCCCCON_ODat_CCaoOngTLuu ?? 0,
                                TTCCCCON_ODat_CCaoOngHLuu = MangThu.TTCCCCON_ODat_CCaoOngHLuu ?? 0,
                                TTCCCCON_ODat_CCaoTBinh = MangThu.TTCCCCON_ODat_CCaoTBinh ?? 0,
                                TTCCCCON_ODa_CCaoOngTLuu = MangThu.TTCCCCON_ODa_CCaoOngTLuu ?? 0,
                                TTCCCCON_ODa_CCaoOngHLuu = MangThu.TTCCCCON_ODa_CCaoOngHLuu ?? 0,
                                TTCCCCON_ODa_CCaoTBinh = MangThu.TTCCCCON_ODa_CCaoTBinh ?? 0,
                                TTCCCCON_DDat_CCaoDapCatTLuu = MangThu.TTCCCCON_DDat_CCaoDapCatTLuu ?? 0,
                                TTCCCCON_DDat_CCaoDapCatHLuu = MangThu.TTCCCCON_DDat_CCaoDapCatHLuu ?? 0,
                                TTCCCCON_DDat_CCaoDapCatTBinh = MangThu.TTCCCCON_DDat_CCaoDapCatTBinh ?? 0,
                                TTCCCCON_DDa_CCaoDapCatTLuu = MangThu.TTCCCCON_DDa_CCaoDapCatTLuu ?? 0,
                                TTCCCCON_DDa_CCaoDapCatHLuu = MangThu.TTCCCCON_DDa_CCaoDapCatHLuu ?? 0,
                                TTCCCCON_DDa_CCaoDapCatTBinh = MangThu.TTCCCCON_DDa_CCaoDapCatTBinh ?? 0,
                                TTMD_CRON_ChieuRongDayDaoNho = MangThu.TTMD_CRON_ChieuRongDayDaoNho ?? 0,
                                TTMD_CRON_TyLeMoMai = MangThu.TTMD_CRON_TyLeMoMai ?? 0,
                                TTMD_CRON_SoCanhMaiTrai = MangThu.TTMD_CRON_SoCanhMaiTrai ?? 0,
                                TTMD_CRON_SoCanhMaiPhai = MangThu.TTMD_CRON_SoCanhMaiPhai ?? 0,
                                DTDTLCRON_Dat_CRongDaoDayLon = MangThu.DTDTLCRON_Dat_CRongDaoDayLon ?? 0,
                                DTDTLCRON_Dat_DTichDao = MangThu.DTDTLCRON_Dat_DTichDao ?? 0,
                                DTDTLCRON_Da_CRongDaoDayLon = MangThu.DTDTLCRON_Da_CRongDaoDayLon ?? 0,
                                DTDTLCRON_Da_DTichDao = MangThu.DTDTLCRON_Da_DTichDao ?? 0,
                                DTDHLCRON_Dat_CRongDaoDayLon = MangThu.DTDHLCRON_Dat_CRongDaoDayLon ?? 0,
                                DTDHLCRON_Dat_DTichDao = MangThu.DTDHLCRON_Dat_DTichDao ?? 0,
                                DTDHLCRON_Da_CRongDaoDayLon = MangThu.DTDHLCRON_Da_CRongDaoDayLon ?? 0,
                                DTDHLCRON_Da_DTichDao = MangThu.DTDHLCRON_Da_DTichDao ?? 0,
                                DTDTB_CRongDaoDayLon = MangThu.DTDTB_CRongDaoDayLon ?? 0,
                                DTDTB_DTichDao = MangThu.DTDTB_DTichDao ?? 0,
                                DTDTB_CRongDaoDayLon1 = MangThu.DTDTB_CRongDaoDayLon1 ?? 0,
                                DTDTB_DTichDao1 = MangThu.DTDTB_DTichDao1 ?? 0,
                                KLDCRON_KlDaoDat = MangThu.KLDCRON_KlDaoDat ?? 0,
                                KLDCRON_KlDaoDa = MangThu.KLDCRON_KlDaoDa ?? 0,
                                KLDCRON_TongKL = MangThu.KLDCRON_TongKL ?? 0,
                                TTKLCC_Tron_Dat = MangThu.TTKLCC_Tron_Dat ?? 0,
                                TTKLCC_Tron_Da = MangThu.TTKLCC_Tron_Da ?? 0,
                                TTKLCC_Tron_TongKL = MangThu.TTKLCC_Tron_TongKL ?? 0,
                                TTKLCC_Hop_Dat = MangThu.TTKLCC_Hop_Dat ?? 0,
                                TTKLCC_Hop_Da = MangThu.TTKLCC_Hop_Da ?? 0,
                                TTKLCC_Hop_TongKL = MangThu.TTKLCC_Hop_TongKL ?? 0,
                                TTKLCC_Ranh_Dat = MangThu.TTKLCC_Ranh_Dat ?? 0,
                                TTKLCC_Ranh_Da = MangThu.TTKLCC_Ranh_Da ?? 0,
                                TTKLCC_Ranh_TongKL = MangThu.TTKLCC_Ranh_TongKL ?? 0,
                                TTKLCC_Ong_Dat = MangThu.TTKLCC_Ong_Dat ?? 0,
                                TTKLCC_Ong_Da = MangThu.TTKLCC_Ong_Da ?? 0,
                                TTKLCC_Ong_OngNhua = MangThu.TTKLCC_Ong_OngNhua ?? 0,
                                TTKLCC_KlCChoDat = MangThu.TTKLCC_KlCChoDat ?? 0,
                                TTKLCC_KlCChoDa = MangThu.TTKLCC_KlCChoDa ?? 0,
                                TTKLCC_TongChiemCho = MangThu.TTKLCC_TongChiemCho ?? 0,
                                KLDT_KlDapTraDat = MangThu.KLDT_KlDapTraDat ?? 0,
                                KLDT_KlDapTraDa = MangThu.KLDT_KlDapTraDa ?? 0,
                                KLDT_TongKlDapTra = MangThu.KLDT_TongKlDapTra ?? 0,
                                KLT_KlThuaDat = MangThu.KLT_KlThuaDat ?? 0,
                                KLT_KlThuaDa = MangThu.KLT_KlThuaDa ?? 0,
                                KLT_TongKlThua = MangThu.KLT_TongKlThua ?? 0,
                                DTDC_TL_CSauDap = MangThu.DTDC_TL_CSauDap ?? 0,
                                DTDC_TL_CRongDapDayLon = MangThu.DTDC_TL_CRongDapDayLon ?? 0,
                                DTDC_TL_DTichDap = MangThu.DTDC_TL_DTichDap ?? 0,
                                DTDC_HL_CSauDap = MangThu.DTDC_HL_CSauDap ?? 0,
                                DTDC_HL_CRongDapDayLon = MangThu.DTDC_HL_CRongDapDayLon ?? 0,
                                DTDC_HL_DTichDap = MangThu.DTDC_HL_DTichDap ?? 0,
                                DTDCTB_CSauDap = MangThu.DTDCTB_CSauDap ?? 0,
                                DTDCTB_CRongDapDayLon = MangThu.DTDCTB_CRongDapDayLon ?? 0,
                                DTDCTB_DTichDap = MangThu.DTDCTB_DTichDap ?? 0,
                                TTKLDC_KlDapCatTruocChiemCho = MangThu.TTKLDC_KlDapCatTruocChiemCho ?? 0,
                                TTKLDC_KlChiemCho = MangThu.TTKLDC_KlChiemCho ?? 0,
                                TTKLDC_KlDapCatSauChiemCho = MangThu.TTKLDC_KlDapCatSauChiemCho ?? 0,
                                ToaDo_X = MangThu.ToaDo_X ?? 0,
                                ToaDo_Y = MangThu.ToaDo_Y ?? 0,
                                Flag = MangThu.Flag,
                                CreateAt = MangThu.CreateAt,
                                CreateBy = MangThu.CreateBy,
                                IsActive = MangThu.IsActive
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

        public async Task Update(MangThu MangThu)
        {
            using var context = _context.CreateDbContext();
            var entity = GetById(MangThu.Id);

            if (entity == null)
            {
                throw new Exception($"Không tìm thấy bản ghi theo ID: {MangThu.Id}");
            }

            context.MangThus.Update(MangThu);
            await context.SaveChangesAsync();
        }
        public async Task UpdateMulti(MangThu[] MangThu)
        {
            using var context = _context.CreateDbContext();
            string[] ids = MangThu.Select(x => x.Id).ToArray();
            var listEntities = await context.MangThus.Where(x => ids.Contains(x.Id)).ToListAsync();
            foreach (var entity in listEntities)
            {
                context.MangThus.Update(entity);
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
            context.Set<MangThu>().Remove(entity);
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

        public async Task<bool> CheckExistId(string field, string value)
        {
            // Thực hiện truy vấn kiểm tra bản ghi dựa trên tên field và giá trị value
            using var context = _context.CreateDbContext();
            var model = await context.MangThus.FirstOrDefaultAsync(m => EF.Property<string>(m, field) == value);

            // Nếu tìm thấy bản ghi, trả về true
            if (model != null)
            {
                return true;
            }

            // Trả về false nếu không tìm thấy bản ghi
            return false;
        }


        public async Task<MangThu> GetById(string id)
        {
            try
            {
                using var context = _context.CreateDbContext();
                // Tìm kiếm bản ghi theo ID
                var entity = await context.MangThus
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

        public async Task Insert(MangThu entity)
        {
            try
            {
                using var context = _context.CreateDbContext();
                if (entity == null)
                {
                    throw new Exception("Không có bản ghi nào để thêm!");
                }
                // Kiểm tra xem bảng có bản ghi nào không
                var maxFlag = await context.MangThus.AnyAsync()
                              ? await context.MangThus.MaxAsync(x => x.Flag)
                              : 0;

                // Tăng giá trị Flag lên 1
                entity.Flag = maxFlag + 1;
                context.MangThus.Add(entity);
                await context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException?.Message ?? ex.Message);
                Console.WriteLine(ex.Message);
            }
        }

        public async Task<string> InsertLaterFlag(MangThu entity, int FlagLast)
        {
            string id = "";
            try
            {
                using var context = _context.CreateDbContext();

                if (entity == null)
                {
                    throw new Exception("Không có bản ghi nào để thêm!");
                }
                var recordsToUpdate = await context.MangThus
                    .Where(x => x.Flag > FlagLast)
                    .ToListAsync();

                foreach (var record in recordsToUpdate)
                {
                    record.Flag += 1;
                }
                await context.SaveChangesAsync();

                if (recordsToUpdate.Count() == 0)
                {
                    // Kiểm tra xem bảng có bản ghi nào không
                    var maxFlag = await context.MangThus.AnyAsync()
                                  ? await context.MangThus.MaxAsync(x => x.Flag)
                                  : 0;

                    // Tăng giá trị Flag lên 1
                    entity.Flag = maxFlag + 1;
                }
                else
                {
                    entity.Flag = FlagLast + 1;
                }
                context.MangThus.Add(entity);
                await context.SaveChangesAsync();

                id = entity.Id ?? "";
                return id;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return id;
            }
        }
        public async Task<int> MultiInsert(List<MangThu> entities)
        {
            try
            {
                using var context = _context.CreateDbContext();

                if (entities == null || entities.Count == 0)
                {
                    throw new Exception("Không có bản ghi nào để thêm!");
                }

                // Kiểm tra xem bảng có bản ghi nào không
                var maxFlag = await context.MangThus.AnyAsync()
                              ? await context.MangThus.MaxAsync(x => x.Flag)
                              : 0;

                foreach (var entity in entities)
                {
                    // Tăng giá trị Flag lên 1
                    maxFlag += 1;
                    entity.Flag = maxFlag;
                    context.MangThus.Add(entity);
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
