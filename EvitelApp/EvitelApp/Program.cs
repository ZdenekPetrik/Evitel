using EvitelApp.Login;
using EvitelLib.Business;
using EvitelLib.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EvitelApp
{
    static class Program
    {
        public static CLoggedUser myLoggedUser;
        private static CLoginManipulation loginManipulation;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            loginManipulation = new CLoginManipulation();
            myLoggedUser = null;
            Login();
            if (myLoggedUser != null)
            {
                Application.Run(new frmMain());
                loginManipulation.Logout(myLoggedUser);
            }
        }


        public static bool Login() {
            eLoginMode loginMode = loginManipulation.GetLoginMode();
            switch (loginMode)
            {
                case eLoginMode.NoLogin:
                    {
                        myLoggedUser = loginManipulation.GetNoLoginUser(); return true; 
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
                default: break;
            }
            return false;
        }
    }
}
