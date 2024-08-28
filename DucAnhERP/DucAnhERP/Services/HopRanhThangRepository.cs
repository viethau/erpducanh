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
                        .OrderBy(m => m.CreateAt)
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
                            PhuBiHoGa_CDai = MHopRanhThang.PhuBiHoGa_CDai??0,
                            PhuBiHoGa_CRong = MHopRanhThang.PhuBiHoGa_CRong ?? 0,
                            BeTongLotMong_D = MHopRanhThang.BeTongLotMong_D ?? 0,
                            BeTongLotMong_R = MHopRanhThang.BeTongLotMong_R ?? 0,
                            BeTongLotMong_C = MHopRanhThang.BeTongLotMong_C ?? 0,
                            BeTongMongHoGa_D = MHopRanhThang.BeTongMongHoGa_D ?? 0,
                            BeTongMongHoGa_R = MHopRanhThang.BeTongMongHoGa_R ?? 0,
                            TBeTongMongHoGa_C = MHopRanhThang.TBeTongMongHoGa_C ?? 0,
                            DeHoGa_D = MHopRanhThang.DeHoGa_D ?? 0,
                            DeHoGa_R = MHopRanhThang.DeHoGa_R ?? 0,
                            DeHoGa_C = MHopRanhThang.DeHoGa_C ?? 0,
                            TuongHoGa_D = MHopRanhThang.TuongHoGa_D ?? 0,
                            TuongHoGa_R = MHopRanhThang.TuongHoGa_R ?? 0,
                            TuongHoGa_CdTuong = MHopRanhThang.TuongHoGa_CdTuong ?? 0,
                            DamGiuaHoGa_D = MHopRanhThang.DamGiuaHoGa_D ?? 0,
                            DamGiuaHoGa_R = MHopRanhThang.DamGiuaHoGa_R ?? 0,
                            DamGiuaHoGa_C = MHopRanhThang.DamGiuaHoGa_C ?? 0,
                            DamGiuaHoGa_CdDam = MHopRanhThang.DamGiuaHoGa_CdDam ?? 0,
                            DamGiuaHoGa_CCaoDamGiuaTuongSoVoiDayHoGa = MHopRanhThang.DamGiuaHoGa_CCaoDamGiuaTuongSoVoiDayHoGa ?? 0,
                            ChatMatTrong_D = MHopRanhThang.ChatMatTrong_D ?? 0,
                            ChatMatTrong_R = MHopRanhThang.ChatMatTrong_R ?? 0,
                            ChatMatNgoaiCanh_D = MHopRanhThang.ChatMatNgoaiCanh_D ?? 0,
                            ChatMatNgoaiCanh_R = MHopRanhThang.ChatMatNgoaiCanh_R ?? 0,
                            MuMoThotDuoi_D = MHopRanhThang.MuMoThotDuoi_D ?? 0,
                            MuMoThotDuoi_R = MHopRanhThang.MuMoThotDuoi_R ?? 0,
                            MuMoThotDuoi_C = MHopRanhThang.MuMoThotDuoi_C ?? 0,
                            MuMoThotDuoi_CdTuong = MHopRanhThang.MuMoThotDuoi_CdTuong ?? 0,
                            MuMoThotTren_D = MHopRanhThang.MuMoThotTren_D ?? 0,
                            MuMoThotTren_R = MHopRanhThang.MuMoThotTren_R ?? 0,
                            MuMoThotTren_C = MHopRanhThang.MuMoThotTren_C ?? 0,
                            MuMoThotTren_CdTuong = MHopRanhThang.MuMoThotTren_CdTuong ?? 0,
                            HinhThucDauNoi1_Loai = MHopRanhThang.HinhThucDauNoi1_Loai ?? 0,
                            HinhThucDauNoi1_CanhDai = MHopRanhThang.HinhThucDauNoi1_CanhDai ?? 0,
                            HinhThucDauNoi1_CanhRong = MHopRanhThang.HinhThucDauNoi1_CanhRong ?? 0,
                            HinhThucDauNoi1_CanhCheo = MHopRanhThang.HinhThucDauNoi1_CanhCheo ?? 0,
                            HinhThucDauNoi2_Loai = MHopRanhThang.HinhThucDauNoi2_Loai ?? 0,
                            HinhThucDauNoi2_CanhDai = MHopRanhThang.HinhThucDauNoi2_CanhDai ?? 0,
                            HinhThucDauNoi2_CanhRong = MHopRanhThang.HinhThucDauNoi2_CanhRong ?? 0,
                            HinhThucDauNoi2_CanhCheo = MHopRanhThang.HinhThucDauNoi2_CanhCheo ?? 0,
                            HinhThucDauNoi3_Loai = MHopRanhThang.HinhThucDauNoi3_Loai ?? 0,
                            HinhThucDauNoi3_CanhDai = MHopRanhThang.HinhThucDauNoi3_CanhDai ?? 0,
                            HinhThucDauNoi3_CanhRong = MHopRanhThang.HinhThucDauNoi3_CanhRong ?? 0,
                            HinhThucDauNoi3_CanhCheo = MHopRanhThang.HinhThucDauNoi3_CanhCheo ?? 0,
                            HinhThucDauNoi4_Loai = MHopRanhThang.HinhThucDauNoi4_Loai ?? 0,
                            HinhThucDauNoi4_CanhDai = MHopRanhThang.HinhThucDauNoi4_CanhDai ?? 0,
                            HinhThucDauNoi4_CanhRong = MHopRanhThang.HinhThucDauNoi4_CanhRong ?? 0,
                            HinhThucDauNoi4_CanhCheo = MHopRanhThang.HinhThucDauNoi4_CanhCheo ?? 0,
                            HinhThucDauNoi5_Loai = MHopRanhThang.HinhThucDauNoi5_Loai ?? 0,
                            HinhThucDauNoi5_CanhDai = MHopRanhThang.HinhThucDauNoi5_CanhDai ?? 0,
                            HinhThucDauNoi5_CanhRong = MHopRanhThang.HinhThucDauNoi5_CanhRong ?? 0,
                            HinhThucDauNoi5_CanhCheo = MHopRanhThang.HinhThucDauNoi5_CanhCheo ?? 0,
                            HinhThucDauNoi6_Loai = MHopRanhThang.HinhThucDauNoi6_Loai ?? 0,
                            HinhThucDauNoi6_CanhDai = MHopRanhThang.HinhThucDauNoi6_CanhDai ?? 0,
                            HinhThucDauNoi6_CanhRong = MHopRanhThang.HinhThucDauNoi6_CanhRong ?? 0,
                            HinhThucDauNoi6_CanhCheo = MHopRanhThang.HinhThucDauNoi6_CanhCheo ?? 0,
                            HinhThucDauNoi7_Loai = MHopRanhThang.HinhThucDauNoi7_Loai ?? 0,
                            HinhThucDauNoi7_CanhDai = MHopRanhThang.HinhThucDauNoi7_CanhDai ?? 0,
                            HinhThucDauNoi7_CanhRong = MHopRanhThang.HinhThucDauNoi7_CanhRong ?? 0,
                            HinhThucDauNoi7_CanhCheo = MHopRanhThang.HinhThucDauNoi7_CanhCheo ?? 0,
                            HinhThucDauNoi8_Loai = MHopRanhThang.HinhThucDauNoi8_Loai ?? 0,
                            HinhThucDauNoi8_CanhDai = MHopRanhThang.HinhThucDauNoi8_CanhDai ?? 0,
                            HinhThucDauNoi8_CanhRong = MHopRanhThang.HinhThucDauNoi8_CanhRong ?? 0,
                            HinhThucDauNoi8_CanhCheo = MHopRanhThang.HinhThucDauNoi8_CanhCheo ?? 0,
                            ThongTinTamDanHoGa2_PhanLoaiDayHoGa = MHopRanhThang.ThongTinTamDanHoGa2_PhanLoaiDayHoGa,
                            ThongTinTamDanHoGa2_HinhThucDayHoGa = MHopRanhThang.ThongTinTamDanHoGa2_HinhThucDayHoGa,
                            ThongTinTamDanHoGa2_DuongKinh = MHopRanhThang.ThongTinTamDanHoGa2_DuongKinh ?? 0,
                            ThongTinTamDanHoGa2_ChieuDay = MHopRanhThang.ThongTinTamDanHoGa2_ChieuDay ?? 0,
                            ThongTinTamDanHoGa2_D = MHopRanhThang.ThongTinTamDanHoGa2_D ?? 0,
                            ThongTinTamDanHoGa2_R = MHopRanhThang.ThongTinTamDanHoGa2_R ?? 0,
                            ThongTinTamDanHoGa2_C = MHopRanhThang.ThongTinTamDanHoGa2_C ?? 0,
                            ThongTinTamDanHoGa2_SoLuongNapDay = MHopRanhThang.ThongTinTamDanHoGa2_SoLuongNapDay,
                            ThongTinVatLieuDaoHoGa_LoaiVatLieuDao = MHopRanhThang.ThongTinVatLieuDaoHoGa_LoaiVatLieuDao,
                            ThongTinVatLieuDaoHoGa_ChieuCaoDaoDa = MHopRanhThang.ThongTinVatLieuDaoHoGa_ChieuCaoDaoDa ?? 0,
                            ThongTinCaoDoHoGa_CaoDoTuNhien = MHopRanhThang.ThongTinCaoDoHoGa_CaoDoTuNhien ?? 0,
                            ThongTinCaoDoHoGa_CdDinhViaHeHoanThien = MHopRanhThang.ThongTinCaoDoHoGa_CdDinhViaHeHoanThien ?? 0,
                            ThongTinCaoDoHoGa_CaoDoDinhK98 = MHopRanhThang.ThongTinCaoDoHoGa_CaoDoDinhK98 ?? 0,
                            ThongTinCaoDoHoGa_CdDayHoGa = MHopRanhThang.ThongTinCaoDoHoGa_CdDayHoGa ?? 0,
                            ThongTinCaoDoHoGa_CdDinhHoGa = MHopRanhThang.ThongTinCaoDoHoGa_CdDinhHoGa ?? 0,
                            ThongTinMaiDao_ChieuRongDayDaoNho = MHopRanhThang.ThongTinMaiDao_ChieuRongDayDaoNho ?? 0,
                            ThongTinMaiDao_TyLeMoMai = MHopRanhThang.ThongTinMaiDao_TyLeMoMai ?? 0,
                            ThongTinMaiDao_SoCanhMaiTrai = MHopRanhThang.ThongTinMaiDao_SoCanhMaiTrai,
                            ThongTinMaiDao_SoCanhMaiPhai = MHopRanhThang.ThongTinMaiDao_SoCanhMaiPhai,
                            ToaDoX = MHopRanhThang.ToaDoX ?? 0,
                            ToaDoY = MHopRanhThang.ToaDoY ?? 0,
                            ThongTinLyTrinhTruyenDan_TuLyTrinh = MHopRanhThang.ThongTinLyTrinhTruyenDan_TuLyTrinh ?? 0,
                            ThongTinLyTrinhTruyenDan_DenLyTrinh = MHopRanhThang.ThongTinLyTrinhTruyenDan_DenLyTrinh ?? 0,
                            ThongTinLyTrinhTruyenDan_TuHoGa = MHopRanhThang.ThongTinLyTrinhTruyenDan_TuHoGa,
                            ThongTinLyTrinhTruyenDan_DenHoGa = MHopRanhThang.ThongTinLyTrinhTruyenDan_DenHoGa,
                            ThongTinDuongTruyenDan_HinhThucTruyenDan = MHopRanhThang.ThongTinDuongTruyenDan_HinhThucTruyenDan,
                            ThongTinDuongTruyenDan_LoaiTruyenDan = MHopRanhThang.ThongTinDuongTruyenDan_LoaiTruyenDan,
                            ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai = MHopRanhThang.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai,
                            TTCDSLCauKienDuongTruyenDan_ChieuDai01CauKien = MHopRanhThang.TTCDSLCauKienDuongTruyenDan_ChieuDai01CauKien ?? 0,
                            TTCDSLCauKienDuongTruyenDan_ChieuDaiMoiNoiCKien = MHopRanhThang.TTCDSLCauKienDuongTruyenDan_ChieuDaiMoiNoiCKien ?? 0,
                            TTCDSLCauKienDuongTruyenDan_SoLuongCKienDungDeTinhChieuDaiBoSung = MHopRanhThang.TTCDSLCauKienDuongTruyenDan_SoLuongCKienDungDeTinhChieuDaiBoSung,
                            TTCDSLCauKienDuongTruyenDan_TongChieuDai = MHopRanhThang.TTCDSLCauKienDuongTruyenDan_TongChieuDai ?? 0,
                            ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop = MHopRanhThang.ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop,
                            ThongTinMongDuongTruyenDan_LoaiMong = MHopRanhThang.ThongTinMongDuongTruyenDan_LoaiMong,
                            ThongTinMongDuongTruyenDan_HinhThucMong = MHopRanhThang.ThongTinMongDuongTruyenDan_HinhThucMong,
                            ThongTinDeCong_TenLoaiDeCong = MHopRanhThang.ThongTinDeCong_TenLoaiDeCong,
                            ThongTinDeCong_CauTaoDeCong = MHopRanhThang.ThongTinDeCong_CauTaoDeCong,
                            ThongTinDeCong_D = MHopRanhThang.ThongTinDeCong_D ?? 0,
                            ThongTinDeCong_R = MHopRanhThang.ThongTinDeCong_R ?? 0,
                            ThongTinDeCong_C = MHopRanhThang.ThongTinDeCong_C ?? 0,
                            ThongTinDeCong_SlDeCong01CauKienTruyenDan = MHopRanhThang.ThongTinDeCong_SlDeCong01CauKienTruyenDan ?? 0,
                            ThongTinDeCong_Kl01DeCong = MHopRanhThang.ThongTinDeCong_Kl01DeCong ?? 0,
                            ThongTinCauTaoCongTron_CDayPhuBi = MHopRanhThang.ThongTinCauTaoCongTron_CDayPhuBi ?? 0,
                            ThongTinCauTaoCongTron_SoCanh = MHopRanhThang.ThongTinCauTaoCongTron_SoCanh ?? 0,
                            ThongTinCauTaoCongTron_LongSuDung = MHopRanhThang.ThongTinCauTaoCongTron_LongSuDung ?? 0,
                            ThongTinCauTaoCongTron_CCaoLotMong = MHopRanhThang.ThongTinCauTaoCongTron_CCaoLotMong ?? 0,
                            ThongTinCauTaoCongTron_CRongLotMong = MHopRanhThang.ThongTinCauTaoCongTron_CRongLotMong ?? 0,
                            ThongTinCauTaoCongTron_CCaoMong = MHopRanhThang.ThongTinCauTaoCongTron_CCaoMong ?? 0,
                            ThongTinCauTaoCongTron_CRongMong = MHopRanhThang.ThongTinCauTaoCongTron_CRongMong ?? 0,
                            ThongTinCauTaoCongTron_CCaoDe = MHopRanhThang.ThongTinCauTaoCongTron_CCaoDe ?? 0,
                            TTKTHHCongHopRanh_CauTaoTuong = MHopRanhThang.TTKTHHCongHopRanh_CauTaoTuong,
                            TTKTHHCongHopRanh_CauTaoMuMo = MHopRanhThang.TTKTHHCongHopRanh_CauTaoMuMo,
                            TTKTHHCongHopRanh_ChatMatTrong = MHopRanhThang.TTKTHHCongHopRanh_ChatMatTrong,
                            TTKTHHCongHopRanh_ChatMatNgoai = MHopRanhThang.TTKTHHCongHopRanh_ChatMatNgoai,
                            TTKTHHCongHopRanh_CCaoLotMong = MHopRanhThang.TTKTHHCongHopRanh_CCaoLotMong ?? 0,
                            TTKTHHCongHopRanh_CRongLotMong = MHopRanhThang.TTKTHHCongHopRanh_CRongLotMong ?? 0,
                            TTKTHHCongHopRanh_CCaoMong = MHopRanhThang.TTKTHHCongHopRanh_CCaoMong ?? 0,
                            TTKTHHCongHopRanh_CRongMong = MHopRanhThang.TTKTHHCongHopRanh_CRongMong ?? 0,
                            TTKTHHCongHopRanh_CCaoDe = MHopRanhThang.TTKTHHCongHopRanh_CCaoDe ?? 0,
                            TTKTHHCongHopRanh_CRongDe = MHopRanhThang.TTKTHHCongHopRanh_CRongDe ?? 0,
                            TTKTHHCongHopRanh_CDayTuong01Ben = MHopRanhThang.TTKTHHCongHopRanh_CDayTuong01Ben ?? 0,
                            TTKTHHCongHopRanh_SoLuongTuong = MHopRanhThang.TTKTHHCongHopRanh_SoLuongTuong ?? 0,
                            TTKTHHCongHopRanh_CRongLongSuDung = MHopRanhThang.TTKTHHCongHopRanh_CRongLongSuDung ?? 0,
                            TTKTHHCongHopRanh_CCaoTuongCongHop = MHopRanhThang.TTKTHHCongHopRanh_CCaoTuongCongHop ?? 0,
                            TTKTHHCongHopRanh_CCaoMuMoThotDuoi = MHopRanhThang.TTKTHHCongHopRanh_CCaoMuMoThotDuoi ?? 0,
                            TTKTHHCongHopRanh_CRongMuMoDuoi = MHopRanhThang.TTKTHHCongHopRanh_CRongMuMoDuoi ?? 0,
                            TTKTHHCongHopRanh_CCaoMuMoThotTren = MHopRanhThang.TTKTHHCongHopRanh_CCaoMuMoThotTren ?? 0,
                            TTKTHHCongHopRanh_CRongMuMoTren = MHopRanhThang.TTKTHHCongHopRanh_CRongMuMoTren ?? 0,
                            TTKTHHCongHopRanh_LoaiThanhChong = MHopRanhThang.TTKTHHCongHopRanh_LoaiThanhChong,
                            TTKTHHCongHopRanh_CauTaoThanhChong = MHopRanhThang.TTKTHHCongHopRanh_CauTaoThanhChong,
                            TTKTHHCongHopRanh_CCaoThanhChong = MHopRanhThang.TTKTHHCongHopRanh_CCaoThanhChong ?? 0,
                            TTKTHHCongHopRanh_CRongThanhChong = MHopRanhThang.TTKTHHCongHopRanh_CRongThanhChong ?? 0,
                            TTKTHHCongHopRanh_CDai = MHopRanhThang.TTKTHHCongHopRanh_CDai ?? 0,
                            TTKTHHCongHopRanh_SoLuongThanhChong = MHopRanhThang.TTKTHHCongHopRanh_SoLuongThanhChong ?? 0,
                            ThongTinKichThuocHinhHocOngNhua_CDayPhuBi = MHopRanhThang.ThongTinKichThuocHinhHocOngNhua_CDayPhuBi ?? 0,
                            ThongTinKichThuocHinhHocOngNhua_SoCanh = MHopRanhThang.ThongTinKichThuocHinhHocOngNhua_SoCanh,
                            ThongTinKichThuocHinhHocOngNhua_LongSuDung = MHopRanhThang.ThongTinKichThuocHinhHocOngNhua_LongSuDung ?? 0,
                            ThongTinKichThuocHinhHocOngNhua_CCaoDemCat = MHopRanhThang.ThongTinKichThuocHinhHocOngNhua_CCaoDemCat ?? 0,
                            ThongTinKichThuocHinhHocOngNhua_CCaoDapCat = MHopRanhThang.ThongTinKichThuocHinhHocOngNhua_CCaoDapCat ?? 0,
                            ThongTinRanhThang_HinhThucMai = MHopRanhThang.ThongTinRanhThang_HinhThucMai,
                            ThongTinRanhThang_CauTaoChanKhay = MHopRanhThang.ThongTinRanhThang_CauTaoChanKhay,
                            ThongTinRanhThang_CauTaoGiangDinh = MHopRanhThang.ThongTinRanhThang_CauTaoGiangDinh,
                            ThongTinRanhThang_HinhThucHanhLangBaoVe = MHopRanhThang.ThongTinRanhThang_HinhThucHanhLangBaoVe,
                            ThongTinRanhThang_PhanLoaiChanKhay = MHopRanhThang.ThongTinRanhThang_PhanLoaiChanKhay,
                            ThongTinRanhThang_CCaoLotChanKhay = MHopRanhThang.ThongTinRanhThang_CCaoLotChanKhay ?? 0,
                            ThongTinRanhThang_CRongLotChanKhay = MHopRanhThang.ThongTinRanhThang_CRongLotChanKhay ?? 0,
                            ThongTinRanhThang_SoLuongLotChanKhay = MHopRanhThang.ThongTinRanhThang_SoLuongLotChanKhay ?? 0,
                            ThongTinRanhThang_CCaoMongChanKhay = MHopRanhThang.ThongTinRanhThang_CCaoMongChanKhay ?? 0,
                            ThongTinRanhThang_CRongMongChanKhay = MHopRanhThang.ThongTinRanhThang_CRongMongChanKhay ?? 0,
                            ThongTinRanhThang_SoLuongMongChanKhay = MHopRanhThang.ThongTinRanhThang_SoLuongMongChanKhay,
                            ThongTinRanhThang_CCaoLot = MHopRanhThang.ThongTinRanhThang_CCaoLot ?? 0,
                            ThongTinRanhThang_CRongLot = MHopRanhThang.ThongTinRanhThang_CRongLot ?? 0,
                            ThongTinRanhThang_CCaoMong = MHopRanhThang.ThongTinRanhThang_CCaoMong ?? 0,
                            ThongTinRanhThang_CRongMong = MHopRanhThang.ThongTinRanhThang_CRongMong ?? 0,
                            ThongTinRanhThang_PhanLoaiMai = MHopRanhThang.ThongTinRanhThang_PhanLoaiMai,
                            ThongTinRanhThang_CRongMai = MHopRanhThang.ThongTinRanhThang_CRongMai ?? 0,
                            ThongTinRanhThang_CDayMai = MHopRanhThang.ThongTinRanhThang_CDayMai ?? 0,
                            ThongTinRanhThang_SoLuongMai = MHopRanhThang.ThongTinRanhThang_SoLuongMai,
                            ThongTinRanhThang_PhanLoaiGiangDinh = MHopRanhThang.ThongTinRanhThang_PhanLoaiGiangDinh,
                            ThongTinRanhThang_CCaoLotGiangDinh = MHopRanhThang.ThongTinRanhThang_CCaoLotGiangDinh ?? 0,
                            ThongTinRanhThang_CRongLotGiangDinh = MHopRanhThang.ThongTinRanhThang_CRongLotGiangDinh ?? 0,
                            ThongTinRanhThang_SoLuongLotGiangDinh = MHopRanhThang.ThongTinRanhThang_SoLuongLotGiangDinh,
                            ThongTinRanhThang_CCaoMongGiangDinh = MHopRanhThang.ThongTinRanhThang_CCaoMongGiangDinh ?? 0,
                            ThongTinRanhThang_CRongMongGiangDinh = MHopRanhThang.ThongTinRanhThang_CRongMongGiangDinh ?? 0,
                            ThongTinRanhThang_SoLuongMongGiangDinh = MHopRanhThang.ThongTinRanhThang_SoLuongMongGiangDinh ?? 0,
                            ThongTinRanhThang_PhanLoaiHanhLangBaoVe = MHopRanhThang.ThongTinRanhThang_PhanLoaiHanhLangBaoVe,
                            ThongTinRanhThang_CCaoHanhLangBaoVe = MHopRanhThang.ThongTinRanhThang_CCaoHanhLangBaoVe ?? 0,
                            ThongTinRanhThang_CRongHanhLangBaoVe = MHopRanhThang.ThongTinRanhThang_CRongHanhLangBaoVe ?? 0,
                            ThongTinRanhThang_SoLuongHangLangBaoVe = MHopRanhThang.ThongTinRanhThang_SoLuongHangLangBaoVe,
                            TTTDCongHoRanh_TenLoaiTamDanTieuChuan = MHopRanhThang.TTTDCongHoRanh_TenLoaiTamDanTieuChuan,
                            TTTDCongHoRanh_CauTaoTamDanTruyenDanTamDanTieuChuan = MHopRanhThang.TTTDCongHoRanh_CauTaoTamDanTruyenDanTamDanTieuChuan,
                            TTTDCongHoRanh_CDai = MHopRanhThang.TTTDCongHoRanh_CDai ?? 0,
                            TTTDCongHoRanh_CRong = MHopRanhThang.TTTDCongHoRanh_CRong ?? 0,
                            TTTDCongHoRanh_CCao = MHopRanhThang.TTTDCongHoRanh_CCao ?? 0,
                            TTTDCongHoRanh_TenLoaiTamDanLoai02 = MHopRanhThang.TTTDCongHoRanh_TenLoaiTamDanLoai02,
                            TTTDCongHoRanh_CauTaoTamDanTruyenDan = MHopRanhThang.TTTDCongHoRanh_CauTaoTamDanTruyenDan,
                            TTTDCongHoRanh_CRong1 = MHopRanhThang.TTTDCongHoRanh_CRong1 ?? 0,
                            TTTDCongHoRanh_CCao1 = MHopRanhThang.TTTDCongHoRanh_CCao1 ?? 0,
                            TTTDCongHoRanh_ChieuDaiMoiNoi = MHopRanhThang.TTTDCongHoRanh_ChieuDaiMoiNoi ?? 0,
                            TTTDCongHoRanh_SoLuongTDanDungDeTinhChieuDaiBoSung = MHopRanhThang.TTTDCongHoRanh_SoLuongTDanDungDeTinhChieuDaiBoSung,
                            CDThuongLuu_HienTrangTruocKhiDaoThuongLuu = MHopRanhThang.CDThuongLuu_HienTrangTruocKhiDaoThuongLuu ?? 0,
                            CDThuongLuu_DayDongChay = MHopRanhThang.CDThuongLuu_DayDongChay ?? 0,
                            CDThuongLuu_DinhTrongLongSuDung = MHopRanhThang.CDThuongLuu_DinhTrongLongSuDung ?? 0,
                            CDThuongLuu_ChieuCaoRanhThangTuDayDongChayDenDinh = MHopRanhThang.CDThuongLuu_ChieuCaoRanhThangTuDayDongChayDenDinh ?? 0,
                            CDHaLu_HienTrangTruocKhiDaoHaLuu = MHopRanhThang.CDHaLu_HienTrangTruocKhiDaoHaLuu ?? 0,
                            CDHaLu_DayDongChay = MHopRanhThang.CDHaLu_DayDongChay ?? 0,
                            CDHaLu_DinhTrongLongSuDung = MHopRanhThang.CDHaLu_DinhTrongLongSuDung ?? 0,
                            CDHaLu_ChieuCaoRanhThangTuDayDongChayDenDinh = MHopRanhThang.CDHaLu_ChieuCaoRanhThangTuDayDongChayDenDinh ?? 0,
                            TTVLDCongRanh_LoaiVatLieuDao = MHopRanhThang.TTVLDCongRanh_LoaiVatLieuDao,
                            TTVLDCongRanh_TLChieuCaoDaoDa = MHopRanhThang.TTVLDCongRanh_TLChieuCaoDaoDa ?? 0,
                            TTVLDCongRanh_HLChieuCaoDaoDa = MHopRanhThang.TTVLDCongRanh_HLChieuCaoDaoDa ?? 0,

                            TTMDRanhOngThang_ChieuRongDayDaoNho = MHopRanhThang.TTMDRanhOngThang_ChieuRongDayDaoNho ?? 0,
                            TTMDRanhOngThang_TyLeMoMai = MHopRanhThang.TTMDRanhOngThang_TyLeMoMai ?? 0,
                            TTMDRanhOngThang_SoCanhMaiTrai = MHopRanhThang.TTMDRanhOngThang_SoCanhMaiTrai,
                            TTMDRanhOngThang_SoCanhMaiPhai = MHopRanhThang.TTMDRanhOngThang_SoCanhMaiPhai ?? 0,
                            TTMDRanhOngThang_ChieuRongDayDaoNho1 = MHopRanhThang.TTMDRanhOngThang_ChieuRongDayDaoNho1 ?? 0,
                            TTMDRanhOngThang_TyLeMoMai1 = MHopRanhThang.TTMDRanhOngThang_TyLeMoMai1 ?? 0,
                            TTMDRanhOngThang_SoCanhMaiTrai1 = MHopRanhThang.TTMDRanhOngThang_SoCanhMaiTrai1,
                            TTMDRanhOngThang_SoCanhMaiPhai1 = MHopRanhThang.TTMDRanhOngThang_SoCanhMaiPhai1 ?? 0,
                            TuToaDoX = MHopRanhThang.TuToaDoX ?? 0,
                            TuToaDoY = MHopRanhThang.TuToaDoY ?? 0,
                            DenToaDoX = MHopRanhThang.DenToaDoX ?? 0,
                            DenToaDoY = MHopRanhThang.DenToaDoY ?? 0,
                            CreateAt = MHopRanhThang.CreateAt,
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

        public async Task<int> MultiInsert(List<MHopRanhThang> entities)
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
                    context.DSHopRanhThang.Add(entity);
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
