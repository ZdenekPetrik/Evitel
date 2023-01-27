using EvitelApp2.Controls;
using EvitelApp2.Forms1;
using EvitelApp2.Helper;
using EvitelApp2.Login;
using EvitelLib2.Common;
using EvitelLib2.Model;
using EvitelLib2.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;

using System.Windows.Forms;

namespace EvitelApp2
{

  public partial class frmMain : System.Windows.Forms.Form
  {
    private UserControl ctrlActiveControlUp;                // Co je prave zobrazeno
    private UserControl ctrlActiveControlDown;
    private ctrlEventLog ctrlEventLog1;
    private ctrlEventLogFilter ctrlEventLogFilter1;

    eShowWindow aktWindow;
    private string Title = "EVITEL";

    public delegate void DetailIntervence(int source, int? IntervenceId);      // Zobrazí detail intervence (LikoIntervenceId>1), nebo zhasne okno (LikoIntervenceId=-1)
    public delegate void RowInformation(int nrAkt, int nrRow);                 // Zobrazí 17/256 v StatusBaru

    private List<eShowWindow> lastWindowStack;

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
      User,
      NecoJineho
    }




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
        MenuItemChangePassword.Visible = false;
      }
      MenuItemUsers.Enabled = Program.myLoggedUser.HasAccess(eLoginAccess.Admin);
      MenuItemNewUser.Enabled = Program.myLoggedUser.HasAccess(eLoginAccess.Admin);

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

      ctrlUser1.Dock = DockStyle.Fill;
      ctrlUser1.ShowRowInformation += ShowRowInformation;

      ucCiselnik1.ShowRowInformation += ShowRowInformation;
      ucIntervents1.ShowRowInformation += ShowRowInformation;
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
        case eShowWindow.User:
          ctrlUser1.Visible = false;
          break;
        case eShowWindow.NecoJineho: break;
        default: break;
      }
      MenuToolsRemoveFilters.Enabled = false;
      MenuToolsRemoveOrders.Enabled = false;
      MenuToolSetColumnLayout.Enabled = false;
      MenuToolsRemoveColumnLayout.Enabled = false;
      FileExportExcel.Enabled = false;
      FileExportCSV.Enabled = false;
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
        this.Text = Title + " - LIKO Intervence id = " + TypeCall.ToString();

      }
      else
      {
        ucCallLIKO1.isNewForm = true;
        this.Text = Title + " - LIKO Nové volání";
      }
      MenuToolSetColumnLayout.Enabled = true;
      MenuToolsRemoveColumnLayout.Enabled = true;
      ucCallLIKO1.PrepareScreen();
      lastWindowStack.Add(aktWindow);

    }
    private void ShowView_Interventi()
    {
      ucIntervents1.Visible = true;
      if (!ucIntervents1.isData)
        ucIntervents1.ReadDataFirstTime();
      MenuToolsRemoveFilters.Enabled = true;
      MenuToolsRemoveOrders.Enabled = true;
      MenuToolSetColumnLayout.Enabled = true;
      MenuToolsRemoveColumnLayout.Enabled = true;
      FileExportExcel.Enabled = true;
      FileExportCSV.Enabled = true;
      aktWindow = eShowWindow.Intervents;
      this.Text = Title + " - Interventi";
      lastWindowStack.Add(aktWindow);

    }
    private void ShowView_Ciselnik(eAllCodeBooks aktCodeBook)
    {
      ucCiselnik1.Visible = true;
      ucCiselnik1.aktCodeBook = aktCodeBook;
      ucCiselnik1.ReadDataFirstTime();
      ucCiselnik1.MyResize();
      MenuToolSetColumnLayout.Enabled = true;
      MenuToolsRemoveColumnLayout.Enabled = true;
      FileExportExcel.Enabled = true;
      FileExportCSV.Enabled = true;

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
      FileExportCSV.Enabled = true;
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
      FileExportCSV.Enabled = true;
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
      FileExportCSV.Enabled = true;
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
      FileExportCSV.Enabled = true;
      aktWindow = eShowWindow.LikoIntervence;
      this.Text = Title + " - Intervence";
      lastWindowStack.Add(aktWindow);
    }

    private void ShowView_Users(bool openNeeded = true)
    {
      if (openNeeded)
      {
        ctrlUser1.ReadDataFirstTime();
        ctrllikoIntervence1.MyResize();
      }
      ctrlUser1.Visible = true;
      MenuToolsRemoveFilters.Enabled = true;
      MenuToolsRemoveOrders.Enabled = true;
      MenuToolSetColumnLayout.Enabled = true;
      MenuToolsRemoveColumnLayout.Enabled = true;
      FileExportExcel.Enabled = true;
      FileExportCSV.Enabled = true;
      aktWindow = eShowWindow.User;
      this.Text = Title + " - Uživatelé";
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

    private void testToolStripMenuItem_Click(object sender, EventArgs e)
    {
    }

    private void EnumsSexMenuItem_Click(object sender, EventArgs e)
    {
      HideActualView();
      ShowView_Ciselnik(eAllCodeBooks.eSex);

    }


    private void EnumTypIncidentuMenuItem_Click(object sender, EventArgs e)
    {
      HideActualView();
      ShowView_Ciselnik(eAllCodeBooks.eSubTypeIncident);
    }

    private void EnumPartyToolStripMenuItem_Click(object sender, EventArgs e)
    {
      HideActualView();
      ShowView_Ciselnik(eAllCodeBooks.eTypeParty);
    }

    private void EnumRegionMenuItem_Click(object sender, EventArgs e)
    {
      HideActualView();
      ShowView_Ciselnik(eAllCodeBooks.eRegions);
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

    private void EnumDruhIntervenceMenuItem_Click(object sender, EventArgs e)
    {
      HideActualView();
      ShowView_Ciselnik(eAllCodeBooks.eDruhIntervence);
    }


    private void MenuItemChangePassword_Click(object sender, EventArgs e)
    {
      frmChangePassword frm = new frmChangePassword();
      frm.ShowDialog();

    }

    private void MenuItemUsers_Click(object sender, EventArgs e)
    {
      HideActualView();
      ShowView_Users();
    }

    private void MenuToolsRemoveFilters_Click(object sender, EventArgs e)
    {
      IctrlWithDGW r = GetActiveCtrl(aktWindow);
      if (r != null)
        r?.RemoveFilters();
      else
      {
        MessageBox.Show(aktWindow.ToString() + " aktivní okno neumožňuje  metodu RemoveOrders().", "NELZE", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }

    }

    private void MenuToolsRemoveOrders_Click(object sender, EventArgs e)
    {
      IctrlWithDGW r = GetActiveCtrl(aktWindow);
      if (r != null)
        r?.RemoveOrders();
      else
      {
        MessageBox.Show(aktWindow.ToString() + " aktivní okno neumožňuje  metodu RemoveOrders().", "NELZE", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void MenuToolsRemoveColumn_Click(object sender, EventArgs e)
    {
      IctrlWithDGW r = GetActiveCtrl(aktWindow);
      if (r != null)
        r?.InitColumns();
      else
      {
        MessageBox.Show(aktWindow.ToString() + " aktivní okno neumožňuje  metodu InitColums().", "NELZE", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void MenuToolSetColumnLayout_Click(object sender, EventArgs e)
    {
      IctrlWithDGW r = GetActiveCtrl(aktWindow);
      if (r != null)
        r?.SetColumns();
      else
      {
        MessageBox.Show(aktWindow.ToString() + " aktivní okno neumožňuje metodu SetColums().", "NELZE", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void MenuItemNewUser_Click(object sender, EventArgs e)
    {
      CRepositoryDB DB = new CRepositoryDB(Program.myLoggedUser.LoginUserId);
      frmUser frm = new frmUser();
      frm.loginUser = new LoginUser();
      frm.loginAccessList = DB.GetLoginAccess();
      frm.StartPosition = FormStartPosition.CenterScreen;
      frm.Type = 1;
      frm.ShowDialog();
      if (frm.isOK)
      {
        DB.UpdateLoginUser(frm.loginUser);
        ctrlUser1.RefreshData();
      }

    }

    private void MenuItemRestore_Click(object sender, EventArgs e)
    {
      (new BackupRestore()).Restore();
    }

    private void MenuItemBackup_Click(object sender, EventArgs e)
    {
      (new BackupRestore()).Backup();
    }

    private void mainTestToolStripMenuItem_Click(object sender, EventArgs e)
    {
      frmTestEndNPOI f = new frmTestEndNPOI();
      f.Show();

    }

    private void EnumNickMenuItem_Click(object sender, EventArgs e)
    {
      HideActualView();
      ShowView_Ciselnik(eAllCodeBooks.eNick);
    }


    private void graphTestToolStripMenuItem_Click(object sender, EventArgs e)
    {

    }

    private void EnumEndOfSpeechMenuItem_Click(object sender, EventArgs e)
    {
      HideActualView();
      ShowView_Ciselnik(eAllCodeBooks.eEndOfSpeech);

    }

    private void EnumSubEndOfSpeechMenuItem_Click(object sender, EventArgs e)
    {
      HideActualView();
      ShowView_Ciselnik(eAllCodeBooks.eSubEndOfSpeech);

    }

    private void EnumAktualniStavKlientaMenuItem_Click(object sender, EventArgs e)
    {
      HideActualView();
      ShowView_Ciselnik(eAllCodeBooks.eClientCurrentStatus);
    }

    private void EnumAktualniStavKlientaDetailMenuItem_Click(object sender, EventArgs e)
    {
      HideActualView();
      ShowView_Ciselnik(eAllCodeBooks.eSubClientCurrentStatus);
    }

    private void EnumTemaKontaktuMenuItem_Click(object sender, EventArgs e)
    {
      HideActualView();
      ShowView_Ciselnik(eAllCodeBooks.eTopic);

    }

    private void EnumTemaKontaktuDetailMenuItem_Click(object sender, EventArgs e)
    {
      HideActualView();
      ShowView_Ciselnik(eAllCodeBooks.eSubTopic);
    }
    private void EnumContactTypeMenuItem_Click(object sender, EventArgs e)
    {
      HideActualView();
      ShowView_Ciselnik(eAllCodeBooks.eContactType);

    }

    private void EnumTypeServiceMenuItem_Click(object sender, EventArgs e)
    {
      HideActualView();
      ShowView_Ciselnik(eAllCodeBooks.eTypeService);

    }

    private void EnumClientFromMenuItem_Click(object sender, EventArgs e)
    {
      HideActualView();
      ShowView_Ciselnik(eAllCodeBooks.eClientFrom);

    }

    private void EnumAgeMenuItem_Click(object sender, EventArgs e)
    {
      HideActualView();
      ShowView_Ciselnik(eAllCodeBooks.eAge);

    }


    #endregion



    private IctrlWithDGW GetActiveCtrl(eShowWindow aktWindow)
    {

      IctrlWithDGW rozhrani = null;
      if (aktWindow == eShowWindow.LikoCall)
        rozhrani = (IctrlWithDGW)ctrlLikoCall1;
      else if (aktWindow == eShowWindow.LikoIncident)
        rozhrani = (IctrlWithDGW)ctrllikoIncident1;
      else if (aktWindow == eShowWindow.LikoIntervence)
        rozhrani = (IctrlWithDGW)ctrllikoIntervence1;
      else if (aktWindow == eShowWindow.LikoParticipant)
        rozhrani = (IctrlWithDGW)ctrlParticipation1;
      else if (aktWindow == eShowWindow.User)
        rozhrani = (IctrlWithDGW)ctrlUser1;
      else if (aktWindow == eShowWindow.NewCall)
        rozhrani = (IctrlWithDGW)ucCallLIKO1;
      else if (aktWindow == eShowWindow.Enums)
        rozhrani = (IctrlWithDGW)ucCiselnik1;
      else if (aktWindow == eShowWindow.Intervents)
        rozhrani = (IctrlWithDGW)ucIntervents1;
      return rozhrani;
    }
    private void fileExportCSV_Click(object sender, EventArgs e)
    {
      IctrlWithDGW r = GetActiveCtrl(aktWindow);
      if (r == null)
      {
        MessageBox.Show("Neexistující tabulka pro CSV", "EVITEL - EXPORT TO CSV", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }
      DataTable dtTable = r.dataTable;

      using (SaveFileDialog fd = new SaveFileDialog())
      {
        fd.Filter = "CSV files (*.csv)|*.csv";
        fd.Title = "Save table to CSV File";
        fd.OverwritePrompt = true;
        fd.CreatePrompt = true;
        if (fd.ShowDialog() == DialogResult.OK)
        {
          var filename = fd.FileName;
          TableToCSV csv = new TableToCSV();
          if (csv.TransformToFile(dtTable, filename))
          {
            MessageBox.Show(" Soubor CSV vytvořen. \n" + filename, "EVITEL - EXPORT TO CSV", MessageBoxButtons.OK, MessageBoxIcon.Information);
          }
          else
          {
            MessageBox.Show("Nelze vytvořit csv File z tabulky. " + csv.sErr, "EVITEL - EXPORT TO CSV", MessageBoxButtons.OK, MessageBoxIcon.Error);
          }
        }
      }

    }


    private void FileExportExcel_Click(object sender, EventArgs e)
    {
      IctrlWithDGW r = GetActiveCtrl(aktWindow);
      if (r == null)
      {
        MessageBox.Show("Neexistující tabulka pro Excel", "EVITEL - EXPORT TO EXCEL", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }
      DataTable dtTable = r.dataTable;

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
          else
          {
            MessageBox.Show("Nelze vytvořit Excel File z tabulky. " + excel.sErr, "EVITEL - EXPORT TO EXCEL", MessageBoxButtons.OK, MessageBoxIcon.Error);
          }
        }
      }

    }

   }
}
