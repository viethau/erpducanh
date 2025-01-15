using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Components.Forms;


namespace DucAnhERP.Models
{
    public partial class ApprovalDeptSetting
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string IdMain { get; set; } = Guid.NewGuid().ToString();
        [Required(ErrorMessage = "Bạn phải nhập chi nhánh")]
        public string CompanyId { get; set; } = "";
        [Required(ErrorMessage = "Bạn phải nhập phòng ban")]
        public string DeptId { get; set; } = "";
        [Required(ErrorMessage = "Bạn phải nhập nghiệp vụ cha")]
        public string ParentMajorId { get; set; } = "";
        [Required(ErrorMessage = "Bạn phải nhập nghiệp vụ")]
        public string MajorId { get; set; } = "";
        [Required(ErrorMessage = "Bạn phải nhập thứ tự phòng ban")]
        public int ApprovalStep { get; set; } = 0;
        public string GroupId { get; set; } = "";
        public int Ordinarily { get; set; } = 0;
        public DateTime CreateAt { get; set; } = DateTime.Now;
        public string CreateBy { get; set; } = "";
        public int IsActive { get; set; } = 0;
        public string ApprovalUserId { get; set; } = "";
        public DateTime DateApproval { get; set; } = DateTime.Now;
        public string DepartmentId { get; set; } = "";
        public int DepartmentOrder { get; set; } = 0;
        public int ApprovalOrder { get; set; } = 0;
        public string ApprovalId { get; set; } = "";
        public string LastApprovalId { get; set; } = "";
        public string IsStatus { get; set; } = "";
    }

    public class ApprovalDeptWrapper
    {
        public EditContext EditContext { get; set; }
        public ApprovalDeptSetting ApprovalRow { get; set; }

        public ApprovalDeptWrapper(ApprovalDeptSetting approvalRow)
        {
            ApprovalRow = approvalRow;
            EditContext = new EditContext(approvalRow);
        }
    }
}
