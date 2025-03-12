using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("BT_QDTHoiDatDChinhs")]
public class BT_QDTHoiDatDChinh
{
    [Key]
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string CompanyId { get; set; } = "";
    [Required(ErrorMessage = "Số QĐ thu hồi đất gốc!")]
    public string Id_DM_QDThuhoiDatGoc { get; set; }

    [Required(ErrorMessage = "Vui lòng nhập số QĐ thu hồi đất Đ.Chỉnh!")]
    public string SoQDTHDDieuChinh { get; set; }
    public DateTime? NTNDieuChinh { get; set; }

    public DateTime CreateAt { get; set; } = DateTime.UtcNow;
    public string CreateBy { get; set; }
    public int IsActive { get; set; } = 1;
}
