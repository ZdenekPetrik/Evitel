using EvitelLib2.Repository;
using Newtonsoft.Json;
using NPOI.SS.Formula.Functions;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using PdfSharpCore.Drawing;
using PdfSharpCore.Fonts;
using PdfSharpCore.Pdf;
using PdfSharpCore.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;


namespace EvitelApp2.Controls
{
  public partial class frmTestEndNPOI : Form
  {
    public frmTestEndNPOI()
    {
      InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
      GlobalFontSettings.FontResolver = new FontResolver();

    }


    private void button1_Click(object sender, EventArgs e)
    {
      // https://www.thecodebuzz.com/read-and-write-excel-file-in-net-core-using-npoi/

      List<UserDetails> persons = new List<UserDetails>()
            {
                new UserDetails() {ID="1001", Name="ABCD", City ="City1", Country="USA"},
                new UserDetails() {ID="1002", Name="PQRS", City ="City2", Country="INDIA"},
                new UserDetails() {ID="1003", Name="XYZZ", City ="City3", Country="CHINA"},
                new UserDetails() {ID="1004", Name="LMNO", City ="City4", Country="UK"},
           };

      // Lets converts our object data to Datatable for a simplified logic.
      // Datatable is most easy way to deal with complex datatypes for easy reading and formatting.

      DataTable table = (DataTable)JsonConvert.DeserializeObject(JsonConvert.SerializeObject(persons), (typeof(DataTable)));
      var memoryStream = new MemoryStream();

      using (var fs = new FileStream("Result.xlsx", FileMode.Create, FileAccess.Write))
      {
        IWorkbook workbook = new XSSFWorkbook();
        ISheet excelSheet = workbook.CreateSheet("Sheet1");

        List<String> columns = new List<string>();
        IRow row = excelSheet.CreateRow(0);
        int columnIndex = 0;

        foreach (System.Data.DataColumn column in table.Columns)
        {
          columns.Add(column.ColumnName);
          row.CreateCell(columnIndex).SetCellValue(column.ColumnName);
          columnIndex++;
        }

        int rowIndex = 1;
        foreach (DataRow dsrow in table.Rows)
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
    public class UserDetails
    {
      public string ID { get; set; }
      public string Name { get; set; }
      public string City { get; set; }
      public string Country { get; set; }
    }

    private void frmTestEndNPOI_Load(object sender, EventArgs e)
    {

    }

    private void button2_Click(object sender, EventArgs e)
    {



      var document = new PdfDocument();
      var page = document.AddPage();

      var gfx = XGraphics.FromPdfPage(page);
      var font = new XFont("Arial", 20, XFontStyle.Bold);

      var textColor = XBrushes.Black;
      var layout = new XRect(20, 20, page.Width, page.Height);
      var format = XStringFormats.Center;


      var pen = new XPen(XColor.FromArgb(50, 30, 200));
      gfx.DrawString("Hello World!", font, textColor, layout, format);




      //      gfx.DrawLine(pen, new XPoint(0, 0), new XPoint(0, 842));
      //      gfx.DrawLine(pen, new XPoint(0, 0), new XPoint(595, 0));
      gfx.DrawLine(pen, new XPoint(0, 0), new XPoint(0, 842 - 24));
      gfx.DrawLine(pen, new XPoint(0, 0), new XPoint(595 - 24, 0));
      gfx.DrawLine(pen, new XPoint(72, 72), new XPoint(72, 842 - (2 * 72)));
      gfx.DrawLine(pen, new XPoint(72, 72), new XPoint(594 - (2 * 72), 72));

      document.Save("helloworld.pdf");
      var p = new Process();
      p.StartInfo = new ProcessStartInfo("helloworld.pdf")
      {
        UseShellExecute = true
      };
      p.Start();
    }

    private void button3_Click(object sender, EventArgs e)
    {
      int a, b;
      Console.WriteLine(Test(out a, out b));
      Console.WriteLine(Test(out a, out a));



      //  double fakt  = Faktorial(double.Parse(txtFaktorialZ.Text));
      //  label1.Text = fakt.ToString();
    }

    /*
    static void Swap<T>(ref T lhs, ref T rhs)
    {
      T temp;
      temp = lhs;
      lhs = rhs;
      rhs = temp;
    }

    private T Faktorial<T> (T number) 
    {
      T decrement = default(T) ;
      T vysledek = default(T);
      if (number <= 1)
        return default(T);
      try
      {
        checked
        {
          vysledek = Faktorial(number--) * number;
        }
      }
      catch (OverflowException e)
      {

        MessageBox.Show(number.ToString() + " " + e.Message);
        return  1;
      }
      return vysledek;
    }
    */


    static bool Test(out int x, out int y)
    {
      x = 123;
      y = 45;
      return (x == y);
    }

    private void btnProtokol_Click(object sender, EventArgs e)
    {
      CRepositoryDB DB = new CRepositoryDB(-1);
      List<int> abc = new List<int>() { 1, 2, 3 };

      var intervenceList = DB.GetWLIKOIntervence().Where(x => abc.Contains(x.LikointervenceId)); ;
      var callsList = DB.GetWLikoCalls().Where(x => intervenceList.Select(x => x.LikointervenceId).Contains(x.LikointervenceId));  



      DateTime dtTo = DateTime.Now;
      DateTime dtFrom = DateTime.Now.AddMinutes(-60 * 12);



      var document = new PdfDocument();
      var page = document.AddPage();
      page.Orientation = PdfSharpCore.PageOrientation.Landscape;

      var penBlack = new XPen(XColor.FromArgb(255, 255, 255));
      var penGray = new XPen(XColor.FromArgb(196, 196, 196));


      var gfx = XGraphics.FromPdfPage(page);
      var fontTitle = new XFont("Arial", 16, XFontStyle.Bold);
      var fontRegular = new XFont("Arial", 11, XFontStyle.Regular);
      var textColorBlack = XBrushes.Black;
      var textColor = XBrushes.DarkGray;
      var format = XStringFormats.TopLeft;
      XRect rect = new XRect(20, 20, 250, 220);
      var pen = new XPen(XColor.FromArgb(127, 127, 127));


      gfx.DrawString("Protokol nahlášených krizových intervencí", fontTitle, textColorBlack, rect, format);
      rect = new XRect(page.Width - 160, 20, 100, 20);
      gfx.DrawString("Od:  " + dtFrom.ToString("dd.MM.yyyy HH:mm:ss"), fontRegular, textColor, rect, format);
      rect = new XRect(page.Width - 160, 35, 100, 20);
      gfx.DrawString("Do:  " + dtTo.ToString("dd.MM.yyyy HH:mm:ss"), fontRegular, textColor, rect, format);

      int hovorStart = 20;
      rect = new XRect(hovorStart, 60, 200, 20);
      gfx.DrawString("Hovor", fontRegular, textColor, rect, XStringFormats.Center);
      gfx.DrawLine(pen, new XPoint(hovorStart, 80), new XPoint(200, 80));

      int udalostStart = 220;
      rect = new XRect(udalostStart, 60, 300, 20);
      gfx.DrawString("Událost", fontRegular, textColor, rect, XStringFormats.Center);
      gfx.DrawLine(pen, new XPoint(udalostStart, 80), new XPoint(500, 80));

      int IntervenceStart = 520;
      rect = new XRect(IntervenceStart, 60, 150, 20);
      gfx.DrawString("Intervence", fontRegular, textColor, rect, XStringFormats.Center);
      gfx.DrawLine(pen, new XPoint(IntervenceStart, 80), new XPoint(650, 80));

      int PredaniStart = 670;
      rect = new XRect(PredaniStart, 60, page.Width - (PredaniStart + 20), 20);
      gfx.DrawString("Předání", fontRegular, textColor, rect, XStringFormats.Center);
      gfx.DrawLine(pen, new XPoint(PredaniStart, 80), new XPoint(page.Width - 20, 80));






      //      gfx.DrawLine(pen, new XPoint(0, 0), new XPoint(0, 842));
      //      gfx.DrawLine(pen, new XPoint(0, 0), new XPoint(595, 0));

      document.Save("helloworld.pdf");
      var p = new Process();
      p.StartInfo = new ProcessStartInfo("helloworld.pdf")
      {
        UseShellExecute = true
      };
      p.Start();

    }
  }
}