using DucAnhERP.Models;
using System.ComponentModel.DataAnnotations;

namespace DucAnhERP.ViewModel
{
    public class PermissionModel : MPermission
    {
        public string ScreenName { get; set; }

        [Required(ErrorMessage = "Bạn phải chọn ít nhất 1 quyền!")]
        public bool IsChecked { get; set; }
    }
}
