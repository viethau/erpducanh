using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DucAnhERP.Models.BoiThuong
{
    [Table("BT_DM_QDCVChiPhiHoiDongs")]
    public class BT_DM_QDCVChiPhiHoiDong
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string CompanyId { get; set; } = "";

        [Required(ErrorMessage = "Số QĐ/CV chi phí hội đồng!")]
        [StringLength(255)]
        public string SoQDCVChiPhiHoiDong { get; set; }
        //[Required(ErrorMessage = "Bạn phải nhập ngày ")]
        public DateTime? NTN { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.UtcNow;
        public string CreateBy { get; set; } = "";
        public int IsActive { get; set; } = 1;
    }
}
