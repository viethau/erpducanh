using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DucAnhERP.Models.ThongKeDien
{
    [Table("D_CDoCDiens")]
    public class D_CDoCDien
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string CompanyId { get; set; } = "";

        [Required(ErrorMessage = "Vui lòng nhập H.Trạng trước khi đào!")]
        public string HienTrangTKD { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập C.cao trước khi đào đến đỉnh móng!")]
        public int CCTKDDDingMong { get; set; }
        public double DinhMong { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập C.Dày móng!")]
        public double CDMong { get; set; }
        public double DinhLotMong { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập C.Dầy lót móng!")]
        public double CDLotMong { get; set; }
        public double DinhDayDao { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tọa độ X")]
        public string ToaDoX { get; set; } = "";
        [Required(ErrorMessage = "Vui lòng nhập tọa độ Y")]
        public string ToaDoY { get; set; } = "";

        public DateTime CreateAt { get; set; } = DateTime.UtcNow;
        public string CreateBy { get; set; }
        public int IsActive { get; set; } = 1;
    }
}
