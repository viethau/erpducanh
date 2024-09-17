using DucAnhERP.Components.Pages.Common;
using DucAnhERP.SeedWork;

namespace DucAnhERP.ViewModel
{
    public class PhanLoaiDeCongModel : PagingParameters
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public int Flag { get; set; } = 0;
        public string? ThongTinDeCong_TenLoaiDeCong { get; set; } = "";
        public string? ThongTinDuongTruyenDan_LoaiTruyenDan { get; set; } = "";
        public string? ThongTinDuongTruyenDan_LoaiTruyenDan_Name { get; set; } = "";
        public string? ThongTinDeCong_CauTaoDeCong { get; set; } = "";
        public string? ThongTinDeCong_CauTaoDeCong_Name { get; set; } = "";
        public Double? ThongTinDeCong_D { get; set; } = 0;
        public Double? ThongTinDeCong_R { get; set; } = 0;
        public Double? ThongTinDeCong_C { get; set; } = 0;
        public DateTime? CreateAt { get; set; } = DateTime.Now;
        public string? CreateBy { get; set; } = "";
        public int? IsActive { get; set; } = 1;
    }
}
