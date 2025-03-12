using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DucAnhERP.Models.ThongKeDien
{
    [Table("D_DM_TuyenDuongs")]
    public class D_DM_TuyenDuong
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string CompanyId { get; set; } = "";

        [Required(ErrorMessage = "Vui lòng nhập tuyến đường!")]
        public string TuyenDuong { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập từ cột!")]
        public string TuCot { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập đến cột!")]
        public string DenCot { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập từ lý trình!")]
        public string TuLyTrinh { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập đến lý trình!")]
        public string DenLyTrinh { get; set; }
        public string ToaDoX { get; set; } = "";
        public string ToaDoY { get; set; } = "";

        public DateTime CreateAt { get; set; } = DateTime.UtcNow;
        public string CreateBy { get; set; }
        public int IsActive { get; set; } = 1;
    }
}
