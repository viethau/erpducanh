using System.ComponentModel.DataAnnotations;

namespace DucAnhERP.Models
{
    public class TKThepMongCHop
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public int Flag { get; set; } = 0;

        [Required(ErrorMessage = "Bạn phải chọn tuyến đường")]
        public string ThongTinLyTrinh_TuyenDuong { get; set; }
        public Double ThongTinLyTrinhTruyenDan_TuLyTrinh { get; set; }
        public Double ThongTinLyTrinhTruyenDan_DenLyTrinh { get; set; }

        [Required(ErrorMessage = "Bạn phải chọn loại cấu kiện ")]
        public string ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop { get; set; } = "";
        [Required(ErrorMessage = "Bạn phải nhập Tên công tác ")]
        public string? TenCongTac { get; set; } = "";
        [Required(ErrorMessage = "Vị trí lấy khối lượng")]
        public string? VTLayKhoiLuong { get; set; } = "";
        [Required(ErrorMessage = "Loại thép")]
        public string? LoaiThep { get; set; } = "";

        [Required(ErrorMessage = "Bạn phải nhập số hiệu")]
        public string? SoHieu { get; set; } = "";

        [Required(ErrorMessage = "Bạn phải nhập Đường kính/chiều dầy")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,4})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? DKCD { get; set; } = 0;

        [Required(ErrorMessage = "Bạn phải nhập Số thanh/01 cấu kiện")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,4})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public int? SoThanh { get; set; } = 0;

        [Required(ErrorMessage = "Bạn phải nhập Số cấu kiện")]
        [Range(0, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        public int? SoCK { get; set; } = 0;

        [Required(ErrorMessage = "Bạn phải nhập Tổng số thanh")]
        public int? TongSoThanh { get; set; } = 0;

        [Required(ErrorMessage = "Bạn phải nhập Chiều dài 01 thanh")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,4})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? ChieuDai1Thanh { get; set; } = 0;

        public Double? TongChieuDai { get; set; } = 0;

        [Required(ErrorMessage = "Bạn phải nhập Trọng lượng thép")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,4})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? TrongLuong { get; set; } = 0;

        public Double? TongTrongLuong { get; set; } = 0;

        public DateTime? CreateAt { get; set; } = DateTime.Now;
        public string? CreateBy { get; set; } = "";
        public int? IsActive { get; set; } = 1;
    }
}
