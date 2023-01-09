using EvitelApp2.Controls;
using EvitelLib2.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EvitelApp2.Helper
{
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
  }
}
