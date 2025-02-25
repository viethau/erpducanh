using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("BT_DM_LoaiChungTu")]
public class BT_DM_LoaiChungTu
{
    [Key]
    public string Id { get; set; } = Guid.NewGuid().ToString();

    [Required(ErrorMessage = "Bạn phải nhập loại chứng từ!")]
    [StringLength(255)]
    public string LoaiChungTu { get; set; }

    [Required]
    public DateTime CreateAt { get; set; } = DateTime.UtcNow;

    [Required]
    [StringLength(255)]
    public string CreateBy { get; set; } = "";

    [Required]
    public int IsActive { get; set; } = 1;
}
