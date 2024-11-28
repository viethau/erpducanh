using DucAnhERP.SeedWork;

namespace DucAnhERP.ViewModel
{
    public class PermissionControlModel : PagingParameters
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string CompanyId { get; set; } = "";
        public string CompanyName { get; set; } = "";
        public string ParentMajorId { get; set; } = "";
        public string ParentMajorName { get; set; } = "";
        public string MajorId { get; set; } = "";
        public string MajorName { get; set; } = "";
        public string UserId { get; set; } = "";
        public string UserName { get; set; } = "";
        public DateTime CreateAt { get; set; } = DateTime.Now;
        public string CreateBy { get; set; } = "";
        public int IsActive { get; set; } = 0;
    }
}
