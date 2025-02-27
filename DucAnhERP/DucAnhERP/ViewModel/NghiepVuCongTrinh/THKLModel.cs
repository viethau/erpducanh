﻿using DucAnhERP.SeedWork;

namespace DucAnhERP.ViewModel.NghiepVuCongTrinh
{
    public class THKLModel : PagingParameters
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public int Flag { get; set; } = 0;
        public string ThongTinLyTrinh_TuyenDuong { get; set; } = "";
        public string ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai { get; set; } = "";
        public string PhanLoaiCTronHopNhua_TenLoaiTruyenDanSauPhanLoai { get; set; } = "";
        public string LoaiBeTong { get; set; } = "";
        public string HangMuc { get; set; } = "";
        public string HangMucCongTac { get; set; } = "";
        public string TenCongTac { get; set; } = "";
        public string DonVi { get; set; } = "";
        public double KL1DonVi { get; set; } = 0;
        public string TenCongTacTheoDM { get; set; } = "";
        public string MaDinhMuc { get; set; } = "";
        public double SLTrai { get; set; } = 0;
        public double SLPhai { get; set; } = 0;
        public double SLTong { get; set; } = 0;
        public double KLTrai { get; set; } = 0;
        public double KLPhai { get; set; } = 0;
        public double KLTong { get; set; } = 0;
        public DateTime? CreateAt { get; set; } = DateTime.Now;
        public string? CreateBy { get; set; } = "";
        public int? IsActive { get; set; } = 1;
    }

    public class THKL1HGModel: THKLModel
    {
        public double KLChiemCho { get; set; } = 0;
        public double KLTangThem { get; set; } = 0;
        public double KLCCVaTT { get; set; } = 0;
    }
}
