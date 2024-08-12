using Microsoft.AspNetCore.Components.Forms;
using System.ComponentModel.DataAnnotations;

namespace DucAnhERP.Models
{
    public class ApprovalStepSetting
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
        [Required(ErrorMessage = "Bạn phải chọn loại thao tác!")]
        public int OperationType { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập nội dung phê duyệt!")]
        public string Content { get; set; }
        public int ApprovalStep { get; set; }
        public DateTime CreateAt { get; set; }
        public string CreateBy { get; set; }
        public int IsActive { get; set; }
    }

    public class ApprovalStepWrapper
    {
        public EditContext EditContext { get; set; }
        public ApprovalStepSetting ApprovalRow { get; set; }
        public bool isDuplicate { get; set; } = true;

        public ApprovalStepWrapper(ApprovalStepSetting approvalRow)
        {
            ApprovalRow = approvalRow;
            EditContext = new EditContext(approvalRow);
        }
    }
}
