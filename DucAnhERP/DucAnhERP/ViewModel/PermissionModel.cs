using DucAnhERP.SeedWork;
namespace DucAnhERP.ViewModel;
public partial class PermissionModel : PagingParameters
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string MajorId { get; set; } = "";
    public string MajorName { get; set; } = "";
    public int PermissionType { get; set; } = 0;
    public string PermissionTypeName { get; set; } = "";
    public string PermissionName { get; set; } = "";
    public DateTime CreateAt { get; set; } = DateTime.Now;
    public string CreateBy { get; set; } = "";
    public int IsActive { get; set; } = 0;

    public bool IsChecked { set; get; } = false;
    public int ScreenId { get; set; } = 0;
    public string ScreenName { get; set; } = "";
}
