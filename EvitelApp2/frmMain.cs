using EvitelApp2.Controls;
using EvitelApp2.Login;
using EvitelLib2.Common;
using EvitelLib2.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            var x = repo.Test();
            aktWindow = eShowWindow.emptyPage;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripTime.Text = DateTime.Now.ToString("HH:mm:ss");

        }

        private void MenuSystemExit_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void HideActualView()
        {
           switch (aktWindow)
            {
                case eShowWindow.emptyPage: break;
                case eShowWindow.EventLog: 
                    ctrlEventLog1.Visible = ctrlEventLogFilter1.Visible = true; 
                    ctrlActiveControlUp = ctrlActiveControlDown = null;
                    break;
                case eShowWindow.NecoJineho: break;
                default: break;
            }
        }

        private void ShowView_EventLog()
        {
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
        }



        void ctrlEventLogFilter1_NewFilter()
        {
            ctrlEventLog1.ReReadData();
        }


        private enum eShowWindow { 
            emptyPage,
            EventLog,
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

    }
}
