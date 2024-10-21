using DucAnhERP.SeedWork;
using System.ComponentModel.DataAnnotations;

namespace DucAnhERP.ViewModel
{
    public class DMTLThepModel : PagingParameters
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public int Flag { get; set; } = 0;
        public string? ChungLoaiThep { get; set; } = "";
        public string? ChungLoaiThep_Name { get; set; } = "";
        public string? DuongKinh { get; set; } = "";
        public string? DonVi { get; set; } = "";
        public Double? TrongLuong { get; set; } = 0;
        public DateTime? CreateAt { get; set; } = DateTime.Now;
        public string? CreateBy { get; set; } = "";
        public int? IsActive { get; set; } = 1;
    }
}
