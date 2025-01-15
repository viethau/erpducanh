using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DucAnhERP.Models;
public partial class QD_BoiThuong_Goc
{
public string Id { get; set; }= Guid.NewGuid().ToString();
[Required(ErrorMessage = "Bạn phải nhập chi nhánh")]
public string CompanyId { get; set; } = "";
[Required(ErrorMessage = "Bạn phải nhập số QĐ bồi thường gốc")]
public string SoQD_BoiThuong_Goc { get; set; } = "";
[Required(ErrorMessage = "Bạn phải nhập ngày quyết định")]
public DateTime Ngay { get; set; } = DateTime.Now;
[Required(ErrorMessage = "Bạn phải nhập thứ tự")]
public int Stt { get; set; } = 0;
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
public partial class QD_BoiThuong_Goc_Log
{
public string Id { get; set; }= Guid.NewGuid().ToString();
public string CompanyId { get; set; } = "";
public string SoQD_BoiThuong_Goc { get; set; } = "";
public DateTime Ngay { get; set; } = DateTime.Now;
public int Stt { get; set; } = 0;
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
public string IdChung { get; set; }= "";
public bool IsValid { get; set; }= false;
}
