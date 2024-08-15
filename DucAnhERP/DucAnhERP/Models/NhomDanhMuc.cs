using System.ComponentModel.DataAnnotations;

namespace DucAnhERP.Models
{
     public class NhomDanhMuc
    {
        [Key]
        public string Id { get; set; }
        public string Ten { get; set; } 

     }
    
}
