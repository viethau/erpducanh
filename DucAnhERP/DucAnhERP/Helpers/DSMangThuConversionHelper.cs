
using DucAnhERP.Components.Pages.NghiepVuCongTrinh;
using DucAnhERP.Models;
using DucAnhERP.ViewModel;

namespace DucAnhERP.Helpers
{
    public class DSMangThuConversionHelper
    {
        public List<DanhMuc> listDanhMuc = new();
        public string GetTenDanhMucById(string id = "")
        {

            var danhMuc = listDanhMuc.FirstOrDefault(dm => dm.Id == id);
            return danhMuc != null ? danhMuc.Ten : "";
        }
    }
}
