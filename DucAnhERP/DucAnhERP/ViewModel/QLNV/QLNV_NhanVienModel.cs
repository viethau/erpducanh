using DucAnhERP.SeedWork;
using System.ComponentModel.DataAnnotations;

namespace DucAnhERP.ViewModel.QLNV
{
    public class QLNV_NhanVienModel : PagingParameters
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
       
        public string TenNhanVien { get; set; } = "";
        public string TaiKhoan { get; set; } = "";

        public string GroupId { get; set; } = "";
        public DateTime CreateAt { get; set; } = DateTime.UtcNow;
        public string CreateBy { get; set; }
        public int IsActive { get; set; } = 1;
    }
}
