using EvitelApp2.Helper;
using EvitelApp2.MyUserControl;
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
  public partial class ctrlLikoCall : UserControl, IctrlWithDGW
  {
    private CRepositoryDB DB;
    private DataTable _dataTable;
    private DataSet _dataSet;
    List<WLikocall> wLikoCalls = new List<WLikocall>();
    BindingSource bindingSource1;
    private List<MyColumn> myColumns;
    private ColumnLayoutDB cldb;
    ToolStripMenuItem toolStripItem1 = new ToolStripMenuItem();
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



    public ctrlLikoCall()
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
         new MyColumn { Name = "Volající", DataPropertyName = "InterventShortName"},
         new MyColumn { Name = "Region", DataPropertyName = "RegionName"},
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
      wLikoCalls = DB.GetWLikoCalls();
      AddDataToTable();
      UpdateColumn();
      cldb = new ColumnLayoutDB(DB, dgw, this.Name + _dataTable.TableName);
      cldb.SetColumnLayout();
    }

    private void CreateTable()
    {
      _dataTable = _dataSet.Tables.Add("wLikoCall");
      foreach (var col in myColumns)
      {
        _dataTable.Columns.Add(col.Name, col.GetMyType());
      }
      bindingSource1.DataMember = _dataTable.TableName;
    }


    private void AddDataToTable()
    {
      _dataTable.Rows.Clear();
      foreach (var p in wLikoCalls)
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

      toolStripItem1.Text = "Detail Hovoru";
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
      JumpToIntervence();
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
      if (mouseLocation.RowIndex >= 0)
        JumpToIntervence();
    }

    private void JumpToIntervence()
    {
      int CallId = (int)dgw.Rows[mouseLocation.RowIndex].Cells["ID"].Value;
      int? likoIntervenceId = wLikoCalls.Where(x => x.CallId == CallId)?.First().LikointervenceId;
      ShowDetailUserControl?.Invoke(1, likoIntervenceId);
    }

    private void dgw_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {

    }

    private void dgw_FilterStringChanged(object sender, Zuby.ADGV.AdvancedDataGridView.FilterEventArgs e)
    {

    }
  }
}
