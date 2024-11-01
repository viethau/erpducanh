using DucAnhERP.SeedWork;

namespace DucAnhERP.ViewModel
{
    public class TKSLModel: PagingParameters
    {
        public string IdPhanLoai { get; set; } = "";
        public string PhanLoai { get; set; } = "";
        public string DonVi { get; set; } = "";
        public double Trai { get; set; } = 0;
        public double Phai { get; set; } = 0;
        public double Tong { get; set; } = 0;
    }
}
