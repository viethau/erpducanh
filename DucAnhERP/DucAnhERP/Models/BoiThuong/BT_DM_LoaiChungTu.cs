using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("BT_DM_LoaiChungTus")]
public class BT_DM_LoaiChungTu
{
    [Key]
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string CompanyId { get; set; } = "";

    [Required(ErrorMessage = "Bạn phải nhập loại chứng từ!")]
    [StringLength(255)]
    public string LoaiChungTu { get; set; }
    public DateTime CreateAt { get; set; } = DateTime.UtcNow;
    public string CreateBy { get; set; } = "";
    public int IsActive { get; set; } = 1;
}
