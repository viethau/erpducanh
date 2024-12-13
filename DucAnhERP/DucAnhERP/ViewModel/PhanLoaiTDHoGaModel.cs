using DucAnhERP.Models;
using DucAnhERP.SeedWork;
using System.ComponentModel.DataAnnotations;

namespace DucAnhERP.ViewModel
{
    public class PhanLoaiTDHoGaModel : PagingParameters
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public int Flag { get; set; } = 0;
        public int IsEdit { get; set; } = 0;
        public string? ThongTinTamDanHoGa2_PhanLoaiDayHoGa { get; set; } = "";
        public string? ThongTinTamDanHoGa2_HinhThucDayHoGa { get; set; } = "";
        public string? ThongTinTamDanHoGa2_HinhThucDayHoGa_Name { get; set; } = "";
        public Double? ThongTinTamDanHoGa2_DuongKinh { get; set; } = 0;
        public Double? ThongTinTamDanHoGa2_ChieuDay { get; set; } = 0;
        public Double? ThongTinTamDanHoGa2_D { get; set; } = 0;
        public Double? ThongTinTamDanHoGa2_R { get; set; } = 0;
        public Double? ThongTinTamDanHoGa2_C { get; set; } = 0;
        public DateTime? CreateAt { get; set; } = DateTime.Now;
        public string? CreateBy { get; set; } = "";
        public int? IsActive { get; set; } = 1;
    }

    public class PLTDHGBaoCaoTSLTDHGModel : PhanLoaiTDHoGaModel
    {
        public int countTrai { get; set; }
        public int countPhai { get; set; }
        public int Tong { get; set; }
    }
    public class PLTDHGBaoCaoTSLTDHGTTModel : PLTDHGBaoCaoTSLTDHGModel
    {
      
        public string ThongTinLyTrinh_TuyenDuong { get; set; }
    }
}
