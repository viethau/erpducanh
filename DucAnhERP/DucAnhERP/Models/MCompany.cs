using System.ComponentModel.DataAnnotations;

namespace DucAnhERP.Models
{
    public class MCompany
    {
        [Key]
        public string Id { get; set; }
        public string? ParentId { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập tên công ty!")]
        public string CompanyName { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập loại công ty!")]
        public int CompanyType { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập số điện thoại!")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập email!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập địa chỉ!")]
        public string Address { get; set; }
        public DateTime CreateAt { get; set; }
        public string CreateBy { get; set; }
        public int IsActive { get; set; }
    }
}
