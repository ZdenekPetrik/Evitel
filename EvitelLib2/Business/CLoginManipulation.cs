using EvitelLib2.Common;
using EvitelLib2.Repository;
using System;
using System.Text.RegularExpressions;

namespace EvitelLib2.Business
{
    public class CLoginManipulation
    {
        /// <summary>
        ///  Zajistí přihlášení uživatele jméno/heslo pokud jméno/heslo souhlasí. Jinak vrací null
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="userPassword"></param>
        /// <returns></returns>
        /// 

        public eLoginMode loginMode { get; set; } = eLoginMode.NoLogin;

        int loginUserId { get; set; } = -1;
        public CLoginManipulation() { }
        public CLoginManipulation(int loginUserId) {
            this.loginUserId = loginUserId;
        }


        public CLoggedUser CheckLogin(string userName, string userPassword) {
            loginMode = GetLoginMode();
            CRepositoryDB db = new CRepositoryDB();
            LoginUser user =  null;
            if (loginMode == eLoginMode.Name || loginMode == eLoginMode.AllowedWindowsUsers)
            {
                user = db.LoginUserNameExists(userName);
            }
            else if (loginMode == eLoginMode.PasswordName)
            {
                user = db.LoginUserNamePasswordExists(userName, userPassword);
            }
            else if (loginMode == eLoginMode.AllWindowsUsers || loginMode == eLoginMode.HybridWindowsUsers)
            {
                user = db.LoginUserNameExists(userName);
                if (user == null)
                {
                    db.AddLoginUser("",userName, userName, loginMode == eLoginMode.HybridWindowsUsers ? "<hybrid>" : "");
                    user = db.LoginUserNameExists(userName);
                }
            }
            if (user == null)
            {
                new CEventLog(eEventCode.e1Login, eEventSubCode.e2BadLogin, userName);
                return null;
            }
            CLoggedUser loggedUser = new CLoggedUser(user);
            if (loginMode == eLoginMode.Name || loginMode == eLoginMode.AllowedWindowsUsers || loginMode == eLoginMode.HybridWindowsUsers )
            {
                if (!loggedUser.HasAnyAccess())
                {
                    new CEventLog(eEventCode.e1Login, eEventSubCode.e2BadLogin, user.LastName, "NoAnyAccess", user.LoginUserId);
                    return null;
                }
            }
            return Login(user);
        }

        public CLoggedUser GetNoLoginUser()
        {
            return CheckLogin("user", "user");
        }

        public eLoginMode GetLoginMode()
        {
            CRepositoryDB db = new CRepositoryDB(loginUserId);
            return (eLoginMode) db.GetSettingI("LoginMode");
        }

        /// provede nezbytné úkony pro přihlášení uživatele (ale už nic nekontroluje)
        private CLoggedUser Login(LoginUser user)
        {
            CLoggedUser loggedUser = new CLoggedUser(user);
            loggedUser.isLogged = true;
            loggedUser.dtLogged = DateTime.Now;
            loggedUser.sessionId = ((ulong)DateTime.Now.ToBinary()).ToString();
            loggedUser.loginMode = GetLoginMode();
 
            new CEventLog(eEventCode.e1Login, eEventSubCode.e2Start, user.LastName, loggedUser.sessionId, user.LoginUserId);
            return loggedUser;
        }


        /// provede nezbytné úkony pro odhlášení uživatele 
        public CLoggedUser Logout(CLoggedUser loggedUser)
        {
            loggedUser.isLogged = false;
            new CEventLog(eEventCode.e1Login, eEventSubCode.e2Stop, loggedUser.LastName, loggedUser.sessionId, loggedUser.LoginUserId);
            return loggedUser;
        }
        /// změna hesla
        public bool ChangePassword(int loginUserIdToChange, string newLoginPassword)
        {
            bool isOK = false;
            CRepositoryDB db = new CRepositoryDB(loginUserIdToChange);
            isOK = db.ChangePassword(loginUserIdToChange, newLoginPassword);
            if (isOK)
               new CEventLog(eEventCode.e1Login, eEventSubCode.e2ChangePassword, "", loginUserIdToChange.ToString(), loginUserId);
            return isOK;
        }

        public bool CheckPassword(string newPassword, out string errString)
        {
            errString = "";
            CRepositoryDB db = new CRepositoryDB(loginUserId);
            string regex = db.GetSettingS("LoginPasswordMask");
            Match match = Regex.Match(newPassword, regex, RegexOptions.IgnoreCase);
            if (!match.Success)
            {
                errString = db.GetSettingS("LoginPassworderErrMessage").Replace("<br/>","\n");
                return false;
            }
            return true;
        }

    }
}
