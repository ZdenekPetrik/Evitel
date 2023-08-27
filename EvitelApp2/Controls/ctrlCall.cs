using EvitelApp2.Helper;
using EvitelApp2.MyUserControl;
using EvitelLib2;
using EvitelLib2.Common;
using EvitelLib2.Model;
using EvitelLib2.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using static EvitelApp2.Controls.frmTestEndNPOI;
using static EvitelApp2.frmMain;

namespace EvitelApp2.Controls
{
  public partial class ctrlCall : UserControl, IctrlWithDGW
  {
    private CRepositoryDB DB;
    private DataTable _dataTable;
    private DataSet _dataSet;
    List<WCall> wCalls = new List<WCall>();
    BindingSource bindingSource1;
    private List<MyColumn> myColumns;
    private ColumnLayoutDB cldb;
    public event RowInformation ShowRowInformation;
    public event DetailIntervence ShowDetailUserControl;
    private DataGridViewCellEventArgs mouseLocation;
    public DataTable dataTable
    {
      get
      {
        DataView dv = new DataView(_dataTable);
        dv.RowFilter = dgw.FilterString;
        dv.Sort = dgw.SortString;
        return dv.ToTable();
      }
    }
    public bool isEditMode = true;            // zobrazeni existujici intervence (tj. isNew == false). Tak ještě je třeba rozhodnout zdali smíme editovat.



    public ctrlCall()
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
         new MyColumn { Name = "ID", DataPropertyName = "CallId", Type=3  },
         new MyColumn { Name = "Datum volání", DataPropertyName = "DtCall" , Type=5},
         new MyColumn { Name = "Rok", DataPropertyName = "Year" , Type=3},
         new MyColumn { Name = "Měsíc", DataPropertyName = "Month" , Type=3},
         new MyColumn { Name = "Typ Hovoru", DataPropertyName = "CallType"},
         new MyColumn { Name = "Začátek", DataPropertyName = "TmStartCall"  },
         new MyColumn { Name = "Konec", DataPropertyName = "TmEndCall"  },
         new MyColumn { Name = "Doba", DataPropertyName = "TmDuration"  },
         new MyColumn { Name = "Volající", DataPropertyName = "InterventShortName"},
         new MyColumn { Name = "Region", DataPropertyName = "RegionName"},
         new MyColumn { Name = "Přezdívka", DataPropertyName = "Nick"},
         new MyColumn { Name = "Kontakt", DataPropertyName = "ContactType"},
         new MyColumn { Name = "Zapsal", DataPropertyName = "UsrLastName" },
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
      wCalls = DB.GetWCalls();
      AddDataToTable();
      UpdateColumn();
      cldb = new ColumnLayoutDB(DB, dgw, this.Name + _dataTable.TableName);
      cldb.SetColumnLayout();
    }

    private void CreateTable()
    {
      _dataTable = _dataSet.Tables.Add("wCall");
      foreach (var col in myColumns)
      {
        _dataTable.Columns.Add(col.Name, col.GetMyType());
      }
      bindingSource1.DataMember = _dataTable.TableName;
    }


    private void AddDataToTable()
    {
      _dataTable.Rows.Clear();
      foreach (var p in wCalls)
      {
        DataRow newRow = _dataTable.NewRow();
        foreach (var col in myColumns)
        {
          newRow[col.Name] = p.GetType().GetProperty(col.DataPropertyName).GetValue(p, null); ;
        }
        //          
        _dataTable.Rows.Add(newRow);
      }
    }


    private void UpdateColumn()
    {
      foreach (var col in myColumns)
      {
        dgw.Columns[col.Name].Visible = col.isVisible;
      }
      dgw.SortDESC(dgw.Columns["Datum volání"]);
      dgw.SortDESC(dgw.Columns["Začátek"]);
      ToolStripMenuItem toolStripItem1 = new ToolStripMenuItem();
      toolStripItem1.Text = "Detail Hovoru";
      toolStripItem1.Click += new EventHandler(toolStripItem1_Click);
      ToolStripMenuItem toolStripItem2 = new ToolStripMenuItem();
      toolStripItem2.Text = "Smazat Hovor";
      toolStripItem2.Click += new EventHandler(toolStripItem2_Click);
      ContextMenuStrip strip = new ContextMenuStrip();
      foreach (DataGridViewColumn column in dgw.Columns)
      {
        column.ContextMenuStrip = strip;
        column.ContextMenuStrip.Items.Add(toolStripItem1);
        if (Program.myLoggedUser.HasAccess(eLoginAccess.Admin))
          column.ContextMenuStrip.Items.Add(toolStripItem2);
      }
    }

    private void toolStripItem1_Click(object sender, EventArgs args)
    {
      JumpToIntervence();
    }
    private void toolStripItem2_Click(object sender, EventArgs args)
    {
      DeleteRow();
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
      if (dgw.CurrentCell != null && Visible)
        dgw_RowEnter(null, new DataGridViewCellEventArgs(0, dgw.CurrentCell.RowIndex));
      else
      {
        ShowRowInformation?.Invoke(-1, -1);
      }
    }
    private void dgw_RowEnter(object sender, DataGridViewCellEventArgs e)
    {
      ShowRowInformation?.Invoke(e.RowIndex + 1, dgw.RowCount);
      var r = NajdiRowIdInAnyTable(e.RowIndex);
      int IdInTable = r.Item2;
      eCallType callType = r.Item1;
      foreach (DataGridViewColumn column in dgw.Columns)
      {
        //column.ContextMenuStrip.Items[1].Visible = (IdInTable == 0);
      }

    }
    private void dgw_DoubleClick(object sender, EventArgs e)
    {
      JumpToIntervence();
    }

    private void JumpToIntervence()
    {
      var r = NajdiRowIdInAnyTable(mouseLocation.RowIndex);
      int IdInTable = r.Item2;
      eCallType callType = r.Item1;
      int CallID = r.Item3;
      if (callType == eCallType.eLPvK && IdInTable > 0)
      {
        ShowDetailUserControl?.Invoke(Helper.commandFromTable.LPKTable, IdInTable);
      }
      else if (callType == eCallType.eLIKO && IdInTable > 0)
      {
        ShowDetailUserControl?.Invoke(Helper.commandFromTable.callTable, IdInTable);
      }
      else if (callType == eCallType.eUnknown)
      {
        MessageBox.Show($"Ani LPvK ani SKI. To Je Divná věta.");
      }
      else
      {
        MessageBox.Show($"K tomuto {callType} hovoru nejsou přiřazeny žádné další informace. CallId = {CallID}");
      }
    }

    private Tuple<eCallType, int, int> NajdiRowIdInAnyTable(int rowIndex)
    {
      int IdTable = 0;
      eCallType callType = eCallType.eUnknown;

      int CallId = (int)dgw.Rows[rowIndex].Cells["ID"].Value;
      int? callTypeId = wCalls.Where(x => x.CallId == CallId)?.First().CallTypeId;
      if (callTypeId == 1)
      {
        IdTable = wCalls.Where(x => x.CallId == CallId)?.First().Lpkid ?? 00;
        callType = eCallType.eLPvK;
      }
      else if (callTypeId == 2)
      {
        IdTable = wCalls.Where(x => x.CallId == CallId)?.First().LikointervenceId ?? 00;
        callType = eCallType.eLIKO;
      }
      return new Tuple<eCallType, int, int>(callType, IdTable, CallId);
    }


    private void DeleteRow()
    {
      var r = NajdiRowIdInAnyTable(mouseLocation.RowIndex);
      int IdInTable = r.Item2;
      eCallType callType = r.Item1;
      int dbReturn = 0;
      int callId = r.Item3;
      if (IdInTable == 0)
      {
        var msgBoxReturn = MessageBox.Show($"Opravdu smazat hovor CallID = {callId}.", "Mazání hovoru", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
        if (msgBoxReturn == DialogResult.Yes)
        {
          dbReturn = DB.DeleteCallRow(callId);
          if (dbReturn == 1)
            dgw.Rows.RemoveAt(mouseLocation.RowIndex);
          else
            MessageBox.Show(DB.sErr);
        }
      }
      else {
        MessageBox.Show($"Nelze smazat hovor {callType}. Hovor lze smazat pouze pokud není ani LPvK ani SKI" , "Mazání hovoru", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
    }
  }
}
