using DucAnhERP.SeedWork;

namespace DucAnhERP.ViewModel
{
    public class PhanLoaiThanhChongModel : PagingParameters
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public int Flag { get; set; } = 0;
        public int IsEdit { get; set; } = 0;
        public string? TTKTHHCongHopRanh_LoaiThanhChong { get; set; } = "";
        public string? TTKTHHCongHopRanh_CauTaoThanhChong { get; set; } = "";
        public string? TTKTHHCongHopRanh_CauTaoThanhChong_Name { get; set; } = "";
        public Double? TTKTHHCongHopRanh_CCaoThanhChong { get; set; } = 0;
        public Double? TTKTHHCongHopRanh_CRongThanhChong { get; set; } = 0;
        public Double? TTKTHHCongHopRanh_CDai { get; set; } = 0;
        public DateTime? CreateAt { get; set; }
        public string? CreateBy { get; set; }
        public int? IsActive { get; set; }

    }
}
