 using EvitelApp2.Controls;
using EvitelLib2.Common;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EvitelApp2.Helper
{

  public enum commandFromTable
  {
    callTable = 1,
    IncidentTable = 2,
    IntervenceTable = 3,
    ParticipantTable = 4,
    SkiReportTable = 5,
    LPKTable = 11,
    LPKFullTable = 12,
    EndOfScreen = 98,   // byvale -1
    ShowScreen = 99   // byvale -99
  };


  public static class Helper
  {

    public static void SelectItemByValue(this ComboBox cbo, int value)
    {
      for (int i = 0; i < cbo.Items.Count; i++)
      {
        if (((EvitelApp2.Controls.ComboItem)cbo.Items[i]).iValue == value) { 
          cbo.SelectedIndex = i;
          break;
        }
      }
    }
    public static int GetQuarter(this DateTime date)
    {
      if (date.Month >= 4 && date.Month <= 6)
        return 2;
      else if (date.Month >= 7 && date.Month <= 9)
        return 3;
      else if (date.Month >= 10 && date.Month <= 12)
        return 4;
      else
        return 1;
    }
    public static int GetHalfYear(this DateTime date)
    {
      if (date.Month > 6)
        return 2;
      else
        return 1;
    }

    // Najde vždy datum Pondělí 
    public static DateTime FirstDayOfWeek(this DateTime date)
    {
      int dayOfWeak = (int)date.DayOfWeek;
      if (dayOfWeak == 0)
        dayOfWeak = 7;
      return date.AddDays(-(dayOfWeak - 1));
    }

    public static DateTime FirstDayQuarter(this DateTime date)
    {
      return new DateTime(date.Year, (((date.GetQuarter() - 1) * 3) + 1), 1);
    }
    public static DateTime FirstDayHalfYear(this DateTime date)
    {
      return new DateTime(date.Year, (((date.GetHalfYear() - 1) * 6) + 1), 1);
    }

  }
}
