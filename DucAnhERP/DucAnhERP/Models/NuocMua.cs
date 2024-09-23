using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace DucAnhERP.Models
{
    public class NuocMua
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [Required(ErrorMessage = "Bạn phải nhập Tuyến đường!")]
        //Thông tin lý trình
        public string? ThongTinLyTrinh_TuyenDuong { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập Lý trình tại tim hố ga!")]
        public string? ThongTinLyTrinh_LyTrinhTaiTimHoGa { get; set; }
        
        //Thông tin chung hố ga
        //[Required(ErrorMessage = "Bạn phải nhập Tên hố ga sau phân loại !")]
        public string ThongTinChungHoGa_TenHoGaSauPhanLoai { get; set; } = "";
        [Required(ErrorMessage = "Bạn phải nhập Tên hố ga theo bản vẽ!")]
        public string ThongTinChungHoGa_TenHoGaTheoBanVe { get; set; } = "";
        [Required(ErrorMessage = "Bạn phải nhập Hình thức hố ga !")]
        public string ThongTinChungHoGa_HinhThucHoGa { get; set; } = "";
        [Required(ErrorMessage = "Bạn phải nhập  kết cấu mũ mố !")]
        public string ThongTinChungHoGa_KetCauMuMo { get; set; } = "";

        [Required(ErrorMessage = "Bạn phải nhập Kết cấu tường!")]
        public string ThongTinChungHoGa_KetCauTuong { get; set; } = "";
        [Required(ErrorMessage = "Bạn phải nhập Hình thức móng hố ga !")]
        public string ThongTinChungHoGa_HinhThucMongHoGa { get; set; } = "";
        [Required(ErrorMessage = "Bạn phải nhập  Kết cấu móng !")]
        public string ThongTinChungHoGa_KetCauMong { get; set; } = "";
        [Required(ErrorMessage = "Bạn phải nhập Chát mặt trong !")]
        public string ThongTinChungHoGa_ChatMatTrong { get; set; } = "";
        [Required(ErrorMessage = "Bạn phải nhập Chát mặt ngoài  !")]
        public string ThongTinChungHoGa_ChatMatNgoai { get; set; } = "";
        //Thông tin kích thước hình học hố ga
        //1.Thông tin phủ bì hố ga (m) 1.PhuBiHoGa
        [Required(ErrorMessage = "Bạn phải nhập chiều dài!")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? PhuBiHoGa_CDai { get; set; } = 0;

        [Required(ErrorMessage = "Bạn phải nhập chiều rộng !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? PhuBiHoGa_CRong { get; set; } = 0;

        [Required(ErrorMessage = "Bạn phải nhập chiều dài  !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? BeTongLotMong_D { get; set; } = 0;

        public Double? BeTongLotMong_R { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập chiều cao !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? BeTongLotMong_C { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập chiều dài  !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? BeTongMongHoGa_D { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập chiều cao !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? BeTongMongHoGa_R { get; set; } = 0;
        public Double? BeTongMongHoGa_C { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập chiều dài  !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? DeHoGa_D { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập chiều rộng !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? DeHoGa_R { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập chiều cao !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? DeHoGa_C { get; set; } = 0;

        //5.Kích thước hình học tường hố ga (m)	TuongHoGa		
        [Required(ErrorMessage = "Bạn phải nhập chiều dài !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? TuongHoGa_D { get; set; } = 0;

        [Required(ErrorMessage = "Bạn phải nhập chiều rộng !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? TuongHoGa_R { get; set; } = 0;
        public Double? TuongHoGa_C { get; set; } = 0;

        [Required(ErrorMessage = "Bạn phải nhập chiều dài tường !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? TuongHoGa_CdTuong { get; set; } = 0;
        //6.KTHH dầm giữa hố ga	 DamGiuaHoGa
        [Required(ErrorMessage = "Bạn phải nhập chiều dài  !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? DamGiuaHoGa_D { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập chiều rộng !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? DamGiuaHoGa_R { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập chiều cao !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? DamGiuaHoGa_C { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải dài dầm!")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? DamGiuaHoGa_CdDam { get; set; } = 0;

        [Required(ErrorMessage = "Bạn phải nhập chiều dài dầm so với đáy hố ga ")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? DamGiuaHoGa_CCaoDamGiuaTuongSoVoiDayHoGa { get; set; } = 0;

        //7.Chát hố ga mặt trong 
        [Required(ErrorMessage = "Bạn phải nhập chiều dài !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? ChatMatTrong_D { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập chiều rộng !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? ChatMatTrong_R { get; set; } = 0;
        public Double? ChatMatTrong_C { get; set; } = 0;

        //8.Chát hố ga mặt ngoài, cạnh 01 +02 (m) ChatMatNgoaiCanh
        [Required(ErrorMessage = "Bạn phải nhập chiều dài  !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? ChatMatNgoaiCanh_D { get; set; } = 0;

        [Required(ErrorMessage = "Bạn phải nhập chiều rộng !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? ChatMatNgoaiCanh_R { get; set; } = 0;
        public Double? ChatMatNgoaiCanh_C { get; set; } = 0;
        //9.Kích thước hình học tường mũ mố thớt dưới (m) MuMoThotDuoi
        [Required(ErrorMessage = "Bạn phải nhập chiều dài  !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? MuMoThotDuoi_D { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập chiều rộng !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? MuMoThotDuoi_R { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập chiều cao !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? MuMoThotDuoi_C { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập chiều dài tường !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? MuMoThotDuoi_CdTuong { get; set; } = 0;

        //10.Kích thước hình học tường mũ mố thớt trên (m)	 MuMoThotTren	
        [Required(ErrorMessage = "Bạn phải nhập chiều dài  !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? MuMoThotTren_D { get; set; } = 0;

        [Required(ErrorMessage = "Bạn phải nhập chiều rộng !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? MuMoThotTren_R { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập chiều cao !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? MuMoThotTren_C { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập chiều dài tường !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? MuMoThotTren_CdTuong { get; set; } = 0;

        //Hạng mục chiếm chỗ hố ga
        //1.Hình thức đấu nối
        [Required(ErrorMessage = "Bạn phải nhập loại !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? HinhThucDauNoi1_Loai { get; set; } = 0;

        [Required(ErrorMessage = "Bạn phải chọn KL bổ sung !")]
        public string ? HinhThucDauNoi1_KLBoSung { get; set; } = "";

        [Required(ErrorMessage = "Bạn phải nhập cạnh dài !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? HinhThucDauNoi1_CanhDai { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập loại !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? HinhThucDauNoi1_CDD { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập C !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? HinhThucDauNoi1_CDR { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập R !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? HinhThucDauNoi1_CDC { get; set; } = 0;

        [Required(ErrorMessage = "Bạn phải nhập cạnh rộng !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? HinhThucDauNoi1_CanhRong { get; set; } = 0;

        [Required(ErrorMessage = "Bạn phải  D!")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? HinhThucDauNoi1_CRD { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải R !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? HinhThucDauNoi1_CRR { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải C !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? HinhThucDauNoi1_CRC { get; set; } = 0;

        [Required(ErrorMessage = "Bạn phải nhập cạnh cheo !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? HinhThucDauNoi1_CanhCheo { get; set; } = 0;

        [Required(ErrorMessage = "Bạn phải nhập D !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? HinhThucDauNoi1_CCD { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải R !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? HinhThucDauNoi1_CCR { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải  C !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? HinhThucDauNoi1_CCC { get; set; } = 0;

        //2.Hình thức đấu nối    HinhThucDauNoi2
        [Required(ErrorMessage = "Bạn phải nhập loại !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? HinhThucDauNoi2_Loai { get; set; } = 0;

        [Required(ErrorMessage = "Bạn phải nhập KL bổ sung !")]
        public string? HinhThucDauNoi2_KLBoSung { get; set; } = "";

        [Required(ErrorMessage = "Bạn phải nhập cạnh dài !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? HinhThucDauNoi2_CanhDai { get; set; } = 0;

        [Required(ErrorMessage = "Bạn phải nhập D !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? HinhThucDauNoi2_CDD { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập R !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? HinhThucDauNoi2_CDR { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập C !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? HinhThucDauNoi2_CDC { get; set; } = 0;

        [Required(ErrorMessage = "Bạn phải nhập cạnh rộng !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? HinhThucDauNoi2_CanhRong { get; set; } = 0;

        [Required(ErrorMessage = "Bạn phải nhập D !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? HinhThucDauNoi2_CRD { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập R !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? HinhThucDauNoi2_CRR { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập C !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? HinhThucDauNoi2_CRC { get; set; } = 0;

        [Required(ErrorMessage = "Bạn phải nhập cạnh cheo !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? HinhThucDauNoi2_CanhCheo { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập D !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? HinhThucDauNoi2_CCD { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập R !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? HinhThucDauNoi2_CCR { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập C !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? HinhThucDauNoi2_CCC { get; set; } = 0;

        //3.Hình thức đấu nối    HinhThucDauNoi3
        [Required(ErrorMessage = "Bạn phải nhập loại !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? HinhThucDauNoi3_Loai { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải KL Bổ sung !")]
        public string? HinhThucDauNoi3_KLBoSung { get; set; } = "";

        [Required(ErrorMessage = "Bạn phải nhập cạnh dài !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? HinhThucDauNoi3_CanhDai { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập D !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? HinhThucDauNoi3_CDD { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập R !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? HinhThucDauNoi3_CDR { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập C !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? HinhThucDauNoi3_CDC { get; set; } = 0;


        [Required(ErrorMessage = "Bạn phải nhập cạnh rộng !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? HinhThucDauNoi3_CanhRong { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập D !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? HinhThucDauNoi3_CRD { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập R !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? HinhThucDauNoi3_CRR { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập C !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? HinhThucDauNoi3_CRC { get; set; } = 0;

        [Required(ErrorMessage = "Bạn phải nhập cạnh chéo !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? HinhThucDauNoi3_CanhCheo { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập D !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? HinhThucDauNoi3_CCD { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập R !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? HinhThucDauNoi3_CCR { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập C !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? HinhThucDauNoi3_CCC { get; set; } = 0;

        //4.Hình thức đấu nối    HinhThucDauNoi4
        [Required(ErrorMessage = "Bạn phải nhập loại !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? HinhThucDauNoi4_Loai { get; set; } = 0;

        [Required(ErrorMessage = "Bạn phải nhập KL bổ sung !")]
        public string? HinhThucDauNoi4_KLBoSung { get; set; } = "";

        [Required(ErrorMessage = "Bạn phải nhập cạnh dài !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? HinhThucDauNoi4_CanhDai { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập loại !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? HinhThucDauNoi4_CDD { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập loại !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? HinhThucDauNoi4_CDR { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập loại !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? HinhThucDauNoi4_CDC { get; set; } = 0;


        [Required(ErrorMessage = "Bạn phải nhập cạnh rộng !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? HinhThucDauNoi4_CanhRong { get; set; } = 0;

        [Required(ErrorMessage = "Bạn phải nhập loại !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? HinhThucDauNoi4_CRD { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập loại !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? HinhThucDauNoi4_CRR { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập loại !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? HinhThucDauNoi4_CRC { get; set; } = 0;

        [Required(ErrorMessage = "Bạn phải nhập cạnh chéo !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? HinhThucDauNoi4_CanhCheo { get; set; } = 0;

        [Required(ErrorMessage = "Bạn phải nhập loại !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? HinhThucDauNoi4_CCD { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập loại !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? HinhThucDauNoi4_CCR { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập loại !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? HinhThucDauNoi4_CCC { get; set; } = 0;

        //5.Hình thức đấu nối    HinhThucDauNoi5
        [Required(ErrorMessage = "Bạn phải nhập loại !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? HinhThucDauNoi5_Loai { get; set; } = 0;

        [Required(ErrorMessage = "Bạn phải nhập KL bổ sung !")]
        public string? HinhThucDauNoi5_KLBoSung { get; set; } = "";

        [Required(ErrorMessage = "Bạn phải nhập cạnh dài !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? HinhThucDauNoi5_CanhDai { get; set; } = 0;

        [Required(ErrorMessage = "Bạn phải nhập D !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? HinhThucDauNoi5_CDD { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập R !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? HinhThucDauNoi5_CDR { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập C !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? HinhThucDauNoi5_CDC { get; set; } = 0;

        [Required(ErrorMessage = "Bạn phải nhập cạnh rộng !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? HinhThucDauNoi5_CanhRong { get; set; } = 0;

        [Required(ErrorMessage = "Bạn phải nhập loại !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? HinhThucDauNoi5_CRD { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập loại !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? HinhThucDauNoi5_CRR { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập loại !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? HinhThucDauNoi5_CRC { get; set; } = 0;


        [Required(ErrorMessage = "Bạn phải nhập cạnh cheo !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? HinhThucDauNoi5_CanhCheo { get; set; } = 0;

        [Required(ErrorMessage = "Bạn phải nhập D !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? HinhThucDauNoi5_CCD { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập R !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? HinhThucDauNoi5_CCR { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập C !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? HinhThucDauNoi5_CCC { get; set; } = 0;

        //6.Hình thức đấu nối    HinhThucDauNoi6
        [Required(ErrorMessage = "Bạn phải nhập loại !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? HinhThucDauNoi6_Loai { get; set; } = 0;


        [Required(ErrorMessage = "Bạn phải nhập KL bổ sung !")]
        public string? HinhThucDauNoi6_KLBoSung { get; set; } = "";

        [Required(ErrorMessage = "Bạn phải nhập cạnh dài !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? HinhThucDauNoi6_CanhDai { get; set; } = 0;

        [Required(ErrorMessage = "Bạn phải nhập D !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? HinhThucDauNoi6_CDD { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập R !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? HinhThucDauNoi6_CDR { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập C !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? HinhThucDauNoi6_CDC { get; set; } = 0;

        [Required(ErrorMessage = "Bạn phải nhập cạnh rộng !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? HinhThucDauNoi6_CanhRong { get; set; } = 0;

        [Required(ErrorMessage = "Bạn phải nhập D !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? HinhThucDauNoi6_CRD { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập R !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? HinhThucDauNoi6_CRR { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập C !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? HinhThucDauNoi6_CRC { get; set; } = 0;


        [Required(ErrorMessage = "Bạn phải nhập cạnh cheo !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? HinhThucDauNoi6_CanhCheo { get; set; } = 0;

        [Required(ErrorMessage = "Bạn phải nhập D !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? HinhThucDauNoi6_CCD { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập R !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? HinhThucDauNoi6_CCR { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập C !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? HinhThucDauNoi6_CCC { get; set; } = 0;

        //7.Hình thức đấu nối    HinhThucDauNoi7
        [Required(ErrorMessage = "Bạn phải nhập loại !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? HinhThucDauNoi7_Loai { get; set; } = 0;

        [Required(ErrorMessage = "Bạn phải nhập KL bổ sung !")]
        public string? HinhThucDauNoi7_KLBoSung { get; set; } = "";

        [Required(ErrorMessage = "Bạn phải nhập cạnh dài !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? HinhThucDauNoi7_CanhDai { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập D !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? HinhThucDauNoi7_CDD { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập R !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? HinhThucDauNoi7_CDR { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập C !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? HinhThucDauNoi7_CDC { get; set; } = 0;

        [Required(ErrorMessage = "Bạn phải nhập cạnh rộng !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? HinhThucDauNoi7_CanhRong { get; set; } = 0;

        [Required(ErrorMessage = "Bạn phải nhập D !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? HinhThucDauNoi7_CRD { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập R !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? HinhThucDauNoi7_CRR { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập C !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? HinhThucDauNoi7_CRC { get; set; } = 0;

        [Required(ErrorMessage = "Bạn phải nhập cạnh cheo !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? HinhThucDauNoi7_CanhCheo { get; set; } = 0;

        [Required(ErrorMessage = "Bạn phải nhập D !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? HinhThucDauNoi7_CCD { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập R !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? HinhThucDauNoi7_CCR { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập C !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? HinhThucDauNoi7_CCC { get; set; } = 0;


        //8.Hình thức đấu nối    HinhThucDauNoi8
        [Required(ErrorMessage = "Bạn phải nhập loại !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? HinhThucDauNoi8_Loai { get; set; } = 0;

        [Required(ErrorMessage = "Bạn phải nhập KL bổ sung !")]
        public string? HinhThucDauNoi8_KLBoSung { get; set; } = "";

        [Required(ErrorMessage = "Bạn phải nhập cạnh dài !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? HinhThucDauNoi8_CanhDai { get; set; } = 0;

        [Required(ErrorMessage = "Bạn phải nhập D !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? HinhThucDauNoi8_CDD { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập R !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? HinhThucDauNoi8_CDR { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập C !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? HinhThucDauNoi8_CDC { get; set; } = 0;


        [Required(ErrorMessage = "Bạn phải nhập cạnh rộng !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? HinhThucDauNoi8_CanhRong { get; set; } = 0;

        [Required(ErrorMessage = "Bạn phải nhập D !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? HinhThucDauNoi8_CRD { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập R !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? HinhThucDauNoi8_CRR { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập C !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? HinhThucDauNoi8_CRC { get; set; } = 0;

        [Required(ErrorMessage = "Bạn phải nhập cạnh cheo !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? HinhThucDauNoi8_CanhCheo { get; set; } = 0;

        [Required(ErrorMessage = "Bạn phải nhập D !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? HinhThucDauNoi8_CCD { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập R !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? HinhThucDauNoi8_CCR { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập C !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? HinhThucDauNoi8_CCC { get; set; } = 0;


        //1.Hình thức đấu nối  
        //[Required(ErrorMessage = "Bạn phải nhập loại !")]
        //[Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        //[RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        //public Double? HinhThucDauNoi1_Loai { get; set; } = 0;

        //[Required(ErrorMessage = "Bạn phải nhập cạnh dài !")]
        //[Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        //[RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        //public Double? HinhThucDauNoi1_CanhDai { get; set; } = 0;

        //[Required(ErrorMessage = "Bạn phải nhập cạnh rộng !")]
        //[Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        //[RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        //public Double? HinhThucDauNoi1_CanhRong { get; set; } = 0;

        //[Required(ErrorMessage = "Bạn phải nhập cạnh cheo !")]
        //[Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        //[RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        //public Double? HinhThucDauNoi1_CanhCheo { get; set; } = 0;

        ////2.Hình thức đấu nối    HinhThucDauNoi2
        //[Required(ErrorMessage = "Bạn phải nhập loại !")]
        //[Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        //[RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        //public Double? HinhThucDauNoi2_Loai { get; set; } = 0;

        //[Required(ErrorMessage = "Bạn phải nhập cạnh dài !")]
        //[Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        //[RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        //public Double? HinhThucDauNoi2_CanhDai { get; set; } = 0;

        //[Required(ErrorMessage = "Bạn phải nhập cạnh rộng !")]
        //[Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        //[RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        //public Double? HinhThucDauNoi2_CanhRong { get; set; } = 0;
        //[Required(ErrorMessage = "Bạn phải nhập cạnh cheo !")]
        //[Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        //[RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        //public Double? HinhThucDauNoi2_CanhCheo { get; set; } = 0;


        ////3.Hình thức đấu nối    HinhThucDauNoi3
        //[Required(ErrorMessage = "Bạn phải nhập loại !")]
        //[Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        //[RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        //public Double? HinhThucDauNoi3_Loai { get; set; } = 0;

        //[Required(ErrorMessage = "Bạn phải nhập cạnh dài !")]
        //[Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        //[RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        //public Double? HinhThucDauNoi3_CanhDai { get; set; } = 0;

        //[Required(ErrorMessage = "Bạn phải nhập cạnh rộng !")]
        //[Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        //[RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        //public Double? HinhThucDauNoi3_CanhRong { get; set; } = 0;
        //[Required(ErrorMessage = "Bạn phải nhập cạnh chéo !")]
        //[Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        //[RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        //public Double? HinhThucDauNoi3_CanhCheo { get; set; } = 0;

        ////4.Hình thức đấu nối    HinhThucDauNoi4
        //[Required(ErrorMessage = "Bạn phải nhập loại !")]
        //[Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        //[RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        //public Double? HinhThucDauNoi4_Loai { get; set; } = 0;

        //[Required(ErrorMessage = "Bạn phải nhập cạnh dài !")]
        //[Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        //[RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        //public Double? HinhThucDauNoi4_CanhDai { get; set; } = 0;

        //[Required(ErrorMessage = "Bạn phải nhập cạnh rộng !")]
        //[Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        //[RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        //public Double? HinhThucDauNoi4_CanhRong { get; set; } = 0;
        //[Required(ErrorMessage = "Bạn phải nhập cạnh chéo !")]
        //[Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        //[RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        //public Double? HinhThucDauNoi4_CanhCheo { get; set; } = 0;

        ////5.Hình thức đấu nối    HinhThucDauNoi5
        //[Required(ErrorMessage = "Bạn phải nhập loại !")]
        //[Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        //[RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        //public Double? HinhThucDauNoi5_Loai { get; set; } = 0;

        //[Required(ErrorMessage = "Bạn phải nhập cạnh dài !")]
        //[Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        //[RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        //public Double? HinhThucDauNoi5_CanhDai { get; set; } = 0;

        //[Required(ErrorMessage = "Bạn phải nhập cạnh rộng !")]
        //[Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        //[RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        //public Double? HinhThucDauNoi5_CanhRong { get; set; } = 0;
        //[Required(ErrorMessage = "Bạn phải nhập cạnh cheo !")]
        //[Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        //[RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        //public Double? HinhThucDauNoi5_CanhCheo { get; set; } = 0;

        ////6.Hình thức đấu nối    HinhThucDauNoi6
        //[Required(ErrorMessage = "Bạn phải nhập loại !")]
        //[Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        //[RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        //public Double? HinhThucDauNoi6_Loai { get; set; } = 0;

        //[Required(ErrorMessage = "Bạn phải nhập cạnh dài !")]
        //[Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        //[RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        //public Double? HinhThucDauNoi6_CanhDai { get; set; } = 0;

        //[Required(ErrorMessage = "Bạn phải nhập cạnh rộng !")]
        //[Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        //[RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        //public Double? HinhThucDauNoi6_CanhRong { get; set; } = 0;
        //[Required(ErrorMessage = "Bạn phải nhập cạnh cheo !")]
        //[Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        //[RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        //public Double? HinhThucDauNoi6_CanhCheo { get; set; } = 0;

        ////7.Hình thức đấu nối    HinhThucDauNoi7
        //[Required(ErrorMessage = "Bạn phải nhập loại !")]
        //[Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        //[RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        //public Double? HinhThucDauNoi7_Loai { get; set; } = 0;

        //[Required(ErrorMessage = "Bạn phải nhập cạnh dài !")]
        //[Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        //[RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        //public Double? HinhThucDauNoi7_CanhDai { get; set; } = 0;

        //[Required(ErrorMessage = "Bạn phải nhập cạnh rộng !")]
        //[Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        //[RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        //public Double? HinhThucDauNoi7_CanhRong { get; set; } = 0;
        //[Required(ErrorMessage = "Bạn phải nhập cạnh cheo !")]
        //[Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        //[RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        //public Double? HinhThucDauNoi7_CanhCheo { get; set; } = 0;

        ////8.Hình thức đấu nối    HinhThucDauNoi8
        //[Required(ErrorMessage = "Bạn phải nhập loại !")]
        //[Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        //[RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        //public Double? HinhThucDauNoi8_Loai { get; set; } = 0;

        //[Required(ErrorMessage = "Bạn phải nhập cạnh dài !")]
        //[Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        //[RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        //public Double? HinhThucDauNoi8_CanhDai { get; set; } = 0;

        //[Required(ErrorMessage = "Bạn phải nhập cạnh rộng !")]
        //[Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        //[RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        //public Double? HinhThucDauNoi8_CanhRong { get; set; } = 0;
        //[Required(ErrorMessage = "Bạn phải nhập cạnh cheo !")]
        //[Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        //[RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        //public Double? HinhThucDauNoi8_CanhCheo { get; set; } = 0;

        //Thông tin tấm đan hố ga ThongTinTamDanHoGa2

        //[Required(ErrorMessage = "Bạn phải nhập Phân loại đậy hố ga !")]
        public string? ThongTinTamDanHoGa2_PhanLoaiDayHoGa { get; set; } = "";
        //[Required(ErrorMessage = "Bạn phải nhập Hình thức đậy hố ga !")]
        public string? ThongTinTamDanHoGa2_HinhThucDayHoGa { get; set; } = "";

        [Required(ErrorMessage = "Bạn phải nhập Đường kính (m) !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? ThongTinTamDanHoGa2_DuongKinh { get; set; } = 0;

        [Required(ErrorMessage = "Bạn phải nhập Chiều dầy (m) !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? ThongTinTamDanHoGa2_ChieuDay { get; set; } = 0;

        [Required(ErrorMessage = "Bạn phải nhập chiều dài !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? ThongTinTamDanHoGa2_D { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập chiều rộng  !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? ThongTinTamDanHoGa2_R { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập chiều cao !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? ThongTinTamDanHoGa2_C { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập số lượng nắp đậy !")]
        [Range(0, int.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        public Double? ThongTinTamDanHoGa2_SoLuongNapDay { get; set; } = 0;

        //Thông tin vật liệu đào hố ga
        [Required(ErrorMessage = "Bạn phải nhập loại vật liệu đào hố ga!")]
        public string? ThongTinVatLieuDaoHoGa_LoaiVatLieuDao { get; set; } = "";

        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        [Required(ErrorMessage = "Bạn phải nhập chiều cao đào đá!")]
        public Double? ThongTinVatLieuDaoHoGa_ChieuCaoDaoDa { get; set; } = 0;
        public Double? ThongTinVatLieuDaoHoGa_ChieuCaoDaoDat { get; set; } = 0;
        public Double? ThongTinVatLieuDaoHoGa_TongChieuCaoDao { get; set; } = 0;

        //Thông tin cao độ hố ga
        [Required(ErrorMessage = "Bạn phải nhập cao độ tự nhiên!")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? ThongTinCaoDoHoGa_CaoDoTuNhien { get; set; } = 0;

        [Required(ErrorMessage = "Bạn phải nhập CĐ đỉnh vỉa hè hoàn thiện !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? ThongTinCaoDoHoGa_CdDinhViaHeHoanThien { get; set; } = 0;

        [Required(ErrorMessage = "Bạn phải nhập Cao độ đỉnh K98)!")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? ThongTinCaoDoHoGa_CaoDoDinhK98 { get; set; } = 0;
        public Double? ThongTinCaoDoHoGa_CaoDoHienTrangTruocKhiDao { get; set; } = 0;
        public Double? ThongTinCaoDoHoGa_DayDao { get; set; } = 0;
        public Double? ThongTinCaoDoHoGa_CSauDao { get; set; } = 0;
        public Double? ThongTinCaoDoHoGa_DinhLotMong { get; set; } = 0;
        public Double? ThongTinCaoDoHoGa_CdDinhMong { get; set; } = 0;

        [Required(ErrorMessage = "Bạn phải nhập CĐ đáy hố ga !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? ThongTinCaoDoHoGa_CdDayHoGa { get; set; } = 0;
        public Double? ThongTinCaoDoHoGa_CCaoTuong { get; set; } = 0;
        public Double? ThongTinCaoDoHoGa_DinhTuongDuoiDamGiuaTuong { get; set; } = 0;
        public Double? ThongTinCaoDoHoGa_DinhDamGiuaTuong { get; set; } = 0;
        public Double? ThongTinCaoDoHoGa_DinhTuong { get; set; } = 0;
        public Double? ThongTinCaoDoHoGa_DinhMuMoThotDuoi { get; set; } = 0;

        [Required(ErrorMessage = "Bạn phải nhập CĐ đỉnh hố ga!")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? ThongTinCaoDoHoGa_CdDinhHoGa { get; set; } = 0;
        public Double? ThongTinCaoDoHoGa_TongChieuCaoHoGa { get; set; } = 0;
        public Double? ThongTinCaoDoHoGa_ChenhCaoDinhHoGaVaHienTrangDao { get; set; } = 0;
        public Double? ThongTinCaoDoHoGa_TongChieuCaoChiemChoDapTra { get; set; } = 0;
        public Double? TTCCCCDTHT_ChieuCaoLotDat { get; set; } = 0;
        public Double? TTCCCCDTHT_ChieuCaoMongDat { get; set; } = 0;
        public Double? TTCCCCDTHT_ChieuCaoTuongDat { get; set; } = 0;
        public Double? TTCCCCDTHT_ChieuCaoLotDa { get; set; } = 0;
        public Double? TTCCCCDTHT_ChieuCaoMongDa { get; set; } = 0;
        public Double? TTCCCCDTHT_ChieuCaoTuongDa { get; set; } = 0;
        public Double? TTCCCCDTHT_TongCieuCaoDat { get; set; } = 0;
        public Double? TTCCCCDTHT_TongChieuCaoDa { get; set; } = 0;
        public Double? TTCCCCDTHT_ChenhDatSoVoiTK { get; set; } = 0;
        public Double? TTCCCCDTHT_ChenhDaSoVoiTK { get; set; } = 0;

        //Thông tin mái đào
        [Required(ErrorMessage = "Bạn phải nhập Chiều rộng đáy đào nhỏ!")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? ThongTinMaiDao_ChieuRongDayDaoNho { get; set; } = 0;

        [Required(ErrorMessage = "Bạn phải nhập Tỷ lệ mở mái!")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? ThongTinMaiDao_TyLeMoMai { get; set; } = 0;

        [Required(ErrorMessage = "Bạn phải nhập Số cạnh mái trái !")]
        [Range(0, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        public Double? ThongTinMaiDao_SoCanhMaiTrai { get; set; } = 0;

        [Required(ErrorMessage = "Bạn phải nhập số cạnh mái phải !")]
        [Range(0, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        public Double? ThongTinMaiDao_SoCanhMaiPhai { get; set; } = 0;

        //Thông tin khối lượng đào
        public Double? TTKLD_CRongDaoDayLonDat { get; set; } = 0;
        public Double? TTKLD_CRongDaoDayLonDa { get; set; } = 0;
        public Double? TTKLD_DienTichDaoDat { get; set; } = 0;
        public Double? TTKLD_DienTichDaoDa { get; set; } = 0;
        public Double? TTKLD_TongDtDao { get; set; } = 0;
        public Double? TTKLD_KlDaoDat { get; set; } = 0;
        public Double? TTKLD_KlDaoDa { get; set; } = 0;
        public Double? TTKLD_TongKlDao { get; set; } = 0;
        public Double? TTKLD_KlChiemChoDat { get; set; } = 0;
        public Double? TTKLD_KlChiemChoDa { get; set; } = 0;
        public Double? TTKLD_TongChiemCho { get; set; } = 0;
        public Double? TTKLD_KlDapTraDat { get; set; } = 0;
        public Double? TTKLD_KlDapTraDa { get; set; } = 0;
        public Double? TTKLD_TongDapTra { get; set; } = 0;
        public Double? TTKLD_KlThuaDat { get; set; } = 0;
        public Double? TTKLD_KlThuaDa { get; set; } = 0;
        public Double? TTKLD_TongThua { get; set; } = 0;

        //Thông tin lý trình truyền dẫn
        [Required(ErrorMessage = "Bạn phải nhập Từ lý trình!")]
        [Range(0.000, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,5})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 5 chữ số thập phân.")]
        public Double? ThongTinLyTrinhTruyenDan_TuLyTrinh { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập Đến lý trình!")]
        [Range(0.000, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,5})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 5 chữ số thập phân.")]
        public Double? ThongTinLyTrinhTruyenDan_DenLyTrinh { get; set; } = 0;
        //[Required(ErrorMessage = "Bạn phải nhập Từ hố ga !")]
        public string? ThongTinLyTrinhTruyenDan_TuHoGa { get; set; } = "";
        //[Required(ErrorMessage = "Bạn phải nhập Đến hố ga !")]
        public string? ThongTinLyTrinhTruyenDan_DenHoGa { get; set; } = "";

        //Thông tin đường truyền dẫn
        //[Required(ErrorMessage = "Bạn phải nhập Hình thức truyền dẫn!")]
        public string? ThongTinDuongTruyenDan_HinhThucTruyenDan { get; set; } = "";
        //[Required(ErrorMessage = "Bạn phải nhập Loại truyền dẫn !")]
        public string? ThongTinDuongTruyenDan_LoaiTruyenDan { get; set; } = "";
        //[Required(ErrorMessage = "Bạn phải nhập Tên loại truyền dẫn sau phân loại!")]
        public string? ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai { get; set; } = "";

        //Thông tin chiều dài và số lượng cấu kiện đường truyền dẫn
 
        [Required(ErrorMessage = "Bạn phải nhập tổng chiều dài!")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        public Double? TTCDSLCauKienDuongTruyenDan_TongChieuDai { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập Chiều dài 01 cấu kiện (m) !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? TTCDSLCauKienDuongTruyenDan_ChieuDai01CauKien { get; set; } = 0;
        public Double? TTCDSLCauKienDuongTruyenDan_SlCauKienTinhKl { get; set; } = 0;

        //Thông tin móng đường truyền dẫn
        //[Required(ErrorMessage = "Bạn phải nhập Phân loại móng cống tròn, cống hộp!")]
        public string? ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop { get; set; } = "";
        //[Required(ErrorMessage = "Bạn phải nhập loại móng!")]
        public string? ThongTinMongDuongTruyenDan_LoaiMong { get; set; } = "";
        //[Required(ErrorMessage = "Bạn phải nhập hình thức móng!")]
        public string? ThongTinMongDuongTruyenDan_HinhThucMong { get; set; } = "";

        public string? ThongTinDeCong_TenLoaiDeCong { get; set; } = "";
        public string? ThongTinDeCong_CauTaoDeCong { get; set; } = "";
        [Required(ErrorMessage = "Bạn phải nhập chiều dài!")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? ThongTinDeCong_D { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập chiều rộng!")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? ThongTinDeCong_R { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập chiều cao!")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? ThongTinDeCong_C { get; set; } = 0;

        [Required(ErrorMessage = "Bạn phải nhập SL đế cống/01 cấu kiện truyền dẫn (C.Kiện) !")]
        [Range(0, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        public Double? ThongTinDeCong_SlDeCong01CauKienTruyenDan { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập  KL 01 đế cống!")]
        [Range(0, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        public Double? ThongTinDeCong_Kl01DeCong { get; set; } = 0;
        public Double? ThongTinDeCong_TongSoLuongDC { get; set; } = 0;
        public Double? ThongTinDeCong_TongKLDeCong { get; set; } = 0;

        //Thông tin cấu tạo cống tròn
        [Required(ErrorMessage = "Bạn phải nhập Dầy phủ bì !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? ThongTinCauTaoCongTron_CDayPhuBi { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập Số cạnh!")]
        [Range(0, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        public Double? ThongTinCauTaoCongTron_SoCanh { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập Lòng sử dụng!")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? ThongTinCauTaoCongTron_LongSuDung { get; set; } = 0;
        public Double? ThongTinCauTaoCongTron_CCaoCauKien { get; set; } = 0;

        [Required(ErrorMessage = "Bạn phải nhập C.Cao lót móng (m)!")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? ThongTinCauTaoCongTron_CCaoLotMong { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập C.Rộng lót móng!")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? ThongTinCauTaoCongTron_CRongLotMong { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập C.Cao móng!")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? ThongTinCauTaoCongTron_CCaoMong { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập C.Rộng móng !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? ThongTinCauTaoCongTron_CRongMong { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập C.Cao đế (tại vị trí đặt C.Kiện) (m)!")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? ThongTinCauTaoCongTron_CCaoDe { get; set; } = 0;
        public Double? ThongTinCauTaoCongTron_TongCCaoCong { get; set; } = 0;
        
        //Thêm
        //Thông tính tính KL cấu kiện cống tròn, cống hộp (các loại phải lắp đặt)
        [Required(ErrorMessage = "Bạn phải nhập Chiều dài mối nối C.Kiện (m)!")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? TTTKLCKCTCH_CDMoiNoiCKien { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập  Số lượng C.Kiện dùng để tính chiều dài bổ sung (C.Kiện) !")]
        [Range(0, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        public Double? TTTKLCKCTCH_SLCKDungDeTinhCD { get; set; } = 0;
        public Double? TTTKLCKCTCH_SLCKNguyen { get; set; } = 0;
        public Double? TTTKLCKCTCH_CDCanLapDat { get; set; } = 0;
        public Double? TTTKLCKCTCH_TongCD { get; set; } = 0;
        public Double? TTTKLCKCTCH_CDThucTeThuaThieu { get; set; } = 0;
        public string? TTTKLCKCTCH_XDOngCongCanThem { get; set; } = "";
        public Double? TTTKLCKCTCH_CDThuaThieuSauTinhKL { get; set; } = 0;

        //Thông tin kích thước hình học cống hộp, rãnh
        //[Required(ErrorMessage = "Bạn phải nhập cấu tạo tường!")]
        public string? TTKTHHCongHopRanh_CauTaoTuong { get; set; } = "";
        //[Required(ErrorMessage = "Bạn phải nhập cấu tạo mũ mố!")]
        public string? TTKTHHCongHopRanh_CauTaoMuMo { get; set; } = "";
        //[Required(ErrorMessage = "Bạn phải nhập Chát mặt trong !")]
        public string? TTKTHHCongHopRanh_ChatMatTrong { get; set; } = "";
        //[Required(ErrorMessage = "Bạn phải nhập Chát mặt ngoài!")]
        public string? TTKTHHCongHopRanh_ChatMatNgoai { get; set; } = "";

        [Required(ErrorMessage = "Bạn phải nhập C.Cao lót móng !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? TTKTHHCongHopRanh_CCaoLotMong { get; set; } = 0;

        [Required(ErrorMessage = "Bạn phải nhập C.Rộng lót móng!")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? TTKTHHCongHopRanh_CRongLotMong { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập C.Cao móng !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? TTKTHHCongHopRanh_CCaoMong { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập  C.Rộng móng!")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? TTKTHHCongHopRanh_CRongMong { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập C.Cao đế !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? TTKTHHCongHopRanh_CCaoDe { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhậpC.Rộng đế !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? TTKTHHCongHopRanh_CRongDe { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập C.Dầy tường 01 bên!")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? TTKTHHCongHopRanh_CDayTuong01Ben { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập Số lượng tường !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? TTKTHHCongHopRanh_SoLuongTuong { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập C.Rộng lòng sử dụng !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? TTKTHHCongHopRanh_CRongLongSuDung { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập C.Cao tường cống hộp!")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? TTKTHHCongHopRanh_CCaoTuongCongHop { get; set; } = 0;
        public Double? TTKTHHCongHopRanh_CCaoTuongRanh { get; set; } = 0;
        public Double? TTKTHHCongHopRanh_CCaoTuongGop { get; set; } = 0;

        [Required(ErrorMessage = "Bạn phải nhập C.Cao mũ mố thớt dưới!")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? TTKTHHCongHopRanh_CCaoMuMoThotDuoi { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập C.Rộng mũ mố dưới!")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? TTKTHHCongHopRanh_CRongMuMoDuoi { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập C.Cao mũ mố thớt trên !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? TTKTHHCongHopRanh_CCaoMuMoThotTren { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập C.Rộng mũ mố trên !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? TTKTHHCongHopRanh_CRongMuMoTren { get; set; } = 0;
        //[Required(ErrorMessage = "Bạn phải nhập Loại thanh chống !")]
        public string TTKTHHCongHopRanh_LoaiThanhChong { get; set; } = "";
        //[Required(ErrorMessage = "Bạn phải nhập Cấu tạo thanh chống!")]
        public string TTKTHHCongHopRanh_CauTaoThanhChong { get; set; } = "";

        [Required(ErrorMessage = "Bạn phải nhập C.Cao thanh chống!")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? TTKTHHCongHopRanh_CCaoThanhChong { get; set; } = 0;

        [Required(ErrorMessage = "Bạn phải nhập C.Rộng thanh chống!")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? TTKTHHCongHopRanh_CRongThanhChong { get; set; } = 0;

        [Required(ErrorMessage = "Bạn phải nhập C.Dài !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? TTKTHHCongHopRanh_CDai { get; set; } = 0;

        [Required(ErrorMessage = "Bạn phải nhập Số lượng thanh chống !")]
        [Range(0, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        public Double? TTKTHHCongHopRanh_SoLuongThanhChong { get; set; } = 0;
        public Double? TTKTHHCongHopRanh_CCaoChatMatTrong { get; set; } = 0;
        public Double? TTKTHHCongHopRanh_CCaoChatmatNgoai { get; set; } = 0;
        public Double? TTKTHHCongHopRanh_TongChieuCao { get; set; } = 0;

        //Thông tin tấm đan cống hộp, rãnh
        //[Required(ErrorMessage = "Bạn phải nhập Tên loại tấm đan tiêu chuẩn!")]
        public string TTTDCongHoRanh_TenLoaiTamDanTieuChuan { get; set; } = "";
        //[Required(ErrorMessage = "Bạn phải nhập Cấu tạo tấm đan truyền dẫn tấm đan tiêu chuẩn!")]
        public string TTTDCongHoRanh_CauTaoTamDanTruyenDanTamDanTieuChuan { get; set; } = "";
        public Double? TTTDCongHoRanh_SoLuong { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập C.Dài  !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? TTTDCongHoRanh_CDai { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập C.Rộng!")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? TTTDCongHoRanh_CRong { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập  C.Cao!")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? TTTDCongHoRanh_CCao { get; set; } = 0;

        //Thông tin tấm đan loại 02
        //[Required(ErrorMessage = "Bạn phải nhập Tên loại tấm đan loại 02!")]
        public string TTTDCongHoRanh_TenLoaiTamDanLoai02 { get; set; } = "";
        //[Required(ErrorMessage = "Bạn phải nhập Cấu tạo tấm đan truyền dẫn !")]
        public string TTTDCongHoRanh_CauTaoTamDanTruyenDan { get; set; } = "";
        public Double? TTTDCongHoRanh_SoLuong1 { get; set; } = 0;

        public Double? TTTDCongHoRanh_CDai1 { get; set; } = 0;

        [Required(ErrorMessage = "Bạn phải nhập chiều rông!")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? TTTDCongHoRanh_CRong1 { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập chiều cao!")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? TTTDCongHoRanh_CCao1 { get; set; } = 0;


        [Required(ErrorMessage = "Bạn phải nhập chiều dài mối nối!")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? TTTDCongHoRanh_ChieuDaiMoiNoi { get; set; } = 0;
        [Range(0, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [Required(ErrorMessage = "Bạn phải nhập Số lượng T.Đan dùng để tính chiều dài bổ sung (C.Kiện) !")]
        public Double? TTTDCongHoRanh_SoLuongTDanDungDeTinhChieuDaiBoSung { get; set; } = 0;
        public Double? TTTDCongHoRanh_SLCauKienNguyen { get; set; } = 0;
        public Double? TTTDCongHoRanh_ChieuDaiTheoSoCKNguyen { get; set; } = 0;
        public Double? TTTDCongHoRanh_TongChieuDaiTheoCKNguyen { get; set; } = 0;
        public Double? TTTDCongHoRanh_ChieuDaiThucTe { get; set; } = 0;
        public string ? TTTDCongHoRanh_XacDinhOngCongCanThem { get; set; } = "";

        //Thông tin kích thước hình học ống nhựa

        //Thông tin kích thước hình học ống nhựa
        [Required(ErrorMessage = "Bạn phải nhập C.Dầy phủ bì!")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? ThongTinKichThuocHinhHocOngNhua_CDayPhuBi { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập số cạnh!")]
        [Range(0, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        public Double? ThongTinKichThuocHinhHocOngNhua_SoCanh { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập Lòng sử dụng !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? ThongTinKichThuocHinhHocOngNhua_LongSuDung { get; set; } = 0;

        //[Required(ErrorMessage = "Bạn phải nhập Tổng C.Cao ống !")]
        //[Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        //[RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? ThongTinKichThuocHinhHocOngNhua_TongCCaoOng { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập  C.Cao đệm cát!")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? ThongTinKichThuocHinhHocOngNhua_CCaoDemCat { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập C.Cao đắp cát !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? ThongTinKichThuocHinhHocOngNhua_CCaoDapCat { get; set; } = 0;

        //Cao độ thượng lưu
     
        [Required(ErrorMessage = "Bạn phải nhập Hiện trạng trước khi đào thượng lưu !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? CDThuongLuu_HienTrangTruocKhiDaoThuongLuu { get; set; } = 0;
        public Double? CDThuongLuu_DayDaoGop { get; set; } = 0;
        public Double? CDThuongLuu_ChieuSauDao { get; set; } = 0;
        public Double? CDThuongLuu_DayDaoCongTron { get; set; } = 0;
        public Double? CDThuongLuu_DayDaoCongHop { get; set; } = 0;
        public Double? CDThuongLuu_DayDaoRanh { get; set; } = 0;
        public Double? CDThuongLuu_DayDaoOngNhua { get; set; } = 0;
        public Double? CDThuongLuu_DinhLotGop { get; set; } = 0;
        public Double? CDThuongLuu_DinhLotOngNhua { get; set; } = 0;
        public Double? CDThuongLuu_DinhLotCongTron { get; set; } = 0;
        public Double? CDThuongLuu_DinhLotCongHop { get; set; } = 0;
        public Double? CDThuongLuu_DinhLotRanh { get; set; } = 0;
        public Double? CDThuongLuu_DinhMongGop { get; set; } = 0;
        public Double? CDThuongLuu_DinhMongCongTron { get; set; } = 0;
        public Double? CDThuongLuu_DinhMongCongHop { get; set; } = 0;
        public Double? CDThuongLuu_DinhMongRanh { get; set; } = 0;
        public Double? CDThuongLuu_DinhDeCong { get; set; } = 0;

        [Required(ErrorMessage = "Bạn phải nhập Đáy dòng chảy!")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? CDThuongLuu_DayDongChay { get; set; } = 0;
        public Double? CDThuongLuu_CCaoTuongCongRanh { get; set; } = 0;
        public Double? CDThuongLuu_DinhTuongCHopRanh { get; set; } = 0;
        public Double? CDThuongLuu_DinhMuMoThotDuoiCongHopRanh { get; set; } = 0;
        public Double? CDThuongLuu_DinhGop { get; set; } = 0;

        [Required(ErrorMessage = "Bạn phải nhập Đỉnh trong lòng sử dụng!")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? CDThuongLuu_DinhTrongLongSuDung { get; set; } = 0;
        public Double? CDThuongLuu_DinhCongTron { get; set; } = 0;
        public Double? CDThuongLuu_DinhCongHop { get; set; } = 0;
        public Double? CDThuongLuu_DinhRanh { get; set; } = 0;
        public Double? CDThuongLuu_DinhOngNhua { get; set; } = 0;
        public Double? CDThuongLuu_DinhDapCat { get; set; } = 0;

        //Cao độ hạ lưu
        [Required(ErrorMessage = "Bạn phải nhập Hiện trạng trước khi đào hạ lưu (m)!")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? CDHaLu_HienTrangTruocKhiDaoHaLuu { get; set; } = 0;
        public Double? CDHaLu_DayDaoGop { get; set; } = 0;
        public Double? CDHaLu_ChieuSauDao { get; set; } = 0;
        public Double? CDHaLu_DayDaoCongTron { get; set; } = 0;
        public Double? CDHaLu_DayDaoCongHop { get; set; } = 0;
        public Double? CDHaLu_DayDaoRanh { get; set; } = 0;
        public Double? CDHaLu_DayDaoOngNhua { get; set; } = 0;
        public Double? CDHaLu_DinhLotGop { get; set; } = 0;
        public Double? CDHaLu_DinhLotOngNhua { get; set; } = 0;
        public Double? CDHaLu_DinhLotCongTron { get; set; } = 0;
        public Double? CDHaLu_DinhLotCongHop { get; set; } = 0;
        public Double? CDHaLu_DinhLotRanh { get; set; } = 0;
        public Double? CDHaLu_DinhMongGop { get; set; } = 0;
        public Double? CDHaLu_DinhMongCongTron { get; set; } = 0;
        public Double? CDHaLu_DinhMongCongHop { get; set; } = 0;
        public Double? CDHaLu_DinhMongRanh { get; set; } = 0;
        public Double? CDHaLu_DinhDeCong { get; set; } = 0;

        [Required(ErrorMessage = "Bạn phải nhập đáy dòng chảy!")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? CDHaLu_DayDongChay { get; set; } = 0;
        public Double? CDHaLu_CCaoTuongCongRanh { get; set; } = 0;
        public Double? CDHaLu_DinhTuongCHopRanh { get; set; } = 0;
        public Double? CDHaLu_DinhMuMoThotDuoiCongHopRanh { get; set; } = 0;
        public Double? CDHaLu_DinhGop { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập Đỉnh trong lòng sử dụng!")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? CDHaLu_DinhTrongLongSuDung { get; set; } = 0;
        public Double? CDHaLu_DinhCongTron { get; set; } = 0;
        public Double? CDHaLu_DinhCongHop { get; set; } = 0;
        public Double? CDHaLu_DinhRanh { get; set; } = 0;
        public Double? CDHaLu_DinhOngNhua { get; set; } = 0;
        public Double? CDHaLu_DinhDapCat { get; set; } = 0;

        //Thông tin vật liệu đào cống, rãnh
        [Required(ErrorMessage = "Bạn phải nhập Loại vật liệu đào cống rãnh!")]
        public string TTVLDCongRanh_LoaiVatLieuDao { get; set; } = "";

        [Required(ErrorMessage = "Bạn phải nhập Chiều cao đào đá thượng lưu!")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? TTVLDCongRanh_TLChieuCaoDaoDa { get; set; } = 0;

        public Double? TTVLDCongRanh_TLChieuCaoDaoDat { get; set; } = 0;
        public Double? TTVLDCongRanh_TLTongChieuSauDao { get; set; } = 0;

        [Required(ErrorMessage = "Bạn phải nhập Chiều cao đào đá hạ lưu!")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? TTVLDCongRanh_HLChieuCaoDaoDa { get; set; } = 0;
        public Double? TTVLDCongRanh_HLChieuCaoDaoDat { get; set; } = 0;
        public Double? TTVLDCongRanh_HLTongChieuSauDao { get; set; } = 0;

        public Double? TTCCCCT_CCaoLotDatTLuu { get; set; } = 0;
        public Double? TTCCCCT_CCaoLotDatHLuu { get; set; } = 0;
        public Double? TTCCCCT_CCaoLotDatMongTBinh { get; set; } = 0;
        public Double? TTCCCCT_CCaoLotDaTLuu { get; set; } = 0;
        public Double? TTCCCCT_CCaoLotDaHLuu { get; set; } = 0;
        public Double? TTCCCCT_CCaoLotDaMongTBinh { get; set; } = 0;
        public Double? TTCCCCT_CCaoMongDatTLuu { get; set; } = 0;
        public Double? TTCCCCT_CCaoMongDatHLuu { get; set; } = 0;
        public Double? TTCCCCT_CCaoMongDatTBinh { get; set; } = 0;
        public Double? TTCCCCT_CCaoMongDaTLuu { get; set; } = 0;
        public Double? TTCCCCT_CCaoMongDaHLuu { get; set; } = 0;
        public Double? TTCCCCT_CCaoMongDaTBinh { get; set; } = 0;
        public Double? TTCCCCT_CCaoDeDatTLuu { get; set; } = 0;
        public Double? TTCCCCT_CCaoDeDatHLuu { get; set; } = 0;
        public Double? TTCCCCT_CCaoDeDatTBinh { get; set; } = 0;
        public Double? TTCCCCT_CCaoDeDaTLuu { get; set; } = 0;
        public Double? TTCCCCT_CCaoDeDaHLuu { get; set; } = 0;
        public Double? TTCCCCT_CCaoDeDaTBinh { get; set; } = 0;
        public Double? TTCCCCT_CCaoCongDatTLuu { get; set; } = 0;
        public Double? TTCCCCT_CCaoCongDatHLuu { get; set; } = 0;
        public Double? TTCCCCT_CCongCongDatTBinh { get; set; } = 0;
        public Double? TTCCCCT_CCaoCongDaTLuu { get; set; } = 0;
        public Double? TTCCCCT_CCaoCongDaHLuu { get; set; } = 0;
        public Double? TTCCCCT_CCongCongDaTBinh { get; set; } = 0;
        public Double? TTCCCCCHR_CCaoLotDatTLuu { get; set; } = 0;
        public Double? TTCCCCCHR_CCaoLotDatHLuu { get; set; } = 0;
        public Double? TTCCCCCHR_CCaoLotDatTBinh { get; set; } = 0;
        public Double? TTCCCCCHR_CCaoLotDaTLuu { get; set; } = 0;
        public Double? TTCCCCCHR_CCaoLotDaHLuu { get; set; } = 0;
        public Double? TTCCCCCHR_CCaoLotDaTBinh { get; set; } = 0;
        public Double? TTCCCCCHR_CCaoMongDatTLuu { get; set; } = 0;
        public Double? TTCCCCCHR_CCaoMongDatHLuu { get; set; } = 0;
        public Double? TTCCCCCHR_CCaoMongDatTBinh { get; set; } = 0;
        public Double? TTCCCCCHR_CCaoMongDaTLuu { get; set; } = 0;
        public Double? TTCCCCCHR_CCaoMongDaHLuu { get; set; } = 0;
        public Double? TTCCCCCHR_CCaoMongDaTBinh { get; set; } = 0;
        public Double? TTCCCCCHR_CCaoTuongDatTLuu { get; set; } = 0;
        public Double? TTCCCCCHR_CCaoTuongDatHLuu { get; set; } = 0;
        public Double? TTCCCCCHR_CCaoTuongDatTBinh { get; set; } = 0;
        public Double? TTCCCCCHR_CCaoTuongDaTLuu { get; set; } = 0;
        public Double? TTCCCCCHR_CCaoTuongDaHLuu { get; set; } = 0;
        public Double? TTCCCCCHR_CCaoTuongDaTBinh { get; set; } = 0;
        public Double? TTCCCCON_CCaoDemCatDatTLuu { get; set; } = 0;
        public Double? TTCCCCON_CCaoDemCatDatHLuu { get; set; } = 0;
        public Double? TTCCCCON_CCaoDemCatDatTBinh { get; set; } = 0;
        public Double? TTCCCCON_CCaoDemCatDaTLuu { get; set; } = 0;
        public Double? TTCCCCON_CCaoDemCatDaHLuu { get; set; } = 0;
        public Double? TTCCCCON_CCaoDemCatDaTBinh { get; set; } = 0;
        public Double? TTCCCCON_CCaoOngDatTLuu { get; set; } = 0;
        public Double? TTCCCCON_CCaoOngDatHLuu { get; set; } = 0;
        public Double? TTCCCCON_CCaoDatTBinh { get; set; } = 0;
        public Double? TTCCCCON_CCaoOngDaTLuu { get; set; } = 0;
        public Double? TTCCCCON_CCaoOngDaHLuu { get; set; } = 0;
        public Double? TTCCCCON_CCaoDaTBinh { get; set; } = 0;
        public Double? TTCCCCON_CCaoDapCatDatTLuu { get; set; } = 0;
        public Double? TTCCCCON_CCaoDapCatDatHLuu { get; set; } = 0;
        public Double? TTCCCCON_CCaoDapCatDatTBinh { get; set; } = 0;
        public Double? TTCCCCON_CCaoDapCatDaTLuu { get; set; } = 0;
        public Double? TTCCCCON_CCaoDapCatDaHLuu { get; set; } = 0;
        public Double? TTCCCCON_CCaoDapCatDaTBinh { get; set; } = 0;
        public Double? TTMDRanhOngThang_ChieuRongDayDaoNho { get; set; } = 0;
        public Double? TTMDRanhOngThang_TyLeMoMai { get; set; } = 0;
        public Double? TTMDRanhOngThang_SoCanhMaiTrai { get; set; } = 0;
        public Double? TTMDRanhOngThang_SoCanhMaiPhai { get; set; } = 0;
        public Double? DTDTLCRONRT_CRongDaoDatDayLon { get; set; } = 0;
        public Double? DTDTLCRONRT_DTichDaoDat { get; set; } = 0;
        public Double? DTDTLCRONRT_CRongDaoDaDayLon { get; set; } = 0;
        public Double? DTDTLCRONRT_DTichDaoDa { get; set; } = 0;
        public Double? DTDHLCRONRT_CRongDaoDatDayLon { get; set; } = 0;
        public Double? DTDHLCRONRT_DTichDaoDat { get; set; } = 0;
        public Double? DTDHLCRONRT_CRongDaoDaDayLon { get; set; } = 0;
        public Double? DTDHLCRONRT_DTichDaoDa { get; set; } = 0;
        public Double? DTDTB_DaoDatCRDaoDayLon { get; set; } = 0;
        public Double? DTDTB_DaoDatDTDao { get; set; } = 0;
        public Double? DTDTB_DaoDaCRDaoDayLon { get; set; } = 0;
        public Double? DTDTB_DaoDaDTDao { get; set; } = 0;
        public Double? TKLD_KlDaoDat { get; set; } = 0;
        public Double? TKLD_KlDaoDa { get; set; } = 0;
        public Double? TKLD_TongKlDaoCongRanhOngNhuaRanhThang { get; set; } = 0;
        public Double? TKLD_KlCChoDatCongTron { get; set; } = 0;
        public Double? TKLD_KlCChoDaCongTron { get; set; } = 0;
        public Double? TKLD_TongKlChiemChoCTron { get; set; } = 0;
        public Double? TKLD_KlCChoDatCongHop { get; set; } = 0;
        public Double? TKLD_KlCChoDaCongHop { get; set; } = 0;
        public Double? TKLD_TongKlCChoCongHop { get; set; } = 0;
        public Double? TKLD_KlCChoDatRanh { get; set; } = 0;
        public Double? TKLD_KlCChoDaRanh { get; set; } = 0;
        public Double? TKLD_TongKlCChoRanh { get; set; } = 0;
        public Double? TKLD_KlCChoDatOngNhua { get; set; } = 0;
        public Double? TKLD_KlCChoDaOngNhua { get; set; } = 0;
        public Double? TKLD_TongKlCChoOngNhua { get; set; } = 0;
        public Double? TKLD_KlCChoDat { get; set; } = 0;
        public Double? TKLD_KlCChoDa { get; set; } = 0;
        public Double? TKLD_TongChiemCho { get; set; } = 0;
        public Double? TKLD_KlDapTraDat { get; set; } = 0;
        public Double? TKLD_KlDapTraDa { get; set; } = 0;
        public Double? TKLD_TongKlDapTra { get; set; } = 0;
        public Double? TKLD_KlThuaDat { get; set; } = 0;
        public Double? TKLD_KlThuaDa { get; set; } = 0;
        public Double? TKLD_TongKLThua { get; set; } = 0;
        public Double? DTDC_TLCSauDap { get; set; } = 0;
        public Double? DTDC_TLCRongDapDayLon { get; set; } = 0;
        public Double? DTDC_TLDTichDap { get; set; } = 0;
        public Double? DTDC_HLCSauDap { get; set; } = 0;
        public Double? DTDC_HLCRongDapDayLon { get; set; } = 0;
        public Double? DTDC_HLDTichDap { get; set; } = 0;
        public Double? DTTB_CSDap { get; set; } = 0;
        public Double? DTTB_CRDapDayLon { get; set; } = 0;
        public Double? DTTB_DTichDap { get; set; } = 0;
        public Double? TTKLDC_KlDapCatTruocChiemCho { get; set; } = 0;
        public Double? TTKLDC_KlChiemCho { get; set; } = 0;
        public Double? TTKLDC_KlDapCatSauChiemCho { get; set; } = 0;

        //Tọa độ
        [Display(Name = "Tọa độ X")]
        [Required(ErrorMessage = "Bạn phải nhập tọa độ X!")]
        [RegularExpression(@"^-?\d+(\.\d{1,6})?$", ErrorMessage = "Tọa độ X phải là số hợp lệ với tối đa 6 chữ số thập phân.")]
        public Double? ToaDoX { get; set; } = 0;

        [Display(Name = "Tọa độ X")]
        [Required(ErrorMessage = "Bạn phải nhập tọa độ Y!")]
        [RegularExpression(@"^-?\d+(\.\d{1,6})?$", ErrorMessage = "Tọa độ X phải là số hợp lệ với tối đa 6 chữ số thập phân.")]
        public Double? ToaDoY { get; set; } = 0;

        public int Flag { get; set; } = 0;
        public DateTime? CreateAt { get; set; } = DateTime.Now;
        public string? CreateBy { get; set; } = "";
        public int? IsActive { get; set; } = 1;

    }

}

