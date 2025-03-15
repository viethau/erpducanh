using DucAnhERP.SeedWork;
using System.ComponentModel.DataAnnotations;

namespace DucAnhERP.ViewModel.QLNV
{
    public class QLNV_CongViecModel : PagingParameters
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Id_Task { get; set; }
        public string Id_NguoiGiaoViec { get; set; } = "";
        public string Id_NguoiThucHien { get; set; }="";
        public string NguoiThucHien { get; set; } = "";
        public string NhomCongViec { get; set; } = "";
        public string TenNhom { get; set; } = "";
        public DateTime? NgayBatDau { get; set; }
        public DateTime? NgayKetThuc { get; set; }
        public string MucDoUuTien { get; set; } = "";
        public string TuDanhGia { get; set; } = "";
        public Double TienDo { get; set; } = 0;
        public string LapLai { get; set; } = "";
        public string NoiDungCongViec { get; set; } = "";
        public string FileDinhKem { get; set; } = "";

        public string GroupId { get; set; } = "";
        public DateTime CreateAt { get; set; } = DateTime.UtcNow;
        public string CreateBy { get; set; }
        public int IsActive { get; set; } = 1;
    }
}
