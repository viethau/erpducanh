using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DucAnhERP.Models.ThongKeDien
{
    [Table("D_XDungCDiens")]
    public class D_XDungCDien
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string CompanyId { get; set; } = "";

        [Required(ErrorMessage = "Vui lòng nhập tuyến đường!")]
        public string Id_DM_TuyenDuong { get; set; }


        [Required(ErrorMessage = "Vui lòng nhập Hạng mục!")]
        public string Id_DM_HangMucLotMong { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập Loại KL!")]
        public string Id_DM_LoaiKL_LMXD { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập chiều dài!")]
        public double KLLM_XD_Dai { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập chiều rộng!")]
        public double KLLM_XD_Rong { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập chiều cao!")]
        public double KLLM_XD_Cao { get; set; }
        public double KLLM_XD_KL { set; get; }


        [Required(ErrorMessage = "Vui lòng nhập loại KL!")]
        public string Id_DM_LoaiKLLotMong_VK { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập SL C.Dài!")]
        public double KLLM_VK_SLCD { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập SL C.Rộng!")]
        public double KLLM_VK_SLCR { get; set; }
        public double KLLM_VK_KL { set; get; }


        [Required(ErrorMessage = "Vui lòng nhập Hạng mục!")]
        public string ID_DM_HangMucMong { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập Loại KL!")]
        public string Id_DM_LoaiKL_MXD { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập chiều dài!")]
        public double KLM_XD_Dai { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập chiều rộng!")]
        public double KLM_XD_Rong { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập chiều cao!")]
        public double KLM_XD_Cao { get; set; }
        public double KLM_XD_KL { set; get; }


        [Required(ErrorMessage = "Vui lòng nhập Loại KL!")]
        public string Id_DM_LoaiKL_VK { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập SL C.Dài!")]
        public double KLM_VK_SLCD { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập SL C.Rộng!")]
        public double KLM_VK_SLCR { get; set; }
        public double KLM_VK_KL { set; get; }


        public DateTime CreateAt { get; set; } = DateTime.UtcNow;
        public string CreateBy { get; set; }
        public int IsActive { get; set; } = 1;
    }
}
