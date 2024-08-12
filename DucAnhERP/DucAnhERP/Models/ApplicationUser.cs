using System.ComponentModel.DataAnnotations;

namespace DucAnhERP.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập họ!")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập tên!")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập ngày sinh!")]
        public DateTime Dob { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập số điện thoại!")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập email!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập địa chỉ!")]
        public string Address { get; set; }
        public string ContractId { get; set; }
        public string CompanyId { get; set; }
        public string DeptId { get; set; }
        public int IsFirstLogin { get; set; }
        public DateTime CreateAt { get; set; }
        public string CreateBy { get; set; }
        public DateTime UpdateAt { get; set; }
        public string UpdateBy { get; set; }
        public int IsActive { get; set; }
    }

}
