using EvitelLib.Entity;
using EvitelLib.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvitelLib.Common
{
    public static class CStateHelper
    {
        static List<State> cacheState;


        public static string GetEventDescriptionValue(eEventCode evCode)
        {
            if (cacheState == null)
            {
                ReadCache();
            }
            var x = from s in cacheState where s.StateType == 99 && s.StateValue == (int)evCode select s;
            if (x.Count() > 0)
                return x.First().DescriptionValue;
            return evCode.ToString() + " no exists in DB as EventCode";
        }
        public static string GetEventSubDescriptionValue(eEventSubCode evSubCode)
        {
            if (cacheState == null)
            {
                ReadCache();
            }
            var x = from s in cacheState where s.StateType == 98 && s.StateValue == (int)evSubCode select s;
            if (x.Count() > 0)
                return x.First().DescriptionValue;
            return evSubCode.ToString() + " no exists in DB as EventCode";
        }

        private static void ReadCache() {
            CRepositoryDB db = new CRepositoryDB(-5);
            cacheState = db.GetAllStates();
        }


    }
}
