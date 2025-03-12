using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("BT_QDGPMBNhanhDChinhs")]
public class BT_QDGPMBNhanhDChinh
{
    [Key]
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string CompanyId { get; set; } = "";
    [Required(ErrorMessage = "Số QĐ thưởng GPMB nhanh gốc!")]
    public string Id_DM_QDTGPMBNhanhGoc { get; set; }

    [Required(ErrorMessage = "Vui lòng nhập số QĐ thưởng GPMB nhanh Đ.Chỉnh!")]
    public string SoQDThuongGPMBNhanhDC { get; set; }
    public DateTime? NTNDieuChinh { get; set; }

    public DateTime CreateAt { get; set; } = DateTime.UtcNow;
    public string CreateBy { get; set; }
    public int IsActive { get; set; } = 1;
}
