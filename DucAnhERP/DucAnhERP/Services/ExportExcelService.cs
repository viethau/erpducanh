using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Globalization;
using System.Reflection;
using System.Reflection.PortableExecutable;
using System.Text.RegularExpressions;

public class ExportExcelService
{
    //public byte[] ExportToExcelWithComplexHeader<T>(IEnumerable<T> data, List<ComplexHeader> headers, Dictionary<string, string> columnMappings, Dictionary<string, string> columnFormats, Dictionary<string, ExcelBorderStyle> columnBorders = null)
    //{
    //    try
    //    {
    //        if (data == null || !data.Any()) throw new ArgumentException("Dữ liệu để xuất không được rỗng.");

    //        using (var package = new ExcelPackage())
    //        {
    //            var worksheet = package.Workbook.Worksheets.Add("data");

    //            // Thiết lập kiểu chữ và cỡ chữ mặc định cho toàn bộ worksheet
    //            worksheet.Cells.Style.Font.Name = "Times New Roman";
    //            worksheet.Cells.Style.Font.Size = 10;

    //            // Thiết lập header phức tạp
    //            foreach (var header in headers)
    //            {
    //                var cellRange = worksheet.Cells[header.StartRow, header.StartCol, header.EndRow, header.EndCol];

    //                // Kiểm tra nếu phạm vi các ô đã được merge
    //                if (cellRange.Merge == false)
    //                {
    //                    cellRange.Merge = true;
    //                }

    //                // Thiết lập nội dung và viết hoa chữ cái đầu nếu cần
    //                cellRange.Value = header.CapitalizeEachWord
    //                    ? CultureInfo.CurrentCulture.TextInfo.ToTitleCase(header.Title.ToLower())
    //                    : header.Title;

    //                // Căn chỉnh
    //                cellRange.Style.HorizontalAlignment = header.Alignment;

    //                // Màu chữ
    //                if (header.TextColor.HasValue)
    //                {
    //                    cellRange.Style.Font.Color.SetColor(header.TextColor.Value);
    //                }

    //                // Cỡ chữ và kiểu chữ
    //                cellRange.Style.Font.Size = header.FontSize;
    //                cellRange.Style.Font.Name = header.FontName;

    //                // Kiểm tra chữ đậm, nghiêng và gạch chân
    //                if (header.IsBold)
    //                {
    //                    cellRange.Style.Font.Bold = true;
    //                }
    //                else
    //                {
    //                    cellRange.Style.Font.Bold = false;
    //                }

    //                if (header.IsItalic)
    //                {
    //                    cellRange.Style.Font.Italic = true;
    //                }
    //                else
    //                {
    //                    cellRange.Style.Font.Italic = false;
    //                }

    //                if (header.IsUnderlined)
    //                {
    //                    cellRange.Style.Font.UnderLine = true;
    //                }
    //                else
    //                {
    //                    cellRange.Style.Font.UnderLine = false;
    //                }

    //                // Màu nền
    //                if (header.BackgroundColor.HasValue)
    //                {
    //                    cellRange.Style.Fill.PatternType = ExcelFillStyle.Solid;
    //                    cellRange.Style.Fill.BackgroundColor.SetColor(header.BackgroundColor.Value);
    //                }

    //                // Bọc chữ trong ô nếu WrapText = true
    //                if (header.WrapText)
    //                {
    //                    cellRange.Style.WrapText = true;
    //                }

    //                // Áp dụng border nếu có
    //                if (header.HasBorder)
    //                {
    //                    cellRange.Style.Border.Top.Style = header.BorderStyle;
    //                    cellRange.Style.Border.Left.Style = header.BorderStyle;
    //                    cellRange.Style.Border.Bottom.Style = header.BorderStyle;
    //                    cellRange.Style.Border.Right.Style = header.BorderStyle;
    //                }
    //            }

    //            // Ghi dữ liệu
    //            int dataStartRow = headers.Max(h => h.EndRow) + 1;
    //            int rowIndex = dataStartRow;
    //            // Nếu không có columnBorders được định nghĩa, sử dụng ExcelBorderStyle.Thin mặc định
    //            var defaultBorderStyle = ExcelBorderStyle.Thin;
    //            foreach (var item in data)
    //            {
    //                int colIndex = 1;
    //                foreach (var column in columnMappings)
    //                {
    //                    var property = typeof(T).GetProperty(column.Key, BindingFlags.Public | BindingFlags.Instance);
    //                    if (property != null)
    //                    {
    //                        var cell = worksheet.Cells[rowIndex, colIndex];
    //                        var value = property.GetValue(item);

    //                        cell.Value = value;

    //                        // Áp dụng định dạng cột nếu được chỉ định
    //                        if (columnFormats != null && columnFormats.ContainsKey(column.Key))
    //                        {
    //                            cell.Style.Numberformat.Format = columnFormats[column.Key];
    //                        }
    //                        // Áp dụng border nếu có trong columnBorders, nếu không dùng mặc định
    //                        if (columnBorders != null && columnBorders.ContainsKey(column.Key))
    //                        {
    //                            var borderStyle = columnBorders[column.Key];
    //                            cell.Style.Border.Top.Style = borderStyle;
    //                            cell.Style.Border.Left.Style = borderStyle;
    //                            cell.Style.Border.Bottom.Style = borderStyle;
    //                            cell.Style.Border.Right.Style = borderStyle;
    //                        }
    //                        else
    //                        {
    //                            // Nếu không có border được định nghĩa cho cột, áp dụng border mặc định
    //                            cell.Style.Border.Top.Style = defaultBorderStyle;
    //                            cell.Style.Border.Left.Style = defaultBorderStyle;
    //                            cell.Style.Border.Bottom.Style = defaultBorderStyle;
    //                            cell.Style.Border.Right.Style = defaultBorderStyle;
    //                        }
    //                        colIndex++;
    //                    }
    //                }
    //                rowIndex++;
    //            }

    //            // Tự động điều chỉnh độ rộng cột
    //            worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

    //            // Xuất ra mảng byte
    //            return package.GetAsByteArray();
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        Console.WriteLine(ex.Message);
    //        throw;
    //    }
    //}

    public byte[] ExportToExcelWithComplexHeader<T>(IEnumerable<T> data, List<ComplexHeader> headers , Dictionary<string, ExcelBorderStyle> columnBorders = null)
    {
        try
        {
            if (data == null || !data.Any()) throw new ArgumentException("Dữ liệu để xuất không được rỗng.");

            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("data");

                // Thiết lập kiểu chữ và cỡ chữ mặc định cho toàn bộ worksheet
                worksheet.Cells.Style.Font.Name = "Times New Roman";
                worksheet.Cells.Style.Font.Size = 10;

                // Thiết lập header phức tạp
                foreach (var header in headers)
                {
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

                    if (header.IsItalic)
                    {
                        cellRange.Style.Font.Italic = true;
                    }

                    if (header.IsUnderlined)
                    {
                        cellRange.Style.Font.UnderLine = true;
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

                // Ghi dữ liệu
                int dataStartRow = headers.Max(h => h.EndRow) + 1;
                int rowIndex = dataStartRow;
                var defaultBorderStyle = ExcelBorderStyle.Thin;
                foreach (var item in data)
                {
                    int colIndex = 1;
                    foreach (var header in headers)
                    {
                        var property = typeof(T).GetProperty(header.DataProperty, BindingFlags.Public | BindingFlags.Instance);
                        if (property != null)
                        {
                            var cell = worksheet.Cells[rowIndex, colIndex];
                            var value = property.GetValue(item);

                            cell.Value = value;

                            // Áp dụng định dạng cột nếu có trong DataFormat
                            if (!string.IsNullOrEmpty(header.DataFormat))
                            {
                                cell.Style.Numberformat.Format = header.DataFormat;
                            }

                            // Áp dụng border nếu có trong columnBorders, nếu không dùng mặc định
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
                                // Nếu không có border được định nghĩa cho cột, áp dụng border mặc định
                                cell.Style.Border.Top.Style = defaultBorderStyle;
                                cell.Style.Border.Left.Style = defaultBorderStyle;
                                cell.Style.Border.Bottom.Style = defaultBorderStyle;
                                cell.Style.Border.Right.Style = defaultBorderStyle;
                            }

                            colIndex++;
                        }
                    }
                    rowIndex++;
                }

                // Tự động điều chỉnh độ rộng cột
                worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                // Xuất ra mảng byte
                return package.GetAsByteArray();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }
    }

    public List<ComplexHeader> ConvertHtmlToComplexHeaders(string html)
    {
        var headers = new List<ComplexHeader>();

        // Biểu thức chính quy để tìm các thẻ <th> trong HTML
        string thPattern = @"<th[^>]*>(.*?)</th>";
        Regex thRegex = new Regex(thPattern, RegexOptions.IgnoreCase);

        var matches = thRegex.Matches(html);
        int row = 16; // Dòng bắt đầu
        int col = 1; // Cột bắt đầu

        foreach (Match match in matches)
        {
            string thContent = match.Groups[1].Value.Trim();
            string classAttribute = match.Value.ToLower();

            // Kiểm tra thuộc tính rowspan, colspan
            int rowspan = GetRowspan(match);
            int colspan = GetColspan(match);

            // Nếu không có rowspan hoặc colspan, giả sử là 1
            rowspan = rowspan == 0 ? 1 : rowspan;
            colspan = colspan == 0 ? 1 : colspan;

            // Tạo ComplexHeader mới
            headers.Add(new ComplexHeader
            {
                Title = thContent,
                StartRow = row,
                StartCol = col,
                EndRow = row + rowspan - 1,
                EndCol = col + colspan - 1,
                IsBold = classAttribute.Contains("text-center"), // Giả sử là chữ đậm khi có "text-center"
                HasBorder = true, // Thêm viền mặc định
                Alignment = ExcelHorizontalAlignment.Center // Căn giữa mặc định
            });

            // Cập nhật cột cho phần tiếp theo
            col += colspan;
        }

        return headers;
    }

    private int GetRowspan(Match match)
    {
        var rowspanMatch = Regex.Match(match.Value, @"rowspan=""(\d+)""", RegexOptions.IgnoreCase);
        return rowspanMatch.Success ? int.Parse(rowspanMatch.Groups[1].Value) : 1;
    }

    private int GetColspan(Match match)
    {
        var colspanMatch = Regex.Match(match.Value, @"colspan=""(\d+)""", RegexOptions.IgnoreCase);
        return colspanMatch.Success ? int.Parse(colspanMatch.Groups[1].Value) : 1;
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


