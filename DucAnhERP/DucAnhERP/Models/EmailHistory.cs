using System.ComponentModel.DataAnnotations;

namespace DucAnhERP.Models
{
    public class EmailHistory
    {
        [Key]
        public string Id { get; set; }
        public string Receiver { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public string? CompanyId { get; set; }
        public string? MajorId { get; set; }
        public string? ScreenId { get; set; }
        public DateTime CreateAt { get; set; }
        public string? CreateBy { get; set; }
        public int IsRead { get; set; }
    }
}
