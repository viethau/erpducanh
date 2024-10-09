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
        [StringLength(int.MaxValue, MinimumLength = 3, ErrorMessage = "Bạn phải chọn loại quyền")]
        public string PermissionId { get; set; }
        [Required(ErrorMessage = "Bạn phải chọn thứ")]
        [StringLength(int.MaxValue, MinimumLength = 3, ErrorMessage = "Bạn phải chọn thứ")]
        public string DayinWeek { get; set; }
        public DateTime CreateAt { get; set; }= DateTime.Now;
        public string CreateBy { get; set; } = "test.vp@gmail.com";
        public int IsActive { get; set; } = 1;
    }

    public class MMajorUserPermissionDetail 
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
        [StringLength(int.MaxValue, MinimumLength = 3, ErrorMessage = "Bạn phải chọn loại quyền")]
        public string PermissionId { get; set; }
        public string Id_MMajorUserPermission { get; set; }
        [Required(ErrorMessage = "Bạn phải chọn thứ")]
        [StringLength(int.MaxValue, MinimumLength = 3, ErrorMessage = "Bạn phải chọn thứ")]
        public string DayinWeek { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.Now;
        public string CreateBy { get; set; } = "test.vp@gmail.com";
        public int IsActive { get; set; } = 1;
        
    }

}
