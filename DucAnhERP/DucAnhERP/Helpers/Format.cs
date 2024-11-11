namespace DucAnhERP.Helpers
{
    public class Format
    {
        // Định dạng số tiền với dấu phân cách hàng nghìn và hai chữ số thập phân, không có đơn vị tiền tệ.
        public static string FormatCurrency(object amount)
        {
            if (double.TryParse(amount.ToString(), out double number))
            {
                return string.Format("{0:N2}", number);
            }
            return amount.ToString(); 
        }

        public static string FormatVND(object amount, string cultureCode = "vi-VN")
        {
            if (double.TryParse(amount.ToString(), out double number))
            {
                var cultureInfo = new System.Globalization.CultureInfo(cultureCode);
                string formatted = number.ToString("C", cultureInfo);
                return formatted.Replace(" ₫", "").Replace("₫", ""); // Loại bỏ các ký hiệu "₫" ở cuối
            }
            return amount.ToString();
        }
    }
}
