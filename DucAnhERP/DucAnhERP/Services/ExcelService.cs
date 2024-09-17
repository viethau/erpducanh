using DucAnhERP.SeedWork;
using OfficeOpenXml;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace DucAnhERP.Services
{
    public interface IExcelRepository
    {
        Task<List<ExcelData>> ReadExcelDataAsync(Stream excelStream);
    }

    public class ExcelRepository : IExcelRepository
    {
        public ExcelRepository()
        {
            // Đặt LicenseContext cho EPPlus
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        }
        public async Task<List<ExcelData>> ReadExcelDataAsync(Stream excelStream)
        {
            var result = new List<ExcelData>();
            try
            {
              
                using (var package = new OfficeOpenXml.ExcelPackage(excelStream))
                {
                    if (package.Workbook.Worksheets.Count == 0)
                        throw new Exception("No worksheets found in Excel file.");

                    var worksheet = package.Workbook.Worksheets.First();
                    if (worksheet.Dimension == null)
                        throw new Exception("Worksheet has no content.");

                    var rowCount = worksheet.Dimension.Rows;
                    var colCount = worksheet.Dimension.Columns;

                    for (int row = 4; row <= rowCount; row++)
                    {
                        var data = new ExcelData();
                        bool hasData = false;
                        for (int col = 1; col <= colCount; col++)
                        {
                            var cellValue = worksheet.Cells[row, col].Text;
                            if (!string.IsNullOrEmpty(cellValue))
                            {
                                hasData = true;
                            }
                            data.RowData.Add(cellValue);
                        }
                        if (hasData)
                        {
                            result.Add(data);
                        }
                      
                    }
                }

                return await Task.FromResult(result);
            }
            catch (Exception ex) {
            
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }

}
