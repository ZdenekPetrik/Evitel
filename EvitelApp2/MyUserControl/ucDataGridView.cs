using EvitelLib2.Model;
using EvitelLib2.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Windows.Forms;

namespace EvitelApp2.MyUserControl
{
    [Description("DataGridView that Saves Column Order, Width and Visibility to user.config")]
    public class ucDataGridView : DataGridView
    {
        private string _UniqueString;
        private CRepositoryDB _DB;
        public UserSort mySort;
        private string fullUniqueString { get { return _UniqueString + "_" + this.Name; } set { } }

        public ucDataGridView() : base()
        {
            mySort = new UserSort();
        }

        public ucDataGridView(IContainer container) : this()
        {
            container.Add(this);
        }


        public void SetColumnOrderExt(string UniqueString, CRepositoryDB DB)
        {
            _UniqueString = UniqueString;
            _DB = DB;
            SetColumnOrder();
        }

        private void SetColumnOrder()
        {
            var configRows = _DB.GetUserColumn(fullUniqueString);

            if (configRows.Count() == 0)
                return;

          //  List<ColumnOrderItem1> columnOrder = ucDataGridViewDB.Default.ColumnOrder[fullUniqueString];

            if (configRows != null)
            {
                var sorted = configRows.OrderBy(i => i.DisplayIndex);
                foreach (var item in sorted)
                {
                    this.Columns[item.ColumnIndex??0].DisplayIndex = item.DisplayIndex ?? (item.ColumnIndex ?? 0);
                    this.Columns[item.ColumnIndex??0].Visible = item.Visible ?? true;
                    this.Columns[item.ColumnIndex??0].Width = item.Width ?? 100;
                }
            }
        }
        //---------------------------------------------------------------------
        private void SaveColumnOrder()
        {
            if (this.AllowUserToOrderColumns)
            {
                try
                {
                    /*
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

                    ucDataGridViewSetting.Default.ColumnOrder[_UniqueString + "_" + this.Name] = columnOrder;
                    ucDataGridViewSetting.Default.Save();
                    */
                    List<UserColumn> userColumnList = new List<UserColumn>();
                    List<ColumnOrderItem> columnOrder = new List<ColumnOrderItem>();
                    DataGridViewColumnCollection columns = this.Columns;
                    for (int i = 0; i < columns.Count; i++)
                    {
                        userColumnList.Add(new UserColumn
                        {
                            ColumnIndex = i,
                            DisplayIndex = columns[i].DisplayIndex,
                            Visible = columns[i].Visible,
                            Width = columns[i].Width,
                            Name = fullUniqueString,
                            LoginUserId = _DB.IdUser
                        });
                    }
                    if (columns.Count > 0)
                        _DB.SaveUserColumn(fullUniqueString, _DB.IdUser, userColumnList);
                }
                catch (Exception Ex) {
                }
            }
        }
        //---------------------------------------------------------------------
        protected override void OnCreateControl()
        {
            base.OnCreateControl();
        }
        //---------------------------------------------------------------------
        protected override void Dispose(bool disposing)
        {
            SaveColumnOrder();
            base.Dispose(disposing);
        }

        internal void SetColumnOrder(string name)
        {
        }
    }

    internal sealed class ucDataGridViewDB : ApplicationSettingsBase
    {

        private static ucDataGridViewDB _defaultInstace = new ucDataGridViewDB();
        public static ucDataGridViewDB Default
        {
            get { return _defaultInstace; }
        }
        public Dictionary<string, List<ColumnOrderItem1>> ColumnOrder
        {
            get { return this["ColumnOrder"] as Dictionary<string, List<ColumnOrderItem1>>; }
            set { this["ColumnOrder"] = value; }
        }

   
    }

}
public sealed class ColumnOrderItem1
{
    public int DisplayIndex { get; set; }
    public int Width { get; set; }
    public bool Visible { get; set; }
    public int ColumnIndex { get; set; }
}



//-------------------------------------------------------------------------
internal sealed class ucDataGridViewSetting : ApplicationSettingsBase
{
    private static ucDataGridViewSetting _defaultInstace =
        (ucDataGridViewSetting)ApplicationSettingsBase
        .Synchronized(new ucDataGridViewSetting());
    //---------------------------------------------------------------------
    public static ucDataGridViewSetting Default
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
public sealed class UserSort
{
    public string ColumnName;
    public ListSortDirection Order = ListSortDirection.Ascending;
    public string OrderString
    {
        get
        {
            if (Order == ListSortDirection.Ascending)
                return " ASC";
            else
                return " DESC";
        }
    }
}
