//using DucAnhERP.Models;
//using DucAnhERP.Repository;
//using DucAnhERP.Services;


//namespace DucAnhERP.Helpers
//{
//    public class PhanLoaiHelper
//    {
//        IPhanLoaiHoGaRepository PhanLoaiHoGaRepository;
//        //Thêm tên theo bảng phân loại hố ga
//        public async Task<NuocMua> ThemTenTheoPL(NuocMua Input)
//        {
//            PhanLoaiHoGa searchData = new PhanLoaiHoGa
//            {
//                ThongTinChungHoGa_TenHoGaSauPhanLoai = Input.ThongTinChungHoGa_TenHoGaSauPhanLoai,
//                ThongTinChungHoGa_HinhThucHoGa = Input.ThongTinChungHoGa_HinhThucHoGa,
//                ThongTinChungHoGa_KetCauMuMo = Input.ThongTinChungHoGa_KetCauMuMo,
//                ThongTinChungHoGa_KetCauTuong = Input.ThongTinChungHoGa_KetCauTuong,
//                ThongTinChungHoGa_HinhThucMongHoGa = Input.ThongTinChungHoGa_HinhThucMongHoGa,
//                ThongTinChungHoGa_KetCauMong = Input.ThongTinChungHoGa_KetCauMong,
//                ThongTinChungHoGa_ChatMatTrong = Input.ThongTinChungHoGa_ChatMatTrong,
//                ThongTinChungHoGa_ChatMatNgoai = Input.ThongTinChungHoGa_ChatMatNgoai,
//                PhuBiHoGa_CDai = Input.PhuBiHoGa_CDai,
//                PhuBiHoGa_CRong = Input.PhuBiHoGa_CRong,
//                BeTongLotMong_D = Input.BeTongLotMong_D,
//                BeTongLotMong_R = Input.BeTongLotMong_R,
//                BeTongLotMong_C = Input.BeTongLotMong_C,
//                BeTongMongHoGa_D = Input.BeTongMongHoGa_D,
//                BeTongMongHoGa_R = Input.BeTongMongHoGa_R,
//                BeTongMongHoGa_C = Input.BeTongMongHoGa_C,
//                DeHoGa_D = Input.DeHoGa_D,
//                DeHoGa_R = Input.DeHoGa_R,
//                DeHoGa_C = Input.DeHoGa_C,
//                TuongHoGa_D = Input.TuongHoGa_D,
//                TuongHoGa_R = Input.TuongHoGa_R,
//                TuongHoGa_C = Input.TuongHoGa_C,
//                TuongHoGa_CdTuong = Input.TuongHoGa_CdTuong,
//                DamGiuaHoGa_D = Input.DamGiuaHoGa_D,
//                DamGiuaHoGa_R = Input.DamGiuaHoGa_R,
//                DamGiuaHoGa_C = Input.DamGiuaHoGa_C,
//                DamGiuaHoGa_CdDam = Input.DamGiuaHoGa_CdDam,
//                DamGiuaHoGa_CCaoDamGiuaTuongSoVoiDayHoGa = Input.DamGiuaHoGa_CCaoDamGiuaTuongSoVoiDayHoGa,
//                ChatMatTrong_D = Input.ChatMatTrong_D,
//                ChatMatTrong_R = Input.ChatMatTrong_R,
//                ChatMatTrong_C = Input.ChatMatTrong_C,
//                ChatMatNgoaiCanh_D = Input.ChatMatNgoaiCanh_D,
//                ChatMatNgoaiCanh_R = Input.ChatMatNgoaiCanh_R,
//                ChatMatNgoaiCanh_C = Input.ChatMatNgoaiCanh_C,
//                MuMoThotDuoi_D = Input.MuMoThotDuoi_D,
//                MuMoThotDuoi_R = Input.MuMoThotDuoi_R,
//                MuMoThotDuoi_C = Input.MuMoThotDuoi_C,
//                MuMoThotDuoi_CdTuong = Input.MuMoThotDuoi_CdTuong,
//                MuMoThotTren_D = Input.MuMoThotTren_D,
//                MuMoThotTren_R = Input.MuMoThotTren_R,
//                MuMoThotTren_C = Input.MuMoThotTren_C,
//                MuMoThotTren_CdTuong = Input.MuMoThotTren_CdTuong,
//                HinhThucDauNoi1_Loai = Input.HinhThucDauNoi1_Loai,
//                HinhThucDauNoi1_CanhDai = Input.HinhThucDauNoi1_CanhDai,
//                HinhThucDauNoi1_CanhRong = Input.HinhThucDauNoi1_CanhRong,
//                HinhThucDauNoi1_CanhCheo = Input.HinhThucDauNoi1_CanhCheo,
//                HinhThucDauNoi2_Loai = Input.HinhThucDauNoi2_Loai,
//                HinhThucDauNoi2_CanhDai = Input.HinhThucDauNoi2_CanhDai,
//                HinhThucDauNoi2_CanhRong = Input.HinhThucDauNoi2_CanhRong,
//                HinhThucDauNoi2_CanhCheo = Input.HinhThucDauNoi2_CanhCheo,
//                HinhThucDauNoi3_Loai = Input.HinhThucDauNoi3_Loai,
//                HinhThucDauNoi3_CanhDai = Input.HinhThucDauNoi3_CanhDai,
//                HinhThucDauNoi3_CanhRong = Input.HinhThucDauNoi3_CanhRong,
//                HinhThucDauNoi3_CanhCheo = Input.HinhThucDauNoi3_CanhCheo,
//                HinhThucDauNoi4_Loai = Input.HinhThucDauNoi4_Loai,
//                HinhThucDauNoi4_CanhDai = Input.HinhThucDauNoi4_CanhDai,
//                HinhThucDauNoi4_CanhRong = Input.HinhThucDauNoi4_CanhRong,
//                HinhThucDauNoi4_CanhCheo = Input.HinhThucDauNoi4_CanhCheo,
//                HinhThucDauNoi5_Loai = Input.HinhThucDauNoi5_Loai,
//                HinhThucDauNoi5_CanhDai = Input.HinhThucDauNoi5_CanhDai,
//                HinhThucDauNoi5_CanhRong = Input.HinhThucDauNoi5_CanhRong,
//                HinhThucDauNoi5_CanhCheo = Input.HinhThucDauNoi5_CanhCheo,
//                HinhThucDauNoi6_Loai = Input.HinhThucDauNoi6_Loai,
//                HinhThucDauNoi6_CanhDai = Input.HinhThucDauNoi6_CanhDai,
//                HinhThucDauNoi6_CanhRong = Input.HinhThucDauNoi6_CanhRong,
//                HinhThucDauNoi6_CanhCheo = Input.HinhThucDauNoi6_CanhCheo,
//                HinhThucDauNoi7_Loai = Input.HinhThucDauNoi7_Loai,
//                HinhThucDauNoi7_CanhDai = Input.HinhThucDauNoi7_CanhDai,
//                HinhThucDauNoi7_CanhRong = Input.HinhThucDauNoi7_CanhRong,
//                HinhThucDauNoi7_CanhCheo = Input.HinhThucDauNoi7_CanhCheo,
//                HinhThucDauNoi8_Loai = Input.HinhThucDauNoi8_Loai,
//                HinhThucDauNoi8_CanhDai = Input.HinhThucDauNoi8_CanhDai,
//                HinhThucDauNoi8_CanhRong = Input.HinhThucDauNoi8_CanhRong,
//                HinhThucDauNoi8_CanhCheo = Input.HinhThucDauNoi8_CanhCheo
//            };
//            var id = await PhanLoaiHoGaRepository.InsertId(searchData);
//            Input.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai = id;
//            return Input;
//        }

//        //Load tên theo phân loại hố ga
//        public async Task<NuocMua> LoadTenHoGaSauPhanLoai(NuocMua Input)
//        {
//            PhanLoaiHoGa searchData = new PhanLoaiHoGa
//            {
//                ThongTinChungHoGa_TenHoGaSauPhanLoai = Input.ThongTinChungHoGa_TenHoGaSauPhanLoai,
//                ThongTinChungHoGa_HinhThucHoGa = Input.ThongTinChungHoGa_HinhThucHoGa,
//                ThongTinChungHoGa_KetCauMuMo = Input.ThongTinChungHoGa_KetCauMuMo,
//                ThongTinChungHoGa_KetCauTuong = Input.ThongTinChungHoGa_KetCauTuong,
//                ThongTinChungHoGa_HinhThucMongHoGa = Input.ThongTinChungHoGa_HinhThucMongHoGa,
//                ThongTinChungHoGa_KetCauMong = Input.ThongTinChungHoGa_KetCauMong,
//                ThongTinChungHoGa_ChatMatTrong = Input.ThongTinChungHoGa_ChatMatTrong,
//                ThongTinChungHoGa_ChatMatNgoai = Input.ThongTinChungHoGa_ChatMatNgoai,
//                PhuBiHoGa_CDai = Input.PhuBiHoGa_CDai,
//                PhuBiHoGa_CRong = Input.PhuBiHoGa_CRong,
//                BeTongLotMong_D = Input.BeTongLotMong_D,
//                BeTongLotMong_R = Input.BeTongLotMong_R,
//                BeTongLotMong_C = Input.BeTongLotMong_C,
//                BeTongMongHoGa_D = Input.BeTongMongHoGa_D,
//                BeTongMongHoGa_R = Input.BeTongMongHoGa_R,
//                BeTongMongHoGa_C = Input.BeTongMongHoGa_C,
//                DeHoGa_D = Input.DeHoGa_D,
//                DeHoGa_R = Input.DeHoGa_R,
//                DeHoGa_C = Input.DeHoGa_C,
//                TuongHoGa_D = Input.TuongHoGa_D,
//                TuongHoGa_R = Input.TuongHoGa_R,
//                TuongHoGa_C = Input.TuongHoGa_C,
//                TuongHoGa_CdTuong = Input.TuongHoGa_CdTuong,
//                DamGiuaHoGa_D = Input.DamGiuaHoGa_D,
//                DamGiuaHoGa_R = Input.DamGiuaHoGa_R,
//                DamGiuaHoGa_C = Input.DamGiuaHoGa_C,
//                DamGiuaHoGa_CdDam = Input.DamGiuaHoGa_CdDam,
//                DamGiuaHoGa_CCaoDamGiuaTuongSoVoiDayHoGa = Input.DamGiuaHoGa_CCaoDamGiuaTuongSoVoiDayHoGa,
//                ChatMatTrong_D = Input.ChatMatTrong_D,
//                ChatMatTrong_R = Input.ChatMatTrong_R,
//                ChatMatTrong_C = Input.ChatMatTrong_C,
//                ChatMatNgoaiCanh_D = Input.ChatMatNgoaiCanh_D,
//                ChatMatNgoaiCanh_R = Input.ChatMatNgoaiCanh_R,
//                ChatMatNgoaiCanh_C = Input.ChatMatNgoaiCanh_C,
//                MuMoThotDuoi_D = Input.MuMoThotDuoi_D,
//                MuMoThotDuoi_R = Input.MuMoThotDuoi_R,
//                MuMoThotDuoi_C = Input.MuMoThotDuoi_C,
//                MuMoThotDuoi_CdTuong = Input.MuMoThotDuoi_CdTuong,
//                MuMoThotTren_D = Input.MuMoThotTren_D,
//                MuMoThotTren_R = Input.MuMoThotTren_R,
//                MuMoThotTren_C = Input.MuMoThotTren_C,
//                MuMoThotTren_CdTuong = Input.MuMoThotTren_CdTuong,
//                HinhThucDauNoi1_Loai = Input.HinhThucDauNoi1_Loai,
//                HinhThucDauNoi1_CanhDai = Input.HinhThucDauNoi1_CanhDai,
//                HinhThucDauNoi1_CanhRong = Input.HinhThucDauNoi1_CanhRong,
//                HinhThucDauNoi1_CanhCheo = Input.HinhThucDauNoi1_CanhCheo,
//                HinhThucDauNoi2_Loai = Input.HinhThucDauNoi2_Loai,
//                HinhThucDauNoi2_CanhDai = Input.HinhThucDauNoi2_CanhDai,
//                HinhThucDauNoi2_CanhRong = Input.HinhThucDauNoi2_CanhRong,
//                HinhThucDauNoi2_CanhCheo = Input.HinhThucDauNoi2_CanhCheo,
//                HinhThucDauNoi3_Loai = Input.HinhThucDauNoi3_Loai,
//                HinhThucDauNoi3_CanhDai = Input.HinhThucDauNoi3_CanhDai,
//                HinhThucDauNoi3_CanhRong = Input.HinhThucDauNoi3_CanhRong,
//                HinhThucDauNoi3_CanhCheo = Input.HinhThucDauNoi3_CanhCheo,
//                HinhThucDauNoi4_Loai = Input.HinhThucDauNoi4_Loai,
//                HinhThucDauNoi4_CanhDai = Input.HinhThucDauNoi4_CanhDai,
//                HinhThucDauNoi4_CanhRong = Input.HinhThucDauNoi4_CanhRong,
//                HinhThucDauNoi4_CanhCheo = Input.HinhThucDauNoi4_CanhCheo,
//                HinhThucDauNoi5_Loai = Input.HinhThucDauNoi5_Loai,
//                HinhThucDauNoi5_CanhDai = Input.HinhThucDauNoi5_CanhDai,
//                HinhThucDauNoi5_CanhRong = Input.HinhThucDauNoi5_CanhRong,
//                HinhThucDauNoi5_CanhCheo = Input.HinhThucDauNoi5_CanhCheo,
//                HinhThucDauNoi6_Loai = Input.HinhThucDauNoi6_Loai,
//                HinhThucDauNoi6_CanhDai = Input.HinhThucDauNoi6_CanhDai,
//                HinhThucDauNoi6_CanhRong = Input.HinhThucDauNoi6_CanhRong,
//                HinhThucDauNoi6_CanhCheo = Input.HinhThucDauNoi6_CanhCheo,
//                HinhThucDauNoi7_Loai = Input.HinhThucDauNoi7_Loai,
//                HinhThucDauNoi7_CanhDai = Input.HinhThucDauNoi7_CanhDai,
//                HinhThucDauNoi7_CanhRong = Input.HinhThucDauNoi7_CanhRong,
//                HinhThucDauNoi7_CanhCheo = Input.HinhThucDauNoi7_CanhCheo,
//                HinhThucDauNoi8_Loai = Input.HinhThucDauNoi8_Loai,
//                HinhThucDauNoi8_CanhDai = Input.HinhThucDauNoi8_CanhDai,
//                HinhThucDauNoi8_CanhRong = Input.HinhThucDauNoi8_CanhRong,
//                HinhThucDauNoi8_CanhCheo = Input.HinhThucDauNoi8_CanhCheo
//            };

//            PhanLoaiHoGa plHoGa = new();
//            plHoGa = await PhanLoaiHoGaRepository.GetMPhanLoaiHoGaByDetail(searchData);
//            if (plHoGa == null)
//            {
//                nuocMuaVM.PhanLoaiHoGas_TenHoGaSauPhanLoai = "";
//                Input.ThongTinChungHoGa_TenHoGaSauPhanLoai = "";
//            }
//            else
//            {
//                nuocMuaVM.PhanLoaiHoGas_TenHoGaSauPhanLoai = plHoGa.ThongTinChungHoGa_TenHoGaSauPhanLoai;
//                Input.ThongTinChungHoGa_TenHoGaSauPhanLoai = plHoGa.Id;
//            }
//            return Input;
//        }

//        //Thêm tên theo bảng phân loại tấm đan hố ga
//        public async Task ThemTenTheoPLTDHoGa()
//        {
//            PhanLoaiTDHoGa searchData = new PhanLoaiTDHoGa
//            {
//                ThongTinTamDanHoGa2_HinhThucDayHoGa = Input.ThongTinTamDanHoGa2_HinhThucDayHoGa,
//                ThongTinTamDanHoGa2_DuongKinh = Input.ThongTinTamDanHoGa2_DuongKinh,
//                ThongTinTamDanHoGa2_ChieuDay = Input.ThongTinTamDanHoGa2_ChieuDay,
//                ThongTinTamDanHoGa2_D = Input.ThongTinTamDanHoGa2_D,
//                ThongTinTamDanHoGa2_R = Input.ThongTinTamDanHoGa2_R,
//                ThongTinTamDanHoGa2_C = Input.ThongTinTamDanHoGa2_C

//            };

//            var id = await PhanLoaiTDHoGaRepository.InsertId(searchData, GetTenDanhMucById(searchData.ThongTinTamDanHoGa2_HinhThucDayHoGa));
//            Input.ThongTinTamDanHoGa2_PhanLoaiDayHoGa = id;
//        }

//        //Load tên theo phân loại tấm đan hố ga
//        public async Task LoadTenHoGaSauPhanLoaiTDHoGa()
//        {
//            PhanLoaiTDHoGa searchData = new PhanLoaiTDHoGa
//            {

//                ThongTinTamDanHoGa2_HinhThucDayHoGa = Input.ThongTinTamDanHoGa2_HinhThucDayHoGa,
//                ThongTinTamDanHoGa2_DuongKinh = Input.ThongTinTamDanHoGa2_DuongKinh,
//                ThongTinTamDanHoGa2_ChieuDay = Input.ThongTinTamDanHoGa2_ChieuDay,
//                ThongTinTamDanHoGa2_D = Input.ThongTinTamDanHoGa2_D,
//                ThongTinTamDanHoGa2_R = Input.ThongTinTamDanHoGa2_R,
//                ThongTinTamDanHoGa2_C = Input.ThongTinTamDanHoGa2_C
//            };

//            PhanLoaiTDHoGa plTDHoGa = new();
//            plTDHoGa = await PhanLoaiTDHoGaRepository.GetMPhanLoaiTDHoGaByDetail(searchData);
//            if (plTDHoGa == null)
//            {
//                nuocMuaVM.PhanLoaiTDHoGa_PhanLoaiDayHoGa = "";
//                Input.ThongTinTamDanHoGa2_PhanLoaiDayHoGa = "";
//            }
//            else
//            {
//                nuocMuaVM.PhanLoaiTDHoGa_PhanLoaiDayHoGa = plTDHoGa.ThongTinTamDanHoGa2_PhanLoaiDayHoGa;
//                Input.ThongTinTamDanHoGa2_PhanLoaiDayHoGa = plTDHoGa.Id;
//            }

//        }

//        //Thêm tên theo bảng phân loại cống hộp cống tròn nhựa
//        public async Task ThemTenTheoPLCTronHopNhua()
//        {
//            PhanLoaiCTronHopNhua searchData = new PhanLoaiCTronHopNhua
//            {
//                ThongTinDuongTruyenDan_HinhThucTruyenDan = Input.ThongTinDuongTruyenDan_HinhThucTruyenDan,
//                ThongTinDuongTruyenDan_LoaiTruyenDan = Input.ThongTinDuongTruyenDan_LoaiTruyenDan,
//                TTCDSLCauKienDuongTruyenDan_ChieuDai01CauKien = Input.TTCDSLCauKienDuongTruyenDan_ChieuDai01CauKien,
//                ThongTinCauTaoCongTron_CDayPhuBi = Input.ThongTinCauTaoCongTron_CDayPhuBi,
//                TTKTHHCongHopRanh_CauTaoTuong = Input.TTKTHHCongHopRanh_CauTaoTuong,
//                TTKTHHCongHopRanh_ChatMatTrong = Input.TTKTHHCongHopRanh_ChatMatTrong,
//                TTKTHHCongHopRanh_ChatMatNgoai = Input.TTKTHHCongHopRanh_ChatMatNgoai,
//                TTKTHHCongHopRanh_CCaoDe = Input.TTKTHHCongHopRanh_CCaoDe,
//                TTKTHHCongHopRanh_CRongDe = Input.TTKTHHCongHopRanh_CRongDe,
//                TTKTHHCongHopRanh_CDayTuong01Ben = Input.TTKTHHCongHopRanh_CDayTuong01Ben,
//                TTKTHHCongHopRanh_SoLuongTuong = Input.TTKTHHCongHopRanh_SoLuongTuong,
//                TTKTHHCongHopRanh_CRongLongSuDung = Input.TTKTHHCongHopRanh_CRongLongSuDung,
//                TTKTHHCongHopRanh_CCaoTuongGop = Input.TTKTHHCongHopRanh_CCaoTuongGop,
//                TTKTHHCongHopRanh_CCaoMuMoThotDuoi = Input.TTKTHHCongHopRanh_CCaoMuMoThotDuoi,
//                TTKTHHCongHopRanh_CRongMuMoDuoi = Input.TTKTHHCongHopRanh_CRongMuMoDuoi,
//                TTKTHHCongHopRanh_CCaoMuMoThotTren = Input.TTKTHHCongHopRanh_CCaoMuMoThotTren,
//                TTKTHHCongHopRanh_CRongMuMoTren = Input.TTKTHHCongHopRanh_CRongMuMoTren,
//                TTKTHHCongHopRanh_CCaoChatMatTrong = Input.TTKTHHCongHopRanh_CCaoChatMatTrong,
//                ThongTinKichThuocHinhHocOngNhua_CDayPhuBi = Input.ThongTinKichThuocHinhHocOngNhua_CDayPhuBi,

//            };

//            var id = await PhanLoaiCTronHopNhuaRepository.InsertId(searchData, GetTenDanhMucById(searchData.ThongTinDuongTruyenDan_HinhThucTruyenDan), GetTenDanhMucById(searchData.ThongTinDuongTruyenDan_LoaiTruyenDan));
//            Input.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai = id;
//        }

//        //Load tên theo phân loại móng cống tròn
//        public async Task LoadTenPLCTronHopNhua()
//        {
//            PhanLoaiCTronHopNhua searchData = new PhanLoaiCTronHopNhua
//            {
//                ThongTinDuongTruyenDan_HinhThucTruyenDan = Input.ThongTinDuongTruyenDan_HinhThucTruyenDan,
//                ThongTinDuongTruyenDan_LoaiTruyenDan = Input.ThongTinDuongTruyenDan_LoaiTruyenDan,
//                TTCDSLCauKienDuongTruyenDan_ChieuDai01CauKien = Input.TTCDSLCauKienDuongTruyenDan_ChieuDai01CauKien,
//                ThongTinCauTaoCongTron_CDayPhuBi = Input.ThongTinCauTaoCongTron_CDayPhuBi,
//                TTKTHHCongHopRanh_CauTaoTuong = Input.TTKTHHCongHopRanh_CauTaoTuong,
//                TTKTHHCongHopRanh_ChatMatTrong = Input.TTKTHHCongHopRanh_ChatMatTrong,
//                TTKTHHCongHopRanh_ChatMatNgoai = Input.TTKTHHCongHopRanh_ChatMatNgoai,
//                TTKTHHCongHopRanh_CCaoDe = Input.TTKTHHCongHopRanh_CCaoDe,
//                TTKTHHCongHopRanh_CRongDe = Input.TTKTHHCongHopRanh_CRongDe,
//                TTKTHHCongHopRanh_CDayTuong01Ben = Input.TTKTHHCongHopRanh_CDayTuong01Ben,
//                TTKTHHCongHopRanh_SoLuongTuong = Input.TTKTHHCongHopRanh_SoLuongTuong,
//                TTKTHHCongHopRanh_CRongLongSuDung = Input.TTKTHHCongHopRanh_CRongLongSuDung,
//                TTKTHHCongHopRanh_CCaoTuongGop = Input.TTKTHHCongHopRanh_CCaoTuongGop,
//                TTKTHHCongHopRanh_CCaoMuMoThotDuoi = Input.TTKTHHCongHopRanh_CCaoMuMoThotDuoi,
//                TTKTHHCongHopRanh_CRongMuMoDuoi = Input.TTKTHHCongHopRanh_CRongMuMoDuoi,
//                TTKTHHCongHopRanh_CCaoMuMoThotTren = Input.TTKTHHCongHopRanh_CCaoMuMoThotTren,
//                TTKTHHCongHopRanh_CRongMuMoTren = Input.TTKTHHCongHopRanh_CRongMuMoTren,
//                TTKTHHCongHopRanh_CCaoChatMatTrong = Input.TTKTHHCongHopRanh_CCaoChatMatTrong,
//                ThongTinKichThuocHinhHocOngNhua_CDayPhuBi = Input.ThongTinKichThuocHinhHocOngNhua_CDayPhuBi,

//            };

//            PhanLoaiCTronHopNhua plCTHNHoGa = new();
//            plCTHNHoGa = await PhanLoaiCTronHopNhuaRepository.GetMPhanLoaiCTronHopNhuaByDetail(searchData);
//            if (plCTHNHoGa == null)
//            {
//                nuocMuaVM.PhanLoaiCTronHopNhua_TenLoaiTruyenDanSauPhanLoai = "";
//                Input.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai = "";
//            }
//            else
//            {
//                nuocMuaVM.PhanLoaiCTronHopNhua_TenLoaiTruyenDanSauPhanLoai = plCTHNHoGa.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai;
//                Input.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai = plCTHNHoGa.Id;
//            }

//        }

//        //Thêm tên theo bảng phân loại cống hộp cống tròn nhựa
//        public async Task ThemTenTheoPLMongCTron()
//        {
//            PhanLoaiMongCTron searchData = new PhanLoaiMongCTron
//            {
//                ThongTinDuongTruyenDan_HinhThucTruyenDan = Input.ThongTinDuongTruyenDan_HinhThucTruyenDan,
//                ThongTinDuongTruyenDan_LoaiTruyenDan = Input.ThongTinDuongTruyenDan_LoaiTruyenDan,
//                ThongTinMongDuongTruyenDan_LoaiMong = Input.ThongTinMongDuongTruyenDan_LoaiMong,
//                ThongTinMongDuongTruyenDan_HinhThucMong = Input.ThongTinMongDuongTruyenDan_HinhThucMong,
//                ThongTinCauTaoCongTron_CCaoLotMong = Input.ThongTinCauTaoCongTron_CCaoLotMong,
//                ThongTinCauTaoCongTron_CRongLotMong = Input.ThongTinCauTaoCongTron_CRongLotMong,
//                ThongTinCauTaoCongTron_CCaoMong = Input.ThongTinCauTaoCongTron_CCaoMong,
//                ThongTinCauTaoCongTron_CRongMong = Input.ThongTinCauTaoCongTron_CRongMong,

//            };

//            var id = await PhanLoaiMongCTronRepository.InsertId(searchData, GetTenDanhMucById(searchData.ThongTinMongDuongTruyenDan_LoaiMong), GetTenDanhMucById(searchData.ThongTinMongDuongTruyenDan_HinhThucMong), GetTenDanhMucById(searchData.ThongTinDuongTruyenDan_LoaiTruyenDan));
//            Input.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai = id;
//        }

//        //Load tên theo phân loại móng cống tròn 
//        public async Task LoadTenPhanLoaiMongCTron()
//        {
//            PhanLoaiMongCTron searchData = new PhanLoaiMongCTron
//            {
//                ThongTinDuongTruyenDan_HinhThucTruyenDan = Input.ThongTinDuongTruyenDan_HinhThucTruyenDan,
//                ThongTinDuongTruyenDan_LoaiTruyenDan = Input.ThongTinDuongTruyenDan_LoaiTruyenDan,
//                ThongTinMongDuongTruyenDan_LoaiMong = Input.ThongTinMongDuongTruyenDan_LoaiMong,
//                ThongTinMongDuongTruyenDan_HinhThucMong = Input.ThongTinMongDuongTruyenDan_HinhThucMong,
//                ThongTinCauTaoCongTron_CCaoLotMong = Input.ThongTinCauTaoCongTron_CCaoLotMong,
//                ThongTinCauTaoCongTron_CRongLotMong = Input.ThongTinCauTaoCongTron_CRongLotMong,
//                ThongTinCauTaoCongTron_CCaoMong = Input.ThongTinCauTaoCongTron_CCaoMong,
//                ThongTinCauTaoCongTron_CRongMong = Input.ThongTinCauTaoCongTron_CRongMong,
//            };

//            PhanLoaiMongCTron plMCT = new();
//            plMCT = await PhanLoaiMongCTronRepository.GetMPhanLoaiMongCTronByDetail(searchData);
//            if (plMCT == null)
//            {
//                nuocMuaVM.PhanLoaiMongCTron_PhanLoaiMongCongTronCongHop = "";
//                Input.ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop = "";
//            }
//            else
//            {
//                nuocMuaVM.PhanLoaiMongCTron_PhanLoaiMongCongTronCongHop = plMCT.ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop;
//                Input.ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop = plMCT.Id;
//            }

//        }

//        //Thêm tên theo bảng phân loại đế cống
//        public async Task ThemTenTheoPLDeCong()
//        {
//            PhanLoaiDeCong searchData = new PhanLoaiDeCong
//            {
//                ThongTinDuongTruyenDan_LoaiTruyenDan = Input.ThongTinDuongTruyenDan_LoaiTruyenDan,
//                ThongTinDeCong_CauTaoDeCong = Input.ThongTinDeCong_CauTaoDeCong,
//                ThongTinDeCong_D = Input.ThongTinDeCong_D,
//                ThongTinDeCong_R = Input.ThongTinDeCong_R,
//                ThongTinDeCong_C = Input.ThongTinDeCong_C,
//            };

//            var id = await PhanLoaiDeCongRepository.InsertId(searchData, GetTenDanhMucById(searchData.ThongTinDeCong_CauTaoDeCong), GetTenDanhMucById(searchData.ThongTinDuongTruyenDan_LoaiTruyenDan));
//            Input.ThongTinDeCong_TenLoaiDeCong = id;
//        }

//        //Load tên theo phân loại đế cống
//        public async Task LoadTenPhanLoaiDeCong()
//        {
//            PhanLoaiDeCong searchData = new PhanLoaiDeCong
//            {
//                ThongTinDuongTruyenDan_LoaiTruyenDan = Input.ThongTinDuongTruyenDan_LoaiTruyenDan,
//                ThongTinDeCong_CauTaoDeCong = Input.ThongTinDeCong_CauTaoDeCong,
//                ThongTinDeCong_D = Input.ThongTinDeCong_D,
//                ThongTinDeCong_R = Input.ThongTinDeCong_R,
//                ThongTinDeCong_C = Input.ThongTinDeCong_C,
//            };

//            PhanLoaiDeCong plDC = new();
//            plDC = await PhanLoaiDeCongRepository.GetMPhanLoaiDeCongByDetail(searchData);
//            if (plDC == null)
//            {
//                nuocMuaVM.PhanLoaiDeCong_TenLoaiDeCong = "";
//                Input.ThongTinDeCong_TenLoaiDeCong = "";
//            }
//            else
//            {
//                nuocMuaVM.PhanLoaiDeCong_TenLoaiDeCong = plDC.ThongTinDeCong_TenLoaiDeCong;
//                Input.ThongTinDeCong_TenLoaiDeCong = plDC.Id;
//            }

//        }
//    }
//}
