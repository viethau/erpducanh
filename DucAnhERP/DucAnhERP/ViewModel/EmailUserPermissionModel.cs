using System.ComponentModel.DataAnnotations;

namespace DucAnhERP.ViewModel
{
    public partial class EmailUserPermissionModel
    {
        public string ParentMajorId { get; set; } = "";
        public string MajorId { get; set; } = "";
        public string Mail { get; set; } = "";
        public string UserId { get; set; } = "";
    }

}
