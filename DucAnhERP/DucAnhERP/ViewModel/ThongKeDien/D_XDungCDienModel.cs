using DucAnhERP.SeedWork;
using System.ComponentModel.DataAnnotations;

namespace DucAnhERP.ViewModel.ThongKeDien
{
    public class D_XDungCDienModel : PagingParameters
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string CompanyId { get; set; } = "";
        public string CompanyName { get; set; } = "";
        public string Id_DM_TuyenDuong { get; set; }
        public string TuyenDuong { get; set; } = "";
        public string TuCot { get; set; } = "";
        public string DenCot { get; set; } = "";
        public string TuLyTrinh { get; set; } = "";
        public string DenLyTrinh { get; set; } = "";

        public string Id_DM_HangMucLotMong { get; set; }
        public string DM_HangMucLotMong { get; set; }
        public string Id_DM_LoaiKL_LMXD { get; set; }
        public string DM_LoaiKL_LMXD { get; set; }
        public double KLLM_XD_Dai { get; set; }
        public double KLLM_XD_Rong { get; set; }
        public double KLLM_XD_Cao { get; set; }
        public double KLLM_XD_KL { set; get; }

        public string Id_DM_LoaiKLLotMong_VK { get; set; }
        public string DM_LoaiKLLotMong_VK { get; set; }
        public double KLLM_VK_SLCD { get; set; }
        public double KLLM_VK_SLCR { get; set; }
        public double KLLM_VK_KL { set; get; }

        public string ID_DM_HangMucMong { get; set; }
        public string DM_HangMucMong { get; set; }
        public string Id_DM_LoaiKL_MXD { get; set; }
        public string DM_LoaiKL_MXD { get; set; }
        public double KLM_XD_Dai { get; set; }
        public double KLM_XD_Rong { get; set; }
        public double KLM_XD_Cao { get; set; }
        public double KLM_XD_KL { set; get; }

        public string Id_DM_LoaiKL_VK { get; set; }
        public string DM_LoaiKL_VK { get; set; }
        public double KLM_VK_SLCD { get; set; }
        public double KLM_VK_SLCR { get; set; }
        public double KLM_VK_KL { set; get; }

        public DateTime CreateAt { get; set; } = DateTime.UtcNow;
        public string CreateBy { get; set; }
        public int IsActive { get; set; } = 1;
    }
}
