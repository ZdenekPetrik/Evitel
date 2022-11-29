using EvitelApp2.Login;
using EvitelLib2.Business;
using EvitelLib2.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EvitelApp2
{
    static class Program
    {
        public static CLoggedUser myLoggedUser;
        private static CLoginManipulation loginManipulation;
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            loginManipulation = new CLoginManipulation();
            myLoggedUser = null;
            //Login();
            myLoggedUser = loginManipulation.CheckLogin("ZPT", "12345678");
            if (myLoggedUser != null)
            {
                Application.Run(new frmMain());
                loginManipulation.Logout(myLoggedUser);
            }
            else
            {
                MessageBox.Show("Bad user ", "No-Login", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        public static bool Login()
        {
            eLoginMode loginMode = loginManipulation.GetLoginMode();
            switch (loginMode)
            {
                case eLoginMode.NoLogin:
                    {
                        myLoggedUser = loginManipulation.GetNoLoginUser(); return true;
                    }
                case eLoginMode.AllowedWindowsUsers:
                case eLoginMode.AllWindowsUsers:
                case eLoginMode.HybridWindowsUsers:
                    {
                        string userFullName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
                        string[] userName = userFullName.Split('\\');
                        myLoggedUser = loginManipulation.CheckLogin(userName[1], "");
                        return (myLoggedUser != null);
                    }
                case eLoginMode.Name:
                    {
                        frmLogin frm = new frmLogin
                        {
                            Mode = 2
                        };
                        if (frm.ShowDialog() == DialogResult.OK)
                        {
                            myLoggedUser = frm.myLoggedUser;
                            return true;
                        }
                        return false;
                    }
                case eLoginMode.PasswordName:
                    {
                        frmLogin frm = new frmLogin();
                        if (frm.ShowDialog() == DialogResult.OK)
                        {
                            myLoggedUser = frm.myLoggedUser;
                            return true;
                        }
                        return false;
                    }
                default:
                    MessageBox.Show("Bad loginMode = " + loginMode.ToString(), "No-Login", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    break;
            }

            return false;
        }
    }
}
