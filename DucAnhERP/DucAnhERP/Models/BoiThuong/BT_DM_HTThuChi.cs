using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("BT_DM_HTThuChi")]
public class BT_DM_HTThuChi
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    [StringLength(255)]
    public string HinhThucthuChi { get; set; }

    [Required]
    public DateTime CreateAt { get; set; } = DateTime.UtcNow;

    [Required]
    [StringLength(255)]
    public string CreateBy { get; set; }

    [Required]
    public int IsActive { get; set; } = 1;
}
