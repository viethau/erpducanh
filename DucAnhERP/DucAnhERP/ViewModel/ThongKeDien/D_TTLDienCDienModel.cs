using DucAnhERP.SeedWork;
using System.ComponentModel.DataAnnotations;

namespace DucAnhERP.ViewModel.ThongKeDien
{
    public class D_TTLDienCDienModel : PagingParameters
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

        public string Id_DM_TuDien { get; set; }
        public string DM_TuDien { get; set; }
        public string LoaiCotTu { get; set; }

        public string Id_DM_BuLong { get; set; }
        public string DM_BuLong { get; set; }
        public string LoaiBulong { get; set; }

        public string Id_DM_TiepDia { get; set; }
        public string DM_TiepDia { get; set; }
        public string TiepDiaCot { get; set; }

        public string Id_DM_BongDen { get; set; }
        public string DM_BongDen { get; set; }
        public string LoaiBongDen { get; set; }
        public int SLBongDen { get; set; }

        public string Id_DM_DayDen { get; set; }
        public string DM_DayDen { get; set; }
        public string LoaiDayDien { get; set; }
        public double CDaiDay { get; set; }

        public double ToaDoX { get; set; }
        public double ToaDoY { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.UtcNow;
        public string CreateBy { get; set; }
        public int IsActive { get; set; } = 1;
    }
}
