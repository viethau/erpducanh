using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("BT_QDPABTDChinhs")]
public class BT_QDPABTDChinh
{
    [Key]
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string CompanyId { get; set; } = "";
    [Required(ErrorMessage = "Vui lòng chọn số QĐ bồi thường gốc!")]
    public string Id_DM_QDBoiThuongGoc { get; set; }

    [Required(ErrorMessage = "Vui lòng nhập số QĐ điều chỉnh!")]
    public string SoQDBTDieuChinh { get; set; }
    public DateTime? NTNBTDieuChinh { get; set; }

    public DateTime CreateAt { get; set; } = DateTime.UtcNow;
    public string CreateBy { get; set; }
    public int IsActive { get; set; } = 1;
}
