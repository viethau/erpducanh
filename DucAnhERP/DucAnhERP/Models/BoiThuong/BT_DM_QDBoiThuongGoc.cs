using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DucAnhERP.Models.BoiThuong
{
    [Table("BT_DM_QDBoiThuongGocs")]
    public class BT_DM_QDBoiThuongGoc
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string CompanyId { get; set; } = "";

        [Required(ErrorMessage = "Số QĐ bồi thường gốc!")]
        [StringLength(255)]
        public string SoQDBTGoc { get; set; }
        //[Required(ErrorMessage = "Bạn phải nhập ngày ")]
        public DateTime NTNPABTGoc { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.UtcNow;
        public string CreateBy { get; set; } = "";
        public int IsActive { get; set; } = 1;
    }
}
