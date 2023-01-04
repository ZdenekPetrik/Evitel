using EvitelApp2.Controls;
using EvitelApp2.Helper;
using EvitelApp2.Login;
using EvitelLib2.Common;
using EvitelLib2.Repository;
using NPOI.SS.UserModel.Charts;
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

namespace EvitelApp2
{

  public partial class frmMain : Form
  {
    private UserControl ctrlActiveControlUp;                // Co je prave zobrazeno
    private UserControl ctrlActiveControlDown;
    private ctrlEventLog ctrlEventLog1;
    private ctrlEventLogFilter ctrlEventLogFilter1;

    eShowWindow aktWindow;
    private string Title = "EVITEL";

    public delegate void DetailIntervence(int source, int? IntervenceId);      // Zobrazí detail intervence (LikoIntervenceId>1), nebo zhasne okno (LikoIntervenceId=-1)
    public delegate void RowInformation(int nrAkt, int nrRow);            // Zobrazí 17/256 v StatusBaru

    private List<eShowWindow> lastWindowStack;

    public frmMain()
    {
      InitializeComponent();

    }

    private void Form1_Load(object sender, EventArgs e)
    {
      lastWindowStack = new List<eShowWindow>();
      toolStripUser.Text = Program.myLoggedUser.LastName;
      toolStripTime.Text = "00:00:00";
      timer1.Interval = 1000;
      timer1.Start();
      if (Program.myLoggedUser.loginMode != eLoginMode.PasswordName)
      {
        MeneToolsChangePassword.Visible = false;
      }
      CRepositoryDB repo = new CRepositoryDB();
      ucCallLIKO1.Dock = DockStyle.Fill;
      ucCallLIKO1.ShowDetailIntervence += ShowDetailIntervence;

      ucIntervents1.Dock = DockStyle.Fill;
      splitContainer1.Dock = DockStyle.Fill;
      ucCiselnik1.Dock = DockStyle.Fill;
      ctrlParticipation1.Dock = DockStyle.Fill;
      ctrlParticipation1.ShowRowInformation += ShowRowInformation;
      ctrlParticipation1.ShowDetailIntervence += ShowDetailIntervence;

      ctrllikoIncident1.Dock = DockStyle.Fill;
      ctrllikoIncident1.ShowRowInformation += ShowRowInformation;
      ctrllikoIncident1.ShowDetailIntervence += ShowDetailIntervence;

      ctrllikoIntervence1.Dock = DockStyle.Fill;
      ctrllikoIntervence1.ShowRowInformation += ShowRowInformation;
      ctrllikoIntervence1.ShowDetailIntervence += ShowDetailIntervence;

      ctrlLikoCall1.Dock = DockStyle.Fill;
      ctrlLikoCall1.ShowRowInformation += ShowRowInformation;
      ctrlLikoCall1.ShowDetailIntervence += ShowDetailIntervence;
      HideAll();
      ShowView_NewCall();
    }

    private void HideAll()
    {
      List<int> listEnumValues = new List<int>();
      eShowWindow[] myEnumMembers = (eShowWindow[])Enum.GetValues(typeof(eShowWindow));
      foreach (eShowWindow enumMember in myEnumMembers)
      {
        aktWindow = enumMember; ;
        HideActualView();
      }
      toolStripRows.Text = "";
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
      toolStripTime.Text = DateTime.Now.ToString("HH:mm:ss");

    }

    private void MenuSystemExit_Click(object sender, EventArgs e)
    {
      this.Close();
    }


    private void HideActualView()
    {
      switch (aktWindow)
      {
        case eShowWindow.emptyPage: break;
        case eShowWindow.EventLog:
          splitContainer1.Visible = false;
          break;
        case eShowWindow.NewCall:
          ucCallLIKO1.Visible = false;
          break;
        case eShowWindow.Intervents:
          ucIntervents1.Visible = false;
          break;
        case eShowWindow.Enums:
          ucCiselnik1.Visible = false;
          break;
        case eShowWindow.LikoParticipant:
          ctrlParticipation1.Visible = false;
          break;
        case eShowWindow.LikoCall:
          ctrlLikoCall1.Visible = false;
          break;
        case eShowWindow.LikoIncident:
          ctrllikoIncident1.Visible = false;
          break;
        case eShowWindow.LikoIntervence:
          ctrllikoIntervence1.Visible = false;
          break;
        case eShowWindow.NecoJineho: break;
        default: break;
      }
      MenuToolsRemoveFilters.Enabled = false;
      MenuToolsRemoveOrders.Enabled = false;
      MenuToolSetColumnLayout.Enabled = false;
      MenuToolsRemoveColumnLayout.Enabled = false;
      FileExportExcel.Enabled = false;
      ctrlActiveControlUp = ctrlActiveControlDown = null;
    }

    private void ShowView_EventLog()
    {
      splitContainer1.Visible = true;
      if (ctrlEventLog1 == null)
      {
        ctrlEventLog1 = new ctrlEventLog();
        ctrlEventLogFilter1 = new ctrlEventLogFilter();
        ctrlEventLog1.eventLogFilter1 = ctrlEventLogFilter1;
        ctrlEventLogFilter1.NewFilter += ctrlEventLogFilter1_NewFilter;
        splitContainer1.Panel1.Controls.Add(ctrlEventLog1);
        splitContainer1.Panel2.Controls.Add(ctrlEventLogFilter1);
      }
      else
      {
        ctrlEventLog1.Visible = ctrlEventLogFilter1.Visible = true;
      }
      ctrlEventLog1.MyResize();
      if (ctrlActiveControlUp != null)
      {
        ctrlActiveControlUp.Visible = ctrlActiveControlDown.Visible = false;
      }
      ctrlActiveControlUp = ctrlEventLog1;
      ctrlActiveControlDown = ctrlEventLogFilter1;
      aktWindow = eShowWindow.EventLog;
      this.Text = Title + " - EventLog";
    }

    private void ShowView_NewCall(int TypeCall = 0)
    {
      ucCallLIKO1.Visible = true;
      aktWindow = eShowWindow.NewCall;
      if (TypeCall > 0)
      {
        ucCallLIKO1.isNewForm = false;
        ucCallLIKO1.LikoIntervenceId = TypeCall;
        ucCallLIKO1.ReadDBData();
        this.Text = Title + " - LIKO Intervence id = " + TypeCall.ToString();
      }
      else
      {
        this.Text = Title + " - LIKO Nové volání";
      }
      lastWindowStack.Add(aktWindow);

    }
    private void ShowView_Interventi()
    {
      ucIntervents1.Visible = true;
      ucIntervents1.isEditModeAllowed = Program.myLoggedUser.HasAccess(eLoginAccess.PowerUser);
      if (!ucIntervents1.isData)
        ucIntervents1.ReadDataFirstTime();
      aktWindow = eShowWindow.Intervents;
      this.Text = Title + " - Interventi";
      lastWindowStack.Add(aktWindow);

    }
    private void ShowView_Ciselnik(eAllEnums aktEnum)
    {
      ucCiselnik1.Visible = true;
      ucCiselnik1.aktEnum = aktEnum;
      ucCiselnik1.ReadDataFirstTime();
      ucCiselnik1.MyResize();
      aktWindow = eShowWindow.Enums;
      this.Text = Title + " - Číselník " + ucCiselnik1.Titulek;
      lastWindowStack.Add(aktWindow);

    }
    private void ShowView_Participant(bool openNeeded = true)
    {
      if (openNeeded)
      {
        ctrlParticipation1.ReadDataFirstTime();
        ctrlParticipation1.MyResize();
      }
      ctrlParticipation1.Visible = true;
      MenuToolsRemoveFilters.Enabled = true;
      MenuToolsRemoveOrders.Enabled = true;
      MenuToolSetColumnLayout.Enabled = true;
      MenuToolsRemoveColumnLayout.Enabled = true;
      FileExportExcel.Enabled = true;
      aktWindow = eShowWindow.LikoParticipant;
      this.Text = Title + "Účastníci intervence";
      lastWindowStack.Add(aktWindow);

    }

    private void ShowView_LikoCalls(bool openNeeded = true)
    {
      if (openNeeded)
      {
        ctrlLikoCall1.ReadDataFirstTime();
        ctrlLikoCall1.MyResize();
      }
      ctrlLikoCall1.Visible = true;
      MenuToolsRemoveFilters.Enabled = true;
      MenuToolsRemoveOrders.Enabled = true;
      MenuToolSetColumnLayout.Enabled = true;
      MenuToolsRemoveColumnLayout.Enabled = true;
      FileExportExcel.Enabled = true;
      aktWindow = eShowWindow.LikoCall;
      this.Text = Title + " - Intervenční telefonní hovory";
      lastWindowStack.Add(aktWindow);
    }

    private void ShowView_LIKOIncidents(bool openNeeded = true)
    {
      if (openNeeded)
      {
        ctrllikoIncident1.ReadDataFirstTime();
        ctrllikoIncident1.MyResize();
      }
      ctrllikoIncident1.Visible = true;
      MenuToolsRemoveFilters.Enabled = true;
      MenuToolsRemoveOrders.Enabled = true;
      MenuToolSetColumnLayout.Enabled = true;
      MenuToolsRemoveColumnLayout.Enabled = true;
      FileExportExcel.Enabled = true;
      aktWindow = eShowWindow.LikoIncident;
      this.Text = Title + " - Incidenty";
      lastWindowStack.Add(aktWindow);

    }
    private void ShowView_Intervence(bool openNeeded = true)
    {
      if (openNeeded)
      {
        ctrllikoIntervence1.ReadDataFirstTime();
        ctrllikoIntervence1.MyResize();
      }
      ctrllikoIntervence1.Visible = true;
      MenuToolsRemoveFilters.Enabled = true;
      MenuToolsRemoveOrders.Enabled = true;
      MenuToolSetColumnLayout.Enabled = true;
      MenuToolsRemoveColumnLayout.Enabled = true;
      FileExportExcel.Enabled = true;
      aktWindow = eShowWindow.LikoIntervence;
      this.Text = Title + " - Intervence";
      lastWindowStack.Add(aktWindow);
    }



    void ctrlEventLogFilter1_NewFilter()
    {
      ctrlEventLog1.ReReadData();
    }

    // source 1=Call, 2=Incident, 3=Intervence, 4=Participant, -1 ucCallLiko konci
    void ShowDetailIntervence(int source, int? IntervenceId)
    {
      if (source >= 1 && source <= 4)
      {
        MessageBox.Show("Zobrazím info o intervenci id = " + IntervenceId.ToString());
        HideActualView();
        ShowView_NewCall(IntervenceId ?? 0);
      }
      else if (source == -1)
      {
        HideActualView();
        aktWindow = lastWindowStack[lastWindowStack.Count - 2];
        switch (aktWindow)
        {
          case eShowWindow.LikoParticipant:
            ShowView_Participant(false);
            break;
          case eShowWindow.LikoCall:
            ShowView_LikoCalls(false);
            break;
          case eShowWindow.LikoIncident:
            ShowView_LIKOIncidents(false);
            break;
          case eShowWindow.LikoIntervence:
            ShowView_Intervence(false);
            break;
          default: break;
        }
      }
    }
    void ShowRowInformation(int nrAkt, int nrRow)
    {
      toolStripRows.Text = nrAkt.ToString() + " / " + nrRow.ToString();
    }

    private enum eShowWindow
    {
      emptyPage,
      EventLog,
      NewCall,
      Intervents,
      Enums,
      LikoParticipant,
      LikoCall,
      LikoIncident,
      LikoIntervence,
      NecoJineho
    }

    private void splitContainer1_Panel1_Resize(object sender, EventArgs e)
    {
      if (ctrlActiveControlUp != null)
      {
        ctrlActiveControlUp.Width = splitContainer1.Panel1.Width;
        ctrlActiveControlUp.Height = splitContainer1.Panel1.Height;
      }
    }

    #region Obsluha menu
    private void newCallLIKOToolStripMenuItem_Click(object sender, EventArgs e)
    {
      HideActualView();
      ShowView_NewCall();

    }
    private void MeneToolsChangePassword_Click(object sender, EventArgs e)
    {
      frmChangePassword frm = new frmChangePassword();
      frm.ShowDialog();
    }

    private void MenuToolEventLog_Click(object sender, EventArgs e)
    {
      HideActualView();
      ShowView_EventLog();
    }
    private void interventiToolStripMenuItem_Click(object sender, EventArgs e)
    {
      HideActualView();
      ShowView_Interventi();

    }

    #endregion

    private void číselníkToolStripMenuItem_Click(object sender, EventArgs e)
    {
    }

    private void testToolStripMenuItem_Click(object sender, EventArgs e)
    {
      frmTestEndNPOI f = new frmTestEndNPOI();
      f.Show();
    }

    private void EnumsSexMenuItem_Click(object sender, EventArgs e)
    {
      HideActualView();
      ShowView_Ciselnik(eAllEnums.eSex);

    }

    private void EnumTypIntervenceMenuItem_Click(object sender, EventArgs e)
    {
      HideActualView();
      ShowView_Ciselnik(eAllEnums.eTypeIntervence);
    }

    private void EnumSubTypIntervenceMenuItem_Click(object sender, EventArgs e)
    {
      HideActualView();
      ShowView_Ciselnik(eAllEnums.eSubTypeIntervence);
    }

    private void EnumPartyToolStripMenuItem_Click(object sender, EventArgs e)
    {
      HideActualView();
      ShowView_Ciselnik(eAllEnums.eTypeParty);
    }

    private void EnumRegionMenuItem_Click(object sender, EventArgs e)
    {
      HideActualView();
      ShowView_Ciselnik(eAllEnums.eRegions);
    }

    private void MenuToolShowParticipation_Click(object sender, EventArgs e)
    {
      HideActualView();
      ShowView_Participant();

    }

    private void MenuToolShowCalls_Click(object sender, EventArgs e)
    {
      HideActualView();
      ShowView_LikoCalls();
    }

    private void MenuToolShowEvents_Click(object sender, EventArgs e)
    {
      HideActualView();
      ShowView_LIKOIncidents();

    }

    private void MenuToolShowIntervence_Click(object sender, EventArgs e)
    {
      HideActualView();
      ShowView_Intervence();

    }

    private void MenuToolsRemoveFilters_Click(object sender, EventArgs e)
    {
      if (aktWindow == eShowWindow.LikoCall)
        ctrlLikoCall1.RemoveFilters();
      else if (aktWindow == eShowWindow.LikoIncident)
        ctrllikoIncident1.RemoveFilters();
      else if (aktWindow == eShowWindow.LikoIntervence)
        ctrllikoIntervence1.RemoveFilters();

    }


    private void MenuToolsRemoveOrders_Click(object sender, EventArgs e)
    {
      if (aktWindow == eShowWindow.LikoCall)
        ctrlLikoCall1.RemoveOrders();
      else if (aktWindow == eShowWindow.LikoIncident)
        ctrllikoIncident1.RemoveOrders();
      else if (aktWindow == eShowWindow.LikoIntervence)
        ctrllikoIntervence1.RemoveOrders();
    }

    private void MenuToolsRemoveColumn_Click(object sender, EventArgs e)
    {
      if (aktWindow == eShowWindow.LikoCall)
        ctrlLikoCall1.InitColumns();
      else if (aktWindow == eShowWindow.LikoIncident)
        ctrllikoIncident1.InitColumns();
      else if (aktWindow == eShowWindow.LikoIntervence)
        ctrllikoIntervence1.InitColumns();
    }

    private void MenuToolSetColumnLayout_Click(object sender, EventArgs e)
    {
      if (aktWindow == eShowWindow.LikoCall)
        ctrlLikoCall1.SetColumns();
      else if (aktWindow == eShowWindow.LikoIncident)
        ctrllikoIncident1.SetColumns();
      else if (aktWindow == eShowWindow.LikoIntervence)
        ctrllikoIntervence1.SetColumns();


    }

    private void FileExportExcel_Click(object sender, EventArgs e)
    {
      DataTable dtTable = null;
      switch (aktWindow)
      {
        case eShowWindow.Enums:
          ucCiselnik1.Visible = false;
          break;
        case eShowWindow.LikoParticipant:
          dtTable = ctrlParticipation1.dataTable;
          break;
        case eShowWindow.LikoCall:
          dtTable = ctrlLikoCall1.dataTable;
          break;
        case eShowWindow.LikoIncident:
          dtTable = ctrllikoIncident1.dataTable;
          break;
        case eShowWindow.LikoIntervence:
          dtTable = ctrllikoIntervence1.dataTable;
          break;
        default: break;
      }
      if (dtTable == null) {
        MessageBox.Show("Neexistující tabulka pro Excel", "EVITEL - EXPORT TO EXCEL", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }


      using (SaveFileDialog fd = new SaveFileDialog())
      {
        fd.Filter = "Excel files (*.xlsx)|*.xlsx";
        fd.Title = "Save table to Excel File";
        fd.OverwritePrompt = true;
        fd.CreatePrompt = true; 
        if (fd.ShowDialog() == DialogResult.OK)
        {
          var filename = fd.FileName;
            TableToExcel excel = new TableToExcel();
            if (excel.TransformToFile(dtTable, filename))
            {
              var p = new Process();
              p.StartInfo = new ProcessStartInfo(filename)
              {
                UseShellExecute = true
              };
              p.Start();
            }
            else {
              MessageBox.Show("Nelze vytvořit Excel File z tabulky. " + excel.sErr, "EVITEL - EXPORT TO EXCEL",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
          }
      }

    }

  }
}
