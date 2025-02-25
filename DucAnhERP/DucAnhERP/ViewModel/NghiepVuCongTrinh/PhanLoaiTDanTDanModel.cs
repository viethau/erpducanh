using DucAnhERP.SeedWork;

namespace DucAnhERP.ViewModel.NghiepVuCongTrinh
{
    public class PhanLoaiTDanTDanModel : PagingParameters 
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public int Flag { get; set; } = 0;
        public int IsEdit { get; set; } = 0;
        public string? TTTDCongHoRanh_TenLoaiTamDanTieuChuan { get; set; } = "";
        public double? ThongTinLyTrinhTruyenDan_TuLyTrinh { get; set; } = 0;
        public double? ThongTinLyTrinhTruyenDan_DenLyTrinh { get; set; } = 0;
        public string? ThongTinDuongTruyenDan_HinhThucTruyenDan { get; set; } = "";
        public string? ThongTinDuongTruyenDan_HinhThucTruyenDan_Name { get; set; } = "";
        public string? ThongTinDuongTruyenDan_LoaiTruyenDan { get; set; } = "";
        public string? ThongTinDuongTruyenDan_LoaiTruyenDan_Name { get; set; } = "";
        public string TTTDCongHoRanh_CauTaoTamDanTruyenDanTamDanTieuChuan { get; set; } = "";
        public string TTTDCongHoRanh_CauTaoTamDanTruyenDanTamDanTieuChuan_Name { get; set; } = "";
        public double? TTTDCongHoRanh_CDai { get; set; } = 0;
        public double? TTTDCongHoRanh_CRong { get; set; } = 0;
        public double? TTTDCongHoRanh_CCao { get; set; } = 0;
        public DateTime? CreateAt { get; set; } = DateTime.Now;
        public string? CreateBy { get; set; } = "";
        public int? IsActive { get; set; } = 1;
    }
}
