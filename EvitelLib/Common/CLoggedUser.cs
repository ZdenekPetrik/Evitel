using EvitelLib.Entity;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace EvitelLib.Common
{
    [NotMapped]
    public class CLoggedUser : LoginUser
    {
        public DateTime dtLogged { get; set; }
        public bool isLogged { get; set; }
        public string sessionId { get; set; }
        public eLoginMode loginMode { get; set; }

        public CLoggedUser DeepCopy()
        {
            CLoggedUser newUser = (CLoggedUser)this.MemberwiseClone();
            newUser.Access = Access;
            return newUser;
        }
        public CLoggedUser() { }

        public CLoggedUser(LoginUser parent)
        {
            foreach (PropertyInfo prop in parent.GetType().GetProperties())
                GetType().GetProperty(prop.Name).SetValue(this, prop.GetValue(parent, null), null);
        }

        public bool HasAccess(eLoginAccess loginAccess)
        {
            foreach (var aktAccess in this.Access)
            {
                if (aktAccess.LoginAccessUserId == (int)loginAccess)
                    return true;
            }
            return false;
        }
        public bool HasAnyAccess()
        {
            return this.Access.Count > 0;
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
        AllWindowsUser = 11,            // dtto jen se eviduje user. Při prvním 'přihlášení' se zaeviduje mezi users (tak6e lze zjistit v protokolu kdo danou věc dělal). Mají všechna práva.     
        HybridWindowsUser = 12,         // Zaragistrovaní uživatelé mají práva, ostatní (sice evidovaní, ale nezaregistrovaní) mají práva user - kontroluje se doména
        AllowedWindowsUser = 13,        // Pouze Zaregistrovaní uživatelé - kontroluje se doména 
        Name = 21,                      // Pouze zaregistrované uživatelé - nevyžaduje se heslo
        PasswordName = 22               // Pouze zaregistrovaní uživatelé - jméno heslo
    }


}
