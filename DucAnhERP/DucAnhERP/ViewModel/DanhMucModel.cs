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
    }
}
