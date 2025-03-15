using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DucAnhERP.Models.QLNV
{
    [Table("QLNV_DanhGias")]
    public class QLNV_DanhGia
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Id_CongViec { get; set; }
        [Required(ErrorMessage = "Vui lòng đánh giá!")]
        [Range(0, 10, ErrorMessage = "Tiến độ phải nằm trong khoảng từ 0 đến 10!")]
        public double DanhGia { get; set; } = 0;
        public string GhiChu { get; set; }

        public string GroupId { get; set; } = "";
        public DateTime CreateAt { get; set; } = DateTime.UtcNow;
        public string CreateBy { get; set; }
        public int IsActive { get; set; } = 1;
    }
}
