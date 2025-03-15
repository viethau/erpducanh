using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DucAnhERP.Models.QLNV
{
    [Table("QLNV_NhanViens")]
    public class QLNV_NhanVien
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required(ErrorMessage = "Vui lòng chọn tên nhân viên!")]
        public string TenNhanVien { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập tài khoản!")]
        [EmailAddress(ErrorMessage = "Tài khoản phải là một địa chỉ email hợp lệ!")]
        public string TaiKhoan { get; set; }

        public string GroupId { get; set; } = "";
        public DateTime CreateAt { get; set; } = DateTime.UtcNow;
        public string CreateBy { get; set; }
        public int IsActive { get; set; } = 1;
    }
}
