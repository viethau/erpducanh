using System.ComponentModel.DataAnnotations;

namespace DucAnhERP.Models
{
    public class MPermissionControl
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [Required(ErrorMessage = "Bạn phải chọn chi nhánh!")]
        public string CompanyId { get; set; }
        [Required(ErrorMessage = "Bạn phải chọn nghiệp vụ!")]
        [StringLength(255, MinimumLength = 1, ErrorMessage = "Bạn phải chọn nghiệp vụ!")]
        public string MajorId { get; set; }
        [Required(ErrorMessage = "Bạn phải chọn người dùng!")]
        public string UserId { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.Now;
        public string CreateBy { get; set; } = "test.vp@gmail.com";
        public int IsActive { get; set; } = 1;


    }
}
