using System.ComponentModel.DataAnnotations;

namespace DucAnhERP.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Bạn phải nhập email!")]
        [EmailAddress]
        public string Email { get; set; } = "qminh97ictu@gmail.com";

        [Required(ErrorMessage = "Bạn phải nhập mật khẩu!")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = "123456Aa@";

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; } = true;
    }
}
