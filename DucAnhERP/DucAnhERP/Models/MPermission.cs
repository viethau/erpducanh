using System.ComponentModel.DataAnnotations;

namespace DucAnhERP.Models
{
    public class MPermission
    {
        [Key]
        public string Id { get; set; }
        public string CompanyId { get; set; }
        public string MajorId { get; set; }
        public string ScreenId { get; set; }
        public int PermissionType { get; set; }
        public string PermissionName { get; set; }
        public DateTime CreateAt { get; set; }
        public string CreateBy { get; set; }
        public int IsActive { get; set; }
    }
}
