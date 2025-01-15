﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DucAnhERP.Models;
public partial class Department
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    [Required(ErrorMessage = "Bạn phải nhập chi nhánh")]
    public string CompanyId { get; set; } = "";
    [Required(ErrorMessage = "Bạn phải nhập tên phòng ban")]
    public string DeptName { get; set; } = "";
    [Required(ErrorMessage = "Bạn phải nhập điện thoại")]
    public string Phone { get; set; } = "";
    [Required(ErrorMessage = "Bạn phải nhập email")]
    public string Email { get; set; } = "";
    public string GroupId { get; set; } = "";
    public int Ordinarily { get; set; } = 0;
    public DateTime? CreateAt { get; set; } = DateTime.Now;
    public string CreateBy { get; set; } = "";
    public int IsActive { get; set; } = 0;
    public string ApprovalUserId { get; set; } = "";
    public DateTime? DateApproval { get; set; } = DateTime.Now;
    public string DepartmentId { get; set; } = "";
    public int DepartmentOrder { get; set; } = 0;
    public int ApprovalOrder { get; set; } = 0;
    public string ApprovalId { get; set; } = "";
    public string LastApprovalId { get; set; } = "";
    public string IsStatus { get; set; } = "";
}
public partial class Department_Log
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string CompanyId { get; set; } = "";
    public string DeptName { get; set; } = "";
    public string Phone { get; set; } = "";
    public string Email { get; set; } = "";
    public string GroupId { get; set; } = "";
    public int Ordinarily { get; set; } = 0;
    public DateTime? CreateAt { get; set; } = DateTime.Now;
    public string CreateBy { get; set; } = "";
    public int IsActive { get; set; } = 0;
    public string ApprovalUserId { get; set; } = "";
    public DateTime? DateApproval { get; set; } = DateTime.Now;
    public string DepartmentId { get; set; } = "";
    public int DepartmentOrder { get; set; } = 0;
    public int ApprovalOrder { get; set; } = 0;
    public string ApprovalId { get; set; } = "";
    public string LastApprovalId { get; set; } = "";
    public string IsStatus { get; set; } = "";
    public string IdChung { get; set; } = "";
    public bool IsValid { get; set; } = false;
}
