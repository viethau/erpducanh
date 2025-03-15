using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DucAnhERP.Models.QLNV
{
    [Table("QLNV_CongViecs")]
    public class QLNV_CongViec
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Id_Task { get; set; }
        public string Id_NguoiGiaoViec { get; set; }
        public string Id_NguoiThucHien { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập nhóm công việc!")]
        public string NhomCongViec { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập ngày bắt đầu!")]
        public DateTime NgayBatDau { get; set; }= DateTime.UtcNow;

        public DateTime? NgayKetThuc { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập mức độ ưu tiên!")]
        public string MucDoUuTien { get; set; }
        public string? TuDanhGia { get; set; } = "";

        [Required(ErrorMessage = "Vui lòng nhập tiến độ!")]
        [Range(0, 100, ErrorMessage = "Tiến độ phải nằm trong khoảng từ 0 đến 100!")]
        public double TienDo { get; set; } = 0;
        [Required(ErrorMessage = "Vui lòng nhập lặp lại!")]
        public string LapLai { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập nôi dung công việc!")]
        public string NoiDungCongViec { get; set; }
        public string? FileDinhKem { get; set; }="";

        public string GroupId { get; set; } = "";
        public DateTime CreateAt { get; set; } = DateTime.UtcNow;
        public string CreateBy { get; set; }
        public int IsActive { get; set; } = 1;
    }
}
