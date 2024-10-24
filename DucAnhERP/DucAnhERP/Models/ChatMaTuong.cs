using System.ComponentModel.DataAnnotations;

namespace DucAnhERP.Models
{
    public class ChatMaTuong
    {
        [Required(ErrorMessage = "Bạn phải nhập tên công tác !")]
        public string KLGXTenCongTac { get; set; } = "";
        [Required(ErrorMessage = "Bạn phải nhập khối lượng !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? KLGXKL { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập tên công tác !")]
        public string KLCTenCongTac { get; set; } = "";
        [Required(ErrorMessage = "Bạn phải nhập khối lượng !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? KLCKL { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập tên công tác !")]
        public string KLBTTenCongTac { get; set; } = "";
        [Required(ErrorMessage = "Bạn phải nhập khối lượng !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? KLBTKL { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập tên công tác !")]
        public string KLVKTenCongTac { get; set; } = "";
        [Required(ErrorMessage = "Bạn phải nhập khối lượng !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? KLVKKL { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập tên công tác !")]
        public string KLSTenCongTac { get; set; } = "";
        [Required(ErrorMessage = "Bạn phải nhập khối lượng !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? KLSKL { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập tên công tác !")]
        public string KLSTenCongTac1 { get; set; } = "";
        [Required(ErrorMessage = "Bạn phải nhập khối lượng !")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Giá trị phải là số hợp lệ với tối đa 3 chữ số thập phân.")]
        public Double? KLSKL1 { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập tên công tác !")]
        public string ThongTinChungHoGa_TenHoGaSauPhanLoai { get; set; } = "";
        //Hạng mục chiếm chỗ hố ga
        //1.Hình thức đấu nối
        public Double? HinhThucDauNoi1Loai { get; set; } = 0;
        public string? HinhThucDauNoi1KLBoSung { get; set; } = "";
        public Double? HinhThucDauNoi1CanhDai { get; set; } = 0;
        public Double? HinhThucDauNoi1CDD { get; set; } = 0;
        public Double? HinhThucDauNoi1CDR { get; set; } = 0;
        public Double? HinhThucDauNoi1CDC { get; set; } = 0;
        public Double? HinhThucDauNoi1CanhRong { get; set; } = 0;
        public Double? HinhThucDauNoi1CRD { get; set; } = 0;
        public Double? HinhThucDauNoi1CRR { get; set; } = 0;
        public Double? HinhThucDauNoi1CRC { get; set; } = 0;
        public Double? HinhThucDauNoi1CanhCheo { get; set; } = 0;
        public Double? HinhThucDauNoi1CCD { get; set; } = 0;
        public Double? HinhThucDauNoi1CCR { get; set; } = 0;
        public Double? HinhThucDauNoi1CCC { get; set; } = 0;
        //2.Hình thức đấu nối    HinhThucDauNoi2
        public Double? HinhThucDauNoi2Loai { get; set; } = 0;
        public string? HinhThucDauNoi2KLBoSung { get; set; } = "";
        public Double? HinhThucDauNoi2CanhDai { get; set; } = 0;
        public Double? HinhThucDauNoi2CDD { get; set; } = 0;
        public Double? HinhThucDauNoi2CDR { get; set; } = 0;
        public Double? HinhThucDauNoi2CDC { get; set; } = 0;
        public Double? HinhThucDauNoi2CanhRong { get; set; } = 0;
        public Double? HinhThucDauNoi2CRD { get; set; } = 0;
        public Double? HinhThucDauNoi2CRR { get; set; } = 0;
        public Double? HinhThucDauNoi2CRC { get; set; } = 0;
        public Double? HinhThucDauNoi2CanhCheo { get; set; } = 0;
        public Double? HinhThucDauNoi2CCD { get; set; } = 0;
        public Double? HinhThucDauNoi2CCR { get; set; } = 0;
        public Double? HinhThucDauNoi2CCC { get; set; } = 0;
        //3.Hình thức đấu nối    HinhThucDauNoi3
        public Double? HinhThucDauNoi3Loai { get; set; } = 0;
        public string? HinhThucDauNoi3KLBoSung { get; set; } = "";
        public Double? HinhThucDauNoi3CanhDai { get; set; } = 0;
        public Double? HinhThucDauNoi3CDD { get; set; } = 0;
        public Double? HinhThucDauNoi3CDR { get; set; } = 0;
        public Double? HinhThucDauNoi3CDC { get; set; } = 0;
        public Double? HinhThucDauNoi3CanhRong { get; set; } = 0;
        public Double? HinhThucDauNoi3CRD { get; set; } = 0;
        public Double? HinhThucDauNoi3CRR { get; set; } = 0;
        public Double? HinhThucDauNoi3CRC { get; set; } = 0;
        public Double? HinhThucDauNoi3CanhCheo { get; set; } = 0;
        public Double? HinhThucDauNoi3CCD { get; set; } = 0;
        public Double? HinhThucDauNoi3CCR { get; set; } = 0;
        public Double? HinhThucDauNoi3CCC { get; set; } = 0;
        //4.Hình thức đấu nối    HinhThucDauNoi4
        public Double? HinhThucDauNoi4Loai { get; set; } = 0;
        public string? HinhThucDauNoi4KLBoSung { get; set; } = "";
        public Double? HinhThucDauNoi4CanhDai { get; set; } = 0;
        public Double? HinhThucDauNoi4CDD { get; set; } = 0;
        public Double? HinhThucDauNoi4CDR { get; set; } = 0;
        public Double? HinhThucDauNoi4CDC { get; set; } = 0;
        public Double? HinhThucDauNoi4CanhRong { get; set; } = 0;
        public Double? HinhThucDauNoi4CRD { get; set; } = 0;
        public Double? HinhThucDauNoi4CRR { get; set; } = 0;
        public Double? HinhThucDauNoi4CRC { get; set; } = 0;
        public Double? HinhThucDauNoi4CanhCheo { get; set; } = 0;
        public Double? HinhThucDauNoi4CCD { get; set; } = 0;
        public Double? HinhThucDauNoi4CCR { get; set; } = 0;
        public Double? HinhThucDauNoi4CCC { get; set; } = 0;
        //5.Hình thức đấu nối    HinhThucDauNoi5
        public Double? HinhThucDauNoi5Loai { get; set; } = 0;
        public string? HinhThucDauNoi5KLBoSung { get; set; } = "";
        public Double? HinhThucDauNoi5CanhDai { get; set; } = 0;
        public Double? HinhThucDauNoi5CDD { get; set; } = 0;
        public Double? HinhThucDauNoi5CDR { get; set; } = 0;
        public Double? HinhThucDauNoi5CDC { get; set; } = 0;
        public Double? HinhThucDauNoi5CanhRong { get; set; } = 0;
        public Double? HinhThucDauNoi5CRD { get; set; } = 0;
        public Double? HinhThucDauNoi5CRR { get; set; } = 0;
        public Double? HinhThucDauNoi5CRC { get; set; } = 0;
        public Double? HinhThucDauNoi5CanhCheo { get; set; } = 0;
        public Double? HinhThucDauNoi5CCD { get; set; } = 0;
        public Double? HinhThucDauNoi5CCR { get; set; } = 0;
        public Double? HinhThucDauNoi5CCC { get; set; } = 0;
        //6.Hình thức đấu nối    HinhThucDauNoi6
        public Double? HinhThucDauNoi6Loai { get; set; } = 0;
        public string? HinhThucDauNoi6KLBoSung { get; set; } = "";
        public Double? HinhThucDauNoi6CanhDai { get; set; } = 0;
        public Double? HinhThucDauNoi6CDD { get; set; } = 0;
        public Double? HinhThucDauNoi6CDR { get; set; } = 0;
        public Double? HinhThucDauNoi6CDC { get; set; } = 0;
        public Double? HinhThucDauNoi6CanhRong { get; set; } = 0;
        public Double? HinhThucDauNoi6CRD { get; set; } = 0;
        public Double? HinhThucDauNoi6CRR { get; set; } = 0;
        public Double? HinhThucDauNoi6CRC { get; set; } = 0;
        public Double? HinhThucDauNoi6CanhCheo { get; set; } = 0;
        public Double? HinhThucDauNoi6CCD { get; set; } = 0;
        public Double? HinhThucDauNoi6CCR { get; set; } = 0;
        public Double? HinhThucDauNoi6CCC { get; set; } = 0;
        //7.Hình thức đấu nối    HinhThucDauNoi7
        public Double? HinhThucDauNoi7Loai { get; set; } = 0;
        public string? HinhThucDauNoi7KLBoSung { get; set; } = "";
        public Double? HinhThucDauNoi7CanhDai { get; set; } = 0;
        public Double? HinhThucDauNoi7CDD { get; set; } = 0;
        public Double? HinhThucDauNoi7CDR { get; set; } = 0;
        public Double? HinhThucDauNoi7CDC { get; set; } = 0;
        public Double? HinhThucDauNoi7CanhRong { get; set; } = 0;
        public Double? HinhThucDauNoi7CRD { get; set; } = 0;
        public Double? HinhThucDauNoi7CRR { get; set; } = 0;
        public Double? HinhThucDauNoi7CRC { get; set; } = 0;
        public Double? HinhThucDauNoi7CanhCheo { get; set; } = 0;
        public Double? HinhThucDauNoi7CCD { get; set; } = 0;
        public Double? HinhThucDauNoi7CCR { get; set; } = 0;
        public Double? HinhThucDauNoi7CCC { get; set; } = 0;
        //8.Hình thức đấu nối    HinhThucDauNoi8
        public Double? HinhThucDauNoi8Loai { get; set; } = 0;
        public string? HinhThucDauNoi8KLBoSung { get; set; } = "";
        public Double? HinhThucDauNoi8CanhDai { get; set; } = 0;
        public Double? HinhThucDauNoi8CDD { get; set; } = 0;
        public Double? HinhThucDauNoi8CDR { get; set; } = 0;
        public Double? HinhThucDauNoi8CDC { get; set; } = 0;
        public Double? HinhThucDauNoi8CanhRong { get; set; } = 0;
        public Double? HinhThucDauNoi8CRD { get; set; } = 0;
        public Double? HinhThucDauNoi8CRR { get; set; } = 0;
        public Double? HinhThucDauNoi8CRC { get; set; } = 0;
        public Double? HinhThucDauNoi8CanhCheo { get; set; } = 0;
        public Double? HinhThucDauNoi8CCD { get; set; } = 0;
        public Double? HinhThucDauNoi8CCR { get; set; } = 0;
        public Double? HinhThucDauNoi8CCC { get; set; } = 0;
    }
}
