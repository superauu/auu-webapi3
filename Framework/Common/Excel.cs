//Author: Nathan Li
//Create Time: Monday, 1 July 2019

using System;
using System.Data;
using System.IO;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace Auu.Framework.Common
{
    public class ExcelHelper : IDisposable
    {
        private readonly string _fileName;
        private bool _disposed;
        private FileStream _fs;
        private IWorkbook _workbook;

        public ExcelHelper(string fileName)
        {
            _fileName = fileName;
            _disposed = false;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public string GetRowNumber(int sheetIndex, string colName, string cellValue)
        {
            return null;
        }
        /// <summary>
        ///     Export DataTable data to excel file
        /// </summary>
        /// <param name="data">data</param>
        /// <param name="isColumnWritten">If export column name to file</param>
        /// <param name="sheetName">sheet name in excel file</param>
        /// <param name="autoWidth"></param>
        /// <returns>lines</returns>
        public int DataTableToExcel(DataTable data, string sheetName, bool isColumnWritten, bool autoWidth = true)
        {
            _fs = new FileStream(_fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            if (_fileName.IndexOf(".xlsx", StringComparison.Ordinal) > 0) // 2007ver
                _workbook = new XSSFWorkbook();
            else if (_fileName.IndexOf(".xls", StringComparison.Ordinal) > 0) // 2003ver
                _workbook = new HSSFWorkbook();

            try
            {
                ISheet sheet;
                if (_workbook != null)
                    sheet = _workbook.CreateSheet(sheetName);
                else
                    return -1;

                int j;
                int count;
                if (isColumnWritten)
                {
                    var row = sheet.CreateRow(0);
                    for (j = 0; j < data.Columns.Count; ++j) row.CreateCell(j).SetCellValue(data.Columns[j].ColumnName);
                    count = 1;
                }
                else
                {
                    count = 0;
                }

                int i;
                for (i = 0; i < data.Rows.Count; ++i)
                {
                    //if old ems and new ems have different data, change the cells color to red.
                    var row = sheet.CreateRow(count);
                    for (j = 0; j < data.Columns.Count; ++j)
                    {
                        row.CreateCell(j).SetCellValue(data.Rows[i][j].ToString());
                    }

                    ++count;
                }

                if (autoWidth)
                {
                    int lastColumNum = sheet.GetRow(0).LastCellNum;
                    for (int k = 0; k <= lastColumNum; k++)
                    {
                        sheet.AutoSizeColumn(k);
                    }
                }

                _workbook.Write(_fs);
                return count;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
                return -1;
            }
            finally
            {
                if (_fs != null)
                    _fs.Close();
            }
        }

        /// <summary>
        ///     Import from excel file to dataTable
        /// </summary>
        /// <param name="sheetName">sheet name</param>
        /// <param name="isFirstRowColumn">if the first row is column name</param>
        /// <returns>DataTable</returns>
        public DataTable ExcelToDataTable(string sheetName, bool isFirstRowColumn)
        {
            var data = new DataTable();
            try
            {
                _fs = new FileStream(_fileName, FileMode.Open, FileAccess.Read);
                if (_fileName.IndexOf(".xlsx", StringComparison.Ordinal) > 0) // 2007ver
                    _workbook = new XSSFWorkbook(_fs);
                else if (_fileName.IndexOf(".xls", StringComparison.Ordinal) > 0) // 2003ver
                    _workbook = new HSSFWorkbook(_fs);

                ISheet sheet;
                if (sheetName != null)
                {
                    sheet = _workbook.GetSheet(sheetName) ?? _workbook.GetSheetAt(0);
                }
                else
                {
                    sheet = _workbook.GetSheetAt(0);
                }

                if (sheet != null)
                {
                    var firstRow = sheet.GetRow(0);
                    int cellCount = firstRow.LastCellNum; //count of columns

                    int startRow;
                    if (isFirstRowColumn)
                    {
                        for (int i = firstRow.FirstCellNum; i < cellCount; ++i)
                        {
                            var cell = firstRow.GetCell(i);
                            if (cell != null)
                            {
                                var cellValue = cell.StringCellValue;
                                if (cellValue != null)
                                {
                                    var column = new DataColumn(cellValue);
                                    data.Columns.Add(column);
                                }
                            }
                        }

                        startRow = sheet.FirstRowNum + 1;
                    }
                    else
                    {
                        startRow = sheet.FirstRowNum;
                    }

                    //flag of the last column.
                    var rowCount = sheet.LastRowNum;
                    for (var i = startRow; i <= rowCount; ++i)
                    {
                        var row = sheet.GetRow(i);
                        if (row == null) continue; //null if the row has no data

                        var dataRow = data.NewRow();
                        for (int j = row.FirstCellNum; j < cellCount; ++j)
                            if (row.GetCell(j) != null) //null if the cell has no data
                                dataRow[j] = row.GetCell(j).ToString();
                        data.Rows.Add(dataRow);
                    }
                }

                return data;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
                return null;
            }
            finally
            {
                if (_fs != null)
                    _fs.Close();
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _fs?.Close();
                }

                _fs = null;
                _disposed = true;
            }
        }
    }
}