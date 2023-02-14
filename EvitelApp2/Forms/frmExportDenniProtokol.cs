using EvitelLib2.Common;
using EvitelLib2.Repository;
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
    CRepositoryDB DB;
    public frmExportDenniProtokol()
    {
      InitializeComponent();
    }

    private void frmExportDenniProtokol_Load(object sender, EventArgs e)
    {
      DB = new CRepositoryDB(Program.myLoggedUser.LoginUserId);

      dateTimePickerFrom.Value = DateTime.Now.Date.AddDays(-1).AddHours(8);
      dtTo.Value = DateTime.Now.Date.AddDays(-1).AddHours(20);
      numIncrement.Value = DB.GetSettingI("CisloJednaciIncrement");
      txtCisloJednaci.Text = DB.GetSettingS("CisloJednaci");
    }

    private void btnGenerate_Click(object sender, EventArgs e)
    {
      using (SaveFileDialog fd = new SaveFileDialog())
      {
        fd.Filter = "PDF file (*.pdf)|*.pdf";
        fd.Title = "Save protocol to PDF File";
        fd.OverwritePrompt = true;
        fd.CreatePrompt = true;
        fd.FileName =  "ProtokolSKI_From" + dateTimePickerFrom.Value.ToString("yyyMMdd_HHmm") + "To_"+ dtTo.Value.ToString("yyyMMdd_HHmm")+".pdf";
        if (fd.ShowDialog() == DialogResult.OK)
        {
          string CisloJednaci = DB.GetSettingS("CisloJednaci");
          CisloJednaci = CisloJednaci.Replace("<ID>", ((int)numIncrement.Value).ToString());
          DB.SetSetting("CisloJednaciIncrement", (int)numIncrement.Value + 1);
          PDFProtocol PDF = new PDFProtocol(Program.myLoggedUser.LoginUserId, dateTimePickerFrom.Value, dtTo.Value, CisloJednaci, fd.FileName);
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
