using System.ComponentModel.DataAnnotations;

namespace DucAnhERP.Models
{
    public class PhanLoaiThanhChong
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public int Flag { get; set; } = 0;

        [Required(ErrorMessage = "Bạn phải nhập loại thanh chống")]
        public string? TTKTHHCongHopRanh_LoaiThanhChong { get; set; } = "";

        //[Required(ErrorMessage = "Bạn phải nhập Cấu tạo thanh chống!")]
        public string? TTKTHHCongHopRanh_CauTaoThanhChong { get; set; } = "";

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
        public DateTime? CreateAt { get; set; } = DateTime.Now;
        public string? CreateBy { get; set; } = "";
        public int? IsActive { get; set; } = 1;
    }
}
