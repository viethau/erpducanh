using DucAnhERP.SeedWork;
using System.ComponentModel.DataAnnotations;

namespace DucAnhERP.ViewModel.NghiepVuCongTrinh
{
    public class KTHHMDCModel : PagingParameters
    {
        
        public string ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai { get; set; }
        public string PhanLoaiCTronHopNhua_TenLoaiTruyenDanSauPhanLoai { get; set; }
        public double TTCDSLCauKienDuongTruyenDan_ChieuDai01CauKien { get; set; }
        public double ThongTinCauTaoCongTron_CDayPhuBi { get; set; }
        public double ThongTinCauTaoCongTron_LongSuDung { get; set; }

        public string ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop { get; set; }
        public string PhanLoaiMongCTron_PhanLoaiMongCongTronCongHop { get; set; }
        public double ThongTinCauTaoCongTron_CCaoLotMong { get; set; }
        public double ThongTinCauTaoCongTron_CRongLotMong { get; set; }
        public double ThongTinCauTaoCongTron_CCaoMong { get; set; }
        public double ThongTinCauTaoCongTron_CRongMong { get; set; }

        public string ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop1 { get; set; }
        public string PhanLoaiMongCTron_PhanLoaiMongCongTronCongHop1 { get; set; }
        public double TTKTHHCongHopRanh_CCaoLotMong { get; set; }
        public double TTKTHHCongHopRanh_CRongLotMong { get; set; }
        public double TTKTHHCongHopRanh_CCaoMong { get; set; }
        public double TTKTHHCongHopRanh_CRongMong { get; set; }

        public string ThongTinDeCong_TenLoaiDeCong { get; set; }
        public string PhanLoaiDeCong_TenLoaiDeCong { get; set; }
        public double ThongTinDeCong_D { get; set; }
        public double ThongTinDeCong_R { get; set; }
        public double ThongTinDeCong_C { get; set; }
    }
}
