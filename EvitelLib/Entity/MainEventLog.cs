using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvitelLib.Entity
{
    public class MainEventLog
    {
        [Key]
        public int Id { get; set; }
        public DateTime dtCreate { get; set; }
        public int LoginUserId { get; set; }
        public EventCode eventType { get; set; }
        public EventSubCode eventSubType { get; set; }
        [MaxLength(50)]
        public string Program { get; set; }
        public string Text { get; set; }
        public string Value { get; set; }
    }
    public enum EventCode
    {
        e1Program = 100,
        e1Login = 102,
        e1Message = 103,
        e1Debug = 104,
        e1CheckSum = 105
    };
    public enum EventSubCode
    {
        e2Start = 1,
        e2Stop,
        e2Error,
        e2Warning,
        e2Info,
        e2BadLogin,
        e2ChangePassword,

        // e1Invoice
        e2Create,
        e2AddOrder,
        e2RemoveOrder,
        e2Remove,
        e2Modify,
        // e1Expenditure
        e2SecondsOrMore,     // druha a dalsi objednávka k případu se nepřenáší
        e2ManualAdd,        // manuální přidání Expenditure
        e2ParujAdd,         // Parovani Expenditure s Objednavkou
        e2ParujRemove,       // Odstraneni Parovani 
        e2Parovani,          // Zprava k parovani (varovani)
        e2ManualChange       // Manuální změna nad Fakturou/File. Třeba změna stavu. 
    };



}
