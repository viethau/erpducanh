using DucAnhERP.SeedWork;
using System.ComponentModel.DataAnnotations;

namespace DucAnhERP.ViewModel.QLNV
{
    public class QLNV_QuanLyNhanVienModel : PagingParameters
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string Id_NhomNhanVien { get; set; } = "";
        public string TenNhom { get; set; } = "";
        public string Id_NhanVien { get; set; } = "";
        public string TenNhanVien { get; set; } = "";
        public string TaiKhoan { get; set; } = "";

        public string GroupId { get; set; } = "";
        public DateTime CreateAt { get; set; } = DateTime.UtcNow;
        public string CreateBy { get; set; }
        public int IsActive { get; set; } = 1;
    }
}
