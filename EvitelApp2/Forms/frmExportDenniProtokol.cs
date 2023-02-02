using EvitelLib2.Common;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EvitelApp2.Forms
{
  public partial class frmExportDenniProtokol : Form
  {
    public frmExportDenniProtokol()
    {
      InitializeComponent();
    }

    private void frmExportDenniProtokol_Load(object sender, EventArgs e)
    {
      dateTimePickerFrom.Format = DateTimePickerFormat.Custom;
      dateTimePickerFrom.CustomFormat = "MM/dd/yyyy hh:mm";
      dateTimePickerTo.Format = DateTimePickerFormat.Custom;
      dateTimePickerTo.CustomFormat = "MM/dd/yyyy HH:mm";

      dateTimePickerFrom.Value = DateTime.Now.Date.AddDays(-1).AddHours(8);
      dateTimePickerTo.Value = DateTime.Now.Date.AddDays(-1).AddHours(20);

    }

    private void btnGenerate_Click(object sender, EventArgs e)
    {
      using (SaveFileDialog fd = new SaveFileDialog())
      {
        fd.Filter = "PDF file (*.pdf)|*.pdf";
        fd.Title = "Save protocol to PDF File";
        fd.OverwritePrompt = true;
        fd.CreatePrompt = true;
        fd.FileName =  "ProtokolSKI_From" + dateTimePickerFrom.Value.ToString("yyyMMdd_HHmm") + "To_"+ dateTimePickerTo.Value.ToString("yyyMMdd_HHmm")+".pdf";
        if (fd.ShowDialog() == DialogResult.OK)
        {

          PDFProtocol PDF = new PDFProtocol(Program.myLoggedUser.LoginUserId, dateTimePickerFrom.Value, dateTimePickerTo.Value, fd.FileName);
          PDF.Generate();
          var p = new Process();
          p.StartInfo = new ProcessStartInfo(fd.FileName)
          {
            UseShellExecute = true
          };
          p.Start();
          this.Close();
        }
      }
    }
  }
}
