using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DucAnhERP.Models.ThongKeDien
{
    [Table("D_DM_LoaiKLs")]
    public class D_DM_LoaiKL
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string CompanyId { get; set; } = "";

        [Required(ErrorMessage = "Vui lòng nhập loại khối lượng!")]
        public string LoaiKhoiLuong { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập đơn vị!")]
        public string DonVi { get; set; }

        public DateTime CreateAt { get; set; } = DateTime.UtcNow;
        public string CreateBy { get; set; }
        public int IsActive { get; set; } = 1;
    }
}
