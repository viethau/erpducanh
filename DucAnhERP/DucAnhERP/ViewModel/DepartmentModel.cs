﻿using DucAnhERP.SeedWork;
namespace DucAnhERP.ViewModel;
public partial class DepartmentModel : PagingParameters
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string CompanyId { get; set; }
    public string DeptName { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string GroupId { get; set; }
    public int Ordinarily { get; set; }
    public DateTime CreateAt { get; set; }
    public string CreateBy { get; set; }
    public int IsActive { get; set; }
    public string ApprovalUserId { get; set; }
    public DateTime DateApproval { get; set; }
    public string DepartmentId { get; set; }
    public int DepartmentOrder { get; set; }
    public int ApprovalOrder { get; set; }
    public string ApprovalId { get; set; }
    public string LastApprovalId { get; set; }
    public string IsStatus { get; set; }
}
