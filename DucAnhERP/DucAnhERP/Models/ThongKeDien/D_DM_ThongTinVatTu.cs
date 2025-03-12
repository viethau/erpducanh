using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DucAnhERP.Models.ThongKeDien
{
    [Table("D_DM_ThongTinVatTus")]
    public class D_DM_ThongTinVatTu
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string CompanyId { get; set; } = "";

        [Required(ErrorMessage = "Vui lòng nhập tên loại vật tư!")]
        public string TenLoaiVatTu { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập từ cột!")]
        public string DonVi { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập thông tin loại vật tư điện!")]
        public string ThongTinLoaiVatTuDien { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập hình ảnh!")]
        public string HinhAnh { get; set; }

        public DateTime CreateAt { get; set; } = DateTime.UtcNow;
        public string CreateBy { get; set; }
        public int IsActive { get; set; } = 1;
    }
}
