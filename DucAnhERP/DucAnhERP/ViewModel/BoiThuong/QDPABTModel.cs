using DucAnhERP.SeedWork;
using System.ComponentModel.DataAnnotations;

namespace DucAnhERP.ViewModel.BoiThuong
{
    public class QDPABTModel : PagingParameters
    {
        public string Id { get; set; }
        public string CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string Id_DM_QD { get; set; }
        public string SoQD { get; set; }
        public DateTime? NTN { get; set; }
        public string SoQDDC { get; set; }
        public DateTime? NTNDC { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.UtcNow;
        public string CreateBy { get; set; }
        public int IsActive { get; set; } = 1;
    }
}
