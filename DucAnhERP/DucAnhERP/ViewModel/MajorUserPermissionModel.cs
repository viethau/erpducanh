using DucAnhERP.Models;
using DucAnhERP.SeedWork;
using System.ComponentModel.DataAnnotations;
namespace DucAnhERP.ViewModel
{
    public class MajorUserPermissionModel : PagingParameters
    {
        public string Id { get; set; }
        public string CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string MajorId { get; set; }
        public string MajorName { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string PermissionId { get; set; }
        public string PermissionName { get; set; }
        public string DayinWeek { get; set; }
        public DateTime CreateAt { get; set; }
        public string CreateBy { get; set; } 
        public int IsActive { get; set; } 
    }
}
