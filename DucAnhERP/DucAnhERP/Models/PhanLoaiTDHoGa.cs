using System.ComponentModel.DataAnnotations;

namespace DucAnhERP.Models
{
    public class MPhanLoaiTDHoGa
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public int Flag { get; set; } = 0;
       
        [Required(ErrorMessage = "Bạn phải nhập Phân loại đậy hố ga !")]
        public string? ThongTinTamDanHoGa2_PhanLoaiDayHoGa { get; set; } = "";
        [Required(ErrorMessage = "Bạn phải nhập Hình thức đậy hố ga !")]
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
       
    }
}
