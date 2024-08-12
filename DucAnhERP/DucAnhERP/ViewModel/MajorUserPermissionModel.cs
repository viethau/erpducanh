using DucAnhERP.Models;
using System.ComponentModel.DataAnnotations;
namespace DucAnhERP.ViewModel
{
    public class MajorUserPermissionModel : MMajorUserPermission
    {
        [Required(ErrorMessage ="Bạn phải xác nhận cài đặt phân quyền cho người dùng đã chọn!")]
        public bool? IsChecked { get; set; }
    }
}
