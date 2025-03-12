using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DucAnhERP.Models.QLNV
{
    [Table("QLNV_CongViecCons")]
    public class QLNV_CongViecCon
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Id_Task { get; set; }
        
        [Required(ErrorMessage = "Vui lòng nhập nội dung công việc!")]
        public string NoiDungCongViec { get; set; }
        public string? FileDinhKem { get; set; }="";
        public DateTime CreateAt { get; set; } = DateTime.UtcNow;
        public string CreateBy { get; set; }
        public int IsActive { get; set; } = 1;
    }
}
