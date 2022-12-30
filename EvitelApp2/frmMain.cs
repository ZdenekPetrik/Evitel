using EvitelApp2.Controls;
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

    public frmMain()
    {
      InitializeComponent();

    }

    private void Form1_Load(object sender, EventArgs e)
    {
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
      ucIntervents1.Dock = DockStyle.Fill;
      splitContainer1.Dock = DockStyle.Fill;
      ucCiselnik1.Dock = DockStyle.Fill;
      ctrlParticipation1.Dock = DockStyle.Fill;
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
        case eShowWindow.Participant:
          ctrlParticipation1.Visible = false;
          break;
        case eShowWindow.NecoJineho: break;
        default: break;
      }
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
      this.Text = Title + " - LIKO Nové volání";

    }
    private void ShowView_Interventi()
    {
      ucIntervents1.Visible = true;
      ucIntervents1.isEditModeAllowed = Program.myLoggedUser.HasAccess(eLoginAccess.PowerUser);
      if (!ucIntervents1.isData)
        ucIntervents1.ReadDataFirstTime();
      aktWindow = eShowWindow.Intervents;
      this.Text = Title + " - Interventi";
    }
    private void ShowView_Ciselnik(eAllEnums aktEnum)
    {
      ucCiselnik1.Visible = true;
      ucCiselnik1.aktEnum = aktEnum;
      ucCiselnik1.ReadDataFirstTime();
      ucCiselnik1.MyResize();
      aktWindow = eShowWindow.Enums;
      this.Text = Title + " - Číselník " + ucCiselnik1.Titulek;

    }
    private void ShowView_Participant()
    {
      ctrlParticipation1.Visible = true;
      ctrlParticipation1.ReadDataFirstTime();
      ctrlParticipation1.MyResize();
      aktWindow = eShowWindow.Participant;
      this.Text = "Účastníci intervence";

    }



    void ctrlEventLogFilter1_NewFilter()
    {
      ctrlEventLog1.ReReadData();
    }


    private enum eShowWindow
    {
      emptyPage,
      EventLog,
      NewCall,
      Intervents,
      Enums,
      Participant,
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
  }
}
