using EvitelLib.Entity;
using EvitelLib.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvitelLib.Common
{
    public static class CUserHelper
    {
        static List<LoginUser> cacheUser;


        public static string GetUserFullName(int loginUserId)
        {
            if (cacheUser == null)
            {
                ReadCache();
            }
            var x = from u in cacheUser where u.LoginUserId==loginUserId select u;
            if (x.Count() > 0)
                return x.First().FirstName + (x.First().FirstName.Length > 0 && x.First().FirstName.Length > 0?" ":"") + x.First().LastName;
            return loginUserId.ToString() + " no exists in DB as User";
        }
        private static void ReadCache() {
            CRepositoryDB db = new CRepositoryDB(-5);
            cacheUser = db.GetUsers();
        }


    }
}
