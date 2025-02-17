﻿using DucAnhERP.SeedWork;

namespace DucAnhERP.ViewModel
{
    public class PhanLoaiMongCongModel: PagingParameters
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public int Flag { get; set; }=0;
        public int IsEdit { get; set; }=0;
        public string? ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop { get; set; } = "";
        public string? ThongTinDuongTruyenDan_HinhThucTruyenDan { get; set; } = "";
        public string? ThongTinDuongTruyenDan_HinhThucTruyenDan_Name { get; set; } = "";
        public string? ThongTinDuongTruyenDan_LoaiTruyenDan { get; set; } = "";
        public string? ThongTinDuongTruyenDan_LoaiTruyenDan_Name { get; set; } = "";
        public string? ThongTinMongDuongTruyenDan_LoaiMong { get; set; } = "";
        public string? ThongTinMongDuongTruyenDan_LoaiMong_Name { get; set; } = "";
        public string? ThongTinMongDuongTruyenDan_HinhThucMong { get; set; } = "";
        public string? ThongTinMongDuongTruyenDan_HinhThucMong_Name { get; set; } = "";
        public Double? ThongTinCauTaoCongTron_CCaoLotMong { get; set; } = 0;
        public Double? ThongTinCauTaoCongTron_CRongLotMong { get; set; } = 0;
        public Double? ThongTinCauTaoCongTron_CCaoMong { get; set; } = 0;
        public Double? ThongTinCauTaoCongTron_CRongMong { get; set; } = 0;
        public DateTime? CreateAt { get; set; }
        public string? CreateBy { get; set; }
        public int? IsActive { get; set; }
    }
}
