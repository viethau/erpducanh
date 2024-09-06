using System.ComponentModel.DataAnnotations;

namespace DucAnhERP.Models
{
    public class PhanLoaiRanhXayBeTong
    {

        public string Id { get; set; } = Guid.NewGuid().ToString();
        public int Flag { get; set; } = 0;

        //ThongTinChungHoGa_TenHoGaTheoBanVe
        //ThongTinDuongTruyenDan_HinhThucTruyenDan
        //ThongTinDuongTruyenDan_LoaiTruyenDan
        // TTKTHHCongHopRanh_CauTaoTuong
        // TTKTHHCongHopRanh_CauTaoMuMo
        // TTKTHHCongHopRanh_ChatMatTrong
        // TTKTHHCongHopRanh_ChatMatNgoai
        // TTKTHHCongHopRanh_CCaoLotMong
        // TTKTHHCongHopRanh_CRongLotMong
        // TTKTHHCongHopRanh_CCaoMong
        // TTKTHHCongHopRanh_CRongMong
        // TTKTHHCongHopRanh_CDayTuong01Ben
        // TTKTHHCongHopRanh_SoLuongTuong
        // TTKTHHCongHopRanh_CRongLongSuDung
        // TTKTHHCongHopRanh_CCaoTuongGop
        // TTKTHHCongHopRanh_CCaoMuMoThotDuoi
        // TTKTHHCongHopRanh_CRongMuMoDuoi
        // TTKTHHCongHopRanh_CCaoMuMoThotTren
        // TTKTHHCongHopRanh_CRongMuMoTren
        // TTKTHHCongHopRanh_CCaoChatMatTrong
        // TTKTHHCongHopRanh_CCaoChatmatNgoai
       

    }
}
