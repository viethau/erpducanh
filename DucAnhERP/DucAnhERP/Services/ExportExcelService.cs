using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Globalization;
using System.Reflection;
using System.Reflection.PortableExecutable;
using System.Text.RegularExpressions;

public class ExportExcelService
{
    public byte[] ExportToExcelWithComplexHeader<T>(IEnumerable<T> data, List<ComplexHeader> headers, Dictionary<string, ExcelBorderStyle> columnBorders = null)
    {
        try
        {
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("data");

                // Thiết lập kiểu chữ và cỡ chữ mặc định cho toàn bộ worksheet
                worksheet.Cells.Style.Font.Name = "Times New Roman";
                worksheet.Cells.Style.Font.Size = 10;
                var defaultBorderStyle = ExcelBorderStyle.Thin;
                // Thiết lập header phức tạp
                foreach (var header in headers)
                {
                    // Kiểm tra phạm vi cột và dòng
                    if (header.StartCol < 1 || header.EndCol < 1 || header.StartRow < 1 || header.EndRow < 1)
                        throw new ArgumentException("Phạm vi cột hoặc dòng không hợp lệ trong header.");

                    var cellRange = worksheet.Cells[header.StartRow, header.StartCol, header.EndRow, header.EndCol];

                    // Kiểm tra nếu phạm vi các ô đã được merge
                    if (cellRange.Merge == false)
                    {
                        cellRange.Merge = true;
                    }

                    // Thiết lập nội dung và viết hoa chữ cái đầu nếu cần
                    cellRange.Value = header.CapitalizeEachWord
                        ? CultureInfo.CurrentCulture.TextInfo.ToTitleCase(header.Title.ToLower())
                        : header.Title;

                    // Căn chỉnh
                    cellRange.Style.HorizontalAlignment = header.Alignment;

                    // Màu chữ
                    if (header.TextColor.HasValue)
                    {
                        cellRange.Style.Font.Color.SetColor(header.TextColor.Value);
                    }

                    // Cỡ chữ và kiểu chữ
                    cellRange.Style.Font.Size = header.FontSize;
                    cellRange.Style.Font.Name = header.FontName;

                    // Kiểm tra chữ đậm, nghiêng và gạch chân
                    if (header.IsBold)
                    {
                        cellRange.Style.Font.Bold = true;
                    }
                    else
                    {
                        cellRange.Style.Font.Bold = false;
                    }

                    if (header.IsItalic)
                    {
                        cellRange.Style.Font.Italic = true;
                    }
                    else
                    {
                        cellRange.Style.Font.Italic = false;
                    }

                    if (header.IsUnderlined)
                    {
                        cellRange.Style.Font.UnderLine = true;
                    }
                    else
                    {
                        cellRange.Style.Font.UnderLine = false;
                    }

                    // Màu nền
                    if (header.BackgroundColor.HasValue)
                    {
                        cellRange.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        cellRange.Style.Fill.BackgroundColor.SetColor(header.BackgroundColor.Value);
                    }

                    // Bọc chữ trong ô nếu WrapText = true
                    if (header.WrapText)
                    {
                        cellRange.Style.WrapText = true;
                    }

                    // Áp dụng border nếu có
                    if (header.HasBorder)
                    {
                        cellRange.Style.Border.Top.Style = header.BorderStyle;
                        cellRange.Style.Border.Left.Style = header.BorderStyle;
                        cellRange.Style.Border.Bottom.Style = header.BorderStyle;
                        cellRange.Style.Border.Right.Style = header.BorderStyle;
                    }
                }

                // Nếu không có dữ liệu, chỉ render phần header
                if (data == null || !data.Any())
                {
                    return package.GetAsByteArray();  // Trả về chỉ file chứa phần header
                }

                // Ghi dữ liệu
                int dataStartRow = headers.Max(h => h.EndRow) + 1;
                int rowIndex = dataStartRow;
                
                foreach (var item in data)
                {
                    foreach (var header in headers)
                    {
                        if (!string.IsNullOrEmpty(header.DataProperty))
                        {
                            var property = typeof(T).GetProperty(header.DataProperty, BindingFlags.Public | BindingFlags.Instance);
                            if (property != null)
                            {
                                var cell = worksheet.Cells[rowIndex, header.StartCol];

                                // Kiểm tra nếu StartCol không vượt quá cột của worksheet
                                if (header.StartCol > worksheet.Dimension.End.Column)
                                {
                                    throw new ArgumentException("StartCol vượt quá phạm vi cột của worksheet.");
                                }

                                var value = property.GetValue(item);
                                cell.Value = value;

                                // Áp dụng định dạng cột nếu có trong DataFormat
                                if (!string.IsNullOrEmpty(header.DataFormat))
                                {
                                    cell.Style.Numberformat.Format = header.DataFormat;
                                }

                                // Áp dụng border nếu có
                                if (columnBorders != null && columnBorders.ContainsKey(header.DataProperty))
                                {
                                    var borderStyle = columnBorders[header.DataProperty];
                                    cell.Style.Border.Top.Style = borderStyle;
                                    cell.Style.Border.Left.Style = borderStyle;
                                    cell.Style.Border.Bottom.Style = borderStyle;
                                    cell.Style.Border.Right.Style = borderStyle;
                                }
                                else
                                {
                                    // Áp dụng border mặc định
                                    cell.Style.Border.Top.Style = defaultBorderStyle;
                                    cell.Style.Border.Left.Style = defaultBorderStyle;
                                    cell.Style.Border.Bottom.Style = defaultBorderStyle;
                                    cell.Style.Border.Right.Style = defaultBorderStyle;
                                }
                            }
                        }
                    }
                    rowIndex++;
                }

                // Tự động điều chỉnh độ rộng cột
                worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                return package.GetAsByteArray();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }
    }

    public List<ComplexHeader> ParseHtmlToComplexHeader(string html)
    {
        var headers = new List<ComplexHeader>();
        var rowIndex = 16;  // Bắt đầu từ dòng 16 thay vì dòng 
        var colIndex = 1;

        // Sử dụng biểu thức chính quy để tìm tất cả thẻ <th> trong đoạn HTML
        var regex = new Regex(@"<th[^>]*>(.*?)<\/th>", RegexOptions.IgnoreCase);
        var matches = regex.Matches(html);

        foreach (Match match in matches)
        {
            // Lấy tiêu đề và các thuộc tính rowspan, colspan
            var thElement = match.Value;
            var title = match.Groups[1].Value.Trim();
            var rowspan = GetAttributeValue(thElement, "rowspan");
            var colspan = GetAttributeValue(thElement, "colspan");

            // Chuyển đổi giá trị rowspan và colspan thành số (hoặc 1 nếu không có)
            int rowspanValue = string.IsNullOrEmpty(rowspan) ? 1 : int.Parse(rowspan);
            int colspanValue = string.IsNullOrEmpty(colspan) ? 1 : int.Parse(colspan);

            // Tạo đối tượng ComplexHeader cho từng th
            var header = new ComplexHeader
            {
                Title = CapitalizeWords(title),
                StartRow = rowIndex,
                StartCol = colIndex,
                EndRow = rowIndex + rowspanValue - 1,  // Dòng kết thúc = Dòng bắt đầu + rowspan - 1
                EndCol = colIndex + colspanValue - 1,  // Cột kết thúc = Cột bắt đầu + colspan - 1
                TextColor = null,  // Có thể set màu nếu cần
                Alignment = ExcelHorizontalAlignment.Center,  // Giả sử căn giữa
                FontSize = 10,  // Cỡ chữ mặc định
                IsBold = false,  // Có thể thêm điều kiện kiểm tra nếu cần
                WrapText = true  // Giả sử bọc chữ trong ô
            };

            // Thêm ComplexHeader vào danh sách
            headers.Add(header);

            // Tăng cột cho mỗi th
            colIndex += colspanValue;  // Cập nhật cột để tính toán chính xác vị trí cho các th tiếp theo
        }

        return headers;
    }

    private string CapitalizeWords(string input)
    {
        if (string.IsNullOrEmpty(input)) return input;

        var words = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < words.Length; i++)
        {
            var word = words[i];
            words[i] = char.ToUpper(word[0]) + word.Substring(1).ToLower();
        }
        return string.Join(" ", words);
    }

    // Hàm lấy giá trị của thuộc tính trong thẻ HTML
    private string GetAttributeValue(string element, string attribute)
    {
        // Cập nhật Regex để hỗ trợ thêm các khoảng trắng hoặc ký tự khác trước dấu "="
        var regex = new Regex($"{attribute}\\s*=\\s*['\"]([^'\"]+)['\"]", RegexOptions.IgnoreCase);
        var match = regex.Match(element);
        return match.Success ? match.Groups[1].Value : string.Empty;
    }


}
public class ComplexHeader
{
    public string Title { get; set; }
    public int StartRow { get; set; }
    public int StartCol { get; set; }
    public int EndRow { get; set; }
    public int EndCol { get; set; }
    public System.Drawing.Color? TextColor { get; set; } // Màu chữ
    public ExcelHorizontalAlignment Alignment { get; set; } = ExcelHorizontalAlignment.Left; // Căn chỉnh
    public bool CapitalizeEachWord { get; set; } = false; // Viết hoa chữ cái đầu
    public string FontName { get; set; } = "Times New Roman"; // Kiểu chữ mặc định là Times New Roman
    public float FontSize { get; set; } = 10; // Cỡ chữ mặc định là 10
    public bool IsBold { get; set; } = false; // Chữ đậm
    public bool IsItalic { get; set; } = false; // Chữ nghiêng
    public bool IsUnderlined { get; set; } = false; // Chữ gạch chân
    public System.Drawing.Color? BackgroundColor { get; set; } // Màu nền của ô
    public bool WrapText { get; set; } = false; // Bọc chữ trong ô

    // Thêm thuộc tính Border
    public bool HasBorder { get; set; } = false; // Điều kiện để áp dụng border cho ô
    public ExcelBorderStyle BorderStyle { get; set; } = ExcelBorderStyle.Thin; // Kiểu border (mặc định là Thin)
    public string DataFormat { get; set; } = "General";  // Định dạng mặc định cho cột
    public string DataProperty { get; set; }  // Thuộc tính trong model ánh xạ với dữ liệu cột
}


