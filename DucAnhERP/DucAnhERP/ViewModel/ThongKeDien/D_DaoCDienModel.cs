using DucAnhERP.SeedWork;
using System.ComponentModel.DataAnnotations;

namespace DucAnhERP.ViewModel.ThongKeDien
{
    public class D_DaoCDienModel : PagingParameters
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

        public double HTTKDao { get; set; } = 0;
        public double DayDao { get; set; } = 0;
        public double CSauDao { get; set; } = 0;
        public double TiLeMoMai { get; set; } = 0;
        public double SoMaiTrai { get; set; } = 0;
        public double SoMaiPhai { get; set; } = 0;
        public double CDaiDao { get; set; } = 0;
        public double CRongDayNho { get; set; } = 0;
        public double CRongDayLon { get; set; } = 0;
        public double DienTich { get; set; } = 0;
        public double KLDao { get; set; } = 0;

        public double ToaDoX { get; set; }
        public double ToaDoY { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.UtcNow;
        public string CreateBy { get; set; }
        public int IsActive { get; set; } = 1;
    }
}
