﻿using System.ComponentModel.DataAnnotations;

namespace DucAnhERP.Models.NghiepVuCongTrinh
{
    public class DanhMuc1
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [Required(ErrorMessage = "Bạn phải chọn nhóm danh mục !")]
        public string IdNhomDanhMuc { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập tên !")]
        public string Ten { get; set; }
        public string? GhiChu { get; set; } = "";
        public DateTime? CreateAt { get; set; } = DateTime.Now;
        public string? CreateBy { get; set; } = "";
        public int? IsActive { get; set; } = 1;
    }
}
