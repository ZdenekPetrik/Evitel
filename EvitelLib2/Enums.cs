using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvitelLib2
{
  public enum eEventCode
  {
    e1Program = 101,
    e1Login = 102,
    e1Message = 103,
    e1DBChange = 104
  };
  public enum eEventSubCode
  {
    e2Start = 1,
    e2Stop = 2,
    e2BadLogin = 3,
    e2ChangePassword = 4,

    e2Error = 11,
    e2Warning = 12,
    e2Info = 13,
    e2Debug = 13,

    e2Create = 21,
    e2Modify = 22,
    e2Remove = 23,

    e2CallTable = 51,
    e2IntervenceTable = 52,
    e2IncidentTable = 53,
    e2LPvKTable = 59,

    e2CodeBook = 61
  };

  public enum eCallType
  {
    eLIKO = 2,
    ePLK = 1
  };

}
