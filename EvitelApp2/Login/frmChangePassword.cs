using EvitelLib2.Business;
using System;
using System.Windows.Forms;

namespace EvitelApp2.Login
{
    public partial class frmChangePassword : Form
    {
        public frmChangePassword()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtNewPassword1.Text == txtNewPassword2.Text)
            {
                if (CheckNewPassword(txtNewPassword1.Text))
                {
                    if (txtOldPassword.Text != txtNewPassword1.Text)
                    {
                        if (txtOldPassword.Text == Program.myLoggedUser.LoginPassword)
                        {
                            if (ChangePassword(Program.myLoggedUser.LoginUserId, txtNewPassword1.Text))
                            {
                                MessageBox.Show("Heslo úspěšně změněno", "Změna hesla", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.DialogResult = DialogResult.OK;
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Heslo nelze změnit", "Změna hesla", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Heslo nelze změnit", "Změna hesla", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Nové heslo nesmí být stejné.", "Změna hesla", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                MessageBox.Show("Nová hesla se musí shodovat.", "Změna hesla", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        private bool ChangePassword(int loginUserId, string newPassword)
        {
            CLoginManipulation clm = new CLoginManipulation(loginUserId);
            return clm.ChangePassword(loginUserId, newPassword);
        }

        private bool CheckNewPassword(string newPassword)
        {
            CLoginManipulation clm = new CLoginManipulation(Program.myLoggedUser.LoginUserId);
            if (clm.CheckPassword(newPassword, out string ErrString))
                return true;
            MessageBox.Show(ErrString, "Změna hesla", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return false;
        }

    }
}
