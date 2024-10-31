using DucAnhERP.SeedWork;
using System.ComponentModel.DataAnnotations;

namespace DucAnhERP.ViewModel
{
    public class KTHHMDCModel : PagingParameters
    {
        
        public string ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai { get; set; }
        public string PhanLoaiCTronHopNhua_TenLoaiTruyenDanSauPhanLoai { get; set; }
        public Double TTCDSLCauKienDuongTruyenDan_ChieuDai01CauKien { get; set; }
        public Double ThongTinCauTaoCongTron_CDayPhuBi { get; set; }
        public Double ThongTinCauTaoCongTron_LongSuDung { get; set; }

        public string ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop { get; set; }
        public string PhanLoaiMongCTron_PhanLoaiMongCongTronCongHop { get; set; }
        public Double ThongTinCauTaoCongTron_CCaoLotMong { get; set; }
        public Double ThongTinCauTaoCongTron_CRongLotMong { get; set; }
        public Double ThongTinCauTaoCongTron_CCaoMong { get; set; }
        public Double ThongTinCauTaoCongTron_CRongMong { get; set; }

        public string ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop1 { get; set; }
        public string PhanLoaiMongCTron_PhanLoaiMongCongTronCongHop1 { get; set; }
        public Double TTKTHHCongHopRanh_CCaoLotMong { get; set; }
        public Double TTKTHHCongHopRanh_CRongLotMong { get; set; }
        public Double TTKTHHCongHopRanh_CCaoMong { get; set; }
        public Double TTKTHHCongHopRanh_CRongMong { get; set; }

        public string ThongTinDeCong_TenLoaiDeCong { get; set; }
        public string PhanLoaiDeCong_TenLoaiDeCong { get; set; }
        public Double ThongTinDeCong_D { get; set; }
        public Double ThongTinDeCong_R { get; set; }
        public Double ThongTinDeCong_C { get; set; }
    }
}
