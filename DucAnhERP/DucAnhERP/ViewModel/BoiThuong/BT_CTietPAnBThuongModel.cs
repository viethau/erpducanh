using DucAnhERP.SeedWork;
using System.ComponentModel.DataAnnotations;

namespace DucAnhERP.ViewModel.BoiThuong
{
    public class BT_CTietPAnBThuongModel : PagingParameters
    {
        
            [Key]
            public string Id { get; set; }
            public string CompanyId { get; set; } = "";
            public string CompanyName { get; set; } = "";
            public string Id_DM_QDBoiThuongGoc { get; set; }
            public DateTime? NTNQDBoiThuongGoc { get; set; }
            public string Id_QDPABTDChinh { get; set; }
            public DateTime? NTNQDPABTDChinh { get; set; }
            public string Id_QDPABTKHopGPMBNhanh { get; set; }
            public DateTime? NTNQDPABTKHopGPMBNhanh { get; set; }
            public string Id_QDGPMBNhanhDChinh { get; set; }
            public DateTime? NTNQDGPMBNhanhDChinh { get; set; }
            public string HoVaTenChuHo { get; set; }
            public string Tinh { get; set; }
            public string Huyen { get; set; }
            public string XaPhuong { get; set; }
            public string KhuThon { get; set; }
            public int CCCD { get; set; }
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
