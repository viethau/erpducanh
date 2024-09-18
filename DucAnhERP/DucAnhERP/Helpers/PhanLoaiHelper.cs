using DucAnhERP.Components.Pages.NghiepVuCongTrinh;
using DucAnhERP.Models;
using DucAnhERP.Repository;
using DucAnhERP.Services;


namespace DucAnhERP.Helpers
{
    public class PhanLoaiHelper
    {
        PhanLoai phanloai =new();
        public List<DanhMuc> listDanhMuc = new();
        IPhanLoaiHoGaRepository PhanLoaiHoGaRepository;
        IPhanLoaiTDHoGaRepository PhanLoaiTDHoGaRepository;
        IPhanLoaiCTronHopNhuaRepository PhanLoaiCTronHopNhuaRepository;
        IPhanLoaiMongCTronRepository PhanLoaiMongCTronRepository;
        IPhanLoaiDeCongRepository PhanLoaiDeCongRepository;
        IPhanLoaiTDanTDanRepository PhanLoaiTDanTDanRepository;
        IPhanLoaiThanhChongRepository PhanLoaiThanhChongRepository;

        public string GetTenDanhMucById(string id)
        {
            var danhMuc = listDanhMuc.FirstOrDefault(dm => dm.Id == id);
            return danhMuc != null ? danhMuc.Ten : null;
        }

        //Thêm tên theo bảng phân loại hố ga
        public async Task<string> ThemTenTheoPL(NuocMua Input)
        {
            var id = "";
            PhanLoaiHoGa searchData = new PhanLoaiHoGa
            {
                ThongTinChungHoGa_TenHoGaSauPhanLoai = Input.ThongTinChungHoGa_TenHoGaSauPhanLoai,
                ThongTinChungHoGa_HinhThucHoGa = Input.ThongTinChungHoGa_HinhThucHoGa,
                ThongTinChungHoGa_KetCauMuMo = Input.ThongTinChungHoGa_KetCauMuMo,
                ThongTinChungHoGa_KetCauTuong = Input.ThongTinChungHoGa_KetCauTuong,
                ThongTinChungHoGa_HinhThucMongHoGa = Input.ThongTinChungHoGa_HinhThucMongHoGa,
                ThongTinChungHoGa_KetCauMong = Input.ThongTinChungHoGa_KetCauMong,
                ThongTinChungHoGa_ChatMatTrong = Input.ThongTinChungHoGa_ChatMatTrong,
                ThongTinChungHoGa_ChatMatNgoai = Input.ThongTinChungHoGa_ChatMatNgoai,
                PhuBiHoGa_CDai = Input.PhuBiHoGa_CDai,
                PhuBiHoGa_CRong = Input.PhuBiHoGa_CRong,
                BeTongLotMong_D = Input.BeTongLotMong_D,
                BeTongLotMong_R = Input.BeTongLotMong_R,
                BeTongLotMong_C = Input.BeTongLotMong_C,
                BeTongMongHoGa_D = Input.BeTongMongHoGa_D,
                BeTongMongHoGa_R = Input.BeTongMongHoGa_R,
                BeTongMongHoGa_C = Input.BeTongMongHoGa_C,
                DeHoGa_D = Input.DeHoGa_D,
                DeHoGa_R = Input.DeHoGa_R,
                DeHoGa_C = Input.DeHoGa_C,
                TuongHoGa_D = Input.TuongHoGa_D,
                TuongHoGa_R = Input.TuongHoGa_R,
                TuongHoGa_C = Input.TuongHoGa_C,
                TuongHoGa_CdTuong = Input.TuongHoGa_CdTuong,
                DamGiuaHoGa_D = Input.DamGiuaHoGa_D,
                DamGiuaHoGa_R = Input.DamGiuaHoGa_R,
                DamGiuaHoGa_C = Input.DamGiuaHoGa_C,
                DamGiuaHoGa_CdDam = Input.DamGiuaHoGa_CdDam,
                DamGiuaHoGa_CCaoDamGiuaTuongSoVoiDayHoGa = Input.DamGiuaHoGa_CCaoDamGiuaTuongSoVoiDayHoGa,
                ChatMatTrong_D = Input.ChatMatTrong_D,
                ChatMatTrong_R = Input.ChatMatTrong_R,
                ChatMatTrong_C = Input.ChatMatTrong_C,
                ChatMatNgoaiCanh_D = Input.ChatMatNgoaiCanh_D,
                ChatMatNgoaiCanh_R = Input.ChatMatNgoaiCanh_R,
                ChatMatNgoaiCanh_C = Input.ChatMatNgoaiCanh_C,
                MuMoThotDuoi_D = Input.MuMoThotDuoi_D,
                MuMoThotDuoi_R = Input.MuMoThotDuoi_R,
                MuMoThotDuoi_C = Input.MuMoThotDuoi_C,
                MuMoThotDuoi_CdTuong = Input.MuMoThotDuoi_CdTuong,
                MuMoThotTren_D = Input.MuMoThotTren_D,
                MuMoThotTren_R = Input.MuMoThotTren_R,
                MuMoThotTren_C = Input.MuMoThotTren_C,
                MuMoThotTren_CdTuong = Input.MuMoThotTren_CdTuong,
                HinhThucDauNoi1_Loai = Input.HinhThucDauNoi1_Loai,
                HinhThucDauNoi1_CanhDai = Input.HinhThucDauNoi1_CanhDai,
                HinhThucDauNoi1_CanhRong = Input.HinhThucDauNoi1_CanhRong,
                HinhThucDauNoi1_CanhCheo = Input.HinhThucDauNoi1_CanhCheo,
                HinhThucDauNoi2_Loai = Input.HinhThucDauNoi2_Loai,
                HinhThucDauNoi2_CanhDai = Input.HinhThucDauNoi2_CanhDai,
                HinhThucDauNoi2_CanhRong = Input.HinhThucDauNoi2_CanhRong,
                HinhThucDauNoi2_CanhCheo = Input.HinhThucDauNoi2_CanhCheo,
                HinhThucDauNoi3_Loai = Input.HinhThucDauNoi3_Loai,
                HinhThucDauNoi3_CanhDai = Input.HinhThucDauNoi3_CanhDai,
                HinhThucDauNoi3_CanhRong = Input.HinhThucDauNoi3_CanhRong,
                HinhThucDauNoi3_CanhCheo = Input.HinhThucDauNoi3_CanhCheo,
                HinhThucDauNoi4_Loai = Input.HinhThucDauNoi4_Loai,
                HinhThucDauNoi4_CanhDai = Input.HinhThucDauNoi4_CanhDai,
                HinhThucDauNoi4_CanhRong = Input.HinhThucDauNoi4_CanhRong,
                HinhThucDauNoi4_CanhCheo = Input.HinhThucDauNoi4_CanhCheo,
                HinhThucDauNoi5_Loai = Input.HinhThucDauNoi5_Loai,
                HinhThucDauNoi5_CanhDai = Input.HinhThucDauNoi5_CanhDai,
                HinhThucDauNoi5_CanhRong = Input.HinhThucDauNoi5_CanhRong,
                HinhThucDauNoi5_CanhCheo = Input.HinhThucDauNoi5_CanhCheo,
                HinhThucDauNoi6_Loai = Input.HinhThucDauNoi6_Loai,
                HinhThucDauNoi6_CanhDai = Input.HinhThucDauNoi6_CanhDai,
                HinhThucDauNoi6_CanhRong = Input.HinhThucDauNoi6_CanhRong,
                HinhThucDauNoi6_CanhCheo = Input.HinhThucDauNoi6_CanhCheo,
                HinhThucDauNoi7_Loai = Input.HinhThucDauNoi7_Loai,
                HinhThucDauNoi7_CanhDai = Input.HinhThucDauNoi7_CanhDai,
                HinhThucDauNoi7_CanhRong = Input.HinhThucDauNoi7_CanhRong,
                HinhThucDauNoi7_CanhCheo = Input.HinhThucDauNoi7_CanhCheo,
                HinhThucDauNoi8_Loai = Input.HinhThucDauNoi8_Loai,
                HinhThucDauNoi8_CanhDai = Input.HinhThucDauNoi8_CanhDai,
                HinhThucDauNoi8_CanhRong = Input.HinhThucDauNoi8_CanhRong,
                HinhThucDauNoi8_CanhCheo = Input.HinhThucDauNoi8_CanhCheo
            };

            CheckObjHelper checkObjhelper = new();
            if (checkObjhelper.AreAllDoublePropertiesGreaterThanZero(searchData))
            {
                id = await PhanLoaiHoGaRepository.InsertId(searchData,Input.ThongTinChungHoGa_TenHoGaTheoBanVe);
                Input.ThongTinChungHoGa_TenHoGaSauPhanLoai = id;
            }
            return id;
        }

        //Load tên theo phân loại hố ga
        public async Task<PhanLoai> LoadTenHoGaSauPhanLoai(NuocMua Input )
        {
            try
            {
                PhanLoaiHoGa searchData = new PhanLoaiHoGa
                {
                    ThongTinChungHoGa_TenHoGaSauPhanLoai = Input.ThongTinChungHoGa_TenHoGaSauPhanLoai,
                    ThongTinChungHoGa_HinhThucHoGa = Input.ThongTinChungHoGa_HinhThucHoGa,
                    ThongTinChungHoGa_KetCauMuMo = Input.ThongTinChungHoGa_KetCauMuMo,
                    ThongTinChungHoGa_KetCauTuong = Input.ThongTinChungHoGa_KetCauTuong,
                    ThongTinChungHoGa_HinhThucMongHoGa = Input.ThongTinChungHoGa_HinhThucMongHoGa,
                    ThongTinChungHoGa_KetCauMong = Input.ThongTinChungHoGa_KetCauMong,
                    ThongTinChungHoGa_ChatMatTrong = Input.ThongTinChungHoGa_ChatMatTrong,
                    ThongTinChungHoGa_ChatMatNgoai = Input.ThongTinChungHoGa_ChatMatNgoai,
                    PhuBiHoGa_CDai = Input.PhuBiHoGa_CDai,
                    PhuBiHoGa_CRong = Input.PhuBiHoGa_CRong,
                    BeTongLotMong_D = Input.BeTongLotMong_D,
                    BeTongLotMong_R = Input.BeTongLotMong_R,
                    BeTongLotMong_C = Input.BeTongLotMong_C,
                    BeTongMongHoGa_D = Input.BeTongMongHoGa_D,
                    BeTongMongHoGa_R = Input.BeTongMongHoGa_R,
                    BeTongMongHoGa_C = Input.BeTongMongHoGa_C,
                    DeHoGa_D = Input.DeHoGa_D,
                    DeHoGa_R = Input.DeHoGa_R,
                    DeHoGa_C = Input.DeHoGa_C,
                    TuongHoGa_D = Input.TuongHoGa_D,
                    TuongHoGa_R = Input.TuongHoGa_R,
                    TuongHoGa_C = Input.TuongHoGa_C,
                    TuongHoGa_CdTuong = Input.TuongHoGa_CdTuong,
                    DamGiuaHoGa_D = Input.DamGiuaHoGa_D,
                    DamGiuaHoGa_R = Input.DamGiuaHoGa_R,
                    DamGiuaHoGa_C = Input.DamGiuaHoGa_C,
                    DamGiuaHoGa_CdDam = Input.DamGiuaHoGa_CdDam,
                    DamGiuaHoGa_CCaoDamGiuaTuongSoVoiDayHoGa = Input.DamGiuaHoGa_CCaoDamGiuaTuongSoVoiDayHoGa,
                    ChatMatTrong_D = Input.ChatMatTrong_D,
                    ChatMatTrong_R = Input.ChatMatTrong_R,
                    ChatMatTrong_C = Input.ChatMatTrong_C,
                    ChatMatNgoaiCanh_D = Input.ChatMatNgoaiCanh_D,
                    ChatMatNgoaiCanh_R = Input.ChatMatNgoaiCanh_R,
                    ChatMatNgoaiCanh_C = Input.ChatMatNgoaiCanh_C,
                    MuMoThotDuoi_D = Input.MuMoThotDuoi_D,
                    MuMoThotDuoi_R = Input.MuMoThotDuoi_R,
                    MuMoThotDuoi_C = Input.MuMoThotDuoi_C,
                    MuMoThotDuoi_CdTuong = Input.MuMoThotDuoi_CdTuong,
                    MuMoThotTren_D = Input.MuMoThotTren_D,
                    MuMoThotTren_R = Input.MuMoThotTren_R,
                    MuMoThotTren_C = Input.MuMoThotTren_C,
                    MuMoThotTren_CdTuong = Input.MuMoThotTren_CdTuong,
                    HinhThucDauNoi1_Loai = Input.HinhThucDauNoi1_Loai,
                    HinhThucDauNoi1_CanhDai = Input.HinhThucDauNoi1_CanhDai,
                    HinhThucDauNoi1_CanhRong = Input.HinhThucDauNoi1_CanhRong,
                    HinhThucDauNoi1_CanhCheo = Input.HinhThucDauNoi1_CanhCheo,
                    HinhThucDauNoi2_Loai = Input.HinhThucDauNoi2_Loai,
                    HinhThucDauNoi2_CanhDai = Input.HinhThucDauNoi2_CanhDai,
                    HinhThucDauNoi2_CanhRong = Input.HinhThucDauNoi2_CanhRong,
                    HinhThucDauNoi2_CanhCheo = Input.HinhThucDauNoi2_CanhCheo,
                    HinhThucDauNoi3_Loai = Input.HinhThucDauNoi3_Loai,
                    HinhThucDauNoi3_CanhDai = Input.HinhThucDauNoi3_CanhDai,
                    HinhThucDauNoi3_CanhRong = Input.HinhThucDauNoi3_CanhRong,
                    HinhThucDauNoi3_CanhCheo = Input.HinhThucDauNoi3_CanhCheo,
                    HinhThucDauNoi4_Loai = Input.HinhThucDauNoi4_Loai,
                    HinhThucDauNoi4_CanhDai = Input.HinhThucDauNoi4_CanhDai,
                    HinhThucDauNoi4_CanhRong = Input.HinhThucDauNoi4_CanhRong,
                    HinhThucDauNoi4_CanhCheo = Input.HinhThucDauNoi4_CanhCheo,
                    HinhThucDauNoi5_Loai = Input.HinhThucDauNoi5_Loai,
                    HinhThucDauNoi5_CanhDai = Input.HinhThucDauNoi5_CanhDai,
                    HinhThucDauNoi5_CanhRong = Input.HinhThucDauNoi5_CanhRong,
                    HinhThucDauNoi5_CanhCheo = Input.HinhThucDauNoi5_CanhCheo,
                    HinhThucDauNoi6_Loai = Input.HinhThucDauNoi6_Loai,
                    HinhThucDauNoi6_CanhDai = Input.HinhThucDauNoi6_CanhDai,
                    HinhThucDauNoi6_CanhRong = Input.HinhThucDauNoi6_CanhRong,
                    HinhThucDauNoi6_CanhCheo = Input.HinhThucDauNoi6_CanhCheo,
                    HinhThucDauNoi7_Loai = Input.HinhThucDauNoi7_Loai,
                    HinhThucDauNoi7_CanhDai = Input.HinhThucDauNoi7_CanhDai,
                    HinhThucDauNoi7_CanhRong = Input.HinhThucDauNoi7_CanhRong,
                    HinhThucDauNoi7_CanhCheo = Input.HinhThucDauNoi7_CanhCheo,
                    HinhThucDauNoi8_Loai = Input.HinhThucDauNoi8_Loai,
                    HinhThucDauNoi8_CanhDai = Input.HinhThucDauNoi8_CanhDai,
                    HinhThucDauNoi8_CanhRong = Input.HinhThucDauNoi8_CanhRong,
                    HinhThucDauNoi8_CanhCheo = Input.HinhThucDauNoi8_CanhCheo
                };

                PhanLoaiHoGa plHoGa = new();
                plHoGa = await PhanLoaiHoGaRepository.GetPhanLoaiHoGaByDetail(searchData);
                if (plHoGa != null)
                {
                    phanloai.Name = plHoGa.ThongTinChungHoGa_TenHoGaSauPhanLoai;
                    phanloai.Id = plHoGa.Id;
                }

                return phanloai;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }

        //Thêm tên theo bảng phân loại tấm đan hố ga
        public async Task<string> ThemTenTheoPLTDHoGa(NuocMua Input, List<DanhMuc> listDanhMuc)
        {
            var id = "";
            PhanLoaiTDHoGa searchData = new PhanLoaiTDHoGa
            {
                ThongTinTamDanHoGa2_HinhThucDayHoGa = Input.ThongTinTamDanHoGa2_HinhThucDayHoGa,
                ThongTinTamDanHoGa2_DuongKinh = Input.ThongTinTamDanHoGa2_DuongKinh,
                ThongTinTamDanHoGa2_ChieuDay = Input.ThongTinTamDanHoGa2_ChieuDay,
                ThongTinTamDanHoGa2_D = Input.ThongTinTamDanHoGa2_D,
                ThongTinTamDanHoGa2_R = Input.ThongTinTamDanHoGa2_R,
                ThongTinTamDanHoGa2_C = Input.ThongTinTamDanHoGa2_C

            };
            CheckObjHelper checkObjhelper = new();
            if (checkObjhelper.AreAllDoublePropertiesGreaterThanZero(searchData))
            {
                id = await PhanLoaiTDHoGaRepository.InsertId(searchData, GetTenDanhMucById(searchData.ThongTinTamDanHoGa2_HinhThucDayHoGa));
               
            }
            return id;

        }

        //Load tên theo phân loại tấm đan hố ga
        public async Task<PhanLoai> LoadTenHoGaSauPhanLoaiTDHoGa(NuocMua Input)
        {
            PhanLoaiTDHoGa searchData = new PhanLoaiTDHoGa
            {

                ThongTinTamDanHoGa2_HinhThucDayHoGa = Input.ThongTinTamDanHoGa2_HinhThucDayHoGa,
                ThongTinTamDanHoGa2_DuongKinh = Input.ThongTinTamDanHoGa2_DuongKinh,
                ThongTinTamDanHoGa2_ChieuDay = Input.ThongTinTamDanHoGa2_ChieuDay,
                ThongTinTamDanHoGa2_D = Input.ThongTinTamDanHoGa2_D,
                ThongTinTamDanHoGa2_R = Input.ThongTinTamDanHoGa2_R,
                ThongTinTamDanHoGa2_C = Input.ThongTinTamDanHoGa2_C
            };

            PhanLoaiTDHoGa plTDHoGa = new();
            plTDHoGa = await PhanLoaiTDHoGaRepository.GetPhanLoaiTDHoGaByDetail(searchData);
            if (plTDHoGa != null)
            {
                phanloai.Id = plTDHoGa.Id;
                phanloai.Name = plTDHoGa.ThongTinTamDanHoGa2_PhanLoaiDayHoGa;
            }
            return phanloai;

        }

        //Thêm tên theo bảng phân loại cống hộp cống tròn nhựa
        public async Task<string> ThemTenTheoPLCTronHopNhua(NuocMua Input , List<DanhMuc> listDanhMuc)
        {
            PhanLoaiCTronHopNhua searchData = new PhanLoaiCTronHopNhua
            {
                ThongTinDuongTruyenDan_HinhThucTruyenDan = Input.ThongTinDuongTruyenDan_HinhThucTruyenDan,
                ThongTinDuongTruyenDan_LoaiTruyenDan = Input.ThongTinDuongTruyenDan_LoaiTruyenDan,
                TTCDSLCauKienDuongTruyenDan_ChieuDai01CauKien = Input.TTCDSLCauKienDuongTruyenDan_ChieuDai01CauKien,
                ThongTinCauTaoCongTron_CDayPhuBi = Input.ThongTinCauTaoCongTron_CDayPhuBi,
                TTKTHHCongHopRanh_CauTaoTuong = Input.TTKTHHCongHopRanh_CauTaoTuong,
                TTKTHHCongHopRanh_ChatMatTrong = Input.TTKTHHCongHopRanh_ChatMatTrong,
                TTKTHHCongHopRanh_ChatMatNgoai = Input.TTKTHHCongHopRanh_ChatMatNgoai,
                TTKTHHCongHopRanh_CCaoDe = Input.TTKTHHCongHopRanh_CCaoDe,
                TTKTHHCongHopRanh_CRongDe = Input.TTKTHHCongHopRanh_CRongDe,
                TTKTHHCongHopRanh_CDayTuong01Ben = Input.TTKTHHCongHopRanh_CDayTuong01Ben,
                TTKTHHCongHopRanh_SoLuongTuong = Input.TTKTHHCongHopRanh_SoLuongTuong,
                TTKTHHCongHopRanh_CRongLongSuDung = Input.TTKTHHCongHopRanh_CRongLongSuDung,
                TTKTHHCongHopRanh_CCaoTuongGop = Input.TTKTHHCongHopRanh_CCaoTuongGop,
                TTKTHHCongHopRanh_CCaoMuMoThotDuoi = Input.TTKTHHCongHopRanh_CCaoMuMoThotDuoi,
                TTKTHHCongHopRanh_CRongMuMoDuoi = Input.TTKTHHCongHopRanh_CRongMuMoDuoi,
                TTKTHHCongHopRanh_CCaoMuMoThotTren = Input.TTKTHHCongHopRanh_CCaoMuMoThotTren,
                TTKTHHCongHopRanh_CRongMuMoTren = Input.TTKTHHCongHopRanh_CRongMuMoTren,
                TTKTHHCongHopRanh_CCaoChatMatTrong = Input.TTKTHHCongHopRanh_CCaoChatMatTrong,
                ThongTinKichThuocHinhHocOngNhua_CDayPhuBi = Input.ThongTinKichThuocHinhHocOngNhua_CDayPhuBi,

            };
            var id = "";
            CheckObjHelper checkObjhelper = new();
            if (checkObjhelper.AreAllDoublePropertiesGreaterThanZero(searchData))
            {
                 id = await PhanLoaiCTronHopNhuaRepository.InsertId(searchData, GetTenDanhMucById(searchData.ThongTinDuongTruyenDan_HinhThucTruyenDan), GetTenDanhMucById(searchData.ThongTinDuongTruyenDan_LoaiTruyenDan));
               
            }
            return id;
        }

        //Load tên theo phân loại móng cống tròn
        public async Task<PhanLoai> LoadTenPLCTronHopNhua(NuocMua Input)
        {
            PhanLoaiCTronHopNhua searchData = new PhanLoaiCTronHopNhua
            {
                ThongTinDuongTruyenDan_HinhThucTruyenDan = Input.ThongTinDuongTruyenDan_HinhThucTruyenDan,
                ThongTinDuongTruyenDan_LoaiTruyenDan = Input.ThongTinDuongTruyenDan_LoaiTruyenDan,
                TTCDSLCauKienDuongTruyenDan_ChieuDai01CauKien = Input.TTCDSLCauKienDuongTruyenDan_ChieuDai01CauKien,
                ThongTinCauTaoCongTron_CDayPhuBi = Input.ThongTinCauTaoCongTron_CDayPhuBi,
                TTKTHHCongHopRanh_CauTaoTuong = Input.TTKTHHCongHopRanh_CauTaoTuong,
                TTKTHHCongHopRanh_ChatMatTrong = Input.TTKTHHCongHopRanh_ChatMatTrong,
                TTKTHHCongHopRanh_ChatMatNgoai = Input.TTKTHHCongHopRanh_ChatMatNgoai,
                TTKTHHCongHopRanh_CCaoDe = Input.TTKTHHCongHopRanh_CCaoDe,
                TTKTHHCongHopRanh_CRongDe = Input.TTKTHHCongHopRanh_CRongDe,
                TTKTHHCongHopRanh_CDayTuong01Ben = Input.TTKTHHCongHopRanh_CDayTuong01Ben,
                TTKTHHCongHopRanh_SoLuongTuong = Input.TTKTHHCongHopRanh_SoLuongTuong,
                TTKTHHCongHopRanh_CRongLongSuDung = Input.TTKTHHCongHopRanh_CRongLongSuDung,
                TTKTHHCongHopRanh_CCaoTuongGop = Input.TTKTHHCongHopRanh_CCaoTuongGop,
                TTKTHHCongHopRanh_CCaoMuMoThotDuoi = Input.TTKTHHCongHopRanh_CCaoMuMoThotDuoi,
                TTKTHHCongHopRanh_CRongMuMoDuoi = Input.TTKTHHCongHopRanh_CRongMuMoDuoi,
                TTKTHHCongHopRanh_CCaoMuMoThotTren = Input.TTKTHHCongHopRanh_CCaoMuMoThotTren,
                TTKTHHCongHopRanh_CRongMuMoTren = Input.TTKTHHCongHopRanh_CRongMuMoTren,
                TTKTHHCongHopRanh_CCaoChatMatTrong = Input.TTKTHHCongHopRanh_CCaoChatMatTrong,
                ThongTinKichThuocHinhHocOngNhua_CDayPhuBi = Input.ThongTinKichThuocHinhHocOngNhua_CDayPhuBi,

            };

            PhanLoaiCTronHopNhua plCTHNHoGa = new();
            plCTHNHoGa = await PhanLoaiCTronHopNhuaRepository.GetPhanLoaiCTronHopNhuaByDetail(searchData);
            if (plCTHNHoGa != null)
            {
                phanloai.Name = plCTHNHoGa.ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai;
                phanloai.Id = plCTHNHoGa.Id;
            }
           
            return phanloai;
        }

        //Thêm tên theo bảng phân loại cống hộp cống tròn nhựa
        public async Task<string> ThemTenTheoPLMongCTron(NuocMua Input , List<DanhMuc> listDanhMuc)
        {
            PhanLoaiMongCTron searchData = new PhanLoaiMongCTron
            {
                ThongTinDuongTruyenDan_HinhThucTruyenDan = Input.ThongTinDuongTruyenDan_HinhThucTruyenDan,
                ThongTinDuongTruyenDan_LoaiTruyenDan = Input.ThongTinDuongTruyenDan_LoaiTruyenDan,
                ThongTinMongDuongTruyenDan_LoaiMong = Input.ThongTinMongDuongTruyenDan_LoaiMong,
                ThongTinMongDuongTruyenDan_HinhThucMong = Input.ThongTinMongDuongTruyenDan_HinhThucMong,
                ThongTinCauTaoCongTron_CCaoLotMong = Input.ThongTinCauTaoCongTron_CCaoLotMong,
                ThongTinCauTaoCongTron_CRongLotMong = Input.ThongTinCauTaoCongTron_CRongLotMong,
                ThongTinCauTaoCongTron_CCaoMong = Input.ThongTinCauTaoCongTron_CCaoMong,
                ThongTinCauTaoCongTron_CRongMong = Input.ThongTinCauTaoCongTron_CRongMong,

            };
            var id = "";
            CheckObjHelper checkObjhelper = new();
            if (checkObjhelper.AreAllDoublePropertiesGreaterThanZero(searchData))
            {
                 id = await PhanLoaiMongCTronRepository.InsertId(searchData, GetTenDanhMucById(searchData.ThongTinMongDuongTruyenDan_LoaiMong), GetTenDanhMucById(searchData.ThongTinMongDuongTruyenDan_HinhThucMong), GetTenDanhMucById(searchData.ThongTinDuongTruyenDan_LoaiTruyenDan));
               
            }
            return id;
        }

        //Load tên theo phân loại móng cống tròn 
        public async Task<PhanLoai> LoadTenPhanLoaiMongCTron(NuocMua Input)
        {
            PhanLoaiMongCTron searchData = new PhanLoaiMongCTron
            {
                ThongTinDuongTruyenDan_HinhThucTruyenDan = Input.ThongTinDuongTruyenDan_HinhThucTruyenDan,
                ThongTinDuongTruyenDan_LoaiTruyenDan = Input.ThongTinDuongTruyenDan_LoaiTruyenDan,
                ThongTinMongDuongTruyenDan_LoaiMong = Input.ThongTinMongDuongTruyenDan_LoaiMong,
                ThongTinMongDuongTruyenDan_HinhThucMong = Input.ThongTinMongDuongTruyenDan_HinhThucMong,
                ThongTinCauTaoCongTron_CCaoLotMong = Input.ThongTinCauTaoCongTron_CCaoLotMong,
                ThongTinCauTaoCongTron_CRongLotMong = Input.ThongTinCauTaoCongTron_CRongLotMong,
                ThongTinCauTaoCongTron_CCaoMong = Input.ThongTinCauTaoCongTron_CCaoMong,
                ThongTinCauTaoCongTron_CRongMong = Input.ThongTinCauTaoCongTron_CRongMong,
            };

            PhanLoaiMongCTron plMCT = new();
            plMCT = await PhanLoaiMongCTronRepository.GetPhanLoaiMongCTronByDetail(searchData);
            if (plMCT != null)
            {
                phanloai.Name = plMCT.ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop;
                phanloai.Id = plMCT.Id;
            }
            return phanloai;

        }

        //Thêm tên theo bảng phân loại đế cống
        public async Task<string> ThemTenTheoPLDeCong(NuocMua Input , List<DanhMuc> listDanhMuc)
        {
            PhanLoaiDeCong searchData = new PhanLoaiDeCong
            {
                ThongTinDuongTruyenDan_LoaiTruyenDan = Input.ThongTinDuongTruyenDan_LoaiTruyenDan,
                ThongTinDeCong_CauTaoDeCong = Input.ThongTinDeCong_CauTaoDeCong,
                ThongTinDeCong_D = Input.ThongTinDeCong_D,
                ThongTinDeCong_R = Input.ThongTinDeCong_R,
                ThongTinDeCong_C = Input.ThongTinDeCong_C,
            };
            CheckObjHelper checkObjhelper = new();
            var id = "";
            if (checkObjhelper.AreAllDoublePropertiesGreaterThanZero(searchData))
            {
                 id = await PhanLoaiDeCongRepository.InsertId(searchData, searchData.ThongTinDeCong_CauTaoDeCong,searchData.ThongTinDuongTruyenDan_LoaiTruyenDan);
                
            }
            return id;
        }

        //Load tên theo phân loại đế cống
        public async Task<PhanLoai> LoadTenPhanLoaiDeCong(NuocMua Input)
        {
            PhanLoaiDeCong searchData = new PhanLoaiDeCong
            {
                ThongTinDuongTruyenDan_LoaiTruyenDan = Input.ThongTinDuongTruyenDan_LoaiTruyenDan,
                ThongTinDeCong_CauTaoDeCong = Input.ThongTinDeCong_CauTaoDeCong,
                ThongTinDeCong_D = Input.ThongTinDeCong_D,
                ThongTinDeCong_R = Input.ThongTinDeCong_R,
                ThongTinDeCong_C = Input.ThongTinDeCong_C,
            };

            PhanLoaiDeCong plDC = new();
            plDC = await PhanLoaiDeCongRepository.GetPhanLoaiDeCongByDetail(searchData);
            if (plDC != null)
            {
                phanloai.Name = plDC.ThongTinDeCong_TenLoaiDeCong;
                phanloai.Id = plDC.Id;
            }
            return phanloai;
        }

        //Thêm tên theo bảng phân loại thanh chống
        public async Task<string> ThemTenTheoPLThanhChong(NuocMua Input , List<DanhMuc> listDanhMuc)
        {
            PhanLoaiThanhChong searchData = new PhanLoaiThanhChong
            {
                TTKTHHCongHopRanh_CauTaoThanhChong = Input.TTKTHHCongHopRanh_CauTaoThanhChong,
                TTKTHHCongHopRanh_CCaoThanhChong = Input.TTKTHHCongHopRanh_CCaoThanhChong,
                TTKTHHCongHopRanh_CRongThanhChong = Input.TTKTHHCongHopRanh_CRongThanhChong,
                TTKTHHCongHopRanh_CDai = Input.TTKTHHCongHopRanh_CDai,
            };
            var id = "";
            CheckObjHelper checkObjhelper = new();
            if (checkObjhelper.AreAllDoublePropertiesGreaterThanZero(searchData))
            {
                 id = await PhanLoaiThanhChongRepository.InsertId(searchData, GetTenDanhMucById(searchData.TTKTHHCongHopRanh_CauTaoThanhChong));
                
            }
            return id;
        }

        //Load tên theo phân loại thanh chống
        public async Task<PhanLoai> LoadTenPhanLoaiThanhChong(NuocMua Input)
        {
            PhanLoaiThanhChong searchData = new PhanLoaiThanhChong
            {
                TTKTHHCongHopRanh_CauTaoThanhChong = Input.TTKTHHCongHopRanh_CauTaoThanhChong,
                TTKTHHCongHopRanh_CCaoThanhChong = Input.TTKTHHCongHopRanh_CCaoThanhChong,
                TTKTHHCongHopRanh_CRongThanhChong = Input.TTKTHHCongHopRanh_CRongThanhChong,
                TTKTHHCongHopRanh_CDai = Input.TTKTHHCongHopRanh_CDai,
            };

            PhanLoaiThanhChong plTC = new();
            plTC = await PhanLoaiThanhChongRepository.GetPhanLoaiThanhChongByDetail(searchData);
            if (plTC != null)
            {

                phanloai.Name = plTC.TTKTHHCongHopRanh_LoaiThanhChong;
                phanloai.Id = plTC.Id;
            
            }
            return phanloai;
        }

        //Thêm tên theo bảng phân loại tấm đan tryền dẫn
        public async Task<string> ThemTenTheoPLTDanTDan(NuocMua Input , List<DanhMuc> listDanhMuc)
        {
            PhanLoaiTDanTDan searchData = new PhanLoaiTDanTDan
            {
                ThongTinLyTrinhTruyenDan_TuLyTrinh = Input.ThongTinLyTrinhTruyenDan_TuLyTrinh,
                ThongTinLyTrinhTruyenDan_DenLyTrinh = Input.ThongTinLyTrinhTruyenDan_DenLyTrinh,
                ThongTinDuongTruyenDan_HinhThucTruyenDan = Input.ThongTinDuongTruyenDan_HinhThucTruyenDan,
                ThongTinDuongTruyenDan_LoaiTruyenDan = Input.ThongTinDuongTruyenDan_LoaiTruyenDan,
                TTTDCongHoRanh_CauTaoTamDanTruyenDanTamDanTieuChuan = Input.TTTDCongHoRanh_CauTaoTamDanTruyenDanTamDanTieuChuan,
                TTTDCongHoRanh_CDai = Input.TTTDCongHoRanh_CDai,
                TTTDCongHoRanh_CRong = Input.TTTDCongHoRanh_CRong,
                TTTDCongHoRanh_CCao = Input.TTTDCongHoRanh_CCao,
            };
            CheckObjHelper checkObjhelper = new();
            var id = "";
            if (checkObjhelper.AreAllDoublePropertiesGreaterThanZero(searchData))
            {
                 id = await PhanLoaiTDanTDanRepository.InsertId(searchData, GetTenDanhMucById(searchData.ThongTinDuongTruyenDan_HinhThucTruyenDan), GetTenDanhMucById(searchData.ThongTinDuongTruyenDan_LoaiTruyenDan), GetTenDanhMucById(searchData.TTTDCongHoRanh_CauTaoTamDanTruyenDanTamDanTieuChuan));
               
            }
            return id;
        }

        public async Task<string> ThemTenTheoPLTDanTDan02(NuocMua Input , List<DanhMuc> listDanhMuc)
        {
            PhanLoaiTDanTDan searchData = new PhanLoaiTDanTDan
            {
                ThongTinLyTrinhTruyenDan_TuLyTrinh = Input.ThongTinLyTrinhTruyenDan_TuLyTrinh,
                ThongTinLyTrinhTruyenDan_DenLyTrinh = Input.ThongTinLyTrinhTruyenDan_DenLyTrinh,
                ThongTinDuongTruyenDan_HinhThucTruyenDan = Input.ThongTinDuongTruyenDan_HinhThucTruyenDan,
                ThongTinDuongTruyenDan_LoaiTruyenDan = Input.ThongTinDuongTruyenDan_LoaiTruyenDan,
                TTTDCongHoRanh_CauTaoTamDanTruyenDanTamDanTieuChuan = Input.TTTDCongHoRanh_CauTaoTamDanTruyenDanTamDanTieuChuan,
                TTTDCongHoRanh_CDai = Input.TTTDCongHoRanh_CDai1,
                TTTDCongHoRanh_CRong = Input.TTTDCongHoRanh_CRong1,
                TTTDCongHoRanh_CCao = Input.TTTDCongHoRanh_CCao1,
            };
            CheckObjHelper checkObjhelper = new();
            var id = "";
            if (checkObjhelper.AreAllDoublePropertiesGreaterThanZero(searchData))
            {
                 id = await PhanLoaiTDanTDanRepository.InsertId(searchData, GetTenDanhMucById(searchData.ThongTinDuongTruyenDan_HinhThucTruyenDan), GetTenDanhMucById(searchData.ThongTinDuongTruyenDan_LoaiTruyenDan), GetTenDanhMucById(searchData.TTTDCongHoRanh_CauTaoTamDanTruyenDanTamDanTieuChuan));
               
            }
            return id;
        }

        //Load tên theo phân loại tấm đan truyền dẫn
        public async Task<PhanLoai> LoadTenPhanLoaiTDanTDan(NuocMua Input)
        {
            PhanLoaiTDanTDan searchData = new PhanLoaiTDanTDan
            {
                ThongTinLyTrinhTruyenDan_TuLyTrinh = Input.ThongTinLyTrinhTruyenDan_TuLyTrinh,
                ThongTinLyTrinhTruyenDan_DenLyTrinh = Input.ThongTinLyTrinhTruyenDan_DenLyTrinh,
                ThongTinDuongTruyenDan_HinhThucTruyenDan = Input.ThongTinDuongTruyenDan_HinhThucTruyenDan,
                ThongTinDuongTruyenDan_LoaiTruyenDan = Input.ThongTinDuongTruyenDan_LoaiTruyenDan,
                TTTDCongHoRanh_CauTaoTamDanTruyenDanTamDanTieuChuan = Input.TTTDCongHoRanh_CauTaoTamDanTruyenDanTamDanTieuChuan,
                TTTDCongHoRanh_CDai = Input.TTTDCongHoRanh_CDai,
                TTTDCongHoRanh_CRong = Input.TTTDCongHoRanh_CRong,
                TTTDCongHoRanh_CCao = Input.TTTDCongHoRanh_CCao,
            };


            PhanLoaiTDanTDan plTDTD = new();
            plTDTD = await PhanLoaiTDanTDanRepository.GetPhanLoaiTDanTDanByDetail(searchData);
            if (plTDTD != null)
            {
                phanloai.Name = plTDTD.TTTDCongHoRanh_TenLoaiTamDanTieuChuan;
                phanloai.Id = plTDTD.Id;
            }
           return phanloai;

        }

    }

}
