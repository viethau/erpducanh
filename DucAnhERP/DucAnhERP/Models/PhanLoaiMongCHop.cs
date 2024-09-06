using System.ComponentModel.DataAnnotations;

namespace DucAnhERP.Models
{
    public class PhanLoaiMongCHop
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public int Flag { get; set; } = 0;

        [Required(ErrorMessage = "Bạn phải nhập phân loại móng cống hộp!")]
        public string? ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop { get; set; } = "";

        [Required(ErrorMessage = "Bạn phải nhập Tên hố ga theo bản vẽ!")]
        public string ThongTinChungHoGa_TenHoGaTheoBanVe { get; set; } = "";
        [Required(ErrorMessage = "Bạn phải nhập Hình thức truyền dẫn!")]
        public string? ThongTinDuongTruyenDan_HinhThucTruyenDan { get; set; } = "";
        [Required(ErrorMessage = "Bạn phải nhập Loại truyền dẫn !")]
        public string? ThongTinDuongTruyenDan_LoaiTruyenDan { get; set; } = "";
        [Required(ErrorMessage = "Bạn phải nhập loại móng!")]
        public string? ThongTinMongDuongTruyenDan_LoaiMong { get; set; } = "";
        [Required(ErrorMessage = "Bạn phải nhập hình thức móng!")]
        public string? ThongTinMongDuongTruyenDan_HinhThucMong { get; set; } = "";

        [Required(ErrorMessage = "Bạn phải nhập C.Cao lót móng (m)!")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? TTKTHHCongHopRanh_CCaoLotMong { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập C.Rộng lót móng!")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? TTKTHHCongHopRanh_CRongLotMong { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập C.Cao móng!")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? TTKTHHCongHopRanh_CCaoMong { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập C.Rộng móng !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? TTKTHHCongHopRanh_CRongMong { get; set; } = 0;

    }
}
