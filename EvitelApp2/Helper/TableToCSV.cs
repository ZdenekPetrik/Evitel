using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvitelApp2.Helper
{
  public class TableToCSV
  {

    public string sErr = "";
    public TableToCSV() { }
    public string delimiter = ";";

    // https://www.c-sharpcorner.com/UploadFile/deveshomar/export-datatable-to-csv-using-extension-method/

    public bool TransformToFile(DataTable dtDataTable, string fileName)
    {
      try
      {

        StreamWriter sw = new StreamWriter(fileName, false, Encoding.Unicode);
        //headers    
        for (int i = 0; i < dtDataTable.Columns.Count; i++)
        {
          sw.Write(dtDataTable.Columns[i]);
          if (i < dtDataTable.Columns.Count - 1)
          {
            sw.Write(delimiter);
          }
        }
        sw.Write(sw.NewLine);
        foreach (DataRow dr in dtDataTable.Rows)
        {
          for (int i = 0; i < dtDataTable.Columns.Count; i++)
          {
            if (!Convert.IsDBNull(dr[i]))
            {
              string value = dr[i].ToString();
              if (value.Contains(','))
              {
                value = String.Format("\"{0}\"", value);
                sw.Write(value);
              }
              else
              {
                sw.Write(dr[i].ToString());
              }
            }
            if (i < dtDataTable.Columns.Count - 1)
            {
              sw.Write(delimiter);
            }
          }
          sw.Write(sw.NewLine);
        }
        sw.Close();
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
