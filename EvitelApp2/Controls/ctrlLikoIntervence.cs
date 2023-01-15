using EvitelApp2.Helper;
using EvitelLib2.Model;
using EvitelLib2.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using static EvitelApp2.frmMain;

namespace EvitelApp2.Controls
{
  public partial class ctrlLIKOIntervence : UserControl, IctrlWithDGW
  {
    private CRepositoryDB DB;
    private DataTable _dataTable;
    private DataSet _dataSet;
    List<WLikointervence> wIntervences = new List<WLikointervence>();
    BindingSource bindingSource1;
    private List<MyColumn> myColumns;
    private ColumnLayoutDB cldb;
    ToolStripMenuItem toolStripItem1 = new ToolStripMenuItem();
    public event RowInformation ShowRowInformation;   // delegat pro zobrazeni poctu radek
    public event DetailIntervence ShowDetailIntervence;
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


    public ctrlLIKOIntervence()
    {
      InitializeComponent();
    }

    private void ctrlIntervence_Load(object sender, EventArgs e)
    {
      if (DesignMode == false)
      {
        DB = new CRepositoryDB(Program.myLoggedUser.LoginUserId);
        MyResize();
      }

      myColumns = new List<MyColumn>()
      {
         new MyColumn { Name = "Id", DataPropertyName = "LikointervenceId", Type = 3 },
         new MyColumn { Name = "Datum čas", DataPropertyName = "DtStartIntervence",Type=5, isVisible = false},
         new MyColumn { Name = "Datum", DataPropertyName = "DateStartIntervence" , Type=5},
         new MyColumn { Name = "Čas", DataPropertyName = "TimeStartIntervence" },
         new MyColumn { Name = "Konec ", DataPropertyName = "DtEndIntervence",Type=5 },
         new MyColumn { Name = "Obětem Poškozeným", DataPropertyName = "ObetemPoskozenym" , Type = 3  },
         new MyColumn { Name = "Pozůstalým blízkým", DataPropertyName = "PozustalymBlizkym"  , Type = 3 },
         new MyColumn { Name = "Ostatním", DataPropertyName = "Ostatnim" , Type = 3  },
         new MyColumn { Name = "Pořadí", DataPropertyName = "Poradi", Type=3},
         new MyColumn { Name = "Intervent", DataPropertyName = "InterventShortName" },
         new MyColumn { Name = "Region", DataPropertyName = "RegionName"}
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

    private void ctrlIntervence_Resize(object sender, EventArgs e)
    {
      MyResize();
    }

    public void ReadDataFirstTime()
    {
      wIntervences = DB.GetWLIKOIntervence();
      AddDataToTable();
      UpdateColumn();
      cldb = new ColumnLayoutDB(DB, dgw, this.Name + _dataTable.TableName);
      cldb.SetColumnLayout();
    }

    private void CreateTable()
    {
      _dataTable = _dataSet.Tables.Add("wIntervence");
      foreach (var col in myColumns)
      {
        _dataTable.Columns.Add(col.Name, col.GetMyType());
      }
      bindingSource1.DataMember = _dataTable.TableName;
    }


    private void AddDataToTable()
    {
      _dataTable.Rows.Clear();
      foreach (var p in wIntervences)
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
      dgw.SortASC(dgw.Columns["Datum čas"]);

      toolStripItem1.Text = "Detail Intervence";
      toolStripItem1.Click += new EventHandler(toolStripItem1_Click);
      ContextMenuStrip strip = new ContextMenuStrip();
      foreach (DataGridViewColumn column in dgw.Columns)
      {
        column.ContextMenuStrip = strip;
        column.ContextMenuStrip.Items.Add(toolStripItem1);
      }


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

    private void dgw_RowEnter(object sender, DataGridViewCellEventArgs e)
    {
      ShowRowInformation?.Invoke(e.RowIndex + 1, wIntervences.Count);

    }

    private void dgw_DoubleClick(object sender, EventArgs e)
    {
      JumpToIntervence();

    }
    private void JumpToIntervence()
    {
      int? likoIntervenceId = (int)dgw.Rows[mouseLocation.RowIndex].Cells["ID"].Value;
      ShowDetailIntervence?.Invoke(3, likoIntervenceId);
    }

    private void toolStripItem1_Click(object sender, EventArgs args)
    {
      JumpToIntervence();
    }

    private void dgw_CellMouseEnter(object sender, DataGridViewCellEventArgs location)
    {
      mouseLocation = location;
    }

  }
}
