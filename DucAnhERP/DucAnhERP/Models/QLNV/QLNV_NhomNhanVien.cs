using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DucAnhERP.Models.QLNV
{
    [Table("QLNV_NhomNhanViens")]
    public class QLNV_NhomNhanVien
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required(ErrorMessage = "Vui lòng chọn người quản lý!")]
        public string Id_QuanLy { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập tên nhóm!")]
        public string TenNhom { get; set; } 
        public DateTime CreateAt { get; set; } = DateTime.UtcNow;
        public string CreateBy { get; set; }
        public int IsActive { get; set; } = 1;
    }
}
