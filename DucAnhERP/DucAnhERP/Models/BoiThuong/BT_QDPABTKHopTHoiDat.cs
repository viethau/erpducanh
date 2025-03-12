using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("BT_QDPABTKHopTHoiDats")]
public class BT_QDPABTKHopTHoiDat
{
    [Key]
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string CompanyId { get; set; } = "";
    [Required(ErrorMessage = "Vui lòng chọn quyết định thu hồi đất gốc!")]
    public string Id_DM_QDThuhoiDatGoc { get; set; }
    [Required(ErrorMessage = "Vui lòng chọn quyết định PABT gốc")]
    public string Id_DM_QDCVChiPhiHoiDong { get; set; }
    public DateTime CreateAt { get; set; } = DateTime.UtcNow;
    public string CreateBy { get; set; }
    public int IsActive { get; set; } = 1;
}
