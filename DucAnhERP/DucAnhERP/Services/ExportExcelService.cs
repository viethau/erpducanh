using DucAnhERP.ViewModel;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Drawing;
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
                    //Viết hoa tiêu đề
                    string title = header.IsUppercase ? header.Title.ToUpper() : header.Title;
                    // Áp dụng viết hoa chữ cái đầu nếu CapitalizeEachWord = true
                    if (header.CapitalizeEachWord)
                    {
                        title = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(title.ToLower());
                    }
                    cellRange.Value = title;
                    // Căn chỉnh
                    cellRange.Style.HorizontalAlignment = header.Alignment;
                    cellRange.Style.VerticalAlignment = header.VerticalAlignment;

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
                            if(header.DataProperty == "TTKTHHCongHopRanh_CCaoChatmatNgoai")
                            {
                                Console.WriteLine("TTKTHHCongHopRanh_CCaoChatmatNgoai");
                            }
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

    public byte[] ExportToExcelWithMultipleSheets<T>(List<SheetInfo<T>> sheets, Dictionary<string, ExcelBorderStyle> columnBorders = null)
    {
        try
        {
            using (var package = new ExcelPackage())
            {
                // Duyệt qua từng sheet trong danh sách sheets
                foreach (var sheetInfo in sheets)
                {
                    // Tạo worksheet mới với tên sheet tương ứng
                    var worksheet = package.Workbook.Worksheets.Add(sheetInfo.SheetName);

                    // Thiết lập kiểu chữ và cỡ chữ mặc định cho toàn bộ worksheet
                    worksheet.Cells.Style.Font.Name = "Times New Roman";
                    worksheet.Cells.Style.Font.Size = 10;
                    var defaultBorderStyle = ExcelBorderStyle.Thin;

                    // Thiết lập header phức tạp cho sheet hiện tại
                    foreach (var header in sheetInfo.Headers)
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

                        //Viết hoa tiêu đề
                        string title = header.IsUppercase ? header.Title.ToUpper() : header.Title;
                        // Áp dụng viết hoa chữ cái đầu nếu CapitalizeEachWord = true
                        if (header.CapitalizeEachWord)
                        {
                            title = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(title.ToLower());
                        }
                        cellRange.Value = title;

                        // Căn chỉnh
                        cellRange.Style.HorizontalAlignment = header.Alignment;
                        cellRange.Style.VerticalAlignment = header.VerticalAlignment;

                        // Màu chữ
                        if (header.TextColor.HasValue)
                        {
                            cellRange.Style.Font.Color.SetColor(header.TextColor.Value);
                        }

                        // Cỡ chữ và kiểu chữ
                        cellRange.Style.Font.Size = header.FontSize;
                        cellRange.Style.Font.Name = header.FontName;

                        // Kiểm tra chữ đậm, nghiêng và gạch chân
                        cellRange.Style.Font.Bold = header.IsBold;
                        cellRange.Style.Font.Italic = header.IsItalic;
                        cellRange.Style.Font.UnderLine = header.IsUnderlined;

                        // Màu nền
                        if (header.BackgroundColor.HasValue)
                        {
                            cellRange.Style.Fill.PatternType = ExcelFillStyle.Solid;
                            cellRange.Style.Fill.BackgroundColor.SetColor(header.BackgroundColor.Value);
                        }

                        // Bọc chữ trong ô nếu WrapText = true
                        cellRange.Style.WrapText = header.WrapText;

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
                    if (sheetInfo.Data == null || !sheetInfo.Data.Any())
                    {
                        continue; // Bỏ qua và chuyển sang sheet tiếp theo
                    }

                    // Ghi dữ liệu vào sheet hiện tại
                    int dataStartRow = sheetInfo.Headers.Max(h => h.EndRow) + 1;
                    int rowIndex = dataStartRow;

                    foreach (var item in sheetInfo.Data)
                    {
                        foreach (var header in sheetInfo.Headers)
                        {
                            if (!string.IsNullOrEmpty(header.DataProperty))
                            {
                                //var property = typeof(T).GetProperty(header.DataProperty, BindingFlags.Public | BindingFlags.Instance);
                                var property = item.GetType().GetProperty(header.DataProperty, BindingFlags.Public | BindingFlags.Instance);
                                if (property != null)
                                {
                                    var cell = worksheet.Cells[rowIndex, header.StartCol];
                                    var value = property.GetValue(item); // Lấy giá trị từ thuộc tính
                                    cell.Value = value; // Gán giá trị vào ô

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
                }

                return package.GetAsByteArray();
            }
        }
        catch (Exception ex)
        {
            throw new Exception($"Lỗi khi xuất file excel {ex.Message}");
        }
    }

    public byte[] ExportToExcelWithMultipleTables<T>(List<SheetInfo1<T>> sheets, RowSpace rowSpace = null)
    {
        try
        {
            using (var package = new ExcelPackage())
            {
                foreach (var sheetInfo in sheets)
                {
                    var worksheet = package.Workbook.Worksheets.Add(sheetInfo.SheetName);

                    // Thiết lập kiểu chữ và cỡ chữ mặc định cho toàn bộ worksheet
                    worksheet.Cells.Style.Font.Name = "Times New Roman";
                    worksheet.Cells.Style.Font.Size = 10;

                    int currentCol = 1; // Theo dõi cột hiện tại

                    foreach (var tableInfo in sheetInfo.Tables)
                    {
                        // Thêm headers của bảng
                        foreach (var header in tableInfo.Headers)
                        {
                            var cellRange = worksheet.Cells[header.StartRow, currentCol + header.StartCol - 1, header.EndRow, currentCol + header.EndCol - 1];

                            if (cellRange.Merge == false)
                            {
                                cellRange.Merge = true;
                            }

                            //Viết hoa tiêu đề
                            string title = header.IsUppercase ? header.Title.ToUpper() : header.Title;
                            // Áp dụng viết hoa chữ cái đầu nếu CapitalizeEachWord = true
                            if (header.CapitalizeEachWord)
                            {
                                title = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(title.ToLower());
                            }
                            cellRange.Value = title;

                            cellRange.Style.HorizontalAlignment = header.Alignment;
                            cellRange.Style.VerticalAlignment = header.VerticalAlignment;

                            if (header.TextColor.HasValue)
                            {
                                cellRange.Style.Font.Color.SetColor(header.TextColor.Value);
                            }

                            cellRange.Style.Font.Size = header.FontSize;
                            cellRange.Style.Font.Name = header.FontName;
                            cellRange.Style.Font.Bold = true;
                            cellRange.Style.Font.Italic = header.IsItalic;
                            cellRange.Style.Font.UnderLine = header.IsUnderlined;

                            if (header.BackgroundColor.HasValue)
                            {
                                cellRange.Style.Fill.PatternType = ExcelFillStyle.Solid;
                                cellRange.Style.Fill.BackgroundColor.SetColor(header.BackgroundColor.Value);
                            }

                            //cellRange.Style.WrapText = header.WrapText;

                            if (header.HasBorder)
                            {
                                cellRange.Style.Border.Top.Style = header.BorderStyle;
                                cellRange.Style.Border.Left.Style = header.BorderStyle;
                                cellRange.Style.Border.Bottom.Style = header.BorderStyle;
                                cellRange.Style.Border.Right.Style = header.BorderStyle;
                            }
                            // Tính toán và đặt chiều cao hàng để hiển thị đầy đủ nội dung
                            double fontSize = header.FontSize;
                            int lineCount = title.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries).Length; // Đếm số dòng
                            double rowHeight = lineCount * fontSize * 1.5; // Ước lượng chiều cao hàng (1.5 là hệ số)
                            worksheet.Row(header.StartRow).Height = rowHeight;
                        }

                        // Thêm dữ liệu của bảng
                        int dataStartRow = tableInfo.Headers.Max(h => h.EndRow) + 1;
                        int rowIndex = dataStartRow;
                        // Biến đếm số thứ tự (STT)
                        int stt = 1;
                        string previousLoaiCK = null;
                        string previousChild = null;
                        int maxEndCol = tableInfo.Headers.Where(h => !string.IsNullOrEmpty(h.DataProperty)).Max(h => h.EndCol); // Lấy EndCol lớn nhất
                        foreach (var item in tableInfo.Data)
                        {
                            // Kiểm tra và thêm dòng gộp nếu LoaiCK thay đổi
                            if (rowSpace != null)
                            {
                                var propertyLoaiCK = item.GetType().GetProperty(rowSpace.DataProperty, BindingFlags.Public | BindingFlags.Instance);
                                if (propertyLoaiCK != null)
                                {
                                    var currentLoaiCK = propertyLoaiCK.GetValue(item)?.ToString();

                                    // Nếu LoaiCK thay đổi so với giá trị trước đó
                                    if (!string.IsNullOrEmpty(currentLoaiCK) && currentLoaiCK != previousLoaiCK)
                                    {
                                        stt = 1;
                                        // Tô màu nền cả dòng màu vàng (trừ cột thứ 2)
                                        for (int col = currentCol; col <= currentCol + maxEndCol - 1; col++)
                                        {
                                            if (col != currentCol + 1) // Bỏ qua cột thứ 2
                                            {
                                                var cell = worksheet.Cells[rowIndex, col];
                                                cell.Style.Fill.PatternType = ExcelFillStyle.Solid;
                                                cell.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.Yellow);
                                            }
                                        }

                                        // Thêm border từ currentCol đến currentCol + maxEndCol - 1
                                        var rowRange = worksheet.Cells[rowIndex, currentCol, rowIndex, currentCol + maxEndCol - 1];
                                        rowRange.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                                        rowRange.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                                        rowRange.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                                        rowRange.Style.Border.Right.Style = ExcelBorderStyle.Thin;

                                        // Tô màu nền cột thứ 2 trong dòng màu light green và chữ in đậm
                                        var secondColumnCell = worksheet.Cells[rowIndex, currentCol + 1];
                                        secondColumnCell.Style.Fill.PatternType = ExcelFillStyle.Solid;
                                        secondColumnCell.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGreen);
                                        secondColumnCell.Style.Font.Bold = true;
                                        secondColumnCell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                                        secondColumnCell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                                        //secondColumnCell.Style.WrapText = true;
                                        // Đặt giá trị cho cột thứ 2
                                        secondColumnCell.Value = $"{currentLoaiCK}";

                                        rowIndex++; // Tăng chỉ số hàng

                                    }

                                    previousLoaiCK = currentLoaiCK; // Cập nhật giá trị LoaiCK trước đó
                                }
                                // Áp dụng các level con
                                foreach (var child in rowSpace.Children)
                                {
                                    var propertyChild = item.GetType().GetProperty(child.DataProperty, BindingFlags.Public | BindingFlags.Instance);
                                    if (propertyChild != null)
                                    {
                                        var currentChild = propertyChild.GetValue(item)?.ToString();
                                        var splitString = SplitString(currentChild??"");
                                        // Nếu LoaiCK thay đổi so với giá trị trước đó
                                        if (!string.IsNullOrEmpty(currentChild) && currentChild != previousChild)
                                        {
                                            stt = 1;
                                            // Tô màu nền cả dòng màu vàng (trừ cột thứ 2)
                                            for (int col = currentCol; col <= currentCol + maxEndCol - 1; col++)
                                            {
                                                var cell = worksheet.Cells[rowIndex, col];
                                                cell.Style.Fill.PatternType = ExcelFillStyle.Solid;
                                                cell.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.Yellow);
                                                cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                                                cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                                            }

                                            // Thêm border từ currentCol đến currentCol + maxEndCol - 1
                                            var rowRange = worksheet.Cells[rowIndex, currentCol, rowIndex, currentCol + maxEndCol - 1];
                                            rowRange.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                                            rowRange.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                                            rowRange.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                                            rowRange.Style.Border.Right.Style = ExcelBorderStyle.Thin;

                                            // Tô màu nền cột thứ 2 trong dòng màu light green và chữ in đậm
                                            var secondColumnCell = worksheet.Cells[rowIndex, currentCol];
                                            secondColumnCell.Style.Font.Bold = true;
                                            secondColumnCell.Style.Font.Color.SetColor(Color.Red);
                                            secondColumnCell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                                            secondColumnCell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                                            secondColumnCell.Value = $"{splitString.Item1}";

                                            // Đặt giá trị cho cột thứ 2

                                            var mergeRange = worksheet.Cells[rowIndex, currentCol + 3, rowIndex, currentCol + 4];
                                            mergeRange.Merge = true;
                                            mergeRange.Style.Font.Bold = true;
                                            mergeRange.Style.Font.Color.SetColor(Color.Red);
                                            mergeRange.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                                            mergeRange.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                                            //mergeRange.Style.WrapText = true;
                                            mergeRange.Value = $"{splitString.Item2} {previousLoaiCK}";

                                            rowIndex++; // Tăng chỉ số hàng

                                        }

                                        previousChild = currentChild; // Cập nhật giá trị trước đó
                                    }
                                }
                            }


                            foreach (var header in tableInfo.Headers)
                            {

                                if (!string.IsNullOrEmpty(header.DataProperty))
                                {
                                    var cell = worksheet.Cells[rowIndex, currentCol + header.StartCol - 1];

                                    // Áp dụng các thuộc tính định dạng từ header cho ô dữ liệu
                                    cell.Style.Font.Name = header.FontName; // Kiểu chữ
                                    cell.Style.Font.Color.SetColor(header.TextColor ?? System.Drawing.Color.Black); // Màu chữ
                                    cell.Style.Fill.PatternType = ExcelFillStyle.Solid; // Tô màu nền
                                    cell.Style.Fill.BackgroundColor.SetColor(header.BackgroundColor ?? System.Drawing.Color.White); // Màu nền
                                    cell.Style.HorizontalAlignment = header.Alignment; // Căn chỉnh ngang
                                    cell.Style.VerticalAlignment = header.VerticalAlignment; // Căn chỉnh dọc
                                    //cell.Style.WrapText = header.WrapText; // Tự động ngắt dòng
                                    cell.Style.Font.Bold = header.IsBold;
                                    // Áp dụng border nếu có
                                    if (header.HasBorder)
                                    {
                                        cell.Style.Border.Top.Style = header.BorderStyle;
                                        cell.Style.Border.Left.Style = header.BorderStyle;
                                        cell.Style.Border.Bottom.Style = header.BorderStyle;
                                        cell.Style.Border.Right.Style = header.BorderStyle;
                                    }


                                    // Nếu DataProperty là "STT", điền số thứ tự
                                    if (header.DataProperty == "STT")
                                    {
                                        cell.Value = stt;
                                        if (!string.IsNullOrEmpty(header.DataFormat))
                                        {
                                            cell.Style.Numberformat.Format = header.DataFormat;
                                        }
                                        cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                                        cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                                        // Áp dụng border nếu có
                                        cell.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                                        cell.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                                        cell.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                                        cell.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                                    }
                                    else
                                    {
                                        var property = item.GetType().GetProperty(header.DataProperty, BindingFlags.Public | BindingFlags.Instance);
                                        if (property != null)
                                        {
                                            var value = property.GetValue(item);
                                            cell.Value = value;

                                            if (!string.IsNullOrEmpty(header.DataFormat))
                                            {
                                                cell.Style.Numberformat.Format = header.DataFormat;
                                            }

                                            // Áp dụng border nếu có
                                            cell.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                                            cell.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                                            cell.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                                            cell.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                                        }
                                    }
                                    
                                }
                            }
                            stt++;
                            rowIndex++;
                        }

                        // Thêm cột ngăn cách 
                        int nextCol = currentCol + tableInfo.Headers.Max(h => h.EndCol);

                        // Kiểm tra xem còn dữ liệu ở sau không
                        bool hasMoreTables = sheetInfo.Tables.IndexOf(tableInfo) < sheetInfo.Tables.Count - 1;

                        // Nếu còn dữ liệu, thêm cột ngăn cách và tô màu xanh da trời
                        if (hasMoreTables)
                        {
                            // Tô màu xanh da trời cho cột ngăn cách
                            var separatorCol = worksheet.Cells[16, nextCol, rowIndex - 1, nextCol];
                            separatorCol.Style.Fill.PatternType = ExcelFillStyle.Solid;
                            separatorCol.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightBlue);

                            // Gộp các dòng từ dòng 16 trở đi
                            for (int i = 16; i <= rowIndex - 1; i++)
                            {
                                worksheet.Cells[i, nextCol].Merge = true;
                            }
                        }

                        // Di chuyển sang vị trí cột tiếp theo
                        currentCol = nextCol + 1;

                    }

                    // Tự động điều chỉnh chiều rộng cột nếu cần
                    worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();
                }

                return package.GetAsByteArray();
            }
        }
        catch (Exception ex)
        {
            throw new Exception($"Lỗi khi xuất file Excel: {ex.Message}");
        }


    }


    public static byte[] MergeExcelFiles(params byte[][] excelFiles)
    {
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

        using var mergedPackage = new ExcelPackage();

        foreach (var file in excelFiles)
        {
            using var stream = new MemoryStream(file);
            using var package = new ExcelPackage(stream);

            foreach (var sheet in package.Workbook.Worksheets)
            {
                // Tạo một sheet mới trong file đích với tên giống sheet gốc
                var newSheet = mergedPackage.Workbook.Worksheets.Add(sheet.Name, sheet);
            }
        }

        return mergedPackage.GetAsByteArray();
    }

    public List<ComplexHeader> ParseHtmlToComplexHeaders(string html)
    {
        var headers = new List<ComplexHeader>();
        int rowIndex = 16;

        // Tách từng hàng <tr>
        var rows = Regex.Matches(html, @"<tr.*?>(.*?)<\/tr>", RegexOptions.Singleline);
        foreach (Match row in rows)
        {
            int colIndex = 1;

            // Tách từng ô <th> hoặc <td>
            var cells = Regex.Matches(row.Groups[1].Value, @"<th.*?>(.*?)<\/th>", RegexOptions.Singleline);
            foreach (Match cell in cells)
            {
                // Lấy nội dung tiêu đề
                string title = ExtractTextFromHtml(cell.Value);
 
                // Tìm giá trị onclick và trích xuất dataProperty từ nó
                string dataProperty = GetDataPropertyFromOnClick(cell.Value);
                // Tìm các thuộc tính rowspan và colspan
                int rowspan = GetAttributeValue(cell.Value, "rowspan", 1);
                int colspan = GetAttributeValue(cell.Value, "colspan", 1);

                headers.Add(new ComplexHeader
                {
                    Title = title,
                    StartRow = rowIndex,
                    EndRow = rowIndex + rowspan - 1,
                    StartCol = colIndex,
                    EndCol = colIndex + colspan - 1,
                    IsBold = cell.Value.Contains("bold"),
                    HasBorder = true,
                    //WrapText = true,
                    Alignment = ExcelHorizontalAlignment.Center,
                    DataProperty = dataProperty,
                });

                colIndex += colspan;
            }

            rowIndex++;
        }

        return headers;
    }
    static string GetDataPropertyFromOnClick(string html)
    {
        var match = Regex.Match(html, @"SortTable\(['""]?([^'""]+)['""]?\)", RegexOptions.IgnoreCase);
        return match.Success ? match.Groups[1].Value : null;  // Trả về giá trị trích được từ onclick
    }
    static int GetAttributeValue(string tag, string attribute, int defaultValue)
    {
        var match = Regex.Match(tag, $@"{attribute}\s*=\s*['""]?(\d+)['""]?", RegexOptions.IgnoreCase);
        return match.Success ? int.Parse(match.Groups[1].Value) : defaultValue;
    }
    public static string ExtractTextFromHtml(string input)
    {
        // Trường hợp 1: Nếu có thẻ <div> và <span>
        string pattern1 = @"<div[^>]*>\s*(.*?)\s*<span";
        Match match1 = Regex.Match(input, pattern1);

        if (match1.Success)
        {
            return match1.Groups[1].Value.Trim();
        }

        // Trường hợp 2: Nếu chỉ có thẻ <th> với nội dung trực tiếp
        string pattern2 = @"<th[^>]*>\s*(.*?)\s*</th>";
        Match match2 = Regex.Match(input, pattern2);

        if (match2.Success)
        {
            return match2.Groups[1].Value.Trim();
        }

        // Trả về chuỗi rỗng nếu không khớp với trường hợp nào
        return string.Empty;
    }

    public static (string, string) SplitString(string input)
    {
        // Biểu thức chính quy để tách phần số La Mã/số thứ tự và phần nội dung
        string pattern = @"^([IVXLCDM]+(?:\.\d+)?)\s*(.*)";
        var match = Regex.Match(input, pattern);

        if (match.Success)
        {
            string numberPart = match.Groups[1].Value; // Phần số La Mã/số thứ tự
            string contentPart = match.Groups[2].Value.Trim(); // Phần nội dung
            contentPart = contentPart.TrimStart('.', ',').Trim();
            return (numberPart, contentPart);
        }

        // Trường hợp không khớp, trả về chuỗi gốc và chuỗi rỗng
        return (string.Empty, input);
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
    public ExcelVerticalAlignment VerticalAlignment { get; set; } = ExcelVerticalAlignment.Center; // Căn chỉnh
    public bool CapitalizeEachWord { get; set; } = false; // Viết hoa chữ cái đầu
    public bool IsUppercase { get; set; } = false;// Viết hoa toàn bộ
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

public class SheetInfo<T>
{
    public string SheetName { get; set; } // Tên của sheet
    public List<ComplexHeader> Headers { get; set; } // Danh sách header của sheet
    public IEnumerable<T> Data { get; set; } // Dữ liệu của sheet
}

public class TableInfo<T>
{
    public List<ComplexHeader> Headers { get; set; } // Danh sách header của bảng
    public IEnumerable<T> Data { get; set; } // Dữ liệu của bảng
}

public class SheetInfo1<T>
{
    public string SheetName { get; set; } // Tên của sheet
    public List<TableInfo<T>> Tables { get; set; } // Danh sách các bảng dữ liệu trên sheet
}

public class RowSpace
{
    public string DataProperty { get; set; } // Tên biến
    public System.Drawing.Color? BackgroundColor { get; set; } // Màu nền của ô
    public List<RowSpace> Children { get; set; } = new List<RowSpace>(); // Danh sách các level con
}