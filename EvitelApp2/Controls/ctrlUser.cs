using EvitelApp2.Forms1;
using EvitelApp2.Helper;
using EvitelApp2.MyUserControl;
using EvitelLib2.Common;
using EvitelLib2.Model;
using EvitelLib2.Repository;
using Newtonsoft.Json;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using static EvitelApp2.Controls.frmTestEndNPOI;
using static EvitelApp2.frmMain;

namespace EvitelApp2.Controls
{
  public partial class ctrlUser : UserControl, IctrlWithDGW
  {
    private CRepositoryDB DB;
    private DataTable _dataTable;
    private DataSet _dataSet;
    List<LoginUser> loginUserList = new List<LoginUser>();
    List<LoginAccess> loginAccessList = new List<LoginAccess>();
    BindingSource bindingSource1;
    private List<MyColumn> myColumns;
    private ColumnLayoutDB cldb;
    ToolStripMenuItem toolStripItem1 = new ToolStripMenuItem();
    public event RowInformation ShowRowInformation;
    private DataGridViewCellEventArgs mouseLocation;
    public DataTable dataTable { get { return _dataTable; } }


    public ctrlUser()
    {
      InitializeComponent();
    }

    private void ctrlLikoCall_Load(object sender, EventArgs e)
    {
      if (DesignMode == false)
      {
        DB = new CRepositoryDB(Program.myLoggedUser.LoginUserId);
        MyResize();
      }

      myColumns = new List<MyColumn>()
      {
         new MyColumn { Name = "LoginUserId", DataPropertyName = "LoginUserId", Type=3 ,  isVisible = false },
         new MyColumn { Name = "Jméno", DataPropertyName = "FirstName"},
         new MyColumn { Name = "Přijmení", DataPropertyName = "LastName" },
         new MyColumn { Name = "Přihlašovací jméno", DataPropertyName = "LoginName"  },
         new MyColumn { Name = "Vytvořeno", DataPropertyName = "Created" , Type=5 },
         new MyColumn { Name = "Přístupy", DataPropertyName = "Access"  }
        };
      _dataTable = new DataTable();
      _dataSet = new DataSet();
      bindingSource1 = new BindingSource();
      bindingSource1.DataSource = _dataSet;
      dgw.SetDoubleBuffered();
      dgw.DataSource = bindingSource1;
      CreateTable();
    }
    public void MyResize()
    {
      dgw.Top = dgw.Left = 0;
      dgw.Width = this.ClientSize.Width - 5;
      dgw.Height = this.ClientSize.Height;
    }

    private void ctrlLikoCall_Resize(object sender, EventArgs e)
    {
      MyResize();
    }



    public void ReadDataFirstTime()
    {
      loginUserList = DB.GetLoginUser();
      loginAccessList = DB.GetLoginAccess();
      AddDataToTable();
      UpdateColumn();
      cldb = new ColumnLayoutDB(DB, dgw, this.Name + _dataTable.TableName);
      cldb.SetColumnLayout();
    }

    private void CreateTable()
    {
      _dataTable = _dataSet.Tables.Add("wLoginUser");
      foreach (var col in myColumns)
      {
        _dataTable.Columns.Add(col.Name, col.GetMyType());
      }
      bindingSource1.DataMember = _dataTable.TableName;
    }


    private void AddDataToTable()
    {
      _dataTable.Rows.Clear();
      foreach (var user in loginUserList)
      {
        DataRow newRow = _dataTable.NewRow();
        foreach (var col in myColumns)
        {
          if (col.DataPropertyName == "Access")
            newRow[col.Name] = GetAccessAcronym(user);
          else
            newRow[col.Name] = user.GetType().GetProperty(col.DataPropertyName).GetValue(user, null); ;
        }
        //          
        _dataTable.Rows.Add(newRow);
      }
    }

    private string GetAccessAcronym(LoginUser user)
    {
      var access = loginAccessList.Where(p => user.LoginAccessUsers.Any(p2 => p2.LoginAccessId == p.LoginAccessId));
      if (access.Count() == 0)
        return "Disabled";
      return String.Join(',', access.Select(x => x.AccessShortName));
    }

    private void UpdateColumn()
    {
      foreach (var col in myColumns)
      {
        dgw.Columns[col.Name].Visible = col.isVisible;
      }
      dgw.SortASC(dgw.Columns["Přijmení"]);

      toolStripItem1.Text = "Detail uživatele ";
      toolStripItem1.Click += new EventHandler(toolStripItem1_Click);
      ContextMenuStrip strip = new ContextMenuStrip();
      foreach (DataGridViewColumn column in dgw.Columns)
      {
        column.ContextMenuStrip = strip;
        column.ContextMenuStrip.Items.Add(toolStripItem1);
      }
    }

    private void toolStripItem1_Click(object sender, EventArgs args)
    {
      JumpToDetail();
    }
    private void dgw_CellMouseEnter(object sender, DataGridViewCellEventArgs location)
    {
      mouseLocation = location;
    }

    public void RemoveFilters()
    {
      dgw.CleanFilter();
    }
    public void RemoveOrders()
    {
      dgw.CleanSort();
    }

    public void InitColumns()
    {
      cldb.DeleteColumnOrder();
      cldb.InitializeColumns();
    }
    public void SetColumns()
    {
      cldb.SaveColumnLayout();
    }
    public void Visibility(bool isVisibility)
    {
      Visible = isVisibility;
      if (Visible)
        dgw_RowEnter(null, new DataGridViewCellEventArgs(0, dgw.CurrentCell.RowIndex));
      else
      {
        ShowRowInformation?.Invoke(-1, -1);
      }
    }

    private void dgw_RowEnter(object sender, DataGridViewCellEventArgs e)
    {
      ShowRowInformation?.Invoke(e.RowIndex + 1, dgw.RowCount);
    }

    private void dgw_DoubleClick(object sender, EventArgs e)
    {
      JumpToDetail();
    }

    private void JumpToDetail()
    {
      int LoginUserId = (int)dgw.Rows[mouseLocation.RowIndex].Cells["LoginUserId"].Value;
      LoginUser loginUser = loginUserList.Where(x => x.LoginUserId == LoginUserId)?.First();

      var isAdmin = loginUser.LoginAccessUsers.Where(x => x.LoginAccessId == (int)eLoginAccess.Admin).Count() == 1;               // jsem administrátor
      var nrAdmins = loginUserList.Where(d => d.LoginAccessUsers.Any(s => s.LoginAccessId == (int)eLoginAccess.Admin)).Count();   // Počet ostatních adminů

      frmUser frm = new frmUser();
      frm.loginUser = loginUser;
      frm.loginAccessList = loginAccessList;
      frm.StartPosition = FormStartPosition.CenterScreen;
      frm.Type = 2;
      frm.isLastAdmin = (isAdmin && nrAdmins==1);
      frm.ShowDialog();
      if (frm.isOK)
      {
        DB.UpdateLoginUser(loginUser);
        RefreshData();
      }
    }

    public void RefreshData()
    {
      loginUserList = DB.GetLoginUser();
      loginAccessList = DB.GetLoginAccess();
      AddDataToTable();
    }
  }
}
