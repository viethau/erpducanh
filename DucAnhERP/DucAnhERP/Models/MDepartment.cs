using System.ComponentModel.DataAnnotations;

namespace DucAnhERP.Models
{
    public class MDepartment
    {
        [Key]
        public string Id { get; set; }
        public string CompanyId { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập tên phòng ban!")]
        public string DeptName { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập số điện thoại!")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập email!")]
        public string Email { get; set; }
        public DateTime CreateAt { get; set; }
        public string CreateBy { get; set; }
        public int IsActive { get; set; }
    }
}
