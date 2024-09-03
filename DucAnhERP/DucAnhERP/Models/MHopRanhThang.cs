using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace DucAnhERP.Models
{
    public class MHopRanhThang
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        //Thông tin lý trình
        [Required(ErrorMessage = "Bạn phải nhập Tuyến đường!")]
        public string ThongTinLyTrinh_TuyenDuong { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập Lý trình tại tim hố ga!")]
        public string ThongTinLyTrinh_LyTrinhTaiTimHoGa { get; set; }
        //Thông tin chung hố ga
        //[Required(ErrorMessage = "Bạn phải nhập Tên hố ga sau phân loại !")]
        public string ThongTinChungHoGa_TenHoGaSauPhanLoai { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập Tên hố ga theo bản vẽ!")]
        public string ThongTinChungHoGa_TenHoGaTheoBanVe { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập Hình thức hố ga !")]
        public string ThongTinChungHoGa_HinhThucHoGa { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập  kết cấu mũ mố !")]
        public string ThongTinChungHoGa_KetCauMuMo { get; set; }

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

        [Required(ErrorMessage = "Bạn phải nhập chiều dài!")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public double? PhuBiHoGa_CDai { get; set; } = 0;


        [Required(ErrorMessage = "Bạn phải nhập chiều rộng !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]

        public double? PhuBiHoGa_CRong { get; set; } = 0;
        //2.Kích thước hình học bê tông lót móng hố ga (m) BeTongLotMong
        [Required(ErrorMessage = "Bạn phải nhập chiều dài  !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]

        public double? BeTongLotMong_D { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập chiều rộng !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]

        public double? BeTongLotMong_R { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập chiều cao !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]

        public double? BeTongLotMong_C { get; set; } = 0;
        //3.Kích thước hình học bê tông móng hố ga (m)	BeTongMongHoGa
        [Required(ErrorMessage = "Bạn phải nhập chiều dài  !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]

        public double? BeTongMongHoGa_D { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập chiều rộng !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]

        public double? BeTongMongHoGa_R { get; set; } = 0;

        [Required(ErrorMessage = "Bạn phải nhập chiều cao !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public double? TBeTongMongHoGa_C { get; set; } = 0;
        //4.KTHH đế hố ga		DeHoGa

        [Required(ErrorMessage = "Bạn phải nhập chiều dài  !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public double? DeHoGa_D { get; set; } = 0;

        [Required(ErrorMessage = "Bạn phải nhập chiều rộng !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public double? DeHoGa_R { get; set; } = 0;

        [Required(ErrorMessage = "Bạn phải nhập chiều cao !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public double? DeHoGa_C { get; set; } = 0;

        //5.Kích thước hình học tường hố ga (m)	TuongHoGa		
        [Required(ErrorMessage = "Bạn phải nhập chiều dài !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public double? TuongHoGa_D { get; set; } = 0;

        [Required(ErrorMessage = "Bạn phải nhập chiều rộng !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public double? TuongHoGa_R { get; set; } = 0;

        //[Required(ErrorMessage = "Bạn phải nhập chiều cao !")]
        //public string TuongHoGa_C { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập chiều dài tường !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public double? TuongHoGa_CdTuong { get; set; } = 0;

        //6.KTHH dầm giữa hố ga	 DamGiuaHoGa

        [Required(ErrorMessage = "Bạn phải nhập chiều dài  !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public double? DamGiuaHoGa_D { get; set; } = 0;

        [Required(ErrorMessage = "Bạn phải nhập chiều rộng !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public double? DamGiuaHoGa_R { get; set; } = 0;

        [Required(ErrorMessage = "Bạn phải nhập chiều cao !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public double? DamGiuaHoGa_C { get; set; } = 0;

        [Required(ErrorMessage = "Bạn phải dài dầm!")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public double? DamGiuaHoGa_CdDam { get; set; } = 0;

        [Required(ErrorMessage = "Bạn phải nhập chiều dài dầm so với đáy hố ga ")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public double? DamGiuaHoGa_CCaoDamGiuaTuongSoVoiDayHoGa { get; set; } = 0;

        //7.Chát hố ga mặt trong 		ChatMatTrong
        [Required(ErrorMessage = "Bạn phải nhập chiều dài !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public double? ChatMatTrong_D { get; set; } = 0;

        [Required(ErrorMessage = "Bạn phải nhập chiều rộng !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public double? ChatMatTrong_R { get; set; } = 0;

        //[Required(ErrorMessage = "Bạn phải nhập chiều cao !")]
        //public string ChatMatTrong_C { get; set; }
        //8.Chát hố ga mặt ngoài, cạnh 01 +02 (m) ChatMatNgoaiCanh
        [Required(ErrorMessage = "Bạn phải nhập chiều dài  !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public double? ChatMatNgoaiCanh_D { get; set; } = 0;

        [Required(ErrorMessage = "Bạn phải nhập chiều rộng !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public double? ChatMatNgoaiCanh_R { get; set; } = 0;

        //[Required(ErrorMessage = "Bạn phải nhập chiều cao !")]
        //public string ChatMatNgoaiCanh_C { get; set; } ;
        //9.Kích thước hình học tường mũ mố thớt dưới (m) MuMoThotDuoi
        [Required(ErrorMessage = "Bạn phải nhập chiều dài  !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public double? MuMoThotDuoi_D { get; set; } = 0;

        [Required(ErrorMessage = "Bạn phải nhập chiều rộng !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public double? MuMoThotDuoi_R { get; set; } = 0;

        [Required(ErrorMessage = "Bạn phải nhập chiều cao !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public double? MuMoThotDuoi_C { get; set; } = 0;

        [Required(ErrorMessage = "Bạn phải nhập chiều dài tường !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public double? MuMoThotDuoi_CdTuong { get; set; } = 0;

        //10.Kích thước hình học tường mũ mố thớt trên (m)	 MuMoThotTren	
        [Required(ErrorMessage = "Bạn phải nhập chiều dài  !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public double? MuMoThotTren_D { get; set; } = 0;

        [Required(ErrorMessage = "Bạn phải nhập chiều rộng !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public double? MuMoThotTren_R { get; set; } = 0;

        [Required(ErrorMessage = "Bạn phải nhập chiều cao !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public double? MuMoThotTren_C { get; set; } = 0;

        [Required(ErrorMessage = "Bạn phải nhập chiều dài tường !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public double? MuMoThotTren_CdTuong { get; set; } = 0;


        //Hạng mục chiếm chỗ hố ga
        //1.Hình thức đấu nối    HinhThucDauNoi1
        [Required(ErrorMessage = "Bạn phải nhập loại !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public double? HinhThucDauNoi1_Loai { get; set; } = 0;

        [Required(ErrorMessage = "Bạn phải nhập cạnh dài !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public double? HinhThucDauNoi1_CanhDai { get; set; } = 0;

        [Required(ErrorMessage = "Bạn phải nhập cạnh rộng !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public double? HinhThucDauNoi1_CanhRong { get; set; } = 0;

        [Required(ErrorMessage = "Bạn phải nhập cạnh cheo !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public double? HinhThucDauNoi1_CanhCheo { get; set; } = 0;

        //2.Hình thức đấu nối    HinhThucDauNoi2
        [Required(ErrorMessage = "Bạn phải nhập loại !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public double? HinhThucDauNoi2_Loai { get; set; } = 0;

        [Required(ErrorMessage = "Bạn phải nhập cạnh dài !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public double? HinhThucDauNoi2_CanhDai { get; set; } = 0;

        [Required(ErrorMessage = "Bạn phải nhập cạnh rộng !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public double? HinhThucDauNoi2_CanhRong { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập cạnh cheo !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public double? HinhThucDauNoi2_CanhCheo { get; set; } = 0;


        //3.Hình thức đấu nối    HinhThucDauNoi3
        [Required(ErrorMessage = "Bạn phải nhập loại !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public double? HinhThucDauNoi3_Loai { get; set; } = 0;

        [Required(ErrorMessage = "Bạn phải nhập cạnh dài !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public double? HinhThucDauNoi3_CanhDai { get; set; } = 0;

        [Required(ErrorMessage = "Bạn phải nhập cạnh rộng !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public double? HinhThucDauNoi3_CanhRong { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập cạnh chéo !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public double? HinhThucDauNoi3_CanhCheo { get; set; } = 0;

        //4.Hình thức đấu nối    HinhThucDauNoi4
        [Required(ErrorMessage = "Bạn phải nhập loại !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public double? HinhThucDauNoi4_Loai { get; set; } = 0;

        [Required(ErrorMessage = "Bạn phải nhập cạnh dài !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public double? HinhThucDauNoi4_CanhDai { get; set; } = 0;

        [Required(ErrorMessage = "Bạn phải nhập cạnh rộng !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public double? HinhThucDauNoi4_CanhRong { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập cạnh chéo !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public double? HinhThucDauNoi4_CanhCheo { get; set; } = 0;

        //5.Hình thức đấu nối    HinhThucDauNoi5
        [Required(ErrorMessage = "Bạn phải nhập loại !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public double? HinhThucDauNoi5_Loai { get; set; } = 0;

        [Required(ErrorMessage = "Bạn phải nhập cạnh dài !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public double? HinhThucDauNoi5_CanhDai { get; set; } = 0;

        [Required(ErrorMessage = "Bạn phải nhập cạnh rộng !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public double? HinhThucDauNoi5_CanhRong { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập cạnh cheo !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public double? HinhThucDauNoi5_CanhCheo { get; set; } = 0;

        //6.Hình thức đấu nối    HinhThucDauNoi6
        [Required(ErrorMessage = "Bạn phải nhập loại !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public double? HinhThucDauNoi6_Loai { get; set; } = 0;

        [Required(ErrorMessage = "Bạn phải nhập cạnh dài !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public double? HinhThucDauNoi6_CanhDai { get; set; } = 0;

        [Required(ErrorMessage = "Bạn phải nhập cạnh rộng !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public double? HinhThucDauNoi6_CanhRong { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập cạnh cheo !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public double? HinhThucDauNoi6_CanhCheo { get; set; } = 0;

        //7.Hình thức đấu nối    HinhThucDauNoi7
        [Required(ErrorMessage = "Bạn phải nhập loại !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public double? HinhThucDauNoi7_Loai { get; set; } = 0;

        [Required(ErrorMessage = "Bạn phải nhập cạnh dài !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public double? HinhThucDauNoi7_CanhDai { get; set; } = 0;

        [Required(ErrorMessage = "Bạn phải nhập cạnh rộng !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public double? HinhThucDauNoi7_CanhRong { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập cạnh cheo !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public double? HinhThucDauNoi7_CanhCheo { get; set; } = 0;

        //8.Hình thức đấu nối    HinhThucDauNoi8
        [Required(ErrorMessage = "Bạn phải nhập loại !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public double? HinhThucDauNoi8_Loai { get; set; } = 0;

        [Required(ErrorMessage = "Bạn phải nhập cạnh dài !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public double? HinhThucDauNoi8_CanhDai { get; set; } = 0;

        [Required(ErrorMessage = "Bạn phải nhập cạnh rộng !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public double? HinhThucDauNoi8_CanhRong { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập cạnh cheo !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public double? HinhThucDauNoi8_CanhCheo { get; set; } = 0;

        //Thông tin tấm đan hố ga ThongTinTamDanHoGa2

        //[Required(ErrorMessage = "Bạn phải nhập Phân loại đậy hố ga !")]
        public string ThongTinTamDanHoGa2_PhanLoaiDayHoGa { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập Hình thức đậy hố ga !")]
        public string ThongTinTamDanHoGa2_HinhThucDayHoGa { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập Đường kính (m) !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public double? ThongTinTamDanHoGa2_DuongKinh { get; set; } = 0;

        [Required(ErrorMessage = "Bạn phải nhập Chiều dầy (m) !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public double? ThongTinTamDanHoGa2_ChieuDay { get; set; } = 0;

        [Required(ErrorMessage = "Bạn phải nhập chiều dài !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public double? ThongTinTamDanHoGa2_D { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập chiều rộng  !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public double? ThongTinTamDanHoGa2_R { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập chiều cao !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public double? ThongTinTamDanHoGa2_C { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập số lượng nắp đậy !")]
        [Range(0, int.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        public int ThongTinTamDanHoGa2_SoLuongNapDay { get; set; } = 0;

        //Thông tin vật liệu đào hố ga
        [Required(ErrorMessage = "Bạn phải nhập loại vật liệu đào!")]
        public string ThongTinVatLieuDaoHoGa_LoaiVatLieuDao { get; set; }

        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        [Required(ErrorMessage = "Bạn phải nhập chiều cao đào đá!")]
        public double? ThongTinVatLieuDaoHoGa_ChieuCaoDaoDa { get; set; } = 0;
        //[Required(ErrorMessage = "Bạn phải nhập chiều cao đào đất!")]
        //public string ThongTinVatLieuDaoHoGa_ChieuCaoDaoDat { get; set; }
        //[Required(ErrorMessage = "Bạn phải nhập tổng chiều cao!")]
        //public string ThongTinVatLieuDaoHoGa_TongChieuCaoDao { get; set; }

        //Thông tin cao độ hố ga

        [Required(ErrorMessage = "Bạn phải nhập cao độ tự nhiên!")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public double? ThongTinCaoDoHoGa_CaoDoTuNhien { get; set; } = 0;

        [Required(ErrorMessage = "Bạn phải nhập CĐ đỉnh vỉa hè hoàn thiện !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public double? ThongTinCaoDoHoGa_CdDinhViaHeHoanThien { get; set; } = 0;

        [Required(ErrorMessage = "Bạn phải nhập Cao độ đỉnh K98)!")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public double? ThongTinCaoDoHoGa_CaoDoDinhK98 { get; set; } = 0;

        //[Required(ErrorMessage = "Bạn phải nhập Cao độ hiện trạng trước khi đào (m) !")]
        //public string ThongTinCaoDoHoGa_CaoDoHienTrangTruocKhiDao { get; set; } ;
        //[Required(ErrorMessage = "Bạn phải nhập Đáy đào !")]
        //public string ThongTinCaoDoHoGa_DayDao { get; set; } ;
        //[Required(ErrorMessage = "Bạn phải nhập C.Sâu đào !")]
        //public string ThongTinCaoDoHoGa_CSauDao { get; set; }
        //[Required(ErrorMessage = "Bạn phải nhập Đỉnh lót móng !")]
        //public string ThongTinCaoDoHoGa_DinhLotMong { get; set; }
        //[Required(ErrorMessage = "Bạn phải nhập CĐ đỉnh móng !")]
        //public string ThongTinCaoDoHoGa_CdDinhMong { get; set; } ;
        [Required(ErrorMessage = "Bạn phải nhập CĐ đáy hố ga !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public double? ThongTinCaoDoHoGa_CdDayHoGa { get; set; } = 0;

        //[Required(ErrorMessage = "Bạn phải nhập C.Cao tường !")]
        //public string ThongTinCaoDoHoGa_CCaoTuong { get; set; }
        //[Required(ErrorMessage = "Bạn phải nhập Đỉnh tường dưới dầm giữa tường !")]
        //public string ThongTinCaoDoHoGa_DinhTuongDuoiDamGiuaTuong { get; set; }
        //[Required(ErrorMessage = "Bạn phải nhập đỉnh dầm giữa tường !")]
        //public string ThongTinCaoDoHoGa_DinhDamGiuaTuong { get; set; } ;
        //[Required(ErrorMessage = "Bạn phải nhập Đỉnh tường !")]
        //public string ThongTinCaoDoHoGa_DinhTuong { get; set; }
        //[Required(ErrorMessage = "Bạn phải nhập Đỉnh mũ mố thớt dưới !")]
        //public string ThongTinCaoDoHoGa_DinhMuMoThotDuoi { get; set; } ;

        [Required(ErrorMessage = "Bạn phải nhập CĐ đỉnh hố ga!")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public double? ThongTinCaoDoHoGa_CdDinhHoGa { get; set; } = 0;

        //[Required(ErrorMessage = "Bạn phải nhập Tổng chiều cao hố ga !")]
        //public string ThongTinCaoDoHoGa_TongChieuCaoHoGa { get; set; } ;
        //[Required(ErrorMessage = "Bạn phải nhập Chênh cao đỉnh hố ga và hiện trạng đào!")]
        //public string ThongTinCaoDoHoGa_ChenhCaoDinhHoGaVaHienTrangDao { get; set; } ;
        //[Required(ErrorMessage = "Bạn phải nhập Tổng chiều cao chiếm chỗ đắp trả!")]
        //public string ThongTinCaoDoHoGa_TongChieuCaoChiemChoDapTra { get; set; } ;

        //Thông tin mái đào
        [Required(ErrorMessage = "Bạn phải nhập Chiều rộng đáy đào nhỏ!")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public double? ThongTinMaiDao_ChieuRongDayDaoNho { get; set; } = 0;

        [Required(ErrorMessage = "Bạn phải nhập Tỷ lệ mở mái!")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public double? ThongTinMaiDao_TyLeMoMai { get; set; } = 0;

        [Required(ErrorMessage = "Bạn phải nhập Số cạnh mái trái !")]
        [Range(0, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        public int ThongTinMaiDao_SoCanhMaiTrai { get; set; } = 0;

        [Required(ErrorMessage = "Bạn phải nhập số cạnh mái phải !")]
        [Range(0, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        public int ThongTinMaiDao_SoCanhMaiPhai { get; set; } = 0;

        //Tọa độ
        [Display(Name = "Tọa độ X")]
        [Required(ErrorMessage = "Bạn phải nhập tọa độ X!")]
        [RegularExpression(@"^-?\d+(\.\d{1,6})?$", ErrorMessage = "Tọa độ X phải là số hợp lệ với tối đa 6 chữ số thập phân.")]
        public double? ToaDoX { get; set; } = 0;

        [Display(Name = "Tọa độ X")]
        [Required(ErrorMessage = "Bạn phải nhập tọa độ Y!")]
        [RegularExpression(@"^-?\d+(\.\d{1,6})?$", ErrorMessage = "Tọa độ X phải là số hợp lệ với tối đa 6 chữ số thập phân.")]
        public double? ToaDoY { get; set; } = 0;



        //Thông tin lý trình truyền dẫn
        [Required(ErrorMessage = "Bạn phải nhập Từ lý trình!")]
        [Range(0.000, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,5})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 5 chữ số thập phân.")]
        public double? ThongTinLyTrinhTruyenDan_TuLyTrinh { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập Đến lý trình!")]
        [Range(0.000, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,5})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 5 chữ số thập phân.")]
        public double? ThongTinLyTrinhTruyenDan_DenLyTrinh { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập Từ hố ga !")]
        public string ThongTinLyTrinhTruyenDan_TuHoGa { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập Đến hố ga !")]
        public string ThongTinLyTrinhTruyenDan_DenHoGa { get; set; }

        //Thông tin đường truyền dẫn
        [Required(ErrorMessage = "Bạn phải nhập Hình thức truyền dẫn!")]
        public string ThongTinDuongTruyenDan_HinhThucTruyenDan { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập Loại truyền dẫn !")]
        public string ThongTinDuongTruyenDan_LoaiTruyenDan { get; set; }
        //[Required(ErrorMessage = "Bạn phải nhập Tên loại truyền dẫn sau phân loại!")]
        public string ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai { get; set; } = "";

        //Thông tin chiều dài và số lượng cấu kiện đường truyền dẫn
        [Required(ErrorMessage = "Bạn phải nhập Chiều dài 01 cấu kiện (m) !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public double? TTCDSLCauKienDuongTruyenDan_ChieuDai01CauKien { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập Chiều dài mối nối C.Kiện!")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public double? TTCDSLCauKienDuongTruyenDan_ChieuDaiMoiNoiCKien { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập Số lượng C.Kiện dùng để tính chiều dài bổ sung (C.Kiện)!")]
        [Range(0, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        public int TTCDSLCauKienDuongTruyenDan_SoLuongCKienDungDeTinhChieuDaiBoSung { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập tổng chiều dài!")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        public double? TTCDSLCauKienDuongTruyenDan_TongChieuDai { get; set; } = 0;

        //Thông tin móng đường truyền dẫn

        //[Required(ErrorMessage = "Bạn phải nhập Phân loại móng cống tròn, cống hộp!")]
        public string ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop { get; set; } = "";
        [Required(ErrorMessage = "Bạn phải nhập loại móng!")]
        public string ThongTinMongDuongTruyenDan_LoaiMong { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập hình thức móng!")]
        public string ThongTinMongDuongTruyenDan_HinhThucMong { get; set; } 

        //Thông tin đế cống
        //[Required(ErrorMessage = "Bạn phải nhập tên loại đế cống!")]
        public string ThongTinDeCong_TenLoaiDeCong { get; set; } = "";
        //[Required(ErrorMessage = "Bạn phải nhập cấu tạo đế cống!")]
        public string ThongTinDeCong_CauTaoDeCong { get; set; } = "";

        [Required(ErrorMessage = "Bạn phải nhập chiều dài!")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public double? ThongTinDeCong_D { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập chiều rộng!")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public double? ThongTinDeCong_R { get; set; } = 0;

        [Required(ErrorMessage = "Bạn phải nhập chiều cao!")]
        [Range(0, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        public double? ThongTinDeCong_C { get; set; } = 0;

        [Required(ErrorMessage = "Bạn phải nhập SL đế cống/01 cấu kiện truyền dẫn (C.Kiện) !")]
        [Range(0, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        public double? ThongTinDeCong_SlDeCong01CauKienTruyenDan { get; set; } = 0;

        [Required(ErrorMessage = "Bạn phải nhập  KL 01 đế cống!")]
        [Range(0, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        public double? ThongTinDeCong_Kl01DeCong { get; set; } = 0;

        //Thông tin cấu tạo cống tròn
        [Required(ErrorMessage = "Bạn phải nhập Dầy phủ bì !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public double? ThongTinCauTaoCongTron_CDayPhuBi { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập Số cạnh!")]
        [Range(0, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        public double? ThongTinCauTaoCongTron_SoCanh { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập Lòng sử dụng!")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public double? ThongTinCauTaoCongTron_LongSuDung { get; set; } = 0;

        [Required(ErrorMessage = "Bạn phải nhập C.Cao lót móng (m)!")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public double? ThongTinCauTaoCongTron_CCaoLotMong { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập C.Rộng lót móng!")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public double? ThongTinCauTaoCongTron_CRongLotMong { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập C.Cao móng!")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public double? ThongTinCauTaoCongTron_CCaoMong { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập C.Rộng móng !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public double? ThongTinCauTaoCongTron_CRongMong { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập C.Cao đế (tại vị trí đặt C.Kiện) (m)!")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public double? ThongTinCauTaoCongTron_CCaoDe { get; set; } = 0;

        //Thông tin kích thước hình học cống hộp, rãnh
        //[Required(ErrorMessage = "Bạn phải nhập cấu tạo tường!")]
        public string TTKTHHCongHopRanh_CauTaoTuong { get; set; } = "";
        //[Required(ErrorMessage = "Bạn phải nhập cấu tạo mũ mố!")]
        public string TTKTHHCongHopRanh_CauTaoMuMo { get; set; } = "";
        //[Required(ErrorMessage = "Bạn phải nhập Chát mặt trong !")]
        public string TTKTHHCongHopRanh_ChatMatTrong { get; set; } = "";
        //[Required(ErrorMessage = "Bạn phải nhập Chát mặt ngoài!")]
        public string TTKTHHCongHopRanh_ChatMatNgoai { get; set; } = "";

        [Required(ErrorMessage = "Bạn phải nhập C.Cao lót móng !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public double? TTKTHHCongHopRanh_CCaoLotMong { get; set; } = 0;

        [Required(ErrorMessage = "Bạn phải nhập C.Rộng lót móng!")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public double? TTKTHHCongHopRanh_CRongLotMong { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập C.Cao móng !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public double? TTKTHHCongHopRanh_CCaoMong { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập  C.Rộng móng!")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public double? TTKTHHCongHopRanh_CRongMong { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập C.Cao đế !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public double? TTKTHHCongHopRanh_CCaoDe { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhậpC.Rộng đế !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public double? TTKTHHCongHopRanh_CRongDe { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập C.Dầy tường 01 bên!")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public double? TTKTHHCongHopRanh_CDayTuong01Ben { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập Số lượng tường !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public double? TTKTHHCongHopRanh_SoLuongTuong { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập C.Rộng lòng sử dụng !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public double? TTKTHHCongHopRanh_CRongLongSuDung { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập C.Cao tường cống hộp!")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public double? TTKTHHCongHopRanh_CCaoTuongCongHop { get; set; } = 0;
        //[Required(ErrorMessage = "Bạn phải nhập C.Cao tường rãnh!")]
        //public string TTKTHHCongHopRanh_CCaoTuongRanh { get; set; }
        //[Required(ErrorMessage = "Bạn phải nhập C.Cao tường gộp !")]
        //public string TTKTHHCongHopRanh_CCaoTuongGop { get; set; } ;

        [Required(ErrorMessage = "Bạn phải nhập C.Cao mũ mố thớt dưới!")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public double? TTKTHHCongHopRanh_CCaoMuMoThotDuoi { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập C.Rộng mũ mố dưới!")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public double? TTKTHHCongHopRanh_CRongMuMoDuoi { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập C.Cao mũ mố thớt trên !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public double? TTKTHHCongHopRanh_CCaoMuMoThotTren { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập C.Rộng mũ mố trên !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public double? TTKTHHCongHopRanh_CRongMuMoTren { get; set; } = 0;
        //[Required(ErrorMessage = "Bạn phải nhập Loại thanh chống !")]
        public string TTKTHHCongHopRanh_LoaiThanhChong { get; set; } = "";
        //[Required(ErrorMessage = "Bạn phải nhập Cấu tạo thanh chống!")]
        public string TTKTHHCongHopRanh_CauTaoThanhChong { get; set; } = "";

        [Required(ErrorMessage = "Bạn phải nhập C.Cao thanh chống!")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public double? TTKTHHCongHopRanh_CCaoThanhChong { get; set; } = 0;

        [Required(ErrorMessage = "Bạn phải nhập C.Rộng thanh chống!")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public double? TTKTHHCongHopRanh_CRongThanhChong { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập C.Dài !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public double? TTKTHHCongHopRanh_CDai { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập Số lượng thanh chống !")]
        [Range(0, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        public double? TTKTHHCongHopRanh_SoLuongThanhChong { get; set; } = 0;

        //Thông tin kích thước hình học ống nhựa
        [Required(ErrorMessage = "Bạn phải nhập C.Dầy phủ bì!")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public double? ThongTinKichThuocHinhHocOngNhua_CDayPhuBi { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập số cạnh!")]
        [Range(0, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        public int ThongTinKichThuocHinhHocOngNhua_SoCanh { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập Lòng sử dụng !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public double? ThongTinKichThuocHinhHocOngNhua_LongSuDung { get; set; } = 0;
        //[Required(ErrorMessage = "Bạn phải nhập Tổng C.Cao ống !")]
        //[Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        //[RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        //public Double ThongTinKichThuocHinhHocOngNhua_TongCCaoOng { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập  C.Cao đệm cát!")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public double? ThongTinKichThuocHinhHocOngNhua_CCaoDemCat { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập C.Cao đắp cát !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public double? ThongTinKichThuocHinhHocOngNhua_CCaoDapCat { get; set; } = 0;

        //Thông tin rãnh thang
        //[Required(ErrorMessage = "Bạn phải nhập Hình thức mái !")]
        public string ThongTinRanhThang_HinhThucMai { get; set; } = "";
        //[Required(ErrorMessage = "Bạn phải nhập Cấu tạo chân khay !")]
        public string ThongTinRanhThang_CauTaoChanKhay { get; set; } = "";
        //[Required(ErrorMessage = "Bạn phải nhập Cấu tạo giằng đỉnh!")]
        public string ThongTinRanhThang_CauTaoGiangDinh { get; set; } = "";
        //[Required(ErrorMessage = "Bạn phải nhập Hình thức hành lang bảo vệ !")]
        public string ThongTinRanhThang_HinhThucHanhLangBaoVe { get; set; } = "";
        //[Required(ErrorMessage = "Bạn phải nhập Phân loại chân khay!")]
        public string ThongTinRanhThang_PhanLoaiChanKhay { get; set; } = "";
        [Required(ErrorMessage = "Bạn phải nhập C.Cao lót chân khay !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public double? ThongTinRanhThang_CCaoLotChanKhay { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập  C.Rộng lót chân khay !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public double? ThongTinRanhThang_CRongLotChanKhay { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập Số lượng lót chân khay !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public double? ThongTinRanhThang_SoLuongLotChanKhay { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập C.Cao móng chân khay!")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public double? ThongTinRanhThang_CCaoMongChanKhay { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập C.Rộng móng chân khay!")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public double? ThongTinRanhThang_CRongMongChanKhay { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập Số lượng móng chân khay !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public int ThongTinRanhThang_SoLuongMongChanKhay { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập C.Cao lót !")]
        [Range(0, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        public double? ThongTinRanhThang_CCaoLot { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập C.Rộng lót!")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public double? ThongTinRanhThang_CRongLot { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập C.Cao móng !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public double? ThongTinRanhThang_CCaoMong { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập C.Rộng móng !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public double? ThongTinRanhThang_CRongMong { get; set; } = 0;
        //[Required(ErrorMessage = "Bạn phải nhập Phân loại mái !")]
        public string ThongTinRanhThang_PhanLoaiMai { get; set; } = "";
        [Required(ErrorMessage = "Bạn phải nhập C.Rộng mái (m)!")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public double? ThongTinRanhThang_CRongMai { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập C.Dầy mái !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public double? ThongTinRanhThang_CDayMai { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập Số lượng mái!")]
        [Range(0, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        public int ThongTinRanhThang_SoLuongMai { get; set; } = 0;
        //[Required(ErrorMessage = "Bạn phải nhập Phân loại giằng đỉnh!")]
        public string ThongTinRanhThang_PhanLoaiGiangDinh { get; set; } = "";

        [Required(ErrorMessage = "Bạn phải nhập C.Cao lót giằng đỉnh!")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public double? ThongTinRanhThang_CCaoLotGiangDinh { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập C.Rộng lót giằng đỉnh !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public double? ThongTinRanhThang_CRongLotGiangDinh { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập Số lượng lót giằng đỉnh!")]
        [Range(0, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        public int ThongTinRanhThang_SoLuongLotGiangDinh { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập C.Cao móng giằng đỉnh !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public double? ThongTinRanhThang_CCaoMongGiangDinh { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập C.Rộng móng giằng đỉnh!")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public double? ThongTinRanhThang_CRongMongGiangDinh { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập Số lượng móng giằng đỉnh !")]
        [Range(0, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        public double? ThongTinRanhThang_SoLuongMongGiangDinh { get; set; } = 0;
        //[Required(ErrorMessage = "Bạn phải nhập Phân loại hành lang bảo vệ !")]
        public string ThongTinRanhThang_PhanLoaiHanhLangBaoVe { get; set; } = "";
        [Required(ErrorMessage = "Bạn phải nhập C.Cao hàng lang bảo vệ !")]
        public double? ThongTinRanhThang_CCaoHanhLangBaoVe { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập C.Rộng hành lang bảo vệ !")]
        public double? ThongTinRanhThang_CRongHanhLangBaoVe { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập Số lượng hàng lang bảo vệ!")]
        [Range(0, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        public int ThongTinRanhThang_SoLuongHangLangBaoVe { get; set; } = 0;

        //Thông tin tấm đan cống hộp, rãnh
        //[Required(ErrorMessage = "Bạn phải nhập Tên loại tấm đan tiêu chuẩn!")]
        public string TTTDCongHoRanh_TenLoaiTamDanTieuChuan { get; set; } = "";
        //[Required(ErrorMessage = "Bạn phải nhập Cấu tạo tấm đan truyền dẫn tấm đan tiêu chuẩn!")]
        public string TTTDCongHoRanh_CauTaoTamDanTruyenDanTamDanTieuChuan { get; set; } = "";
        //[Required(ErrorMessage = "Bạn phải nhập Số lượng !")]
        //public string TTTDCongHoRanh_SoLuong { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập C.Dài  !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public double? TTTDCongHoRanh_CDai { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập C.Rộng!")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public double? TTTDCongHoRanh_CRong { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập  C.Cao!")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public double? TTTDCongHoRanh_CCao { get; set; } = 0;


        //[Required(ErrorMessage = "Bạn phải nhập Tên loại tấm đan loại 02!")]
        public string TTTDCongHoRanh_TenLoaiTamDanLoai02 { get; set; } = "";
        //[Required(ErrorMessage = "Bạn phải nhập Cấu tạo tấm đan truyền dẫn !")]
        public string TTTDCongHoRanh_CauTaoTamDanTruyenDan { get; set; } = "";
        //[Required(ErrorMessage = "Bạn phải nhập sô lượng !")]
        //public string TTTDCongHoRanh_SoLuong1 { get; set; } ;
        //[Required(ErrorMessage = "Bạn phải nhập chiều dài!")]
        //public string TTTDCongHoRanh_CDai1 { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập chiều rông!")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public double? TTTDCongHoRanh_CRong1 { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập chiều cao!")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public double? TTTDCongHoRanh_CCao1 { get; set; } = 0;

        [Required(ErrorMessage = "Bạn phải nhập chiều dài mối nối!")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public double? TTTDCongHoRanh_ChieuDaiMoiNoi { get; set; } = 0;
        [Range(0, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [Required(ErrorMessage = "Bạn phải nhập Số lượng T.Đan dùng để tính chiều dài bổ sung (C.Kiện) !")]
        public int TTTDCongHoRanh_SoLuongTDanDungDeTinhChieuDaiBoSung { get; set; } = 0;

        //Cao độ thượng lưu
        [Required(ErrorMessage = "Bạn phải nhập Hiện trạng trước khi đào thượng lưu !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public double? CDThuongLuu_HienTrangTruocKhiDaoThuongLuu { get; set; } = 0;

        [Required(ErrorMessage = "Bạn phải nhập Đáy dòng chảy!")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public double? CDThuongLuu_DayDongChay { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập Đỉnh trong lòng sử dụng!")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public double? CDThuongLuu_DinhTrongLongSuDung { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập Chiều cao rãnh thang từ đáy dòng chảy đến đỉnh !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public double? CDThuongLuu_ChieuCaoRanhThangTuDayDongChayDenDinh { get; set; } = 0;

        //Cao độ hạ lưu
        [Required(ErrorMessage = "Bạn phải nhập Hiện trạng trước khi đào hạ lưu (m)!")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public double? CDHaLu_HienTrangTruocKhiDaoHaLuu { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập đáy dòng chảy!")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public double? CDHaLu_DayDongChay { get; set; } = 0;

        [Required(ErrorMessage = "Bạn phải nhập Đỉnh trong lòng sử dụng!")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public double? CDHaLu_DinhTrongLongSuDung { get; set; } = 0;

        [Required(ErrorMessage = "Bạn phải nhập Chiều cao rãnh thang từ đáy dòng chảy đến đỉnh!")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public double? CDHaLu_ChieuCaoRanhThangTuDayDongChayDenDinh { get; set; } = 0;


        ////Thông tin vật liệu đào cống, rãnh
        [Required(ErrorMessage = "Bạn phải nhập Loại vật liệu đào!")]
        public string TTVLDCongRanh_LoaiVatLieuDao { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập Chiều cao đào đá thượng lưu!")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public double? TTVLDCongRanh_TLChieuCaoDaoDa { get; set; } = 0;

        [Required(ErrorMessage = "Bạn phải nhập Chiều cao đào đá hạ lưu!")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public double? TTVLDCongRanh_HLChieuCaoDaoDa { get; set; } = 0;

        //Thông tin mái đào
        //Thông tin mái đào cống, rãnh, ống nhựa, rãnh thang

        [Required(ErrorMessage = "Bạn phải nhập Chiều rộng đáy đào nhỏ!")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public double? TTMDRanhOngThang_ChieuRongDayDaoNho { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập Tỷ lệ mở mái!")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public double? TTMDRanhOngThang_TyLeMoMai { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập Số cạnh mái trái!")]
        [Range(0, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        public double? TTMDRanhOngThang_SoCanhMaiTrai { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập Số cạnh mái phải!")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public double? TTMDRanhOngThang_SoCanhMaiPhai { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập Chiều rộng đáy đào nhỏ!")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public double? TTMDRanhOngThang_ChieuRongDayDaoNho1 { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập Tỷ lệ mở mái!")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public double? TTMDRanhOngThang_TyLeMoMai1 { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập Số cạnh mái trái!")]
        [Range(0, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        public double? TTMDRanhOngThang_SoCanhMaiTrai1 { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập Số cạnh mái phải!")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public double? TTMDRanhOngThang_SoCanhMaiPhai1 { get; set; } = 0;

        //Tọa độ
        [Required(ErrorMessage = "Bạn phải nhập tọa độ X")]
        [RegularExpression(@"^-?\d+(\.\d{1,6})?$", ErrorMessage = "Tọa độ X phải là số hợp lệ với tối đa 6 chữ số thập phân.")]
        public double? TuToaDoX { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập tọa độ Y")]
        [RegularExpression(@"^-?\d+(\.\d{1,6})?$", ErrorMessage = "Tọa độ X phải là số hợp lệ với tối đa 6 chữ số thập phân.")]
        public double? TuToaDoY { get; set; } = 0;

        [Required(ErrorMessage = "Bạn phải nhập tọa độ X")]
        [RegularExpression(@"^-?\d+(\.\d{1,6})?$", ErrorMessage = "Tọa độ X phải là số hợp lệ với tối đa 6 chữ số thập phân.")]
        public double? DenToaDoX { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập tọa độ Y")]
        [RegularExpression(@"^-?\d+(\.\d{1,6})?$", ErrorMessage = "Tọa độ X phải là số hợp lệ với tối đa 6 chữ số thập phân.")]
        public double? DenToaDoY { get; set; } = 0;

        public DateTime CreateAt { get; set; } = DateTime.Now;

    }

}

