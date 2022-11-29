using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Windows.Forms;

namespace EvitelApp.Components
{
  public partial class DataGridViewExt : DataGridView
  {
    private string _UniqueString;
    public UserSort mySort;
    public DataGridViewExt()
    {
      mySort = new UserSort();
      InitializeComponent();
    }

    public DataGridViewExt(IContainer container):this()
    {
      container.Add(this);
    }

 
    private void SetColumnOrder()
    {
      if (!gfDataGridViewSetting.Default.ColumnOrder.ContainsKey(_UniqueString+"_"+this.Name))
        return;

      List<ColumnOrderItem> columnOrder =
        gfDataGridViewSetting.Default.ColumnOrder[_UniqueString + "_" + this.Name];

      if (columnOrder != null)
      {
        var sorted = columnOrder.OrderBy(i => i.DisplayIndex);
        foreach (var item in sorted)
        {
          if (this.Columns.Count > item.ColumnIndex)
          {
            this.Columns[item.ColumnIndex].DisplayIndex = item.DisplayIndex;
            this.Columns[item.ColumnIndex].Visible = item.Visible;
            this.Columns[item.ColumnIndex].Width = item.Width;
          }
        }
      }
    }
    //---------------------------------------------------------------------
    private void SaveColumnOrder()
    {
      if (this.AllowUserToOrderColumns)
      {
        List<ColumnOrderItem> columnOrder = new List<ColumnOrderItem>();
        DataGridViewColumnCollection columns = this.Columns;
        for (int i = 0; i < columns.Count; i++)
        {
          columnOrder.Add(new ColumnOrderItem
          {
            ColumnIndex = i,
            DisplayIndex = columns[i].DisplayIndex,
            Visible = columns[i].Visible,
            Width = columns[i].Width
          });
        }

        gfDataGridViewSetting.Default.ColumnOrder[_UniqueString + "_" + this.Name] = columnOrder;
 //       gfDataGridViewSetting.Default.Save();
      }
    }
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        SaveColumnOrder();
        components.Dispose();
      }
      base.Dispose(disposing);
    }
     //---------------------------------------------------------------------
 
  }
//   c:\Users\petrikz\AppData\Local\SelfiAdmin\SelfiAdmin.vshost.exe_Url_w4nnd3ic2nxa0jhasmfc1dakhg5mrps4\1.0.0.0\

  internal sealed class gfDataGridViewSetting : ApplicationSettingsBase
  {
    private static gfDataGridViewSetting _defaultInstace =
      (gfDataGridViewSetting)ApplicationSettingsBase
      .Synchronized(new gfDataGridViewSetting());
    //---------------------------------------------------------------------
    public static gfDataGridViewSetting Default
    {
      get { return _defaultInstace; }
    }
    //---------------------------------------------------------------------
    // Because there can be more than one DGV in the user-application
    // a dictionary is used to save the settings for this DGV.
    // As key the name of the control is used.
    [UserScopedSetting]
    [SettingsSerializeAs(SettingsSerializeAs.Binary)]
    [DefaultSettingValue("")]
    public Dictionary<string, List<ColumnOrderItem>> ColumnOrder
    {
      get { return this["ColumnOrder"] as Dictionary<string, List<ColumnOrderItem>>; }
      set { this["ColumnOrder"] = value; }
    }
  }
  //-------------------------------------------------------------------------
  [Serializable]
  public sealed class ColumnOrderItem
  {
    public int DisplayIndex { get; set; }
    public int Width { get; set; }
    public bool Visible { get; set; }
    public int ColumnIndex { get; set; }
  }

  public sealed class UserSort{
    public string ColumnName;
    public ListSortDirection Order = ListSortDirection.Ascending;
    public string OrderString {
      get
      {
        if (Order == ListSortDirection.Ascending)
          return " ASC";
        else
          return " DESC";
      }
    }
  }

   

}
