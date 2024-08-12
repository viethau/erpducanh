using DucAnhERP.Models;
using DucAnhERP.SeedWork;
using System.ComponentModel.DataAnnotations;

namespace DucAnhERP.ViewModel
{
    public class MajorModel : PagingParameters
    {
        [Key]
        public string Id { get; set; }
        public string? ParentId { get; set; }
        public string MajorName { get; set; }
        public int Order { get; set; }
        public string? Table { get; set; }
        public DateTime CreateAt { get; set; }
        public string CreateBy { get; set; }
        public int IsActive { get; set; }
        public string ParentName { get; set; }
    }
}
