
using EvitelLib2.Model;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace EvitelLib2.Common
{
    [NotMapped]
    public class CLoggedUser : LoginUser
    {
        public DateTime dtLogged { get; set; }
        public bool isLogged { get; set; }
        public string sessionId { get; set; }
        public bool isHybrid { get { return (LoginPassword == "<hybrid>"); } set { LoginPassword = "<hybrid>"; } } 
        public eLoginMode loginMode { get; set; }

        public CLoggedUser DeepCopy()
        {
            CLoggedUser newUser = (CLoggedUser)this.MemberwiseClone();
            if (isHybrid) {
                LoginAccessUsers = new Collection<LoginAccessUser>
                {
                    new LoginAccessUser { LoginAccessId = (int)eLoginAccess.User, LoginUserId = LoginUserId, LoginAccessUserId = 0 }
                };
            }
            else
                newUser.LoginAccessUsers = LoginAccessUsers;
            return newUser;
        }
        public CLoggedUser() { }

        public CLoggedUser(LoginUser parent)
        {
            foreach (PropertyInfo prop in parent.GetType().GetProperties())
            {
                if (prop.Name == "Access" && parent.LoginPassword == "<hybrid>")
                {
                    LoginAccessUsers = new Collection<LoginAccessUser>();
                    LoginAccessUsers.Add(new LoginAccessUser { LoginAccessId = (int)eLoginAccess.User, LoginUserId = LoginUserId, LoginAccessUserId = 0 });
                }
                else
                {
                    GetType().GetProperty(prop.Name).SetValue(this, prop.GetValue(parent, null), null);
                }
            }
        }

        public bool HasAccess(eLoginAccess loginAccess)
        {
            foreach (var aktAccess in this.LoginAccessUsers)
            {
                if (aktAccess.LoginAccessId == (int)loginAccess)
                    return true;
            }
            return false;
        }
        public bool HasAnyAccess()
        {
            return this.LoginAccessUsers.Count > 0;
        }
    }


    public enum eLoginAccess
    {
        Admin = 1,
        User = 2,
        PowerUser = 3,
        Archive = 4
    }
    
    public enum eLoginMode
    {
        NoLogin = 1,                    // žádný uživatel, resp. všichni v programu jsou přihlášeni jako User a mají všechna práva
        AllWindowsUsers = 11,            // dtto jen se eviduje user. Při prvním 'přihlášení' se zaeviduje mezi users (tak6e lze zjistit v protokolu kdo danou věc dělal). Mají všechna práva.     
        HybridWindowsUsers = 12,         // Zaragistrovaní uživatelé mají práva, ostatní (sice evidovaní, ale nezaregistrovaní) mají práva user - kontroluje se doména
        AllowedWindowsUsers = 13,        // Pouze Zaregistrovaní uživatelé - kontroluje se doména 
        Name = 21,                      // Pouze zaregistrované uživatelé - nevyžaduje se heslo
        PasswordName = 22               // Pouze zaregistrovaní uživatelé - jméno heslo
    }


}
