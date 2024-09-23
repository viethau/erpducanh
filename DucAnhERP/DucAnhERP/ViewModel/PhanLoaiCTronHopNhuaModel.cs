using DucAnhERP.SeedWork;

namespace DucAnhERP.ViewModel
{
    public class PhanLoaiCTronHopNhuaModel : PagingParameters
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public int Flag { get; set; } = 0;
        public string? ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai { get; set; } = "";
        public string? ThongTinDuongTruyenDan_HinhThucTruyenDan { get; set; } = "";
        public string? ThongTinDuongTruyenDan_HinhThucTruyenDan_Name { get; set; } = "";
        public string? ThongTinDuongTruyenDan_LoaiTruyenDan { get; set; } = "";
        public string? ThongTinDuongTruyenDan_LoaiTruyenDan_Name { get; set; } = "";
        public Double? TTCDSLCauKienDuongTruyenDan_ChieuDai01CauKien { get; set; } = 0;
        public Double? ThongTinCauTaoCongTron_CDayPhuBi { get; set; } = 0;
        public string? TTKTHHCongHopRanh_CauTaoTuong { get; set; } = "";
        public string? TTKTHHCongHopRanh_CauTaoTuong_Name { get; set; } = "";
        public string? TTKTHHCongHopRanh_CauTaoMuMo { get; set; } = "";
        public string? TTKTHHCongHopRanh_CauTaoMuMo_Name { get; set; } = "";
        public string? TTKTHHCongHopRanh_ChatMatTrong { get; set; } = "";
        public string? TTKTHHCongHopRanh_ChatMatTrong_Name { get; set; } = "";
        public string? TTKTHHCongHopRanh_ChatMatNgoai { get; set; } = "";
        public string? TTKTHHCongHopRanh_ChatMatNgoai_Name { get; set; } = "";
        public Double? TTKTHHCongHopRanh_CCaoDe { get; set; } = 0;
        public Double? TTKTHHCongHopRanh_CRongDe { get; set; } = 0;
        public Double? TTKTHHCongHopRanh_CDayTuong01Ben { get; set; } = 0;
        public Double? TTKTHHCongHopRanh_SoLuongTuong { get; set; } = 0;
        public Double? TTKTHHCongHopRanh_CRongLongSuDung { get; set; } = 0;
        public Double? TTKTHHCongHopRanh_CCaoTuongGop { get; set; } = 0;
        public Double? TTKTHHCongHopRanh_CCaoMuMoThotDuoi { get; set; } = 0;
        public Double? TTKTHHCongHopRanh_CRongMuMoDuoi { get; set; } = 0;
        public Double? TTKTHHCongHopRanh_CCaoMuMoThotTren { get; set; } = 0;
        public Double? TTKTHHCongHopRanh_CRongMuMoTren { get; set; } = 0;
        public Double? TTKTHHCongHopRanh_CCaoChatMatTrong { get; set; } = 0;
        public Double? TTKTHHCongHopRanh_CCaoChatMatNgoai { get; set; } = 0;
        public Double? ThongTinKichThuocHinhHocOngNhua_CDayPhuBi { get; set; } = 0;
        public DateTime? CreateAt { get; set; } = DateTime.Now;
        public string? CreateBy { get; set; } = "";
        public int? IsActive { get; set; } = 1;
    }
}
