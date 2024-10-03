using System.ComponentModel.DataAnnotations;

namespace DucAnhERP.Models
{
    public class MPermission
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [Required(ErrorMessage = "Bạn phải nhập mã nghiệp vụ")]
        public string MajorId { get; set; } = "";
        [Required(ErrorMessage = "Bạn phải nhập loại quyền")]
        public int PermissionType { get; set; } = 0;
        [Required(ErrorMessage = "Bạn phải nhập tên quyền")]
        public string PermissionName { get; set; } = "";
        public DateTime CreateAt { get; set; } = DateTime.Now;
        public string CreateBy { get; set; } = "test.vp@gmail.com";
        public int IsActive { get; set; } = 1;
        
    }
}
