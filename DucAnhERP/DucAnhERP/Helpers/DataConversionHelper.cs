using DucAnhERP.Components.Pages.NghiepVuCongTrinh;
using DucAnhERP.Models;
using DucAnhERP.ViewModel;

namespace DucAnhERP.Helpers
{
    public class DataConversionHelper
    {
        public List<DanhMuc1> listDanhMuc = new();
        public string GetTenDanhMucById(string id = "")
        {

            var danhMuc = listDanhMuc.FirstOrDefault(dm => dm.Id == id);
            return danhMuc != null ? danhMuc.Ten : "";
        }
        public async Task<List<HopRanhThangModel>> ConvertDataHopRanhThang(List<HopRanhThangModel> list, List<DanhMuc1> listDM)
        {
            listDanhMuc = listDM;
            if (list == null || list.Count == 0)
            {
                Console.WriteLine("Danh sách trống.");
            }
            else
            {
                var i = 0;
                list.ForEach(item =>
                {
                    i++;
                   
                    item.ThongTinCaoDoHoGa_CaoDoHienTrangTruocKhiDao = ThongTinCaoDoHoGa_CaoDoHienTrangTruocKhiDao(item.ThongTinCaoDoHoGa_CaoDoTuNhien, item.ThongTinCaoDoHoGa_CaoDoDinhK98, item.ThongTinCaoDoHoGa_CdDinhViaHeHoanThien);
                    item.ThongTinCaoDoHoGa_CdDinhMong = ThongTinCaoDoHoGa_CdDinhMong(item.ThongTinChungHoGa_HinhThucHoGa, item.ThongTinChungHoGa_HinhThucMongHoGa, item.ThongTinCaoDoHoGa_CdDayHoGa, item.DeHoGa_C);
                    item.ThongTinCaoDoHoGa_DinhLotMong = ThongTinCaoDoHoGa_DinhLotMong(item.ThongTinChungHoGa_HinhThucMongHoGa, item.ThongTinCaoDoHoGa_CdDinhMong, item.BeTongMongHoGa_C);
                    item.ThongTinCaoDoHoGa_DayDao = ThongTinCaoDoHoGa_DayDao(item.ThongTinChungHoGa_HinhThucHoGa, item.ThongTinChungHoGa_HinhThucMongHoGa, item.ThongTinCaoDoHoGa_DinhLotMong, item.BeTongLotMong_C, item.ThongTinCaoDoHoGa_CdDayHoGa, item.DeHoGa_C);
                    item.ThongTinCaoDoHoGa_CSauDao = ThongTinCaoDoHoGa_CSauDao(item.ThongTinCaoDoHoGa_CaoDoHienTrangTruocKhiDao, item.ThongTinCaoDoHoGa_DayDao);
                    item.ThongTinVatLieuDaoHoGa_ChieuCaoDaoDat = ThongTinVatLieuDaoHoGa_ChieuCaoDaoDat(item.ThongTinVatLieuDaoHoGa_LoaiVatLieuDao, item.ThongTinCaoDoHoGa_CSauDao, item.ThongTinVatLieuDaoHoGa_ChieuCaoDaoDa);
                    item.ThongTinVatLieuDaoHoGa_TongChieuCaoDao = (item.ThongTinVatLieuDaoHoGa_ChieuCaoDaoDa + item.ThongTinVatLieuDaoHoGa_ChieuCaoDaoDat);

                    item.ThongTinCaoDoHoGa_TongChieuCaoHoGa = ThongTinCaoDoHoGa_TongChieuCaoHoGa(item.ThongTinCaoDoHoGa_CdDinhHoGa, item.ThongTinCaoDoHoGa_DayDao);
                    item.ThongTinCaoDoHoGa_ChenhCaoDinhHoGaVaHienTrangDao = ThongTinCaoDoHoGa_ChenhCaoDinhHoGaVaHienTrangDao(item.ThongTinCaoDoHoGa_CdDinhHoGa, item.ThongTinCaoDoHoGa_CaoDoHienTrangTruocKhiDao);
                    item.ThongTinCaoDoHoGa_TongChieuCaoChiemChoDapTra = Math.Round(item.ThongTinCaoDoHoGa_TongChieuCaoHoGa - item.ThongTinCaoDoHoGa_ChenhCaoDinhHoGaVaHienTrangDao, 2);
                    item.ThongTinCaoDoHoGa_DinhMuMoThotDuoi = ThongTinCaoDoHoGa_DinhMuMoThotDuoi(item.ThongTinCaoDoHoGa_CdDinhHoGa, item.MuMoThotTren_C);
                    item.ThongTinCaoDoHoGa_DinhTuong = ThongTinCaoDoHoGa_DinhTuong(item.ThongTinCaoDoHoGa_DinhMuMoThotDuoi, item.MuMoThotDuoi_C);
                    item.ThongTinCaoDoHoGa_DinhTuongDuoiDamGiuaTuong = ThongTinCaoDoHoGa_DinhTuongDuoiDamGiuaTuong(item.DamGiuaHoGa_CCaoDamGiuaTuongSoVoiDayHoGa, item.ThongTinCaoDoHoGa_CdDayHoGa);
                    item.ThongTinCaoDoHoGa_DinhDamGiuaTuong = ThongTinCaoDoHoGa_DinhDamGiuaTuong(item.DamGiuaHoGa_CCaoDamGiuaTuongSoVoiDayHoGa, item.ThongTinCaoDoHoGa_DinhTuongDuoiDamGiuaTuong, item.DamGiuaHoGa_C);
                    item.ThongTinCaoDoHoGa_CCaoTuong = ThongTinCaoDoHoGa_CCaoTuong(item.DamGiuaHoGa_CCaoDamGiuaTuongSoVoiDayHoGa, item.ThongTinCaoDoHoGa_DinhTuong, item.ThongTinCaoDoHoGa_CdDayHoGa, item.DamGiuaHoGa_C);
                    item.TuongHoGa_C = item.ThongTinCaoDoHoGa_CCaoTuong;
                    item.ChatMatNgoaiCanh_C = ChatMatNgoaiCanh_C(item.ThongTinChungHoGa_ChatMatNgoai, item.ThongTinChungHoGa_KetCauTuong, item.ThongTinChungHoGa_KetCauMuMo, item.TuongHoGa_C, item.DamGiuaHoGa_CdDam, item.MuMoThotDuoi_C, item.MuMoThotTren_C, item.MuMoThotTren_CdTuong);
                    item.ChatMatTrong_C = ChatMatTrong_C(item.ThongTinChungHoGa_ChatMatTrong, item.ThongTinChungHoGa_KetCauTuong, item.ThongTinChungHoGa_KetCauMuMo, item.TuongHoGa_C, item.DamGiuaHoGa_C, item.MuMoThotDuoi_C, item.MuMoThotTren_C);

                    item.TTCCCCDTHT_ChieuCaoLotDat = TTCCCCDTHT_ChieuCaoLotDat(item.ThongTinVatLieuDaoHoGa_LoaiVatLieuDao, item.ThongTinVatLieuDaoHoGa_ChieuCaoDaoDat, item.BeTongLotMong_C);
                    item.TTCCCCDTHT_ChieuCaoMongDat = TTCCCCDTHT_ChieuCaoMongDat(item.ThongTinVatLieuDaoHoGa_LoaiVatLieuDao, item.ThongTinVatLieuDaoHoGa_ChieuCaoDaoDat, item.BeTongLotMong_C, item.BeTongMongHoGa_C);
                    item.TTCCCCDTHT_ChieuCaoTuongDat = TTCCCCDTHT_ChieuCaoTuongDat(item.ThongTinVatLieuDaoHoGa_LoaiVatLieuDao, item.ThongTinVatLieuDaoHoGa_ChieuCaoDaoDat, item.BeTongLotMong_C, item.BeTongMongHoGa_C, item.TuongHoGa_C, item.DamGiuaHoGa_C, item.MuMoThotDuoi_C, item.MuMoThotTren_C);
                    item.TTCCCCDTHT_ChieuCaoLotDa = TTCCCCDTHT_ChieuCaoLotDa(item.ThongTinVatLieuDaoHoGa_LoaiVatLieuDao, item.ThongTinVatLieuDaoHoGa_ChieuCaoDaoDa, item.ThongTinVatLieuDaoHoGa_TongChieuCaoDao, item.TTCCCCDTHT_ChieuCaoLotDat, item.BeTongLotMong_C);
                    item.TTCCCCDTHT_ChieuCaoMongDa = TTCCCCDTHT_ChieuCaoMongDa(item.ThongTinVatLieuDaoHoGa_LoaiVatLieuDao, item.ThongTinVatLieuDaoHoGa_ChieuCaoDaoDa, item.ThongTinVatLieuDaoHoGa_TongChieuCaoDao, item.TTCCCCDTHT_ChieuCaoMongDat, item.TTCCCCDTHT_ChieuCaoLotDa, item.BeTongLotMong_C, item.BeTongMongHoGa_C);
                    item.TTCCCCDTHT_ChieuCaoTuongDa = TTCCCCDTHT_ChieuCaoTuongDa(item.ThongTinVatLieuDaoHoGa_LoaiVatLieuDao, item.ThongTinVatLieuDaoHoGa_ChieuCaoDaoDa, item.ThongTinVatLieuDaoHoGa_TongChieuCaoDao, item.TTCCCCDTHT_ChieuCaoTuongDat, item.TTCCCCDTHT_ChieuCaoLotDa, item.TTCCCCDTHT_ChieuCaoMongDa, item.BeTongLotMong_C, item.BeTongMongHoGa_C, item.TuongHoGa_C, item.DamGiuaHoGa_C, item.MuMoThotDuoi_C, item.MuMoThotTren_C);
                    item.TTCCCCDTHT_TongCieuCaoDat = Math.Round((item.TTCCCCDTHT_ChieuCaoLotDat + item.TTCCCCDTHT_ChieuCaoMongDat + item.TTCCCCDTHT_ChieuCaoTuongDat), 2);
                    item.TTCCCCDTHT_TongChieuCaoDa = Math.Round((item.TTCCCCDTHT_ChieuCaoLotDa + item.TTCCCCDTHT_ChieuCaoMongDa + item.TTCCCCDTHT_ChieuCaoTuongDa), 2);
                    item.TTCCCCDTHT_ChenhDatSoVoiTK = Math.Round((item.ThongTinVatLieuDaoHoGa_ChieuCaoDaoDat - item.TTCCCCDTHT_TongCieuCaoDat), 2);
                    item.TTCCCCDTHT_ChenhDaSoVoiTK = Math.Round((item.ThongTinVatLieuDaoHoGa_ChieuCaoDaoDa - item.TTCCCCDTHT_TongChieuCaoDa), 2);

                    item.TTKLD_CRongDaoDayLonDat = TTKLD_CRongDaoDayLonDat(item.ThongTinVatLieuDaoHoGa_LoaiVatLieuDao, item.ThongTinVatLieuDaoHoGa_ChieuCaoDaoDat, item.ThongTinMaiDao_TyLeMoMai, item.ThongTinMaiDao_SoCanhMaiTrai, item.ThongTinMaiDao_SoCanhMaiPhai, item.ThongTinMaiDao_ChieuRongDayDaoNho);
                    item.TTKLD_CRongDaoDayLonDa = TinhTTTKLD_CRongDaoDayLonDaoan(item.ThongTinVatLieuDaoHoGa_LoaiVatLieuDao, item.ThongTinVatLieuDaoHoGa_ChieuCaoDaoDa, item.ThongTinMaiDao_TyLeMoMai, item.ThongTinMaiDao_SoCanhMaiTrai, item.ThongTinMaiDao_SoCanhMaiPhai, item.TTKLD_CRongDaoDayLonDat, item.ThongTinMaiDao_ChieuRongDayDaoNho);
                    item.TTKLD_DienTichDaoDat = TTKLD_DienTichDaoDat(item.TTKLD_CRongDaoDayLonDat, item.ThongTinMaiDao_ChieuRongDayDaoNho, item.ThongTinVatLieuDaoHoGa_ChieuCaoDaoDat);
                    item.TTKLD_DienTichDaoDa = TTKLD_DienTichDaoDa(item.TTKLD_CRongDaoDayLonDa, item.TTKLD_CRongDaoDayLonDat, item.ThongTinMaiDao_ChieuRongDayDaoNho, item.ThongTinVatLieuDaoHoGa_ChieuCaoDaoDa);
                    item.TTKLD_TongDtDao = TTKLD_TongDtDao(item.TTKLD_DienTichDaoDat, item.TTKLD_DienTichDaoDa);
                    item.DTDCKRD_CKCRongDaoDayLon = DTDCKRD_CKCRongDaoDayLon(item.ThongTinRanhThang_CCaoLotChanKhay, item.ThongTinRanhThang_CCaoMongChanKhay, item.TTMDRanhOngThang_TyLeMoMai1, item.TTMDRanhOngThang_SoCanhMaiTrai1, item.TTMDRanhOngThang_SoCanhMaiPhai1, item.TTMDRanhOngThang_ChieuRongDayDaoNho1);
                    item.DTDCKRD_CKDTichDao = DTDCKRD_CKDTichDao(item.DTDCKRD_CKCRongDaoDayLon, item.TTMDRanhOngThang_ChieuRongDayDaoNho1, item.ThongTinRanhThang_CCaoLotChanKhay, item.ThongTinRanhThang_CCaoMongChanKhay, item.ThongTinRanhThang_SoLuongMongChanKhay);
                    item.DTDCKRD_CRongDaoDayLon = DTDCKRD_CRongDaoDayLon(item.ThongTinRanhThang_CCaoLotGiangDinh, item.ThongTinRanhThang_CCaoMongGiangDinh, item.TTMDRanhOngThang_TyLeMoMai1, item.TTMDRanhOngThang_SoCanhMaiTrai1, item.TTMDRanhOngThang_SoCanhMaiPhai1, item.TTMDRanhOngThang_ChieuRongDayDaoNho1);
                    item.DTDCKRD_DTichDao = DTDCKRD_DTichDao(item.DTDCKRD_CRongDaoDayLon, item.TTMDRanhOngThang_ChieuRongDayDaoNho1, item.ThongTinRanhThang_CCaoLotGiangDinh, item.ThongTinRanhThang_CCaoMongGiangDinh, item.ThongTinRanhThang_SoLuongMongGiangDinh);


                    item.TTKLD_KlDaoDat = TTKLD_KlDaoDat(item.TTKLD_DienTichDaoDat, item.BeTongLotMong_D, item.PhuBiHoGa_CDai, item.ThongTinChungHoGa_TenHoGaTheoBanVe);
                    item.TTKLD_KlDaoDa = TTKLD_KlDaoDa(item.TTKLD_DienTichDaoDa, item.BeTongLotMong_D, item.PhuBiHoGa_CDai, item.ThongTinChungHoGa_TenHoGaTheoBanVe);
                    item.TTKLD_TongKlDao = TTKLD_TongKlDao(item.TTKLD_KlDaoDat, item.TTKLD_KlDaoDa);
                    item.TTKLD_KlChiemChoDat = TTKLD_KlChiemChoDat(item.ThongTinChungHoGa_TenHoGaTheoBanVe, item.BeTongLotMong_D, item.TTCCCCDTHT_ChieuCaoLotDat, item.BeTongLotMong_R, item.BeTongMongHoGa_D, item.BeTongMongHoGa_R, item.TTCCCCDTHT_ChieuCaoMongDat, item.TTCCCCDTHT_ChieuCaoTuongDat, item.PhuBiHoGa_CDai, item.PhuBiHoGa_CRong);
                    item.TTKLD_KlChiemChoDa = TTKLD_KlChiemChoDa(item.ThongTinChungHoGa_TenHoGaTheoBanVe, item.BeTongLotMong_D, item.TTCCCCDTHT_ChieuCaoLotDa, item.BeTongLotMong_R, item.BeTongMongHoGa_D, item.BeTongMongHoGa_R, item.TTCCCCDTHT_ChieuCaoMongDa, item.TTCCCCDTHT_ChieuCaoTuongDa, item.PhuBiHoGa_CDai, item.PhuBiHoGa_CRong);
                    item.TTKLD_TongChiemCho = TTKLD_TongChiemCho(item.TTKLD_KlChiemChoDat, item.TTKLD_KlChiemChoDa);
                    item.TTKLD_KlDapTraDat = TinhTTKLD_KlDapTraDatHieu(item.TTKLD_KlDaoDat, item.TTKLD_KlChiemChoDat);
                    item.TTKLD_KlDapTraDa = TTKLD_KlDapTraDa(item.TTKLD_KlDaoDa, item.TTKLD_KlChiemChoDa);
                    item.TTKLD_TongDapTra = TTKLD_TongDapTra(item.TTKLD_KlDapTraDat, item.TTKLD_KlDapTraDa);
                    item.TTKLD_KlThuaDat = item.TTKLD_KlChiemChoDat;
                    item.TTKLD_KlThuaDa = item.TTKLD_KlChiemChoDa;
                    item.TTKLD_TongThua = item.TTKLD_KlThuaDat + item.TTKLD_KlThuaDa;

                    item.TTCDSLCauKienDuongTruyenDan_SlCauKienNguyen = TTCDSLCauKienDuongTruyenDan_SlCauKienNguyen(item.ThongTinDuongTruyenDan_HinhThucTruyenDan, item.TTCDSLCauKienDuongTruyenDan_TongChieuDai, item.TTCDSLCauKienDuongTruyenDan_ChieuDai01CauKien, item.TTCDSLCauKienDuongTruyenDan_ChieuDaiMoiNoiCKien);
                    item.TTCDSLCauKienDuongTruyenDan_CDaiCanDeLapDatDuocTheoSoCkNguyen = TTCDSLCauKienDuongTruyenDan_CDaiCanDeLapDatDuocTheoSoCkNguyen(item.ThongTinDuongTruyenDan_HinhThucTruyenDan, item.TTCDSLCauKienDuongTruyenDan_SlCauKienNguyen, item.TTCDSLCauKienDuongTruyenDan_SoLuongCKienDungDeTinhChieuDaiBoSung, item.TTCDSLCauKienDuongTruyenDan_ChieuDaiMoiNoiCKien);
                    item.TTCDSLCauKienDuongTruyenDan_TongCDaiLapDatTheoSoCkNguyen = TTCDSLCauKienDuongTruyenDan_TongCDaiLapDatTheoSoCkNguyen(item.ThongTinDuongTruyenDan_HinhThucTruyenDan, item.TTCDSLCauKienDuongTruyenDan_SlCauKienNguyen, item.TTCDSLCauKienDuongTruyenDan_ChieuDai01CauKien, item.TTCDSLCauKienDuongTruyenDan_CDaiCanDeLapDatDuocTheoSoCkNguyen);
                    item.TTCDSLCauKienDuongTruyenDan_CDaiThucTeConThuaThieuSoVoiCRongLongMuMoHoGa = TTCDSLCauKienDuongTruyenDan_CDaiThucTeConThuaThieuSoVoiCRongLongMuMoHoGa(item.ThongTinDuongTruyenDan_HinhThucTruyenDan, item.TTCDSLCauKienDuongTruyenDan_TongCDaiLapDatTheoSoCkNguyen, item.TTCDSLCauKienDuongTruyenDan_TongChieuDai);
                    item.TTCDSLCauKienDuongTruyenDan_XacDinhOngCongCanThem = TTCDSLCauKienDuongTruyenDan_XacDinhOngCongCanThem(item.TTCDSLCauKienDuongTruyenDan_CDaiThucTeConThuaThieuSoVoiCRongLongMuMoHoGa);
                    item.TTCDSLCauKienDuongTruyenDan_SlCauKienTinhKl = TTCDSLCauKienDuongTruyenDan_SlCauKienTinhKl(item.ThongTinDuongTruyenDan_HinhThucTruyenDan, item.TTCDSLCauKienDuongTruyenDan_XacDinhOngCongCanThem, item.TTCDSLCauKienDuongTruyenDan_SlCauKienNguyen, item.TTCDSLCauKienDuongTruyenDan_SoLuongCKienDungDeTinhChieuDaiBoSung);
                    item.TTCDSLCauKienDuongTruyenDan_CDaiConThuaThieuSauTinhTheoCkTinhKl = TTCDSLCauKienDuongTruyenDan_CDaiConThuaThieuSauTinhTheoCkTinhKl(item.ThongTinDuongTruyenDan_HinhThucTruyenDan, item.TTCDSLCauKienDuongTruyenDan_SlCauKienTinhKl, item.TTCDSLCauKienDuongTruyenDan_SoLuongCKienDungDeTinhChieuDaiBoSung, item.TTCDSLCauKienDuongTruyenDan_ChieuDaiMoiNoiCKien, item.TTCDSLCauKienDuongTruyenDan_ChieuDai01CauKien, item.TTCDSLCauKienDuongTruyenDan_TongChieuDai);

                    item.ThongTinDeCong_TongSoLuongDC = item.ThongTinDeCong_SlDeCong01CauKienTruyenDan * item.TTCDSLCauKienDuongTruyenDan_SlCauKienTinhKl;
                    item.ThongTinDeCong_TongKLDeCong = Math.Round(item.ThongTinDeCong_Kl01DeCong * item.ThongTinDeCong_TongSoLuongDC, 2);

                    item.ThongTinCauTaoCongTron_CCaoCauKien = ThongTinCauTaoCongTron_CCaoCauKien(item.ThongTinCauTaoCongTron_CDayPhuBi, item.ThongTinCauTaoCongTron_SoCanh, item.ThongTinCauTaoCongTron_LongSuDung);
                    item.ThongTinCauTaoCongTron_TongCCaoCong = ThongTinCauTaoCongTron_TongCCaoCong(item.ThongTinCauTaoCongTron_CCaoCauKien, item.ThongTinCauTaoCongTron_CCaoLotMong, item.ThongTinCauTaoCongTron_CCaoMong, item.ThongTinCauTaoCongTron_CCaoDe);


                    item.TTKTHHCongHopRanh_CCaoChatMatTrong = TTKTHHCongHopRanh_CCaoChatMatTrong(item.TTKTHHCongHopRanh_ChatMatTrong, item.TTKTHHCongHopRanh_CauTaoTuong, item.TTKTHHCongHopRanh_CauTaoMuMo, item.TTKTHHCongHopRanh_CCaoTuongGop, item.TTKTHHCongHopRanh_CCaoMuMoThotDuoi, item.TTKTHHCongHopRanh_CCaoMuMoThotTren);
                    item.TTKTHHCongHopRanh_CCaoChatmatNgoai = TTKTHHCongHopRanh_CCaoChatmatNgoai(item.TTKTHHCongHopRanh_ChatMatNgoai, item.TTKTHHCongHopRanh_CauTaoTuong, item.TTKTHHCongHopRanh_CauTaoMuMo, item.TTKTHHCongHopRanh_CCaoTuongGop, item.TTKTHHCongHopRanh_CCaoMuMoThotDuoi, item.TTKTHHCongHopRanh_CCaoMuMoThotTren, item.TTKTHHCongHopRanh_CRongMuMoTren);

                    item.ThongTinKichThuocHinhHocOngNhua_TongCCaoOng = ThongTinKichThuocHinhHocOngNhua_TongCCaoOng(item.ThongTinKichThuocHinhHocOngNhua_CDayPhuBi, item.ThongTinKichThuocHinhHocOngNhua_SoCanh, item.ThongTinKichThuocHinhHocOngNhua_LongSuDung);

                    item.TTTDCongHoRanh_SLCauKienNguyen = TTTDCongHoRanh_SLCauKienNguyen(item.ThongTinDuongTruyenDan_HinhThucTruyenDan, item.TTCDSLCauKienDuongTruyenDan_TongChieuDai, item.TTTDCongHoRanh_CDai, item.TTTDCongHoRanh_ChieuDaiMoiNoi);
                    item.TTTDCongHoRanh_SoLuong = TTTDCongHoRanh_SoLuong(item.ThongTinDuongTruyenDan_HinhThucTruyenDan, item.TTTDCongHoRanh_SLCauKienNguyen);
                    item.TTTDCongHoRanh_ChieuDaiTheoSoCKNguyen = TTTDCongHoRanh_ChieuDaiTheoSoCKNguyen(item.ThongTinDuongTruyenDan_HinhThucTruyenDan, item.TTTDCongHoRanh_SLCauKienNguyen, item.TTTDCongHoRanh_ChieuDaiMoiNoi);
                    item.TTTDCongHoRanh_TongChieuDaiTheoCKNguyen = TTTDCongHoRanh_TongChieuDaiTheoCKNguyen(item.ThongTinDuongTruyenDan_HinhThucTruyenDan, item.TTTDCongHoRanh_SLCauKienNguyen, item.TTTDCongHoRanh_CDai, item.TTTDCongHoRanh_ChieuDaiTheoSoCKNguyen);
                    item.TTTDCongHoRanh_ChieuDaiThucTe = TTTDCongHoRanh_ChieuDaiThucTe(item.ThongTinDuongTruyenDan_HinhThucTruyenDan, item.TTTDCongHoRanh_TongChieuDaiTheoCKNguyen, item.TTCDSLCauKienDuongTruyenDan_TongChieuDai);
                    item.TTTDCongHoRanh_XacDinhOngCongCanThem = TTTDCongHoRanh_XacDinhOngCongCanThem(item.ThongTinDuongTruyenDan_HinhThucTruyenDan, item.TTTDCongHoRanh_ChieuDaiThucTe);
                    item.TTTDCongHoRanh_SoLuong1 = TTTDCongHoRanh_SoLuong1(item.ThongTinDuongTruyenDan_HinhThucTruyenDan, item.TTTDCongHoRanh_XacDinhOngCongCanThem); ;

                    //Chua tinh
                    item.TTTDCongHoRanh_CDai1 = TTTDCongHoRanh_CDai1(item.ThongTinDuongTruyenDan_HinhThucTruyenDan, new List<string> { "Cống hộp", "Rãnh xây", "Rãnh bê tông", "Cống hộp", "Rãnh xây" },
                    new List<double> { 100, 200, 150, 250, 300 },
                    new List<string> { "Thêm 01", "Thêm 01", "Thêm 01", "Thêm 01", "Không thêm" });

                    item.CDThuongLuu_DinhDeCong = CDThuongLuu_DinhDeCong(item.ThongTinMongDuongTruyenDan_LoaiMong, item.CDThuongLuu_DayDongChay, item.ThongTinCauTaoCongTron_CDayPhuBi);
                    item.CDThuongLuu_DinhMongRanh = CDThuongLuu_DinhMongRanh(item.ThongTinDuongTruyenDan_HinhThucTruyenDan, item.ThongTinMongDuongTruyenDan_LoaiMong, item.CDThuongLuu_DayDongChay);
                    item.CDThuongLuu_DinhMongCongHop = CDThuongLuu_DinhMongCongHop(item.ThongTinDuongTruyenDan_HinhThucTruyenDan, item.ThongTinMongDuongTruyenDan_LoaiMong, item.CDThuongLuu_DayDongChay, item.TTKTHHCongHopRanh_CCaoDe);
                    item.CDThuongLuu_DinhMongCongTron = CDThuongLuu_DinhMongCongTron(item.ThongTinDuongTruyenDan_HinhThucTruyenDan, item.ThongTinMongDuongTruyenDan_LoaiMong, item.CDThuongLuu_DayDongChay, item.ThongTinCauTaoCongTron_CDayPhuBi, item.CDThuongLuu_DinhDeCong, item.ThongTinCauTaoCongTron_CCaoDe);
                    item.CDThuongLuu_DinhMongChanKhay = CDThuongLuu_DinhMongChanKhay(item.ThongTinDuongTruyenDan_HinhThucTruyenDan, item.ThongTinRanhThang_CauTaoChanKhay, item.CDThuongLuu_DayDongChay);
                    item.CDThuongLuu_DinhMongRanhThang = CDThuongLuu_DinhMongRanhThang(item.ThongTinDuongTruyenDan_HinhThucTruyenDan, item.ThongTinMongDuongTruyenDan_LoaiMong, item.CDThuongLuu_DayDongChay);
                    item.CDThuongLuu_DinhMongGop = CDThuongLuu_DinhMongGop(item.ThongTinDuongTruyenDan_HinhThucTruyenDan, item.ThongTinMongDuongTruyenDan_LoaiMong, item.CDThuongLuu_DayDongChay, item.ThongTinCauTaoCongTron_CDayPhuBi, item.CDThuongLuu_DinhDeCong, item.ThongTinCauTaoCongTron_CCaoDe, item.TTKTHHCongHopRanh_CCaoDe);
                    item.CDThuongLuu_DinhLotRanh = CDThuongLuu_DinhLotRanh(item.ThongTinDuongTruyenDan_HinhThucTruyenDan, item.ThongTinMongDuongTruyenDan_LoaiMong, item.CDThuongLuu_DinhMongRanh, item.TTKTHHCongHopRanh_CCaoMong);
                    item.CDThuongLuu_DinhLotCongHop = CDThuongLuu_DinhLotCongHop(item.ThongTinDuongTruyenDan_HinhThucTruyenDan, item.ThongTinMongDuongTruyenDan_LoaiMong, item.CDThuongLuu_DinhMongCongHop, item.TTKTHHCongHopRanh_CCaoMong);
                    item.CDThuongLuu_DinhLotCongTron = CDThuongLuu_DinhLotCongTron(item.ThongTinDuongTruyenDan_HinhThucTruyenDan, item.ThongTinMongDuongTruyenDan_LoaiMong, item.CDThuongLuu_DinhMongCongTron, item.ThongTinCauTaoCongTron_CCaoMong);
                    item.CDThuongLuu_DinhLotOngNhua = CDThuongLuu_DinhLotOngNhua(item.ThongTinDuongTruyenDan_HinhThucTruyenDan, item.ThongTinMongDuongTruyenDan_LoaiMong, item.CDThuongLuu_DayDongChay, item.ThongTinKichThuocHinhHocOngNhua_CDayPhuBi);
                    item.CDThuongLuu_DinhLotGiangDinhRanhThang = CDThuongLuu_DinhLotGiangDinhRanhThang(item.ThongTinDuongTruyenDan_HinhThucTruyenDan, item.ThongTinRanhThang_CauTaoGiangDinh, item.CDThuongLuu_DinhRanhThang, item.ThongTinRanhThang_CCaoMongGiangDinh);
                    item.CDThuongLuu_DinhLotChanKhayRanhThang = CDThuongLuu_DinhLotChanKhayRanhThang(item.ThongTinDuongTruyenDan_HinhThucTruyenDan, item.ThongTinRanhThang_CauTaoChanKhay, item.CDThuongLuu_DayDongChay, item.ThongTinRanhThang_CCaoMongChanKhay);
                    item.CDThuongLuu_DinhLotRanhThang = CDThuongLuu_DinhLotRanhThang(item.ThongTinDuongTruyenDan_HinhThucTruyenDan, item.ThongTinMongDuongTruyenDan_LoaiMong, item.CDThuongLuu_DayDongChay, item.ThongTinRanhThang_CCaoMong);
                    item.CDThuongLuu_DinhLotGop = CDThuongLuu_DinhLotGop(item.ThongTinDuongTruyenDan_HinhThucTruyenDan, item.ThongTinMongDuongTruyenDan_LoaiMong, item.CDThuongLuu_DayDongChay, item.ThongTinRanhThang_CCaoMong, item.ThongTinKichThuocHinhHocOngNhua_CDayPhuBi, item.CDThuongLuu_DinhMongCongTron, item.ThongTinCauTaoCongTron_CCaoMong, item.CDThuongLuu_DinhMongCongHop, item.TTKTHHCongHopRanh_CCaoMong, item.CDThuongLuu_DinhMongRanh);
                    item.CDThuongLuu_DayDaoRanhThang = CDThuongLuu_DayDaoRanhThang(item.ThongTinDuongTruyenDan_HinhThucTruyenDan, item.ThongTinMongDuongTruyenDan_LoaiMong, item.CDThuongLuu_DinhLotRanhThang, item.ThongTinRanhThang_CCaoLot, item.CDThuongLuu_DayDongChay);
                    item.CDThuongLuu_DayDaoChanKhayRanhThang = CDThuongLuu_DayDaoChanKhayRanhThang(item.ThongTinDuongTruyenDan_HinhThucTruyenDan, item.ThongTinRanhThang_CauTaoChanKhay, item.CDThuongLuu_DinhLotChanKhayRanhThang, item.ThongTinRanhThang_CCaoLotChanKhay, item.CDThuongLuu_DayDongChay);
                    item.CDThuongLuu_DayDaoGiangDinhRanhThang = CDThuongLuu_DayDaoGiangDinhRanhThang(item.ThongTinDuongTruyenDan_HinhThucTruyenDan, item.ThongTinRanhThang_CauTaoGiangDinh, item.CDThuongLuu_DinhLotGiangDinhRanhThang, item.ThongTinRanhThang_CCaoLotGiangDinh, item.CDThuongLuu_DinhRanhThang);
                    item.CDThuongLuu_DayDaoOngNhua = CDThuongLuu_DayDaoOngNhua(item.ThongTinDuongTruyenDan_HinhThucTruyenDan, item.ThongTinMongDuongTruyenDan_LoaiMong, item.CDThuongLuu_DayDongChay, item.ThongTinKichThuocHinhHocOngNhua_CDayPhuBi, item.CDThuongLuu_DinhLotOngNhua, item.ThongTinKichThuocHinhHocOngNhua_CCaoDemCat);
                    item.CDThuongLuu_DayDaoRanh = CDThuongLuu_DayDaoRanh(item.ThongTinDuongTruyenDan_HinhThucTruyenDan, item.CDThuongLuu_DinhLotRanh, item.TTKTHHCongHopRanh_CCaoLotMong);
                    item.CDThuongLuu_DayDaoCongHop = CDThuongLuu_DayDaoCongHop(item.ThongTinDuongTruyenDan_HinhThucTruyenDan, item.ThongTinMongDuongTruyenDan_LoaiMong, item.CDThuongLuu_DayDongChay, item.TTKTHHCongHopRanh_CCaoDe, item.CDThuongLuu_DinhLotCongHop, item.TTKTHHCongHopRanh_CCaoLotMong);
                    item.CDThuongLuu_DayDaoCongTron = CDThuongLuu_DayDaoCongTron(item.ThongTinDuongTruyenDan_HinhThucTruyenDan, item.ThongTinMongDuongTruyenDan_LoaiMong, item.CDThuongLuu_DayDongChay, item.ThongTinCauTaoCongTron_CDayPhuBi, item.CDThuongLuu_DinhDeCong, item.ThongTinCauTaoCongTron_CCaoDe, item.CDThuongLuu_DinhLotCongTron, item.ThongTinCauTaoCongTron_CCaoLotMong);
                    item.CDThuongLuu_DayDaoGop = CDThuongLuu_DayDaoGop(item.ThongTinDuongTruyenDan_HinhThucTruyenDan, item.ThongTinMongDuongTruyenDan_LoaiMong, item.CDThuongLuu_DayDongChay, item.ThongTinCauTaoCongTron_CDayPhuBi, item.CDThuongLuu_DinhDeCong, item.ThongTinCauTaoCongTron_CCaoDe, item.CDThuongLuu_DinhLotCongTron, item.ThongTinCauTaoCongTron_CCaoLotMong, item.TTKTHHCongHopRanh_CCaoDe, item.CDThuongLuu_DinhLotCongHop, item.TTKTHHCongHopRanh_CCaoLotMong, item.CDThuongLuu_DinhLotRanh, item.ThongTinKichThuocHinhHocOngNhua_CDayPhuBi, item.CDThuongLuu_DinhLotOngNhua, item.ThongTinKichThuocHinhHocOngNhua_CCaoDemCat, item.CDThuongLuu_DinhLotRanhThang, item.ThongTinRanhThang_CCaoLot);
                    item.CDThuongLuu_ChieuSauDao = CDThuongLuu_ChieuSauDao(item.CDThuongLuu_HienTrangTruocKhiDaoThuongLuu, item.CDThuongLuu_DayDaoGop);

                    item.CDThuongLuu_DinhRanhThang = CDThuongLuu_DinhRanhThang(item.ThongTinDuongTruyenDan_HinhThucTruyenDan, item.CDThuongLuu_DayDongChay, item.CDThuongLuu_ChieuCaoRanhThangTuDayDongChayDenDinh);
                    item.CDThuongLuu_DinhCongTron = CDThuongLuu_DinhCongTron(item.ThongTinDuongTruyenDan_HinhThucTruyenDan, item.CDThuongLuu_DinhTrongLongSuDung, item.ThongTinCauTaoCongTron_CDayPhuBi);
                    item.CDThuongLuu_DinhCongHop = CDThuongLuu_DinhCongHop(item.ThongTinDuongTruyenDan_HinhThucTruyenDan, item.CDThuongLuu_DinhTrongLongSuDung, item.TTKTHHCongHopRanh_CCaoMuMoThotTren);
                    item.CDThuongLuu_DinhRanh = CDThuongLuu_DinhRanh(item.ThongTinDuongTruyenDan_HinhThucTruyenDan, item.CDThuongLuu_DinhTrongLongSuDung, item.TTKTHHCongHopRanh_CCaoMuMoThotTren);
                    item.CDThuongLuu_DinhOngNhua = CDThuongLuu_DinhOngNhua(item.ThongTinDuongTruyenDan_HinhThucTruyenDan, item.CDThuongLuu_DinhTrongLongSuDung, item.ThongTinKichThuocHinhHocOngNhua_CDayPhuBi);
                    item.CDThuongLuu_DinhDapCat = CDThuongLuu_DinhDapCat(item.ThongTinDuongTruyenDan_HinhThucTruyenDan, item.CDThuongLuu_DinhOngNhua, item.ThongTinKichThuocHinhHocOngNhua_CCaoDapCat);
                    item.CDThuongLuu_DinhMuMoThotDuoiCongHopRanh = CDThuongLuu_DinhMuMoThotDuoiCongHopRanh(item.ThongTinDuongTruyenDan_HinhThucTruyenDan, item.CDThuongLuu_DinhCongHop, item.CDThuongLuu_DinhRanh, item.TTKTHHCongHopRanh_CCaoMuMoThotTren);
                    item.CDThuongLuu_DinhGiangDinhRanhThang = CDThuongLuu_DinhGiangDinhRanhThang(item.ThongTinDuongTruyenDan_HinhThucTruyenDan, item.ThongTinRanhThang_CauTaoGiangDinh, item.ThongTinRanhThang_CRongMongChanKhay);
                    item.CDThuongLuu_DinhGop = CDThuongLuu_DinhGop(item.ThongTinDuongTruyenDan_HinhThucTruyenDan, item.CDThuongLuu_DinhTrongLongSuDung, item.ThongTinCauTaoCongTron_CDayPhuBi, item.TTKTHHCongHopRanh_CCaoMuMoThotTren, item.ThongTinKichThuocHinhHocOngNhua_CDayPhuBi, item.CDThuongLuu_DayDongChay, item.CDThuongLuu_ChieuCaoRanhThangTuDayDongChayDenDinh);
                    item.CDThuongLuu_DinhTuongCHopRanh = CDThuongLuu_DinhTuongCHopRanh(item.ThongTinDuongTruyenDan_HinhThucTruyenDan, item.CDThuongLuu_DinhMuMoThotDuoiCongHopRanh, item.TTKTHHCongHopRanh_CCaoMuMoThotDuoi);
                    item.CDThuongLuu_CCaoTuongCongRanh = CDThuongLuu_CCaoTuongCongRanh(item.ThongTinDuongTruyenDan_HinhThucTruyenDan, item.CDThuongLuu_DinhTuongCHopRanh, item.CDThuongLuu_DayDongChay);

                    item.CDHaLu_DinhRanhThang = CDHaLu_DinhRanhThang(item.ThongTinDuongTruyenDan_HinhThucTruyenDan, item.CDHaLu_DayDongChay, item.CDHaLu_ChieuCaoRanhThangTuDayDongChayDenDinh);
                    item.CDHaLu_DinhCongTron = CDHaLu_DinhCongTron(item.ThongTinDuongTruyenDan_HinhThucTruyenDan, item.CDHaLu_DinhTrongLongSuDung, item.ThongTinCauTaoCongTron_CDayPhuBi);
                    item.CDHaLu_DinhCongHop = CDHaLu_DinhCongHop(item.ThongTinDuongTruyenDan_HinhThucTruyenDan, item.CDHaLu_DinhTrongLongSuDung, item.TTKTHHCongHopRanh_CCaoMuMoThotTren);
                    item.CDHaLu_DinhRanh = CDHaLu_DinhRanh(item.ThongTinDuongTruyenDan_HinhThucTruyenDan, item.CDHaLu_DinhTrongLongSuDung, item.TTKTHHCongHopRanh_CCaoMuMoThotTren);
                    item.CDHaLu_DinhOngNhua = CDHaLu_DinhOngNhua(item.ThongTinDuongTruyenDan_HinhThucTruyenDan, item.CDHaLu_DinhTrongLongSuDung, item.ThongTinKichThuocHinhHocOngNhua_CDayPhuBi);
                    item.CDHaLu_DinhDapCat = CDHaLu_DinhDapCat(item.ThongTinDuongTruyenDan_HinhThucTruyenDan, item.CDHaLu_DinhOngNhua, item.ThongTinKichThuocHinhHocOngNhua_CCaoDapCat);
                    item.CDHaLu_DinhGop = CDHaLu_DinhGop(item.ThongTinDuongTruyenDan_HinhThucTruyenDan, item.CDHaLu_DinhTrongLongSuDung, item.ThongTinCauTaoCongTron_CDayPhuBi, item.TTKTHHCongHopRanh_CCaoMuMoThotTren, item.ThongTinKichThuocHinhHocOngNhua_CDayPhuBi, item.CDHaLu_DayDongChay, item.CDHaLu_ChieuCaoRanhThangTuDayDongChayDenDinh);
                    item.CDHaLu_DinhGiangDinhRanhThang = CDHaLu_DinhGiangDinhRanhThang(item.ThongTinDuongTruyenDan_HinhThucTruyenDan, item.ThongTinRanhThang_CauTaoGiangDinh, item.CDHaLu_DinhRanhThang);
                    item.CDHaLu_DinhMuMoThotDuoiCongHopRanh = CDHaLu_DinhMuMoThotDuoiCongHopRanh(item.ThongTinDuongTruyenDan_HinhThucTruyenDan, item.CDHaLu_DinhCongHop, item.TTKTHHCongHopRanh_CCaoMuMoThotTren, item.CDHaLu_DinhRanh);
                    item.CDHaLu_DinhTuongCHopRanh = CDHaLu_DinhTuongCHopRanh(item.ThongTinDuongTruyenDan_HinhThucTruyenDan, item.CDHaLu_DinhMuMoThotDuoiCongHopRanh, item.TTKTHHCongHopRanh_CCaoMuMoThotDuoi);
                    item.CDHaLu_CCaoTuongCongRanh = CDHaLu_CCaoTuongCongRanh(item.ThongTinDuongTruyenDan_HinhThucTruyenDan, item.CDHaLu_DinhTuongCHopRanh, item.CDHaLu_DayDongChay);

                    item.TTKTHHCongHopRanh_CCaoTuongRanh = TTKTHHCongHopRanh_CCaoTuongRanh(item.ThongTinDuongTruyenDan_HinhThucTruyenDan, item.CDThuongLuu_CCaoTuongCongRanh, item.CDHaLu_CCaoTuongCongRanh);
                    item.TTKTHHCongHopRanh_CCaoTuongGop = TTKTHHCongHopRanh_CCaoTuongGop(item.TTKTHHCongHopRanh_CCaoTuongCongHop, item.TTKTHHCongHopRanh_CCaoTuongRanh);
                    item.TTKTHHCongHopRanh_TongChieuCao = TTKTHHCongHopRanh_TongChieuCao(item.TTKTHHCongHopRanh_CCaoLotMong, item.TTKTHHCongHopRanh_CCaoMong, item.TTKTHHCongHopRanh_CCaoDe, item.TTKTHHCongHopRanh_CCaoTuongGop, item.TTKTHHCongHopRanh_CCaoMuMoThotDuoi, item.TTKTHHCongHopRanh_CCaoMuMoThotTren);

                    item.CDHaLu_DinhDeCong = CDHaLu_DinhDeCong(item.ThongTinMongDuongTruyenDan_LoaiMong, item.CDHaLu_DayDongChay, item.ThongTinCauTaoCongTron_CDayPhuBi);
                    item.CDHaLu_DinhMongRanh = CDHaLu_DinhMongRanh(item.ThongTinDuongTruyenDan_HinhThucTruyenDan, item.ThongTinMongDuongTruyenDan_LoaiMong, item.CDHaLu_DayDongChay);
                    item.CDHaLu_DinhMongCongHop = CDHaLu_DinhMongCongHop(item.ThongTinDuongTruyenDan_HinhThucTruyenDan, item.ThongTinMongDuongTruyenDan_LoaiMong, item.CDHaLu_DayDongChay, item.TTKTHHCongHopRanh_CCaoDe);
                    item.CDHaLu_DinhMongCongTron = CDHaLu_DinhMongCongTron(item.ThongTinDuongTruyenDan_HinhThucTruyenDan, item.ThongTinMongDuongTruyenDan_LoaiMong, item.CDHaLu_DayDongChay, item.ThongTinCauTaoCongTron_CDayPhuBi, item.CDHaLu_DinhDeCong, item.ThongTinCauTaoCongTron_CCaoDe);
                    item.CDHaLu_DinhMongChanKhay = CDHaLu_DinhMongChanKhay(item.ThongTinDuongTruyenDan_HinhThucTruyenDan, item.ThongTinRanhThang_CauTaoChanKhay, item.CDHaLu_DayDongChay);
                    item.CDHaLu_DinhMongRanhThang = CDHaLu_DinhMongRanhThang(item.ThongTinDuongTruyenDan_HinhThucTruyenDan, item.ThongTinMongDuongTruyenDan_LoaiMong, item.CDHaLu_DayDongChay);
                    item.CDHaLu_DinhMongGop = CDHaLu_DinhMongGop(item.ThongTinDuongTruyenDan_HinhThucTruyenDan, item.ThongTinMongDuongTruyenDan_LoaiMong, item.CDHaLu_DayDongChay, item.ThongTinCauTaoCongTron_CDayPhuBi, item.CDHaLu_DinhDeCong, item.ThongTinCauTaoCongTron_CCaoDe, item.TTKTHHCongHopRanh_CCaoDe);
                    item.CDHaLu_DinhLotRanh = CDHaLu_DinhLotRanh(item.ThongTinDuongTruyenDan_HinhThucTruyenDan, item.ThongTinMongDuongTruyenDan_LoaiMong, item.CDHaLu_DinhMongRanh, item.TTKTHHCongHopRanh_CCaoMong);
                    item.CDHaLu_DinhLotCongHop = CDHaLu_DinhLotCongHop(item.ThongTinDuongTruyenDan_HinhThucTruyenDan, item.ThongTinMongDuongTruyenDan_LoaiMong, item.CDHaLu_DinhMongCongHop, item.TTKTHHCongHopRanh_CCaoMong);
                    item.CDHaLu_DinhLotCongTron = CDHaLu_DinhLotCongTron(item.ThongTinDuongTruyenDan_HinhThucTruyenDan, item.ThongTinMongDuongTruyenDan_LoaiMong, item.CDHaLu_DinhMongCongTron, item.ThongTinCauTaoCongTron_CCaoMong);
                    item.CDHaLu_DinhLotOngNhua = CDHaLu_DinhLotOngNhua(item.ThongTinDuongTruyenDan_HinhThucTruyenDan, item.ThongTinMongDuongTruyenDan_LoaiMong, item.CDHaLu_DayDongChay, item.ThongTinKichThuocHinhHocOngNhua_CDayPhuBi);
                    item.CDHaLu_DinhLotGiangDinhRanhThang = CDHaLu_DinhLotGiangDinhRanhThang(item.ThongTinDuongTruyenDan_HinhThucTruyenDan, item.ThongTinRanhThang_CauTaoGiangDinh, item.CDHaLu_DinhRanhThang, item.ThongTinRanhThang_CCaoMongGiangDinh);
                    item.CDHaLu_DinhLotChanKhayRanhThang = CDHaLu_DinhLotChanKhayRanhThang(item.ThongTinDuongTruyenDan_HinhThucTruyenDan, item.ThongTinRanhThang_CauTaoChanKhay, item.CDHaLu_DayDongChay, item.ThongTinRanhThang_CCaoMongChanKhay);
                    item.CDHaLu_DinhLotRanhThang = CDHaLu_DinhLotRanhThang(item.ThongTinDuongTruyenDan_HinhThucTruyenDan, item.ThongTinMongDuongTruyenDan_LoaiMong, item.CDHaLu_DayDongChay, item.ThongTinRanhThang_CCaoMong);
                    item.CDHaLu_DinhLotGop = CDHaLu_DinhLotGop(item.ThongTinDuongTruyenDan_HinhThucTruyenDan, item.ThongTinMongDuongTruyenDan_LoaiMong, item.CDHaLu_DayDongChay, item.ThongTinRanhThang_CCaoMong, item.ThongTinKichThuocHinhHocOngNhua_CDayPhuBi, item.CDHaLu_DinhMongCongTron, item.ThongTinCauTaoCongTron_CCaoMong, item.CDHaLu_DinhMongCongHop, item.TTKTHHCongHopRanh_CCaoMong, item.CDHaLu_DinhMongRanh);
                    item.CDHaLu_DayDaoRanhThang = CDHaLu_DayDaoRanhThang(item.ThongTinDuongTruyenDan_HinhThucTruyenDan, item.ThongTinMongDuongTruyenDan_LoaiMong, item.CDHaLu_DinhLotRanhThang, item.ThongTinRanhThang_CCaoLot, item.CDHaLu_DayDongChay);
                    item.CDHaLu_DayDaoChanKhayRanhThang = CDHaLu_DayDaoChanKhayRanhThang(item.ThongTinDuongTruyenDan_HinhThucTruyenDan, item.ThongTinRanhThang_CauTaoChanKhay, item.CDHaLu_DinhLotChanKhayRanhThang, item.ThongTinRanhThang_CCaoLotChanKhay, item.CDHaLu_DayDongChay);
                    item.CDHaLu_DayDaoGiangDinhRanhThang = CDHaLu_DayDaoGiangDinhRanhThang(item.ThongTinDuongTruyenDan_HinhThucTruyenDan, item.ThongTinRanhThang_CauTaoGiangDinh, item.CDHaLu_DinhLotGiangDinhRanhThang, item.ThongTinRanhThang_CCaoLotGiangDinh, item.CDHaLu_DinhRanhThang);
                    item.CDHaLu_DayDaoOngNhua = CDHaLu_DayDaoOngNhua(item.ThongTinDuongTruyenDan_HinhThucTruyenDan, item.ThongTinMongDuongTruyenDan_LoaiMong, item.CDHaLu_DayDongChay, item.ThongTinKichThuocHinhHocOngNhua_CDayPhuBi, item.CDHaLu_DinhLotOngNhua, item.ThongTinKichThuocHinhHocOngNhua_CCaoDemCat);
                    item.CDHaLu_DayDaoRanh = CDHaLu_DayDaoRanh(item.ThongTinDuongTruyenDan_HinhThucTruyenDan, item.CDHaLu_DinhLotRanh, item.TTKTHHCongHopRanh_CCaoLotMong);
                    item.CDHaLu_DayDaoCongHop = CDHaLu_DayDaoCongHop(item.ThongTinDuongTruyenDan_HinhThucTruyenDan, item.ThongTinMongDuongTruyenDan_LoaiMong, item.CDHaLu_DayDongChay, item.TTKTHHCongHopRanh_CCaoDe, item.CDHaLu_DinhLotCongHop, item.TTKTHHCongHopRanh_CCaoLotMong);
                    item.CDHaLu_DayDaoCongTron = CDHaLu_DayDaoCongTron(item.ThongTinDuongTruyenDan_HinhThucTruyenDan, item.ThongTinMongDuongTruyenDan_LoaiMong, item.CDHaLu_DayDongChay, item.ThongTinCauTaoCongTron_CDayPhuBi, item.CDHaLu_DinhDeCong, item.ThongTinCauTaoCongTron_CCaoDe, item.CDHaLu_DinhLotCongTron, item.ThongTinCauTaoCongTron_CCaoLotMong);
                    item.CDHaLu_DayDaoGop = CDHaLu_DayDaoGop(item.ThongTinDuongTruyenDan_HinhThucTruyenDan, item.ThongTinMongDuongTruyenDan_LoaiMong, item.CDHaLu_DayDongChay, item.ThongTinCauTaoCongTron_CDayPhuBi, item.CDHaLu_DinhDeCong, item.ThongTinCauTaoCongTron_CCaoDe,item.CDHaLu_DinhLotCongTron, item.ThongTinCauTaoCongTron_CCaoLotMong, item.TTKTHHCongHopRanh_CCaoDe, item.CDHaLu_DinhLotCongHop, item.TTKTHHCongHopRanh_CCaoLotMong,item.CDHaLu_DinhLotRanh, item.ThongTinKichThuocHinhHocOngNhua_CDayPhuBi, item.CDHaLu_DinhLotOngNhua, item.ThongTinKichThuocHinhHocOngNhua_CCaoDemCat, item.CDHaLu_DinhLotRanhThang, item.ThongTinRanhThang_CCaoLot);
                    item.CDHaLu_ChieuSauDao = CDHaLu_ChieuSauDao(item.CDHaLu_DayDaoGop, item.CDHaLu_HienTrangTruocKhiDaoHaLuu);

                    item.TTVLDCongRanh_TLChieuCaoDaoDat = TTVLDCongRanh_TLChieuCaoDaoDat(item.TTVLDCongRanh_LoaiVatLieuDao, item.CDThuongLuu_ChieuSauDao, item.TTVLDCongRanh_TLChieuCaoDaoDa);
                    item.TTVLDCongRanh_TLTongChieuSauDao = Math.Round(item.TTVLDCongRanh_TLChieuCaoDaoDa + item.TTVLDCongRanh_TLChieuCaoDaoDat, 2);
                    item.TTVLDCongRanh_HLChieuCaoDaoDat = TTVLDCongRanh_HLChieuCaoDaoDat(item.TTVLDCongRanh_LoaiVatLieuDao, item.CDHaLu_ChieuSauDao, item.TTVLDCongRanh_HLChieuCaoDaoDa);
                    item.TTVLDCongRanh_HLTongChieuSauDao = Math.Round(item.TTVLDCongRanh_HLChieuCaoDaoDa + item.TTVLDCongRanh_HLChieuCaoDaoDat,2);

                    item.TTCCCCT_CCaoLotDatTLuu = TTCCCCT_CCaoLotDatTLuu(item.TTVLDCongRanh_LoaiVatLieuDao, item.TTVLDCongRanh_TLChieuCaoDaoDat, item.ThongTinCauTaoCongTron_CCaoLotMong);
                    item.TTCCCCT_CCaoLotDatHLuu = TTCCCCT_CCaoLotDatHLuu(item.TTVLDCongRanh_LoaiVatLieuDao, item.TTVLDCongRanh_HLChieuCaoDaoDat, item.ThongTinCauTaoCongTron_CCaoLotMong);
                    item.TTCCCCT_CCaoLotDatMongTBinh = (item.TTCCCCT_CCaoLotDatTLuu + item.TTCCCCT_CCaoLotDatHLuu) / 2;
                    item.TTCCCCT_CCaoLotDaTLuu = TTCCCCT_CCaoLotDaTLuu(item.TTVLDCongRanh_LoaiVatLieuDao, item.TTVLDCongRanh_TLChieuCaoDaoDa, item.TTVLDCongRanh_TLTongChieuSauDao, item.TTCCCCT_CCaoLotDatTLuu, item.ThongTinCauTaoCongTron_CCaoLotMong);
                    item.TTCCCCT_CCaoLotDaHLuu = TTCCCCT_CCaoLotDaHLuu(item.TTVLDCongRanh_LoaiVatLieuDao, item.TTVLDCongRanh_HLChieuCaoDaoDa, item.TTVLDCongRanh_HLTongChieuSauDao, item.TTCCCCT_CCaoLotDatHLuu, item.ThongTinCauTaoCongTron_CCaoLotMong);
                    item.TTCCCCT_CCaoLotDaMongTBinh = (item.TTCCCCT_CCaoLotDaTLuu + item.TTCCCCT_CCaoLotDaHLuu) / 2;
                    item.TTCCCCT_CCaoMongDatTLuu = TTCCCCT_CCaoMongDatTLuu(item.TTVLDCongRanh_LoaiVatLieuDao, item.TTVLDCongRanh_TLChieuCaoDaoDat, item.ThongTinCauTaoCongTron_CCaoLotMong, item.ThongTinCauTaoCongTron_CCaoMong);
                    item.TTCCCCT_CCaoMongDatHLuu = TTCCCCT_CCaoMongDatHLuu(item.TTVLDCongRanh_LoaiVatLieuDao, item.TTVLDCongRanh_HLChieuCaoDaoDat, item.ThongTinCauTaoCongTron_CCaoLotMong, item.ThongTinCauTaoCongTron_CCaoMong);
                    item.TTCCCCT_CCaoMongDatTBinh = (item.TTCCCCT_CCaoMongDatTLuu + item.TTCCCCT_CCaoMongDatHLuu) / 2;
                    item.TTCCCCT_CCaoMongDaTLuu = TTCCCCT_CCaoMongDaTLuu(item.TTVLDCongRanh_LoaiVatLieuDao, item.TTVLDCongRanh_TLChieuCaoDaoDa, item.ThongTinCauTaoCongTron_CCaoLotMong, item.ThongTinCauTaoCongTron_CCaoMong, item.TTVLDCongRanh_TLTongChieuSauDao, item.TTCCCCT_CCaoMongDatTLuu, item.TTCCCCT_CCaoLotDaTLuu);
                    item.TTCCCCT_CCaoMongDaHLuu = TTCCCCT_CCaoMongDaHLuu(item.TTVLDCongRanh_LoaiVatLieuDao, item.TTVLDCongRanh_HLChieuCaoDaoDa, item.ThongTinCauTaoCongTron_CCaoLotMong, item.ThongTinCauTaoCongTron_CCaoMong, item.TTVLDCongRanh_HLTongChieuSauDao, item.TTCCCCT_CCaoMongDatHLuu, item.TTCCCCT_CCaoLotDaHLuu);
                    item.TTCCCCT_CCaoMongDaTBinh = (item.TTCCCCT_CCaoMongDaTLuu + item.TTCCCCT_CCaoMongDaHLuu) / 2;
                    item.TTCCCCT_CCaoDeDatTLuu = TTCCCCT_CCaoDeDatTLuu(item.TTVLDCongRanh_LoaiVatLieuDao, item.TTVLDCongRanh_TLChieuCaoDaoDat, item.ThongTinCauTaoCongTron_CCaoLotMong, item.ThongTinCauTaoCongTron_CCaoMong, item.ThongTinCauTaoCongTron_CCaoDe);
                    item.TTCCCCT_CCaoDeDatHLuu = TTCCCCT_CCaoDeDatHLuu(item.TTVLDCongRanh_LoaiVatLieuDao, item.TTVLDCongRanh_HLChieuCaoDaoDat, item.ThongTinCauTaoCongTron_CCaoLotMong, item.ThongTinCauTaoCongTron_CCaoMong, item.ThongTinCauTaoCongTron_CCaoDe);
                    item.TTCCCCT_CCaoDeDatTBinh = (item.TTCCCCT_CCaoDeDatTLuu + item.TTCCCCT_CCaoDeDatHLuu) / 2;
                    item.TTCCCCT_CCaoDeDaTLuu = TTCCCCT_CCaoDeDaTLuu(item.TTVLDCongRanh_LoaiVatLieuDao, item.TTVLDCongRanh_TLChieuCaoDaoDa, item.ThongTinCauTaoCongTron_CCaoLotMong, item.ThongTinCauTaoCongTron_CCaoMong, item.ThongTinCauTaoCongTron_CCaoDe, item.TTVLDCongRanh_TLTongChieuSauDao, item.TTCCCCT_CCaoDeDatTLuu, item.TTCCCCT_CCaoLotDaTLuu, item.TTCCCCT_CCaoMongDaTLuu);
                    item.TTCCCCT_CCaoDeDaHLuu = TTCCCCT_CCaoDeDaHLuu(item.TTVLDCongRanh_LoaiVatLieuDao, item.TTVLDCongRanh_HLChieuCaoDaoDa, item.ThongTinCauTaoCongTron_CCaoLotMong, item.ThongTinCauTaoCongTron_CCaoMong, item.ThongTinCauTaoCongTron_CCaoDe, item.TTVLDCongRanh_HLTongChieuSauDao, item.TTCCCCT_CCaoDeDatHLuu, item.TTCCCCT_CCaoLotDaHLuu, item.TTCCCCT_CCaoMongDaHLuu);
                    item.TTCCCCT_CCaoDeDaTBinh = (item.TTCCCCT_CCaoDeDaTLuu + item.TTCCCCT_CCaoDeDaHLuu) / 2;
                    item.TTCCCCT_CCaoCongDatTLuu = TTCCCCT_CCaoCongDatTLuu(item.TTVLDCongRanh_LoaiVatLieuDao, item.TTVLDCongRanh_TLChieuCaoDaoDat, item.ThongTinCauTaoCongTron_CCaoLotMong, item.ThongTinCauTaoCongTron_CCaoMong, item.ThongTinCauTaoCongTron_CCaoDe, item.ThongTinCauTaoCongTron_TongCCaoCong);
                    item.TTCCCCT_CCaoCongDatHLuu = TTCCCCT_CCaoCongDatHLuu(item.TTVLDCongRanh_LoaiVatLieuDao, item.TTVLDCongRanh_HLChieuCaoDaoDat, item.ThongTinCauTaoCongTron_CCaoLotMong, item.ThongTinCauTaoCongTron_CCaoMong, item.ThongTinCauTaoCongTron_CCaoDe, item.ThongTinCauTaoCongTron_TongCCaoCong);
                    item.TTCCCCT_CCongCongDatTBinh = (item.TTCCCCT_CCaoCongDatTLuu + item.TTCCCCT_CCaoCongDatHLuu) / 2;
                    item.TTCCCCT_CCaoCongDaTLuu = TTCCCCT_CCaoCongDaTLuu(item.TTVLDCongRanh_LoaiVatLieuDao, item.TTVLDCongRanh_TLChieuCaoDaoDa, item.TTVLDCongRanh_TLTongChieuSauDao, item.TTCCCCT_CCaoCongDatTLuu, item.ThongTinCauTaoCongTron_CCaoCauKien, item.ThongTinCauTaoCongTron_TongCCaoCong, item.ThongTinCauTaoCongTron_CCaoLotMong, item.ThongTinCauTaoCongTron_CCaoMong, item.ThongTinCauTaoCongTron_CCaoDe, item.TTCCCCT_CCaoLotDaTLuu, item.TTCCCCT_CCaoMongDaTLuu, item.TTCCCCT_CCaoDeDaTLuu);
                    item.TTCCCCT_CCaoCongDaHLuu = TTCCCCT_CCaoCongDaHLuu(item.TTVLDCongRanh_LoaiVatLieuDao, item.TTVLDCongRanh_HLChieuCaoDaoDa, item.TTVLDCongRanh_HLTongChieuSauDao, item.TTCCCCT_CCaoCongDatHLuu, item.ThongTinCauTaoCongTron_CCaoCauKien, item.ThongTinCauTaoCongTron_TongCCaoCong, item.ThongTinCauTaoCongTron_CCaoLotMong, item.ThongTinCauTaoCongTron_CCaoMong, item.ThongTinCauTaoCongTron_CCaoDe, item.TTCCCCT_CCaoLotDaHLuu, item.TTCCCCT_CCaoMongDaHLuu, item.TTCCCCT_CCaoDeDaHLuu);
                    item.TTCCCCT_CCongCongDaTBinh = (item.TTCCCCT_CCaoCongDaTLuu + item.TTCCCCT_CCaoCongDaHLuu) / 2;

                    item.TTCCCCCHR_CCaoLotDatTLuu = TTCCCCCHR_CCaoLotDatTLuu(item.TTVLDCongRanh_LoaiVatLieuDao, item.TTVLDCongRanh_TLChieuCaoDaoDat, item.TTKTHHCongHopRanh_CCaoLotMong);
                    item.TTCCCCCHR_CCaoLotDatHLuu = TTCCCCCHR_CCaoLotDatHLuu(item.TTVLDCongRanh_LoaiVatLieuDao, item.TTVLDCongRanh_HLChieuCaoDaoDat, item.TTKTHHCongHopRanh_CCaoLotMong);
                    item.TTCCCCCHR_CCaoLotDatTBinh = (item.TTCCCCCHR_CCaoLotDatTLuu + item.TTCCCCCHR_CCaoLotDatHLuu) / 2;
                    item.TTCCCCCHR_CCaoLotDaTLuu = TTCCCCCHR_CCaoLotDaTLuu(item.TTVLDCongRanh_LoaiVatLieuDao, item.TTVLDCongRanh_TLChieuCaoDaoDa, item.TTVLDCongRanh_TLTongChieuSauDao, item.TTKTHHCongHopRanh_CCaoLotMong, item.TTCCCCCHR_CCaoLotDatTLuu);
                    item.TTCCCCCHR_CCaoLotDaHLuu = TTCCCCCHR_CCaoLotDaHLuu(item.TTVLDCongRanh_LoaiVatLieuDao, item.TTVLDCongRanh_HLChieuCaoDaoDa, item.TTVLDCongRanh_HLTongChieuSauDao, item.TTKTHHCongHopRanh_CCaoLotMong, item.TTCCCCCHR_CCaoLotDatHLuu);
                    item.TTCCCCCHR_CCaoLotDaTBinh = (item.TTCCCCCHR_CCaoLotDaTLuu + item.TTCCCCCHR_CCaoLotDaHLuu) / 2;
                    item.TTCCCCCHR_CCaoMongDatTLuu = TTCCCCCHR_CCaoMongDatTLuu(item.TTVLDCongRanh_LoaiVatLieuDao, item.TTVLDCongRanh_TLChieuCaoDaoDat, item.TTKTHHCongHopRanh_CCaoLotMong, item.TTKTHHCongHopRanh_CCaoMong);
                    item.TTCCCCCHR_CCaoMongDatHLuu = TTCCCCCHR_CCaoMongDatHLuu(item.TTVLDCongRanh_LoaiVatLieuDao, item.TTVLDCongRanh_HLChieuCaoDaoDat, item.TTKTHHCongHopRanh_CCaoLotMong, item.TTKTHHCongHopRanh_CCaoMong);
                    item.TTCCCCCHR_CCaoMongDatTBinh = (item.TTCCCCCHR_CCaoMongDatTLuu + item.TTCCCCCHR_CCaoMongDatHLuu) / 2;
                    item.TTCCCCCHR_CCaoMongDaTLuu = TTCCCCCHR_CCaoMongDaTLuu(item.TTVLDCongRanh_LoaiVatLieuDao, item.TTVLDCongRanh_TLChieuCaoDaoDa, item.TTKTHHCongHopRanh_CCaoLotMong, item.TTKTHHCongHopRanh_CCaoMong, item.TTVLDCongRanh_TLTongChieuSauDao, item.TTCCCCCHR_CCaoMongDatTLuu, item.TTCCCCCHR_CCaoLotDaTLuu);
                    item.TTCCCCCHR_CCaoMongDaHLuu = TTCCCCCHR_CCaoMongDaHLuu(item.TTVLDCongRanh_LoaiVatLieuDao, item.TTVLDCongRanh_HLChieuCaoDaoDa, item.TTKTHHCongHopRanh_CCaoLotMong, item.TTKTHHCongHopRanh_CCaoMong, item.TTVLDCongRanh_HLTongChieuSauDao, item.TTCCCCCHR_CCaoMongDatHLuu, item.TTCCCCCHR_CCaoLotDaHLuu);
                    item.TTCCCCCHR_CCaoMongDaTBinh = (item.TTCCCCCHR_CCaoMongDaTLuu + item.TTCCCCCHR_CCaoMongDaHLuu) / 2;
                    item.TTCCCCCHR_CCaoTuongDatTLuu = TTCCCCCHR_CCaoTuongDatTLuu(item.TTVLDCongRanh_LoaiVatLieuDao, item.TTVLDCongRanh_TLChieuCaoDaoDat, item.TTKTHHCongHopRanh_CCaoLotMong, item.TTKTHHCongHopRanh_CCaoMong, item.TTKTHHCongHopRanh_TongChieuCao);
                    item.TTCCCCCHR_CCaoTuongDatHLuu = TTCCCCCHR_CCaoTuongDatHLuu(item.TTVLDCongRanh_LoaiVatLieuDao, item.TTVLDCongRanh_HLChieuCaoDaoDat, item.TTKTHHCongHopRanh_CCaoLotMong, item.TTKTHHCongHopRanh_CCaoMong, item.TTKTHHCongHopRanh_TongChieuCao);
                    item.TTCCCCCHR_CCaoTuongDatTBinh = (item.TTCCCCCHR_CCaoTuongDatTLuu + item.TTCCCCCHR_CCaoTuongDatHLuu) / 2;
                    item.TTCCCCCHR_CCaoTuongDaTLuu = TTCCCCCHR_CCaoTuongDaTLuu(item.TTVLDCongRanh_LoaiVatLieuDao, item.TTVLDCongRanh_TLChieuCaoDaoDa, item.TTKTHHCongHopRanh_CCaoLotMong, item.TTKTHHCongHopRanh_CCaoMong, item.TTKTHHCongHopRanh_TongChieuCao, item.TTVLDCongRanh_TLTongChieuSauDao, item.TTCCCCCHR_CCaoTuongDatTLuu, item.TTCCCCCHR_CCaoLotDaTLuu, item.TTCCCCCHR_CCaoMongDaTLuu);
                    item.TTCCCCCHR_CCaoTuongDaHLuu = TTCCCCCHR_CCaoTuongDaHLuu(item.TTVLDCongRanh_LoaiVatLieuDao, item.TTVLDCongRanh_HLChieuCaoDaoDa, item.TTKTHHCongHopRanh_CCaoLotMong, item.TTKTHHCongHopRanh_CCaoMong, item.TTKTHHCongHopRanh_TongChieuCao, item.TTVLDCongRanh_HLTongChieuSauDao, item.TTCCCCCHR_CCaoTuongDatHLuu, item.TTCCCCCHR_CCaoLotDaHLuu, item.TTCCCCCHR_CCaoMongDaHLuu);
                    item.TTCCCCCHR_CCaoTuongDaTBinh = (item.TTCCCCCHR_CCaoTuongDaTLuu + item.TTCCCCCHR_CCaoTuongDaHLuu) / 2;
                    item.TTCCCCON_CCaoDemCatDatTLuu = TTCCCCON_CCaoDemCatDatTLuu(item.TTVLDCongRanh_LoaiVatLieuDao, item.TTVLDCongRanh_TLChieuCaoDaoDat, item.ThongTinKichThuocHinhHocOngNhua_CCaoDemCat);
                    item.TTCCCCON_CCaoDemCatDatHLuu = TTCCCCON_CCaoDemCatDatHLuu(item.TTVLDCongRanh_LoaiVatLieuDao, item.TTVLDCongRanh_HLChieuCaoDaoDat, item.ThongTinKichThuocHinhHocOngNhua_CCaoDemCat);
                    item.TTCCCCON_CCaoDemCatDatTBinh = (item.TTCCCCON_CCaoDemCatDatTLuu + item.TTCCCCON_CCaoDemCatDatHLuu) / 2;
                    item.TTCCCCON_CCaoDemCatDaTLuu = TTCCCCON_CCaoDemCatDaTLuu(item.TTVLDCongRanh_LoaiVatLieuDao, item.TTVLDCongRanh_TLChieuCaoDaoDa, item.TTVLDCongRanh_TLTongChieuSauDao, item.ThongTinKichThuocHinhHocOngNhua_CCaoDemCat, item.TTCCCCON_CCaoDemCatDatTLuu);
                    item.TTCCCCON_CCaoDemCatDaHLuu = TTCCCCON_CCaoDemCatDaHLuu(item.TTVLDCongRanh_LoaiVatLieuDao, item.TTVLDCongRanh_HLChieuCaoDaoDa, item.TTVLDCongRanh_HLTongChieuSauDao, item.ThongTinKichThuocHinhHocOngNhua_CCaoDemCat, item.TTCCCCON_CCaoDemCatDatHLuu);
                    item.TTCCCCON_CCaoDemCatDaTBinh = (item.TTCCCCON_CCaoDemCatDaTLuu + item.TTCCCCON_CCaoDemCatDaHLuu) / 2;
                    item.TTCCCCON_CCaoOngDatTLuu = TTCCCCON_CCaoOngDatTLuu(item.TTVLDCongRanh_LoaiVatLieuDao, item.TTVLDCongRanh_TLChieuCaoDaoDat, item.ThongTinKichThuocHinhHocOngNhua_CCaoDemCat, item.ThongTinKichThuocHinhHocOngNhua_TongCCaoOng);
                    item.TTCCCCON_CCaoOngDatHLuu = TTCCCCON_CCaoOngDatHLuu(item.TTVLDCongRanh_LoaiVatLieuDao, item.TTVLDCongRanh_HLChieuCaoDaoDat, item.ThongTinKichThuocHinhHocOngNhua_CCaoDemCat, item.ThongTinKichThuocHinhHocOngNhua_TongCCaoOng);
                    item.TTCCCCON_CCaoDatTBinh = (item.TTCCCCON_CCaoOngDatTLuu + item.TTCCCCON_CCaoOngDatHLuu) / 2;
                    item.TTCCCCON_CCaoOngDaTLuu = TTCCCCON_CCaoOngDaTLuu(item.TTVLDCongRanh_LoaiVatLieuDao, item.TTVLDCongRanh_TLChieuCaoDaoDa, item.ThongTinKichThuocHinhHocOngNhua_CCaoDemCat, item.ThongTinKichThuocHinhHocOngNhua_TongCCaoOng, item.TTVLDCongRanh_TLTongChieuSauDao, item.TTCCCCON_CCaoOngDatTLuu, item.TTCCCCON_CCaoDemCatDaTLuu);
                    item.TTCCCCON_CCaoOngDaHLuu = TTCCCCON_CCaoOngDaHLuu(item.TTVLDCongRanh_LoaiVatLieuDao, item.TTVLDCongRanh_HLChieuCaoDaoDa, item.ThongTinKichThuocHinhHocOngNhua_CCaoDemCat, item.ThongTinKichThuocHinhHocOngNhua_TongCCaoOng, item.TTVLDCongRanh_HLTongChieuSauDao, item.TTCCCCON_CCaoOngDatHLuu, item.TTCCCCON_CCaoDemCatDaHLuu);
                    item.TTCCCCON_CCaoDaTBinh = (item.TTCCCCON_CCaoOngDaTLuu + item.TTCCCCON_CCaoOngDaHLuu) / 2;
                    item.TTCCCCON_CCaoDapCatDatTLuu = TTCCCCON_CCaoDapCatDatTLuu(item.TTVLDCongRanh_LoaiVatLieuDao, item.TTVLDCongRanh_TLChieuCaoDaoDat, item.ThongTinKichThuocHinhHocOngNhua_CCaoDemCat, item.ThongTinKichThuocHinhHocOngNhua_TongCCaoOng, item.ThongTinKichThuocHinhHocOngNhua_CCaoDapCat);
                    item.TTCCCCON_CCaoDapCatDatHLuu = TTCCCCON_CCaoDapCatDatHLuu(item.TTVLDCongRanh_LoaiVatLieuDao, item.TTVLDCongRanh_HLChieuCaoDaoDat, item.ThongTinKichThuocHinhHocOngNhua_CCaoDemCat, item.ThongTinKichThuocHinhHocOngNhua_TongCCaoOng, item.ThongTinKichThuocHinhHocOngNhua_CCaoDapCat);
                    item.TTCCCCON_CCaoDapCatDatTBinh = (item.TTCCCCON_CCaoDapCatDatTLuu + item.TTCCCCON_CCaoDapCatDatHLuu) / 2;
                    item.TTCCCCON_CCaoDapCatDaTLuu = TTCCCCON_CCaoDapCatDaTLuu(item.TTVLDCongRanh_LoaiVatLieuDao, item.TTVLDCongRanh_TLChieuCaoDaoDa, item.ThongTinKichThuocHinhHocOngNhua_TongCCaoOng, item.ThongTinKichThuocHinhHocOngNhua_CCaoDemCat, item.ThongTinKichThuocHinhHocOngNhua_CCaoDapCat, item.TTVLDCongRanh_TLTongChieuSauDao, item.TTCCCCON_CCaoDapCatDatTLuu, item.TTCCCCON_CCaoDemCatDaTLuu, item.TTCCCCON_CCaoOngDaTLuu);
                    item.TTCCCCON_CCaoDapCatDaHLuu = TTCCCCON_CCaoDapCatDaHLuu(item.TTVLDCongRanh_LoaiVatLieuDao, item.TTVLDCongRanh_HLChieuCaoDaoDa, item.ThongTinKichThuocHinhHocOngNhua_TongCCaoOng, item.ThongTinKichThuocHinhHocOngNhua_CCaoDemCat, item.ThongTinKichThuocHinhHocOngNhua_CCaoDapCat, item.TTVLDCongRanh_HLTongChieuSauDao, item.TTCCCCON_CCaoDapCatDatHLuu, item.TTCCCCON_CCaoDemCatDaTLuu, item.TTCCCCON_CCaoOngDaTLuu);
                    item.TTCCCCON_CCaoDapCatDaTBinh = (item.TTCCCCON_CCaoDapCatDaTLuu + item.TTCCCCON_CCaoDapCatDaHLuu) / 2;
                    item.TTCCRT_LotDatThuongLuu = TTCCRT_LotDatThuongLuu(item.TTVLDCongRanh_LoaiVatLieuDao, item.TTVLDCongRanh_TLChieuCaoDaoDat, item.ThongTinRanhThang_CCaoLot);
                    item.TTCCRT_LotDatHaLuu = TTCCRT_LotDatHaLuu(item.TTVLDCongRanh_LoaiVatLieuDao, item.TTVLDCongRanh_HLChieuCaoDaoDat, item.ThongTinRanhThang_CCaoLot);
                    item.TTCCRT_LotDatTrungBinh = (item.TTCCRT_LotDatThuongLuu + item.TTCCRT_LotDatHaLuu) / 2;
                    item.TTCCRT_LotDaThuongLuu = TTCCRT_LotDaThuongLuu(item.TTVLDCongRanh_LoaiVatLieuDao, item.TTVLDCongRanh_TLChieuCaoDaoDa, item.TTVLDCongRanh_TLTongChieuSauDao, item.ThongTinRanhThang_CCaoLot, item.TTCCRT_LotDatThuongLuu);
                    item.TTCCRT_LotDaHaLuu = TTCCRT_LotDaHaLuu(item.TTVLDCongRanh_LoaiVatLieuDao, item.TTVLDCongRanh_HLChieuCaoDaoDa, item.TTVLDCongRanh_HLTongChieuSauDao, item.ThongTinRanhThang_CCaoLot, item.TTCCRT_LotDatHaLuu);
                    item.TTCCRT_LotDaTrungBinh = (item.TTCCRT_LotDaThuongLuu + item.TTCCRT_LotDaHaLuu) / 2;
                    item.TTCCRT_MongDatThuongLuu = TTCCRT_MongDatThuongLuu(item.TTVLDCongRanh_LoaiVatLieuDao, item.TTVLDCongRanh_TLChieuCaoDaoDat, item.ThongTinRanhThang_CCaoLot, item.ThongTinRanhThang_CCaoMong);
                    item.TTCCRT_MongDatHaLuu = TTCCRT_MongDatHaLuu(item.TTVLDCongRanh_LoaiVatLieuDao, item.TTVLDCongRanh_HLChieuCaoDaoDat, item.ThongTinRanhThang_CCaoLot, item.ThongTinRanhThang_CCaoMong);
                    item.TTCCRT_MongDatTrungBinh = (item.TTCCRT_MongDatThuongLuu + item.TTCCRT_MongDatHaLuu) / 2;
                    item.TTCCRT_MongDaThuongLuu = TTCCRT_MongDaThuongLuu(item.TTVLDCongRanh_LoaiVatLieuDao, item.TTVLDCongRanh_TLChieuCaoDaoDa, item.ThongTinRanhThang_CCaoLot, item.ThongTinRanhThang_CCaoMong, item.TTVLDCongRanh_TLTongChieuSauDao, item.TTCCRT_MongDatThuongLuu, item.TTCCRT_LotDaThuongLuu);
                    item.TTCCRT_MongDaHaLuu = TTCCRT_MongDaHaLuu(item.TTVLDCongRanh_LoaiVatLieuDao, item.TTVLDCongRanh_HLChieuCaoDaoDa, item.ThongTinRanhThang_CCaoLot, item.ThongTinRanhThang_CCaoMong, item.TTVLDCongRanh_HLTongChieuSauDao, item.TTCCRT_MongDatHaLuu, item.TTCCRT_LotDaHaLuu);
                    item.TTCCRT_MongDaTrungBinh = (item.TTCCRT_MongDaThuongLuu + item.TTCCRT_MongDaHaLuu) / 2;

                    item.DTDTLCRONRT_CRongDaoDatDayLon = DTDTLCRONRT_CRongDaoDatDayLon(item.TTVLDCongRanh_TLChieuCaoDaoDat, item.TTMDRanhOngThang_TyLeMoMai, item.TTMDRanhOngThang_SoCanhMaiTrai, item.TTMDRanhOngThang_SoCanhMaiPhai, item.TTMDRanhOngThang_ChieuRongDayDaoNho);
                    item.DTDTLCRONRT_DTichDaoDat = DTDTLCRONRT_DTichDaoDat(item.DTDTLCRONRT_CRongDaoDatDayLon, item.TTMDRanhOngThang_ChieuRongDayDaoNho, item.TTVLDCongRanh_TLChieuCaoDaoDat);
                    item.DTDTLCRONRT_CRongDaoDaDayLon = DTDTLCRONRT_CRongDaoDaDayLon(item.TTVLDCongRanh_TLChieuCaoDaoDa, item.TTMDRanhOngThang_TyLeMoMai, item.TTMDRanhOngThang_SoCanhMaiTrai, item.TTMDRanhOngThang_SoCanhMaiPhai, item.DTDTLCRONRT_CRongDaoDatDayLon, item.TTMDRanhOngThang_ChieuRongDayDaoNho);
                    item.DTDTLCRONRT_DTichDaoDa = DTDTLCRONRT_DTichDaoDa(item.DTDTLCRONRT_CRongDaoDatDayLon, item.DTDTLCRONRT_CRongDaoDaDayLon, item.TTVLDCongRanh_TLChieuCaoDaoDa, item.TTMDRanhOngThang_ChieuRongDayDaoNho);
                    item.DTDHLCRONRT_CRongDaoDatDayLon = DTDHLCRONRT_CRongDaoDatDayLon(item.TTVLDCongRanh_HLChieuCaoDaoDat, item.TTMDRanhOngThang_TyLeMoMai, item.TTMDRanhOngThang_SoCanhMaiTrai, item.TTMDRanhOngThang_SoCanhMaiPhai, item.TTMDRanhOngThang_ChieuRongDayDaoNho);
                    item.DTDHLCRONRT_DTichDaoDat = DTDHLCRONRT_DTichDaoDat(item.DTDHLCRONRT_CRongDaoDatDayLon, item.TTMDRanhOngThang_ChieuRongDayDaoNho, item.TTVLDCongRanh_HLChieuCaoDaoDat);
                    item.DTDHLCRONRT_CRongDaoDaDayLon = DTDHLCRONRT_CRongDaoDaDayLon(item.TTVLDCongRanh_HLChieuCaoDaoDa, item.TTMDRanhOngThang_TyLeMoMai, item.TTMDRanhOngThang_SoCanhMaiTrai, item.TTMDRanhOngThang_SoCanhMaiPhai, item.DTDHLCRONRT_CRongDaoDatDayLon, item.TTMDRanhOngThang_ChieuRongDayDaoNho);
                    item.DTDHLCRONRT_DTichDaoDa = DTDHLCRONRT_DTichDaoDa(item.DTDHLCRONRT_CRongDaoDatDayLon, item.DTDHLCRONRT_CRongDaoDaDayLon, item.TTVLDCongRanh_HLChieuCaoDaoDa, item.TTMDRanhOngThang_ChieuRongDayDaoNho);

                    item.TKLD_KlDaoDat = TKLD_KlDaoDat(item.DTDTLCRONRT_DTichDaoDat, item.DTDHLCRONRT_DTichDaoDat, item.TTCDSLCauKienDuongTruyenDan_TongChieuDai);
                    item.TKLD_KlDaoDa = TKLD_KlDaoDa(item.DTDTLCRONRT_DTichDaoDa, item.DTDHLCRONRT_DTichDaoDa, item.TTCDSLCauKienDuongTruyenDan_TongChieuDai);
                    item.TKLD_TongKlDaoCongRanhOngNhuaRanhThang = TKLD_TongKlDaoCongRanhOngNhuaRanhThang(item.TKLD_KlDaoDat, item.TKLD_KlDaoDa);
                    item.TKLD_ChanKhay = TKLD_ChanKhay(item.DTDCKRD_CKDTichDao, item.TTCDSLCauKienDuongTruyenDan_TongChieuDai);
                    item.TKLD_GiangDinh = TKLD_GiangDinh(item.DTDCKRD_DTichDao, item.TTCDSLCauKienDuongTruyenDan_TongChieuDai);
                    item.TKLD_TongKlDaoDatChanKhayRanhDinh = (item.TKLD_ChanKhay + item.TKLD_GiangDinh);
                    item.TKLD_TongKlDaoDat = TKLD_TongKlDaoDat(item.TKLD_KlDaoDat, item.TKLD_TongKlDaoDatChanKhayRanhDinh);
                    item.TKLD_TongKlDaoDa = TKLD_TongKlDaoDa(item.TKLD_KlDaoDa);
                    item.TKLD_TongKlDao = TKLD_TongKlDao(item.TKLD_TongKlDaoDat, item.TKLD_TongKlDaoDa);
                    item.TKLD_KlCChoDatCongTron = TKLD_KlCChoDatCongTron(item.TTCCCCT_CCaoLotDatMongTBinh, item.ThongTinCauTaoCongTron_CRongLotMong, item.ThongTinCauTaoCongTron_CRongMong, item.TTCCCCT_CCaoMongDatTBinh, item.TTCCCCT_CCongCongDatTBinh, item.TTCDSLCauKienDuongTruyenDan_TongChieuDai, item.TTCCCCT_CCaoDeDatTBinh, item.ThongTinDeCong_Kl01DeCong, item.ThongTinDeCong_TongSoLuongDC);
                    item.TKLD_KlCChoDaCongTron = TKLD_KlCChoDaCongTron(item.TTCCCCT_CCaoLotDaMongTBinh, item.ThongTinCauTaoCongTron_CRongLotMong, item.ThongTinCauTaoCongTron_CRongMong, item.TTCCCCT_CCaoMongDaTBinh, item.TTCCCCT_CCongCongDaTBinh, item.TTCDSLCauKienDuongTruyenDan_TongChieuDai, item.TTCCCCT_CCaoDeDaTBinh, item.ThongTinDeCong_Kl01DeCong, item.ThongTinDeCong_TongSoLuongDC);
                    item.TKLD_TongKlChiemChoCTron = TKLD_TongKlChiemChoCTron(item.TKLD_KlCChoDatCongTron, item.TKLD_KlCChoDaCongTron);
                    item.TKLD_KlCChoDatCongHop = TKLD_KlCChoDatCongHop(item.ThongTinDuongTruyenDan_HinhThucTruyenDan, item.TTCCCCCHR_CCaoLotDatTBinh, item.TTKTHHCongHopRanh_CRongLotMong, item.TTKTHHCongHopRanh_CRongMong, item.TTCCCCCHR_CCaoMongDatTBinh, item.TTCCCCCHR_CCaoTuongDatTBinh, item.TTKTHHCongHopRanh_CDayTuong01Ben, item.TTKTHHCongHopRanh_SoLuongTuong, item.TTKTHHCongHopRanh_CRongLongSuDung, item.TTCDSLCauKienDuongTruyenDan_TongChieuDai);
                    item.TKLD_KlCChoDaCongHop = TKLD_KlCChoDaCongHop(item.ThongTinDuongTruyenDan_HinhThucTruyenDan, item.TTCCCCCHR_CCaoLotDaTBinh, item.TTKTHHCongHopRanh_CRongLotMong, item.TTKTHHCongHopRanh_CRongMong, item.TTCCCCCHR_CCaoMongDaTBinh, item.TTCCCCCHR_CCaoTuongDaTBinh, item.TTKTHHCongHopRanh_CDayTuong01Ben, item.TTKTHHCongHopRanh_SoLuongTuong, item.TTKTHHCongHopRanh_CRongLongSuDung, item.TTCDSLCauKienDuongTruyenDan_TongChieuDai);
                    item.TKLD_TongKlCChoCongHop = TKLD_TongKlCChoCongHop(item.TKLD_KlCChoDatCongHop, item.TKLD_KlCChoDaCongHop);
                    item.TKLD_KlCChoDatRanh = TKLD_KlCChoDatRanh(item.TTCCCCCHR_CCaoLotDatTBinh, item.TTKTHHCongHopRanh_CRongLotMong, item.TTKTHHCongHopRanh_CRongMong, item.TTCCCCCHR_CCaoMongDatTBinh, item.TTCCCCCHR_CCaoTuongDatTBinh, item.TTKTHHCongHopRanh_CDayTuong01Ben, item.TTKTHHCongHopRanh_SoLuongTuong, item.TTKTHHCongHopRanh_CRongLongSuDung, item.TTCDSLCauKienDuongTruyenDan_TongChieuDai, item.ThongTinDuongTruyenDan_HinhThucTruyenDan);
                    item.TKLD_KlCChoDaRanh = TKLD_KlCChoDaRanh(item.TTCCCCCHR_CCaoLotDaTBinh, item.TTKTHHCongHopRanh_CRongLotMong, item.TTKTHHCongHopRanh_CRongMong, item.TTCCCCCHR_CCaoMongDaTBinh, item.TTCCCCCHR_CCaoTuongDaTBinh, item.TTKTHHCongHopRanh_CDayTuong01Ben, item.TTKTHHCongHopRanh_SoLuongTuong, item.TTKTHHCongHopRanh_CRongLongSuDung, item.TTCDSLCauKienDuongTruyenDan_TongChieuDai, item.ThongTinDuongTruyenDan_HinhThucTruyenDan);
                    item.TKLD_TongKlCChoRanh = TKLD_TongKlCChoRanh(item.TKLD_KlCChoDatRanh, item.TKLD_KlCChoDaRanh);
                    item.TKLD_KlCChoDatOngNhua = TKLD_KlCChoDatOngNhua(item.TTCCCCON_CCaoDemCatDatTBinh, item.TTCCCCON_CCaoDatTBinh, item.TTCCCCON_CCaoDapCatDatTBinh, item.TTMDRanhOngThang_TyLeMoMai, item.TTMDRanhOngThang_SoCanhMaiTrai, item.TTMDRanhOngThang_SoCanhMaiPhai, item.TTMDRanhOngThang_ChieuRongDayDaoNho, item.TTCDSLCauKienDuongTruyenDan_TongChieuDai);
                    item.TKLD_KlCChoDaOngNhua = TKLD_KlCChoDaOngNhua(item.TTCCCCON_CCaoDemCatDaTBinh, item.TTCCCCON_CCaoDaTBinh, item.TTCCCCON_CCaoDapCatDaTBinh, item.TTMDRanhOngThang_TyLeMoMai, item.TTMDRanhOngThang_SoCanhMaiTrai, item.TTMDRanhOngThang_SoCanhMaiPhai, item.TTMDRanhOngThang_ChieuRongDayDaoNho, item.TTCDSLCauKienDuongTruyenDan_TongChieuDai);
                    item.TKLD_TongKlCChoOngNhua = TKLD_TongKlCChoOngNhua(item.TKLD_KlCChoDatOngNhua, item.TKLD_KlCChoDaOngNhua);
                    item.TKLD_KlCChoDatRanhThang = TKLD_KlCChoDatRanhThang(item.TTCCRT_LotDatTrungBinh, item.ThongTinRanhThang_CRongLot, item.ThongTinRanhThang_CRongMong, item.TTCCRT_MongDatTrungBinh, item.TTCDSLCauKienDuongTruyenDan_TongChieuDai);
                    item.TKLD_KlCChoDaRanhThang = TKLD_KlCChoDaRanhThang(item.TTCCRT_LotDaTrungBinh, item.ThongTinRanhThang_CRongLot, item.ThongTinRanhThang_CRongMong, item.TTCCRT_MongDaTrungBinh, item.TTCDSLCauKienDuongTruyenDan_TongChieuDai);
                    item.TKLD_TongKlCChoRanhThang = TKLD_TongKlCChoRanhThang(item.TKLD_KlCChoDatRanhThang, item.TKLD_KlCChoDaRanhThang);
                    item.TKLD_KlCChoDatChanKhay = TKLD_KlCChoDatChanKhay(item.ThongTinRanhThang_CCaoLotChanKhay, item.ThongTinRanhThang_CRongLotChanKhay, item.ThongTinRanhThang_SoLuongLotChanKhay, item.ThongTinRanhThang_CCaoMongChanKhay, item.ThongTinRanhThang_CRongMongChanKhay, item.ThongTinRanhThang_SoLuongMongChanKhay, item.TTCDSLCauKienDuongTruyenDan_TongChieuDai);
                    item.TKLD_KlCChoDatChanGiangDinh = TKLD_KlCChoDatChanGiangDinh(item.ThongTinRanhThang_CCaoLotGiangDinh, item.ThongTinRanhThang_CRongLotGiangDinh, item.ThongTinRanhThang_SoLuongLotGiangDinh, item.ThongTinRanhThang_CCaoMongGiangDinh, item.ThongTinRanhThang_CRongMongGiangDinh, item.ThongTinRanhThang_SoLuongMongGiangDinh, item.TTCDSLCauKienDuongTruyenDan_TongChieuDai);
                    item.TKLD_TongKlCChoDat = TKLD_TongKlCChoDat(item.TKLD_KlCChoDatRanhThang, item.TKLD_KlCChoDatChanKhay, item.TKLD_KlCChoDatChanGiangDinh);
                    item.TKLD_TongKlCChoDa = TKLD_TongKlCChoDa(item.TKLD_KlCChoDaRanhThang);
                    item.TKLD_TongKlCCho = TKLD_TongKlCCho(item.TKLD_TongKlCChoDat, item.TKLD_TongKlCChoDa);
                    item.TKLD_KlCChoDat = TKLD_KlCChoDat(item.TKLD_KlCChoDatCongTron, item.TKLD_KlCChoDatCongHop, item.TKLD_KlCChoDatRanh, item.TKLD_KlCChoDatOngNhua, item.TKLD_TongKlCChoDat);
                    item.TKLD_KlCChoDa = TKLD_KlCChoDa(item.TKLD_KlCChoDaCongTron, item.TKLD_KlCChoDaCongHop, item.TKLD_KlCChoDaRanh, item.TKLD_KlCChoDaOngNhua, item.TKLD_TongKlCChoDa);
                    item.TKLD_TongChiemCho = TKLD_TongChiemCho(item.TKLD_KlCChoDat, item.TKLD_KlCChoDa);
                    item.TKLD_KlDapTraDat = TKLD_KlDapTraDat(item.TKLD_TongKlDaoDat, item.TKLD_KlCChoDat);
                    item.TKLD_KlDapTraDa = TKLD_KlDapTraDa(item.TKLD_TongKlDaoDa, item.TKLD_KlCChoDa);
                    item.TKLD_TongKlDapTra = TKLD_TongKlDapTra(item.TKLD_KlDapTraDat, item.TKLD_KlDapTraDa);
                    item.TKLD_KlThuaDat = item.TKLD_KlCChoDat;
                    item.TKLD_KlThuaDa = item.TKLD_KlCChoDa;
                    item.TKLD_TongKLThua = item.TKLD_TongChiemCho;
                    item.DTDC_TLCSauDap = DTDC_TLCSauDap(item.ThongTinKichThuocHinhHocOngNhua_TongCCaoOng, item.ThongTinKichThuocHinhHocOngNhua_CCaoDemCat, item.ThongTinKichThuocHinhHocOngNhua_CCaoDapCat, item.ThongTinDuongTruyenDan_HinhThucTruyenDan, item.ThongTinMongDuongTruyenDan_LoaiMong);
                    item.DTDC_TLCRongDapDayLon = DTDC_TLCRongDapDayLon(item.DTDC_TLCSauDap, item.TTMDRanhOngThang_TyLeMoMai, item.TTMDRanhOngThang_SoCanhMaiTrai, item.TTMDRanhOngThang_SoCanhMaiPhai, item.TTMDRanhOngThang_ChieuRongDayDaoNho, item.ThongTinDuongTruyenDan_HinhThucTruyenDan, item.ThongTinMongDuongTruyenDan_LoaiMong);
                    item.DTDC_TLDTichDap = DTDC_TLDTichDap(item.DTDC_TLCRongDapDayLon, item.TTMDRanhOngThang_ChieuRongDayDaoNho, item.ThongTinKichThuocHinhHocOngNhua_TongCCaoOng, item.ThongTinKichThuocHinhHocOngNhua_CCaoDemCat, item.ThongTinKichThuocHinhHocOngNhua_CCaoDapCat, item.ThongTinDuongTruyenDan_HinhThucTruyenDan, item.ThongTinMongDuongTruyenDan_LoaiMong);
                    item.DTDC_HLCSauDap = DTDC_HLCSauDap(item.ThongTinKichThuocHinhHocOngNhua_TongCCaoOng, item.ThongTinKichThuocHinhHocOngNhua_CCaoDemCat, item.ThongTinKichThuocHinhHocOngNhua_CCaoDapCat, item.ThongTinDuongTruyenDan_HinhThucTruyenDan, item.ThongTinMongDuongTruyenDan_LoaiMong);
                    item.DTDC_HLCRongDapDayLon = DTDC_HLCRongDapDayLon(item.DTDC_HLCSauDap, item.TTMDRanhOngThang_TyLeMoMai, item.TTMDRanhOngThang_SoCanhMaiTrai, item.TTMDRanhOngThang_SoCanhMaiPhai, item.TTMDRanhOngThang_ChieuRongDayDaoNho, item.ThongTinDuongTruyenDan_HinhThucTruyenDan, item.ThongTinMongDuongTruyenDan_LoaiMong);
                    item.DTDC_HLDTichDap = DTDC_HLDTichDap(item.DTDC_HLCRongDapDayLon, item.TTMDRanhOngThang_ChieuRongDayDaoNho, item.ThongTinKichThuocHinhHocOngNhua_TongCCaoOng, item.ThongTinKichThuocHinhHocOngNhua_CCaoDemCat, item.ThongTinKichThuocHinhHocOngNhua_CCaoDapCat, item.ThongTinDuongTruyenDan_HinhThucTruyenDan, item.ThongTinMongDuongTruyenDan_LoaiMong);
                    item.TTKLDC_KlDapCatTruocChiemCho = TTKLDC_KlDapCatTruocChiemCho(item.DTDC_TLDTichDap, item.DTDC_HLDTichDap, item.TTCDSLCauKienDuongTruyenDan_TongChieuDai);
                    item.TTKLDC_KlChiemCho = TTKLDC_KlChiemCho(item.ThongTinKichThuocHinhHocOngNhua_TongCCaoOng, item.TTCDSLCauKienDuongTruyenDan_TongChieuDai, item.ThongTinDuongTruyenDan_HinhThucTruyenDan, item.ThongTinMongDuongTruyenDan_LoaiMong);
                    item.TTKLDC_KlDapCatSauChiemCho = Math.Round(item.TTKLDC_KlDapCatTruocChiemCho - item.TTKLDC_KlChiemCho, 2);
                });
            }
            return list;
        }



        public double ThongTinCaoDoHoGa_CaoDoHienTrangTruocKhiDao(double ThongTinCaoDoHoGa_CaoDoTuNhien, double ThongTinCaoDoHoGa_CaoDoDinhK98, double ThongTinCaoDoHoGa_CdDinhViaHeHoanThien)
        {
            double result;

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

            return Math.Round(result, 2);
        }

        public double ThongTinCaoDoHoGa_CdDinhMong(string ThongTinChungHoGa_HinhThucHoGa, string ThongTinChungHoGa_HinhThucMongHoGa, double ThongTinCaoDoHoGa_CdDayHoGa, double DeHoGa_C)
        {
            ThongTinChungHoGa_HinhThucHoGa = GetTenDanhMucById(ThongTinChungHoGa_HinhThucHoGa);
            ThongTinChungHoGa_HinhThucMongHoGa = GetTenDanhMucById(ThongTinChungHoGa_HinhThucMongHoGa);
            if (ThongTinChungHoGa_HinhThucHoGa.ToUpper().Trim() == "Lắp đặt".ToUpper()
            && ThongTinChungHoGa_HinhThucMongHoGa.ToUpper().Trim() == "Có móng".ToUpper())
            {
                return Math.Round(ThongTinCaoDoHoGa_CdDayHoGa - DeHoGa_C, 2);
            }
            else
            {
                return ThongTinCaoDoHoGa_CdDayHoGa;
            }
        }

        public double ThongTinCaoDoHoGa_DinhLotMong(string ThongTinChungHoGa_HinhThucMongHoGa, double ThongTinCaoDoHoGa_CdDinhMong, double BeTongMongHoGa_C)
        {
            if (ThongTinChungHoGa_HinhThucMongHoGa == "Không có móng")
            {
                return 0;
            }
            else
            {
                return Math.Round(ThongTinCaoDoHoGa_CdDinhMong - BeTongMongHoGa_C, 2);
            }
        }

        public double ThongTinCaoDoHoGa_DayDao(string ThongTinChungHoGa_HinhThucHoGa, string ThongTinChungHoGa_HinhThucMongHoGa, double ThongTinCaoDoHoGa_DinhLotMong, double BeTongLotMong_C, double ThongTinCaoDoHoGa_CdDayHoGa, double DeHoGa_C)
        {
            double result;
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

            return Math.Round(result, 2);
        }
        public double ThongTinCaoDoHoGa_CSauDao(double ThongTinCaoDoHoGa_CaoDoHienTrangTruocKhiDao, double ThongTinCaoDoHoGa_DayDao)
        {
            return Math.Round(ThongTinCaoDoHoGa_CaoDoHienTrangTruocKhiDao - ThongTinCaoDoHoGa_DayDao, 2);
        }
        public double ThongTinVatLieuDaoHoGa_ChieuCaoDaoDat(string ThongTinVatLieuDaoHoGa_LoaiVatLieuDao, double ThongTinCaoDoHoGa_CSauDao, double ThongTinVatLieuDaoHoGa_ChieuCaoDaoDa)
        {
            ThongTinVatLieuDaoHoGa_LoaiVatLieuDao = GetTenDanhMucById(ThongTinVatLieuDaoHoGa_LoaiVatLieuDao).ToUpper().Trim();
            if (string.IsNullOrEmpty(ThongTinVatLieuDaoHoGa_LoaiVatLieuDao))
            {
                return 0;
            }
            else if (ThongTinVatLieuDaoHoGa_LoaiVatLieuDao == "Đào đá".ToUpper())
            {
                return 0;
            }
            else
            {
                return Math.Round(ThongTinCaoDoHoGa_CSauDao - ThongTinVatLieuDaoHoGa_ChieuCaoDaoDa, 2);
            }
        }

        public double ChatMatNgoaiCanh_C(string ThongTinChungHoGa_ChatMatNgoai, string ThongTinChungHoGa_KetCauTuong, string ThongTinChungHoGa_KetCauMuMo, double TuongHoGa_C, double DamGiuaHoGa_CdDam, double MuMoThotDuoi_C, double MuMoThotTren_C, double MuMoThotTren_CdTuong)
        {
            ThongTinChungHoGa_KetCauMuMo = GetTenDanhMucById(ThongTinChungHoGa_KetCauMuMo).ToUpper().Trim();
            ThongTinChungHoGa_KetCauTuong = GetTenDanhMucById(ThongTinChungHoGa_KetCauTuong).ToUpper().Trim();
            ThongTinChungHoGa_ChatMatNgoai = GetTenDanhMucById(ThongTinChungHoGa_ChatMatNgoai).ToUpper().Trim();

            if (ThongTinChungHoGa_ChatMatNgoai == "Có".ToUpper() && ThongTinChungHoGa_KetCauTuong == "Tường xây gạch".ToUpper())
            {
                if (ThongTinChungHoGa_KetCauMuMo == "Mũ mố xây gạch".ToUpper())
                {
                    return Math.Round(TuongHoGa_C + DamGiuaHoGa_CdDam + MuMoThotDuoi_C + MuMoThotTren_C + MuMoThotTren_CdTuong, 2);
                }
                else
                {
                    return Math.Round(TuongHoGa_C + DamGiuaHoGa_CdDam, 2);
                }
            }
            else if (ThongTinChungHoGa_ChatMatNgoai == "Có".ToUpper() && ThongTinChungHoGa_KetCauTuong == "Tường bê tông".ToUpper())
            {
                if (ThongTinChungHoGa_KetCauMuMo == "Mũ mố xây gạch".ToUpper())
                {
                    return Math.Round(MuMoThotTren_C + MuMoThotTren_CdTuong, 2);
                }
                else
                {
                    return 0;
                }
            }
            else if (ThongTinChungHoGa_ChatMatNgoai == "Không".ToUpper() && ThongTinChungHoGa_KetCauMuMo == "Mũ mố xây gạch".ToUpper())
            {
                return Math.Round(MuMoThotTren_C + MuMoThotTren_CdTuong, 2);
            }
            else
            {
                return 0;
            }
        }
        public double ChatMatTrong_C(string ThongTinChungHoGa_ChatMatTrong, string ThongTinChungHoGa_KetCauTuong, string ThongTinChungHoGa_KetCauMuMo, double TuongHoGa_C, double DamGiuaHoGa_C, double MuMoThotDuoi_C, double MuMoThotTren_C)
        {
            ThongTinChungHoGa_ChatMatTrong = GetTenDanhMucById(ThongTinChungHoGa_ChatMatTrong).ToUpper().Trim();
            ThongTinChungHoGa_KetCauTuong = GetTenDanhMucById(ThongTinChungHoGa_KetCauTuong).ToUpper().Trim();
            ThongTinChungHoGa_KetCauMuMo = GetTenDanhMucById(ThongTinChungHoGa_KetCauMuMo).ToUpper().Trim();
            if (ThongTinChungHoGa_ChatMatTrong == "CÓ" && ThongTinChungHoGa_KetCauTuong == "TƯỜNG XÂY GẠCH")
            {
                if (ThongTinChungHoGa_KetCauMuMo == "MŨ MỐ XÂY GẠCH")
                {
                    return Math.Round(TuongHoGa_C + DamGiuaHoGa_C + MuMoThotDuoi_C + MuMoThotTren_C, 2);
                }
                else
                {
                    return Math.Round(TuongHoGa_C + DamGiuaHoGa_C + MuMoThotDuoi_C, 2);
                }
            }
            else if (ThongTinChungHoGa_ChatMatTrong == "CÓ" && ThongTinChungHoGa_KetCauTuong == "TƯỜNG BÊ TÔNG")
            {
                if (ThongTinChungHoGa_KetCauMuMo == "MŨ MỐ XÂY GẠCH")
                {
                    return MuMoThotTren_C;
                }
                else
                {
                    return 0;
                }
            }
            else if (ThongTinChungHoGa_ChatMatTrong == "KHÔNG" && ThongTinChungHoGa_KetCauMuMo == "MŨ MỐ XÂY GẠCH")
            {
                return MuMoThotTren_C;
            }
            else
            {
                return 0;
            }
        }

        public double ThongTinCaoDoHoGa_TongChieuCaoHoGa(double ThongTinCaoDoHoGa_CdDinhHoGa, double ThongTinCaoDoHoGa_DayDao)
        {
            return Math.Round(ThongTinCaoDoHoGa_CdDinhHoGa - ThongTinCaoDoHoGa_DayDao, 2);
        }
        public double ThongTinCaoDoHoGa_ChenhCaoDinhHoGaVaHienTrangDao(double ThongTinCaoDoHoGa_CdDinhHoGa, double ThongTinCaoDoHoGa_CaoDoHienTrangTruocKhiDao)
        {
            return Math.Round(ThongTinCaoDoHoGa_CdDinhHoGa - ThongTinCaoDoHoGa_CaoDoHienTrangTruocKhiDao, 2);
        }
        public double ThongTinCaoDoHoGa_DinhMuMoThotDuoi(double ThongTinCaoDoHoGa_CdDinhHoGa, double MuMoThotTren_C)
        {
            return Math.Round(ThongTinCaoDoHoGa_CdDinhHoGa - MuMoThotTren_C, 2);
        }

        public double ThongTinCaoDoHoGa_DinhTuong(double ThongTinCaoDoHoGa_DinhMuMoThotDuoi, double MuMoThotDuoi_C)
        {
            return Math.Round(ThongTinCaoDoHoGa_DinhMuMoThotDuoi - MuMoThotDuoi_C, 2);
        }

        public double ThongTinCaoDoHoGa_DinhTuongDuoiDamGiuaTuong(double DamGiuaHoGa_CCaoDamGiuaTuongSoVoiDayHoGa, double ThongTinCaoDoHoGa_CdDayHoGa)
        {
            return Math.Round(DamGiuaHoGa_CCaoDamGiuaTuongSoVoiDayHoGa > 0 ? ThongTinCaoDoHoGa_CdDayHoGa + DamGiuaHoGa_CCaoDamGiuaTuongSoVoiDayHoGa : 0, 2);
        }


        public double ThongTinCaoDoHoGa_DinhDamGiuaTuong(double DamGiuaHoGa_CCaoDamGiuaTuongSoVoiDayHoGa, double ThongTinCaoDoHoGa_DinhTuongDuoiDamGiuaTuong, double DamGiuaHoGa_C)
        {
            return Math.Round(DamGiuaHoGa_CCaoDamGiuaTuongSoVoiDayHoGa > 0 ? ThongTinCaoDoHoGa_DinhTuongDuoiDamGiuaTuong + DamGiuaHoGa_C : 0, 2);
        }



        public double ThongTinCaoDoHoGa_CCaoTuong(double DamGiuaHoGa_CCaoDamGiuaTuongSoVoiDayHoGa, double ThongTinCaoDoHoGa_DinhTuong, double ThongTinCaoDoHoGa_CdDayHoGa, double DamGiuaHoGa_C)
        {
            double ketQua = DamGiuaHoGa_CCaoDamGiuaTuongSoVoiDayHoGa > 0 ? ThongTinCaoDoHoGa_DinhTuong - ThongTinCaoDoHoGa_CdDayHoGa - DamGiuaHoGa_C : ThongTinCaoDoHoGa_DinhTuong - ThongTinCaoDoHoGa_CdDayHoGa;
            return Math.Round(ketQua, 2);
        }

        public double TTCCCCDTHT_ChieuCaoLotDat(string ThongTinVatLieuDaoHoGa_LoaiVatLieuDao, double ThongTinVatLieuDaoHoGa_ChieuCaoDaoDat, double BeTongLotMong_C)
        {
            ThongTinVatLieuDaoHoGa_LoaiVatLieuDao = GetTenDanhMucById(ThongTinVatLieuDaoHoGa_LoaiVatLieuDao).ToUpper().Trim();
            double ketQua = 0;

            if (ThongTinVatLieuDaoHoGa_LoaiVatLieuDao == "Đào đất".ToUpper() || ThongTinVatLieuDaoHoGa_LoaiVatLieuDao == "Đào đất + đào đá".ToUpper())
            {
                ketQua = ThongTinVatLieuDaoHoGa_ChieuCaoDaoDat >= BeTongLotMong_C ? BeTongLotMong_C : ThongTinVatLieuDaoHoGa_ChieuCaoDaoDat;
            }

            return Math.Round(ketQua, 2);
        }

        public double TTCCCCDTHT_ChieuCaoMongDat(string ThongTinVatLieuDaoHoGa_LoaiVatLieuDao, double ThongTinVatLieuDaoHoGa_ChieuCaoDaoDat, double BeTongLotMong_C, double BeTongMongHoGa_C)
        {
            double ketQua = 0;
            ThongTinVatLieuDaoHoGa_LoaiVatLieuDao = GetTenDanhMucById(ThongTinVatLieuDaoHoGa_LoaiVatLieuDao).ToUpper().Trim();

            if (ThongTinVatLieuDaoHoGa_LoaiVatLieuDao == "Đào đất".ToUpper() || ThongTinVatLieuDaoHoGa_LoaiVatLieuDao == "Đào đất + đào đá".ToUpper())
            {
                if (ThongTinVatLieuDaoHoGa_ChieuCaoDaoDat <= BeTongLotMong_C)
                {
                    ketQua = 0;
                }
                else if (ThongTinVatLieuDaoHoGa_ChieuCaoDaoDat >= BeTongLotMong_C + BeTongMongHoGa_C)
                {
                    ketQua = BeTongMongHoGa_C;
                }
                else
                {
                    ketQua = ThongTinVatLieuDaoHoGa_ChieuCaoDaoDat - BeTongLotMong_C;
                }
            }

            return Math.Round(ketQua, 2);
        }

        public double TTCCCCDTHT_ChieuCaoTuongDat(string ThongTinVatLieuDaoHoGa_LoaiVatLieuDao, double ThongTinVatLieuDaoHoGa_ChieuCaoDaoDat, double BeTongLotMong_C, double BeTongMongHoGa_C, double TuongHoGa_C, double DamGiuaHoGa_C, double MuMoThotDuoi_C, double MuMoThotTren_C)
        {
            double ketQua = 0;
            ThongTinVatLieuDaoHoGa_LoaiVatLieuDao = GetTenDanhMucById(ThongTinVatLieuDaoHoGa_LoaiVatLieuDao).ToUpper().Trim();
            double tongThem = TuongHoGa_C + DamGiuaHoGa_C + MuMoThotDuoi_C + MuMoThotTren_C;
            double gioiHanTren = BeTongLotMong_C + BeTongMongHoGa_C + TuongHoGa_C + DamGiuaHoGa_C + MuMoThotDuoi_C + MuMoThotTren_C;

            if (ThongTinVatLieuDaoHoGa_LoaiVatLieuDao == "Đào đất".ToUpper() || ThongTinVatLieuDaoHoGa_LoaiVatLieuDao == "Đào đất + đào đá".ToUpper())
            {
                if (ThongTinVatLieuDaoHoGa_ChieuCaoDaoDat <= BeTongLotMong_C + BeTongMongHoGa_C)
                {
                    ketQua = 0;
                }
                else if (ThongTinVatLieuDaoHoGa_ChieuCaoDaoDat >= gioiHanTren)
                {
                    ketQua = tongThem;
                }
                else
                {
                    ketQua = ThongTinVatLieuDaoHoGa_ChieuCaoDaoDat - (BeTongLotMong_C + BeTongMongHoGa_C);
                }
            }

            return Math.Round(ketQua, 2);
        }

        public double TTCCCCDTHT_ChieuCaoLotDa(string ThongTinVatLieuDaoHoGa_LoaiVatLieuDao, double ThongTinVatLieuDaoHoGa_ChieuCaoDaoDa, double ThongTinVatLieuDaoHoGa_TongChieuCaoDao, double TTCCCCDTHT_ChieuCaoLotDat, double BeTongLotMong_C)
        {
            double ketQua = 0;

            ThongTinVatLieuDaoHoGa_LoaiVatLieuDao = GetTenDanhMucById(ThongTinVatLieuDaoHoGa_LoaiVatLieuDao).ToUpper().Trim();

            if (ThongTinVatLieuDaoHoGa_LoaiVatLieuDao == "Đào đá".ToUpper())
            {
                ketQua = ThongTinVatLieuDaoHoGa_ChieuCaoDaoDa >= BeTongLotMong_C ? BeTongLotMong_C : ThongTinVatLieuDaoHoGa_ChieuCaoDaoDa;
            }
            else if (ThongTinVatLieuDaoHoGa_LoaiVatLieuDao == "Đào đất + Đào đá".ToUpper())
            {
                if (ThongTinVatLieuDaoHoGa_TongChieuCaoDao >= BeTongLotMong_C)
                {
                    ketQua = TTCCCCDTHT_ChieuCaoLotDat < BeTongLotMong_C ? BeTongLotMong_C - TTCCCCDTHT_ChieuCaoLotDat : 0;
                }
                else
                {
                    ketQua = ThongTinVatLieuDaoHoGa_ChieuCaoDaoDa;
                }
            }

            return Math.Round(ketQua, 2);
        }

        public double TTCCCCDTHT_ChieuCaoMongDa(string ThongTinVatLieuDaoHoGa_LoaiVatLieuDao, double ThongTinVatLieuDaoHoGa_ChieuCaoDaoDa, double ThongTinVatLieuDaoHoGa_TongChieuCaoDao, double TTCCCCDTHT_ChieuCaoMongDat, double TTCCCCDTHT_ChieuCaoLotDa, double BeTongLotMong_C, double BeTongMongHoGa_C)
        {
            double ketQua = 0;
            ThongTinVatLieuDaoHoGa_LoaiVatLieuDao = GetTenDanhMucById(ThongTinVatLieuDaoHoGa_LoaiVatLieuDao).ToUpper().Trim();
            if (ThongTinVatLieuDaoHoGa_LoaiVatLieuDao == "Đào đá".ToUpper())
            {
                if (ThongTinVatLieuDaoHoGa_ChieuCaoDaoDa <= BeTongLotMong_C)
                {
                    ketQua = 0;
                }
                else if (ThongTinVatLieuDaoHoGa_ChieuCaoDaoDa >= BeTongLotMong_C + BeTongMongHoGa_C)
                {
                    ketQua = BeTongMongHoGa_C;
                }
                else
                {
                    ketQua = ThongTinVatLieuDaoHoGa_ChieuCaoDaoDa - BeTongLotMong_C;
                }
            }
            else if (ThongTinVatLieuDaoHoGa_LoaiVatLieuDao == "Đào đất + Đào đá".ToUpper())
            {
                if (ThongTinVatLieuDaoHoGa_TongChieuCaoDao >= BeTongLotMong_C + BeTongMongHoGa_C)
                {
                    if (TTCCCCDTHT_ChieuCaoMongDat < BeTongMongHoGa_C)
                    {
                        ketQua = BeTongMongHoGa_C - TTCCCCDTHT_ChieuCaoMongDat;
                    }
                    else
                    {
                        ketQua = 0;
                    }
                }
                else
                {
                    ketQua = ThongTinVatLieuDaoHoGa_ChieuCaoDaoDa - TTCCCCDTHT_ChieuCaoLotDa;
                }
            }

            return Math.Round(ketQua, 2);
        }

        public double TTCCCCDTHT_ChieuCaoTuongDa(string ThongTinVatLieuDaoHoGa_LoaiVatLieuDao, double ThongTinVatLieuDaoHoGa_ChieuCaoDaoDa, double ThongTinVatLieuDaoHoGa_TongChieuCaoDao, double TTCCCCDTHT_ChieuCaoTuongDat, double TTCCCCDTHT_ChieuCaoLotDa, double TTCCCCDTHT_ChieuCaoMongDa, double BeTongLotMong_C, double BeTongMongHoGa_C, double TuongHoGa_C, double DamGiuaHoGa_C, double MuMoThotDuoi_C, double MuMoThotTren_C)
        {
            double ketQua = 0;
            ThongTinVatLieuDaoHoGa_LoaiVatLieuDao = GetTenDanhMucById(ThongTinVatLieuDaoHoGa_LoaiVatLieuDao).ToUpper().Trim();
            if (ThongTinVatLieuDaoHoGa_LoaiVatLieuDao == "Đào đá".ToUpper())
            {
                if (ThongTinVatLieuDaoHoGa_ChieuCaoDaoDa <= BeTongLotMong_C + BeTongMongHoGa_C)
                {
                    ketQua = 0;
                }
                else if (ThongTinVatLieuDaoHoGa_ChieuCaoDaoDa >= BeTongLotMong_C + BeTongMongHoGa_C + TuongHoGa_C + DamGiuaHoGa_C + MuMoThotDuoi_C + MuMoThotTren_C)
                {
                    ketQua = TuongHoGa_C + DamGiuaHoGa_C + MuMoThotDuoi_C + MuMoThotTren_C;
                }
                else
                {
                    ketQua = ThongTinVatLieuDaoHoGa_ChieuCaoDaoDa - (BeTongLotMong_C + BeTongMongHoGa_C);
                }
            }
            else if (ThongTinVatLieuDaoHoGa_LoaiVatLieuDao == "Đào đất + Đào đá".ToUpper())
            {
                if (ThongTinVatLieuDaoHoGa_TongChieuCaoDao >= BeTongLotMong_C + BeTongMongHoGa_C + TuongHoGa_C + DamGiuaHoGa_C + MuMoThotDuoi_C + MuMoThotTren_C)
                {
                    if (TTCCCCDTHT_ChieuCaoTuongDat < TuongHoGa_C + DamGiuaHoGa_C + MuMoThotDuoi_C + MuMoThotTren_C)
                    {
                        ketQua = TuongHoGa_C + DamGiuaHoGa_C + MuMoThotDuoi_C + MuMoThotTren_C - TTCCCCDTHT_ChieuCaoTuongDat;
                    }
                    else
                    {
                        ketQua = 0;
                    }
                }
                else
                {
                    ketQua = ThongTinVatLieuDaoHoGa_ChieuCaoDaoDa - (TTCCCCDTHT_ChieuCaoLotDa + TTCCCCDTHT_ChieuCaoMongDa);
                }
            }

            return Math.Round(ketQua, 2);
        }

        public double TTKLD_CRongDaoDayLonDat(string ThongTinVatLieuDaoHoGa_LoaiVatLieuDao, double ThongTinVatLieuDaoHoGa_ChieuCaoDaoDat, double ThongTinMaiDao_TyLeMoMai, double ThongTinMaiDao_SoCanhMaiTrai, double ThongTinMaiDao_SoCanhMaiPhai, double ThongTinMaiDao_ChieuRongDayDaoNho)
        {
            double ketQua = 0;
            ThongTinVatLieuDaoHoGa_LoaiVatLieuDao = GetTenDanhMucById(ThongTinVatLieuDaoHoGa_LoaiVatLieuDao).ToUpper().Trim();

            if (ThongTinVatLieuDaoHoGa_LoaiVatLieuDao == "Đào đất".ToUpper() || ThongTinVatLieuDaoHoGa_LoaiVatLieuDao == "Đào đất + đào đá".ToUpper())
            {
                ketQua = (ThongTinVatLieuDaoHoGa_ChieuCaoDaoDat * ThongTinMaiDao_TyLeMoMai * (ThongTinMaiDao_SoCanhMaiTrai + ThongTinMaiDao_SoCanhMaiPhai)) + ThongTinMaiDao_ChieuRongDayDaoNho;
            }

            return Math.Round(ketQua, 2);
        }
        public double TinhTTTKLD_CRongDaoDayLonDaoan(string ThongTinVatLieuDaoHoGa_LoaiVatLieuDao, double ThongTinVatLieuDaoHoGa_ChieuCaoDaoDa, double ThongTinMaiDao_TyLeMoMai, double ThongTinMaiDao_SoCanhMaiTrai, double ThongTinMaiDao_SoCanhMaiPhai, double TTKLD_CRongDaoDayLonDat, double ThongTinMaiDao_ChieuRongDayDaoNho)
        {
            double ketQua = 0;
            ThongTinVatLieuDaoHoGa_LoaiVatLieuDao = GetTenDanhMucById(ThongTinVatLieuDaoHoGa_LoaiVatLieuDao).ToUpper().Trim();
            if (ThongTinVatLieuDaoHoGa_LoaiVatLieuDao == "Đào đá".ToUpper() || ThongTinVatLieuDaoHoGa_LoaiVatLieuDao == "Đào đất + đào đá".ToUpper())
            {
                if (TTKLD_CRongDaoDayLonDat > 0)
                {
                    ketQua = (ThongTinVatLieuDaoHoGa_ChieuCaoDaoDa * ThongTinMaiDao_TyLeMoMai * (ThongTinMaiDao_SoCanhMaiTrai + ThongTinMaiDao_SoCanhMaiPhai)) + TTKLD_CRongDaoDayLonDat;
                }
                else
                {
                    ketQua = (ThongTinVatLieuDaoHoGa_ChieuCaoDaoDa * ThongTinMaiDao_TyLeMoMai * (ThongTinMaiDao_SoCanhMaiTrai + ThongTinMaiDao_SoCanhMaiPhai)) + ThongTinMaiDao_ChieuRongDayDaoNho;
                }
            }

            return Math.Round(ketQua, 2);
        }
        public double TTKLD_DienTichDaoDat(double TTKLD_CRongDaoDayLonDat, double ThongTinMaiDao_ChieuRongDayDaoNho, double ThongTinVatLieuDaoHoGa_ChieuCaoDaoDat)
        {
            double ketQua = (TTKLD_CRongDaoDayLonDat + ThongTinMaiDao_ChieuRongDayDaoNho) * (ThongTinVatLieuDaoHoGa_ChieuCaoDaoDat / 2);
            return Math.Round(ketQua, 2);
        }
        public double TTKLD_DienTichDaoDa(double TTKLD_CRongDaoDayLonDa, double TTKLD_CRongDaoDayLonDat, double ThongTinMaiDao_ChieuRongDayDaoNho, double ThongTinVatLieuDaoHoGa_ChieuCaoDaoDa)
        {
            // Tính toán giá trị dựa trên điều kiện và làm tròn đến 2 chữ số thập phân
            double ketQua;
            if (TTKLD_CRongDaoDayLonDat > 0)
            {
                ketQua = (TTKLD_CRongDaoDayLonDa + TTKLD_CRongDaoDayLonDat) * (ThongTinVatLieuDaoHoGa_ChieuCaoDaoDa / 2);
            }
            else
            {
                ketQua = (TTKLD_CRongDaoDayLonDa + ThongTinMaiDao_ChieuRongDayDaoNho) * (ThongTinVatLieuDaoHoGa_ChieuCaoDaoDa / 2);
            }
            return Math.Round(ketQua, 2);
        }
        public double TTKLD_TongDtDao(double TTKLD_DienTichDaoDat, double TTKLD_DienTichDaoDa)
        {
            // Tính tổng và làm tròn đến 2 chữ số thập phân
            double ketQua = TTKLD_DienTichDaoDat + TTKLD_DienTichDaoDa;
            return Math.Round(ketQua, 2);
        }
        public double TTKLD_KlDaoDat(double TTKLD_DienTichDaoDat, double BeTongLotMong_D, double PhuBiHoGa_CDai, string ThongTinChungHoGa_TenHoGaTheoBanVe)
        {
            string cuoi2KyTu = ThongTinChungHoGa_TenHoGaTheoBanVe.Length >= 2 ? ThongTinChungHoGa_TenHoGaTheoBanVe.Substring(ThongTinChungHoGa_TenHoGaTheoBanVe.Length - 2) : string.Empty;
            double ketQua;
            if (cuoi2KyTu == "=G")
            {
                ketQua = 0;
            }
            else
            {
                ketQua = BeTongLotMong_D > 0 ? TTKLD_DienTichDaoDat * BeTongLotMong_D : TTKLD_DienTichDaoDat * PhuBiHoGa_CDai;
            }
            return Math.Round(ketQua, 2);
        }
        public double TTKLD_KlDaoDa(double TTKLD_DienTichDaoDa, double BeTongLotMong_D, double PhuBiHoGa_CDai, string ThongTinChungHoGa_TenHoGaTheoBanVe)
        {
            string cuoi2KyTu = ThongTinChungHoGa_TenHoGaTheoBanVe.Length >= 2 ? ThongTinChungHoGa_TenHoGaTheoBanVe.Substring(ThongTinChungHoGa_TenHoGaTheoBanVe.Length - 2) : string.Empty;
            double ketQua = cuoi2KyTu == "=G" ? 0 : (BeTongLotMong_D > 0 ? TTKLD_DienTichDaoDa * BeTongLotMong_D : TTKLD_DienTichDaoDa * PhuBiHoGa_CDai);
            return Math.Round(ketQua, 2);
        }
        public double TTKLD_TongKlDao(double TTKLD_KlDaoDat, double TTKLD_KlDaoDa)
        {
            return Math.Round(TTKLD_KlDaoDat + TTKLD_KlDaoDa, 2);
        }
        public double TTKLD_KlChiemChoDat(string ThongTinChungHoGa_TenHoGaTheoBanVe, double BeTongLotMong_D, double DThongTinChungHoGa_TenHoGaTheoBanVe, double BeTongLotMong_R, double TBeTongMongHoGa_D, double TBeTongMongHoGa_R, double TTCCCCDTHT_ChieuCaoMongDat, double TTCCCCDTHT_ChieuCaoTuongDat, double PhuBiHoGa_CDai, double PhuBiHoGa_CRong)
        {
            if (ThongTinChungHoGa_TenHoGaTheoBanVe.ToUpper().EndsWith("=G"))
            {
                return 0;
            }
            else if (BeTongLotMong_D > 0)
            {
                return Math.Round((DThongTinChungHoGa_TenHoGaTheoBanVe * BeTongLotMong_D * BeTongLotMong_R) + (TBeTongMongHoGa_D * TBeTongMongHoGa_R * TTCCCCDTHT_ChieuCaoMongDat) + (TTCCCCDTHT_ChieuCaoTuongDat * PhuBiHoGa_CDai * PhuBiHoGa_CRong), 2);
            }
            else
            {
                return Math.Round((DThongTinChungHoGa_TenHoGaTheoBanVe * PhuBiHoGa_CDai * PhuBiHoGa_CRong) + (PhuBiHoGa_CDai * PhuBiHoGa_CRong * TTCCCCDTHT_ChieuCaoMongDat) + (TTCCCCDTHT_ChieuCaoTuongDat * PhuBiHoGa_CDai * PhuBiHoGa_CRong), 2);
            }
        }
        public double TTKLD_KlChiemChoDa(string ThongTinChungHoGa_TenHoGaTheoBanVe, double BeTongLotMong_D, double TTCCCCDTHT_ChieuCaoLotDa, double BeTongLotMong_R, double TBeTongMongHoGa_D, double TBeTongMongHoGa_R, double TTCCCCDTHT_ChieuCaoMongDa, double TTCCCCDTHT_ChieuCaoTuongDa, double PhuBiHoGa_CDai, double PhuBiHoGa_CRong)
        {
            if (ThongTinChungHoGa_TenHoGaTheoBanVe.EndsWith("=G"))
            {
                return 0;
            }
            else if (BeTongLotMong_D > 0)
            {
                return Math.Round((TTCCCCDTHT_ChieuCaoLotDa * BeTongLotMong_D * BeTongLotMong_R) + (TBeTongMongHoGa_D * TBeTongMongHoGa_R * TTCCCCDTHT_ChieuCaoMongDa) + (TTCCCCDTHT_ChieuCaoTuongDa * PhuBiHoGa_CDai * PhuBiHoGa_CRong), 2);
            }
            else
            {
                return Math.Round((TTCCCCDTHT_ChieuCaoLotDa * PhuBiHoGa_CDai * PhuBiHoGa_CRong) + (PhuBiHoGa_CDai * PhuBiHoGa_CRong * TTCCCCDTHT_ChieuCaoMongDa) + (TTCCCCDTHT_ChieuCaoTuongDa * PhuBiHoGa_CDai * PhuBiHoGa_CRong), 2);
            }
        }
        public double TTKLD_TongChiemCho(double TTKLD_KlChiemChoDat, double TTKLD_KlChiemChoDa)
        {
            return Math.Round(TTKLD_KlChiemChoDat + TTKLD_KlChiemChoDa, 2);
        }
        public double TinhTTKLD_KlDapTraDatHieu(double TTKLD_KlDaoDat, double TTKLD_KlChiemChoDat)
        {
            return Math.Round(TTKLD_KlDaoDat - TTKLD_KlChiemChoDat, 2);
        }
        public double TTKLD_KlDapTraDa(double TTKLD_KlDaoDa, double TTKLD_KlChiemChoDa)
        {
            return Math.Round(TTKLD_KlDaoDa - TTKLD_KlChiemChoDa, 2);
        }
        public double TTKLD_TongDapTra(double TTKLD_KlDapTraDat, double TTKLD_KlDapTraDa)
        {
            return Math.Round(TTKLD_KlDapTraDat + TTKLD_KlDapTraDa, 2);
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
        public double TTCDSLCauKienDuongTruyenDan_SlCauKienTinhKl(string ThongTinDuongTruyenDan_HinhThucTruyenDan, string TTCDSLCauKienDuongTruyenDan_XacDinhOngCongCanThem, double TTCDSLCauKienDuongTruyenDan_SlCauKienNguyen, double TTCDSLCauKienDuongTruyenDan_SoLuongCKienDungDeTinhChieuDaiBoSung)
        {
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "Cống tròn".ToUpper() || ThongTinDuongTruyenDan_HinhThucTruyenDan == "Cống hộp".ToUpper())
            {
                return TTCDSLCauKienDuongTruyenDan_XacDinhOngCongCanThem == "Thêm 01" ? Math.Round(TTCDSLCauKienDuongTruyenDan_SlCauKienNguyen + TTCDSLCauKienDuongTruyenDan_SoLuongCKienDungDeTinhChieuDaiBoSung, 2) : TTCDSLCauKienDuongTruyenDan_SlCauKienNguyen;
            }
            return 0;
        }
        public double TTCDSLCauKienDuongTruyenDan_CDaiCanDeLapDatDuocTheoSoCkNguyen(string ThongTinDuongTruyenDan_HinhThucTruyenDan, double TTCDSLCauKienDuongTruyenDan_SlCauKienNguyen, double TTCDSLCauKienDuongTruyenDan_SoLuongCKienDungDeTinhChieuDaiBoSung, double TTCDSLCauKienDuongTruyenDan_ChieuDaiMoiNoiCKien)
        {
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            return (ThongTinDuongTruyenDan_HinhThucTruyenDan == "Cống tròn".ToUpper() || ThongTinDuongTruyenDan_HinhThucTruyenDan == "Cống hộp".ToUpper()) ? Math.Round((TTCDSLCauKienDuongTruyenDan_SlCauKienNguyen - TTCDSLCauKienDuongTruyenDan_SoLuongCKienDungDeTinhChieuDaiBoSung) * TTCDSLCauKienDuongTruyenDan_ChieuDaiMoiNoiCKien, 3) : 0;
        }
        public double TTCDSLCauKienDuongTruyenDan_TongCDaiLapDatTheoSoCkNguyen(string ThongTinDuongTruyenDan_HinhThucTruyenDan, double TTCDSLCauKienDuongTruyenDan_SlCauKienNguyen, double TTCDSLCauKienDuongTruyenDan_ChieuDai01CauKien, double TTCDSLCauKienDuongTruyenDan_CDaiCanDeLapDatDuocTheoSoCkNguyen)
        {
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            return (ThongTinDuongTruyenDan_HinhThucTruyenDan == "Cống tròn".ToUpper() || ThongTinDuongTruyenDan_HinhThucTruyenDan == "Cống hộp".ToUpper()) ? Math.Round((TTCDSLCauKienDuongTruyenDan_SlCauKienNguyen * TTCDSLCauKienDuongTruyenDan_ChieuDai01CauKien) + TTCDSLCauKienDuongTruyenDan_CDaiCanDeLapDatDuocTheoSoCkNguyen, 2) : 0;
        }
        public double TTCDSLCauKienDuongTruyenDan_CDaiThucTeConThuaThieuSoVoiCRongLongMuMoHoGa(string ThongTinDuongTruyenDan_HinhThucTruyenDan, double TTCDSLCauKienDuongTruyenDan_TongCDaiLapDatTheoSoCkNguyen, double TTCDSLCauKienDuongTruyenDan_TongChieuDai)
        {
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            return (ThongTinDuongTruyenDan_HinhThucTruyenDan == "Cống tròn".ToUpper() || ThongTinDuongTruyenDan_HinhThucTruyenDan == "Cống hộp".ToUpper()) ? Math.Round(TTCDSLCauKienDuongTruyenDan_TongCDaiLapDatTheoSoCkNguyen - TTCDSLCauKienDuongTruyenDan_TongChieuDai, 3) : 0;
        }
        public double TTCDSLCauKienDuongTruyenDan_CDaiConThuaThieuSauTinhTheoCkTinhKl(string ThongTinDuongTruyenDan_HinhThucTruyenDan, double TTCDSLCauKienDuongTruyenDan_SlCauKienTinhKl, double TTCDSLCauKienDuongTruyenDan_SoLuongCKienDungDeTinhChieuDaiBoSung, double TTCDSLCauKienDuongTruyenDan_ChieuDaiMoiNoiCKien, double TTCDSLCauKienDuongTruyenDan_ChieuDai01CauKien, double TTCDSLCauKienDuongTruyenDan_TongChieuDai)
        {
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            return (ThongTinDuongTruyenDan_HinhThucTruyenDan == "Cống tròn".ToUpper() || ThongTinDuongTruyenDan_HinhThucTruyenDan == "Cống hộp".ToUpper())
                ? Math.Round((((TTCDSLCauKienDuongTruyenDan_SlCauKienTinhKl - TTCDSLCauKienDuongTruyenDan_SoLuongCKienDungDeTinhChieuDaiBoSung) * TTCDSLCauKienDuongTruyenDan_ChieuDaiMoiNoiCKien) + (TTCDSLCauKienDuongTruyenDan_SlCauKienTinhKl * TTCDSLCauKienDuongTruyenDan_ChieuDai01CauKien)) - TTCDSLCauKienDuongTruyenDan_TongChieuDai, 4)
                : 0;
        }

        public double ThongTinCauTaoCongTron_CCaoCauKien(double ThongTinCauTaoCongTron_CDayPhuBi, double ThongTinCauTaoCongTron_SoCanh, double ThongTinCauTaoCongTron_LongSuDung)
        {
            return Math.Round((ThongTinCauTaoCongTron_CDayPhuBi * ThongTinCauTaoCongTron_SoCanh) + ThongTinCauTaoCongTron_LongSuDung, 2);
        }
        public double ThongTinCauTaoCongTron_TongCCaoCong(double ThongTinCauTaoCongTron_CCaoCauKien, double ThongTinCauTaoCongTron_CCaoLotMong, double ThongTinCauTaoCongTron_CCaoMong, double ThongTinCauTaoCongTron_CCaoDe)
        {
            return Math.Round(ThongTinCauTaoCongTron_CCaoCauKien + ThongTinCauTaoCongTron_CCaoLotMong + ThongTinCauTaoCongTron_CCaoMong + ThongTinCauTaoCongTron_CCaoDe, 2);
        }

        public double TTKTHHCongHopRanh_CCaoTuongRanh(string ThongTinDuongTruyenDan_HinhThucTruyenDan, double CDThuongLuu_CCaoTuongCongRanh, double CDHaLu_CCaoTuongCongRanh)
        {
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "Rãnh xây".ToUpper() || ThongTinDuongTruyenDan_HinhThucTruyenDan == "Rãnh bê tông".ToUpper())
            {
                return Math.Round((CDThuongLuu_CCaoTuongCongRanh + CDHaLu_CCaoTuongCongRanh) / 2, 2);
            }
            return 0;
        }
        public double TTKTHHCongHopRanh_CCaoTuongGop(double TTKTHHCongHopRanh_CCaoTuongCongHop, double TTKTHHCongHopRanh_CCaoTuongRanh)
        {
            return Math.Round(TTKTHHCongHopRanh_CCaoTuongCongHop + TTKTHHCongHopRanh_CCaoTuongRanh, 2);
        }


        public double TTKTHHCongHopRanh_CCaoChatMatTrong(string TTKTHHCongHopRanh_ChatMatTrong, string TTKTHHCongHopRanh_CauTaoTuong, string TTKTHHCongHopRanh_CauTaoMuMo, double TTKTHHCongHopRanh_CCaoTuongGop, double TTKTHHCongHopRanh_CCaoMuMoThotDuoi, double TTKTHHCongHopRanh_CCaoMuMoThotTren)
        {
            TTKTHHCongHopRanh_ChatMatTrong = GetTenDanhMucById(TTKTHHCongHopRanh_ChatMatTrong).ToUpper().Trim();
            TTKTHHCongHopRanh_CauTaoTuong = GetTenDanhMucById(TTKTHHCongHopRanh_CauTaoTuong).ToUpper().Trim();

            if (TTKTHHCongHopRanh_ChatMatTrong == "Có".ToUpper() && TTKTHHCongHopRanh_CauTaoTuong == "Tường xây gạch".ToUpper())
            {
                return TTKTHHCongHopRanh_CauTaoMuMo == "Không mũ mố".ToUpper() ? TTKTHHCongHopRanh_CCaoTuongGop : TTKTHHCongHopRanh_CCaoTuongGop + TTKTHHCongHopRanh_CCaoMuMoThotDuoi + TTKTHHCongHopRanh_CCaoMuMoThotTren;
            }
            else if (TTKTHHCongHopRanh_ChatMatTrong == "Không".ToUpper() && TTKTHHCongHopRanh_CauTaoMuMo == "Mũ mố xây gạch".ToUpper())
            {
                return TTKTHHCongHopRanh_CCaoMuMoThotTren;
            }
            return 0;
        }
        public double TTKTHHCongHopRanh_CCaoChatmatNgoai(string TTKTHHCongHopRanh_ChatMatNgoai, string TTKTHHCongHopRanh_CauTaoTuong, string TTKTHHCongHopRanh_CauTaoMuMo, double TTKTHHCongHopRanh_CCaoTuongGop, double TTKTHHCongHopRanh_CCaoMuMoThotDuoi, double TTKTHHCongHopRanh_CCaoMuMoThotTren, double TTKTHHCongHopRanh_CRongMuMoTren)
        {
            if (TTKTHHCongHopRanh_ChatMatNgoai == "Có" && TTKTHHCongHopRanh_CauTaoTuong == "Tường xây gạch")
            {
                return TTKTHHCongHopRanh_CauTaoMuMo == "Không mũ mố" ? TTKTHHCongHopRanh_CCaoTuongGop : TTKTHHCongHopRanh_CCaoTuongGop + TTKTHHCongHopRanh_CCaoMuMoThotDuoi + TTKTHHCongHopRanh_CCaoMuMoThotTren;
            }
            else if (TTKTHHCongHopRanh_ChatMatNgoai == "Không" && TTKTHHCongHopRanh_CauTaoMuMo == "Mũ mố xây gạch")
            {
                return TTKTHHCongHopRanh_CCaoMuMoThotTren + TTKTHHCongHopRanh_CRongMuMoTren;
            }
            return 0;
        }
        public double TTKTHHCongHopRanh_TongChieuCao(double TTKTHHCongHopRanh_CCaoLotMong, double TTKTHHCongHopRanh_CCaoMong, double TTKTHHCongHopRanh_CCaoDe, double TTKTHHCongHopRanh_CCaoTuongGop, double TTKTHHCongHopRanh_CCaoMuMoThotDuoi, double TTKTHHCongHopRanh_CCaoMuMoThotTren)
        {
            return Math.Round(TTKTHHCongHopRanh_CCaoLotMong + TTKTHHCongHopRanh_CCaoMong + TTKTHHCongHopRanh_CCaoDe + TTKTHHCongHopRanh_CCaoTuongGop + TTKTHHCongHopRanh_CCaoMuMoThotDuoi + TTKTHHCongHopRanh_CCaoMuMoThotTren, 2);
        }

        public double ThongTinKichThuocHinhHocOngNhua_TongCCaoOng(double ThongTinKichThuocHinhHocOngNhua_CDayPhuBi, double ThongTinKichThuocHinhHocOngNhua_SoCanh, double ThongTinKichThuocHinhHocOngNhua_LongSuDung)
        {
            return Math.Round((ThongTinKichThuocHinhHocOngNhua_CDayPhuBi * ThongTinKichThuocHinhHocOngNhua_SoCanh) + ThongTinKichThuocHinhHocOngNhua_LongSuDung, 2);
        }

        public double TTTDCongHoRanh_SoLuong(string ThongTinDuongTruyenDan_HinhThucTruyenDan, double TTTDCongHoRanh_SLCauKienNguyen)
        {
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).Trim().ToUpper();
            return Math.Round((ThongTinDuongTruyenDan_HinhThucTruyenDan == "Cống hộp".ToUpper() || ThongTinDuongTruyenDan_HinhThucTruyenDan == "Rãnh xây".ToUpper() || ThongTinDuongTruyenDan_HinhThucTruyenDan == "Rãnh bê tông".ToUpper()) ? TTTDCongHoRanh_SLCauKienNguyen : 0, 2);
        }


        public int TTTDCongHoRanh_SLCauKienNguyen(string ThongTinDuongTruyenDan_HinhThucTruyenDan, double TTCDSLCauKienDuongTruyenDan_TongChieuDai, double TTTDCongHoRanh_Cdai, double TTTDCongHoRanh_ChieuDaiMoiNoi)
        {
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "Rãnh xây".ToUpper()
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
                    // Trường hợp nếu mẫu số bằng 0, trả về 0
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
            return (ThongTinDuongTruyenDan_HinhThucTruyenDan == "Rãnh xây".ToUpper() || ThongTinDuongTruyenDan_HinhThucTruyenDan == "Rãnh bê tông".ToUpper() || ThongTinDuongTruyenDan_HinhThucTruyenDan == "Cống hộp".ToUpper())
                ? TTTDCongHoRanh_SLCauKienNguyen * TTTDCongHoRanh_ChieuDaiMoiNoi
                : 0;
        }
        public double TTTDCongHoRanh_TongChieuDaiTheoCKNguyen(string ThongTinDuongTruyenDan_HinhThucTruyenDan, double TTTDCongHoRanh_SLCauKienNguyen, double TTTDCongHoRanh_Cdai, double TTTDCongHoRanh_ChieuDaiTheoSoCKNguyen)
        {
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            return (ThongTinDuongTruyenDan_HinhThucTruyenDan == "Rãnh xây".ToUpper() || ThongTinDuongTruyenDan_HinhThucTruyenDan == "Rãnh bê tông".ToUpper() || ThongTinDuongTruyenDan_HinhThucTruyenDan == "Cống hộp".ToUpper())
                ? (TTTDCongHoRanh_SLCauKienNguyen * TTTDCongHoRanh_Cdai) + TTTDCongHoRanh_ChieuDaiTheoSoCKNguyen
                : 0;
        }
        public double TTTDCongHoRanh_ChieuDaiThucTe(string ThongTinDuongTruyenDan_HinhThucTruyenDan, double TTTDCongHoRanh_TongChieuDaiTheoCKNguyen, double TTCDSLCauKienDuongTruyenDan_TongChieuDai)
        {
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            return (ThongTinDuongTruyenDan_HinhThucTruyenDan == "Rãnh xây".ToUpper() || ThongTinDuongTruyenDan_HinhThucTruyenDan == "Rãnh bê tông".ToUpper() || ThongTinDuongTruyenDan_HinhThucTruyenDan == "Cống hộp".ToUpper())
                ? Math.Round(TTTDCongHoRanh_TongChieuDaiTheoCKNguyen - TTCDSLCauKienDuongTruyenDan_TongChieuDai,2)
                : 0;
        }
        public string TTTDCongHoRanh_XacDinhOngCongCanThem(string ThongTinDuongTruyenDan_HinhThucTruyenDan, double TTTDCongHoRanh_ChieuDaiThucTe)
        {
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "Rãnh xây".ToUpper() || ThongTinDuongTruyenDan_HinhThucTruyenDan == "Rãnh bê tông".ToUpper() || ThongTinDuongTruyenDan_HinhThucTruyenDan == "Cống hộp".ToUpper())
            {
                return (TTTDCongHoRanh_ChieuDaiThucTe >= -0.02) ? "Đủ" : "Thêm 01";
            }
            return "0";
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


        public double TTTDCongHoRanh_CDai1(string ThongTinDuongTruyenDan_HinhThucTruyenDan, IEnumerable<string> EPRange, IEnumerable<double> JDRange, IEnumerable<string> JERange)
        {
            // Chuyển đổi EP16 thành dạng chữ hoa và loại bỏ khoảng trắng đầu cuối
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();

            // Lọc các giá trị cần tính trung bình dựa trên điều kiện
            var filteredValues = new List<double>();

            for (int i = 0; i < EPRange.Count(); i++)
            {
                bool condition = false;

                if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "CỐNG HỘP" && EPRange.ElementAt(i) == "Cống hộp" && JERange.ElementAt(i) == "Thêm 01")
                {
                    condition = true;
                }
                else if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "RÃNH XÂY" && EPRange.ElementAt(i) == "Rãnh xây" && JERange.ElementAt(i) == "Thêm 01")
                {
                    condition = true;
                }
                else if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "RÃNH BÊ TÔNG" && EPRange.ElementAt(i) == "Rãnh bê tông" && JERange.ElementAt(i) == "Thêm 01")
                {
                    condition = true;
                }

                if (condition)
                {
                    filteredValues.Add(JDRange.ElementAt(i));
                }
            }

            // Tính trung bình các giá trị đã lọc
            double average = filteredValues.Count > 0 ? filteredValues.Average() : 0;

            // Làm tròn và trả về giá trị tuyệt đối
            return Math.Round(Math.Abs(average), 2);
        }



        public double CDThuongLuu_DinhDeCong(string ThongTinMongDuongTruyenDan_LoaiMong, double CDThuongLuu_DayDongChay, double ThongTinCauTaoCongTron_CDayPhuBi)
        {
            ThongTinMongDuongTruyenDan_LoaiMong = GetTenDanhMucById(ThongTinMongDuongTruyenDan_LoaiMong).ToUpper().Trim();
            if (ThongTinMongDuongTruyenDan_LoaiMong == "Móng bê tông kết hợp đế".ToUpper() || ThongTinMongDuongTruyenDan_LoaiMong == "Đế".ToUpper())
            {
                return Math.Round(CDThuongLuu_DayDongChay - ThongTinCauTaoCongTron_CDayPhuBi, 3);
            }
            else
            {
                return 0;
            }
        }
        public double CDThuongLuu_DinhMongRanh(string ThongTinDuongTruyenDan_HinhThucTruyenDan, string ThongTinMongDuongTruyenDan_LoaiMong, double CDThuongLuu_DayDongChay)
        {
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            ThongTinMongDuongTruyenDan_LoaiMong = GetTenDanhMucById(ThongTinMongDuongTruyenDan_LoaiMong).ToUpper().Trim();
            if ((ThongTinDuongTruyenDan_HinhThucTruyenDan == "Rãnh xây".ToUpper() && ThongTinMongDuongTruyenDan_LoaiMong == "Móng bê tông".ToUpper()) ||
                (ThongTinDuongTruyenDan_HinhThucTruyenDan == "Rãnh bê tông".ToUpper() && ThongTinMongDuongTruyenDan_LoaiMong == "Móng bê tông".ToUpper()))
            {
                return CDThuongLuu_DayDongChay;
            }
            else
            {
                return 0;
            }
        }
        public double CDThuongLuu_DinhMongCongHop(string ThongTinDuongTruyenDan_HinhThucTruyenDan, string ThongTinMongDuongTruyenDan_LoaiMong, double CDThuongLuu_DayDongChay, double TTKTHHCongHopRanh_CCaoDe)
        {
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            ThongTinMongDuongTruyenDan_LoaiMong = GetTenDanhMucById(ThongTinMongDuongTruyenDan_LoaiMong).ToUpper().Trim();
            if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "Cống hộp".ToUpper() && ThongTinMongDuongTruyenDan_LoaiMong == "Móng bê tông".ToUpper())
            {
                return Math.Round(CDThuongLuu_DayDongChay - TTKTHHCongHopRanh_CCaoDe,2);
            }
            else
            {
                return 0;
            }
        }
        public double CDThuongLuu_DinhMongCongTron(string ThongTinDuongTruyenDan_HinhThucTruyenDan, string ThongTinMongDuongTruyenDan_LoaiMong, double CDThuongLuu_DayDongChay, double ThongTinCauTaoCongTron_CDayPhuBi, double CDThuongLuu_DinhDeCong, double ThongTinCauTaoCongTron_CCaoDe)
        {
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            ThongTinMongDuongTruyenDan_LoaiMong = GetTenDanhMucById(ThongTinMongDuongTruyenDan_LoaiMong).ToUpper().Trim();
            if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "Cống tròn".ToUpper())
            {
                if (ThongTinMongDuongTruyenDan_LoaiMong == "Móng bê tông".ToUpper())
                {
                    return Math.Round( CDThuongLuu_DayDongChay - ThongTinCauTaoCongTron_CDayPhuBi,2);
                }
                else if (ThongTinMongDuongTruyenDan_LoaiMong == "Móng bê tông kết hợp đế".ToUpper())
                {
                    return Math.Round(CDThuongLuu_DinhDeCong - ThongTinCauTaoCongTron_CCaoDe,2);
                }
            }
            return 0;
        }
        public double CDThuongLuu_DinhMongChanKhay(string ThongTinDuongTruyenDan_HinhThucTruyenDan, string ThongTinRanhThang_CauTaoChanKhay, double CDThuongLuu_DayDongChay)
        {
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "Rãnh thang".ToUpper())
            {
                if (ThongTinRanhThang_CauTaoChanKhay == "Bê tông".ToUpper() || ThongTinRanhThang_CauTaoChanKhay == "Bê tông cốt thép".ToUpper())
                {
                    return CDThuongLuu_DayDongChay;
                }
            }
            return 0;
        }
        public double CDThuongLuu_DinhMongRanhThang(string ThongTinDuongTruyenDan_HinhThucTruyenDan, string ThongTinMongDuongTruyenDan_LoaiMong, double CDThuongLuu_DayDongChay)
        {
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            ThongTinMongDuongTruyenDan_LoaiMong = GetTenDanhMucById(ThongTinMongDuongTruyenDan_LoaiMong).ToUpper().Trim();
            if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "Rãnh thang".ToUpper() && ThongTinMongDuongTruyenDan_LoaiMong == "Móng bê tông".ToUpper())
            {
                return CDThuongLuu_DayDongChay;
            }
            return 0;
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
            else if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "Rãnh xây".ToUpper() || ThongTinDuongTruyenDan_HinhThucTruyenDan == "Rãnh bê tông".ToUpper())
            {
                if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "Rãnh xây".ToUpper() && ThongTinMongDuongTruyenDan_LoaiMong == "Móng bê tông".ToUpper())
                {
                    result = CDThuongLuu_DayDongChay;
                }
                else if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "Rãnh bê tông".ToUpper() && ThongTinMongDuongTruyenDan_LoaiMong == "Móng bê tông".ToUpper())
                {
                    result = CDThuongLuu_DayDongChay;
                }
               
            }
            return Math.Round(result, 2);
        }
        public double CDThuongLuu_DinhLotRanh(string ThongTinDuongTruyenDan_HinhThucTruyenDan, string ThongTinMongDuongTruyenDan_LoaiMong, double CDThuongLuu_DinhMongRanh, double TTKTHHCongHopRanh_CCaoMong)
        {
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            ThongTinMongDuongTruyenDan_LoaiMong = GetTenDanhMucById(ThongTinMongDuongTruyenDan_LoaiMong).ToUpper().Trim();
            if ((ThongTinDuongTruyenDan_HinhThucTruyenDan == "Rãnh xây".ToUpper() || ThongTinDuongTruyenDan_HinhThucTruyenDan == "Rãnh bê tông".ToUpper()) && ThongTinMongDuongTruyenDan_LoaiMong == "Móng bê tông".ToUpper())
            {
                return Math.Round(CDThuongLuu_DinhMongRanh - TTKTHHCongHopRanh_CCaoMong,2);
            }
            return 0;
        }
        public double CDThuongLuu_DinhLotCongHop(string ThongTinDuongTruyenDan_HinhThucTruyenDan, string ThongTinMongDuongTruyenDan_LoaiMong, double CDThuongLuu_DinhMongCongHop, double TTKTHHCongHopRanh_CCaoMong)
        {
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            ThongTinMongDuongTruyenDan_LoaiMong = GetTenDanhMucById(ThongTinMongDuongTruyenDan_LoaiMong).ToUpper().Trim();
            if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "Cống hộp".ToUpper() && ThongTinMongDuongTruyenDan_LoaiMong == "Móng bê tông".ToUpper())
            {
                return Math.Round(CDThuongLuu_DinhMongCongHop - TTKTHHCongHopRanh_CCaoMong,2);
            }
            return 0;
        }
        public double CDThuongLuu_DinhLotCongTron(string ThongTinDuongTruyenDan_HinhThucTruyenDan, string ThongTinMongDuongTruyenDan_LoaiMong, double CDThuongLuu_DinhMongCongTron, double ThongTinCauTaoCongTron_CCaoMong)
        {
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            ThongTinMongDuongTruyenDan_LoaiMong = GetTenDanhMucById(ThongTinMongDuongTruyenDan_LoaiMong).ToUpper().Trim();
            if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "Cống tròn".ToUpper() && (ThongTinMongDuongTruyenDan_LoaiMong == "Móng bê tông".ToUpper() || ThongTinMongDuongTruyenDan_LoaiMong == "Móng bê tông kết hợp đế".ToUpper()))
            {
                return Math.Round( CDThuongLuu_DinhMongCongTron - ThongTinCauTaoCongTron_CCaoMong ,2);
            }
            return 0;
        }
        public double CDThuongLuu_DinhLotOngNhua(string ThongTinDuongTruyenDan_HinhThucTruyenDan, string ThongTinMongDuongTruyenDan_LoaiMong, double CDThuongLuu_DayDongChay, double ThongTinKichThuocHinhHocOngNhua_CDayPhuBi)
        {
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            ThongTinMongDuongTruyenDan_LoaiMong = GetTenDanhMucById(ThongTinMongDuongTruyenDan_LoaiMong).ToUpper().Trim();
            if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "Ống nhựa".ToUpper() && ThongTinMongDuongTruyenDan_LoaiMong == "Đắp cát".ToUpper())
            {
                return Math.Round( CDThuongLuu_DayDongChay - ThongTinKichThuocHinhHocOngNhua_CDayPhuBi,2);
            }
            return 0;
        }
        public double CDThuongLuu_DinhLotGiangDinhRanhThang(string ThongTinDuongTruyenDan_HinhThucTruyenDan, string ThongTinRanhThang_CauTaoGiangDinh, double CDThuongLuu_DinhRanhThang, double ThongTinRanhThang_CCaoMongGiangDinh)
        {
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            ThongTinRanhThang_CauTaoGiangDinh = GetTenDanhMucById(ThongTinRanhThang_CauTaoGiangDinh).ToUpper().Trim();
            if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "Rãnh thang".ToUpper() && (ThongTinRanhThang_CauTaoGiangDinh == "Bê tông".ToUpper() || ThongTinRanhThang_CauTaoGiangDinh == "Bê tông cốt thép".ToUpper()))
            {
                return Math.Round(CDThuongLuu_DinhRanhThang - ThongTinRanhThang_CCaoMongGiangDinh,2);
            }
            return 0;
        }
        public double CDThuongLuu_DinhLotChanKhayRanhThang(string ThongTinDuongTruyenDan_HinhThucTruyenDan, string ThongTinRanhThang_CauTaoChanKhay, double CDThuongLuu_DayDongChay, double ThongTinRanhThang_CCaoMongChanKhay)
        {
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            ThongTinRanhThang_CauTaoChanKhay = GetTenDanhMucById(ThongTinRanhThang_CauTaoChanKhay).ToUpper().Trim();
            if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "Rãnh thang".ToUpper() && (ThongTinRanhThang_CauTaoChanKhay == "Bê tông".ToUpper() || ThongTinRanhThang_CauTaoChanKhay == "Bê tông cốt thép".ToUpper()))
            {
                return Math.Round(CDThuongLuu_DayDongChay - ThongTinRanhThang_CCaoMongChanKhay,2);
            }
            return 0;
        }
        public double CDThuongLuu_DinhLotRanhThang(string ThongTinDuongTruyenDan_HinhThucTruyenDan, string ThongTinMongDuongTruyenDan_LoaiMong, double CDThuongLuu_DayDongChay, double ThongTinRanhThang_CCaoMong)
        {
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            ThongTinMongDuongTruyenDan_LoaiMong = GetTenDanhMucById(ThongTinMongDuongTruyenDan_LoaiMong).ToUpper().Trim();
            if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "Rãnh thang".ToUpper() && ThongTinMongDuongTruyenDan_LoaiMong == "Móng bê tông".ToUpper())
            {
                return Math.Round(CDThuongLuu_DayDongChay - ThongTinRanhThang_CCaoMong,2);
            }
            return 0;
        }
        public double CDThuongLuu_DinhLotGop(string ThongTinDuongTruyenDan_HinhThucTruyenDan, string ThongTinMongDuongTruyenDan_LoaiMong, double CDThuongLuu_DayDongChay, double ThongTinRanhThang_CCaoMong, double ThongTinKichThuocHinhHocOngNhua_CDayPhuBi, double CDThuongLuu_DinhMongCongTron, double ThongTinCauTaoCongTron_CCaoMong, double CDThuongLuu_DinhMongCongHop, double TTKTHHCongHopRanh_CCaoMong, double CDThuongLuu_DinhMongRanh)
        {
            double result = 0;
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            ThongTinMongDuongTruyenDan_LoaiMong = GetTenDanhMucById(ThongTinMongDuongTruyenDan_LoaiMong).ToUpper().Trim();
            if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "Rãnh thang".ToUpper())
            {
                if (ThongTinMongDuongTruyenDan_LoaiMong == "Móng bê tông".ToUpper())
                {
                    result = CDThuongLuu_DayDongChay - ThongTinRanhThang_CCaoMong;
                }
            }
            else if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "Ống nhựa".ToUpper())
            {
                if (ThongTinMongDuongTruyenDan_LoaiMong == "Đắp cát".ToUpper())
                {
                    result = CDThuongLuu_DayDongChay - ThongTinKichThuocHinhHocOngNhua_CDayPhuBi;
                }
            }
            else if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "Cống tròn".ToUpper())
            {
                if (ThongTinMongDuongTruyenDan_LoaiMong == "Móng bê tông".ToUpper() || ThongTinMongDuongTruyenDan_LoaiMong == "Móng bê tông kết hợp đế".ToUpper())
                {
                    result = CDThuongLuu_DinhMongCongTron - ThongTinCauTaoCongTron_CCaoMong;
                }
            }
            else if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "Cống hộp".ToUpper())
            {
                if (ThongTinMongDuongTruyenDan_LoaiMong == "Móng bê tông".ToUpper())
                {
                    result = CDThuongLuu_DinhMongCongHop - TTKTHHCongHopRanh_CCaoMong;
                }
            }
            else if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "Rãnh xây".ToUpper() || ThongTinDuongTruyenDan_HinhThucTruyenDan == "Rãnh bê tông".ToUpper())
            {
                if (ThongTinMongDuongTruyenDan_LoaiMong == "Móng bê tông".ToUpper())
                {
                    result = CDThuongLuu_DinhMongRanh - TTKTHHCongHopRanh_CCaoMong;
                }
            }

            return Math.Round(result,2);
        }
        public double CDThuongLuu_DayDaoRanhThang(string ThongTinDuongTruyenDan_HinhThucTruyenDan, string ThongTinMongDuongTruyenDan_LoaiMong, double CDThuongLuu_DinhLotRanhThang, double ThongTinRanhThang_CCaoLot, double CDThuongLuu_DayDongChay)
        {
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "Rãnh thang".ToUpper())
            {
                if (ThongTinMongDuongTruyenDan_LoaiMong == "Móng bê tông".ToUpper())
                {
                    return Math.Round( CDThuongLuu_DinhLotRanhThang - ThongTinRanhThang_CCaoLot,2);
                }
                else
                {
                    return CDThuongLuu_DayDongChay;
                }
            }
            return 0;
        }
        public double CDThuongLuu_DayDaoChanKhayRanhThang(string ThongTinDuongTruyenDan_HinhThucTruyenDan, string ThongTinRanhThang_CauTaoChanKhay, double CDThuongLuu_DinhLotChanKhayRanhThang, double ThongTinRanhThang_CCaoLotChanKhay, double CDThuongLuu_DayDongChay)
        {
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            ThongTinRanhThang_CauTaoChanKhay = GetTenDanhMucById(ThongTinRanhThang_CauTaoChanKhay).ToUpper().Trim();
            if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "Rãnh thang".ToUpper())
            {
                if (ThongTinRanhThang_CauTaoChanKhay == "Bê tông".ToUpper() || ThongTinRanhThang_CauTaoChanKhay == "Bê tông cốt thép".ToUpper())
                {
                    return Math.Round(CDThuongLuu_DinhLotChanKhayRanhThang - ThongTinRanhThang_CCaoLotChanKhay,2);
                }
                else
                {
                    return CDThuongLuu_DayDongChay;
                }
            }
            return 0;
        }
        public double CDThuongLuu_DayDaoGiangDinhRanhThang(string ThongTinDuongTruyenDan_HinhThucTruyenDan, string ThongTinRanhThang_CauTaoGiangDinh, double CDThuongLuu_DinhLotGiangDinhRanhThang, double ThongTinRanhThang_CCaoLotGiangDinh, double CDThuongLuu_DinhRanhThang)
        {
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            ThongTinRanhThang_CauTaoGiangDinh = GetTenDanhMucById(ThongTinRanhThang_CauTaoGiangDinh).ToUpper().Trim();
            if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "Rãnh thang".ToUpper())
            {
                if (ThongTinRanhThang_CauTaoGiangDinh == "Bê tông".ToUpper() || ThongTinRanhThang_CauTaoGiangDinh == "Bê tông cốt thép".ToUpper())
                {
                    return CDThuongLuu_DinhLotGiangDinhRanhThang - ThongTinRanhThang_CCaoLotGiangDinh;
                }
                else
                {
                    return CDThuongLuu_DinhRanhThang;
                }
            }
            return 0;
        }
        public double CDThuongLuu_DayDaoOngNhua(string ThongTinDuongTruyenDan_HinhThucTruyenDan, string ThongTinMongDuongTruyenDan_LoaiMong, double CDThuongLuu_DayDongChay, double ThongTinKichThuocHinhHocOngNhua_CDayPhuBi, double CDThuongLuu_DinhLotOngNhua, double ThongTinKichThuocHinhHocOngNhua_CCaoDemCat)
        {
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            ThongTinMongDuongTruyenDan_LoaiMong = GetTenDanhMucById(ThongTinMongDuongTruyenDan_LoaiMong).ToUpper().Trim();
            if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "Ống nhựa".ToUpper())
            {
                if (ThongTinMongDuongTruyenDan_LoaiMong == "Không đắp cát".ToUpper())
                {
                    return Math.Round(CDThuongLuu_DayDongChay - ThongTinKichThuocHinhHocOngNhua_CDayPhuBi,2);
                }
                else if (ThongTinMongDuongTruyenDan_LoaiMong == "Đắp cát".ToUpper())
                {
                    return Math.Round(CDThuongLuu_DinhLotOngNhua - ThongTinKichThuocHinhHocOngNhua_CCaoDemCat,2);
                }
            }
            return 0;
        }
        public double CDThuongLuu_DayDaoRanh(string ThongTinDuongTruyenDan_HinhThucTruyenDan, double CDThuongLuu_DinhLotRanh, double TTKTHHCongHopRanh_CCaoLotMong)
        {
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "Rãnh xây".ToUpper() || ThongTinDuongTruyenDan_HinhThucTruyenDan == "Rãnh bê tông".ToUpper())
            {
                return Math.Round(CDThuongLuu_DinhLotRanh - TTKTHHCongHopRanh_CCaoLotMong,2);
            }
            return 0;
        }
        public double CDThuongLuu_DayDaoCongHop(string ThongTinDuongTruyenDan_HinhThucTruyenDan, string ThongTinMongDuongTruyenDan_LoaiMong, double CDThuongLuu_DayDongChay, double TTKTHHCongHopRanh_CCaoDe, double CDThuongLuu_DinhLotCongHop, double TTKTHHCongHopRanh_CCaoLotMong)
        {
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            ThongTinMongDuongTruyenDan_LoaiMong = GetTenDanhMucById(ThongTinMongDuongTruyenDan_LoaiMong).ToUpper().Trim();
            if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "Cống hộp".ToUpper())
            {
                if (ThongTinMongDuongTruyenDan_LoaiMong == "Không có móng".ToUpper())
                {
                    return Math.Round(CDThuongLuu_DayDongChay - TTKTHHCongHopRanh_CCaoDe,2);
                }
                else if (ThongTinMongDuongTruyenDan_LoaiMong == "Móng bê tông".ToUpper())
                {
                    return Math.Round(CDThuongLuu_DinhLotCongHop - TTKTHHCongHopRanh_CCaoLotMong,2);
                }
            }
            return 0;
        }
        public double CDThuongLuu_DayDaoCongTron(string ThongTinDuongTruyenDan_HinhThucTruyenDan, string ThongTinMongDuongTruyenDan_LoaiMong, double CDThuongLuu_DayDongChay, double ThongTinCauTaoCongTron_CDayPhuBi, double CDThuongLuu_DinhDeCong, double ThongTinCauTaoCongTron_CCaoDe, double CDThuongLuu_DinhLotCongTron, double ThongTinCauTaoCongTron_CCaoLotMong)
        {
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            ThongTinMongDuongTruyenDan_LoaiMong = GetTenDanhMucById(ThongTinMongDuongTruyenDan_LoaiMong).ToUpper().Trim();
            if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "Cống tròn".ToUpper())
            {
                if (ThongTinMongDuongTruyenDan_LoaiMong == "Không có móng".ToUpper())
                {
                    return Math.Round(CDThuongLuu_DayDongChay - ThongTinCauTaoCongTron_CDayPhuBi,2);
                }
                else if (ThongTinMongDuongTruyenDan_LoaiMong == "Đế".ToUpper())
                {
                    return Math.Round(CDThuongLuu_DinhDeCong - ThongTinCauTaoCongTron_CCaoDe,2);
                }
                else if (ThongTinMongDuongTruyenDan_LoaiMong == "Móng bê tông".ToUpper() || ThongTinMongDuongTruyenDan_LoaiMong == "Móng bê tông kết hợp đế".ToUpper())
                {
                    return Math.Round(CDThuongLuu_DinhLotCongTron - ThongTinCauTaoCongTron_CCaoLotMong,2);
                }
            }
            return 0;
        }
        public double CDThuongLuu_DayDaoGop(string ThongTinDuongTruyenDan_HinhThucTruyenDan, string ThongTinMongDuongTruyenDan_LoaiMong, double CDThuongLuu_DayDongChay, double ThongTinCauTaoCongTron_CDayPhuBi, double CDThuongLuu_DinhDeCong, double ThongTinCauTaoCongTron_CCaoDe, double CDThuongLuu_DinhLotCongTron, double ThongTinCauTaoCongTron_CCaoLotMong, double TTKTHHCongHopRanh_CCaoDe, double CDThuongLuu_DinhLotCongHop, double TTKTHHCongHopRanh_CCaoLotMong, double CDThuongLuu_DinhLotRanh, double ThongTinKichThuocHinhHocOngNhua_CDayPhuBi, double CDThuongLuu_DinhLotOngNhua, double ThongTinKichThuocHinhHocOngNhua_CCaoDemCat, double CDThuongLuu_DinhLotRanhThang, double ThongTinRanhThang_CCaoLot)
        {
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            ThongTinMongDuongTruyenDan_LoaiMong = GetTenDanhMucById(ThongTinMongDuongTruyenDan_LoaiMong).ToUpper().Trim();
            if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "Cống tròn".ToUpper())
            {
                if (ThongTinMongDuongTruyenDan_LoaiMong == "Không có móng".ToUpper())
                {
                    return Math.Round(CDThuongLuu_DayDongChay - ThongTinCauTaoCongTron_CDayPhuBi, 2);
                }
                else if (ThongTinMongDuongTruyenDan_LoaiMong == "Đế".ToUpper())
                {
                    return Math.Round(CDThuongLuu_DinhDeCong - ThongTinCauTaoCongTron_CCaoDe, 2);
                }
                else if (ThongTinMongDuongTruyenDan_LoaiMong == "Móng bê tông".ToUpper() || ThongTinMongDuongTruyenDan_LoaiMong == "Móng bê tông kết hợp đế".ToUpper())
                {
                    return Math.Round(CDThuongLuu_DinhLotCongTron - ThongTinCauTaoCongTron_CCaoLotMong, 2);
                }
            }
            else if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "Cống hộp".ToUpper())
            {
                if (ThongTinMongDuongTruyenDan_LoaiMong == "Không có móng".ToUpper())
                {
                    return Math.Round(CDThuongLuu_DayDongChay - TTKTHHCongHopRanh_CCaoDe, 2);
                }
                else if (ThongTinMongDuongTruyenDan_LoaiMong == "Móng bê tông".ToUpper())
                {
                    return Math.Round(CDThuongLuu_DinhLotCongHop - TTKTHHCongHopRanh_CCaoLotMong, 2);
                }
            }
            else if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "Rãnh xây".ToUpper() || ThongTinDuongTruyenDan_HinhThucTruyenDan == "Rãnh bê tông".ToUpper())
            {
                return Math.Round(CDThuongLuu_DinhLotRanh - TTKTHHCongHopRanh_CCaoLotMong, 2);
            }
            else if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "Ống nhựa".ToUpper())
            {
                if (ThongTinMongDuongTruyenDan_LoaiMong == "Không đắp cát".ToUpper())
                {
                    return Math.Round(CDThuongLuu_DayDongChay - ThongTinKichThuocHinhHocOngNhua_CDayPhuBi, 2);
                }
                else if (ThongTinMongDuongTruyenDan_LoaiMong == "Đắp cát".ToUpper())
                {
                    return Math.Round(CDThuongLuu_DinhLotOngNhua - ThongTinKichThuocHinhHocOngNhua_CCaoDemCat, 2);
                }
            }
            else if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "Rãnh thang".ToUpper())
            {
                if (ThongTinMongDuongTruyenDan_LoaiMong == "Móng bê tông".ToUpper())
                {
                    return Math.Round(CDThuongLuu_DinhLotRanhThang - ThongTinRanhThang_CCaoLot, 2);
                }
                else
                {
                    return Math.Round(CDThuongLuu_DayDongChay, 2);
                }
            }

            return 0;
        }
        public double CDThuongLuu_ChieuSauDao(double CDThuongLuu_HienTrangTruocKhiDaoThuongLuu, double CDThuongLuu_DayDaoGop)
        {
            return CDThuongLuu_DayDaoGop > 0 ? Math.Round(CDThuongLuu_HienTrangTruocKhiDaoThuongLuu - CDThuongLuu_DayDaoGop,2) : 0;
        }


        public double CDThuongLuu_DinhRanhThang(string ThongTinDuongTruyenDan_HinhThucTruyenDan, double CDThuongLuu_DayDongChay, double CDThuongLuu_ChieuCaoRanhThangTuDayDongChayDenDinh)
        {
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "RÃNH THANG")
            {
                return Math.Round(CDThuongLuu_DayDongChay + CDThuongLuu_ChieuCaoRanhThangTuDayDongChayDenDinh, 2);
            }
            else
            {
                return 0;
            }
        }
        public double CDThuongLuu_DinhCongTron(string ThongTinDuongTruyenDan_HinhThucTruyenDan, double CDThuongLuu_DinhTrongLongSuDung, double ThongTinCauTaoCongTron_CDayPhuBi)
        {
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "CỐNG TRÒN")
            {
                return Math.Round(CDThuongLuu_DinhTrongLongSuDung + ThongTinCauTaoCongTron_CDayPhuBi, 2);
            }
            else
            {
                return 0;
            }
        }
        public double CDThuongLuu_DinhCongHop(string ThongTinDuongTruyenDan_HinhThucTruyenDan, double CDThuongLuu_DinhTrongLongSuDung, double TTKTHHCongHopRanh_CCaoMuMoThotTren)
        {
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "CỐNG HỘP")
            {
                return Math.Round(CDThuongLuu_DinhTrongLongSuDung + TTKTHHCongHopRanh_CCaoMuMoThotTren, 2);
            }
            else
            {
                return 0;
            }
        }
        public double CDThuongLuu_DinhRanh(string ThongTinDuongTruyenDan_HinhThucTruyenDan, double CDThuongLuu_DinhTrongLongSuDung, double TTKTHHCongHopRanh_CCaoMuMoThotTren)
        {
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "RÃNH XÂY" || ThongTinDuongTruyenDan_HinhThucTruyenDan == "RÃNH BÊ TÔNG")
            {
                return Math.Round(CDThuongLuu_DinhTrongLongSuDung + TTKTHHCongHopRanh_CCaoMuMoThotTren, 2);
            }
            else
            {
                return 0;
            }
        }
        public double CDThuongLuu_DinhOngNhua(string ThongTinDuongTruyenDan_HinhThucTruyenDan, double CDThuongLuu_DinhTrongLongSuDung, double ThongTinKichThuocHinhHocOngNhua_CDayPhuBi)
        {
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "ỐNG NHỰA")
            {
                return Math.Round(CDThuongLuu_DinhTrongLongSuDung + ThongTinKichThuocHinhHocOngNhua_CDayPhuBi, 2);
            }
            else
            {
                return 0;
            }
        }
        public double CDThuongLuu_DinhDapCat(string ThongTinDuongTruyenDan_HinhThucTruyenDan, double CDThuongLuu_DinhOngNhua, double ThongTinKichThuocHinhHocOngNhua_CCaoDapCat)
        {
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "ỐNG NHỰA")
            {
                return Math.Round(CDThuongLuu_DinhOngNhua + ThongTinKichThuocHinhHocOngNhua_CCaoDapCat, 2);
            }
            else
            {
                return 0;
            }
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

            return Math.Round(result, 2);
        }
        public double CDThuongLuu_DinhGiangDinhRanhThang(string ThongTinDuongTruyenDan_HinhThucTruyenDan, string ThongTinRanhThang_CauTaoGiangDinh, double ThongTinRanhThang_CRongMongChanKhay)
        {
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "RÃNH THANG")
            {
                if (ThongTinRanhThang_CauTaoGiangDinh == "BÊ TÔNG" || ThongTinRanhThang_CauTaoGiangDinh == "BÊ TÔNG CỐT THÉP")
                {
                    return Math.Round(ThongTinRanhThang_CRongMongChanKhay, 2);
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
        public double CDThuongLuu_DinhGop(string ThongTinDuongTruyenDan_HinhThucTruyenDan, double CDThuongLuu_DinhTrongLongSuDung, double ThongTinCauTaoCongTron_CDayPhuBi, double TTKTHHCongHopRanh_CCaoMuMoThotTren, double ThongTinKichThuocHinhHocOngNhua_CDayPhuBi, double CDThuongLuu_DayDongChay, double CDThuongLuu_ChieuCaoRanhThangTuDayDongChayDenDinh)
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
                result = CDThuongLuu_DayDongChay + CDThuongLuu_ChieuCaoRanhThangTuDayDongChayDenDinh;
            }

            return Math.Round(result, 2);
        }


        public double CDThuongLuu_DinhTuongCHopRanh(string ThongTinDuongTruyenDan_HinhThucTruyenDan, double CDThuongLuu_DinhMuMoThotDuoiCongHopRanh, double TTKTHHCongHopRanh_CCaoMuMoThotDuoi)
        {
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "RÃNH XÂY" || ThongTinDuongTruyenDan_HinhThucTruyenDan == "RÃNH BÊ TÔNG" || ThongTinDuongTruyenDan_HinhThucTruyenDan == "CỐNG HỘP")
            {
                return Math.Round(CDThuongLuu_DinhMuMoThotDuoiCongHopRanh - TTKTHHCongHopRanh_CCaoMuMoThotDuoi, 2);
            }
            else
            {
                return 0;
            }
        }
        public double CDThuongLuu_CCaoTuongCongRanh(string ThongTinDuongTruyenDan_HinhThucTruyenDan, double CDThuongLuu_DinhTuongCHopRanh, double CDThuongLuu_DayDongChay)
        {
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "RÃNH XÂY" || ThongTinDuongTruyenDan_HinhThucTruyenDan == "RÃNH BÊ TÔNG" || ThongTinDuongTruyenDan_HinhThucTruyenDan == "CỐNG HỘP")
            {
                return Math.Round(CDThuongLuu_DinhTuongCHopRanh - CDThuongLuu_DayDongChay, 2);
            }
            else
            {
                return 0;
            }
        }



        public double CDHaLu_DinhRanhThang(string ThongTinDuongTruyenDan_HinhThucTruyenDan, double CDHaLu_DayDongChay, double CDHaLu_ChieuCaoRanhThangTuDayDongChayDenDinh)
        {
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            return ThongTinDuongTruyenDan_HinhThucTruyenDan == "Rãnh thang".ToUpper() ? Math.Round(CDHaLu_DayDongChay + CDHaLu_ChieuCaoRanhThangTuDayDongChayDenDinh, 2) : 0;
        }
        public double CDHaLu_DinhDapCat(string ThongTinDuongTruyenDan_HinhThucTruyenDan, double CDHaLu_DinhOngNhua, double ThongTinKichThuocHinhHocOngNhua_CCaoDapCat)
        {
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            return ThongTinDuongTruyenDan_HinhThucTruyenDan == "Ống nhựa".ToUpper() ? Math.Round(CDHaLu_DinhOngNhua + ThongTinKichThuocHinhHocOngNhua_CCaoDapCat, 2) : 0;
        }
        public double CDHaLu_DinhOngNhua(string ThongTinDuongTruyenDan_HinhThucTruyenDan, double CDHaLu_DinhTrongLongSuDung, double ThongTinKichThuocHinhHocOngNhua_CDayPhuBi)
        {
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            return ThongTinDuongTruyenDan_HinhThucTruyenDan == "Ống nhựa".ToUpper() ? Math.Round(CDHaLu_DinhTrongLongSuDung + ThongTinKichThuocHinhHocOngNhua_CDayPhuBi, 2) : 0;
        }
        public double CDHaLu_DinhRanh(string ThongTinDuongTruyenDan_HinhThucTruyenDan, double CDHaLu_DinhTrongLongSuDung, double TTKTHHCongHopRanh_CCaoMuMoThotTren)
        {
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            return (ThongTinDuongTruyenDan_HinhThucTruyenDan == "Rãnh xây".ToUpper() || ThongTinDuongTruyenDan_HinhThucTruyenDan == "Rãnh bê tông".ToUpper())
                ? Math.Round(CDHaLu_DinhTrongLongSuDung + TTKTHHCongHopRanh_CCaoMuMoThotTren, 2)
                : 0;
        }
        public double CDHaLu_DinhCongHop(string ThongTinDuongTruyenDan_HinhThucTruyenDan, double CDHaLu_DinhTrongLongSuDung, double TTKTHHCongHopRanh_CCaoMuMoThotTren)
        {
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            return ThongTinDuongTruyenDan_HinhThucTruyenDan == "Cống hộp".ToUpper()
                ? Math.Round(CDHaLu_DinhTrongLongSuDung + TTKTHHCongHopRanh_CCaoMuMoThotTren, 2)
                : 0;
        }
        public double CDHaLu_DinhCongTron(string ThongTinDuongTruyenDan_HinhThucTruyenDan, double CDHaLu_DinhTrongLongSuDung, double ThongTinCauTaoCongTron_CDayPhuBi)
        {
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            return ThongTinDuongTruyenDan_HinhThucTruyenDan == "Cống tròn".ToUpper()
                ? Math.Round(CDHaLu_DinhTrongLongSuDung + ThongTinCauTaoCongTron_CDayPhuBi, 2)
                : 0;
        }
        public double CDHaLu_DinhGop(string ThongTinDuongTruyenDan_HinhThucTruyenDan, double CDHaLu_DinhTrongLongSuDung, double ThongTinCauTaoCongTron_CDayPhuBi, double TTKTHHCongHopRanh_CCaoMuMoThotTren, double ThongTinKichThuocHinhHocOngNhua_CDayPhuBi, double CDHaLu_DayDongChay, double CDHaLu_ChieuCaoRanhThangTuDayDongChayDenDinh)
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
            else if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "Rãnh xây".ToUpper() || ThongTinDuongTruyenDan_HinhThucTruyenDan == "Rãnh bê tông".ToUpper())
            {
                result = CDHaLu_DinhTrongLongSuDung + TTKTHHCongHopRanh_CCaoMuMoThotTren;
            }
            else if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "Ống nhựa".ToUpper())
            {
                result = CDHaLu_DinhTrongLongSuDung + ThongTinKichThuocHinhHocOngNhua_CDayPhuBi;
            }
            else if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "Rãnh thang".ToUpper())
            {
                result = CDHaLu_DayDongChay + CDHaLu_ChieuCaoRanhThangTuDayDongChayDenDinh;
            }

            return Math.Round(result, 2);
        }
        public double CDHaLu_DinhGiangDinhRanhThang(string ThongTinDuongTruyenDan_HinhThucTruyenDan, string ThongTinRanhThang_CauTaoGiangDinh, double CDHaLu_DinhRanhThang)
        {
            double result = 0;
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "Rãnh thang".ToUpper() && (ThongTinRanhThang_CauTaoGiangDinh == "Bê tông".ToUpper() || ThongTinRanhThang_CauTaoGiangDinh == "Bê tông cốt thép".ToUpper()))
            {
                result = CDHaLu_DinhRanhThang;
            }

            return Math.Round(result, 2);
        }
        public double CDHaLu_DinhMuMoThotDuoiCongHopRanh(string ThongTinDuongTruyenDan_HinhThucTruyenDan, double CDHaLu_DinhCongHop, double TTKTHHCongHopRanh_CCaoMuMoThotTren, double CDHaLu_DinhRanh)
        {
            double result = 0;
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "Cống hộp".ToUpper())
            {
                result = CDHaLu_DinhCongHop - TTKTHHCongHopRanh_CCaoMuMoThotTren;
            }
            else if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "Rãnh xây".ToUpper() || ThongTinDuongTruyenDan_HinhThucTruyenDan == "Rãnh bê tông".ToUpper())
            {
                result = CDHaLu_DinhRanh - TTKTHHCongHopRanh_CCaoMuMoThotTren;
            }

            return Math.Round(result, 2);
        }
        public double CDHaLu_DinhTuongCHopRanh(string ThongTinDuongTruyenDan_HinhThucTruyenDan, double CDHaLu_DinhMuMoThotDuoiCongHopRanh, double TTKTHHCongHopRanh_CCaoMuMoThotDuoi)
        {
            double result = 0;
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "Rãnh xây".ToUpper() || ThongTinDuongTruyenDan_HinhThucTruyenDan == "Rãnh bê tông".ToUpper() || ThongTinDuongTruyenDan_HinhThucTruyenDan == "Cống hộp".ToUpper())
            {
                result = CDHaLu_DinhMuMoThotDuoiCongHopRanh - TTKTHHCongHopRanh_CCaoMuMoThotDuoi;
            }

            return Math.Round(result, 2);
        }
        public double CDHaLu_CCaoTuongCongRanh(string ThongTinDuongTruyenDan_HinhThucTruyenDan, double CDHaLu_DinhTuongCHopRanh, double CDHaLu_DayDongChay)
        {
            double result = 0;
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "Rãnh xây".ToUpper() || ThongTinDuongTruyenDan_HinhThucTruyenDan == "Rãnh bê tông".ToUpper() || ThongTinDuongTruyenDan_HinhThucTruyenDan == "Cống hộp".ToUpper())
            {
                result = CDHaLu_DinhTuongCHopRanh - CDHaLu_DayDongChay;
            }

            return Math.Round(result, 2);
        }
        public double CDHaLu_DinhDeCong(string ThongTinMongDuongTruyenDan_LoaiMong, double CDHaLu_DayDongChay, double ThongTinCauTaoCongTron_CDayPhuBi)
        {
            double result = 0;
            ThongTinMongDuongTruyenDan_LoaiMong = GetTenDanhMucById(ThongTinMongDuongTruyenDan_LoaiMong).ToUpper().Trim();
            if (ThongTinMongDuongTruyenDan_LoaiMong == "Móng bê tông kết hợp đế".ToUpper() || ThongTinMongDuongTruyenDan_LoaiMong == "Đế".ToUpper())
            {
                result = CDHaLu_DayDongChay - ThongTinCauTaoCongTron_CDayPhuBi;
            }

            return Math.Round(result, 2);
        }
        public double CDHaLu_DinhMongRanh(string ThongTinDuongTruyenDan_HinhThucTruyenDan, string ThongTinMongDuongTruyenDan_LoaiMong, double CDHaLu_DayDongChay)
        {
            double result = 0;
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            ThongTinMongDuongTruyenDan_LoaiMong = GetTenDanhMucById(ThongTinMongDuongTruyenDan_LoaiMong).ToUpper().Trim();
            if ((ThongTinDuongTruyenDan_HinhThucTruyenDan == "Rãnh xây".ToUpper() || ThongTinDuongTruyenDan_HinhThucTruyenDan == "Rãnh bê tông".ToUpper()) && ThongTinMongDuongTruyenDan_LoaiMong == "Móng bê tông".ToUpper())
            {
                result = CDHaLu_DayDongChay;
            }

            return Math.Round(result, 3);
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

            return Math.Round(result, 3);
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

            return Math.Round(result, 3);
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

            return Math.Round(result, 3);
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

            return Math.Round(result, 3);
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
            else if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "Rãnh xây".ToUpper() || ThongTinDuongTruyenDan_HinhThucTruyenDan == "Rãnh bê tông".ToUpper())
            {
                if (ThongTinMongDuongTruyenDan_LoaiMong == "Móng bê tông".ToUpper())
                {
                    result = CDHaLu_DayDongChay;
                }
            }

            return Math.Round(result, 3);
        }
        public double CDHaLu_DinhLotRanh(string ThongTinDuongTruyenDan_HinhThucTruyenDan, string ThongTinMongDuongTruyenDan_LoaiMong, double CDHaLu_DinhMongRanh, double TTKTHHCongHopRanh_CCaoMong)
        {
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            ThongTinMongDuongTruyenDan_LoaiMong = GetTenDanhMucById(ThongTinMongDuongTruyenDan_LoaiMong).ToUpper().Trim();
            if ((ThongTinDuongTruyenDan_HinhThucTruyenDan == "Rãnh xây".ToUpper() || ThongTinDuongTruyenDan_HinhThucTruyenDan == "Rãnh bê tông".ToUpper()) && ThongTinMongDuongTruyenDan_LoaiMong == "Móng bê tông".ToUpper())
            {
                return Math.Round(CDHaLu_DinhMongRanh - TTKTHHCongHopRanh_CCaoMong, 2);
            }

            return 0;
        }
        public double CDHaLu_DinhLotCongHop(string ThongTinDuongTruyenDan_HinhThucTruyenDan, string ThongTinMongDuongTruyenDan_LoaiMong, double CDHaLu_DinhMongCongHop, double TTKTHHCongHopRanh_CCaoMong)
        {
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            ThongTinMongDuongTruyenDan_LoaiMong = GetTenDanhMucById(ThongTinMongDuongTruyenDan_LoaiMong).ToUpper().Trim();
            if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "Cống hộp".ToUpper() && ThongTinMongDuongTruyenDan_LoaiMong == "Móng bê tông".ToUpper())
            {
                return Math.Round(CDHaLu_DinhMongCongHop - TTKTHHCongHopRanh_CCaoMong, 2);
            }

            return 0;
        }
        public double CDHaLu_DinhLotCongTron(string ThongTinDuongTruyenDan_HinhThucTruyenDan, string ThongTinMongDuongTruyenDan_LoaiMong, double CDHaLu_DinhMongCongTron, double ThongTinCauTaoCongTron_CCaoMong)
        {
            ThongTinMongDuongTruyenDan_LoaiMong = GetTenDanhMucById(ThongTinMongDuongTruyenDan_LoaiMong).ToUpper().Trim();
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "Cống tròn".ToUpper() && (ThongTinMongDuongTruyenDan_LoaiMong == "Móng bê tông".ToUpper() || ThongTinMongDuongTruyenDan_LoaiMong == "Móng bê tông kết hợp đế".ToUpper()))
            {
                return Math.Round(CDHaLu_DinhMongCongTron - ThongTinCauTaoCongTron_CCaoMong,2);
            }

            return 0;
        }
        public double CDHaLu_DinhLotOngNhua(string ThongTinDuongTruyenDan_HinhThucTruyenDan, string ThongTinMongDuongTruyenDan_LoaiMong, double CDHaLu_DayDongChay, double ThongTinKichThuocHinhHocOngNhua_CDayPhuBi)
        {
            ThongTinMongDuongTruyenDan_LoaiMong = GetTenDanhMucById(ThongTinMongDuongTruyenDan_LoaiMong).ToUpper().Trim();
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "Ống nhựa".ToUpper() && ThongTinMongDuongTruyenDan_LoaiMong == "Đắp cát".ToUpper())
            {
                return Math.Round(CDHaLu_DayDongChay - ThongTinKichThuocHinhHocOngNhua_CDayPhuBi,2);
            }

            return 0;
        }
        public double CDHaLu_DinhLotGiangDinhRanhThang(string ThongTinDuongTruyenDan_HinhThucTruyenDan, string ThongTinRanhThang_CauTaoGiangDinh, double CDHaLu_DinhRanhThang, double ThongTinRanhThang_CCaoMongGiangDinh)
        {
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            ThongTinRanhThang_CauTaoGiangDinh = GetTenDanhMucById(ThongTinRanhThang_CauTaoGiangDinh).ToUpper().Trim();
            if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "Rãnh thang".ToUpper() && (ThongTinRanhThang_CauTaoGiangDinh == "Bê tông".ToUpper() || ThongTinRanhThang_CauTaoGiangDinh == "Bê tông cốt thép".ToUpper()))
            {
                return Math.Round(CDHaLu_DinhRanhThang - ThongTinRanhThang_CCaoMongGiangDinh,2);
            }

            return 0;
        }
        public double CDHaLu_DinhLotChanKhayRanhThang(string ThongTinDuongTruyenDan_HinhThucTruyenDan, string ThongTinRanhThang_CauTaoChanKhay, double CDHaLu_DayDongChay, double ThongTinRanhThang_CCaoMongChanKhay)
        {
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            ThongTinRanhThang_CauTaoChanKhay = GetTenDanhMucById(ThongTinRanhThang_CauTaoChanKhay).ToUpper().Trim();
            if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "Rãnh thang".ToUpper() && (ThongTinRanhThang_CauTaoChanKhay == "Bê tông".ToUpper() || ThongTinRanhThang_CauTaoChanKhay == "Bê tông cốt thép".ToUpper()))
            {
                return Math.Round(CDHaLu_DayDongChay - ThongTinRanhThang_CCaoMongChanKhay,2);
            }
            return 0;
        }
        public double CDHaLu_DinhLotRanhThang(string ThongTinDuongTruyenDan_HinhThucTruyenDan, string ThongTinMongDuongTruyenDan_LoaiMong, double CDHaLu_DayDongChay, double ThongTinRanhThang_CCaoMong)
        {
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "Rãnh thang".ToUpper() && ThongTinMongDuongTruyenDan_LoaiMong == "Móng bê tông".ToUpper())
            {
                return Math.Round(CDHaLu_DayDongChay - ThongTinRanhThang_CCaoMong,2);
            }

            return 0;
        }
        public double CDHaLu_DinhLotGop(string ThongTinDuongTruyenDan_HinhThucTruyenDan, string ThongTinMongDuongTruyenDan_LoaiMong, double CDHaLu_DayDongChay, double ThongTinRanhThang_CCaoMong, double ThongTinKichThuocHinhHocOngNhua_CDayPhuBi, double CDHaLu_DinhMongCongTron, double ThongTinCauTaoCongTron_CCaoMong, double CDHaLu_DinhMongCongHop, double TTKTHHCongHopRanh_CCaoMong, double CDHaLu_DinhMongRanh)
        {
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            ThongTinMongDuongTruyenDan_LoaiMong = GetTenDanhMucById(ThongTinMongDuongTruyenDan_LoaiMong).ToUpper().Trim();
            if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "Rãnh thang".ToUpper())
            {
                if (ThongTinMongDuongTruyenDan_LoaiMong == "Móng bê tông".ToUpper())
                {
                    return Math.Round(CDHaLu_DayDongChay - ThongTinRanhThang_CCaoMong,2);
                }
            }
            else if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "Ống nhựa".ToUpper())
            {
                if (ThongTinMongDuongTruyenDan_LoaiMong == "Đắp cát".ToUpper())
                {
                    return Math.Round(CDHaLu_DayDongChay - ThongTinKichThuocHinhHocOngNhua_CDayPhuBi,2);
                }
            }
            else if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "Cống tròn".ToUpper())
            {
                if (ThongTinMongDuongTruyenDan_LoaiMong == "Móng bê tông".ToUpper() || ThongTinMongDuongTruyenDan_LoaiMong == "Móng bê tông kết hợp đế".ToUpper())
                {
                    return Math.Round(CDHaLu_DinhMongCongTron - ThongTinCauTaoCongTron_CCaoMong,2);
                }
            }
            else if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "Cống hộp".ToUpper())
            {
                if (ThongTinMongDuongTruyenDan_LoaiMong == "Móng bê tông".ToUpper())
                {
                    return Math.Round(CDHaLu_DinhMongCongHop - TTKTHHCongHopRanh_CCaoMong,2);
                }
            }
            else if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "Rãnh xây".ToUpper() || ThongTinDuongTruyenDan_HinhThucTruyenDan == "Rãnh bê tông".ToUpper())
            {
                if (ThongTinMongDuongTruyenDan_LoaiMong == "Móng bê tông".ToUpper())
                {
                    return Math.Round(CDHaLu_DinhMongRanh - TTKTHHCongHopRanh_CCaoMong,2);
                }
            }

            return 0;
        }
        public double CDHaLu_DayDaoRanhThang(string ThongTinDuongTruyenDan_HinhThucTruyenDan, string ThongTinMongDuongTruyenDan_LoaiMong, double CDHaLu_DinhLotRanhThang, double ThongTinRanhThang_CCaoLot, double CDHaLu_DayDongChay)
        {
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            ThongTinMongDuongTruyenDan_LoaiMong = GetTenDanhMucById(ThongTinMongDuongTruyenDan_LoaiMong).ToUpper().Trim();
            if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "Rãnh thang".ToUpper())
            {
                if (ThongTinMongDuongTruyenDan_LoaiMong == "Móng bê tông".ToUpper())
                {
                    return Math.Round(CDHaLu_DinhLotRanhThang - ThongTinRanhThang_CCaoLot,2);
                }
                else
                {
                    return CDHaLu_DayDongChay;
                }
            }

            return 0;
        }
        public double CDHaLu_DayDaoChanKhayRanhThang(string ThongTinDuongTruyenDan_HinhThucTruyenDan, string ThongTinRanhThang_CauTaoChanKhay, double CDHaLu_DinhLotChanKhayRanhThang, double ThongTinRanhThang_CCaoLotChanKhay, double CDHaLu_DayDongChay)
        {
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            ThongTinRanhThang_CauTaoChanKhay = GetTenDanhMucById(ThongTinRanhThang_CauTaoChanKhay).ToUpper().Trim();
            if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "Rãnh thang".ToUpper())
            {
                if (ThongTinRanhThang_CauTaoChanKhay == "Bê tông".ToUpper() || ThongTinRanhThang_CauTaoChanKhay == "Bê tông cốt thép".ToUpper())
                {
                    return Math.Round(CDHaLu_DinhLotChanKhayRanhThang - ThongTinRanhThang_CCaoLotChanKhay,2);
                }
                else
                {
                    return CDHaLu_DayDongChay;
                }
            }

            return 0;
        }
        public double CDHaLu_DayDaoGiangDinhRanhThang(string ThongTinDuongTruyenDan_HinhThucTruyenDan, string ThongTinRanhThang_CauTaoGiangDinh, double CDHaLu_DinhLotGiangDinhRanhThang, double ThongTinRanhThang_CCaoLotGiangDinh, double CDHaLu_DinhRanhThang)
        {
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            ThongTinRanhThang_CauTaoGiangDinh = GetTenDanhMucById(ThongTinRanhThang_CauTaoGiangDinh).ToUpper().Trim();
            if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "Rãnh thang".ToUpper())
            {
                if (ThongTinRanhThang_CauTaoGiangDinh == "Bê tông".ToUpper() || ThongTinRanhThang_CauTaoGiangDinh == "Bê tông cốt thép".ToUpper())
                {
                    return Math.Round(CDHaLu_DinhLotGiangDinhRanhThang - ThongTinRanhThang_CCaoLotGiangDinh,2);
                }
                else
                {
                    return CDHaLu_DinhRanhThang;
                }
            }

            return 0;
        }
        public double CDHaLu_DayDaoOngNhua(string ThongTinDuongTruyenDan_HinhThucTruyenDan, string ThongTinMongDuongTruyenDan_LoaiMong, double CDHaLu_DayDongChay, double ThongTinKichThuocHinhHocOngNhua_CDayPhuBi, double CDHaLu_DinhLotOngNhua, double ThongTinKichThuocHinhHocOngNhua_CCaoDemCat)
        {
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            ThongTinMongDuongTruyenDan_LoaiMong = GetTenDanhMucById(ThongTinMongDuongTruyenDan_LoaiMong).ToUpper().Trim();
            if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "Ống nhựa".ToUpper())
            {
                if (ThongTinMongDuongTruyenDan_LoaiMong == "Không đắp cát".ToUpper())
                {
                    return Math.Round(CDHaLu_DayDongChay - ThongTinKichThuocHinhHocOngNhua_CDayPhuBi,2);
                }
                else if (ThongTinMongDuongTruyenDan_LoaiMong == "Đắp cát".ToUpper())
                {
                    return Math.Round(CDHaLu_DinhLotOngNhua - ThongTinKichThuocHinhHocOngNhua_CCaoDemCat,2);
                }
            }

            return 0;
        }
        public double CDHaLu_DayDaoRanh(string ThongTinDuongTruyenDan_HinhThucTruyenDan, double CDHaLu_DinhLotRanh, double TTKTHHCongHopRanh_CCaoLotMong)
        {
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "Rãnh xây".ToUpper() || ThongTinDuongTruyenDan_HinhThucTruyenDan == "Rãnh bê tông".ToUpper())
            {
                return Math.Round(CDHaLu_DinhLotRanh - TTKTHHCongHopRanh_CCaoLotMong,2);
            }

            return 0;
        }
        public double CDHaLu_DayDaoCongHop(string ThongTinDuongTruyenDan_HinhThucTruyenDan, string ThongTinMongDuongTruyenDan_LoaiMong, double CDHaLu_DayDongChay, double TTKTHHCongHopRanh_CCaoDe, double CDHaLu_DinhLotCongHop, double TTKTHHCongHopRanh_CCaoLotMong)
        {
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            ThongTinMongDuongTruyenDan_LoaiMong = GetTenDanhMucById(ThongTinMongDuongTruyenDan_LoaiMong).ToUpper().Trim();
            if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "Cống hộp".ToUpper() && ThongTinMongDuongTruyenDan_LoaiMong == "Không có móng".ToUpper())
            {
                return Math.Round(CDHaLu_DayDongChay - TTKTHHCongHopRanh_CCaoDe,2);
            }
            else if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "Cống hộp".ToUpper() && ThongTinMongDuongTruyenDan_LoaiMong == "Móng bê tông".ToUpper())
            {
                return Math.Round(CDHaLu_DinhLotCongHop - TTKTHHCongHopRanh_CCaoLotMong,2);
            }

            return 0;
        }
        public double CDHaLu_DayDaoCongTron(string ThongTinDuongTruyenDan_HinhThucTruyenDan, string ThongTinMongDuongTruyenDan_LoaiMong, double CDHaLu_DayDongChay, double ThongTinCauTaoCongTron_CDayPhuBi, double CDHaLu_DinhDeCong, double ThongTinCauTaoCongTron_CCaoDe, double CDHaLu_DinhLotCongTron, double ThongTinCauTaoCongTron_CCaoLotMong)
        {
            ThongTinDuongTruyenDan_HinhThucTruyenDan = GetTenDanhMucById(ThongTinDuongTruyenDan_HinhThucTruyenDan).ToUpper().Trim();
            ThongTinMongDuongTruyenDan_LoaiMong = GetTenDanhMucById(ThongTinMongDuongTruyenDan_LoaiMong).ToUpper().Trim();
            if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "Cống tròn".ToUpper())
            {
                if (ThongTinMongDuongTruyenDan_LoaiMong == "Không có móng".ToUpper())
                {
                    return Math.Round(CDHaLu_DayDongChay - ThongTinCauTaoCongTron_CDayPhuBi,2);
                }
                else if (ThongTinMongDuongTruyenDan_LoaiMong == "Đế".ToUpper())
                {
                    return Math.Round(CDHaLu_DinhDeCong - ThongTinCauTaoCongTron_CCaoDe,2);
                }
                else if (ThongTinMongDuongTruyenDan_LoaiMong == "Móng bê tông".ToUpper() || ThongTinMongDuongTruyenDan_LoaiMong == "Móng bê tông kết hợp đế".ToUpper())
                {
                    return Math.Round(CDHaLu_DinhLotCongTron - ThongTinCauTaoCongTron_CCaoLotMong,2);
                }
            }

            return 0;
        }

        public double CDHaLu_DayDaoGop(string ThongTinDuongTruyenDan_HinhThucTruyenDan, string ThongTinMongDuongTruyenDan_LoaiMong, double CDHaLu_DayDongChay, double ThongTinCauTaoCongTron_CDayPhuBi, double CDHaLu_DinhDeCong, double ThongTinCauTaoCongTron_CCaoDe,
                             double CDHaLu_DinhLotCongTron, double ThongTinCauTaoCongTron_CCaoLotMong, double TTKTHHCongHopRanh_CCaoDe, double CDHaLu_DinhLotCongHop, double TTKTHHCongHopRanh_CCaoLotMong,
                             double CDHaLu_DinhLotRanh, double ThongTinKichThuocHinhHocOngNhua_CDayPhuBi, double CDHaLu_DinhLotOngNhua, double ThongTinKichThuocHinhHocOngNhua_CCaoDemCat, double CDHaLu_DinhLotRanhThang, double ThongTinRanhThang_CCaoLot)
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
                else if (ThongTinMongDuongTruyenDan_LoaiMong== "MÓNG BÊ TÔNG" || ThongTinMongDuongTruyenDan_LoaiMong == "MÓNG BÊ TÔNG KẾT HỢP ĐẾ")
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
                else if (ThongTinMongDuongTruyenDan_LoaiMong== "ĐẮP CÁT")
                {
                    result = CDHaLu_DinhLotOngNhua - ThongTinKichThuocHinhHocOngNhua_CCaoDemCat;
                }
            }
            else if (ThongTinDuongTruyenDan_HinhThucTruyenDan == "RÃNH THANG")
            {
                if (ThongTinMongDuongTruyenDan_LoaiMong== "MÓNG BÊ TÔNG")
                {
                    result = CDHaLu_DinhLotRanhThang - ThongTinRanhThang_CCaoLot;
                }
                else
                {
                    result = CDHaLu_DayDongChay;
                }
            }

            return Math.Round(result, 2);
        }

        public double CDHaLu_ChieuSauDao(double CDHaLu_DayDaoGop, double CDHaLu_HienTrangTruocKhiDaoHaLuu)
        {
            if (CDHaLu_DayDaoGop > 0)
            {
                return Math.Round(CDHaLu_HienTrangTruocKhiDaoHaLuu - CDHaLu_DayDaoGop, 2);
            }
            else
            {
                return 0;
            }
        }

        public double TTVLDCongRanh_TLChieuCaoDaoDat(string TTVLDCongRanh_LoaiVatLieuDao, double CDThuongLuu_ChieuSauDao, double TTVLDCongRanh_TLChieuCaoDaoDa)
        {
            TTVLDCongRanh_LoaiVatLieuDao = GetTenDanhMucById(TTVLDCongRanh_LoaiVatLieuDao).ToUpper().Trim();
            if (string.IsNullOrEmpty(TTVLDCongRanh_LoaiVatLieuDao))
            {
                return 0;
            }
            else if (TTVLDCongRanh_LoaiVatLieuDao == "Đào đá".ToUpper())
            {
                return 0;
            }
            else
            {
                return Math.Round(CDThuongLuu_ChieuSauDao - TTVLDCongRanh_TLChieuCaoDaoDa,2);
            }
        }
        public double TTVLDCongRanh_HLChieuCaoDaoDat(string TTVLDCongRanh_LoaiVatLieuDao, double CDHaLu_ChieuSauDao, double TTVLDCongRanh_HLChieuCaoDaoDa)
        {
            TTVLDCongRanh_LoaiVatLieuDao = GetTenDanhMucById(TTVLDCongRanh_LoaiVatLieuDao).ToUpper().Trim();
            if (string.IsNullOrEmpty(TTVLDCongRanh_LoaiVatLieuDao))
            {
                return 0;
            }
            else if (TTVLDCongRanh_LoaiVatLieuDao == "Đào đá".ToUpper())
            {
                return 0;
            }
            else
            {
                return Math.Round(CDHaLu_ChieuSauDao - TTVLDCongRanh_HLChieuCaoDaoDa, 2);
            }
        }


        public double TTCCCCT_CCaoLotDatTLuu(string TTVLDCongRanh_LoaiVatLieuDao, double TTVLDCongRanh_TLChieuCaoDaoDat, double ThongTinCauTaoCongTron_CCaoLotMong)
        {
            TTVLDCongRanh_LoaiVatLieuDao = GetTenDanhMucById(TTVLDCongRanh_LoaiVatLieuDao).ToUpper().Trim();
            if (TTVLDCongRanh_LoaiVatLieuDao == "Đào đất".ToUpper() || TTVLDCongRanh_LoaiVatLieuDao == "Đào đất + đào đá".ToUpper())
            {
                return TTVLDCongRanh_TLChieuCaoDaoDat >= ThongTinCauTaoCongTron_CCaoLotMong ? ThongTinCauTaoCongTron_CCaoLotMong : TTVLDCongRanh_TLChieuCaoDaoDat;
            }
            else
            {
                return 0;
            }
        }
        public double TTCCCCT_CCaoLotDatHLuu(string TTVLDCongRanh_LoaiVatLieuDao, double TTVLDCongRanh_HLChieuCaoDaoDat, double ThongTinCauTaoCongTron_CCaoLotMong)
        {
            TTVLDCongRanh_LoaiVatLieuDao = GetTenDanhMucById(TTVLDCongRanh_LoaiVatLieuDao).ToUpper().Trim();
            if (TTVLDCongRanh_LoaiVatLieuDao == "Đào đất".ToUpper() || TTVLDCongRanh_LoaiVatLieuDao == "Đào đất + đào đá".ToUpper())
            {
                return TTVLDCongRanh_HLChieuCaoDaoDat >= ThongTinCauTaoCongTron_CCaoLotMong ? ThongTinCauTaoCongTron_CCaoLotMong : TTVLDCongRanh_HLChieuCaoDaoDat;
            }
            else
            {
                return 0;
            }
        }
        public double TTCCCCT_CCaoLotDaTLuu(string TTVLDCongRanh_LoaiVatLieuDao, double TTVLDCongRanh_TLChieuCaoDaoDa, double TTVLDCongRanh_TLTongChieuSauDao, double TTCCCCT_CCaoLotDatTLuu, double ThongTinCauTaoCongTron_CCaoLotMong)
        {
            TTVLDCongRanh_LoaiVatLieuDao = GetTenDanhMucById(TTVLDCongRanh_LoaiVatLieuDao).ToUpper().Trim();
            if (TTVLDCongRanh_LoaiVatLieuDao == "Đào đá".ToUpper())
            {
                return TTVLDCongRanh_TLChieuCaoDaoDa >= ThongTinCauTaoCongTron_CCaoLotMong ? ThongTinCauTaoCongTron_CCaoLotMong : TTVLDCongRanh_TLChieuCaoDaoDa;
            }
            else if (TTVLDCongRanh_LoaiVatLieuDao == "Đào đất + Đào đá".ToUpper())
            {
                if (TTVLDCongRanh_TLTongChieuSauDao >= ThongTinCauTaoCongTron_CCaoLotMong)
                {
                    return TTCCCCT_CCaoLotDatTLuu < ThongTinCauTaoCongTron_CCaoLotMong ? ThongTinCauTaoCongTron_CCaoLotMong - TTCCCCT_CCaoLotDatTLuu : 0;
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
        public double TKLD_KlCChoDat(double TKLD_KlCChoDatCongTron, double TKLD_KlCChoDatCongHop, double TKLD_KlCChoDatRanh, double TKLD_KlCChoDatOngNhua, double TKLD_TongKlCChoDat)
        {
            // Tính tổng của các giá trị và làm tròn đến 2 chữ số thập phân
            return Math.Round(TKLD_KlCChoDatCongTron + TKLD_KlCChoDatCongHop + TKLD_KlCChoDatRanh + TKLD_KlCChoDatOngNhua + TKLD_TongKlCChoDat, 2);
        }
        public double TKLD_KlCChoDa(double TKLD_KlCChoDaCongTron, double TKLD_KlCChoDaCongHop, double TKLD_KlCChoDaRanh, double TKLD_KlCChoDaOngNhua, double TKLD_TongKlCChoDa)
        {
            // Tính tổng của các giá trị và làm tròn đến 2 chữ số thập phân
            return Math.Round(TKLD_KlCChoDaCongTron + TKLD_KlCChoDaCongHop + TKLD_KlCChoDaRanh + TKLD_KlCChoDaOngNhua + TKLD_TongKlCChoDa, 2);
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
    
    
        
    
    
    }
}
