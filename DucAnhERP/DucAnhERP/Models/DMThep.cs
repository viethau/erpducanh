using System.ComponentModel.DataAnnotations;

namespace DucAnhERP.Models
{
    public class DMThep
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public int Flag { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải chọn chủng loại thép ")]
        public string? ChungLoaiThep { get; set; } = "";

        [Required(ErrorMessage = "Bạn phải nhập đường kính")]
        public string? DuongKinh { get; set; } ="";

        [Required(ErrorMessage = "Bạn phải nhập đơn vị")]
        public string? DonVi { get; set; } = "";

        [Required(ErrorMessage = "Bạn phải nhập Trọng lượng ")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? TrongLuong { get; set; } = 0;

        public DateTime? CreateAt { get; set; } = DateTime.Now;
        public string? CreateBy { get; set; } = "";
        public int? IsActive { get; set; } = 1;
    }
}
