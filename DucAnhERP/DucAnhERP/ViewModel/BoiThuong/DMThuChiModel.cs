using DucAnhERP.SeedWork;
using System.ComponentModel.DataAnnotations;

namespace DucAnhERP.ViewModel.BoiThuong
{
    public class DMThuChiModel: PagingParameters
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Ten { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.UtcNow;
        public string CreateBy { get; set; }
        public int IsActive { get; set; } = 1;
    }
}
