using DucAnhERP.SeedWork;

namespace DucAnhERP.ViewModel
{
    public class SLCKModel :PagingParameters
    {
        public string ThongTinDuongTruyenDan_HinhThucTruyenDan { get; set; } = "";
        public string ThongTinDuongTruyenDan_HinhThucTruyenDan_Name { get; set; } = "";
        public string ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai { get; set; } = "";
        public string PhanLoaiCTronHopNhua_TenLoaiTruyenDanSauPhanLoai { get; set; } = "";
        public double TTCDSLCauKienDuongTruyenDan_ChieuDai01CauKien { get; set; } = 0;
        public string DonVi { get; set; } = "";
        public double Trai { get; set; } = 0;
        public double Phai { get; set; } = 0;
        public double Tong { get; set; } = 0;
    }
}
