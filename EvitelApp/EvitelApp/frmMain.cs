using EvitelApp.Login;
using EvitelLib.Common;
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
    }
}
