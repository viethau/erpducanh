using DucAnhERP.Components.Pages.NghiepVuCongTrinh;
using DucAnhERP.Data;
using DucAnhERP.Models;
using DucAnhERP.Repository;
using DucAnhERP.ViewModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;

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
        public async Task<List<NuocMuaModel>> GetAllByVM(NuocMuaModel nuocMuaModel)
        {
            try
            {
                using var context = _context.CreateDbContext();

                //var query2 = (
                //                from ds in context.DSNuocMua
                //                join pl in context.PhanLoaiHoGas on ds.ThongTinChungHoGa_TenHoGaSauPhanLoai equals pl.Id
                //                select new
                //                {
                //                    ds.ThongTinChungHoGa_TenHoGaTheoBanVe,
                //                    pl.ThongTinChungHoGa_TenHoGaSauPhanLoai,
                //                    ds.CreateAt
                //                } into LOC
                //                select new
                //                {
                //                    LOC.ThongTinChungHoGa_TenHoGaTheoBanVe,
                //                    PhanLoaiHoGas_TenHoGaSauPhanLoai = LOC.ThongTinChungHoGa_TenHoGaTheoBanVe != null &&
                //                        LOC.ThongTinChungHoGa_TenHoGaTheoBanVe.EndsWith("=G")
                //                        ? (
                //                            (from dsSub in context.DSNuocMua
                //                             join plSub in context.PhanLoaiHoGas
                //                                 on dsSub.ThongTinChungHoGa_TenHoGaSauPhanLoai equals plSub.Id
                //                             where LOC.ThongTinChungHoGa_TenHoGaTheoBanVe.Replace("=G", "") == dsSub.ThongTinChungHoGa_TenHoGaTheoBanVe &&
                //                                   !dsSub.ThongTinChungHoGa_TenHoGaTheoBanVe.EndsWith("=G")
                //                             select plSub.ThongTinChungHoGa_TenHoGaSauPhanLoai)
                //                            .FirstOrDefault() ?? LOC.ThongTinChungHoGa_TenHoGaSauPhanLoai
                //                        ) + "=G"
                //                        : LOC.ThongTinChungHoGa_TenHoGaSauPhanLoai,
                //                    LOC.CreateAt
                //                }
                //            ).OrderBy(LOC => LOC.CreateAt).ToList();


                //Console.WriteLine("data");


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

                            //    // Join với các bảng danhmuc
                            //join hinhThucHoGa in context.DSDanhMuc
                            //    on nuocMua.ThongTinChungHoGa_HinhThucHoGa equals hinhThucHoGa.Id into gj4
                            //from hinhThucHoGa in gj4.DefaultIfEmpty() // Left join for HinhThucHoGa

                            //join ketCauMuMo in context.DSDanhMuc
                            //    on nuocMua.ThongTinChungHoGa_KetCauMuMo equals ketCauMuMo.Id into gj5
                            //from ketCauMuMo in gj5.DefaultIfEmpty() // Left join for KetCauMuMo

                            //join ketCauTuong in context.DSDanhMuc
                            //    on nuocMua.ThongTinChungHoGa_KetCauTuong equals ketCauTuong.Id into gj6
                            //from ketCauTuong in gj6.DefaultIfEmpty() // Left join for KetCauTuong

                            //join hinhThucMongHoGa in context.DSDanhMuc
                            //    on nuocMua.ThongTinChungHoGa_HinhThucMongHoGa equals hinhThucMongHoGa.Id into gj7
                            //from hinhThucMongHoGa in gj7.DefaultIfEmpty() // Left join for HinhThucMongHoGa

                            //join ketCauMong in context.DSDanhMuc
                            //    on nuocMua.ThongTinChungHoGa_KetCauMong equals ketCauMong.Id into gj8
                            //from ketCauMong in gj8.DefaultIfEmpty() // Left join for KetCauMong

                            //join chatMatTrong in context.DSDanhMuc
                            //    on nuocMua.ThongTinChungHoGa_ChatMatTrong equals chatMatTrong.Id into gj9
                            //from chatMatTrong in gj9.DefaultIfEmpty() // Left join for ChatMatTrong

                            //join chatMatNgoai in context.DSDanhMuc
                            //    on nuocMua.ThongTinChungHoGa_ChatMatNgoai equals chatMatNgoai.Id into gj10
                            //from chatMatNgoai in gj10.DefaultIfEmpty() // Left join for ChatMatNgoai

                            //join hinhThucDayHoGa2 in context.DSDanhMuc
                            //    on nuocMua.ThongTinTamDanHoGa2_HinhThucDayHoGa equals hinhThucDayHoGa2.Id into gj11
                            //from hinhThucDayHoGa2 in gj11.DefaultIfEmpty() // Left join for 

                            //join loaiVatLieuDao in context.DSDanhMuc
                            //    on nuocMua.ThongTinVatLieuDaoHoGa_LoaiVatLieuDao equals loaiVatLieuDao.Id into gj12
                            //from loaiVatLieuDao in gj12.DefaultIfEmpty() // Left join for 

                            //join hinhThucTruyenDan in context.DSDanhMuc
                            //   on nuocMua.ThongTinDuongTruyenDan_HinhThucTruyenDan equals hinhThucTruyenDan.Id into gj13
                            //from hinhThucTruyenDan in gj13.DefaultIfEmpty() // Left join for 

                            //join loaiTruyenDan in context.DSDanhMuc
                            //   on nuocMua.ThongTinDuongTruyenDan_LoaiTruyenDan equals loaiTruyenDan.Id into gj14
                            //from loaiTruyenDan in gj14.DefaultIfEmpty() // Left join for 

                            //join loaiMong in context.DSDanhMuc
                            //    on nuocMua.ThongTinMongDuongTruyenDan_LoaiMong equals loaiMong.Id into gj15
                            //from loaiMong in gj15.DefaultIfEmpty() // Left join for 

                            //join hinhThucMong in context.DSDanhMuc
                            //    on nuocMua.ThongTinMongDuongTruyenDan_HinhThucMong equals hinhThucMong.Id into gj16
                            //from hinhThucMong in gj16.DefaultIfEmpty() // Left join for 

                            //join cauTaoDeCong in context.DSDanhMuc
                            //    on nuocMua.ThongTinDeCong_CauTaoDeCong equals cauTaoDeCong.Id into gj17
                            //from cauTaoDeCong in gj17.DefaultIfEmpty() // Left join for

                            // join cauTaoTuong in context.DSDanhMuc
                            //    on nuocMua.TTKTHHCongHopRanh_CauTaoTuong equals cauTaoTuong.Id into gj18
                            //from cauTaoTuong in gj18.DefaultIfEmpty()

                            //join cauTaoMuMo in context.DSDanhMuc
                            //    on nuocMua.TTKTHHCongHopRanh_CauTaoMuMo equals cauTaoMuMo.Id into gj19
                            //from cauTaoMuMo in gj19.DefaultIfEmpty()

                            //join chatMatTrong_TTKTHH in context.DSDanhMuc
                            //    on nuocMua.TTKTHHCongHopRanh_ChatMatTrong equals chatMatTrong_TTKTHH.Id into gj20
                            //from chatMatTrong_TTKTHH in gj20.DefaultIfEmpty()

                            //join chatMatNgoai_TTKTHH in context.DSDanhMuc
                            //    on nuocMua.TTKTHHCongHopRanh_ChatMatNgoai equals chatMatNgoai_TTKTHH.Id into gj21
                            //from chatMatNgoai_TTKTHH in gj21.DefaultIfEmpty()

                            //join cauTaoThanhChong in context.DSDanhMuc
                            //     on nuocMua.TTKTHHCongHopRanh_CauTaoThanhChong equals cauTaoThanhChong.Id into gj22
                            //from cauTaoThanhChong in gj22.DefaultIfEmpty()

                            //join cauTaoTamDanTruyenDanTamDanTieuChuan in context.DSDanhMuc
                            //     on nuocMua.TTTDCongHoRanh_CauTaoTamDanTruyenDanTamDanTieuChuan equals cauTaoTamDanTruyenDanTamDanTieuChuan.Id into gj23
                            //from cauTaoTamDanTruyenDanTamDanTieuChuan in gj23.DefaultIfEmpty()

                            //join cauTaoTamDanTruyenDan in context.DSDanhMuc
                            //     on nuocMua.TTTDCongHoRanh_CauTaoTamDanTruyenDan equals cauTaoTamDanTruyenDan.Id into gj24
                            //from cauTaoTamDanTruyenDan in gj24.DefaultIfEmpty()

                            //join loaiVatLieuDao_TTVLD in context.DSDanhMuc
                            //     on nuocMua.TTVLDCongRanh_LoaiVatLieuDao equals loaiVatLieuDao_TTVLD.Id into gj25
                            //from loaiVatLieuDao_TTVLD in gj25.DefaultIfEmpty()

                            //join KLBoSung1 in context.DSDanhMuc
                            //   on nuocMua.HinhThucDauNoi1_KLBoSung equals KLBoSung1.Id into gj26
                            //from KLBoSung1 in gj26.DefaultIfEmpty() // Left join for HinhThucDauNoi1_KLBoSung

                            //join KLBoSung2 in context.DSDanhMuc
                            //  on nuocMua.HinhThucDauNoi1_KLBoSung equals KLBoSung2.Id into gj27
                            //from KLBoSung2 in gj27.DefaultIfEmpty() // Left join for HinhThucDauNoi2_KLBoSung

                            //join KLBoSung3 in context.DSDanhMuc
                            //  on nuocMua.HinhThucDauNoi1_KLBoSung equals KLBoSung3.Id into gj28
                            //from KLBoSung3 in gj28.DefaultIfEmpty() // Left join for HinhThucDauNoi2_KLBoSung

                            //join KLBoSung4 in context.DSDanhMuc
                            //  on nuocMua.HinhThucDauNoi1_KLBoSung equals KLBoSung4.Id into gj29
                            //from KLBoSung4 in gj29.DefaultIfEmpty() // Left join for HinhThucDauNoi4_KLBoSung

                            //join KLBoSung5 in context.DSDanhMuc
                            //  on nuocMua.HinhThucDauNoi1_KLBoSung equals KLBoSung5.Id into gj30
                            //from KLBoSung5 in gj30.DefaultIfEmpty() // Left join for HinhThucDauNoi5_KLBoSung

                            //join KLBoSung6 in context.DSDanhMuc
                            //  on nuocMua.HinhThucDauNoi1_KLBoSung equals KLBoSung6.Id into gj31
                            //from KLBoSung6 in gj31.DefaultIfEmpty() // Left join for HinhThucDauNoi6_KLBoSung

                            //join KLBoSung7 in context.DSDanhMuc
                            //  on nuocMua.HinhThucDauNoi1_KLBoSung equals KLBoSung7.Id into gj32
                            //from KLBoSung7 in gj32.DefaultIfEmpty() // Left join for HinhThucDauNoi7_KLBoSung

                            //join KLBoSung8 in context.DSDanhMuc
                            //  on nuocMua.HinhThucDauNoi1_KLBoSung equals KLBoSung8.Id into gj33
                            //from KLBoSung8 in gj33.DefaultIfEmpty() // Left join for HinhThucDauNoi8_KLBoSung

                                // Sắp xếp theo Flag của DSNuocMua
                            orderby nuocMua.Flag
                            select new NuocMuaModel
                            {
                                Id = nuocMua.Id,
                                ThongTinLyTrinh_TuyenDuong = nuocMua.ThongTinLyTrinh_TuyenDuong ?? "",
                                ThongTinLyTrinh_LyTrinhTaiTimHoGa = nuocMua.ThongTinLyTrinh_LyTrinhTaiTimHoGa ?? "",
                                ThongTinChungHoGa_TenHoGaSauPhanLoai = nuocMua.ThongTinChungHoGa_TenHoGaSauPhanLoai ?? "",
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
                                ThongTinChungHoGa_HinhThucHoGa = nuocMua.ThongTinChungHoGa_HinhThucHoGa ?? "",
                                ThongTinChungHoGa_HinhThucHoGa_Name = "",
                                ThongTinChungHoGa_KetCauMuMo = nuocMua.ThongTinChungHoGa_KetCauMuMo ?? "",
                                ThongTinChungHoGa_KetCauMuMo_Name = "",
                                ThongTinChungHoGa_KetCauTuong = nuocMua.ThongTinChungHoGa_KetCauTuong ?? "",
                                ThongTinChungHoGa_KetCauTuong_Name = "",
                                ThongTinChungHoGa_HinhThucMongHoGa = nuocMua.ThongTinChungHoGa_HinhThucMongHoGa ?? "",
                                ThongTinChungHoGa_HinhThucMongHoGa_Name = "",
                                ThongTinChungHoGa_KetCauMong = nuocMua.ThongTinChungHoGa_KetCauMong ?? "",
                                ThongTinChungHoGa_KetCauMong_Name = "",
                                ThongTinChungHoGa_ChatMatTrong = nuocMua.ThongTinChungHoGa_ChatMatTrong ?? "",
                                ThongTinChungHoGa_ChatMatTrong_Name = "",
                                ThongTinChungHoGa_ChatMatNgoai = nuocMua.ThongTinChungHoGa_ChatMatNgoai ?? "",
                                ThongTinChungHoGa_ChatMatNgoai_Name = "",
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
                                HinhThucDauNoi1_KLBoSung = nuocMua.HinhThucDauNoi1_KLBoSung ?? "",
                                HinhThucDauNoi1_KLBoSung_Name ="",
                                HinhThucDauNoi1_CanhDai = nuocMua.HinhThucDauNoi1_CanhDai ?? 0,
                                HinhThucDauNoi1_CDD = nuocMua.HinhThucDauNoi1_CDD ?? 0,
                                HinhThucDauNoi1_CDR = nuocMua.HinhThucDauNoi1_CDR ?? 0,
                                HinhThucDauNoi1_CDC = nuocMua.HinhThucDauNoi1_CDC ?? 0,
                                HinhThucDauNoi1_CanhRong = nuocMua.HinhThucDauNoi1_CanhRong ?? 0,
                                HinhThucDauNoi1_CRD = nuocMua.HinhThucDauNoi1_CRD ?? 0,
                                HinhThucDauNoi1_CRR = nuocMua.HinhThucDauNoi1_CRR ?? 0,
                                HinhThucDauNoi1_CRC = nuocMua.HinhThucDauNoi1_CRC ?? 0,
                                HinhThucDauNoi1_CanhCheo = nuocMua.HinhThucDauNoi1_CanhCheo ?? 0,
                                HinhThucDauNoi1_CCD = nuocMua.HinhThucDauNoi1_CCD ?? 0,
                                HinhThucDauNoi1_CCR = nuocMua.HinhThucDauNoi1_CCR ?? 0,
                                HinhThucDauNoi1_CCC = nuocMua.HinhThucDauNoi1_CCC ?? 0,
                                HinhThucDauNoi2_Loai = nuocMua.HinhThucDauNoi2_Loai ?? 0,
                                HinhThucDauNoi2_KLBoSung = nuocMua.HinhThucDauNoi2_KLBoSung ?? "",
                                HinhThucDauNoi2_KLBoSung_Name =  "",
                                HinhThucDauNoi2_CanhDai = nuocMua.HinhThucDauNoi2_CanhDai ?? 0,
                                HinhThucDauNoi2_CDD = nuocMua.HinhThucDauNoi2_CDD ?? 0,
                                HinhThucDauNoi2_CDR = nuocMua.HinhThucDauNoi2_CDR ?? 0,
                                HinhThucDauNoi2_CDC = nuocMua.HinhThucDauNoi2_CDC ?? 0,
                                HinhThucDauNoi2_CanhRong = nuocMua.HinhThucDauNoi2_CanhRong ?? 0,
                                HinhThucDauNoi2_CRD = nuocMua.HinhThucDauNoi2_CRD ?? 0,
                                HinhThucDauNoi2_CRR = nuocMua.HinhThucDauNoi2_CRR ?? 0,
                                HinhThucDauNoi2_CRC = nuocMua.HinhThucDauNoi2_CRC ?? 0,
                                HinhThucDauNoi2_CanhCheo = nuocMua.HinhThucDauNoi2_CanhCheo ?? 0,
                                HinhThucDauNoi2_CCD = nuocMua.HinhThucDauNoi2_CCD ?? 0,
                                HinhThucDauNoi2_CCR = nuocMua.HinhThucDauNoi2_CCR ?? 0,
                                HinhThucDauNoi2_CCC = nuocMua.HinhThucDauNoi2_CCC ?? 0,
                                HinhThucDauNoi3_Loai = nuocMua.HinhThucDauNoi3_Loai ?? 0,
                                HinhThucDauNoi3_KLBoSung = nuocMua.HinhThucDauNoi3_KLBoSung ?? "",
                                HinhThucDauNoi3_KLBoSung_Name =  "",
                                HinhThucDauNoi3_CanhDai = nuocMua.HinhThucDauNoi3_CanhDai ?? 0,
                                HinhThucDauNoi3_CDD = nuocMua.HinhThucDauNoi3_CDD ?? 0,
                                HinhThucDauNoi3_CDR = nuocMua.HinhThucDauNoi3_CDR ?? 0,
                                HinhThucDauNoi3_CDC = nuocMua.HinhThucDauNoi3_CDC ?? 0,
                                HinhThucDauNoi3_CanhRong = nuocMua.HinhThucDauNoi3_CanhRong ?? 0,
                                HinhThucDauNoi3_CRD = nuocMua.HinhThucDauNoi3_CRD ?? 0,
                                HinhThucDauNoi3_CRR = nuocMua.HinhThucDauNoi3_CRR ?? 0,
                                HinhThucDauNoi3_CRC = nuocMua.HinhThucDauNoi3_CRC ?? 0,
                                HinhThucDauNoi3_CanhCheo = nuocMua.HinhThucDauNoi3_CanhCheo ?? 0,
                                HinhThucDauNoi3_CCD = nuocMua.HinhThucDauNoi3_CCD ?? 0,
                                HinhThucDauNoi3_CCR = nuocMua.HinhThucDauNoi3_CCR ?? 0,
                                HinhThucDauNoi3_CCC = nuocMua.HinhThucDauNoi3_CCC ?? 0,
                                HinhThucDauNoi4_Loai = nuocMua.HinhThucDauNoi4_Loai ?? 0,
                                HinhThucDauNoi4_KLBoSung = nuocMua.HinhThucDauNoi4_KLBoSung ?? "",
                                HinhThucDauNoi4_KLBoSung_Name = "",
                                HinhThucDauNoi4_CanhDai = nuocMua.HinhThucDauNoi4_CanhDai ?? 0,
                                HinhThucDauNoi4_CDD = nuocMua.HinhThucDauNoi4_CDD ?? 0,
                                HinhThucDauNoi4_CDR = nuocMua.HinhThucDauNoi4_CDR ?? 0,
                                HinhThucDauNoi4_CDC = nuocMua.HinhThucDauNoi4_CDC ?? 0,
                                HinhThucDauNoi4_CanhRong = nuocMua.HinhThucDauNoi4_CanhRong ?? 0,
                                HinhThucDauNoi4_CRD = nuocMua.HinhThucDauNoi4_CRD ?? 0,
                                HinhThucDauNoi4_CRR = nuocMua.HinhThucDauNoi4_CRR ?? 0,
                                HinhThucDauNoi4_CRC = nuocMua.HinhThucDauNoi4_CRC ?? 0,
                                HinhThucDauNoi4_CanhCheo = nuocMua.HinhThucDauNoi4_CanhCheo ?? 0,
                                HinhThucDauNoi4_CCD = nuocMua.HinhThucDauNoi4_CCD ?? 0,
                                HinhThucDauNoi4_CCR = nuocMua.HinhThucDauNoi4_CCR ?? 0,
                                HinhThucDauNoi4_CCC = nuocMua.HinhThucDauNoi4_CCC ?? 0,
                                HinhThucDauNoi5_Loai = nuocMua.HinhThucDauNoi5_Loai ?? 0,
                                HinhThucDauNoi5_KLBoSung = nuocMua.HinhThucDauNoi5_KLBoSung ?? "",
                                HinhThucDauNoi5_KLBoSung_Name =  "",
                                HinhThucDauNoi5_CanhDai = nuocMua.HinhThucDauNoi5_CanhDai ?? 0,
                                HinhThucDauNoi5_CDD = nuocMua.HinhThucDauNoi5_CDD ?? 0,
                                HinhThucDauNoi5_CDR = nuocMua.HinhThucDauNoi5_CDR ?? 0,
                                HinhThucDauNoi5_CDC = nuocMua.HinhThucDauNoi5_CDC ?? 0,
                                HinhThucDauNoi5_CanhRong = nuocMua.HinhThucDauNoi5_CanhRong ?? 0,
                                HinhThucDauNoi5_CRD = nuocMua.HinhThucDauNoi5_CRD ?? 0,
                                HinhThucDauNoi5_CRR = nuocMua.HinhThucDauNoi5_CRR ?? 0,
                                HinhThucDauNoi5_CRC = nuocMua.HinhThucDauNoi5_CRC ?? 0,
                                HinhThucDauNoi5_CanhCheo = nuocMua.HinhThucDauNoi5_CanhCheo ?? 0,
                                HinhThucDauNoi5_CCD = nuocMua.HinhThucDauNoi5_CCD ?? 0,
                                HinhThucDauNoi5_CCR = nuocMua.HinhThucDauNoi5_CCR ?? 0,
                                HinhThucDauNoi5_CCC = nuocMua.HinhThucDauNoi5_CCC ?? 0,
                                HinhThucDauNoi6_Loai = nuocMua.HinhThucDauNoi6_Loai ?? 0,
                                HinhThucDauNoi6_KLBoSung = nuocMua.HinhThucDauNoi6_KLBoSung ?? "",
                                HinhThucDauNoi6_KLBoSung_Name = "",
                                HinhThucDauNoi6_CanhDai = nuocMua.HinhThucDauNoi6_CanhDai ?? 0,
                                HinhThucDauNoi6_CDD = nuocMua.HinhThucDauNoi6_CDD ?? 0,
                                HinhThucDauNoi6_CDR = nuocMua.HinhThucDauNoi6_CDR ?? 0,
                                HinhThucDauNoi6_CDC = nuocMua.HinhThucDauNoi6_CDC ?? 0,
                                HinhThucDauNoi6_CanhRong = nuocMua.HinhThucDauNoi6_CanhRong ?? 0,
                                HinhThucDauNoi6_CRD = nuocMua.HinhThucDauNoi6_CRD ?? 0,
                                HinhThucDauNoi6_CRR = nuocMua.HinhThucDauNoi6_CRR ?? 0,
                                HinhThucDauNoi6_CRC = nuocMua.HinhThucDauNoi6_CRC ?? 0,
                                HinhThucDauNoi6_CanhCheo = nuocMua.HinhThucDauNoi6_CanhCheo ?? 0,
                                HinhThucDauNoi6_CCD = nuocMua.HinhThucDauNoi6_CCD ?? 0,
                                HinhThucDauNoi6_CCR = nuocMua.HinhThucDauNoi6_CCR ?? 0,
                                HinhThucDauNoi6_CCC = nuocMua.HinhThucDauNoi6_CCC ?? 0,
                                HinhThucDauNoi7_Loai = nuocMua.HinhThucDauNoi7_Loai ?? 0,
                                HinhThucDauNoi7_KLBoSung = nuocMua.HinhThucDauNoi7_KLBoSung ?? "",
                                HinhThucDauNoi7_KLBoSung_Name = "",
                                HinhThucDauNoi7_CanhDai = nuocMua.HinhThucDauNoi7_CanhDai ?? 0,
                                HinhThucDauNoi7_CDD = nuocMua.HinhThucDauNoi7_CDD ?? 0,
                                HinhThucDauNoi7_CDR = nuocMua.HinhThucDauNoi7_CDR ?? 0,
                                HinhThucDauNoi7_CDC = nuocMua.HinhThucDauNoi7_CDC ?? 0,
                                HinhThucDauNoi7_CanhRong = nuocMua.HinhThucDauNoi7_CanhRong ?? 0,
                                HinhThucDauNoi7_CRD = nuocMua.HinhThucDauNoi7_CRD ?? 0,
                                HinhThucDauNoi7_CRR = nuocMua.HinhThucDauNoi7_CRR ?? 0,
                                HinhThucDauNoi7_CRC = nuocMua.HinhThucDauNoi7_CRC ?? 0,
                                HinhThucDauNoi7_CanhCheo = nuocMua.HinhThucDauNoi7_CanhCheo ?? 0,
                                HinhThucDauNoi7_CCD = nuocMua.HinhThucDauNoi7_CCD ?? 0,
                                HinhThucDauNoi7_CCR = nuocMua.HinhThucDauNoi7_CCR ?? 0,
                                HinhThucDauNoi7_CCC = nuocMua.HinhThucDauNoi7_CCC ?? 0,
                                HinhThucDauNoi8_Loai = nuocMua.HinhThucDauNoi8_Loai ?? 0,
                                HinhThucDauNoi8_KLBoSung = nuocMua.HinhThucDauNoi8_KLBoSung ?? "",
                                HinhThucDauNoi8_KLBoSung_Name =  "",
                                HinhThucDauNoi8_CanhDai = nuocMua.HinhThucDauNoi8_CanhDai ?? 0,
                                HinhThucDauNoi8_CDD = nuocMua.HinhThucDauNoi8_CDD ?? 0,
                                HinhThucDauNoi8_CDR = nuocMua.HinhThucDauNoi8_CDR ?? 0,
                                HinhThucDauNoi8_CDC = nuocMua.HinhThucDauNoi8_CDC ?? 0,
                                HinhThucDauNoi8_CanhRong = nuocMua.HinhThucDauNoi8_CanhRong ?? 0,
                                HinhThucDauNoi8_CRD = nuocMua.HinhThucDauNoi8_CRD ?? 0,
                                HinhThucDauNoi8_CRR = nuocMua.HinhThucDauNoi8_CRR ?? 0,
                                HinhThucDauNoi8_CRC = nuocMua.HinhThucDauNoi8_CRC ?? 0,
                                HinhThucDauNoi8_CanhCheo = nuocMua.HinhThucDauNoi8_CanhCheo ?? 0,
                                HinhThucDauNoi8_CCD = nuocMua.HinhThucDauNoi8_CCD ?? 0,
                                HinhThucDauNoi8_CCR = nuocMua.HinhThucDauNoi8_CCR ?? 0,
                                HinhThucDauNoi8_CCC = nuocMua.HinhThucDauNoi8_CCC ?? 0,

                                ThongTinTamDanHoGa2_PhanLoaiDayHoGa = nuocMua.ThongTinTamDanHoGa2_PhanLoaiDayHoGa ?? "",
                                PhanLoaiTDHoGa_PhanLoaiDayHoGa = phanLoaiTDHoGa.ThongTinTamDanHoGa2_PhanLoaiDayHoGa??"",
                                ThongTinTamDanHoGa2_HinhThucDayHoGa = nuocMua.ThongTinTamDanHoGa2_HinhThucDayHoGa ?? "",
                                ThongTinTamDanHoGa2_HinhThucDayHoGa_Name = "",
                                ThongTinTamDanHoGa2_DuongKinh = nuocMua.ThongTinTamDanHoGa2_DuongKinh ?? 0,
                                ThongTinTamDanHoGa2_ChieuDay = nuocMua.ThongTinTamDanHoGa2_ChieuDay ?? 0,
                                ThongTinTamDanHoGa2_D = nuocMua.ThongTinTamDanHoGa2_D ?? 0,
                                ThongTinTamDanHoGa2_R = nuocMua.ThongTinTamDanHoGa2_R ?? 0,
                                ThongTinTamDanHoGa2_C = nuocMua.ThongTinTamDanHoGa2_C ?? 0,
                                ThongTinTamDanHoGa2_SoLuongNapDay = nuocMua.ThongTinTamDanHoGa2_SoLuongNapDay ?? 0,
                                ThongTinVatLieuDaoHoGa_LoaiVatLieuDao = nuocMua.ThongTinVatLieuDaoHoGa_LoaiVatLieuDao ?? "",
                                ThongTinVatLieuDaoHoGa_LoaiVatLieuDao_Name = "",
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
                                ThongTinDuongTruyenDan_HinhThucTruyenDan_Name = "",
                                ThongTinDuongTruyenDan_LoaiTruyenDan = nuocMua.ThongTinDuongTruyenDan_LoaiTruyenDan ?? "",
                                ThongTinDuongTruyenDan_LoaiTruyenDan_Name = "",
                                ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai = nuocMua.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai ?? "",
                                PhanLoaiCTronHopNhua_TenLoaiTruyenDanSauPhanLoai = PhanLoaiCTronHopNhua.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai ?? "",

                                TTCDSLCauKienDuongTruyenDan_TongChieuDai = nuocMua.TTCDSLCauKienDuongTruyenDan_TongChieuDai ?? 0,
                                TTCDSLCauKienDuongTruyenDan_ChieuDai01CauKien = nuocMua.TTCDSLCauKienDuongTruyenDan_ChieuDai01CauKien ?? 0,
                                TTCDSLCauKienDuongTruyenDan_SlCauKienTinhKl = nuocMua.TTCDSLCauKienDuongTruyenDan_SlCauKienTinhKl ?? 0,

                                ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop = nuocMua.ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop ?? "",
                                PhanLoaiMongCTron_PhanLoaiMongCongTronCongHop = PhanLoaiMongCTron.ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop ?? "",
                                ThongTinMongDuongTruyenDan_LoaiMong = nuocMua.ThongTinMongDuongTruyenDan_LoaiMong ?? "",
                                ThongTinMongDuongTruyenDan_LoaiMong_Name = "",
                                ThongTinMongDuongTruyenDan_HinhThucMong = nuocMua.ThongTinMongDuongTruyenDan_HinhThucMong ?? "",
                                ThongTinMongDuongTruyenDan_HinhThucMong_Name = "",
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
                                TTKTHHCongHopRanh_CauTaoTuong_Name = "",
                                TTKTHHCongHopRanh_CauTaoMuMo = nuocMua.TTKTHHCongHopRanh_CauTaoMuMo ?? "",
                                TTKTHHCongHopRanh_CauTaoMuMo_Name = "",
                                TTKTHHCongHopRanh_ChatMatTrong = nuocMua.TTKTHHCongHopRanh_ChatMatTrong ?? "",
                                TTKTHHCongHopRanh_ChatMatTrong_Name = "",
                                TTKTHHCongHopRanh_ChatMatNgoai = nuocMua.TTKTHHCongHopRanh_ChatMatNgoai ?? "",
                                TTKTHHCongHopRanh_ChatMatNgoai_Name = "",
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
                                TTKTHHCongHopRanh_CauTaoThanhChong_Name = "",
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
                                TTTDCongHoRanh_CauTaoTamDanTruyenDanTamDanTieuChuan_Name = "",
                                TTTDCongHoRanh_SoLuong = nuocMua.TTTDCongHoRanh_SoLuong ?? 0,
                                TTTDCongHoRanh_CDai = nuocMua.TTTDCongHoRanh_CDai ?? 0,
                                TTTDCongHoRanh_CRong = nuocMua.TTTDCongHoRanh_CRong ?? 0,
                                TTTDCongHoRanh_CCao = nuocMua.TTTDCongHoRanh_CCao ?? 0,
                                TTTDCongHoRanh_TenLoaiTamDanLoai02 = nuocMua.TTTDCongHoRanh_TenLoaiTamDanLoai02 ?? "",
                                PhanLoaiTDanTDan_TenLoaiTamDanLoai02 = PhanLoaiTDanTDan02.TTTDCongHoRanh_TenLoaiTamDanTieuChuan??"",
                                TTTDCongHoRanh_CauTaoTamDanTruyenDan = nuocMua.TTTDCongHoRanh_CauTaoTamDanTruyenDan ?? "",
                                TTTDCongHoRanh_CauTaoTamDanTruyenDan_Name = "",
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
                                TTVLDCongRanh_LoaiVatLieuDao_Name = "",
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
                                TraiPhai = nuocMua.TraiPhai,
                            };
                if( nuocMuaModel.TraiPhai < 2)
                {
                    query = query.Where(x=>x.TraiPhai == nuocMuaModel.TraiPhai);
                }
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
                    //var maxFlag = await context.DSNuocMua.AnyAsync()
                    //              ? await context.DSNuocMua.MaxAsync(x => x.Flag)
                    //              : 0;
                    var maxFlag = await context.DSNuocMua.AnyAsync(x => x.TraiPhai == entity.TraiPhai)
                              ? await context.DSNuocMua.Where(x => x.TraiPhai == entity.TraiPhai).MaxAsync(x => x.Flag)
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
                var maxFlag = await context.DSNuocMua.AnyAsync(x => x.TraiPhai == entities[0].TraiPhai)
                               ? await context.DSNuocMua.Where(x => x.TraiPhai == entities[0].TraiPhai).MaxAsync(x => x.Flag)
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

        //Lấy tất cả tuyến đường 
        public async Task<List<NuocMuaModel>> GetDSTuyenDuong()
        {
            try
            {
                using var context = _context.CreateDbContext();
                var data = await context.DSNuocMua
                    .Where(ds => !string.IsNullOrEmpty(ds.ThongTinLyTrinh_TuyenDuong))
                    .Select(ds => ds.ThongTinLyTrinh_TuyenDuong)
                    .Distinct()
                    .OrderBy(tuyenDuong => tuyenDuong)
                    .Select(tuyenDuong => new NuocMuaModel
                    {
                        ThongTinLyTrinh_TuyenDuong = tuyenDuong ??""
                    })
                    .ToListAsync();

                return data;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi dữ liệu {ex.Message}!");
            }
        }


        //báo cáo 
        public async Task<List<NuocMuaModel>> GetBaoCaoTTHoGa(NuocMuaModel nuocMuaModel)
        {
            try
            {
                using var context = _context.CreateDbContext();
                var query = from nuocMua in context.DSNuocMua
                                // Left join với bảng PhanLoaiHoGas
                            join phanLoaiHoGa in context.PhanLoaiHoGas
                            on nuocMua.ThongTinChungHoGa_TenHoGaSauPhanLoai equals phanLoaiHoGa.Id into phanLoaiHoGaJoin
                            from phanLoaiHoGa in phanLoaiHoGaJoin.DefaultIfEmpty()

                            join phanLoaiTDHoGa in context.PhanLoaiTDHoGas
                           on nuocMua.ThongTinTamDanHoGa2_PhanLoaiDayHoGa equals phanLoaiTDHoGa.Id into phanLoaiTDHoGaJoin
                            from phanLoaiTDHoGa in phanLoaiTDHoGaJoin.DefaultIfEmpty()

                            join hinhThucTruyenDan in context.DSDanhMuc
                               on nuocMua.ThongTinDuongTruyenDan_HinhThucTruyenDan equals hinhThucTruyenDan.Id into gj13
                            from hinhThucTruyenDan in gj13.DefaultIfEmpty()

                            join loaiTruyenDan in context.DSDanhMuc
                               on nuocMua.ThongTinDuongTruyenDan_LoaiTruyenDan equals loaiTruyenDan.Id into gj14
                            from loaiTruyenDan in gj14.DefaultIfEmpty() 

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
                                ThongTinTamDanHoGa2_PhanLoaiDayHoGa = nuocMua.ThongTinTamDanHoGa2_PhanLoaiDayHoGa ?? "",
                                PhanLoaiTDHoGa_PhanLoaiDayHoGa = phanLoaiTDHoGa.ThongTinTamDanHoGa2_PhanLoaiDayHoGa ?? "",
                                ThongTinTamDanHoGa2_SoLuongNapDay = nuocMua.ThongTinTamDanHoGa2_SoLuongNapDay ?? 0,

                                ThongTinDuongTruyenDan_HinhThucTruyenDan = nuocMua.ThongTinDuongTruyenDan_HinhThucTruyenDan ?? "",
                                ThongTinDuongTruyenDan_HinhThucTruyenDan_Name = hinhThucTruyenDan.Ten,
                                ThongTinDuongTruyenDan_LoaiTruyenDan = nuocMua.ThongTinDuongTruyenDan_LoaiTruyenDan ?? "",
                                ThongTinDuongTruyenDan_LoaiTruyenDan_Name = loaiTruyenDan.Ten,

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

                                ToaDoX = nuocMua.ToaDoX ?? 0,
                                ToaDoY = nuocMua.ToaDoY ?? 0,
                                Flag = nuocMua.Flag,
                                TraiPhai = nuocMua.TraiPhai,
                            };

                if (!string.IsNullOrEmpty(nuocMuaModel.ThongTinChungHoGa_TenHoGaSauPhanLoai))
                {
                    query = query.Where(x => x.ThongTinChungHoGa_TenHoGaSauPhanLoai == nuocMuaModel.ThongTinChungHoGa_TenHoGaSauPhanLoai);
                }
                if (!string.IsNullOrEmpty(nuocMuaModel.ThongTinTamDanHoGa2_PhanLoaiDayHoGa))
                {
                    query = query.Where(x => x.ThongTinTamDanHoGa2_PhanLoaiDayHoGa == nuocMuaModel.ThongTinTamDanHoGa2_PhanLoaiDayHoGa);
                }
                if (!string.IsNullOrEmpty(nuocMuaModel.ThongTinDuongTruyenDan_HinhThucTruyenDan))
                {
                    query = query.Where(x => x.ThongTinDuongTruyenDan_HinhThucTruyenDan == nuocMuaModel.ThongTinDuongTruyenDan_HinhThucTruyenDan);
                }
                if (nuocMuaModel.TraiPhai != 2)
                {
                    query = query.Where(x => x.TraiPhai.Equals(nuocMuaModel.TraiPhai));
                }
                var data = await query.ToListAsync();
                return data;
            }
            catch (Exception ex)
            {
               
                throw new Exception ($"Lỗi dữ liệu {ex.Message}!");
            }
        }
        public async Task<List<NuocMuaModel>> GetBaoCaoKLBPhapHGa(NuocMuaModel nuocMuaModel)
        {
            try
            {
                using var context = _context.CreateDbContext();
                var query = from nuocMua in context.DSNuocMua
                                // Left join với bảng PhanLoaiHoGas
                            join phanLoaiHoGa in context.PhanLoaiHoGas
                            on nuocMua.ThongTinChungHoGa_TenHoGaSauPhanLoai equals phanLoaiHoGa.Id into phanLoaiHoGaJoin
                            from phanLoaiHoGa in phanLoaiHoGaJoin.DefaultIfEmpty()

                            join phanLoaiTDHoGa in context.PhanLoaiTDHoGas
                           on nuocMua.ThongTinTamDanHoGa2_PhanLoaiDayHoGa equals phanLoaiTDHoGa.Id into phanLoaiTDHoGaJoin
                            from phanLoaiTDHoGa in phanLoaiTDHoGaJoin.DefaultIfEmpty()

                            join loaiVatLieuDao in context.DSDanhMuc
                               on nuocMua.ThongTinVatLieuDaoHoGa_LoaiVatLieuDao equals loaiVatLieuDao.Id into gj3
                            from loaiVatLieuDao in gj3.DefaultIfEmpty()

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
                                ThongTinTamDanHoGa2_PhanLoaiDayHoGa = nuocMua.ThongTinTamDanHoGa2_PhanLoaiDayHoGa ?? "",
                                PhanLoaiTDHoGa_PhanLoaiDayHoGa = phanLoaiTDHoGa.ThongTinTamDanHoGa2_PhanLoaiDayHoGa ?? "",

                                ThongTinVatLieuDaoHoGa_LoaiVatLieuDao = nuocMua.ThongTinVatLieuDaoHoGa_LoaiVatLieuDao ?? "",
                                ThongTinVatLieuDaoHoGa_LoaiVatLieuDao_Name = loaiVatLieuDao.Ten ?? "",
                                ThongTinVatLieuDaoHoGa_ChieuCaoDaoDa = nuocMua.ThongTinVatLieuDaoHoGa_ChieuCaoDaoDa ?? 0,
                                ThongTinVatLieuDaoHoGa_ChieuCaoDaoDat = nuocMua.ThongTinVatLieuDaoHoGa_ChieuCaoDaoDat ?? 0,
                                ThongTinMaiDao_ChieuRongDayDaoNho = nuocMua.ThongTinMaiDao_ChieuRongDayDaoNho ?? 0,
                                ThongTinMaiDao_TyLeMoMai = nuocMua.ThongTinMaiDao_TyLeMoMai ?? 0,
                                ThongTinMaiDao_SoCanhMaiTrai = nuocMua.ThongTinMaiDao_SoCanhMaiTrai ?? 0,
                                ThongTinMaiDao_SoCanhMaiPhai = nuocMua.ThongTinMaiDao_SoCanhMaiPhai ?? 0,
                                TTKLD_CRongDaoDayLonDat = nuocMua.TTKLD_CRongDaoDayLonDat ?? 0,
                                TTKLD_CRongDaoDayLonDa = nuocMua.TTKLD_CRongDaoDayLonDa ?? 0,
                                TTKLD_DienTichDaoDat = nuocMua.TTKLD_DienTichDaoDat ?? 0,
                                TTKLD_DienTichDaoDa = nuocMua.TTKLD_DienTichDaoDa ?? 0,
                                TTKLD_KlDaoDat = nuocMua.TTKLD_KlDaoDat ?? 0,
                                TTKLD_KlDaoDa = nuocMua.TTKLD_KlDaoDa ?? 0,
                                TTKLD_TongKlDao = nuocMua.TTKLD_TongKlDao ?? 0,
                                TTKLD_KlChiemChoDat = nuocMua.TTKLD_KlChiemChoDat ?? 0,
                                TTKLD_KlChiemChoDa = nuocMua.TTKLD_KlChiemChoDa ?? 0,
                                TTKLD_TongChiemCho = nuocMua.TTKLD_TongChiemCho ?? 0,
                                TTKLD_KlDapTraDat = nuocMua.TTKLD_KlDapTraDat ?? 0,
                                TTKLD_KlDapTraDa = nuocMua.TTKLD_KlDapTraDa ?? 0,
                                TTKLD_TongDapTra = nuocMua.TTKLD_TongDapTra ?? 0,



                                ToaDoX = nuocMua.ToaDoX ?? 0,
                                ToaDoY = nuocMua.ToaDoY ?? 0,
                                Flag = nuocMua.Flag,
                                TraiPhai = nuocMua.TraiPhai,
                            };

                if (!string.IsNullOrEmpty(nuocMuaModel.ThongTinChungHoGa_TenHoGaSauPhanLoai))
                {
                    query = query.Where(x => x.ThongTinChungHoGa_TenHoGaSauPhanLoai == nuocMuaModel.ThongTinChungHoGa_TenHoGaSauPhanLoai);
                }
                if (!string.IsNullOrEmpty(nuocMuaModel.ThongTinTamDanHoGa2_PhanLoaiDayHoGa))
                {
                    query = query.Where(x => x.ThongTinTamDanHoGa2_PhanLoaiDayHoGa == nuocMuaModel.ThongTinTamDanHoGa2_PhanLoaiDayHoGa);
                }
                if (!string.IsNullOrEmpty(nuocMuaModel.ThongTinVatLieuDaoHoGa_LoaiVatLieuDao))
                {
                    query = query.Where(x => x.ThongTinVatLieuDaoHoGa_LoaiVatLieuDao == nuocMuaModel.ThongTinVatLieuDaoHoGa_LoaiVatLieuDao);
                }
                if (nuocMuaModel.TraiPhai != 2)
                {
                    query = query.Where(x => x.TraiPhai.Equals(nuocMuaModel.TraiPhai));
                }
                var data = await query.ToListAsync();
                return data;
            }
            catch (Exception ex)
            {

                throw new Exception($"Lỗi dữ liệu {ex.Message}!");
            }
        }
        public async Task<List<NuocMuaModel>> GetBaoCaoKHopHGaTDan(NuocMuaModel nuocMuaModel)
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

                            orderby nuocMua.Flag
                            select new NuocMuaModel
                            {
                                Id = nuocMua.Id,
                                ThongTinLyTrinh_TuyenDuong = nuocMua.ThongTinLyTrinh_TuyenDuong ?? "",
                                ThongTinLyTrinh_LyTrinhTaiTimHoGa = nuocMua.ThongTinLyTrinh_LyTrinhTaiTimHoGa ?? "",
                                ThongTinChungHoGa_TenHoGaSauPhanLoai = nuocMua.ThongTinChungHoGa_TenHoGaSauPhanLoai ?? "",
                                PhanLoaiHoGas_TenHoGaSauPhanLoai = phanLoaiHoGa != null ? phanLoaiHoGa.ThongTinChungHoGa_TenHoGaSauPhanLoai : "",

                                ThongTinTamDanHoGa2_PhanLoaiDayHoGa = nuocMua.ThongTinTamDanHoGa2_PhanLoaiDayHoGa ?? "",
                                PhanLoaiTDHoGa_PhanLoaiDayHoGa = phanLoaiTDHoGa.ThongTinTamDanHoGa2_PhanLoaiDayHoGa ?? "",
                               
                                ThongTinTamDanHoGa2_DuongKinh = nuocMua.ThongTinTamDanHoGa2_DuongKinh ?? 0,
                                ThongTinTamDanHoGa2_ChieuDay = nuocMua.ThongTinTamDanHoGa2_ChieuDay ?? 0,

                                ThongTinTamDanHoGa2_D = nuocMua.ThongTinTamDanHoGa2_D ?? 0,
                                ThongTinTamDanHoGa2_R = nuocMua.ThongTinTamDanHoGa2_R ?? 0,
                                ThongTinTamDanHoGa2_C = nuocMua.ThongTinTamDanHoGa2_C ?? 0,
                                ThongTinTamDanHoGa2_SoLuongNapDay = nuocMua.ThongTinTamDanHoGa2_SoLuongNapDay ?? 0,

                                ToaDoX = nuocMua.ToaDoX ?? 0,
                                ToaDoY = nuocMua.ToaDoY ?? 0,
                                Flag = nuocMua.Flag,
                                TraiPhai = nuocMua.TraiPhai,
                            };

                if (!string.IsNullOrEmpty(nuocMuaModel.ThongTinTamDanHoGa2_PhanLoaiDayHoGa))
                {
                    query = query.Where(x => x.ThongTinTamDanHoGa2_PhanLoaiDayHoGa == nuocMuaModel.ThongTinTamDanHoGa2_PhanLoaiDayHoGa);
                }
                if (nuocMuaModel.TraiPhai != 2)
                {
                    query = query.Where(x => x.TraiPhai.Equals(nuocMuaModel.TraiPhai));
                }
                var data = await query.ToListAsync();
                return data;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
        public async Task<List<PLHGBaoCaoModel>> GetBaoCaoTongSLHGa()
        {
            try
            {
                using var context = _context.CreateDbContext();
                var query = from d in context.DSNuocMua
                            join p in context.PhanLoaiHoGas
                            on d.ThongTinChungHoGa_TenHoGaSauPhanLoai equals p.Id
                            group d by new { p.Id, p.ThongTinChungHoGa_TenHoGaSauPhanLoai } into grouped
                            select new PLHGBaoCaoModel
                            {
                                Id = grouped.Key.Id,
                                ThongTinChungHoGa_TenHoGaSauPhanLoai = grouped.Key.ThongTinChungHoGa_TenHoGaSauPhanLoai,
                                countTrai = grouped.Sum(x => x.TraiPhai == 0 ? 1 : 0),
                                countPhai = grouped.Sum(x => x.TraiPhai == 1 ? 1 : 0),
                                Tong = grouped.Sum(x => (x.TraiPhai == 0 ? 1 : 0)) + grouped.Sum(x => (x.TraiPhai == 1 ? 1 : 0))
                            };

                var data = await query.ToListAsync();
                return data;
            }
            catch(Exception ex)
            {
                throw new Exception("Lỗi tải dữ liệu :"+ex.Message); 
            }
        }
        public async Task<List<PLHGBaoCaoSLHGTTModel>> GetBaoCaoTongSLHGaTTuyen()
        {
            try
            {
                using var context = _context.CreateDbContext();
                var query = from n in context.DSNuocMua
                            join p in context.PhanLoaiHoGas
                            on n.ThongTinChungHoGa_TenHoGaSauPhanLoai equals p.Id
                            group n by new { n.ThongTinLyTrinh_TuyenDuong, p.ThongTinChungHoGa_TenHoGaSauPhanLoai, p.Id } into grouped
                            orderby grouped.Key.ThongTinLyTrinh_TuyenDuong
                            select new PLHGBaoCaoSLHGTTModel
                            {
                                Id = grouped.Key.Id,
                                ThongTinLyTrinh_TuyenDuong = grouped.Key.ThongTinLyTrinh_TuyenDuong,
                                ThongTinChungHoGa_TenHoGaSauPhanLoai = grouped.Key.ThongTinChungHoGa_TenHoGaSauPhanLoai,
                                countTrai = grouped.Sum(x => x.TraiPhai == 0 ? 1 : 0),
                                countPhai = grouped.Sum(x => x.TraiPhai == 1 ? 1 : 0),
                                Tong = grouped.Sum(x => x.TraiPhai == 0 ? 1 : 0) + grouped.Sum(x => x.TraiPhai == 1 ? 1 : 0)
                            };


                var data = await query.ToListAsync();
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi tải dữ liệu :" + ex.Message);
            }
        }
        public async Task<List<PLTDHGBaoCaoTSLTDHGModel>> GetBaoCaoTongSLTDanHGa()
        {
            try
            {
                using var context = _context.CreateDbContext();
                var query = from pl in context.PhanLoaiTDHoGas
                            join n in context.DSNuocMua
                                on pl.Id equals n.ThongTinTamDanHoGa2_PhanLoaiDayHoGa
                            group n by new
                            {
                                pl.Id,
                                pl.ThongTinTamDanHoGa2_PhanLoaiDayHoGa,
                                pl.ThongTinTamDanHoGa2_DuongKinh,
                                pl.ThongTinTamDanHoGa2_ChieuDay,
                                pl.ThongTinTamDanHoGa2_D,
                                pl.ThongTinTamDanHoGa2_R,
                                pl.ThongTinTamDanHoGa2_C
                            } into g
                            select new PLTDHGBaoCaoTSLTDHGModel
                            {
                                Id= g.Key.Id,
                                ThongTinTamDanHoGa2_PhanLoaiDayHoGa = g.Key.ThongTinTamDanHoGa2_PhanLoaiDayHoGa,
                                ThongTinTamDanHoGa2_DuongKinh = g.Key.ThongTinTamDanHoGa2_DuongKinh??0,
                                ThongTinTamDanHoGa2_ChieuDay = g.Key.ThongTinTamDanHoGa2_ChieuDay ?? 0,
                                ThongTinTamDanHoGa2_D = g.Key.ThongTinTamDanHoGa2_D ?? 0,
                                ThongTinTamDanHoGa2_R = g.Key.ThongTinTamDanHoGa2_R ?? 0,
                                ThongTinTamDanHoGa2_C = g.Key.ThongTinTamDanHoGa2_C ??0,
                                countTrai = (int)g.Sum(n => n.TraiPhai == 0 ? (n.ThongTinTamDanHoGa2_SoLuongNapDay ?? 0) : 0),
                                countPhai = (int)g.Sum(n => n.TraiPhai == 1 ? (n.ThongTinTamDanHoGa2_SoLuongNapDay ?? 0) : 0),
                                Tong = (int)g.Sum(n => (n.TraiPhai == 0 ? (n.ThongTinTamDanHoGa2_SoLuongNapDay ?? 0) : 0) +
                                                  (n.TraiPhai == 1 ? (n.ThongTinTamDanHoGa2_SoLuongNapDay ?? 0) : 0))
                            };

                var result = query.ToList();


                var data = await query.ToListAsync();
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi tải dữ liệu :" + ex.Message);
            }
        }
        public async Task<List<PLTDHGBaoCaoTSLTDHGTTModel>> GetBaoCaoSLTDanHGaTTuyen()
        {
            try
            {
                using var context = _context.CreateDbContext();
                var query = from pl in context.PhanLoaiTDHoGas
                            join n in context.DSNuocMua
                                on pl.Id equals n.ThongTinTamDanHoGa2_PhanLoaiDayHoGa
                            group n by new
                            {
                                pl.Id,
                                pl.ThongTinTamDanHoGa2_PhanLoaiDayHoGa,
                                pl.ThongTinTamDanHoGa2_DuongKinh,
                                pl.ThongTinTamDanHoGa2_ChieuDay,
                                pl.ThongTinTamDanHoGa2_D,
                                pl.ThongTinTamDanHoGa2_R,
                                pl.ThongTinTamDanHoGa2_C,
                                n.ThongTinLyTrinh_TuyenDuong
                            } into g
                            select new PLTDHGBaoCaoTSLTDHGTTModel
                            {
                                Id = g.Key.Id,
                                ThongTinLyTrinh_TuyenDuong = g.Key.ThongTinLyTrinh_TuyenDuong,
                                ThongTinTamDanHoGa2_PhanLoaiDayHoGa = g.Key.ThongTinTamDanHoGa2_PhanLoaiDayHoGa,
                                ThongTinTamDanHoGa2_DuongKinh = g.Key.ThongTinTamDanHoGa2_DuongKinh ?? 0,
                                ThongTinTamDanHoGa2_ChieuDay = g.Key.ThongTinTamDanHoGa2_ChieuDay ?? 0,
                                ThongTinTamDanHoGa2_D = g.Key.ThongTinTamDanHoGa2_D ?? 0,
                                ThongTinTamDanHoGa2_R = g.Key.ThongTinTamDanHoGa2_R ?? 0,
                                ThongTinTamDanHoGa2_C = g.Key.ThongTinTamDanHoGa2_C ?? 0,
                                countTrai = (int)g.Sum(n => n.TraiPhai == 0 ? (n.ThongTinTamDanHoGa2_SoLuongNapDay ?? 0) : 0),
                                countPhai = (int)g.Sum(n => n.TraiPhai == 1 ? (n.ThongTinTamDanHoGa2_SoLuongNapDay ?? 0) : 0),
                                Tong = (int)g.Sum(n => (n.TraiPhai == 0 ? (n.ThongTinTamDanHoGa2_SoLuongNapDay ?? 0) : 0) +
                                                  (n.TraiPhai == 1 ? (n.ThongTinTamDanHoGa2_SoLuongNapDay ?? 0) : 0))
                            };

                var result = query
                .OrderBy(g => g.ThongTinLyTrinh_TuyenDuong)
                .ToList();

                var data = await query.ToListAsync();
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi tải dữ liệu :" + ex.Message);
            }
        }
        public async Task<List<KTHHMDCModel>> GetBaoCaoKTHHMDC()
        {
            try
            {
                List<KTHHMDCModel> result = new();
                List<NuocMuaModel> data1 = new();
                List<NuocMuaModel> data2 = new();
                List<NuocMuaModel> data3 = new();
                List<NuocMuaModel> data4 = new();
                int count = 0;
                using var context = _context.CreateDbContext();
                data1 = (from a in context.DSNuocMua
                        join b in context.DSDanhMuc on a.ThongTinDuongTruyenDan_HinhThucTruyenDan equals b.Id
                        where b.Ten == "Cống tròn" && !string.IsNullOrEmpty(a.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai)
                        join d in context.PhanLoaiCTronHopNhuas on a.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai equals d.Id into dGroup
                        from d in dGroup.DefaultIfEmpty()
                        group new
                        {
                            TenDanhMuc = b.Ten, // Tên khác cho thuộc tính
                            TenLoaiTruyenDanSauPhanLoai = a.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai,
                            ChieuDaiCauKien = a.TTCDSLCauKienDuongTruyenDan_ChieuDai01CauKien,
                            CDayPhuBi = a.ThongTinCauTaoCongTron_CDayPhuBi,
                            LongSuDung = a.ThongTinCauTaoCongTron_LongSuDung,
                            TenLoaiTruyenDanSau = (d != null) ? d.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai : null
                        } by new
                        {
                            DanhMucTen = b.Ten, // Đặt tên khác cho thuộc tính trong group
                            LoaiTruyenDan = a.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai,
                            ChieuDai = a.TTCDSLCauKienDuongTruyenDan_ChieuDai01CauKien,
                            PhuBi = a.ThongTinCauTaoCongTron_CDayPhuBi,
                            SuDung = a.ThongTinCauTaoCongTron_LongSuDung,
                            TenLoaiTruyenDan = (d != null) ? d.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai : null
                        } into g
                        orderby g.Key.TenLoaiTruyenDan // Sử dụng tên duy nhất ở đây
                         select new NuocMuaModel
                        {
                            PhanLoaiCTronHopNhua_TenLoaiTruyenDanSauPhanLoai = g.Key.TenLoaiTruyenDan ?? "",
                            TTCDSLCauKienDuongTruyenDan_ChieuDai01CauKien = g.Key.ChieuDai ?? 0,
                            ThongTinCauTaoCongTron_CDayPhuBi = g.Key.PhuBi ?? 0,
                            ThongTinCauTaoCongTron_LongSuDung = g.Key.SuDung ?? 0,
                            ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai = g.Key.LoaiTruyenDan ?? ""// Đặt tên duy nhất cho thuộc tính
                        }).Distinct().ToList();
                count = data1.Count > count ? data1.Count : count;

                data2 = (from a in context.DSNuocMua
                         join b in context.DSDanhMuc on a.ThongTinDuongTruyenDan_HinhThucTruyenDan equals b.Id
                         join d in context.PhanLoaiMongCTrons on a.ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop equals d.Id into dGroup
                         from d in dGroup.DefaultIfEmpty()
                         where b.Ten == "Cống tròn" && !string.IsNullOrEmpty(a.ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop)
                         group new
                         {
                             PhanLoaiMongCongTronCongHop = (d != null) ? d.ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop : null,
                             IdPhanLoai = a.ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop,
                             CCaoLotMong = a.ThongTinCauTaoCongTron_CCaoLotMong,
                             CRongLotMong = a.ThongTinCauTaoCongTron_CRongLotMong,
                             CCaoMong = a.ThongTinCauTaoCongTron_CCaoMong,
                             CRongMong = a.ThongTinCauTaoCongTron_CRongMong
                         } by new
                         {
                             PhanLoaiMongCongTronCongHop = (d != null) ? d.ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop : null,
                             IdPhanLoai = a.ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop,
                             CCaoLotMong = a.ThongTinCauTaoCongTron_CCaoLotMong,
                             CRongLotMong = a.ThongTinCauTaoCongTron_CRongLotMong,
                             CCaoMong = a.ThongTinCauTaoCongTron_CCaoMong,
                             CRongMong = a.ThongTinCauTaoCongTron_CRongMong
                         } into g
                         orderby g.Key.PhanLoaiMongCongTronCongHop // Nếu cần thay đổi hoặc xác nhận
                         select new NuocMuaModel
                         {
                             ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop = g.Key.IdPhanLoai,
                             PhanLoaiMongCTron_PhanLoaiMongCongTronCongHop = g.Key.PhanLoaiMongCongTronCongHop,
                             ThongTinCauTaoCongTron_CCaoLotMong = g.Key.CCaoLotMong ?? 0,
                             ThongTinCauTaoCongTron_CRongLotMong = g.Key.CCaoLotMong ?? 0,
                             ThongTinCauTaoCongTron_CCaoMong = g.Key.CCaoMong ?? 0,
                             ThongTinCauTaoCongTron_CRongMong = g.Key.CRongMong ?? 0
                         }).Distinct().ToList();
                count = data2.Count > count ? data2.Count : count;
                data3 = (from a in context.DSNuocMua
                         join b in context.DSDanhMuc on a.ThongTinDuongTruyenDan_HinhThucTruyenDan equals b.Id
                         join d in context.PhanLoaiMongCTrons on a.ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop equals d.Id into dGroup
                         from d in dGroup.DefaultIfEmpty()
                         where b.Ten == "Cống hộp" && !string.IsNullOrEmpty(a.ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop)
                         group new
                         {
                             PhanLoaiMongCongTronCongHop = (d != null) ? d.ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop : null,
                             IdPhanLoai = a.ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop,
                             CCaoLotMong = a.TTKTHHCongHopRanh_CCaoLotMong,
                             CRongLotMong = a.TTKTHHCongHopRanh_CRongLotMong,
                             CCaoMong = a.TTKTHHCongHopRanh_CCaoMong,
                             CRongMong = a.TTKTHHCongHopRanh_CRongMong
                         } by new
                         {
                             PhanLoaiMongCongTronCongHop = (d != null) ? d.ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop : null,
                             IdPhanLoai = a.ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop,
                             CCaoLotMong = a.TTKTHHCongHopRanh_CCaoLotMong,
                             CRongLotMong = a.TTKTHHCongHopRanh_CRongLotMong,
                             CCaoMong = a.TTKTHHCongHopRanh_CCaoMong,
                             CRongMong = a.TTKTHHCongHopRanh_CRongMong
                         } into g
                         orderby g.Key.PhanLoaiMongCongTronCongHop // Nếu cần thay đổi hoặc xác nhận
                         select new NuocMuaModel
                         {
                             ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop = g.Key.IdPhanLoai ,
                             PhanLoaiMongCTron_PhanLoaiMongCongTronCongHop = g.Key.PhanLoaiMongCongTronCongHop,
                             ThongTinCauTaoCongTron_CCaoLotMong = g.Key.CCaoLotMong ?? 0,
                             ThongTinCauTaoCongTron_CRongLotMong = g.Key.CCaoLotMong ?? 0,
                             ThongTinCauTaoCongTron_CCaoMong = g.Key.CCaoMong ?? 0,
                             ThongTinCauTaoCongTron_CRongMong = g.Key.CRongMong ?? 0
                         }).Distinct().ToList();
                count = data3.Count > count ? data3.Count : count;

                data4 = (from a in context.DSNuocMua
                         join d in context.PhanLoaiDeCongs on a.ThongTinDeCong_TenLoaiDeCong equals d.Id into dGroup
                         from d in dGroup.DefaultIfEmpty()
                         where a.ThongTinDeCong_TenLoaiDeCong != ""
                         group new
                         {
                             TenLoaiDeCong = d.ThongTinDeCong_TenLoaiDeCong,
                             a.ThongTinDeCong_TenLoaiDeCong,
                             a.ThongTinDeCong_D,
                             a.ThongTinDeCong_R,
                             a.ThongTinDeCong_C
                         } by new
                         {
                             a.ThongTinDeCong_TenLoaiDeCong,
                             a.ThongTinDeCong_D,
                             a.ThongTinDeCong_R,
                             a.ThongTinDeCong_C,
                             TenLoaiDeCong = d.ThongTinDeCong_TenLoaiDeCong
                         } into g
                         orderby g.Key.TenLoaiDeCong
                         select new NuocMuaModel
                         {
                            ThongTinDeCong_TenLoaiDeCong = g.Key.ThongTinDeCong_TenLoaiDeCong,
                             ThongTinDeCong_D = g.Key.ThongTinDeCong_D ??0,
                             ThongTinDeCong_R =  g.Key.ThongTinDeCong_R ?? 0,
                             ThongTinDeCong_C = g.Key.ThongTinDeCong_C ?? 0,
                             PhanLoaiDeCong_TenLoaiDeCong = g.Key.TenLoaiDeCong
                         }).Distinct().ToList();
                count = data4.Count > count ? data4.Count : count;
                if(count> 0)
                {
                    for (int i = 0; i < count; i++)
                    {
                        KTHHMDCModel item = new KTHHMDCModel();

                        if (data1.Count > i) // Kiểm tra nếu i nhỏ hơn data1.Count
                        {
                            item.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai = data1[i].ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai;
                            item.PhanLoaiCTronHopNhua_TenLoaiTruyenDanSauPhanLoai = data1[i].PhanLoaiCTronHopNhua_TenLoaiTruyenDanSauPhanLoai;
                            item.TTCDSLCauKienDuongTruyenDan_ChieuDai01CauKien = data1[i].TTCDSLCauKienDuongTruyenDan_ChieuDai01CauKien;
                            item.ThongTinCauTaoCongTron_CDayPhuBi = data1[i].ThongTinCauTaoCongTron_CDayPhuBi;
                            item.ThongTinCauTaoCongTron_LongSuDung = data1[i].ThongTinCauTaoCongTron_LongSuDung;
                        }

                        if (data2.Count > i) // Kiểm tra nếu i nhỏ hơn data2.Count
                        {
                            item.ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop = data2[i].ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop;
                            item.PhanLoaiMongCTron_PhanLoaiMongCongTronCongHop = data2[i].PhanLoaiMongCTron_PhanLoaiMongCongTronCongHop;
                            item.ThongTinCauTaoCongTron_CCaoLotMong = data2[i].ThongTinCauTaoCongTron_CCaoLotMong;
                            item.ThongTinCauTaoCongTron_CRongLotMong = data2[i].ThongTinCauTaoCongTron_CRongLotMong;
                            item.ThongTinCauTaoCongTron_CCaoMong = data2[i].ThongTinCauTaoCongTron_CCaoMong;
                            item.ThongTinCauTaoCongTron_CRongMong = data2[i].ThongTinCauTaoCongTron_CRongMong;
                        }

                        if (data3.Count > i) // Kiểm tra nếu i nhỏ hơn data2.Count
                        {
                            item.ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop1 = data3[i].ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop;
                            item.PhanLoaiMongCTron_PhanLoaiMongCongTronCongHop1 = data3[i].PhanLoaiMongCTron_PhanLoaiMongCongTronCongHop;
                            item.TTKTHHCongHopRanh_CCaoLotMong = data3[i].ThongTinCauTaoCongTron_CCaoLotMong;
                            item.TTKTHHCongHopRanh_CRongLotMong = data3[i].ThongTinCauTaoCongTron_CRongLotMong;
                            item.TTKTHHCongHopRanh_CCaoMong = data3[i].ThongTinCauTaoCongTron_CCaoMong;
                            item.TTKTHHCongHopRanh_CRongMong = data3[i].ThongTinCauTaoCongTron_CRongMong;
                        }

                        if (data4.Count > i) // Kiểm tra nếu i nhỏ hơn data2.Count
                        {
                            item.ThongTinDeCong_TenLoaiDeCong = data4[i].ThongTinDeCong_TenLoaiDeCong;
                            item.PhanLoaiDeCong_TenLoaiDeCong = data4[i].PhanLoaiDeCong_TenLoaiDeCong;
                            item.ThongTinDeCong_D = data4[i].ThongTinDeCong_D;
                            item.ThongTinDeCong_R = data4[i].ThongTinDeCong_R;
                            item.ThongTinDeCong_C = data4[i].ThongTinDeCong_C;
                        }
                        result.Add(item);
                    }

                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi tải dữ liệu :" + ex.Message);
            }
        }
        public async Task<List<NuocMuaModel>> GetBaoCaoKTHHONhua()
        {
            List<NuocMuaModel> result = new();
            using var context = _context.CreateDbContext();
            result = (from a in context.DSNuocMua
                         join b in context.PhanLoaiCTronHopNhuas on a.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai equals b.Id into bGroup
                         from b in bGroup.DefaultIfEmpty()
                         join c in context.DSDanhMuc on a.ThongTinDuongTruyenDan_HinhThucTruyenDan equals c.Id into cGroup
                         from c in cGroup.DefaultIfEmpty()
                         where c.Ten == "Ống nhựa"
                         select new NuocMuaModel
                         {
                             ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai = a.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai??"",
                             PhanLoaiCTronHopNhua_TenLoaiTruyenDanSauPhanLoai =  b.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai ?? "",
                             ThongTinKichThuocHinhHocOngNhua_CDayPhuBi = a.ThongTinKichThuocHinhHocOngNhua_CDayPhuBi??0,
                             ThongTinKichThuocHinhHocOngNhua_LongSuDung = a.ThongTinKichThuocHinhHocOngNhua_LongSuDung ?? 0
                         }).Distinct().ToList();

            return result;
        }
        public async Task<List<NuocMuaModel>> GetBaoCaoKTHHCHop()
        {
            List<NuocMuaModel> result = new();
            using var context = _context.CreateDbContext();
            result = (from a in context.DSNuocMua
                                   join c in context.DSDanhMuc on a.ThongTinDuongTruyenDan_HinhThucTruyenDan equals c.Id
                                  join f in context.PhanLoaiCTronHopNhuas on a.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai equals f.Id into fGroup
                                  from f in fGroup.DefaultIfEmpty()
                                  join d in context.DSDanhMuc on a.TTKTHHCongHopRanh_CauTaoTuong equals d.Id into dGroup
                                   from d in dGroup.DefaultIfEmpty()
                                   join e in context.DSDanhMuc on a.TTKTHHCongHopRanh_CauTaoMuMo equals e.Id into eGroup
                                   from e in eGroup.DefaultIfEmpty()
                                   where c.Ten == "Cống hộp"
                                   select new NuocMuaModel
                                   {
                                      
                                       ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai = a.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai ??"",
                                       PhanLoaiCTronHopNhua_TenLoaiTruyenDanSauPhanLoai = f.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai,
                                       TTCDSLCauKienDuongTruyenDan_ChieuDai01CauKien = a.TTCDSLCauKienDuongTruyenDan_ChieuDai01CauKien ?? 0,
                                       TTKTHHCongHopRanh_CauTaoTuong_Name = d.Ten,
                                       TTKTHHCongHopRanh_CauTaoMuMo_Name = e.Ten,
                                       TTKTHHCongHopRanh_CCaoDe = a.TTKTHHCongHopRanh_CCaoDe ??0,
                                       TTKTHHCongHopRanh_CRongDe = a.TTKTHHCongHopRanh_CRongDe ?? 0,
                                       TTKTHHCongHopRanh_CDayTuong01Ben = a.TTKTHHCongHopRanh_CDayTuong01Ben ?? 0,
                                       TTKTHHCongHopRanh_SoLuongTuong = a.TTKTHHCongHopRanh_SoLuongTuong ?? 0,
                                       TTKTHHCongHopRanh_CRongLongSuDung = a.TTKTHHCongHopRanh_CRongLongSuDung ?? 0,
                                       TTKTHHCongHopRanh_CCaoTuongGop = a.TTKTHHCongHopRanh_CCaoTuongGop ?? 0,
                                       TTKTHHCongHopRanh_CCaoMuMoThotDuoi = a.TTKTHHCongHopRanh_CCaoMuMoThotDuoi ?? 0,
                                       TTKTHHCongHopRanh_CRongMuMoDuoi = a.TTKTHHCongHopRanh_CRongMuMoDuoi ?? 0,
                                       TTKTHHCongHopRanh_CCaoMuMoThotTren = a.TTKTHHCongHopRanh_CCaoMuMoThotTren ?? 0,
                                       TTKTHHCongHopRanh_CRongMuMoTren = a.TTKTHHCongHopRanh_CRongMuMoTren ?? 0
                                   }).Distinct().ToList();

            return result;
        }
        public async Task<List<NuocMuaModel>> GetBaoCaoKTHHTDCH()
        {
            List<NuocMuaModel> result = new();
            using var context = _context.CreateDbContext();
            var result1 = ( from a in context.DSNuocMua
                                   join c in context.DSDanhMuc on a.ThongTinDuongTruyenDan_HinhThucTruyenDan equals c.Id
                                   join f in context.PhanLoaiTDanTDans on a.TTTDCongHoRanh_TenLoaiTamDanTieuChuan equals f.Id
                                   where c.Ten == "Cống hộp" && a.TTTDCongHoRanh_SoLuong > 0
                                   select new NuocMuaModel
                                   {
                                       PhanLoaiTDanTDan_TenLoaiTamDanTieuChuan = f.TTTDCongHoRanh_TenLoaiTamDanTieuChuan ??"",
                                       TTTDCongHoRanh_TenLoaiTamDanTieuChuan = a.TTTDCongHoRanh_TenLoaiTamDanTieuChuan,
                                       TTTDCongHoRanh_CDai = f.TTTDCongHoRanh_CDai ??0,
                                       TTTDCongHoRanh_CRong = f.TTTDCongHoRanh_CRong ??0,
                                       TTTDCongHoRanh_CCao = f.TTTDCongHoRanh_CCao ??0
                                   }).Distinct().ToList();
            var result2 = (from a in context.DSNuocMua
                           join c in context.DSDanhMuc on a.ThongTinDuongTruyenDan_HinhThucTruyenDan equals c.Id
                           join f in context.PhanLoaiTDanTDans on a.TTTDCongHoRanh_TenLoaiTamDanLoai02 equals f.Id
                           where c.Ten == "Cống hộp" && a.TTTDCongHoRanh_SoLuong > 0
                           select new NuocMuaModel
                           {
                               PhanLoaiTDanTDan_TenLoaiTamDanTieuChuan = f.TTTDCongHoRanh_TenLoaiTamDanTieuChuan ?? "",
                               TTTDCongHoRanh_TenLoaiTamDanTieuChuan = a.TTTDCongHoRanh_TenLoaiTamDanLoai02,
                               TTTDCongHoRanh_CDai = f.TTTDCongHoRanh_CDai ?? 0,
                               TTTDCongHoRanh_CRong = f.TTTDCongHoRanh_CRong ?? 0,
                               TTTDCongHoRanh_CCao = f.TTTDCongHoRanh_CCao ?? 0
                           }).Distinct().ToList();
            result = result1.Concat(result2).Distinct().ToList();

            return result;
        }
        public async Task<List<NuocMuaModel>> GetBaoCaoKTHHRX()
        {
            try
            {
                List<NuocMuaModel> result = new();
                using var context = _context.CreateDbContext();

                 result = (from a in context.DSNuocMua
                              join b in context.DSDanhMuc on a.ThongTinDuongTruyenDan_HinhThucTruyenDan equals b.Id
                              join d in context.PhanLoaiCTronHopNhuas on a.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai equals d.Id into dGroup
                              from d in dGroup.DefaultIfEmpty()
                              where b.Ten == "Rãnh xây"
                                    && !string.IsNullOrEmpty(a.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai)
                              group new
                              {
                                  TenLoaiTruyenDanSauPhanLoai = d.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai,
                                  a.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai,
                                  a.TTKTHHCongHopRanh_CauTaoTuong,
                                  a.TTKTHHCongHopRanh_CauTaoMuMo,
                                  a.TTKTHHCongHopRanh_ChatMatTrong,
                                  a.TTKTHHCongHopRanh_ChatMatNgoai,
                                  a.TTKTHHCongHopRanh_CCaoLotMong,
                                  a.TTKTHHCongHopRanh_CRongLotMong,
                                  a.TTKTHHCongHopRanh_CCaoMong,
                                  a.TTKTHHCongHopRanh_CRongMong,
                                  a.TTKTHHCongHopRanh_CDayTuong01Ben,
                                  a.TTKTHHCongHopRanh_SoLuongTuong,
                                  a.TTKTHHCongHopRanh_CRongLongSuDung,
                                  a.TTKTHHCongHopRanh_CCaoTuongGop,
                                  a.TTKTHHCongHopRanh_CCaoMuMoThotDuoi,
                                  a.TTKTHHCongHopRanh_CRongMuMoDuoi,
                                  a.TTKTHHCongHopRanh_CCaoMuMoThotTren,
                                  a.TTKTHHCongHopRanh_CRongMuMoTren,
                                  a.TTKTHHCongHopRanh_CCaoChatMatTrong,
                                  a.TTKTHHCongHopRanh_CCaoChatmatNgoai,
                                  a.ThongTinMongDuongTruyenDan_LoaiMong,
                                  a.ThongTinMongDuongTruyenDan_HinhThucMong
                              } by new
                              {
                                  TenLoaiTruyenDanSauPhanLoai = d.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai,
                                  a.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai,
                                  a.TTKTHHCongHopRanh_CauTaoTuong,
                                  a.TTKTHHCongHopRanh_CauTaoMuMo,
                                  a.TTKTHHCongHopRanh_ChatMatTrong,
                                  a.TTKTHHCongHopRanh_ChatMatNgoai,
                                  a.TTKTHHCongHopRanh_CCaoLotMong,
                                  a.TTKTHHCongHopRanh_CRongLotMong,
                                  a.TTKTHHCongHopRanh_CCaoMong,
                                  a.TTKTHHCongHopRanh_CRongMong,
                                  a.TTKTHHCongHopRanh_CDayTuong01Ben,
                                  a.TTKTHHCongHopRanh_SoLuongTuong,
                                  a.TTKTHHCongHopRanh_CRongLongSuDung,
                                  a.TTKTHHCongHopRanh_CCaoTuongGop,
                                  a.TTKTHHCongHopRanh_CCaoMuMoThotDuoi,
                                  a.TTKTHHCongHopRanh_CRongMuMoDuoi,
                                  a.TTKTHHCongHopRanh_CCaoMuMoThotTren,
                                  a.TTKTHHCongHopRanh_CRongMuMoTren,
                                  a.TTKTHHCongHopRanh_CCaoChatMatTrong,
                                  a.TTKTHHCongHopRanh_CCaoChatmatNgoai,
                                  a.ThongTinMongDuongTruyenDan_LoaiMong,
                                  a.ThongTinMongDuongTruyenDan_HinhThucMong
                              } into g
                              orderby g.Key.TenLoaiTruyenDanSauPhanLoai
                           select new NuocMuaModel
                              {
                                    PhanLoaiCTronHopNhua_TenLoaiTruyenDanSauPhanLoai =  g.Key.TenLoaiTruyenDanSauPhanLoai,
                                    ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai = g.Key.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai,
                                    TTKTHHCongHopRanh_CauTaoTuong= g.Key.TTKTHHCongHopRanh_CauTaoTuong ,
                                    TTKTHHCongHopRanh_CauTaoMuMo= g.Key.TTKTHHCongHopRanh_CauTaoMuMo ,
                                    TTKTHHCongHopRanh_ChatMatTrong= g.Key.TTKTHHCongHopRanh_ChatMatTrong ,
                                    TTKTHHCongHopRanh_ChatMatNgoai= g.Key.TTKTHHCongHopRanh_ChatMatNgoai ,
                                    TTKTHHCongHopRanh_CCaoLotMong= g.Key.TTKTHHCongHopRanh_CCaoLotMong??0 ,
                                    TTKTHHCongHopRanh_CRongLotMong= g.Key.TTKTHHCongHopRanh_CRongLotMong??0 ,
                                    TTKTHHCongHopRanh_CCaoMong= g.Key.TTKTHHCongHopRanh_CCaoMong??0 ,
                                    TTKTHHCongHopRanh_CRongMong= g.Key.TTKTHHCongHopRanh_CRongMong??0 ,
                                    TTKTHHCongHopRanh_CDayTuong01Ben= g.Key.TTKTHHCongHopRanh_CDayTuong01Ben??0 ,
                                    TTKTHHCongHopRanh_SoLuongTuong= g.Key.TTKTHHCongHopRanh_SoLuongTuong??0 ,
                                    TTKTHHCongHopRanh_CRongLongSuDung= g.Key.TTKTHHCongHopRanh_CRongLongSuDung??0 ,
                                    TTKTHHCongHopRanh_CCaoTuongGop= g.Key.TTKTHHCongHopRanh_CCaoTuongGop??0 ,
                                    TTKTHHCongHopRanh_CCaoMuMoThotDuoi= g.Key.TTKTHHCongHopRanh_CCaoMuMoThotDuoi??0 ,
                                    TTKTHHCongHopRanh_CRongMuMoDuoi= g.Key.TTKTHHCongHopRanh_CRongMuMoDuoi??0 ,
                                    TTKTHHCongHopRanh_CCaoMuMoThotTren= g.Key.TTKTHHCongHopRanh_CCaoMuMoThotTren??0 ,
                                    TTKTHHCongHopRanh_CRongMuMoTren= g.Key.TTKTHHCongHopRanh_CRongMuMoTren??0 ,
                                    TTKTHHCongHopRanh_CCaoChatMatTrong= g.Key.TTKTHHCongHopRanh_CCaoChatMatTrong??0 ,
                                    TTKTHHCongHopRanh_CCaoChatmatNgoai  = g.Key.TTKTHHCongHopRanh_CCaoChatmatNgoai  ??0 ,
                                    ThongTinMongDuongTruyenDan_LoaiMong = g.Key.ThongTinMongDuongTruyenDan_LoaiMong,
                                    ThongTinMongDuongTruyenDan_HinhThucMong = g.Key.ThongTinMongDuongTruyenDan_HinhThucMong
                              }).Distinct().ToList();


                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi tải dữ liệu :" + ex.Message);
            }
        }
        public async Task<List<NuocMuaModel>> GetBaoCaoKTHHTC()
        {
            try
            {
                using var context = _context.CreateDbContext();
                var result = (from a in context.DSNuocMua
                              join b in context.PhanLoaiThanhChongs
                              on a.TTKTHHCongHopRanh_LoaiThanhChong equals b.Id
                              where a.TTKTHHCongHopRanh_CCaoThanhChong > 0
                              select new NuocMuaModel
                              {
                                  TTKTHHCongHopRanh_LoaiThanhChong = a.TTKTHHCongHopRanh_LoaiThanhChong,
                                  PhanLoaiThanhChong_LoaiThanhChong = b.TTKTHHCongHopRanh_LoaiThanhChong??"",
                                  TTKTHHCongHopRanh_CCaoThanhChong = a.TTKTHHCongHopRanh_CCaoThanhChong ?? 0,
                                  TTKTHHCongHopRanh_CRongThanhChong = a.TTKTHHCongHopRanh_CRongThanhChong ?? 0,
                                  TTKTHHCongHopRanh_CDai = a.TTKTHHCongHopRanh_CDai ?? 0
                              }).Distinct().ToList();
                return result;

            }
            catch (Exception)
            {

                throw new Exception("Lỗi khi tải dữ liệu");
            }
        }
        public async Task<List<NuocMuaModel>> GetBaoCaoKTHHTDRX()
        {
            try
            {
                using var context = _context.CreateDbContext();
                List<NuocMuaModel> result = new List<NuocMuaModel>();
            
                 var result1 = (from a in context.DSNuocMua
                              join b in context.PhanLoaiTDanTDans
                              on a.TTTDCongHoRanh_TenLoaiTamDanTieuChuan equals b.Id
                              join c in context.DSDanhMuc
                              on a.ThongTinDuongTruyenDan_HinhThucTruyenDan equals c.Id
                              where c.Ten == "Rãnh xây" && a.TTTDCongHoRanh_SoLuong > 0
                              select new NuocMuaModel
                              {
                                  TTTDCongHoRanh_TenLoaiTamDanTieuChuan = a.TTTDCongHoRanh_TenLoaiTamDanTieuChuan,
                                  PhanLoaiTDanTDan_TenLoaiTamDanTieuChuan = b.TTTDCongHoRanh_TenLoaiTamDanTieuChuan??"",
                                  TTTDCongHoRanh_CDai = a.TTTDCongHoRanh_CDai ?? 0,
                                  TTTDCongHoRanh_CRong = a.TTTDCongHoRanh_CRong ?? 0,
                                  TTTDCongHoRanh_CCao = a.TTTDCongHoRanh_CCao ?? 0
                              });
                var result2 = (from a in context.DSNuocMua
                              join b in context.PhanLoaiTDanTDans
                              on a.TTTDCongHoRanh_TenLoaiTamDanLoai02 equals b.Id
                              join c in context.DSDanhMuc
                              on a.ThongTinDuongTruyenDan_HinhThucTruyenDan equals c.Id
                              where c.Ten == "Rãnh xây" && a.TTTDCongHoRanh_SoLuong1 > 0
                              select new NuocMuaModel
                              {
                                  TTTDCongHoRanh_TenLoaiTamDanTieuChuan = a.TTTDCongHoRanh_TenLoaiTamDanLoai02,
                                  PhanLoaiTDanTDan_TenLoaiTamDanTieuChuan = b.TTTDCongHoRanh_TenLoaiTamDanTieuChuan ?? "",
                                  TTTDCongHoRanh_CDai = a.TTTDCongHoRanh_CDai1 ?? 0,
                                  TTTDCongHoRanh_CRong = a.TTTDCongHoRanh_CRong1 ?? 0,
                                  TTTDCongHoRanh_CCao = a.TTTDCongHoRanh_CCao1 ?? 0
                              });

                result = result1.Concat(result2).Distinct().OrderBy(x => x.PhanLoaiTDanTDan_TenLoaiTamDanTieuChuan).ToList();

                return result;
            }
            catch (Exception)
            {

                throw new Exception("Lỗi khi tải dữ liệu");
            }
        }
        public async Task<List<NuocMuaModel>> GetBaoCaoKTHHRBT()
        {
            try
            {
                List<NuocMuaModel> result = new();
                using var context = _context.CreateDbContext();

                result = (from a in context.DSNuocMua
                          join b in context.DSDanhMuc on a.ThongTinDuongTruyenDan_HinhThucTruyenDan equals b.Id
                          join d in context.PhanLoaiCTronHopNhuas on a.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai equals d.Id into dGroup
                          from d in dGroup.DefaultIfEmpty()
                          where b.Ten == "Rãnh bê tông"
                                && !string.IsNullOrEmpty(a.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai)
                          group new
                          {
                              TenLoaiTruyenDanSauPhanLoai = d.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai,
                              a.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai,
                              a.TTKTHHCongHopRanh_CauTaoTuong,
                              a.TTKTHHCongHopRanh_CauTaoMuMo,
                              a.TTKTHHCongHopRanh_ChatMatTrong,
                              a.TTKTHHCongHopRanh_ChatMatNgoai,
                              a.TTKTHHCongHopRanh_CCaoLotMong,
                              a.TTKTHHCongHopRanh_CRongLotMong,
                              a.TTKTHHCongHopRanh_CCaoMong,
                              a.TTKTHHCongHopRanh_CRongMong,
                              a.TTKTHHCongHopRanh_CDayTuong01Ben,
                              a.TTKTHHCongHopRanh_SoLuongTuong,
                              a.TTKTHHCongHopRanh_CRongLongSuDung,
                              a.TTKTHHCongHopRanh_CCaoTuongGop,
                              a.TTKTHHCongHopRanh_CCaoMuMoThotDuoi,
                              a.TTKTHHCongHopRanh_CRongMuMoDuoi,
                              a.TTKTHHCongHopRanh_CCaoMuMoThotTren,
                              a.TTKTHHCongHopRanh_CRongMuMoTren,
                              a.TTKTHHCongHopRanh_CCaoChatMatTrong,
                              a.TTKTHHCongHopRanh_CCaoChatmatNgoai,
                              a.ThongTinMongDuongTruyenDan_LoaiMong,
                              a.ThongTinMongDuongTruyenDan_HinhThucMong
                          } by new
                          {
                              TenLoaiTruyenDanSauPhanLoai = d.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai,
                              a.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai,
                              a.TTKTHHCongHopRanh_CauTaoTuong,
                              a.TTKTHHCongHopRanh_CauTaoMuMo,
                              a.TTKTHHCongHopRanh_ChatMatTrong,
                              a.TTKTHHCongHopRanh_ChatMatNgoai,
                              a.TTKTHHCongHopRanh_CCaoLotMong,
                              a.TTKTHHCongHopRanh_CRongLotMong,
                              a.TTKTHHCongHopRanh_CCaoMong,
                              a.TTKTHHCongHopRanh_CRongMong,
                              a.TTKTHHCongHopRanh_CDayTuong01Ben,
                              a.TTKTHHCongHopRanh_SoLuongTuong,
                              a.TTKTHHCongHopRanh_CRongLongSuDung,
                              a.TTKTHHCongHopRanh_CCaoTuongGop,
                              a.TTKTHHCongHopRanh_CCaoMuMoThotDuoi,
                              a.TTKTHHCongHopRanh_CRongMuMoDuoi,
                              a.TTKTHHCongHopRanh_CCaoMuMoThotTren,
                              a.TTKTHHCongHopRanh_CRongMuMoTren,
                              a.TTKTHHCongHopRanh_CCaoChatMatTrong,
                              a.TTKTHHCongHopRanh_CCaoChatmatNgoai,
                              a.ThongTinMongDuongTruyenDan_LoaiMong,
                              a.ThongTinMongDuongTruyenDan_HinhThucMong
                          } into g
                          orderby g.Key.TenLoaiTruyenDanSauPhanLoai
                          select new NuocMuaModel
                          {
                              PhanLoaiCTronHopNhua_TenLoaiTruyenDanSauPhanLoai = g.Key.TenLoaiTruyenDanSauPhanLoai,
                              ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai = g.Key.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai,
                              TTKTHHCongHopRanh_CauTaoTuong = g.Key.TTKTHHCongHopRanh_CauTaoTuong,
                              TTKTHHCongHopRanh_CauTaoMuMo = g.Key.TTKTHHCongHopRanh_CauTaoMuMo,
                              TTKTHHCongHopRanh_ChatMatTrong = g.Key.TTKTHHCongHopRanh_ChatMatTrong,
                              TTKTHHCongHopRanh_ChatMatNgoai = g.Key.TTKTHHCongHopRanh_ChatMatNgoai,
                              TTKTHHCongHopRanh_CCaoLotMong = g.Key.TTKTHHCongHopRanh_CCaoLotMong ?? 0,
                              TTKTHHCongHopRanh_CRongLotMong = g.Key.TTKTHHCongHopRanh_CRongLotMong ?? 0,
                              TTKTHHCongHopRanh_CCaoMong = g.Key.TTKTHHCongHopRanh_CCaoMong ?? 0,
                              TTKTHHCongHopRanh_CRongMong = g.Key.TTKTHHCongHopRanh_CRongMong ?? 0,
                              TTKTHHCongHopRanh_CDayTuong01Ben = g.Key.TTKTHHCongHopRanh_CDayTuong01Ben ?? 0,
                              TTKTHHCongHopRanh_SoLuongTuong = g.Key.TTKTHHCongHopRanh_SoLuongTuong ?? 0,
                              TTKTHHCongHopRanh_CRongLongSuDung = g.Key.TTKTHHCongHopRanh_CRongLongSuDung ?? 0,
                              TTKTHHCongHopRanh_CCaoTuongGop = g.Key.TTKTHHCongHopRanh_CCaoTuongGop ?? 0,
                              TTKTHHCongHopRanh_CCaoMuMoThotDuoi = g.Key.TTKTHHCongHopRanh_CCaoMuMoThotDuoi ?? 0,
                              TTKTHHCongHopRanh_CRongMuMoDuoi = g.Key.TTKTHHCongHopRanh_CRongMuMoDuoi ?? 0,
                              TTKTHHCongHopRanh_CCaoMuMoThotTren = g.Key.TTKTHHCongHopRanh_CCaoMuMoThotTren ?? 0,
                              TTKTHHCongHopRanh_CRongMuMoTren = g.Key.TTKTHHCongHopRanh_CRongMuMoTren ?? 0,
                              TTKTHHCongHopRanh_CCaoChatMatTrong = g.Key.TTKTHHCongHopRanh_CCaoChatMatTrong ?? 0,
                              TTKTHHCongHopRanh_CCaoChatmatNgoai = g.Key.TTKTHHCongHopRanh_CCaoChatmatNgoai ?? 0,
                              ThongTinMongDuongTruyenDan_LoaiMong = g.Key.ThongTinMongDuongTruyenDan_LoaiMong,
                              ThongTinMongDuongTruyenDan_HinhThucMong = g.Key.ThongTinMongDuongTruyenDan_HinhThucMong
                          }).Distinct().ToList();


                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi tải dữ liệu :" + ex.Message);
            }
        }
        public async Task<List<NuocMuaModel>> GetBaoCaoKTHHTDRBT()
        {
            try
            {
                using var context = _context.CreateDbContext();
                List<NuocMuaModel> result = new List<NuocMuaModel>();

                var result1 = (from a in context.DSNuocMua
                               join b in context.PhanLoaiTDanTDans
                               on a.TTTDCongHoRanh_TenLoaiTamDanTieuChuan equals b.Id
                               join c in context.DSDanhMuc
                               on a.ThongTinDuongTruyenDan_HinhThucTruyenDan equals c.Id
                               where c.Ten == "Rãnh bê tông" && a.TTTDCongHoRanh_SoLuong > 0
                               select new NuocMuaModel
                               {
                                   TTTDCongHoRanh_TenLoaiTamDanTieuChuan = a.TTTDCongHoRanh_TenLoaiTamDanTieuChuan,
                                   PhanLoaiTDanTDan_TenLoaiTamDanTieuChuan = b.TTTDCongHoRanh_TenLoaiTamDanTieuChuan ?? "",
                                   TTTDCongHoRanh_CDai = a.TTTDCongHoRanh_CDai ?? 0,
                                   TTTDCongHoRanh_CRong = a.TTTDCongHoRanh_CRong ?? 0,
                                   TTTDCongHoRanh_CCao = a.TTTDCongHoRanh_CCao ?? 0
                               });
                var result2 = (from a in context.DSNuocMua
                               join b in context.PhanLoaiTDanTDans
                               on a.TTTDCongHoRanh_TenLoaiTamDanLoai02 equals b.Id
                               join c in context.DSDanhMuc
                               on a.ThongTinDuongTruyenDan_HinhThucTruyenDan equals c.Id
                               where c.Ten == "Rãnh bê tông" && a.TTTDCongHoRanh_SoLuong1 > 0
                               select new NuocMuaModel
                               {
                                   TTTDCongHoRanh_TenLoaiTamDanTieuChuan = a.TTTDCongHoRanh_TenLoaiTamDanLoai02,
                                   PhanLoaiTDanTDan_TenLoaiTamDanTieuChuan = b.TTTDCongHoRanh_TenLoaiTamDanTieuChuan ?? "",
                                   TTTDCongHoRanh_CDai = a.TTTDCongHoRanh_CDai1 ?? 0,
                                   TTTDCongHoRanh_CRong = a.TTTDCongHoRanh_CRong1 ?? 0,
                                   TTTDCongHoRanh_CCao = a.TTTDCongHoRanh_CCao1 ?? 0
                               });

                result = result1.Concat(result2).Distinct().OrderBy(x => x.PhanLoaiTDanTDan_TenLoaiTamDanTieuChuan).ToList();

                return result;
            }
            catch (Exception)
            {

                throw new Exception("Lỗi khi tải dữ liệu");
            }
        }
        public async Task<List<SLCKModel>> GetBaoCaoSLCKCT(string HinhThucTruyenDan)
        {
            using var context = _context.CreateDbContext();
            List<SLCKModel> result = new();

            result = (from a in context.DSNuocMua
                      join b in context.PhanLoaiCTronHopNhuas on a.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai equals b.Id
                      join c in context.DSDanhMuc on a.ThongTinDuongTruyenDan_HinhThucTruyenDan equals c.Id
                      where c.Ten == HinhThucTruyenDan
                      group a by new
                      {
                          c.Ten,
                          c.Id,
                          PhanLoaiCTronHopNhua_TenLoaiTruyenDanSauPhanLoai = b.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai,
                          a.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai,
                          a.TTCDSLCauKienDuongTruyenDan_ChieuDai01CauKien
                      } into g
                      orderby g.Key.PhanLoaiCTronHopNhua_TenLoaiTruyenDanSauPhanLoai ascending
                      select new SLCKModel
                      {
                          ThongTinDuongTruyenDan_HinhThucTruyenDan_Name = g.Key.Ten,
                          ThongTinDuongTruyenDan_HinhThucTruyenDan = g.Key.Id,
                          PhanLoaiCTronHopNhua_TenLoaiTruyenDanSauPhanLoai = g.Key.PhanLoaiCTronHopNhua_TenLoaiTruyenDanSauPhanLoai,
                          ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai = g.Key.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai,
                          TTCDSLCauKienDuongTruyenDan_ChieuDai01CauKien = g.Key.TTCDSLCauKienDuongTruyenDan_ChieuDai01CauKien??0,
                          Trai = g.Where(x => x.TraiPhai == 0).Sum(x => x.TTCDSLCauKienDuongTruyenDan_TongChieuDai) ?? 0,
                          Phai = g.Where(x => x.TraiPhai == 1).Sum(x => x.TTCDSLCauKienDuongTruyenDan_TongChieuDai) ?? 0,
                          Tong = g.Sum(x => x.TTCDSLCauKienDuongTruyenDan_TongChieuDai) ?? 0,
                          DonVi = (g.Key.Ten == "Cống tròn" || g.Key.Ten == "Cống hộp") ? "Cấu kiện" : "M"
                      }).Distinct().ToList();

            return result;
        }
        public async Task<List<SLTDanTTuyenModel>> GetBaoCaoSLTDTT()
        {
            using var context = _context.CreateDbContext();
            List<SLTDanTTuyenModel> result = new();

            result = (from a in context.DSNuocMua
                      join b in context.PhanLoaiCTronHopNhuas on a.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai equals b.Id
                      join c in context.DSDanhMuc on a.ThongTinDuongTruyenDan_HinhThucTruyenDan equals c.Id
                      group a by new
                      {
                          c.Ten,
                          c.Id,
                          PhanLoaiCTronHopNhua_TenLoaiTruyenDanSauPhanLoai = b.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai,
                          a.ThongTinLyTrinh_TuyenDuong,
                          a.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai,
                          a.TTCDSLCauKienDuongTruyenDan_ChieuDai01CauKien
                      } into g
                      orderby g.Key.PhanLoaiCTronHopNhua_TenLoaiTruyenDanSauPhanLoai ascending
                      select new SLTDanTTuyenModel
                      {
                          ThongTinDuongTruyenDan_HinhThucTruyenDan_Name = g.Key.Ten,
                          ThongTinDuongTruyenDan_HinhThucTruyenDan = g.Key.Id,
                          ThongTinLyTrinh_TuyenDuong = g.Key.ThongTinLyTrinh_TuyenDuong,
                          PhanLoaiCTronHopNhua_TenLoaiTruyenDanSauPhanLoai = g.Key.PhanLoaiCTronHopNhua_TenLoaiTruyenDanSauPhanLoai,
                          ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai = g.Key.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai,
                          TTCDSLCauKienDuongTruyenDan_ChieuDai01CauKien = g.Key.TTCDSLCauKienDuongTruyenDan_ChieuDai01CauKien ?? 0,
                          Trai = g.Where(x => x.TraiPhai == 0).Sum(x => x.TTCDSLCauKienDuongTruyenDan_TongChieuDai) ?? 0,
                          Phai = g.Where(x => x.TraiPhai == 1).Sum(x => x.TTCDSLCauKienDuongTruyenDan_TongChieuDai) ?? 0,
                          Tong = g.Sum(x => x.TTCDSLCauKienDuongTruyenDan_TongChieuDai) ?? 0,
                          DonVi = (g.Key.Ten == "Cống tròn" || g.Key.Ten == "Cống hộp") ? "Cấu kiện" : "M"
                      }).Distinct().ToList();

            return result;
        }
        public async Task<List<TKSLModel>> GetBaoCaoSLMong(string HinhThucTruyenDan)
        {
            using var context = _context.CreateDbContext();
            List<TKSLModel> result = new();
             result = (from a in context.DSNuocMua
                          join b in context.PhanLoaiMongCTrons on a.ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop equals b.Id
                          join c in context.DSDanhMuc on a.ThongTinDuongTruyenDan_HinhThucTruyenDan equals c.Id
                          where c.Ten == HinhThucTruyenDan
                       group a by new
                          {
                              PhanLoaiMongCTron_PhanLoaiMongCongTronCongHop= b.ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop,
                              a.ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop,
                      
                          } into g
                          orderby g.Key.PhanLoaiMongCTron_PhanLoaiMongCongTronCongHop ascending
                          select new TKSLModel
                          {
                              PhanLoai = g.Key.PhanLoaiMongCTron_PhanLoaiMongCongTronCongHop,
                              IdPhanLoai = g.Key.ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop,
                              Trai = g.Where(x => x.TraiPhai == 0).Sum(x => x.TTCDSLCauKienDuongTruyenDan_TongChieuDai) ?? 0,
                              Phai = g.Where(x => x.TraiPhai == 1).Sum(x => x.TTCDSLCauKienDuongTruyenDan_TongChieuDai) ?? 0,
                              Tong = g.Sum(x => x.TTCDSLCauKienDuongTruyenDan_TongChieuDai) ?? 0,
                              DonVi = (g.Key.PhanLoaiMongCTron_PhanLoaiMongCongTronCongHop.Length >= 4 &&
                                     g.Key.PhanLoaiMongCTron_PhanLoaiMongCongTronCongHop.Substring(0, 4) == "Móng") ? "M" : ""
                          }).Distinct().ToList();


            return result;
        }
        public async Task<List<TKSLTTModel>> GetBaoCaoSLMongTH()
        {
            using var context = _context.CreateDbContext();
            List<TKSLTTModel> result = new();
            result = (from a in context.DSNuocMua
                      join b in context.PhanLoaiMongCTrons on a.ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop equals b.Id
                      join c in context.DSDanhMuc on a.ThongTinDuongTruyenDan_HinhThucTruyenDan equals c.Id
                   
                      group a by new
                      {
                          PhanLoaiMongCTron_PhanLoaiMongCongTronCongHop = b.ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop,
                          a.ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop,
                          a.ThongTinLyTrinh_TuyenDuong,

                      } into g
                      orderby g.Key.PhanLoaiMongCTron_PhanLoaiMongCongTronCongHop ascending
                      select new TKSLTTModel
                      {
                          ThongTinLyTrinh_TuyenDuong = g.Key.ThongTinLyTrinh_TuyenDuong,
                          PhanLoai = g.Key.PhanLoaiMongCTron_PhanLoaiMongCongTronCongHop,
                          IdPhanLoai = g.Key.ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop,
                          Trai = g.Where(x => x.TraiPhai == 0).Sum(x => x.TTCDSLCauKienDuongTruyenDan_TongChieuDai) ?? 0,
                          Phai = g.Where(x => x.TraiPhai == 1).Sum(x => x.TTCDSLCauKienDuongTruyenDan_TongChieuDai) ?? 0,
                          Tong = g.Sum(x => x.TTCDSLCauKienDuongTruyenDan_TongChieuDai) ?? 0,
                          DonVi = (g.Key.PhanLoaiMongCTron_PhanLoaiMongCongTronCongHop.Length >= 4 &&
                                 g.Key.PhanLoaiMongCTron_PhanLoaiMongCongTronCongHop.Substring(0, 4) == "Móng") ? "M" : ""
                      }).Distinct().ToList();


            return result;
        }
        public async Task<List<TKSLModel>> GetBaoCaoSLDe()
        {
            using var context = _context.CreateDbContext();
            List<TKSLModel> result = new();
           
             result = (from a in context.DSNuocMua
                          join b in context.PhanLoaiDeCongs on a.ThongTinDeCong_TenLoaiDeCong equals b.Id
                          where a.ThongTinDeCong_D > 0
                          group a by new
                          {
                              PhanLoaiDeCong_TenLoaiDeCong = b.ThongTinDeCong_TenLoaiDeCong,
                              a.ThongTinDeCong_TenLoaiDeCong,
                          } into g
                          orderby g.Key.PhanLoaiDeCong_TenLoaiDeCong ascending
                          select new TKSLModel
                          {
                              PhanLoai = g.Key.PhanLoaiDeCong_TenLoaiDeCong,
                              IdPhanLoai = g.Key.ThongTinDeCong_TenLoaiDeCong,
                              Trai = g.Sum(x => x.TraiPhai == 0 ? x.ThongTinDeCong_SlDeCong01CauKienTruyenDan : 0)??0,
                              Phai = g.Sum(x => x.TraiPhai == 1 ? x.ThongTinDeCong_SlDeCong01CauKienTruyenDan : 0)??0,
                              Tong = g.Sum(x => x.ThongTinDeCong_SlDeCong01CauKienTruyenDan)??0,
                              DonVi = (g.Key.PhanLoaiDeCong_TenLoaiDeCong.Length >= 2 &&
                                 g.Key.PhanLoaiDeCong_TenLoaiDeCong.Substring(0, 2) == "Đế") ? "Cấu kiện" : ""
                          }).Distinct().ToList();


            return result;
        }
        public async Task<List<TKSLTTModel>> GetBaoCaoSLDeTT()
        {
            using var context = _context.CreateDbContext();
            List<TKSLTTModel> result = new();

            result = (from a in context.DSNuocMua
                      join b in context.PhanLoaiDeCongs on a.ThongTinDeCong_TenLoaiDeCong equals b.Id
                      where a.ThongTinDeCong_D > 0
                      group a by new
                      {
                          PhanLoaiDeCong_TenLoaiDeCong = b.ThongTinDeCong_TenLoaiDeCong,
                          a.ThongTinDeCong_TenLoaiDeCong,
                          a.ThongTinLyTrinh_TuyenDuong
                      } into g
                      orderby g.Key.PhanLoaiDeCong_TenLoaiDeCong ascending
                      select new TKSLTTModel
                      {
                          ThongTinLyTrinh_TuyenDuong = g.Key.ThongTinLyTrinh_TuyenDuong,
                          PhanLoai = g.Key.PhanLoaiDeCong_TenLoaiDeCong,
                          IdPhanLoai = g.Key.ThongTinDeCong_TenLoaiDeCong,
                          Trai = g.Sum(x => x.TraiPhai == 0 ? x.ThongTinDeCong_SlDeCong01CauKienTruyenDan : 0) ?? 0,
                          Phai = g.Sum(x => x.TraiPhai == 1 ? x.ThongTinDeCong_SlDeCong01CauKienTruyenDan : 0) ?? 0,
                          Tong = g.Sum(x => x.ThongTinDeCong_SlDeCong01CauKienTruyenDan) ?? 0,
                          DonVi = (g.Key.PhanLoaiDeCong_TenLoaiDeCong.Length >= 2 &&
                             g.Key.PhanLoaiDeCong_TenLoaiDeCong.Substring(0, 2) == "Đế") ? "Cấu kiện" : ""
                      }).Distinct().ToList();


            return result;
        }
        public async Task<List<TKSLModel>> GetBaoCaoSLTT()
        {
            using var context = _context.CreateDbContext();
            List<TKSLModel> result = new();

            result = (from a in context.DSNuocMua
                      join b in context.PhanLoaiThanhChongs on a.TTKTHHCongHopRanh_LoaiThanhChong equals b.Id
                      where a.TTKTHHCongHopRanh_CCaoThanhChong > 0
                      group a by new
                      {
                          PhanLoai = b.TTKTHHCongHopRanh_LoaiThanhChong,
                          a.TTKTHHCongHopRanh_LoaiThanhChong,
                      } into g
                      orderby g.Key.PhanLoai ascending
                      select new TKSLModel
                      {
                          PhanLoai = g.Key.PhanLoai,
                          IdPhanLoai = g.Key.TTKTHHCongHopRanh_LoaiThanhChong,
                          Trai = g.Sum(x => x.TraiPhai == 0 ? x.TTKTHHCongHopRanh_SoLuongThanhChong : 0) ?? 0,
                          Phai = g.Sum(x => x.TraiPhai == 1 ? x.TTKTHHCongHopRanh_SoLuongThanhChong : 0) ?? 0,
                          Tong = g.Sum(x => x.TTKTHHCongHopRanh_SoLuongThanhChong) ?? 0,
                          DonVi = (g.Key.PhanLoai.Length >= 2 &&
                             g.Key.PhanLoai.Substring(0, 11) == "Thanh chống") ? "Cấu kiện" : ""
                      }).Distinct().ToList();


            return result;
        }
        public async Task<List<TKSLTTModel>> GetBaoCaoSLTTTT()
        {
            using var context = _context.CreateDbContext();
            List<TKSLTTModel> result = new();

            result = (from a in context.DSNuocMua
                      join b in context.PhanLoaiThanhChongs on a.TTKTHHCongHopRanh_LoaiThanhChong equals b.Id
                      where a.TTKTHHCongHopRanh_CCaoThanhChong > 0
                      group a by new
                      {
                          PhanLoai = b.TTKTHHCongHopRanh_LoaiThanhChong,
                          a.TTKTHHCongHopRanh_LoaiThanhChong,
                          a.ThongTinLyTrinh_TuyenDuong
                      } into g
                      orderby g.Key.PhanLoai ascending
                      select new TKSLTTModel
                      {
                          ThongTinLyTrinh_TuyenDuong = g.Key.ThongTinLyTrinh_TuyenDuong,
                          PhanLoai = g.Key.PhanLoai,
                          IdPhanLoai = g.Key.TTKTHHCongHopRanh_LoaiThanhChong,
                          Trai = g.Sum(x => x.TraiPhai == 0 ? x.TTKTHHCongHopRanh_SoLuongThanhChong : 0) ?? 0,
                          Phai = g.Sum(x => x.TraiPhai == 1 ? x.TTKTHHCongHopRanh_SoLuongThanhChong : 0) ?? 0,
                          Tong = g.Sum(x => x.TTKTHHCongHopRanh_SoLuongThanhChong) ?? 0,
                          DonVi = (g.Key.PhanLoai.Length >= 2 &&
                             g.Key.PhanLoai.Substring(0, 2) == "Đế") ? "Cấu kiện" : ""
                      }).Distinct().ToList();


            return result;
        }
        public async Task<List<TKSLModel>> GetBaoCaoSLTDan(string HinhThucTruyenDan)
        {
            try
            {
                using var context = _context.CreateDbContext();
                List<TKSLModel> result = new List<TKSLModel>();

                var result1 = (from a in context.DSNuocMua
                               join b in context.PhanLoaiTDanTDans
                               on a.TTTDCongHoRanh_TenLoaiTamDanTieuChuan equals b.Id
                               join c in context.DSDanhMuc
                               on a.ThongTinDuongTruyenDan_HinhThucTruyenDan equals c.Id
                               where c.Ten == HinhThucTruyenDan && a.TTTDCongHoRanh_SoLuong > 0
                               group a by new
                               {
                                   PhanLoai = b.TTTDCongHoRanh_TenLoaiTamDanTieuChuan,
                                   a.TTTDCongHoRanh_TenLoaiTamDanTieuChuan
                               } into g
                               orderby g.Key.PhanLoai ascending
                               select new TKSLModel
                               {
                                   IdPhanLoai = g.Key.TTTDCongHoRanh_TenLoaiTamDanTieuChuan,
                                   PhanLoai = g.Key.PhanLoai ?? "",
                                   Trai = g.Sum(x => x.TraiPhai == 0 ? x.TTTDCongHoRanh_SoLuong : 0)??0,
                                   Phai = g.Sum(x => x.TraiPhai == 1 ? x.TTTDCongHoRanh_SoLuong : 0)??0,
                                   Tong = g.Sum(x => x.TTTDCongHoRanh_SoLuong)??0,
                                   DonVi = (g.Key.PhanLoai != null && g.Key.PhanLoai.StartsWith("Tấm đan")) ? "Cấu kiện" : ""
                               }).ToList();

                var result2 = (from a in context.DSNuocMua
                               join b in context.PhanLoaiTDanTDans
                               on a.TTTDCongHoRanh_TenLoaiTamDanLoai02 equals b.Id
                               join c in context.DSDanhMuc
                               on a.ThongTinDuongTruyenDan_HinhThucTruyenDan equals c.Id
                               where c.Ten == HinhThucTruyenDan && a.TTTDCongHoRanh_SoLuong1 > 0
                               group a by new
                               {
                                   PhanLoai = b.TTTDCongHoRanh_TenLoaiTamDanTieuChuan,
                                   a.TTTDCongHoRanh_TenLoaiTamDanLoai02
                               } into g
                               orderby g.Key.PhanLoai ascending
                               select new TKSLModel
                               {
                                   IdPhanLoai = g.Key.TTTDCongHoRanh_TenLoaiTamDanLoai02,
                                   PhanLoai = g.Key.PhanLoai ,
                                   Trai = g.Sum(x => x.TraiPhai == 0 ? x.TTTDCongHoRanh_SoLuong1 : 0) ?? 0,
                                   Phai = g.Sum(x => x.TraiPhai == 1 ? x.TTTDCongHoRanh_SoLuong1 : 0) ?? 0,
                                   Tong = g.Sum(x => x.TTTDCongHoRanh_SoLuong1) ?? 0,
                                   DonVi = (g.Key.PhanLoai.Length >= 2 && g.Key.PhanLoai.Substring(0, 7) == "Tấm đan") ? "Cấu kiện" : ""
                               });

                result = result1.Concat(result2).Distinct().OrderBy(x => x.PhanLoai).ToList();

                return result;
            }
            catch (Exception)
            {

                throw new Exception("Lỗi khi tải dữ liệu");
            }
        }
        public async Task<List<TKSLTTModel>> GetBaoCaoSLTDanTT()
        {
            try
            {
                using var context = _context.CreateDbContext();
                List<TKSLTTModel> result = new List<TKSLTTModel>();

                var result1 = (from a in context.DSNuocMua
                               join b in context.PhanLoaiTDanTDans
                               on a.TTTDCongHoRanh_TenLoaiTamDanTieuChuan equals b.Id
                               where  a.TTTDCongHoRanh_SoLuong > 0
                               group a by new
                               {
                                   PhanLoai = b.TTTDCongHoRanh_TenLoaiTamDanTieuChuan,
                                   a.TTTDCongHoRanh_TenLoaiTamDanTieuChuan,
                                   a.ThongTinLyTrinh_TuyenDuong
                               } into g
                               orderby g.Key.PhanLoai ascending
                               select new TKSLTTModel
                               {
                                   ThongTinLyTrinh_TuyenDuong = g.Key.ThongTinLyTrinh_TuyenDuong,
                                   IdPhanLoai = g.Key.TTTDCongHoRanh_TenLoaiTamDanTieuChuan,
                                   PhanLoai = g.Key.PhanLoai ?? "",
                                   Trai = g.Sum(x => x.TraiPhai == 0 ? x.TTTDCongHoRanh_SoLuong : 0) ?? 0,
                                   Phai = g.Sum(x => x.TraiPhai == 1 ? x.TTTDCongHoRanh_SoLuong : 0) ?? 0,
                                   Tong = g.Sum(x => x.TTTDCongHoRanh_SoLuong) ?? 0,
                                   DonVi = (g.Key.PhanLoai != null && g.Key.PhanLoai.StartsWith("Tấm đan")) ? "Cấu kiện" : ""
                               }).ToList();

                var result2 = (from a in context.DSNuocMua
                               join b in context.PhanLoaiTDanTDans
                               on a.TTTDCongHoRanh_TenLoaiTamDanLoai02 equals b.Id
                               where a.TTTDCongHoRanh_SoLuong1 > 0
                               group a by new
                               {
                                   PhanLoai = b.TTTDCongHoRanh_TenLoaiTamDanTieuChuan,
                                   a.TTTDCongHoRanh_TenLoaiTamDanLoai02,
                                   a.ThongTinLyTrinh_TuyenDuong
                               } into g
                               orderby g.Key.PhanLoai ascending
                               select new TKSLTTModel
                               {
                                   IdPhanLoai = g.Key.TTTDCongHoRanh_TenLoaiTamDanLoai02,
                                   ThongTinLyTrinh_TuyenDuong = g.Key.ThongTinLyTrinh_TuyenDuong,
                                   PhanLoai = g.Key.PhanLoai,
                                   Trai = g.Sum(x => x.TraiPhai == 0 ? x.TTTDCongHoRanh_SoLuong1 : 0) ?? 0,
                                   Phai = g.Sum(x => x.TraiPhai == 1 ? x.TTTDCongHoRanh_SoLuong1 : 0) ?? 0,
                                   Tong = g.Sum(x => x.TTTDCongHoRanh_SoLuong1) ?? 0,
                                   DonVi = (g.Key.PhanLoai.Length >= 2 && g.Key.PhanLoai.Substring(0, 7) == "Tấm đan") ? "Cấu kiện" : ""
                               });

                result = result1.Concat(result2).Distinct().OrderBy(x => x.PhanLoai).ToList();

                return result;
            }
            catch (Exception)
            {

                throw new Exception("Lỗi khi tải dữ liệu");
            }
        }
        public async Task<List<NuocMuaModel>> GetBaoCaoMongCTSDThep()
        {
            try
            {
                List<NuocMuaModel> result = new();
                using var context = _context.CreateDbContext();

                 result = (from a in context.DSNuocMua
                             join c in context.DSDanhMuc on a.ThongTinDuongTruyenDan_HinhThucTruyenDan equals c.Id
                             join d in context.DSDanhMuc on a.ThongTinMongDuongTruyenDan_HinhThucMong equals d.Id
                             join b in context.PhanLoaiMongCTrons on a.ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop equals b.Id into bJoin
                             from b in bJoin.DefaultIfEmpty()
                             where c.Ten == "Cống tròn" && d.Ten == "Có cốt thép"
                             select new NuocMuaModel
                             {
                                 ThongTinDuongTruyenDan_HinhThucTruyenDan = a.ThongTinDuongTruyenDan_HinhThucTruyenDan??"",
                                 ThongTinDuongTruyenDan_HinhThucTruyenDan_Name = c.Ten,
                                 ThongTinMongDuongTruyenDan_HinhThucMong = a.ThongTinMongDuongTruyenDan_HinhThucMong??"",
                                 ThongTinMongDuongTruyenDan_HinhThucMong_Name = d.Ten,
                                 ThongTinLyTrinh_TuyenDuong = a.ThongTinLyTrinh_TuyenDuong ?? "",
                                 ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop = a.ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop??"",
                                 PhanLoaiMongCTron_PhanLoaiMongCongTronCongHop = b.ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop??"",
                                 ThongTinLyTrinhTruyenDan_TuLyTrinh = a.ThongTinLyTrinhTruyenDan_TuLyTrinh??0,
                                 ThongTinLyTrinhTruyenDan_DenLyTrinh = a.ThongTinLyTrinhTruyenDan_DenLyTrinh??0,
                             }).Distinct().ToList();

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi tải dữ liệu :" + ex.Message);
            }
        }
        public async Task<List<NuocMuaModel>> GetBaoCaoCongTronSDThep()
        {
            try
            {
                List<NuocMuaModel> result = new();
                using var context = _context.CreateDbContext();

                 result = (from a in context.DSNuocMua
                              join b in context.PhanLoaiCTronHopNhuas on a.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai equals b.Id
                              join c in context.DSDanhMuc on a.ThongTinDuongTruyenDan_HinhThucTruyenDan equals c.Id
                              where c.Ten == "Cống tròn"
                              orderby b.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai
                              select new NuocMuaModel
                              {
                                  ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai = a.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai??"",
                                  PhanLoaiCTronHopNhua_TenLoaiTruyenDanSauPhanLoai =  b.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai,
                                  ThongTinDuongTruyenDan_HinhThucTruyenDan = a.ThongTinDuongTruyenDan_HinhThucTruyenDan??"",
                                  ThongTinDuongTruyenDan_HinhThucTruyenDan_Name = c.Ten
                              }).Distinct().ToList();


                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi tải dữ liệu :" + ex.Message);
            }
        }
        public async Task<List<NuocMuaModel>> GetBaoCaoDeCongSDThep()
        {
            try
            {
                List<NuocMuaModel> result = new();
                using var context = _context.CreateDbContext();

                result = (from a in context.DSNuocMua
                              join b in context.PhanLoaiDeCongs on a.ThongTinDeCong_TenLoaiDeCong equals b.Id
                              join c in context.DSDanhMuc on a.ThongTinDeCong_CauTaoDeCong equals c.Id
                              where c.Ten == "Có cốt thép"
                              orderby b.ThongTinDeCong_TenLoaiDeCong
                              select new NuocMuaModel
                              {
                                  ThongTinDeCong_TenLoaiDeCong = a.ThongTinDeCong_TenLoaiDeCong ?? "",
                                  PhanLoaiDeCong_TenLoaiDeCong = b.ThongTinDeCong_TenLoaiDeCong??"",
                                  ThongTinDeCong_CauTaoDeCong =  a.ThongTinDeCong_CauTaoDeCong??"",
                                  ThongTinDeCong_CauTaoDeCong_Name =  c.Ten,
                              }).Distinct().ToList();



                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi tải dữ liệu :" + ex.Message);
            }
        }
        public async Task<List<NuocMuaModel>> GetBaoCaoCongHopSDThep()
        {
            try
            {
                List<NuocMuaModel> result = new();
                using var context = _context.CreateDbContext();

                 result = (from a in context.DSNuocMua
                             join b in context.PhanLoaiCTronHopNhuas on a.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai equals b.Id
                             join c in context.DSDanhMuc on a.TTKTHHCongHopRanh_CauTaoTuong equals c.Id
                           join e in context.DSDanhMuc on a.TTKTHHCongHopRanh_CauTaoMuMo equals e.Id into eGroup
                           from e in eGroup.DefaultIfEmpty()
                           join f in context.DSDanhMuc on a.ThongTinDuongTruyenDan_HinhThucTruyenDan equals f.Id into fGroup
                           from f in fGroup.DefaultIfEmpty()
                           where f.Ten == "Cống hộp" &&
                                   (c.Ten == "Tường bê tông cốt thép" || e.Ten == "Mũ mố bê tông cốt thép")
                             select new NuocMuaModel
                             {
                             
                                 ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai = a.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai??"",
                                 PhanLoaiCTronHopNhua_TenLoaiTruyenDanSauPhanLoai = b.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai,
                                 TTKTHHCongHopRanh_CauTaoTuong = a.TTKTHHCongHopRanh_CauTaoTuong??"",
                                 TTKTHHCongHopRanh_CauTaoTuong_Name = c.Ten,
                                 TTKTHHCongHopRanh_CauTaoMuMo = a.TTKTHHCongHopRanh_CauTaoMuMo??"",
                                 TTKTHHCongHopRanh_CauTaoMuMo_Name = e.Ten,
                                 ThongTinDuongTruyenDan_HinhThucTruyenDan = a.ThongTinDuongTruyenDan_HinhThucTruyenDan??"",
                                 ThongTinDuongTruyenDan_HinhThucTruyenDan_Name = f.Ten
                             }).Distinct().ToList();
 
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi tải dữ liệu :" + ex.Message);
            }
        }
        public async Task<List<NuocMuaModel>> GetBaoCaoMongCongHopSDThep()
        {
            try
            {
                List<NuocMuaModel> result = new();
                using var context = _context.CreateDbContext();

                 result = ( from a in context.DSNuocMua
                                        join b in context.PhanLoaiMongCTrons on a.ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop equals b.Id
                                        join c in context.DSDanhMuc on a.ThongTinMongDuongTruyenDan_HinhThucMong equals c.Id
                                        join f in context.DSDanhMuc on a.ThongTinDuongTruyenDan_HinhThucTruyenDan equals f.Id into fGroup
                                        from f in fGroup.DefaultIfEmpty()
                                        where f.Ten == "Cống hộp" && c.Ten == "Có cốt thép"
                                        select new NuocMuaModel
                                        {
                                            ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop = a.ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop ??"",
                                            PhanLoaiMongCTron_PhanLoaiMongCongTronCongHop = b.ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop ??"",
                                            ThongTinLyTrinh_TuyenDuong = a.ThongTinLyTrinh_TuyenDuong??"",
                                            ThongTinLyTrinhTruyenDan_TuLyTrinh = a.ThongTinLyTrinhTruyenDan_TuLyTrinh??0,
                                            ThongTinLyTrinhTruyenDan_DenLyTrinh = a.ThongTinLyTrinhTruyenDan_DenLyTrinh??0,
                                            
                                            }
                                        ).Distinct().ToList();
 
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi tải dữ liệu :" + ex.Message);
            }
        }
        public async Task<List<NuocMuaModel>> GetBaoCaoTDCHSDThep()
        {
            try
            {
                using var context = _context.CreateDbContext();
                List<NuocMuaModel> result = new List<NuocMuaModel>();

                var result1 = (from a in context.DSNuocMua
                                            join c in context.DSDanhMuc on a.ThongTinDuongTruyenDan_HinhThucTruyenDan equals c.Id into cGroup
                                            from c in cGroup.DefaultIfEmpty()
                                            join d in context.DSDanhMuc on a.TTTDCongHoRanh_CauTaoTamDanTruyenDanTamDanTieuChuan equals d.Id
                                            join f in context.PhanLoaiTDanTDans on a.TTTDCongHoRanh_TenLoaiTamDanTieuChuan equals f.Id
                                            where c.Ten == "Cống hộp" && d.Ten == "Có cốt thép" && a.TTTDCongHoRanh_SoLuong > 0
                                            select new NuocMuaModel
                                            {
                                                TTTDCongHoRanh_TenLoaiTamDanTieuChuan = f.Id,
                                                PhanLoaiTDanTDan_TenLoaiTamDanTieuChuan = f.TTTDCongHoRanh_TenLoaiTamDanTieuChuan??"",
                                                TTTDCongHoRanh_CauTaoTamDanTruyenDanTamDanTieuChuan = a.TTTDCongHoRanh_CauTaoTamDanTruyenDanTamDanTieuChuan,
                                                TTTDCongHoRanh_CauTaoTamDanTruyenDanTamDanTieuChuan_Name = d.Ten,
                                                TTTDCongHoRanh_CDai = a.TTTDCongHoRanh_CDai??0,
                                                TTTDCongHoRanh_CRong = a.TTTDCongHoRanh_CRong ?? 0,
                                                TTTDCongHoRanh_CCao = a.TTTDCongHoRanh_CCao ?? 0
                                            }).ToList();

                var result2 = (from a in context.DSNuocMua
                               join c in context.DSDanhMuc on a.ThongTinDuongTruyenDan_HinhThucTruyenDan equals c.Id into cGroup
                               from c in cGroup.DefaultIfEmpty()
                               join d in context.DSDanhMuc on a.TTTDCongHoRanh_CauTaoTamDanTruyenDan equals d.Id
                               join f in context.PhanLoaiTDanTDans on a.TTTDCongHoRanh_TenLoaiTamDanLoai02 equals f.Id
                               where c.Ten == "Cống hộp" && d.Ten == "Có cốt thép" && a.TTTDCongHoRanh_SoLuong1 > 0
                               select new NuocMuaModel
                               {
                                   TTTDCongHoRanh_TenLoaiTamDanTieuChuan = f.Id,
                                   PhanLoaiTDanTDan_TenLoaiTamDanTieuChuan = f.TTTDCongHoRanh_TenLoaiTamDanTieuChuan ?? "",
                                   TTTDCongHoRanh_CauTaoTamDanTruyenDanTamDanTieuChuan = a.TTTDCongHoRanh_CauTaoTamDanTruyenDan,
                                   TTTDCongHoRanh_CauTaoTamDanTruyenDanTamDanTieuChuan_Name = d.Ten,
                                   TTTDCongHoRanh_CDai = a.TTTDCongHoRanh_CDai1 ?? 0,
                                   TTTDCongHoRanh_CRong = a.TTTDCongHoRanh_CRong1 ?? 0,
                                   TTTDCongHoRanh_CCao = a.TTTDCongHoRanh_CCao1 ?? 0
                               }).ToList();

                result = result1.Concat(result2).Distinct().OrderBy(x => x.PhanLoaiTDanTDan_TenLoaiTamDanTieuChuan).ToList();

                return result;
            }
            catch (Exception)
            {

                throw new Exception("Lỗi khi tải dữ liệu");
            }
        }
        public async Task<List<NuocMuaModel>> GetBaoCaoRXSDThep()
        {
            try
            {
                using var context = _context.CreateDbContext();

                var result = await (from a in context.DSNuocMua.AsNoTracking()
                                    join f in context.PhanLoaiCTronHopNhuas.AsNoTracking()
                                        on a.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai equals f.Id into fGroup
                                    from f in fGroup.DefaultIfEmpty()
                                    join g in context.PhanLoaiMongCTrons.AsNoTracking()
                                        on a.ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop equals g.Id into gGroup
                                    from g in gGroup.DefaultIfEmpty()
                                    join b in context.DSDanhMuc.AsNoTracking()
                                        on a.ThongTinDuongTruyenDan_HinhThucTruyenDan equals b.Id into bGroup
                                    from b in bGroup.DefaultIfEmpty()
                                    join c in context.DSDanhMuc.AsNoTracking()
                                        on a.TTKTHHCongHopRanh_CauTaoTuong equals c.Id into cGroup
                                    from c in cGroup.DefaultIfEmpty()
                                    join d in context.DSDanhMuc.AsNoTracking()
                                        on a.TTKTHHCongHopRanh_CauTaoMuMo equals d.Id into dGroup
                                    from d in dGroup.DefaultIfEmpty()
                                    join e in context.DSDanhMuc.AsNoTracking()
                                        on a.ThongTinMongDuongTruyenDan_HinhThucMong equals e.Id into eGroup
                                    from e in eGroup.DefaultIfEmpty()
                                    join h in context.DSDanhMuc.AsNoTracking()
                                       on a.ThongTinMongDuongTruyenDan_LoaiMong equals h.Id into hGroup
                                    from h in hGroup.DefaultIfEmpty()
                                    where b.Ten == "Rãnh xây" &&
                                          (c.Ten == "Tường bê tông cốt thép" ||
                                           d.Ten == "Mũ mố bê tông cốt thép" ||
                                           e.Ten == "Có cốt thép")
                                    select new NuocMuaModel
                                    {
                                        ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai = a.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai??"",
                                        PhanLoaiCTronHopNhua_TenLoaiTruyenDanSauPhanLoai = f.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai ?? "",
                                        ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop = a.ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop ?? "",
                                        PhanLoaiMongCTron_PhanLoaiMongCongTronCongHop = !string.IsNullOrEmpty(g.ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop)? g.ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop: (h.Ten+" , " + e.Ten)??"",
                                        ThongTinDuongTruyenDan_HinhThucTruyenDan = a.ThongTinDuongTruyenDan_HinhThucTruyenDan ?? "",
                                        ThongTinDuongTruyenDan_HinhThucTruyenDan_Name = b.Ten ?? "",
                                        TTKTHHCongHopRanh_CauTaoTuong = a.TTKTHHCongHopRanh_CauTaoTuong ?? "",
                                        TTKTHHCongHopRanh_CauTaoTuong_Name = c.Ten ?? "",
                                        TTKTHHCongHopRanh_CauTaoMuMo = a.TTKTHHCongHopRanh_CauTaoMuMo ?? "",
                                        TTKTHHCongHopRanh_CauTaoMuMo_Name = d.Ten ?? "",
                                        ThongTinMongDuongTruyenDan_HinhThucMong = a.ThongTinMongDuongTruyenDan_HinhThucMong ?? "",
                                        ThongTinMongDuongTruyenDan_HinhThucMong_Name = e.Ten ?? ""
                                    }).Distinct().ToListAsync();

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi tải dữ liệu: " + ex.Message);
            }
        }
        public async Task<List<NuocMuaModel>> GetBaoCaoTDRXSDThep()
        {
            try
            {
                using var context = _context.CreateDbContext();
                List<NuocMuaModel> result = new List<NuocMuaModel>();

                var result1 = (from a in context.DSNuocMua
                               join c in context.DSDanhMuc on a.ThongTinDuongTruyenDan_HinhThucTruyenDan equals c.Id into cGroup
                               from c in cGroup.DefaultIfEmpty()
                               join d in context.DSDanhMuc on a.TTTDCongHoRanh_CauTaoTamDanTruyenDanTamDanTieuChuan equals d.Id
                               join f in context.PhanLoaiTDanTDans on a.TTTDCongHoRanh_TenLoaiTamDanTieuChuan equals f.Id
                               where c.Ten == "Rãnh xây" && d.Ten == "Có cốt thép" && a.TTTDCongHoRanh_SoLuong > 0
                               select new NuocMuaModel
                               {
                                   TTTDCongHoRanh_TenLoaiTamDanTieuChuan =a.TTTDCongHoRanh_TenLoaiTamDanTieuChuan??"",
                                   PhanLoaiTDanTDan_TenLoaiTamDanTieuChuan = f.TTTDCongHoRanh_TenLoaiTamDanTieuChuan ?? "",
                                   TTTDCongHoRanh_CauTaoTamDanTruyenDanTamDanTieuChuan = a.TTTDCongHoRanh_CauTaoTamDanTruyenDanTamDanTieuChuan,
                                   TTTDCongHoRanh_CauTaoTamDanTruyenDanTamDanTieuChuan_Name = d.Ten,
                                   TTTDCongHoRanh_CDai = a.TTTDCongHoRanh_CDai ?? 0,
                                   TTTDCongHoRanh_CRong = a.TTTDCongHoRanh_CRong ?? 0,
                                   TTTDCongHoRanh_CCao = a.TTTDCongHoRanh_CCao ?? 0
                               }).ToList();

                var result2 = (from a in context.DSNuocMua
                               join c in context.DSDanhMuc on a.ThongTinDuongTruyenDan_HinhThucTruyenDan equals c.Id into cGroup
                               from c in cGroup.DefaultIfEmpty()
                               join d in context.DSDanhMuc on a.TTTDCongHoRanh_CauTaoTamDanTruyenDan equals d.Id
                               join f in context.PhanLoaiTDanTDans on a.TTTDCongHoRanh_TenLoaiTamDanLoai02 equals f.Id
                               where c.Ten == "Rãnh xây" && d.Ten == "Có cốt thép" && a.TTTDCongHoRanh_SoLuong1 > 0
                               select new NuocMuaModel
                               {
                                   TTTDCongHoRanh_TenLoaiTamDanTieuChuan = a.TTTDCongHoRanh_TenLoaiTamDanLoai02??"",
                                   PhanLoaiTDanTDan_TenLoaiTamDanTieuChuan = f.TTTDCongHoRanh_TenLoaiTamDanTieuChuan ?? "",
                                   TTTDCongHoRanh_CauTaoTamDanTruyenDanTamDanTieuChuan = a.TTTDCongHoRanh_CauTaoTamDanTruyenDan,
                                   TTTDCongHoRanh_CauTaoTamDanTruyenDanTamDanTieuChuan_Name = d.Ten,
                                   TTTDCongHoRanh_CDai = a.TTTDCongHoRanh_CDai1 ?? 0,
                                   TTTDCongHoRanh_CRong = a.TTTDCongHoRanh_CRong1 ?? 0,
                                   TTTDCongHoRanh_CCao = a.TTTDCongHoRanh_CCao1 ?? 0
                               }).ToList();

                result = result1.Concat(result2).Distinct().OrderBy(x => x.PhanLoaiTDanTDan_TenLoaiTamDanTieuChuan).ToList();

                return result;
            }
            catch (Exception)
            {

                throw new Exception("Lỗi khi tải dữ liệu");
            }
        }
        public async Task<List<NuocMuaModel>> GetBaoCaoTCSDThep()
        {
            try
            {
                using var context = _context.CreateDbContext();
                List<NuocMuaModel> result = new List<NuocMuaModel>();
                result = await (from a in context.DSNuocMua.AsNoTracking()
                                    join b in context.DSDanhMuc.AsNoTracking()
                                        on a.TTKTHHCongHopRanh_CauTaoThanhChong equals b.Id into bGroup
                                    from b in bGroup.DefaultIfEmpty()
                                    join c in context.PhanLoaiThanhChongs.AsNoTracking()
                                        on a.TTKTHHCongHopRanh_LoaiThanhChong equals c.Id
                                    where b.Ten == "Có cốt thép"
                                    select new NuocMuaModel
                                    {
                                        PhanLoaiThanhChong_LoaiThanhChong = c.TTKTHHCongHopRanh_LoaiThanhChong??"",
                                        TTKTHHCongHopRanh_LoaiThanhChong = a.TTKTHHCongHopRanh_LoaiThanhChong,
                                        TTKTHHCongHopRanh_CauTaoThanhChong_Name = b.Ten,
                                        TTKTHHCongHopRanh_CauTaoThanhChong = a.TTKTHHCongHopRanh_CauTaoThanhChong
                                    }).Distinct().ToListAsync();

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi tải dữ liệu: " + ex.Message);
            }
        }
        public async Task<List<NuocMuaModel>> GetBaoCaoRBTSDThep()
        {
            try
            {
                using var context = _context.CreateDbContext();

                var result = await (from a in context.DSNuocMua.AsNoTracking()
                                    join f in context.PhanLoaiCTronHopNhuas.AsNoTracking()
                                        on a.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai equals f.Id into fGroup
                                    from f in fGroup.DefaultIfEmpty()
                                    join g in context.PhanLoaiMongCTrons.AsNoTracking()
                                        on a.ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop equals g.Id into gGroup
                                    from g in gGroup.DefaultIfEmpty()
                                    join b in context.DSDanhMuc.AsNoTracking()
                                        on a.ThongTinDuongTruyenDan_HinhThucTruyenDan equals b.Id into bGroup
                                    from b in bGroup.DefaultIfEmpty()
                                    join c in context.DSDanhMuc.AsNoTracking()
                                        on a.TTKTHHCongHopRanh_CauTaoTuong equals c.Id into cGroup
                                    from c in cGroup.DefaultIfEmpty()
                                    join d in context.DSDanhMuc.AsNoTracking()
                                        on a.TTKTHHCongHopRanh_CauTaoMuMo equals d.Id into dGroup
                                    from d in dGroup.DefaultIfEmpty()
                                    join e in context.DSDanhMuc.AsNoTracking()
                                        on a.ThongTinMongDuongTruyenDan_HinhThucMong equals e.Id into eGroup
                                    from e in eGroup.DefaultIfEmpty()
                                    join h in context.DSDanhMuc.AsNoTracking()
                                       on a.ThongTinMongDuongTruyenDan_LoaiMong equals h.Id into hGroup
                                    from h in hGroup.DefaultIfEmpty()
                                    where b.Ten == "Rãnh bê tông" &&
                                          (c.Ten == "Tường bê tông cốt thép" ||
                                           d.Ten == "Mũ mố bê tông cốt thép" ||
                                           e.Ten == "Có cốt thép")
                                    select new NuocMuaModel
                                    {
                                        ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai = a.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai ?? "",
                                        PhanLoaiCTronHopNhua_TenLoaiTruyenDanSauPhanLoai = f.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai ?? "",
                                        ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop = a.ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop ?? "",
                                        PhanLoaiMongCTron_PhanLoaiMongCongTronCongHop = !string.IsNullOrEmpty(g.ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop) ? g.ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop : (h.Ten + " , " + e.Ten) ?? "",
                                        ThongTinDuongTruyenDan_HinhThucTruyenDan = a.ThongTinDuongTruyenDan_HinhThucTruyenDan ?? "",
                                        ThongTinDuongTruyenDan_HinhThucTruyenDan_Name = b.Ten ?? "",
                                        TTKTHHCongHopRanh_CauTaoTuong = a.TTKTHHCongHopRanh_CauTaoTuong ?? "",
                                        TTKTHHCongHopRanh_CauTaoTuong_Name = c.Ten ?? "",
                                        TTKTHHCongHopRanh_CauTaoMuMo = a.TTKTHHCongHopRanh_CauTaoMuMo ?? "",
                                        TTKTHHCongHopRanh_CauTaoMuMo_Name = d.Ten ?? "",
                                        ThongTinMongDuongTruyenDan_HinhThucMong = a.ThongTinMongDuongTruyenDan_HinhThucMong ?? "",
                                        ThongTinMongDuongTruyenDan_HinhThucMong_Name = e.Ten ?? ""
                                    }).Distinct().ToListAsync();

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi tải dữ liệu: " + ex.Message);
            }
        }
        public async Task<List<NuocMuaModel>> GetBaoCaoTDRBTSDThep()
        {
            try
            {
                using var context = _context.CreateDbContext();
                List<NuocMuaModel> result = new List<NuocMuaModel>();

                var result1 = (from a in context.DSNuocMua
                               join c in context.DSDanhMuc on a.ThongTinDuongTruyenDan_HinhThucTruyenDan equals c.Id into cGroup
                               from c in cGroup.DefaultIfEmpty()
                               join d in context.DSDanhMuc on a.TTTDCongHoRanh_CauTaoTamDanTruyenDanTamDanTieuChuan equals d.Id
                               join f in context.PhanLoaiTDanTDans on a.TTTDCongHoRanh_TenLoaiTamDanTieuChuan equals f.Id
                               where c.Ten == "Rãnh bê tông" && d.Ten == "Có cốt thép" && a.TTTDCongHoRanh_SoLuong > 0
                               select new NuocMuaModel
                               {
                                   TTTDCongHoRanh_TenLoaiTamDanTieuChuan = a.TTTDCongHoRanh_TenLoaiTamDanTieuChuan,
                                   PhanLoaiTDanTDan_TenLoaiTamDanTieuChuan = f.TTTDCongHoRanh_TenLoaiTamDanTieuChuan ?? "",
                                   TTTDCongHoRanh_CauTaoTamDanTruyenDanTamDanTieuChuan = a.TTTDCongHoRanh_CauTaoTamDanTruyenDanTamDanTieuChuan,
                                   TTTDCongHoRanh_CauTaoTamDanTruyenDanTamDanTieuChuan_Name = d.Ten,
                                   TTTDCongHoRanh_CDai = a.TTTDCongHoRanh_CDai ?? 0,
                                   TTTDCongHoRanh_CRong = a.TTTDCongHoRanh_CRong ?? 0,
                                   TTTDCongHoRanh_CCao = a.TTTDCongHoRanh_CCao ?? 0
                               }).Distinct().ToList();

                var result2 = (from a in context.DSNuocMua
                               join c in context.DSDanhMuc on a.ThongTinDuongTruyenDan_HinhThucTruyenDan equals c.Id into cGroup
                               from c in cGroup.DefaultIfEmpty()
                               join d in context.DSDanhMuc on a.TTTDCongHoRanh_CauTaoTamDanTruyenDan equals d.Id
                               join f in context.PhanLoaiTDanTDans on a.TTTDCongHoRanh_TenLoaiTamDanLoai02 equals f.Id
                               where c.Ten == "Rãnh bê tông" && d.Ten == "Có cốt thép" && a.TTTDCongHoRanh_SoLuong1 > 0
                               select new NuocMuaModel
                               {
                                   TTTDCongHoRanh_TenLoaiTamDanTieuChuan = a.TTTDCongHoRanh_TenLoaiTamDanLoai02,
                                   PhanLoaiTDanTDan_TenLoaiTamDanTieuChuan = f.TTTDCongHoRanh_TenLoaiTamDanTieuChuan ?? "",
                                   TTTDCongHoRanh_CauTaoTamDanTruyenDanTamDanTieuChuan = a.TTTDCongHoRanh_CauTaoTamDanTruyenDan,
                                   TTTDCongHoRanh_CauTaoTamDanTruyenDanTamDanTieuChuan_Name = d.Ten,
                                   TTTDCongHoRanh_CDai = a.TTTDCongHoRanh_CDai1 ?? 0,
                                   TTTDCongHoRanh_CRong = a.TTTDCongHoRanh_CRong1 ?? 0,
                                   TTTDCongHoRanh_CCao = a.TTTDCongHoRanh_CCao1 ?? 0
                               }).Distinct().ToList();

                result = result1.Concat(result2).Distinct().OrderBy(x => x.PhanLoaiTDanTDan_TenLoaiTamDanTieuChuan).ToList();

                return result;
            }
            catch (Exception)
            {

                throw new Exception("Lỗi khi tải dữ liệu");
            }
        }
    }
}
