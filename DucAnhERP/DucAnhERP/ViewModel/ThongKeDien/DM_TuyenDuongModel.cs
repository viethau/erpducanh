using DucAnhERP.SeedWork;
using System.ComponentModel.DataAnnotations;

namespace DucAnhERP.ViewModel.ThongKeDien
{
    public class DM_TuyenDuongModel : PagingParameters
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string CompanyId { get; set; } = "";
        public string CompanyName { get; set; } = "";
        public string TuyenDuong { get; set; } = "";
        public string TuCot { get; set; } = "";
        public string DenCot { get; set; } = "";
        public string TuLyTrinh { get; set; } = "";
        public string DenLyTrinh { get; set; } = "";
        public string ToaDoX { get; set; } = "";
        public string ToaDoY { get; set; } = "";
        public DateTime CreateAt { get; set; } = DateTime.UtcNow;
        public string CreateBy { get; set; }
        public int IsActive { get; set; } = 1;
    }
}
