using DucAnhERP.SeedWork;
using System.ComponentModel.DataAnnotations;

namespace DucAnhERP.ViewModel
{
    public class DanhMucModel : PagingParameters
    {
        [Key]
        public string Id { get; set; }
        public string IdNhomDanhMuc { get; set; }
        public string Ten { get; set; }
        public string TenNhom { get; set; }
        public string GhiChu { get; set; }
        public DateTime? CreateAt { get; set; }
        public string? CreateBy { get; set; }
        public int? IsActive { get; set; }
    }
}
