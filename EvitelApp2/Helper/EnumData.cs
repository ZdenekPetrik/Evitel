using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvitelApp2.Helper
{
  
  public enum eAllCodeBooks
  {
    eSex = 1,
    eSubTypeIncident,
    eTypeIncident,
    eTypeParty,
    eRegions,
    eIntervents,
    eDruhIntervence,
    eNick,
    eEndOfSpeech,
    eSubEndOfSpeech,
    eClientCurrentStatus,
    eSubClientCurrentStatus,
    eContactTopic,
    eSubContactTopic,
    eContactType,
    eAge,
    eClientFrom,
    eTypeService
  }

  public class EnumData
  {
    public string Title { get; set; }
    public List<MyColumn> myColumns = new List<MyColumn>();
  }

}
