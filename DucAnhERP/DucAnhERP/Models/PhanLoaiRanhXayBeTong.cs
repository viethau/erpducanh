using System.ComponentModel.DataAnnotations;

namespace DucAnhERP.Models
{
    public class PhanLoaiRanhXayBeTong
    {

        public string Id { get; set; } = Guid.NewGuid().ToString();
        public int Flag { get; set; } = 0;

        [Required(ErrorMessage = "Bạn phải nhập Tên loại truyền dẫn sau phân loại!")]
        public string? ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai { get; set; } = "";

        [Required(ErrorMessage = "Bạn phải nhập Hình thức truyền dẫn!")]
        public string? ThongTinDuongTruyenDan_HinhThucTruyenDan { get; set; } = "";
        [Required(ErrorMessage = "Bạn phải nhập Loại truyền dẫn !")]
        public string? ThongTinDuongTruyenDan_LoaiTruyenDan { get; set; } = "";

        [Required(ErrorMessage = "Bạn phải nhập cấu tạo tường!")]
        public string? TTKTHHCongHopRanh_CauTaoTuong { get; set; } = "";

        [Required(ErrorMessage = "Bạn phải nhập cấu tạo mũ mố!")]
        public string? TTKTHHCongHopRanh_CauTaoMuMo { get; set; } = "";
        [Required(ErrorMessage = "Bạn phải nhập Chát mặt trong !")]
        public string? TTKTHHCongHopRanh_ChatMatTrong { get; set; } = "";
        [Required(ErrorMessage = "Bạn phải nhập Chát mặt ngoài!")]
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
        [Required(ErrorMessage = "Bạn phải nhập chiều cao chát mặt trong !")]
        [Range(0, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        public Double? TTKTHHCongHopRanh_CCaoChatMatTrong { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập chiều cao chát mặt ngoài !")]
        [Range(0, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        public Double? TTKTHHCongHopRanh_CCaoChatmatNgoai { get; set; } = 0;

        public DateTime? CreateAt { get; set; } = DateTime.Now;
        public string? CreateBy { get; set; } = "";
        public int? IsActive { get; set; } = 1;
    }
}
