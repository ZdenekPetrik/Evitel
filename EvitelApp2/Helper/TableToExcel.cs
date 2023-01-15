using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvitelApp2.Helper
{
  internal class TableToExcel
  {

    public string sErr = "";
    public TableToExcel() { }

    public bool TransformToFile(DataTable dataTable, string fileName)
    {
      // https://www.thecodebuzz.com/read-and-write-excel-file-in-net-core-using-npoi/
      try
      {
        var memoryStream = new MemoryStream();
        using (var fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
        {
          IWorkbook workbook = new XSSFWorkbook();
          ISheet excelSheet = workbook.CreateSheet("List1");

          List<String> columns = new List<string>();
          IRow row = excelSheet.CreateRow(0);
          int columnIndex = 0;

          foreach (System.Data.DataColumn column in dataTable.Columns)
          {
            columns.Add(column.ColumnName);
            row.CreateCell(columnIndex).SetCellValue(column.ColumnName);
            columnIndex++;
          }

          int rowIndex = 1;
          foreach (DataRow dsrow in dataTable.Rows)
          {
            row = excelSheet.CreateRow(rowIndex);
            int cellIndex = 0;
            foreach (String col in columns)
            {
              row.CreateCell(cellIndex).SetCellValue(dsrow[col].ToString());
              cellIndex++;
            }

            rowIndex++;
          }
          workbook.Write(fs);
        }
      }
      catch (Exception Ex)
      {
        sErr = Ex.Message;
        return false;
      }
      return true;
    }

  }
}
