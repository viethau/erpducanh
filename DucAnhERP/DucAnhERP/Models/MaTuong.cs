using System.ComponentModel.DataAnnotations;

namespace DucAnhERP.Models
{
    public class MaTuong
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public int Flag { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập tên công tác !")]
        public string KLGX_TenCongTac        { get; set; } = "";

        [Required(ErrorMessage = "Bạn phải nhập khối lượng !")]
        public Double? KLGX_KL { get; set; } = 0;

        [Required(ErrorMessage = "Bạn phải nhập tên công tác !")]
        public string KLC_TenCongTac { get; set; } = "";

        [Required(ErrorMessage = "Bạn phải nhập khối lượng !")]
        public Double? KLC_KL { get; set; } = 0;

        [Required(ErrorMessage = "Bạn phải nhập tên công tác !")]
        public string? KLBT_TenCongTac { get; set; } = "";

        [Required(ErrorMessage = "Bạn phải nhập khối lượng !")]
        public double KLBT_KL { get; set; } = 0;
        
        [Required(ErrorMessage = "Bạn phải nhập tên công tác !")]
        public string? KLVK_TenCongTac { get; set; } = "";

        [Required(ErrorMessage = "Bạn phải nhập khối lượng !")]
        public double KLVK_KL { get; set; } = 0;

        [Required(ErrorMessage = "Bạn phải nhập tên công tác !")]
        public string? KLS_TenCongTac { get; set; } = "";

        [Required(ErrorMessage = "Bạn phải nhập khối lượng !")]
        public double KLS_KL { get; set; } = 0;

        
        [Required(ErrorMessage = "Bạn phải nhập tên công tác !")]
        public string KLS_TenCongTac1 { get; set; } = "";

        [Required(ErrorMessage = "Bạn phải nhập khối lượng !")]
        public Double? KLS_KL1 { get; set; } = 0;
               
        public string ThongTinChungHoGa_TenHoGaSauPhanLoai { get; set; } = "";
        //Hạng mục chiếm chỗ hố ga
        //1.Hình thức đấu nối
        public Double? HinhThucDauNoi1_Loai { get; set; } = 0;
        public string? HinhThucDauNoi1_KLBoSung { get; set; } = "";
        public Double? HinhThucDauNoi1_CanhDai { get; set; } = 0;
        public Double? HinhThucDauNoi1_CDD { get; set; } = 0;
        public Double? HinhThucDauNoi1_CDR { get; set; } = 0;
        public Double? HinhThucDauNoi1_CDC { get; set; } = 0;
        public Double? HinhThucDauNoi1_CanhRong { get; set; } = 0;
        public Double? HinhThucDauNoi1_CRD { get; set; } = 0;
        public Double? HinhThucDauNoi1_CRR { get; set; } = 0;
        public Double? HinhThucDauNoi1_CRC { get; set; } = 0;
        public Double? HinhThucDauNoi1_CanhCheo { get; set; } = 0;
        public Double? HinhThucDauNoi1_CCD { get; set; } = 0;
        public Double? HinhThucDauNoi1_CCR { get; set; } = 0;
        public Double? HinhThucDauNoi1_CCC { get; set; } = 0;
        public Double? HinhThucDauNoi2_Loai { get; set; } = 0;
        public string? HinhThucDauNoi2_KLBoSung { get; set; } = "";
        public Double? HinhThucDauNoi2_CanhDai { get; set; } = 0;
        public Double? HinhThucDauNoi2_CDD { get; set; } = 0;
        public Double? HinhThucDauNoi2_CDR { get; set; } = 0;
        public Double? HinhThucDauNoi2_CDC { get; set; } = 0;
        public Double? HinhThucDauNoi2_CanhRong { get; set; } = 0;
        public Double? HinhThucDauNoi2_CRD { get; set; } = 0;
        public Double? HinhThucDauNoi2_CRR { get; set; } = 0;
        public Double? HinhThucDauNoi2_CRC { get; set; } = 0;
        public Double? HinhThucDauNoi2_CanhCheo { get; set; } = 0;
        public Double? HinhThucDauNoi2_CCD { get; set; } = 0;
        public Double? HinhThucDauNoi2_CCR { get; set; } = 0;
        public Double? HinhThucDauNoi2_CCC { get; set; } = 0;
        public Double? HinhThucDauNoi3_Loai { get; set; } = 0;
        public string? HinhThucDauNoi3_KLBoSung { get; set; } = "";
        public Double? HinhThucDauNoi3_CanhDai { get; set; } = 0;
        public Double? HinhThucDauNoi3_CDD { get; set; } = 0;
        public Double? HinhThucDauNoi3_CDR { get; set; } = 0;
        public Double? HinhThucDauNoi3_CDC { get; set; } = 0;
        public Double? HinhThucDauNoi3_CanhRong { get; set; } = 0;
        public Double? HinhThucDauNoi3_CRD { get; set; } = 0;
        public Double? HinhThucDauNoi3_CRR { get; set; } = 0;
        public Double? HinhThucDauNoi3_CRC { get; set; } = 0;
        public Double? HinhThucDauNoi3_CanhCheo { get; set; } = 0;
        public Double? HinhThucDauNoi3_CCD { get; set; } = 0;
        public Double? HinhThucDauNoi3_CCR { get; set; } = 0;
        public Double? HinhThucDauNoi3_CCC { get; set; } = 0;
        public Double? HinhThucDauNoi4_Loai { get; set; } = 0;
        public string? HinhThucDauNoi4_KLBoSung { get; set; } = "";
        public Double? HinhThucDauNoi4_CanhDai { get; set; } = 0;
        public Double? HinhThucDauNoi4_CDD { get; set; } = 0;
        public Double? HinhThucDauNoi4_CDR { get; set; } = 0;
        public Double? HinhThucDauNoi4_CDC { get; set; } = 0;
        public Double? HinhThucDauNoi4_CanhRong { get; set; } = 0;
        public Double? HinhThucDauNoi4_CRD { get; set; } = 0;
        public Double? HinhThucDauNoi4_CRR { get; set; } = 0;
        public Double? HinhThucDauNoi4_CRC { get; set; } = 0;
        public Double? HinhThucDauNoi4_CanhCheo { get; set; } = 0;
        public Double? HinhThucDauNoi4_CCD { get; set; } = 0;
        public Double? HinhThucDauNoi4_CCR { get; set; } = 0;
        public Double? HinhThucDauNoi4_CCC { get; set; } = 0;
        public Double? HinhThucDauNoi5_Loai { get; set; } = 0;
        public string? HinhThucDauNoi5_KLBoSung { get; set; } = "";
        public Double? HinhThucDauNoi5_CanhDai { get; set; } = 0;
        public Double? HinhThucDauNoi5_CDD { get; set; } = 0;
        public Double? HinhThucDauNoi5_CDR { get; set; } = 0;
        public Double? HinhThucDauNoi5_CDC { get; set; } = 0;
        public Double? HinhThucDauNoi5_CanhRong { get; set; } = 0;
        public Double? HinhThucDauNoi5_CRD { get; set; } = 0;
        public Double? HinhThucDauNoi5_CRR { get; set; } = 0;
        public Double? HinhThucDauNoi5_CRC { get; set; } = 0;
        public Double? HinhThucDauNoi5_CanhCheo { get; set; } = 0;
        public Double? HinhThucDauNoi5_CCD { get; set; } = 0;
        public Double? HinhThucDauNoi5_CCR { get; set; } = 0;
        public Double? HinhThucDauNoi5_CCC { get; set; } = 0;
        public Double? HinhThucDauNoi6_Loai { get; set; } = 0;
        public string? HinhThucDauNoi6_KLBoSung { get; set; } = "";
        public Double? HinhThucDauNoi6_CanhDai { get; set; } = 0;
        public Double? HinhThucDauNoi6_CDD { get; set; } = 0;
        public Double? HinhThucDauNoi6_CDR { get; set; } = 0;
        public Double? HinhThucDauNoi6_CDC { get; set; } = 0;
        public Double? HinhThucDauNoi6_CanhRong { get; set; } = 0;
        public Double? HinhThucDauNoi6_CRD { get; set; } = 0;
        public Double? HinhThucDauNoi6_CRR { get; set; } = 0;
        public Double? HinhThucDauNoi6_CRC { get; set; } = 0;
        public Double? HinhThucDauNoi6_CanhCheo { get; set; } = 0;
        public Double? HinhThucDauNoi6_CCD { get; set; } = 0;
        public Double? HinhThucDauNoi6_CCR { get; set; } = 0;
        public Double? HinhThucDauNoi6_CCC { get; set; } = 0;
        public Double? HinhThucDauNoi7_Loai { get; set; } = 0;
        public string? HinhThucDauNoi7_KLBoSung { get; set; } = "";
        public Double? HinhThucDauNoi7_CanhDai { get; set; } = 0;
        public Double? HinhThucDauNoi7_CDD { get; set; } = 0;
        public Double? HinhThucDauNoi7_CDR { get; set; } = 0;
        public Double? HinhThucDauNoi7_CDC { get; set; } = 0;
        public Double? HinhThucDauNoi7_CanhRong { get; set; } = 0;
        public Double? HinhThucDauNoi7_CRD { get; set; } = 0;
        public Double? HinhThucDauNoi7_CRR { get; set; } = 0;
        public Double? HinhThucDauNoi7_CRC { get; set; } = 0;
        public Double? HinhThucDauNoi7_CanhCheo { get; set; } = 0;
        public Double? HinhThucDauNoi7_CCD { get; set; } = 0;
        public Double? HinhThucDauNoi7_CCR { get; set; } = 0;
        public Double? HinhThucDauNoi7_CCC { get; set; } = 0;
        public Double? HinhThucDauNoi8_Loai { get; set; } = 0;
        public string? HinhThucDauNoi8_KLBoSung { get; set; } = "";
        public Double? HinhThucDauNoi8_CanhDai { get; set; } = 0;
        public Double? HinhThucDauNoi8_CDD { get; set; } = 0;
        public Double? HinhThucDauNoi8_CDR { get; set; } = 0;
        public Double? HinhThucDauNoi8_CDC { get; set; } = 0;
        public Double? HinhThucDauNoi8_CanhRong { get; set; } = 0;
        public Double? HinhThucDauNoi8_CRD { get; set; } = 0;
        public Double? HinhThucDauNoi8_CRR { get; set; } = 0;
        public Double? HinhThucDauNoi8_CRC { get; set; } = 0;
        public Double? HinhThucDauNoi8_CanhCheo { get; set; } = 0;
        public Double? HinhThucDauNoi8_CCD { get; set; } = 0;
        public Double? HinhThucDauNoi8_CCR { get; set; } = 0;
        public Double? HinhThucDauNoi8_CCC { get; set; } = 0;

        public DateTime? CreateAt { get; set; } = DateTime.Now;
        public string? CreateBy { get; set; } = "";
        public int? IsActive { get; set; } = 1;
    }
}
