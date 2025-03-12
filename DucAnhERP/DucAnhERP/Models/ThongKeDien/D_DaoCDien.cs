using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DucAnhERP.Models.ThongKeDien
{
    [Table("D_DaoCDiens")]
    public class D_DaoCDien
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string CompanyId { get; set; } = "";

        [Required(ErrorMessage = "Vui lòng chọn tuyến đường!")]
        public string Id_DM_TuyenDuong { get; set; }

        public double HTTKDao { get; set; } = 0;
        public double DayDao { get; set; } = 0;
        public double CSauDao { get; set; } = 0;

        [Required(ErrorMessage = "Vui lòng nhập tỉ lệ mở mái!")]
        public double TiLeMoMai { get; set; } = 0;
        [Required(ErrorMessage = "Vui lòng nhập Số mái trái!")]
        public double SoMaiTrai { get; set; } = 0;
        [Required(ErrorMessage = "Vui lòng nhập Số mái phải!")]
        public double SoMaiPhai { get; set; } = 0;
        [Required(ErrorMessage = "Vui lòng nhập C.Dài đào!")]
        public double CDaiDao { get; set; } = 0;
        [Required(ErrorMessage = "Vui lòng nhập C.Rộng đáy nhỏ!")]
        public double CRongDayNho { get; set; } = 0;
        public double CRongDayLon { get; set; } = 0;
        public double DienTich { get; set; } = 0;
        public double KLDao { get; set; } = 0;

        public DateTime CreateAt { get; set; } = DateTime.UtcNow;
        public string CreateBy { get; set; }
        public int IsActive { get; set; } = 1;
    }
}
