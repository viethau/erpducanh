using System.ComponentModel.DataAnnotations;

namespace DucAnhERP.Models
{
    public class PhanLoaiDeCong
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public int Flag { get; set; } = 0;

        [Required(ErrorMessage = "Bạn phải nhập tên loại đế cống ")]
        public string? ThongTinDeCong_TenLoaiDeCong { get; set; } = "";

        [Required(ErrorMessage = "Bạn phải nhập Loại truyền dẫn !")]
        public string? ThongTinDuongTruyenDan_LoaiTruyenDan { get; set; } = "";

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
        public int? Loai { get; set; } = 0;
        public DateTime? CreateAt { get; set; } = DateTime.Now;
        public string? CreateBy { get; set; } = "";
        public int? IsActive { get; set; } = 1;
       
    }
}
