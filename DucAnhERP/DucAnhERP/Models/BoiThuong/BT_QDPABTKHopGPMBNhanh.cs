using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("BT_QDPABTKHopGPMBNhanhs")]
public class BT_QDPABTKHopGPMBNhanh
{
    [Key]
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string CompanyId { get; set; } = "";
    [Required(ErrorMessage = "Vui lòng chọn số quyết định bồi thường gốc!")]
    public string Id_DM_QDBoiThuongGoc { get; set; }
    [Required(ErrorMessage = "Vui lòng chọn QĐ thưởng GPMB nhanh gốc!")]
    public string Id_DM_QDTGPMBNhanhGoc { get; set; }
    public DateTime CreateAt { get; set; } = DateTime.UtcNow;
    public string CreateBy { get; set; }
    public int IsActive { get; set; } = 1;
}
