using System.ComponentModel.DataAnnotations;

namespace DucAnhERP.Models
{
    public class MMajor
    {
        [Key]
        public string Id { get; set; }
        public string? ParentId { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập tên nghiệp vụ!")]
        public string MajorName { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập thứ tự sắp xếp!")]
        public int Order { get; set; }
        public string? Table { get; set; }
        public DateTime CreateAt { get; set; }
        public string CreateBy { get; set; }
        public int IsActive { get; set; }
    }
}
