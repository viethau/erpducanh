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

        public async Task<List<NuocMua>> GetAll()
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

            try
            {
                using var context = _context.CreateDbContext();
                var query = from nuocMua in context.DSNuocMua
                                // Left join với bảng PhanLoaiHoGas
                            join phanLoaiHoGa in context.PhanLoaiHoGas
                            on nuocMua.ThongTinChungHoGa_TenHoGaSauPhanLoai equals phanLoaiHoGa.Id into phanLoaiHoGaJoin
                            from phanLoaiHoGa in phanLoaiHoGaJoin.DefaultIfEmpty()

                                // Left join với bảng PhanLoaiTDHoGas
                            join phanLoaiTDHoGa in context.PhanLoaiTDHoGas
                            on nuocMua.ThongTinTamDanHoGa2_PhanLoaiDayHoGa equals phanLoaiTDHoGa.Id into phanLoaiTDHoGaJoin
                            from phanLoaiTDHoGa in phanLoaiTDHoGaJoin.DefaultIfEmpty()

                                // Left join với bảng PhanLoaiTDHoGas
                            join PhanLoaiCTronHopNhua in context.PhanLoaiCTronHopNhuas
                            on nuocMua.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai equals PhanLoaiCTronHopNhua.Id into PhanLoaiCTronHopNhuaJoin
                            from PhanLoaiCTronHopNhua in PhanLoaiCTronHopNhuaJoin.DefaultIfEmpty()

                                // Left join với bảng PhanLoaiMongCTrons
                            join PhanLoaiMongCTron in context.PhanLoaiMongCTrons
                            on nuocMua.ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop equals PhanLoaiMongCTron.Id into PhanLoaiMongCTronJoin
                            from PhanLoaiMongCTron in PhanLoaiMongCTronJoin.DefaultIfEmpty()

                                // Left join với bảng PhanLoaiDeCongs
                            join PhanLoaiDeCong in context.PhanLoaiDeCongs
                            on nuocMua.ThongTinDeCong_TenLoaiDeCong equals PhanLoaiDeCong.Id into PhanLoaiDeCongJoin
                            from PhanLoaiDeCong in PhanLoaiDeCongJoin.DefaultIfEmpty()

                                // Left join với bảng PhanLoaiThanhChongs
                            join PhanLoaiThanhChong in context.PhanLoaiThanhChongs
                            on nuocMua.TTKTHHCongHopRanh_LoaiThanhChong equals PhanLoaiThanhChong.Id into PhanLoaiThanhChongJoin
                            from PhanLoaiThanhChong in PhanLoaiThanhChongJoin.DefaultIfEmpty()

                                // Left join với bảng PhanLoaiTDanTDans
                            join PhanLoaiTDanTDan in context.PhanLoaiTDanTDans
                            on nuocMua.TTTDCongHoRanh_TenLoaiTamDanTieuChuan equals PhanLoaiTDanTDan.Id into PhanLoaiTDanTDanJoin
                            from PhanLoaiTDanTDan in PhanLoaiTDanTDanJoin.DefaultIfEmpty()

                                // Left join với bảng PhanLoaiTDanTDans
                            join PhanLoaiTDanTDan02 in context.PhanLoaiTDanTDans
                            on nuocMua.TTTDCongHoRanh_TenLoaiTamDanLoai02 equals PhanLoaiTDanTDan02.Id into PhanLoaiTDanTDan02Join
                            from PhanLoaiTDanTDan02 in PhanLoaiTDanTDan02Join.DefaultIfEmpty()

                                // Join với các bảng phân loại
                            join hinhThucHoGa in context.DSDanhMuc
                                on nuocMua.ThongTinChungHoGa_HinhThucHoGa equals hinhThucHoGa.Id into gj4
                            from hinhThucHoGa in gj4.DefaultIfEmpty() // Left join for HinhThucHoGa

                            join ketCauMuMo in context.DSDanhMuc
                                on nuocMua.ThongTinChungHoGa_KetCauMuMo equals ketCauMuMo.Id into gj5
                            from ketCauMuMo in gj5.DefaultIfEmpty() // Left join for KetCauMuMo

                            join ketCauTuong in context.DSDanhMuc
                                on nuocMua.ThongTinChungHoGa_KetCauTuong equals ketCauTuong.Id into gj6
                            from ketCauTuong in gj6.DefaultIfEmpty() // Left join for KetCauTuong

                            join hinhThucMongHoGa in context.DSDanhMuc
                                on nuocMua.ThongTinChungHoGa_HinhThucMongHoGa equals hinhThucMongHoGa.Id into gj7
                            from hinhThucMongHoGa in gj7.DefaultIfEmpty() // Left join for HinhThucMongHoGa

                            join ketCauMong in context.DSDanhMuc
                                on nuocMua.ThongTinChungHoGa_KetCauMong equals ketCauMong.Id into gj8
                            from ketCauMong in gj8.DefaultIfEmpty() // Left join for KetCauMong

                            join chatMatTrong in context.DSDanhMuc
                                on nuocMua.ThongTinChungHoGa_ChatMatTrong equals chatMatTrong.Id into gj9
                            from chatMatTrong in gj9.DefaultIfEmpty() // Left join for ChatMatTrong

                            join chatMatNgoai in context.DSDanhMuc
                                on nuocMua.ThongTinChungHoGa_ChatMatNgoai equals chatMatNgoai.Id into gj10
                            from chatMatNgoai in gj10.DefaultIfEmpty() // Left join for ChatMatNgoai

                            join hinhThucDayHoGa2 in context.DSDanhMuc
                                on nuocMua.ThongTinTamDanHoGa2_HinhThucDayHoGa equals hinhThucDayHoGa2.Id into gj11
                            from hinhThucDayHoGa2 in gj11.DefaultIfEmpty() // Left join for 

                            join loaiVatLieuDao in context.DSDanhMuc
                                on nuocMua.ThongTinVatLieuDaoHoGa_LoaiVatLieuDao equals loaiVatLieuDao.Id into gj12
                            from loaiVatLieuDao in gj12.DefaultIfEmpty() // Left join for 

                            join hinhThucTruyenDan in context.DSDanhMuc
                               on nuocMua.ThongTinDuongTruyenDan_HinhThucTruyenDan equals hinhThucTruyenDan.Id into gj13
                            from hinhThucTruyenDan in gj13.DefaultIfEmpty() // Left join for 

                            join loaiTruyenDan in context.DSDanhMuc
                               on nuocMua.ThongTinDuongTruyenDan_LoaiTruyenDan equals loaiTruyenDan.Id into gj14
                            from loaiTruyenDan in gj14.DefaultIfEmpty() // Left join for 

                            join loaiMong in context.DSDanhMuc
                                on nuocMua.ThongTinMongDuongTruyenDan_LoaiMong equals loaiMong.Id into gj15
                            from loaiMong in gj15.DefaultIfEmpty() // Left join for 

                            join hinhThucMong in context.DSDanhMuc
                                on nuocMua.ThongTinMongDuongTruyenDan_HinhThucMong equals hinhThucMong.Id into gj16
                            from hinhThucMong in gj16.DefaultIfEmpty() // Left join for 

                            join cauTaoDeCong in context.DSDanhMuc
                                on nuocMua.ThongTinDeCong_CauTaoDeCong equals cauTaoDeCong.Id into gj17
                            from cauTaoDeCong in gj17.DefaultIfEmpty() // Left join for

                             join cauTaoTuong in context.DSDanhMuc
                                on nuocMua.TTKTHHCongHopRanh_CauTaoTuong equals cauTaoTuong.Id into gj18
                            from cauTaoTuong in gj18.DefaultIfEmpty()

                            join cauTaoMuMo in context.DSDanhMuc
                                on nuocMua.TTKTHHCongHopRanh_CauTaoMuMo equals cauTaoMuMo.Id into gj19
                            from cauTaoMuMo in gj19.DefaultIfEmpty()

                            join chatMatTrong_TTKTHH in context.DSDanhMuc
                                on nuocMua.TTKTHHCongHopRanh_ChatMatTrong equals chatMatTrong_TTKTHH.Id into gj20
                            from chatMatTrong_TTKTHH in gj20.DefaultIfEmpty()

                            join chatMatNgoai_TTKTHH in context.DSDanhMuc
                                on nuocMua.TTKTHHCongHopRanh_ChatMatNgoai equals chatMatNgoai_TTKTHH.Id into gj21
                            from chatMatNgoai_TTKTHH in gj21.DefaultIfEmpty()

                            join cauTaoThanhChong in context.DSDanhMuc
                                 on nuocMua.TTKTHHCongHopRanh_CauTaoThanhChong equals cauTaoThanhChong.Id into gj22
                            from cauTaoThanhChong in gj22.DefaultIfEmpty()

                            join cauTaoTamDanTruyenDanTamDanTieuChuan in context.DSDanhMuc
                                 on nuocMua.TTTDCongHoRanh_CauTaoTamDanTruyenDanTamDanTieuChuan equals cauTaoTamDanTruyenDanTamDanTieuChuan.Id into gj23
                            from cauTaoTamDanTruyenDanTamDanTieuChuan in gj23.DefaultIfEmpty()

                            join cauTaoTamDanTruyenDan in context.DSDanhMuc
                                 on nuocMua.TTTDCongHoRanh_CauTaoTamDanTruyenDan equals cauTaoTamDanTruyenDan.Id into gj24
                            from cauTaoTamDanTruyenDan in gj24.DefaultIfEmpty()

                            join loaiVatLieuDao_TTVLD in context.DSDanhMuc
                                 on nuocMua.TTVLDCongRanh_LoaiVatLieuDao equals loaiVatLieuDao_TTVLD.Id into gj25
                            from loaiVatLieuDao_TTVLD in gj25.DefaultIfEmpty()
                                // Sắp xếp theo Flag của DSNuocMua
                            orderby nuocMua.Flag
                            select new NuocMuaModel
                            {
                                Id = nuocMua.Id,
                                ThongTinLyTrinh_TuyenDuong = nuocMua.ThongTinLyTrinh_TuyenDuong ?? "",
                                ThongTinLyTrinh_LyTrinhTaiTimHoGa = nuocMua.ThongTinLyTrinh_LyTrinhTaiTimHoGa ?? "",
                                ThongTinChungHoGa_TenHoGaSauPhanLoai = nuocMua.ThongTinChungHoGa_TenHoGaSauPhanLoai ?? "",
                                PhanLoaiHoGas_TenHoGaSauPhanLoai = phanLoaiHoGa != null ? phanLoaiHoGa.ThongTinChungHoGa_TenHoGaSauPhanLoai : "",
                                ThongTinChungHoGa_TenHoGaTheoBanVe = nuocMua.ThongTinChungHoGa_TenHoGaTheoBanVe ?? "",
                                ThongTinChungHoGa_HinhThucHoGa = nuocMua.ThongTinChungHoGa_HinhThucHoGa ?? "",
                                ThongTinChungHoGa_HinhThucHoGa_Name = hinhThucHoGa.Ten,
                                ThongTinChungHoGa_KetCauMuMo = nuocMua.ThongTinChungHoGa_KetCauMuMo ?? "",
                                ThongTinChungHoGa_KetCauMuMo_Name = ketCauMuMo.Ten,
                                ThongTinChungHoGa_KetCauTuong = nuocMua.ThongTinChungHoGa_KetCauTuong ?? "",
                                ThongTinChungHoGa_KetCauTuong_Name = ketCauTuong.Ten,
                                ThongTinChungHoGa_HinhThucMongHoGa = nuocMua.ThongTinChungHoGa_HinhThucMongHoGa ?? "",
                                ThongTinChungHoGa_HinhThucMongHoGa_Name = hinhThucMongHoGa.Ten,
                                ThongTinChungHoGa_KetCauMong = nuocMua.ThongTinChungHoGa_KetCauMong ?? "",
                                ThongTinChungHoGa_KetCauMong_Name = ketCauMong.Ten,
                                ThongTinChungHoGa_ChatMatTrong = nuocMua.ThongTinChungHoGa_ChatMatTrong ?? "",
                                ThongTinChungHoGa_ChatMatTrong_Name = chatMatTrong.Ten,
                                ThongTinChungHoGa_ChatMatNgoai = nuocMua.ThongTinChungHoGa_ChatMatNgoai ?? "",
                                ThongTinChungHoGa_ChatMatNgoai_Name = chatMatNgoai.Ten,
                                PhuBiHoGa_CDai = nuocMua.PhuBiHoGa_CDai ?? 0,
                                PhuBiHoGa_CRong = nuocMua.PhuBiHoGa_CRong ?? 0,
                                BeTongLotMong_D = nuocMua.BeTongLotMong_D ?? 0,
                                BeTongLotMong_R = nuocMua.BeTongLotMong_R ?? 0,
                                BeTongLotMong_C = nuocMua.BeTongLotMong_C ?? 0,
                                BeTongMongHoGa_D = nuocMua.BeTongMongHoGa_D ?? 0,
                                BeTongMongHoGa_R = nuocMua.BeTongMongHoGa_R ?? 0,
                                BeTongMongHoGa_C = nuocMua.BeTongMongHoGa_C ?? 0,
                                DeHoGa_D = nuocMua.DeHoGa_D ?? 0,
                                DeHoGa_R = nuocMua.DeHoGa_R ?? 0,
                                DeHoGa_C = nuocMua.DeHoGa_C ?? 0,
                                TuongHoGa_D = nuocMua.TuongHoGa_D ?? 0,
                                TuongHoGa_R = nuocMua.TuongHoGa_R ?? 0,
                                TuongHoGa_C = nuocMua.TuongHoGa_C ?? 0,
                                TuongHoGa_CdTuong = nuocMua.TuongHoGa_CdTuong ?? 0,
                                DamGiuaHoGa_D = nuocMua.DamGiuaHoGa_D ?? 0,
                                DamGiuaHoGa_R = nuocMua.DamGiuaHoGa_R ?? 0,
                                DamGiuaHoGa_C = nuocMua.DamGiuaHoGa_C ?? 0,
                                DamGiuaHoGa_CdDam = nuocMua.DamGiuaHoGa_CdDam ?? 0,
                                DamGiuaHoGa_CCaoDamGiuaTuongSoVoiDayHoGa = nuocMua.DamGiuaHoGa_CCaoDamGiuaTuongSoVoiDayHoGa ?? 0,
                                ChatMatTrong_D = nuocMua.ChatMatTrong_D ?? 0,
                                ChatMatTrong_R = nuocMua.ChatMatTrong_R ?? 0,
                                ChatMatTrong_C = nuocMua.ChatMatTrong_C ?? 0,
                                ChatMatNgoaiCanh_D = nuocMua.ChatMatNgoaiCanh_D ?? 0,
                                ChatMatNgoaiCanh_R = nuocMua.ChatMatNgoaiCanh_R ?? 0,
                                ChatMatNgoaiCanh_C = nuocMua.ChatMatNgoaiCanh_C ?? 0,
                                MuMoThotDuoi_D = nuocMua.MuMoThotDuoi_D ?? 0,
                                MuMoThotDuoi_R = nuocMua.MuMoThotDuoi_R ?? 0,
                                MuMoThotDuoi_C = nuocMua.MuMoThotDuoi_C ?? 0,
                                MuMoThotDuoi_CdTuong = nuocMua.MuMoThotDuoi_CdTuong ?? 0,
                                MuMoThotTren_D = nuocMua.MuMoThotTren_D ?? 0,
                                MuMoThotTren_R = nuocMua.MuMoThotTren_R ?? 0,
                                MuMoThotTren_C = nuocMua.MuMoThotTren_C ?? 0,
                                MuMoThotTren_CdTuong = nuocMua.MuMoThotTren_CdTuong ?? 0,
                                HinhThucDauNoi1_Loai = nuocMua.HinhThucDauNoi1_Loai ?? 0,
                                HinhThucDauNoi1_CanhDai = nuocMua.HinhThucDauNoi1_CanhDai ?? 0,
                                HinhThucDauNoi1_CanhRong = nuocMua.HinhThucDauNoi1_CanhRong ?? 0,
                                HinhThucDauNoi1_CanhCheo = nuocMua.HinhThucDauNoi1_CanhCheo ?? 0,
                                HinhThucDauNoi2_Loai = nuocMua.HinhThucDauNoi2_Loai ?? 0,
                                HinhThucDauNoi2_CanhDai = nuocMua.HinhThucDauNoi2_CanhDai ?? 0,
                                HinhThucDauNoi2_CanhRong = nuocMua.HinhThucDauNoi2_CanhRong ?? 0,
                                HinhThucDauNoi2_CanhCheo = nuocMua.HinhThucDauNoi2_CanhCheo ?? 0,
                                HinhThucDauNoi3_Loai = nuocMua.HinhThucDauNoi3_Loai ?? 0,
                                HinhThucDauNoi3_CanhDai = nuocMua.HinhThucDauNoi3_CanhDai ?? 0,
                                HinhThucDauNoi3_CanhRong = nuocMua.HinhThucDauNoi3_CanhRong ?? 0,
                                HinhThucDauNoi3_CanhCheo = nuocMua.HinhThucDauNoi3_CanhCheo ?? 0,
                                HinhThucDauNoi4_Loai = nuocMua.HinhThucDauNoi4_Loai ?? 0,
                                HinhThucDauNoi4_CanhDai = nuocMua.HinhThucDauNoi4_CanhDai ?? 0,
                                HinhThucDauNoi4_CanhRong = nuocMua.HinhThucDauNoi4_CanhRong ?? 0,
                                HinhThucDauNoi4_CanhCheo = nuocMua.HinhThucDauNoi4_CanhCheo ?? 0,
                                HinhThucDauNoi5_Loai = nuocMua.HinhThucDauNoi5_Loai ?? 0,
                                HinhThucDauNoi5_CanhDai = nuocMua.HinhThucDauNoi5_CanhDai ?? 0,
                                HinhThucDauNoi5_CanhRong = nuocMua.HinhThucDauNoi5_CanhRong ?? 0,
                                HinhThucDauNoi5_CanhCheo = nuocMua.HinhThucDauNoi5_CanhCheo ?? 0,
                                HinhThucDauNoi6_Loai = nuocMua.HinhThucDauNoi6_Loai ?? 0,
                                HinhThucDauNoi6_CanhDai = nuocMua.HinhThucDauNoi6_CanhDai ?? 0,
                                HinhThucDauNoi6_CanhRong = nuocMua.HinhThucDauNoi6_CanhRong ?? 0,
                                HinhThucDauNoi6_CanhCheo = nuocMua.HinhThucDauNoi6_CanhCheo ?? 0,
                                HinhThucDauNoi7_Loai = nuocMua.HinhThucDauNoi7_Loai ?? 0,
                                HinhThucDauNoi7_CanhDai = nuocMua.HinhThucDauNoi7_CanhDai ?? 0,
                                HinhThucDauNoi7_CanhRong = nuocMua.HinhThucDauNoi7_CanhRong ?? 0,
                                HinhThucDauNoi7_CanhCheo = nuocMua.HinhThucDauNoi7_CanhCheo ?? 0,
                                HinhThucDauNoi8_Loai = nuocMua.HinhThucDauNoi8_Loai ?? 0,
                                HinhThucDauNoi8_CanhDai = nuocMua.HinhThucDauNoi8_CanhDai ?? 0,
                                HinhThucDauNoi8_CanhRong = nuocMua.HinhThucDauNoi8_CanhRong ?? 0,
                                HinhThucDauNoi8_CanhCheo = nuocMua.HinhThucDauNoi8_CanhCheo ?? 0,
                                ThongTinTamDanHoGa2_PhanLoaiDayHoGa = nuocMua.ThongTinTamDanHoGa2_PhanLoaiDayHoGa ?? "",
                                PhanLoaiTDHoGa_PhanLoaiDayHoGa = phanLoaiTDHoGa.ThongTinTamDanHoGa2_PhanLoaiDayHoGa??"",
                                ThongTinTamDanHoGa2_HinhThucDayHoGa = nuocMua.ThongTinTamDanHoGa2_HinhThucDayHoGa ?? "",
                                ThongTinTamDanHoGa2_HinhThucDayHoGa_Name = hinhThucDayHoGa2.Ten,
                                ThongTinTamDanHoGa2_DuongKinh = nuocMua.ThongTinTamDanHoGa2_DuongKinh ?? 0,
                                ThongTinTamDanHoGa2_ChieuDay = nuocMua.ThongTinTamDanHoGa2_ChieuDay ?? 0,
                                ThongTinTamDanHoGa2_D = nuocMua.ThongTinTamDanHoGa2_D ?? 0,
                                ThongTinTamDanHoGa2_R = nuocMua.ThongTinTamDanHoGa2_R ?? 0,
                                ThongTinTamDanHoGa2_C = nuocMua.ThongTinTamDanHoGa2_C ?? 0,
                                ThongTinTamDanHoGa2_SoLuongNapDay = nuocMua.ThongTinTamDanHoGa2_SoLuongNapDay ?? 0,
                                ThongTinVatLieuDaoHoGa_LoaiVatLieuDao = nuocMua.ThongTinVatLieuDaoHoGa_LoaiVatLieuDao ?? "",
                                ThongTinVatLieuDaoHoGa_LoaiVatLieuDao_Name = loaiVatLieuDao.Ten,
                                ThongTinVatLieuDaoHoGa_ChieuCaoDaoDa = nuocMua.ThongTinVatLieuDaoHoGa_ChieuCaoDaoDa ?? 0,
                                ThongTinVatLieuDaoHoGa_ChieuCaoDaoDat = nuocMua.ThongTinVatLieuDaoHoGa_ChieuCaoDaoDat ?? 0,
                                ThongTinVatLieuDaoHoGa_TongChieuCaoDao = nuocMua.ThongTinVatLieuDaoHoGa_TongChieuCaoDao ?? 0,
                                ThongTinCaoDoHoGa_CaoDoTuNhien = nuocMua.ThongTinCaoDoHoGa_CaoDoTuNhien ?? 0,
                                ThongTinCaoDoHoGa_CdDinhViaHeHoanThien = nuocMua.ThongTinCaoDoHoGa_CdDinhViaHeHoanThien ?? 0,
                                ThongTinCaoDoHoGa_CaoDoDinhK98 = nuocMua.ThongTinCaoDoHoGa_CaoDoDinhK98 ?? 0,
                                ThongTinCaoDoHoGa_CaoDoHienTrangTruocKhiDao = nuocMua.ThongTinCaoDoHoGa_CaoDoHienTrangTruocKhiDao ?? 0,
                                ThongTinCaoDoHoGa_DayDao = nuocMua.ThongTinCaoDoHoGa_DayDao ?? 0,
                                ThongTinCaoDoHoGa_CSauDao = nuocMua.ThongTinCaoDoHoGa_CSauDao ?? 0,
                                ThongTinCaoDoHoGa_DinhLotMong = nuocMua.ThongTinCaoDoHoGa_DinhLotMong ?? 0,
                                ThongTinCaoDoHoGa_CdDinhMong = nuocMua.ThongTinCaoDoHoGa_CdDinhMong ?? 0,
                                ThongTinCaoDoHoGa_CdDayHoGa = nuocMua.ThongTinCaoDoHoGa_CdDayHoGa ?? 0,
                                ThongTinCaoDoHoGa_CCaoTuong = nuocMua.ThongTinCaoDoHoGa_CCaoTuong ?? 0,
                                ThongTinCaoDoHoGa_DinhTuongDuoiDamGiuaTuong = nuocMua.ThongTinCaoDoHoGa_DinhTuongDuoiDamGiuaTuong ?? 0,
                                ThongTinCaoDoHoGa_DinhDamGiuaTuong = nuocMua.ThongTinCaoDoHoGa_DinhDamGiuaTuong ?? 0,
                                ThongTinCaoDoHoGa_DinhTuong = nuocMua.ThongTinCaoDoHoGa_DinhTuong ?? 0,
                                ThongTinCaoDoHoGa_DinhMuMoThotDuoi = nuocMua.ThongTinCaoDoHoGa_DinhMuMoThotDuoi ?? 0,
                                ThongTinCaoDoHoGa_CdDinhHoGa = nuocMua.ThongTinCaoDoHoGa_CdDinhHoGa ?? 0,
                                ThongTinCaoDoHoGa_TongChieuCaoHoGa = nuocMua.ThongTinCaoDoHoGa_TongChieuCaoHoGa ?? 0,
                                ThongTinCaoDoHoGa_ChenhCaoDinhHoGaVaHienTrangDao = nuocMua.ThongTinCaoDoHoGa_ChenhCaoDinhHoGaVaHienTrangDao ?? 0,
                                ThongTinCaoDoHoGa_TongChieuCaoChiemChoDapTra = nuocMua.ThongTinCaoDoHoGa_TongChieuCaoChiemChoDapTra ?? 0,
                                TTCCCCDTHT_ChieuCaoLotDat = nuocMua.TTCCCCDTHT_ChieuCaoLotDat ?? 0,
                                TTCCCCDTHT_ChieuCaoMongDat = nuocMua.TTCCCCDTHT_ChieuCaoMongDat ?? 0,
                                TTCCCCDTHT_ChieuCaoTuongDat = nuocMua.TTCCCCDTHT_ChieuCaoTuongDat ?? 0,
                                TTCCCCDTHT_ChieuCaoLotDa = nuocMua.TTCCCCDTHT_ChieuCaoLotDa ?? 0,
                                TTCCCCDTHT_ChieuCaoMongDa = nuocMua.TTCCCCDTHT_ChieuCaoMongDa ?? 0,
                                TTCCCCDTHT_ChieuCaoTuongDa = nuocMua.TTCCCCDTHT_ChieuCaoTuongDa ?? 0,
                                TTCCCCDTHT_TongCieuCaoDat = nuocMua.TTCCCCDTHT_TongCieuCaoDat ?? 0,
                                TTCCCCDTHT_TongChieuCaoDa = nuocMua.TTCCCCDTHT_TongChieuCaoDa ?? 0,
                                TTCCCCDTHT_ChenhDatSoVoiTK = nuocMua.TTCCCCDTHT_ChenhDatSoVoiTK ?? 0,
                                TTCCCCDTHT_ChenhDaSoVoiTK = nuocMua.TTCCCCDTHT_ChenhDaSoVoiTK ?? 0,
                                ThongTinMaiDao_ChieuRongDayDaoNho = nuocMua.ThongTinMaiDao_ChieuRongDayDaoNho ?? 0,
                                ThongTinMaiDao_TyLeMoMai = nuocMua.ThongTinMaiDao_TyLeMoMai ?? 0,
                                ThongTinMaiDao_SoCanhMaiTrai = nuocMua.ThongTinMaiDao_SoCanhMaiTrai ?? 0,
                                ThongTinMaiDao_SoCanhMaiPhai = nuocMua.ThongTinMaiDao_SoCanhMaiPhai ?? 0,
                                TTKLD_CRongDaoDayLonDat = nuocMua.TTKLD_CRongDaoDayLonDat ?? 0,
                                TTKLD_CRongDaoDayLonDa = nuocMua.TTKLD_CRongDaoDayLonDa ?? 0,
                                TTKLD_DienTichDaoDat = nuocMua.TTKLD_DienTichDaoDat ?? 0,
                                TTKLD_DienTichDaoDa = nuocMua.TTKLD_DienTichDaoDa ?? 0,
                                TTKLD_TongDtDao = nuocMua.TTKLD_TongDtDao ?? 0,
                                TTKLD_KlDaoDat = nuocMua.TTKLD_KlDaoDat ?? 0,
                                TTKLD_KlDaoDa = nuocMua.TTKLD_KlDaoDa ?? 0,
                                TTKLD_TongKlDao = nuocMua.TTKLD_TongKlDao ?? 0,
                                TTKLD_KlChiemChoDat = nuocMua.TTKLD_KlChiemChoDat ?? 0,
                                TTKLD_KlChiemChoDa = nuocMua.TTKLD_KlChiemChoDa ?? 0,
                                TTKLD_TongChiemCho = nuocMua.TTKLD_TongChiemCho ?? 0,
                                TTKLD_KlDapTraDat = nuocMua.TTKLD_KlDapTraDat ?? 0,
                                TTKLD_KlDapTraDa = nuocMua.TTKLD_KlDapTraDa ?? 0,
                                TTKLD_TongDapTra = nuocMua.TTKLD_TongDapTra ?? 0,
                                TTKLD_KlThuaDat = nuocMua.TTKLD_KlThuaDat ?? 0,
                                TTKLD_KlThuaDa = nuocMua.TTKLD_KlThuaDa ?? 0,
                                TTKLD_TongThua = nuocMua.TTKLD_TongThua ?? 0,
                                ThongTinLyTrinhTruyenDan_TuLyTrinh = nuocMua.ThongTinLyTrinhTruyenDan_TuLyTrinh ?? 0,
                                ThongTinLyTrinhTruyenDan_DenLyTrinh = nuocMua.ThongTinLyTrinhTruyenDan_DenLyTrinh ?? 0,
                                ThongTinLyTrinhTruyenDan_TuHoGa = nuocMua.ThongTinLyTrinhTruyenDan_TuHoGa ?? "",
                                ThongTinLyTrinhTruyenDan_DenHoGa = nuocMua.ThongTinLyTrinhTruyenDan_DenHoGa ?? "",
                                ThongTinDuongTruyenDan_HinhThucTruyenDan = nuocMua.ThongTinDuongTruyenDan_HinhThucTruyenDan ?? "",
                                ThongTinDuongTruyenDan_HinhThucTruyenDan_Name = hinhThucTruyenDan.Ten,
                                ThongTinDuongTruyenDan_LoaiTruyenDan = nuocMua.ThongTinDuongTruyenDan_LoaiTruyenDan ?? "",
                                ThongTinDuongTruyenDan_LoaiTruyenDan_Name = loaiTruyenDan.Ten,
                                ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai = nuocMua.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai ?? "",
                                PhanLoaiCTronHopNhua_TenLoaiTruyenDanSauPhanLoai = PhanLoaiCTronHopNhua.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai ?? "",

                                TTCDSLCauKienDuongTruyenDan_TongChieuDai = nuocMua.TTCDSLCauKienDuongTruyenDan_TongChieuDai ?? 0,
                                TTCDSLCauKienDuongTruyenDan_ChieuDai01CauKien = nuocMua.TTCDSLCauKienDuongTruyenDan_ChieuDai01CauKien ?? 0,
                                TTCDSLCauKienDuongTruyenDan_SlCauKienTinhKl = nuocMua.TTCDSLCauKienDuongTruyenDan_SlCauKienTinhKl ?? 0,

                                ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop = nuocMua.ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop ?? "",
                                PhanLoaiMongCTron_PhanLoaiMongCongTronCongHop = PhanLoaiMongCTron.ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop ?? "",
                                ThongTinMongDuongTruyenDan_LoaiMong = nuocMua.ThongTinMongDuongTruyenDan_LoaiMong ?? "",
                                ThongTinMongDuongTruyenDan_LoaiMong_Name = loaiMong.Ten,
                                ThongTinMongDuongTruyenDan_HinhThucMong = nuocMua.ThongTinMongDuongTruyenDan_HinhThucMong ?? "",
                                ThongTinMongDuongTruyenDan_HinhThucMong_Name = hinhThucMong.Ten,
                                ThongTinDeCong_TenLoaiDeCong = nuocMua.ThongTinDeCong_TenLoaiDeCong ?? "",
                                PhanLoaiDeCong_TenLoaiDeCong = PhanLoaiDeCong.ThongTinDeCong_TenLoaiDeCong ?? "",
                                ThongTinDeCong_CauTaoDeCong = nuocMua.ThongTinDeCong_CauTaoDeCong ?? "",
                                ThongTinDeCong_D = nuocMua.ThongTinDeCong_D ?? 0,
                                ThongTinDeCong_R = nuocMua.ThongTinDeCong_R ?? 0,
                                ThongTinDeCong_C = nuocMua.ThongTinDeCong_C ?? 0,
                                ThongTinDeCong_SlDeCong01CauKienTruyenDan = nuocMua.ThongTinDeCong_SlDeCong01CauKienTruyenDan ?? 0,
                                ThongTinDeCong_Kl01DeCong = nuocMua.ThongTinDeCong_Kl01DeCong ?? 0,
                                ThongTinDeCong_TongSoLuongDC = nuocMua.ThongTinDeCong_TongSoLuongDC ?? 0,
                                ThongTinDeCong_TongKLDeCong = nuocMua.ThongTinDeCong_TongKLDeCong ?? 0,
                                ThongTinCauTaoCongTron_CDayPhuBi = nuocMua.ThongTinCauTaoCongTron_CDayPhuBi ?? 0,
                                ThongTinCauTaoCongTron_SoCanh = nuocMua.ThongTinCauTaoCongTron_SoCanh ?? 0,
                                ThongTinCauTaoCongTron_LongSuDung = nuocMua.ThongTinCauTaoCongTron_LongSuDung ?? 0,
                                ThongTinCauTaoCongTron_CCaoCauKien = nuocMua.ThongTinCauTaoCongTron_CCaoCauKien ?? 0,
                                ThongTinCauTaoCongTron_CCaoLotMong = nuocMua.ThongTinCauTaoCongTron_CCaoLotMong ?? 0,
                                ThongTinCauTaoCongTron_CRongLotMong = nuocMua.ThongTinCauTaoCongTron_CRongLotMong ?? 0,
                                ThongTinCauTaoCongTron_CCaoMong = nuocMua.ThongTinCauTaoCongTron_CCaoMong ?? 0,
                                ThongTinCauTaoCongTron_CRongMong = nuocMua.ThongTinCauTaoCongTron_CRongMong ?? 0,
                                ThongTinCauTaoCongTron_CCaoDe = nuocMua.ThongTinCauTaoCongTron_CCaoDe ?? 0,
                                ThongTinCauTaoCongTron_TongCCaoCong = nuocMua.ThongTinCauTaoCongTron_TongCCaoCong ?? 0,
                                TTTKLCKCTCH_CDMoiNoiCKien = nuocMua.TTTKLCKCTCH_CDMoiNoiCKien ?? 0,
                                TTTKLCKCTCH_SLCKDungDeTinhCD = nuocMua.TTTKLCKCTCH_SLCKDungDeTinhCD ?? 0,
                                TTTKLCKCTCH_SLCKNguyen = nuocMua.TTTKLCKCTCH_SLCKNguyen ?? 0,
                                TTTKLCKCTCH_CDCanLapDat = nuocMua.TTTKLCKCTCH_CDCanLapDat ?? 0,
                                TTTKLCKCTCH_TongCD = nuocMua.TTTKLCKCTCH_TongCD ?? 0,
                                TTTKLCKCTCH_CDThucTeThuaThieu = nuocMua.TTTKLCKCTCH_CDThucTeThuaThieu ?? 0,
                                TTTKLCKCTCH_XDOngCongCanThem = nuocMua.TTTKLCKCTCH_XDOngCongCanThem ?? "",
                                TTTKLCKCTCH_CDThuaThieuSauTinhKL = nuocMua.TTTKLCKCTCH_CDThuaThieuSauTinhKL ?? 0,
                                TTKTHHCongHopRanh_CauTaoTuong = nuocMua.TTKTHHCongHopRanh_CauTaoTuong ?? "",
                                TTKTHHCongHopRanh_CauTaoTuong_Name = cauTaoTuong.Ten,
                                TTKTHHCongHopRanh_CauTaoMuMo = nuocMua.TTKTHHCongHopRanh_CauTaoMuMo ?? "",
                                TTKTHHCongHopRanh_CauTaoMuMo_Name = cauTaoMuMo.Ten,
                                TTKTHHCongHopRanh_ChatMatTrong = nuocMua.TTKTHHCongHopRanh_ChatMatTrong ?? "",
                                TTKTHHCongHopRanh_ChatMatTrong_Name = chatMatTrong_TTKTHH.Ten,
                                TTKTHHCongHopRanh_ChatMatNgoai = nuocMua.TTKTHHCongHopRanh_ChatMatNgoai ?? "",
                                TTKTHHCongHopRanh_ChatMatNgoai_Name = chatMatNgoai_TTKTHH.Ten,
                                TTKTHHCongHopRanh_CCaoLotMong = nuocMua.TTKTHHCongHopRanh_CCaoLotMong ?? 0,
                                TTKTHHCongHopRanh_CRongLotMong = nuocMua.TTKTHHCongHopRanh_CRongLotMong ?? 0,
                                TTKTHHCongHopRanh_CCaoMong = nuocMua.TTKTHHCongHopRanh_CCaoMong ?? 0,
                                TTKTHHCongHopRanh_CRongMong = nuocMua.TTKTHHCongHopRanh_CRongMong ?? 0,
                                TTKTHHCongHopRanh_CCaoDe = nuocMua.TTKTHHCongHopRanh_CCaoDe ?? 0,
                                TTKTHHCongHopRanh_CRongDe = nuocMua.TTKTHHCongHopRanh_CRongDe ?? 0,
                                TTKTHHCongHopRanh_CDayTuong01Ben = nuocMua.TTKTHHCongHopRanh_CDayTuong01Ben ?? 0,
                                TTKTHHCongHopRanh_SoLuongTuong = nuocMua.TTKTHHCongHopRanh_SoLuongTuong ?? 0,
                                TTKTHHCongHopRanh_CRongLongSuDung = nuocMua.TTKTHHCongHopRanh_CRongLongSuDung ?? 0,
                                TTKTHHCongHopRanh_CCaoTuongCongHop = nuocMua.TTKTHHCongHopRanh_CCaoTuongCongHop ?? 0,
                                TTKTHHCongHopRanh_CCaoTuongRanh = nuocMua.TTKTHHCongHopRanh_CCaoTuongRanh ?? 0,
                                TTKTHHCongHopRanh_CCaoTuongGop = nuocMua.TTKTHHCongHopRanh_CCaoTuongGop ?? 0,
                                TTKTHHCongHopRanh_CCaoMuMoThotDuoi = nuocMua.TTKTHHCongHopRanh_CCaoMuMoThotDuoi ?? 0,
                                TTKTHHCongHopRanh_CRongMuMoDuoi = nuocMua.TTKTHHCongHopRanh_CRongMuMoDuoi ?? 0,
                                TTKTHHCongHopRanh_CCaoMuMoThotTren = nuocMua.TTKTHHCongHopRanh_CCaoMuMoThotTren ?? 0,
                                TTKTHHCongHopRanh_CRongMuMoTren = nuocMua.TTKTHHCongHopRanh_CRongMuMoTren ?? 0,
                                TTKTHHCongHopRanh_LoaiThanhChong = nuocMua.TTKTHHCongHopRanh_LoaiThanhChong ?? "",
                                PhanLoaiThanhChong_LoaiThanhChong = PhanLoaiThanhChong.TTKTHHCongHopRanh_LoaiThanhChong ?? "",
                                TTKTHHCongHopRanh_CauTaoThanhChong = nuocMua.TTKTHHCongHopRanh_CauTaoThanhChong ?? "",
                                TTKTHHCongHopRanh_CauTaoThanhChong_Name = cauTaoThanhChong.Ten,
                                TTKTHHCongHopRanh_CCaoThanhChong = nuocMua.TTKTHHCongHopRanh_CCaoThanhChong ?? 0,
                                TTKTHHCongHopRanh_CRongThanhChong = nuocMua.TTKTHHCongHopRanh_CRongThanhChong ?? 0,
                                TTKTHHCongHopRanh_CDai = nuocMua.TTKTHHCongHopRanh_CDai ?? 0,
                                TTKTHHCongHopRanh_SoLuongThanhChong = nuocMua.TTKTHHCongHopRanh_SoLuongThanhChong ?? 0,
                                TTKTHHCongHopRanh_CCaoChatMatTrong = nuocMua.TTKTHHCongHopRanh_CCaoChatMatTrong ?? 0,
                                TTKTHHCongHopRanh_CCaoChatmatNgoai = nuocMua.TTKTHHCongHopRanh_CCaoChatmatNgoai ?? 0,
                                TTKTHHCongHopRanh_TongChieuCao = nuocMua.TTKTHHCongHopRanh_TongChieuCao ?? 0,
                                TTTDCongHoRanh_TenLoaiTamDanTieuChuan = nuocMua.TTTDCongHoRanh_TenLoaiTamDanTieuChuan ?? "",
                                PhanLoaiTDanTDan_TenLoaiTamDanTieuChuan = PhanLoaiTDanTDan.TTTDCongHoRanh_TenLoaiTamDanTieuChuan??"",
                                TTTDCongHoRanh_CauTaoTamDanTruyenDanTamDanTieuChuan = nuocMua.TTTDCongHoRanh_CauTaoTamDanTruyenDanTamDanTieuChuan ?? "",
                                TTTDCongHoRanh_CauTaoTamDanTruyenDanTamDanTieuChuan_Name = cauTaoTamDanTruyenDanTamDanTieuChuan.Ten,
                                TTTDCongHoRanh_SoLuong = nuocMua.TTTDCongHoRanh_SoLuong ?? 0,
                                TTTDCongHoRanh_CDai = nuocMua.TTTDCongHoRanh_CDai ?? 0,
                                TTTDCongHoRanh_CRong = nuocMua.TTTDCongHoRanh_CRong ?? 0,
                                TTTDCongHoRanh_CCao = nuocMua.TTTDCongHoRanh_CCao ?? 0,
                                TTTDCongHoRanh_TenLoaiTamDanLoai02 = nuocMua.TTTDCongHoRanh_TenLoaiTamDanLoai02 ?? "",
                                PhanLoaiTDanTDan_TenLoaiTamDanLoai02 = PhanLoaiTDanTDan02.TTTDCongHoRanh_TenLoaiTamDanTieuChuan??"",
                                TTTDCongHoRanh_CauTaoTamDanTruyenDan = nuocMua.TTTDCongHoRanh_CauTaoTamDanTruyenDan ?? "",
                                TTTDCongHoRanh_CauTaoTamDanTruyenDan_Name = cauTaoTamDanTruyenDan.Ten,
                                TTTDCongHoRanh_SoLuong1 = nuocMua.TTTDCongHoRanh_SoLuong1 ?? 0,
                                TTTDCongHoRanh_CDai1 = nuocMua.TTTDCongHoRanh_CDai1 ?? 0,
                                TTTDCongHoRanh_CRong1 = nuocMua.TTTDCongHoRanh_CRong1 ?? 0,
                                TTTDCongHoRanh_CCao1 = nuocMua.TTTDCongHoRanh_CCao1 ?? 0,
                                TTTDCongHoRanh_ChieuDaiMoiNoi = nuocMua.TTTDCongHoRanh_ChieuDaiMoiNoi ?? 0,
                                TTTDCongHoRanh_SoLuongTDanDungDeTinhChieuDaiBoSung = nuocMua.TTTDCongHoRanh_SoLuongTDanDungDeTinhChieuDaiBoSung ?? 0,
                                TTTDCongHoRanh_SLCauKienNguyen = nuocMua.TTTDCongHoRanh_SLCauKienNguyen ?? 0,
                                TTTDCongHoRanh_ChieuDaiTheoSoCKNguyen = nuocMua.TTTDCongHoRanh_ChieuDaiTheoSoCKNguyen ?? 0,
                                TTTDCongHoRanh_TongChieuDaiTheoCKNguyen = nuocMua.TTTDCongHoRanh_TongChieuDaiTheoCKNguyen ?? 0,
                                TTTDCongHoRanh_ChieuDaiThucTe = nuocMua.TTTDCongHoRanh_ChieuDaiThucTe ?? 0,
                                TTTDCongHoRanh_XacDinhOngCongCanThem = nuocMua.TTTDCongHoRanh_XacDinhOngCongCanThem ?? "",
                                ThongTinKichThuocHinhHocOngNhua_CDayPhuBi = nuocMua.ThongTinKichThuocHinhHocOngNhua_CDayPhuBi ?? 0,
                                ThongTinKichThuocHinhHocOngNhua_SoCanh = nuocMua.ThongTinKichThuocHinhHocOngNhua_SoCanh ?? 0,
                                ThongTinKichThuocHinhHocOngNhua_LongSuDung = nuocMua.ThongTinKichThuocHinhHocOngNhua_LongSuDung ?? 0,
                                ThongTinKichThuocHinhHocOngNhua_TongCCaoOng = nuocMua.ThongTinKichThuocHinhHocOngNhua_TongCCaoOng ?? 0,
                                ThongTinKichThuocHinhHocOngNhua_CCaoDemCat = nuocMua.ThongTinKichThuocHinhHocOngNhua_CCaoDemCat ?? 0,
                                ThongTinKichThuocHinhHocOngNhua_CCaoDapCat = nuocMua.ThongTinKichThuocHinhHocOngNhua_CCaoDapCat ?? 0,
                                CDThuongLuu_HienTrangTruocKhiDaoThuongLuu = nuocMua.CDThuongLuu_HienTrangTruocKhiDaoThuongLuu ?? 0,
                                CDThuongLuu_DayDaoGop = nuocMua.CDThuongLuu_DayDaoGop ?? 0,
                                CDThuongLuu_ChieuSauDao = nuocMua.CDThuongLuu_ChieuSauDao ?? 0,
                                CDThuongLuu_DayDaoCongTron = nuocMua.CDThuongLuu_DayDaoCongTron ?? 0,
                                CDThuongLuu_DayDaoCongHop = nuocMua.CDThuongLuu_DayDaoCongHop ?? 0,
                                CDThuongLuu_DayDaoRanh = nuocMua.CDThuongLuu_DayDaoRanh ?? 0,
                                CDThuongLuu_DayDaoOngNhua = nuocMua.CDThuongLuu_DayDaoOngNhua ?? 0,
                                CDThuongLuu_DinhLotGop = nuocMua.CDThuongLuu_DinhLotGop ?? 0,
                                CDThuongLuu_DinhLotOngNhua = nuocMua.CDThuongLuu_DinhLotOngNhua ?? 0,
                                CDThuongLuu_DinhLotCongTron = nuocMua.CDThuongLuu_DinhLotCongTron ?? 0,
                                CDThuongLuu_DinhLotCongHop = nuocMua.CDThuongLuu_DinhLotCongHop ?? 0,
                                CDThuongLuu_DinhLotRanh = nuocMua.CDThuongLuu_DinhLotRanh ?? 0,
                                CDThuongLuu_DinhMongGop = nuocMua.CDThuongLuu_DinhMongGop ?? 0,
                                CDThuongLuu_DinhMongCongTron = nuocMua.CDThuongLuu_DinhMongCongTron ?? 0,
                                CDThuongLuu_DinhMongCongHop = nuocMua.CDThuongLuu_DinhMongCongHop ?? 0,
                                CDThuongLuu_DinhMongRanh = nuocMua.CDThuongLuu_DinhMongRanh ?? 0,
                                CDThuongLuu_DinhDeCong = nuocMua.CDThuongLuu_DinhDeCong ?? 0,
                                CDThuongLuu_DayDongChay = nuocMua.CDThuongLuu_DayDongChay ?? 0,
                                CDThuongLuu_CCaoTuongCongRanh = nuocMua.CDThuongLuu_CCaoTuongCongRanh ?? 0,
                                CDThuongLuu_DinhTuongCHopRanh = nuocMua.CDThuongLuu_DinhTuongCHopRanh ?? 0,
                                CDThuongLuu_DinhMuMoThotDuoiCongHopRanh = nuocMua.CDThuongLuu_DinhMuMoThotDuoiCongHopRanh ?? 0,
                                CDThuongLuu_DinhGop = nuocMua.CDThuongLuu_DinhGop ?? 0,
                                CDThuongLuu_DinhTrongLongSuDung = nuocMua.CDThuongLuu_DinhTrongLongSuDung ?? 0,
                                CDThuongLuu_DinhCongTron = nuocMua.CDThuongLuu_DinhCongTron ?? 0,
                                CDThuongLuu_DinhCongHop = nuocMua.CDThuongLuu_DinhCongHop ?? 0,
                                CDThuongLuu_DinhRanh = nuocMua.CDThuongLuu_DinhRanh ?? 0,
                                CDThuongLuu_DinhOngNhua = nuocMua.CDThuongLuu_DinhOngNhua ?? 0,
                                CDThuongLuu_DinhDapCat = nuocMua.CDThuongLuu_DinhDapCat ?? 0,
                                CDHaLu_HienTrangTruocKhiDaoHaLuu = nuocMua.CDHaLu_HienTrangTruocKhiDaoHaLuu ?? 0,
                                CDHaLu_DayDaoGop = nuocMua.CDHaLu_DayDaoGop ?? 0,
                                CDHaLu_ChieuSauDao = nuocMua.CDHaLu_ChieuSauDao ?? 0,
                                CDHaLu_DayDaoCongTron = nuocMua.CDHaLu_DayDaoCongTron ?? 0,
                                CDHaLu_DayDaoCongHop = nuocMua.CDHaLu_DayDaoCongHop ?? 0,
                                CDHaLu_DayDaoRanh = nuocMua.CDHaLu_DayDaoRanh ?? 0,
                                CDHaLu_DayDaoOngNhua = nuocMua.CDHaLu_DayDaoOngNhua ?? 0,
                                CDHaLu_DinhLotGop = nuocMua.CDHaLu_DinhLotGop ?? 0,
                                CDHaLu_DinhLotOngNhua = nuocMua.CDHaLu_DinhLotOngNhua ?? 0,
                                CDHaLu_DinhLotCongTron = nuocMua.CDHaLu_DinhLotCongTron ?? 0,
                                CDHaLu_DinhLotCongHop = nuocMua.CDHaLu_DinhLotCongHop ?? 0,
                                CDHaLu_DinhLotRanh = nuocMua.CDHaLu_DinhLotRanh ?? 0,
                                CDHaLu_DinhMongGop = nuocMua.CDHaLu_DinhMongGop ?? 0,
                                CDHaLu_DinhMongCongTron = nuocMua.CDHaLu_DinhMongCongTron ?? 0,
                                CDHaLu_DinhMongCongHop = nuocMua.CDHaLu_DinhMongCongHop ?? 0,
                                CDHaLu_DinhMongRanh = nuocMua.CDHaLu_DinhMongRanh ?? 0,
                                CDHaLu_DinhDeCong = nuocMua.CDHaLu_DinhDeCong ?? 0,
                                CDHaLu_DayDongChay = nuocMua.CDHaLu_DayDongChay ?? 0,
                                CDHaLu_CCaoTuongCongRanh = nuocMua.CDHaLu_CCaoTuongCongRanh ?? 0,
                                CDHaLu_DinhTuongCHopRanh = nuocMua.CDHaLu_DinhTuongCHopRanh ?? 0,
                                CDHaLu_DinhMuMoThotDuoiCongHopRanh = nuocMua.CDHaLu_DinhMuMoThotDuoiCongHopRanh ?? 0,
                                CDHaLu_DinhGop = nuocMua.CDHaLu_DinhGop ?? 0,
                                CDHaLu_DinhTrongLongSuDung = nuocMua.CDHaLu_DinhTrongLongSuDung ?? 0,
                                CDHaLu_DinhCongTron = nuocMua.CDHaLu_DinhCongTron ?? 0,
                                CDHaLu_DinhCongHop = nuocMua.CDHaLu_DinhCongHop ?? 0,
                                CDHaLu_DinhRanh = nuocMua.CDHaLu_DinhRanh ?? 0,
                                CDHaLu_DinhOngNhua = nuocMua.CDHaLu_DinhOngNhua ?? 0,
                                CDHaLu_DinhDapCat = nuocMua.CDHaLu_DinhDapCat ?? 0,
                                TTVLDCongRanh_LoaiVatLieuDao = nuocMua.TTVLDCongRanh_LoaiVatLieuDao ?? "",
                                TTVLDCongRanh_LoaiVatLieuDao_Name = loaiVatLieuDao_TTVLD.Ten,
                                TTVLDCongRanh_TLChieuCaoDaoDa = nuocMua.TTVLDCongRanh_TLChieuCaoDaoDa ?? 0,
                                TTVLDCongRanh_TLChieuCaoDaoDat = nuocMua.TTVLDCongRanh_TLChieuCaoDaoDat ?? 0,
                                TTVLDCongRanh_TLTongChieuSauDao = nuocMua.TTVLDCongRanh_TLTongChieuSauDao ?? 0,
                                TTVLDCongRanh_HLChieuCaoDaoDa = nuocMua.TTVLDCongRanh_HLChieuCaoDaoDa ?? 0,
                                TTVLDCongRanh_HLChieuCaoDaoDat = nuocMua.TTVLDCongRanh_HLChieuCaoDaoDat ?? 0,
                                TTVLDCongRanh_HLTongChieuSauDao = nuocMua.TTVLDCongRanh_HLTongChieuSauDao ?? 0,
                                TTCCCCT_CCaoLotDatTLuu = nuocMua.TTCCCCT_CCaoLotDatTLuu ?? 0,
                                TTCCCCT_CCaoLotDatHLuu = nuocMua.TTCCCCT_CCaoLotDatHLuu ?? 0,
                                TTCCCCT_CCaoLotDatMongTBinh = nuocMua.TTCCCCT_CCaoLotDatMongTBinh ?? 0,
                                TTCCCCT_CCaoLotDaTLuu = nuocMua.TTCCCCT_CCaoLotDaTLuu ?? 0,
                                TTCCCCT_CCaoLotDaHLuu = nuocMua.TTCCCCT_CCaoLotDaHLuu ?? 0,
                                TTCCCCT_CCaoLotDaMongTBinh = nuocMua.TTCCCCT_CCaoLotDaMongTBinh ?? 0,
                                TTCCCCT_CCaoMongDatTLuu = nuocMua.TTCCCCT_CCaoMongDatTLuu ?? 0,
                                TTCCCCT_CCaoMongDatHLuu = nuocMua.TTCCCCT_CCaoMongDatHLuu ?? 0,
                                TTCCCCT_CCaoMongDatTBinh = nuocMua.TTCCCCT_CCaoMongDatTBinh ?? 0,
                                TTCCCCT_CCaoMongDaTLuu = nuocMua.TTCCCCT_CCaoMongDaTLuu ?? 0,
                                TTCCCCT_CCaoMongDaHLuu = nuocMua.TTCCCCT_CCaoMongDaHLuu ?? 0,
                                TTCCCCT_CCaoMongDaTBinh = nuocMua.TTCCCCT_CCaoMongDaTBinh ?? 0,
                                TTCCCCT_CCaoDeDatTLuu = nuocMua.TTCCCCT_CCaoDeDatTLuu ?? 0,
                                TTCCCCT_CCaoDeDatHLuu = nuocMua.TTCCCCT_CCaoDeDatHLuu ?? 0,
                                TTCCCCT_CCaoDeDatTBinh = nuocMua.TTCCCCT_CCaoDeDatTBinh ?? 0,
                                TTCCCCT_CCaoDeDaTLuu = nuocMua.TTCCCCT_CCaoDeDaTLuu ?? 0,
                                TTCCCCT_CCaoDeDaHLuu = nuocMua.TTCCCCT_CCaoDeDaHLuu ?? 0,
                                TTCCCCT_CCaoDeDaTBinh = nuocMua.TTCCCCT_CCaoDeDaTBinh ?? 0,
                                TTCCCCT_CCaoCongDatTLuu = nuocMua.TTCCCCT_CCaoCongDatTLuu ?? 0,
                                TTCCCCT_CCaoCongDatHLuu = nuocMua.TTCCCCT_CCaoCongDatHLuu ?? 0,
                                TTCCCCT_CCongCongDatTBinh = nuocMua.TTCCCCT_CCongCongDatTBinh ?? 0,
                                TTCCCCT_CCaoCongDaTLuu = nuocMua.TTCCCCT_CCaoCongDaTLuu ?? 0,
                                TTCCCCT_CCaoCongDaHLuu = nuocMua.TTCCCCT_CCaoCongDaHLuu ?? 0,
                                TTCCCCT_CCongCongDaTBinh = nuocMua.TTCCCCT_CCongCongDaTBinh ?? 0,
                                TTCCCCCHR_CCaoLotDatTLuu = nuocMua.TTCCCCCHR_CCaoLotDatTLuu ?? 0,
                                TTCCCCCHR_CCaoLotDatHLuu = nuocMua.TTCCCCCHR_CCaoLotDatHLuu ?? 0,
                                TTCCCCCHR_CCaoLotDatTBinh = nuocMua.TTCCCCCHR_CCaoLotDatTBinh ?? 0,
                                TTCCCCCHR_CCaoLotDaTLuu = nuocMua.TTCCCCCHR_CCaoLotDaTLuu ?? 0,
                                TTCCCCCHR_CCaoLotDaHLuu = nuocMua.TTCCCCCHR_CCaoLotDaHLuu ?? 0,
                                TTCCCCCHR_CCaoLotDaTBinh = nuocMua.TTCCCCCHR_CCaoLotDaTBinh ?? 0,
                                TTCCCCCHR_CCaoMongDatTLuu = nuocMua.TTCCCCCHR_CCaoMongDatTLuu ?? 0,
                                TTCCCCCHR_CCaoMongDatHLuu = nuocMua.TTCCCCCHR_CCaoMongDatHLuu ?? 0,
                                TTCCCCCHR_CCaoMongDatTBinh = nuocMua.TTCCCCCHR_CCaoMongDatTBinh ?? 0,
                                TTCCCCCHR_CCaoMongDaTLuu = nuocMua.TTCCCCCHR_CCaoMongDaTLuu ?? 0,
                                TTCCCCCHR_CCaoMongDaHLuu = nuocMua.TTCCCCCHR_CCaoMongDaHLuu ?? 0,
                                TTCCCCCHR_CCaoMongDaTBinh = nuocMua.TTCCCCCHR_CCaoMongDaTBinh ?? 0,
                                TTCCCCCHR_CCaoTuongDatTLuu = nuocMua.TTCCCCCHR_CCaoTuongDatTLuu ?? 0,
                                TTCCCCCHR_CCaoTuongDatHLuu = nuocMua.TTCCCCCHR_CCaoTuongDatHLuu ?? 0,
                                TTCCCCCHR_CCaoTuongDatTBinh = nuocMua.TTCCCCCHR_CCaoTuongDatTBinh ?? 0,
                                TTCCCCCHR_CCaoTuongDaTLuu = nuocMua.TTCCCCCHR_CCaoTuongDaTLuu ?? 0,
                                TTCCCCCHR_CCaoTuongDaHLuu = nuocMua.TTCCCCCHR_CCaoTuongDaHLuu ?? 0,
                                TTCCCCCHR_CCaoTuongDaTBinh = nuocMua.TTCCCCCHR_CCaoTuongDaTBinh ?? 0,
                                TTCCCCON_CCaoDemCatDatTLuu = nuocMua.TTCCCCON_CCaoDemCatDatTLuu ?? 0,
                                TTCCCCON_CCaoDemCatDatHLuu = nuocMua.TTCCCCON_CCaoDemCatDatHLuu ?? 0,
                                TTCCCCON_CCaoDemCatDatTBinh = nuocMua.TTCCCCON_CCaoDemCatDatTBinh ?? 0,
                                TTCCCCON_CCaoDemCatDaTLuu = nuocMua.TTCCCCON_CCaoDemCatDaTLuu ?? 0,
                                TTCCCCON_CCaoDemCatDaHLuu = nuocMua.TTCCCCON_CCaoDemCatDaHLuu ?? 0,
                                TTCCCCON_CCaoDemCatDaTBinh = nuocMua.TTCCCCON_CCaoDemCatDaTBinh ?? 0,
                                TTCCCCON_CCaoOngDatTLuu = nuocMua.TTCCCCON_CCaoOngDatTLuu ?? 0,
                                TTCCCCON_CCaoOngDatHLuu = nuocMua.TTCCCCON_CCaoOngDatHLuu ?? 0,
                                TTCCCCON_CCaoDatTBinh = nuocMua.TTCCCCON_CCaoDatTBinh ?? 0,
                                TTCCCCON_CCaoOngDaTLuu = nuocMua.TTCCCCON_CCaoOngDaTLuu ?? 0,
                                TTCCCCON_CCaoOngDaHLuu = nuocMua.TTCCCCON_CCaoOngDaHLuu ?? 0,
                                TTCCCCON_CCaoDaTBinh = nuocMua.TTCCCCON_CCaoDaTBinh ?? 0,
                                TTCCCCON_CCaoDapCatDatTLuu = nuocMua.TTCCCCON_CCaoDapCatDatTLuu ?? 0,
                                TTCCCCON_CCaoDapCatDatHLuu = nuocMua.TTCCCCON_CCaoDapCatDatHLuu ?? 0,
                                TTCCCCON_CCaoDapCatDatTBinh = nuocMua.TTCCCCON_CCaoDapCatDatTBinh ?? 0,
                                TTCCCCON_CCaoDapCatDaTLuu = nuocMua.TTCCCCON_CCaoDapCatDaTLuu ?? 0,
                                TTCCCCON_CCaoDapCatDaHLuu = nuocMua.TTCCCCON_CCaoDapCatDaHLuu ?? 0,
                                TTCCCCON_CCaoDapCatDaTBinh = nuocMua.TTCCCCON_CCaoDapCatDaTBinh ?? 0,
                                TTMDRanhOngThang_ChieuRongDayDaoNho = nuocMua.TTMDRanhOngThang_ChieuRongDayDaoNho ?? 0,
                                TTMDRanhOngThang_TyLeMoMai = nuocMua.TTMDRanhOngThang_TyLeMoMai ?? 0,
                                TTMDRanhOngThang_SoCanhMaiTrai = nuocMua.TTMDRanhOngThang_SoCanhMaiTrai ?? 0,
                                TTMDRanhOngThang_SoCanhMaiPhai = nuocMua.TTMDRanhOngThang_SoCanhMaiPhai ?? 0,
                                DTDTLCRONRT_CRongDaoDatDayLon = nuocMua.DTDTLCRONRT_CRongDaoDatDayLon ?? 0,
                                DTDTLCRONRT_DTichDaoDat = nuocMua.DTDTLCRONRT_DTichDaoDat ?? 0,
                                DTDTLCRONRT_CRongDaoDaDayLon = nuocMua.DTDTLCRONRT_CRongDaoDaDayLon ?? 0,
                                DTDTLCRONRT_DTichDaoDa = nuocMua.DTDTLCRONRT_DTichDaoDa ?? 0,
                                DTDHLCRONRT_CRongDaoDatDayLon = nuocMua.DTDHLCRONRT_CRongDaoDatDayLon ?? 0,
                                DTDHLCRONRT_DTichDaoDat = nuocMua.DTDHLCRONRT_DTichDaoDat ?? 0,
                                DTDHLCRONRT_CRongDaoDaDayLon = nuocMua.DTDHLCRONRT_CRongDaoDaDayLon ?? 0,
                                DTDHLCRONRT_DTichDaoDa = nuocMua.DTDHLCRONRT_DTichDaoDa ?? 0,
                                DTDTB_DaoDatCRDaoDayLon = nuocMua.DTDTB_DaoDatCRDaoDayLon ?? 0,
                                DTDTB_DaoDatDTDao = nuocMua.DTDTB_DaoDatDTDao ?? 0,
                                DTDTB_DaoDaCRDaoDayLon = nuocMua.DTDTB_DaoDaCRDaoDayLon ?? 0,
                                DTDTB_DaoDaDTDao = nuocMua.DTDTB_DaoDaDTDao ?? 0,
                                TKLD_KlDaoDat = nuocMua.TKLD_KlDaoDat ?? 0,
                                TKLD_KlDaoDa = nuocMua.TKLD_KlDaoDa ?? 0,
                                TKLD_TongKlDaoCongRanhOngNhuaRanhThang = nuocMua.TKLD_TongKlDaoCongRanhOngNhuaRanhThang ?? 0,
                                TKLD_KlCChoDatCongTron = nuocMua.TKLD_KlCChoDatCongTron ?? 0,
                                TKLD_KlCChoDaCongTron = nuocMua.TKLD_KlCChoDaCongTron ?? 0,
                                TKLD_TongKlChiemChoCTron = nuocMua.TKLD_TongKlChiemChoCTron ?? 0,
                                TKLD_KlCChoDatCongHop = nuocMua.TKLD_KlCChoDatCongHop ?? 0,
                                TKLD_KlCChoDaCongHop = nuocMua.TKLD_KlCChoDaCongHop ?? 0,
                                TKLD_TongKlCChoCongHop = nuocMua.TKLD_TongKlCChoCongHop ?? 0,
                                TKLD_KlCChoDatRanh = nuocMua.TKLD_KlCChoDatRanh ?? 0,
                                TKLD_KlCChoDaRanh = nuocMua.TKLD_KlCChoDaRanh ?? 0,
                                TKLD_TongKlCChoRanh = nuocMua.TKLD_TongKlCChoRanh ?? 0,
                                TKLD_KlCChoDatOngNhua = nuocMua.TKLD_KlCChoDatOngNhua ?? 0,
                                TKLD_KlCChoDaOngNhua = nuocMua.TKLD_KlCChoDaOngNhua ?? 0,
                                TKLD_TongKlCChoOngNhua = nuocMua.TKLD_TongKlCChoOngNhua ?? 0,
                                TKLD_KlCChoDat = nuocMua.TKLD_KlCChoDat ?? 0,
                                TKLD_KlCChoDa = nuocMua.TKLD_KlCChoDa ?? 0,
                                TKLD_TongChiemCho = nuocMua.TKLD_TongChiemCho ?? 0,
                                TKLD_KlDapTraDat = nuocMua.TKLD_KlDapTraDat ?? 0,
                                TKLD_KlDapTraDa = nuocMua.TKLD_KlDapTraDa ?? 0,
                                TKLD_TongKlDapTra = nuocMua.TKLD_TongKlDapTra ?? 0,
                                TKLD_KlThuaDat = nuocMua.TKLD_KlThuaDat ?? 0,
                                TKLD_KlThuaDa = nuocMua.TKLD_KlThuaDa ?? 0,
                                TKLD_TongKLThua = nuocMua.TKLD_TongKLThua ?? 0,
                                DTDC_TLCSauDap = nuocMua.DTDC_TLCSauDap ?? 0,
                                DTDC_TLCRongDapDayLon = nuocMua.DTDC_TLCRongDapDayLon ?? 0,
                                DTDC_TLDTichDap = nuocMua.DTDC_TLDTichDap ?? 0,
                                DTDC_HLCSauDap = nuocMua.DTDC_HLCSauDap ?? 0,
                                DTDC_HLCRongDapDayLon = nuocMua.DTDC_HLCRongDapDayLon ?? 0,
                                DTDC_HLDTichDap = nuocMua.DTDC_HLDTichDap ?? 0,
                                DTTB_CSDap = nuocMua.DTTB_CSDap ?? 0,
                                DTTB_CRDapDayLon = nuocMua.DTTB_CRDapDayLon ?? 0,
                                DTTB_DTichDap = nuocMua.DTTB_DTichDap ?? 0,
                                TTKLDC_KlDapCatTruocChiemCho = nuocMua.TTKLDC_KlDapCatTruocChiemCho ?? 0,
                                TTKLDC_KlChiemCho = nuocMua.TTKLDC_KlChiemCho ?? 0,
                                TTKLDC_KlDapCatSauChiemCho = nuocMua.TTKLDC_KlDapCatSauChiemCho ?? 0,
                                ToaDoX = nuocMua.ToaDoX ?? 0,
                                ToaDoY = nuocMua.ToaDoY ?? 0,
                                Flag = nuocMua.Flag,
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

        public async Task Update(NuocMua nuocMua)
        {
            using var context = _context.CreateDbContext();
            var entity = GetById(nuocMua.Id);

            if (entity == null)
            {
                throw new Exception($"Không tìm thấy bản ghi theo ID: {nuocMua.Id}");
            }

            context.DSNuocMua.Update(nuocMua);
            await context.SaveChangesAsync();
        }
        public async Task UpdateMulti(NuocMua[] nuocMua)
        {
            using var context = _context.CreateDbContext();
            string[] ids = nuocMua.Select(x => x.Id).ToArray();
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
            context.Set<NuocMua>().Remove(entity);
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
            var model = await context.DSNuocMua.FirstOrDefaultAsync(m => EF.Property<string>(m, field) == value);

            // Nếu tìm thấy bản ghi, trả về true
            if (model != null)
            {
                return true;
            }

            // Trả về false nếu không tìm thấy bản ghi
            return false;
        }


        public async Task<NuocMua> GetById(string id)
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

        public async Task Insert(NuocMua entity)
        {
            try
            {
                using var context = _context.CreateDbContext();
                if (entity == null)
                {
                    throw new Exception("Không có bản ghi nào để thêm!");
                }
                // Kiểm tra xem bảng có bản ghi nào không
                var maxFlag = await context.DSNuocMua.AnyAsync()
                              ? await context.DSNuocMua.MaxAsync(x => x.Flag)
                              : 0;

                // Tăng giá trị Flag lên 1
                entity.Flag = maxFlag + 1;
                context.DSNuocMua.Add(entity);
                await context.SaveChangesAsync();
               
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException?.Message ?? ex.Message);
                Console.WriteLine(ex.Message);
            }
        }

        public async Task<string> InsertLaterFlag(NuocMua entity, int FlagLast)
        {
            string id = "";
            try
            {
                using var context = _context.CreateDbContext();

                if (entity == null)
                {
                    throw new Exception("Không có bản ghi nào để thêm!");
                }
                var recordsToUpdate = await context.DSNuocMua
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
                    var maxFlag = await context.DSNuocMua.AnyAsync()
                                  ? await context.DSNuocMua.MaxAsync(x => x.Flag)
                                  : 0;

                    // Tăng giá trị Flag lên 1
                    entity.Flag = maxFlag + 1;
                }
                else
                {
                    entity.Flag = FlagLast + 1;
                }
                context.DSNuocMua.Add(entity);
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
        public async Task<int> MultiInsert(List<NuocMua> entities)
        {
            try
            {
                using var context = _context.CreateDbContext();

                if (entities == null || entities.Count == 0)
                {
                    throw new Exception("Không có bản ghi nào để thêm!");
                }

                // Kiểm tra xem bảng có bản ghi nào không
                var maxFlag = await context.DSNuocMua.AnyAsync()
                              ? await context.DSNuocMua.MaxAsync(x => x.Flag)
                              : 0;

                foreach (var entity in entities)
                {
                    // Tăng giá trị Flag lên 1
                    maxFlag += 1; 
                    entity.Flag = maxFlag ;
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
