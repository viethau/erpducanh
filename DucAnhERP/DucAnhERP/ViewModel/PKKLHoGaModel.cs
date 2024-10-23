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
        public string ThongTinChungHoGa_KetCauMuMo { get; set; } = "";
        public string LoaiBeTong { get; set; } = "";
        public string HangMucThiCong { get; set; } = "";
        public string TenCongTac { get; set; } = "";
        public string DonVi { get; set; } = "";
        public decimal BeTongLotMong_D { get; set; } = 0;
        public decimal BeTongLotMong_R { get; set; } = 0;
        public decimal BeTongLotMong_C { get; set; } = 0;
        public decimal KTHH_DienTich { get; set; } = 0;
        public decimal GhiChu { get; set; } = 0;
        public decimal SLCauKien { get; set; } = 0;
        public decimal KL1CK { get; set; } = 0;
        public decimal TTCDT_CDai { get; set; } = 0;
        public decimal TTCDT_Crong { get; set; } = 0;
        public decimal TTCDT_Cday { get; set; } = 0;
        public decimal TTCDT_DT { get; set; } = 0;
        public decimal TTCDT_SLCK { get; set; } = 0;
        public decimal TTCDT_KL { get; set; } = 0;
        public decimal KLKP_KL { get; set; } = 0;
        public decimal KLKP_Sl { get; set; } = 0;
        public decimal KL1CK_ChuaTruCC { get; set; } = 0;
        public decimal KLCC1CK { get; set; } = 0;
        public decimal TKLCK_SauCC { get; set; } = 0;
        public DateTime? CreateAt { get; set; } = DateTime.Now;
        public string? CreateBy { get; set; } = "";
        public int? IsActive { get; set; } = 1;

    }
}
