using DucAnhERP.Models;
using DucAnhERP.SeedWork;

namespace DucAnhERP.ViewModel
{
    public class PhanLoaiHoGaModel : PagingParameters
    {
        public string Id { get; set; }
        public int Flag { get; set; } = 0;
        public string? ThongTinChungHoGa_TenHoGaSauPhanLoai { get; set; } = "";
        public string? ThongTinChungHoGa_HinhThucHoGa { get; set; } = "";
        public string? ThongTinChungHoGa_HinhThucHoGa_Name { get; set; } = "";
        public string? ThongTinChungHoGa_KetCauMuMo { get; set; } = "";
        public string? ThongTinChungHoGa_KetCauMuMo_Name { get; set; } = "";
        public string? ThongTinChungHoGa_KetCauTuong { get; set; } = "";
        public string? ThongTinChungHoGa_KetCauTuong_Name { get; set; } = "";
        public string? ThongTinChungHoGa_HinhThucMongHoGa { get; set; } = "";
        public string? ThongTinChungHoGa_HinhThucMongHoGa_Name { get; set; } = "";
        public string? ThongTinChungHoGa_KetCauMong { get; set; } = "";
        public string? ThongTinChungHoGa_KetCauMong_Name { get; set; } = "";
        public string? ThongTinChungHoGa_ChatMatTrong { get; set; } = "";
        public string? ThongTinChungHoGa_ChatMatTrong_Name { get; set; } = "";
        public string? ThongTinChungHoGa_ChatMatNgoai { get; set; } = "";
        public string? ThongTinChungHoGa_ChatMatNgoai_Name { get; set; } = "";
        public Double? PhuBiHoGa_CDai { get; set; } = 0;
        public Double? PhuBiHoGa_CRong { get; set; } = 0;
        public Double? BeTongLotMong_D { get; set; } = 0;
        public Double? BeTongLotMong_R { get; set; } = 0;
        public Double? BeTongLotMong_C { get; set; } = 0;
        public Double? BeTongMongHoGa_D { get; set; } = 0;
        public Double? BeTongMongHoGa_R { get; set; } = 0;
        public Double? BeTongMongHoGa_C { get; set; } = 0;
        public Double? DeHoGa_D { get; set; } = 0;
        public Double? DeHoGa_R { get; set; } = 0;
        public Double? DeHoGa_C { get; set; } = 0;
        public Double? TuongHoGa_D { get; set; } = 0;
        public Double? TuongHoGa_R { get; set; } = 0;
        public Double? TuongHoGa_C { get; set; } = 0;
        public Double? TuongHoGa_CdTuong { get; set; } = 0;
        public Double? DamGiuaHoGa_D { get; set; } = 0;
        public Double? DamGiuaHoGa_R { get; set; } = 0;
        public Double? DamGiuaHoGa_C { get; set; } = 0;
        public Double? DamGiuaHoGa_CdDam { get; set; } = 0;
        public Double? DamGiuaHoGa_CCaoDamGiuaTuongSoVoiDayHoGa { get; set; } = 0;
        public Double? ChatMatTrong_D { get; set; } = 0;
        public Double? ChatMatTrong_R { get; set; } = 0;
        public Double? ChatMatTrong_C { get; set; } = 0;
        public Double? ChatMatNgoaiCanh_D { get; set; } = 0;
        public Double? ChatMatNgoaiCanh_R { get; set; } = 0;
        public Double? ChatMatNgoaiCanh_C { get; set; } = 0;
        public Double? MuMoThotDuoi_D { get; set; } = 0;
        public Double? MuMoThotDuoi_R { get; set; } = 0;
        public Double? MuMoThotDuoi_C { get; set; } = 0;
        public Double? MuMoThotDuoi_CdTuong { get; set; } = 0;
        public Double? MuMoThotTren_D { get; set; } = 0;
        public Double? MuMoThotTren_R { get; set; } = 0;
        public Double? MuMoThotTren_C { get; set; } = 0;
        public Double? MuMoThotTren_CdTuong { get; set; } = 0;
        public Double? HinhThucDauNoi1_Loai { get; set; } = 0;
        public Double? HinhThucDauNoi1_CanhDai { get; set; } = 0;
        public Double? HinhThucDauNoi1_CanhRong { get; set; } = 0;
        public Double? HinhThucDauNoi1_CanhCheo { get; set; } = 0;
        public Double? HinhThucDauNoi2_Loai { get; set; } = 0;
        public Double? HinhThucDauNoi2_CanhDai { get; set; } = 0;
        public Double? HinhThucDauNoi2_CanhRong { get; set; } = 0;
        public Double? HinhThucDauNoi2_CanhCheo { get; set; } = 0;
        public Double? HinhThucDauNoi3_Loai { get; set; } = 0;
        public Double? HinhThucDauNoi3_CanhDai { get; set; } = 0;
        public Double? HinhThucDauNoi3_CanhRong { get; set; } = 0;
        public Double? HinhThucDauNoi3_CanhCheo { get; set; } = 0;
        public Double? HinhThucDauNoi4_Loai { get; set; } = 0;
        public Double? HinhThucDauNoi4_CanhDai { get; set; } = 0;
        public Double? HinhThucDauNoi4_CanhRong { get; set; } = 0;
        public Double? HinhThucDauNoi4_CanhCheo { get; set; } = 0;
        public Double? HinhThucDauNoi5_Loai { get; set; } = 0;
        public Double? HinhThucDauNoi5_CanhDai { get; set; } = 0;
        public Double? HinhThucDauNoi5_CanhRong { get; set; } = 0;
        public Double? HinhThucDauNoi5_CanhCheo { get; set; } = 0;
        public Double? HinhThucDauNoi6_Loai { get; set; } = 0;
        public Double? HinhThucDauNoi6_CanhDai { get; set; } = 0;
        public Double? HinhThucDauNoi6_CanhRong { get; set; } = 0;
        public Double? HinhThucDauNoi6_CanhCheo { get; set; } = 0;
        public Double? HinhThucDauNoi7_Loai { get; set; } = 0;
        public Double? HinhThucDauNoi7_CanhDai { get; set; } = 0;
        public Double? HinhThucDauNoi7_CanhRong { get; set; } = 0;
        public Double? HinhThucDauNoi7_CanhCheo { get; set; } = 0;
        public Double? HinhThucDauNoi8_Loai { get; set; } = 0;
        public Double? HinhThucDauNoi8_CanhDai { get; set; } = 0;
        public Double? HinhThucDauNoi8_CanhRong { get; set; } = 0;
        public Double? HinhThucDauNoi8_CanhCheo { get; set; } = 0;
        public DateTime? CreateAt { get; set; }
        public string? CreateBy { get; set; }
        public int? IsActive { get; set; }
    }

    public class PLHGBaoCaoModel : PhanLoaiHoGaModel {
        public int countTrai { get; set; }
        public int countPhai { get; set; }
        public int Tong { get; set; }
    }
    public class PLHGBaoCaoSLHGTTModel : PLHGBaoCaoModel
    {
        public string ThongTinLyTrinh_TuyenDuong { get; set; }
    }
   
}
