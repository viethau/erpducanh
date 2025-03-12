using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DucAnhERP.Models.QLNV
{
    [Table("QLNV_QuanLyNhanViens")]
    public class QLNV_QuanLyNhanVien
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required(ErrorMessage = "Vui lòng chọn nhóm !")]
        public string Id_NhomNhanVien { get; set; }
        [Required(ErrorMessage = "Vui lòng chọn nhân viên!")]
        public string Id_NhanVien { get; set; } 
        public DateTime CreateAt { get; set; } = DateTime.UtcNow;
        public string CreateBy { get; set; }
        public int IsActive { get; set; } = 1;
    }
}
