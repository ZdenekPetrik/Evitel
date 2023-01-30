using EvitelLib2.Model;
using EvitelLib2.Repository;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using NPOI.OpenXmlFormats.Spreadsheet;
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
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Forms;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;



namespace EvitelApp2.Controls
{
  public partial class frmTestEndNPOI : Form
  {
    CRepositoryDB DB;

    public frmTestEndNPOI()
    {
      InitializeComponent();
    }



    private void AutoCompleteExample()
    {
      // Create the list to use as the custom source. 
      var source = new AutoCompleteStringCollection();
      source.AddRange(new string[]
                      {
                        "January",
                        "February",
                        "March",
                        "April",
                        "May",
                        "June",
                        "July",
                        "August",
                        "September",
                        "October",
                        "November",
                        "December"
                      });

      // Create and initialize the text box.
      var textBox = new TextBox
      {
        AutoCompleteCustomSource = source,
        AutoCompleteMode =
                            AutoCompleteMode.SuggestAppend,
        AutoCompleteSource =
                            AutoCompleteSource.CustomSource,
        Location = new Point(20, 20),
        Width = ClientRectangle.Width - 40,
        Visible = true
      };

      // Add the text box to the form.
      Controls.Add(textBox);
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
      DB = new CRepositoryDB(-1);

      GlobalFontSettings.FontResolver = new FontResolver();
      AutoCompleteStringCollection col = new AutoCompleteStringCollection
      {
        "adam",
        "adamovič",
        "adamov",
        "broumov",
        "broskve"
      };

      txtAutocomplete.AutoCompleteSource = AutoCompleteSource.CustomSource;
      txtAutocomplete.AutoCompleteCustomSource = col;
      txtAutocomplete.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

    }

    private void btnTreeViewRead_Click(object sender, EventArgs e)
    {
      var subCSS = DB.GetSubClientCurrentStatus();
      var css = DB.GetClientCurrentStatus().OrderBy(x => x.ClientCurrentStatusId);
      var LPKClientCurrentStatus = DB.GetLPKClientCurrentStatus(3);
      this.treeViewContactTopic.Nodes.Clear();  
      foreach (var cssItem in css)
      {
        TreeNode mainNode = new TreeNode();
        mainNode.Name = cssItem.ClientCurrentStatusId.ToString();
        mainNode.Text = cssItem.Text;
        foreach (var subCssItem in subCSS.Where(x => x.ClientCurrentStatusId == cssItem.ClientCurrentStatusId).OrderBy(x => x.SubClientCurrentStatusId))
        {
          TreeNode Node2 = new TreeNode();
          Node2.Name = subCssItem.SubClientCurrentStatusId.ToString();
          Node2.Text = subCssItem.Text;
          Node2.Checked = LPKClientCurrentStatus.Contains(subCssItem.SubClientCurrentStatusId);

          mainNode.Nodes.Add(Node2);
        }
        this.treeViewContactTopic.Nodes.Add(mainNode);

      }
      this.treeViewContactTopic.CheckBoxes = true;
      this.treeViewContactTopic.DrawMode = TreeViewDrawMode.OwnerDrawAll;

    }

    private void btnTreeViewWrite_Click(object sender, EventArgs e)
    {
      List<int> EditedListID = new List<int>();
      foreach (TreeNode n in treeViewContactTopic.Nodes)
      {
        foreach (TreeNode n2 in n.Nodes)
        {
          if (n2.Checked)
          {
            EditedListID.Add(int.Parse(n2.Name));
          }
        }
      }
      DB.SetLPKClientCurrentStatus(3, EditedListID);
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

      var intervenceList = DB.GetWLIKOIntervence().Where(x => abc.Contains(x.LikointervenceId));    //  new List<WIntervence>(); 
      var callsList = DB.GetWLikoCalls().Where(x => intervenceList.Select(x => x.LikointervenceId).Contains(x.LikointervenceId));
      var incidentsList = DB.GetWLIKOIncident().Where(x => intervenceList.Select(x => x.LikoincidentId).Contains(x.LikoincidentId));



      DateTime dtTo = DateTime.Now;
      DateTime dtFrom = DateTime.Now.AddMinutes(-60 * 12);



      var document = new PdfDocument();
      var page = document.AddPage();
      page.Orientation = PdfSharpCore.PageOrientation.Landscape;

      var penBlack = new XPen(XColor.FromArgb(255, 255, 255));
      var penGray = new XPen(XColor.FromArgb(230, 230, 230));


      var gfx = XGraphics.FromPdfPage(page);
      var fontTitle = new XFont("Arial", 16, XFontStyle.Bold);
      var fontRegular = new XFont("Arial", 9, XFontStyle.Regular);
      var fontBold = new XFont("Arial", 10, XFontStyle.Bold);
      var textColorBlack = XBrushes.Black;
      var textColor = XBrushes.DarkSlateGray;
      var format = XStringFormats.TopLeft;
      XRect rect = new XRect(20, 20, 250, 220);
      var pen = new XPen(XColor.FromArgb(127, 127, 127));


      gfx.DrawString("Protokol nahlášených krizových intervencí", fontTitle, textColorBlack, rect, format);
      rect = new XRect(page.Width - 160, 20, 100, 20);
      gfx.DrawString("Od:  " + dtFrom.ToString("dd.MM.yyyy HH:mm:ss"), fontRegular, textColor, rect, format);
      rect = new XRect(page.Width - 160, 35, 100, 20);
      gfx.DrawString("Do:  " + dtTo.ToString("dd.MM.yyyy HH:mm:ss"), fontRegular, textColor, rect, format);

      if (intervenceList.Count() == 0)
      {
        rect = new XRect(20, 100, page.Width - 20, 20);
        gfx.DrawString("V průběhu směny nebyla oznámena žádná událost", fontRegular, textColor, rect, XStringFormats.Center);
      }
      else
      {


        int aktY = 60;
        int aktY2 = 80;
        int hovorStart = 20;
        int hovorSize = 170;
        rect = new XRect(hovorStart, aktY, hovorSize - 20, 20);
        gfx.DrawString("Hovor", fontRegular, textColor, rect, XStringFormats.Center);
        gfx.DrawLine(pen, new XPoint(hovorStart, aktY2), new XPoint(hovorSize - 20, aktY2));

        int udalostStart = hovorStart + hovorSize;
        int udalostSize = 260;
        rect = new XRect(udalostStart, aktY, udalostSize - 20, 20);
        gfx.DrawString("Událost", fontRegular, textColor, rect, XStringFormats.Center);
        gfx.DrawLine(pen, new XPoint(udalostStart, aktY2), new XPoint(udalostStart + udalostSize - 20, aktY2));

        int IntervenceStart = udalostStart + udalostSize;
        int IntervenceSize = 200;

        rect = new XRect(IntervenceStart, aktY, IntervenceSize - 20, 20);
        gfx.DrawString("Intervence", fontRegular, textColor, rect, XStringFormats.Center);
        gfx.DrawLine(pen, new XPoint(IntervenceStart, aktY2), new XPoint(IntervenceStart + IntervenceSize - 20, aktY2));

        int PredaniStart = IntervenceStart + IntervenceSize;
        int PredaniSize = (int)page.Width - PredaniStart;
        rect = new XRect(PredaniStart, aktY, PredaniSize, 20);
        gfx.DrawString("Předání", fontRegular, textColor, rect, XStringFormats.Center);
        gfx.DrawLine(pen, new XPoint(PredaniStart, aktY2), new XPoint(PredaniStart + PredaniSize - 20, aktY2));


        aktY = 100;
        aktY2 = 120;
        hovorStart = 20;
        gfx.DrawLine(pen, new XPoint(hovorStart, aktY2), new XPoint(page.Width - 20, aktY2));
        gfx.DrawString("Id", fontBold, textColorBlack, new XRect(hovorStart, aktY, 40, 20), XStringFormats.CenterLeft);
        gfx.DrawString("Čas", fontBold, textColorBlack, new XRect(hovorStart + 40, aktY, 30, 20), XStringFormats.CenterLeft);
        gfx.DrawString("Volal", fontBold, textColorBlack, new XRect(hovorStart + 70, aktY, 100, 20), XStringFormats.CenterLeft);

        gfx.DrawString("Kraj", fontBold, textColorBlack, new XRect(udalostStart, aktY, 100, 20), XStringFormats.CenterLeft);
        gfx.DrawString("Datum", fontBold, textColorBlack, new XRect(udalostStart + 100, aktY, 60, 20), XStringFormats.CenterLeft);
        gfx.DrawString("Místo", fontBold, textColorBlack, new XRect(udalostStart + 160, aktY, 100, 20), XStringFormats.CenterLeft);

        gfx.DrawString("Typ", fontBold, textColorBlack, new XRect(IntervenceStart, aktY, 100, 20), XStringFormats.CenterLeft);
        gfx.DrawString("Zápis", fontBold, textColorBlack, new XRect(IntervenceStart + 140, aktY, 60, 20), XStringFormats.CenterLeft);
        gfx.DrawString("Datum", fontBold, textColorBlack, new XRect(IntervenceStart + 160, aktY, 60, 20), XStringFormats.CenterLeft);


        gfx.DrawString("Obětí", fontBold, textColorBlack, new XRect(PredaniStart, aktY, 50, 20), XStringFormats.CenterLeft);
        gfx.DrawString("Osob", fontBold, textColorBlack, new XRect(PredaniStart + 50, aktY, 50, 20), XStringFormats.CenterLeft);
        gfx.DrawString("Přijal", fontBold, textColorBlack, new XRect(PredaniStart + 50, aktY, 50, 20), XStringFormats.CenterLeft);


        gfx.DrawString(dtFrom.ToString("dddd d. MMMM yyyy", new CultureInfo("cs-cz")), fontBold, textColor, new XRect(hovorStart, aktY + 40, 20, 20), XStringFormats.TopLeft);
        gfx.DrawLine(pen, new XPoint(hovorStart, aktY + 55), new XPoint(page.Width - 20, aktY + 55));

        aktY = 160;
        foreach (var aktIntervence in intervenceList)
        {
          var aktCall = callsList.Where(x => x.LikointervenceId == aktIntervence.LikointervenceId).FirstOrDefault();
          var aktIncident = incidentsList.Where(x => x.LikoincidentId == aktIntervence.LikoincidentId).FirstOrDefault();

          gfx.DrawString(aktCall.LikointervenceId.ToString() + ".", fontRegular, textColor, new XRect(hovorStart, aktY, 40, 20), XStringFormats.CenterLeft);
          gfx.DrawString((aktCall.DtStartCall ?? DateTime.Now).ToString("HH:mm"), fontRegular, textColor, new XRect(hovorStart + 40, aktY, 30, 20), XStringFormats.CenterLeft);
          gfx.DrawString(aktCall.InterventShortName, fontRegular, textColor, new XRect(hovorStart + 70, aktY, 100, 20), XStringFormats.CenterLeft);

          gfx.DrawString(aktIncident.RegionName, fontRegular, textColor, new XRect(udalostStart, aktY, 100, 20), XStringFormats.CenterLeft);
          gfx.DrawString((aktIncident.DtIncident ?? DateTime.Now).ToString("dd.MM.yyyy"), fontRegular, textColor, new XRect(udalostStart + 100, aktY, 60, 20), XStringFormats.CenterLeft);
          gfx.DrawString(aktIncident.Place, fontRegular, textColor, new XRect(udalostStart + 160, aktY, 100, 20), XStringFormats.CenterLeft);

          gfx.DrawString(aktIncident.IncidentName, fontRegular, textColor, new XRect(IntervenceStart, aktY, 140, 20), XStringFormats.CenterLeft);
          gfx.DrawString(aktIntervence.Poradi.ToString(), fontRegular, textColor, new XRect(IntervenceStart + 140, aktY, 140, 20), XStringFormats.CenterLeft);
          gfx.DrawString((aktIntervence.DtStartIntervence ?? DateTime.Now).ToString("dd.MM.yyyy"), fontRegular, textColor, new XRect(IntervenceStart + 160, aktY, 40, 20), XStringFormats.CenterLeft);

          aktY += 20;
        }
        string bottom = "";
        if (intervenceList.Count() == 1)
          bottom = "Jeden hovor za směnu";
        else if (intervenceList.Count() <= 4)
          bottom = intervenceList.Count().ToString() + " hovory za směnu";
        else
          bottom = intervenceList.Count().ToString() + " hovorů za směnu";

        aktY += 20;
        gfx.DrawString(bottom, fontBold, textColorBlack, new XRect(hovorStart, aktY, 100, 20), XStringFormats.Center);

      }

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

    private void btnBackup_Click(object sender, EventArgs e)
    {
      try
      {
        using (SaveFileDialog fd = new SaveFileDialog())
        {
          fd.FileName = "EvitelBackup_" + DateTime.Now.ToString("yyyMMdd_HHmmss") + ".bak";
          fd.Filter = "Backup files (*.bak)|*.bak";
          fd.Title = "Save table to Backup File";
          fd.OverwritePrompt = true;
          fd.CreatePrompt = true;
          if (fd.ShowDialog() == DialogResult.OK)
          {
            var filename = fd.FileName;
            string command = "BACKUP DATABASE Evitel TO DISK = '" + fd.FileName + "'";

            using (var ctx = new Evitel2Context())
            {
              //Get student name of string type
              var a = ctx.Database.ExecuteSqlRaw(command);
            }
          }
        }
      }
      catch (Exception Ex)
      {
        MessageBox.Show("Nelze provést zálohování. " + Ex.Message);
      }
    }

    private void btnRestore_Click(object sender, EventArgs e)
    {
      try
      {

        string databaseName = "Evitel";
        var filePath = string.Empty;
        using (OpenFileDialog openFileDialog = new OpenFileDialog())
        {
          openFileDialog.Filter = "backup files (*.bak)|*.bak|All files (*.*)|*.*";

          if (openFileDialog.ShowDialog() == DialogResult.OK)
          {
            filePath = openFileDialog.FileName;
          }
        }
        if (filePath.Length > 0)
        {


          string command = "ALTER DATABASE [" + databaseName + "] SET SINGLE_USER WITH ROLLBACK IMMEDIATE";
          using (var ctx = new Evitel2Context())
          {
            //Get student name of string type
            var a = ctx.Database.ExecuteSqlRaw(command);
          }
          command = "RESTORE DATABASE [" + databaseName + "] FROM DISK = N'" + filePath + "' WITH REPLACE";
          using (var ctx = new Evitel2Context())
          {
            //Get student name of string type
            var a = ctx.Database.ExecuteSqlRaw(command);
          }

          command = "ALTER DATABASE [" + databaseName + "] SET MULTI_USER";
          using (var ctx = new Evitel2Context())
          {
            //Get student name of string type
            var a = ctx.Database.ExecuteSqlRaw(command);
          }
        }
      }
      catch (Exception Ex)
      {
        MessageBox.Show("Nelze provést obnovu databáze. " + Ex.Message);
      }
    }

    private void treeViewContactTopic_DrawNode(object sender, DrawTreeNodeEventArgs e)
    {
      if (e.Node.Parent == null)
      {
        int d = (int)(0.2 * e.Bounds.Height);
        Rectangle rect = new Rectangle(d + treeViewContactTopic.Margin.Left, d + e.Bounds.Top, e.Bounds.Height - d * 2, e.Bounds.Height - d * 2);
        e.Graphics.FillRectangle(new SolidBrush(Color.FromKnownColor(KnownColor.Control)), rect);
        e.Graphics.DrawRectangle(Pens.Silver, rect);
        StringFormat sf = new StringFormat() { LineAlignment = StringAlignment.Center, Alignment = StringAlignment.Center };
        e.Graphics.DrawString(e.Node.IsExpanded ? "-" : "+", treeViewContactTopic.Font, new SolidBrush(Color.Blue), rect, sf);
        //Draw the dotted line connecting the expanding/collapsing button and the node Text
        using (Pen dotted = new Pen(Color.Black) { DashStyle = System.Drawing.Drawing2D.DashStyle.Dot })
        {
          e.Graphics.DrawLine(dotted, new Point(rect.Right + 1, rect.Top + rect.Height / 2), new Point(rect.Right + 4, rect.Top + rect.Height / 2));
        }
        //Draw text
        sf.Alignment = StringAlignment.Near;
        Rectangle textRect = new Rectangle(e.Bounds.Left + rect.Right + 4, e.Bounds.Top, e.Bounds.Width - rect.Right - 4, e.Bounds.Height);
        if (e.Node.IsSelected)
        {
          SizeF textSize = e.Graphics.MeasureString(e.Node.Text, treeViewContactTopic.Font);
          e.Graphics.FillRectangle(new SolidBrush(SystemColors.Highlight), new RectangleF(textRect.Left, textRect.Top, textSize.Width, textRect.Height));
        }
        e.Graphics.DrawString(e.Node.Text, treeViewContactTopic.Font, new SolidBrush(treeViewContactTopic.ForeColor), textRect, sf);
      }
      else e.DrawDefault = true;
    }

  }
}