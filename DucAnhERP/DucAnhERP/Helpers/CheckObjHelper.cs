using System.Reflection;
using System.Text.RegularExpressions;

namespace DucAnhERP.Helpers
{
    public class CheckObjHelper
    {
        // Hàm kiểm tra tất cả các thuộc tính kiểu double và double? trong obj có > 0 không
        public bool AreAllDoublePropertiesGreaterThanZero(object obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            // Lấy tất cả các thuộc tính của đối tượng
            PropertyInfo[] properties = obj.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var property in properties)
            {
                // Kiểm tra nếu thuộc tính là kiểu double hoặc Nullable<double> (double?)
                if (property.PropertyType == typeof(double) || property.PropertyType == typeof(double?))
                {
                    // Lấy giá trị của thuộc tính
                    var value = property.GetValue(obj);

                    // Nếu giá trị không null, kiểm tra nếu != 0 thì trả về false
                    if (value != null && (double)value != 0)
                    {
                        return true;
                    }
                }
            }

            // Nếu tất cả các thuộc tính double đều > 0 hoặc null thì trả về true
            return false;
        }

        public static string UpdateSoHieu(string soHieu, int delta = -1)
        {
            if (string.IsNullOrEmpty(soHieu))
            {
                return soHieu; // Trả về giá trị gốc nếu `SoHieu` rỗng hoặc null
            }

            // Sử dụng Regex để phân tách phần chữ và số
            var match = Regex.Match(soHieu, @"^([A-Za-z]*)(\d+)$");
            if (match.Success)
            {
                string prefix = match.Groups[1].Value; // Phần chữ, ví dụ: "B", "N"
                string numberPart = match.Groups[2].Value; // Phần số, ví dụ: "01"

                // Tăng hoặc giảm phần số
                int number = int.Parse(numberPart);
                int newNumber = number + delta;

                // Đảm bảo không có số âm
                if (newNumber < 0)
                {
                    throw new ArgumentException($"Giá trị số hiệu không thể nhỏ hơn 0: {soHieu}");
                }

                // Giữ nguyên định dạng độ dài của phần số
                string formattedNumber = newNumber.ToString(new string('0', numberPart.Length));

                return $"{prefix}{formattedNumber}";
            }

            // Nếu không khớp định dạng, trả về `SoHieu` gốc
            return soHieu;
        }
    }
}

