using DucAnhERP.Models;
using DucAnhERP.SeedWork;
using System.ComponentModel.DataAnnotations;

namespace DucAnhERP.ViewModel
{
    public class PKKLHoGaModel : PagingParameters    {

        public string Id { get; set; } = Guid.NewGuid().ToString();
        public int Flag { get; set; } = 0;
        public string ThongTinChungHoGa_TenHoGaSauPhanLoai { get; set; } = "";
        public string ThongTinChungHoGa_TenHoGaSauPhanLoai_Name { get; set; } = "";
        public string ThongTinChungHoGa_HinhThucHoGa { get; set; } = "";
        public string ThongTinChungHoGa_HinhThucHoGa_Name { get; set; } = "";
        public string ThongTinChungHoGa_KetCauMuMo { get; set; } = "";
        public string ThongTinChungHoGa_KetCauMuMo_Name { get; set; } = "";
        public string LoaiBeTong { get; set; } = "";
        public string HangMuc { get; set; } = "";
        public string HangMucCongTac { get; set; } = "";
        public string TenCongTac { get; set; } = "";
        public string DonVi { get; set; } = "";
        public double BeTongLotMong_D { get; set; } = 0;
        public double BeTongLotMong_R { get; set; } = 0;
        public double BeTongLotMong_C { get; set; } = 0;
        public double KTHH_DienTich { get; set; } = 0;
        public string GhiChu { get; set; } = "";
        public double SLCauKien { get; set; } = 0;
        public double KL1CK { get; set; } = 0;
        public double TTCDT_CDai { get; set; } = 0;
        public double TTCDT_Crong { get; set; } = 0;
        public double TTCDT_Cday { get; set; } = 0;
        public double TTCDT_DT { get; set; } = 0;
        public double TTCDT_SLCK { get; set; } = 0;
        public double TTCDT_KL { get; set; } = 0;
        public double KLKP_KL { get; set; } = 0;
        public double KLKP_Sl { get; set; } = 0;
        public double KL1CK_ChuaTruCC { get; set; } = 0;
        public double KLCC1CK { get; set; } = 0;
        public double TKLCK_SauCC { get; set; } = 0;
        public DateTime? CreateAt { get; set; } = DateTime.Now;
        public string? CreateBy { get; set; } = "";
        public int? IsActive { get; set; } = 1;

    }
}
