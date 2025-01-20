using DucAnhERP.SeedWork;
using System.ComponentModel.DataAnnotations;

namespace DucAnhERP.ViewModel
{
    public class PhanQuyenCaiDatDuyetModel : PagingParameters
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string CompanyId { get; set; } = "";
        public string CompanyName { get; set; } = "";
        public string ParentMajorId { get; set; } = "";
        public string ParentMajorName { get; set; } = "";
        public string MajorId { get; set; } = "";
        public string MajorName { get; set; } = "";
        public string DeptId { get; set; } = "";
        public string DeptName { get; set; } = "";
        public string UserId { get; set; } = "";
        public string UserName { get; set; } = "";
        public string IdMain { get; set; } = "";
        public DateTime CreateAt { get; set; } = DateTime.Now;
        public string CreateBy { get; set; } = "test.vp@gmail.com";
        public int IsActive { get; set; } = 1;
        public string IdChung { get; set; } = "";
        public bool IsValid { get; set; } = false;
    }
}
