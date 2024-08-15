using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace DucAnhERP.Models
{
    public class RainwaterDrainage
    {
        //Thông tin lý trình
        [Required(ErrorMessage = "Bạn phải nhập Tuyến đường!")]
        public string ThongTinLyTrinh_TuyenDuong { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập Lý trình tại tim hố ga!")]
        public string ThongTinLyTrinh_LyTrinhTaiTimHoGa { get; set; }
        //Thông tin chung hố ga
        [Required(ErrorMessage = "Bạn phải nhập Tên hố ga sau phân loại !")]
        public string ThongTinChungHoGa_TenHoGaSauPhanLoai { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập Tên hố ga theo bản vẽ!")]
        public string ThongTinChungHoGa_TenHoGaTheoBanVe { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập Hình thức hố ga !")]
        public string ThongTinChungHoGa_HinhThucHoGa { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập  kết cấu mũ mố !")]
        public string ThongTinChungHoGa_KetCauMuMo { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập hình thức đậy hố ga!")]
        public string ThongTinTamDanHoGa_HinhThucDayHoGa { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập Kết cấu tường!")]
        public string ThongTinChungHoGa_KetCauTuong { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập Hình thức móng hố ga !")]
        public string ThongTinChungHoGa_HinhThucMongHoGa { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập  Kết cấu móng !")]
        public string ThongTinChungHoGa_KetCauMong { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập Chát mặt trong !")]
        public string ThongTinChungHoGa_ChatMatTrong { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập Chát mặt ngoài  !")]
        public string ThongTinChungHoGa_ChatMatNgoai { get; set; }
        //Thông tin kích thước hình học hố ga
        //1.Thông tin phủ bì hố ga (m) 1.PhuBiHoGa
        [Required(ErrorMessage = "Bạn phải nhập chiều dài  !")]
        public string PhuBiHoGa_CDai { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập  chiều rộng !")]
        public string PhuBiHoGa_CRong { get; set; }
        //2.Kích thước hình học bê tông lót móng hố ga (m) BeTongLotMong
        [Required(ErrorMessage = "Bạn phải nhập chiều dài  !")]
        public string BeTongLotMong_D { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập chiều rộng !")]
        public string BeTongLotMong_R { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập chiều cao !")]
        public string BeTongLotMong_C { get; set; }
        //3.Kích thước hình học bê tông móng hố ga (m)	BeTongMongHoGa
        [Required(ErrorMessage = "Bạn phải nhập chiều dài  !")]
        public string BeTongMongHoGa_D { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập chiều rộng !")]
        public string BeTongMongHoGa_R { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập chiều cao !")]
        public string TBeTongMongHoGa_C { get; set; }
        //4.KTHH đế hố ga		DeHoGa
        [Required(ErrorMessage = "Bạn phải nhập chiều dài  !")]
        public string DeHoGa_D { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập chiều rộng !")]
        public string DeHoGa_R { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập chiều cao !")]
        public string DeHoGa_C { get; set; }
        //5.Kích thước hình học tường hố ga (m)	TuongHoGa		
        public string TuongHoGa_D { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập chiều rộng !")]
        public string TuongHoGa_R { get; set; }
        //[Required(ErrorMessage = "Bạn phải nhập chiều cao !")]
        //public string TuongHoGa_C { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập chiều dài tường !")]
        public string TuongHoGa_CdTuong { get; set; }
      
        //6.KTHH dầm giữa hố ga	 DamGiuaHoGa
        
        [Required(ErrorMessage = "Bạn phải nhập chiều dài  !")]
        public string DamGiuaHoGa_D { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập chiều rộng !")]
        public string DamGiuaHoGa_R { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập chiều cao !")]
        public string DamGiuaHoGa_C { get; set; }
        [Required(ErrorMessage = "Bạn phải dài dầm!")]
        public string DamGiuaHoGa_CdDam { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập chiều dài dầm so với đáy hố ga ")]
        public string DamGiuaHoGa_CCaoDamGiuaTuongSoVoiDayHoGa { get; set; }
        //7.Chát hố ga mặt trong 		ChatMatTrong
        [Required(ErrorMessage = "Bạn phải nhập chiều dài !")]
        public string ChatMatTrong_D { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập chiều rộng !")]
        public string ChatMatTrong_R { get; set; }
        //[Required(ErrorMessage = "Bạn phải nhập chiều cao !")]
        //public string ChatMatTrong_C { get; set; }
        //8.Chát hố ga mặt ngoài, cạnh 01 +02 (m) ChatMatNgoaiCanh
        [Required(ErrorMessage = "Bạn phải nhập chiều dài  !")]
        public string ChatMatNgoaiCanh_D { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập chiều rộng !")]
        public string ChatMatNgoaiCanh_R { get; set; }
        //[Required(ErrorMessage = "Bạn phải nhập chiều cao !")]
        //public string ChatMatNgoaiCanh_C { get; set; }
        //9.Kích thước hình học tường mũ mố thớt dưới (m) MuMoThotDuoi
        [Required(ErrorMessage = "Bạn phải nhập chiều dài  !")]
        public string MuMoThotDuoi_D { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập chiều rộng !")]
        public string MuMoThotDuoi_R { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập chiều cao !")]
        public string MuMoThotDuoi_C { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập chiều dài tường !")]
        public string MuMoThotDuoi_CdTuong { get; set; }

        //10.Kích thước hình học tường mũ mố thớt trên (m)	 MuMoThotTren	
        //[Required(ErrorMessage = "Bạn phải nhập chiều dài  !")]	
        public string MuMoThotTren_D { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập chiều rộng !")]
        public string MuMoThotTren_R { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập chiều cao !")]
        public string MuMoThotTren_C { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập chiều dài tường !")]
        public string MuMoThotTren_CdTuong { get; set; }


        //Hạng mục chiếm chỗ hố ga
        //1.Hình thức đấu nối    HinhThucDauNoi1
        [Required(ErrorMessage = "Bạn phải nhập loại !")]
        public string HinhThucDauNoi1_Loai { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập cạnh dài !")]
        public string HinhThucDauNoi1_CanhDai { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập cạnh rộng !")]
        public string HinhThucDauNoi1_CanhRong { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập cạnh cheo !")]
        public string HinhThucDauNoi1_CanhCheo { get; set; }

        //2.Hình thức đấu nối    HinhThucDauNoi2

        public string HinhThucDauNoi2_Loai { get; set; }
        public string HinhThucDauNoi2_CanhDai { get; set; }
        public string HinhThucDauNoi2_CanhRong { get; set; }
        public string HinhThucDauNoi2_CanhCheo { get; set; }


        //3.Hình thức đấu nối    HinhThucDauNoi3
        public string HinhThucDauNoi3_Loai { get; set; }
        public string HinhThucDauNoi3_CanhDai { get; set; }
        public string HinhThucDauNoi3_CanhRong { get; set; }
        public string HinhThucDauNoi3_CanhCheo { get; set; }

        //4.Hình thức đấu nối    HinhThucDauNoi4
        public string HinhThucDauNoi4_Loai { get; set; }
        public string HinhThucDauNoi4_CanhDai { get; set; }
        public string HinhThucDauNoi4_CanhRong { get; set; }
        public string HinhThucDauNoi4_CanhCheo { get; set; }

        //5.Hình thức đấu nối    HinhThucDauNoi5
        public string HinhThucDauNoi5_Loai { get; set; }
        public string HinhThucDauNoi5_CanhDai { get; set; }
        public string HinhThucDauNoi5_CanhRong { get; set; }
        public string HinhThucDauNoi5_CanhCheo { get; set; }

        //6.Hình thức đấu nối    HinhThucDauNoi6
        public string HinhThucDauNoi6_Loai { get; set; }
        public string HinhThucDauNoi6_CanhDai { get; set; }
        public string HinhThucDauNoi6_CanhRong { get; set; }
        public string HinhThucDauNoi6_CanhCheo { get; set; }

        //7.Hình thức đấu nối    HinhThucDauNoi7
        public string HinhThucDauNoi7_Loai { get; set; }
        public string HinhThucDauNoi7_CanhDai { get; set; }
        public string HinhThucDauNoi7_CanhRong { get; set; }
        public string HinhThucDauNoi7_CanhCheo { get; set; }

        //8.Hình thức đấu nối    HinhThucDauNoi8
        public string HinhThucDauNoi8_Loai { get; set; }
        public string HinhThucDauNoi8_CanhDai { get; set; }
        public string HinhThucDauNoi8_CanhRong { get; set; }
        public string HinhThucDauNoi8_CanhCheo { get; set; }

        //Thông tin tấm đan hố ga ThongTinTamDanHoGa2

        [Required(ErrorMessage = "Bạn phải nhập Phân loại đậy hố ga !")]
        public string ThongTinTamDanHoGa2_PhanLoaiDayHoGa { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập Hình thức đậy hố ga !")]
        public string ThongTinTamDanHoGa2_HinhThucDayHoGa { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập Đường kính (m) !")]
        public string ThongTinTamDanHoGa2_DuongKinh { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập Chiều dầy (m) !")]
        public string ThongTinTamDanHoGa2_ChieuDay { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập chiều dài !")]
        public string ThongTinTamDanHoGa2_D { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập chiều rộng  !")]
        public string ThongTinTamDanHoGa2_R { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập chiều cao !")]
        public string ThongTinTamDanHoGa2_C { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập số lượng nắp đậy !")]
        public string ThongTinTamDanHoGa2_SoLuongNapDay { get; set; }

        //Thông tin vật liệu đào hố ga
        [Required(ErrorMessage = "Bạn phải nhập loại vật liệu đào!")]
        public string ThongTinVatLieuDaoHoGa_LoaiVatLieuDao { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập chiều cao đào đá!")]
        public string ThongTinVatLieuDaoHoGa_ChieuCaoDaoDa { get; set; }
        //[Required(ErrorMessage = "Bạn phải nhập chiều cao đào đất!")]
        //public string ThongTinVatLieuDaoHoGa_ChieuCaoDaoDat { get; set; }
        //[Required(ErrorMessage = "Bạn phải nhập tổng chiều cao!")]
        //public string ThongTinVatLieuDaoHoGa_TongChieuCaoDao { get; set; }

        //Thông tin cao độ hố ga

        //[Required(ErrorMessage = "Bạn phải nhập cao độ tự nhiên!")]
        //public string ThongTinCaoDoHoGa_CaoDoTuNhien { get; set; }
        //[Required(ErrorMessage = "Bạn phải nhập CĐ đỉnh vỉa hè hoàn thiện !")]
        //public string ThongTinCaoDoHoGa_CdDinhViaHeHoanThien { get; set; }
        //[Required(ErrorMessage = "Bạn phải nhập Cao độ đỉnh K98)!")]
        //public string ThongTinCaoDoHoGa_CaoDoDinhK98 { get; set; }
        //[Required(ErrorMessage = "Bạn phải nhập Cao độ hiện trạng trước khi đào (m) !")]
        //public string ThongTinCaoDoHoGa_CaoDoHienTrangTruocKhiDao { get; set; }
        //[Required(ErrorMessage = "Bạn phải nhập Đáy đào !")]
        //public string ThongTinCaoDoHoGa_DayDao { get; set; }
        //[Required(ErrorMessage = "Bạn phải nhập C.Sâu đào !")]
        //public string ThongTinCaoDoHoGa_CSauDao { get; set; }
        //[Required(ErrorMessage = "Bạn phải nhập Đỉnh lót móng !")]
        //public string ThongTinCaoDoHoGa_DinhLotMong { get; set; }
        //[Required(ErrorMessage = "Bạn phải nhập CĐ đỉnh móng !")]
        //public string ThongTinCaoDoHoGa_CdDinhMong { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập CĐ đáy hố ga !")]
        public string ThongTinCaoDoHoGa_CdDayHoGa { get; set; }
        //[Required(ErrorMessage = "Bạn phải nhập C.Cao tường !")]
        //public string ThongTinCaoDoHoGa_CCaoTuong { get; set; }
        //[Required(ErrorMessage = "Bạn phải nhập Đỉnh tường dưới dầm giữa tường !")]
        //public string ThongTinCaoDoHoGa_DinhTuongDuoiDamGiuaTuong { get; set; }
        //[Required(ErrorMessage = "Bạn phải nhập đỉnh dầm giữa tường !")]
        //public string ThongTinCaoDoHoGa_DinhDamGiuaTuong { get; set; }
        //[Required(ErrorMessage = "Bạn phải nhập Đỉnh tường !")]
        //public string ThongTinCaoDoHoGa_DinhTuong { get; set; }
        //[Required(ErrorMessage = "Bạn phải nhập Đỉnh mũ mố thớt dưới !")]
        //public string ThongTinCaoDoHoGa_DinhMuMoThotDuoi { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập CĐ đỉnh hố ga!")]
        public string ThongTinCaoDoHoGa_CdDinhHoGa { get; set; }
        //[Required(ErrorMessage = "Bạn phải nhập Tổng chiều cao hố ga !")]
        //public string ThongTinCaoDoHoGa_TongChieuCaoHoGa { get; set; }
        //[Required(ErrorMessage = "Bạn phải nhập Chênh cao đỉnh hố ga và hiện trạng đào!")]
        //public string ThongTinCaoDoHoGa_ChenhCaoDinhHoGaVaHienTrangDao { get; set; }
        //[Required(ErrorMessage = "Bạn phải nhập Tổng chiều cao chiếm chỗ đắp trả!")]
        //public string ThongTinCaoDoHoGa_TongChieuCaoChiemChoDapTra { get; set; }

        //Thông tin mái đào
        [Required(ErrorMessage = "Bạn phải nhập Chiều rộng đáy đào nhỏ!")]
        public string ThongTinMaiDao_ChieuRongDayDaoNho { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập Tỷ lệ mở mái!")]
        public string ThongTinMaiDao_TyLeMoMai { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập Số cạnh mái trái !")]
        public string ThongTinMaiDao_SoCanhMaiTrai { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập số cạnh mái phải !")]
        public string ThongTinMaiDao_SoCanhMaiPhai { get; set; }

        //Tọa độ
        [Required(ErrorMessage = "Bạn phải nhập tọa độ X!")]
        public string ToaDoX { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập tọa độ y!")]
        public string ToaDoY { get; set; }



        //Thông tin lý trình truyền dẫn
        [Required(ErrorMessage = "Bạn phải nhập Từ lý trình!")]
        public string ThongTinLyTrinhTruyenDan_TuLyTrinh { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập Đến lý trình!")]
        public string ThongTinLyTrinhTruyenDan_DenLyTrinh { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập Từ hố ga !")]
        public string ThongTinLyTrinhTruyenDan_TuHoGa { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập Đến hố ga !")]
        public string ThongTinLyTrinhTruyenDan_DenHoGa { get; set; }

        //Thông tin đường truyền dẫn
        [Required(ErrorMessage = "Bạn phải nhập Hình thức truyền dẫn!")]
        public string ThongTinDuongTruyenDan_HinhThucTruyenDan { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập Loại truyền dẫn !")]
        public string ThongTinDuongTruyenDan_LoaiTruyenDan { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập Tên loại truyền dẫn sau phân loại!")]
        public string ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai { get; set; }

        //Thông tin chiều dài và số lượng cấu kiện đường truyền dẫn
        [Required(ErrorMessage = "Bạn phải nhập Chiều dài 01 cấu kiện (m) !")] 
        public string TTCDSLCauKienDuongTruyenDan_ChieuDai01CauKien { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập Chiều dài mối nối C.Kiện!")] 
        public string TTCDSLCauKienDuongTruyenDan_ChieuDaiMoiNoiCKien { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập Số lượng C.Kiện dùng để tính chiều dài bổ sung (C.Kiện)!")] 
        public string TTCDSLCauKienDuongTruyenDan_SoLuongCKienDungDeTinhChieuDaiBoSung { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập tổng chiều dài!")] 
        public string TTCDSLCauKienDuongTruyenDan_TongChieuDai { get; set; }

        //Thông tin móng đường truyền dẫn
        
        [Required(ErrorMessage = "Bạn phải nhập Loại móng!")]
        public string ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop{get;set;}
        [Required(ErrorMessage = "Bạn phải nhập loại móng!")]
        public string ThongTinMongDuongTruyenDan_LoaiMong { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập hình thức móng!")]
        public string ThongTinMongDuongTruyenDan_HinhThucMong { get; set; }

        //Thông tin đế cống
        [Required(ErrorMessage = "Bạn phải nhập tên loại đế cống!")]
        public string ThongTinDeCong_TenLoaiDeCong { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập cấu tạo đế cống!")]
        public string ThongTinDeCong_CauTaoDeCong { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập chiều dài!")]
        public string ThongTinDeCong_D { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập chiều rộng!")]
        public string ThongTinDeCong_R { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập chiều cao!")]
        public string ThongTinDeCong_C { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập SL đế cống/01 cấu kiện truyền dẫn (C.Kiện) !")]
        public string ThongTinDeCong_SlDeCong01CauKienTruyenDan { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập  KL 01 đế cống!")]
        public string ThongTinDeCong_Kl01DeCong { get; set; }

        //Thông tin cấu tạo cống tròn
        [Required(ErrorMessage = "Bạn phải nhập Dầy phủ bì !")]
        public string ThongTinCauTaoCongTron_CDayPhuBi { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập Số cạnh!")]
        public string ThongTinCauTaoCongTron_SoCanh { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập Lòng sử dụng!")]
        public string ThongTinCauTaoCongTron_LongSuDung { get; set; }
     
        [Required(ErrorMessage = "Bạn phải nhập C.Cao lót móng (m)!")]
        public string ThongTinCauTaoCongTron_CCaoLotMong { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập C.Rộng lót móng!")]
        public string ThongTinCauTaoCongTron_CRongLotMong { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập C.Cao móng!")]
        public string ThongTinCauTaoCongTron_CCaoMong { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập C.Rộng móng !")]
        public string ThongTinCauTaoCongTron_CRongMong { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập C.Cao đế (tại vị trí đặt C.Kiện) (m)!")]
        public string ThongTinCauTaoCongTron_CCaoDe { get; set; }

        //Thông tin kích thước hình học cống hộp, rãnh
        [Required(ErrorMessage = "Bạn phải nhập cấu tạo tường!")]
        public string TTKTHHCongHopRanh_CauTaoTuong { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập cấu tạo mũ mố!")]
        public string TTKTHHCongHopRanh_CauTaoMuMo { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập Chát mặt trong !")]
        public string TTKTHHCongHopRanh_ChatMatTrong { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập Chát mặt ngoài!")]
        public string TTKTHHCongHopRanh_ChatMatNgoai { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập C.Cao lót móng !")]
        public string TTKTHHCongHopRanh_CCaoLotMong { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập C.Rộng lót móng!")]
        public string TTKTHHCongHopRanh_CRongLotMong { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập C.Cao móng !")]
        public string TTKTHHCongHopRanh_CCaoMong { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập  C.Rộng móng!")]
        public string TTKTHHCongHopRanh_CRongMong { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập C.Cao đế !")]
        public string TTKTHHCongHopRanh_CCaoDe { get; set; }
        [Required(ErrorMessage = "Bạn phải nhậpC.Rộng đế !")]
        public string TTKTHHCongHopRanh_CRongDe { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập C.Dầy tường 01 bên!")]
        public string TTKTHHCongHopRanh_CDayTuong01Ben { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập Số lượng tường !")]
        public string TTKTHHCongHopRanh_SoLuongTuong { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập C.Rộng lòng sử dụng !")]
        public string TTKTHHCongHopRanh_CRongLongSuDung { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập C.Cao tường cống hộp!")]
        public string TTKTHHCongHopRanh_CCaoTuongCongHop { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập C.Cao tường rãnh!")]
        public string TTKTHHCongHopRanh_CCaoTuongRanh { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập C.Cao tường gộp !")]
        public string TTKTHHCongHopRanh_CCaoTuongGop { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập C.Cao mũ mố thớt dưới!")]
        public string TTKTHHCongHopRanh_CCaoMuMoThotDuoi { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập C.Rộng mũ mố dưới!")]
        public string TTKTHHCongHopRanh_CRongMuMoDuoi { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập C.Cao mũ mố thớt trên !")]
        public string TTKTHHCongHopRanh_CCaoMuMoThotTren { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập C.Rộng mũ mố trên !")]
        public string TTKTHHCongHopRanh_CRongMuMoTren { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập Loại thanh chống !")]
        public string TTKTHHCongHopRanh_LoaiThanhChong { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập Cấu tạo thanh chống!")]
        public string TTKTHHCongHopRanh_CauTaoThanhChong { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập C.Cao thanh chống!")]
        public string TTKTHHCongHopRanh_CCaoThanhChong { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập C.Rộng thanh chống!")]
        public string TTKTHHCongHopRanh_CRongThanhChong { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập C.Dài !")]
        public string TTKTHHCongHopRanh_CDai { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập Số lượng thanh chống !")]
        public string TTKTHHCongHopRanh_SoLuongThanhChong { get; set; }

        //Thông tin kích thước hình học ống nhựa
        [Required(ErrorMessage = "Bạn phải nhập C.Dầy phủ bì!")]
        public string ThongTinKichThuocHinhHocOngNhua_CDayPhuBi { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập số cạnh!")]
        public string ThongTinKichThuocHinhHocOngNhua_SoCanh { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập Lòng sử dụng !")]
        public string ThongTinKichThuocHinhHocOngNhua_LongSuDung { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập Tổng C.Cao ống !")]
        public string ThongTinKichThuocHinhHocOngNhua_TongCCaoOng { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập  C.Cao đệm cát!")]
        public string ThongTinKichThuocHinhHocOngNhua_CCaoDemCat { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập C.Cao đắp cát !")]
        public string ThongTinKichThuocHinhHocOngNhua_CCaoDapCat { get; set; }

        //Thông tin rãnh thang
        [Required(ErrorMessage = "Bạn phải nhập Hình thức mái !")]
        public string ThongTinRanhThang_HinhThucMai { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập Cấu tạo chân khay !")]
        public string ThongTinRanhThang_CauTaoChanKhay { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập Cấu tạo giằng đỉnh!")]
        public string ThongTinRanhThang_CauTaoGiangDinh { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập Hình thức hành lang bảo vệ !")]
        public string ThongTinRanhThang_HinhThucHanhLangBaoVe { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập Phân loại chân khay!")]
        public string ThongTinRanhThang_PhanLoaiChanKhay { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập C.Cao lót chân khay !")]
        public string ThongTinRanhThang_CCaoLotChanKhay { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập  C.Rộng lót chân khay !")]
        public string ThongTinRanhThang_CRongLotChanKhay { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập Số lượng lót chân khay !")]
        public string ThongTinRanhThang_SoLuongLotChanKhay { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập C.Cao móng chân khay!")]
        public string ThongTinRanhThang_CCaoMongChanKhay { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập C.Rộng móng chân khay!")]
        public string ThongTinRanhThang_CRongMongChanKhay { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập Số lượng móng chân khay !")]
        public string ThongTinRanhThang_SoLuongMongChanKhay { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập C.Cao lót !")]
        public string ThongTinRanhThang_CCaoLot { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập C.Rộng lót!")]
        public string ThongTinRanhThang_CRongLot { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập C.Cao móng !")]
        public string ThongTinRanhThang_CCaoMong { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập C.Rộng móng !")]
        public string ThongTinRanhThang_CRongMong { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập Phân loại mái !")]
        public string ThongTinRanhThang_PhanLoaiMai { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập C.Rộng mái (m)!")]
        public string ThongTinRanhThang_CRongMai { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập C.Dầy mái !")]
        public string ThongTinRanhThang_CDayMai { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập Số lượng mái!")]
        public string ThongTinRanhThang_SoLuongMai { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập Phân loại giằng đỉnh!")]
        public string ThongTinRanhThang_PhanLoaiGiangDinh { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập C.Cao lót giằng đỉnh!")]
        public string ThongTinRanhThang_CCaoLotGiangDinh { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập C.Rộng lót giằng đỉnh !")]
        public string ThongTinRanhThang_CRongLotGiangDinh { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập Số lượng lót giằng đỉnh!")]
        public string ThongTinRanhThang_SoLuongLotGiangDinh { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập C.Cao móng giằng đỉnh !")]
        public string ThongTinRanhThang_CCaoMongGiangDinh { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập C.Rộng móng giằng đỉnh!")]
        public string ThongTinRanhThang_CRongMongGiangDinh { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập Số lượng móng giằng đỉnh !")]
        public string ThongTinRanhThang_SoLuongMongGiangDinh { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập Phân loại hành lang bảo vệ !")]
        public string ThongTinRanhThang_PhanLoaiHanhLangBaoVe { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập C.Cao hàng lang bảo vệ !")]
        public string ThongTinRanhThang_CCaoHangLangBaoVe { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập C.Rộng hành lang bảo vệ !")]
        public string ThongTinRanhThang_CRongHanhLangBaoVe { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập !")]
        public string ThongTinRanhThang_SoLuongHangLangBaoVe { get; set; }

        //Thông tin tấm đan cống hộp, rãnh
        [Required(ErrorMessage = "Bạn phải nhập Tên loại tấm đan tiêu chuẩn!")]  
        public string TTTDCongHoRanh_TenLoaiTamDanTieuChuan { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập Cấu tạo tấm đan truyền dẫn tấm đan tiêu chuẩn!")]
        public string TTTDCongHoRanh_CauTaoTamDanTruyenDanTamDanTieuChuan { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập Số lượng !")]
        public string TTTDCongHoRanh_SoLuong { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập C.Dài  !")]
        public string TTTDCongHoRanh_CDai { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập C.Rộng!")]
        public string TTTDCongHoRanh_CRong { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập  C.Cao!")]
        public string TTTDCongHoRanh_CCao { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập Tên loại tấm đan loại 02!")]
        public string TTTDCongHoRanh_TenLoaiTamDanLoai02 { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập Cấu tạo tấm đan truyền dẫn !")]
        public string TTTDCongHoRanh_CauTaoTamDanTruyenDan { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập sô lượng !")]
        public string TTTDCongHoRanh_SoLuong1 { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập chiều dài!")]
        public string TTTDCongHoRanh_CDai1 { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập chiều rông!")]
        public string TTTDCongHoRanh_CRong1 { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập chiều cao!")]
        public string TTTDCongHoRanh_CCao1 { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập chiều dài mối nối!")]
        public string TTTDCongHoRanh_ChieuDaiMoiNoi { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập Số lượng T.Đan dùng để tính chiều dài bổ sung (C.Kiện) !")]
        public string TTTDCongHoRanh_SoLuongTDanDungDeTinhChieuDaiBoSung { get; set; }

        //Cao độ thượng lưu
        [Required(ErrorMessage = "Bạn phải nhập Hiện trạng trước khi đào thượng lưu !")]   
        public string CDThuongLuu_HienTrangTruocKhiDaoThuongLuu { get; set; }
       
        [Required(ErrorMessage = "Bạn phải nhập Đáy dòng chảy!")]
        public string CDThuongLuu_DayDongChay { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập Đỉnh trong lòng sử dụng!")]
        public string CDThuongLuu_DinhTrongLongSuDung { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập Chiều cao rãnh thang từ đáy dòng chảy đến đỉnh !")]
        public string CDThuongLuu_ChieuCaoRanhThangTuDayDongChayDenDinh { get; set; }

        //Cao độ hạ lưu
        [Required(ErrorMessage = "Bạn phải nhập Hiện trạng trước khi đào hạ lưu (m)!")]   
        public string CDHaLu_HienTrangTruocKhiDaoHaLuu { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập đáy dòng chảy!")]
        public string CDHaLu_DayDongChay { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập Đỉnh trong lòng sử dụng!")]
        public string CDHaLu_DinhTrongLongSuDung { get; set; }
       
        [Required(ErrorMessage = "Bạn phải nhập Chiều cao rãnh thang từ đáy dòng chảy đến đỉnh!")]
        public string CDHaLu_ChieuCaoRanhThangTuDayDongChayDenDinh { get; set; }


        //Thông tin vật liệu đào cống, rãnh
        [Required(ErrorMessage = "Bạn phải nhập Loại vật liệu đào!")]
        public string TTVLDCongRanh_LoaiVatLieuDao { get; set; }
        
        [Required(ErrorMessage = "Bạn phải nhập Chiều cao đào đá!")]
        public string TTVLDCongRanh_TLChieuCaoDaoDa { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập Chiều cao đào đá!")]
        public string TTVLDCongRanh_HLChieuCaoDaoDa { get; set; }

        //Thông tin mái đào
        //Thông tin mái đào cống, rãnh, ống nhựa, rãnh thang

        [Required(ErrorMessage = "Bạn phải nhập Chiều rộng đáy đào nhỏ!")]
        public string TTMDRanhOngThang_ChieuRongDayDaoNho { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập Tỷ lệ mở mái!")]
        public string TTMDRanhOngThang_TyLeMoMai { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập Số cạnh mái trái!")]
        public string TTMDRanhOngThang_SoCanhMaiTrai { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập Số cạnh mái phải!")]
        public string TTMDRanhOngThang_SoCanhMaiPhai { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập Chiều rộng đáy đào nhỏ!")]
        public string TTMDRanhOngThang_ChieuRongDayDaoNho1 { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập Tỷ lệ mở mái!")]
        public string TTMDRanhOngThang_TyLeMoMai1 { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập Số cạnh mái trái!")]
        public string TTMDRanhOngThang_SoCanhMaiTrai1 { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập Số cạnh mái phải!")]
        public string TTMDRanhOngThang_SoCanhMaiPhai1 { get; set; }

        //Tọa độ
        [Required(ErrorMessage = "Bạn phải nhập tọa độ X")]
        public string TuToaDoX { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập tọa độ Y")]
        public string TuToaDoY { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập tọa độ X")]
        public string DenToaDoX { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập tọa độ Y")]
        public string DenToaDoY { get; set; }

    }
}
