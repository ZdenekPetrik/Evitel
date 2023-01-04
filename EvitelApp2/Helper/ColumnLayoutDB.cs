using EvitelLib2.Model;
using EvitelLib2.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EvitelApp2.Helper
{
  public class ColumnLayoutDB
  {
    private CRepositoryDB DB;
    private string uniqueName;
    private DataGridView dgw;

    public ColumnLayoutDB(CRepositoryDB DB, DataGridView dgw, string uniqueName)
    {
      this.DB = DB;
      this.dgw = dgw;
      this.uniqueName = uniqueName;
    }

    public void SetColumnLayout()
    {
      var configRows = DB.GetUserColumn(uniqueName);
      if (configRows != null)
      {
        if (configRows.Count == 0)
          return;
        if (configRows.Count != dgw.Columns.Count)
          return;
        var sorted = configRows.OrderBy(i => i.DisplayIndex);
        foreach (var item in sorted)
        {
          dgw.Columns[item.ColumnIndex ?? 0].DisplayIndex = item.DisplayIndex ?? (item.ColumnIndex ?? 0);
          dgw.Columns[item.ColumnIndex ?? 0].Width = item.Width ?? 100;
        }
      }
    }
    public void SaveColumnLayout()
    {
      try
      {
        List<UserColumn> userColumnList = new List<UserColumn>();
        DataGridViewColumnCollection columns = dgw.Columns;
        for (int i = 0; i < columns.Count; i++)
        {
          userColumnList.Add(new UserColumn
          {
            ColumnIndex = i,
            DisplayIndex = columns[i].DisplayIndex,
 //           Visible = columns[i].Visible,
            Width = columns[i].Width,
            Name = uniqueName,
            LoginUserId = DB.IdUser
          });
        }
        if (columns.Count > 0)
          DB.SaveUserColumn(uniqueName, DB.IdUser, userColumnList);
      }
      catch (Exception Ex)
      {
      }
    }
    public void DeleteColumnOrder()
    {
      DB.DeleteUserColumn(uniqueName, DB.IdUser);
    }
    public void InitializeColumns()
    {
      for (int i = 0; i < dgw.Columns.Count; i++)
      {
        dgw.Columns[i].DisplayIndex = i;
        dgw.Columns[i].Width = 100;
      }
    }

  }


}
