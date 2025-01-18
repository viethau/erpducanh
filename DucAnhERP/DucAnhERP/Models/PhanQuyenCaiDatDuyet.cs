using System.ComponentModel.DataAnnotations;

namespace DucAnhERP.Models
{
    public class PhanQuyenCaiDatDuyet
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [Required(ErrorMessage = "Bạn phải nhập chi nhánh")]
        public string CompanyId { get; set; } = "";
        [Required(ErrorMessage = "Bạn phải nhập nghiệp vụ cha")]
        public string ParentMajorId { get; set; } = "";
        [Required(ErrorMessage = "Bạn phải nhập nghiệp vụ")]
        public string MajorId { get; set; } = "";
        [Required(ErrorMessage = "Bạn phải nhập phòng ban")]
        public string DeptId { get; set; } = "";
        [Required(ErrorMessage = "Bạn phải nhập người dùng")]
        public string UserId { get; set; } = "";
        public string GroupId { get; set; } = "";
        public DateTime CreateAt { get; set; } = DateTime.Now;
        public string CreateBy { get; set; } = "";
        public int IsActive { get; set; } = 0;
    }
    public class PhanQuyenCaiDatDuyet_Log
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string CompanyId { get; set; } = "";
        public string ParentMajorId { get; set; } = "";
        public string MajorId { get; set; } = "";
        public string DeptId { get; set; } = "";
        public string UserId { get; set; } = "";
        public string GroupId { get; set; } = "";
        public DateTime CreateAt { get; set; } = DateTime.Now;
        public string CreateBy { get; set; } = "test.vp@gmail.com";
        public int IsActive { get; set; } = 1;
        public string IdChung { get; set; } = "";
        public bool IsValid { get; set; } = false;
    }
}
