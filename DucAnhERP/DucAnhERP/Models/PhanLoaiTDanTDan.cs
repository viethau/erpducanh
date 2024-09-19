using System.ComponentModel.DataAnnotations;

namespace DucAnhERP.Models
{
    public class PhanLoaiTDanTDan
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public int Flag { get; set; } = 0;

        [Required(ErrorMessage = "Bạn phải nhập tên tấm đan tiêu chuẩn")]
        public string? TTTDCongHoRanh_TenLoaiTamDanTieuChuan { get; set; } = "";

        [Required(ErrorMessage = "Bạn phải nhập Từ lý trình!")]
        [Range(0.000, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,5})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 5 chữ số thập phân.")]
        public Double? ThongTinLyTrinhTruyenDan_TuLyTrinh { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập Đến lý trình!")]
        [Range(0.000, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,5})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 5 chữ số thập phân.")]
        public Double? ThongTinLyTrinhTruyenDan_DenLyTrinh { get; set; } = 0;

        //[Required(ErrorMessage = "Bạn phải nhập Hình thức truyền dẫn!")]
        public string? ThongTinDuongTruyenDan_HinhThucTruyenDan { get; set; } = "";
        //[Required(ErrorMessage = "Bạn phải nhập Loại truyền dẫn !")]
        public string? ThongTinDuongTruyenDan_LoaiTruyenDan { get; set; } = "";

        //[Required(ErrorMessage = "Bạn phải nhập Cấu tạo tấm đan truyền dẫn tấm đan tiêu chuẩn!")]
        public string TTTDCongHoRanh_CauTaoTamDanTruyenDanTamDanTieuChuan { get; set; } = "";
        
        public Double? TTTDCongHoRanh_CDai { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập C.Rộng!")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? TTTDCongHoRanh_CRong { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập  C.Cao!")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? TTTDCongHoRanh_CCao { get; set; } = 0;
        public DateTime? CreateAt { get; set; } = DateTime.Now;
        public string? CreateBy { get; set; } = "";
        public int? IsActive { get; set; } = 1;
    }
}
