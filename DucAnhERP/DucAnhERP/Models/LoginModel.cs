using System.ComponentModel.DataAnnotations;

namespace DucAnhERP.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Bạn phải nhập email!")]
        [EmailAddress]
        public string Email { get; set; } = "";

        [Required(ErrorMessage = "Bạn phải nhập mật khẩu!")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = "";

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}
