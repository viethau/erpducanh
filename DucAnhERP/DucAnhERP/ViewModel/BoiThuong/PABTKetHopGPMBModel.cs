using DucAnhERP.SeedWork;
using System.ComponentModel.DataAnnotations;

namespace DucAnhERP.ViewModel.BoiThuong
{
    public class PABTKetHopGPMBModel : PagingParameters
    {
        public string Id { get; set; }
        public string CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string Id_DM_QDBoiThuongGoc { get; set; }
        public string SoQDBTGoc { get; set; }
        public DateTime? NTNPABTGoc { get; set; }
        public string Id_DM_QDTGPMBNhanhGoc { get; set; }
        public string  SoQDThuongGPMBNhanhGoc { get; set; }
        public DateTime? NTNGPMBNhanhGoc { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.UtcNow;
        public string CreateBy { get; set; }
        public int IsActive { get; set; } = 1;
    }
}
