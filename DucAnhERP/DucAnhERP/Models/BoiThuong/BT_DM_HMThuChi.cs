using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("BT_DM_HMChis")]
public class BT_DM_HMChi
{
    [Key]
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string CompanyId { get; set; } = "";
    [Required]
    [StringLength(255)]
    public string HangMucChi { get; set; }
    public DateTime CreateAt { get; set; } = DateTime.UtcNow;
    public string CreateBy { get; set; }
    public int IsActive { get; set; } = 1;
}
