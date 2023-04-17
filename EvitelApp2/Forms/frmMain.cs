using EvitelApp2.Controls;
using EvitelApp2.Forms;
using EvitelApp2.Forms1;
using EvitelApp2.Helper;
using EvitelApp2.Login;
using EvitelLib2.Common;
using EvitelLib2.Model;
using EvitelLib2.Repository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
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

    public delegate void DetailIntervence(int source, int? IntervenceId);      // Zobrazí detail intervence (LikoIntervenceId>1), nebo zhasne okno (LikoIntervenceId=-1), nebo skočí na SKI (-99,2) nebo LPvK (-99,1)
    public delegate void RowInformation(int nrAkt, int nrRow);                 // Zobrazí 17/256 v StatusBaru

    private List<eShowWindow> lastWindowStack;

    private enum eShowWindow
    {
      emptyPage,
      EventLog,
      SKINewCall,
      LPvKNewCall,
      Intervents,
      Enums,
      SKIParticipant,
      SKICall,
      SKIIncident,
      SKIIntervence,
      User,
      CallAll,
      LPvKRows,
      SKIReport,
      Statistika,
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
      // Nastavení viditelnosti menu dle práv
      if (Program.myLoggedUser.loginMode != eLoginMode.PasswordName)
      {
        MenuItemChangePassword.Visible = false;
      }
      if (ConfigurationManager.AppSettings["Debug"] != "Yes")
      {
        testToolStripMenuItem.Visible = false;
      }
      MenuItemBackup.Enabled = Program.myLoggedUser.HasAccess(eLoginAccess.Admin);
      MenuItemRestore.Enabled = Program.myLoggedUser.HasAccess(eLoginAccess.Admin);
      MenuItemUsers.Enabled = Program.myLoggedUser.HasAccess(eLoginAccess.Admin);
      MenuItemNewUser.Enabled = Program.myLoggedUser.HasAccess(eLoginAccess.Admin);
      MenuItemPromenneAplikace.Enabled = Program.myLoggedUser.HasAccess(eLoginAccess.Admin);
      // 
      CRepositoryDB repo = new CRepositoryDB();
      ucCallLIKO1.Dock = DockStyle.Fill;
      ucCallLIKO1.ShowDetailUserControl += ShowDetailUserControl_Obsluha;

      ucCallLPK1.Dock = DockStyle.Fill;
      ucCallLPK1.ShowDetailUserControl += ShowDetailUserControl_Obsluha;


      ucIntervents1.Dock = DockStyle.Fill;
      splitContainer1.Dock = DockStyle.Fill;
      ucCiselnik1.Dock = DockStyle.Fill;
      ctrlParticipation1.Dock = DockStyle.Fill;
      ctrlParticipation1.ShowRowInformation += ShowRowInformation;
      ctrlParticipation1.ShowDetailUserControl += ShowDetailUserControl_Obsluha;

      ctrllikoIncident1.Dock = DockStyle.Fill;
      ctrllikoIncident1.ShowRowInformation += ShowRowInformation;
      ctrllikoIncident1.ShowDetailUserControl += ShowDetailUserControl_Obsluha;

      ctrllikoIntervence1.Dock = DockStyle.Fill;
      ctrllikoIntervence1.ShowRowInformation += ShowRowInformation;
      ctrllikoIntervence1.ShowDetailUserControl += ShowDetailUserControl_Obsluha;

      ctrlLikoCall1.Dock = DockStyle.Fill;
      ctrlLikoCall1.ShowRowInformation += ShowRowInformation;
      ctrlLikoCall1.ShowDetailUserControl += ShowDetailUserControl_Obsluha;

      ctrlCall1.Dock = DockStyle.Fill;
      ctrlCall1.ShowRowInformation += ShowRowInformation;
      ctrlCall1.ShowDetailUserControl += ShowDetailUserControl_Obsluha;

      ctrllpk1.Dock = DockStyle.Fill;
      ctrllpk1.ShowRowInformation += ShowRowInformation;
      ctrllpk1.ShowDetailUserControl += ShowDetailUserControl_Obsluha;

      ctrlUser1.Dock = DockStyle.Fill;
      ctrlUser1.ShowRowInformation += ShowRowInformation;

      ucCiselnik1.ShowRowInformation += ShowRowInformation;
      ucIntervents1.ShowRowInformation += ShowRowInformation;

      ctrlSKIReport1.Dock = DockStyle.Fill;
      ctrlSKIReport1.ShowRowInformation += ShowRowInformation;
      ctrlSKIReport1.ShowDetailUserControl += ShowDetailUserControl_Obsluha;

      ctrlStatistika1.Dock = DockStyle.Fill;
      ctrlStatistika1.ShowRowInformation += ShowRowInformation;
      ctrlStatistika1.ShowDetailUserControl += ShowDetailUserControl_Obsluha;

      HideAll();
      ShowView_NewCall();
    }

    private void HideAll()
    {
      List<int> listEnumValues = new List<int>();
      eShowWindow[] myEnumMembers = (eShowWindow[])Enum.GetValues(typeof(eShowWindow));
      foreach (eShowWindow enumMember in myEnumMembers)
      {
        aktWindow = enumMember; 
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
        case eShowWindow.SKINewCall:
          ucCallLIKO1.Visible = false;
          break;
        case eShowWindow.LPvKNewCall:
          ucCallLPK1.Visible = false;
          break;
        case eShowWindow.Intervents:
          ucIntervents1.Visibility(false);
          break;
        case eShowWindow.Enums:
          ucCiselnik1.Visibility(false);
          break;
        case eShowWindow.SKIParticipant:
          ctrlParticipation1.Visibility(false);
          break;
        case eShowWindow.SKICall:
          ctrlLikoCall1.Visibility(false);
          break;
        case eShowWindow.SKIIncident:
          ctrllikoIncident1.Visibility(false);
          break;
        case eShowWindow.SKIIntervence:
          ctrllikoIntervence1.Visibility(false); ;
          break;
        case eShowWindow.User:
          ctrlUser1.Visibility(false);
          break;
        case eShowWindow.CallAll:
          ctrlCall1.Visibility(false);
          break;
        case eShowWindow.LPvKRows:
          ctrllpk1.Visibility(false);
          break;
        case eShowWindow.SKIReport:
          ctrlSKIReport1.Visibility(false);
          break;
        case eShowWindow.Statistika:
          ctrlStatistika1.Visibility(false);
          break;
        case eShowWindow.NecoJineho:
          break;
        default:
          break;
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
      aktWindow = eShowWindow.SKINewCall;
      if (TypeCall > 0)
      {
        ucCallLIKO1.isNewForm = false;
        ucCallLIKO1.LikoIntervenceId = TypeCall;
        this.Text = Title + " - Linka krizové intervence (SKI) Detail";
      }
      else
      {
        ucCallLIKO1.isNewForm = true;
        this.Text = Title + " - Linka krizové intervence (SKI) Nové volání";
      }
      ucCallLIKO1.Title = this.Text;
      ucCallLIKO1.PrepareScreen();
      lastWindowStack.Add(aktWindow);

    }

    private void ShowView_NewCallLPK(int TypeCall = 0)
    {
      ucCallLPK1.Visible = true;
      aktWindow = eShowWindow.LPvKNewCall;
      if (TypeCall > 0)
      {
        ucCallLPK1.isNewForm = false;
        ucCallLPK1.LPKId = TypeCall;
        this.Text = Title + " - Linka Pomoci v krizi (LPvK) Detail";

      }
      else
      {
        ucCallLPK1.isNewForm = true;
        this.Text = Title + " - Linka Pomoci v krizi (LPvK) Nové volání";
      }
      ucCallLPK1.Title = this.Text;
      ucCallLPK1.PrepareScreen();
      lastWindowStack.Add(aktWindow);

    }


    private void ShowView_Interventi()
    {
      if (!ucIntervents1.isData)
        ucIntervents1.ReadDataFirstTime();
      ucIntervents1.Visibility(true);
      aktWindow = eShowWindow.Intervents;
      MenuToolsRemoveFilters.Enabled = true;
      MenuToolsRemoveOrders.Enabled = true;
      MenuToolSetColumnLayout.Enabled = true;
      MenuToolsRemoveColumnLayout.Enabled = true;
      FileExportExcel.Enabled = Program.myLoggedUser.HasAccess(eLoginAccess.PowerUser);
      FileExportCSV.Enabled = Program.myLoggedUser.HasAccess(eLoginAccess.PowerUser);
      this.Text = Title + " - Interventi";
      lastWindowStack.Add(aktWindow);

    }
    private void ShowView_Ciselnik(eAllCodeBooks aktCodeBook)
    {
      ucCiselnik1.aktCodeBook = aktCodeBook;
      ucCiselnik1.ReadDataFirstTime();
      ucCiselnik1.MyResize();
      MenuToolSetColumnLayout.Enabled = true;
      MenuToolsRemoveColumnLayout.Enabled = true;
      FileExportExcel.Enabled = true;
      FileExportCSV.Enabled = true;
      aktWindow = eShowWindow.Enums;
      ucCiselnik1.Visibility(true);
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
      MenuToolsRemoveFilters.Enabled = true;
      MenuToolsRemoveOrders.Enabled = true;
      MenuToolSetColumnLayout.Enabled = true;
      MenuToolsRemoveColumnLayout.Enabled = true;
      FileExportExcel.Enabled = true;
      FileExportCSV.Enabled = true;
      aktWindow = eShowWindow.SKIParticipant;
      ctrlParticipation1.Visibility(true);
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
      MenuToolsRemoveFilters.Enabled = true;
      MenuToolsRemoveOrders.Enabled = true;
      MenuToolSetColumnLayout.Enabled = true;
      MenuToolsRemoveColumnLayout.Enabled = true;
      FileExportExcel.Enabled = true;
      FileExportCSV.Enabled = true;
      aktWindow = eShowWindow.SKICall;
      ctrlLikoCall1.Visibility(true);
      this.Text = Title + " - Intervenční telefonní hovory";
      lastWindowStack.Add(aktWindow);
    }
    private void ShowView_CallAll(bool openNeeded = true)
    {
      if (openNeeded)
      {
        ctrlCall1.ReadDataFirstTime();
        ctrlCall1.MyResize();
      }
      MenuToolsRemoveFilters.Enabled = true;
      MenuToolsRemoveOrders.Enabled = true;
      MenuToolSetColumnLayout.Enabled = true;
      MenuToolsRemoveColumnLayout.Enabled = true;
      FileExportExcel.Enabled = true;
      FileExportCSV.Enabled = true;
      aktWindow = eShowWindow.CallAll;
      ctrlCall1.Visibility(true);
      this.Text = Title + " - Telefonní hovory (SKI + LPvK)";
      lastWindowStack.Add(aktWindow);
    }

    private void ShowView_LPKRows(bool openNeeded = true)
    {
      if (openNeeded)
      {
        ctrllpk1.ReadDataFirstTime();
        ctrllpk1.MyResize();
      }
      MenuToolsRemoveFilters.Enabled = true;
      MenuToolsRemoveOrders.Enabled = true;
      MenuToolSetColumnLayout.Enabled = true;
      MenuToolsRemoveColumnLayout.Enabled = true;
      FileExportExcel.Enabled = true;
      FileExportCSV.Enabled = true;
      aktWindow = eShowWindow.LPvKRows;
      ctrllpk1.Visibility(true);
      this.Text = Title + " - Linka pomoci v krizi (LPvK)";
      lastWindowStack.Add(aktWindow);
    }

    private void ShowView_LIKOIncidents(bool openNeeded = true)
    {
      if (openNeeded)
      {
        ctrllikoIncident1.ReadDataFirstTime();
        ctrllikoIncident1.MyResize();
      }
      MenuToolsRemoveFilters.Enabled = true;
      MenuToolsRemoveOrders.Enabled = true;
      MenuToolSetColumnLayout.Enabled = true;
      MenuToolsRemoveColumnLayout.Enabled = true;
      FileExportExcel.Enabled = true;
      FileExportCSV.Enabled = true;
      aktWindow = eShowWindow.SKIIncident;
      ctrllikoIncident1.Visibility(true);
      this.Text = Title + " - SKI Události";
      lastWindowStack.Add(aktWindow);

    }
    private void ShowView_Intervence(bool openNeeded = true)
    {
      if (openNeeded)
      {
        ctrllikoIntervence1.ReadDataFirstTime();
        ctrllikoIntervence1.MyResize();
      }
      MenuToolsRemoveFilters.Enabled = true;
      MenuToolsRemoveOrders.Enabled = true;
      MenuToolSetColumnLayout.Enabled = true;
      MenuToolsRemoveColumnLayout.Enabled = true;
      FileExportExcel.Enabled = true;
      FileExportCSV.Enabled = true;
      aktWindow = eShowWindow.SKIIntervence;
      ctrllikoIntervence1.Visibility(true);
      this.Text = Title + " - SKI Intervence";
      lastWindowStack.Add(aktWindow);
    }

    private void ShowView_SKIReport(bool openNeeded = true)
    {
      if (openNeeded)
      {
        ctrlSKIReport1.ReadDataFirstTime();
        ctrlSKIReport1.MyResize();
      }
      MenuToolsRemoveFilters.Enabled = true;
      MenuToolsRemoveOrders.Enabled = true;
      MenuToolSetColumnLayout.Enabled = true;
      MenuToolsRemoveColumnLayout.Enabled = true;
      FileExportExcel.Enabled = true;
      FileExportCSV.Enabled = true;
      aktWindow = eShowWindow.SKIReport;
      ctrlSKIReport1.Visibility(true);
      this.Text = Title + " - SKI Report";
      lastWindowStack.Add(aktWindow);
    }

    private void ShowView_Users(bool openNeeded = true)
    {
      if (openNeeded)
      {
        ctrlUser1.ReadDataFirstTime();
        ctrlUser1.MyResize();
      }
      MenuToolsRemoveFilters.Enabled = true;
      MenuToolsRemoveOrders.Enabled = true;
      MenuToolSetColumnLayout.Enabled = true;
      MenuToolsRemoveColumnLayout.Enabled = true;
      FileExportExcel.Enabled = true;
      FileExportCSV.Enabled = true;
      aktWindow = eShowWindow.User;
      ctrlUser1.Visibility(true);
      this.Text = Title + " - Uživatelé";
      lastWindowStack.Add(aktWindow);
    }
    private void ShowView_Statistika(string Titulek)
    {
      aktWindow = eShowWindow.Statistika;
      FileExportExcel.Enabled = Program.myLoggedUser.HasAccess(eLoginAccess.PowerUser);
      FileExportCSV.Enabled = Program.myLoggedUser.HasAccess(eLoginAccess.PowerUser);
      ctrlStatistika1.Visibility(true);
      this.Text = Title + " - Statistika " + Titulek;
      lastWindowStack.Add(aktWindow);
    }



    void ctrlEventLogFilter1_NewFilter()
    {
      ctrlEventLog1.ReReadData();
    }

    // source 1=Call, 2=Incident, 3=Intervence, 4=Participant, 11=LPK, -1 ucCallLiko/LPvK konci
    private void ShowDetailUserControl_Obsluha(int source, int? IntervenceId)
    {
      if (source >= 1 && source <= 5)
      {
        HideActualView();
        ShowView_NewCall(IntervenceId ?? 0);
      }
      else if (source == 11)
      {
        HideActualView();
        ShowView_NewCallLPK(IntervenceId ?? 0);
      }
      else if (source == -1)
      {
        HideActualView();
        aktWindow = lastWindowStack[lastWindowStack.Count - 2];
        switch (aktWindow)
        {
          case eShowWindow.SKIReport:
            ShowView_SKIReport(IntervenceId > 0);
            break;
          case eShowWindow.SKIParticipant:
            ShowView_Participant(IntervenceId > 0);
            break;
          case eShowWindow.SKICall:
            ShowView_LikoCalls(IntervenceId > 0);
            break;
          case eShowWindow.SKIIncident:
            ShowView_LIKOIncidents(IntervenceId > 0);
            break;
          case eShowWindow.SKIIntervence:
            ShowView_Intervence(IntervenceId > 0);
            break;
          case eShowWindow.CallAll:
            ShowView_CallAll(IntervenceId > 0);
            break;
          case eShowWindow.LPvKRows:
            ShowView_LPKRows(IntervenceId > 0); // tzn. že se věta změnila - znovu načti
            break;
          default: break;
        }
      }
      else if (source == -99 && IntervenceId == 1)
      {
        HideActualView();
        ShowView_NewCallLPK();
      }
      else if (source == -99 && IntervenceId == 2)
      {
        HideActualView();
        ShowView_NewCall();
      }
    }
    void ShowRowInformation(int nrAkt, int nrRow)
    {
      if (nrAkt == -1 && nrRow == -1)
        toolStripRows.Text = "";
      else
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
    private void newCallLDToolStripMenuItem_Click(object sender, EventArgs e)
    {
      HideActualView();
      ShowView_NewCallLPK();

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
      ShowView_Ciselnik(eAllCodeBooks.eContactTopic);

    }

    private void EnumTemaKontaktuDetailMenuItem_Click(object sender, EventArgs e)
    {
      HideActualView();
      ShowView_Ciselnik(eAllCodeBooks.eSubContactTopic);
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
    private void MenuToolShowCallsAll_Click(object sender, EventArgs e)
    {
      HideActualView();
      ShowView_CallAll();
    }
    private void linkaPomociVKriziLPKToolStripMenuItem_Click(object sender, EventArgs e)
    {
      HideActualView();
      ShowView_LPKRows();

    }
    private void exportDenníProtokolToolStripMenuItem_Click(object sender, EventArgs e)
    {
      frmExportDenniProtokol frm = new frmExportDenniProtokol();
      frm.ShowDialog();
    }
    private void oAplikaciToolStripMenuItem_Click(object sender, EventArgs e)
    {
      frmAbout frm = new frmAbout();
      frm.ShowDialog();

    }
    private void MenuToolShowSKIReport_Click(object sender, EventArgs e)
    {
      HideActualView();
      ShowView_SKIReport();
    }
    private void MenuItemPromenneAplikace_Click(object sender, EventArgs e)
    {
      frmSetting frm = new frmSetting();
      frm.ShowDialog();
    }
    private void statistikaVoláníToolStripMenuItem_Click(object sender, EventArgs e)
    {
      frmStatisticsCall frm = new frmStatisticsCall();
      if (frm.ShowDialog() == DialogResult.OK)
      {
        ctrlStatistika1.dataTable = frm.aktStatistikaTable;
        ShowView_Statistika("Volání");
      }
    }
    private void statistikaSKIUdálostíToolStripMenuItem_Click(object sender, EventArgs e)
    {
      frmStatisticsEvent frm = new frmStatisticsEvent();
      if (frm.ShowDialog() == DialogResult.OK)
      {
        ctrlStatistika1.dataTable = frm.aktStatistikaTable;
        ShowView_Statistika("Volání");
      }

    }

    private void statiskikaLPvKToolStripMenuItem_Click(object sender, EventArgs e)
    {
      frmStatisticsLPvK frm = new frmStatisticsLPvK();
      if (frm.ShowDialog() == DialogResult.OK)
      {
        ctrlStatistika1.dataTable = frm.aktStatistikaTable;
        ShowView_Statistika("Statistika LPVK");
      }

    }


    #endregion



    private IctrlWithDGW GetActiveCtrl(eShowWindow aktWindow)
    {

      IctrlWithDGW rozhrani = null;
      if (aktWindow == eShowWindow.SKICall)
        rozhrani = (IctrlWithDGW)ctrlLikoCall1;
      else if (aktWindow == eShowWindow.SKIIncident)
        rozhrani = (IctrlWithDGW)ctrllikoIncident1;
      else if (aktWindow == eShowWindow.SKIIntervence)
        rozhrani = (IctrlWithDGW)ctrllikoIntervence1;
      else if (aktWindow == eShowWindow.SKIParticipant)
        rozhrani = (IctrlWithDGW)ctrlParticipation1;
      else if (aktWindow == eShowWindow.User)
        rozhrani = (IctrlWithDGW)ctrlUser1;
      else if (aktWindow == eShowWindow.SKINewCall)
        rozhrani = (IctrlWithDGW)ucCallLIKO1;
      else if (aktWindow == eShowWindow.Enums)
        rozhrani = (IctrlWithDGW)ucCiselnik1;
      else if (aktWindow == eShowWindow.Intervents)
        rozhrani = (IctrlWithDGW)ucIntervents1;
      else if (aktWindow == eShowWindow.LPvKRows)
        rozhrani = (IctrlWithDGW)ctrllpk1;
      else if (aktWindow == eShowWindow.CallAll)
        rozhrani = (IctrlWithDGW)ctrlCall1;
      else if (aktWindow == eShowWindow.SKIReport)
        rozhrani = (IctrlWithDGW)ctrlSKIReport1;
      else if (aktWindow == eShowWindow.Statistika)
        rozhrani = (IctrlWithDGW)ctrlStatistika1;
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

    private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
    {
      if (MessageBox.Show("Opravdu ukončit EVITEL?", "EVITEL", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
        e.Cancel = true;
    }

  }
}
