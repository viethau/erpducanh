using System.ComponentModel.DataAnnotations;

namespace DucAnhERP.Models
{
    public class PKKLCTietTDHG
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public int Flag { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải chọn loại cấu kiện")]
        public string ThongTinTamDanHoGa2_PhanLoaiDayHoGa { get; set; } = "";
        public string LoaiBeTong { get; set; } = "";
        [Required(ErrorMessage = "Bạn phải chọn hạng mục ")]
        public string HangMuc { get; set; } = "";
        [Required(ErrorMessage = "Bạn phải nhập hạng mục công tác")]
        public string HangMucCongTac { get; set; } = "";
        [Required(ErrorMessage = "Bạn phải nhập tên công tác ")]
        public string TenCongTac { get; set; } = "";
        public string DonVi { get; set; } = "";
        public double KTHH_D { get; set; } = 0;
        public double KTHH_R { get; set; } = 0;
        public double KTHH_C { get; set; } = 0;
        public double KTHH_DienTich { get; set; } = 0;
        public string KTHH_GhiChu { get; set; } = "";
        public double KTHH_SLCauKien { get; set; } = 0;
        public double KTHH_KL1CK { get; set; } = 0;
        public double TTCDT_CDai { get; set; } = 0;
        public double TTCDT_CRong { get; set; } = 0;
        public double TTCDT_CDay { get; set; } = 0;
        public double TTCDT_DienTich { get; set; } = 0;
        public double TTCDT_SLCK { get; set; } = 0;
        public double TTCDT_KL { get; set; } = 0;
        public double KLKP_KL { get; set; } = 0;
        public double KLKP_Sl { get; set; } = 0;
        public double KL1CK_ChuaTruCC { get; set; } = 0;
        public double KLCC1CK { get; set; } = 0;
        public double TKLCK_SauCC { get; set; } = 0;
        public DateTime? CreateAt { get; set; } = DateTime.Now;
        public string? CreateBy { get; set; } = "";
        public int? IsActive { get; set; } = 1;
    }
}
