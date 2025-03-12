using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DucAnhERP.Models.BoiThuong
{
    [Table("BT_CTietPAnBThuongs")]
    public class BT_CTietPAnBThuong
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string CompanyId { get; set; } = "";
        [Required(ErrorMessage = "Vui lòng chọn số QĐ bồi thường gốc!")]
        public string Id_DM_QDBoiThuongGoc { get; set; }
        public string Id_QDPABTDChinh { get; set; }
        public string Id_QDPABTKHopGPMBNhanh { get; set; }
        public string Id_QDGPMBNhanhDChinh { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập Họ và tên chủ hộ")]
        public string HoVaTenChuHo { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập CCCD")]
        public int CCCD { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn Tỉnh")]
        public string Tinh { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập Huyện")]
        public string Huyen { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập Họ và tên Xã/phường")]
        public string XaPhuong { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập Khu/thôn")]
        public string KhuThon { get; set; }

        public float BTGPMB { get; set; }
        public float ThuongGPMBNhanh { get; set; }
        public float TongGiaTri { get; set; }
        public float TongDTThuHoi { get; set; }
        public float LUC { get; set; }
        public float LUK { get; set; }
        public float BHK { get; set; }
        public float NTS { get; set; }
        public float RSX { get; set; }
        public float ONT { get; set; }
        public float CLN { get; set; }
        public float CLNV { get; set; }
        public float BCS { get; set; }
        public float DTL { get; set; }
        public float DGT { get; set; }
        public float DCS { get; set; }
        public float NTD { get; set; }
        public float MNC { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.UtcNow;
        public string CreateBy { get; set; }
        public int IsActive { get; set; } = 1;
    }
}

