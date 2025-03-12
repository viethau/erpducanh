using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DucAnhERP.Models.ThongKeDien
{
    [Table("D_TTLDienCDiens")]
    public class D_TTLDienCDien
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string CompanyId { get; set; } = "";

        [Required(ErrorMessage = "Vui lòng nhập tuyến đường!")]
        public string Id_DM_TuyenDuong { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập loại KL!")]
        public string Id_DM_TuDien { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập loại cột tủ!")]
        public string LoaiCotTu { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập loại KL!")]
        public string Id_DM_BuLong { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập loại bu lông!")]
        public string LoaiBulong { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập loại KL!")]
        public string Id_DM_TiepDia { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tiếp địa cột!")]
        public string TiepDiaCot { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập loại KL!")]
        public string Id_DM_BongDen { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập loại bóng đèn!")]
        public string LoaiBongDen { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập SL bóng đèn (bộ)")]
        [Range(1, int.MaxValue, ErrorMessage = "SL bóng đèn phải lớn hơn 0")]
        public int SLBongDen { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập loại KL!")]
        public string Id_DM_DayDen { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập loại dây điện!")]
        public string LoaiDayDien { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập chiều dài đáy")]
        [Range(0.1, double.MaxValue, ErrorMessage = "Chiều dài đáy phải lớn hơn 0")]
        public double CDaiDay { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tọa độ X")]
        [Range(double.Epsilon, double.MaxValue, ErrorMessage = "Tọa độ X phải khác 0")]
        public Double ToaDoX { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập tọa độ Y")]
        [Range(double.Epsilon, double.MaxValue, ErrorMessage = "Tọa độ Y phải khác 0")]
        public Double ToaDoY { get; set; }

        public DateTime CreateAt { get; set; } = DateTime.UtcNow;
        public string CreateBy { get; set; }
        public int IsActive { get; set; } = 1;
    }
}
