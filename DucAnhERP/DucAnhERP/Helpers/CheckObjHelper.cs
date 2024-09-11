using System.Reflection;

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
    }
}

