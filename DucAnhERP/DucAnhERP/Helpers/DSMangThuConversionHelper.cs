
using DucAnhERP.Components.Pages.NghiepVuCongTrinh;
using DucAnhERP.Models;
using DucAnhERP.ViewModel;
using System;

namespace DucAnhERP.Helpers
{
    public class DSMangThuConversionHelper
    {
        public List<DanhMuc> listDanhMuc = new();
        public string GetTenDanhMucById(string id = "")
        {

            var danhMuc = listDanhMuc.FirstOrDefault(dm => dm.Id == id);
            return danhMuc != null ? danhMuc.Ten : "";
        }
        public async Task<MangThu> ConvertNuocMua(MangThu item, List<DanhMuc> listDM)
        {

            listDanhMuc = listDM;

            
           

            
            item.TTTDCHR_BS_SlCauKienNguyen = TTTDCHR_BS_SlCauKienNguyen(string HB16, double HE16, double JR16, double KA16);
            item.TTTDCHR_BS_ChieuDaiCan = TTTDCHR_BS_ChieuDaiCan(string HB16, double JR16, double KC16, double KA16);
            item.TTTDCHR_BS_TongChieuDai = TTTDCHR_BS_TongChieuDai(string HB16, double JR16, double KC16, double KD16);
            item.TTTDCHR_BS_ChieuDaiThucTe = TTTDCHR_BS_ChieuDaiThucTe(string HB16, double JR16, double KE16, double HE16);
            item.TTTDCHR_BS_OngCongCanThem = TTTDCHR_BS_OngCongCanThem(string HB16, double KF16);
            item.TTKTHHON_TongCCaoOng = TTKTHHON_TongCCaoOng(double KH16, double KI16, double KJ16);
            item.CDTL_Mong_DinhDeCong = CDTL_Mong_DinhDeCong(string HI16, double LE16, double HT16);
            item.CDTL_Mong_DinhMongRanh = CDTL_Mong_DinhMongRanh(string HB16, string HI16, double LE16);
            item.CDTL_Mong_DinhMongCongHop = CDTL_Mong_DinhMongCongHop(string HB16, string HI16, double LE16, double IT16);
            item.CDTL_Mong_DinhMongCongTron = CDTL_Mong_DinhMongCongTron(string HB16, string HI16, double LE16, double HT16, double LD16, double IB16);
            item.CDTL_Mong_DinhMongGop = CDTL_Mong_DinhMongGop(string HB16, string HI16, double LE16, double HT16, double LD16, double IB16, double IT16);
            item.CDTL_Lot_DinhLotRanh = CDTL_Lot_DinhLotRanh(string HB16, string HI16, double LC16, double IR16);
            item.CDTL_Lot_DinhLotCongHop = CDTL_Lot_DinhLotCongHop(string HB16, string HI16, double LB16, double IR16);
            item.CDTL_Lot_DinhLotCongTron = CDTL_Lot_DinhLotCongTron(string HB16, string HI16, double LA16, double HZ16);
            item.CDTL_Lot_DinhLotOngNhua = CDTL_Lot_DinhLotOngNhua(string HB16, string HI16, double LE16, double KH16);
            item.CDTL_Lot_DinhLotGop = CDTL_Lot_DinhLotGop(string HB16, string HI16, double LE16, double KH16, double LA16, double HZ16, double LB16, double IR16, double LC16);
            item.CDTL_Day_DayDaoOngNhua = CDTL_Day_DayDaoOngNhua(string HB16, string HI16, double LE16, double KH16, double KV16, double KL16);
            item.CDTL_Day_DayDaoRanh = CDTL_Day_DayDaoRanh(string HB16, double KY16, double IP16);
            item.CDTL_Day_DayDaoCongHop = CDTL_Day_DayDaoCongHop(string HB16, string HI16, double LE16, double IT16, double KX16, double IP16);
            item.CDTL_Day_DayDaoCongTron = CDTL_Day_DayDaoCongTron(string HB16, string HI16, double LE16, double HT16, double LD16, double IB16, double KW16, double HX16);
            item.CDTL_Day_DayDaoGop = CDTL_Day_DayDaoGop(string HB16, string HI16, double LE16, double HT16, double LD16, double IB16, double KW16, double HX16, double KX16, double IP16, double KY16, double KV16, double KL16, double KH16);
            item.CDTL_Day_ChieuSauDao = CDTL_Day_ChieuSauDao(double KO16, double KN16);
            item. =  ;

            return item;
        }

        public double TTTDCHR_BS_SlCauKienNguyen(string HB16, double HE16, double JR16, double KA16)
        {
            // Chuyển đổi giá trị HB16 về chữ hoa và xóa khoảng trắng
            HB16 = GetTenDanhMucById(HB16).ToUpper().Trim();
            double result = 0; // Khởi tạo kết quả

            // Kiểm tra điều kiện
            if (HB16 == "RÃNH XÂY" || HB16 == "RÃNH BÊ TÔNG" || HB16 == "CỐNG HỘP")
            {
                if (JR16 > 0)
                {
                    result = Math.Floor(HE16 / (JR16 + KA16)); // Tính giá trị nếu điều kiện thỏa mãn
                }
            }

            return result; // Trả về kết quả
        }
        public double TTTDCHR_BS_ChieuDaiCan(string HB16, double JR16, double KC16, double KA16)
        {
            // Chuyển đổi giá trị HB16 về chữ hoa và xóa khoảng trắng
            HB16 = GetTenDanhMucById(HB16).ToUpper().Trim();
            double result = 0; // Khởi tạo kết quả

            // Kiểm tra điều kiện
            if (HB16 == "RÃNH XÂY" || HB16 == "RÃNH BÊ TÔNG" || HB16 == "CỐNG HỘP")
            {
                if (JR16 > 0)
                {
                    result = KC16 * KA16; // Tính giá trị nếu điều kiện thỏa mãn
                }
            }

            return result; // Trả về kết quả
        }
        public double TTTDCHR_BS_TongChieuDai(string HB16, double JR16, double KC16, double KD16)
        {
            // Chuyển đổi giá trị HB16 về chữ hoa và xóa khoảng trắng
            HB16 = GetTenDanhMucById(HB16).ToUpper().Trim();
            double result = 0; // Khởi tạo kết quả

            // Kiểm tra điều kiện
            if (HB16 == "RÃNH XÂY" || HB16 == "RÃNH BÊ TÔNG" || HB16 == "CỐNG HỘP")
            {
                if (JR16 > 0)
                {
                    result = (KC16 * JR16) + KD16; // Tính giá trị nếu điều kiện thỏa mãn
                }
            }

            return result; // Trả về kết quả
        }
        public double TTTDCHR_BS_ChieuDaiThucTe(string HB16, double JR16, double KE16, double HE16)
        {
            // Chuyển đổi giá trị HB16 về chữ hoa và xóa khoảng trắng
            HB16 = GetTenDanhMucById(HB16).ToUpper().Trim();
            double result = 0; // Khởi tạo kết quả

            // Kiểm tra điều kiện
            if (HB16 == "RÃNH XÂY" || HB16 == "RÃNH BÊ TÔNG" || HB16 == "CỐNG HỘP")
            {
                if (JR16 > 0)
                {
                    result = KE16 - HE16; // Tính giá trị nếu điều kiện thỏa mãn
                }
            }

            return result; // Trả về kết quả
        }
        public string TTTDCHR_BS_OngCongCanThem(string HB16, double KF16)
        {
            // Chuyển đổi giá trị HB16 về chữ hoa và xóa khoảng trắng
            HB16 = GetTenDanhMucById(HB16).ToUpper().Trim();
            string result = "0"; // Khởi tạo kết quả mặc định

            // Kiểm tra điều kiện
            if (HB16 == "RÃNH XÂY" || HB16 == "RÃNH BÊ TÔNG" || HB16 == "CỐNG HỘP")
            {
                if (KF16 >= -0.02)
                {
                    result = "Đủ"; // Kết quả nếu thỏa mãn điều kiện
                }
                else
                {
                    result = "Thêm 01"; // Kết quả nếu không thỏa mãn điều kiện
                }
            }

            return result; // Trả về kết quả
        }
        public double TTKTHHON_TongCCaoOng(double KH16, double KI16, double KJ16)
        {
            double result = (KH16 * KI16) + KJ16; // Tính toán
            return Math.Round(result, 2); // Trả về giá trị đã làm tròn
        }
        public double CDTL_Mong_DinhDeCong(string HI16, double LE16, double HT16)
        {
            double result = 0; // Khởi tạo biến kết quả
            HI16 = GetTenDanhMucById(HI16).ToUpper().Trim();
            // Kiểm tra điều kiện
            if (HI16 == "Móng bê tông kết hợp đế" || HI16 == "Đế")
            {
                result = LE16 - HT16; // Tính toán
            }

            return result; // Trả về giá trị kết quả
        }
        public double CDTL_Mong_DinhMongRanh(string HB16, string HI16, double LE16)
        {
            double result = 0; // Khởi tạo biến kết quả
            HB16 = GetTenDanhMucById(HB16).ToUpper().Trim();
            HI16 = GetTenDanhMucById(HI16).ToUpper().Trim();
            // Kiểm tra điều kiện
            if ((HB16 == "Rãnh xây" && HI16 == "Móng bê tông") || (HB16 == "Rãnh bê tông" && HI16 == "Móng bê tông"))
            {
                result = LE16; // Tính toán
            }

            return result; // Trả về giá trị kết quả
        }
        public double CDTL_Mong_DinhMongCongHop(string HB16, string HI16, double LE16, double IT16)
        {
            // Chuyển đổi HB16 bằng phương thức GetTenDanhMucById và xử lý chuỗi
            HB16 = GetTenDanhMucById(HB16).ToUpper().Trim();
            HI16 = HI16.ToUpper().Trim(); // Đảm bảo HI16 cũng được xử lý

            double result = 0; // Khởi tạo biến kết quả

            // Kiểm tra điều kiện
            if (HB16 == "CỐNG HỘP" && HI16 == "MÓNG BÊ TÔNG")
            {
                result = LE16 - IT16; // Tính toán
            }

            return result; // Trả về giá trị kết quả
        }
        public double CDTL_Mong_DinhMongCongTron(string HB16, string HI16, double LE16, double HT16, double LD16, double IB16)
        {
            // Chuyển đổi HB16 bằng phương thức GetTenDanhMucById và xử lý chuỗi
            HB16 = GetTenDanhMucById(HB16).ToUpper().Trim();
            HI16 = HI16.ToUpper().Trim(); // Đảm bảo HI16 cũng được xử lý

            double result = 0; // Khởi tạo biến kết quả

            // Kiểm tra điều kiện
            if (HB16 == "CỐNG TRÒN")
            {
                if (HI16 == "MÓNG BÊ TÔNG")
                {
                    result = LE16 - HT16; // Tính toán cho trường hợp Móng bê tông
                }
                else if (HI16 == "MÓNG BÊ TÔNG KẾT HỢP ĐẾ")
                {
                    result = LD16 - IB16; // Tính toán cho trường hợp Móng bê tông kết hợp đế
                }
            }

            return result; // Trả về giá trị kết quả
        }
        public double CDTL_Mong_DinhMongGop(string HB16, string HI16, double LE16, double HT16, double LD16, double IB16, double IT16)
        {
            // Chuyển đổi HB16 và HI16 bằng phương thức GetTenDanhMucById và xử lý chuỗi
            HB16 = GetTenDanhMucById(HB16).ToUpper().Trim();
            HI16 = HI16.ToUpper().Trim(); // Đảm bảo HI16 cũng được xử lý

            double result = 0; // Khởi tạo biến kết quả

            // Kiểm tra điều kiện
            if (HB16 == "RÃNH THANG")
            {
                if (HB16 == "RÃNH THANG" && HI16 == "MÓNG BÊ TÔNG")
                {
                    result = LE16; // Trường hợp Rãnh thang và Móng bê tông
                }
            }
            else if (HB16 == "CỐNG TRÒN")
            {
                if (HI16 == "MÓNG BÊ TÔNG")
                {
                    result = LE16 - HT16; // Trường hợp Cống tròn và Móng bê tông
                }
                else if (HI16 == "MÓNG BÊ TÔNG KẾT HỢP ĐẾ")
                {
                    result = LD16 - IB16; // Trường hợp Cống tròn và Móng bê tông kết hợp đế
                }
            }
            else if (HB16 == "CỐNG HỘP" && HI16 == "MÓNG BÊ TÔNG")
            {
                result = LE16 - IT16; // Trường hợp Cống hộp và Móng bê tông
            }
            else if (HB16 == "RÃNH XÂY" || HB16 == "RÃNH BÊ TÔNG")
            {
                if (HI16 == "MÓNG BÊ TÔNG")
                {
                    result = LE16; // Trường hợp Rãnh xây hoặc Rãnh bê tông và Móng bê tông
                }
            }

            return result; // Trả về giá trị kết quả
        }
        public double CDTL_Lot_DinhLotRanh(string HB16, string HI16, double LC16, double IR16)
        {
            // Chuyển đổi HB16 và HI16 bằng phương thức GetTenDanhMucById và xử lý chuỗi
            HB16 = GetTenDanhMucById(HB16).ToUpper().Trim();
            HI16 = HI16.ToUpper().Trim(); // Đảm bảo HI16 cũng được xử lý

            double result = 0; // Khởi tạo biến kết quả

            // Kiểm tra điều kiện
            if (HB16 == "RÃNH XÂY" && HI16 == "MÓNG BÊ TÔNG")
            {
                result = LC16 - IR16; // Trường hợp Rãnh xây và Móng bê tông
            }
            else if (HB16 == "RÃNH BÊ TÔNG" && HI16 == "MÓNG BÊ TÔNG")
            {
                result = LC16 - IR16; // Trường hợp Rãnh bê tông và Móng bê tông
            }
            else
            {
                result = 0; // Trường hợp khác
            }

            return result; // Trả về giá trị kết quả
        }
        public double CDTL_Lot_DinhLotCongHop(string HB16, string HI16, double LB16, double IR16)
        {
            // Chuyển đổi HB16 và HI16 bằng phương thức GetTenDanhMucById và xử lý chuỗi
            HB16 = GetTenDanhMucById(HB16).ToUpper().Trim();
            HI16 = HI16.ToUpper().Trim(); // Đảm bảo HI16 cũng được xử lý

            double result = 0; // Khởi tạo biến kết quả

            // Kiểm tra điều kiện
            if (HB16 == "CỐNG HỘP" && HI16 == "MÓNG BÊ TÔNG")
            {
                result = LB16 - IR16; // Trường hợp Cống hộp và Móng bê tông
            }
            else
            {
                result = 0; // Trường hợp khác
            }

            return result; // Trả về giá trị kết quả
        }
        public double CDTL_Lot_DinhLotCongTron(string HB16, string HI16, double LA16, double HZ16)
        {
            // Chuyển đổi HB16 và HI16 bằng phương thức GetTenDanhMucById và xử lý chuỗi
            HB16 = GetTenDanhMucById(HB16).ToUpper().Trim();
            HI16 = HI16.ToUpper().Trim(); // Đảm bảo HI16 cũng được xử lý

            double result = 0; // Khởi tạo biến kết quả

            // Kiểm tra điều kiện
            if (HB16 == "CỐNG TRÒN")
            {
                if (HI16 == "MÓNG BÊ TÔNG" || HI16 == "MÓNG BÊ TÔNG KẾT HỢP ĐẾ")
                {
                    result = LA16 - HZ16; // Tính giá trị nếu điều kiện thỏa mãn
                }
            }

            return result; // Trả về giá trị kết quả
        }
        public double CDTL_Lot_DinhLotOngNhua(string HB16, string HI16, double LE16, double KH16)
        {
            // Chuyển đổi HB16 và HI16 bằng phương thức GetTenDanhMucById và xử lý chuỗi
            HB16 = GetTenDanhMucById(HB16).ToUpper().Trim();
            HI16 = HI16.ToUpper().Trim(); // Đảm bảo HI16 cũng được xử lý

            double result = 0; // Khởi tạo biến kết quả

            // Kiểm tra điều kiện
            if (HB16 == "ỐNG NHỰA" && HI16 == "ĐẮP CÁT")
            {
                result = LE16 - KH16; // Tính giá trị nếu điều kiện thỏa mãn
            }

            return result; // Trả về giá trị kết quả
        }
        public double CDTL_Lot_DinhLotGop(string HB16, string HI16, double LE16, double KH16, double LA16, double HZ16, double LB16, double IR16, double LC16)
        {
            // Chuyển đổi HB16 và HI16 bằng phương thức GetTenDanhMucById và xử lý chuỗi
            HB16 = GetTenDanhMucById(HB16).ToUpper().Trim();
            HI16 = HI16.ToUpper().Trim(); // Đảm bảo HI16 cũng được xử lý

            double result = 0; // Khởi tạo biến kết quả

            // Kiểm tra điều kiện
            if (HB16 == "RÃNH THANG")
            {
                if (HI16 == "MÓNG BÊ TÔNG")
                {
                    result = LE16 - /* giá trị thiếu ở đây */; // Bạn cần thay thế #REF! với giá trị cụ thể
                }
            }
            else if (HB16 == "ỐNG NHỰA" && HI16 == "ĐẮP CÁT")
            {
                result = LE16 - KH16; // Tính giá trị nếu điều kiện thỏa mãn
            }
            else if (HB16 == "CỐNG TRÒN")
            {
                if (HI16 == "MÓNG BÊ TÔNG" || HI16 == "MÓNG BÊ TÔNG KẾT HỢP ĐẾ")
                {
                    result = LA16 - HZ16; // Tính giá trị nếu điều kiện thỏa mãn
                }
            }
            else if (HB16 == "CỐNG HỘP" && HI16 == "MÓNG BÊ TÔNG")
            {
                result = LB16 - IR16; // Tính giá trị nếu điều kiện thỏa mãn
            }
            else if (HB16 == "RÃNH XÂY" || HB16 == "RÃNH BÊ TÔNG")
            {
                if (HI16 == "MÓNG BÊ TÔNG")
                {
                    result = LC16 - IR16; // Tính giá trị nếu điều kiện thỏa mãn
                }
            }

            return result; // Trả về giá trị kết quả
        }
        public double CDTL_Day_DayDaoOngNhua(string HB16, string HI16, double LE16, double KH16, double KV16, double KL16)
        {
            // Chuyển đổi HB16 và HI16 bằng phương thức GetTenDanhMucById và xử lý chuỗi
            HB16 = GetTenDanhMucById(HB16).ToUpper().Trim();
            HI16 = HI16.ToUpper().Trim(); // Đảm bảo HI16 cũng được xử lý

            double result = 0; // Khởi tạo biến kết quả

            // Kiểm tra điều kiện
            if (HB16 == "ỐNG NHỰA" && HI16 == "KHÔNG ĐẮP CÁT")
            {
                result = LE16 - KH16; // Tính giá trị nếu điều kiện thỏa mãn
            }
            else if (HB16 == "ỐNG NHỰA" && HI16 == "ĐẮP CÁT")
            {
                result = KV16 - KL16; // Tính giá trị nếu điều kiện thỏa mãn
            }

            return result; // Trả về giá trị kết quả
        }
        public double CDTL_Day_DayDaoRanh(string HB16, double KY16, double IP16)
        {
            // Chuyển đổi HB16 bằng phương thức GetTenDanhMucById và xử lý chuỗi
            HB16 = GetTenDanhMucById(HB16).ToUpper().Trim(); // Chuyển đổi HB16 thành chữ hoa và xóa khoảng trắng

            double result = 0; // Khởi tạo biến kết quả

            // Kiểm tra điều kiện
            if (HB16 == "RÃNH XÂY" || HB16 == "RÃNH BÊ TÔNG")
            {
                result = KY16 - IP16; // Tính giá trị nếu điều kiện thỏa mãn
            }

            return result; // Trả về giá trị kết quả
        }
        public double CDTL_Day_DayDaoCongHop(string HB16, string HI16, double LE16, double IT16, double KX16, double IP16)
        {
            // Chuyển đổi HB16 và HI16 bằng phương thức GetTenDanhMucById và xử lý chuỗi
            HB16 = GetTenDanhMucById(HB16).ToUpper().Trim(); // Chuyển đổi HB16 thành chữ hoa và xóa khoảng trắng
            HI16 = GetTenDanhMucById(HI16).ToUpper().Trim(); // Chuyển đổi HI16 thành chữ hoa và xóa khoảng trắng

            double result = 0; // Khởi tạo biến kết quả

            // Kiểm tra điều kiện
            if (HB16 == "CỐNG HỘP")
            {
                if (HI16 == "KHÔNG CÓ MÓNG")
                {
                    result = LE16 - IT16; // Tính giá trị nếu HI16 là "Không có móng"
                }
                else if (HI16 == "MÓNG BÊ TÔNG")
                {
                    result = KX16 - IP16; // Tính giá trị nếu HI16 là "Móng bê tông"
                }
            }

            return result; // Trả về giá trị kết quả
        }
        public double CDTL_Day_DayDaoCongTron(string HB16, string HI16, double LE16, double HT16, double LD16, double IB16, double KW16, double HX16)
        {
            // Chuyển đổi HB16 và HI16 bằng phương thức GetTenDanhMucById và xử lý chuỗi
            HB16 = GetTenDanhMucById(HB16).ToUpper().Trim(); // Chuyển đổi HB16 thành chữ hoa và xóa khoảng trắng
            HI16 = GetTenDanhMucById(HI16).ToUpper().Trim(); // Chuyển đổi HI16 thành chữ hoa và xóa khoảng trắng

            double result = 0; // Khởi tạo biến kết quả

            // Kiểm tra điều kiện
            if (HB16 == "CỐNG TRÒN")
            {
                if (HI16 == "KHÔNG CÓ MÓNG")
                {
                    result = LE16 - HT16; // Tính giá trị nếu HI16 là "Không có móng"
                }
                else if (HI16 == "ĐẾ")
                {
                    result = LD16 - IB16; // Tính giá trị nếu HI16 là "Đế"
                }
                else if (HI16 == "MÓNG BÊ TÔNG" || HI16 == "MÓNG BÊ TÔNG KẾT HỢP ĐẾ")
                {
                    result = KW16 - HX16; // Tính giá trị nếu HI16 là "Móng bê tông" hoặc "Móng bê tông kết hợp đế"
                }
            }

            return result; // Trả về giá trị kết quả
        }
        public double CDTL_Day_DayDaoGop(string HB16, string HI16, double LE16, double HT16, double LD16, double IB16, double KW16, double HX16, double KX16, double IP16, double KY16, double KV16, double KL16, double KH16)
        {
            // Chuyển đổi HB16 và HI16 bằng phương thức GetTenDanhMucById và xử lý chuỗi
            HB16 = GetTenDanhMucById(HB16).ToUpper().Trim(); // Chuyển đổi HB16 thành chữ hoa và xóa khoảng trắng
            HI16 = GetTenDanhMucById(HI16).ToUpper().Trim(); // Chuyển đổi HI16 thành chữ hoa và xóa khoảng trắng

            double result = 0; // Khởi tạo biến kết quả

            // Kiểm tra điều kiện
            if (HB16 == "CỐNG TRÒN")
            {
                if (HI16 == "KHÔNG CÓ MÓNG")
                {
                    result = LE16 - HT16; // Tính giá trị nếu HI16 là "Không có móng"
                }
                else if (HI16 == "ĐẾ")
                {
                    result = LD16 - IB16; // Tính giá trị nếu HI16 là "Đế"
                }
                else if (HI16 == "MÓNG BÊ TÔNG" || HI16 == "MÓNG BÊ TÔNG KẾT HỢP ĐẾ")
                {
                    result = KW16 - HX16; // Tính giá trị nếu HI16 là "Móng bê tông" hoặc "Móng bê tông kết hợp đế"
                }
            }
            else if (HB16 == "CỐNG HỘP")
            {
                if (HI16 == "KHÔNG CÓ MÓNG")
                {
                    result = LE16 - IT16; // Tính giá trị nếu HI16 là "Không có móng"
                }
                else if (HI16 == "MÓNG BÊ TÔNG")
                {
                    result = KX16 - IP16; // Tính giá trị nếu HI16 là "Móng bê tông"
                }
            }
            else if (HB16 == "RÃNH XÂY" || HB16 == "RÃNH BÊ TÔNG")
            {
                result = KY16 - IP16; // Tính giá trị nếu HB16 là "Rãnh xây" hoặc "Rãnh bê tông"
            }
            else if (HB16 == "ỐNG NHỰA")
            {
                if (HI16 == "KHÔNG ĐẮP CÁT")
                {
                    result = LE16 - KH16; // Tính giá trị nếu HI16 là "Không đắp cát"
                }
                else if (HI16 == "ĐẮP CÁT")
                {
                    result = KV16 - KL16; // Tính giá trị nếu HI16 là "Đắp cát"
                }
            }
            else if (HB16 == "RÃNH THANG")
            {
                if (HI16 == "MÓNG BÊ TÔNG")
                {
                    // Lưu ý: Giá trị #REF! không thể chuyển đổi sang C#
                    // Bạn cần xác định rõ giá trị này trước khi sử dụng
                    result = 0; // Thay thế bằng giá trị chính xác nếu có
                }
                else
                {
                    result = LE16; // Nếu không có điều kiện nào khác
                }
            }

            return Math.Round(result, 2); // Trả về giá trị làm tròn tới 2 chữ số thập phân
        }

        public double CDTL_Day_ChieuSauDao(double KO16, double KN16)
        {
            double result = 0; // Khởi tạo biến kết quả

            // Kiểm tra điều kiện
            if (KO16 > 0)
            {
                result = KN16 - KO16; // Tính giá trị nếu KO16 lớn hơn 0
            }

            return Math.Round(result, 2); // Trả về giá trị làm tròn tới 2 chữ số thập phân
        }




    }
}
