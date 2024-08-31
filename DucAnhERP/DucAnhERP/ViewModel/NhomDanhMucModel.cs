using DucAnhERP.SeedWork;
using System.ComponentModel.DataAnnotations;

namespace DucAnhERP.ViewModel
{
    public class NhomDanhMucModel : PagingParameters
    {
        [Key]
        public string Id { get; set; }

        public string Ten { get; set; }

    }
}

