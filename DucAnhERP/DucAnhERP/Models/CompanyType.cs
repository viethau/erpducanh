using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DucAnhERP.Models;
public partial class CompanyType
{
public string Id { get; set; }= Guid.NewGuid().ToString();
[Required(ErrorMessage = "Bạn phải nhập tên loại chi nhánh")]
public string TenLoaiChiNhanh { get; set; } = "";
[Required(ErrorMessage = "Bạn phải nhập groupId")]
public string GroupId { get; set; } = "";
[Required(ErrorMessage = "Bạn phải nhập thứ tự")]
public int Ordinarily { get; set; } = 0;
public DateTime CreateAt { get; set; } = DateTime.Now;
public string CreateBy { get; set; } = "";
public int IsActive { get; set; } = 0;
[Required(ErrorMessage = "Bạn phải nhập người duyệt")]
public string ApprovalUserId { get; set; } = "";
public DateTime DateApproval { get; set; } = DateTime.Now;
[Required(ErrorMessage = "Bạn phải nhập phòng ban duyệt")]
public string DepartmentId { get; set; } = "";
[Required(ErrorMessage = "Bạn phải nhập thứ tự phòng ban")]
public int DepartmentOrder { get; set; } = 0;
public int ApprovalOrder { get; set; } = 0;
[Required(ErrorMessage = "Bạn phải nhập iD duyệt")]
public string ApprovalId { get; set; } = "";
[Required(ErrorMessage = "Bạn phải nhập id duyệt cuối")]
public string LastApprovalId { get; set; } = "";
[Required(ErrorMessage = "Bạn phải nhập trạng thái")]
public string IsStatus { get; set; } = "";
}
public partial class CompanyType_Log
{
public string Id { get; set; }= Guid.NewGuid().ToString();
public string TenLoaiChiNhanh { get; set; } = "";
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
}
