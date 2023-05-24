//using System.Collections.Generic;
//using lib_barcode.api.DTO;
//using lib_barcode.api.Models;
//using OfficeOpenXml;

//namespace api_bharat_lawns.Helper
//{
//    public class FileHelper : IFileHelper<Cell>
//    {

//        public async Task<dynamic> GetExcelDataAsync(IFormFile excellFile)
//        {
//            var list = new List<Cell>();
//            var errorsList = new List<ExcelError>();
//            using (var stream = new MemoryStream())
//            {
//                await excellFile.CopyToAsync(stream);

//                using (var package = new ExcelPackage(stream))
//                {
//                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
//                    var rowCount = worksheet.Dimension.Rows;

//                    for (int row = 2; row <= rowCount; row++)
//                    {
//                        try
//                        {
//                            var col1 = worksheet.Cells[row, 1].Value?.ToString()?.Trim();
//                            var col2 = worksheet.Cells[row, 2].Value?.ToString()?.Trim();
//                            if (String.IsNullOrEmpty(col1) || String.IsNullOrEmpty(col2))
//                                continue;
//                            list.Add(new Cell
//                            {
//                                Barcode = col1,
//                                Capacity = float.Parse(col2)
//                            });
//                        }
//                        catch (Exception ex)
//                        {
//                            //To be implemented write error row wise in excel or return error file
//                            var excelError = new ExcelError
//                            {
//                                Row = row,
//                                Message = ex.Message
//                            };
//                            errorsList.Add(excelError);
//                            continue;
//                        }
//                    }
//                }
//            }
//            return new { cellsList = list, errorsList = errorsList};
//        }

//        public async Task<string> SaveFileAsync(IFormFile file, string path)
//        {
//            if (!Directory.Exists(path))
//            {
//                Directory.CreateDirectory(path);
//            }
//            var fileName = string.Concat(Path.GetFileNameWithoutExtension(file.FileName),
//                                          "_",
//                                          DateTime.Now.ToString("yyyyMMddTHHmmss"),
//                                          Path.GetExtension(file.FileName));
//            var pathWithName = Path.Combine(path, fileName);
//            using (FileStream stream = new FileStream(pathWithName, FileMode.Create))
//            {
//                await file.CopyToAsync(stream);
//            }
//            var relativePath = Path.GetRelativePath("wwwroot", pathWithName);
//            return relativePath;
//        }

//    }
//}

