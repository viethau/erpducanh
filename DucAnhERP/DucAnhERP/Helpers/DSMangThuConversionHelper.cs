
using DucAnhERP.Components.Pages.NghiepVuCongTrinh;
using DucAnhERP.Models;
using DucAnhERP.ViewModel;
using System;

namespace DucAnhERP.Helpers
{
    public class DSMangThuConversionHelper
    {
        public List<DanhMuc1> listDanhMuc = new();
        public string GetTenDanhMucById(string id = "")
        {

            var danhMuc = listDanhMuc.FirstOrDefault(dm => dm.Id == id);
            return danhMuc != null ? danhMuc.Ten : "";
        }
        public async Task<MangThu> ConvertNuocMua(MangThu item, List<DanhMuc1> listDM)
        {

            listDanhMuc = listDM;

            //item.TTVLDHT_ChieuCaoDaoDat = TTVLDHT_ChieuCaoDaoDat(string DA16, double DR16, double DB16);
            //item.TTVLDHT_TongChieuCaoDao = TTVLDHT_TongChieuCaoDao(double DB16, double DC16);

            //item.TTCD_HE_DinhMong = TTCD_HE_DinhMong(double DJ16, double S16);
            //item.TTCD_HE_DinhLot = TTCD_HE_DinhLot(double DI16, double P16);
            //item.TTCD_HE_DayDao = TTCD_HE_CSauDao(double DH16, double M16);
            //item.TTCD_HE_CSauDao = TTCD_HE_CSauDao(double DE16, double DF16);
            //item.TTCD_HE_TongChieuCaoBoVia = TTCD_HE_TongChieuCaoBoVia(double DJ16, double DF16);
            //item.TTCD_HE_ChenhCaoDinh = TTCD_HE_ChenhCaoDinh(double DJ16, double DE16);
            //item.TTCD_HE_TongChieuCao = TTCD_HE_TongChieuCao(double DK16, double DL16);
            //item.TTCD_DN_CdHienTrang = TTCD_DN_CdHienTrang(double DN16, double CZ16);
            //item.TTCD_HT_CdDinhMong = TTCD_HT_CdDinhMong(double DU16, double AK16, string T16, string W16);
            //item.TTCD_HT_DinhLotMong = TTCD_HT_DinhLotMong(double DT16, double AH16, string W16);
            //item.TTCD_HT_DayDao = TTCD_HT_DayDao(double DS16, double AE16, double DU16, double AK16, string T16, string W16);
            //item.TTCD_HT_CSauDao = TTCD_HT_CSauDao(double DP16, double DQ16);
            //item.TTCD_HT_DinhMuMoThotDuoi = TTCD_HT_DinhMuMoThotDuoi(double EA16, double BG16);
            //item.TTCD_HT_DinhTuong = TTCD_HT_DinhTuong(double DZ16, double BC16);
            //item.TTCD_HT_CCaoTuong = TTCD_HT_CCaoTuong(double DY16, double DU16);
            //item.TTCD_HT_DinhTuongDuoi = TTCD_HT_DinhTuongDuoi(double DU16, double AT16);
            //item.TTCD_HT_DinhDamGiuaTuong = TTCD_HT_DinhDamGiuaTuong(double DW16, double AR16);
            //item.TTCD_HT_TongChieuCaoHoThu = TTCD_HT_TongChieuCaoHoThu(double EA16, double DQ16);
            //item.TTCD_HT_ChenhCaoDinh = TTCD_HT_ChenhCaoDinh(double EA16, double DP16);
            //item.TTCD_HT_TongChieuCao = TTCD_HT_TongChieuCao(double EB16, double EC16);
            //item.TTCCDT_BV_CCaoLotBoViaCChoDat = TTCCDT_BV_CCaoLotBoViaCChoDat(double DC16, double M16, string DA16);
            //item.TTCCDT_BV_CCaoMongBoViaCChoDat = TTCCDT_BV_CCaoMongBoViaCChoDat(double DC16, double M16, double P16, string DA16);
            //item.TTCCDT_BV_CCaoBoViaCChoDat = TTCCDT_BV_CCaoBoViaCChoDat(string DA16, double DC16, double M16, double P16, double S16);
            //item.TTCCDT_BV_CCaoLotBoViaCChoDa = TTCCDT_BV_CCaoLotBoViaCChoDa(string DA16, double DB16, double DD16, double EE16, double M16);
            //item.TTCCDT_BV_CCaoMongBoViaCChoDa = TTCCDT_BV_CCaoMongBoViaCChoDa(string DA16, double DB16, double DD16, double EF16, double EH16, double M16, double P16);
            //item.TTCCDT_BV_CCaoBoViaCChoDa = TTCCDT_BV_CCaoBoViaCChoDa(string DA16, double DB16, double DD16, double EG16, double EH16, double EI16, double M16, double P16, double S16);
            //item.TTCCDT_BV_TongCCaoCChoDat = TTCCDT_BV_TongCCaoCChoDat(string H16, double EE16, double EF16, double EG16);
            //item.TTCCDT_BV_TongCCaoCChoDa = TTCCDT_BV_TongCCaoCChoDa(string H16, double EH16, double EI16, double EJ16);
            //item.TTCCDT_BV_ChenhDatSoVoiThietKe = TTCCDT_BV_ChenhDatSoVoiThietKe(string H16, double DC16, double EK16);
            //item.TTCCDT_HT_ChieuCaoLotCChoDat = TTCCDT_HT_ChieuCaoLotCChoDat(string DA16, double DC16, double AE16);
            //item.TTCCDT_HT_ChieuCaoMongCChoDat = TTCCDT_HT_ChieuCaoMongCChoDat(string DA16, double DC16, double AE16, double AH16);
            //item.TTCCDT_HT_ChieuCaoTuongCChoDat = TTCCDT_HT_ChieuCaoTuongCChoDat(string DA16, double DC16, double AE16, double AH16, double AN16, double AR16, double BC16, double BG16);
            //item.TTCCDT_HT_ChieuCaoLotCChoDa = TTCCDT_HT_ChieuCaoLotCChoDa(string DA16, double DB16, double AE16, double DD16, double EO16);
            //item.TTCCDT_HT_ChieuCaoMongCChoDa = TTCCDT_HT_ChieuCaoMongCChoDa(string DA16, double DB16, double AE16, double DD16, double EO16);
            //item.TTCCDT_HT_ChieuCaoTuongCChoDa = TTCCDT_HT_ChieuCaoTuongCChoDa(string DA16, double DB16, double AE16, double AH16, double AN16, double AR16, double BC16, double BG16, double DD16, double EQ16, double ER16, double ES16);
            //item.TTCCDT_HT_TongCCaoDatCCho = CalculTTCCDT_HT_TongCCaoDatCChoateHốThu(string H16, double EO16, double EP16, double EQ16);
            //item.TTCCDT_HT_TongCCaoDaCCho = TTCCDT_HT_TongCCaoDaCCho(string H16, double ER16, double ES16, double ET16);
            //item.TTCCDT_HT_ChenhDatSoVoiThietKe = TTCCDT_HT_ChenhDatSoVoiThietKe(string H16, double DB16, double EV16);
            //item.TTCCDT_HT_ChenhDaSoVoiThietKe = TTCCDT_HT_ChenhDaSoVoiThietKe(string H16, double DC16, double EU16);
            //item.TTDTD_BV_CRongDaoDayLonDat = TTDTD_BV_CRongDaoDayLonDat(string H16, double DC16, double EZ16, double FA16, double FB16, double EY16);
            //item.TTDTD_BV_CRongDaoDayLonDa = TTDTD_BV_CRongDaoDayLonDa(string H16, double DB16, double EZ16, double FA16, double FB16, double EY16, double FC16);
            //item.TTDTD_BV_DienTichDaoDat = TTDTD_BV_DienTichDaoDat(double H16, double FC16, double EY16, double DC16);
            //item.TTDTD_BV_DienTichDaoDa = TTDTD_BV_DienTichDaoDa(string H16, double FC16, double FD16, double EY16, double DB16);
            //item.TTDTD_BV_TongDtDao = TTDTD_BV_TongDtDao(double FE16, double FF16, string H16);
            //item.TTDTD_HT_CRongDaoDayLonDat = TTDTD_HT_CRongDaoDayLonDat(double DC16, double EZ16, double FA16, double FB16, double EY16, string DA16);
            //item.TTDTD_HT_CRongDaoDayLonDa = TTDTD_HT_CRongDaoDayLonDa(double DB16, double EZ16, double FA16, double FB16, double FH16, double EY16, string DA16);
            //item.TTDTD_HT_DienTichDaoDat = TTDTD_HT_DienTichDaoDat(double FH16, double EY16, double DC16);
            //item.TTDTD_HT_DienTichDaoDa = TTDTD_HT_DienTichDaoDa(double FI16, double FH16, double EY16, double DB16);
            //item.TTDTD_HT_TongDtDao = TTDTD_HT_TongDtDao(double FJ16, double FK16);
            //item.DTDTB_CRongDaoDayLonDat = DTDTB_CRongDaoDayLonDat(double FC16, double FH16);
            //item.DTDTB_CRongDaoDayLonDa = DTDTB_CRongDaoDayLonDa(double FD16, double FI16);
            //item.DTDTB_DienTichDaoDat = DTDTB_DienTichDaoDat(double FE16, double FJ16);
            //item.DTDTB_DienTichDaoDa = DTDTB_DienTichDaoDa(double FF16, double FK16);
            //item.DTDTB_TongDtDao = DTDTB_TongDtDao(double FG16, double FL16);
            //item.TTKLD_BV_KlDaoDat = TTKLD_BV_KlDaoDat(double K16, double FE16, double Q16);
            //item.TTKLD_BV_KlDaoDa = TTKLD_BV_KlDaoDa(double K16, double FF16, double Q16);
            //item.TTKLD_BV_TongKlDao = TTKLD_BV_TongKlDao(double FR16, double FS16);
            //item.TTKLD_BV_KlChiemChoDat = TTKLD_BV_KlChiemChoDat(double EE16, double K16, double L16, double N16, double O16, double EF16, double EG16, double Q16, double R16);
            //item.TTKLD_BV_KlChiemChoDa = TTKLD_BV_KlChiemChoDa(double EH16, double K16, double L16, double N16, double O16, double EI16, double EJ16, double Q16, double R16);
            //item.TTKLD_BV_TongChiemCho = TTKLD_BV_TongChiemCho(double FU16, double FV16);
            //item.TTKLD_BV_KlDapTraDat = TTKLD_BV_KlDapTraDat(double FR16, double FU16);
            //item.TTKLD_BV_KlDapTraDa = TTKLD_BV_KlDapTraDa(double FS16, double FV16);
            //item.TTKLD_BV_TongDapTra = TTKLD_BV_TongDapTra(double FT16, double FW16);
            //item.TTKLD_BV_KlThuaDat = TTKLD_BV_KlThuaDat(double FU16);
            //item.TTKLD_BV_KlThuaDa = TTKLD_BV_KlThuaDa(double FV16);
            //item.TTKLD_BV_TongThua = TTKLD_BV_TongThua(double FW16);
            //item.TTKLD_HT_KlDaoDat = TTKLD_HT_KlDaoDat(string E16, double AC16, double FJ16, double AA16);
            //item.TTKLD_HT_KlDaoDa = TTKLD_HT_KlDaoDa(string E16, double AC16, double FK16, double AA16);
            //item.TTKLD_HT_TongKlDao = TTKLD_HT_TongKlDao(double GD16, double GE16);
            //item.TTKLD_HT_KlChiemChoDat = TTKLD_HT_KlChiemChoDat(string E16, double AC16, double EO16, double AD16, double AF16, double AG16, double EP16, double EQ16, double AA16, double AB16);
            //item.TTKLD_HT_KlChiemChoDa = TTKLD_HT_KlChiemChoDa(string E16, double AC16, double ER16, double AD16, double AF16, double AG16, double ES16, double ET16, double AA16, double AB16);
            //item.TTKLD_HT_TongChiemCho = TTKLD_HT_TongChiemCho(double GG16, double GH16);
            //item.TTKLD_HT_KlDapTraDat = TTKLD_HT_KlDapTraDat(double GD16, double GG16);
            //item.TTKLD_HT_KlDapTraDa = TTKLD_HT_KlDapTraDa(double GE16, double GH16);
            //item.TTKLD_HT_TongDapTra = TTKLD_HT_TongDapTra(double GJ16, double GK16);
            //item.TTKLD_HT_KlThuaDat = item.TTKLD_HT_KlChiemChoDat;
            //item.TTKLD_HT_KlThuaDa = item.TTKLD_HT_KlChiemChoDa;
            //item.TTKLD_HT_TongThua = item.TTKLD_HT_KlThuaDat + item.TTKLD_HT_KlThuaDa;

            //item.TTKLDTB_KlDaoDat = TTKLDTB_KlDaoDat(double FR16, double GD16);
            //item.TTKLDTB_KlDaoDa = TTKLDTB_KlDaoDa(double FS16, double GE16);
            //item.TTKLDTB_TongKlDao = TTKLDTB_TongKlDao(double FT16, double GF16);
            //item.TTKLDTB_KlChiemChoDat = TTKLDTB_KlChiemChoDat(double FU16, double GG16);
            //item.TTKLDTB_KlChiemChoDa = TTKLDTB_KlChiemChoDa(double FV16, double GH16);
            //item.TTKLDTB_TongChiemCho = TTKLDTB_TongChiemCho(double FW16, double GI16);
            //item.TTKLDTB_KlDapTraDat = TTKLDTB_KlDapTraDat(double FX16, double GJ16);
            //item.TTKLDTB_KlDapTraDa = TTKLDTB_KlDapTraDa(double FY16, double GK16);
            //item.TTKLDTB_TongDapTra = TTKLDTB_TongDapTra(double FZ16, double GL16);
            //item.TTKLDTB_KlThuaDat = TTKLDTB_KlThuaDat(double GA16, double GM16);
            //item.TTKLDTB_KlThuaDa = TTKLDTB_KlThuaDa(double GB16, double GN16);
            //item.TTKLDTB_TongThua = TTKLDTB_TongThua(double GC16, double GO16);
            //item.TTCD_SlCauKienTinhKl = TTCD_SlCauKienTinhKl(double IF16, double IE16, string HB16, string IJ16)
            //item.TTDC_KL_TongSoLuongDeCong = TTDC_KL_TongSoLuongDeCong(double HP16, double HG16);
            //item.TTDC_KL_TongKlDeCong = TTDC_KL_TongKlDeCong(double HQ16, double HR16);
            //item.TTCTCT_CCaoCauKien = TTCTCT_CCaoCauKien(double HT16, double HU16, double HV16);
            //item.TTCTCT_TongCCaoCong = TTCTCT_TongCCaoCong(double HW16, double HX16, double HZ16, double IB16);
            //item.TTTKLCKCTH_SlCauKienNguyen = TTTKLCKCTH_SlCauKienNguyen(string HB16, double HE16, double HF16, double ID16);
            //item.TTTKLCKCTH_CDaiCan = TTTKLCKCTH_CDaiCan(string HB16, double IF16, double IE16, double ID16);
            //item.TTTKLCKCTH_TongCDai = TTTKLCKCTH_TongCDai(string HB16, double IF16, double HF16, double IG16);
            //item.TTTKLCKCTH_CDaiThucTe = TTTKLCKCTH_CDaiThucTe(string HB16, double IH16, double HE16);
            //item.TTTKLCKCTH_OngCongCanThem = TTTKLCKCTH_OngCongCanThem(double II16);
            //item.TTTKLCKCTH_CDaiConThua = TTTKLCKCTH_CDaiConThua(double HG16, double IE16, double ID16, double HF16, double HE16, string HB16);
            //item.TTKTHHCHR_Than_CCaoTuongRanh = TTKTHHCHR_Than_CCaoTuongRanh(string HB16, double LF16, double MH16);
            //item.TTKTHHCHR_Than_CCaoTuongGop = TTKTHHCHR_Than_CCaoTuongGop(double IY16, double IZ16);
            //item.TTKTHHCHR_Chat_CCaoChatMatTrong = TTKTHHCHR_Chat_CCaoChatMatTrong(string IN16, string IL16, string IM16, double JA16, double JB16, double JD16);
            //item.TTKTHHCHR_Chat_CCaoChatMatNgoai = TTKTHHCHR_Chat_CCaoChatMatNgoai(string IO16, string IL16, string IM16, double JA16, double JB16, double JD16, double JE16);
            //item.TTKTHHCHR_TongChieuCao = TTKTHHCHR_TongChieuCao(double IP16, double IR16, double IT16, double JA16, double JB16, double JD16);
            //item.TTTDCHR_1_SoLuong = TTTDCHR_1_SoLuong(string HB16, double KC16);


            //item.TTTDCHR_BS_SlCauKienNguyen = TTTDCHR_BS_SlCauKienNguyen(string HB16, double HE16, double JR16, double KA16);
            //item.TTTDCHR_BS_ChieuDaiCan = TTTDCHR_BS_ChieuDaiCan(string HB16, double JR16, double KC16, double KA16);
            //item.TTTDCHR_BS_TongChieuDai = TTTDCHR_BS_TongChieuDai(string HB16, double JR16, double KC16, double KD16);
            //item.TTTDCHR_BS_ChieuDaiThucTe = TTTDCHR_BS_ChieuDaiThucTe(string HB16, double JR16, double KE16, double HE16);
            //item.TTTDCHR_BS_OngCongCanThem = TTTDCHR_BS_OngCongCanThem(string HB16, double KF16);
            //item.TTKTHHON_TongCCaoOng = TTKTHHON_TongCCaoOng(double KH16, double KI16, double KJ16);
            //item.CDTL_Mong_DinhDeCong = CDTL_Mong_DinhDeCong(string HI16, double LE16, double HT16);
            //item.CDTL_Mong_DinhMongRanh = CDTL_Mong_DinhMongRanh(string HB16, string HI16, double LE16);
            //item.CDTL_Mong_DinhMongCongHop = CDTL_Mong_DinhMongCongHop(string HB16, string HI16, double LE16, double IT16);
            //item.CDTL_Mong_DinhMongCongTron = CDTL_Mong_DinhMongCongTron(string HB16, string HI16, double LE16, double HT16, double LD16, double IB16);
            //item.CDTL_Mong_DinhMongGop = CDTL_Mong_DinhMongGop(string HB16, string HI16, double LE16, double HT16, double LD16, double IB16, double IT16);
            //item.CDTL_Lot_DinhLotRanh = CDTL_Lot_DinhLotRanh(string HB16, string HI16, double LC16, double IR16);
            //item.CDTL_Lot_DinhLotCongHop = CDTL_Lot_DinhLotCongHop(string HB16, string HI16, double LB16, double IR16);
            //item.CDTL_Lot_DinhLotCongTron = CDTL_Lot_DinhLotCongTron(string HB16, string HI16, double LA16, double HZ16);
            //item.CDTL_Lot_DinhLotOngNhua = CDTL_Lot_DinhLotOngNhua(string HB16, string HI16, double LE16, double KH16);
            //item.CDTL_Lot_DinhLotGop = CDTL_Lot_DinhLotGop(string HB16, string HI16, double LE16, double KH16, double LA16, double HZ16, double LB16, double IR16, double LC16);
            //item.CDTL_Day_DayDaoOngNhua = CDTL_Day_DayDaoOngNhua(string HB16, string HI16, double LE16, double KH16, double KV16, double KL16);
            //item.CDTL_Day_DayDaoRanh = CDTL_Day_DayDaoRanh(string HB16, double KY16, double IP16);
            //item.CDTL_Day_DayDaoCongHop = CDTL_Day_DayDaoCongHop(string HB16, string HI16, double LE16, double IT16, double KX16, double IP16);
            //item.CDTL_Day_DayDaoCongTron = CDTL_Day_DayDaoCongTron(string HB16, string HI16, double LE16, double HT16, double LD16, double IB16, double KW16, double HX16);
            //item.CDTL_Day_DayDaoGop = CDTL_Day_DayDaoGop(string HB16, string HI16, double LE16, double HT16, double LD16, double IB16, double KW16, double HX16, double KX16, double IP16, double KY16, double KV16, double KL16, double KH16);
            //item.CDTL_Day_ChieuSauDao = CDTL_Day_ChieuSauDao(double KO16, double KN16);
            //item. =  ;

            return item;
        }

        //public double TTTDCHR_BS_SlCauKienNguyen(string HB16, double HE16, double JR16, double KA16)
        //{
        //    // Chuyển đổi giá trị HB16 về chữ hoa và xóa khoảng trắng
        //    HB16 = GetTenDanhMucById(HB16).ToUpper().Trim();
        //    double result = 0; // Khởi tạo kết quả

        //    // Kiểm tra điều kiện
        //    if (HB16 == "RÃNH XÂY" || HB16 == "RÃNH BÊ TÔNG" || HB16 == "CỐNG HỘP")
        //    {
        //        if (JR16 > 0)
        //        {
        //            result = Math.Floor(HE16 / (JR16 + KA16)); // Tính giá trị nếu điều kiện thỏa mãn
        //        }
        //    }

        //    return result; // Trả về kết quả
        //}
        //public double TTTDCHR_BS_ChieuDaiCan(string HB16, double JR16, double KC16, double KA16)
        //{
        //    // Chuyển đổi giá trị HB16 về chữ hoa và xóa khoảng trắng
        //    HB16 = GetTenDanhMucById(HB16).ToUpper().Trim();
        //    double result = 0; // Khởi tạo kết quả

        //    // Kiểm tra điều kiện
        //    if (HB16 == "RÃNH XÂY" || HB16 == "RÃNH BÊ TÔNG" || HB16 == "CỐNG HỘP")
        //    {
        //        if (JR16 > 0)
        //        {
        //            result = KC16 * KA16; // Tính giá trị nếu điều kiện thỏa mãn
        //        }
        //    }

        //    return result; // Trả về kết quả
        //}
        //public double TTTDCHR_BS_TongChieuDai(string HB16, double JR16, double KC16, double KD16)
        //{
        //    // Chuyển đổi giá trị HB16 về chữ hoa và xóa khoảng trắng
        //    HB16 = GetTenDanhMucById(HB16).ToUpper().Trim();
        //    double result = 0; // Khởi tạo kết quả

        //    // Kiểm tra điều kiện
        //    if (HB16 == "RÃNH XÂY" || HB16 == "RÃNH BÊ TÔNG" || HB16 == "CỐNG HỘP")
        //    {
        //        if (JR16 > 0)
        //        {
        //            result = (KC16 * JR16) + KD16; // Tính giá trị nếu điều kiện thỏa mãn
        //        }
        //    }

        //    return result; // Trả về kết quả
        //}
        //public double TTTDCHR_BS_ChieuDaiThucTe(string HB16, double JR16, double KE16, double HE16)
        //{
        //    // Chuyển đổi giá trị HB16 về chữ hoa và xóa khoảng trắng
        //    HB16 = GetTenDanhMucById(HB16).ToUpper().Trim();
        //    double result = 0; // Khởi tạo kết quả

        //    // Kiểm tra điều kiện
        //    if (HB16 == "RÃNH XÂY" || HB16 == "RÃNH BÊ TÔNG" || HB16 == "CỐNG HỘP")
        //    {
        //        if (JR16 > 0)
        //        {
        //            result = KE16 - HE16; // Tính giá trị nếu điều kiện thỏa mãn
        //        }
        //    }

        //    return result; // Trả về kết quả
        //}
        //public string TTTDCHR_BS_OngCongCanThem(string HB16, double KF16)
        //{
        //    // Chuyển đổi giá trị HB16 về chữ hoa và xóa khoảng trắng
        //    HB16 = GetTenDanhMucById(HB16).ToUpper().Trim();
        //    string result = "0"; // Khởi tạo kết quả mặc định

        //    // Kiểm tra điều kiện
        //    if (HB16 == "RÃNH XÂY" || HB16 == "RÃNH BÊ TÔNG" || HB16 == "CỐNG HỘP")
        //    {
        //        if (KF16 >= -0.02)
        //        {
        //            result = "Đủ"; // Kết quả nếu thỏa mãn điều kiện
        //        }
        //        else
        //        {
        //            result = "Thêm 01"; // Kết quả nếu không thỏa mãn điều kiện
        //        }
        //    }

        //    return result; // Trả về kết quả
        //}
        //public double TTKTHHON_TongCCaoOng(double KH16, double KI16, double KJ16)
        //{
        //    double result = (KH16 * KI16) + KJ16; // Tính toán
        //    return Math.Round(result, 2); // Trả về giá trị đã làm tròn
        //}
        //public double CDTL_Mong_DinhDeCong(string HI16, double LE16, double HT16)
        //{
        //    double result = 0; // Khởi tạo biến kết quả
        //    HI16 = GetTenDanhMucById(HI16).ToUpper().Trim();
        //    // Kiểm tra điều kiện
        //    if (HI16 == "Móng bê tông kết hợp đế" || HI16 == "Đế")
        //    {
        //        result = LE16 - HT16; // Tính toán
        //    }

        //    return result; // Trả về giá trị kết quả
        //}
        //public double CDTL_Mong_DinhMongRanh(string HB16, string HI16, double LE16)
        //{
        //    double result = 0; // Khởi tạo biến kết quả
        //    HB16 = GetTenDanhMucById(HB16).ToUpper().Trim();
        //    HI16 = GetTenDanhMucById(HI16).ToUpper().Trim();
        //    // Kiểm tra điều kiện
        //    if ((HB16 == "Rãnh xây" && HI16 == "Móng bê tông") || (HB16 == "Rãnh bê tông" && HI16 == "Móng bê tông"))
        //    {
        //        result = LE16; // Tính toán
        //    }

        //    return result; // Trả về giá trị kết quả
        //}
        //public double CDTL_Mong_DinhMongCongHop(string HB16, string HI16, double LE16, double IT16)
        //{
        //    // Chuyển đổi HB16 bằng phương thức GetTenDanhMucById và xử lý chuỗi
        //    HB16 = GetTenDanhMucById(HB16).ToUpper().Trim();
        //    HI16 = HI16.ToUpper().Trim(); // Đảm bảo HI16 cũng được xử lý

        //    double result = 0; // Khởi tạo biến kết quả

        //    // Kiểm tra điều kiện
        //    if (HB16 == "CỐNG HỘP" && HI16 == "MÓNG BÊ TÔNG")
        //    {
        //        result = LE16 - IT16; // Tính toán
        //    }

        //    return result; // Trả về giá trị kết quả
        //}
        //public double CDTL_Mong_DinhMongCongTron(string HB16, string HI16, double LE16, double HT16, double LD16, double IB16)
        //{
        //    // Chuyển đổi HB16 bằng phương thức GetTenDanhMucById và xử lý chuỗi
        //    HB16 = GetTenDanhMucById(HB16).ToUpper().Trim();
        //    HI16 = HI16.ToUpper().Trim(); // Đảm bảo HI16 cũng được xử lý

        //    double result = 0; // Khởi tạo biến kết quả

        //    // Kiểm tra điều kiện
        //    if (HB16 == "CỐNG TRÒN")
        //    {
        //        if (HI16 == "MÓNG BÊ TÔNG")
        //        {
        //            result = LE16 - HT16; // Tính toán cho trường hợp Móng bê tông
        //        }
        //        else if (HI16 == "MÓNG BÊ TÔNG KẾT HỢP ĐẾ")
        //        {
        //            result = LD16 - IB16; // Tính toán cho trường hợp Móng bê tông kết hợp đế
        //        }
        //    }

        //    return result; // Trả về giá trị kết quả
        //}
        //public double CDTL_Mong_DinhMongGop(string HB16, string HI16, double LE16, double HT16, double LD16, double IB16, double IT16)
        //{
        //    // Chuyển đổi HB16 và HI16 bằng phương thức GetTenDanhMucById và xử lý chuỗi
        //    HB16 = GetTenDanhMucById(HB16).ToUpper().Trim();
        //    HI16 = HI16.ToUpper().Trim(); // Đảm bảo HI16 cũng được xử lý

        //    double result = 0; // Khởi tạo biến kết quả

        //    // Kiểm tra điều kiện
        //    if (HB16 == "RÃNH THANG")
        //    {
        //        if (HB16 == "RÃNH THANG" && HI16 == "MÓNG BÊ TÔNG")
        //        {
        //            result = LE16; // Trường hợp Rãnh thang và Móng bê tông
        //        }
        //    }
        //    else if (HB16 == "CỐNG TRÒN")
        //    {
        //        if (HI16 == "MÓNG BÊ TÔNG")
        //        {
        //            result = LE16 - HT16; // Trường hợp Cống tròn và Móng bê tông
        //        }
        //        else if (HI16 == "MÓNG BÊ TÔNG KẾT HỢP ĐẾ")
        //        {
        //            result = LD16 - IB16; // Trường hợp Cống tròn và Móng bê tông kết hợp đế
        //        }
        //    }
        //    else if (HB16 == "CỐNG HỘP" && HI16 == "MÓNG BÊ TÔNG")
        //    {
        //        result = LE16 - IT16; // Trường hợp Cống hộp và Móng bê tông
        //    }
        //    else if (HB16 == "RÃNH XÂY" || HB16 == "RÃNH BÊ TÔNG")
        //    {
        //        if (HI16 == "MÓNG BÊ TÔNG")
        //        {
        //            result = LE16; // Trường hợp Rãnh xây hoặc Rãnh bê tông và Móng bê tông
        //        }
        //    }

        //    return result; // Trả về giá trị kết quả
        //}
        //public double CDTL_Lot_DinhLotRanh(string HB16, string HI16, double LC16, double IR16)
        //{
        //    // Chuyển đổi HB16 và HI16 bằng phương thức GetTenDanhMucById và xử lý chuỗi
        //    HB16 = GetTenDanhMucById(HB16).ToUpper().Trim();
        //    HI16 = HI16.ToUpper().Trim(); // Đảm bảo HI16 cũng được xử lý

        //    double result = 0; // Khởi tạo biến kết quả

        //    // Kiểm tra điều kiện
        //    if (HB16 == "RÃNH XÂY" && HI16 == "MÓNG BÊ TÔNG")
        //    {
        //        result = LC16 - IR16; // Trường hợp Rãnh xây và Móng bê tông
        //    }
        //    else if (HB16 == "RÃNH BÊ TÔNG" && HI16 == "MÓNG BÊ TÔNG")
        //    {
        //        result = LC16 - IR16; // Trường hợp Rãnh bê tông và Móng bê tông
        //    }
        //    else
        //    {
        //        result = 0; // Trường hợp khác
        //    }

        //    return result; // Trả về giá trị kết quả
        //}
        //public double CDTL_Lot_DinhLotCongHop(string HB16, string HI16, double LB16, double IR16)
        //{
        //    // Chuyển đổi HB16 và HI16 bằng phương thức GetTenDanhMucById và xử lý chuỗi
        //    HB16 = GetTenDanhMucById(HB16).ToUpper().Trim();
        //    HI16 = HI16.ToUpper().Trim(); // Đảm bảo HI16 cũng được xử lý

        //    double result = 0; // Khởi tạo biến kết quả

        //    // Kiểm tra điều kiện
        //    if (HB16 == "CỐNG HỘP" && HI16 == "MÓNG BÊ TÔNG")
        //    {
        //        result = LB16 - IR16; // Trường hợp Cống hộp và Móng bê tông
        //    }
        //    else
        //    {
        //        result = 0; // Trường hợp khác
        //    }

        //    return result; // Trả về giá trị kết quả
        //}
        //public double CDTL_Lot_DinhLotCongTron(string HB16, string HI16, double LA16, double HZ16)
        //{
        //    // Chuyển đổi HB16 và HI16 bằng phương thức GetTenDanhMucById và xử lý chuỗi
        //    HB16 = GetTenDanhMucById(HB16).ToUpper().Trim();
        //    HI16 = HI16.ToUpper().Trim(); // Đảm bảo HI16 cũng được xử lý

        //    double result = 0; // Khởi tạo biến kết quả

        //    // Kiểm tra điều kiện
        //    if (HB16 == "CỐNG TRÒN")
        //    {
        //        if (HI16 == "MÓNG BÊ TÔNG" || HI16 == "MÓNG BÊ TÔNG KẾT HỢP ĐẾ")
        //        {
        //            result = LA16 - HZ16; // Tính giá trị nếu điều kiện thỏa mãn
        //        }
        //    }

        //    return result; // Trả về giá trị kết quả
        //}
        //public double CDTL_Lot_DinhLotOngNhua(string HB16, string HI16, double LE16, double KH16)
        //{
        //    // Chuyển đổi HB16 và HI16 bằng phương thức GetTenDanhMucById và xử lý chuỗi
        //    HB16 = GetTenDanhMucById(HB16).ToUpper().Trim();
        //    HI16 = HI16.ToUpper().Trim(); // Đảm bảo HI16 cũng được xử lý

        //    double result = 0; // Khởi tạo biến kết quả

        //    // Kiểm tra điều kiện
        //    if (HB16 == "ỐNG NHỰA" && HI16 == "ĐẮP CÁT")
        //    {
        //        result = LE16 - KH16; // Tính giá trị nếu điều kiện thỏa mãn
        //    }

        //    return result; // Trả về giá trị kết quả
        //}
        //public double CDTL_Lot_DinhLotGop(string HB16, string HI16, double LE16, double KH16, double LA16, double HZ16, double LB16, double IR16, double LC16)
        //{
        //    // Chuyển đổi HB16 và HI16 bằng phương thức GetTenDanhMucById và xử lý chuỗi
        //    HB16 = GetTenDanhMucById(HB16).ToUpper().Trim();
        //    HI16 = HI16.ToUpper().Trim(); // Đảm bảo HI16 cũng được xử lý

        //    double result = 0; // Khởi tạo biến kết quả

        //    // Kiểm tra điều kiện
        //    if (HB16 == "RÃNH THANG")
        //    {
        //        if (HI16 == "MÓNG BÊ TÔNG")
        //        {
        //            result = LE16 - /* giá trị thiếu ở đây */; // Bạn cần thay thế #REF! với giá trị cụ thể
        //        }
        //    }
        //    else if (HB16 == "ỐNG NHỰA" && HI16 == "ĐẮP CÁT")
        //    {
        //        result = LE16 - KH16; // Tính giá trị nếu điều kiện thỏa mãn
        //    }
        //    else if (HB16 == "CỐNG TRÒN")
        //    {
        //        if (HI16 == "MÓNG BÊ TÔNG" || HI16 == "MÓNG BÊ TÔNG KẾT HỢP ĐẾ")
        //        {
        //            result = LA16 - HZ16; // Tính giá trị nếu điều kiện thỏa mãn
        //        }
        //    }
        //    else if (HB16 == "CỐNG HỘP" && HI16 == "MÓNG BÊ TÔNG")
        //    {
        //        result = LB16 - IR16; // Tính giá trị nếu điều kiện thỏa mãn
        //    }
        //    else if (HB16 == "RÃNH XÂY" || HB16 == "RÃNH BÊ TÔNG")
        //    {
        //        if (HI16 == "MÓNG BÊ TÔNG")
        //        {
        //            result = LC16 - IR16; // Tính giá trị nếu điều kiện thỏa mãn
        //        }
        //    }

        //    return result; // Trả về giá trị kết quả
        //}
        //public double CDTL_Day_DayDaoOngNhua(string HB16, string HI16, double LE16, double KH16, double KV16, double KL16)
        //{
        //    // Chuyển đổi HB16 và HI16 bằng phương thức GetTenDanhMucById và xử lý chuỗi
        //    HB16 = GetTenDanhMucById(HB16).ToUpper().Trim();
        //    HI16 = HI16.ToUpper().Trim(); // Đảm bảo HI16 cũng được xử lý

        //    double result = 0; // Khởi tạo biến kết quả

        //    // Kiểm tra điều kiện
        //    if (HB16 == "ỐNG NHỰA" && HI16 == "KHÔNG ĐẮP CÁT")
        //    {
        //        result = LE16 - KH16; // Tính giá trị nếu điều kiện thỏa mãn
        //    }
        //    else if (HB16 == "ỐNG NHỰA" && HI16 == "ĐẮP CÁT")
        //    {
        //        result = KV16 - KL16; // Tính giá trị nếu điều kiện thỏa mãn
        //    }

        //    return result; // Trả về giá trị kết quả
        //}
        //public double CDTL_Day_DayDaoRanh(string HB16, double KY16, double IP16)
        //{
        //    // Chuyển đổi HB16 bằng phương thức GetTenDanhMucById và xử lý chuỗi
        //    HB16 = GetTenDanhMucById(HB16).ToUpper().Trim(); // Chuyển đổi HB16 thành chữ hoa và xóa khoảng trắng

        //    double result = 0; // Khởi tạo biến kết quả

        //    // Kiểm tra điều kiện
        //    if (HB16 == "RÃNH XÂY" || HB16 == "RÃNH BÊ TÔNG")
        //    {
        //        result = KY16 - IP16; // Tính giá trị nếu điều kiện thỏa mãn
        //    }

        //    return result; // Trả về giá trị kết quả
        //}
        //public double CDTL_Day_DayDaoCongHop(string HB16, string HI16, double LE16, double IT16, double KX16, double IP16)
        //{
        //    // Chuyển đổi HB16 và HI16 bằng phương thức GetTenDanhMucById và xử lý chuỗi
        //    HB16 = GetTenDanhMucById(HB16).ToUpper().Trim(); // Chuyển đổi HB16 thành chữ hoa và xóa khoảng trắng
        //    HI16 = GetTenDanhMucById(HI16).ToUpper().Trim(); // Chuyển đổi HI16 thành chữ hoa và xóa khoảng trắng

        //    double result = 0; // Khởi tạo biến kết quả

        //    // Kiểm tra điều kiện
        //    if (HB16 == "CỐNG HỘP")
        //    {
        //        if (HI16 == "KHÔNG CÓ MÓNG")
        //        {
        //            result = LE16 - IT16; // Tính giá trị nếu HI16 là "Không có móng"
        //        }
        //        else if (HI16 == "MÓNG BÊ TÔNG")
        //        {
        //            result = KX16 - IP16; // Tính giá trị nếu HI16 là "Móng bê tông"
        //        }
        //    }

        //    return result; // Trả về giá trị kết quả
        //}
        //public double CDTL_Day_DayDaoCongTron(string HB16, string HI16, double LE16, double HT16, double LD16, double IB16, double KW16, double HX16)
        //{
        //    // Chuyển đổi HB16 và HI16 bằng phương thức GetTenDanhMucById và xử lý chuỗi
        //    HB16 = GetTenDanhMucById(HB16).ToUpper().Trim(); // Chuyển đổi HB16 thành chữ hoa và xóa khoảng trắng
        //    HI16 = GetTenDanhMucById(HI16).ToUpper().Trim(); // Chuyển đổi HI16 thành chữ hoa và xóa khoảng trắng

        //    double result = 0; // Khởi tạo biến kết quả

        //    // Kiểm tra điều kiện
        //    if (HB16 == "CỐNG TRÒN")
        //    {
        //        if (HI16 == "KHÔNG CÓ MÓNG")
        //        {
        //            result = LE16 - HT16; // Tính giá trị nếu HI16 là "Không có móng"
        //        }
        //        else if (HI16 == "ĐẾ")
        //        {
        //            result = LD16 - IB16; // Tính giá trị nếu HI16 là "Đế"
        //        }
        //        else if (HI16 == "MÓNG BÊ TÔNG" || HI16 == "MÓNG BÊ TÔNG KẾT HỢP ĐẾ")
        //        {
        //            result = KW16 - HX16; // Tính giá trị nếu HI16 là "Móng bê tông" hoặc "Móng bê tông kết hợp đế"
        //        }
        //    }

        //    return result; // Trả về giá trị kết quả
        //}
        //public double CDTL_Day_DayDaoGop(string HB16, string HI16, double LE16, double HT16, double LD16, double IB16, double KW16, double HX16, double KX16, double IP16, double KY16, double KV16, double KL16, double KH16)
        //{
        //    // Chuyển đổi HB16 và HI16 bằng phương thức GetTenDanhMucById và xử lý chuỗi
        //    HB16 = GetTenDanhMucById(HB16).ToUpper().Trim(); // Chuyển đổi HB16 thành chữ hoa và xóa khoảng trắng
        //    HI16 = GetTenDanhMucById(HI16).ToUpper().Trim(); // Chuyển đổi HI16 thành chữ hoa và xóa khoảng trắng

        //    double result = 0; // Khởi tạo biến kết quả

        //    // Kiểm tra điều kiện
        //    if (HB16 == "CỐNG TRÒN")
        //    {
        //        if (HI16 == "KHÔNG CÓ MÓNG")
        //        {
        //            result = LE16 - HT16; // Tính giá trị nếu HI16 là "Không có móng"
        //        }
        //        else if (HI16 == "ĐẾ")
        //        {
        //            result = LD16 - IB16; // Tính giá trị nếu HI16 là "Đế"
        //        }
        //        else if (HI16 == "MÓNG BÊ TÔNG" || HI16 == "MÓNG BÊ TÔNG KẾT HỢP ĐẾ")
        //        {
        //            result = KW16 - HX16; // Tính giá trị nếu HI16 là "Móng bê tông" hoặc "Móng bê tông kết hợp đế"
        //        }
        //    }
        //    else if (HB16 == "CỐNG HỘP")
        //    {
        //        if (HI16 == "KHÔNG CÓ MÓNG")
        //        {
        //            result = LE16 - IT16; // Tính giá trị nếu HI16 là "Không có móng"
        //        }
        //        else if (HI16 == "MÓNG BÊ TÔNG")
        //        {
        //            result = KX16 - IP16; // Tính giá trị nếu HI16 là "Móng bê tông"
        //        }
        //    }
        //    else if (HB16 == "RÃNH XÂY" || HB16 == "RÃNH BÊ TÔNG")
        //    {
        //        result = KY16 - IP16; // Tính giá trị nếu HB16 là "Rãnh xây" hoặc "Rãnh bê tông"
        //    }
        //    else if (HB16 == "ỐNG NHỰA")
        //    {
        //        if (HI16 == "KHÔNG ĐẮP CÁT")
        //        {
        //            result = LE16 - KH16; // Tính giá trị nếu HI16 là "Không đắp cát"
        //        }
        //        else if (HI16 == "ĐẮP CÁT")
        //        {
        //            result = KV16 - KL16; // Tính giá trị nếu HI16 là "Đắp cát"
        //        }
        //    }
        //    else if (HB16 == "RÃNH THANG")
        //    {
        //        if (HI16 == "MÓNG BÊ TÔNG")
        //        {
        //            // Lưu ý: Giá trị #REF! không thể chuyển đổi sang C#
        //            // Bạn cần xác định rõ giá trị này trước khi sử dụng
        //            result = 0; // Thay thế bằng giá trị chính xác nếu có
        //        }
        //        else
        //        {
        //            result = LE16; // Nếu không có điều kiện nào khác
        //        }
        //    }

        //    return Math.Round(result, 2); // Trả về giá trị làm tròn tới 2 chữ số thập phân
        //}

        //public double CDTL_Day_ChieuSauDao(double KO16, double KN16)
        //{
        //    double result = 0; // Khởi tạo biến kết quả

        //    // Kiểm tra điều kiện
        //    if (KO16 > 0)
        //    {
        //        result = KN16 - KO16; // Tính giá trị nếu KO16 lớn hơn 0
        //    }

        //    return Math.Round(result, 2); // Trả về giá trị làm tròn tới 2 chữ số thập phân
        //}


        //public double TTVLDHT_ChieuCaoDaoDat(string DA16, double DR16, double DB16)
        //{
        //    double result = 0;
        //    DA16 = GetTenDanhMucById(DA16); // Gọi hàm để lấy tên danh mục

        //    if (string.IsNullOrEmpty(DA16))
        //    {
        //        result = 0;
        //    }
        //    else if (DA16.ToUpper().Trim() == "ĐÀO ĐÁ")
        //    {
        //        result = 0;
        //    }
        //    else
        //    {
        //        result = DR16 - DB16;
        //    }

        //    return Math.Round(result, 2);
        //}
        //public double TTVLDHT_TongChieuCaoDao(double DB16, double DC16)
        //{
        //    double result = DB16 + DC16; // Tính tổng của DB16 và DC16
        //    return Math.Round(result, 2); // Làm tròn kết quả về 2 chữ số thập phân
        //}
        //public double TTCD_HE_DinhMong(double DJ16, double S16)
        //{
        //    double result = DJ16 - S16; // Tính hiệu giữa DJ16 và S16
        //    return Math.Round(result, 2); // Làm tròn kết quả về 2 chữ số thập phân
        //}
        //public double TTCD_HE_DinhLot(double DI16, double P16)
        //{
        //    double result = DI16 - P16; // Tính hiệu giữa DI16 và P16
        //    return Math.Round(result, 2); // Làm tròn kết quả về 2 chữ số thập phân
        //}
        //public double TTCD_HE_DayDao(double DH16, double M16)
        //{
        //    double result = DH16 - M16; // Tính hiệu giữa DH16 và M16
        //    return Math.Round(result, 2); // Làm tròn kết quả về 2 chữ số thập phân
        //}
        //public double TTCD_HE_CSauDao(double DE16, double DF16)
        //{
        //    double result = DE16 - DF16; // Tính hiệu giữa DE16 và DF16
        //    return Math.Round(result, 2); // Làm tròn kết quả về 2 chữ số thập phân
        //}
        //public double TTCD_HE_TongChieuCaoBoVia(double DJ16, double DF16)
        //{
        //    double result = DJ16 - DF16; // Tính hiệu giữa DJ16 và DF16
        //    return Math.Round(result, 2); // Làm tròn kết quả về 2 chữ số thập phân
        //}
        //public double TTCD_HE_ChenhCaoDinh(double DJ16, double DE16)
        //{
        //    double result = DJ16 - DE16; // Tính hiệu giữa DJ16 và DE16
        //    return Math.Round(result, 2); // Làm tròn kết quả về 2 chữ số thập phân
        //}
        //public double TTCD_HE_TongChieuCao(double DK16, double DL16)
        //{
        //    double result = DK16 - DL16; // Tính hiệu giữa DK16 và DL16
        //    return Math.Round(result, 2); // Làm tròn kết quả về 2 chữ số thập phân
        //}
        //public double TTCD_DN_CdHienTrang(double DN16, double CZ16)
        //{
        //    double result = DN16 - CZ16; // Tính hiệu giữa DN16 và CZ16
        //    return Math.Round(result, 2); // Làm tròn kết quả về 2 chữ số thập phân
        //}
        //public double TTCD_HT_CdDinhMong(double DU16, double AK16, string T16, string W16)
        //{
        //    double result = 0;

        //    // Lấy tên danh mục từ Id nếu cần so sánh chuỗi
        //    T16 = GetTenDanhMucById(T16);
        //    W16 = GetTenDanhMucById(W16);

        //    // Kiểm tra điều kiện
        //    if (T16.ToUpper().Trim() == "Lắp đặt".ToUpper() && W16.ToUpper().Trim() == "Có móng".ToUpper())
        //    {
        //        result = DU16 - AK16; // Nếu điều kiện thỏa mãn, tính DU16 - AK16
        //    }
        //    else
        //    {
        //        result = DU16; // Nếu không, trả về DU16
        //    }

        //    return Math.Round(result, 2); // Làm tròn kết quả về 2 chữ số thập phân
        //}
        //public double TTCD_HT_DinhLotMong(double DT16, double AH16, string W16)
        //{
        //    double result = 0;

        //    // Lấy tên danh mục từ Id nếu cần so sánh chuỗi
        //    W16 = GetTenDanhMucById(W16);

        //    // Kiểm tra điều kiện
        //    if (W16.ToUpper().Trim() == "Không có móng".ToUpper())
        //    {
        //        result = 0; // Nếu W16 là "Không có móng", trả về 0
        //    }
        //    else
        //    {
        //        result = DT16 - AH16; // Nếu không, trả về DT16 - AH16
        //    }

        //    return Math.Round(result, 2); // Làm tròn kết quả về 2 chữ số thập phân
        //}
        //public double TTCD_HT_DayDao(double DS16, double AE16, double DU16, double AK16, string T16, string W16)
        //{
        //    double result = 0;

        //    // Lấy tên danh mục từ Id nếu cần so sánh chuỗi
        //    T16 = GetTenDanhMucById(T16);
        //    W16 = GetTenDanhMucById(W16);

        //    // Kiểm tra điều kiện
        //    if (W16.ToUpper().Trim() == "Có móng".ToUpper())
        //    {
        //        result = DS16 - AE16; // Nếu W16 là "Có móng", tính DS16 - AE16
        //    }
        //    else if (T16.ToUpper().Trim() == "Lắp đặt".ToUpper() && W16.ToUpper().Trim() == "Không có móng".ToUpper())
        //    {
        //        result = DU16 - AK16; // Nếu T16 là "Lắp đặt" và W16 là "Không có móng", tính DU16 - AK16
        //    }
        //    else
        //    {
        //        result = DU16; // Nếu không, trả về DU16
        //    }

        //    return Math.Round(result, 2); // Làm tròn kết quả về 2 chữ số thập phân
        //}
        //public double TTCD_HT_CSauDao(double DP16, double DQ16)
        //{
        //    double result = DP16 - DQ16; // Tính hiệu giữa DP16 và DQ16
        //    return Math.Round(result, 2); // Làm tròn kết quả về 2 chữ số thập phân
        //}
        //public double TTCD_HT_DinhMuMoThotDuoi(double EA16, double BG16)
        //{
        //    double result = EA16 - BG16; // Tính hiệu giữa EA16 và BG16
        //    return Math.Round(result, 2); // Làm tròn kết quả về 2 chữ số thập phân
        //}
        //public double TTCD_HT_DinhTuong(double DZ16, double BC16)
        //{
        //    double result = DZ16 - BC16; // Tính hiệu giữa DZ16 và BC16
        //    return Math.Round(result, 2); // Làm tròn kết quả về 2 chữ số thập phân
        //}
        //public double TTCD_HT_CCaoTuong(double DY16, double DU16)
        //{
        //    double result = DY16 - DU16; // Tính hiệu giữa DY16 và DU16
        //    return Math.Round(result, 2); // Làm tròn kết quả về 2 chữ số thập phân
        //}
        //public double TTCD_HT_DinhTuongDuoi(double DU16, double AT16)
        //{
        //    double result = 0;

        //    // Kiểm tra điều kiện
        //    if (AT16 > 0)
        //    {
        //        result = DU16 + AT16; // Nếu AT16 lớn hơn 0, tính DU16 + AT16
        //    }
        //    else
        //    {
        //        result = 0; // Nếu không, kết quả là 0
        //    }

        //    return Math.Round(result, 2); // Làm tròn kết quả về 2 chữ số thập phân
        //}
        //public double TTCD_HT_DinhDamGiuaTuong(double DW16, double AR16)
        //{
        //    double result = DW16 + AR16; // Tính tổng giữa DW16 và AR16
        //    return Math.Round(result, 2); // Làm tròn kết quả về 2 chữ số thập phân
        //}
        //public double TTCD_HT_TongChieuCaoHoThu(double EA16, double DQ16)
        //{
        //    double result = EA16 - DQ16; // Tính hiệu giữa EA16 và DQ16
        //    return Math.Round(result, 2); // Làm tròn kết quả về 2 chữ số thập phân
        //}
        //public double TTCD_HT_ChenhCaoDinh(double EA16, double DP16)
        //{
        //    double result = EA16 - DP16; // Tính hiệu giữa EA16 và DP16
        //    return Math.Round(result, 2); // Làm tròn kết quả về 2 chữ số thập phân
        //}
        //public double TTCD_HT_TongChieuCao(double EB16, double EC16)
        //{
        //    double result = EB16 - EC16; // Tính hiệu giữa EB16 và EC16
        //    return Math.Round(result, 2); // Làm tròn kết quả về 2 chữ số thập phân
        //}
        //public double TTCCDT_BV_CCaoLotBoViaCChoDat(double DC16, double M16, string DA16)
        //{
        //    double result = 0;
        //    DA16 = GetTenDanhMucById(DA16).ToUpper().Trim();
        //    // Kiểm tra điều kiện
        //    if (DA16 == "ĐÀO ĐẤT" || DA16 == "ĐÀO ĐẤT + ĐÀO ĐÁ")
        //    {
        //        result = (DC16 >= M16) ? M16 : DC16; // Nếu DC16 lớn hơn hoặc bằng M16, chọn M16, ngược lại chọn DC16
        //    }
        //    else
        //    {
        //        result = 0; // Nếu không, kết quả là 0
        //    }

        //    return Math.Round(result, 2); // Làm tròn kết quả về 2 chữ số thập phân
        //}
        //public double TTCCDT_BV_CCaoMongBoViaCChoDat(double DC16, double M16, double P16, string DA16)
        //{
        //    double result = 0;
        //    DA16 = GetTenDanhMucById(DA16).ToUpper().Trim();
        //    // Kiểm tra điều kiện
        //    if (DA16 == "ĐÀO ĐẤT" || DA16 == "ĐÀO ĐẤT + ĐÀO ĐÁ")
        //    {
        //        if (DC16 <= M16)
        //        {
        //            result = 0; // Nếu DC16 nhỏ hơn hoặc bằng M16, kết quả là 0
        //        }
        //        else if (DC16 >= M16 + P16)
        //        {
        //            result = P16; // Nếu DC16 lớn hơn hoặc bằng M16 + P16, kết quả là P16
        //        }
        //        else
        //        {
        //            result = DC16 - M16; // Nếu không, tính hiệu giữa DC16 và M16
        //        }
        //    }
        //    else
        //    {
        //        result = 0; // Nếu không, kết quả là 0
        //    }

        //    return Math.Round(result, 2); // Làm tròn kết quả về 2 chữ số thập phân
        //}
        //public double TTCCDT_BV_CCaoBoViaCChoDat(string DA16, double DC16, double M16, double P16, double S16)
        //{
        //    double result = 0;
        //    DA16 = GetTenDanhMucById(DA16).ToUpper().Trim();
        //    // Kiểm tra điều kiện
        //    if (DA16 == "ĐÀO ĐẤT" || DA16 == "ĐÀO ĐẤT + ĐÀO ĐÁ")
        //    {
        //        if (DC16 <= M16 + P16)
        //        {
        //            result = 0; // Nếu DC16 nhỏ hơn hoặc bằng M16 + P16, kết quả là 0
        //        }
        //        else if (DC16 >= M16 + P16 + S16)
        //        {
        //            result = S16; // Nếu DC16 lớn hơn hoặc bằng M16 + P16 + S16, kết quả là S16
        //        }
        //        else
        //        {
        //            result = DC16 - (M16 + P16); // Nếu không, tính hiệu giữa DC16 và (M16 + P16)
        //        }
        //    }
        //    else
        //    {
        //        result = 0; // Nếu không, kết quả là 0
        //    }

        //    return Math.Round(result, 2); // Làm tròn kết quả về 2 chữ số thập phân
        //}
        //public double TTCCDT_BV_CCaoLotBoViaCChoDa(string DA16, double DB16, double DD16, double EE16, double M16)
        //{
        //    double result = 0;
        //    DA16 = GetTenDanhMucById(DA16).ToUpper().Trim();
        //    if (DA16 == "ĐÀO ĐÁ")
        //    {
        //        result = (DB16 >= M16) ? M16 : DB16; // Nếu DB16 lớn hơn hoặc bằng M16, trả về M16, ngược lại trả về DB16
        //    }
        //    else if (DA16 == "ĐÀO ĐẤT + ĐÀO ĐÁ")
        //    {
        //        if (DD16 >= M16)
        //        {
        //            result = (EE16 < M16) ? M16 - EE16 : 0; // Nếu EE16 nhỏ hơn M16, trả về M16 - EE16, ngược lại trả về 0
        //        }
        //        else
        //        {
        //            result = DB16; // Nếu DD16 nhỏ hơn M16, trả về DB16
        //        }
        //    }
        //    else
        //    {
        //        result = 0; // Nếu không thỏa mãn điều kiện nào, trả về 0
        //    }

        //    return Math.Round(result, 2); // Làm tròn kết quả về 2 chữ số thập phân
        //}
        //public double TTCCDT_BV_CCaoMongBoViaCChoDa(string DA16, double DB16, double DD16, double EF16, double EH16, double M16, double P16)
        //{
        //    double result = 0;
        //    DA16 = GetTenDanhMucById(DA16).ToUpper().Trim();
        //    if (DA16 == "ĐÀO ĐÁ")
        //    {
        //        if (DB16 <= M16)
        //        {
        //            result = 0; // Nếu DB16 nhỏ hơn hoặc bằng M16, kết quả là 0
        //        }
        //        else if (DB16 >= M16 + P16)
        //        {
        //            result = P16; // Nếu DB16 lớn hơn hoặc bằng M16 + P16, kết quả là P16
        //        }
        //        else
        //        {
        //            result = DB16 - M16; // Nếu không, tính hiệu giữa DB16 và M16
        //        }
        //    }
        //    else if (DA16 == "ĐÀO ĐẤT + ĐÀO ĐÁ")
        //    {
        //        if (DD16 >= M16 + P16)
        //        {
        //            result = (EF16 < P16) ? P16 - EF16 : 0; // Nếu EF16 nhỏ hơn P16, kết quả là P16 - EF16, ngược lại là 0
        //        }
        //        else
        //        {
        //            result = DB16 - EH16; // Nếu không thỏa mãn điều kiện, tính hiệu giữa DB16 và EH16
        //        }
        //    }
        //    else
        //    {
        //        result = 0; // Nếu không thỏa mãn điều kiện nào, trả về 0
        //    }

        //    return Math.Round(result, 2); // Làm tròn kết quả về 2 chữ số thập phân
        //}
        //public double TTCCDT_BV_CCaoBoViaCChoDa(string DA16, double DB16, double DD16, double EG16, double EH16, double EI16, double M16, double P16, double S16)
        //{
        //    // Gọi hàm GetTenDanhMucById và chuẩn hóa giá trị của DA16
        //    DA16 = GetTenDanhMucById(DA16).ToUpper().Trim();

        //    double result = 0;

        //    if (DA16 == "ĐÀO ĐÁ")
        //    {
        //        if (DB16 <= M16 + P16)
        //        {
        //            result = 0; // Nếu DB16 nhỏ hơn hoặc bằng M16 + P16, kết quả là 0
        //        }
        //        else if (DB16 >= M16 + P16 + S16)
        //        {
        //            result = S16; // Nếu DB16 lớn hơn hoặc bằng M16 + P16 + S16, kết quả là S16
        //        }
        //        else
        //        {
        //            result = DB16 - (M16 + P16); // Tính hiệu giữa DB16 và (M16 + P16)
        //        }
        //    }
        //    else if (DA16 == "ĐÀO ĐẤT + ĐÀO ĐÁ")
        //    {
        //        if (DD16 >= M16 + P16 + S16)
        //        {
        //            result = (EG16 < S16) ? S16 - EG16 : 0; // Nếu EG16 nhỏ hơn S16, trả về S16 - EG16, ngược lại là 0
        //        }
        //        else
        //        {
        //            result = DB16 - (EH16 + EI16); // Tính hiệu giữa DB16 và (EH16 + EI16)
        //        }
        //    }
        //    else
        //    {
        //        result = 0; // Nếu không thỏa mãn điều kiện nào, trả về 0
        //    }

        //    return Math.Round(result, 2); // Làm tròn kết quả về 2 chữ số thập phân
        //}
        //public double TTCCDT_BV_TongCCaoCChoDat(string H16, double EE16, double EF16, double EG16)
        //{
        //    // Gọi hàm GetTenDanhMucById và chuẩn hóa giá trị của H16
        //    H16 = GetTenDanhMucById(H16).ToUpper().Trim();

        //    double result = 0;

        //    // Kiểm tra điều kiện và tính toán kết quả
        //    if (H16 == "BÓ VỈA HÀM ẾCH")
        //    {
        //        result = EE16 + EF16 + EG16; // Tính tổng EE16, EF16 và EG16
        //    }

        //    return Math.Round(result, 2); // Làm tròn kết quả về 2 chữ số thập phân
        //}
        //public double TTCCDT_BV_TongCCaoCChoDa(string H16, double EH16, double EI16, double EJ16)
        //{
        //    // Gọi hàm GetTenDanhMucById và chuẩn hóa giá trị của H16
        //    H16 = GetTenDanhMucById(H16).ToUpper().Trim();

        //    double result = 0;

        //    // Kiểm tra điều kiện và tính toán kết quả
        //    if (H16 == "BÓ VỈA HÀM ẾCH")
        //    {
        //        result = EH16 + EI16 + EJ16; // Tính tổng EH16, EI16 và EJ16
        //    }

        //    return Math.Round(result, 2); // Làm tròn kết quả về 2 chữ số thập phân
        //}

        //public double TTCCDT_BV_ChenhDatSoVoiThietKe(string H16, double DC16, double EK16)
        //{
        //    // Gọi hàm GetTenDanhMucById và chuẩn hóa giá trị của H16
        //    H16 = GetTenDanhMucById(H16).ToUpper().Trim();

        //    double result = 0;

        //    // Kiểm tra điều kiện và tính toán kết quả
        //    if (H16 == "BÓ VỈA HÀM ẾCH")
        //    {
        //        result = DC16 - EK16; // Tính hiệu giữa DC16 và EK16
        //    }

        //    return Math.Round(result, 2); // Làm tròn kết quả về 2 chữ số thập phân
        //}
        //public double TTCCDT_HT_ChieuCaoLotCChoDat(string DA16, double DC16, double AE16)
        //{
        //    // Gọi hàm GetTenDanhMucById và chuẩn hóa giá trị của DA16
        //    DA16 = GetTenDanhMucById(DA16).ToUpper().Trim();

        //    double result = 0;

        //    // Kiểm tra điều kiện và tính toán kết quả
        //    if (DA16 == "ĐÀO ĐẤT" || DA16 == "ĐÀO ĐẤT + ĐÀO ĐÁ")
        //    {
        //        result = DC16 >= AE16 ? AE16 : DC16; // Lấy giá trị lớn hơn giữa DC16 và AE16
        //    }

        //    return Math.Round(result, 2); // Làm tròn kết quả về 2 chữ số thập phân
        //}
        //public double TTCCDT_HT_ChieuCaoMongCChoDat(string DA16, double DC16, double AE16, double AH16)
        //{
        //    // Gọi hàm GetTenDanhMucById và chuẩn hóa giá trị của DA16
        //    DA16 = GetTenDanhMucById(DA16).ToUpper().Trim();

        //    double result = 0;

        //    // Kiểm tra điều kiện và tính toán kết quả
        //    if (DA16 == "ĐÀO ĐẤT" || DA16 == "ĐÀO ĐẤT + ĐÀO ĐÁ")
        //    {
        //        if (DC16 <= AE16)
        //        {
        //            result = 0; // Nếu DC16 nhỏ hơn hoặc bằng AE16, trả về 0
        //        }
        //        else if (DC16 >= AE16 + AH16)
        //        {
        //            result = AH16; // Nếu DC16 lớn hơn hoặc bằng tổng AE16 và AH16, trả về AH16
        //        }
        //        else
        //        {
        //            result = DC16 - AE16; // Ngược lại, trả về hiệu giữa DC16 và AE16
        //        }
        //    }

        //    return Math.Round(result, 2); // Làm tròn kết quả về 2 chữ số thập phân
        //}
        //public double TTCCDT_HT_ChieuCaoTuongCChoDat(string DA16, double DC16, double AE16, double AH16, double AN16, double AR16, double BC16, double BG16)
        //{
        //    // Gọi hàm GetTenDanhMucById và chuẩn hóa giá trị của DA16
        //    DA16 = GetTenDanhMucById(DA16).ToUpper().Trim();

        //    double result = 0;

        //    // Kiểm tra điều kiện và tính toán kết quả
        //    if (DA16 == "ĐÀO ĐẤT" || DA16 == "ĐÀO ĐẤT + ĐÀO ĐÁ")
        //    {
        //        if (DC16 <= AE16 + AH16)
        //        {
        //            result = 0; // Nếu DC16 nhỏ hơn hoặc bằng tổng AE16 và AH16, trả về 0
        //        }
        //        else if (DC16 >= AE16 + AH16 + AN16 + AR16 + BC16 + BG16)
        //        {
        //            result = AN16 + AR16 + BC16 + BG16; // Nếu DC16 lớn hơn hoặc bằng tổng các giá trị, trả về tổng các giá trị
        //        }
        //        else
        //        {
        //            result = DC16 - (AE16 + AH16); // Ngược lại, trả về hiệu giữa DC16 và tổng AE16, AH16
        //        }
        //    }

        //    return Math.Round(result, 2); // Làm tròn kết quả về 2 chữ số thập phân
        //}
        //public double TTCCDT_HT_ChieuCaoLotCChoDa(string DA16, double DB16, double AE16, double DD16, double EO16)
        //{
        //    // Gọi hàm GetTenDanhMucById và chuẩn hóa giá trị của DA16
        //    DA16 = GetTenDanhMucById(DA16).ToUpper().Trim();

        //    double result = 0;

        //    // Kiểm tra điều kiện và tính toán kết quả
        //    if (DA16 == "ĐÀO ĐÁ")
        //    {
        //        // Nếu DA16 là "Đào đá"
        //        result = DB16 >= AE16 ? AE16 : DB16; // Trả về AE16 nếu DB16 lớn hơn hoặc bằng AE16, ngược lại trả về DB16
        //    }
        //    else if (DA16 == "ĐÀO ĐẤT + ĐÀO ĐÁ")
        //    {
        //        // Nếu DA16 là "Đào đất + Đào đá"
        //        if (DD16 >= AE16)
        //        {
        //            result = EO16 < AE16 ? AE16 - EO16 : 0; // Nếu DD16 lớn hơn hoặc bằng AE16, kiểm tra EO16 và trả về giá trị tương ứng
        //        }
        //        else
        //        {
        //            result = DB16; // Ngược lại, trả về DB16
        //        }
        //    }

        //    return result; // Trả về kết quả
        //}
        //public double TTCCDT_HT_ChieuCaoMongCChoDa(string DA16, double DB16, double AE16, double DD16, double EO16)
        //{
        //    // Gọi hàm GetTenDanhMucById và chuẩn hóa giá trị của DA16
        //    DA16 = GetTenDanhMucById(DA16).ToUpper().Trim();

        //    double result = 0;

        //    // Kiểm tra điều kiện và tính toán kết quả
        //    if (DA16 == "ĐÀO ĐÁ")
        //    {
        //        // Nếu DA16 là "Đào đá"
        //        result = DB16 >= AE16 ? AE16 : DB16; // Trả về AE16 nếu DB16 lớn hơn hoặc bằng AE16, ngược lại trả về DB16
        //    }
        //    else if (DA16 == "ĐÀO ĐẤT + ĐÀO ĐÁ")
        //    {
        //        // Nếu DA16 là "Đào đất + Đào đá"
        //        if (DD16 >= AE16)
        //        {
        //            result = EO16 < AE16 ? AE16 - EO16 : 0; // Nếu DD16 lớn hơn hoặc bằng AE16, kiểm tra EO16 và trả về giá trị tương ứng
        //        }
        //        else
        //        {
        //            result = DB16; // Ngược lại, trả về DB16
        //        }
        //    }

        //    return result; // Trả về kết quả
        //}
        //public double TTCCDT_HT_ChieuCaoTuongCChoDa(string DA16, double DB16, double AE16, double AH16, double AN16, double AR16, double BC16, double BG16, double DD16, double EQ16, double ER16, double ES16)
        //{
        //    // Gọi hàm GetTenDanhMucById và chuẩn hóa giá trị của DA16
        //    DA16 = GetTenDanhMucById(DA16).ToUpper().Trim();

        //    double result = 0;

        //    // Kiểm tra điều kiện và tính toán kết quả
        //    if (DA16 == "ĐÀO ĐÁ")
        //    {
        //        if (DB16 <= AE16 + AH16)
        //        {
        //            result = 0; // Trả về 0 nếu DB16 nhỏ hơn hoặc bằng AE16 + AH16
        //        }
        //        else if (DB16 >= AE16 + AH16 + AN16 + AR16 + BC16 + BG16)
        //        {
        //            result = AN16 + AR16 + BC16 + BG16; // Trả về tổng của AN16, AR16, BC16 và BG16
        //        }
        //        else
        //        {
        //            result = DB16 - (AE16 + AH16); // Trả về hiệu giữa DB16 và tổng của AE16 + AH16
        //        }
        //    }
        //    else if (DA16 == "ĐÀO ĐẤT + ĐÀO ĐÁ")
        //    {
        //        if (DD16 >= AE16 + AH16 + AN16 + AR16 + BC16 + BG16)
        //        {
        //            result = EQ16 < (AN16 + AR16 + BC16 + BG16) ? (AN16 + AR16 + BC16 + BG16 - EQ16) : 0; // Tính toán theo điều kiện EQ16
        //        }
        //        else
        //        {
        //            result = DB16 - (ER16 + ES16); // Trả về hiệu giữa DB16 và tổng của ER16 + ES16
        //        }
        //    }

        //    return result; // Trả về kết quả
        //}
        //public double CalculTTCCDT_HT_TongCCaoDatCChoateHốThu(string H16, double EO16, double EP16, double EQ16)
        //{
        //    // Gọi hàm GetTenDanhMucById và chuẩn hóa giá trị của H16
        //    H16 = GetTenDanhMucById(H16).ToUpper().Trim();

        //    // Kiểm tra điều kiện và tính toán kết quả
        //    if (H16 == "HỐ THU")
        //    {
        //        return EO16 + EP16 + EQ16; // Trả về tổng của EO16, EP16 và EQ16
        //    }

        //    return 0; // Trả về 0 nếu không thỏa điều kiện
        //}
        //public double TTCCDT_HT_TongCCaoDaCCho(string H16, double ER16, double ES16, double ET16)
        //{
        //    // Gọi hàm GetTenDanhMucById và chuẩn hóa giá trị của H16
        //    H16 = GetTenDanhMucById(H16).ToUpper().Trim();

        //    // Kiểm tra điều kiện và tính toán kết quả
        //    if (H16 == "HỐ THU")
        //    {
        //        return ER16 + ES16 + ET16; // Trả về tổng của ER16, ES16 và ET16
        //    }

        //    return 0; // Trả về 0 nếu không thỏa điều kiện
        //}
        //public double TTCCDT_HT_ChenhDatSoVoiThietKe(string H16, double DB16, double EV16)
        //{
        //    // Gọi hàm GetTenDanhMucById và chuẩn hóa giá trị của H16
        //    H16 = GetTenDanhMucById(H16).ToUpper().Trim();

        //    // Kiểm tra điều kiện và tính toán kết quả
        //    if (H16 == "HỐ THU")
        //    {
        //        return DB16 - EV16; // Trả về hiệu giữa DB16 và EV16
        //    }

        //    return 0; // Trả về 0 nếu không thỏa điều kiện
        //}
        //public double TTCCDT_HT_ChenhDaSoVoiThietKe(string H16, double DC16, double EU16)
        //{
        //    // Gọi hàm GetTenDanhMucById và chuẩn hóa giá trị của H16
        //    H16 = GetTenDanhMucById(H16).ToUpper().Trim();

        //    // Kiểm tra điều kiện và tính toán kết quả
        //    if (H16 == "HỐ THU")
        //    {
        //        return DC16 - EU16; // Trả về hiệu giữa DC16 và EU16
        //    }

        //    return 0; // Trả về 0 nếu không thỏa điều kiện
        //}
        //public double TTDTD_BV_CRongDaoDayLonDat(string H16, double DC16, double EZ16, double FA16, double FB16, double EY16)
        //{
        //    // Gọi hàm GetTenDanhMucById và chuẩn hóa giá trị của H16
        //    H16 = GetTenDanhMucById(H16).ToUpper().Trim();

        //    // Kiểm tra điều kiện và tính toán kết quả
        //    if (H16 == "BÓ VỈA HÀM ẾCH")
        //    {
        //        if (DC16 > 0)
        //        {
        //            // Tính toán và làm tròn kết quả về 2 chữ số thập phân
        //            double result = (DC16 * EZ16 * (FA16 + FB16)) + EY16;
        //            return Math.Round(result, 2); // Làm tròn kết quả
        //        }
        //    }

        //    return 0; // Trả về 0 nếu không thỏa điều kiện
        //}
        //public double TTDTD_BV_CRongDaoDayLonDa(string H16, double DB16, double EZ16, double FA16, double FB16, double EY16, double FC16)
        //{
        //    // Gọi hàm GetTenDanhMucById và chuẩn hóa giá trị của H16
        //    H16 = GetTenDanhMucById(H16).ToUpper().Trim();

        //    // Kiểm tra điều kiện và tính toán kết quả
        //    if (H16 == "BÓ VỈA HÀM ẾCH")
        //    {
        //        if (DB16 > 0)
        //        {
        //            if (FC16 > 0)
        //            {
        //                // Tính toán và làm tròn kết quả về 2 chữ số thập phân
        //                double result = (DB16 * EZ16 * (FA16 + FB16)) + FC16;
        //                return Math.Round(result, 2); // Làm tròn kết quả
        //            }
        //            else
        //            {
        //                // Tính toán và làm tròn kết quả về 2 chữ số thập phân
        //                double result = (DB16 * EZ16 * (FA16 + FB16)) + EY16;
        //                return Math.Round(result, 2); // Làm tròn kết quả
        //            }
        //        }
        //    }

        //    return 0; // Trả về 0 nếu không thỏa điều kiện
        //}
        //public double TTDTD_BV_DienTichDaoDat(string H16, double FC16, double EY16, double DC16)
        //{
        //    // Gọi hàm GetTenDanhMucById và chuẩn hóa giá trị của H16
        //    H16 = GetTenDanhMucById(H16).ToUpper().Trim();

        //    // Kiểm tra điều kiện và tính toán kết quả
        //    if (H16 == "BÓ VỈA HÀM ẾCH")
        //    {
        //        // Tính toán và làm tròn kết quả về 2 chữ số thập phân
        //        double result = (FC16 + EY16) * (DC16 / 2);
        //        return Math.Round(result, 2); // Làm tròn kết quả
        //    }

        //    return 0; // Trả về 0 nếu không thỏa điều kiện
        //}
        //public double TTDTD_BV_DienTichDaoDa(string H16, double FC16, double FD16, double EY16, double DB16)
        //{
        //    // Gọi hàm GetTenDanhMucById và chuẩn hóa giá trị của H16
        //    H16 = GetTenDanhMucById(H16).ToUpper().Trim();

        //    // Kiểm tra điều kiện và tính toán kết quả
        //    if (H16 == "BÓ VỈA HÀM ẾCH")
        //    {
        //        if (FC16 > 0)
        //        {
        //            // Tính toán và làm tròn kết quả về 2 chữ số thập phân
        //            double result = (FD16 + FC16) * (DB16 / 2);
        //            return Math.Round(result, 2); // Làm tròn kết quả
        //        }
        //        else
        //        {
        //            // Nếu FC16 không lớn hơn 0
        //            double result = (FD16 + EY16) * (DB16 / 2);
        //            return Math.Round(result, 2); // Làm tròn kết quả
        //        }
        //    }

        //    return 0; // Trả về 0 nếu không thỏa điều kiện
        //}
        //public double TTDTD_BV_TongDtDao(double FE16, double FF16, string H16)
        //{
        //    double result = 0;

        //    // Lấy tên danh mục từ Id nếu cần so sánh chuỗi
        //    H16 = GetTenDanhMucById(H16);

        //    // Kiểm tra điều kiện
        //    if (H16.ToUpper().Trim() == "Bó vỉa hàm ếch".ToUpper())
        //    {
        //        result = FE16 + FF16; // Nếu H16 là "Bó vỉa hàm ếch", tính FE16 + FF16
        //    }
        //    else
        //    {
        //        result = 0; // Nếu không, trả về 0
        //    }

        //    return Math.Round(result, 2); // Làm tròn kết quả về 2 chữ số thập phân
        //}
        //public double TTDTD_HT_CRongDaoDayLonDat(double DC16, double EZ16, double FA16, double FB16, double EY16, string DA16)
        //{
        //    double result = 0;

        //    // Lấy tên danh mục từ Id nếu cần so sánh chuỗi
        //    DA16 = GetTenDanhMucById(DA16);

        //    // Kiểm tra điều kiện
        //    if (DA16.ToUpper().Trim() == "Đào đất".ToUpper() || DA16.ToUpper().Trim() == "Đào đất + đào đá".ToUpper())
        //    {
        //        result = (DC16 * EZ16 * (FA16 + FB16)) + EY16; // Nếu điều kiện thỏa mãn, tính theo công thức
        //    }
        //    else
        //    {
        //        result = 0; // Nếu không, trả về 0
        //    }

        //    return Math.Round(result, 2); // Làm tròn kết quả về 2 chữ số thập phân
        //}


        //public double TTDTD_HT_CRongDaoDayLonDa(double DB16, double EZ16, double FA16, double FB16, double FH16, double EY16, string DA16)
        //{
        //    double result = 0;

        //    // Lấy tên danh mục từ Id nếu cần so sánh chuỗi
        //    DA16 = GetTenDanhMucById(DA16);

        //    // Kiểm tra điều kiện
        //    if (DA16.ToUpper().Trim() == "Đào đá".ToUpper() || DA16.ToUpper().Trim() == "Đào đất + đào đá".ToUpper())
        //    {
        //        if (FH16 > 0) // Kiểm tra điều kiện thứ hai
        //        {
        //            result = (DB16 * EZ16 * (FA16 + FB16)) + FH16; // Tính toán nếu FH16 > 0
        //        }
        //        else
        //        {
        //            result = (DB16 * EZ16 * (FA16 + FB16)) + EY16; // Tính toán nếu FH16 <= 0
        //        }
        //    }
        //    else
        //    {
        //        result = 0; // Nếu không, trả về 0
        //    }

        //    return Math.Round(result, 2); // Làm tròn kết quả về 2 chữ số thập phân
        //}
        //public double TTDTD_HT_DienTichDaoDat(double FH16, double EY16, double DC16)
        //{
        //    double result = (FH16 + EY16) * (DC16 / 2); // Tính theo công thức
        //    return Math.Round(result, 2); // Làm tròn kết quả về 2 chữ số thập phân
        //}
        //public double TTDTD_HT_DienTichDaoDa(double FI16, double FH16, double EY16, double DB16)
        //{
        //    double result = 0;

        //    // Kiểm tra điều kiện
        //    if (FH16 > 0)
        //    {
        //        result = (FI16 + FH16) * (DB16 / 2); // Tính toán nếu FH16 > 0
        //    }
        //    else
        //    {
        //        result = (FI16 + EY16) * (DB16 / 2); // Tính toán nếu FH16 <= 0
        //    }

        //    return Math.Round(result, 2); // Làm tròn kết quả về 2 chữ số thập phân
        //}
        //public double TTDTD_HT_TongDtDao(double FJ16, double FK16)
        //{
        //    double result = FJ16 + FK16; // Tính tổng giữa FJ16 và FK16
        //    return Math.Round(result, 2); // Làm tròn kết quả về 2 chữ số thập phân
        //}
        //public double DTDTB_CRongDaoDayLonDat(double FC16, double FH16)
        //{
        //    double result = (FC16 + FH16) / 2; // Tính trung bình giữa FC16 và FH16
        //    return result; // Trả về kết quả
        //}
        //public double DTDTB_CRongDaoDayLonDa(double FD16, double FI16)
        //{
        //    double result = (FD16 + FI16) / 2; // Tính trung bình giữa FD16 và FI16
        //    return result; // Trả về kết quả
        //}
        //public double DTDTB_DienTichDaoDat(double FE16, double FJ16)
        //{
        //    double result = (FE16 + FJ16) / 2; // Tính trung bình giữa FE16 và FJ16
        //    return result; // Trả về kết quả
        //}
        //public double DTDTB_DienTichDaoDa(double FF16, double FK16)
        //{
        //    double result = (FF16 + FK16) / 2; // Tính trung bình giữa FF16 và FK16
        //    return result; // Trả về kết quả
        //}
        //public double DTDTB_TongDtDao(double FG16, double FL16)
        //{
        //    double result = (FG16 + FL16) / 2; // Tính trung bình giữa FG16 và FL16
        //    return result; // Trả về kết quả
        //}
        //public double TTKLD_BV_KlDaoDat(double K16, double FE16, double Q16)
        //{
        //    double result;

        //    // Kiểm tra điều kiện
        //    if (K16 > 0)
        //    {
        //        result = FE16 * K16; // Tính toán nếu K16 > 0
        //    }
        //    else
        //    {
        //        result = FE16 * Q16; // Tính toán nếu K16 <= 0
        //    }

        //    return Math.Round(result, 2); // Làm tròn kết quả về 2 chữ số thập phân
        //}
        //public double TTKLD_BV_KlDaoDa(double K16, double FF16, double Q16)
        //{
        //    double result;

        //    // Kiểm tra điều kiện
        //    if (K16 > 0)
        //    {
        //        result = FF16 * K16; // Tính toán nếu K16 > 0
        //    }
        //    else
        //    {
        //        result = FF16 * Q16; // Tính toán nếu K16 <= 0
        //    }

        //    return Math.Round(result, 2); // Làm tròn kết quả về 2 chữ số thập phân
        //}
        //public double TTKLD_BV_TongKlDao(double FR16, double FS16)
        //{
        //    double result = FR16 + FS16; // Tính tổng giữa FR16 và FS16
        //    return Math.Round(result, 2); // Làm tròn kết quả về 2 chữ số thập phân
        //}
        //public double TTKLD_BV_KlChiemChoDat(double EE16, double K16, double L16, double N16, double O16, double EF16, double EG16, double Q16, double R16)
        //{
        //    double result = (EE16 * K16 * L16) + (N16 * O16 * EF16) + (EG16 * Q16 * R16); // Tính giá trị theo công thức
        //    return Math.Round(result, 2); // Làm tròn kết quả về 2 chữ số thập phân
        //}
        //public double TTKLD_BV_KlChiemChoDa(double EH16, double K16, double L16, double N16, double O16, double EI16, double EJ16, double Q16, double R16)
        //{
        //    double result = (EH16 * K16 * L16) + (N16 * O16 * EI16) + (EJ16 * Q16 * R16); // Tính giá trị theo công thức
        //    return Math.Round(result, 2); // Làm tròn kết quả về 2 chữ số thập phân
        //}
        //public double TTKLD_BV_TongChiemCho(double FU16, double FV16)
        //{
        //    double result = FU16 + FV16; // Tính tổng giữa FU16 và FV16
        //    return Math.Round(result, 2); // Làm tròn kết quả về 2 chữ số thập phân
        //}
        //public double TTKLD_BV_KlDapTraDat(double FR16, double FU16)
        //{
        //    double result = FR16 - FU16; // Tính hiệu giữa FR16 và FU16
        //    return Math.Round(result, 2); // Làm tròn kết quả về 2 chữ số thập phân
        //}
        //public double TTKLD_BV_KlDapTraDa(double FS16, double FV16)
        //{
        //    double result = FS16 - FV16; // Tính hiệu giữa FS16 và FV16
        //    return Math.Round(result, 2); // Làm tròn kết quả về 2 chữ số thập phân
        //}

        //public double TTKLD_BV_TongDapTra(double FT16, double FW16)
        //{
        //    double result = FT16 - FW16; // Tính hiệu giữa FT16 và FW16
        //    return Math.Round(result, 2); // Làm tròn kết quả về 2 chữ số thập phân
        //}
        //public double TTKLD_BV_KlThuaDat(double FU16)
        //{
        //    return Math.Round(FU16, 2); // Làm tròn FU16 về 2 chữ số thập phân
        //}
        //public double TTKLD_BV_KlThuaDa(double FV16)
        //{
        //    return Math.Round(FV16, 2); // Làm tròn FV16 về 2 chữ số thập phân
        //}
        //public double TTKLD_BV_TongThua(double FW16)
        //{
        //    return Math.Round(FW16, 2); // Làm tròn FW16 về 2 chữ số thập phân
        //}
        //public double TTKLD_HT_KlDaoDat(string E16, double AC16, double FJ16, double AA16)
        //{
        //    double result;

        //    // Sử dụng GetTenDanhMucById và chuyển đổi thành chữ hoa, loại bỏ khoảng trắng
        //    E16 = GetTenDanhMucById(E16).ToUpper().Trim();

        //    // Kiểm tra điều kiện RIGHT(E16, 2) = "=G"
        //    if (E16.Substring(E16.Length - 2) == "=G")
        //    {
        //        result = 0; // Nếu điều kiện đúng, gán result là 0
        //    }
        //    else
        //    {
        //        // Kiểm tra AC16 > 0
        //        if (AC16 > 0)
        //        {
        //            result = FJ16 * AC16; // Tính FJ16 * AC16
        //        }
        //        else
        //        {
        //            result = FJ16 * AA16; // Tính FJ16 * AA16
        //        }
        //    }

        //    return Math.Round(result, 2); // Làm tròn kết quả về 2 chữ số thập phân
        //}
        //public double TTKLD_HT_KlDaoDa(string E16, double AC16, double FK16, double AA16)
        //{
        //    double result;

        //    // Sử dụng GetTenDanhMucById và chuyển đổi thành chữ hoa, loại bỏ khoảng trắng
        //    E16 = GetTenDanhMucById(E16).ToUpper().Trim();

        //    // Kiểm tra điều kiện RIGHT(E16, 2) = "=G"
        //    if (E16.Substring(E16.Length - 2) == "=G")
        //    {
        //        result = 0; // Nếu điều kiện đúng, gán result là 0
        //    }
        //    else
        //    {
        //        // Kiểm tra AC16 > 0
        //        if (AC16 > 0)
        //        {
        //            result = FK16 * AC16; // Tính FK16 * AC16
        //        }
        //        else
        //        {
        //            result = FK16 * AA16; // Tính FK16 * AA16
        //        }
        //    }

        //    return Math.Round(result, 2); // Làm tròn kết quả về 2 chữ số thập phân
        //}
        //public double TTKLD_HT_TongKlDao(double GD16, double GE16)
        //{
        //    double result = GD16 + GE16; // Tính tổng giữa GD16 và GE16
        //    return Math.Round(result, 2); // Làm tròn kết quả về 2 chữ số thập phân
        //}
        //public double TTKLD_HT_KlChiemChoDat(string E16, double AC16, double EO16, double AD16, double AF16, double AG16, double EP16, double EQ16, double AA16, double AB16)
        //{
        //    double result;

        //    // Sử dụng GetTenDanhMucById và chuyển đổi thành chữ hoa, loại bỏ khoảng trắng
        //    E16 = GetTenDanhMucById(E16).ToUpper().Trim();

        //    // Kiểm tra điều kiện RIGHT(E16, 2) = "=G"
        //    if (E16.Substring(E16.Length - 2) == "=G")
        //    {
        //        result = 0; // Nếu điều kiện đúng, gán result là 0
        //    }
        //    else
        //    {
        //        // Kiểm tra AC16 > 0
        //        if (AC16 > 0)
        //        {
        //            result = (EO16 * AC16 * AD16) + (AF16 * AG16 * EP16) + (EQ16 * AA16 * AB16); // Tính toán khi AC16 > 0
        //        }
        //        else
        //        {
        //            result = (EO16 * AA16 * AB16) + (AA16 * AB16 * EP16) + (EQ16 * AA16 * AB16); // Tính toán khi AC16 <= 0
        //        }
        //    }

        //    return Math.Round(result, 2); // Làm tròn kết quả về 2 chữ số thập phân
        //}
        //public double TTKLD_HT_KlChiemChoDa(string E16, double AC16, double ER16, double AD16, double AF16, double AG16, double ES16, double ET16, double AA16, double AB16)
        //{
        //    double result;

        //    // Sử dụng GetTenDanhMucById và chuyển đổi thành chữ hoa, loại bỏ khoảng trắng
        //    E16 = GetTenDanhMucById(E16).ToUpper().Trim();

        //    // Kiểm tra điều kiện RIGHT(E16, 2) = "=G"
        //    if (E16.Substring(E16.Length - 2) == "=G")
        //    {
        //        result = 0; // Nếu điều kiện đúng, gán result là 0
        //    }
        //    else
        //    {
        //        // Kiểm tra AC16 > 0
        //        if (AC16 > 0)
        //        {
        //            result = (ER16 * AC16 * AD16) + (AF16 * AG16 * ES16) + (ET16 * AA16 * AB16); // Tính toán khi AC16 > 0
        //        }
        //        else
        //        {
        //            result = (ER16 * AA16 * AB16) + (AA16 * AB16 * ES16) + (ET16 * AA16 * AB16); // Tính toán khi AC16 <= 0
        //        }
        //    }

        //    return Math.Round(result, 2); // Làm tròn kết quả về 2 chữ số thập phân
        //}
        //public double TTKLD_HT_TongChiemCho(double GG16, double GH16)
        //{
        //    double result = GG16 + GH16; // Tính tổng giữa GG16 và GH16
        //    return Math.Round(result, 2); // Làm tròn kết quả về 2 chữ số thập phân
        //}
        //public double TTKLD_HT_KlDapTraDat(double GD16, double GG16)
        //{
        //    double result = GD16 - GG16; // Tính hiệu giữa GD16 và GG16
        //    return Math.Round(result, 2); // Làm tròn kết quả về 2 chữ số thập phân
        //}
        //public double TTKLD_HT_KlDapTraDa(double GE16, double GH16)
        //{
        //    double result = GE16 - GH16; // Tính hiệu giữa GE16 và GH16
        //    return Math.Round(result, 2); // Làm tròn kết quả về 2 chữ số thập phân
        //}
        //public double TTKLD_HT_TongDapTra(double GJ16, double GK16)
        //{
        //    double result = GJ16 + GK16; // Tính tổng giữa GJ16 và GK16
        //    return Math.Round(result, 2); // Làm tròn kết quả về 2 chữ số thập phân
        //}
        //public double TTKLDTB_KlDaoDat(double FR16, double GD16)
        //{
        //    double result = (FR16 + GD16) / 2; // Tính trung bình giữa FR16 và GD16
        //    return result; // Trả về kết quả
        //}
        //public double TTKLDTB_KlDaoDa(double FS16, double GE16)
        //{
        //    double result = (FS16 + GE16) / 2; // Tính trung bình giữa FS16 và GE16
        //    return result; // Trả về kết quả
        //}
        //public double TTKLDTB_TongKlDao(double FT16, double GF16)
        //{
        //    double result = (FT16 + GF16) / 2; // Tính trung bình giữa FT16 và GF16
        //    return result; // Trả về kết quả
        //}
        //public double TTKLDTB_KlChiemChoDat(double FU16, double GG16)
        //{
        //    double result = (FU16 + GG16) / 2; // Tính trung bình giữa FU16 và GG16
        //    return result; // Trả về kết quả
        //}
        //public double TTKLDTB_KlChiemChoDa(double FV16, double GH16)
        //{
        //    double result = (FV16 + GH16) / 2; // Tính trung bình giữa FV16 và GH16
        //    return result; // Trả về kết quả
        //}
        //public double TTKLDTB_TongChiemCho(double FW16, double GI16)
        //{
        //    double result = (FW16 + GI16) / 2; // Tính trung bình giữa FW16 và GI16
        //    return Math.Round(result, 2);
        //}
        //public double TTKLDTB_KlDapTraDat(double FX16, double GJ16)
        //{
        //    double result = (FX16 + GJ16) / 2; // Tính trung bình giữa FX16 và GJ16
        //    return Math.Round(result, 2);
        //}
        //public double TTKLDTB_KlDapTraDa(double FY16, double GK16)
        //{
        //    double result = (FY16 + GK16) / 2; // Tính trung bình giữa FY16 và GK16
        //    return Math.Round(result, 2);
        //}
        //public double TTKLDTB_TongDapTra(double FZ16, double GL16)
        //{
        //    double result = (FZ16 + GL16) / 2; // Tính trung bình giữa FZ16 và GL16
        //    return Math.Round(result, 2);
        //}
        //public double TTKLDTB_KlThuaDat(double GA16, double GM16)
        //{
        //    double result = (GA16 + GM16) / 2; // Tính trung bình giữa GA16 và GM16
        //    return Math.Round(result, 2);
        //}
        //public double TTKLDTB_KlThuaDa(double GB16, double GN16)
        //{
        //    double result = (GB16 + GN16) / 2; // Tính trung bình giữa GB16 và GN16
        //    return Math.Round(result, 2);
        //}
        //public double TTKLDTB_TongThua(double GC16, double GO16)
        //{
        //    double result = (GC16 + GO16) / 2; // Tính trung bình giữa GC16 và GO16
        //    return Math.Round(result, 2);
        //}
        //public double TTCD_SlCauKienTinhKl(double IF16, double IE16, string HB16, string IJ16)
        //{
        //    // So sánh và xử lý giá trị theo điều kiện
        //    double result = 0;
        //    HB16 = GetTenDanhMucById(HB16).ToUpper().Trim(); // Chuyển đổi giá trị HB16
        //    if (HB16 == "CỐNG TRÒN" || HB16 == "CỐNG HỘP")
        //    {
        //        if (IJ16 == "Thêm 01")
        //        {
        //            result = IF16 + IE16; // Trả về tổng IF16 và IE16
        //        }

        //    }
        //    return Math.Round(result, 2);
        //}
        //public double TTDC_KL_TongSoLuongDeCong(double HP16, double HG16)
        //{
        //    double result = HP16 * HG16; // Tính tích giữa HP16 và HG16
        //    return Math.Round(result, 2);
        //}
        //public double TTDC_KL_TongKlDeCong(double HQ16, double HR16)
        //{
        //    double result = HQ16 * HR16; // Tính tích giữa HQ16 và HR16
        //    return Math.Round(result, 2); // Làm tròn kết quả về 2 chữ số thập phân
        //}
        //public double TTCTCT_CCaoCauKien(double HT16, double HU16, double HV16)
        //{
        //    double result = (HT16 * HU16) + HV16; // Tính tổng giữa tích HT16 và HU16 với HV16
        //    return Math.Round(result, 2); // Làm tròn kết quả về 2 chữ số thập phân
        //}
        //public double TTCTCT_TongCCaoCong(double HW16, double HX16, double HZ16, double IB16)
        //{
        //    double result = HW16 + HX16 + HZ16 + IB16; // Tính tổng giữa HW16, HX16, HZ16 và IB16
        //    return Math.Round(result, 2); // Làm tròn kết quả về 2 chữ số thập phân
        //}
        //public int TTTKLCKCTH_SlCauKienNguyen(string HB16, double HE16, double HF16, double ID16)
        //{
        //    HB16 = GetTenDanhMucById(HB16).ToUpper().Trim();
        //    if (HB16.ToUpper().Trim() == "CỐNG TRÒN" || HB16.ToUpper().Trim() == "CỐNG HỘP")
        //    {
        //        return (int)(HE16 / (HF16 + ID16)); // Tính thương và lấy phần nguyên
        //    }
        //    return 0; // Trả về 0 nếu không thỏa mãn điều kiện
        //}
        //public double TTTKLCKCTH_CDaiCan(string HB16, double IF16, double IE16, double ID16)
        //{
        //    HB16 = GetTenDanhMucById(HB16).ToUpper().Trim();

        //    double result = 0; // Khởi tạo biến result

        //    if (HB16 == "CỐNG TRÒN" || HB16 == "CỐNG HỘP")
        //    {
        //        result = (IF16 - IE16) * ID16; // Tính hiệu và nhân với ID16
        //    }

        //    return Math.Round(result, 2); // Làm tròn kết quả về 2 chữ số thập phân và trả về
        //}
        //public double TTTKLCKCTH_TongCDai(string HB16, double IF16, double HF16, double IG16)
        //{
        //    HB16 = GetTenDanhMucById(HB16).ToUpper().Trim(); // Sử dụng GetTenDanhMucById và chuẩn hóa chuỗi

        //    double result = 0; // Khởi tạo biến result

        //    if (HB16 == "CỐNG TRÒN" || HB16 == "CỐNG HỘP")
        //    {
        //        result = (IF16 * HF16) + IG16; // Tính toán theo công thức
        //    }

        //    return Math.Round(result, 2); // Làm tròn kết quả về 2 chữ số thập phân và trả về
        //}
        //public double TTTKLCKCTH_CDaiThucTe(string HB16, double IH16, double HE16)
        //{
        //    HB16 = GetTenDanhMucById(HB16).ToUpper().Trim(); // Sử dụng GetTenDanhMucById và chuẩn hóa chuỗi

        //    double result = 0; // Khởi tạo biến result

        //    if (HB16 == "CỐNG TRÒN" || HB16 == "CỐNG HỘP")
        //    {
        //        result = IH16 - HE16; // Tính hiệu giữa IH16 và HE16
        //    }

        //    return Math.Round(result, 2); // Làm tròn kết quả về 2 chữ số thập phân và trả về
        //}
        //public string TTTKLCKCTH_OngCongCanThem(double II16)
        //{
        //    if (II16 < -0.1)
        //    {
        //        return "Thêm 01"; // Trả về "Thêm 01" nếu II16 < -0.1
        //    }
        //    else
        //    {
        //        return "Đủ"; // Trả về "Đủ" nếu không
        //    }
        //}
        //public double TTTKLCKCTH_CDaiConThua(double HG16, double IE16, double ID16, double HF16, double HE16, string HB16)
        //{
        //    double result = 0;
        //    HB16 = GetTenDanhMucById(HB16).ToUpper().Trim();
        //    // Kiểm tra điều kiện cho HB16
        //    if (HB16 == "Cống tròn" || HB16 == "Cống hộp")
        //    {
        //        // Tính toán theo công thức
        //        result = ((HG16 - IE16) * ID16) + (HG16 * HF16) - HE16;
        //    }

        //    return Math.Round(result, 2); // Làm tròn kết quả về 2 chữ số thập phân
        //}
        //public double TTKTHHCHR_Than_CCaoTuongRanh(string HB16, double LF16, double MH16)
        //{
        //    double result = 0;
        //    HB16 = GetTenDanhMucById(HB16).ToUpper().Trim();
        //    // Kiểm tra điều kiện cho HB16
        //    if (HB16 == "Rãnh xây" || HB16 == "Rãnh bê tông")
        //    {
        //        // Tính trung bình
        //        result = (LF16 + MH16) / 2;
        //    }

        //    return Math.Round(result, 2); // Làm tròn kết quả về 2 chữ số thập phân
        //}
        //public double TTKTHHCHR_Than_CCaoTuongGop(double IY16, double IZ16)
        //{
        //    double result = IY16 + IZ16; // Tính tổng giữa IY16 và IZ16
        //    return Math.Round(result, 2); // Làm tròn kết quả về 2 chữ số thập phân
        //}
        //public double TTKTHHCHR_Chat_CCaoChatMatTrong(string IN16, string IL16, string IM16, double JA16, double JB16, double JD16)
        //{
        //    double result = 0;

        //    IN16 = GetTenDanhMucById(IN16).ToUpper().Trim();
        //    IL16 = GetTenDanhMucById(IL16).ToUpper().Trim();
        //    IM16 = GetTenDanhMucById(IM16).ToUpper().Trim();

        //    if (IN16 == "CÓ" && IL16 == "TƯỜNG XÂY GẠCH")
        //    {
        //        if (IM16 == "KHÔNG MŨ MỐ")
        //        {
        //            result = JA16;
        //        }
        //        else
        //        {
        //            result = JA16 + JB16 + JD16;
        //        }
        //    }
        //    else if (IN16 == "KHÔNG" && IM16 == "MŨ MỐ XÂY GẠCH")
        //    {
        //        result = JD16;
        //    }

        //    return result;
        //}
        //public double TTKTHHCHR_Chat_CCaoChatMatNgoai(string IO16, string IL16, string IM16, double JA16, double JB16, double JD16, double JE16)
        //{
        //    double result = 0;

        //    IO16 = GetTenDanhMucById(IO16).ToUpper().Trim();
        //    IL16 = GetTenDanhMucById(IL16).ToUpper().Trim();
        //    IM16 = GetTenDanhMucById(IM16).ToUpper().Trim();

        //    if (IO16 == "CÓ" && IL16 == "TƯỜNG XÂY GẠCH")
        //    {
        //        if (IM16 == "KHÔNG MŨ MỐ")
        //        {
        //            result = JA16;
        //        }
        //        else
        //        {
        //            result = JA16 + JB16 + JD16;
        //        }
        //    }
        //    else if (IO16 == "KHÔNG" && IM16 == "MŨ MỐ XÂY GẠCH")
        //    {
        //        result = JD16 + JE16;
        //    }

        //    return result;
        //}
        //public double TTKTHHCHR_TongChieuCao(double IP16, double IR16, double IT16, double JA16, double JB16, double JD16)
        //{
        //    double result = IP16 + IR16 + IT16 + JA16 + JB16 + JD16; // Tính tổng các giá trị
        //    return Math.Round(result, 2); // Làm tròn kết quả về 2 chữ số thập phân
        //}
        //public double TTTDCHR_1_SoLuong(string HB16, double KC16)
        //{
        //    HB16 = GetTenDanhMucById(HB16).ToUpper().Trim(); // Chuyển đổi giá trị HB16
        //    double result = 0; // Khởi tạo kết quả

        //    // Kiểm tra điều kiện
        //    if (HB16 == "RÃNH XÂY" || HB16 == "RÃNH BÊ TÔNG" || HB16 == "CỐNG HỘP")
        //    {
        //        result = KC16; // Gán giá trị KC16 nếu điều kiện thỏa mãn
        //    }

        //    return result; // Trả về kết quả
        //}


    }
}
