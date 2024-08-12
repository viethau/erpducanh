using System.ComponentModel.DataAnnotations;

namespace DucAnhERP.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Bạn phải nhập họ!")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập tên!")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập email!")]
        [EmailAddress(ErrorMessage = "Địa chỉ email không hợp lệ")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập ngày tháng năm sinh!")]
        [DataType(DataType.Date, ErrorMessage = "Ngày không hợp lệ")]
        [Range(typeof(DateTime), "1/1/1900", "1/1/2024", ErrorMessage = "Ngày không hợp lệ")]
        public DateTime? Dob { get; set; } = DateTime.UtcNow;

        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Số điện thoại không hợp lệ")]
        [Required(ErrorMessage = "Bạn phải nhập số điện thoại!")]
        public string PhoneNumber { get; set; }

        [Display(Name = "CompanyName")]
        [Required(ErrorMessage = "Bạn phải nhập tên doanh nghiệp!")]
        public string CompanyName { get; set; }

        [Display(Name = "Address")]
        [Required(ErrorMessage = "Bạn phải nhập địa chỉ!")]
        public string Address { get; set; }

        [Display(Name = "TaxNo")]
        [Required(ErrorMessage = "Bạn phải nhập mã số thuế!")]
        public string Tax { get; set; }
    }
}
