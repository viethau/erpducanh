using System.ComponentModel.DataAnnotations;

namespace DucAnhERP.Models
{
    public class MMajorUserPermission
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [Required(ErrorMessage = "Bạn phải chọn chi nhánh!")]
        public string CompanyId { get; set; }
        [Required(ErrorMessage = "Bạn phải chọn nghiệp vụ!")]
        public string MajorId { get; set; }
        [Required(ErrorMessage = "Bạn phải chọn người dùng!")]
        public string UserId { get; set; }
        [Required(ErrorMessage = "Bạn phải chọn loại quyền")]
        public string PermissionId { get; set; }
        public DateTime CreateAt { get; set; }= DateTime.Now;
        public string CreateBy { get; set; } = "test.vp@gmail.com";
        public int IsActive { get; set; } = 1;
    }
}
