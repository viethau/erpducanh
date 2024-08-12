using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Components.Forms;


namespace DucAnhERP.Models
{
    public class ApprovalDeptSetting
    {
        [Key]
        public string Id { get; set; }
        [Required(ErrorMessage = "Bạn phải chọn chi nhánh!")]
        public string CompanyId { get; set; }
        [Required(ErrorMessage = "Bạn phải chọn phòng ban!")]
        public string DeptId { get; set; }
        [Required(ErrorMessage = "Bạn phải chọn nghiệp vụ!")]
        public string MajorId { get; set; }
        [Required(ErrorMessage = "Bạn phải chọn phân loại nghiệp vụ!")]
        public string ScreenId { get; set; }
        [Required(ErrorMessage = "Bạn phải chọn thứ tự phê duyệt!")]
        public int ApprovalStep { get; set; }
        public DateTime CreateAt { get; set; }
        public string CreateBy { get; set; }
        public int IsActive { get; set; }
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
