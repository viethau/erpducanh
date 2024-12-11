using System.ComponentModel.DataAnnotations;

namespace DucAnhERP.Models
{
    public class PhanLoaiHoGa
    {
        public string Id { get; set; }  = Guid.NewGuid().ToString();
        public int Flag { get; set; }  = 0;

        [Required(ErrorMessage = "Bạn phải nhập Tên hố ga sau phân loại !")]
        public string ThongTinChungHoGa_TenHoGaSauPhanLoai { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập hình thức hố ga!")]
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
        public double? BeTongMongHoGa_C { get; set; } = 0;
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
        public double? TuongHoGa_C { get; set; } = 0;
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
        public double? ChatMatTrong_C { get; set; } = 0;
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
        public double? ChatMatNgoaiCanh_C { get; set; } = 0 ;
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
        public DateTime? CreateAt { get; set; } = DateTime.Now;
        public string? CreateBy { get; set; } = "";
        public int? IsActive { get; set; } = 1;
    }
}
