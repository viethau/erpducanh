using DucAnhERP.Data;
using DucAnhERP.Models;
using DucAnhERP.Repository;
using DucAnhERP.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace DucAnhERP.Services
{
    public class HopRanhThangRepository : IHopRanhThangRepository
    {
        private readonly IDbContextFactory<ApplicationDbContext> _context;

        public HopRanhThangRepository(IDbContextFactory<ApplicationDbContext> context)
        {
            _context = context;
        }

        public async Task<List<MHopRanhThang>> GetAll()
        {
            try
            {
                using var context = _context.CreateDbContext();
                var entity = await context.DSHopRanhThang.ToListAsync();
                return entity;
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.Error.WriteLine($"An error occurred: {ex.Message}");
                throw; // Optionally rethrow the exception
            }
        }

        public async Task<List<HopRanhThangModel>> GetData()
        {

            using var context = _context.CreateDbContext();
            var query = from MHopRanhThang in context.DSHopRanhThang
                        select new HopRanhThangModel
                        {
                            Id = MHopRanhThang.Id,
                            ThongTinLyTrinh_TuyenDuong = MHopRanhThang.ThongTinLyTrinh_TuyenDuong,
                            ThongTinLyTrinh_LyTrinhTaiTimHoGa = MHopRanhThang.ThongTinLyTrinh_LyTrinhTaiTimHoGa,
                            ThongTinChungHoGa_TenHoGaSauPhanLoai = MHopRanhThang.ThongTinChungHoGa_TenHoGaSauPhanLoai,
                            ThongTinChungHoGa_TenHoGaTheoBanVe = MHopRanhThang.ThongTinChungHoGa_TenHoGaTheoBanVe,
                            ThongTinChungHoGa_HinhThucHoGa = MHopRanhThang.ThongTinChungHoGa_HinhThucHoGa,
                            ThongTinChungHoGa_KetCauMuMo = MHopRanhThang.ThongTinChungHoGa_KetCauMuMo,
                            ThongTinChungHoGa_KetCauTuong = MHopRanhThang.ThongTinChungHoGa_KetCauTuong,
                            ThongTinChungHoGa_HinhThucMongHoGa = MHopRanhThang.ThongTinChungHoGa_HinhThucMongHoGa,
                            ThongTinChungHoGa_KetCauMong = MHopRanhThang.ThongTinChungHoGa_KetCauMong,
                            ThongTinChungHoGa_ChatMatTrong = MHopRanhThang.ThongTinChungHoGa_ChatMatTrong,
                            ThongTinChungHoGa_ChatMatNgoai = MHopRanhThang.ThongTinChungHoGa_ChatMatNgoai,
                            PhuBiHoGa_CDai = MHopRanhThang.PhuBiHoGa_CDai,
                            PhuBiHoGa_CRong = MHopRanhThang.PhuBiHoGa_CRong,
                            BeTongLotMong_D = MHopRanhThang.BeTongLotMong_D,
                            BeTongLotMong_R = MHopRanhThang.BeTongLotMong_R,
                            BeTongLotMong_C = MHopRanhThang.BeTongLotMong_C,
                            BeTongMongHoGa_D = MHopRanhThang.BeTongMongHoGa_D,
                            BeTongMongHoGa_R = MHopRanhThang.BeTongMongHoGa_R,
                            TBeTongMongHoGa_C = MHopRanhThang.TBeTongMongHoGa_C,
                            DeHoGa_D = MHopRanhThang.DeHoGa_D,
                            DeHoGa_R = MHopRanhThang.DeHoGa_R,
                            DeHoGa_C = MHopRanhThang.DeHoGa_C,
                            TuongHoGa_D = MHopRanhThang.TuongHoGa_D,
                            TuongHoGa_R = MHopRanhThang.TuongHoGa_R,
                            TuongHoGa_CdTuong = MHopRanhThang.TuongHoGa_CdTuong,
                            DamGiuaHoGa_D = MHopRanhThang.DamGiuaHoGa_D,
                            DamGiuaHoGa_R = MHopRanhThang.DamGiuaHoGa_R,
                            DamGiuaHoGa_C = MHopRanhThang.DamGiuaHoGa_C,
                            DamGiuaHoGa_CdDam = MHopRanhThang.DamGiuaHoGa_CdDam,
                            DamGiuaHoGa_CCaoDamGiuaTuongSoVoiDayHoGa = MHopRanhThang.DamGiuaHoGa_CCaoDamGiuaTuongSoVoiDayHoGa,
                            ChatMatTrong_D = MHopRanhThang.ChatMatTrong_D,
                            ChatMatTrong_R = MHopRanhThang.ChatMatTrong_R,
                            ChatMatNgoaiCanh_D = MHopRanhThang.ChatMatNgoaiCanh_D,
                            ChatMatNgoaiCanh_R = MHopRanhThang.ChatMatNgoaiCanh_R,
                            MuMoThotDuoi_D = MHopRanhThang.MuMoThotDuoi_D,
                            MuMoThotDuoi_R = MHopRanhThang.MuMoThotDuoi_R,
                            MuMoThotDuoi_C = MHopRanhThang.MuMoThotDuoi_C,
                            MuMoThotDuoi_CdTuong = MHopRanhThang.MuMoThotDuoi_CdTuong,
                            MuMoThotTren_D = MHopRanhThang.MuMoThotTren_D,
                            MuMoThotTren_R = MHopRanhThang.MuMoThotTren_R,
                            MuMoThotTren_C = MHopRanhThang.MuMoThotTren_C,
                            MuMoThotTren_CdTuong = MHopRanhThang.MuMoThotTren_CdTuong,
                            HinhThucDauNoi1_Loai = MHopRanhThang.HinhThucDauNoi1_Loai,
                            HinhThucDauNoi1_CanhDai = MHopRanhThang.HinhThucDauNoi1_CanhDai,
                            HinhThucDauNoi1_CanhRong = MHopRanhThang.HinhThucDauNoi1_CanhRong,
                            HinhThucDauNoi1_CanhCheo = MHopRanhThang.HinhThucDauNoi1_CanhCheo,
                            HinhThucDauNoi2_Loai = MHopRanhThang.HinhThucDauNoi2_Loai,
                            HinhThucDauNoi2_CanhDai = MHopRanhThang.HinhThucDauNoi2_CanhDai,
                            HinhThucDauNoi2_CanhRong = MHopRanhThang.HinhThucDauNoi2_CanhRong,
                            HinhThucDauNoi2_CanhCheo = MHopRanhThang.HinhThucDauNoi2_CanhCheo,
                            HinhThucDauNoi3_Loai = MHopRanhThang.HinhThucDauNoi3_Loai,
                            HinhThucDauNoi3_CanhDai = MHopRanhThang.HinhThucDauNoi3_CanhDai,
                            HinhThucDauNoi3_CanhRong = MHopRanhThang.HinhThucDauNoi3_CanhRong,
                            HinhThucDauNoi3_CanhCheo = MHopRanhThang.HinhThucDauNoi3_CanhCheo,
                            HinhThucDauNoi4_Loai = MHopRanhThang.HinhThucDauNoi4_Loai,
                            HinhThucDauNoi4_CanhDai = MHopRanhThang.HinhThucDauNoi4_CanhDai,
                            HinhThucDauNoi4_CanhRong = MHopRanhThang.HinhThucDauNoi4_CanhRong,
                            HinhThucDauNoi4_CanhCheo = MHopRanhThang.HinhThucDauNoi4_CanhCheo,
                            HinhThucDauNoi5_Loai = MHopRanhThang.HinhThucDauNoi5_Loai,
                            HinhThucDauNoi5_CanhDai = MHopRanhThang.HinhThucDauNoi5_CanhDai,
                            HinhThucDauNoi5_CanhRong = MHopRanhThang.HinhThucDauNoi5_CanhRong,
                            HinhThucDauNoi5_CanhCheo = MHopRanhThang.HinhThucDauNoi5_CanhCheo,
                            HinhThucDauNoi6_Loai = MHopRanhThang.HinhThucDauNoi6_Loai,
                            HinhThucDauNoi6_CanhDai = MHopRanhThang.HinhThucDauNoi6_CanhDai,
                            HinhThucDauNoi6_CanhRong = MHopRanhThang.HinhThucDauNoi6_CanhRong,
                            HinhThucDauNoi6_CanhCheo = MHopRanhThang.HinhThucDauNoi6_CanhCheo,
                            HinhThucDauNoi7_Loai = MHopRanhThang.HinhThucDauNoi7_Loai,
                            HinhThucDauNoi7_CanhDai = MHopRanhThang.HinhThucDauNoi7_CanhDai,
                            HinhThucDauNoi7_CanhRong = MHopRanhThang.HinhThucDauNoi7_CanhRong,
                            HinhThucDauNoi7_CanhCheo = MHopRanhThang.HinhThucDauNoi7_CanhCheo,
                            HinhThucDauNoi8_Loai = MHopRanhThang.HinhThucDauNoi8_Loai,
                            HinhThucDauNoi8_CanhDai = MHopRanhThang.HinhThucDauNoi8_CanhDai,
                            HinhThucDauNoi8_CanhRong = MHopRanhThang.HinhThucDauNoi8_CanhRong,
                            HinhThucDauNoi8_CanhCheo = MHopRanhThang.HinhThucDauNoi8_CanhCheo,
                            ThongTinTamDanHoGa2_PhanLoaiDayHoGa = MHopRanhThang.ThongTinTamDanHoGa2_PhanLoaiDayHoGa,
                            ThongTinTamDanHoGa2_HinhThucDayHoGa = MHopRanhThang.ThongTinTamDanHoGa2_HinhThucDayHoGa,
                            ThongTinTamDanHoGa2_DuongKinh = MHopRanhThang.ThongTinTamDanHoGa2_DuongKinh,
                            ThongTinTamDanHoGa2_ChieuDay = MHopRanhThang.ThongTinTamDanHoGa2_ChieuDay,
                            ThongTinTamDanHoGa2_D = MHopRanhThang.ThongTinTamDanHoGa2_D,
                            ThongTinTamDanHoGa2_R = MHopRanhThang.ThongTinTamDanHoGa2_R,
                            ThongTinTamDanHoGa2_C = MHopRanhThang.ThongTinTamDanHoGa2_C,
                            ThongTinTamDanHoGa2_SoLuongNapDay = MHopRanhThang.ThongTinTamDanHoGa2_SoLuongNapDay,
                            ThongTinVatLieuDaoHoGa_LoaiVatLieuDao = MHopRanhThang.ThongTinVatLieuDaoHoGa_LoaiVatLieuDao,
                            ThongTinVatLieuDaoHoGa_ChieuCaoDaoDa = MHopRanhThang.ThongTinVatLieuDaoHoGa_ChieuCaoDaoDa,
                            ThongTinCaoDoHoGa_CaoDoTuNhien = MHopRanhThang.ThongTinCaoDoHoGa_CaoDoTuNhien,
                            ThongTinCaoDoHoGa_CdDinhViaHeHoanThien = MHopRanhThang.ThongTinCaoDoHoGa_CdDinhViaHeHoanThien,
                            ThongTinCaoDoHoGa_CaoDoDinhK98 = MHopRanhThang.ThongTinCaoDoHoGa_CaoDoDinhK98,
                            ThongTinCaoDoHoGa_CdDayHoGa = MHopRanhThang.ThongTinCaoDoHoGa_CdDayHoGa,
                            ThongTinCaoDoHoGa_CdDinhHoGa = MHopRanhThang.ThongTinCaoDoHoGa_CdDinhHoGa,
                            ThongTinMaiDao_ChieuRongDayDaoNho = MHopRanhThang.ThongTinMaiDao_ChieuRongDayDaoNho,
                            ThongTinMaiDao_TyLeMoMai = MHopRanhThang.ThongTinMaiDao_TyLeMoMai,
                            ThongTinMaiDao_SoCanhMaiTrai = MHopRanhThang.ThongTinMaiDao_SoCanhMaiTrai,
                            ThongTinMaiDao_SoCanhMaiPhai = MHopRanhThang.ThongTinMaiDao_SoCanhMaiPhai,
                            ToaDoX = MHopRanhThang.ToaDoX,
                            ToaDoY = MHopRanhThang.ToaDoY,
                            ThongTinLyTrinhTruyenDan_TuLyTrinh = MHopRanhThang.ThongTinLyTrinhTruyenDan_TuLyTrinh,
                            ThongTinLyTrinhTruyenDan_DenLyTrinh = MHopRanhThang.ThongTinLyTrinhTruyenDan_DenLyTrinh,
                            ThongTinLyTrinhTruyenDan_TuHoGa = MHopRanhThang.ThongTinLyTrinhTruyenDan_TuHoGa,
                            ThongTinLyTrinhTruyenDan_DenHoGa = MHopRanhThang.ThongTinLyTrinhTruyenDan_DenHoGa,
                            ThongTinDuongTruyenDan_HinhThucTruyenDan = MHopRanhThang.ThongTinDuongTruyenDan_HinhThucTruyenDan,
                            ThongTinDuongTruyenDan_LoaiTruyenDan = MHopRanhThang.ThongTinDuongTruyenDan_LoaiTruyenDan,
                            ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai = MHopRanhThang.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai,
                            TTCDSLCauKienDuongTruyenDan_ChieuDai01CauKien = MHopRanhThang.TTCDSLCauKienDuongTruyenDan_ChieuDai01CauKien,
                            TTCDSLCauKienDuongTruyenDan_ChieuDaiMoiNoiCKien = MHopRanhThang.TTCDSLCauKienDuongTruyenDan_ChieuDaiMoiNoiCKien,
                            TTCDSLCauKienDuongTruyenDan_SoLuongCKienDungDeTinhChieuDaiBoSung = MHopRanhThang.TTCDSLCauKienDuongTruyenDan_SoLuongCKienDungDeTinhChieuDaiBoSung,
                            TTCDSLCauKienDuongTruyenDan_TongChieuDai = MHopRanhThang.TTCDSLCauKienDuongTruyenDan_TongChieuDai,
                            ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop = MHopRanhThang.ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop,
                            ThongTinMongDuongTruyenDan_LoaiMong = MHopRanhThang.ThongTinMongDuongTruyenDan_LoaiMong,
                            ThongTinMongDuongTruyenDan_HinhThucMong = MHopRanhThang.ThongTinMongDuongTruyenDan_HinhThucMong,
                            ThongTinDeCong_TenLoaiDeCong = MHopRanhThang.ThongTinDeCong_TenLoaiDeCong,
                            ThongTinDeCong_CauTaoDeCong = MHopRanhThang.ThongTinDeCong_CauTaoDeCong,
                            ThongTinDeCong_D = MHopRanhThang.ThongTinDeCong_D,
                            ThongTinDeCong_R = MHopRanhThang.ThongTinDeCong_R,
                            ThongTinDeCong_C = MHopRanhThang.ThongTinDeCong_C,
                            ThongTinDeCong_SlDeCong01CauKienTruyenDan = MHopRanhThang.ThongTinDeCong_SlDeCong01CauKienTruyenDan,
                            ThongTinDeCong_Kl01DeCong = MHopRanhThang.ThongTinDeCong_Kl01DeCong,
                            ThongTinCauTaoCongTron_CDayPhuBi = MHopRanhThang.ThongTinCauTaoCongTron_CDayPhuBi,
                            ThongTinCauTaoCongTron_SoCanh = MHopRanhThang.ThongTinCauTaoCongTron_SoCanh,
                            ThongTinCauTaoCongTron_LongSuDung = MHopRanhThang.ThongTinCauTaoCongTron_LongSuDung,
                            ThongTinCauTaoCongTron_CCaoLotMong = MHopRanhThang.ThongTinCauTaoCongTron_CCaoLotMong,
                            ThongTinCauTaoCongTron_CRongLotMong = MHopRanhThang.ThongTinCauTaoCongTron_CRongLotMong,
                            ThongTinCauTaoCongTron_CCaoMong = MHopRanhThang.ThongTinCauTaoCongTron_CCaoMong,
                            ThongTinCauTaoCongTron_CRongMong = MHopRanhThang.ThongTinCauTaoCongTron_CRongMong,
                            ThongTinCauTaoCongTron_CCaoDe = MHopRanhThang.ThongTinCauTaoCongTron_CCaoDe,
                            TTKTHHCongHopRanh_CauTaoTuong = MHopRanhThang.TTKTHHCongHopRanh_CauTaoTuong,
                            TTKTHHCongHopRanh_CauTaoMuMo = MHopRanhThang.TTKTHHCongHopRanh_CauTaoMuMo,
                            TTKTHHCongHopRanh_ChatMatTrong = MHopRanhThang.TTKTHHCongHopRanh_ChatMatTrong,
                            TTKTHHCongHopRanh_ChatMatNgoai = MHopRanhThang.TTKTHHCongHopRanh_ChatMatNgoai,
                            TTKTHHCongHopRanh_CCaoLotMong = MHopRanhThang.TTKTHHCongHopRanh_CCaoLotMong,
                            TTKTHHCongHopRanh_CRongLotMong = MHopRanhThang.TTKTHHCongHopRanh_CRongLotMong,
                            TTKTHHCongHopRanh_CCaoMong = MHopRanhThang.TTKTHHCongHopRanh_CCaoMong,
                            TTKTHHCongHopRanh_CRongMong = MHopRanhThang.TTKTHHCongHopRanh_CRongMong,
                            TTKTHHCongHopRanh_CCaoDe = MHopRanhThang.TTKTHHCongHopRanh_CCaoDe,
                            TTKTHHCongHopRanh_CRongDe = MHopRanhThang.TTKTHHCongHopRanh_CRongDe,
                            TTKTHHCongHopRanh_CDayTuong01Ben = MHopRanhThang.TTKTHHCongHopRanh_CDayTuong01Ben,
                            TTKTHHCongHopRanh_SoLuongTuong = MHopRanhThang.TTKTHHCongHopRanh_SoLuongTuong,
                            TTKTHHCongHopRanh_CRongLongSuDung = MHopRanhThang.TTKTHHCongHopRanh_CRongLongSuDung,
                            TTKTHHCongHopRanh_CCaoTuongCongHop = MHopRanhThang.TTKTHHCongHopRanh_CCaoTuongCongHop,
                            TTKTHHCongHopRanh_CCaoMuMoThotDuoi = MHopRanhThang.TTKTHHCongHopRanh_CCaoMuMoThotDuoi,
                            TTKTHHCongHopRanh_CRongMuMoDuoi = MHopRanhThang.TTKTHHCongHopRanh_CRongMuMoDuoi,
                            TTKTHHCongHopRanh_CCaoMuMoThotTren = MHopRanhThang.TTKTHHCongHopRanh_CCaoMuMoThotTren,
                            TTKTHHCongHopRanh_CRongMuMoTren = MHopRanhThang.TTKTHHCongHopRanh_CRongMuMoTren,
                            TTKTHHCongHopRanh_LoaiThanhChong = MHopRanhThang.TTKTHHCongHopRanh_LoaiThanhChong,
                            TTKTHHCongHopRanh_CauTaoThanhChong = MHopRanhThang.TTKTHHCongHopRanh_CauTaoThanhChong,
                            TTKTHHCongHopRanh_CCaoThanhChong = MHopRanhThang.TTKTHHCongHopRanh_CCaoThanhChong,
                            TTKTHHCongHopRanh_CRongThanhChong = MHopRanhThang.TTKTHHCongHopRanh_CRongThanhChong,
                            TTKTHHCongHopRanh_CDai = MHopRanhThang.TTKTHHCongHopRanh_CDai,
                            TTKTHHCongHopRanh_SoLuongThanhChong = MHopRanhThang.TTKTHHCongHopRanh_SoLuongThanhChong,
                            ThongTinKichThuocHinhHocOngNhua_CDayPhuBi = MHopRanhThang.ThongTinKichThuocHinhHocOngNhua_CDayPhuBi,
                            ThongTinKichThuocHinhHocOngNhua_SoCanh = MHopRanhThang.ThongTinKichThuocHinhHocOngNhua_SoCanh,
                            ThongTinKichThuocHinhHocOngNhua_LongSuDung = MHopRanhThang.ThongTinKichThuocHinhHocOngNhua_LongSuDung,
                            ThongTinKichThuocHinhHocOngNhua_CCaoDemCat = MHopRanhThang.ThongTinKichThuocHinhHocOngNhua_CCaoDemCat,
                            ThongTinKichThuocHinhHocOngNhua_CCaoDapCat = MHopRanhThang.ThongTinKichThuocHinhHocOngNhua_CCaoDapCat,
                            ThongTinRanhThang_HinhThucMai = MHopRanhThang.ThongTinRanhThang_HinhThucMai,
                            ThongTinRanhThang_CauTaoChanKhay = MHopRanhThang.ThongTinRanhThang_CauTaoChanKhay,
                            ThongTinRanhThang_CauTaoGiangDinh = MHopRanhThang.ThongTinRanhThang_CauTaoGiangDinh,
                            ThongTinRanhThang_HinhThucHanhLangBaoVe = MHopRanhThang.ThongTinRanhThang_HinhThucHanhLangBaoVe,
                            ThongTinRanhThang_PhanLoaiChanKhay = MHopRanhThang.ThongTinRanhThang_PhanLoaiChanKhay,
                            ThongTinRanhThang_CCaoLotChanKhay = MHopRanhThang.ThongTinRanhThang_CCaoLotChanKhay,
                            ThongTinRanhThang_CRongLotChanKhay = MHopRanhThang.ThongTinRanhThang_CRongLotChanKhay,
                            ThongTinRanhThang_SoLuongLotChanKhay = MHopRanhThang.ThongTinRanhThang_SoLuongLotChanKhay,
                            ThongTinRanhThang_CCaoMongChanKhay = MHopRanhThang.ThongTinRanhThang_CCaoMongChanKhay,
                            ThongTinRanhThang_CRongMongChanKhay = MHopRanhThang.ThongTinRanhThang_CRongMongChanKhay,
                            ThongTinRanhThang_SoLuongMongChanKhay = MHopRanhThang.ThongTinRanhThang_SoLuongMongChanKhay,
                            ThongTinRanhThang_CCaoLot = MHopRanhThang.ThongTinRanhThang_CCaoLot,
                            ThongTinRanhThang_CRongLot = MHopRanhThang.ThongTinRanhThang_CRongLot,
                            ThongTinRanhThang_CCaoMong = MHopRanhThang.ThongTinRanhThang_CCaoMong,
                            ThongTinRanhThang_CRongMong = MHopRanhThang.ThongTinRanhThang_CRongMong,
                            ThongTinRanhThang_PhanLoaiMai = MHopRanhThang.ThongTinRanhThang_PhanLoaiMai,
                            ThongTinRanhThang_CRongMai = MHopRanhThang.ThongTinRanhThang_CRongMai,
                            ThongTinRanhThang_CDayMai = MHopRanhThang.ThongTinRanhThang_CDayMai,
                            ThongTinRanhThang_SoLuongMai = MHopRanhThang.ThongTinRanhThang_SoLuongMai,
                            ThongTinRanhThang_PhanLoaiGiangDinh = MHopRanhThang.ThongTinRanhThang_PhanLoaiGiangDinh,
                            ThongTinRanhThang_CCaoLotGiangDinh = MHopRanhThang.ThongTinRanhThang_CCaoLotGiangDinh,
                            ThongTinRanhThang_CRongLotGiangDinh = MHopRanhThang.ThongTinRanhThang_CRongLotGiangDinh,
                            ThongTinRanhThang_SoLuongLotGiangDinh = MHopRanhThang.ThongTinRanhThang_SoLuongLotGiangDinh,
                            ThongTinRanhThang_CCaoMongGiangDinh = MHopRanhThang.ThongTinRanhThang_CCaoMongGiangDinh,
                            ThongTinRanhThang_CRongMongGiangDinh = MHopRanhThang.ThongTinRanhThang_CRongMongGiangDinh,
                            ThongTinRanhThang_SoLuongMongGiangDinh = MHopRanhThang.ThongTinRanhThang_SoLuongMongGiangDinh,
                            ThongTinRanhThang_PhanLoaiHanhLangBaoVe = MHopRanhThang.ThongTinRanhThang_PhanLoaiHanhLangBaoVe,
                            ThongTinRanhThang_CCaoHanhLangBaoVe = MHopRanhThang.ThongTinRanhThang_CCaoHanhLangBaoVe,
                            ThongTinRanhThang_CRongHanhLangBaoVe = MHopRanhThang.ThongTinRanhThang_CRongHanhLangBaoVe,
                            ThongTinRanhThang_SoLuongHangLangBaoVe = MHopRanhThang.ThongTinRanhThang_SoLuongHangLangBaoVe,
                            TTTDCongHoRanh_TenLoaiTamDanTieuChuan = MHopRanhThang.TTTDCongHoRanh_TenLoaiTamDanTieuChuan,
                            TTTDCongHoRanh_CauTaoTamDanTruyenDanTamDanTieuChuan = MHopRanhThang.TTTDCongHoRanh_CauTaoTamDanTruyenDanTamDanTieuChuan,
                            TTTDCongHoRanh_CDai = MHopRanhThang.TTTDCongHoRanh_CDai,
                            TTTDCongHoRanh_CRong = MHopRanhThang.TTTDCongHoRanh_CRong,
                            TTTDCongHoRanh_CCao = MHopRanhThang.TTTDCongHoRanh_CCao,
                            TTTDCongHoRanh_TenLoaiTamDanLoai02 = MHopRanhThang.TTTDCongHoRanh_TenLoaiTamDanLoai02,
                            TTTDCongHoRanh_CauTaoTamDanTruyenDan = MHopRanhThang.TTTDCongHoRanh_CauTaoTamDanTruyenDan,
                            TTTDCongHoRanh_CRong1 = MHopRanhThang.TTTDCongHoRanh_CRong1,
                            TTTDCongHoRanh_CCao1 = MHopRanhThang.TTTDCongHoRanh_CCao1,
                            TTTDCongHoRanh_ChieuDaiMoiNoi = MHopRanhThang.TTTDCongHoRanh_ChieuDaiMoiNoi,
                            TTTDCongHoRanh_SoLuongTDanDungDeTinhChieuDaiBoSung = MHopRanhThang.TTTDCongHoRanh_SoLuongTDanDungDeTinhChieuDaiBoSung,
                            CDThuongLuu_HienTrangTruocKhiDaoThuongLuu = MHopRanhThang.CDThuongLuu_HienTrangTruocKhiDaoThuongLuu,
                            CDThuongLuu_DayDongChay = MHopRanhThang.CDThuongLuu_DayDongChay,
                            CDThuongLuu_DinhTrongLongSuDung = MHopRanhThang.CDThuongLuu_DinhTrongLongSuDung,
                            CDThuongLuu_ChieuCaoRanhThangTuDayDongChayDenDinh = MHopRanhThang.CDThuongLuu_ChieuCaoRanhThangTuDayDongChayDenDinh,
                            CDHaLu_HienTrangTruocKhiDaoHaLuu = MHopRanhThang.CDHaLu_HienTrangTruocKhiDaoHaLuu,
                            CDHaLu_DayDongChay = MHopRanhThang.CDHaLu_DayDongChay,
                            CDHaLu_DinhTrongLongSuDung = MHopRanhThang.CDHaLu_DinhTrongLongSuDung,
                            CDHaLu_ChieuCaoRanhThangTuDayDongChayDenDinh = MHopRanhThang.CDHaLu_ChieuCaoRanhThangTuDayDongChayDenDinh,
                            TTVLDCongRanh_LoaiVatLieuDao = MHopRanhThang.TTVLDCongRanh_LoaiVatLieuDao,
                            TTVLDCongRanh_TLChieuCaoDaoDa = MHopRanhThang.TTVLDCongRanh_TLChieuCaoDaoDa,
                            TTVLDCongRanh_HLChieuCaoDaoDa = MHopRanhThang.TTVLDCongRanh_HLChieuCaoDaoDa,

                            TTMDRanhOngThang_ChieuRongDayDaoNho = MHopRanhThang.TTMDRanhOngThang_ChieuRongDayDaoNho,
                            TTMDRanhOngThang_TyLeMoMai = MHopRanhThang.TTMDRanhOngThang_TyLeMoMai,
                            TTMDRanhOngThang_SoCanhMaiTrai = MHopRanhThang.TTMDRanhOngThang_SoCanhMaiTrai,
                            TTMDRanhOngThang_SoCanhMaiPhai = MHopRanhThang.TTMDRanhOngThang_SoCanhMaiPhai,
                            TTMDRanhOngThang_ChieuRongDayDaoNho1 = MHopRanhThang.TTMDRanhOngThang_ChieuRongDayDaoNho1,
                            TTMDRanhOngThang_TyLeMoMai1 = MHopRanhThang.TTMDRanhOngThang_TyLeMoMai1,
                            TTMDRanhOngThang_SoCanhMaiTrai1 = MHopRanhThang.TTMDRanhOngThang_SoCanhMaiTrai1,
                            TTMDRanhOngThang_SoCanhMaiPhai1 = MHopRanhThang.TTMDRanhOngThang_SoCanhMaiPhai1,
                            TuToaDoX = MHopRanhThang.TuToaDoX,
                            TuToaDoY = MHopRanhThang.TuToaDoY,
                            DenToaDoX = MHopRanhThang.DenToaDoX,
                            DenToaDoY = MHopRanhThang.DenToaDoY,

                        };
            var data = await query.ToListAsync();
            return data;
        }

        public async Task Update(MHopRanhThang hopRanhThang)
        {
            using var context = _context.CreateDbContext();
            var entity = GetById(hopRanhThang.Id);

            if (entity == null)
            {
                throw new Exception($"Không tìm thấy bản ghi theo ID: {hopRanhThang.Id}");
            }

            context.DSHopRanhThang.Update(hopRanhThang);
            await context.SaveChangesAsync();
        }

        public async Task UpdateMulti(MHopRanhThang[] hopRanhThang)
        {
            using var context = _context.CreateDbContext();
            string[] ids = hopRanhThang.Select(x => x.Id).ToArray();
            var listEntities = await context.DSHopRanhThang.Where(x => ids.Contains(x.Id)).ToListAsync();
            foreach (var entity in listEntities)
            {
                context.DSHopRanhThang.Update(entity);
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

        public async Task<MHopRanhThang> GetById(string id)
        {
            using var context = _context.CreateDbContext();
            var entity = await context.DSHopRanhThang.Where(x => x.Id.Equals(id)).FirstOrDefaultAsync();

            if (entity == null)
            {
                throw new Exception($"Không tìm thấy bản ghi theo ID: {id}");
            }

            return entity;
        }

        public async Task Insert(MHopRanhThang entity)
        {
            try
            {
                using var context = _context.CreateDbContext();
                if (entity == null)
                {
                    throw new Exception("Không có bản ghi nào để thêm!");
                }

                entity.Id = Guid.NewGuid().ToString();
                context.DSHopRanhThang.Add(entity);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}
