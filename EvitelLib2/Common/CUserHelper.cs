using EvitelLib2.Repository;
using System.Collections.Generic;
using System.Linq;

namespace EvitelLib2.Common
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
