﻿using DucAnhERP.SeedWork;

namespace DucAnhERP.ViewModel.NghiepVuCongTrinh
{
    public class TKThepMongCHopModel :PagingParameters
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public int Flag { get; set; } = 0;
        public string ThongTinLyTrinh_TuyenDuong { get; set; }
        public double ThongTinLyTrinhTruyenDan_TuLyTrinh { get; set; }
        public double ThongTinLyTrinhTruyenDan_DenLyTrinh { get; set; }
        public string ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop { get; set; } = "";
        public string PhanLoaiMongCTron_PhanLoaiMongCongTronCongHop { get; set; } = "";
        public string? TenCongTac { get; set; } = "";
        public string? VTLayKhoiLuong { get; set; } = "";
        public string? LoaiThep { get; set; } = "";
        public string? LoaiThep_Name { get; set; } = "";
        public int? SoHieu { get; set; } = 0;
        public double? DKCD { get; set; } = 0;
        public int? SoThanh { get; set; } = 0;
        public int? SoCK { get; set; } = 0;
        public int? TongSoThanh { get; set; } = 0;
        public double? ChieuDai1Thanh { get; set; } = 0;
        public double? TongChieuDai { get; set; } = 0;
        public double? TrongLuong { get; set; } = 0;
        public double? TongTrongLuong { get; set; } = 0;
        public DateTime? CreateAt { get; set; } = DateTime.Now;
        public string? CreateBy { get; set; } = "";
        public int? IsActive { get; set; } = 1;
    }
}
