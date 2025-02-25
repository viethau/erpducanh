using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("BT_DM_HMThuChi")]
public class BT_DM_HMThuChi
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    [StringLength(255)]
    public string HangMucChi { get; set; }

    [Required]
    public DateTime CreateAt { get; set; } = DateTime.UtcNow;

    [Required]
    [StringLength(255)]
    public string CreateBy { get; set; }

    [Required]
    public int IsActive { get; set; } = 1;
}
