using System.ComponentModel.DataAnnotations;

namespace DucAnhERP.Models
{
    public class ApprovalStaffSetting
    {
        [Key]
        public string Id { get; set; }
        public string CompanyId { get; set; }
        public string DeptId { get; set; }
        public string MajorId { get; set; }
        public string ScreenId { get; set; }
        public string Approver { get; set; }
        public string Content { get; set; }
        public DateTime CreateAt { get; set; }
        public string CreateBy { get; set; }
        public int IsActive { get; set; }
    }
}
