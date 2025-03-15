using DucAnhERP.SeedWork;
using System.ComponentModel.DataAnnotations;

namespace DucAnhERP.ViewModel.QLNV
{
    public class QLNV_DanhGiaModel : PagingParameters
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
       
        public string Id_CongViec { get; set; } = "";
        public string Id_NguoiGiaoViec { get; set; } = "";
        public string NoiDungCongViec { get; set; } = "";
        public string Id_NguoiThucHien { get; set; } = "";
        public string TenThucHien { get; set; } = "";
        public string TaiKhoanThucHien { get; set; } = "";
        public Double DanhGia { get; set; }=0;
        public string GhiChu { get; set; } = "";

        public string GroupId { get; set; } = "";
        public DateTime CreateAt { get; set; } = DateTime.UtcNow;
        public string CreateBy { get; set; }
        public int IsActive { get; set; } = 1;
    }
}
