using DucAnhERP.SeedWork;

namespace DucAnhERP.ViewModel
{
    public class TKThepTChongModel :PagingParameters
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public int Flag { get; set; } = 0;
        public string TTKTHHCongHopRanh_LoaiThanhChong { get; set; } = "";
        public string PhanLoaiThanhChong_LoaiThanhChong { get; set; } = "";
        public string? TenCongTac { get; set; } = "";
        public string? VTLayKhoiLuong { get; set; } = "";
        public string? LoaiThep { get; set; } = "";
        public string? LoaiThep_Name { get; set; } = "";
        public string? SoHieu { get; set; } = "";
        public Double? DKCD { get; set; } = 0;
        public int? SoThanh { get; set; } = 0;
        public int? SoCK { get; set; } = 0;
        public int? TongSoThanh { get; set; } = 0;
        public Double? ChieuDai1Thanh { get; set; } = 0;
        public Double? TongChieuDai { get; set; } = 0;
        public Double? TrongLuong { get; set; } = 0;
        public Double? TongTrongLuong { get; set; } = 0;
        public DateTime? CreateAt { get; set; } = DateTime.Now;
        public string? CreateBy { get; set; } = "";
        public int? IsActive { get; set; } = 1;
    }
}
