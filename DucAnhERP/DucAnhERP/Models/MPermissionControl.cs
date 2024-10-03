using System.ComponentModel.DataAnnotations;

namespace DucAnhERP.Models
{
    public class MPermissionControl
    {
        [Key]
        public string Id { get; set; }
        [Required(ErrorMessage = "Bạn phải chọn chi nhánh!")]
        public string CompanyId { get; set; }
        [Required(ErrorMessage = "Bạn phải chọn nghiệp vụ!")]
        public string MajorId { get; set; }
        [Required(ErrorMessage = "Bạn phải chọn người dùng!")]
        public string UserId { get; set; }
        public DateTime CreateAt { get; set; }
        public string CreateBy { get; set; }
        public DateTime UpdateAt { get; set; }
        public string UpdateBy { get; set; }
        public int IsActive { get; set; }

    }
}
