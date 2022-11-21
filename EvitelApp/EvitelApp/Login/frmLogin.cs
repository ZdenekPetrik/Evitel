using EvitelLib.Business;
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

namespace EvitelApp.Login
{
    public partial class frmLogin : Form
    {
        public CLoggedUser myLoggedUser;
        public int Mode = 1;
        public frmLogin()
        {
            InitializeComponent();
            myLoggedUser = null;
        }

        private void LoginFrm_Load(object sender, EventArgs e)
        {
            if (Mode == 2) {
                this.userPassword.Visible = false;
                this.lblUserPassword.Visible = false;
                this.btnLogin.Top = this.btnLogin.Top - 30;
                this.Height = this.Height - 30;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            CLoginManipulation l = new CLoginManipulation();
            myLoggedUser = l.CheckLogin(this.userName.Text, this.userPassword.Text);
            if (myLoggedUser != null)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Uživatel '" + this.userName.Text + "' neexistuje, nebo nemá práva pro přihlášení do systému Evitel", "No-Login", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.userName.Text = "";
                this.userPassword.Text = "";
            }

        }
    }
}
