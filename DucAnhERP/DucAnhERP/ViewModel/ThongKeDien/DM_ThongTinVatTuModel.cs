using DucAnhERP.SeedWork;
using System.ComponentModel.DataAnnotations;

namespace DucAnhERP.ViewModel.ThongKeDien
{
    public class DM_ThongTinVatTuModel : PagingParameters
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string CompanyId { get; set; } = "";
        public string CompanyName { get; set; } = "";
        public string TenLoaiVatTu { get; set; } = "";
        public string DonVi { get; set; } = "";
        public string ThongTinLoaiVatTuDien { get; set; } = "";
        public string HinhAnh { get; set; } = "";
        public DateTime CreateAt { get; set; } = DateTime.UtcNow;
        public string CreateBy { get; set; }
        public int IsActive { get; set; } = 1;
    }
}
