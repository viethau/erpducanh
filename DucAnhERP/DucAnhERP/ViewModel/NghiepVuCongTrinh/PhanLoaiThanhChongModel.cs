using DucAnhERP.SeedWork;

namespace DucAnhERP.ViewModel.NghiepVuCongTrinh
{
    public class PhanLoaiThanhChongModel : PagingParameters
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public int Flag { get; set; } = 0;
        public int IsEdit { get; set; } = 0;
        public string? TTKTHHCongHopRanh_LoaiThanhChong { get; set; } = "";
        public string? TTKTHHCongHopRanh_CauTaoThanhChong { get; set; } = "";
        public string? TTKTHHCongHopRanh_CauTaoThanhChong_Name { get; set; } = "";
        public double? TTKTHHCongHopRanh_CCaoThanhChong { get; set; } = 0;
        public double? TTKTHHCongHopRanh_CRongThanhChong { get; set; } = 0;
        public double? TTKTHHCongHopRanh_CDai { get; set; } = 0;
        public DateTime? CreateAt { get; set; }
        public string? CreateBy { get; set; }
        public int? IsActive { get; set; }

    }
}
