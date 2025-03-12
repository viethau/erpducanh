using DucAnhERP.SeedWork;
using System.ComponentModel.DataAnnotations;

namespace DucAnhERP.ViewModel.ThongKeDien
{
    public class D_CDoCDienModel : PagingParameters
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string CompanyId { get; set; } = "";
        public string CompanyName { get; set; } = "";
        public string Id_DM_TuyenDuong { get; set; }
        public string TuyenDuong { get; set; } = "";
        public string TuCot { get; set; } = "";
        public string DenCot { get; set; } = "";
        public string TuLyTrinh { get; set; } = "";
        public string DenLyTrinh { get; set; } = "";

        public double HienTrangTKD { get; set; } = 0;
        public double CCTKDDDinhMong { get; set; } = 0;
        public double DinhMong { get; set; } = 0;
        public double CDMong { get; set; } = 0;
        public double DinhLotMong { get; set; } = 0;
        public double CDLotMong { get; set; } = 0;
        public double DinhDayDao { get; set; } = 0;

        public double ToaDoX { get; set; }
        public double ToaDoY { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.UtcNow;
        public string CreateBy { get; set; }
        public int IsActive { get; set; } = 1;
    }
}
