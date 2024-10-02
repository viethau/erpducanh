using DucAnhERP.Components.Pages.NghiepVuCongTrinh;
using DucAnhERP.Models;
using DucAnhERP.ViewModel;
using System.Collections.Generic;
using static OfficeOpenXml.ExcelErrorValue;

namespace DucAnhERP.Helpers
{
    public class DSNuocMuaConversionHelper
    {
        public List<DanhMuc> listDanhMuc = new();
        public string GetTenDanhMucById(string id = "")
        {

            var danhMuc = listDanhMuc.FirstOrDefault(dm => dm.Id == id);
            return danhMuc != null ? danhMuc.Ten : "";
        }

        public async Task<List<NuocMua>> ConvertDSNuocMua(List<NuocMua> list, List<DanhMuc> listDM)
        {
            listDanhMuc = listDM;
            List<NuocMua> listNuocMua = new List<NuocMua>();

            if (list == null || list.Count == 0)
            {
                Console.WriteLine("Danh sách trống.");
                return listNuocMua; // Trả về danh sách trống khi danh sách đầu vào rỗng
            }


            //TTTDCongHoRanh_CDai1(
            //double[] TTTDCongHoRanh_ChieuDaiThucTes,
            //string[] ThongTinDuongTruyenDan_HinhThucTruyenDans,
            //string[] TTTDCongHoRanh_XacDinhOngCongCanThems,
            //string ThongTinDuongTruyenDan_HinhThucTruyenDan,
            //string TTTDCongHoRanh_XacDinhOngCongCanThem)
            //nuocmua.TTTDCongHoRanh_CDai1 = TTTDCongHoRanh_CDai1(ChieuDaiThucTes, HinhThucTruyenDans, XacDinhOngCongCanThems,
            //nuocmua.ThongTinDuongTruyenDan_HinhThucTruyenDan, nuocmua.TTTDCongHoRanh_XacDinhOngCongCanThem);


            double[] ChieuDaiThucTes = {};
            string[] HinhThucTruyenDans = {};
            string[] XacDinhOngCongCanThems = {};

            foreach (var item in list)
            {
                NuocMua nuocmua = await ConvertNuocMua(item, listDM);
                listNuocMua.Add(nuocmua);
            }

            if(listNuocMua.Count > 0)
            {

               ChieuDaiThucTes = listNuocMua
                  .Select(item => item.TTTDCongHoRanh_ChieuDaiThucTe.GetValueOrDefault(0)) // Thay thế giá trị null bằng 0
                  .ToArray();

                HinhThucTruyenDans = listNuocMua
                    .Select(item => !string.IsNullOrEmpty(item.ThongTinDuongTruyenDan_HinhThucTruyenDan)
                                    ? item.ThongTinDuongTruyenDan_HinhThucTruyenDan
                                    : "") 
                    .ToArray();

                XacDinhOngCongCanThems = listNuocMua
                   .Select(item => !string.IsNullOrEmpty(item.TTTDCongHoRanh_XacDinhOngCongCanThem)
                                   ? item.TTTDCongHoRanh_XacDinhOngCongCanThem
                                   : "") 
                   .ToArray();

                foreach (var item in listNuocMua)
                {
                    item.TTTDCongHoRanh_CDai1 = TTTDCongHoRanh_CDai1(ChieuDaiThucTes, HinhThucTruyenDans, XacDinhOngCongCanThems,item.ThongTinDuongTruyenDan_HinhThucTruyenDan, item.TTTDCongHoRanh_XacDinhOngCongCanThem);
                }
            }

            return listNuocMua;
        }

        public async Task<NuocMua> ConvertNuocMua(NuocMua item, List<DanhMuc> listDM)
        {
            Double a = 0.0304999999994;
            var b = Math.Round(a, 3);
            var c = Math.Round(b, 2 , MidpointRounding.AwayFromZero);
            listDanhMuc = listDM;
            item.ThongTinCaoDoHoGa_CaoDoHienTrangTruocKhiDao = ThongTinCaoDoHoGa_CaoDoHienTrangTruocKhiDao(item.ThongTinCaoDoHoGa_CaoDoTuNhien??0, item.ThongTinCaoDoHoGa_CaoDoDinhK98??0, item.ThongTinCaoDoHoGa_CdDinhViaHeHoanThien ??0);
            item.ThongTinCaoDoHoGa_CdDinhMong = ThongTinCaoDoHoGa_CdDinhMong(item.ThongTinChungHoGa_HinhThucHoGa, item.ThongTinChungHoGa_HinhThucMongHoGa, item.ThongTinCaoDoHoGa_CdDayHoGa ?? 0, item.DeHoGa_C ??0);
            item.ThongTinCaoDoHoGa_DinhLotMong = ThongTinCaoDoHoGa_DinhLotMong(item.ThongTinChungHoGa_HinhThucMongHoGa, item.ThongTinCaoDoHoGa_CdDinhMong ?? 0, item.BeTongMongHoGa_C ??0);
            item.ThongTinCaoDoHoGa_DayDao = ThongTinCaoDoHoGa_DayDao(item.ThongTinChungHoGa_HinhThucHoGa, item.ThongTinChungHoGa_HinhThucMongHoGa, item.ThongTinCaoDoHoGa_DinhLotMong ?? 0, item.BeTongLotMong_C ?? 0, item.ThongTinCaoDoHoGa_CdDayHoGa ?? 0, item.DeHoGa_C ??0);
            item.ThongTinCaoDoHoGa_CSauDao = ThongTinCaoDoHoGa_CSauDao(item.ThongTinCaoDoHoGa_CaoDoHienTrangTruocKhiDao ?? 0, item.ThongTinCaoDoHoGa_DayDao ??0);
            item.ThongTinVatLieuDaoHoGa_ChieuCaoDaoDat = ThongTinVatLieuDaoHoGa_ChieuCaoDaoDat(item.ThongTinVatLieuDaoHoGa_LoaiVatLieuDao??"", item.ThongTinCaoDoHoGa_CSauDao ?? 0, item.ThongTinVatLieuDaoHoGa_ChieuCaoDaoDa??0);
            item.ThongTinVatLieuDaoHoGa_TongChieuCaoDao = (item.ThongTinVatLieuDaoHoGa_ChieuCaoDaoDa + item.ThongTinVatLieuDaoHoGa_ChieuCaoDaoDat??0);

            item.ThongTinCaoDoHoGa_TongChieuCaoHoGa = ThongTinCaoDoHoGa_TongChieuCaoHoGa(item.ThongTinCaoDoHoGa_CdDinhHoGa ?? 0, item.ThongTinCaoDoHoGa_DayDao ??0);
            item.ThongTinCaoDoHoGa_ChenhCaoDinhHoGaVaHienTrangDao = ThongTinCaoDoHoGa_ChenhCaoDinhHoGaVaHienTrangDao(item.ThongTinCaoDoHoGa_CdDinhHoGa ?? 0, item.ThongTinCaoDoHoGa_CaoDoHienTrangTruocKhiDao ??0);
            item.ThongTinCaoDoHoGa_TongChieuCaoChiemChoDapTra = Math.Round(item.ThongTinCaoDoHoGa_TongChieuCaoHoGa - item.ThongTinCaoDoHoGa_ChenhCaoDinhHoGaVaHienTrangDao ?? 0, 2);
            item.ThongTinCaoDoHoGa_DinhMuMoThotDuoi = ThongTinCaoDoHoGa_DinhMuMoThotDuoi(item.ThongTinCaoDoHoGa_CdDinhHoGa ?? 0, item.MuMoThotTren_C ??0 ,item.ThongTinTamDanHoGa2_C ??0);
            item.ThongTinCaoDoHoGa_DinhTuong = ThongTinCaoDoHoGa_DinhTuong(item.ThongTinCaoDoHoGa_DinhMuMoThotDuoi ?? 0, item.MuMoThotDuoi_C ??0);
            item.ThongTinCaoDoHoGa_DinhTuongDuoiDamGiuaTuong = ThongTinCaoDoHoGa_DinhTuongDuoiDamGiuaTuong(item.DamGiuaHoGa_CCaoDamGiuaTuongSoVoiDayHoGa ?? 0, item.ThongTinCaoDoHoGa_CdDayHoGa ??0);
            item.ThongTinCaoDoHoGa_DinhDamGiuaTuong = ThongTinCaoDoHoGa_DinhDamGiuaTuong(item.DamGiuaHoGa_CCaoDamGiuaTuongSoVoiDayHoGa ?? 0, item.ThongTinCaoDoHoGa_DinhTuongDuoiDamGiuaTuong ?? 0, item.DamGiuaHoGa_C ??0);
            item.ThongTinCaoDoHoGa_CCaoTuong = ThongTinCaoDoHoGa_CCaoTuong(item.DamGiuaHoGa_CCaoDamGiuaTuongSoVoiDayHoGa ?? 0, item.ThongTinCaoDoHoGa_DinhTuong ?? 0, item.ThongTinCaoDoHoGa_CdDayHoGa ?? 0, item.DamGiuaHoGa_C ??0);
            item.TuongHoGa_C = item.ThongTinCaoDoHoGa_CCaoTuong;
            item.ChatMatNgoaiCanh_C = ChatMatNgoaiCanh_C(item.ThongTinChungHoGa_ChatMatNgoai, item.ThongTinChungHoGa_KetCauTuong, item.ThongTinChungHoGa_KetCauMuMo, item.TuongHoGa_C ?? 0, item.DamGiuaHoGa_CdDam ?? 0, item.MuMoThotDuoi_C ?? 0, item.MuMoThotTren_C ?? 0, item.MuMoThotTren_CdTuong ??0);
            item.ChatMatTrong_C = ChatMatTrong_C(item.ThongTinChungHoGa_ChatMatTrong, item.ThongTinChungHoGa_KetCauTuong, item.ThongTinChungHoGa_KetCauMuMo, item.TuongHoGa_C ?? 0, item.DamGiuaHoGa_C ?? 0, item.MuMoThotDuoi_C ?? 0, item.MuMoThotTren_C ??0);

            item.TTCCCCDTHT_ChieuCaoLotDat = TTCCCCDTHT_ChieuCaoLotDat(item.ThongTinVatLieuDaoHoGa_LoaiVatLieuDao??"", item.ThongTinVatLieuDaoHoGa_ChieuCaoDaoDat ?? 0, item.BeTongLotMong_C ??0);
            item.TTCCCCDTHT_ChieuCaoMongDat = TTCCCCDTHT_ChieuCaoMongDat(item.ThongTinVatLieuDaoHoGa_LoaiVatLieuDao??"", item.ThongTinVatLieuDaoHoGa_ChieuCaoDaoDat ?? 0, item.BeTongLotMong_C ?? 0, item.BeTongMongHoGa_C ??0);
            item.TTCCCCDTHT_ChieuCaoTuongDat = TTCCCCDTHT_ChieuCaoTuongDat(item.ThongTinVatLieuDaoHoGa_LoaiVatLieuDao??"", item.ThongTinVatLieuDaoHoGa_ChieuCaoDaoDat ?? 0, item.BeTongLotMong_C ?? 0, item.BeTongMongHoGa_C ?? 0, item.TuongHoGa_C ?? 0, item.DamGiuaHoGa_C ?? 0, item.MuMoThotDuoi_C ?? 0, item.MuMoThotTren_C??0);
            item.TTCCCCDTHT_ChieuCaoLotDa = TTCCCCDTHT_ChieuCaoLotDa(item.ThongTinVatLieuDaoHoGa_LoaiVatLieuDao ?? "", item.ThongTinVatLieuDaoHoGa_ChieuCaoDaoDa ?? 0, item.ThongTinVatLieuDaoHoGa_TongChieuCaoDao ?? 0, item.TTCCCCDTHT_ChieuCaoLotDat ?? 0, item.BeTongLotMong_C ??0);
            item.TTCCCCDTHT_ChieuCaoMongDa = TTCCCCDTHT_ChieuCaoMongDa(item.ThongTinVatLieuDaoHoGa_LoaiVatLieuDao ?? "", item.ThongTinVatLieuDaoHoGa_ChieuCaoDaoDa ?? 0, item.ThongTinVatLieuDaoHoGa_TongChieuCaoDao ?? 0, item.TTCCCCDTHT_ChieuCaoMongDat ?? 0, item.TTCCCCDTHT_ChieuCaoLotDa ?? 0, item.BeTongLotMong_C ?? 0, item.BeTongMongHoGa_C ??0);
            item.TTCCCCDTHT_ChieuCaoTuongDa = TTCCCCDTHT_ChieuCaoTuongDa(item.ThongTinVatLieuDaoHoGa_LoaiVatLieuDao ?? "", item.ThongTinVatLieuDaoHoGa_ChieuCaoDaoDa ?? 0, item.ThongTinVatLieuDaoHoGa_TongChieuCaoDao ?? 0, item.TTCCCCDTHT_ChieuCaoTuongDat ?? 0, item.TTCCCCDTHT_ChieuCaoLotDa ?? 0, item.TTCCCCDTHT_ChieuCaoMongDa ?? 0, item.BeTongLotMong_C ?? 0, item.BeTongMongHoGa_C ?? 0, item.TuongHoGa_C ?? 0, item.DamGiuaHoGa_C ?? 0, item.MuMoThotDuoi_C ?? 0, item.MuMoThotTren_C ??0);
            item.TTCCCCDTHT_TongCieuCaoDat = Math.Round((item.TTCCCCDTHT_ChieuCaoLotDat + item.TTCCCCDTHT_ChieuCaoMongDat + item.TTCCCCDTHT_ChieuCaoTuongDat ?? 0), 2);
            item.TTCCCCDTHT_TongChieuCaoDa = Math.Round((item.TTCCCCDTHT_ChieuCaoLotDa + item.TTCCCCDTHT_ChieuCaoMongDa + item.TTCCCCDTHT_ChieuCaoTuongDa ?? 0), 2);
            item.TTCCCCDTHT_ChenhDatSoVoiTK = Math.Round((item.ThongTinVatLieuDaoHoGa_ChieuCaoDaoDat  - item.TTCCCCDTHT_TongCieuCaoDat ?? 0), 2);
            item.TTCCCCDTHT_ChenhDaSoVoiTK = Math.Round((item.ThongTinVatLieuDaoHoGa_ChieuCaoDaoDa ?? 0 - item.TTCCCCDTHT_TongChieuCaoDa ?? 0), 2);

            item.TTKLD_CRongDaoDayLonDat = TTKLD_CRongDaoDayLonDat(item.ThongTinVatLieuDaoHoGa_LoaiVatLieuDao ?? "", item.ThongTinVatLieuDaoHoGa_ChieuCaoDaoDat ?? 0, item.ThongTinMaiDao_TyLeMoMai ?? 0, item.ThongTinMaiDao_SoCanhMaiTrai ?? 0, item.ThongTinMaiDao_SoCanhMaiPhai ?? 0, item.ThongTinMaiDao_ChieuRongDayDaoNho ??0);
            item.TTKLD_CRongDaoDayLonDa = TinhTTTKLD_CRongDaoDayLonDaoan(item.ThongTinVatLieuDaoHoGa_LoaiVatLieuDao ?? "", item.ThongTinVatLieuDaoHoGa_ChieuCaoDaoDa ?? 0, item.ThongTinMaiDao_TyLeMoMai ?? 0, item.ThongTinMaiDao_SoCanhMaiTrai ?? 0, item.ThongTinMaiDao_SoCanhMaiPhai ?? 0, item.TTKLD_CRongDaoDayLonDat ?? 0, item.ThongTinMaiDao_ChieuRongDayDaoNho ??0);
            item.TTKLD_DienTichDaoDat = TTKLD_DienTichDaoDat(item.TTKLD_CRongDaoDayLonDat ?? 0, item.ThongTinMaiDao_ChieuRongDayDaoNho ?? 0, item.ThongTinVatLieuDaoHoGa_ChieuCaoDaoDat ??0);
            item.TTKLD_DienTichDaoDa = TTKLD_DienTichDaoDa(item.TTKLD_CRongDaoDayLonDa ?? 0, item.TTKLD_CRongDaoDayLonDat ?? 0, item.ThongTinMaiDao_ChieuRongDayDaoNho ?? 0, item.ThongTinVatLieuDaoHoGa_ChieuCaoDaoDa ??0);
            item.TTKLD_TongDtDao = TTKLD_TongDtDao(item.TTKLD_DienTichDaoDat ?? 0, item.TTKLD_DienTichDaoDa ??0);
            //item.DTDCKRD_CKCRongDaoDayLon = DTDCKRD_CKCRongDaoDayLon(item.ThongTinRanhThang_CCaoLotChanKhay, item.ThongTinRanhThang_CCaoMongChanKhay, item.TTMDRanhOngThang_TyLeMoMai1, item.TTMDRanhOngThang_SoCanhMaiTrai1, item.TTMDRanhOngThang_SoCanhMaiPhai1, item.TTMDRanhOngThang_ChieuRongDayDaoNho1??0);
            //item.DTDCKRD_CKDTichDao = DTDCKRD_CKDTichDao(item.DTDCKRD_CKCRongDaoDayLon, item.TTMDRanhOngThang_ChieuRongDayDaoNho1, item.ThongTinRanhThang_CCaoLotChanKhay, item.ThongTinRanhThang_CCaoMongChanKhay, item.ThongTinRanhThang_SoLuongMongChanKhay??0);
            //item.DTDCKRD_CRongDaoDayLon = DTDCKRD_CRongDaoDayLon(item.ThongTinRanhThang_CCaoLotGiangDinh, item.ThongTinRanhThang_CCaoMongGiangDinh, item.TTMDRanhOngThang_TyLeMoMai1, item.TTMDRanhOngThang_SoCanhMaiTrai1, item.TTMDRanhOngThang_SoCanhMaiPhai1, item.TTMDRanhOngThang_ChieuRongDayDaoNho1??0);
            //item.DTDCKRD_DTichDao = DTDCKRD_DTichDao(item.DTDCKRD_CRongDaoDayLon, item.TTMDRanhOngThang_ChieuRongDayDaoNho1, item.ThongTinRanhThang_CCaoLotGiangDinh, item.ThongTinRanhThang_CCaoMongGiangDinh, item.ThongTinRanhThang_SoLuongMongGiangDinh??0);


            item.TTKLD_KlDaoDat = TTKLD_KlDaoDat(item.TTKLD_DienTichDaoDat??0, item.BeTongLotMong_D ?? 0, item.PhuBiHoGa_CDai ?? 0, item.ThongTinChungHoGa_TenHoGaTheoBanVe??"");
            item.TTKLD_KlDaoDa = TTKLD_KlDaoDa(item.TTKLD_DienTichDaoDa ?? 0, item.BeTongLotMong_D ?? 0, item.PhuBiHoGa_CDai ?? 0, item.ThongTinChungHoGa_TenHoGaTheoBanVe??"");
            item.TTKLD_TongKlDao = TTKLD_TongKlDao(item.TTKLD_KlDaoDat ?? 0, item.TTKLD_KlDaoDa ??0);
            item.TTKLD_KlChiemChoDat = TTKLD_KlChiemChoDat(item.ThongTinChungHoGa_TenHoGaTheoBanVe??"", item.BeTongLotMong_D ?? 0, item.TTCCCCDTHT_ChieuCaoLotDat ?? 0, item.BeTongLotMong_R ?? 0, item.BeTongMongHoGa_D ?? 0, item.BeTongMongHoGa_R ?? 0, item.TTCCCCDTHT_ChieuCaoMongDat ?? 0, item.TTCCCCDTHT_ChieuCaoTuongDat ?? 0, item.PhuBiHoGa_CDai ?? 0, item.PhuBiHoGa_CRong ??0);
            item.TTKLD_KlChiemChoDa = TTKLD_KlChiemChoDa(item.ThongTinChungHoGa_TenHoGaTheoBanVe??"", item.BeTongLotMong_D ?? 0, item.TTCCCCDTHT_ChieuCaoLotDa ?? 0, item.BeTongLotMong_R ?? 0, item.BeTongMongHoGa_D ?? 0, item.BeTongMongHoGa_R ?? 0, item.TTCCCCDTHT_ChieuCaoMongDa ?? 0, item.TTCCCCDTHT_ChieuCaoTuongDa ?? 0, item.PhuBiHoGa_CDai ?? 0, item.PhuBiHoGa_CRong ??0);
            item.TTKLD_TongChiemCho = TTKLD_TongChiemCho(item.TTKLD_KlChiemChoDat ?? 0, item.TTKLD_KlChiemChoDa ??0);
            item.TTKLD_KlDapTraDat = TTKLD_KlDapTraDat(item.TTKLD_KlDaoDat ?? 0, item.TTKLD_KlChiemChoDat ??0);
            item.TTKLD_KlDapTraDa = TTKLD_KlDapTraDa(item.TTKLD_KlDaoDa ?? 0, item.TTKLD_KlChiemChoDa ??0);
            item.TTKLD_TongDapTra = TTKLD_TongDapTra(item.TTKLD_KlDapTraDat ?? 0, item.TTKLD_KlDapTraDa ??0);
            item.TTKLD_KlThuaDat = item.TTKLD_KlChiemChoDat;
            item.TTKLD_KlThuaDa = item.TTKLD_KlChiemChoDa;
            item.TTKLD_TongThua = item.TTKLD_KlThuaDat + item.TTKLD_KlThuaDa;

            //item.TTCDSLCauKienDuongTruyenDan_SlCauKienNguyen = TTCDSLCauKienDuongTruyenDan_SlCauKienNguyen(item.ThongTinDuongTruyenDan_HinhThucTruyenDan ?? "", item.TTCDSLCauKienDuongTruyenDan_TongChieuDai, item.TTCDSLCauKienDuongTruyenDan_ChieuDai01CauKien, item.TTCDSLCauKienDuongTruyenDan_ChieuDaiMoiNoiCKien??0);
            //item.TTCDSLCauKienDuongTruyenDan_CDaiCanDeLapDatDuocTheoSoCkNguyen = TTCDSLCauKienDuongTruyenDan_CDaiCanDeLapDatDuocTheoSoCkNguyen(item.ThongTinDuongTruyenDan_HinhThucTruyenDan ?? "", item.TTCDSLCauKienDuongTruyenDan_SlCauKienNguyen, item.TTCDSLCauKienDuongTruyenDan_SoLuongCKienDungDeTinhChieuDaiBoSung, item.TTCDSLCauKienDuongTruyenDan_ChieuDaiMoiNoiCKien??0);
            //item.TTCDSLCauKienDuongTruyenDan_TongCDaiLapDatTheoSoCkNguyen = TTCDSLCauKienDuongTruyenDan_TongCDaiLapDatTheoSoCkNguyen(item.ThongTinDuongTruyenDan_HinhThucTruyenDan ?? "", item.TTCDSLCauKienDuongTruyenDan_SlCauKienNguyen, item.TTCDSLCauKienDuongTruyenDan_ChieuDai01CauKien, item.TTCDSLCauKienDuongTruyenDan_CDaiCanDeLapDatDuocTheoSoCkNguyen??0);
            //item.TTCDSLCauKienDuongTruyenDan_CDaiThucTeConThuaThieuSoVoiCRongLongMuMoHoGa = TTCDSLCauKienDuongTruyenDan_CDaiThucTeConThuaThieuSoVoiCRongLongMuMoHoGa(item.ThongTinDuongTruyenDan_HinhThucTruyenDan ?? "", item.TTCDSLCauKienDuongTruyenDan_TongCDaiLapDatTheoSoCkNguyen, item.TTCDSLCauKienDuongTruyenDan_TongChieuDai??0);
            //item.TTCDSLCauKienDuongTruyenDan_XacDinhOngCongCanThem = TTCDSLCauKienDuongTruyenDan_XacDinhOngCongCanThem(item.TTCDSLCauKienDuongTruyenDan_CDaiThucTeConThuaThieuSoVoiCRongLongMuMoHoGa??0);
            
            //item.TTCDSLCauKienDuongTruyenDan_CDaiConThuaThieuSauTinhTheoCkTinhKl = TTCDSLCauKienDuongTruyenDan_CDaiConThuaThieuSauTinhTheoCkTinhKl(item.ThongTinDuongTruyenDan_HinhThucTruyenDan ?? "", item.TTCDSLCauKienDuongTruyenDan_SlCauKienTinhKl, item.TTCDSLCauKienDuongTruyenDan_SoLuongCKienDungDeTinhChieuDaiBoSung, item.TTCDSLCauKienDuongTruyenDan_ChieuDaiMoiNoiCKien, item.TTCDSLCauKienDuongTruyenDan_ChieuDai01CauKien, item.TTCDSLCauKienDuongTruyenDan_TongChieuDai??0);

            item.ThongTinDeCong_TongSoLuongDC = item.ThongTinDeCong_SlDeCong01CauKienTruyenDan * item.TTCDSLCauKienDuongTruyenDan_SlCauKienTinhKl;
            item.ThongTinDeCong_TongKLDeCong = Math.Round(item.ThongTinDeCong_Kl01DeCong ?? 0 * item.ThongTinDeCong_TongSoLuongDC ?? 0, 2);

            item.ThongTinCauTaoCongTron_CCaoCauKien = ThongTinCauTaoCongTron_CCaoCauKien(item.ThongTinCauTaoCongTron_CDayPhuBi??0, item.ThongTinCauTaoCongTron_SoCanh ?? 0, item.ThongTinCauTaoCongTron_LongSuDung ??0);
            item.ThongTinCauTaoCongTron_TongCCaoCong = ThongTinCauTaoCongTron_TongCCaoCong(item.ThongTinCauTaoCongTron_CCaoCauKien ?? 0, item.ThongTinCauTaoCongTron_CCaoLotMong??0, item.ThongTinCauTaoCongTron_CCaoMong ?? 0, item.ThongTinCauTaoCongTron_CCaoDe ??0);

            item.TTTKLCKCTCH_SLCKNguyen = TTTKLCKCTCH_SLCKNguyen(item.ThongTinDuongTruyenDan_HinhThucTruyenDan ?? "", item.TTCDSLCauKienDuongTruyenDan_TongChieuDai ?? 0, item.TTCDSLCauKienDuongTruyenDan_ChieuDai01CauKien??0, item.TTTKLCKCTCH_CDMoiNoiCKien ?? 0);
            item.TTTKLCKCTCH_CDCanLapDat = TTTKLCKCTCH_CDCanLapDat(item.ThongTinDuongTruyenDan_HinhThucTruyenDan??"", item.TTTKLCKCTCH_SLCKNguyen ?? 0, item.TTTKLCKCTCH_SLCKDungDeTinhCD ?? 0, item.TTTKLCKCTCH_CDMoiNoiCKien ?? 0);
            
            item.TTTKLCKCTCH_TongCD = TTTKLCKCTCH_TongCD(item.ThongTinDuongTruyenDan_HinhThucTruyenDan??"", item.TTTKLCKCTCH_SLCKNguyen ?? 0, item.TTCDSLCauKienDuongTruyenDan_ChieuDai01CauKien ?? 0, item.TTTKLCKCTCH_CDCanLapDat ?? 0);
            item.TTTKLCKCTCH_CDThucTeThuaThieu = TTTKLCKCTCH_CDThucTeThuaThieu(item.ThongTinDuongTruyenDan_HinhThucTruyenDan ??"", item.TTTKLCKCTCH_TongCD ?? 0, item.TTCDSLCauKienDuongTruyenDan_TongChieuDai ?? 0);
            item.TTTKLCKCTCH_XDOngCongCanThem = TTTKLCKCTCH_XDOngCongCanThem(item.TTTKLCKCTCH_CDThucTeThuaThieu ??0);
            item.TTCDSLCauKienDuongTruyenDan_SlCauKienTinhKl = TTCDSLCauKienDuongTruyenDan_SlCauKienTinhKl(item.ThongTinDuongTruyenDan_HinhThucTruyenDan ?? "", item.TTTKLCKCTCH_XDOngCongCanThem ?? "", item.TTTKLCKCTCH_SLCKNguyen ?? 0, item.TTTKLCKCTCH_SLCKDungDeTinhCD ?? 0);
            item.TTTKLCKCTCH_CDThuaThieuSauTinhKL = TTTKLCKCTCH_CDThuaThieuSauTinhKL(item.ThongTinDuongTruyenDan_HinhThucTruyenDan ?? "", item.TTCDSLCauKienDuongTruyenDan_SlCauKienTinhKl ?? 0, item.TTTKLCKCTCH_SLCKDungDeTinhCD ?? 0, item.TTTKLCKCTCH_CDMoiNoiCKien ?? 0, item.TTCDSLCauKienDuongTruyenDan_ChieuDai01CauKien ?? 0, item.TTCDSLCauKienDuongTruyenDan_TongChieuDai ?? 0);

            item.TTKTHHCongHopRanh_CCaoChatMatTrong = TTKTHHCongHopRanh_CCaoChatMatTrong(item.TTKTHHCongHopRanh_ChatMatTrong??"", item.TTKTHHCongHopRanh_CauTaoTuong ?? "", item.TTKTHHCongHopRanh_CauTaoMuMo??"", item.TTKTHHCongHopRanh_CCaoTuongGop ?? 0, item.TTKTHHCongHopRanh_CCaoMuMoThotDuoi ?? 0, item.TTKTHHCongHopRanh_CCaoMuMoThotTren??0);
            item.TTKTHHCongHopRanh_CCaoChatmatNgoai = TTKTHHCongHopRanh_CCaoChatmatNgoai(item.TTKTHHCongHopRanh_ChatMatNgoai ?? "", item.TTKTHHCongHopRanh_CauTaoTuong??"", item.TTKTHHCongHopRanh_CauTaoMuMo ?? "", item.TTKTHHCongHopRanh_CCaoTuongGop ?? 0, item.TTKTHHCongHopRanh_CCaoMuMoThotDuoi ?? 0, item.TTKTHHCongHopRanh_CCaoMuMoThotTren??0, item.TTKTHHCongHopRanh_CRongMuMoTren ??0);

            item.ThongTinKichThuocHinhHocOngNhua_TongCCaoOng = ThongTinKichThuocHinhHocOngNhua_TongCCaoOng(item.ThongTinKichThuocHinhHocOngNhua_CDayPhuBi ??0, item.ThongTinKichThuocHinhHocOngNhua_SoCanh ?? 0, item.ThongTinKichThuocHinhHocOngNhua_LongSuDung ??0);

            item.TTTDCongHoRanh_SLCauKienNguyen = TTTDCongHoRanh_SLCauKienNguyen(item.ThongTinDuongTruyenDan_HinhThucTruyenDan ?? "", item.TTCDSLCauKienDuongTruyenDan_TongChieuDai ?? 0, item.TTTDCongHoRanh_CDai ?? 0, item.TTTDCongHoRanh_ChieuDaiMoiNoi ??0);
            item.TTTDCongHoRanh_SoLuong = TTTDCongHoRanh_SoLuong(item.ThongTinDuongTruyenDan_HinhThucTruyenDan?? "", item.TTTDCongHoRanh_SLCauKienNguyen ??0);
            item.TTTDCongHoRanh_ChieuDaiTheoSoCKNguyen = TTTDCongHoRanh_ChieuDaiTheoSoCKNguyen(item.ThongTinDuongTruyenDan_HinhThucTruyenDan??"", item.TTTDCongHoRanh_SLCauKienNguyen ?? 0, item.TTTDCongHoRanh_ChieuDaiMoiNoi ??0);
            item.TTTDCongHoRanh_TongChieuDaiTheoCKNguyen = TTTDCongHoRanh_TongChieuDaiTheoCKNguyen(item.ThongTinDuongTruyenDan_HinhThucTruyenDan?? "", item.TTTDCongHoRanh_SLCauKienNguyen ?? 0, item.TTTDCongHoRanh_CDai ?? 0, item.TTTDCongHoRanh_ChieuDaiTheoSoCKNguyen ??0);
            item.TTTDCongHoRanh_ChieuDaiThucTe = TTTDCongHoRanh_ChieuDaiThucTe(item.ThongTinDuongTruyenDan_HinhThucTruyenDan ?? "", item.TTTDCongHoRanh_TongChieuDaiTheoCKNguyen ?? 0, item.TTCDSLCauKienDuongTruyenDan_TongChieuDai ??0);
            item.TTTDCongHoRanh_XacDinhOngCongCanThem = TTTDCongHoRanh_XacDinhOngCongCanThem(item.ThongTinDuongTruyenDan_HinhThucTruyenDan ?? "", item.TTTDCongHoRanh_ChieuDaiThucTe??0);
            item.TTTDCongHoRanh_SoLuong1 = TTTDCongHoRanh_SoLuong1(item.ThongTinDuongTruyenDan_HinhThucTruyenDan ?? "", item.TTTDCongHoRanh_XacDinhOngCongCanThem ?? "");

            item.CDThuongLuu_DinhDeCong = CDThuongLuu_DinhDeCong(item.ThongTinMongDuongTruyenDan_LoaiMong ?? "", item.CDThuongLuu_DayDongChay ?? 0, item.ThongTinCauTaoCongTron_CDayPhuBi??0);
            item.CDThuongLuu_DinhMongRanh = CDThuongLuu_DinhMongRanh(item.ThongTinDuongTruyenDan_HinhThucTruyenDan ?? "", item.ThongTinMongDuongTruyenDan_LoaiMong ?? "", item.CDThuongLuu_DayDongChay ??0);
            item.CDThuongLuu_DinhMongCongHop = CDThuongLuu_DinhMongCongHop(item.ThongTinDuongTruyenDan_HinhThucTruyenDan ?? "", item.ThongTinMongDuongTruyenDan_LoaiMong ??"", item.CDThuongLuu_DayDongChay ?? 0, item.TTKTHHCongHopRanh_CCaoDe??0);
            item.CDThuongLuu_DinhMongCongTron = CDThuongLuu_DinhMongCongTron(item.ThongTinDuongTruyenDan_HinhThucTruyenDan ?? "", item.ThongTinMongDuongTruyenDan_LoaiMong ?? "", item.CDThuongLuu_DayDongChay ?? 0, item.ThongTinCauTaoCongTron_CDayPhuBi??0 , item.CDThuongLuu_DinhDeCong ?? 0, item.ThongTinCauTaoCongTron_CCaoDe??0);
            //item.CDThuongLuu_DinhMongChanKhay = CDThuongLuu_DinhMongChanKhay(item.ThongTinDuongTruyenDan_HinhThucTruyenDan ?? "", item.ThongTinRanhThang_CauTaoChanKhay, item.CDThuongLuu_DayDongChay??0);
            //item.CDThuongLuu_DinhMongRanhThang = CDThuongLuu_DinhMongRanhThang(item.ThongTinDuongTruyenDan_HinhThucTruyenDan ?? "", item.ThongTinMongDuongTruyenDan_LoaiMong ?? "", item.CDThuongLuu_DayDongChay??0);
            item.CDThuongLuu_DinhMongGop = CDThuongLuu_DinhMongGop(item.ThongTinDuongTruyenDan_HinhThucTruyenDan ?? "", item.ThongTinMongDuongTruyenDan_LoaiMong ?? "", item.CDThuongLuu_DayDongChay ?? 0, item.ThongTinCauTaoCongTron_CDayPhuBi??0 , item.CDThuongLuu_DinhDeCong ?? 0, item.ThongTinCauTaoCongTron_CCaoDe ??0, item.TTKTHHCongHopRanh_CCaoDe??0);
            item.CDThuongLuu_DinhLotRanh   = CDThuongLuu_DinhLotRanh(item.ThongTinDuongTruyenDan_HinhThucTruyenDan ?? "", item.ThongTinMongDuongTruyenDan_LoaiMong ?? "", item.CDThuongLuu_DinhMongRanh ?? 0, item.TTKTHHCongHopRanh_CCaoMong ??0);
            item.CDThuongLuu_DinhLotCongHop = CDThuongLuu_DinhLotCongHop(item.ThongTinDuongTruyenDan_HinhThucTruyenDan ?? "", item.ThongTinMongDuongTruyenDan_LoaiMong ?? "", item.CDThuongLuu_DinhMongCongHop ?? 0, item.TTKTHHCongHopRanh_CCaoMong ??0);
            item.CDThuongLuu_DinhLotCongTron = CDThuongLuu_DinhLotCongTron(item.ThongTinDuongTruyenDan_HinhThucTruyenDan ?? "", item.ThongTinMongDuongTruyenDan_LoaiMong ?? "", item.CDThuongLuu_DinhMongCongTron ?? 0, item.ThongTinCauTaoCongTron_CCaoMong ??0);
            item.CDThuongLuu_DinhLotOngNhua = CDThuongLuu_DinhLotOngNhua(item.ThongTinDuongTruyenDan_HinhThucTruyenDan ?? "", item.ThongTinMongDuongTruyenDan_LoaiMong ?? "", item.CDThuongLuu_DayDongChay ?? 0, item.ThongTinKichThuocHinhHocOngNhua_CDayPhuBi ??0);
            //item.CDThuongLuu_DinhLotGiangDinhRanhThang = CDThuongLuu_DinhLotGiangDinhRanhThang(item.ThongTinDuongTruyenDan_HinhThucTruyenDan ?? "", item.ThongTinRanhThang_CauTaoGiangDinh, item.CDThuongLuu_DinhRanhThang, item.ThongTinRanhThang_CCaoMongGiangDinh??0);
            //item.CDThuongLuu_DinhLotChanKhayRanhThang = CDThuongLuu_DinhLotChanKhayRanhThang(item.ThongTinDuongTruyenDan_HinhThucTruyenDan ?? "", item.ThongTinRanhThang_CauTaoChanKhay, item.CDThuongLuu_DayDongChay ?? 0, item.ThongTinRanhThang_CCaoMongChanKhay??0);
            //item.CDThuongLuu_DinhLotRanhThang = CDThuongLuu_DinhLotRanhThang(item.ThongTinDuongTruyenDan_HinhThucTruyenDan ?? "", item.ThongTinMongDuongTruyenDan_LoaiMong ?? "", item.CDThuongLuu_DayDongChay ?? 0, item.TTKTHHCongHopRanh_CCaoMong?? 0);
            item.CDThuongLuu_DinhLotGop = CDThuongLuu_DinhLotGop(item.ThongTinDuongTruyenDan_HinhThucTruyenDan ?? "", item.ThongTinMongDuongTruyenDan_LoaiMong ?? "", item.CDThuongLuu_DayDongChay ?? 0, item.ThongTinKichThuocHinhHocOngNhua_CDayPhuBi ?? 0, item.CDThuongLuu_DinhMongCongTron ?? 0, item.ThongTinCauTaoCongTron_CCaoMong ?? 0, item.CDThuongLuu_DinhMongCongHop ?? 0, item.TTKTHHCongHopRanh_CCaoMong ?? 0, item.CDThuongLuu_DinhMongRanh ?? 0);
            //item.CDThuongLuu_DayDaoRanhThang = CDThuongLuu_DayDaoRanhThang(item.ThongTinDuongTruyenDan_HinhThucTruyenDan ?? "", item.ThongTinMongDuongTruyenDan_LoaiMong ?? "", item.CDThuongLuu_DinhLotRanh ??0 Thang, item.ThongTinRanhThang_CCaoLot, item.CDThuongLuu_DayDongChay??0);
            //item.CDThuongLuu_DayDaoChanKhayRanhThang = CDThuongLuu_DayDaoChanKhayRanhThang(item.ThongTinDuongTruyenDan_HinhThucTruyenDan ?? "", item.ThongTinRanhThang_CauTaoChanKhay, item.CDThuongLuu_DinhLotChanKhayRanhThang, item.ThongTinRanhThang_CCaoLotChanKhay, item.CDThuongLuu_DayDongChay??0);
            //item.CDThuongLuu_DayDaoGiangDinhRanhThang = CDThuongLuu_DayDaoGiangDinhRanhThang(item.ThongTinDuongTruyenDan_HinhThucTruyenDan ?? "", item.ThongTinRanhThang_CauTaoGiangDinh, item.CDThuongLuu_DinhLotGiangDinhRanhThang, item.ThongTinRanhThang_CCaoLotGiangDinh, item.CDThuongLuu_DinhRanhThang??0);
            item.CDThuongLuu_DayDaoOngNhua = CDThuongLuu_DayDaoOngNhua(item.ThongTinDuongTruyenDan_HinhThucTruyenDan ?? "", item.ThongTinMongDuongTruyenDan_LoaiMong ?? "", item.CDThuongLuu_DayDongChay ?? 0, item.ThongTinKichThuocHinhHocOngNhua_CDayPhuBi ??0, item.CDThuongLuu_DinhLotOngNhua??0, item.ThongTinKichThuocHinhHocOngNhua_CCaoDemCat ??0);
            item.CDThuongLuu_DayDaoRanh = CDThuongLuu_DayDaoRanh(item.ThongTinDuongTruyenDan_HinhThucTruyenDan ?? "", item.CDThuongLuu_DinhLotRanh ??0 , item.TTKTHHCongHopRanh_CCaoLotMong ??0);
            item.CDThuongLuu_DayDaoCongHop = CDThuongLuu_DayDaoCongHop(item.ThongTinDuongTruyenDan_HinhThucTruyenDan ?? "", item.ThongTinMongDuongTruyenDan_LoaiMong ?? "", item.CDThuongLuu_DayDongChay ?? 0, item.TTKTHHCongHopRanh_CCaoDe??0, item.CDThuongLuu_DinhLotCongHop??0, item.TTKTHHCongHopRanh_CCaoLotMong ??0);
            item.CDThuongLuu_DayDaoCongTron = CDThuongLuu_DayDaoCongTron(item.ThongTinDuongTruyenDan_HinhThucTruyenDan ?? "", item.ThongTinMongDuongTruyenDan_LoaiMong ?? "", item.CDThuongLuu_DayDongChay ?? 0, item.ThongTinCauTaoCongTron_CDayPhuBi??0  , item.CDThuongLuu_DinhDeCong ?? 0, item.ThongTinCauTaoCongTron_CCaoDe ??0, item.CDThuongLuu_DinhLotCongTron??0, item.ThongTinCauTaoCongTron_CCaoLotMong??0);
            item.CDThuongLuu_DayDaoGop = CDThuongLuu_DayDaoGop(item.ThongTinDuongTruyenDan_HinhThucTruyenDan ?? "", item.ThongTinMongDuongTruyenDan_LoaiMong ?? "", item.CDThuongLuu_DayDongChay ?? 0, item.ThongTinCauTaoCongTron_CDayPhuBi ?? 0, item.CDThuongLuu_DinhDeCong ?? 0, item.ThongTinCauTaoCongTron_CCaoDe ?? 0, item.CDThuongLuu_DinhLotCongTron ?? 0, item.ThongTinCauTaoCongTron_CCaoLotMong ?? 0, item.TTKTHHCongHopRanh_CCaoDe ?? 0, item.CDThuongLuu_DinhLotCongHop ?? 0, item.TTKTHHCongHopRanh_CCaoLotMong ?? 0, item.CDThuongLuu_DinhLotRanh ?? 0, item.ThongTinKichThuocHinhHocOngNhua_CDayPhuBi ?? 0, item.CDThuongLuu_DinhLotOngNhua ?? 0, item.ThongTinKichThuocHinhHocOngNhua_CCaoDemCat ?? 0);
            item.CDThuongLuu_ChieuSauDao = CDThuongLuu_ChieuSauDao(item.CDThuongLuu_HienTrangTruocKhiDaoThuongLuu??0, item.CDThuongLuu_DayDaoGop??0);

            //item.CDThuongLuu_DinhRanhThang = CDThuongLuu_DinhRanhThang(item.ThongTinDuongTruyenDan_HinhThucTruyenDan ?? "", item.CDThuongLuu_DayDongChay ?? 0, item.CDThuongLuu_ChieuCaoRanhThangTuDayDongChayDenDinh??0);
            item.CDThuongLuu_DinhCongTron = CDThuongLuu_DinhCongTron(item.ThongTinDuongTruyenDan_HinhThucTruyenDan ?? "", item.CDThuongLuu_DinhTrongLongSuDung??0, item.ThongTinCauTaoCongTron_CDayPhuBi??0);
            item.CDThuongLuu_DinhCongHop = CDThuongLuu_DinhCongHop(item.ThongTinDuongTruyenDan_HinhThucTruyenDan ?? "", item.CDThuongLuu_DinhTrongLongSuDung??0, item.TTKTHHCongHopRanh_CCaoMuMoThotTren??0);
            item.CDThuongLuu_DinhRanh = CDThuongLuu_DinhRanh(item.ThongTinDuongTruyenDan_HinhThucTruyenDan ?? "", item.CDThuongLuu_DinhTrongLongSuDung??0, item.TTKTHHCongHopRanh_CCaoMuMoThotTren??0);
            item.CDThuongLuu_DinhOngNhua =  CDThuongLuu_DinhOngNhua(item.ThongTinDuongTruyenDan_HinhThucTruyenDan ?? "", item.CDThuongLuu_DinhTrongLongSuDung??0, item.ThongTinKichThuocHinhHocOngNhua_CDayPhuBi ??0);
            item.CDThuongLuu_DinhDapCat = CDThuongLuu_DinhDapCat(item.ThongTinDuongTruyenDan_HinhThucTruyenDan ?? "", item.CDThuongLuu_DinhOngNhua??0, item.ThongTinKichThuocHinhHocOngNhua_CCaoDapCat??0);
            item.CDThuongLuu_DinhMuMoThotDuoiCongHopRanh = CDThuongLuu_DinhMuMoThotDuoiCongHopRanh(item.ThongTinDuongTruyenDan_HinhThucTruyenDan ?? "", item.CDThuongLuu_DinhCongHop??0, item.CDThuongLuu_DinhRanh??0, item.TTKTHHCongHopRanh_CCaoMuMoThotTren??0);
            //item.CDThuongLuu_DinhGiangDinhRanhThang = CDThuongLuu_DinhGiangDinhRanhThang(item.ThongTinDuongTruyenDan_HinhThucTruyenDan ?? "", item.ThongTinRanhThang_CauTaoGiangDinh, item.ThongTinRanhThang_CRongMongChanKhay??0);
            item.CDThuongLuu_DinhGop = CDThuongLuu_DinhGop(item.ThongTinDuongTruyenDan_HinhThucTruyenDan ?? "", item.CDThuongLuu_DinhTrongLongSuDung??0, item.ThongTinCauTaoCongTron_CDayPhuBi??0 , item.TTKTHHCongHopRanh_CCaoMuMoThotTren??0, item.ThongTinKichThuocHinhHocOngNhua_CDayPhuBi ??0, item.CDThuongLuu_DayDongChay ?? 0);
            item.CDThuongLuu_DinhTuongCHopRanh = CDThuongLuu_DinhTuongCHopRanh(item.ThongTinDuongTruyenDan_HinhThucTruyenDan ?? "", item.CDThuongLuu_DinhMuMoThotDuoiCongHopRanh ?? 0, item.TTKTHHCongHopRanh_CCaoMuMoThotDuoi ??0);
            item.CDThuongLuu_CCaoTuongCongRanh = CDThuongLuu_CCaoTuongCongRanh(item.ThongTinDuongTruyenDan_HinhThucTruyenDan ?? "", item.CDThuongLuu_DinhTuongCHopRanh ?? 0, item.CDThuongLuu_DayDongChay ??0);

            //item.CDHaLu_DinhRanhThang = CDHaLu_DinhRanhThang(item.ThongTinDuongTruyenDan_HinhThucTruyenDan ?? "", item.CDHaLu_DayDongChay, item.CDHaLu_ChieuCaoRanhThangTuDayDongChayDenDinh??0);
            item.CDHaLu_DinhCongTron = CDHaLu_DinhCongTron(item.ThongTinDuongTruyenDan_HinhThucTruyenDan ?? "", item.CDHaLu_DinhTrongLongSuDung ?? 0, item.ThongTinCauTaoCongTron_CDayPhuBi??0);
            item.CDHaLu_DinhCongHop = CDHaLu_DinhCongHop(item.ThongTinDuongTruyenDan_HinhThucTruyenDan ?? "", item.CDHaLu_DinhTrongLongSuDung ?? 0, item.TTKTHHCongHopRanh_CCaoMuMoThotTren??0);
            item.CDHaLu_DinhRanh = CDHaLu_DinhRanh(item.ThongTinDuongTruyenDan_HinhThucTruyenDan ?? "", item.CDHaLu_DinhTrongLongSuDung ?? 0, item.TTKTHHCongHopRanh_CCaoMuMoThotTren??0);
            item.CDHaLu_DinhOngNhua = CDHaLu_DinhOngNhua(item.ThongTinDuongTruyenDan_HinhThucTruyenDan ?? "", item.CDHaLu_DinhTrongLongSuDung ?? 0, item.ThongTinKichThuocHinhHocOngNhua_CDayPhuBi ??0);
            item.CDHaLu_DinhDapCat = CDHaLu_DinhDapCat(item.ThongTinDuongTruyenDan_HinhThucTruyenDan ?? "", item.CDHaLu_DinhOngNhua ?? 0, item.ThongTinKichThuocHinhHocOngNhua_CCaoDapCat??0);
            item.CDHaLu_DinhGop = CDHaLu_DinhGop(item.ThongTinDuongTruyenDan_HinhThucTruyenDan ?? "", item.CDHaLu_DinhTrongLongSuDung??0, item.ThongTinCauTaoCongTron_CDayPhuBi??0 , item.TTKTHHCongHopRanh_CCaoMuMoThotTren??0, item.ThongTinKichThuocHinhHocOngNhua_CDayPhuBi ??0, item.CDHaLu_DayDongChay ?? 0);
            //item.CDHaLu_DinhGiangDinhRanhThang = CDHaLu_DinhGiangDinhRanhThang(item.ThongTinDuongTruyenDan_HinhThucTruyenDan ?? "", item.ThongTinRanhThang_CauTaoGiangDinh, item.CDHaLu_DinhRanhThang??0);
            item.CDHaLu_DinhMuMoThotDuoiCongHopRanh = CDHaLu_DinhMuMoThotDuoiCongHopRanh(item.ThongTinDuongTruyenDan_HinhThucTruyenDan ?? "", item.CDHaLu_DinhCongHop??0, item.TTKTHHCongHopRanh_CCaoMuMoThotTren??0, item.CDHaLu_DinhRanh??0);
            item.CDHaLu_DinhTuongCHopRanh = CDHaLu_DinhTuongCHopRanh(item.ThongTinDuongTruyenDan_HinhThucTruyenDan ?? "", item.CDHaLu_DinhMuMoThotDuoiCongHopRanh ?? 0, item.TTKTHHCongHopRanh_CCaoMuMoThotDuoi ??0);
            item.CDHaLu_CCaoTuongCongRanh = CDHaLu_CCaoTuongCongRanh(item.ThongTinDuongTruyenDan_HinhThucTruyenDan ?? "", item.CDHaLu_DinhTuongCHopRanh ?? 0, item.CDHaLu_DayDongChay ??0);

            item.TTKTHHCongHopRanh_CCaoTuongRanh = TTKTHHCongHopRanh_CCaoTuongRanh(item.ThongTinDuongTruyenDan_HinhThucTruyenDan ?? "", item.CDThuongLuu_CCaoTuongCongRanh ?? 0, item.CDHaLu_CCaoTuongCongRanh??0);
            item.TTKTHHCongHopRanh_CCaoTuongGop = TTKTHHCongHopRanh_CCaoTuongGop(item.TTKTHHCongHopRanh_CCaoTuongCongHop ?? 0, item.TTKTHHCongHopRanh_CCaoTuongRanh??0);
            item.TTKTHHCongHopRanh_TongChieuCao = TTKTHHCongHopRanh_TongChieuCao(item.TTKTHHCongHopRanh_CCaoLotMong ?? 0, item.TTKTHHCongHopRanh_CCaoMong ?? 0, item.TTKTHHCongHopRanh_CCaoDe ?? 0, item.TTKTHHCongHopRanh_CCaoTuongGop ?? 0, item.TTKTHHCongHopRanh_CCaoMuMoThotDuoi ?? 0, item.TTKTHHCongHopRanh_CCaoMuMoThotTren ??0);

            item.CDHaLu_DinhDeCong = CDHaLu_DinhDeCong(item.ThongTinMongDuongTruyenDan_LoaiMong ?? "", item.CDHaLu_DayDongChay ?? 0, item.ThongTinCauTaoCongTron_CDayPhuBi ??0);
            item.CDHaLu_DinhMongRanh = CDHaLu_DinhMongRanh(item.ThongTinDuongTruyenDan_HinhThucTruyenDan ?? "", item.ThongTinMongDuongTruyenDan_LoaiMong ?? "", item.CDHaLu_DayDongChay??0);
            item.CDHaLu_DinhMongCongHop = CDHaLu_DinhMongCongHop(item.ThongTinDuongTruyenDan_HinhThucTruyenDan ?? "", item.ThongTinMongDuongTruyenDan_LoaiMong ?? "", item.CDHaLu_DayDongChay ?? 0, item.TTKTHHCongHopRanh_CCaoDe ??0);
            item.CDHaLu_DinhMongCongTron = CDHaLu_DinhMongCongTron(item.ThongTinDuongTruyenDan_HinhThucTruyenDan ?? "", item.ThongTinMongDuongTruyenDan_LoaiMong ?? "", item.CDHaLu_DayDongChay ?? 0, item.ThongTinCauTaoCongTron_CDayPhuBi ??0, item.CDHaLu_DinhDeCong ?? 0, item.ThongTinCauTaoCongTron_CCaoDe??0);
            //item.CDHaLu_DinhMongChanKhay = CDHaLu_DinhMongChanKhay(item.ThongTinDuongTruyenDan_HinhThucTruyenDan ?? "", item.ThongTinRanhThang_CauTaoChanKhay??0, item.CDHaLu_DayDongChay??0);
            //item.CDHaLu_DinhMongRanhThang = CDHaLu_DinhMongRanhThang(item.ThongTinDuongTruyenDan_HinhThucTruyenDan ?? "", item.ThongTinMongDuongTruyenDan_LoaiMong ?? "", item.CDHaLu_DayDongChay??0);
            item.CDHaLu_DinhMongGop = CDHaLu_DinhMongGop(item.ThongTinDuongTruyenDan_HinhThucTruyenDan ?? "", item.ThongTinMongDuongTruyenDan_LoaiMong ?? "", item.CDHaLu_DayDongChay ?? 0, item.ThongTinCauTaoCongTron_CDayPhuBi ??0, item.CDHaLu_DinhDeCong ?? 0, item.ThongTinCauTaoCongTron_CCaoDe ?? 0, item.TTKTHHCongHopRanh_CCaoDe ??0);
            item.CDHaLu_DinhLotRanh = CDHaLu_DinhLotRanh(item.ThongTinDuongTruyenDan_HinhThucTruyenDan ?? "", item.ThongTinMongDuongTruyenDan_LoaiMong ?? "", item.CDHaLu_DinhMongRanh ?? 0, item.TTKTHHCongHopRanh_CCaoMong??0);
            item.CDHaLu_DinhLotCongHop = CDHaLu_DinhLotCongHop(item.ThongTinDuongTruyenDan_HinhThucTruyenDan ?? "", item.ThongTinMongDuongTruyenDan_LoaiMong ?? "", item.CDHaLu_DinhMongCongHop ?? 0, item.TTKTHHCongHopRanh_CCaoMong??0);
            item.CDHaLu_DinhLotCongTron = CDHaLu_DinhLotCongTron(item.ThongTinDuongTruyenDan_HinhThucTruyenDan ?? "", item.ThongTinMongDuongTruyenDan_LoaiMong ?? "", item.CDHaLu_DinhMongCongTron ?? 0, item.ThongTinCauTaoCongTron_CCaoMong??0);
            item.CDHaLu_DinhLotOngNhua = CDHaLu_DinhLotOngNhua(item.ThongTinDuongTruyenDan_HinhThucTruyenDan ?? "", item.ThongTinMongDuongTruyenDan_LoaiMong ?? "", item.CDHaLu_DayDongChay ?? 0, item.ThongTinKichThuocHinhHocOngNhua_CDayPhuBi ??0);
            //item.CDHaLu_DinhLotGiangDinhRanhThang = CDHaLu_DinhLotGiangDinhRanhThang(item.ThongTinDuongTruyenDan_HinhThucTruyenDan ?? "", item.ThongTinRanhThang_CauTaoGiangDinh??0, item.CDHaLu_DinhRanhThang??0, item.ThongTinRanhThang_CCaoMongGiangDinh??0);
            //item.CDHaLu_DinhLotChanKhayRanhThang = CDHaLu_DinhLotChanKhayRanhThang(item.ThongTinDuongTruyenDan_HinhThucTruyenDan ?? "", item.ThongTinRanhThang_CauTaoChanKhay??0, item.CDHaLu_DayDongChay??0, item.ThongTinRanhThang_CCaoMongChanKhay??0);
            //item.CDHaLu_DinhLotRanhThang = CDHaLu_DinhLotRanhThang(item.ThongTinDuongTruyenDan_HinhThucTruyenDan ?? "", item.ThongTinMongDuongTruyenDan_LoaiMong ?? "", item.CDHaLu_DayDongChay??0, item.ThongTinRanhThang_CCaoMong??0);
            item.CDHaLu_DinhLotGop = CDHaLu_DinhLotGop(item.ThongTinDuongTruyenDan_HinhThucTruyenDan ?? "", item.ThongTinMongDuongTruyenDan_LoaiMong ?? "", item.CDHaLu_DayDongChay??0, item.ThongTinKichThuocHinhHocOngNhua_CDayPhuBi ??0, item.CDHaLu_DinhMongCongTron??0, item.ThongTinCauTaoCongTron_CCaoMong??0, item.CDHaLu_DinhMongCongHop??0, item.TTKTHHCongHopRanh_CCaoMong??0, item.CDHaLu_DinhMongRanh??0);
            //item.CDHaLu_DayDaoRanhThang = CDHaLu_DayDaoRanhThang(item.ThongTinDuongTruyenDan_HinhThucTruyenDan ?? "", item.ThongTinMongDuongTruyenDan_LoaiMong ?? "", item.CDHaLu_DinhLotRanhThang??0, item.ThongTinRanhThang_CCaoLot??0, item.CDHaLu_DayDongChay??0);
            //item.CDHaLu_DayDaoChanKhayRanhThang = CDHaLu_DayDaoChanKhayRanhThang(item.ThongTinDuongTruyenDan_HinhThucTruyenDan ?? "", item.ThongTinRanhThang_CauTaoChanKhay??0, item.CDHaLu_DinhLotChanKhayRanhThang??0, item.ThongTinRanhThang_CCaoLotChanKhay??0, item.CDHaLu_DayDongChay??0);
            //item.CDHaLu_DayDaoGiangDinhRanhThang = CDHaLu_DayDaoGiangDinhRanhThang(item.ThongTinDuongTruyenDan_HinhThucTruyenDan ?? "", item.ThongTinRanhThang_CauTaoGiangDinh??0, item.CDHaLu_DinhLotGiangDinhRanhThang??0, item.ThongTinRanhThang_CCaoLotGiangDinh??0, item.CDHaLu_DinhRanhThang??0);
            item.CDHaLu_DayDaoOngNhua = CDHaLu_DayDaoOngNhua(item.ThongTinDuongTruyenDan_HinhThucTruyenDan ?? "", item.ThongTinMongDuongTruyenDan_LoaiMong ?? "", item.CDHaLu_DayDongChay ?? 0, item.ThongTinKichThuocHinhHocOngNhua_CDayPhuBi ?? 0, item.CDHaLu_DinhLotOngNhua ?? 0, item.ThongTinKichThuocHinhHocOngNhua_CCaoDemCat ??0);
            item.CDHaLu_DayDaoRanh = CDHaLu_DayDaoRanh(item.ThongTinDuongTruyenDan_HinhThucTruyenDan ?? "", item.CDHaLu_DinhLotRanh ?? 0, item.TTKTHHCongHopRanh_CCaoLotMong ??0);
            item.CDHaLu_DayDaoCongHop = CDHaLu_DayDaoCongHop(item.ThongTinDuongTruyenDan_HinhThucTruyenDan ?? "", item.ThongTinMongDuongTruyenDan_LoaiMong ?? "", item.CDHaLu_DayDongChay ?? 0, item.TTKTHHCongHopRanh_CCaoDe ?? 0, item.CDHaLu_DinhLotCongHop ?? 0, item.TTKTHHCongHopRanh_CCaoLotMong ??0);
            item.CDHaLu_DayDaoCongTron = CDHaLu_DayDaoCongTron(item.ThongTinDuongTruyenDan_HinhThucTruyenDan ?? "", item.ThongTinMongDuongTruyenDan_LoaiMong ?? "", item.CDHaLu_DayDongChay ?? 0, item.ThongTinCauTaoCongTron_CDayPhuBi ??0, item.CDHaLu_DinhDeCong ?? 0, item.ThongTinCauTaoCongTron_CCaoDe ?? 0, item.CDHaLu_DinhLotCongTron ?? 0, item.ThongTinCauTaoCongTron_CCaoLotMong ??0);
            item.CDHaLu_DayDaoGop = CDHaLu_DayDaoGop(item.ThongTinDuongTruyenDan_HinhThucTruyenDan ?? "", item.ThongTinMongDuongTruyenDan_LoaiMong ?? "", item.CDHaLu_DayDongChay??0, item.ThongTinCauTaoCongTron_CDayPhuBi??0, item.CDHaLu_DinhDeCong??0, item.ThongTinCauTaoCongTron_CCaoDe ??0, item.CDHaLu_DinhLotCongTron??0, item.ThongTinCauTaoCongTron_CCaoLotMong??0, item.TTKTHHCongHopRanh_CCaoDe??0, item.CDHaLu_DinhLotCongHop??0, item.TTKTHHCongHopRanh_CCaoLotMong ??0, item.CDHaLu_DinhLotRanh??0, item.ThongTinKichThuocHinhHocOngNhua_CDayPhuBi ??0, item.CDHaLu_DinhLotOngNhua??0, item.ThongTinKichThuocHinhHocOngNhua_CCaoDemCat ??0);
            item.CDHaLu_ChieuSauDao = CDHaLu_ChieuSauDao(item.CDHaLu_DayDaoGop ?? 0, item.CDHaLu_HienTrangTruocKhiDaoHaLuu??0);

            item.TTVLDCongRanh_TLChieuCaoDaoDat = TTVLDCongRanh_TLChieuCaoDaoDat(item.TTVLDCongRanh_LoaiVatLieuDao ?? "", item.CDThuongLuu_ChieuSauDao ?? 0, item.TTVLDCongRanh_TLChieuCaoDaoDa??0);
            item.TTVLDCongRanh_TLTongChieuSauDao = Math.Round(item.TTVLDCongRanh_TLChieuCaoDaoDa + item.TTVLDCongRanh_TLChieuCaoDaoDat ?? 0, 2);
            item.TTVLDCongRanh_HLChieuCaoDaoDat = TTVLDCongRanh_HLChieuCaoDaoDat(item.TTVLDCongRanh_LoaiVatLieuDao ?? "", item.CDHaLu_ChieuSauDao ?? 0, item.TTVLDCongRanh_HLChieuCaoDaoDa??0);
            item.TTVLDCongRanh_HLTongChieuSauDao = Math.Round(item.TTVLDCongRanh_HLChieuCaoDaoDa + item.TTVLDCongRanh_HLChieuCaoDaoDat ?? 0, 2);

            item.TTCCCCT_CCaoLotDatTLuu = TTCCCCT_CCaoLotDatTLuu(item.TTVLDCongRanh_LoaiVatLieuDao ?? "", item.TTVLDCongRanh_TLChieuCaoDaoDat ?? 0, item.ThongTinCauTaoCongTron_CCaoLotMong ??0);
            item.TTCCCCT_CCaoLotDatHLuu = TTCCCCT_CCaoLotDatHLuu(item.TTVLDCongRanh_LoaiVatLieuDao ?? "", item.TTVLDCongRanh_HLChieuCaoDaoDat ?? 0, item.ThongTinCauTaoCongTron_CCaoLotMong ??0);
            item.TTCCCCT_CCaoLotDatMongTBinh = (item.TTCCCCT_CCaoLotDatTLuu + item.TTCCCCT_CCaoLotDatHLuu) / 2;
            item.TTCCCCT_CCaoLotDaTLuu = TTCCCCT_CCaoLotDaTLuu(item.TTVLDCongRanh_LoaiVatLieuDao ?? "", item.TTVLDCongRanh_TLChieuCaoDaoDa ?? 0, item.TTVLDCongRanh_TLTongChieuSauDao ?? 0, item.TTCCCCT_CCaoLotDatTLuu ?? 0, item.ThongTinCauTaoCongTron_CCaoLotMong ??0);
            item.TTCCCCT_CCaoLotDaHLuu = TTCCCCT_CCaoLotDaHLuu(item.TTVLDCongRanh_LoaiVatLieuDao ?? "", item.TTVLDCongRanh_HLChieuCaoDaoDa ?? 0, item.TTVLDCongRanh_HLTongChieuSauDao ?? 0, item.TTCCCCT_CCaoLotDatHLuu ?? 0, item.ThongTinCauTaoCongTron_CCaoLotMong ??0);
            item.TTCCCCT_CCaoLotDaMongTBinh = (item.TTCCCCT_CCaoLotDaTLuu + item.TTCCCCT_CCaoLotDaHLuu) / 2;
            item.TTCCCCT_CCaoMongDatTLuu = TTCCCCT_CCaoMongDatTLuu(item.TTVLDCongRanh_LoaiVatLieuDao ?? "", item.TTVLDCongRanh_TLChieuCaoDaoDat ?? 0, item.ThongTinCauTaoCongTron_CCaoLotMong ?? 0, item.ThongTinCauTaoCongTron_CCaoMong??0);
            item.TTCCCCT_CCaoMongDatHLuu = TTCCCCT_CCaoMongDatHLuu(item.TTVLDCongRanh_LoaiVatLieuDao ?? "", item.TTVLDCongRanh_HLChieuCaoDaoDat ?? 0, item.ThongTinCauTaoCongTron_CCaoLotMong ?? 0, item.ThongTinCauTaoCongTron_CCaoMong??0);
            item.TTCCCCT_CCaoMongDatTBinh = (item.TTCCCCT_CCaoMongDatTLuu + item.TTCCCCT_CCaoMongDatHLuu) / 2;
            item.TTCCCCT_CCaoMongDaTLuu = TTCCCCT_CCaoMongDaTLuu(item.TTVLDCongRanh_LoaiVatLieuDao ?? "", item.TTVLDCongRanh_TLChieuCaoDaoDa ?? 0, item.ThongTinCauTaoCongTron_CCaoLotMong ?? 0, item.ThongTinCauTaoCongTron_CCaoMong ?? 0, item.TTVLDCongRanh_TLTongChieuSauDao ?? 0, item.TTCCCCT_CCaoMongDatTLuu ?? 0, item.TTCCCCT_CCaoLotDaTLuu??0);
            item.TTCCCCT_CCaoMongDaHLuu = TTCCCCT_CCaoMongDaHLuu(item.TTVLDCongRanh_LoaiVatLieuDao ?? "", item.TTVLDCongRanh_HLChieuCaoDaoDa ?? 0, item.ThongTinCauTaoCongTron_CCaoLotMong ?? 0, item.ThongTinCauTaoCongTron_CCaoMong ?? 0, item.TTVLDCongRanh_HLTongChieuSauDao ?? 0, item.TTCCCCT_CCaoMongDatHLuu ?? 0, item.TTCCCCT_CCaoLotDaHLuu??0);
            item.TTCCCCT_CCaoMongDaTBinh = (item.TTCCCCT_CCaoMongDaTLuu + item.TTCCCCT_CCaoMongDaHLuu) / 2;
            item.TTCCCCT_CCaoDeDatTLuu = TTCCCCT_CCaoDeDatTLuu(item.TTVLDCongRanh_LoaiVatLieuDao ?? "", item.TTVLDCongRanh_TLChieuCaoDaoDat ?? 0, item.ThongTinCauTaoCongTron_CCaoLotMong ?? 0, item.ThongTinCauTaoCongTron_CCaoMong ?? 0, item.ThongTinCauTaoCongTron_CCaoDe??0);
            item.TTCCCCT_CCaoDeDatHLuu = TTCCCCT_CCaoDeDatHLuu(item.TTVLDCongRanh_LoaiVatLieuDao ?? "", item.TTVLDCongRanh_HLChieuCaoDaoDat ?? 0, item.ThongTinCauTaoCongTron_CCaoLotMong ?? 0, item.ThongTinCauTaoCongTron_CCaoMong ?? 0, item.ThongTinCauTaoCongTron_CCaoDe??0);
            item.TTCCCCT_CCaoDeDatTBinh = (item.TTCCCCT_CCaoDeDatTLuu + item.TTCCCCT_CCaoDeDatHLuu) / 2;
            item.TTCCCCT_CCaoDeDaTLuu = TTCCCCT_CCaoDeDaTLuu(item.TTVLDCongRanh_LoaiVatLieuDao ?? "", item.TTVLDCongRanh_TLChieuCaoDaoDa ?? 0, item.ThongTinCauTaoCongTron_CCaoLotMong ?? 0, item.ThongTinCauTaoCongTron_CCaoMong ?? 0, item.ThongTinCauTaoCongTron_CCaoDe ?? 0, item.TTVLDCongRanh_TLTongChieuSauDao ?? 0, item.TTCCCCT_CCaoDeDatTLuu ?? 0, item.TTCCCCT_CCaoLotDaTLuu ?? 0, item.TTCCCCT_CCaoMongDaTLuu??0);
            item.TTCCCCT_CCaoDeDaHLuu = TTCCCCT_CCaoDeDaHLuu(item.TTVLDCongRanh_LoaiVatLieuDao ?? "", item.TTVLDCongRanh_HLChieuCaoDaoDa ?? 0, item.ThongTinCauTaoCongTron_CCaoLotMong ?? 0, item.ThongTinCauTaoCongTron_CCaoMong ?? 0, item.ThongTinCauTaoCongTron_CCaoDe ?? 0, item.TTVLDCongRanh_HLTongChieuSauDao ?? 0, item.TTCCCCT_CCaoDeDatHLuu ?? 0, item.TTCCCCT_CCaoLotDaHLuu ?? 0, item.TTCCCCT_CCaoMongDaHLuu??0);
            item.TTCCCCT_CCaoDeDaTBinh = (item.TTCCCCT_CCaoDeDaTLuu + item.TTCCCCT_CCaoDeDaHLuu) / 2;
            item.TTCCCCT_CCaoCongDatTLuu = TTCCCCT_CCaoCongDatTLuu(item.TTVLDCongRanh_LoaiVatLieuDao ?? "", item.TTVLDCongRanh_TLChieuCaoDaoDat ?? 0, item.ThongTinCauTaoCongTron_CCaoLotMong ?? 0, item.ThongTinCauTaoCongTron_CCaoMong ?? 0, item.ThongTinCauTaoCongTron_CCaoDe ?? 0, item.ThongTinCauTaoCongTron_TongCCaoCong??0);
            item.TTCCCCT_CCaoCongDatHLuu = TTCCCCT_CCaoCongDatHLuu(item.TTVLDCongRanh_LoaiVatLieuDao ?? "", item.TTVLDCongRanh_HLChieuCaoDaoDat ?? 0, item.ThongTinCauTaoCongTron_CCaoLotMong ?? 0, item.ThongTinCauTaoCongTron_CCaoMong ?? 0, item.ThongTinCauTaoCongTron_CCaoDe ?? 0, item.ThongTinCauTaoCongTron_TongCCaoCong??0);
            item.TTCCCCT_CCongCongDatTBinh = (item.TTCCCCT_CCaoCongDatTLuu + item.TTCCCCT_CCaoCongDatHLuu) / 2;
            item.TTCCCCT_CCaoCongDaTLuu = TTCCCCT_CCaoCongDaTLuu(item.TTVLDCongRanh_LoaiVatLieuDao ?? "", item.TTVLDCongRanh_TLChieuCaoDaoDa ?? 0, item.TTVLDCongRanh_TLTongChieuSauDao ?? 0, item.TTCCCCT_CCaoCongDatTLuu ?? 0, item.ThongTinCauTaoCongTron_CCaoCauKien ?? 0, item.ThongTinCauTaoCongTron_TongCCaoCong ?? 0, item.ThongTinCauTaoCongTron_CCaoLotMong ?? 0, item.ThongTinCauTaoCongTron_CCaoMong ?? 0, item.ThongTinCauTaoCongTron_CCaoDe ?? 0, item.TTCCCCT_CCaoLotDaTLuu ?? 0, item.TTCCCCT_CCaoMongDaTLuu ?? 0, item.TTCCCCT_CCaoDeDaTLuu??0);
            item.TTCCCCT_CCaoCongDaHLuu = TTCCCCT_CCaoCongDaHLuu(item.TTVLDCongRanh_LoaiVatLieuDao ?? "", item.TTVLDCongRanh_HLChieuCaoDaoDa ?? 0, item.TTVLDCongRanh_HLTongChieuSauDao ?? 0, item.TTCCCCT_CCaoCongDatHLuu ?? 0, item.ThongTinCauTaoCongTron_CCaoCauKien ?? 0, item.ThongTinCauTaoCongTron_TongCCaoCong ?? 0, item.ThongTinCauTaoCongTron_CCaoLotMong ?? 0, item.ThongTinCauTaoCongTron_CCaoMong ?? 0, item.ThongTinCauTaoCongTron_CCaoDe ?? 0, item.TTCCCCT_CCaoLotDaHLuu ?? 0, item.TTCCCCT_CCaoMongDaHLuu ?? 0, item.TTCCCCT_CCaoDeDaHLuu??0);
            item.TTCCCCT_CCongCongDaTBinh = (item.TTCCCCT_CCaoCongDaTLuu + item.TTCCCCT_CCaoCongDaHLuu) / 2;

            item.TTCCCCCHR_CCaoLotDatTLuu = TTCCCCCHR_CCaoLotDatTLuu(item.TTVLDCongRanh_LoaiVatLieuDao ?? "", item.TTVLDCongRanh_TLChieuCaoDaoDat ?? 0, item.TTKTHHCongHopRanh_CCaoLotMong ??0);
            item.TTCCCCCHR_CCaoLotDatHLuu = TTCCCCCHR_CCaoLotDatHLuu(item.TTVLDCongRanh_LoaiVatLieuDao ?? "", item.TTVLDCongRanh_HLChieuCaoDaoDat ?? 0, item.TTKTHHCongHopRanh_CCaoLotMong ??0);
            item.TTCCCCCHR_CCaoLotDatTBinh = (item.TTCCCCCHR_CCaoLotDatTLuu + item.TTCCCCCHR_CCaoLotDatHLuu) / 2;
            item.TTCCCCCHR_CCaoLotDaTLuu = TTCCCCCHR_CCaoLotDaTLuu(item.TTVLDCongRanh_LoaiVatLieuDao ?? "", item.TTVLDCongRanh_TLChieuCaoDaoDa ?? 0, item.TTVLDCongRanh_TLTongChieuSauDao ?? 0, item.TTKTHHCongHopRanh_CCaoLotMong ?? 0, item.TTCCCCCHR_CCaoLotDatTLuu??0);
            item.TTCCCCCHR_CCaoLotDaHLuu = TTCCCCCHR_CCaoLotDaHLuu(item.TTVLDCongRanh_LoaiVatLieuDao ?? "", item.TTVLDCongRanh_HLChieuCaoDaoDa ?? 0, item.TTVLDCongRanh_HLTongChieuSauDao ?? 0, item.TTKTHHCongHopRanh_CCaoLotMong ?? 0, item.TTCCCCCHR_CCaoLotDatHLuu??0);
            item.TTCCCCCHR_CCaoLotDaTBinh = (item.TTCCCCCHR_CCaoLotDaTLuu + item.TTCCCCCHR_CCaoLotDaHLuu) / 2;
            item.TTCCCCCHR_CCaoMongDatTLuu = TTCCCCCHR_CCaoMongDatTLuu(item.TTVLDCongRanh_LoaiVatLieuDao ?? "", item.TTVLDCongRanh_TLChieuCaoDaoDat ?? 0, item.TTKTHHCongHopRanh_CCaoLotMong ?? 0, item.TTKTHHCongHopRanh_CCaoMong??0);
            item.TTCCCCCHR_CCaoMongDatHLuu = TTCCCCCHR_CCaoMongDatHLuu(item.TTVLDCongRanh_LoaiVatLieuDao ?? "", item.TTVLDCongRanh_HLChieuCaoDaoDat ?? 0, item.TTKTHHCongHopRanh_CCaoLotMong ?? 0, item.TTKTHHCongHopRanh_CCaoMong??0);
            item.TTCCCCCHR_CCaoMongDatTBinh = (item.TTCCCCCHR_CCaoMongDatTLuu + item.TTCCCCCHR_CCaoMongDatHLuu) / 2;
            item.TTCCCCCHR_CCaoMongDaTLuu = TTCCCCCHR_CCaoMongDaTLuu(item.TTVLDCongRanh_LoaiVatLieuDao ?? "", item.TTVLDCongRanh_TLChieuCaoDaoDa ?? 0, item.TTKTHHCongHopRanh_CCaoLotMong ?? 0, item.TTKTHHCongHopRanh_CCaoMong ?? 0, item.TTVLDCongRanh_TLTongChieuSauDao ?? 0, item.TTCCCCCHR_CCaoMongDatTLuu ?? 0, item.TTCCCCCHR_CCaoLotDaTLuu??0);
            item.TTCCCCCHR_CCaoMongDaHLuu = TTCCCCCHR_CCaoMongDaHLuu(item.TTVLDCongRanh_LoaiVatLieuDao ?? "", item.TTVLDCongRanh_HLChieuCaoDaoDa ?? 0, item.TTKTHHCongHopRanh_CCaoLotMong ?? 0, item.TTKTHHCongHopRanh_CCaoMong ?? 0, item.TTVLDCongRanh_HLTongChieuSauDao ?? 0, item.TTCCCCCHR_CCaoMongDatHLuu ?? 0, item.TTCCCCCHR_CCaoLotDaHLuu??0);
            item.TTCCCCCHR_CCaoMongDaTBinh = (item.TTCCCCCHR_CCaoMongDaTLuu + item.TTCCCCCHR_CCaoMongDaHLuu) / 2;
            item.TTCCCCCHR_CCaoTuongDatTLuu = TTCCCCCHR_CCaoTuongDatTLuu(item.TTVLDCongRanh_LoaiVatLieuDao ?? "", item.TTVLDCongRanh_TLChieuCaoDaoDat ?? 0, item.TTKTHHCongHopRanh_CCaoLotMong ?? 0, item.TTKTHHCongHopRanh_CCaoMong ?? 0, item.TTKTHHCongHopRanh_TongChieuCao ??0);
            item.TTCCCCCHR_CCaoTuongDatHLuu = TTCCCCCHR_CCaoTuongDatHLuu(item.TTVLDCongRanh_LoaiVatLieuDao ?? "", item.TTVLDCongRanh_HLChieuCaoDaoDat ?? 0, item.TTKTHHCongHopRanh_CCaoLotMong ?? 0, item.TTKTHHCongHopRanh_CCaoMong ?? 0, item.TTKTHHCongHopRanh_TongChieuCao ??0);
            item.TTCCCCCHR_CCaoTuongDatTBinh = (item.TTCCCCCHR_CCaoTuongDatTLuu + item.TTCCCCCHR_CCaoTuongDatHLuu) / 2;
            item.TTCCCCCHR_CCaoTuongDaTLuu = TTCCCCCHR_CCaoTuongDaTLuu(item.TTVLDCongRanh_LoaiVatLieuDao ?? "", item.TTVLDCongRanh_TLChieuCaoDaoDa ?? 0, item.TTKTHHCongHopRanh_CCaoLotMong ?? 0, item.TTKTHHCongHopRanh_CCaoMong ?? 0, item.TTKTHHCongHopRanh_TongChieuCao ?? 0, item.TTVLDCongRanh_TLTongChieuSauDao ?? 0, item.TTCCCCCHR_CCaoTuongDatTLuu ?? 0, item.TTCCCCCHR_CCaoLotDaTLuu ?? 0, item.TTCCCCCHR_CCaoMongDaTLuu ??0);
            item.TTCCCCCHR_CCaoTuongDaHLuu = TTCCCCCHR_CCaoTuongDaHLuu(item.TTVLDCongRanh_LoaiVatLieuDao ?? "", item.TTVLDCongRanh_HLChieuCaoDaoDa ?? 0, item.TTKTHHCongHopRanh_CCaoLotMong ?? 0, item.TTKTHHCongHopRanh_CCaoMong ?? 0, item.TTKTHHCongHopRanh_TongChieuCao ?? 0, item.TTVLDCongRanh_HLTongChieuSauDao ?? 0, item.TTCCCCCHR_CCaoTuongDatHLuu ?? 0, item.TTCCCCCHR_CCaoLotDaHLuu ?? 0, item.TTCCCCCHR_CCaoMongDaHLuu ??0);
            item.TTCCCCCHR_CCaoTuongDaTBinh = (item.TTCCCCCHR_CCaoTuongDaTLuu + item.TTCCCCCHR_CCaoTuongDaHLuu) / 2;
            item.TTCCCCON_CCaoDemCatDatTLuu = TTCCCCON_CCaoDemCatDatTLuu(item.TTVLDCongRanh_LoaiVatLieuDao ?? "", item.TTVLDCongRanh_TLChieuCaoDaoDat ?? 0, item.ThongTinKichThuocHinhHocOngNhua_CCaoDemCat ??0);
            item.TTCCCCON_CCaoDemCatDatHLuu = TTCCCCON_CCaoDemCatDatHLuu(item.TTVLDCongRanh_LoaiVatLieuDao ?? "", item.TTVLDCongRanh_HLChieuCaoDaoDat ?? 0, item.ThongTinKichThuocHinhHocOngNhua_CCaoDemCat ??0);
            item.TTCCCCON_CCaoDemCatDatTBinh = (item.TTCCCCON_CCaoDemCatDatTLuu + item.TTCCCCON_CCaoDemCatDatHLuu) / 2;
            item.TTCCCCON_CCaoDemCatDaTLuu = TTCCCCON_CCaoDemCatDaTLuu(item.TTVLDCongRanh_LoaiVatLieuDao ?? "", item.TTVLDCongRanh_TLChieuCaoDaoDa ?? 0, item.TTVLDCongRanh_TLTongChieuSauDao ?? 0, item.ThongTinKichThuocHinhHocOngNhua_CCaoDemCat ?? 0, item.TTCCCCON_CCaoDemCatDatTLuu ??0);
            item.TTCCCCON_CCaoDemCatDaHLuu = TTCCCCON_CCaoDemCatDaHLuu(item.TTVLDCongRanh_LoaiVatLieuDao ?? "", item.TTVLDCongRanh_HLChieuCaoDaoDa ?? 0, item.TTVLDCongRanh_HLTongChieuSauDao ?? 0, item.ThongTinKichThuocHinhHocOngNhua_CCaoDemCat ?? 0, item.TTCCCCON_CCaoDemCatDatHLuu ??0);
            item.TTCCCCON_CCaoDemCatDaTBinh = (item.TTCCCCON_CCaoDemCatDaTLuu + item.TTCCCCON_CCaoDemCatDaHLuu) / 2;
            item.TTCCCCON_CCaoOngDatTLuu = TTCCCCON_CCaoOngDatTLuu(item.TTVLDCongRanh_LoaiVatLieuDao ?? "", item.TTVLDCongRanh_TLChieuCaoDaoDat ?? 0, item.ThongTinKichThuocHinhHocOngNhua_CCaoDemCat ?? 0, item.ThongTinKichThuocHinhHocOngNhua_TongCCaoOng ??0);
            item.TTCCCCON_CCaoOngDatHLuu = TTCCCCON_CCaoOngDatHLuu(item.TTVLDCongRanh_LoaiVatLieuDao ?? "", item.TTVLDCongRanh_HLChieuCaoDaoDat ?? 0, item.ThongTinKichThuocHinhHocOngNhua_CCaoDemCat ?? 0, item.ThongTinKichThuocHinhHocOngNhua_TongCCaoOng ??0);
            item.TTCCCCON_CCaoDatTBinh = (item.TTCCCCON_CCaoOngDatTLuu + item.TTCCCCON_CCaoOngDatHLuu) / 2;
            item.TTCCCCON_CCaoOngDaTLuu = TTCCCCON_CCaoOngDaTLuu(item.TTVLDCongRanh_LoaiVatLieuDao ?? "", item.TTVLDCongRanh_TLChieuCaoDaoDa ?? 0, item.ThongTinKichThuocHinhHocOngNhua_CCaoDemCat ?? 0, item.ThongTinKichThuocHinhHocOngNhua_TongCCaoOng ?? 0, item.TTVLDCongRanh_TLTongChieuSauDao ?? 0, item.TTCCCCON_CCaoOngDatTLuu ?? 0, item.TTCCCCON_CCaoDemCatDaTLuu ??0);
            item.TTCCCCON_CCaoOngDaHLuu = TTCCCCON_CCaoOngDaHLuu(item.TTVLDCongRanh_LoaiVatLieuDao ?? "", item.TTVLDCongRanh_HLChieuCaoDaoDa ?? 0, item.ThongTinKichThuocHinhHocOngNhua_CCaoDemCat ?? 0, item.ThongTinKichThuocHinhHocOngNhua_TongCCaoOng ?? 0, item.TTVLDCongRanh_HLTongChieuSauDao ?? 0, item.TTCCCCON_CCaoOngDatHLuu ?? 0, item.TTCCCCON_CCaoDemCatDaHLuu ??0);
            item.TTCCCCON_CCaoDaTBinh = (item.TTCCCCON_CCaoOngDaTLuu + item.TTCCCCON_CCaoOngDaHLuu) / 2;
            
            item.TTCCCCON_CCaoDapCatDatTLuu = TTCCCCON_CCaoDapCatDatTLuu(item.TTVLDCongRanh_LoaiVatLieuDao ?? "", item.TTVLDCongRanh_TLChieuCaoDaoDat ?? 0, item.ThongTinKichThuocHinhHocOngNhua_CCaoDemCat ?? 0, item.ThongTinKichThuocHinhHocOngNhua_TongCCaoOng ?? 0, item.ThongTinKichThuocHinhHocOngNhua_CCaoDapCat ??0);
            item.TTCCCCON_CCaoDapCatDatHLuu = TTCCCCON_CCaoDapCatDatHLuu(item.TTVLDCongRanh_LoaiVatLieuDao ?? "", item.TTVLDCongRanh_HLChieuCaoDaoDat ?? 0, item.ThongTinKichThuocHinhHocOngNhua_CCaoDemCat ?? 0, item.ThongTinKichThuocHinhHocOngNhua_TongCCaoOng ?? 0, item.ThongTinKichThuocHinhHocOngNhua_CCaoDapCat ??0);
            item.TTCCCCON_CCaoDapCatDatTBinh = (item.TTCCCCON_CCaoDapCatDatTLuu + item.TTCCCCON_CCaoDapCatDatHLuu) / 2;
            item.TTCCCCON_CCaoDapCatDaTLuu = TTCCCCON_CCaoDapCatDaTLuu(item.TTVLDCongRanh_LoaiVatLieuDao ?? "", item.TTVLDCongRanh_TLChieuCaoDaoDa ?? 0, item.ThongTinKichThuocHinhHocOngNhua_TongCCaoOng ?? 0, item.ThongTinKichThuocHinhHocOngNhua_CCaoDemCat ?? 0, item.ThongTinKichThuocHinhHocOngNhua_CCaoDapCat ?? 0, item.TTVLDCongRanh_TLTongChieuSauDao ?? 0, item.TTCCCCON_CCaoDapCatDatTLuu ?? 0, item.TTCCCCON_CCaoDemCatDaTLuu ?? 0, item.TTCCCCON_CCaoOngDaTLuu ??0);
            item.TTCCCCON_CCaoDapCatDaHLuu = TTCCCCON_CCaoDapCatDaHLuu(item.TTVLDCongRanh_LoaiVatLieuDao ?? "", item.TTVLDCongRanh_HLChieuCaoDaoDa ?? 0, item.ThongTinKichThuocHinhHocOngNhua_TongCCaoOng ?? 0, item.ThongTinKichThuocHinhHocOngNhua_CCaoDemCat ?? 0, item.ThongTinKichThuocHinhHocOngNhua_CCaoDapCat ?? 0, item.TTVLDCongRanh_HLTongChieuSauDao ?? 0, item.TTCCCCON_CCaoDapCatDatHLuu ?? 0, item.TTCCCCON_CCaoDemCatDaTLuu ?? 0, item.TTCCCCON_CCaoOngDaTLuu ??0);
            item.TTCCCCON_CCaoDapCatDaTBinh = (item.TTCCCCON_CCaoDapCatDaTLuu + item.TTCCCCON_CCaoDapCatDaHLuu) / 2;
            //item.TTCCRT_LotDatThuongLuu = TTCCRT_LotDatThuongLuu(item.TTVLDCongRanh_LoaiVatLieuDao??0, item.TTVLDCongRanh_TLChieuCaoDaoDat??0, item.ThongTinRanhThang_CCaoLot??0);
            //item.TTCCRT_LotDatHaLuu = TTCCRT_LotDatHaLuu(item.TTVLDCongRanh_LoaiVatLieuDao??0, item.TTVLDCongRanh_HLChieuCaoDaoDat??0, item.ThongTinRanhThang_CCaoLot??0);
            //item.TTCCRT_LotDatTrungBinh = (item.TTCCRT_LotDatThuongLuu + item.TTCCRT_LotDatHaLuu) / 2;
            //item.TTCCRT_LotDaThuongLuu = TTCCRT_LotDaThuongLuu(item.TTVLDCongRanh_LoaiVatLieuDao??0, item.TTVLDCongRanh_TLChieuCaoDaoDa??0, item.TTVLDCongRanh_TLTongChieuSauDao??0, item.ThongTinRanhThang_CCaoLot??0, item.TTCCRT_LotDatThuongLuu??0);
            //item.TTCCRT_LotDaHaLuu = TTCCRT_LotDaHaLuu(item.TTVLDCongRanh_LoaiVatLieuDao??0, item.TTVLDCongRanh_HLChieuCaoDaoDa??0, item.TTVLDCongRanh_HLTongChieuSauDao??0, item.ThongTinRanhThang_CCaoLot??0, item.TTCCRT_LotDatHaLuu??0);
            //item.TTCCRT_LotDaTrungBinh = (item.TTCCRT_LotDaThuongLuu + item.TTCCRT_LotDaHaLuu) / 2;
            //item.TTCCRT_MongDatThuongLuu = TTCCRT_MongDatThuongLuu(item.TTVLDCongRanh_LoaiVatLieuDao??0, item.TTVLDCongRanh_TLChieuCaoDaoDat??0, item.ThongTinRanhThang_CCaoLot??0, item.ThongTinRanhThang_CCaoMong??0);
            //item.TTCCRT_MongDatHaLuu = TTCCRT_MongDatHaLuu(item.TTVLDCongRanh_LoaiVatLieuDao??0, item.TTVLDCongRanh_HLChieuCaoDaoDat??0, item.ThongTinRanhThang_CCaoLot??0, item.ThongTinRanhThang_CCaoMong??0);
            //item.TTCCRT_MongDatTrungBinh = (item.TTCCRT_MongDatThuongLuu + item.TTCCRT_MongDatHaLuu) / 2;
            //item.TTCCRT_MongDaThuongLuu = TTCCRT_MongDaThuongLuu(item.TTVLDCongRanh_LoaiVatLieuDao??0, item.TTVLDCongRanh_TLChieuCaoDaoDa??0, item.ThongTinRanhThang_CCaoLot??0, item.ThongTinRanhThang_CCaoMong??0, item.TTVLDCongRanh_TLTongChieuSauDao??0, item.TTCCRT_MongDatThuongLuu??0, item.TTCCRT_LotDaThuongLuu??0);
            //item.TTCCRT_MongDaHaLuu = TTCCRT_MongDaHaLuu(item.TTVLDCongRanh_LoaiVatLieuDao??0, item.TTVLDCongRanh_HLChieuCaoDaoDa??0, item.ThongTinRanhThang_CCaoLot??0, item.ThongTinRanhThang_CCaoMong??0, item.TTVLDCongRanh_HLTongChieuSauDao??0, item.TTCCRT_MongDatHaLuu??0, item.TTCCRT_LotDaHaLuu??0);
            //item.TTCCRT_MongDaTrungBinh = (item.TTCCRT_MongDaThuongLuu + item.TTCCRT_MongDaHaLuu) / 2;

            item.DTDTLCRONRT_CRongDaoDatDayLon = DTDTLCRONRT_CRongDaoDatDayLon(item.TTVLDCongRanh_TLChieuCaoDaoDat ?? 0, item.TTMDRanhOngThang_TyLeMoMai ?? 0, item.TTMDRanhOngThang_SoCanhMaiTrai ?? 0, item.TTMDRanhOngThang_SoCanhMaiPhai ?? 0, item.TTMDRanhOngThang_ChieuRongDayDaoNho ??0);
            item.DTDTLCRONRT_DTichDaoDat = DTDTLCRONRT_DTichDaoDat(item.DTDTLCRONRT_CRongDaoDatDayLon ?? 0, item.TTMDRanhOngThang_ChieuRongDayDaoNho ?? 0, item.TTVLDCongRanh_TLChieuCaoDaoDat ??0);
            item.DTDTLCRONRT_CRongDaoDaDayLon = DTDTLCRONRT_CRongDaoDaDayLon(item.TTVLDCongRanh_TLChieuCaoDaoDa ?? 0, item.TTMDRanhOngThang_TyLeMoMai ?? 0, item.TTMDRanhOngThang_SoCanhMaiTrai ?? 0, item.TTMDRanhOngThang_SoCanhMaiPhai ?? 0, item.DTDTLCRONRT_CRongDaoDatDayLon ?? 0, item.TTMDRanhOngThang_ChieuRongDayDaoNho ??0);
            item.DTDTLCRONRT_DTichDaoDa = DTDTLCRONRT_DTichDaoDa(item.DTDTLCRONRT_CRongDaoDatDayLon ?? 0, item.DTDTLCRONRT_CRongDaoDaDayLon ?? 0, item.TTVLDCongRanh_TLChieuCaoDaoDa ?? 0, item.TTMDRanhOngThang_ChieuRongDayDaoNho ??0);
            item.DTDHLCRONRT_CRongDaoDatDayLon = DTDHLCRONRT_CRongDaoDatDayLon(item.TTVLDCongRanh_HLChieuCaoDaoDat ?? 0, item.TTMDRanhOngThang_TyLeMoMai ?? 0, item.TTMDRanhOngThang_SoCanhMaiTrai ?? 0, item.TTMDRanhOngThang_SoCanhMaiPhai ?? 0, item.TTMDRanhOngThang_ChieuRongDayDaoNho ??0);
            item.DTDHLCRONRT_DTichDaoDat = DTDHLCRONRT_DTichDaoDat(item.DTDHLCRONRT_CRongDaoDatDayLon ?? 0, item.TTMDRanhOngThang_ChieuRongDayDaoNho ?? 0, item.TTVLDCongRanh_HLChieuCaoDaoDat ??0);
            item.DTDHLCRONRT_CRongDaoDaDayLon = DTDHLCRONRT_CRongDaoDaDayLon(item.TTVLDCongRanh_HLChieuCaoDaoDa ?? 0, item.TTMDRanhOngThang_TyLeMoMai ?? 0, item.TTMDRanhOngThang_SoCanhMaiTrai ?? 0, item.TTMDRanhOngThang_SoCanhMaiPhai ?? 0, item.DTDHLCRONRT_CRongDaoDatDayLon ?? 0, item.TTMDRanhOngThang_ChieuRongDayDaoNho ??0);
            item.DTDHLCRONRT_DTichDaoDa = DTDHLCRONRT_DTichDaoDa(item.DTDHLCRONRT_CRongDaoDatDayLon ?? 0, item.DTDHLCRONRT_CRongDaoDaDayLon ?? 0, item.TTVLDCongRanh_HLChieuCaoDaoDa ?? 0, item.TTMDRanhOngThang_ChieuRongDayDaoNho ??0);


            item.DTDTB_DaoDatCRDaoDayLon = DTDTB_DaoDatCRDaoDayLon(item.DTDTLCRONRT_CRongDaoDatDayLon ??0 , item.DTDHLCRONRT_CRongDaoDatDayLon ??0);
            item.DTDTB_DaoDatDTDao = DTDTB_DaoDatDTDao(item.DTDTLCRONRT_DTichDaoDat ?? 0 , item.DTDHLCRONRT_DTichDaoDat ?? 0);
            item.DTDTB_DaoDaCRDaoDayLon = DTDTB_DaoDaCRDaoDayLon(item.DTDTLCRONRT_CRongDaoDaDayLon ?? 0 , item.DTDHLCRONRT_CRongDaoDaDayLon ?? 0) ;
            item.DTDTB_DaoDaDTDao = DTDTB_DaoDaDTDao(item.DTDTLCRONRT_DTichDaoDa ?? 0 ,item.DTDHLCRONRT_DTichDaoDa ?? 0) ;

            item.TKLD_KlDaoDat = TKLD_KlDaoDat(item.DTDTLCRONRT_DTichDaoDat ?? 0, item.DTDHLCRONRT_DTichDaoDat ?? 0, item.TTCDSLCauKienDuongTruyenDan_TongChieuDai ??0);
            item.TKLD_KlDaoDa = TKLD_KlDaoDa(item.DTDTLCRONRT_DTichDaoDa ?? 0, item.DTDHLCRONRT_DTichDaoDa ?? 0, item.TTCDSLCauKienDuongTruyenDan_TongChieuDai ??0);
            item.TKLD_TongKlDaoCongRanhOngNhuaRanhThang = TKLD_TongKlDaoCongRanhOngNhuaRanhThang(item.TKLD_KlDaoDat ?? 0, item.TKLD_KlDaoDa ??0);
            //item.TKLD_ChanKhay = TKLD_ChanKhay(item.DTDCKRD_CKDTichDao??0, item.TTCDSLCauKienDuongTruyenDan_TongChieuDai??0);
            //item.TKLD_GiangDinh = TKLD_GiangDinh(item.DTDCKRD_DTichDao??0, item.TTCDSLCauKienDuongTruyenDan_TongChieuDai??0);
            //item.TKLD_TongKlDaoDatChanKhayRanhDinh = (item.TKLD_ChanKhay + item.TKLD_GiangDinh??0);
            //item.TKLD_TongKlDaoDat = TKLD_TongKlDaoDat(item.TKLD_KlDaoDat??0, item.TKLD_TongKlDaoDatChanKhayRanhDinh??0);
            //item.TKLD_TongKlDaoDa = TKLD_TongKlDaoDa(item.TKLD_KlDaoDa??0);
            //item.TKLD_TongKlDao = TKLD_TongKlDao(item.TKLD_TongKlDaoDat??0, item.TKLD_TongKlDaoDa??0);
            item.TKLD_KlCChoDatCongTron = TKLD_KlCChoDatCongTron(item.TTCCCCT_CCaoLotDatMongTBinh ?? 0, item.ThongTinCauTaoCongTron_CRongLotMong ?? 0, item.ThongTinCauTaoCongTron_CRongMong ?? 0, item.TTCCCCT_CCaoMongDatTBinh ?? 0, item.TTCCCCT_CCongCongDatTBinh ?? 0, item.TTCDSLCauKienDuongTruyenDan_TongChieuDai ?? 0, item.TTCCCCT_CCaoDeDatTBinh ?? 0, item.ThongTinDeCong_Kl01DeCong ?? 0, item.ThongTinDeCong_TongSoLuongDC ??0);
            item.TKLD_KlCChoDaCongTron = TKLD_KlCChoDaCongTron(item.TTCCCCT_CCaoLotDaMongTBinh ?? 0, item.ThongTinCauTaoCongTron_CRongLotMong ?? 0, item.ThongTinCauTaoCongTron_CRongMong ?? 0, item.TTCCCCT_CCaoMongDaTBinh ?? 0, item.TTCCCCT_CCongCongDaTBinh ?? 0, item.TTCDSLCauKienDuongTruyenDan_TongChieuDai ?? 0, item.TTCCCCT_CCaoDeDaTBinh ?? 0, item.ThongTinDeCong_Kl01DeCong ?? 0, item.ThongTinDeCong_TongSoLuongDC ??0);
            item.TKLD_TongKlChiemChoCTron = TKLD_TongKlChiemChoCTron(item.TKLD_KlCChoDatCongTron ?? 0, item.TKLD_KlCChoDaCongTron ??0);
            item.TKLD_KlCChoDatCongHop = TKLD_KlCChoDatCongHop(item.ThongTinDuongTruyenDan_HinhThucTruyenDan ?? "", item.TTCCCCCHR_CCaoLotDatTBinh ?? 0, item.TTKTHHCongHopRanh_CRongLotMong ?? 0, item.TTKTHHCongHopRanh_CRongMong ?? 0, item.TTCCCCCHR_CCaoMongDatTBinh ?? 0, item.TTCCCCCHR_CCaoTuongDatTBinh ?? 0, item.TTKTHHCongHopRanh_CDayTuong01Ben ?? 0, item.TTKTHHCongHopRanh_SoLuongTuong ?? 0, item.TTKTHHCongHopRanh_CRongLongSuDung ?? 0, item.TTCDSLCauKienDuongTruyenDan_TongChieuDai ??0);
            item.TKLD_KlCChoDaCongHop = TKLD_KlCChoDaCongHop(item.ThongTinDuongTruyenDan_HinhThucTruyenDan ?? "", item.TTCCCCCHR_CCaoLotDaTBinh ?? 0, item.TTKTHHCongHopRanh_CRongLotMong ?? 0, item.TTKTHHCongHopRanh_CRongMong ?? 0, item.TTCCCCCHR_CCaoMongDaTBinh ?? 0, item.TTCCCCCHR_CCaoTuongDaTBinh ?? 0, item.TTKTHHCongHopRanh_CDayTuong01Ben ?? 0, item.TTKTHHCongHopRanh_SoLuongTuong ?? 0, item.TTKTHHCongHopRanh_CRongLongSuDung ?? 0, item.TTCDSLCauKienDuongTruyenDan_TongChieuDai ??0);
            item.TKLD_TongKlCChoCongHop = TKLD_TongKlCChoCongHop(item.TKLD_KlCChoDatCongHop ?? 0, item.TKLD_KlCChoDaCongHop ??0);
            item.TKLD_KlCChoDatRanh = TKLD_KlCChoDatRanh(item.TTCCCCCHR_CCaoLotDatTBinh ?? 0, item.TTKTHHCongHopRanh_CRongLotMong ?? 0, item.TTKTHHCongHopRanh_CRongMong ?? 0, item.TTCCCCCHR_CCaoMongDatTBinh ?? 0, item.TTCCCCCHR_CCaoTuongDatTBinh ?? 0, item.TTKTHHCongHopRanh_CDayTuong01Ben ?? 0, item.TTKTHHCongHopRanh_SoLuongTuong ?? 0, item.TTKTHHCongHopRanh_CRongLongSuDung ?? 0, item.TTCDSLCauKienDuongTruyenDan_TongChieuDai ?? 0, item.ThongTinDuongTruyenDan_HinhThucTruyenDan ?? "");
            item.TKLD_KlCChoDaRanh = TKLD_KlCChoDaRanh(item.TTCCCCCHR_CCaoLotDaTBinh ?? 0, item.TTKTHHCongHopRanh_CRongLotMong ?? 0, item.TTKTHHCongHopRanh_CRongMong ?? 0, item.TTCCCCCHR_CCaoMongDaTBinh ?? 0, item.TTCCCCCHR_CCaoTuongDaTBinh ?? 0, item.TTKTHHCongHopRanh_CDayTuong01Ben ?? 0, item.TTKTHHCongHopRanh_SoLuongTuong ?? 0, item.TTKTHHCongHopRanh_CRongLongSuDung ?? 0, item.TTCDSLCauKienDuongTruyenDan_TongChieuDai ?? 0, item.ThongTinDuongTruyenDan_HinhThucTruyenDan ?? "");
            item.TKLD_TongKlCChoRanh = TKLD_TongKlCChoRanh(item.TKLD_KlCChoDatRanh ?? 0, item.TKLD_KlCChoDaRanh ??0);
            item.TKLD_KlCChoDatOngNhua = TKLD_KlCChoDatOngNhua(item.TTCCCCON_CCaoDemCatDatTBinh ?? 0, item.TTCCCCON_CCaoDatTBinh ?? 0, item.TTCCCCON_CCaoDapCatDatTBinh ?? 0, item.TTMDRanhOngThang_TyLeMoMai ?? 0, item.TTMDRanhOngThang_SoCanhMaiTrai ?? 0, item.TTMDRanhOngThang_SoCanhMaiPhai ?? 0, item.TTMDRanhOngThang_ChieuRongDayDaoNho ?? 0, item.TTCDSLCauKienDuongTruyenDan_TongChieuDai ??0);
            item.TKLD_KlCChoDaOngNhua = TKLD_KlCChoDaOngNhua(item.TTCCCCON_CCaoDemCatDaTBinh ?? 0, item.TTCCCCON_CCaoDaTBinh ?? 0, item.TTCCCCON_CCaoDapCatDaTBinh ?? 0, item.TTMDRanhOngThang_TyLeMoMai ?? 0, item.TTMDRanhOngThang_SoCanhMaiTrai ?? 0, item.TTMDRanhOngThang_SoCanhMaiPhai ?? 0, item.TTMDRanhOngThang_ChieuRongDayDaoNho ?? 0, item.TTCDSLCauKienDuongTruyenDan_TongChieuDai ??0);
            item.TKLD_TongKlCChoOngNhua = TKLD_TongKlCChoOngNhua(item.TKLD_KlCChoDatOngNhua ?? 0, item.TKLD_KlCChoDaOngNhua ??0);
            //item.TKLD_KlCChoDatRanhThang = TKLD_KlCChoDatRanhThang(item.TTCCRT_LotDatTrungBinh??0, item.ThongTinRanhThang_CRongLot??0, item.ThongTinRanhThang_CRongMong??0, item.TTCCRT_MongDatTrungBinh??0, item.TTCDSLCauKienDuongTruyenDan_TongChieuDai??0);
            //item.TKLD_KlCChoDaRanhThang = TKLD_KlCChoDaRanhThang(item.TTCCRT_LotDaTrungBinh??0, item.ThongTinRanhThang_CRongLot??0, item.ThongTinRanhThang_CRongMong??0, item.TTCCRT_MongDaTrungBinh??0, item.TTCDSLCauKienDuongTruyenDan_TongChieuDai??0);
            //item.TKLD_TongKlCChoRanhThang = TKLD_TongKlCChoRanhThang(item.TKLD_KlCChoDatRanhThang??0, item.TKLD_KlCChoDaRanhThang??0);
            //item.TKLD_KlCChoDatChanKhay = TKLD_KlCChoDatChanKhay(item.ThongTinRanhThang_CCaoLotChanKhay??0, item.ThongTinRanhThang_CRongLotChanKhay??0, item.ThongTinRanhThang_SoLuongLotChanKhay??0, item.ThongTinRanhThang_CCaoMongChanKhay??0, item.ThongTinRanhThang_CRongMongChanKhay??0, item.ThongTinRanhThang_SoLuongMongChanKhay??0, item.TTCDSLCauKienDuongTruyenDan_TongChieuDai??0);
            //item.TKLD_KlCChoDatChanGiangDinh = TKLD_KlCChoDatChanGiangDinh(item.ThongTinRanhThang_CCaoLotGiangDinh??0, item.ThongTinRanhThang_CRongLotGiangDinh??0, item.ThongTinRanhThang_SoLuongLotGiangDinh??0, item.ThongTinRanhThang_CCaoMongGiangDinh??0, item.ThongTinRanhThang_CRongMongGiangDinh??0, item.ThongTinRanhThang_SoLuongMongGiangDinh??0, item.TTCDSLCauKienDuongTruyenDan_TongChieuDai??0);
            //item.TKLD_TongKlCChoDat = TKLD_TongKlCChoDat(item.TKLD_KlCChoDatRanhThang??0, item.TKLD_KlCChoDatChanKhay??0, item.TKLD_KlCChoDatChanGiangDinh??0);
            //item.TKLD_TongKlCChoDa = TKLD_TongKlCChoDa(item.TKLD_KlCChoDaRanhThang??0);
            //item.TKLD_TongKlCCho = TKLD_TongKlCCho(item.TKLD_TongKlCChoDat??0, item.TKLD_TongKlCChoDa??0);
            item.TKLD_KlCChoDat = TKLD_KlCChoDat(item.TKLD_KlCChoDatCongTron??0, item.TKLD_KlCChoDatCongHop??0, item.TKLD_KlCChoDatRanh??0, item.TKLD_KlCChoDatOngNhua??0);
            item.TKLD_KlCChoDa = TKLD_KlCChoDa(item.TKLD_KlCChoDaCongTron??0, item.TKLD_KlCChoDaCongHop??0, item.TKLD_KlCChoDaRanh??0, item.TKLD_KlCChoDaOngNhua??0);
            
            item.TKLD_TongChiemCho = TKLD_TongChiemCho(item.TKLD_KlCChoDat ?? 0, item.TKLD_KlCChoDa ??0);
            item.TKLD_KlDapTraDat = Math.Round((item.TKLD_KlDaoDat - item.TKLD_KlCChoDat) ?? 0, 2);
            item.TKLD_KlDapTraDa = Math.Round((item.TTKLD_KlDaoDa - item.TKLD_KlCChoDa) ?? 0, 2);
            item.TKLD_TongKlDapTra = TKLD_TongKlDapTra(item.TKLD_KlDapTraDat ?? 0, item.TKLD_KlDapTraDa ??0);
            item.TKLD_KlThuaDat = item.TKLD_KlCChoDat;
            item.TKLD_KlThuaDa = item.TKLD_KlCChoDa;
            item.TKLD_TongKLThua = item.TKLD_TongChiemCho;
            item.DTDC_TLCSauDap = DTDC_TLCSauDap(item.ThongTinKichThuocHinhHocOngNhua_TongCCaoOng ?? 0, item.ThongTinKichThuocHinhHocOngNhua_CCaoDemCat ?? 0, item.ThongTinKichThuocHinhHocOngNhua_CCaoDapCat ?? 0, item.ThongTinDuongTruyenDan_HinhThucTruyenDan ?? "", item.ThongTinMongDuongTruyenDan_LoaiMong ?? "");
            item.DTDC_TLCRongDapDayLon = DTDC_TLCRongDapDayLon(item.DTDC_TLCSauDap ?? 0, item.TTMDRanhOngThang_TyLeMoMai ?? 0, item.TTMDRanhOngThang_SoCanhMaiTrai ?? 0, item.TTMDRanhOngThang_SoCanhMaiPhai ?? 0, item.TTMDRanhOngThang_ChieuRongDayDaoNho ?? 0, item.ThongTinDuongTruyenDan_HinhThucTruyenDan ?? "", item.ThongTinMongDuongTruyenDan_LoaiMong??"");
            item.DTDC_TLDTichDap = DTDC_TLDTichDap(item.DTDC_TLCRongDapDayLon ?? 0, item.TTMDRanhOngThang_ChieuRongDayDaoNho ?? 0, item.ThongTinKichThuocHinhHocOngNhua_TongCCaoOng ?? 0, item.ThongTinKichThuocHinhHocOngNhua_CCaoDemCat ?? 0, item.ThongTinKichThuocHinhHocOngNhua_CCaoDapCat ?? 0, item.ThongTinDuongTruyenDan_HinhThucTruyenDan ?? "", item.ThongTinMongDuongTruyenDan_LoaiMong ?? "");
            item.DTDC_HLCSauDap = DTDC_HLCSauDap(item.ThongTinKichThuocHinhHocOngNhua_TongCCaoOng ?? 0, item.ThongTinKichThuocHinhHocOngNhua_CCaoDemCat ?? 0, item.ThongTinKichThuocHinhHocOngNhua_CCaoDapCat ?? 0, item.ThongTinDuongTruyenDan_HinhThucTruyenDan ?? "", item.ThongTinMongDuongTruyenDan_LoaiMong?? "");
            item.DTDC_HLCRongDapDayLon = DTDC_HLCRongDapDayLon(item.DTDC_HLCSauDap ?? 0, item.TTMDRanhOngThang_TyLeMoMai ?? 0, item.TTMDRanhOngThang_SoCanhMaiTrai ?? 0, item.TTMDRanhOngThang_SoCanhMaiPhai ?? 0, item.TTMDRanhOngThang_ChieuRongDayDaoNho ?? 0, item.ThongTinDuongTruyenDan_HinhThucTruyenDan ?? "", item.ThongTinMongDuongTruyenDan_LoaiMong?? "");
            item.DTDC_HLDTichDap = DTDC_HLDTichDap(item.DTDC_HLCRongDapDayLon ?? 0, item.TTMDRanhOngThang_ChieuRongDayDaoNho ?? 0, item.ThongTinKichThuocHinhHocOngNhua_TongCCaoOng ?? 0, item.ThongTinKichThuocHinhHocOngNhua_CCaoDemCat ?? 0, item.ThongTinKichThuocHinhHocOngNhua_CCaoDapCat ?? 0, item.ThongTinDuongTruyenDan_HinhThucTruyenDan ?? "", item.ThongTinMongDuongTruyenDan_LoaiMong?? "");
            item.TTKLDC_KlDapCatTruocChiemCho = TTKLDC_KlDapCatTruocChiemCho(item.DTDC_TLDTichDap ?? 0, item.DTDC_HLDTichDap ?? 0, item.TTCDSLCauKienDuongTruyenDan_TongChieuDai??0);
            item.TTKLDC_KlChiemCho = TTKLDC_KlChiemCho(item.ThongTinKichThuocHinhHocOngNhua_TongCCaoOng ?? 0, item.TTCDSLCauKienDuongTruyenDan_TongChieuDai ?? 0, item.ThongTinDuongTruyenDan_HinhThucTruyenDan ?? "", item.ThongTinMongDuongTruyenDan_LoaiMong?? "");
            item.TTKLDC_KlDapCatSauChiemCho = Math.Round(item.TTKLDC_KlDapCatTruocChiemCho - item.TTKLDC_KlChiemCho ?? 0, 2);

            return item;
        }

        public double ThongTinCaoDoHoGa_CaoDoHienTrangTruocKhiDao(double ThongTinCaoDoHoGa_CaoDoTuNhien, double ThongTinCaoDoHoGa_CaoDoDinhK98 , double ThongTinCaoDoHoGa_CdDinhViaHeHoanThien)
        {
            double result =0;

            if (ThongTinCaoDoHoGa_CaoDoTuNhien < ThongTinCaoDoHoGa_CaoDoDinhK98)
            {
                result = ThongTinCaoDoHoGa_CaoDoDinhK98;
            }
            else if (ThongTinCaoDoHoGa_CaoDoTuNhien >= ThongTinCaoDoHoGa_CdDinhViaHeHoanThien)
            {
                result = ThongTinCaoDoHoGa_CdDinhViaHeHoanThien;
            }
            else
            {
                result = ThongTinCaoDoHoGa_CaoDoTuNhien;
            }
            result = Math.Round(result, 3);
            return Math.Round(result, 2 , MidpointRounding.AwayFromZero);
        }

        public double ThongTinCaoDoHoGa_CdDinhMong(string ThongTinChungHoGa_HinhThucHoGa, string ThongTinChungHoGa_HinhThucMongHoGa, double ThongTinCaoDoHoGa_CdDayHoGa, double DeHoGa_C)
        {
            double result = 0;
            ThongTinChungHoGa_HinhThucHoGa = GetTenDanhMucById(ThongTinChungHoGa_HinhThucHoGa);
            ThongTinChungHoGa_HinhThucMongHoGa = GetTenDanhMucById(ThongTinChungHoGa_HinhThucMongHoGa);
            if (ThongTinChungHoGa_HinhThucHoGa.ToUpper().Trim() == "Lắp đặt".ToUpper()
            && ThongTinChungHoGa_HinhThucMongHoGa.ToUpper().Trim() == "Có móng".ToUpper())
            {
                result = ThongTinCaoDoHoGa_CdDayHoGa - DeHoGa_C;
            }
            else
            {
                result =  ThongTinCaoDoHoGa_CdDayHoGa;
            }
            result = Math.Round(result, 3);
            return Math.Round(result, 2, MidpointRounding.AwayFromZero);
        }

        public double ThongTinCaoDoHoGa_DinhLotMong(string ThongTinChungHoGa_HinhThucMongHoGa, double ThongTinCaoDoHoGa_CdDinhMong, double BeTongMongHoGa_C)
        {
            double result = 0;
            if (ThongTinChungHoGa_HinhThucMongHoGa == "Không có móng")
            {
                result =  0;
            }
            else
            {
                result = ThongTinCaoDoHoGa_CdDinhMong - BeTongMongHoGa_C;
            }
            result = Math.Round(result, 3);
            return Math.Round(result, 2, MidpointRounding.AwayFromZero);
        }

        public double ThongTinCaoDoHoGa_DayDao(string ThongTinChungHoGa_HinhThucHoGa, string ThongTinChungHoGa_HinhThucMongHoGa, double ThongTinCaoDoHoGa_DinhLotMong, double BeTongLotMong_C, double ThongTinCaoDoHoGa_CdDayHoGa, double DeHoGa_C)
        {
            double result = 0;
            ThongTinChungHoGa_HinhThucMongHoGa = GetTenDanhMucById(ThongTinChungHoGa_HinhThucMongHoGa).ToUpper().Trim();
            ThongTinChungHoGa_HinhThucHoGa = GetTenDanhMucById(ThongTinChungHoGa_HinhThucHoGa).ToUpper().Trim();
            if (ThongTinChungHoGa_HinhThucMongHoGa == "Có móng".ToUpper())
            {
                result = ThongTinCaoDoHoGa_DinhLotMong - BeTongLotMong_C;
            }
            else if (ThongTinChungHoGa_HinhThucHoGa == "Lắp đặt".ToUpper() && ThongTinChungHoGa_HinhThucMongHoGa == "Không có móng".ToUpper())
            {
                result = ThongTinCaoDoHoGa_CdDayHoGa - DeHoGa_C;
            }
            else
            {
                result = ThongTinCaoDoHoGa_CdDayHoGa;
            }

            result = Math.Round(result, 3);
            return Math.Round(result, 2, MidpointRounding.AwayFromZero);
        }
        public double ThongTinCaoDoHoGa_CSauDao(double ThongTinCaoDoHoGa_CaoDoHienTrangTruocKhiDao, double ThongTinCaoDoHoGa_DayDao)
        {
            return Math.Round(ThongTinCaoDoHoGa_CaoDoHienTrangTruocKhiDao - ThongTinCaoDoHoGa_DayDao, 2);
        }
        public double ThongTinVatLieuDaoHoGa_ChieuCaoDaoDat(string ThongTinVatLieuDaoHoGa_LoaiVatLieuDao, double ThongTinCaoDoHoGa_CSauDao, double ThongTinVatLieuDaoHoGa_ChieuCaoDaoDa)
        {
            double result = 0;
            ThongTinVatLieuDaoHoGa_LoaiVatLieuDao = GetTenDanhMucById(ThongTinVatLieuDaoHoGa_LoaiVatLieuDao).ToUpper().Trim();
            if (string.IsNullOrEmpty(ThongTinVatLieuDaoHoGa_LoaiVatLieuDao))
            {
                result = 0;
            }
            else if (ThongTinVatLieuDaoHoGa_LoaiVatLieuDao == "Đào đá".ToUpper())
            {
                result = 0;
            }
            else
            {
                result = ThongTinCaoDoHoGa_CSauDao - ThongTinVatLieuDaoHoGa_ChieuCaoDaoDa;
            }
            result = Math.Round(result, 3);
            return Math.Round(result, 2, MidpointRounding.AwayFromZero);
        }

        public double ChatMatNgoaiCanh_C(string ThongTinChungHoGa_ChatMatNgoai, string ThongTinChungHoGa_KetCauTuong, string ThongTinChungHoGa_KetCauMuMo, double TuongHoGa_C, double DamGiuaHoGa_CdDam, double MuMoThotDuoi_C, double MuMoThotTren_C, double MuMoThotTren_CdTuong)
        {
            ThongTinChungHoGa_KetCauMuMo = GetTenDanhMucById(ThongTinChungHoGa_KetCauMuMo).ToUpper().Trim();
            ThongTinChungHoGa_KetCauTuong = GetTenDanhMucById(ThongTinChungHoGa_KetCauTuong).ToUpper().Trim();
            ThongTinChungHoGa_ChatMatNgoai = GetTenDanhMucById(ThongTinChungHoGa_ChatMatNgoai).ToUpper().Trim();

            double result = 0;
            if (ThongTinChungHoGa_ChatMatNgoai == "Có".ToUpper() && ThongTinChungHoGa_KetCauTuong == "Tường xây gạch".ToUpper())
            {
                if (ThongTinChungHoGa_KetCauMuMo == "Mũ mố xây gạch".ToUpper())
                {
                    result = TuongHoGa_C + DamGiuaHoGa_CdDam + MuMoThotDuoi_C + MuMoThotTren_C + MuMoThotTren_CdTuong;
                }
                else
                {
                    result = TuongHoGa_C + DamGiuaHoGa_CdDam;
                }
            }
            else if (ThongTinChungHoGa_ChatMatNgoai == "Có".ToUpper() && ThongTinChungHoGa_KetCauTuong == "Tường bê tông".ToUpper())
            {
                if (ThongTinChungHoGa_KetCauMuMo == "Mũ mố xây gạch".ToUpper())
                {
                    result = MuMoThotTren_C + MuMoThotTren_CdTuong;
                }
                else
                {
                    result = 0;
                }
            }
            else if (ThongTinChungHoGa_ChatMatNgoai == "Không".ToUpper() && ThongTinChungHoGa_KetCauMuMo == "Mũ mố xây gạch".ToUpper())
            {
                result = MuMoThotTren_C + MuMoThotTren_CdTuong;
            }
            else
            {
                result = 0;
            }

            result = Math.Round(result, 3);
            return Math.Round(result, 2, MidpointRounding.AwayFromZero);
        }
        public double ChatMatTrong_C(string ThongTinChungHoGa_ChatMatTrong, string ThongTinChungHoGa_KetCauTuong, string ThongTinChungHoGa_KetCauMuMo, double TuongHoGa_C, double DamGiuaHoGa_C, double MuMoThotDuoi_C, double MuMoThotTren_C)
        {
            double result = 0;
            ThongTinChungHoGa_ChatMatTrong = GetTenDanhMucById(ThongTinChungHoGa_ChatMatTrong).ToUpper().Trim();
            ThongTinChungHoGa_KetCauTuong = GetTenDanhMucById(ThongTinChungHoGa_KetCauTuong).ToUpper().Trim();
            ThongTinChungHoGa_KetCauMuMo = GetTenDanhMucById(ThongTinChungHoGa_KetCauMuMo).ToUpper().Trim();
            if (ThongTinChungHoGa_ChatMatTrong == "CÓ" && ThongTinChungHoGa_KetCauTuong == "TƯỜNG XÂY GẠCH")
            {
                if (ThongTinChungHoGa_KetCauMuMo == "MŨ MỐ XÂY GẠCH")
                {
                    result = TuongHoGa_C + DamGiuaHoGa_C + MuMoThotDuoi_C + MuMoThotTren_C;
                }
                else
                {
                    result = TuongHoGa_C + DamGiuaHoGa_C + MuMoThotDuoi_C;
                }
            }
            else if (ThongTinChungHoGa_ChatMatTrong == "CÓ" && ThongTinChungHoGa_KetCauTuong == "TƯỜNG BÊ TÔNG")
            {
                if (ThongTinChungHoGa_KetCauMuMo == "MŨ MỐ XÂY GẠCH")
                {
                    result = MuMoThotTren_C;
                }
                else
                {
                    result = 0;
                }
            }
            else if (ThongTinChungHoGa_ChatMatTrong == "KHÔNG" && ThongTinChungHoGa_KetCauMuMo == "MŨ MỐ XÂY GẠCH")
            {
                result = MuMoThotTren_C;
            }
            else
            {
                result = 0;
            }
            result = Math.Round(result, 3);
            return Math.Round(result, 2, MidpointRounding.AwayFromZero);
        }

        public double ThongTinCaoDoHoGa_TongChieuCaoHoGa(double ThongTinCaoDoHoGa_CdDinhHoGa, double ThongTinCaoDoHoGa_DayDao)
        {
            double result = 0;
            result = ThongTinCaoDoHoGa_CdDinhHoGa - ThongTinCaoDoHoGa_DayDao;
            result = Math.Round(result, 3);
            return Math.Round(result, 2, MidpointRounding.AwayFromZero);
        }
        public double ThongTinCaoDoHoGa_ChenhCaoDinhHoGaVaHienTrangDao(double ThongTinCaoDoHoGa_CdDinhHoGa, double ThongTinCaoDoHoGa_CaoDoHienTrangTruocKhiDao)
        {
            double result = 0;
            result = ThongTinCaoDoHoGa_CdDinhHoGa - ThongTinCaoDoHoGa_CaoDoHienTrangTruocKhiDao;
            result = Math.Round(result, 3);
            return Math.Round(result, 2, MidpointRounding.AwayFromZero);
        }
        //xxxx
        public double ThongTinCaoDoHoGa_DinhMuMoThotDuoi(double ThongTinCaoDoHoGa_CdDinhHoGa, double MuMoThotTren_C , double ThongTinTamDanHoGa2_C)
        {
            double result = 0;

            if (MuMoThotTren_C > 0)
            {
                result = ThongTinCaoDoHoGa_CdDinhHoGa - MuMoThotTren_C;
            }
            else
            {
                result = ThongTinCaoDoHoGa_CdDinhHoGa - ThongTinTamDanHoGa2_C;
;
            }

            result = Math.Round(result, 3);
            return Math.Round(result, 2, MidpointRounding.AwayFromZero);
        }

        public double ThongTinCaoDoHoGa_DinhTuong(double ThongTinCaoDoHoGa_DinhMuMoThotDuoi, double MuMoThotDuoi_C)
        {
            double result = 0;
            result = ThongTinCaoDoHoGa_DinhMuMoThotDuoi - MuMoThotDuoi_C;
            result = Math.Round(result, 3);
            return Math.Round(result, 2, MidpointRounding.AwayFromZero);
        }

        public double ThongTinCaoDoHoGa_DinhTuongDuoiDamGiuaTuong(double DamGiuaHoGa_CCaoDamGiuaTuongSoVoiDayHoGa, double ThongTinCaoDoHoGa_CdDayHoGa)
        {
            double result = 0;
            result =  DamGiuaHoGa_CCaoDamGiuaTuongSoVoiDayHoGa > 0 ? ThongTinCaoDoHoGa_CdDayHoGa + DamGiuaHoGa_CCaoDamGiuaTuongSoVoiDayHoGa : 0;
            result = Math.Round(result, 3);
            return Math.Round(result, 2, MidpointRounding.AwayFromZero);
        }


        public double ThongTinCaoDoHoGa_DinhDamGiuaTuong(double DamGiuaHoGa_CCaoDamGiuaTuongSoVoiDayHoGa, double ThongTinCaoDoHoGa_DinhTuongDuoiDamGiuaTuong, double DamGiuaHoGa_C)
        {
            double result = 0;
            result =  DamGiuaHoGa_CCaoDamGiuaTuongSoVoiDayHoGa > 0 ? ThongTinCaoDoHoGa_DinhTuongDuoiDamGiuaTuong + DamGiuaHoGa_C : 0;
            result = Math.Round(result, 3);
            return Math.Round(result, 2, MidpointRounding.AwayFromZero);
        }



        public double ThongTinCaoDoHoGa_CCaoTuong(double DamGiuaHoGa_CCaoDamGiuaTuongSoVoiDayHoGa, double ThongTinCaoDoHoGa_DinhTuong, double ThongTinCaoDoHoGa_CdDayHoGa, double DamGiuaHoGa_C)
        {
            double result = 0;
            result = DamGiuaHoGa_CCaoDamGiuaTuongSoVoiDayHoGa > 0 ? ThongTinCaoDoHoGa_DinhTuong - ThongTinCaoDoHoGa_CdDayHoGa - DamGiuaHoGa_C : ThongTinCaoDoHoGa_DinhTuong - ThongTinCaoDoHoGa_CdDayHoGa;
            result = Math.Round(result, 3);
            return Math.Round(result, 1, MidpointRounding.AwayFromZero);
        }

        public double TTCCCCDTHT_ChieuCaoLotDat(string ThongTinVatLieuDaoHoGa_LoaiVatLieuDao, double ThongTinVatLieuDaoHoGa_ChieuCaoDaoDat, double BeTongLotMong_C)
        {
            ThongTinVatLieuDaoHoGa_LoaiVatLieuDao = GetTenDanhMucById(ThongTinVatLieuDaoHoGa_LoaiVatLieuDao).ToUpper().Trim();
            double result = 0;

            if (ThongTinVatLieuDaoHoGa_LoaiVatLieuDao == "Đào đất".ToUpper() || ThongTinVatLieuDaoHoGa_LoaiVatLieuDao == "Đào đất + đào đá".ToUpper())
            {
                result = ThongTinVatLieuDaoHoGa_ChieuCaoDaoDat >= BeTongLotMong_C ? BeTongLotMong_C : ThongTinVatLieuDaoHoGa_ChieuCaoDaoDat;
            }
            result = Math.Round(result, 3);
            return Math.Round(result, 2, MidpointRounding.AwayFromZero);
        }

        public double TTCCCCDTHT_ChieuCaoMongDat(string ThongTinVatLieuDaoHoGa_LoaiVatLieuDao, double ThongTinVatLieuDaoHoGa_ChieuCaoDaoDat, double BeTongLotMong_C, double BeTongMongHoGa_C)
        {
            double result = 0;
            ThongTinVatLieuDaoHoGa_LoaiVatLieuDao = GetTenDanhMucById(ThongTinVatLieuDaoHoGa_LoaiVatLieuDao).ToUpper().Trim();

            if (ThongTinVatLieuDaoHoGa_LoaiVatLieuDao == "Đào đất".ToUpper() || ThongTinVatLieuDaoHoGa_LoaiVatLieuDao == "Đào đất + đào đá".ToUpper())
            {
                if (ThongTinVatLieuDaoHoGa_ChieuCaoDaoDat <= BeTongLotMong_C)
                {
                    result = 0;
                }
                else if (ThongTinVatLieuDaoHoGa_ChieuCaoDaoDat >= BeTongLotMong_C + BeTongMongHoGa_C)
                {
                    result = BeTongMongHoGa_C;
                }
                else
                {
                    result = ThongTinVatLieuDaoHoGa_ChieuCaoDaoDat - BeTongLotMong_C;
                }
            }

            result = Math.Round(result, 3);
            return Math.Round(result, 2, MidpointRounding.AwayFromZero);
        }

        public double TTCCCCDTHT_ChieuCaoTuongDat(string ThongTinVatLieuDaoHoGa_LoaiVatLieuDao, double ThongTinVatLieuDaoHoGa_ChieuCaoDaoDat, double BeTongLotMong_C, double BeTongMongHoGa_C, double TuongHoGa_C, double DamGiuaHoGa_C, double MuMoThotDuoi_C, double MuMoThotTren_C)
        {
            double result = 0;
            ThongTinVatLieuDaoHoGa_LoaiVatLieuDao = GetTenDanhMucById(ThongTinVatLieuDaoHoGa_LoaiVatLieuDao).ToUpper().Trim();
            double tongThem = TuongHoGa_C + DamGiuaHoGa_C + MuMoThotDuoi_C + MuMoThotTren_C;
            double gioiHanTren = BeTongLotMong_C + BeTongMongHoGa_C + TuongHoGa_C + DamGiuaHoGa_C + MuMoThotDuoi_C + MuMoThotTren_C;

            if (ThongTinVatLieuDaoHoGa_LoaiVatLieuDao == "Đào đất".ToUpper() || ThongTinVatLieuDaoHoGa_LoaiVatLieuDao == "Đào đất + đào đá".ToUpper())
            {
                if (ThongTinVatLieuDaoHoGa_ChieuCaoDaoDat <= BeTongLotMong_C + BeTongMongHoGa_C)
                {
                    result = 0;
                }
                else if (ThongTinVatLieuDaoHoGa_ChieuCaoDaoDat >= gioiHanTren)
                {
                    result = tongThem;
                }
                else
                {
                    result = ThongTinVatLieuDaoHoGa_ChieuCaoDaoDat - (BeTongLotMong_C + BeTongMongHoGa_C);
                }
            }

            result = Math.Round(result, 3);
            return Math.Round(result, 2, MidpointRounding.AwayFromZero);
        }

        public double TTCCCCDTHT_ChieuCaoLotDa(string ThongTinVatLieuDaoHoGa_LoaiVatLieuDao, double ThongTinVatLieuDaoHoGa_ChieuCaoDaoDa, double ThongTinVatLieuDaoHoGa_TongChieuCaoDao, double TTCCCCDTHT_ChieuCaoLotDat, double BeTongLotMong_C)
        {
            double result = 0;

            ThongTinVatLieuDaoHoGa_LoaiVatLieuDao = GetTenDanhMucById(ThongTinVatLieuDaoHoGa_LoaiVatLieuDao).ToUpper().Trim();

            if (ThongTinVatLieuDaoHoGa_LoaiVatLieuDao == "Đào đá".ToUpper())
            {
                result = ThongTinVatLieuDaoHoGa_ChieuCaoDaoDa >= BeTongLotMong_C ? BeTongLotMong_C : ThongTinVatLieuDaoHoGa_ChieuCaoDaoDa;
            }
            else if (ThongTinVatLieuDaoHoGa_LoaiVatLieuDao == "Đào đất + Đào đá".ToUpper())
            {
                if (ThongTinVatLieuDaoHoGa_TongChieuCaoDao >= BeTongLotMong_C)
                {
                    result = TTCCCCDTHT_ChieuCaoLotDat < BeTongLotMong_C ? BeTongLotMong_C - TTCCCCDTHT_ChieuCaoLotDat : 0;
                }
                else
                {
                    result = ThongTinVatLieuDaoHoGa_ChieuCaoDaoDa;
                }
            }

            result = Math.Round(result, 3);
            return Math.Round(result, 2, MidpointRounding.AwayFromZero);
        }

        public double TTCCCCDTHT_ChieuCaoMongDa(string ThongTinVatLieuDaoHoGa_LoaiVatLieuDao, double ThongTinVatLieuDaoHoGa_ChieuCaoDaoDa, double ThongTinVatLieuDaoHoGa_TongChieuCaoDao, double TTCCCCDTHT_ChieuCaoMongDat, double TTCCCCDTHT_ChieuCaoLotDa, double BeTongLotMong_C, double BeTongMongHoGa_C)
        {
            double result = 0;
            ThongTinVatLieuDaoHoGa_LoaiVatLieuDao = GetTenDanhMucById(ThongTinVatLieuDaoHoGa_LoaiVatLieuDao).ToUpper().Trim();
            if (ThongTinVatLieuDaoHoGa_LoaiVatLieuDao == "Đào đá".ToUpper())
            {
                if (ThongTinVatLieuDaoHoGa_ChieuCaoDaoDa <= BeTongLotMong_C)
                {
                    result = 0;
                }
                else if (ThongTinVatLieuDaoHoGa_ChieuCaoDaoDa >= BeTongLotMong_C + BeTongMongHoGa_C)
                {
                    result = BeTongMongHoGa_C;
                }
                else
                {
                    result = ThongTinVatLieuDaoHoGa_ChieuCaoDaoDa - BeTongLotMong_C;
                }
            }
            else if (ThongTinVatLieuDaoHoGa_LoaiVatLieuDao == "Đào đất + Đào đá".ToUpper())
            {
                if (ThongTinVatLieuDaoHoGa_TongChieuCaoDao >= BeTongLotMong_C + BeTongMongHoGa_C)
                {
                    if (TTCCCCDTHT_ChieuCaoMongDat < BeTongMongHoGa_C)
                    {
                        result = BeTongMongHoGa_C - TTCCCCDTHT_ChieuCaoMongDat;
                    }
                    else
                    {
                        result = 0;
                    }
                }
                else
                {
                    result = ThongTinVatLieuDaoHoGa_ChieuCaoDaoDa - TTCCCCDTHT_ChieuCaoLotDa;
                }
            }

            result = Math.Round(result, 3);
            return Math.Round(result, 2, MidpointRounding.AwayFromZero);
        }

        public double TTCCCCDTHT_ChieuCaoTuongDa(string ThongTinVatLieuDaoHoGa_LoaiVatLieuDao, double ThongTinVatLieuDaoHoGa_ChieuCaoDaoDa, double ThongTinVatLieuDaoHoGa_TongChieuCaoDao, double TTCCCCDTHT_ChieuCaoTuongDat, double TTCCCCDTHT_ChieuCaoLotDa, double TTCCCCDTHT_ChieuCaoMongDa, double BeTongLotMong_C, double BeTongMongHoGa_C, double TuongHoGa_C, double DamGiuaHoGa_C, double MuMoThotDuoi_C, double MuMoThotTren_C)
        {
            double result = 0;
            ThongTinVatLieuDaoHoGa_LoaiVatLieuDao = GetTenDanhMucById(ThongTinVatLieuDaoHoGa_LoaiVatLieuDao).ToUpper().Trim();
            if (ThongTinVatLieuDaoHoGa_LoaiVatLieuDao == "Đào đá".ToUpper())
            {
                if (ThongTinVatLieuDaoHoGa_ChieuCaoDaoDa <= BeTongLotMong_C + BeTongMongHoGa_C)
                {
                    result = 0;
                }
                else if (ThongTinVatLieuDaoHoGa_ChieuCaoDaoDa >= BeTongLotMong_C + BeTongMongHoGa_C + TuongHoGa_C + DamGiuaHoGa_C + MuMoThotDuoi_C + MuMoThotTren_C)
                {
                    result = TuongHoGa_C + DamGiuaHoGa_C + MuMoThotDuoi_C + MuMoThotTren_C;
                }
                else
                {
                    result = ThongTinVatLieuDaoHoGa_ChieuCaoDaoDa - (BeTongLotMong_C + BeTongMongHoGa_C);
                }
            }
            else if (ThongTinVatLieuDaoHoGa_LoaiVatLieuDao == "Đào đất + Đào đá".ToUpper())
            {
                if (ThongTinVatLieuDaoHoGa_TongChieuCaoDao >= BeTongLotMong_C + BeTongMongHoGa_C + TuongHoGa_C + DamGiuaHoGa_C + MuMoThotDuoi_C + MuMoThotTren_C)
                {
                    if (TTCCCCDTHT_ChieuCaoTuongDat < TuongHoGa_C + DamGiuaHoGa_C + MuMoThotDuoi_C + MuMoThotTren_C)
                    {
                        result = TuongHoGa_C + DamGiuaHoGa_C + MuMoThotDuoi_C + MuMoThotTren_C - TTCCCCDTHT_ChieuCaoTuongDat;
                    }
                    else
                    {
                        result = 0;
                    }
                }
                else
                {
                    result = ThongTinVatLieuDaoHoGa_ChieuCaoDaoDa - (TTCCCCDTHT_ChieuCaoLotDa + TTCCCCDTHT_ChieuCaoMongDa);
                }
            }

            result = Math.Round(result, 3);
            return Math.Round(result, 2, MidpointRounding.AwayFromZero);
        }

        public double TTKLD_CRongDaoDayLonDat(string ThongTinVatLieuDaoHoGa_LoaiVatLieuDao, double ThongTinVatLieuDaoHoGa_ChieuCaoDaoDat, double ThongTinMaiDao_TyLeMoMai, double ThongTinMaiDao_SoCanhMaiTrai, double ThongTinMaiDao_SoCanhMaiPhai, double ThongTinMaiDao_ChieuRongDayDaoNho)
        {
            double result = 0;
            ThongTinVatLieuDaoHoGa_LoaiVatLieuDao = GetTenDanhMucById(ThongTinVatLieuDaoHoGa_LoaiVatLieuDao).ToUpper().Trim();

            if (ThongTinVatLieuDaoHoGa_LoaiVatLieuDao == "Đào đất".ToUpper() || ThongTinVatLieuDaoHoGa_LoaiVatLieuDao == "Đào đất + đào đá".ToUpper())
            {
                result = (ThongTinVatLieuDaoHoGa_ChieuCaoDaoDat * ThongTinMaiDao_TyLeMoMai * (ThongTinMaiDao_SoCanhMaiTrai + ThongTinMaiDao_SoCanhMaiPhai)) + ThongTinMaiDao_ChieuRongDayDaoNho;
            }

            result = Math.Round(result, 3);
            return Math.Round(result, 2, MidpointRounding.AwayFromZero);
        }
        public double TinhTTTKLD_CRongDaoDayLonDaoan(string ThongTinVatLieuDaoHoGa_LoaiVatLieuDao, double ThongTinVatLieuDaoHoGa_ChieuCaoDaoDa, double ThongTinMaiDao_TyLeMoMai, double ThongTinMaiDao_SoCanhMaiTrai, double ThongTinMaiDao_SoCanhMaiPhai, double TTKLD_CRongDaoDayLonDat, double ThongTinMaiDao_ChieuRongDayDaoNho)
        {
            double result = 0;
            ThongTinVatLieuDaoHoGa_LoaiVatLieuDao = GetTenDanhMucById(ThongTinVatLieuDaoHoGa_LoaiVatLieuDao).ToUpper().Trim();
            if (ThongTinVatLieuDaoHoGa_LoaiVatLieuDao == "Đào đá".ToUpper() || ThongTinVatLieuDaoHoGa_LoaiVatLieuDao == "Đào đất + đào đá".ToUpper())
            {
                if (TTKLD_CRongDaoDayLonDat > 0)
                {
                    result = (ThongTinVatLieuDaoHoGa_ChieuCaoDaoDa * ThongTinMaiDao_TyLeMoMai * (ThongTinMaiDao_SoCanhMaiTrai + ThongTinMaiDao_SoCanhMaiPhai)) + TTKLD_CRongDaoDayLonDat;
                }
                else
                {
                    result = (ThongTinVatLieuDaoHoGa_ChieuCaoDaoDa * ThongTinMaiDao_TyLeMoMai * (ThongTinMaiDao_SoCanhMaiTrai + ThongTinMaiDao_SoCanhMaiPhai)) + ThongTinMaiDao_ChieuRongDayDaoNho;
                }
            }

            result = Math.Round(result, 3);
            return Math.Round(result, 2, MidpointRounding.AwayFromZero);
        }
        public double TTKLD_DienTichDaoDat(double TTKLD_CRongDaoDayLonDat, double ThongTinMaiDao_ChieuRongDayDaoNho, double ThongTinVatLieuDaoHoGa_ChieuCaoDaoDat)
        {
            double result = 0;
            result = (TTKLD_CRongDaoDayLonDat + ThongTinMaiDao_ChieuRongDayDaoNho) * (ThongTinVatLieuDaoHoGa_ChieuCaoDaoDat / 2);
            result = Math.Round(result, 3);
            return Math.Round(result, 2, MidpointRounding.AwayFromZero);
        }
        public double TTKLD_DienTichDaoDa(double TTKLD_CRongDaoDayLonDa, double TTKLD_CRongDaoDayLonDat, double ThongTinMaiDao_ChieuRongDayDaoNho, double ThongTinVatLieuDaoHoGa_ChieuCaoDaoDa)
        {
            // Tính toán giá trị dựa trên điều kiện và làm tròn đến 2 chữ số thập phân
            double result = 0;
            if (TTKLD_CRongDaoDayLonDat > 0)
            {
                result = (TTKLD_CRongDaoDayLonDa + TTKLD_CRongDaoDayLonDat) * (ThongTinVatLieuDaoHoGa_ChieuCaoDaoDa / 2);
            }
            else
            {
                result = (TTKLD_CRongDaoDayLonDa + ThongTinMaiDao_ChieuRongDayDaoNho) * (ThongTinVatLieuDaoHoGa_ChieuCaoDaoDa / 2);
            }
            result = Math.Round(result, 3);
            return Math.Round(result, 2, MidpointRounding.AwayFromZero);
        }
        public double TTKLD_TongDtDao(double TTKLD_DienTichDaoDat, double TTKLD_DienTichDaoDa)
        {
            // Tính tổng và làm tròn đến 2 chữ số thập phân
            double result = 0;
            result = TTKLD_DienTichDaoDat + TTKLD_DienTichDaoDa;
            result = Math.Round(result, 3);
            return Math.Round(result, 2, MidpointRounding.AwayFromZero);
        }
        public double TTKLD_KlDaoDat(double TTKLD_DienTichDaoDat, double BeTongLotMong_D, double PhuBiHoGa_CDai, string ThongTinChungHoGa_TenHoGaTheoBanVe)
        {
            string cuoi2KyTu = ThongTinChungHoGa_TenHoGaTheoBanVe.Length >= 2 ? ThongTinChungHoGa_TenHoGaTheoBanVe.Substring(ThongTinChungHoGa_TenHoGaTheoBanVe.Length - 2) : string.Empty;
            double result = 0;
            if (cuoi2KyTu == "=G")
            {
                result = 0;
            }
            else
            {
                result = BeTongLotMong_D > 0 ? TTKLD_DienTichDaoDat * BeTongLotMong_D : TTKLD_DienTichDaoDat * PhuBiHoGa_CDai;
            }
            result = Math.Round(result, 3);
            return Math.Round(result, 2, MidpointRounding.AwayFromZero);
        }
        public double TTKLD_KlDaoDa(double TTKLD_DienTichDaoDa, double BeTongLotMong_D, double PhuBiHoGa_CDai, string ThongTinChungHoGa_TenHoGaTheoBanVe)
        {
            string cuoi2KyTu = ThongTinChungHoGa_TenHoGaTheoBanVe.Length >= 2 ? ThongTinChungHoGa_TenHoGaTheoBanVe.Substring(ThongTinChungHoGa_TenHoGaTheoBanVe.Length - 2) : string.Empty;
            double result = cuoi2KyTu == "=G" ? 0 : (BeTongLotMong_D > 0 ? TTKLD_DienTichDaoDa * BeTongLotMong_D : TTKLD_DienTichDaoDa * PhuBiHoGa_CDai);
            result = Math.Round(result, 3);
            return Math.Round(result, 2, MidpointRounding.AwayFromZero);
        }
        public double TTKLD_TongKlDao(double TTKLD_KlDaoDat, double TTKLD_KlDaoDa)
        {
            double result = 0;
            result =  TTKLD_KlDaoDat + TTKLD_KlDaoDa;
            result = Math.Round(result, 3);
            return Math.Round(result, 2, MidpointRounding.AwayFromZero);
        }

        public double TTKLD_KlChiemChoDat(string ThongTinChungHoGa_TenHoGaTheoBanVe, double BeTongLotMong_D, double DThongTinChungHoGa_TenHoGaTheoBanVe, double BeTongLotMong_R, double TBeTongMongHoGa_D, double TBeTongMongHoGa_R, double TTCCCCDTHT_ChieuCaoMongDat, double TTCCCCDTHT_ChieuCaoTuongDat, double PhuBiHoGa_CDai, double PhuBiHoGa_CRong)
        {
            double result = 0;

            if (ThongTinChungHoGa_TenHoGaTheoBanVe.ToUpper().EndsWith("=G"))
            {
                return 0;
            }
            else if (BeTongLotMong_D > 0)
            {
                result = (DThongTinChungHoGa_TenHoGaTheoBanVe * BeTongLotMong_D * BeTongLotMong_R) +
                         (TBeTongMongHoGa_D * TBeTongMongHoGa_R * TTCCCCDTHT_ChieuCaoMongDat) +
                         (TTCCCCDTHT_ChieuCaoTuongDat * PhuBiHoGa_CDai * PhuBiHoGa_CRong);
            }
            else
            {
                result = (DThongTinChungHoGa_TenHoGaTheoBanVe * PhuBiHoGa_CDai * PhuBiHoGa_CRong) +
                         (PhuBiHoGa_CDai * PhuBiHoGa_CRong * TTCCCCDTHT_ChieuCaoMongDat) +
                         (TTCCCCDTHT_ChieuCaoTuongDat * PhuBiHoGa_CDai * PhuBiHoGa_CRong);
            }

             Math.Round(result, 3);
            return Math.Round(result, 2, MidpointRounding.AwayFromZero);
        }

        public double TTKLD_KlChiemChoDa(string ThongTinChungHoGa_TenHoGaTheoBanVe, double BeTongLotMong_D, double TTCCCCDTHT_ChieuCaoLotDa, double BeTongLotMong_R, double TBeTongMongHoGa_D, double TBeTongMongHoGa_R, double TTCCCCDTHT_ChieuCaoMongDa, double TTCCCCDTHT_ChieuCaoTuongDa, double PhuBiHoGa_CDai, double PhuBiHoGa_CRong)
        {
            double result = 0;

            if (ThongTinChungHoGa_TenHoGaTheoBanVe.EndsWith("=G"))
            {
                result = 0;
            }
            else if (BeTongLotMong_D > 0)
            {
                result = (TTCCCCDTHT_ChieuCaoLotDa * BeTongLotMong_D * BeTongLotMong_R) +
                         (TBeTongMongHoGa_D * TBeTongMongHoGa_R * TTCCCCDTHT_ChieuCaoMongDa) +
                         (TTCCCCDTHT_ChieuCaoTuongDa * PhuBiHoGa_CDai * PhuBiHoGa_CRong);
            }
            else
            {
                result = (TTCCCCDTHT_ChieuCaoLotDa * PhuBiHoGa_CDai * PhuBiHoGa_CRong) +
                         (PhuBiHoGa_CDai * PhuBiHoGa_CRong * TTCCCCDTHT_ChieuCaoMongDa) +
                         (TTCCCCDTHT_ChieuCaoTuongDa * PhuBiHoGa_CDai * PhuBiHoGa_CRong);
            }

            result = Math.Round(result, 3);
            return Math.Round(result, 2, MidpointRounding.AwayFromZero);
        }

        public double TTKLD_TongChiemCho(double TTKLD_KlChiemChoDat, double TTKLD_KlChiemChoDa)
        {
            double result = TTKLD_KlChiemChoDat + TTKLD_KlChiemChoDa;
            result = Math.Round(result, 3);
            return Math.Round(result, 2, MidpointRounding.AwayFromZero);
        }

        public double TTKLD_KlDapTraDat(double TTKLD_KlDaoDat, double TTKLD_KlChiemChoDat)
        {
            double result = TTKLD_KlDaoDat - TTKLD_KlChiemChoDat;
            result = Math.Round(result, 3);
            return Math.Round(result, 2, MidpointRounding.AwayFromZero);
        }

        public double TTKLD_KlDapTraDa(double TTKLD_KlDaoDa, double TTKLD_KlChiemChoDa)
        {
            double result = TTKLD_KlDaoDa - TTKLD_KlChiemChoDa;
            result = Math.Round(result, 3);
            return Math.Round(result, 2, MidpointRounding.AwayFromZero);
        }

        public double TTKLD_TongDapTra(double TTKLD_KlDapTraDat, double TTKLD_KlDapTraDa)
        {
            double result = TTKLD_KlDapTraDat + TTKLD_KlDapTraDa;
            result = Math.Round(result, 3);
            return Math.Round(result, 2, MidpointRounding.AwayFromZero);
        }


        public string TTCDSLCauKienDuongTruyenDan_XacDinhOngCongCanThem(double TTCDSLCauKienDuongTruyenDan_CDaiThucTeConThuaThieuSoVoiCRongLongMuMoHoGa)
        {
            return TTCDSLCauKienDuongTruyenDan_CDaiThucTeConThuaThieuSoVoiCRongLongMuMoHoGa < -0.1 ? "Thêm 01" : "Đủ";
        }

        public int TTCDSLCauKienDuongTruyenDan_SlCauKienNguyen(string ThongTinDuongTruyenDan_HinhThucTruyenDan, double TTCDSLCauKienDuongTruyenDan_TongChieuDai, double TTCDSLCauKienDuongTruyenDan_ChieuDai01CauKien, double TTCDSLCauKienDuongTruyenDan_ChieuDaiMoiNoiCKien)
        {
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).Trim().ToUpper();
            if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "CỐNG TRÒN" || ThongTinDuongTruyenDan_HinhThucTruyenDan == "CỐNG HỘP")
            {
                // Tránh chia cho 0 bằng cách kiểm tra ES16 + ET16
                if (TTCDSLCauKienDuongTruyenDan_ChieuDai01CauKien + TTCDSLCauKienDuongTruyenDan_ChieuDaiMoiNoiCKien != 0)
                {
                    return (int)(TTCDSLCauKienDuongTruyenDan_TongChieuDai / (TTCDSLCauKienDuongTruyenDan_ChieuDai01CauKien + TTCDSLCauKienDuongTruyenDan_ChieuDaiMoiNoiCKien));
                }
                else
                {
                    return 0; // Hoặc có thể xử lý lỗi chia cho 0 ở đây nếu cần
                }
            }
            else
            {
                return 0;
            }

        }
        public double TTCDSLCauKienDuongTruyenDan_SlCauKienTinhKl(string ThongTinDuongTruyenDan_HinhThucTruyenDan, string TTTKLCKCTCH_XDOngCongCanThem, double TTTKLCKCTCH_SLCKNguyen, double TTTKLCKCTCH_SLCKDungDeTinhCD)
        {
            double result = 0;
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).Trim().ToUpper();
            if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "Cống tròn".ToUpper() || ThongTinDuongTruyenDan_HinhThucTruyenDan == "Cống hộp".ToUpper())
            {
                if (TTTKLCKCTCH_XDOngCongCanThem.Trim().ToUpper() == "Thêm 01".Trim().ToUpper())
                {
                    result = TTTKLCKCTCH_SLCKNguyen + TTTKLCKCTCH_SLCKDungDeTinhCD;
                }
                else
                {
                    result = TTTKLCKCTCH_SLCKNguyen;
                }
            }
            else
            {
                result = 0;
            }

            result = Math.Round(result, 3);
            return Math.Round(result, 2, MidpointRounding.AwayFromZero);
        }
       
        public double TTCDSLCauKienDuongTruyenDan_CDaiCanDeLapDatDuocTheoSoCkNguyen(string ThongTinDuongTruyenDan_HinhThucTruyenDan, double TTCDSLCauKienDuongTruyenDan_SlCauKienNguyen, double TTCDSLCauKienDuongTruyenDan_SoLuongCKienDungDeTinhChieuDaiBoSung, double TTCDSLCauKienDuongTruyenDan_ChieuDaiMoiNoiCKien)
        {
            double result = 0;
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();

            if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "Cống tròn".ToUpper() || ThongTinDuongTruyenDan_HinhThucTruyenDan == "Cống hộp".ToUpper())
            {
                result = (TTCDSLCauKienDuongTruyenDan_SlCauKienNguyen - TTCDSLCauKienDuongTruyenDan_SoLuongCKienDungDeTinhChieuDaiBoSung) * TTCDSLCauKienDuongTruyenDan_ChieuDaiMoiNoiCKien;
            }
            else
            {
                result = 0;
            }

            result = Math.Round(result, 3);
            return Math.Round(result, 2, MidpointRounding.AwayFromZero);
        }

        public double TTCDSLCauKienDuongTruyenDan_TongCDaiLapDatTheoSoCkNguyen(string ThongTinDuongTruyenDan_HinhThucTruyenDan, double TTCDSLCauKienDuongTruyenDan_SlCauKienNguyen, double TTCDSLCauKienDuongTruyenDan_ChieuDai01CauKien, double TTCDSLCauKienDuongTruyenDan_CDaiCanDeLapDatDuocTheoSoCkNguyen)
        {
            double result = 0;
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();

            if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "Cống tròn".ToUpper() || ThongTinDuongTruyenDan_HinhThucTruyenDan == "Cống hộp".ToUpper())
            {
                result = (TTCDSLCauKienDuongTruyenDan_SlCauKienNguyen * TTCDSLCauKienDuongTruyenDan_ChieuDai01CauKien) + TTCDSLCauKienDuongTruyenDan_CDaiCanDeLapDatDuocTheoSoCkNguyen;
            }
            else
            {
                result = 0;
            }

            result = Math.Round(result, 3);
            return Math.Round(result, 2, MidpointRounding.AwayFromZero);
        }


        public double TTCDSLCauKienDuongTruyenDan_CDaiThucTeConThuaThieuSoVoiCRongLongMuMoHoGa(string ThongTinDuongTruyenDan_HinhThucTruyenDan, double TTCDSLCauKienDuongTruyenDan_TongCDaiLapDatTheoSoCkNguyen, double TTCDSLCauKienDuongTruyenDan_TongChieuDai)
        {
            double result = 0;
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();

            if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "Cống tròn".ToUpper() || ThongTinDuongTruyenDan_HinhThucTruyenDan == "Cống hộp".ToUpper())
            {
                result = TTCDSLCauKienDuongTruyenDan_TongCDaiLapDatTheoSoCkNguyen - TTCDSLCauKienDuongTruyenDan_TongChieuDai;
            }
            else
            {
                result = 0;
            }

            result = Math.Round(result, 3);
            return Math.Round(result, 2, MidpointRounding.AwayFromZero);
        }

       
        public double TTCDSLCauKienDuongTruyenDan_CDaiConThuaThieuSauTinhTheoCkTinhKl(string ThongTinDuongTruyenDan_HinhThucTruyenDan, double TTCDSLCauKienDuongTruyenDan_SlCauKienTinhKl, double TTCDSLCauKienDuongTruyenDan_SoLuongCKienDungDeTinhChieuDaiBoSung, double TTCDSLCauKienDuongTruyenDan_ChieuDaiMoiNoiCKien, double TTCDSLCauKienDuongTruyenDan_ChieuDai01CauKien, double TTCDSLCauKienDuongTruyenDan_TongChieuDai)
        {
            double result = 0;
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();

            if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "Cống tròn".ToUpper() || ThongTinDuongTruyenDan_HinhThucTruyenDan == "Cống hộp".ToUpper())
            {
                result = (((TTCDSLCauKienDuongTruyenDan_SlCauKienTinhKl - TTCDSLCauKienDuongTruyenDan_SoLuongCKienDungDeTinhChieuDaiBoSung) * TTCDSLCauKienDuongTruyenDan_ChieuDaiMoiNoiCKien) + (TTCDSLCauKienDuongTruyenDan_SlCauKienTinhKl * TTCDSLCauKienDuongTruyenDan_ChieuDai01CauKien)) - TTCDSLCauKienDuongTruyenDan_TongChieuDai;
            }
            else
            {
                result = 0;
            }

            result = Math.Round(result, 3);
            return Math.Round(result, 2, MidpointRounding.AwayFromZero);
        }


        public double ThongTinCauTaoCongTron_CCaoCauKien(double ThongTinCauTaoCongTron_CDayPhuBi, double ThongTinCauTaoCongTron_SoCanh, double ThongTinCauTaoCongTron_LongSuDung)
        {
            double result = 0;
            result = (ThongTinCauTaoCongTron_CDayPhuBi * ThongTinCauTaoCongTron_SoCanh) + ThongTinCauTaoCongTron_LongSuDung;
            result = Math.Round(result, 3);
            return Math.Round(result, 2, MidpointRounding.AwayFromZero);
        }

     

        public double ThongTinCauTaoCongTron_TongCCaoCong(double ThongTinCauTaoCongTron_CCaoCauKien, double ThongTinCauTaoCongTron_CCaoLotMong, double ThongTinCauTaoCongTron_CCaoMong, double ThongTinCauTaoCongTron_CCaoDe)
        {
            double result = 0;
            result = ThongTinCauTaoCongTron_CCaoCauKien + ThongTinCauTaoCongTron_CCaoLotMong + ThongTinCauTaoCongTron_CCaoMong + ThongTinCauTaoCongTron_CCaoDe;
            result = Math.Round(result, 3);
            return Math.Round(result, 2, MidpointRounding.AwayFromZero);
        }



        //xxx
        public double TTTKLCKCTCH_CDThuaThieuSauTinhKL(string ThongTinDuongTruyenDan_HinhThucTruyenDan, double TTCDSLCauKienDuongTruyenDan_SlCauKienTinhKl, double TTTKLCKCTCH_SLCKDungDeTinhCD, double TTTKLCKCTCH_CDMoiNoiCKien, double TTCDSLCauKienDuongTruyenDan_ChieuDai01CauKien, double TTCDSLCauKienDuongTruyenDan_TongChieuDai)
        {
            double result =0;
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "Cống tròn".ToUpper() || ThongTinDuongTruyenDan_HinhThucTruyenDan == "Cống hộp".ToUpper())
            {
                result = (((TTCDSLCauKienDuongTruyenDan_SlCauKienTinhKl - TTTKLCKCTCH_SLCKDungDeTinhCD) * TTTKLCKCTCH_CDMoiNoiCKien) + (TTCDSLCauKienDuongTruyenDan_SlCauKienTinhKl * TTCDSLCauKienDuongTruyenDan_ChieuDai01CauKien)) - TTCDSLCauKienDuongTruyenDan_TongChieuDai;
            }
            else
            {
                result = 0;
            }
            result = Math.Round(result ,3);
            return Math.Round(result, 2 ,MidpointRounding.AwayFromZero);
        }


        public string TTTKLCKCTCH_XDOngCongCanThem(double TTTKLCKCTCH_CDThucTeThuaThieu)
        {
            if (TTTKLCKCTCH_CDThucTeThuaThieu < -0.1)
            {
                return "Thêm 01";
            }
            else
            {
                return "Đủ";
            }
        }


        public double TTTKLCKCTCH_CDThucTeThuaThieu(string ThongTinDuongTruyenDan_HinhThucTruyenDan, double TTTKLCKCTCH_TongCD, double TTCDSLCauKienDuongTruyenDan_TongChieuDai)
        {
            double result =0;
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "Cống tròn".ToUpper() || ThongTinDuongTruyenDan_HinhThucTruyenDan == "Cống hộp".ToUpper())
            {
                result = TTTKLCKCTCH_TongCD - TTCDSLCauKienDuongTruyenDan_TongChieuDai;
            }
            else
            {
                result = 0;
            }

            result = Math.Round(result, 3);
            return Math.Round(result, 2, MidpointRounding.AwayFromZero);
        }


        public double TTTKLCKCTCH_TongCD(string ThongTinDuongTruyenDan_HinhThucTruyenDan, double TTTKLCKCTCH_SLCKNguyen, double TTCDSLCauKienDuongTruyenDan_ChieuDai01CauKien, double TTTKLCKCTCH_CDCanLapDat)
        {
            double result = 0;
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "Cống tròn".ToUpper() || ThongTinDuongTruyenDan_HinhThucTruyenDan == "Cống hộp".ToUpper())
            {
                result = (TTTKLCKCTCH_SLCKNguyen * TTCDSLCauKienDuongTruyenDan_ChieuDai01CauKien) + TTTKLCKCTCH_CDCanLapDat;
            }
            else
            {
                result = 0;
            }

            result = Math.Round(result, 3);
            return Math.Round(result, 2, MidpointRounding.AwayFromZero);
        }


        public double TTTKLCKCTCH_CDCanLapDat(string ThongTinDuongTruyenDan_HinhThucTruyenDan, double TTTKLCKCTCH_SLCKNguyen, double TTTKLCKCTCH_SLCKDungDeTinhCD, double TTTKLCKCTCH_CDMoiNoiCKien)
        {
            double result =0 ;
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "Cống tròn".ToUpper() || ThongTinDuongTruyenDan_HinhThucTruyenDan == "Cống hộp".ToUpper())
            {
                result = (TTTKLCKCTCH_SLCKNguyen - TTTKLCKCTCH_SLCKDungDeTinhCD) * TTTKLCKCTCH_CDMoiNoiCKien;
            }
            else
            {
                result = 0;
            }

            result = Math.Round(result, 3);
            return Math.Round(result, 2, MidpointRounding.AwayFromZero);
        }

        public double TTTKLCKCTCH_SLCKNguyen(string ThongTinDuongTruyenDan_HinhThucTruyenDan, double TTCDSLCauKienDuongTruyenDan_TongChieuDai, double TTCDSLCauKienDuongTruyenDan_ChieuDai01CauKien, double TTTKLCKCTCH_CDMoiNoiCKien)
        {
            double result = 0;
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "Cống tròn".ToUpper() || ThongTinDuongTruyenDan_HinhThucTruyenDan == "Cống hộp".ToUpper())
            {
                if (TTCDSLCauKienDuongTruyenDan_ChieuDai01CauKien + TTTKLCKCTCH_CDMoiNoiCKien != 0){
                    result = Math.Floor(TTCDSLCauKienDuongTruyenDan_TongChieuDai / (TTCDSLCauKienDuongTruyenDan_ChieuDai01CauKien + TTTKLCKCTCH_CDMoiNoiCKien));
                }
                    
            }
            else
            {
                result = 0;
            }

            result = Math.Round(result, 3);
            return Math.Round(result, 2, MidpointRounding.AwayFromZero);
        }





        public double TTKTHHCongHopRanh_CCaoTuongRanh(string ThongTinDuongTruyenDan_HinhThucTruyenDan, double CDThuongLuu_CCaoTuongCongRanh, double CDHaLu_CCaoTuongCongRanh)
        {
            double result = 0;
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "RÃNH XÂY".ToUpper() || ThongTinDuongTruyenDan_HinhThucTruyenDan == "Rãnh bê tông".ToUpper())
            {
                result = (CDThuongLuu_CCaoTuongCongRanh + CDHaLu_CCaoTuongCongRanh) / 2;
            }
           
            result = Math.Round(result, 3);
            return Math.Round(result, 2, MidpointRounding.AwayFromZero);
        }
        public double TTKTHHCongHopRanh_CCaoTuongGop(double TTKTHHCongHopRanh_CCaoTuongCongHop, double TTKTHHCongHopRanh_CCaoTuongRanh)
        {
            double result = 0;
            result =  TTKTHHCongHopRanh_CCaoTuongCongHop + TTKTHHCongHopRanh_CCaoTuongRanh;
            result = Math.Round(result, 3);
            return Math.Round(result, 2, MidpointRounding.AwayFromZero);
        }


        public double TTKTHHCongHopRanh_CCaoChatMatTrong(string TTKTHHCongHopRanh_ChatMatTrong, string TTKTHHCongHopRanh_CauTaoTuong, string TTKTHHCongHopRanh_CauTaoMuMo, double TTKTHHCongHopRanh_CCaoTuongGop, double TTKTHHCongHopRanh_CCaoMuMoThotDuoi, double TTKTHHCongHopRanh_CCaoMuMoThotTren)
        {
            double result = 0;
            TTKTHHCongHopRanh_ChatMatTrong = GetTenDanhMucById(TTKTHHCongHopRanh_ChatMatTrong).ToUpper().Trim();
            TTKTHHCongHopRanh_CauTaoTuong = GetTenDanhMucById(TTKTHHCongHopRanh_CauTaoTuong).ToUpper().Trim();

            if (TTKTHHCongHopRanh_ChatMatTrong == "Có".ToUpper() && TTKTHHCongHopRanh_CauTaoTuong == "Tường xây gạch".ToUpper())
            {
                result = TTKTHHCongHopRanh_CauTaoMuMo == "Không mũ mố".ToUpper() ? TTKTHHCongHopRanh_CCaoTuongGop : TTKTHHCongHopRanh_CCaoTuongGop + TTKTHHCongHopRanh_CCaoMuMoThotDuoi + TTKTHHCongHopRanh_CCaoMuMoThotTren;
            }
            else if (TTKTHHCongHopRanh_ChatMatTrong == "Không".ToUpper() && TTKTHHCongHopRanh_CauTaoMuMo == "Mũ mố xây gạch".ToUpper())
            {
                result = TTKTHHCongHopRanh_CCaoMuMoThotTren;
            }
           
            result = Math.Round(result, 3);
            return Math.Round(result, 2, MidpointRounding.AwayFromZero);
        }
        public double TTKTHHCongHopRanh_CCaoChatmatNgoai(string TTKTHHCongHopRanh_ChatMatNgoai, string TTKTHHCongHopRanh_CauTaoTuong, string TTKTHHCongHopRanh_CauTaoMuMo, double TTKTHHCongHopRanh_CCaoTuongGop, double TTKTHHCongHopRanh_CCaoMuMoThotDuoi, double TTKTHHCongHopRanh_CCaoMuMoThotTren, double TTKTHHCongHopRanh_CRongMuMoTren)
        {
            double result = 0;
            if (TTKTHHCongHopRanh_ChatMatNgoai == "Có" && TTKTHHCongHopRanh_CauTaoTuong == "Tường xây gạch")
            {
                result = TTKTHHCongHopRanh_CauTaoMuMo == "Không mũ mố" ? TTKTHHCongHopRanh_CCaoTuongGop : TTKTHHCongHopRanh_CCaoTuongGop + TTKTHHCongHopRanh_CCaoMuMoThotDuoi + TTKTHHCongHopRanh_CCaoMuMoThotTren;
            }
            else if (TTKTHHCongHopRanh_ChatMatNgoai == "Không" && TTKTHHCongHopRanh_CauTaoMuMo == "Mũ mố xây gạch")
            {
                result = TTKTHHCongHopRanh_CCaoMuMoThotTren + TTKTHHCongHopRanh_CRongMuMoTren;
            }

            result = Math.Round(result, 3);
            return Math.Round(result, 2, MidpointRounding.AwayFromZero);
        }
        
        public double TTKTHHCongHopRanh_TongChieuCao(double TTKTHHCongHopRanh_CCaoLotMong,double TTKTHHCongHopRanh_CCaoMong,double TTKTHHCongHopRanh_CCaoDe,double TTKTHHCongHopRanh_CCaoTuongGop,double TTKTHHCongHopRanh_CCaoMuMoThotDuoi,double TTKTHHCongHopRanh_CCaoMuMoThotTren)
        {
            double result = TTKTHHCongHopRanh_CCaoLotMong
                            + TTKTHHCongHopRanh_CCaoMong
                            + TTKTHHCongHopRanh_CCaoDe
                            + TTKTHHCongHopRanh_CCaoTuongGop
                            + TTKTHHCongHopRanh_CCaoMuMoThotDuoi
                            + TTKTHHCongHopRanh_CCaoMuMoThotTren;

            result = Math.Round(result, 3); 
            return Math.Round(result, 2, MidpointRounding.AwayFromZero); 
        }

        public double ThongTinKichThuocHinhHocOngNhua_TongCCaoOng(double ThongTinKichThuocHinhHocOngNhua_CDayPhuBi,double ThongTinKichThuocHinhHocOngNhua_SoCanh,double ThongTinKichThuocHinhHocOngNhua_LongSuDung)
        {
            double result = (ThongTinKichThuocHinhHocOngNhua_CDayPhuBi * ThongTinKichThuocHinhHocOngNhua_SoCanh)
                            + ThongTinKichThuocHinhHocOngNhua_LongSuDung;

            result = Math.Round(result, 3); 
            return Math.Round(result, 2, MidpointRounding.AwayFromZero); 
        }
        public double TTTDCongHoRanh_SoLuong(string ThongTinDuongTruyenDan_HinhThucTruyenDan, double TTTDCongHoRanh_SLCauKienNguyen)
        {
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).Trim().ToUpper();

            double result = 0;

            if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "CỐNG HỘP" ||
                ThongTinDuongTruyenDan_HinhThucTruyenDan == "RÃNH XÂY" ||
                ThongTinDuongTruyenDan_HinhThucTruyenDan == "RÃNH BÊ TÔNG")
            {
                result = TTTDCongHoRanh_SLCauKienNguyen;
            }

            result = Math.Round(result, 3);
            return Math.Round(result, 2, MidpointRounding.AwayFromZero);
        }



        public int TTTDCongHoRanh_SLCauKienNguyen(string ThongTinDuongTruyenDan_HinhThucTruyenDan, double TTCDSLCauKienDuongTruyenDan_TongChieuDai, double TTTDCongHoRanh_Cdai, double TTTDCongHoRanh_ChieuDaiMoiNoi)
        {
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "RÃNH XÂY".ToUpper()
                || ThongTinDuongTruyenDan_HinhThucTruyenDan == "Rãnh bê tông".ToUpper()
                || ThongTinDuongTruyenDan_HinhThucTruyenDan == "Cống hộp".ToUpper())
            {
                double denominator = TTTDCongHoRanh_Cdai + TTTDCongHoRanh_ChieuDaiMoiNoi;
                if (denominator != 0)
                {
                    return (int)(TTCDSLCauKienDuongTruyenDan_TongChieuDai / denominator);
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }

        }
        public double TTTDCongHoRanh_ChieuDaiTheoSoCKNguyen(string ThongTinDuongTruyenDan_HinhThucTruyenDan, double TTTDCongHoRanh_SLCauKienNguyen, double TTTDCongHoRanh_ChieuDaiMoiNoi)
        {
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            double result = (ThongTinDuongTruyenDan_HinhThucTruyenDan == "RÃNH XÂY".ToUpper() || ThongTinDuongTruyenDan_HinhThucTruyenDan == "RÃNH BÊ TÔNG".ToUpper() || ThongTinDuongTruyenDan_HinhThucTruyenDan == "CỐNG HỘP".ToUpper())
                ? TTTDCongHoRanh_SLCauKienNguyen * TTTDCongHoRanh_ChieuDaiMoiNoi
                : 0;
            result = Math.Round(result, 3);
            return Math.Round(result, 2, MidpointRounding.AwayFromZero);
        }

        public double TTTDCongHoRanh_TongChieuDaiTheoCKNguyen(string ThongTinDuongTruyenDan_HinhThucTruyenDan, double TTTDCongHoRanh_SLCauKienNguyen, double TTTDCongHoRanh_Cdai, double TTTDCongHoRanh_ChieuDaiTheoSoCKNguyen)
        {
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            double result = (ThongTinDuongTruyenDan_HinhThucTruyenDan == "RÃNH XÂY".ToUpper() || ThongTinDuongTruyenDan_HinhThucTruyenDan == "RÃNH BÊ TÔNG".ToUpper() || ThongTinDuongTruyenDan_HinhThucTruyenDan == "CỐNG HỘP".ToUpper())
                ? (TTTDCongHoRanh_SLCauKienNguyen * TTTDCongHoRanh_Cdai) + TTTDCongHoRanh_ChieuDaiTheoSoCKNguyen
                : 0;
            result = Math.Round(result, 3);
            return Math.Round(result, 2, MidpointRounding.AwayFromZero);
        }

        public double TTTDCongHoRanh_ChieuDaiThucTe(string ThongTinDuongTruyenDan_HinhThucTruyenDan, double TTTDCongHoRanh_TongChieuDaiTheoCKNguyen, double TTCDSLCauKienDuongTruyenDan_TongChieuDai)
        {
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            double result = (ThongTinDuongTruyenDan_HinhThucTruyenDan == "RÃNH XÂY".ToUpper() || ThongTinDuongTruyenDan_HinhThucTruyenDan == "RÃNH BÊ TÔNG".ToUpper() || ThongTinDuongTruyenDan_HinhThucTruyenDan == "CỐNG HỘP".ToUpper())
                ? TTTDCongHoRanh_TongChieuDaiTheoCKNguyen - TTCDSLCauKienDuongTruyenDan_TongChieuDai
                : 0;
            result = Math.Round(result, 3);
            return Math.Round(result, 2, MidpointRounding.AwayFromZero);
        }


        public string TTTDCongHoRanh_XacDinhOngCongCanThem(string ThongTinDuongTruyenDan_HinhThucTruyenDan, double TTTDCongHoRanh_ChieuDaiThucTe)
        {
            string result;
            
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();

            if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "RÃNH XÂY".ToUpper() || ThongTinDuongTruyenDan_HinhThucTruyenDan == "RÃNH BÊ TÔNG".ToUpper() || ThongTinDuongTruyenDan_HinhThucTruyenDan == "CỐNG HỘP".ToUpper())
            {
                if (TTTDCongHoRanh_ChieuDaiThucTe >= -0.02)
                {
                    result = "Đủ";
                }
                else
                {
                    result = "Thêm 01";
                }
            }
            else
            {
                result = "0";
            }

            return result;
        }




        public int TTTDCongHoRanh_SoLuong1(string ThongTinDuongTruyenDan_HinhThucTruyenDan, string TTTDCongHoRanh_XacDinhOngCongCanThem)
        {
            // Chuyển đổi các tham số EP17 và JE17 thành dạng chữ hoa và loại bỏ khoảng trắng đầu cuối
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            TTTDCongHoRanh_XacDinhOngCongCanThem = TTTDCongHoRanh_XacDinhOngCongCanThem.ToUpper().Trim();

            // Kiểm tra điều kiện
            if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "CỐNG HỘP" || ThongTinDuongTruyenDan_HinhThucTruyenDan == "RÃNH XÂY" || ThongTinDuongTruyenDan_HinhThucTruyenDan == "RÃNH BÊ TÔNG")
            {
                return TTTDCongHoRanh_XacDinhOngCongCanThem == "THÊM 01" ? 1 : 0;
            }
            else
            {
                return 0;
            }
        }


        public double TTTDCongHoRanh_CDai1(double[] TTTDCongHoRanh_ChieuDaiThucTes, string[] ThongTinDuongTruyenDan_HinhThucTruyenDans, string[] TTTDCongHoRanh_XacDinhOngCongCanThems, string ThongTinDuongTruyenDan_HinhThucTruyenDan, string TTTDCongHoRanh_XacDinhOngCongCanThem)
        {
            try
            {
                ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
                // Kiểm tra điều kiện TTTDCongHoRanh_XacDinhOngCongCanThem có phải là "Thêm 01" không
                if (TTTDCongHoRanh_XacDinhOngCongCanThem == "Thêm 01")
                {
                    // Lọc các giá trị TTTDCongHoRanh_ChieuDaiThucTes thoả mãn điều kiện từ ThongTinDuongTruyenDan_HinhThucTruyenDans và hsValues
                    //var filteredValues = TTTDCongHoRanh_ChieuDaiThucTes
                    //    .Where((hrValue, index) =>
                    //        GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDans[index].ToUpper().Trim()) == ThongTinDuongTruyenDan_HinhThucTruyenDan.ToUpper().Trim()
                    //        && TTTDCongHoRanh_XacDinhOngCongCanThems[index] == "Thêm 01")
                    //    .ToArray();

                    List<double> filteredValues = new List<double>();

                    // Duyệt qua các phần tử của mảng hrValues
                    for (int index = 0; index < TTTDCongHoRanh_ChieuDaiThucTes.Length; index++)
                    {
                        double hrValue = TTTDCongHoRanh_ChieuDaiThucTes[index];
                        string enValue = ThongTinDuongTruyenDan_HinhThucTruyenDans[index];
                        string hsValue = TTTDCongHoRanh_XacDinhOngCongCanThems[index];

                        // Kiểm tra điều kiện enValues[index] == en100
                        bool isEnMatch = GetTenDanhMucById(enValue).ToUpper().Trim() == ThongTinDuongTruyenDan_HinhThucTruyenDan.ToUpper().Trim();

                        // Kiểm tra điều kiện hsValues[index] == "Thêm 01"
                        bool isHsMatch = hsValue == "Thêm 01";

                        // Nếu cả hai điều kiện đều đúng, thêm hrValue vào danh sách
                        if (isEnMatch && isHsMatch)
                        {
                            filteredValues.Add(hrValue);
                        }
                    }

                    // Chuyển danh sách về mảng
                    double[] filteredArray = filteredValues.ToArray();

                    // Nếu có các giá trị thoả mãn, tính trung bình
                    if (filteredValues.Any())
                    {
                        double average = filteredValues.Average();
                        // Lấy giá trị tuyệt đối và làm tròn đến 2 chữ số thập phân
                        return Math.Round(Math.Abs(average), 2);
                    }
                }

                // Nếu không thoả mãn điều kiện, trả về 0
                return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public double CDThuongLuu_DinhDeCong(string ThongTinMongDuongTruyenDan_LoaiMong, double CDThuongLuu_DayDongChay, double ThongTinCauTaoCongTron_CDayPhuBi)
        {
            double result = 0;
            ThongTinMongDuongTruyenDan_LoaiMong = GetTenDanhMucById(ThongTinMongDuongTruyenDan_LoaiMong).ToUpper().Trim();
            if (ThongTinMongDuongTruyenDan_LoaiMong == "Móng bê tông kết hợp đế".ToUpper() || ThongTinMongDuongTruyenDan_LoaiMong == "Đế".ToUpper())
            {
                result = CDThuongLuu_DayDongChay - ThongTinCauTaoCongTron_CDayPhuBi;
            }
            else
            {
                result = 0;
            }
            result = Math.Round(result, 3);
            return Math.Round(result, 2, MidpointRounding.AwayFromZero);
        }
        public double CDThuongLuu_DinhMongRanh(string ThongTinDuongTruyenDan_HinhThucTruyenDan, string ThongTinMongDuongTruyenDan_LoaiMong, double CDThuongLuu_DayDongChay)
        {
            double result = 0;
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            ThongTinMongDuongTruyenDan_LoaiMong = GetTenDanhMucById(ThongTinMongDuongTruyenDan_LoaiMong).ToUpper().Trim();
            if ((ThongTinDuongTruyenDan_HinhThucTruyenDan == "RÃNH XÂY".ToUpper() && ThongTinMongDuongTruyenDan_LoaiMong == "Móng bê tông".ToUpper()) ||
                (ThongTinDuongTruyenDan_HinhThucTruyenDan == "Rãnh bê tông".ToUpper() && ThongTinMongDuongTruyenDan_LoaiMong == "Móng bê tông".ToUpper()))
            {
                result = CDThuongLuu_DayDongChay;
            }
            else
            {
                result = 0;
            }
            result = Math.Round(result, 3);
            return Math.Round(result, 2, MidpointRounding.AwayFromZero);
        }
        public double CDThuongLuu_DinhMongCongHop(string ThongTinDuongTruyenDan_HinhThucTruyenDan, string ThongTinMongDuongTruyenDan_LoaiMong, double CDThuongLuu_DayDongChay, double TTKTHHCongHopRanh_CCaoDe)
        {
            double result = 0;
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            ThongTinMongDuongTruyenDan_LoaiMong = GetTenDanhMucById(ThongTinMongDuongTruyenDan_LoaiMong).ToUpper().Trim();
            if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "Cống hộp".ToUpper() && ThongTinMongDuongTruyenDan_LoaiMong == "Móng bê tông".ToUpper())
            {
                result =  CDThuongLuu_DayDongChay - TTKTHHCongHopRanh_CCaoDe;
            }
            else
            {
                result = 0;
            }
            result = Math.Round(result, 3);
            return Math.Round(result, 2, MidpointRounding.AwayFromZero);
        }
        public double CDThuongLuu_DinhMongCongTron(string ThongTinDuongTruyenDan_HinhThucTruyenDan, string ThongTinMongDuongTruyenDan_LoaiMong, double CDThuongLuu_DayDongChay, double ThongTinCauTaoCongTron_CDayPhuBi, double CDThuongLuu_DinhDeCong, double ThongTinCauTaoCongTron_CCaoDe)
        {
            double result = 0;
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            ThongTinMongDuongTruyenDan_LoaiMong = GetTenDanhMucById(ThongTinMongDuongTruyenDan_LoaiMong).ToUpper().Trim();
            if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "Cống tròn".ToUpper())
            {
                if (ThongTinMongDuongTruyenDan_LoaiMong == "Móng bê tông".ToUpper())
                {
                    result = CDThuongLuu_DayDongChay - ThongTinCauTaoCongTron_CDayPhuBi;
                }
                else if (ThongTinMongDuongTruyenDan_LoaiMong == "Móng bê tông kết hợp đế".ToUpper())
                {
                    result = CDThuongLuu_DinhDeCong - ThongTinCauTaoCongTron_CCaoDe;
                }
            }
            result = Math.Round(result, 3);
            return Math.Round(result, 2, MidpointRounding.AwayFromZero);
        }
        public double CDThuongLuu_DinhMongChanKhay(string ThongTinDuongTruyenDan_HinhThucTruyenDan, string ThongTinRanhThang_CauTaoChanKhay, double CDThuongLuu_DayDongChay)
        {
            double result = 0;
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "Rãnh thang".ToUpper())
            {
                if (ThongTinRanhThang_CauTaoChanKhay == "Bê tông".ToUpper() || ThongTinRanhThang_CauTaoChanKhay == "Bê tông cốt thép".ToUpper())
                {
                    result =  CDThuongLuu_DayDongChay;
                }
            }
            result = Math.Round(result, 3);
            return Math.Round(result, 2, MidpointRounding.AwayFromZero);
        }
        public double CDThuongLuu_DinhMongRanhThang(string ThongTinDuongTruyenDan_HinhThucTruyenDan, string ThongTinMongDuongTruyenDan_LoaiMong, double CDThuongLuu_DayDongChay)
        {
            double result = 0;
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            ThongTinMongDuongTruyenDan_LoaiMong = GetTenDanhMucById(ThongTinMongDuongTruyenDan_LoaiMong).ToUpper().Trim();
            if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "Rãnh thang".ToUpper() && ThongTinMongDuongTruyenDan_LoaiMong == "Móng bê tông".ToUpper())
            {
                result = CDThuongLuu_DayDongChay;
            }
            result = Math.Round(result, 3);
            return Math.Round(result, 2, MidpointRounding.AwayFromZero);
        }
        public double CDThuongLuu_DinhMongGop(string ThongTinDuongTruyenDan_HinhThucTruyenDan, string ThongTinMongDuongTruyenDan_LoaiMong, double CDThuongLuu_DayDongChay, double ThongTinCauTaoCongTron_CDayPhuBi, double CDThuongLuu_DinhDeCong, double ThongTinCauTaoCongTron_CCaoDe, double TTKTHHCongHopRanh_CCaoDe)
        {
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            ThongTinMongDuongTruyenDan_LoaiMong = GetTenDanhMucById(ThongTinMongDuongTruyenDan_LoaiMong).ToUpper().Trim();
            double result = 0;
            if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "Rãnh thang".ToUpper())
            {
                if (ThongTinMongDuongTruyenDan_LoaiMong == "Móng bê tông".ToUpper())
                {
                    result = CDThuongLuu_DayDongChay;
                }

            }
            else if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "Cống tròn".ToUpper())
            {
                if (ThongTinMongDuongTruyenDan_LoaiMong == "Móng bê tông".ToUpper())
                {
                    result = CDThuongLuu_DayDongChay - ThongTinCauTaoCongTron_CDayPhuBi;
                }
                else if (ThongTinMongDuongTruyenDan_LoaiMong == "Móng bê tông kết hợp đế".ToUpper())
                {
                    result = CDThuongLuu_DinhDeCong - ThongTinCauTaoCongTron_CCaoDe;
                }

            }
            else if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "Cống hộp".ToUpper())
            {
                if (ThongTinMongDuongTruyenDan_LoaiMong == "Móng bê tông".ToUpper())
                {
                    result = CDThuongLuu_DayDongChay - TTKTHHCongHopRanh_CCaoDe;
                }

            }
            else if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "RÃNH XÂY".ToUpper() || ThongTinDuongTruyenDan_HinhThucTruyenDan == "Rãnh bê tông".ToUpper())
            {
                if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "RÃNH XÂY".ToUpper() && ThongTinMongDuongTruyenDan_LoaiMong == "Móng bê tông".ToUpper())
                {
                    result = CDThuongLuu_DayDongChay;
                }
                else if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "Rãnh bê tông".ToUpper() && ThongTinMongDuongTruyenDan_LoaiMong == "Móng bê tông".ToUpper())
                {
                    result = CDThuongLuu_DayDongChay;
                }

            }
            result = Math.Round(result, 3);
            return Math.Round(result, 2, MidpointRounding.AwayFromZero);
        }
        public double CDThuongLuu_DinhLotRanh(string ThongTinDuongTruyenDan_HinhThucTruyenDan, string ThongTinMongDuongTruyenDan_LoaiMong, double CDThuongLuu_DinhMongRanh, double TTKTHHCongHopRanh_CCaoMong)
        {
            double result = 0;
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            ThongTinMongDuongTruyenDan_LoaiMong = GetTenDanhMucById(ThongTinMongDuongTruyenDan_LoaiMong).ToUpper().Trim();
            if ((ThongTinDuongTruyenDan_HinhThucTruyenDan == "RÃNH XÂY".ToUpper() || ThongTinDuongTruyenDan_HinhThucTruyenDan == "Rãnh bê tông".ToUpper()) && ThongTinMongDuongTruyenDan_LoaiMong == "Móng bê tông".ToUpper())
            {
                result = CDThuongLuu_DinhMongRanh - TTKTHHCongHopRanh_CCaoMong;
            }
            result = Math.Round(result, 3);
            return Math.Round(result, 2, MidpointRounding.AwayFromZero);
        }
        public double CDThuongLuu_DinhLotCongHop(string ThongTinDuongTruyenDan_HinhThucTruyenDan, string ThongTinMongDuongTruyenDan_LoaiMong, double CDThuongLuu_DinhMongCongHop, double TTKTHHCongHopRanh_CCaoMong)
        {
            double result = 0;
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            ThongTinMongDuongTruyenDan_LoaiMong = GetTenDanhMucById(ThongTinMongDuongTruyenDan_LoaiMong).ToUpper().Trim();
            if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "Cống hộp".ToUpper() && ThongTinMongDuongTruyenDan_LoaiMong == "Móng bê tông".ToUpper())
            {
                result = CDThuongLuu_DinhMongCongHop - TTKTHHCongHopRanh_CCaoMong;
            }
            result = Math.Round(result, 3);
            return Math.Round(result, 2, MidpointRounding.AwayFromZero);
        }
        public double CDThuongLuu_DinhLotCongTron(string ThongTinDuongTruyenDan_HinhThucTruyenDan, string ThongTinMongDuongTruyenDan_LoaiMong, double CDThuongLuu_DinhMongCongTron, double ThongTinCauTaoCongTron_CCaoMong)
        {
            double result = 0;
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            ThongTinMongDuongTruyenDan_LoaiMong = GetTenDanhMucById(ThongTinMongDuongTruyenDan_LoaiMong).ToUpper().Trim();
            if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "Cống tròn".ToUpper() && (ThongTinMongDuongTruyenDan_LoaiMong == "Móng bê tông".ToUpper() || ThongTinMongDuongTruyenDan_LoaiMong == "Móng bê tông kết hợp đế".ToUpper()))
            {
                result = CDThuongLuu_DinhMongCongTron - ThongTinCauTaoCongTron_CCaoMong;
            }
            result = Math.Round(result, 3);
            return Math.Round(result, 2, MidpointRounding.AwayFromZero);

        }
        public double CDThuongLuu_DinhLotOngNhua(string ThongTinDuongTruyenDan_HinhThucTruyenDan, string ThongTinMongDuongTruyenDan_LoaiMong, double CDThuongLuu_DayDongChay, double ThongTinKichThuocHinhHocOngNhua_CDayPhuBi)
        {
            double result = 0;
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            ThongTinMongDuongTruyenDan_LoaiMong = GetTenDanhMucById(ThongTinMongDuongTruyenDan_LoaiMong).ToUpper().Trim();
            if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "Ống nhựa".ToUpper() && ThongTinMongDuongTruyenDan_LoaiMong == "Đắp cát".ToUpper())
            {
                result = CDThuongLuu_DayDongChay - ThongTinKichThuocHinhHocOngNhua_CDayPhuBi;
            }
            result = Math.Round(result, 3);
            return Math.Round(result, 2, MidpointRounding.AwayFromZero);
        }
        public double CDThuongLuu_DinhLotGiangDinhRanhThang(string ThongTinDuongTruyenDan_HinhThucTruyenDan, string ThongTinRanhThang_CauTaoGiangDinh, double CDThuongLuu_DinhRanhThang, double ThongTinRanhThang_CCaoMongGiangDinh)
        {
            double result = 0;
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            ThongTinRanhThang_CauTaoGiangDinh = GetTenDanhMucById(ThongTinRanhThang_CauTaoGiangDinh).ToUpper().Trim();
            if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "Rãnh thang".ToUpper() && (ThongTinRanhThang_CauTaoGiangDinh == "Bê tông".ToUpper() || ThongTinRanhThang_CauTaoGiangDinh == "Bê tông cốt thép".ToUpper()))
            {
                result = CDThuongLuu_DinhRanhThang - ThongTinRanhThang_CCaoMongGiangDinh;
            }
            result = Math.Round(result, 3);
            return Math.Round(result, 2, MidpointRounding.AwayFromZero);
        }
        public double CDThuongLuu_DinhLotChanKhayRanhThang(string ThongTinDuongTruyenDan_HinhThucTruyenDan, string ThongTinRanhThang_CauTaoChanKhay, double CDThuongLuu_DayDongChay, double ThongTinRanhThang_CCaoMongChanKhay)
        {
            double result = 0;
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            ThongTinRanhThang_CauTaoChanKhay = GetTenDanhMucById(ThongTinRanhThang_CauTaoChanKhay).ToUpper().Trim();
            if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "Rãnh thang".ToUpper() && (ThongTinRanhThang_CauTaoChanKhay == "Bê tông".ToUpper() || ThongTinRanhThang_CauTaoChanKhay == "Bê tông cốt thép".ToUpper()))
            {
                 result =CDThuongLuu_DayDongChay - ThongTinRanhThang_CCaoMongChanKhay;
            }
            result = Math.Round(result, 3);
            return Math.Round(result, 2, MidpointRounding.AwayFromZero);
        }
       

        public double CDThuongLuu_DinhLotRanhThang(string ThongTinDuongTruyenDan_HinhThucTruyenDan, string ThongTinMongDuongTruyenDan_LoaiMong, double CDThuongLuu_DayDongChay, double ThongTinRanhThang_CCaoMong)
        {
            double result =0;
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            ThongTinMongDuongTruyenDan_LoaiMong = GetTenDanhMucById(ThongTinMongDuongTruyenDan_LoaiMong).ToUpper().Trim();

            if ((ThongTinDuongTruyenDan_HinhThucTruyenDan == "RÃNH XÂY".ToUpper() && ThongTinMongDuongTruyenDan_LoaiMong == "MÓNG BÊ TÔNG".ToUpper()) ||
                (ThongTinDuongTruyenDan_HinhThucTruyenDan == "RÃNH BÊ TÔNG".ToUpper() && ThongTinMongDuongTruyenDan_LoaiMong == "MÓNG BÊ TÔNG".ToUpper()))
            {
                result = CDThuongLuu_DayDongChay - ThongTinRanhThang_CCaoMong;
            }
            else
            {
                result = 0;
            }

            result = Math.Round(result, 3);
            return Math.Round(result, 2, MidpointRounding.AwayFromZero);
        }

        public double CDThuongLuu_DinhLotGop(string ThongTinDuongTruyenDan_HinhThucTruyenDan, string ThongTinMongDuongTruyenDan_LoaiMong, double CDThuongLuu_DayDongChay, double ThongTinKichThuocHinhHocOngNhua_CDayPhuBi, double CDThuongLuu_DinhMongCongTron, double ThongTinCauTaoCongTron_CCaoMong, double CDThuongLuu_DinhMongCongHop, double TTKTHHCongHopRanh_CCaoMong, double CDThuongLuu_DinhMongRanh)
        {
            double result =0;
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            ThongTinMongDuongTruyenDan_LoaiMong = GetTenDanhMucById(ThongTinMongDuongTruyenDan_LoaiMong).ToUpper().Trim();

            if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "RÃNH THANG".ToUpper())
            {
                if (ThongTinMongDuongTruyenDan_LoaiMong == "MÓNG BÊ TÔNG".ToUpper())
                {
                    // Xử lý trường hợp #REF! bằng cách gán giá trị mặc định là 0
                    result = CDThuongLuu_DayDongChay - 0;
                }
                else
                {
                    result = 0;
                }
            }
            else if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "ỐNG NHỰA".ToUpper())
            {
                if (ThongTinMongDuongTruyenDan_LoaiMong == "ĐẮP CÁT".ToUpper())
                {
                    result = CDThuongLuu_DayDongChay - ThongTinKichThuocHinhHocOngNhua_CDayPhuBi;
                }
                else
                {
                    result = 0;
                }
            }
            else if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "CỐNG TRÒN".ToUpper())
            {
                if (ThongTinMongDuongTruyenDan_LoaiMong == "MÓNG BÊ TÔNG".ToUpper() || ThongTinMongDuongTruyenDan_LoaiMong == "MÓNG BÊ TÔNG KẾT HỢP ĐẾ".ToUpper())
                {
                    result = CDThuongLuu_DinhMongCongTron - ThongTinCauTaoCongTron_CCaoMong;
                }
                else
                {
                    result = 0;
                }
            }
            else if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "CỐNG HỘP".ToUpper())
            {
                if (ThongTinMongDuongTruyenDan_LoaiMong == "MÓNG BÊ TÔNG".ToUpper())
                {
                    result = CDThuongLuu_DinhMongCongHop - TTKTHHCongHopRanh_CCaoMong;
                }
                else
                {
                    result = 0;
                }
            }
            else if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "RÃNH XÂY".ToUpper() || ThongTinDuongTruyenDan_HinhThucTruyenDan == "RÃNH BÊ TÔNG".ToUpper())
            {
                if (ThongTinMongDuongTruyenDan_LoaiMong == "MÓNG BÊ TÔNG".ToUpper())
                {
                    result = CDThuongLuu_DinhMongRanh - TTKTHHCongHopRanh_CCaoMong;
                }
                else
                {
                    result = 0;
                }
            }
            else
            {
                result = 0;
            }

            result = Math.Round(result, 3);
            return Math.Round(result, 2, MidpointRounding.AwayFromZero);
        }

        public double CDThuongLuu_DayDaoRanhThang(string ThongTinDuongTruyenDan_HinhThucTruyenDan, string ThongTinMongDuongTruyenDan_LoaiMong, double CDThuongLuu_DinhLotRanhThang, double ThongTinRanhThang_CCaoLot, double CDThuongLuu_DayDongChay)
        {
            double result = 0;
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "Rãnh thang".ToUpper())
            {
                if (ThongTinMongDuongTruyenDan_LoaiMong == "Móng bê tông".ToUpper())
                {
                    result = CDThuongLuu_DinhLotRanhThang - ThongTinRanhThang_CCaoLot;
                }
                else
                {
                    result = CDThuongLuu_DayDongChay;
                }
            }
            result = Math.Round(result, 3);
            return Math.Round(result, 2, MidpointRounding.AwayFromZero);
        }
        public double CDThuongLuu_DayDaoChanKhayRanhThang(string ThongTinDuongTruyenDan_HinhThucTruyenDan, string ThongTinRanhThang_CauTaoChanKhay, double CDThuongLuu_DinhLotChanKhayRanhThang, double ThongTinRanhThang_CCaoLotChanKhay, double CDThuongLuu_DayDongChay)
        {
            double result = 0;
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            ThongTinRanhThang_CauTaoChanKhay = GetTenDanhMucById(ThongTinRanhThang_CauTaoChanKhay).ToUpper().Trim();
            if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "Rãnh thang".ToUpper())
            {
                if (ThongTinRanhThang_CauTaoChanKhay == "Bê tông".ToUpper() || ThongTinRanhThang_CauTaoChanKhay == "Bê tông cốt thép".ToUpper())
                {
                    result = CDThuongLuu_DinhLotChanKhayRanhThang - ThongTinRanhThang_CCaoLotChanKhay;
                }
                else
                {
                    result = CDThuongLuu_DayDongChay;
                }
            }
            result = Math.Round(result, 3);
            return Math.Round(result, 2, MidpointRounding.AwayFromZero);
        }
        public double CDThuongLuu_DayDaoGiangDinhRanhThang(string ThongTinDuongTruyenDan_HinhThucTruyenDan, string ThongTinRanhThang_CauTaoGiangDinh, double CDThuongLuu_DinhLotGiangDinhRanhThang, double ThongTinRanhThang_CCaoLotGiangDinh, double CDThuongLuu_DinhRanhThang)
        {
            double result = 0;
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            ThongTinRanhThang_CauTaoGiangDinh = GetTenDanhMucById(ThongTinRanhThang_CauTaoGiangDinh).ToUpper().Trim();
            if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "Rãnh thang".ToUpper())
            {
                if (ThongTinRanhThang_CauTaoGiangDinh == "Bê tông".ToUpper() || ThongTinRanhThang_CauTaoGiangDinh == "Bê tông cốt thép".ToUpper())
                {
                    result = CDThuongLuu_DinhLotGiangDinhRanhThang - ThongTinRanhThang_CCaoLotGiangDinh;
                }
                else
                {
                    result = CDThuongLuu_DinhRanhThang;
                }
            }
            result = Math.Round(result, 3);
            return Math.Round(result, 2, MidpointRounding.AwayFromZero);
        }
        public double CDThuongLuu_DayDaoOngNhua(string ThongTinDuongTruyenDan_HinhThucTruyenDan, string ThongTinMongDuongTruyenDan_LoaiMong, double CDThuongLuu_DayDongChay, double ThongTinKichThuocHinhHocOngNhua_CDayPhuBi, double CDThuongLuu_DinhLotOngNhua, double ThongTinKichThuocHinhHocOngNhua_CCaoDemCat)
        {
            double result = 0;
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            ThongTinMongDuongTruyenDan_LoaiMong = GetTenDanhMucById(ThongTinMongDuongTruyenDan_LoaiMong).ToUpper().Trim();
            if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "Ống nhựa".ToUpper())
            {
                if (ThongTinMongDuongTruyenDan_LoaiMong == "Không đắp cát".ToUpper())
                {
                    result = CDThuongLuu_DayDongChay - ThongTinKichThuocHinhHocOngNhua_CDayPhuBi;
                }
                else if (ThongTinMongDuongTruyenDan_LoaiMong == "Đắp cát".ToUpper())
                {
                    result = CDThuongLuu_DinhLotOngNhua - ThongTinKichThuocHinhHocOngNhua_CCaoDemCat;
                }
            }
            result = Math.Round(result, 3);
            return Math.Round(result, 2, MidpointRounding.AwayFromZero);
        }
        public double CDThuongLuu_DayDaoRanh(string ThongTinDuongTruyenDan_HinhThucTruyenDan, double CDThuongLuu_DinhLotRanh, double TTKTHHCongHopRanh_CCaoLotMong)
        {
            double result = 0;
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "RÃNH XÂY".ToUpper() || ThongTinDuongTruyenDan_HinhThucTruyenDan == "Rãnh bê tông".ToUpper())
            {
                result = CDThuongLuu_DinhLotRanh - TTKTHHCongHopRanh_CCaoLotMong;
            }
            result = Math.Round(result, 3);
            return Math.Round(result, 2, MidpointRounding.AwayFromZero);
        }
       
        public double CDThuongLuu_DayDaoCongHop(string ThongTinDuongTruyenDan_HinhThucTruyenDan, string ThongTinMongDuongTruyenDan_LoaiMong, double CDThuongLuu_DayDongChay, double TTKTHHCongHopRanh_CCaoDe, double CDThuongLuu_DinhLotCongHop, double TTKTHHCongHopRanh_CCaoLotMong)
        {
            double result = 0;

            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            ThongTinMongDuongTruyenDan_LoaiMong = GetTenDanhMucById(ThongTinMongDuongTruyenDan_LoaiMong).ToUpper().Trim();

            if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "CỐNG HỘP")
            {
                if (ThongTinMongDuongTruyenDan_LoaiMong == "KHÔNG CÓ MÓNG")
                {
                    result = CDThuongLuu_DayDongChay - TTKTHHCongHopRanh_CCaoDe;
                }
                else if (ThongTinMongDuongTruyenDan_LoaiMong == "MÓNG BÊ TÔNG")
                {
                    result = CDThuongLuu_DinhLotCongHop - TTKTHHCongHopRanh_CCaoLotMong;
                }
            }

            result = Math.Round(result, 3);
            return Math.Round(result, 2, MidpointRounding.AwayFromZero); 
        }

        public double CDThuongLuu_DayDaoCongTron(string ThongTinDuongTruyenDan_HinhThucTruyenDan, string ThongTinMongDuongTruyenDan_LoaiMong, double CDThuongLuu_DayDongChay, double ThongTinCauTaoCongTron_CDayPhuBi, double CDThuongLuu_DinhDeCong, double ThongTinCauTaoCongTron_CCaoDe, double CDThuongLuu_DinhLotCongTron, double ThongTinCauTaoCongTron_CCaoLotMong)
        {
            double result = 0;

            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            ThongTinMongDuongTruyenDan_LoaiMong = GetTenDanhMucById(ThongTinMongDuongTruyenDan_LoaiMong).ToUpper().Trim();

            if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "CỐNG TRÒN")
            {
                if (ThongTinMongDuongTruyenDan_LoaiMong == "KHÔNG CÓ MÓNG")
                {
                    result = CDThuongLuu_DayDongChay - ThongTinCauTaoCongTron_CDayPhuBi;
                }
                else if (ThongTinMongDuongTruyenDan_LoaiMong == "ĐẾ")
                {
                    result = CDThuongLuu_DinhDeCong - ThongTinCauTaoCongTron_CCaoDe;
                }
                else if (ThongTinMongDuongTruyenDan_LoaiMong == "MÓNG BÊ TÔNG" || ThongTinMongDuongTruyenDan_LoaiMong == "MÓNG BÊ TÔNG KẾT HỢP ĐẾ")
                {
                    result = CDThuongLuu_DinhLotCongTron - ThongTinCauTaoCongTron_CCaoLotMong;
                }
            }

            result = Math.Round(result, 3); // Làm tròn đến 3 chữ số thập phân
            return Math.Round(result, 2, MidpointRounding.AwayFromZero); // Làm tròn đến 2 chữ số thập phân
        }


        public double CDThuongLuu_DayDaoGop(string ThongTinDuongTruyenDan_HinhThucTruyenDan, string ThongTinMongDuongTruyenDan_LoaiMong, double CDThuongLuu_DayDongChay, double ThongTinCauTaoCongTron_CDayPhuBi, double CDThuongLuu_DinhDeCong, double ThongTinCauTaoCongTron_CCaoDe, double CDThuongLuu_DinhLotCongTron, double ThongTinCauTaoCongTron_CCaoLotMong, double TTKTHHCongHopRanh_CCaoDe, double CDThuongLuu_DinhLotCongHop, double TTKTHHCongHopRanh_CCaoLotMong, double CDThuongLuu_DinhLotRanh, double ThongTinKichThuocHinhHocOngNhua_CDayPhuBi, double CDThuongLuu_DinhLotOngNhua, double ThongTinKichThuocHinhHocOngNhua_CCaoDemCat)
        {
            double result;
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            ThongTinMongDuongTruyenDan_LoaiMong = GetTenDanhMucById(ThongTinMongDuongTruyenDan_LoaiMong).ToUpper().Trim();

            if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "CỐNG TRÒN".ToUpper())
            {
                if (ThongTinMongDuongTruyenDan_LoaiMong == "KHÔNG CÓ MÓNG".ToUpper())
                {
                    result = CDThuongLuu_DayDongChay - ThongTinCauTaoCongTron_CDayPhuBi;
                }
                else if (ThongTinMongDuongTruyenDan_LoaiMong == "ĐẾ".ToUpper())
                {
                    result = CDThuongLuu_DinhDeCong - ThongTinCauTaoCongTron_CCaoDe;
                }
                else if (ThongTinMongDuongTruyenDan_LoaiMong == "MÓNG BÊ TÔNG".ToUpper() || ThongTinMongDuongTruyenDan_LoaiMong == "MÓNG BÊ TÔNG KẾT HỢP ĐẾ".ToUpper())
                {
                    result = CDThuongLuu_DinhLotCongTron - ThongTinCauTaoCongTron_CCaoLotMong;
                }
                else
                {
                    result = 0;
                }
            }
            else if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "CỐNG HỘP".ToUpper())
            {
                if (ThongTinMongDuongTruyenDan_LoaiMong == "KHÔNG CÓ MÓNG".ToUpper())
                {
                    result = CDThuongLuu_DayDongChay - TTKTHHCongHopRanh_CCaoDe;
                }
                else if (ThongTinMongDuongTruyenDan_LoaiMong == "MÓNG BÊ TÔNG".ToUpper())
                {
                    result = CDThuongLuu_DinhLotCongHop - TTKTHHCongHopRanh_CCaoLotMong;
                }
                else
                {
                    result = 0;
                }
            }
            else if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "RÃNH XÂY".ToUpper() || ThongTinDuongTruyenDan_HinhThucTruyenDan == "RÃNH BÊ TÔNG".ToUpper())
            {
                result = CDThuongLuu_DinhLotRanh - TTKTHHCongHopRanh_CCaoLotMong;
            }
            else if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "ỐNG NHỰA".ToUpper())
            {
                if (ThongTinMongDuongTruyenDan_LoaiMong == "KHÔNG ĐẮP CÁT".ToUpper())
                {
                    result = CDThuongLuu_DayDongChay - ThongTinKichThuocHinhHocOngNhua_CDayPhuBi;
                }
                else if (ThongTinMongDuongTruyenDan_LoaiMong == "ĐẮP CÁT".ToUpper())
                {
                    result = CDThuongLuu_DinhLotOngNhua - ThongTinKichThuocHinhHocOngNhua_CCaoDemCat;
                }
                else
                {
                    result = 0;
                }
            }
            else if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "RÃNH THANG".ToUpper())
            {
                if (ThongTinMongDuongTruyenDan_LoaiMong == "MÓNG BÊ TÔNG".ToUpper())
                {
                    result = 0; // Thay thế #REF! bằng giá trị mặc định 0
                }
                else
                {
                    result = CDThuongLuu_DayDongChay;
                }
            }
            else
            {
                result = 0;
            }

            result = Math.Round(result, 3); // Làm tròn đến 3 chữ số thập phân
            return Math.Round(result, 2, MidpointRounding.AwayFromZero); // Làm tròn đến 2 chữ số thập phân
        }


        public double CDThuongLuu_ChieuSauDao(double CDThuongLuu_HienTrangTruocKhiDaoThuongLuu, double CDThuongLuu_DayDaoGop)
        {
            double result = 0;

            if (CDThuongLuu_DayDaoGop > 0)
            {
                result = CDThuongLuu_HienTrangTruocKhiDaoThuongLuu - CDThuongLuu_DayDaoGop;
            }

            result = Math.Round(result, 3); // Làm tròn đến 3 chữ số thập phân
            return Math.Round(result, 2, MidpointRounding.AwayFromZero); // Làm tròn đến 2 chữ số thập phân
        }



        public double CDThuongLuu_DinhRanhThang(string ThongTinDuongTruyenDan_HinhThucTruyenDan, double CDThuongLuu_DayDongChay, double CDThuongLuu_ChieuCaoRanhThangTuDayDongChayDenDinh)
        {
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            double result = 0;

            if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "RÃNH THANG".ToUpper())
            {
                result = CDThuongLuu_DayDongChay + CDThuongLuu_ChieuCaoRanhThangTuDayDongChayDenDinh;
            }

            result = Math.Round(result, 3); // Làm tròn đến 3 chữ số thập phân
            return Math.Round(result, 2, MidpointRounding.AwayFromZero); // Làm tròn đến 2 chữ số thập phân
        }


        public double CDThuongLuu_DinhCongTron(string ThongTinDuongTruyenDan_HinhThucTruyenDan, double CDThuongLuu_DinhTrongLongSuDung, double ThongTinCauTaoCongTron_CDayPhuBi)
        {
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            double result = 0;

            if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "CỐNG TRÒN".ToUpper())
            {
                result = CDThuongLuu_DinhTrongLongSuDung + ThongTinCauTaoCongTron_CDayPhuBi;
            }

            result = Math.Round(result, 3); // Làm tròn đến 3 chữ số thập phân
            return Math.Round(result, 2, MidpointRounding.AwayFromZero); // Làm tròn đến 2 chữ số thập phân
        }

        public double CDThuongLuu_DinhCongHop(string ThongTinDuongTruyenDan_HinhThucTruyenDan, double CDThuongLuu_DinhTrongLongSuDung, double TTKTHHCongHopRanh_CCaoMuMoThotTren)
        {
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            double result = 0;

            if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "CỐNG HỘP".ToUpper())
            {
                result = CDThuongLuu_DinhTrongLongSuDung + TTKTHHCongHopRanh_CCaoMuMoThotTren;
            }

            result = Math.Round(result, 3); // Làm tròn đến 3 chữ số thập phân
            return Math.Round(result, 2, MidpointRounding.AwayFromZero); // Làm tròn đến 2 chữ số thập phân
        }

        public double CDThuongLuu_DinhRanh(string ThongTinDuongTruyenDan_HinhThucTruyenDan, double CDThuongLuu_DinhTrongLongSuDung, double TTKTHHCongHopRanh_CCaoMuMoThotTren)
        {
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            double result = 0;

            if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "RÃNH XÂY".ToUpper() || ThongTinDuongTruyenDan_HinhThucTruyenDan == "RÃNH BÊ TÔNG".ToUpper())
            {
                result = CDThuongLuu_DinhTrongLongSuDung + TTKTHHCongHopRanh_CCaoMuMoThotTren;
            }

            result = Math.Round(result, 3); // Làm tròn đến 3 chữ số thập phân
            return Math.Round(result, 2, MidpointRounding.AwayFromZero); // Làm tròn đến 2 chữ số thập phân
        }

        public double CDThuongLuu_DinhOngNhua(string ThongTinDuongTruyenDan_HinhThucTruyenDan, double CDThuongLuu_DinhTrongLongSuDung, double ThongTinKichThuocHinhHocOngNhua_CDayPhuBi)
        {
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            double result = 0;

            if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "ỐNG NHỰA".ToUpper())
            {
                result = CDThuongLuu_DinhTrongLongSuDung + ThongTinKichThuocHinhHocOngNhua_CDayPhuBi;
            }

            result = Math.Round(result, 3); // Làm tròn đến 3 chữ số thập phân
            return Math.Round(result, 2, MidpointRounding.AwayFromZero); // Làm tròn đến 2 chữ số thập phân
        }

        public double CDThuongLuu_DinhDapCat(string ThongTinDuongTruyenDan_HinhThucTruyenDan, double CDThuongLuu_DinhOngNhua, double ThongTinKichThuocHinhHocOngNhua_CCaoDapCat)
        {
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            double result = 0;

            if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "ỐNG NHỰA".ToUpper())
            {
                result = CDThuongLuu_DinhOngNhua + ThongTinKichThuocHinhHocOngNhua_CCaoDapCat;
            }

            result = Math.Round(result, 3); // Làm tròn đến 3 chữ số thập phân
            return Math.Round(result, 2, MidpointRounding.AwayFromZero); // Làm tròn đến 2 chữ số thập phân
        }

        public double CDThuongLuu_DinhMuMoThotDuoiCongHopRanh(string ThongTinDuongTruyenDan_HinhThucTruyenDan, double CDThuongLuu_DinhCongHop, double CDThuongLuu_DinhRanh, double TTKTHHCongHopRanh_CCaoMuMoThotTren)
        {
            double result;
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "CỐNG HỘP")
            {
                result = CDThuongLuu_DinhCongHop - TTKTHHCongHopRanh_CCaoMuMoThotTren;
            }
            else if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "RÃNH XÂY" || ThongTinDuongTruyenDan_HinhThucTruyenDan == "RÃNH BÊ TÔNG")
            {
                result = CDThuongLuu_DinhRanh - TTKTHHCongHopRanh_CCaoMuMoThotTren;
            }
            else
            {
                result = 0;
            }

            result = Math.Round(result, 3); // Làm tròn đến 3 chữ số thập phân
            return Math.Round(result, 2, MidpointRounding.AwayFromZero); // Làm tròn đến 2 chữ số thập phân
        }
        public double CDThuongLuu_DinhGiangDinhRanhThang(string ThongTinDuongTruyenDan_HinhThucTruyenDan, string ThongTinRanhThang_CauTaoGiangDinh, double ThongTinRanhThang_CRongMongChanKhay)
        {
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            double result = 0;

            if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "RÃNH THANG".ToUpper())
            {
                if (ThongTinRanhThang_CauTaoGiangDinh == "BÊ TÔNG".ToUpper() || ThongTinRanhThang_CauTaoGiangDinh == "BÊ TÔNG CỐT THÉP".ToUpper())
                {
                    result = ThongTinRanhThang_CRongMongChanKhay;
                }
            }

            result = Math.Round(result, 3); // Làm tròn đến 3 chữ số thập phân
            return Math.Round(result, 2, MidpointRounding.AwayFromZero); // Làm tròn đến 2 chữ số thập phân
        }

        public double CDThuongLuu_DinhGop(string ThongTinDuongTruyenDan_HinhThucTruyenDan, double CDThuongLuu_DinhTrongLongSuDung, double ThongTinCauTaoCongTron_CDayPhuBi, double TTKTHHCongHopRanh_CCaoMuMoThotTren, double ThongTinKichThuocHinhHocOngNhua_CDayPhuBi, double CDThuongLuu_DayDongChay)
        {
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            double result = 0;

            if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "CỐNG TRÒN")
            {
                result = CDThuongLuu_DinhTrongLongSuDung + ThongTinCauTaoCongTron_CDayPhuBi;
            }
            else if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "CỐNG HỘP")
            {
                result = CDThuongLuu_DinhTrongLongSuDung + TTKTHHCongHopRanh_CCaoMuMoThotTren;
            }
            else if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "RÃNH XÂY" || ThongTinDuongTruyenDan_HinhThucTruyenDan == "RÃNH BÊ TÔNG")
            {
                result = CDThuongLuu_DinhTrongLongSuDung + TTKTHHCongHopRanh_CCaoMuMoThotTren;
            }
            else if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "ỐNG NHỰA")
            {
                result = CDThuongLuu_DinhTrongLongSuDung + ThongTinKichThuocHinhHocOngNhua_CDayPhuBi;
            }
            else if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "RÃNH THANG")
            {
                result = CDThuongLuu_DayDongChay + 0;
            }

            result = Math.Round(result, 3); // Làm tròn đến 3 chữ số thập phân
            return Math.Round(result, 2, MidpointRounding.AwayFromZero); // Làm tròn đến 2 chữ số thập phân
        }


        public double CDThuongLuu_DinhTuongCHopRanh(string ThongTinDuongTruyenDan_HinhThucTruyenDan, double CDThuongLuu_DinhMuMoThotDuoiCongHopRanh, double TTKTHHCongHopRanh_CCaoMuMoThotDuoi)
        {
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            double result = 0;

            if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "RÃNH XÂY".ToUpper() ||
                ThongTinDuongTruyenDan_HinhThucTruyenDan == "RÃNH BÊ TÔNG".ToUpper() ||
                ThongTinDuongTruyenDan_HinhThucTruyenDan == "CỐNG HỘP".ToUpper())
            {
                result = CDThuongLuu_DinhMuMoThotDuoiCongHopRanh - TTKTHHCongHopRanh_CCaoMuMoThotDuoi;
            }

            result = Math.Round(result, 3); // Làm tròn đến 3 chữ số thập phân
            return Math.Round(result, 2, MidpointRounding.AwayFromZero); // Làm tròn đến 2 chữ số thập phân
        }

        public double CDThuongLuu_CCaoTuongCongRanh(string ThongTinDuongTruyenDan_HinhThucTruyenDan, double CDThuongLuu_DinhTuongCHopRanh, double CDThuongLuu_DayDongChay)
        {
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            double result = 0;

            if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "RÃNH XÂY".ToUpper() ||
                ThongTinDuongTruyenDan_HinhThucTruyenDan == "RÃNH BÊ TÔNG".ToUpper() ||
                ThongTinDuongTruyenDan_HinhThucTruyenDan == "CỐNG HỘP".ToUpper())
            {
                result = CDThuongLuu_DinhTuongCHopRanh - CDThuongLuu_DayDongChay;
            }

            result = Math.Round(result, 3); // Làm tròn đến 3 chữ số thập phân
            return Math.Round(result, 2, MidpointRounding.AwayFromZero); // Làm tròn đến 2 chữ số thập phân
        }

        public double CDHaLu_DinhRanhThang(string ThongTinDuongTruyenDan_HinhThucTruyenDan, double CDHaLu_DayDongChay, double CDHaLu_ChieuCaoRanhThangTuDayDongChayDenDinh)
        {
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            double result = 0;

            if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "RÃNH THANG")
            {
                result = CDHaLu_DayDongChay + CDHaLu_ChieuCaoRanhThangTuDayDongChayDenDinh;
            }

            result = Math.Round(result, 3); // Làm tròn đến 3 chữ số thập phân
            return Math.Round(result, 2, MidpointRounding.AwayFromZero); // Làm tròn đến 2 chữ số thập phân
        }

        public double CDHaLu_DinhDapCat(string ThongTinDuongTruyenDan_HinhThucTruyenDan, double CDHaLu_DinhOngNhua, double ThongTinKichThuocHinhHocOngNhua_CCaoDapCat)
        {
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            double result = 0;

            if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "ỐNG NHỰA")
            {
                result = CDHaLu_DinhOngNhua + ThongTinKichThuocHinhHocOngNhua_CCaoDapCat;
            }

            result = Math.Round(result, 3); // Làm tròn đến 3 chữ số thập phân
            return Math.Round(result, 2, MidpointRounding.AwayFromZero); // Làm tròn đến 2 chữ số thập phân
        }

        public double CDHaLu_DinhOngNhua(string ThongTinDuongTruyenDan_HinhThucTruyenDan, double CDHaLu_DinhTrongLongSuDung, double ThongTinKichThuocHinhHocOngNhua_CDayPhuBi)
        {
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            double result = 0;

            if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "ỐNG NHỰA")
            {
                result = CDHaLu_DinhTrongLongSuDung + ThongTinKichThuocHinhHocOngNhua_CDayPhuBi;
            }

            result = Math.Round(result, 3); // Làm tròn đến 3 chữ số thập phân
            return Math.Round(result, 2, MidpointRounding.AwayFromZero); // Làm tròn đến 2 chữ số thập phân
        }

        public double CDHaLu_DinhRanh(string ThongTinDuongTruyenDan_HinhThucTruyenDan, double CDHaLu_DinhTrongLongSuDung, double TTKTHHCongHopRanh_CCaoMuMoThotTren)
        {
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            double result = 0;

            if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "RÃNH XÂY" || ThongTinDuongTruyenDan_HinhThucTruyenDan == "RÃNH BÊ TÔNG")
            {
                result = CDHaLu_DinhTrongLongSuDung + TTKTHHCongHopRanh_CCaoMuMoThotTren;
            }

            result = Math.Round(result, 3); // Làm tròn đến 3 chữ số thập phân
            return Math.Round(result, 2, MidpointRounding.AwayFromZero); // Làm tròn đến 2 chữ số thập phân
        }

        public double CDHaLu_DinhCongHop(string ThongTinDuongTruyenDan_HinhThucTruyenDan, double CDHaLu_DinhTrongLongSuDung, double TTKTHHCongHopRanh_CCaoMuMoThotTren)
        {
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            double result = 0;

            if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "CỐNG HỘP")
            {
                result = CDHaLu_DinhTrongLongSuDung + TTKTHHCongHopRanh_CCaoMuMoThotTren;
            }

            result = Math.Round(result, 3); // Làm tròn đến 3 chữ số thập phân
            return Math.Round(result, 2, MidpointRounding.AwayFromZero); // Làm tròn đến 2 chữ số thập phân
        }

        public double CDHaLu_DinhCongTron(string ThongTinDuongTruyenDan_HinhThucTruyenDan, double CDHaLu_DinhTrongLongSuDung, double ThongTinCauTaoCongTron_CDayPhuBi)
        {
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            double result = 0;

            if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "CỐNG TRÒN")
            {
                result = CDHaLu_DinhTrongLongSuDung + ThongTinCauTaoCongTron_CDayPhuBi;
            }

            result = Math.Round(result, 3); // Làm tròn đến 3 chữ số thập phân
            return Math.Round(result, 2, MidpointRounding.AwayFromZero); // Làm tròn đến 2 chữ số thập phân
        }

        public double CDHaLu_DinhGop(string ThongTinDuongTruyenDan_HinhThucTruyenDan, double CDHaLu_DinhTrongLongSuDung, double ThongTinCauTaoCongTron_CDayPhuBi, double TTKTHHCongHopRanh_CCaoMuMoThotTren, double ThongTinKichThuocHinhHocOngNhua_CDayPhuBi, double CDHaLu_DayDongChay)
        {
            double result = 0;
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "Cống tròn".ToUpper())
            {
                result = CDHaLu_DinhTrongLongSuDung + ThongTinCauTaoCongTron_CDayPhuBi;
            }
            else if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "Cống hộp".ToUpper())
            {
                result = CDHaLu_DinhTrongLongSuDung + TTKTHHCongHopRanh_CCaoMuMoThotTren;
            }
            else if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "RÃNH XÂY".ToUpper() || ThongTinDuongTruyenDan_HinhThucTruyenDan == "Rãnh bê tông".ToUpper())
            {
                result = CDHaLu_DinhTrongLongSuDung + TTKTHHCongHopRanh_CCaoMuMoThotTren;
            }
            else if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "Ống nhựa".ToUpper())
            {
                result = CDHaLu_DinhTrongLongSuDung + ThongTinKichThuocHinhHocOngNhua_CDayPhuBi;
            }
            else if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "Rãnh thang".ToUpper())
            {
                result = CDHaLu_DayDongChay + 0;
            }

            result = Math.Round(result, 3); // Làm tròn đến 3 chữ số thập phân
            return Math.Round(result, 2, MidpointRounding.AwayFromZero); // Làm tròn đến 2 chữ số thập phân
        }
        public double CDHaLu_DinhGiangDinhRanhThang(string ThongTinDuongTruyenDan_HinhThucTruyenDan, string ThongTinRanhThang_CauTaoGiangDinh, double CDHaLu_DinhRanhThang)
        {
            double result = 0;
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "Rãnh thang".ToUpper() && (ThongTinRanhThang_CauTaoGiangDinh == "Bê tông".ToUpper() || ThongTinRanhThang_CauTaoGiangDinh == "Bê tông cốt thép".ToUpper()))
            {
                result = CDHaLu_DinhRanhThang;
            }

            result = Math.Round(result, 3); // Làm tròn đến 3 chữ số thập phân
            return Math.Round(result, 2, MidpointRounding.AwayFromZero); // Làm tròn đến 2 chữ số thập phân
        }
        public double CDHaLu_DinhMuMoThotDuoiCongHopRanh(string ThongTinDuongTruyenDan_HinhThucTruyenDan, double CDHaLu_DinhCongHop, double TTKTHHCongHopRanh_CCaoMuMoThotTren, double CDHaLu_DinhRanh)
        {
            double result = 0;
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "Cống hộp".ToUpper())
            {
                result = CDHaLu_DinhCongHop - TTKTHHCongHopRanh_CCaoMuMoThotTren;
            }
            else if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "RÃNH XÂY".ToUpper() || ThongTinDuongTruyenDan_HinhThucTruyenDan == "Rãnh bê tông".ToUpper())
            {
                result = CDHaLu_DinhRanh - TTKTHHCongHopRanh_CCaoMuMoThotTren;
            }

            result = Math.Round(result, 3); // Làm tròn đến 3 chữ số thập phân
            return Math.Round(result, 2, MidpointRounding.AwayFromZero); // Làm tròn đến 2 chữ số thập phân
        }
        public double CDHaLu_DinhTuongCHopRanh(string ThongTinDuongTruyenDan_HinhThucTruyenDan, double CDHaLu_DinhMuMoThotDuoiCongHopRanh, double TTKTHHCongHopRanh_CCaoMuMoThotDuoi)
        {
            double result = 0;
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "RÃNH XÂY".ToUpper() || ThongTinDuongTruyenDan_HinhThucTruyenDan == "Rãnh bê tông".ToUpper() || ThongTinDuongTruyenDan_HinhThucTruyenDan == "Cống hộp".ToUpper())
            {
                result = CDHaLu_DinhMuMoThotDuoiCongHopRanh - TTKTHHCongHopRanh_CCaoMuMoThotDuoi;
            }

            result = Math.Round(result, 3); // Làm tròn đến 3 chữ số thập phân
            return Math.Round(result, 2, MidpointRounding.AwayFromZero); // Làm tròn đến 2 chữ số thập phân
        }
        public double CDHaLu_CCaoTuongCongRanh(string ThongTinDuongTruyenDan_HinhThucTruyenDan, double CDHaLu_DinhTuongCHopRanh, double CDHaLu_DayDongChay)
        {
            double result = 0;
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "RÃNH XÂY".ToUpper() || ThongTinDuongTruyenDan_HinhThucTruyenDan == "Rãnh bê tông".ToUpper() || ThongTinDuongTruyenDan_HinhThucTruyenDan == "Cống hộp".ToUpper())
            {
                result = CDHaLu_DinhTuongCHopRanh - CDHaLu_DayDongChay;
            }

            result = Math.Round(result, 3); // Làm tròn đến 3 chữ số thập phân
            return Math.Round(result, 2, MidpointRounding.AwayFromZero); // Làm tròn đến 2 chữ số thập phân
        }
        public double CDHaLu_DinhDeCong(string ThongTinMongDuongTruyenDan_LoaiMong, double CDHaLu_DayDongChay, double ThongTinCauTaoCongTron_CDayPhuBi)
        {
            double result = 0;
            ThongTinMongDuongTruyenDan_LoaiMong = GetTenDanhMucById(ThongTinMongDuongTruyenDan_LoaiMong).ToUpper().Trim();
            if (ThongTinMongDuongTruyenDan_LoaiMong == "Móng bê tông kết hợp đế".ToUpper() || ThongTinMongDuongTruyenDan_LoaiMong == "Đế".ToUpper())
            {
                result = CDHaLu_DayDongChay - ThongTinCauTaoCongTron_CDayPhuBi;
            }

            result = Math.Round(result, 3); // Làm tròn đến 3 chữ số thập phân
            return Math.Round(result, 2, MidpointRounding.AwayFromZero); // Làm tròn đến 2 chữ số thập phân
        }
        public double CDHaLu_DinhMongRanh(string ThongTinDuongTruyenDan_HinhThucTruyenDan, string ThongTinMongDuongTruyenDan_LoaiMong, double CDHaLu_DayDongChay)
        {
            double result = 0;
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            ThongTinMongDuongTruyenDan_LoaiMong = GetTenDanhMucById(ThongTinMongDuongTruyenDan_LoaiMong).ToUpper().Trim();
            if ((ThongTinDuongTruyenDan_HinhThucTruyenDan == "RÃNH XÂY".ToUpper() || ThongTinDuongTruyenDan_HinhThucTruyenDan == "Rãnh bê tông".ToUpper()) && ThongTinMongDuongTruyenDan_LoaiMong == "Móng bê tông".ToUpper())
            {
                result = CDHaLu_DayDongChay;
            }

            result = Math.Round(result, 3); // Làm tròn đến 3 chữ số thập phân
            return Math.Round(result, 2, MidpointRounding.AwayFromZero); // Làm tròn đến 2 chữ số thập phân
        }
        public double CDHaLu_DinhMongCongHop(string ThongTinDuongTruyenDan_HinhThucTruyenDan, string ThongTinMongDuongTruyenDan_LoaiMong, double CDHaLu_DayDongChay, double TTKTHHCongHopRanh_CCaoDe)
        {
            double result = 0;
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            ThongTinMongDuongTruyenDan_LoaiMong = GetTenDanhMucById(ThongTinMongDuongTruyenDan_LoaiMong).ToUpper().Trim();
            if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "Cống hộp".ToUpper() && ThongTinMongDuongTruyenDan_LoaiMong == "Móng bê tông".ToUpper())
            {
                result = CDHaLu_DayDongChay - TTKTHHCongHopRanh_CCaoDe;
            }

            result = Math.Round(result, 3); // Làm tròn đến 3 chữ số thập phân
            return Math.Round(result, 2, MidpointRounding.AwayFromZero); // Làm tròn đến 2 chữ số thập phân
        }
        public double CDHaLu_DinhMongCongTron(string ThongTinDuongTruyenDan_HinhThucTruyenDan, string ThongTinMongDuongTruyenDan_LoaiMong, double CDHaLu_DayDongChay, double ThongTinCauTaoCongTron_CDayPhuBi, double CDHaLu_DinhDeCong, double ThongTinCauTaoCongTron_CCaoDe)
        {
            double result = 0;
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            ThongTinMongDuongTruyenDan_LoaiMong = GetTenDanhMucById(ThongTinMongDuongTruyenDan_LoaiMong).ToUpper().Trim();
            if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "Cống tròn".ToUpper())
            {
                if (ThongTinMongDuongTruyenDan_LoaiMong == "Móng bê tông".ToUpper())
                {
                    result = CDHaLu_DayDongChay - ThongTinCauTaoCongTron_CDayPhuBi;
                }
                else if (ThongTinMongDuongTruyenDan_LoaiMong == "Móng bê tông kết hợp đế".ToUpper())
                {
                    result = CDHaLu_DinhDeCong - ThongTinCauTaoCongTron_CCaoDe;
                }
            }

            result = Math.Round(result, 3); // Làm tròn đến 3 chữ số thập phân
            return Math.Round(result, 2, MidpointRounding.AwayFromZero); // Làm tròn đến 2 chữ số thập phân
        }
        public double CDHaLu_DinhMongChanKhay(string ThongTinDuongTruyenDan_HinhThucTruyenDan, string ThongTinRanhThang_CauTaoChanKhay, double CDHaLu_DayDongChay)
        {
            double result = 0;
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            ThongTinRanhThang_CauTaoChanKhay = GetTenDanhMucById(ThongTinRanhThang_CauTaoChanKhay).ToUpper().Trim();
            if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "Rãnh thang".ToUpper() && (ThongTinRanhThang_CauTaoChanKhay == "Bê tông".ToUpper() || ThongTinRanhThang_CauTaoChanKhay == "Bê tông cốt thép".ToUpper()))
            {
                result = CDHaLu_DayDongChay;
            }

            result = Math.Round(result, 3); // Làm tròn đến 3 chữ số thập phân
            return Math.Round(result, 2, MidpointRounding.AwayFromZero); // Làm tròn đến 2 chữ số thập phân
        }
        public double CDHaLu_DinhMongRanhThang(string ThongTinDuongTruyenDan_HinhThucTruyenDan, string ThongTinMongDuongTruyenDan_LoaiMong, double CDHaLu_DayDongChay)
        {
            double result = 0;
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            ThongTinMongDuongTruyenDan_LoaiMong = GetTenDanhMucById(ThongTinMongDuongTruyenDan_LoaiMong).ToUpper().Trim();
            if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "Rãnh thang".ToUpper() && ThongTinMongDuongTruyenDan_LoaiMong == "Móng bê tông".ToUpper())
            {
                result = CDHaLu_DayDongChay;
            }

            result = Math.Round(result, 3); // Làm tròn đến 3 chữ số thập phân
            return Math.Round(result, 2, MidpointRounding.AwayFromZero); // Làm tròn đến 2 chữ số thập phân
        }
        public double CDHaLu_DinhMongGop(string ThongTinDuongTruyenDan_HinhThucTruyenDan, string ThongTinMongDuongTruyenDan_LoaiMong, double CDHaLu_DayDongChay, double ThongTinCauTaoCongTron_CDayPhuBi, double CDHaLu_DinhDeCong, double ThongTinCauTaoCongTron_CCaoDe, double TTKTHHCongHopRanh_CCaoDe)
        {
            double result = 0;
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            ThongTinMongDuongTruyenDan_LoaiMong = GetTenDanhMucById(ThongTinMongDuongTruyenDan_LoaiMong).ToUpper().Trim();
            if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "Rãnh thang".ToUpper())
            {
                if (ThongTinMongDuongTruyenDan_LoaiMong == "Móng bê tông".ToUpper())
                {
                    result = CDHaLu_DayDongChay;
                }
            }
            else if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "Cống tròn".ToUpper())
            {
                if (ThongTinMongDuongTruyenDan_LoaiMong == "Móng bê tông".ToUpper())
                {
                    result = CDHaLu_DayDongChay - ThongTinCauTaoCongTron_CDayPhuBi;
                }
                else if (ThongTinMongDuongTruyenDan_LoaiMong == "Móng bê tông kết hợp đế".ToUpper())
                {
                    result = CDHaLu_DinhDeCong - ThongTinCauTaoCongTron_CCaoDe;
                }
            }
            else if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "Cống hộp".ToUpper())
            {
                if (ThongTinMongDuongTruyenDan_LoaiMong == "Móng bê tông".ToUpper())
                {
                    result = CDHaLu_DayDongChay - TTKTHHCongHopRanh_CCaoDe;
                }
            }
            else if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "RÃNH XÂY".ToUpper() || ThongTinDuongTruyenDan_HinhThucTruyenDan == "Rãnh bê tông".ToUpper())
            {
                if (ThongTinMongDuongTruyenDan_LoaiMong == "Móng bê tông".ToUpper())
                {
                    result = CDHaLu_DayDongChay;
                }
            }

            result = Math.Round(result, 3); // Làm tròn đến 3 chữ số thập phân
            return Math.Round(result, 2, MidpointRounding.AwayFromZero); // Làm tròn đến 2 chữ số thập phân
        }
        public double CDHaLu_DinhLotRanh(string ThongTinDuongTruyenDan_HinhThucTruyenDan, string ThongTinMongDuongTruyenDan_LoaiMong, double CDHaLu_DinhMongRanh, double TTKTHHCongHopRanh_CCaoMong)
        {
            double result = 0;
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            ThongTinMongDuongTruyenDan_LoaiMong = GetTenDanhMucById(ThongTinMongDuongTruyenDan_LoaiMong).ToUpper().Trim();

            if ((ThongTinDuongTruyenDan_HinhThucTruyenDan == "RÃNH XÂY" || ThongTinDuongTruyenDan_HinhThucTruyenDan == "RÃNH BÊ TÔNG")
                && ThongTinMongDuongTruyenDan_LoaiMong == "MÓNG BÊ TÔNG")
            {
                result = CDHaLu_DinhMongRanh - TTKTHHCongHopRanh_CCaoMong;
            }

            result = Math.Round(result, 3); // Làm tròn đến 3 chữ số thập phân
            return Math.Round(result, 2, MidpointRounding.AwayFromZero); // Làm tròn đến 2 chữ số thập phân
        }

        public double CDHaLu_DinhLotCongHop(string ThongTinDuongTruyenDan_HinhThucTruyenDan, string ThongTinMongDuongTruyenDan_LoaiMong, double CDHaLu_DinhMongCongHop, double TTKTHHCongHopRanh_CCaoMong)
        {
            double result = 0;
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            ThongTinMongDuongTruyenDan_LoaiMong = GetTenDanhMucById(ThongTinMongDuongTruyenDan_LoaiMong).ToUpper().Trim();

            if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "CỐNG HỘP" && ThongTinMongDuongTruyenDan_LoaiMong == "MÓNG BÊ TÔNG")
            {
                result = CDHaLu_DinhMongCongHop - TTKTHHCongHopRanh_CCaoMong;
            }

            result = Math.Round(result, 3); // Làm tròn đến 3 chữ số thập phân
            return Math.Round(result, 2, MidpointRounding.AwayFromZero); // Làm tròn đến 2 chữ số thập phân
        }

        public double CDHaLu_DinhLotCongTron(string ThongTinDuongTruyenDan_HinhThucTruyenDan, string ThongTinMongDuongTruyenDan_LoaiMong, double CDHaLu_DinhMongCongTron, double ThongTinCauTaoCongTron_CCaoMong)
        {
            double result = 0;
            ThongTinMongDuongTruyenDan_LoaiMong = GetTenDanhMucById(ThongTinMongDuongTruyenDan_LoaiMong).ToUpper().Trim();
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();

            if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "CỐNG TRÒN" &&
                (ThongTinMongDuongTruyenDan_LoaiMong == "MÓNG BÊ TÔNG" || ThongTinMongDuongTruyenDan_LoaiMong == "MÓNG BÊ TÔNG KẾT HỢP ĐẾ"))
            {
                result = CDHaLu_DinhMongCongTron - ThongTinCauTaoCongTron_CCaoMong;
            }

            result = Math.Round(result, 3); // Làm tròn đến 3 chữ số thập phân
            return Math.Round(result, 2, MidpointRounding.AwayFromZero); // Làm tròn đến 2 chữ số thập phân
        }

        public double CDHaLu_DinhLotOngNhua(string ThongTinDuongTruyenDan_HinhThucTruyenDan, string ThongTinMongDuongTruyenDan_LoaiMong, double CDHaLu_DayDongChay, double ThongTinKichThuocHinhHocOngNhua_CDayPhuBi)
        {
            double result = 0;
            ThongTinMongDuongTruyenDan_LoaiMong = GetTenDanhMucById(ThongTinMongDuongTruyenDan_LoaiMong).ToUpper().Trim();
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();

            if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "ỐNG NHỰA" && ThongTinMongDuongTruyenDan_LoaiMong == "ĐẮP CÁT")
            {
                result = CDHaLu_DayDongChay - ThongTinKichThuocHinhHocOngNhua_CDayPhuBi;
            }

            result = Math.Round(result, 3); // Làm tròn đến 3 chữ số thập phân
            return Math.Round(result, 2, MidpointRounding.AwayFromZero); // Làm tròn đến 2 chữ số thập phân
        }

        public double CDHaLu_DinhLotGiangDinhRanhThang(string ThongTinDuongTruyenDan_HinhThucTruyenDan, string ThongTinRanhThang_CauTaoGiangDinh, double CDHaLu_DinhRanhThang, double ThongTinRanhThang_CCaoMongGiangDinh)
        {
            double result = 0;
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            ThongTinRanhThang_CauTaoGiangDinh = GetTenDanhMucById(ThongTinRanhThang_CauTaoGiangDinh).ToUpper().Trim();

            if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "RÃNH THANG" && (ThongTinRanhThang_CauTaoGiangDinh == "BÊ TÔNG" || ThongTinRanhThang_CauTaoGiangDinh == "BÊ TÔNG CỐT THÉP"))
            {
                result = CDHaLu_DinhRanhThang - ThongTinRanhThang_CCaoMongGiangDinh;
            }

            result = Math.Round(result, 3); // Làm tròn đến 3 chữ số thập phân
            return Math.Round(result, 2, MidpointRounding.AwayFromZero); // Làm tròn đến 2 chữ số thập phân
        }

        public double CDHaLu_DinhLotChanKhayRanhThang(string ThongTinDuongTruyenDan_HinhThucTruyenDan, string ThongTinRanhThang_CauTaoChanKhay, double CDHaLu_DayDongChay, double ThongTinRanhThang_CCaoMongChanKhay)
        {
            double result = 0;
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            ThongTinRanhThang_CauTaoChanKhay = GetTenDanhMucById(ThongTinRanhThang_CauTaoChanKhay).ToUpper().Trim();

            if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "RÃNH THANG" && (ThongTinRanhThang_CauTaoChanKhay == "BÊ TÔNG" || ThongTinRanhThang_CauTaoChanKhay == "BÊ TÔNG CỐT THÉP"))
            {
                result = CDHaLu_DayDongChay - ThongTinRanhThang_CCaoMongChanKhay;
            }

            result = Math.Round(result, 3); // Làm tròn đến 3 chữ số thập phân
            return Math.Round(result, 2, MidpointRounding.AwayFromZero); // Làm tròn đến 2 chữ số thập phân
        }

        public double CDHaLu_DinhLotRanhThang(string ThongTinDuongTruyenDan_HinhThucTruyenDan, string ThongTinMongDuongTruyenDan_LoaiMong, double CDHaLu_DayDongChay, double ThongTinRanhThang_CCaoMong)
        {
            double result = 0;
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            ThongTinMongDuongTruyenDan_LoaiMong = GetTenDanhMucById(ThongTinMongDuongTruyenDan_LoaiMong).ToUpper().Trim();

            if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "RÃNH THANG" && ThongTinMongDuongTruyenDan_LoaiMong == "MÓNG BÊ TÔNG")
            {
                result = CDHaLu_DayDongChay - ThongTinRanhThang_CCaoMong;
            }

            result = Math.Round(result, 3); // Làm tròn đến 3 chữ số thập phân
            return Math.Round(result, 2, MidpointRounding.AwayFromZero); // Làm tròn đến 2 chữ số thập phân
        }

        public double CDHaLu_DinhLotGop(string ThongTinDuongTruyenDan_HinhThucTruyenDan, string ThongTinMongDuongTruyenDan_LoaiMong, double CDHaLu_DayDongChay, double ThongTinKichThuocHinhHocOngNhua_CDayPhuBi, double CDHaLu_DinhMongCongTron, double ThongTinCauTaoCongTron_CCaoMong, double CDHaLu_DinhMongCongHop, double TTKTHHCongHopRanh_CCaoMong, double CDHaLu_DinhMongRanh)
        {
            double result = 0; // Khai báo biến result
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            ThongTinMongDuongTruyenDan_LoaiMong = GetTenDanhMucById(ThongTinMongDuongTruyenDan_LoaiMong).ToUpper().Trim();

            if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "RÃNH THANG")
            {
                if (ThongTinMongDuongTruyenDan_LoaiMong == "MÓNG BÊ TÔNG")
                {
                    result = CDHaLu_DayDongChay; // Không cần trừ
                }
            }
            else if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "ỐNG NHỰA")
            {
                if (ThongTinMongDuongTruyenDan_LoaiMong == "ĐẮP CÁT")
                {
                    result = CDHaLu_DayDongChay - ThongTinKichThuocHinhHocOngNhua_CDayPhuBi;
                }
            }
            else if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "CỐNG TRÒN")
            {
                if (ThongTinMongDuongTruyenDan_LoaiMong == "MÓNG BÊ TÔNG" || ThongTinMongDuongTruyenDan_LoaiMong == "MÓNG BÊ TÔNG KẾT HỢP ĐẾ")
                {
                    result = CDHaLu_DinhMongCongTron - ThongTinCauTaoCongTron_CCaoMong;
                }
            }
            else if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "CỐNG HỘP")
            {
                if (ThongTinMongDuongTruyenDan_LoaiMong == "MÓNG BÊ TÔNG")
                {
                    result = CDHaLu_DinhMongCongHop - TTKTHHCongHopRanh_CCaoMong;
                }
            }
            else if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "RÃNH XÂY" || ThongTinDuongTruyenDan_HinhThucTruyenDan == "RÃNH BÊ TÔNG")
            {
                if (ThongTinMongDuongTruyenDan_LoaiMong == "MÓNG BÊ TÔNG")
                {
                    result = CDHaLu_DinhMongRanh - TTKTHHCongHopRanh_CCaoMong;
                }
            }

            result = Math.Round(result, 3); // Làm tròn đến 3 chữ số thập phân
            return Math.Round(result, 2, MidpointRounding.AwayFromZero); // Làm tròn đến 2 chữ số thập phân
        }

        public double CDHaLu_DayDaoRanhThang(string ThongTinDuongTruyenDan_HinhThucTruyenDan, string ThongTinMongDuongTruyenDan_LoaiMong, double CDHaLu_DinhLotRanhThang, double ThongTinRanhThang_CCaoLot, double CDHaLu_DayDongChay)
        {
            double result = 0;
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            ThongTinMongDuongTruyenDan_LoaiMong = GetTenDanhMucById(ThongTinMongDuongTruyenDan_LoaiMong).ToUpper().Trim();

            if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "RÃNH THANG")
            {
                if (ThongTinMongDuongTruyenDan_LoaiMong == "MÓNG BÊ TÔNG")
                {
                    result = CDHaLu_DinhLotRanhThang - ThongTinRanhThang_CCaoLot;
                }
                else
                {
                    result = CDHaLu_DayDongChay;
                }
            }

            result = Math.Round(result, 3); // Làm tròn đến 3 chữ số thập phân
            return Math.Round(result, 2, MidpointRounding.AwayFromZero); // Làm tròn đến 2 chữ số thập phân
        }

        public double CDHaLu_DayDaoChanKhayRanhThang(string ThongTinDuongTruyenDan_HinhThucTruyenDan, string ThongTinRanhThang_CauTaoChanKhay, double CDHaLu_DinhLotChanKhayRanhThang, double ThongTinRanhThang_CCaoLotChanKhay, double CDHaLu_DayDongChay)
        {
            double result = 0;
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            ThongTinRanhThang_CauTaoChanKhay = GetTenDanhMucById(ThongTinRanhThang_CauTaoChanKhay).ToUpper().Trim();

            if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "RÃNH THANG")
            {
                if (ThongTinRanhThang_CauTaoChanKhay == "BÊ TÔNG" || ThongTinRanhThang_CauTaoChanKhay == "BÊ TÔNG CỐT THÉP")
                {
                    result = CDHaLu_DinhLotChanKhayRanhThang - ThongTinRanhThang_CCaoLotChanKhay;
                }
                else
                {
                    result = CDHaLu_DayDongChay;
                }
            }

            result = Math.Round(result, 3); // Làm tròn đến 3 chữ số thập phân
            return Math.Round(result, 2, MidpointRounding.AwayFromZero); // Làm tròn đến 2 chữ số thập phân
        }

        public double CDHaLu_DayDaoGiangDinhRanhThang(string ThongTinDuongTruyenDan_HinhThucTruyenDan, string ThongTinRanhThang_CauTaoGiangDinh, double CDHaLu_DinhLotGiangDinhRanhThang, double ThongTinRanhThang_CCaoLotGiangDinh, double CDHaLu_DinhRanhThang)
        {
            double result = 0;
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            ThongTinRanhThang_CauTaoGiangDinh = GetTenDanhMucById(ThongTinRanhThang_CauTaoGiangDinh).ToUpper().Trim();

            if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "RÃNH THANG")
            {
                if (ThongTinRanhThang_CauTaoGiangDinh == "BÊ TÔNG" || ThongTinRanhThang_CauTaoGiangDinh == "BÊ TÔNG CỐT THÉP")
                {
                    result = CDHaLu_DinhLotGiangDinhRanhThang - ThongTinRanhThang_CCaoLotGiangDinh;
                }
                else
                {
                    result = CDHaLu_DinhRanhThang;
                }
            }

            result = Math.Round(result, 3); // Làm tròn đến 3 chữ số thập phân
            return Math.Round(result, 2, MidpointRounding.AwayFromZero); // Làm tròn đến 2 chữ số thập phân
        }

        public double CDHaLu_DayDaoOngNhua(string ThongTinDuongTruyenDan_HinhThucTruyenDan, string ThongTinMongDuongTruyenDan_LoaiMong, double CDHaLu_DayDongChay, double ThongTinKichThuocHinhHocOngNhua_CDayPhuBi, double CDHaLu_DinhLotOngNhua, double ThongTinKichThuocHinhHocOngNhua_CCaoDemCat)
        {
            double result = 0;
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            ThongTinMongDuongTruyenDan_LoaiMong = GetTenDanhMucById(ThongTinMongDuongTruyenDan_LoaiMong).ToUpper().Trim();

            if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "ỐNG NHỰA")
            {
                if (ThongTinMongDuongTruyenDan_LoaiMong == "KHÔNG ĐẮP CÁT")
                {
                    result = CDHaLu_DayDongChay - ThongTinKichThuocHinhHocOngNhua_CDayPhuBi;
                }
                else if (ThongTinMongDuongTruyenDan_LoaiMong == "ĐẮP CÁT")
                {
                    result = CDHaLu_DinhLotOngNhua - ThongTinKichThuocHinhHocOngNhua_CCaoDemCat;
                }
            }

            result = Math.Round(result, 3); // Làm tròn đến 3 chữ số thập phân
            return Math.Round(result, 2, MidpointRounding.AwayFromZero); // Làm tròn đến 2 chữ số thập phân
        }

        public double CDHaLu_DayDaoRanh(string ThongTinDuongTruyenDan_HinhThucTruyenDan, double CDHaLu_DinhLotRanh, double TTKTHHCongHopRanh_CCaoLotMong)
        {
            double result = 0;
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();

            if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "RÃNH XÂY" || ThongTinDuongTruyenDan_HinhThucTruyenDan == "RÃNH BÊ TÔNG")
            {
                result = CDHaLu_DinhLotRanh - TTKTHHCongHopRanh_CCaoLotMong;
            }

            result = Math.Round(result, 3); // Làm tròn đến 3 chữ số thập phân
            return Math.Round(result, 2, MidpointRounding.AwayFromZero); // Làm tròn đến 2 chữ số thập phân
        }

        public double CDHaLu_DayDaoCongHop(string ThongTinDuongTruyenDan_HinhThucTruyenDan, string ThongTinMongDuongTruyenDan_LoaiMong, double CDHaLu_DayDongChay, double TTKTHHCongHopRanh_CCaoDe, double CDHaLu_DinhLotCongHop, double TTKTHHCongHopRanh_CCaoLotMong)
        {
            double result = 0;
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            ThongTinMongDuongTruyenDan_LoaiMong = GetTenDanhMucById(ThongTinMongDuongTruyenDan_LoaiMong).ToUpper().Trim();

            if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "CỐNG HỘP" && ThongTinMongDuongTruyenDan_LoaiMong == "KHÔNG CÓ MÓNG")
            {
                result = CDHaLu_DayDongChay - TTKTHHCongHopRanh_CCaoDe;
            }
            else if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "CỐNG HỘP" && ThongTinMongDuongTruyenDan_LoaiMong == "MÓNG BÊ TÔNG")
            {
                result = CDHaLu_DinhLotCongHop - TTKTHHCongHopRanh_CCaoLotMong;
            }

            result = Math.Round(result, 3); // Làm tròn đến 3 chữ số thập phân
            return Math.Round(result, 2, MidpointRounding.AwayFromZero); // Làm tròn đến 2 chữ số thập phân
        }

        public double CDHaLu_DayDaoCongTron(string ThongTinDuongTruyenDan_HinhThucTruyenDan, string ThongTinMongDuongTruyenDan_LoaiMong, double CDHaLu_DayDongChay, double ThongTinCauTaoCongTron_CDayPhuBi, double CDHaLu_DinhDeCong, double ThongTinCauTaoCongTron_CCaoDe, double CDHaLu_DinhLotCongTron, double ThongTinCauTaoCongTron_CCaoLotMong)
        {
            double result = 0;
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            ThongTinMongDuongTruyenDan_LoaiMong = GetTenDanhMucById(ThongTinMongDuongTruyenDan_LoaiMong).ToUpper().Trim();

            if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "CỐNG TRÒN")
            {
                if (ThongTinMongDuongTruyenDan_LoaiMong == "KHÔNG CÓ MÓNG")
                {
                    result = CDHaLu_DayDongChay - ThongTinCauTaoCongTron_CDayPhuBi;
                }
                else if (ThongTinMongDuongTruyenDan_LoaiMong == "ĐẾ")
                {
                    result = CDHaLu_DinhDeCong - ThongTinCauTaoCongTron_CCaoDe;
                }
                else if (ThongTinMongDuongTruyenDan_LoaiMong == "MÓNG BÊ TÔNG" || ThongTinMongDuongTruyenDan_LoaiMong == "MÓNG BÊ TÔNG KẾT HỢP ĐẾ")
                {
                    result = CDHaLu_DinhLotCongTron - ThongTinCauTaoCongTron_CCaoLotMong;
                }
            }

            result = Math.Round(result, 3); // Làm tròn đến 3 chữ số thập phân
            return Math.Round(result, 2, MidpointRounding.AwayFromZero); // Làm tròn đến 2 chữ số thập phân
        }

        public double CDHaLu_DayDaoGop(string ThongTinDuongTruyenDan_HinhThucTruyenDan, string ThongTinMongDuongTruyenDan_LoaiMong, double CDHaLu_DayDongChay, double ThongTinCauTaoCongTron_CDayPhuBi, double CDHaLu_DinhDeCong, double ThongTinCauTaoCongTron_CCaoDe,
                             double CDHaLu_DinhLotCongTron, double ThongTinCauTaoCongTron_CCaoLotMong, double TTKTHHCongHopRanh_CCaoDe, double CDHaLu_DinhLotCongHop, double TTKTHHCongHopRanh_CCaoLotMong,
                             double CDHaLu_DinhLotRanh, double ThongTinKichThuocHinhHocOngNhua_CDayPhuBi, double CDHaLu_DinhLotOngNhua, double ThongTinKichThuocHinhHocOngNhua_CCaoDemCat)
        {
            double result = 0;

            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            ThongTinMongDuongTruyenDan_LoaiMong = GetTenDanhMucById(ThongTinMongDuongTruyenDan_LoaiMong).ToUpper().Trim();

            if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "CỐNG TRÒN")
            {
                if (ThongTinMongDuongTruyenDan_LoaiMong == "KHÔNG CÓ MÓNG")
                {
                    result = CDHaLu_DayDongChay - ThongTinCauTaoCongTron_CDayPhuBi;
                }
                else if (ThongTinMongDuongTruyenDan_LoaiMong == "ĐẾ")
                {
                    result = CDHaLu_DinhDeCong - ThongTinCauTaoCongTron_CCaoDe;
                }
                else if (ThongTinMongDuongTruyenDan_LoaiMong == "MÓNG BÊ TÔNG" || ThongTinMongDuongTruyenDan_LoaiMong == "MÓNG BÊ TÔNG KẾT HỢP ĐẾ")
                {
                    result = CDHaLu_DinhLotCongTron - ThongTinCauTaoCongTron_CCaoLotMong;
                }
            }
            else if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "CỐNG HỘP")
            {
                if (ThongTinMongDuongTruyenDan_LoaiMong == "KHÔNG CÓ MÓNG")
                {
                    result = CDHaLu_DayDongChay - TTKTHHCongHopRanh_CCaoDe;
                }
                else if (ThongTinMongDuongTruyenDan_LoaiMong == "MÓNG BÊ TÔNG")
                {
                    result = CDHaLu_DinhLotCongHop - TTKTHHCongHopRanh_CCaoLotMong;
                }
            }
            else if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "RÃNH XÂY" || ThongTinDuongTruyenDan_HinhThucTruyenDan == "RÃNH BÊ TÔNG")
            {
                result = CDHaLu_DinhLotRanh - TTKTHHCongHopRanh_CCaoLotMong;
            }
            else if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "ỐNG NHỰA")
            {
                if (ThongTinMongDuongTruyenDan_LoaiMong == "KHÔNG ĐẮP CÁT")
                {
                    result = CDHaLu_DayDongChay - ThongTinKichThuocHinhHocOngNhua_CDayPhuBi;
                }
                else if (ThongTinMongDuongTruyenDan_LoaiMong == "ĐẮP CÁT")
                {
                    result = CDHaLu_DinhLotOngNhua - ThongTinKichThuocHinhHocOngNhua_CCaoDemCat;
                }
            }
            else if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "RÃNH THANG")
            {
                if (ThongTinMongDuongTruyenDan_LoaiMong == "MÓNG BÊ TÔNG")
                {
                    result = CDHaLu_DayDongChay - 0;
                }
                else
                {
                    result = CDHaLu_DayDongChay;
                }
            }
            result = Math.Round(result, 3); // Làm tròn đến 3 chữ số thập phân
            return Math.Round(result, 2);
        }

        public double CDHaLu_ChieuSauDao(double CDHaLu_DayDaoGop, double CDHaLu_HienTrangTruocKhiDaoHaLuu)
        {
            double result = 0;

            if (CDHaLu_DayDaoGop > 0)
            {
                result = CDHaLu_HienTrangTruocKhiDaoHaLuu - CDHaLu_DayDaoGop;
            }
            result = Math.Round(result, 3); // Làm tròn đến 3 chữ số thập phân
            result = Math.Round(result, 2); // Làm tròn đến 2 chữ số thập phân
            return result;
        }


        public double TTVLDCongRanh_TLChieuCaoDaoDat(string TTVLDCongRanh_LoaiVatLieuDao, double CDThuongLuu_ChieuSauDao, double TTVLDCongRanh_TLChieuCaoDaoDa)
        {
            double result = 0;

            TTVLDCongRanh_LoaiVatLieuDao = GetTenDanhMucById(TTVLDCongRanh_LoaiVatLieuDao).ToUpper().Trim();

            if (string.IsNullOrEmpty(TTVLDCongRanh_LoaiVatLieuDao))
            {
                return 0;
            }
            else if (TTVLDCongRanh_LoaiVatLieuDao == "ĐÀO ĐÁ".ToUpper())
            {
                return 0;
            }
            else
            {
                result = CDThuongLuu_ChieuSauDao - TTVLDCongRanh_TLChieuCaoDaoDa;
            }

            result = Math.Round(result, 3); // Làm tròn đến 3 chữ số thập phân
            result = Math.Round(result, 2); // Làm tròn đến 2 chữ số thập phân
            return result;
        }

        public double TTVLDCongRanh_HLChieuCaoDaoDat(string TTVLDCongRanh_LoaiVatLieuDao, double CDHaLu_ChieuSauDao, double TTVLDCongRanh_HLChieuCaoDaoDa)
        {
            double result = 0;
            TTVLDCongRanh_LoaiVatLieuDao = GetTenDanhMucById(TTVLDCongRanh_LoaiVatLieuDao).ToUpper().Trim();

            if (string.IsNullOrEmpty(TTVLDCongRanh_LoaiVatLieuDao))
            {
                return 0;
            }
            else if (TTVLDCongRanh_LoaiVatLieuDao == "ĐÀO ĐÁ")
            {
                return 0;
            }
            else
            {
                result = CDHaLu_ChieuSauDao - TTVLDCongRanh_HLChieuCaoDaoDa;
            }

            result = Math.Round(result, 3); // Làm tròn đến 3 chữ số thập phân
            return Math.Round(result, 2, MidpointRounding.AwayFromZero); // Làm tròn đến 2 chữ số thập phân
        }


        public double TTCCCCT_CCaoLotDatTLuu(string TTVLDCongRanh_LoaiVatLieuDao, double TTVLDCongRanh_TLChieuCaoDaoDat, double ThongTinCauTaoCongTron_CCaoLotMong)
        {
            double result = 0;
            TTVLDCongRanh_LoaiVatLieuDao = GetTenDanhMucById(TTVLDCongRanh_LoaiVatLieuDao).ToUpper().Trim();

            if (TTVLDCongRanh_LoaiVatLieuDao == "ĐÀO ĐẤT" || TTVLDCongRanh_LoaiVatLieuDao == "ĐÀO ĐẤT + ĐÀO ĐÁ")
            {
                result = TTVLDCongRanh_TLChieuCaoDaoDat >= ThongTinCauTaoCongTron_CCaoLotMong
                    ? ThongTinCauTaoCongTron_CCaoLotMong
                    : TTVLDCongRanh_TLChieuCaoDaoDat;
            }

            result = Math.Round(result, 3); // Làm tròn đến 3 chữ số thập phân
            return Math.Round(result, 2, MidpointRounding.AwayFromZero); // Làm tròn đến 2 chữ số thập phân
        }

        public double TTCCCCT_CCaoLotDatHLuu(string TTVLDCongRanh_LoaiVatLieuDao, double TTVLDCongRanh_HLChieuCaoDaoDat, double ThongTinCauTaoCongTron_CCaoLotMong)
        {
            double result = 0;
            TTVLDCongRanh_LoaiVatLieuDao = GetTenDanhMucById(TTVLDCongRanh_LoaiVatLieuDao).ToUpper().Trim();
            if (TTVLDCongRanh_LoaiVatLieuDao == "Đào đất".ToUpper() || TTVLDCongRanh_LoaiVatLieuDao == "Đào đất + đào đá".ToUpper())
            {
                result = TTVLDCongRanh_HLChieuCaoDaoDat >= ThongTinCauTaoCongTron_CCaoLotMong ? ThongTinCauTaoCongTron_CCaoLotMong : TTVLDCongRanh_HLChieuCaoDaoDat;
            }
            else
            {
                result = 0;
            }
            result = Math.Round(result, 3);
            return Math.Round(result, 2, MidpointRounding.AwayFromZero);
        }

        public double TTCCCCT_CCaoLotDaTLuu(string TTVLDCongRanh_LoaiVatLieuDao, double TTVLDCongRanh_TLChieuCaoDaoDa, double TTVLDCongRanh_TLTongChieuSauDao, double TTCCCCT_CCaoLotDatTLuu, double ThongTinCauTaoCongTron_CCaoLotMong)
        {
            double result = 0;
            TTVLDCongRanh_LoaiVatLieuDao = GetTenDanhMucById(TTVLDCongRanh_LoaiVatLieuDao).ToUpper().Trim();

            if (TTVLDCongRanh_LoaiVatLieuDao == "Đào đá".ToUpper())
            {
                result = TTVLDCongRanh_TLChieuCaoDaoDa >= ThongTinCauTaoCongTron_CCaoLotMong ? ThongTinCauTaoCongTron_CCaoLotMong : TTVLDCongRanh_TLChieuCaoDaoDa;
            }
            else if (TTVLDCongRanh_LoaiVatLieuDao == "Đào đất + Đào đá".ToUpper())
            {
                if (TTVLDCongRanh_TLTongChieuSauDao >= ThongTinCauTaoCongTron_CCaoLotMong)
                {
                    result = TTCCCCT_CCaoLotDatTLuu < ThongTinCauTaoCongTron_CCaoLotMong ? ThongTinCauTaoCongTron_CCaoLotMong - TTCCCCT_CCaoLotDatTLuu : 0;
                }
                else
                {
                    result = TTVLDCongRanh_TLChieuCaoDaoDa;
                }
            }
            else
            {
                result = 0;
            }

            result = Math.Round(result, 3);
            return Math.Round(result, 2, MidpointRounding.AwayFromZero);
        }

        public double TTCCCCT_CCaoLotDaHLuu(string TTVLDCongRanh_LoaiVatLieuDao, double TTVLDCongRanh_HLChieuCaoDaoDa, double TTVLDCongRanh_HLTongChieuSauDao, double TTCCCCT_CCaoLotDatHLuu, double ThongTinCauTaoCongTron_CCaoLotMong)
        {
            TTVLDCongRanh_LoaiVatLieuDao = GetTenDanhMucById(TTVLDCongRanh_LoaiVatLieuDao).ToUpper().Trim();

            if (TTVLDCongRanh_LoaiVatLieuDao == "ĐÀO ĐÁ")
            {
                return TTVLDCongRanh_HLChieuCaoDaoDa >= ThongTinCauTaoCongTron_CCaoLotMong ? ThongTinCauTaoCongTron_CCaoLotMong : TTVLDCongRanh_HLChieuCaoDaoDa;
            }
            else if (TTVLDCongRanh_LoaiVatLieuDao == "ĐÀO ĐẤT + ĐÀO ĐÁ")
            {
                if (TTVLDCongRanh_HLTongChieuSauDao >= ThongTinCauTaoCongTron_CCaoLotMong)
                {
                    return TTCCCCT_CCaoLotDatHLuu < ThongTinCauTaoCongTron_CCaoLotMong ? ThongTinCauTaoCongTron_CCaoLotMong - TTCCCCT_CCaoLotDatHLuu : 0;
                }
                else
                {
                    return TTVLDCongRanh_HLChieuCaoDaoDa;
                }
            }
            else
            {
                return 0;
            }
        }
        public double TTCCCCT_CCaoMongDatTLuu(string TTVLDCongRanh_LoaiVatLieuDao, double TTVLDCongRanh_TLChieuCaoDaoDat, double ThongTinCauTaoCongTron_CCaoLotMong, double ThongTinCauTaoCongTron_CCaoMong)
        {
            TTVLDCongRanh_LoaiVatLieuDao = GetTenDanhMucById(TTVLDCongRanh_LoaiVatLieuDao).ToUpper().Trim();

            if (TTVLDCongRanh_LoaiVatLieuDao == "ĐÀO ĐẤT" || TTVLDCongRanh_LoaiVatLieuDao == "ĐÀO ĐẤT + ĐÀO ĐÁ")
            {
                if (TTVLDCongRanh_TLChieuCaoDaoDat <= ThongTinCauTaoCongTron_CCaoLotMong)
                {
                    return 0;
                }
                else if (TTVLDCongRanh_TLChieuCaoDaoDat >= ThongTinCauTaoCongTron_CCaoLotMong + ThongTinCauTaoCongTron_CCaoMong)
                {
                    return ThongTinCauTaoCongTron_CCaoMong;
                }
                else
                {
                    return TTVLDCongRanh_TLChieuCaoDaoDat - ThongTinCauTaoCongTron_CCaoLotMong;
                }
            }
            else
            {
                return 0;
            }
        }
        public double TTCCCCT_CCaoMongDatHLuu(string TTVLDCongRanh_LoaiVatLieuDao, double TTVLDCongRanh_HLChieuCaoDaoDat, double ThongTinCauTaoCongTron_CCaoLotMong, double ThongTinCauTaoCongTron_CCaoMong)
        {
            TTVLDCongRanh_LoaiVatLieuDao = GetTenDanhMucById(TTVLDCongRanh_LoaiVatLieuDao).ToUpper().Trim();

            if (TTVLDCongRanh_LoaiVatLieuDao == "ĐÀO ĐẤT" || TTVLDCongRanh_LoaiVatLieuDao == "ĐÀO ĐẤT + ĐÀO ĐÁ")
            {
                if (TTVLDCongRanh_HLChieuCaoDaoDat <= ThongTinCauTaoCongTron_CCaoLotMong)
                {
                    return 0;
                }
                else if (TTVLDCongRanh_HLChieuCaoDaoDat >= ThongTinCauTaoCongTron_CCaoLotMong + ThongTinCauTaoCongTron_CCaoMong)
                {
                    return ThongTinCauTaoCongTron_CCaoMong;
                }
                else
                {
                    return TTVLDCongRanh_HLChieuCaoDaoDat - ThongTinCauTaoCongTron_CCaoLotMong;
                }
            }
            else
            {
                return 0;
            }
        }
        public double TTCCCCT_CCaoMongDaTLuu(string TTVLDCongRanh_LoaiVatLieuDao, double TTVLDCongRanh_TLChieuCaoDaoDa, double ThongTinCauTaoCongTron_CCaoLotMong, double ThongTinCauTaoCongTron_CCaoMong, double TTVLDCongRanh_TLTongChieuSauDao, double TTCCCCT_CCaoMongDatTLuu, double TTCCCCT_CCaoLotDaTLuu)
        {
            TTVLDCongRanh_LoaiVatLieuDao = GetTenDanhMucById(TTVLDCongRanh_LoaiVatLieuDao).ToUpper().Trim();

            if (TTVLDCongRanh_LoaiVatLieuDao == "ĐÀO ĐÁ")
            {
                if (TTVLDCongRanh_TLChieuCaoDaoDa <= ThongTinCauTaoCongTron_CCaoLotMong)
                {
                    return 0;
                }
                else if (TTVLDCongRanh_TLChieuCaoDaoDa >= ThongTinCauTaoCongTron_CCaoLotMong + ThongTinCauTaoCongTron_CCaoMong)
                {
                    return ThongTinCauTaoCongTron_CCaoMong;
                }
                else
                {
                    return TTVLDCongRanh_TLChieuCaoDaoDa - ThongTinCauTaoCongTron_CCaoLotMong;
                }
            }
            else if (TTVLDCongRanh_LoaiVatLieuDao == "ĐÀO ĐẤT + ĐÀO ĐÁ")
            {
                if (TTVLDCongRanh_TLTongChieuSauDao >= ThongTinCauTaoCongTron_CCaoLotMong + ThongTinCauTaoCongTron_CCaoMong)
                {
                    return TTCCCCT_CCaoMongDatTLuu < ThongTinCauTaoCongTron_CCaoMong ? ThongTinCauTaoCongTron_CCaoMong - TTCCCCT_CCaoMongDatTLuu : 0;
                }
                else
                {
                    return TTVLDCongRanh_TLChieuCaoDaoDa - TTCCCCT_CCaoLotDaTLuu;
                }
            }
            else
            {
                return 0;
            }
        }
        public double TTCCCCT_CCaoMongDaHLuu(string TTVLDCongRanh_LoaiVatLieuDao, double TTVLDCongRanh_HLChieuCaoDaoDa, double ThongTinCauTaoCongTron_CCaoLotMong, double ThongTinCauTaoCongTron_CCaoMong, double TTVLDCongRanh_HLTongChieuSauDao, double TTCCCCT_CCaoMongDatHLuu, double TTCCCCT_CCaoLotDaHLuu)
        {
            TTVLDCongRanh_LoaiVatLieuDao = GetTenDanhMucById(TTVLDCongRanh_LoaiVatLieuDao).ToUpper().Trim();

            if (TTVLDCongRanh_LoaiVatLieuDao == "ĐÀO ĐÁ")
            {
                if (TTVLDCongRanh_HLChieuCaoDaoDa <= ThongTinCauTaoCongTron_CCaoLotMong)
                {
                    return 0;
                }
                else if (TTVLDCongRanh_HLChieuCaoDaoDa >= ThongTinCauTaoCongTron_CCaoLotMong + ThongTinCauTaoCongTron_CCaoMong)
                {
                    return ThongTinCauTaoCongTron_CCaoMong;
                }
                else
                {
                    return TTVLDCongRanh_HLChieuCaoDaoDa - ThongTinCauTaoCongTron_CCaoLotMong;
                }
            }
            else if (TTVLDCongRanh_LoaiVatLieuDao == "ĐÀO ĐẤT + ĐÀO ĐÁ")
            {
                if (TTVLDCongRanh_HLTongChieuSauDao >= ThongTinCauTaoCongTron_CCaoLotMong + ThongTinCauTaoCongTron_CCaoMong)
                {
                    return TTCCCCT_CCaoMongDatHLuu < ThongTinCauTaoCongTron_CCaoMong ? ThongTinCauTaoCongTron_CCaoMong - TTCCCCT_CCaoMongDatHLuu : 0;
                }
                else
                {
                    return TTVLDCongRanh_HLChieuCaoDaoDa - TTCCCCT_CCaoLotDaHLuu;
                }
            }
            else
            {
                return 0;
            }
        }
        public double TTCCCCT_CCaoDeDatTLuu(string TTVLDCongRanh_LoaiVatLieuDao, double TTVLDCongRanh_TLChieuCaoDaoDat, double ThongTinCauTaoCongTron_CCaoLotMong, double ThongTinCauTaoCongTron_CCaoMong, double ThongTinCauTaoCongTron_CCaoDe)
        {
            TTVLDCongRanh_LoaiVatLieuDao = GetTenDanhMucById(TTVLDCongRanh_LoaiVatLieuDao).ToUpper().Trim();

            if (TTVLDCongRanh_LoaiVatLieuDao == "ĐÀO ĐẤT" || TTVLDCongRanh_LoaiVatLieuDao == "ĐÀO ĐẤT + ĐÀO ĐÁ")
            {
                if (TTVLDCongRanh_TLChieuCaoDaoDat <= ThongTinCauTaoCongTron_CCaoLotMong + ThongTinCauTaoCongTron_CCaoMong)
                {
                    return 0;
                }
                else if (TTVLDCongRanh_TLChieuCaoDaoDat >= ThongTinCauTaoCongTron_CCaoLotMong + ThongTinCauTaoCongTron_CCaoMong + ThongTinCauTaoCongTron_CCaoDe)
                {
                    return ThongTinCauTaoCongTron_CCaoDe;
                }
                else
                {
                    return TTVLDCongRanh_TLChieuCaoDaoDat - (ThongTinCauTaoCongTron_CCaoLotMong + ThongTinCauTaoCongTron_CCaoMong);
                }
            }
            else
            {
                return 0;
            }
        }
        public double TTCCCCT_CCaoDeDatHLuu(string TTVLDCongRanh_LoaiVatLieuDao, double TTVLDCongRanh_HLChieuCaoDaoDat, double ThongTinCauTaoCongTron_CCaoLotMong, double ThongTinCauTaoCongTron_CCaoMong, double ThongTinCauTaoCongTron_CCaoDe)
        {
            TTVLDCongRanh_LoaiVatLieuDao = GetTenDanhMucById(TTVLDCongRanh_LoaiVatLieuDao).ToUpper().Trim();

            if (TTVLDCongRanh_LoaiVatLieuDao == "ĐÀO ĐẤT" || TTVLDCongRanh_LoaiVatLieuDao == "ĐÀO ĐẤT + ĐÀO ĐÁ")
            {
                if (TTVLDCongRanh_HLChieuCaoDaoDat <= ThongTinCauTaoCongTron_CCaoLotMong + ThongTinCauTaoCongTron_CCaoMong)
                {
                    return 0;
                }
                else if (TTVLDCongRanh_HLChieuCaoDaoDat >= ThongTinCauTaoCongTron_CCaoLotMong + ThongTinCauTaoCongTron_CCaoMong + ThongTinCauTaoCongTron_CCaoDe)
                {
                    return ThongTinCauTaoCongTron_CCaoDe;
                }
                else
                {
                    return TTVLDCongRanh_HLChieuCaoDaoDat - (ThongTinCauTaoCongTron_CCaoLotMong + ThongTinCauTaoCongTron_CCaoMong);
                }
            }
            else
            {
                return 0;
            }
        }
        public double TTCCCCT_CCaoDeDaTLuu(string TTVLDCongRanh_LoaiVatLieuDao, double TTVLDCongRanh_TLChieuCaoDaoDa, double ThongTinCauTaoCongTron_CCaoLotMong, double ThongTinCauTaoCongTron_CCaoMong, double ThongTinCauTaoCongTron_CCaoDe, double TTVLDCongRanh_TLTongChieuSauDao, double TTCCCCT_CCaoDeDatTLuu, double TTCCCCT_CCaoLotDaTLuu, double TTCCCCT_CCaoMongDaTLuu)
        {
            TTVLDCongRanh_LoaiVatLieuDao = GetTenDanhMucById(TTVLDCongRanh_LoaiVatLieuDao).ToUpper().Trim();

            if (TTVLDCongRanh_LoaiVatLieuDao == "ĐÀO ĐÁ")
            {
                if (TTVLDCongRanh_TLChieuCaoDaoDa <= ThongTinCauTaoCongTron_CCaoLotMong + ThongTinCauTaoCongTron_CCaoMong)
                {
                    return 0;
                }
                else if (TTVLDCongRanh_TLChieuCaoDaoDa >= ThongTinCauTaoCongTron_CCaoLotMong + ThongTinCauTaoCongTron_CCaoMong + ThongTinCauTaoCongTron_CCaoDe)
                {
                    return ThongTinCauTaoCongTron_CCaoDe;
                }
                else
                {
                    return TTVLDCongRanh_TLChieuCaoDaoDa - (ThongTinCauTaoCongTron_CCaoLotMong + ThongTinCauTaoCongTron_CCaoMong);
                }
            }
            else if (TTVLDCongRanh_LoaiVatLieuDao == "ĐÀO ĐẤT + ĐÀO ĐÁ")
            {
                if (TTVLDCongRanh_TLTongChieuSauDao >= ThongTinCauTaoCongTron_CCaoLotMong + ThongTinCauTaoCongTron_CCaoMong + ThongTinCauTaoCongTron_CCaoDe)
                {
                    return TTCCCCT_CCaoDeDatTLuu < ThongTinCauTaoCongTron_CCaoDe ? ThongTinCauTaoCongTron_CCaoDe - TTCCCCT_CCaoDeDatTLuu : 0;
                }
                else
                {
                    return TTVLDCongRanh_TLChieuCaoDaoDa - (TTCCCCT_CCaoLotDaTLuu + TTCCCCT_CCaoMongDaTLuu);
                }
            }
            else
            {
                return 0;
            }
        }
        public double TTCCCCT_CCaoDeDaHLuu(string TTVLDCongRanh_LoaiVatLieuDao, double TTVLDCongRanh_HLChieuCaoDaoDa, double ThongTinCauTaoCongTron_CCaoLotMong, double ThongTinCauTaoCongTron_CCaoMong, double ThongTinCauTaoCongTron_CCaoDe, double TTVLDCongRanh_HLTongChieuSauDao, double TTCCCCT_CCaoDeDatHLuu, double TTCCCCT_CCaoLotDaHLuu, double TTCCCCT_CCaoMongDaHLuu)
        {
            TTVLDCongRanh_LoaiVatLieuDao = GetTenDanhMucById(TTVLDCongRanh_LoaiVatLieuDao).ToUpper().Trim();

            if (TTVLDCongRanh_LoaiVatLieuDao == "ĐÀO ĐÁ")
            {
                if (TTVLDCongRanh_HLChieuCaoDaoDa <= ThongTinCauTaoCongTron_CCaoLotMong + ThongTinCauTaoCongTron_CCaoMong)
                {
                    return 0;
                }
                else if (TTVLDCongRanh_HLChieuCaoDaoDa >= ThongTinCauTaoCongTron_CCaoLotMong + ThongTinCauTaoCongTron_CCaoMong + ThongTinCauTaoCongTron_CCaoDe)
                {
                    return ThongTinCauTaoCongTron_CCaoDe;
                }
                else
                {
                    return TTVLDCongRanh_HLChieuCaoDaoDa - (ThongTinCauTaoCongTron_CCaoLotMong + ThongTinCauTaoCongTron_CCaoMong);
                }
            }
            else if (TTVLDCongRanh_LoaiVatLieuDao == "ĐÀO ĐẤT + ĐÀO ĐÁ")
            {
                if (TTVLDCongRanh_HLTongChieuSauDao >= ThongTinCauTaoCongTron_CCaoLotMong + ThongTinCauTaoCongTron_CCaoMong + ThongTinCauTaoCongTron_CCaoDe)
                {
                    return TTCCCCT_CCaoDeDatHLuu < ThongTinCauTaoCongTron_CCaoDe ? ThongTinCauTaoCongTron_CCaoDe - TTCCCCT_CCaoDeDatHLuu : 0;
                }
                else
                {
                    return TTVLDCongRanh_HLChieuCaoDaoDa - (TTCCCCT_CCaoLotDaHLuu + TTCCCCT_CCaoMongDaHLuu);
                }
            }
            else
            {
                return 0;
            }
        }
        public double TTCCCCT_CCaoCongDatTLuu(string TTVLDCongRanh_LoaiVatLieuDao, double TTVLDCongRanh_TLChieuCaoDaoDat, double ThongTinCauTaoCongTron_CCaoLotMong, double ThongTinCauTaoCongTron_CCaoMong, double ThongTinCauTaoCongTron_CCaoDe, double ThongTinCauTaoCongTron_TongCCaoCong)
        {
            TTVLDCongRanh_LoaiVatLieuDao = GetTenDanhMucById(TTVLDCongRanh_LoaiVatLieuDao).ToUpper().Trim();

            if (TTVLDCongRanh_LoaiVatLieuDao == "ĐÀO ĐẤT" || TTVLDCongRanh_LoaiVatLieuDao == "ĐÀO ĐẤT + ĐÀO ĐÁ")
            {
                if (TTVLDCongRanh_TLChieuCaoDaoDat <= ThongTinCauTaoCongTron_CCaoLotMong + ThongTinCauTaoCongTron_CCaoMong + ThongTinCauTaoCongTron_CCaoDe)
                {
                    return 0;
                }
                else if (TTVLDCongRanh_TLChieuCaoDaoDat >= ThongTinCauTaoCongTron_TongCCaoCong)
                {
                    return ThongTinCauTaoCongTron_TongCCaoCong;
                }
                else
                {
                    return TTVLDCongRanh_TLChieuCaoDaoDat - (ThongTinCauTaoCongTron_CCaoLotMong + ThongTinCauTaoCongTron_CCaoMong + ThongTinCauTaoCongTron_CCaoDe);
                }
            }
            else
            {
                return 0;
            }
        }
        public double TTCCCCT_CCaoCongDatHLuu(string TTVLDCongRanh_LoaiVatLieuDao, double TTVLDCongRanh_HLChieuCaoDaoDat, double ThongTinCauTaoCongTron_CCaoLotMong, double ThongTinCauTaoCongTron_CCaoMong, double ThongTinCauTaoCongTron_CCaoDe, double ThongTinCauTaoCongTron_TongCCaoCong)
        {
            TTVLDCongRanh_LoaiVatLieuDao = GetTenDanhMucById(TTVLDCongRanh_LoaiVatLieuDao).ToUpper().Trim();

            if (TTVLDCongRanh_LoaiVatLieuDao == "ĐÀO ĐẤT" || TTVLDCongRanh_LoaiVatLieuDao == "ĐÀO ĐẤT + ĐÀO ĐÁ")
            {
                if (TTVLDCongRanh_HLChieuCaoDaoDat <= ThongTinCauTaoCongTron_CCaoLotMong + ThongTinCauTaoCongTron_CCaoMong + ThongTinCauTaoCongTron_CCaoDe)
                {
                    return 0;
                }
                else if (TTVLDCongRanh_HLChieuCaoDaoDat >= ThongTinCauTaoCongTron_TongCCaoCong)
                {
                    return ThongTinCauTaoCongTron_TongCCaoCong;
                }
                else
                {
                    return Math.Round(TTVLDCongRanh_HLChieuCaoDaoDat - (ThongTinCauTaoCongTron_CCaoLotMong + ThongTinCauTaoCongTron_CCaoMong + ThongTinCauTaoCongTron_CCaoDe), 2);
                }
            }
            else
            {
                return 0;
            }
        }

        public double TTCCCCT_CCaoCongDaTLuu(string TTVLDCongRanh_LoaiVatLieuDao, double TTVLDCongRanh_TLChieuCaoDaoDa, double TTVLDCongRanh_TLTongChieuSauDao, double TTCCCCT_CCaoCongDatTLuu, double ThongTinCauTaoCongTron_CCaoCauKien, double ThongTinCauTaoCongTron_TongCCaoCong, double ThongTinCauTaoCongTron_CCaoLotMong, double ThongTinCauTaoCongTron_CCaoMong, double ThongTinCauTaoCongTron_CCaoDe, double TTCCCCT_CCaoLotDaTLuu, double TTCCCCT_CCaoMongDaTLuu, double TTCCCCT_CCaoDeDaTLuu)
        {
            TTVLDCongRanh_LoaiVatLieuDao = GetTenDanhMucById(TTVLDCongRanh_LoaiVatLieuDao).ToUpper().Trim();

            if (TTVLDCongRanh_LoaiVatLieuDao == "ĐÀO ĐÁ")
            {
                if (TTVLDCongRanh_TLChieuCaoDaoDa <= ThongTinCauTaoCongTron_CCaoLotMong + ThongTinCauTaoCongTron_CCaoMong + ThongTinCauTaoCongTron_CCaoDe)
                {
                    return 0;
                }
                else if (TTVLDCongRanh_TLChieuCaoDaoDa >= ThongTinCauTaoCongTron_TongCCaoCong)
                {
                    return ThongTinCauTaoCongTron_TongCCaoCong;
                }
                else
                {
                    return TTVLDCongRanh_TLChieuCaoDaoDa - (ThongTinCauTaoCongTron_CCaoLotMong + ThongTinCauTaoCongTron_CCaoMong + ThongTinCauTaoCongTron_CCaoDe);
                }
            }
            else if (TTVLDCongRanh_LoaiVatLieuDao == "ĐÀO ĐẤT + ĐÀO ĐÁ")
            {
                if (TTVLDCongRanh_TLTongChieuSauDao >= ThongTinCauTaoCongTron_TongCCaoCong)
                {
                    return TTCCCCT_CCaoCongDatTLuu < ThongTinCauTaoCongTron_CCaoCauKien ? ThongTinCauTaoCongTron_CCaoCauKien - TTCCCCT_CCaoCongDatTLuu : 0;
                }
                else
                {
                    return TTVLDCongRanh_TLChieuCaoDaoDa - (TTCCCCT_CCaoLotDaTLuu + TTCCCCT_CCaoMongDaTLuu + TTCCCCT_CCaoDeDaTLuu);
         }
            }
            else
            {
                return 0;
            }
        }
        public double TTCCCCT_CCaoCongDaHLuu(string TTVLDCongRanh_LoaiVatLieuDao, double TTVLDCongRanh_HLChieuCaoDaoDa, double TTVLDCongRanh_HLTongChieuSauDao, double TTCCCCT_CCaoCongDatHLuu, double ThongTinCauTaoCongTron_CCaoCauKien, double ThongTinCauTaoCongTron_TongCCaoCong, double ThongTinCauTaoCongTron_CCaoLotMong, double ThongTinCauTaoCongTron_CCaoMong, double ThongTinCauTaoCongTron_CCaoDe, double TTCCCCT_CCaoLotDaHLuu, double TTCCCCT_CCaoMongDaHLuu, double TTCCCCT_CCaoDeDaHLuu)
        {
            TTVLDCongRanh_LoaiVatLieuDao = GetTenDanhMucById(TTVLDCongRanh_LoaiVatLieuDao).ToUpper().Trim();

            if (TTVLDCongRanh_LoaiVatLieuDao == "ĐÀO ĐÁ")
            {
                if (TTVLDCongRanh_HLChieuCaoDaoDa <= ThongTinCauTaoCongTron_CCaoLotMong + ThongTinCauTaoCongTron_CCaoMong + ThongTinCauTaoCongTron_CCaoDe)
                {
                    return 0;
                }
                else if (TTVLDCongRanh_HLChieuCaoDaoDa >= ThongTinCauTaoCongTron_TongCCaoCong)
                {
                    return ThongTinCauTaoCongTron_TongCCaoCong;
                }
                else
                {
                    return TTVLDCongRanh_HLChieuCaoDaoDa - (ThongTinCauTaoCongTron_CCaoLotMong + ThongTinCauTaoCongTron_CCaoMong + ThongTinCauTaoCongTron_CCaoDe);
         }
            }
            else if (TTVLDCongRanh_LoaiVatLieuDao == "ĐÀO ĐẤT + ĐÀO ĐÁ")
            {
                if (TTVLDCongRanh_HLTongChieuSauDao >= ThongTinCauTaoCongTron_TongCCaoCong)
                {
                    return TTCCCCT_CCaoCongDatHLuu < ThongTinCauTaoCongTron_CCaoCauKien ? ThongTinCauTaoCongTron_CCaoCauKien - TTCCCCT_CCaoCongDatHLuu : 0;
                }
                else
                {
                    return TTVLDCongRanh_HLChieuCaoDaoDa - (TTCCCCT_CCaoLotDaHLuu + TTCCCCT_CCaoMongDaHLuu + TTCCCCT_CCaoDeDaHLuu);
         }
            }
            else
            {
                return 0;
            }
        }

        public double TTCCCCCHR_CCaoLotDatTLuu(string TTVLDCongRanh_LoaiVatLieuDao, double TTVLDCongRanh_TLChieuCaoDaoDat, double TTKTHHCongHopRanh_CCaoLotMong)
        {
            TTVLDCongRanh_LoaiVatLieuDao = GetTenDanhMucById(TTVLDCongRanh_LoaiVatLieuDao).ToUpper().Trim();

            if (TTVLDCongRanh_LoaiVatLieuDao == "ĐÀO ĐẤT" || TTVLDCongRanh_LoaiVatLieuDao == "ĐÀO ĐẤT + ĐÀO ĐÁ")
            {
                return TTVLDCongRanh_TLChieuCaoDaoDat >= TTKTHHCongHopRanh_CCaoLotMong ? TTKTHHCongHopRanh_CCaoLotMong : TTVLDCongRanh_TLChieuCaoDaoDat;
            }
            else
            {
                return 0;
            }
        }
        public double TTCCCCCHR_CCaoLotDatHLuu(string TTVLDCongRanh_LoaiVatLieuDao, double TTVLDCongRanh_HLChieuCaoDaoDat, double TTKTHHCongHopRanh_CCaoLotMong)
        {
            TTVLDCongRanh_LoaiVatLieuDao = GetTenDanhMucById(TTVLDCongRanh_LoaiVatLieuDao).ToUpper().Trim();

            if (TTVLDCongRanh_LoaiVatLieuDao == "ĐÀO ĐẤT" || TTVLDCongRanh_LoaiVatLieuDao == "ĐÀO ĐẤT + ĐÀO ĐÁ")
            {
                return TTVLDCongRanh_HLChieuCaoDaoDat >= TTKTHHCongHopRanh_CCaoLotMong ? TTKTHHCongHopRanh_CCaoLotMong : TTVLDCongRanh_HLChieuCaoDaoDat;
            }
            else
            {
                return 0;
            }
        }
        public double TTCCCCCHR_CCaoLotDaTLuu(string TTVLDCongRanh_LoaiVatLieuDao, double TTVLDCongRanh_TLChieuCaoDaoDa, double TTVLDCongRanh_TLTongChieuSauDao, double TTKTHHCongHopRanh_CCaoLotMong, double TTCCCCCHR_CCaoLotDatTLuu)
        {
            TTVLDCongRanh_LoaiVatLieuDao = GetTenDanhMucById(TTVLDCongRanh_LoaiVatLieuDao).ToUpper().Trim();

            if (TTVLDCongRanh_LoaiVatLieuDao == "ĐÀO ĐÁ")
            {
                return TTVLDCongRanh_TLChieuCaoDaoDa >= TTKTHHCongHopRanh_CCaoLotMong ? TTKTHHCongHopRanh_CCaoLotMong : TTVLDCongRanh_TLChieuCaoDaoDa;
            }
            else if (TTVLDCongRanh_LoaiVatLieuDao == "ĐÀO ĐẤT + ĐÀO ĐÁ")
            {
                if (TTVLDCongRanh_TLTongChieuSauDao >= TTKTHHCongHopRanh_CCaoLotMong)
                {
                    return TTCCCCCHR_CCaoLotDatTLuu < TTKTHHCongHopRanh_CCaoLotMong ? TTKTHHCongHopRanh_CCaoLotMong - TTCCCCCHR_CCaoLotDatTLuu : 0;
                }
                else
                {
                    return TTVLDCongRanh_TLChieuCaoDaoDa;
                }
            }
            else
            {
                return 0;
            }
        }
        public double TTCCCCCHR_CCaoLotDaHLuu(string TTVLDCongRanh_LoaiVatLieuDao, double TTVLDCongRanh_HLChieuCaoDaoDa, double TTVLDCongRanh_HLTongChieuSauDao, double TTKTHHCongHopRanh_CCaoLotMong, double TTCCCCCHR_CCaoLotDatHLuu)
        {
            TTVLDCongRanh_LoaiVatLieuDao = GetTenDanhMucById(TTVLDCongRanh_LoaiVatLieuDao).ToUpper().Trim();

            if (TTVLDCongRanh_LoaiVatLieuDao == "ĐÀO ĐÁ")
            {
                return TTVLDCongRanh_HLChieuCaoDaoDa >= TTKTHHCongHopRanh_CCaoLotMong ? TTKTHHCongHopRanh_CCaoLotMong : TTVLDCongRanh_HLChieuCaoDaoDa;
            }
            else if (TTVLDCongRanh_LoaiVatLieuDao == "ĐÀO ĐẤT + ĐÀO ĐÁ")
            {
                if (TTVLDCongRanh_HLTongChieuSauDao >= TTKTHHCongHopRanh_CCaoLotMong)
                {
                    return TTCCCCCHR_CCaoLotDatHLuu < TTKTHHCongHopRanh_CCaoLotMong ? TTKTHHCongHopRanh_CCaoLotMong - TTCCCCCHR_CCaoLotDatHLuu : 0;
                }
                else
                {
                    return TTVLDCongRanh_HLChieuCaoDaoDa;
                }
            }
            else
            {
                return 0;
            }
        }
        public double TTCCCCCHR_CCaoMongDatTLuu(string TTVLDCongRanh_LoaiVatLieuDao, double TTVLDCongRanh_TLChieuCaoDaoDat, double TTKTHHCongHopRanh_CCaoLotMong, double TTKTHHCongHopRanh_CCaoMong)
        {
            TTVLDCongRanh_LoaiVatLieuDao = GetTenDanhMucById(TTVLDCongRanh_LoaiVatLieuDao).ToUpper().Trim();

            if (TTVLDCongRanh_LoaiVatLieuDao == "ĐÀO ĐẤT" || TTVLDCongRanh_LoaiVatLieuDao == "ĐÀO ĐẤT + ĐÀO ĐÁ")
            {
                if (TTVLDCongRanh_TLChieuCaoDaoDat <= TTKTHHCongHopRanh_CCaoLotMong)
                {
                    return 0;
                }
                else if (TTVLDCongRanh_TLChieuCaoDaoDat >= TTKTHHCongHopRanh_CCaoLotMong + TTKTHHCongHopRanh_CCaoMong)
                {
                    return TTKTHHCongHopRanh_CCaoMong;
                }
                else
                {
                    return TTVLDCongRanh_TLChieuCaoDaoDat - TTKTHHCongHopRanh_CCaoLotMong;
                }
            }
            else
            {
                return 0;
            }
        }
        public double TTCCCCCHR_CCaoMongDatHLuu(string TTVLDCongRanh_LoaiVatLieuDao, double TTVLDCongRanh_HLChieuCaoDaoDat, double TTKTHHCongHopRanh_CCaoLotMong, double TTKTHHCongHopRanh_CCaoMong)
        {
            TTVLDCongRanh_LoaiVatLieuDao = GetTenDanhMucById(TTVLDCongRanh_LoaiVatLieuDao).ToUpper().Trim();

            if (TTVLDCongRanh_LoaiVatLieuDao == "ĐÀO ĐẤT" || TTVLDCongRanh_LoaiVatLieuDao == "ĐÀO ĐẤT + ĐÀO ĐÁ")
            {
                if (TTVLDCongRanh_HLChieuCaoDaoDat <= TTKTHHCongHopRanh_CCaoLotMong)
                {
                    return 0;
                }
                else if (TTVLDCongRanh_HLChieuCaoDaoDat >= TTKTHHCongHopRanh_CCaoLotMong + TTKTHHCongHopRanh_CCaoMong)
                {
                    return TTKTHHCongHopRanh_CCaoMong;
                }
                else
                {
                    return TTVLDCongRanh_HLChieuCaoDaoDat - TTKTHHCongHopRanh_CCaoLotMong;
                }
            }
            else
            {
                return 0;
            }
        }
        public double TTCCCCCHR_CCaoMongDaTLuu(string TTVLDCongRanh_LoaiVatLieuDao, double TTVLDCongRanh_TLChieuCaoDaoDa, double TTKTHHCongHopRanh_CCaoLotMong, double TTKTHHCongHopRanh_CCaoMong, double TTVLDCongRanh_TLTongChieuSauDao, double TTCCCCCHR_CCaoMongDatTLuu, double TTCCCCCHR_CCaoLotDaTLuu)
        {
            TTVLDCongRanh_LoaiVatLieuDao = GetTenDanhMucById(TTVLDCongRanh_LoaiVatLieuDao).ToUpper().Trim();

            if (TTVLDCongRanh_LoaiVatLieuDao == "ĐÀO ĐÁ")
            {
                if (TTVLDCongRanh_TLChieuCaoDaoDa <= TTKTHHCongHopRanh_CCaoLotMong)
                {
                    return 0;
                }
                else if (TTVLDCongRanh_TLChieuCaoDaoDa >= TTKTHHCongHopRanh_CCaoLotMong + TTKTHHCongHopRanh_CCaoMong)
                {
                    return TTKTHHCongHopRanh_CCaoMong;
                }
                else
                {
                    return TTVLDCongRanh_TLChieuCaoDaoDa - TTKTHHCongHopRanh_CCaoLotMong;
                }
            }
            else if (TTVLDCongRanh_LoaiVatLieuDao == "ĐÀO ĐẤT + ĐÀO ĐÁ")
            {
                if (TTVLDCongRanh_TLTongChieuSauDao >= TTKTHHCongHopRanh_CCaoLotMong + TTKTHHCongHopRanh_CCaoMong)
                {
                    return TTCCCCCHR_CCaoMongDatTLuu < TTKTHHCongHopRanh_CCaoMong ? TTKTHHCongHopRanh_CCaoMong - TTCCCCCHR_CCaoMongDatTLuu : 0;
                }
                else
                {
                    return TTVLDCongRanh_TLChieuCaoDaoDa - TTCCCCCHR_CCaoLotDaTLuu;
                }
            }
            else
            {
                return 0;
            }
        }
        public double TTCCCCCHR_CCaoMongDaHLuu(string TTVLDCongRanh_LoaiVatLieuDao, double TTVLDCongRanh_HLChieuCaoDaoDa, double TTKTHHCongHopRanh_CCaoLotMong, double TTKTHHCongHopRanh_CCaoMong, double TTVLDCongRanh_HLTongChieuSauDao, double TTCCCCCHR_CCaoMongDatHLuu, double TTCCCCCHR_CCaoLotDaHLuu)
        {
            TTVLDCongRanh_LoaiVatLieuDao = GetTenDanhMucById(TTVLDCongRanh_LoaiVatLieuDao).ToUpper().Trim();

            if (TTVLDCongRanh_LoaiVatLieuDao == "ĐÀO ĐÁ")
            {
                if (TTVLDCongRanh_HLChieuCaoDaoDa <= TTKTHHCongHopRanh_CCaoLotMong)
                {
                    return 0;
                }
                else if (TTVLDCongRanh_HLChieuCaoDaoDa >= TTKTHHCongHopRanh_CCaoLotMong + TTKTHHCongHopRanh_CCaoMong)
                {
                    return TTKTHHCongHopRanh_CCaoMong;
                }
                else
                {
                    return TTVLDCongRanh_HLChieuCaoDaoDa - TTKTHHCongHopRanh_CCaoLotMong;
                }
            }
            else if (TTVLDCongRanh_LoaiVatLieuDao == "ĐÀO ĐẤT + ĐÀO ĐÁ")
            {
                if (TTVLDCongRanh_HLTongChieuSauDao >= TTKTHHCongHopRanh_CCaoLotMong + TTKTHHCongHopRanh_CCaoMong)
                {
                    return TTCCCCCHR_CCaoMongDatHLuu < TTKTHHCongHopRanh_CCaoMong ? TTKTHHCongHopRanh_CCaoMong - TTCCCCCHR_CCaoMongDatHLuu : 0;
                }
                else
                {
                    return TTVLDCongRanh_HLChieuCaoDaoDa - TTCCCCCHR_CCaoLotDaHLuu;
                }
            }
            else
            {
                return 0;
            }
        }
        public double TTCCCCCHR_CCaoTuongDatTLuu(string TTVLDCongRanh_LoaiVatLieuDao, double TTVLDCongRanh_TLChieuCaoDaoDat, double TTKTHHCongHopRanh_CCaoLotMong, double TTKTHHCongHopRanh_CCaoMong, double TTKTHHCongHopRanh_TongChieuCao)
        {
            TTVLDCongRanh_LoaiVatLieuDao = GetTenDanhMucById(TTVLDCongRanh_LoaiVatLieuDao).ToUpper().Trim();

            if (TTVLDCongRanh_LoaiVatLieuDao == "ĐÀO ĐẤT" || TTVLDCongRanh_LoaiVatLieuDao == "ĐÀO ĐẤT + ĐÀO ĐÁ")
            {
                double giaTriToiDa = TTKTHHCongHopRanh_CCaoLotMong + TTKTHHCongHopRanh_CCaoMong;

                if (TTVLDCongRanh_TLChieuCaoDaoDat <= giaTriToiDa)
                {
                    return 0;
                }
                else if (TTVLDCongRanh_TLChieuCaoDaoDat >= TTKTHHCongHopRanh_TongChieuCao - giaTriToiDa)
                {
                    return TTKTHHCongHopRanh_TongChieuCao - giaTriToiDa;
                }
                else
                {
                    return TTVLDCongRanh_TLChieuCaoDaoDat - giaTriToiDa;
                }
            }
            else
            {
                return 0;
            }
        }
        public double TTCCCCCHR_CCaoTuongDatHLuu(string TTVLDCongRanh_LoaiVatLieuDao, double TTVLDCongRanh_HLChieuCaoDaoDat, double TTKTHHCongHopRanh_CCaoLotMong, double TTKTHHCongHopRanh_CCaoMong, double TTKTHHCongHopRanh_TongChieuCao)
        {
            TTVLDCongRanh_LoaiVatLieuDao = GetTenDanhMucById(TTVLDCongRanh_LoaiVatLieuDao).ToUpper().Trim();

            if (TTVLDCongRanh_LoaiVatLieuDao == "ĐÀO ĐẤT" || TTVLDCongRanh_LoaiVatLieuDao == "ĐÀO ĐẤT + ĐÀO ĐÁ")
            {
                double giaTriToiDa = TTKTHHCongHopRanh_CCaoLotMong + TTKTHHCongHopRanh_CCaoMong;

                if (TTVLDCongRanh_HLChieuCaoDaoDat <= giaTriToiDa)
                {
                    return 0;
                }
                else if (TTVLDCongRanh_HLChieuCaoDaoDat >= TTKTHHCongHopRanh_TongChieuCao - giaTriToiDa)
                {
                    return TTKTHHCongHopRanh_TongChieuCao - giaTriToiDa;
                }
                else
                {
                    return TTVLDCongRanh_HLChieuCaoDaoDat - giaTriToiDa;
                }
            }
            else
            {
                return 0;
            }
        }
        public double TTCCCCCHR_CCaoTuongDaTLuu(string TTVLDCongRanh_LoaiVatLieuDao, double TTVLDCongRanh_TLChieuCaoDaoDa, double TTKTHHCongHopRanh_CCaoLotMong, double TTKTHHCongHopRanh_CCaoMong, double TTKTHHCongHopRanh_TongChieuCao, double TTVLDCongRanh_TLTongChieuSauDao, double TTCCCCCHR_CCaoTuongDatTLuu, double TTCCCCCHR_CCaoLotDaTLuu, double TTCCCCCHR_CCaoMongDaTLuu)
        {
            TTVLDCongRanh_LoaiVatLieuDao = GetTenDanhMucById(TTVLDCongRanh_LoaiVatLieuDao).ToUpper().Trim();

            if (TTVLDCongRanh_LoaiVatLieuDao == "ĐÀO ĐÁ")
            {
                double giaTriToiDa = TTKTHHCongHopRanh_CCaoLotMong + TTKTHHCongHopRanh_CCaoMong;

                if (TTVLDCongRanh_TLChieuCaoDaoDa <= giaTriToiDa)
                {
                    return 0;
                }
                else if (TTVLDCongRanh_TLChieuCaoDaoDa >= TTKTHHCongHopRanh_TongChieuCao)
                {
                    return TTKTHHCongHopRanh_TongChieuCao - giaTriToiDa;
                }
                else
                {
                    return TTVLDCongRanh_TLChieuCaoDaoDa - giaTriToiDa;
                }
            }
            else if (TTVLDCongRanh_LoaiVatLieuDao == "ĐÀO ĐẤT + ĐÀO ĐÁ")
            {
                if (TTVLDCongRanh_TLTongChieuSauDao >= TTKTHHCongHopRanh_TongChieuCao)
                {
                    double giaTriToiDa = TTKTHHCongHopRanh_TongChieuCao - (TTKTHHCongHopRanh_CCaoLotMong + TTKTHHCongHopRanh_CCaoMong);
             if (TTCCCCCHR_CCaoTuongDatTLuu < giaTriToiDa)
                    {
                        return giaTriToiDa - TTCCCCCHR_CCaoTuongDatTLuu;
                    }
                    else
                    {
                        return 0;
                    }
                }
                else
                {
                    return TTVLDCongRanh_TLChieuCaoDaoDa - (TTCCCCCHR_CCaoLotDaTLuu + TTCCCCCHR_CCaoMongDaTLuu);
         }
            }
            else
            {
                return 0;
            }
        }
        public double TTCCCCCHR_CCaoTuongDaHLuu(string TTVLDCongRanh_LoaiVatLieuDao, double TTVLDCongRanh_HLChieuCaoDaoDa, double TTKTHHCongHopRanh_CCaoLotMong, double TTKTHHCongHopRanh_CCaoMong, double TTKTHHCongHopRanh_TongChieuCao, double TTVLDCongRanh_HLTongChieuSauDao, double TTCCCCCHR_CCaoTuongDatHLuu, double TTCCCCCHR_CCaoLotDaHLuu, double TTCCCCCHR_CCaoMongDaHLuu)
        {
            TTVLDCongRanh_LoaiVatLieuDao = GetTenDanhMucById(TTVLDCongRanh_LoaiVatLieuDao).ToUpper().Trim();

            if (TTVLDCongRanh_LoaiVatLieuDao == "ĐÀO ĐÁ")
            {
                double giaTriToiDa = TTKTHHCongHopRanh_CCaoLotMong + TTKTHHCongHopRanh_CCaoMong;

                if (TTVLDCongRanh_HLChieuCaoDaoDa <= giaTriToiDa)
                {
                    return 0;
                }
                else if (TTVLDCongRanh_HLChieuCaoDaoDa >= TTKTHHCongHopRanh_TongChieuCao)
                {
                    return TTKTHHCongHopRanh_TongChieuCao - giaTriToiDa;
                }
                else
                {
                    return TTVLDCongRanh_HLChieuCaoDaoDa - giaTriToiDa;
                }
            }
            else if (TTVLDCongRanh_LoaiVatLieuDao == "ĐÀO ĐẤT + ĐÀO ĐÁ")
            {
                if (TTVLDCongRanh_HLTongChieuSauDao >= TTKTHHCongHopRanh_TongChieuCao)
                {
                    double giaTriToiDa = TTKTHHCongHopRanh_TongChieuCao - (TTKTHHCongHopRanh_CCaoLotMong + TTKTHHCongHopRanh_CCaoMong);
             if (TTCCCCCHR_CCaoTuongDatHLuu < giaTriToiDa)
                    {
                        return giaTriToiDa - TTCCCCCHR_CCaoTuongDatHLuu;
                    }
                    else
                    {
                        return 0;
                    }
                }
                else
                {
                    return TTVLDCongRanh_HLChieuCaoDaoDa - (TTCCCCCHR_CCaoLotDaHLuu + TTCCCCCHR_CCaoMongDaHLuu);
         }
            }
            else
            {
                return 0;
            }
        }
        public double TTCCCCON_CCaoDemCatDatTLuu(string TTVLDCongRanh_LoaiVatLieuDao, double TTVLDCongRanh_TLChieuCaoDaoDat, double ThongTinKichThuocHinhHocOngNhua_CCaoDemCat)
        {
            TTVLDCongRanh_LoaiVatLieuDao = GetTenDanhMucById(TTVLDCongRanh_LoaiVatLieuDao).ToUpper().Trim();

            if (TTVLDCongRanh_LoaiVatLieuDao == "ĐÀO ĐẤT" || TTVLDCongRanh_LoaiVatLieuDao == "ĐÀO ĐẤT + ĐÀO ĐÁ")
            {
                return TTVLDCongRanh_TLChieuCaoDaoDat >= ThongTinKichThuocHinhHocOngNhua_CCaoDemCat ? ThongTinKichThuocHinhHocOngNhua_CCaoDemCat : TTVLDCongRanh_TLChieuCaoDaoDat;
            }
            else
            {
                return 0;
            }
        }
        public double TTCCCCON_CCaoDemCatDatHLuu(string TTVLDCongRanh_LoaiVatLieuDao, double TTVLDCongRanh_HLChieuCaoDaoDat, double ThongTinKichThuocHinhHocOngNhua_CCaoDemCat)
        {
            TTVLDCongRanh_LoaiVatLieuDao = GetTenDanhMucById(TTVLDCongRanh_LoaiVatLieuDao).ToUpper().Trim();

            if (TTVLDCongRanh_LoaiVatLieuDao == "ĐÀO ĐẤT" || TTVLDCongRanh_LoaiVatLieuDao == "ĐÀO ĐẤT + ĐÀO ĐÁ")
            {
                return TTVLDCongRanh_HLChieuCaoDaoDat >= ThongTinKichThuocHinhHocOngNhua_CCaoDemCat ? ThongTinKichThuocHinhHocOngNhua_CCaoDemCat : TTVLDCongRanh_HLChieuCaoDaoDat;
            }
            else
            {
                return 0;
            }
        }
        public double TTCCCCON_CCaoDemCatDaTLuu(string TTVLDCongRanh_LoaiVatLieuDao, double TTVLDCongRanh_TLChieuCaoDaoDa, double TTVLDCongRanh_TLTongChieuSauDao, double ThongTinKichThuocHinhHocOngNhua_CCaoDemCat, double TTCCCCON_CCaoDemCatDatTLuu)
        {
            TTVLDCongRanh_LoaiVatLieuDao = GetTenDanhMucById(TTVLDCongRanh_LoaiVatLieuDao).ToUpper().Trim();

            if (TTVLDCongRanh_LoaiVatLieuDao == "ĐÀO ĐÁ")
            {
                return TTVLDCongRanh_TLChieuCaoDaoDa >= ThongTinKichThuocHinhHocOngNhua_CCaoDemCat ? ThongTinKichThuocHinhHocOngNhua_CCaoDemCat : TTVLDCongRanh_TLChieuCaoDaoDa;
            }
            else if (TTVLDCongRanh_LoaiVatLieuDao == "ĐÀO ĐẤT + ĐÀO ĐÁ")
            {
                if (TTVLDCongRanh_TLTongChieuSauDao >= ThongTinKichThuocHinhHocOngNhua_CCaoDemCat)
                {
                    return TTCCCCON_CCaoDemCatDatTLuu < ThongTinKichThuocHinhHocOngNhua_CCaoDemCat ? ThongTinKichThuocHinhHocOngNhua_CCaoDemCat - TTCCCCON_CCaoDemCatDatTLuu : 0;
                }
                else
                {
                    return TTVLDCongRanh_TLChieuCaoDaoDa;
                }
            }
            else
            {
                return 0;
            }
        }
        public double TTCCCCON_CCaoDemCatDaHLuu(string TTVLDCongRanh_LoaiVatLieuDao, double TTVLDCongRanh_HLChieuCaoDaoDa, double TTVLDCongRanh_HLTongChieuSauDao, double ThongTinKichThuocHinhHocOngNhua_CCaoDemCat, double TTCCCCON_CCaoDemCatDatHLuu)
        {
            TTVLDCongRanh_LoaiVatLieuDao = GetTenDanhMucById(TTVLDCongRanh_LoaiVatLieuDao).ToUpper().Trim();

            if (TTVLDCongRanh_LoaiVatLieuDao == "ĐÀO ĐÁ")
            {
                return TTVLDCongRanh_HLChieuCaoDaoDa >= ThongTinKichThuocHinhHocOngNhua_CCaoDemCat ? ThongTinKichThuocHinhHocOngNhua_CCaoDemCat : TTVLDCongRanh_HLChieuCaoDaoDa;
            }
            else if (TTVLDCongRanh_LoaiVatLieuDao == "ĐÀO ĐẤT + ĐÀO ĐÁ")
            {
                if (TTVLDCongRanh_HLTongChieuSauDao >= ThongTinKichThuocHinhHocOngNhua_CCaoDemCat)
                {
                    return TTCCCCON_CCaoDemCatDatHLuu < ThongTinKichThuocHinhHocOngNhua_CCaoDemCat ? ThongTinKichThuocHinhHocOngNhua_CCaoDemCat - TTCCCCON_CCaoDemCatDatHLuu : 0;
                }
                else
                {
                    return TTVLDCongRanh_HLChieuCaoDaoDa;
                }
            }
            else
            {
                return 0;
            }
        }
        public double TTCCCCON_CCaoOngDatTLuu(string TTVLDCongRanh_LoaiVatLieuDao, double TTVLDCongRanh_TLChieuCaoDaoDat, double ThongTinKichThuocHinhHocOngNhua_CCaoDemCat, double ThongTinKichThuocHinhHocOngNhua_TongCCaoOng)
        {
            TTVLDCongRanh_LoaiVatLieuDao = GetTenDanhMucById(TTVLDCongRanh_LoaiVatLieuDao).ToUpper().Trim();

            if (TTVLDCongRanh_LoaiVatLieuDao == "ĐÀO ĐẤT" || TTVLDCongRanh_LoaiVatLieuDao == "ĐÀO ĐẤT + ĐÀO ĐÁ")
            {
                if (TTVLDCongRanh_TLChieuCaoDaoDat <= ThongTinKichThuocHinhHocOngNhua_CCaoDemCat)
                {
                    return 0;
                }
                else if (TTVLDCongRanh_TLChieuCaoDaoDat >= ThongTinKichThuocHinhHocOngNhua_CCaoDemCat + ThongTinKichThuocHinhHocOngNhua_TongCCaoOng)
                {
                    return ThongTinKichThuocHinhHocOngNhua_TongCCaoOng;
                }
                else
                {
                    return TTVLDCongRanh_TLChieuCaoDaoDat - ThongTinKichThuocHinhHocOngNhua_CCaoDemCat;
                }
            }
            else
            {
                return 0;
            }
        }
        public double TTCCCCON_CCaoOngDatHLuu(string TTVLDCongRanh_LoaiVatLieuDao, double TTVLDCongRanh_HLChieuCaoDaoDat, double ThongTinKichThuocHinhHocOngNhua_CCaoDemCat, double ThongTinKichThuocHinhHocOngNhua_TongCCaoOng)
        {
            TTVLDCongRanh_LoaiVatLieuDao = GetTenDanhMucById(TTVLDCongRanh_LoaiVatLieuDao).ToUpper().Trim();

            if (TTVLDCongRanh_LoaiVatLieuDao == "ĐÀO ĐẤT" || TTVLDCongRanh_LoaiVatLieuDao == "ĐÀO ĐẤT + ĐÀO ĐÁ")
            {
                if (TTVLDCongRanh_HLChieuCaoDaoDat <= ThongTinKichThuocHinhHocOngNhua_CCaoDemCat)
                {
                    return 0;
                }
                else if (TTVLDCongRanh_HLChieuCaoDaoDat >= ThongTinKichThuocHinhHocOngNhua_CCaoDemCat + ThongTinKichThuocHinhHocOngNhua_TongCCaoOng)
                {
                    return ThongTinKichThuocHinhHocOngNhua_TongCCaoOng;
                }
                else
                {
                    return TTVLDCongRanh_HLChieuCaoDaoDat - ThongTinKichThuocHinhHocOngNhua_CCaoDemCat;
                }
            }
            else
            {
                return 0;
            }
        }

        public double TTCCCCON_CCaoOngDaTLuu(string TTVLDCongRanh_LoaiVatLieuDao, double TTVLDCongRanh_TLChieuCaoDaoDa, double ThongTinKichThuocHinhHocOngNhua_CCaoDemCat, double ThongTinKichThuocHinhHocOngNhua_TongCCaoOng, double TTVLDCongRanh_TLTongChieuSauDao, double TTCCCCON_CCaoOngDatTLuu, double TTCCCCON_CCaoDemCatDaTLuu)
        {
            TTVLDCongRanh_LoaiVatLieuDao = GetTenDanhMucById(TTVLDCongRanh_LoaiVatLieuDao).ToUpper().Trim();

            if (TTVLDCongRanh_LoaiVatLieuDao == "ĐÀO ĐÁ")
            {
                if (TTVLDCongRanh_TLChieuCaoDaoDa <= ThongTinKichThuocHinhHocOngNhua_CCaoDemCat)
                {
                    return 0;
                }
                else if (TTVLDCongRanh_TLChieuCaoDaoDa >= ThongTinKichThuocHinhHocOngNhua_CCaoDemCat + ThongTinKichThuocHinhHocOngNhua_TongCCaoOng)
                {
                    return ThongTinKichThuocHinhHocOngNhua_TongCCaoOng;
                }
                else
                {
                    return TTVLDCongRanh_TLChieuCaoDaoDa - ThongTinKichThuocHinhHocOngNhua_CCaoDemCat;
                }
            }
            else if (TTVLDCongRanh_LoaiVatLieuDao == "ĐÀO ĐẤT + ĐÀO ĐÁ")
            {
                if (TTVLDCongRanh_TLTongChieuSauDao >= ThongTinKichThuocHinhHocOngNhua_TongCCaoOng + ThongTinKichThuocHinhHocOngNhua_CCaoDemCat)
                {
                    if (TTCCCCON_CCaoOngDatTLuu < ThongTinKichThuocHinhHocOngNhua_TongCCaoOng)
                    {
                        return ThongTinKichThuocHinhHocOngNhua_TongCCaoOng - TTCCCCON_CCaoOngDatTLuu;
                    }
                    else
                    {
                        return 0;
                    }
                }
                else
                {
                    return TTVLDCongRanh_TLChieuCaoDaoDa - TTCCCCON_CCaoDemCatDaTLuu;
                }
            }
            else
            {
                return 0;
            }
        }
        public double TTCCCCON_CCaoOngDaHLuu(string TTVLDCongRanh_LoaiVatLieuDao, double TTVLDCongRanh_HLChieuCaoDaoDa, double ThongTinKichThuocHinhHocOngNhua_CCaoDemCat, double ThongTinKichThuocHinhHocOngNhua_TongCCaoOng, double TTVLDCongRanh_HLTongChieuSauDao, double TTCCCCON_CCaoOngDatHLuu, double TTCCCCON_CCaoDemCatDaHLuu)
        {
            TTVLDCongRanh_LoaiVatLieuDao = GetTenDanhMucById(TTVLDCongRanh_LoaiVatLieuDao).ToUpper().Trim();

            if (TTVLDCongRanh_LoaiVatLieuDao == "ĐÀO ĐÁ")
            {
                if (TTVLDCongRanh_HLChieuCaoDaoDa <= ThongTinKichThuocHinhHocOngNhua_CCaoDemCat)
                {
                    return 0;
                }
                else if (TTVLDCongRanh_HLChieuCaoDaoDa >= ThongTinKichThuocHinhHocOngNhua_CCaoDemCat + ThongTinKichThuocHinhHocOngNhua_TongCCaoOng)
                {
                    return ThongTinKichThuocHinhHocOngNhua_TongCCaoOng;
                }
                else
                {
                    return TTVLDCongRanh_HLChieuCaoDaoDa - ThongTinKichThuocHinhHocOngNhua_CCaoDemCat;
                }
            }
            else if (TTVLDCongRanh_LoaiVatLieuDao == "ĐÀO ĐẤT + ĐÀO ĐÁ")
            {
                if (TTVLDCongRanh_HLTongChieuSauDao >= ThongTinKichThuocHinhHocOngNhua_TongCCaoOng + ThongTinKichThuocHinhHocOngNhua_CCaoDemCat)
                {
                    if (TTCCCCON_CCaoOngDatHLuu < ThongTinKichThuocHinhHocOngNhua_TongCCaoOng)
                    {
                        return ThongTinKichThuocHinhHocOngNhua_TongCCaoOng - TTCCCCON_CCaoOngDatHLuu;
                    }
                    else
                    {
                        return 0;
                    }
                }
                else
                {
                    return TTVLDCongRanh_HLChieuCaoDaoDa - TTCCCCON_CCaoDemCatDaHLuu;
                }
            }
            else
            {
                return 0;
            }
        }
        public double TTCCCCON_CCaoDapCatDatTLuu(string TTVLDCongRanh_LoaiVatLieuDao, double TTVLDCongRanh_TLChieuCaoDaoDat, double ThongTinKichThuocHinhHocOngNhua_CCaoDemCat, double ThongTinKichThuocHinhHocOngNhua_TongCCaoOng, double ThongTinKichThuocHinhHocOngNhua_CCaoDapCat)
        {
            TTVLDCongRanh_LoaiVatLieuDao = GetTenDanhMucById(TTVLDCongRanh_LoaiVatLieuDao).ToUpper().Trim();

            if (TTVLDCongRanh_LoaiVatLieuDao == "ĐÀO ĐẤT" || TTVLDCongRanh_LoaiVatLieuDao == "ĐÀO ĐẤT + ĐÀO ĐÁ")
            {
                if (TTVLDCongRanh_TLChieuCaoDaoDat <= ThongTinKichThuocHinhHocOngNhua_CCaoDemCat + ThongTinKichThuocHinhHocOngNhua_TongCCaoOng)
                {
                    return 0;
                }
                else if (TTVLDCongRanh_TLChieuCaoDaoDat >= ThongTinKichThuocHinhHocOngNhua_TongCCaoOng + ThongTinKichThuocHinhHocOngNhua_CCaoDemCat + ThongTinKichThuocHinhHocOngNhua_CCaoDapCat)
                {
                    return ThongTinKichThuocHinhHocOngNhua_CCaoDapCat;
                }
                else
                {
                    return TTVLDCongRanh_TLChieuCaoDaoDat - (ThongTinKichThuocHinhHocOngNhua_TongCCaoOng + ThongTinKichThuocHinhHocOngNhua_CCaoDemCat);
         }
            }
            else
            {
                return 0;
            }
        }
        public double TTCCCCON_CCaoDapCatDatHLuu(string TTVLDCongRanh_LoaiVatLieuDao, double TTVLDCongRanh_HLChieuCaoDaoDat, double ThongTinKichThuocHinhHocOngNhua_CCaoDemCat, double ThongTinKichThuocHinhHocOngNhua_TongCCaoOng, double ThongTinKichThuocHinhHocOngNhua_CCaoDapCat)
        {
            TTVLDCongRanh_LoaiVatLieuDao = GetTenDanhMucById(TTVLDCongRanh_LoaiVatLieuDao).ToUpper().Trim();

            if (TTVLDCongRanh_LoaiVatLieuDao == "ĐÀO ĐẤT" || TTVLDCongRanh_LoaiVatLieuDao == "ĐÀO ĐẤT + ĐÀO ĐÁ")
            {
                if (TTVLDCongRanh_HLChieuCaoDaoDat <= ThongTinKichThuocHinhHocOngNhua_CCaoDemCat + ThongTinKichThuocHinhHocOngNhua_TongCCaoOng)
                {
                    return 0;
                }
                else if (TTVLDCongRanh_HLChieuCaoDaoDat >= ThongTinKichThuocHinhHocOngNhua_TongCCaoOng + ThongTinKichThuocHinhHocOngNhua_CCaoDemCat + ThongTinKichThuocHinhHocOngNhua_CCaoDapCat)
                {
                    return ThongTinKichThuocHinhHocOngNhua_CCaoDapCat;
                }
                else
                {
                    return TTVLDCongRanh_HLChieuCaoDaoDat - (ThongTinKichThuocHinhHocOngNhua_TongCCaoOng + ThongTinKichThuocHinhHocOngNhua_CCaoDemCat);
         }
            }
            else
            {
                return 0;
            }
        }
        public double TTCCCCON_CCaoDapCatDaTLuu(string TTVLDCongRanh_LoaiVatLieuDao, double TTVLDCongRanh_TLChieuCaoDaoDa, double ThongTinKichThuocHinhHocOngNhua_TongCCaoOng, double ThongTinKichThuocHinhHocOngNhua_CCaoDemCat, double ThongTinKichThuocHinhHocOngNhua_CCaoDapCat, double TTVLDCongRanh_TLTongChieuSauDao, double TTCCCCON_CCaoDapCatDatTLuu, double TTCCCCON_CCaoDemCatDaTLuu, double TTCCCCON_CCaoOngDaTLuu)
        {
            TTVLDCongRanh_LoaiVatLieuDao = GetTenDanhMucById(TTVLDCongRanh_LoaiVatLieuDao).ToUpper().Trim();

            if (TTVLDCongRanh_LoaiVatLieuDao == "ĐÀO ĐÁ")
            {
                if (TTVLDCongRanh_TLChieuCaoDaoDa <= ThongTinKichThuocHinhHocOngNhua_TongCCaoOng + ThongTinKichThuocHinhHocOngNhua_CCaoDemCat)
                {
                    return 0;
                }
                else if (TTVLDCongRanh_TLChieuCaoDaoDa >= ThongTinKichThuocHinhHocOngNhua_TongCCaoOng + ThongTinKichThuocHinhHocOngNhua_CCaoDemCat + ThongTinKichThuocHinhHocOngNhua_CCaoDapCat)
                {
                    return ThongTinKichThuocHinhHocOngNhua_CCaoDapCat;
                }
                else
                {
                    return TTVLDCongRanh_TLChieuCaoDaoDa - (ThongTinKichThuocHinhHocOngNhua_TongCCaoOng + ThongTinKichThuocHinhHocOngNhua_CCaoDemCat);
         }
            }
            else if (TTVLDCongRanh_LoaiVatLieuDao == "ĐÀO ĐẤT + ĐÀO ĐÁ")
            {
                if (TTVLDCongRanh_TLTongChieuSauDao >= ThongTinKichThuocHinhHocOngNhua_TongCCaoOng + ThongTinKichThuocHinhHocOngNhua_CCaoDemCat + ThongTinKichThuocHinhHocOngNhua_CCaoDapCat)
                {
                    return TTCCCCON_CCaoDapCatDatTLuu < ThongTinKichThuocHinhHocOngNhua_CCaoDapCat ? ThongTinKichThuocHinhHocOngNhua_CCaoDapCat - TTCCCCON_CCaoDapCatDatTLuu : 0;
                }
                else
                {
                    return TTVLDCongRanh_TLChieuCaoDaoDa - (TTCCCCON_CCaoDemCatDaTLuu + TTCCCCON_CCaoOngDaTLuu);
         }
            }
            else
            {
                return 0;
            }
        }
        public double TTCCCCON_CCaoDapCatDaHLuu(string TTVLDCongRanh_LoaiVatLieuDao, double TTVLDCongRanh_HLChieuCaoDaoDa, double ThongTinKichThuocHinhHocOngNhua_TongCCaoOng, double ThongTinKichThuocHinhHocOngNhua_CCaoDemCat, double ThongTinKichThuocHinhHocOngNhua_CCaoDapCat, double TTVLDCongRanh_HLTongChieuSauDao, double TTCCCCON_CCaoDapCatDatHLuu, double TTCCCCON_CCaoDemCatDaTLuu, double TTCCCCON_CCaoOngDaTLuu)
        {
            TTVLDCongRanh_LoaiVatLieuDao = GetTenDanhMucById(TTVLDCongRanh_LoaiVatLieuDao).ToUpper().Trim();

            if (TTVLDCongRanh_LoaiVatLieuDao == "ĐÀO ĐÁ")
            {
                if (TTVLDCongRanh_HLChieuCaoDaoDa <= ThongTinKichThuocHinhHocOngNhua_TongCCaoOng + ThongTinKichThuocHinhHocOngNhua_CCaoDemCat)
                {
                    return 0;
                }
                else if (TTVLDCongRanh_HLChieuCaoDaoDa >= ThongTinKichThuocHinhHocOngNhua_TongCCaoOng + ThongTinKichThuocHinhHocOngNhua_CCaoDemCat + ThongTinKichThuocHinhHocOngNhua_CCaoDapCat)
                {
                    return ThongTinKichThuocHinhHocOngNhua_CCaoDapCat;
                }
                else
                {
                    return TTVLDCongRanh_HLChieuCaoDaoDa - (ThongTinKichThuocHinhHocOngNhua_TongCCaoOng + ThongTinKichThuocHinhHocOngNhua_CCaoDemCat);
         }
            }
            else if (TTVLDCongRanh_LoaiVatLieuDao == "ĐÀO ĐẤT + ĐÀO ĐÁ")
            {
                if (TTVLDCongRanh_HLTongChieuSauDao >= ThongTinKichThuocHinhHocOngNhua_TongCCaoOng + ThongTinKichThuocHinhHocOngNhua_CCaoDemCat + ThongTinKichThuocHinhHocOngNhua_CCaoDapCat)
                {
                    return TTCCCCON_CCaoDapCatDatHLuu < ThongTinKichThuocHinhHocOngNhua_CCaoDapCat ? ThongTinKichThuocHinhHocOngNhua_CCaoDapCat - TTCCCCON_CCaoDapCatDatHLuu : 0;
                }
                else
                {
                    return TTVLDCongRanh_HLChieuCaoDaoDa - (TTCCCCON_CCaoDemCatDaTLuu + TTCCCCON_CCaoOngDaTLuu);
         }
            }
            else
            {
                return 0;
            }
        }
        public double TTCCRT_LotDatThuongLuu(string TTVLDCongRanh_LoaiVatLieuDao, double TTVLDCongRanh_TLChieuCaoDaoDat, double ThongTinRanhThang_CCaoLot)
        {
            TTVLDCongRanh_LoaiVatLieuDao = GetTenDanhMucById(TTVLDCongRanh_LoaiVatLieuDao).ToUpper().Trim();

            if (TTVLDCongRanh_LoaiVatLieuDao == "ĐÀO ĐẤT" || TTVLDCongRanh_LoaiVatLieuDao == "ĐÀO ĐẤT + ĐÀO ĐÁ")
            {
                return TTVLDCongRanh_TLChieuCaoDaoDat >= ThongTinRanhThang_CCaoLot ? ThongTinRanhThang_CCaoLot : TTVLDCongRanh_TLChieuCaoDaoDat;
            }
            else
            {
                return 0;
            }
        }
        public double TTCCRT_LotDatHaLuu(string TTVLDCongRanh_LoaiVatLieuDao, double TTVLDCongRanh_HLChieuCaoDaoDat, double ThongTinRanhThang_CCaoLot)
        {
            TTVLDCongRanh_LoaiVatLieuDao = GetTenDanhMucById(TTVLDCongRanh_LoaiVatLieuDao).ToUpper().Trim();

            if (TTVLDCongRanh_LoaiVatLieuDao == "ĐÀO ĐẤT" || TTVLDCongRanh_LoaiVatLieuDao == "ĐÀO ĐẤT + ĐÀO ĐÁ")
            {
                return TTVLDCongRanh_HLChieuCaoDaoDat >= ThongTinRanhThang_CCaoLot ? ThongTinRanhThang_CCaoLot : TTVLDCongRanh_HLChieuCaoDaoDat;
            }
            else
            {
                return 0;
            }
        }
        public double TTCCRT_LotDaThuongLuu(string TTVLDCongRanh_LoaiVatLieuDao, double TTVLDCongRanh_TLChieuCaoDaoDa, double TTVLDCongRanh_TLTongChieuSauDao, double ThongTinRanhThang_CCaoLot, double TTCCRT_LotDatThuongLuu)
        {
            TTVLDCongRanh_LoaiVatLieuDao = GetTenDanhMucById(TTVLDCongRanh_LoaiVatLieuDao).ToUpper().Trim();

            if (TTVLDCongRanh_LoaiVatLieuDao == "ĐÀO ĐÁ")
            {
                return TTVLDCongRanh_TLChieuCaoDaoDa >= ThongTinRanhThang_CCaoLot ? ThongTinRanhThang_CCaoLot : TTVLDCongRanh_TLChieuCaoDaoDa;
            }
            else if (TTVLDCongRanh_LoaiVatLieuDao == "ĐÀO ĐẤT + ĐÀO ĐÁ")
            {
                if (TTVLDCongRanh_TLTongChieuSauDao >= ThongTinRanhThang_CCaoLot)
                {
                    return TTCCRT_LotDatThuongLuu < ThongTinRanhThang_CCaoLot ? ThongTinRanhThang_CCaoLot - TTCCRT_LotDatThuongLuu : 0;
                }
                else
                {
                    return TTVLDCongRanh_TLChieuCaoDaoDa;
                }
            }
            else
            {
                return 0;
            }
        }
        public double TTCCRT_LotDaHaLuu(string TTVLDCongRanh_LoaiVatLieuDao, double TTVLDCongRanh_HLChieuCaoDaoDa, double TTVLDCongRanh_HLTongChieuSauDao, double ThongTinRanhThang_CCaoLot, double TTCCRT_LotDatHaLuu)
        {
            TTVLDCongRanh_LoaiVatLieuDao = GetTenDanhMucById(TTVLDCongRanh_LoaiVatLieuDao).ToUpper().Trim();

            if (TTVLDCongRanh_LoaiVatLieuDao == "ĐÀO ĐÁ")
            {
                return TTVLDCongRanh_HLChieuCaoDaoDa >= ThongTinRanhThang_CCaoLot ? ThongTinRanhThang_CCaoLot : TTVLDCongRanh_HLChieuCaoDaoDa;
            }
            else if (TTVLDCongRanh_LoaiVatLieuDao == "ĐÀO ĐẤT + ĐÀO ĐÁ")
            {
                if (TTVLDCongRanh_HLTongChieuSauDao >= ThongTinRanhThang_CCaoLot)
                {
                    return TTCCRT_LotDatHaLuu < ThongTinRanhThang_CCaoLot ? ThongTinRanhThang_CCaoLot - TTCCRT_LotDatHaLuu : 0;
                }
                else
                {
                    return TTVLDCongRanh_HLChieuCaoDaoDa;
                }
            }
            else
            {
                return 0;
            }
        }
        public double TTCCRT_MongDatThuongLuu(string TTVLDCongRanh_LoaiVatLieuDao, double TTVLDCongRanh_TLChieuCaoDaoDat, double ThongTinRanhThang_CCaoLot, double ThongTinRanhThang_CCaoMong)
        {
            TTVLDCongRanh_LoaiVatLieuDao = GetTenDanhMucById(TTVLDCongRanh_LoaiVatLieuDao).ToUpper().Trim();

            if (TTVLDCongRanh_LoaiVatLieuDao == "ĐÀO ĐẤT" || TTVLDCongRanh_LoaiVatLieuDao == "ĐÀO ĐẤT + ĐÀO ĐÁ")
            {
                if (TTVLDCongRanh_TLChieuCaoDaoDat <= ThongTinRanhThang_CCaoLot)
                {
                    return 0;
                }
                else if (TTVLDCongRanh_TLChieuCaoDaoDat >= ThongTinRanhThang_CCaoLot + ThongTinRanhThang_CCaoMong)
                {
                    return ThongTinRanhThang_CCaoMong;
                }
                else
                {
                    return TTVLDCongRanh_TLChieuCaoDaoDat - ThongTinRanhThang_CCaoLot;
                }
            }
            else
            {
                return 0;
            }
        }
        public double TTCCRT_MongDatHaLuu(string TTVLDCongRanh_LoaiVatLieuDao, double TTVLDCongRanh_HLChieuCaoDaoDat, double ThongTinRanhThang_CCaoLot, double ThongTinRanhThang_CCaoMong)
        {
            TTVLDCongRanh_LoaiVatLieuDao = GetTenDanhMucById(TTVLDCongRanh_LoaiVatLieuDao).ToUpper().Trim();

            if (TTVLDCongRanh_LoaiVatLieuDao == "ĐÀO ĐẤT" || TTVLDCongRanh_LoaiVatLieuDao == "ĐÀO ĐẤT + ĐÀO ĐÁ")
            {
                if (TTVLDCongRanh_HLChieuCaoDaoDat <= ThongTinRanhThang_CCaoLot)
                {
                    return 0;
                }
                else if (TTVLDCongRanh_HLChieuCaoDaoDat >= ThongTinRanhThang_CCaoLot + ThongTinRanhThang_CCaoMong)
                {
                    return ThongTinRanhThang_CCaoMong;
                }
                else
                {
                    return TTVLDCongRanh_HLChieuCaoDaoDat - ThongTinRanhThang_CCaoLot;
                }
            }
            else
            {
                return 0;
            }
        }
        public double TTCCRT_MongDaThuongLuu(string TTVLDCongRanh_LoaiVatLieuDao, double TTVLDCongRanh_TLChieuCaoDaoDa, double ThongTinRanhThang_CCaoLot, double ThongTinRanhThang_CCaoMong, double TTVLDCongRanh_TLTongChieuSauDao, double TTCCRT_MongDatThuongLuu, double TTCCRT_LotDaThuongLuu)
        {
            TTVLDCongRanh_LoaiVatLieuDao = GetTenDanhMucById(TTVLDCongRanh_LoaiVatLieuDao).ToUpper().Trim();

            if (TTVLDCongRanh_LoaiVatLieuDao == "ĐÀO ĐÁ")
            {
                if (TTVLDCongRanh_TLChieuCaoDaoDa <= ThongTinRanhThang_CCaoLot)
                {
                    return 0;
                }
                else if (TTVLDCongRanh_TLChieuCaoDaoDa >= ThongTinRanhThang_CCaoLot + ThongTinRanhThang_CCaoMong)
                {
                    return ThongTinRanhThang_CCaoMong;
                }
                else
                {
                    return TTVLDCongRanh_TLChieuCaoDaoDa - ThongTinRanhThang_CCaoLot;
                }
            }
            else if (TTVLDCongRanh_LoaiVatLieuDao == "ĐÀO ĐẤT + ĐÀO ĐÁ")
            {
                if (TTVLDCongRanh_TLTongChieuSauDao >= ThongTinRanhThang_CCaoLot + ThongTinRanhThang_CCaoMong)
                {
                    return TTCCRT_MongDatThuongLuu < ThongTinRanhThang_CCaoMong ? ThongTinRanhThang_CCaoMong - TTCCRT_MongDatThuongLuu : 0;
                }
                else
                {
                    return TTVLDCongRanh_TLChieuCaoDaoDa - TTCCRT_LotDaThuongLuu;
                }
            }
            else
            {
                return 0;
            }
        }
        public double TTCCRT_MongDaHaLuu(string TTVLDCongRanh_LoaiVatLieuDao, double TTVLDCongRanh_HLChieuCaoDaoDa, double ThongTinRanhThang_CCaoLot, double ThongTinRanhThang_CCaoMong, double TTVLDCongRanh_HLTongChieuSauDao, double TTCCRT_MongDatHaLuu, double TTCCRT_LotDaHaLuu)
        {
            TTVLDCongRanh_LoaiVatLieuDao = GetTenDanhMucById(TTVLDCongRanh_LoaiVatLieuDao).ToUpper().Trim();

            if (TTVLDCongRanh_LoaiVatLieuDao == "ĐÀO ĐÁ")
            {
                if (TTVLDCongRanh_HLChieuCaoDaoDa <= ThongTinRanhThang_CCaoLot)
                {
                    return 0;
                }
                else if (TTVLDCongRanh_HLChieuCaoDaoDa >= ThongTinRanhThang_CCaoLot + ThongTinRanhThang_CCaoMong)
                {
                    return ThongTinRanhThang_CCaoMong;
                }
                else
                {
                    return TTVLDCongRanh_HLChieuCaoDaoDa - ThongTinRanhThang_CCaoLot;
                }
            }
            else if (TTVLDCongRanh_LoaiVatLieuDao == "ĐÀO ĐẤT + ĐÀO ĐÁ")
            {
                if (TTVLDCongRanh_HLTongChieuSauDao >= ThongTinRanhThang_CCaoLot + ThongTinRanhThang_CCaoMong)
                {
                    return TTCCRT_MongDatHaLuu < ThongTinRanhThang_CCaoMong ? ThongTinRanhThang_CCaoMong - TTCCRT_MongDatHaLuu : 0;
                }
                else
                {
                    return TTVLDCongRanh_HLChieuCaoDaoDa - TTCCRT_LotDaHaLuu;
                }
            }
            else
            {
                return 0;
            }
        }


        public double DTDTLCRONRT_CRongDaoDatDayLon(double TTVLDCongRanh_TLChieuCaoDaoDat, double TTMDRanhOngThang_TyLeMoMai, double TTMDRanhOngThang_SoCanhMaiTrai, double TTMDRanhOngThang_SoCanhMaiPhai, double TTMDRanhOngThang_ChieuRongDayDaoNho)
        {
            return Math.Round(TTVLDCongRanh_TLChieuCaoDaoDat > 0 ? (TTVLDCongRanh_TLChieuCaoDaoDat * TTMDRanhOngThang_TyLeMoMai * (TTMDRanhOngThang_SoCanhMaiTrai + TTMDRanhOngThang_SoCanhMaiPhai)) + TTMDRanhOngThang_ChieuRongDayDaoNho : 0, 2);
        }
        public double DTDTLCRONRT_DTichDaoDat(double DTDTLCRONRT_CRongDaoDatDayLon, double TTMDRanhOngThang_ChieuRongDayDaoNho, double TTVLDCongRanh_TLChieuCaoDaoDat)
        {
            return Math.Round((DTDTLCRONRT_CRongDaoDatDayLon + TTMDRanhOngThang_ChieuRongDayDaoNho) * (TTVLDCongRanh_TLChieuCaoDaoDat / 2), 2);
        }

        public double DTDTLCRONRT_CRongDaoDaDayLon(double TTVLDCongRanh_TLChieuCaoDaoDa, double TTMDRanhOngThang_TyLeMoMai, double TTMDRanhOngThang_SoCanhMaiTrai, double TTMDRanhOngThang_SoCanhMaiPhai, double DTDTLCRONRT_CRongDaoDatDayLon, double TTMDRanhOngThang_ChieuRongDayDaoNho)
        {
            return Math.Round(TTVLDCongRanh_TLChieuCaoDaoDa > 0 ? (TTVLDCongRanh_TLChieuCaoDaoDa * TTMDRanhOngThang_TyLeMoMai * (TTMDRanhOngThang_SoCanhMaiTrai + TTMDRanhOngThang_SoCanhMaiPhai)) + (DTDTLCRONRT_CRongDaoDatDayLon > 0 ? DTDTLCRONRT_CRongDaoDatDayLon : TTMDRanhOngThang_ChieuRongDayDaoNho) : 0, 2);
        }
        public double DTDTLCRONRT_DTichDaoDa(double DTDTLCRONRT_CRongDaoDatDayLon, double DTDTLCRONRT_CRongDaoDaDayLon, double TTVLDCongRanh_TLChieuCaoDaoDa, double TTMDRanhOngThang_ChieuRongDayDaoNho)
        {
            return Math.Round(DTDTLCRONRT_CRongDaoDatDayLon > 0 ? (DTDTLCRONRT_CRongDaoDaDayLon + DTDTLCRONRT_CRongDaoDatDayLon) * (TTVLDCongRanh_TLChieuCaoDaoDa / 2) : (DTDTLCRONRT_CRongDaoDaDayLon + TTMDRanhOngThang_ChieuRongDayDaoNho) * (TTVLDCongRanh_TLChieuCaoDaoDa / 2), 2);
        }

        public double DTDHLCRONRT_CRongDaoDatDayLon(double TTVLDCongRanh_HLChieuCaoDaoDat, double TTMDRanhOngThang_TyLeMoMai, double TTMDRanhOngThang_SoCanhMaiTrai, double TTMDRanhOngThang_SoCanhMaiPhai, double TTMDRanhOngThang_ChieuRongDayDaoNho)
        {
            return Math.Round(TTVLDCongRanh_HLChieuCaoDaoDat > 0 ? (TTVLDCongRanh_HLChieuCaoDaoDat * TTMDRanhOngThang_TyLeMoMai * (TTMDRanhOngThang_SoCanhMaiTrai + TTMDRanhOngThang_SoCanhMaiPhai)) + TTMDRanhOngThang_ChieuRongDayDaoNho : 0, 2);
        }

        public double DTDHLCRONRT_DTichDaoDat(double DTDHLCRONRT_CRongDaoDatDayLon, double TTMDRanhOngThang_ChieuRongDayDaoNho, double TTVLDCongRanh_HLChieuCaoDaoDat)
        {
            return Math.Round((DTDHLCRONRT_CRongDaoDatDayLon + TTMDRanhOngThang_ChieuRongDayDaoNho) * (TTVLDCongRanh_HLChieuCaoDaoDat / 2), 2);
        }

        public double DTDHLCRONRT_CRongDaoDaDayLon(double TTVLDCongRanh_HLChieuCaoDaoDa, double TTMDRanhOngThang_TyLeMoMai, double TTMDRanhOngThang_SoCanhMaiTrai, double TTMDRanhOngThang_SoCanhMaiPhai, double DTDHLCRONRT_CRongDaoDatDayLon, double TTMDRanhOngThang_ChieuRongDayDaoNho)
        {
            return Math.Round(TTVLDCongRanh_HLChieuCaoDaoDa > 0 ? (TTVLDCongRanh_HLChieuCaoDaoDa * TTMDRanhOngThang_TyLeMoMai * (TTMDRanhOngThang_SoCanhMaiTrai + TTMDRanhOngThang_SoCanhMaiPhai)) + (DTDHLCRONRT_CRongDaoDatDayLon > 0 ? DTDHLCRONRT_CRongDaoDatDayLon : TTMDRanhOngThang_ChieuRongDayDaoNho) : 0, 2);
        }

        public double DTDHLCRONRT_DTichDaoDa(double DTDHLCRONRT_CRongDaoDatDayLon, double DTDHLCRONRT_CRongDaoDaDayLon, double TTVLDCongRanh_HLChieuCaoDaoDa, double TTMDRanhOngThang_ChieuRongDayDaoNho)
        {
            return Math.Round(DTDHLCRONRT_CRongDaoDatDayLon > 0 ? (DTDHLCRONRT_CRongDaoDaDayLon + DTDHLCRONRT_CRongDaoDatDayLon) * (TTVLDCongRanh_HLChieuCaoDaoDa / 2) : (DTDHLCRONRT_CRongDaoDaDayLon + TTMDRanhOngThang_ChieuRongDayDaoNho) * (TTVLDCongRanh_HLChieuCaoDaoDa / 2), 2);
        }

        public double DTDTB_DaoDatCRDaoDayLon(double DTDTLCRONRT_CRongDaoDatDayLon, double DTDHLCRONRT_CRongDaoDatDayLon)
        {
            var results = (DTDTLCRONRT_CRongDaoDatDayLon+ DTDHLCRONRT_CRongDaoDatDayLon)/2;
            return Math.Round(results, 2);
        }
        public double DTDTB_DaoDatDTDao(double DTDTLCRONRT_DTichDaoDat, double DTDHLCRONRT_DTichDaoDat)
        {
            var results =( DTDTLCRONRT_DTichDaoDat + DTDHLCRONRT_DTichDaoDat)/2;
            return Math.Round(results, 2);
        }
        public double DTDTB_DaoDaCRDaoDayLon(double DTDTLCRONRT_CRongDaoDaDayLon, double DTDHLCRONRT_CRongDaoDaDayLon)
        {
            var results = (DTDTLCRONRT_CRongDaoDaDayLon + DTDHLCRONRT_CRongDaoDaDayLon)/2;
            return Math.Round(results, 2);
        }
        public double DTDTB_DaoDaDTDao(double DTDTLCRONRT_DTichDaoDa, double DTDHLCRONRT_DTichDaoDa)
        {
            var results = (DTDTLCRONRT_DTichDaoDa + DTDHLCRONRT_DTichDaoDa)/2;
            return Math.Round(results, 2);
        }

        public double DTDCKRD_CKCRongDaoDayLon(double ThongTinRanhThang_CCaoLotChanKhay, double ThongTinRanhThang_CCaoMongChanKhay, double TTMDRanhOngThang_TyLeMoMai1, double TTMDRanhOngThang_SoCanhMaiTrai1, double TTMDRanhOngThang_SoCanhMaiPhai1, double TTMDRanhOngThang_ChieuRongDayDaoNho1)
        {
            return Math.Round(((ThongTinRanhThang_CCaoLotChanKhay + ThongTinRanhThang_CCaoMongChanKhay) * TTMDRanhOngThang_TyLeMoMai1 * (TTMDRanhOngThang_SoCanhMaiTrai1 + TTMDRanhOngThang_SoCanhMaiPhai1)) + TTMDRanhOngThang_ChieuRongDayDaoNho1, 2);
        }
        public double DTDCKRD_CKDTichDao(double DTDCKRD_CKCRongDaoDayLon, double TTMDRanhOngThang_ChieuRongDayDaoNho1, double ThongTinRanhThang_CCaoLotChanKhay, double ThongTinRanhThang_CCaoMongChanKhay, double ThongTinRanhThang_SoLuongMongChanKhay)
        {
            return Math.Round(((DTDCKRD_CKCRongDaoDayLon + TTMDRanhOngThang_ChieuRongDayDaoNho1) * ((ThongTinRanhThang_CCaoLotChanKhay + ThongTinRanhThang_CCaoMongChanKhay) / 2)) * ThongTinRanhThang_SoLuongMongChanKhay, 2);
        }

        public double DTDCKRD_CRongDaoDayLon(double ThongTinRanhThang_CCaoLotGiangDinh, double ThongTinRanhThang_CCaoMongGiangDinh, double TTMDRanhOngThang_TyLeMoMai1, double TTMDRanhOngThang_SoCanhMaiTrai1, double TTMDRanhOngThang_SoCanhMaiPhai1, double TTMDRanhOngThang_ChieuRongDayDaoNho1)
        {
            return Math.Round(((ThongTinRanhThang_CCaoLotGiangDinh + ThongTinRanhThang_CCaoMongGiangDinh) * TTMDRanhOngThang_TyLeMoMai1 * (TTMDRanhOngThang_SoCanhMaiTrai1 + TTMDRanhOngThang_SoCanhMaiPhai1)) + TTMDRanhOngThang_ChieuRongDayDaoNho1, 2);
        }

        public double DTDCKRD_DTichDao(double DTDCKRD_CRongDaoDayLon, double TTMDRanhOngThang_ChieuRongDayDaoNho1, double ThongTinRanhThang_CCaoLotGiangDinh, double ThongTinRanhThang_CCaoMongGiangDinh, double ThongTinRanhThang_SoLuongMongGiangDinh)
        {
            return Math.Round(((DTDCKRD_CRongDaoDayLon + TTMDRanhOngThang_ChieuRongDayDaoNho1) * ((ThongTinRanhThang_CCaoLotGiangDinh + ThongTinRanhThang_CCaoMongGiangDinh) / 2)) * ThongTinRanhThang_SoLuongMongGiangDinh, 2);
        }




        public double TKLD_KlDaoDat(double DTDTLCRONRT_DTichDaoDat, double DTDHLCRONRT_DTichDaoDat, double TTCDSLCauKienDuongTruyenDan_TongChieuDai)
        {
            return Math.Round(((DTDTLCRONRT_DTichDaoDat + DTDHLCRONRT_DTichDaoDat) / 2) * TTCDSLCauKienDuongTruyenDan_TongChieuDai, 2);
        }
        public double TKLD_KlDaoDa(double DTDTLCRONRT_DTichDaoDa, double DTDHLCRONRT_DTichDaoDa, double TTCDSLCauKienDuongTruyenDan_TongChieuDai)
        {
            return Math.Round(((DTDTLCRONRT_DTichDaoDa + DTDHLCRONRT_DTichDaoDa) / 2) * TTCDSLCauKienDuongTruyenDan_TongChieuDai, 2);
        }
        public double TKLD_TongKlDaoCongRanhOngNhuaRanhThang(double TKLD_KlDaoDat, double TKLD_KlDaoDa)
        {
            return Math.Round(TKLD_KlDaoDat + TKLD_KlDaoDa, 2);
        }
        public double TKLD_ChanKhay(double DTDCKRD_CKDTichDao, double TTCDSLCauKienDuongTruyenDan_TongChieuDai)
        {
            return Math.Round(DTDCKRD_CKDTichDao * TTCDSLCauKienDuongTruyenDan_TongChieuDai, 2);
        }
        public double TKLD_GiangDinh(double DTDCKRD_DTichDao, double TTCDSLCauKienDuongTruyenDan_TongChieuDai)
        {
            return Math.Round(DTDCKRD_DTichDao * TTCDSLCauKienDuongTruyenDan_TongChieuDai, 2);
        }
        public double TKLD_TongKlDaoDat(double TKLD_KlDaoDat, double TKLD_TongKlDaoDatChanKhayRanhDinh)
        {
            return Math.Round(TKLD_KlDaoDat + TKLD_TongKlDaoDatChanKhayRanhDinh, 2);
        }
        public double TKLD_TongKlDaoDa(double TKLD_KlDaoDa)
        {
            return Math.Round(TKLD_KlDaoDa, 2);
        }
        public double TKLD_TongKlDao(double TKLD_TongKlDaoDat, double TKLD_TongKlDaoDa)
        {
            return Math.Round(TKLD_TongKlDaoDat + TKLD_TongKlDaoDa, 2);
        }
        public double TKLD_KlCChoDatCongTron(double TTCCCCT_CCaoLotDatMongTBinh, double ThongTinCauTaoCongTron_CRongLotMong, double ThongTinCauTaoCongTron_CRongMong, double TTCCCCT_CCaoMongDatTBinh, double TTCCCCT_CCongCongDatTBinh, double TTCDSLCauKienDuongTruyenDan_TongChieuDai, double TTCCCCT_CCaoDeDatTBinh, double ThongTinDeCong_Kl01DeCong, double ThongTinDeCong_TongSoLuongDC)
        {
            double phan1 = (TTCCCCT_CCaoLotDatMongTBinh * ThongTinCauTaoCongTron_CRongLotMong) + (ThongTinCauTaoCongTron_CRongMong * TTCCCCT_CCaoMongDatTBinh) + ((3.14 * TTCCCCT_CCongCongDatTBinh * TTCCCCT_CCongCongDatTBinh) / 4);
     double phan2 = phan1 * TTCDSLCauKienDuongTruyenDan_TongChieuDai;
            double phan3 = TTCCCCT_CCaoDeDatTBinh * ThongTinDeCong_Kl01DeCong * ThongTinDeCong_TongSoLuongDC;
            return Math.Round(phan2 + phan3, 2);
        }
        public double TKLD_KlCChoDaCongTron(double TTCCCCT_CCaoLotDaMongTBinh, double ThongTinCauTaoCongTron_CRongLotMong, double ThongTinCauTaoCongTron_CRongMong, double TTCCCCT_CCaoMongDaTBinh, double TTCCCCT_CCongCongDaTBinh, double TTCDSLCauKienDuongTruyenDan_TongChieuDai, double TTCCCCT_CCaoDeDaTBinh, double ThongTinDeCong_Kl01DeCong, double ThongTinDeCong_TongSoLuongDC)
        {
            double phan1 = (TTCCCCT_CCaoLotDaMongTBinh * ThongTinCauTaoCongTron_CRongLotMong) + (ThongTinCauTaoCongTron_CRongMong * TTCCCCT_CCaoMongDaTBinh) + ((3.14 * TTCCCCT_CCongCongDaTBinh * TTCCCCT_CCongCongDaTBinh) / 4);
            double phan2 = phan1 * TTCDSLCauKienDuongTruyenDan_TongChieuDai;
            double phan3 = TTCCCCT_CCaoDeDaTBinh * ThongTinDeCong_Kl01DeCong * ThongTinDeCong_TongSoLuongDC;
            return Math.Round(phan2 + phan3, 2);
        }
        public double TKLD_TongKlChiemChoCTron(double TKLD_KlCChoDatCongTron, double TKLD_KlCChoDaCongTron)
        {
            return Math.Round(TKLD_KlCChoDatCongTron + TKLD_KlCChoDaCongTron, 2);
        }
        public double TKLD_KlCChoDatCongHop(string ThongTinDuongTruyenDan_HinhThucTruyenDan, double TTCCCCCHR_CCaoLotDatTBinh, double TTKTHHCongHopRanh_CRongLotMong, double TTKTHHCongHopRanh_CRongMong, double TTCCCCCHR_CCaoMongDatTBinh, double TTCCCCCHR_CCaoTuongDatTBinh, double TTKTHHCongHopRanh_CDayTuong01Ben, double TTKTHHCongHopRanh_SoLuongTuong, double TTKTHHCongHopRanh_CRongLongSuDung, double TTCDSLCauKienDuongTruyenDan_TongChieuDai)
        {
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            if (ThongTinDuongTruyenDan_HinhThucTruyenDan.ToUpper() == "CỐNG HỘP")
            {
                double giaTri = ((TTCCCCCHR_CCaoLotDatTBinh * TTKTHHCongHopRanh_CRongLotMong) + (TTKTHHCongHopRanh_CRongMong * TTCCCCCHR_CCaoMongDatTBinh) + (TTCCCCCHR_CCaoTuongDatTBinh * ((TTKTHHCongHopRanh_CDayTuong01Ben * TTKTHHCongHopRanh_SoLuongTuong) + TTKTHHCongHopRanh_CRongLongSuDung))) * TTCDSLCauKienDuongTruyenDan_TongChieuDai;
                return Math.Round(giaTri, 2);
            }
            else
            {
                return 0;
            }
        }
        public double TKLD_KlCChoDaCongHop(string ThongTinDuongTruyenDan_HinhThucTruyenDan, double TTCCCCCHR_CCaoLotDaTBinh, double TTKTHHCongHopRanh_CRongLotMong, double TTKTHHCongHopRanh_CRongMong, double TTCCCCCHR_CCaoMongDaTBinh, double TTCCCCCHR_CCaoTuongDaTBinh, double TTKTHHCongHopRanh_CDayTuong01Ben, double TTKTHHCongHopRanh_SoLuongTuong, double TTKTHHCongHopRanh_CRongLongSuDung, double TTCDSLCauKienDuongTruyenDan_TongChieuDai)
        {
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            if (ThongTinDuongTruyenDan_HinhThucTruyenDan.ToUpper() == "CỐNG HỘP")
            {

                double giaTri = ((TTCCCCCHR_CCaoLotDaTBinh * TTKTHHCongHopRanh_CRongLotMong) + (TTKTHHCongHopRanh_CRongMong * TTCCCCCHR_CCaoMongDaTBinh) + (TTCCCCCHR_CCaoTuongDaTBinh * ((TTKTHHCongHopRanh_CDayTuong01Ben * TTKTHHCongHopRanh_SoLuongTuong) + TTKTHHCongHopRanh_CRongLongSuDung))) * TTCDSLCauKienDuongTruyenDan_TongChieuDai;
                return Math.Round(giaTri, 2);
            }
            else
            {
                // Trả về 0 nếu điều kiện không thỏa mãn
                return 0;
            }
        }
        public double TKLD_TongKlCChoCongHop(double TKLD_KlCChoDatCongHop, double TKLD_KlCChoDaCongHop)
        {
            // Tính tổng và làm tròn đến 2 chữ số thập phân
            return Math.Round(TKLD_KlCChoDatCongHop + TKLD_KlCChoDaCongHop, 2);
        }
        public double TKLD_KlCChoDatRanh(double TTCCCCCHR_CCaoLotDatTBinh, double TTKTHHCongHopRanh_CRongLotMong, double TTKTHHCongHopRanh_CRongMong, double TTCCCCCHR_CCaoMongDatTBinh, double TTCCCCCHR_CCaoTuongDatTBinh, double TTKTHHCongHopRanh_CDayTuong01Ben, double TTKTHHCongHopRanh_SoLuongTuong, double TTKTHHCongHopRanh_CRongLongSuDung, double TTCDSLCauKienDuongTruyenDan_TongChieuDai, string ThongTinDuongTruyenDan_HinhThucTruyenDan)
        {
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "RÃNH XÂY" || ThongTinDuongTruyenDan_HinhThucTruyenDan == "RÃNH BÊ TÔNG")
            {
                // Tính toán giá trị
                double giaTri = ((TTCCCCCHR_CCaoLotDatTBinh * TTKTHHCongHopRanh_CRongLotMong) + (TTKTHHCongHopRanh_CRongMong * TTCCCCCHR_CCaoMongDatTBinh) + (TTCCCCCHR_CCaoTuongDatTBinh * ((TTKTHHCongHopRanh_CDayTuong01Ben * TTKTHHCongHopRanh_SoLuongTuong) + TTKTHHCongHopRanh_CRongLongSuDung))) * TTCDSLCauKienDuongTruyenDan_TongChieuDai;
                // Làm tròn đến 2 chữ số thập phân
                return Math.Round(giaTri, 2);
            }
            else
            {
                return 0;
            }
        }
        public double TKLD_KlCChoDaRanh(double TTCCCCCHR_CCaoLotDaTBinh, double TTKTHHCongHopRanh_CRongLotMong, double TTKTHHCongHopRanh_CRongMong, double TTCCCCCHR_CCaoMongDaTBinh, double TTCCCCCHR_CCaoTuongDaTBinh, double TTKTHHCongHopRanh_CDayTuong01Ben, double TTKTHHCongHopRanh_SoLuongTuong, double TTKTHHCongHopRanh_CRongLongSuDung, double TTCDSLCauKienDuongTruyenDan_TongChieuDai, string ThongTinDuongTruyenDan_HinhThucTruyenDan)
        {
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "RÃNH XÂY" || ThongTinDuongTruyenDan_HinhThucTruyenDan == "RÃNH BÊ TÔNG")
            {
                // Tính toán giá trị
                double giaTri = ((TTCCCCCHR_CCaoLotDaTBinh * TTKTHHCongHopRanh_CRongLotMong) + (TTKTHHCongHopRanh_CRongMong * TTCCCCCHR_CCaoMongDaTBinh) + (TTCCCCCHR_CCaoTuongDaTBinh * ((TTKTHHCongHopRanh_CDayTuong01Ben * TTKTHHCongHopRanh_SoLuongTuong) + TTKTHHCongHopRanh_CRongLongSuDung))) * TTCDSLCauKienDuongTruyenDan_TongChieuDai;
                // Làm tròn đến 2 chữ số thập phân
                return Math.Round(giaTri, 2);
            }
            else
            {
                return 0;
            }
        }
        public double TKLD_TongKlCChoRanh(double TKLD_KlCChoDatRanh, double TKLD_KlCChoDaRanh)
        {
            // Tính tổng  TKLD_KlCChoDatRanh  và  TKLD_KlCChoDaRanh
            double result = TKLD_KlCChoDatRanh + TKLD_KlCChoDaRanh;
            // Làm tròn kết quả đến 2 chữ số thập phân
            return Math.Round(result, 2);
        }
        public double TKLD_KlCChoDatOngNhua(double TTCCCCON_CCaoDemCatDatTBinh, double TTCCCCON_CCaoDatTBinh, double TTCCCCON_CCaoDapCatDatTBinh, double TTMDRanhOngThang_TyLeMoMai, double TTMDRanhOngThang_SoCanhMaiTrai, double TTMDRanhOngThang_SoCanhMaiPhai, double TTMDRanhOngThang_ChieuRongDayDaoNho, double TTCDSLCauKienDuongTruyenDan_TongChieuDai)
        {
            double sumOEOKOQ = TTCCCCON_CCaoDemCatDatTBinh + TTCCCCON_CCaoDatTBinh + TTCCCCON_CCaoDapCatDatTBinh;
            double intermediateResult = ((((sumOEOKOQ * TTMDRanhOngThang_TyLeMoMai * (TTMDRanhOngThang_SoCanhMaiTrai + TTMDRanhOngThang_SoCanhMaiPhai)) + TTMDRanhOngThang_ChieuRongDayDaoNho) + TTMDRanhOngThang_ChieuRongDayDaoNho) * (sumOEOKOQ / 2)) * TTCDSLCauKienDuongTruyenDan_TongChieuDai;

            // Làm tròn kết quả đến 2 chữ số thập phân
            return Math.Round(intermediateResult, 2);
        }
        public double TKLD_KlCChoDaOngNhua(double TTCCCCON_CCaoDemCatDaTBinh, double TTCCCCON_CCaoDaTBinh, double TTCCCCON_CCaoDapCatDaTBinh, double TTMDRanhOngThang_TyLeMoMai, double TTMDRanhOngThang_SoCanhMaiTrai, double TTMDRanhOngThang_SoCanhMaiPhai, double TTMDRanhOngThang_ChieuRongDayDaoNho, double TTCDSLCauKienDuongTruyenDan_TongChieuDai)
        {
            // Tính tổng của TTCCCCON_CCaoDemCatDaTBinh   , TTCCCCON_CCaoDaTBinh và   TTCCCCON_CCaoDapCatDaTBinh
            double sumOHONOT = TTCCCCON_CCaoDemCatDaTBinh + TTCCCCON_CCaoDaTBinh + TTCCCCON_CCaoDapCatDaTBinh;

            // Tính toán biểu thức phức tạp
            double intermediateResult = (((((sumOHONOT * TTMDRanhOngThang_TyLeMoMai * (TTMDRanhOngThang_SoCanhMaiTrai + TTMDRanhOngThang_SoCanhMaiPhai)) + TTMDRanhOngThang_ChieuRongDayDaoNho) + TTMDRanhOngThang_ChieuRongDayDaoNho) * (sumOHONOT / 2)) * TTCDSLCauKienDuongTruyenDan_TongChieuDai);

     // Làm tròn kết quả đến 2 chữ số thập phân
     return Math.Round(intermediateResult, 2);
        }
        public double TKLD_TongKlCChoOngNhua(double TKLD_KlCChoDatOngNhua, double TKLD_KlCChoDaOngNhua)
        {
            // Tính tổng của  TKLD_KlCChoDatOngNhua  và  TKLD_KlCChoDaOngNhua
            double sum = TKLD_KlCChoDatOngNhua + TKLD_KlCChoDaOngNhua;

            // Làm tròn kết quả đến 2 chữ số thập phân
            return Math.Round(sum, 2);
        }
        public double TKLD_KlCChoDatRanhThang(double TTCCRT_LotDatTrungBinh, double ThongTinRanhThang_CRongLot, double ThongTinRanhThang_CRongMong, double TTCCRT_MongDatTrungBinh, double TTCDSLCauKienDuongTruyenDan_TongChieuDai)
        {
            // Tính toán giá trị theo công thức
            double result = ((TTCCRT_LotDatTrungBinh * ThongTinRanhThang_CRongLot) + (ThongTinRanhThang_CRongMong * TTCCRT_MongDatTrungBinh)) * TTCDSLCauKienDuongTruyenDan_TongChieuDai;

            // Làm tròn kết quả đến 2 chữ số thập phân
            return Math.Round(result, 2);
        }
        public double TKLD_KlCChoDaRanhThang(double TTCCRT_LotDaTrungBinh, double ThongTinRanhThang_CRongLot, double ThongTinRanhThang_CRongMong, double TTCCRT_MongDaTrungBinh, double TTCDSLCauKienDuongTruyenDan_TongChieuDai)
        {
            // Tính toán giá trị theo công thức
            double result = ((TTCCRT_LotDaTrungBinh * ThongTinRanhThang_CRongLot) + (ThongTinRanhThang_CRongMong * TTCCRT_MongDaTrungBinh)) * TTCDSLCauKienDuongTruyenDan_TongChieuDai;

            // Làm tròn kết quả đến 2 chữ số thập phân
            return Math.Round(result, 2);
        }
        public double TKLD_TongKlCChoRanhThang(double TKLD_KlCChoDatRanhThang, double TKLD_KlCChoDaRanhThang)
        {
            // Tính tổng của  TKLD_KlCChoDatRanhThang  và  TKLD_KlCChoDaRanhThang
            double result = TKLD_KlCChoDatRanhThang + TKLD_KlCChoDaRanhThang;

            // Làm tròn kết quả đến 2 chữ số thập phân
            return Math.Round(result, 2);
        }
        public double TKLD_KlCChoDatChanKhay(double ThongTinRanhThang_CCaoLotChanKhay, double ThongTinRanhThang_CRongLotChanKhay, double ThongTinRanhThang_SoLuongLotChanKhay, double ThongTinRanhThang_CCaoMongChanKhay, double ThongTinRanhThang_CRongMongChanKhay, double ThongTinRanhThang_SoLuongMongChanKhay, double TTCDSLCauKienDuongTruyenDan_TongChieuDai)
        {
            // Tính toán giá trị theo công thức
            double result = ((ThongTinRanhThang_CCaoLotChanKhay * ThongTinRanhThang_CRongLotChanKhay * ThongTinRanhThang_SoLuongLotChanKhay) + (ThongTinRanhThang_CCaoMongChanKhay * ThongTinRanhThang_CRongMongChanKhay * ThongTinRanhThang_SoLuongMongChanKhay)) * TTCDSLCauKienDuongTruyenDan_TongChieuDai;

            // Làm tròn kết quả đến 2 chữ số thập phân
            return Math.Round(result, 2);
        }
        public double TKLD_KlCChoDatChanGiangDinh(double ThongTinRanhThang_CCaoLotGiangDinh, double ThongTinRanhThang_CRongLotGiangDinh, double ThongTinRanhThang_SoLuongLotGiangDinh, double ThongTinRanhThang_CCaoMongGiangDinh, double ThongTinRanhThang_CRongMongGiangDinh, double ThongTinRanhThang_SoLuongMongGiangDinh, double TTCDSLCauKienDuongTruyenDan_TongChieuDai)
        {
            // Tính toán giá trị theo công thức
            double result = ((ThongTinRanhThang_CCaoLotGiangDinh * ThongTinRanhThang_CRongLotGiangDinh * ThongTinRanhThang_SoLuongLotGiangDinh) + (ThongTinRanhThang_CCaoMongGiangDinh * ThongTinRanhThang_CRongMongGiangDinh * ThongTinRanhThang_SoLuongMongGiangDinh)) * TTCDSLCauKienDuongTruyenDan_TongChieuDai;

            // Làm tròn kết quả đến 2 chữ số thập phân
            return Math.Round(result, 2);
        }
        public double TKLD_TongKlCChoDat(double TKLD_KlCChoDatRanhThang, double TKLD_KlCChoDatChanKhay, double TKLD_KlCChoDatChanGiangDinh)
        {
            // Tính tổng và làm tròn kết quả đến 2 chữ số thập phân
            return Math.Round(TKLD_KlCChoDatRanhThang + TKLD_KlCChoDatChanKhay + TKLD_KlCChoDatChanGiangDinh, 2);
        }
        public double TKLD_TongKlCChoDa(double TKLD_KlCChoDaRanhThang)
        {
            // Làm tròn giá trị  TKLD_KlCChoDaRanhThang  đến 2 chữ số thập phân
            return Math.Round(TKLD_KlCChoDaRanhThang, 2);
        }
        public double TKLD_TongKlCCho(double TKLD_TongKlCChoDat, double TKLD_TongKlCChoDa)
        {
            // Tính tổng của  TKLD_TongKlCChoDat  và  TKLD_TongKlCChoDa , sau đó làm tròn đến 2 chữ số thập phân
            return Math.Round(TKLD_TongKlCChoDat + TKLD_TongKlCChoDa, 2);
        }
        public double TKLD_KlCChoDat(double TKLD_KlCChoDatCongTron, double TKLD_KlCChoDatCongHop, double TKLD_KlCChoDatRanh, double TKLD_KlCChoDatOngNhua)
        {
            double result = 0;
            result = TKLD_KlCChoDatCongTron + TKLD_KlCChoDatCongHop + TKLD_KlCChoDatRanh + TKLD_KlCChoDatOngNhua;
            // Tính tổng của các giá trị và làm tròn đến 2 chữ số thập phân
            return Math.Round(result, 2);
        }
        public double TKLD_KlCChoDa(double TKLD_KlCChoDaCongTron, double TKLD_KlCChoDaCongHop, double TKLD_KlCChoDaRanh, double TKLD_KlCChoDaOngNhua)
        {
            double result = 0;
            result = TKLD_KlCChoDaCongTron + TKLD_KlCChoDaCongHop + TKLD_KlCChoDaRanh + TKLD_KlCChoDaOngNhua;
            // Tính tổng của các giá trị và làm tròn đến 2 chữ số thập phân
            return Math.Round(result , 2);
        }
        public double TKLD_TongChiemCho(double TKLD_KlCChoDat, double TKLD_KlCChoDa)
        {
            // Tính tổng của các giá trị và làm tròn đến 2 chữ số thập phân
            return Math.Round(TKLD_KlCChoDat + TKLD_KlCChoDa, 2);
        }
        public double TKLD_KlDapTraDat(double TKLD_TongKlDaoDat, double TKLD_KlCChoDat)
        {
            // Tính hiệu của các giá trị và làm tròn đến 2 chữ số thập phân
            return Math.Round(TKLD_TongKlDaoDat - TKLD_KlCChoDat, 2);
        }
        public double TKLD_KlDapTraDa(double TKLD_TongKlDaoDa, double TKLD_KlCChoDa)
        {
            // Tính hiệu của các giá trị và làm tròn đến 2 chữ số thập phân
            return Math.Round(TKLD_TongKlDaoDa - TKLD_KlCChoDa, 2);
        }
        public double TKLD_TongKlDapTra(double TKLD_KlDapTraDat, double TKLD_KlDapTraDa)
        {
            // Tính tổng của các giá trị và làm tròn đến 2 chữ số thập phân
            return Math.Round(TKLD_KlDapTraDat + TKLD_KlDapTraDa, 2);
        }
        public double DTDC_TLCSauDap(double ThongTinKichThuocHinhHocOngNhua_TongCCaoOng, double ThongTinKichThuocHinhHocOngNhua_CCaoDemCat, double ThongTinKichThuocHinhHocOngNhua_CCaoDapCat, string ThongTinDuongTruyenDan_HinhThucTruyenDan, string ThongTinMongDuongTruyenDan_LoaiMong)
        {
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            ThongTinMongDuongTruyenDan_LoaiMong = GetTenDanhMucById(ThongTinMongDuongTruyenDan_LoaiMong).ToUpper().Trim();

            // Kiểm tra điều kiện và tính tổng nếu điều kiện đúng, sau đó làm tròn đến 2 chữ số thập phân
            double result = (ThongTinDuongTruyenDan_HinhThucTruyenDan == "ỐNG NHỰA" && ThongTinMongDuongTruyenDan_LoaiMong == "ĐẮP CÁT") ? ThongTinKichThuocHinhHocOngNhua_TongCCaoOng + ThongTinKichThuocHinhHocOngNhua_CCaoDemCat + ThongTinKichThuocHinhHocOngNhua_CCaoDapCat : 0;
            return Math.Round(result, 2);
        }
        public double DTDC_TLCRongDapDayLon(double DTDC_TLCSauDap, double TTMDRanhOngThang_TyLeMoMai, double TTMDRanhOngThang_SoCanhMaiTrai, double TTMDRanhOngThang_SoCanhMaiPhai, double TTMDRanhOngThang_ChieuRongDayDaoNho, string ThongTinDuongTruyenDan_HinhThucTruyenDan, string ThongTinMongDuongTruyenDan_LoaiMong)
        {
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            ThongTinMongDuongTruyenDan_LoaiMong = GetTenDanhMucById(ThongTinMongDuongTruyenDan_LoaiMong).ToUpper().Trim();

            // Kiểm tra điều kiện và tính giá trị nếu điều kiện đúng, sau đó làm tròn đến 2 chữ số thập phân
            double result = (ThongTinDuongTruyenDan_HinhThucTruyenDan == "ỐNG NHỰA" && ThongTinMongDuongTruyenDan_LoaiMong == "ĐẮP CÁT")
                ? (DTDC_TLCSauDap * TTMDRanhOngThang_TyLeMoMai * (TTMDRanhOngThang_SoCanhMaiTrai + TTMDRanhOngThang_SoCanhMaiPhai)) + TTMDRanhOngThang_ChieuRongDayDaoNho
                : 0;
            return Math.Round(result, 2);
        }
        public double DTDC_TLDTichDap(double DTDC_TLCRongDapDayLon, double TTMDRanhOngThang_ChieuRongDayDaoNho, double ThongTinKichThuocHinhHocOngNhua_TongCCaoOng, double ThongTinKichThuocHinhHocOngNhua_CCaoDemCat, double ThongTinKichThuocHinhHocOngNhua_CCaoDapCat, string ThongTinDuongTruyenDan_HinhThucTruyenDan, string ThongTinMongDuongTruyenDan_LoaiMong)
        {
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            ThongTinMongDuongTruyenDan_LoaiMong = GetTenDanhMucById(ThongTinMongDuongTruyenDan_LoaiMong).ToUpper().Trim();

            // Kiểm tra điều kiện và tính giá trị nếu điều kiện đúng, sau đó làm tròn đến 2 chữ số thập phân
            double result = (ThongTinDuongTruyenDan_HinhThucTruyenDan == "ỐNG NHỰA" && ThongTinMongDuongTruyenDan_LoaiMong == "ĐẮP CÁT")
                ? (DTDC_TLCRongDapDayLon + TTMDRanhOngThang_ChieuRongDayDaoNho) * ((ThongTinKichThuocHinhHocOngNhua_TongCCaoOng + ThongTinKichThuocHinhHocOngNhua_CCaoDemCat + ThongTinKichThuocHinhHocOngNhua_CCaoDapCat) / 2)
                : 0;
            return Math.Round(result, 2);
        }
        public double DTDC_HLCSauDap(double ThongTinKichThuocHinhHocOngNhua_TongCCaoOng, double ThongTinKichThuocHinhHocOngNhua_CCaoDemCat, double ThongTinKichThuocHinhHocOngNhua_CCaoDapCat, string ThongTinDuongTruyenDan_HinhThucTruyenDan, string ThongTinMongDuongTruyenDan_LoaiMong)
        {
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            ThongTinMongDuongTruyenDan_LoaiMong = GetTenDanhMucById(ThongTinMongDuongTruyenDan_LoaiMong).ToUpper().Trim();

            // Kiểm tra điều kiện và tính giá trị nếu điều kiện đúng, sau đó làm tròn đến 2 chữ số thập phân
            double result = (ThongTinDuongTruyenDan_HinhThucTruyenDan == "ỐNG NHỰA" && ThongTinMongDuongTruyenDan_LoaiMong == "ĐẮP CÁT")
                ? ThongTinKichThuocHinhHocOngNhua_TongCCaoOng + ThongTinKichThuocHinhHocOngNhua_CCaoDemCat + ThongTinKichThuocHinhHocOngNhua_CCaoDapCat
                : 0;
            return Math.Round(result, 2);
        }
        public double DTDC_HLCRongDapDayLon(double DTDC_HLCSauDap, double TTMDRanhOngThang_TyLeMoMai, double TTMDRanhOngThang_SoCanhMaiTrai, double TTMDRanhOngThang_SoCanhMaiPhai, double TTMDRanhOngThang_ChieuRongDayDaoNho, string ThongTinDuongTruyenDan_HinhThucTruyenDan, string ThongTinMongDuongTruyenDan_LoaiMong)
        {
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            ThongTinMongDuongTruyenDan_LoaiMong = GetTenDanhMucById(ThongTinMongDuongTruyenDan_LoaiMong).ToUpper().Trim();

            // Kiểm tra điều kiện và tính giá trị nếu điều kiện đúng, sau đó làm tròn đến 2 chữ số thập phân
            double result = (ThongTinDuongTruyenDan_HinhThucTruyenDan == "ỐNG NHỰA" && ThongTinMongDuongTruyenDan_LoaiMong == "ĐẮP CÁT")
                ? (DTDC_HLCSauDap * TTMDRanhOngThang_TyLeMoMai * (TTMDRanhOngThang_SoCanhMaiTrai + TTMDRanhOngThang_SoCanhMaiPhai)) + TTMDRanhOngThang_ChieuRongDayDaoNho
                : 0;
            return Math.Round(result, 2);
        }
        public double DTDC_HLDTichDap(double DTDC_HLCRongDapDayLon, double TTMDRanhOngThang_ChieuRongDayDaoNho, double ThongTinKichThuocHinhHocOngNhua_TongCCaoOng, double ThongTinKichThuocHinhHocOngNhua_CCaoDemCat, double ThongTinKichThuocHinhHocOngNhua_CCaoDapCat, string ThongTinDuongTruyenDan_HinhThucTruyenDan, string ThongTinMongDuongTruyenDan_LoaiMong)
        {
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            ThongTinMongDuongTruyenDan_LoaiMong = GetTenDanhMucById(ThongTinMongDuongTruyenDan_LoaiMong).ToUpper().Trim();

            // Kiểm tra điều kiện và tính giá trị nếu điều kiện đúng, sau đó làm tròn đến 2 chữ số thập phân
            double result = (ThongTinDuongTruyenDan_HinhThucTruyenDan == "ỐNG NHỰA" && ThongTinMongDuongTruyenDan_LoaiMong == "ĐẮP CÁT")
                ? (DTDC_HLCRongDapDayLon + TTMDRanhOngThang_ChieuRongDayDaoNho) * ((ThongTinKichThuocHinhHocOngNhua_TongCCaoOng + ThongTinKichThuocHinhHocOngNhua_CCaoDemCat + ThongTinKichThuocHinhHocOngNhua_CCaoDapCat) / 2)
                : 0;
            return Math.Round(result, 2);
        }
        public double TTKLDC_KlDapCatTruocChiemCho(double DTDC_TLDTichDap, double DTDC_HLDTichDap, double TTCDSLCauKienDuongTruyenDan_TongChieuDai)
        {
            // Tính giá trị theo công thức và làm tròn đến 2 chữ số thập phân
            double result = ((DTDC_TLDTichDap + DTDC_HLDTichDap) / 2) * TTCDSLCauKienDuongTruyenDan_TongChieuDai;
            return Math.Round(result, 2);
        }
        public double TTKLDC_KlChiemCho(double ThongTinKichThuocHinhHocOngNhua_TongCCaoOng, double TTCDSLCauKienDuongTruyenDan_TongChieuDai, string ThongTinDuongTruyenDan_HinhThucTruyenDan, string ThongTinMongDuongTruyenDan_LoaiMong)
        {
            // Chuyển đổi các tham số ThongTinDuongTruyenDan_HinhThucTruyenDan  và  ThongTinMongDuongTruyenDan_LoaiMong  thành dạng chữ hoa và loại bỏ khoảng trắng đầu cuối
            ThongTinDuongTruyenDan_HinhThucTruyenDan = ThongTinDuongTruyenDan_HinhThucTruyenDan.ToUpper().Trim();
            ThongTinMongDuongTruyenDan_LoaiMong = ThongTinMongDuongTruyenDan_LoaiMong.ToUpper().Trim();

            // Kiểm tra điều kiện
            if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "ỐNG NHỰA" && ThongTinMongDuongTruyenDan_LoaiMong == "ĐẮP CÁT")
            {
                // Tính giá trị theo công thức và làm tròn đến 2 chữ số thập phân
                double result = ((3.14 * ThongTinKichThuocHinhHocOngNhua_TongCCaoOng * ThongTinKichThuocHinhHocOngNhua_TongCCaoOng) / 4) * TTCDSLCauKienDuongTruyenDan_TongChieuDai;
                return Math.Round(result, 2);
            }
            else
            {
                // Trả về 0 nếu điều kiện không thỏa mãn
                return 0;
            }
        }

        //End NuocMua


    }
}
