using EvitelApp.Controls;
using EvitelApp.Login;
using EvitelLib.Common;
using EvitelLib.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EvitelApp
{
    public partial class frmMain : Form
    {
        UserControl ctrlActiveControlUp;                // Co je prave zobrazeno
        UserControl ctrlActiveControlDown;



        ctrlEventLog ctrlEventLog1;
        ctrlEventLogFilter ctrlEventLogFilter1;
        ctrlPhones ctrlPhones1;
        ctrlEventLogFilter ctrlEventLogFilter2;
        public CLoggedUser myLoggedUser;
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            toolStripUser.Text = Program.myLoggedUser.LastName;
            timer1.Interval = 1000;
            timer1.Start();
            if (Program.myLoggedUser.loginMode != eLoginMode.PasswordName)
            {
                ChangePasswordToolStripMenuItem.Visible = false;
            }
            CRepositoryDB repo = new CRepositoryDB();
            var x = repo.Test();

        }

        private void změnaHeslaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword frm = new frmChangePassword();
            frm.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripTime.Text = DateTime.Now.ToString("HH:mm:ss");

        }

        private void eventLogMenuItem_Click(object sender, EventArgs e)
        {
            splitContainer1.Visible = true;
            ZobrazProtokol();
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ZobrazProtokol()
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

        }

        void ctrlEventLogFilter1_NewFilter()
        {
            ctrlEventLog1.ReReadData();
        }

        private void splitContainer1_Panel1_Resize(object sender, EventArgs e)
        {
            if (ctrlActiveControlUp != null)
            {
                ctrlActiveControlUp.Width = splitContainer1.Panel1.Width;
                ctrlActiveControlUp.Height = splitContainer1.Panel1.Height;
            }
        }

        private void statusStrip1_Resize(object sender, EventArgs e)
        {
        }

        private void phonesMenuItem_Click(object sender, EventArgs e)
        {
            splitContainer1.Visible = true;
            ZobrazPhones();

        }
        private void ZobrazPhones()
        {
            if (ctrlPhones1 == null)
            {
                ctrlPhones1 = new ctrlPhones();
                splitContainer1.Panel1.Controls.Add(ctrlPhones1);
            }
            else
            {
                ctrlPhones1.Visible  = true;
            }
            ctrlActiveControlUp = ctrlPhones1;
            ctrlActiveControlDown = ctrlEventLogFilter1;

        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTest frm = new frmTest();
            frm.ShowDialog();
        }
    }
}
