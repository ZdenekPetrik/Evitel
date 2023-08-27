using EvitelApp2.Helper;
using EvitelLib2.Model;
using EvitelLib2.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using static EvitelApp2.frmMain;

namespace EvitelApp2.Controls
{
  public partial class ctrlLIKOIncident : UserControl, IctrlWithDGW
  {
    private CRepositoryDB DB;
    private DataTable _dataTable;
    private DataSet _dataSet;
    List<WLikoincident> wIncidents = new List<WLikoincident>();
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


    public ctrlLIKOIncident()
    {
      InitializeComponent();
    }

    private void ctrlIncident_Load(object sender, EventArgs e)
    {
      if (DesignMode == false)
      {
        DB = new CRepositoryDB(Program.myLoggedUser.LoginUserId);
        MyResize();
      }

      myColumns = new List<MyColumn>()
      {

         new MyColumn { Name = "ID", DataPropertyName = "LikoincidentId" , Type = 3},
         new MyColumn { Name = "Datum", DataPropertyName = "DtUdalost", Type=5},
         new MyColumn { Name = "Čas", DataPropertyName = "TmUdalost", Type=6},
         new MyColumn { Name = "Rok", DataPropertyName = "Year",Type=3},
         new MyColumn { Name = "Měsíc", DataPropertyName = "Month",Type=3},
         new MyColumn { Name = "Událost", DataPropertyName = "DruhUdalosti"},
         new MyColumn { Name = "Kategorie", DataPropertyName = "KategorieUdalosti"},
         new MyColumn { Name = "Kraj", DataPropertyName = "UdalostRegion"},
         new MyColumn { Name = "Místo", DataPropertyName = "UdalostMisto"},
         new MyColumn { Name = "Následek Smrti", DataPropertyName = "NasledekSmrti", Type = 2},
         new MyColumn { Name = "Dokonané", DataPropertyName = "Dokonane", Type = 2},
         new MyColumn { Name = "Pokus Příprava", DataPropertyName = "PokusPriprava", Type = 2},
         new MyColumn { Name = "Počet Poškocených", DataPropertyName = "PocetPoskozenych",Type=3},
         new MyColumn { Name = "Poznámka", DataPropertyName = "UdalostNote"},
         new MyColumn { Name = "Volání datum", DataPropertyName = "DtCall", Type=5},
         new MyColumn { Name = "Čas tf. ", DataPropertyName = "TmCall", Type=6},
         new MyColumn { Name = "CallId", DataPropertyName = "CallId", Type=3  },
         new MyColumn { Name = "Volajici", DataPropertyName = "Volajici"},
         new MyColumn { Name = "Kraj Volajicí", DataPropertyName = "VolajiciKraj"},
         new MyColumn { Name = "Zapsal", DataPropertyName = "UserLastName" }
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
      wIncidents = DB.GetWLIKOIncident();
      AddDataToTable();
      UpdateColumn();
      cldb = new ColumnLayoutDB(DB, dgw, this.Name + _dataTable.TableName);
      cldb.SetColumnLayout();
    }

    private void CreateTable()
    {
      _dataTable = _dataSet.Tables.Add("wIncident");
      foreach (var col in myColumns)
      {
        _dataTable.Columns.Add(col.Name, col.GetMyType());
      }
      bindingSource1.DataMember = _dataTable.TableName;
    }


    private void AddDataToTable()
    {
      _dataTable.Rows.Clear();
      foreach (var p in wIncidents)
      {
        DataRow newRow = _dataTable.NewRow();
        foreach (var col in myColumns)
        {
          var x = p.GetType().GetProperty(col.DataPropertyName).GetValue(p, null);
          if (x != null)
            newRow[col.Name] = x;
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
      dgw.SortDESC(dgw.Columns["Datum"]);
      dgw.SortDESC(dgw.Columns["Čas"]);

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
    }


    private void dgw_DoubleClick(object sender, EventArgs e)
    {
      if (mouseLocation.RowIndex >= 0)
        JumpToIntervence();
    }

    private void JumpToIntervence()
    {
      int Id = (int)dgw.Rows[mouseLocation.RowIndex].Cells["ID"].Value;
      var x = DB.GetWLIKOIntervence();
      int? likoIntervenceId = DB.GetWLIKOIntervence().Where(x => x.LikoincidentId == Id && x.IntervPoradi == 1).FirstOrDefault().LikointervenceId;
      ShowDetailUserControl?.Invoke(Helper.commandFromTable.IncidentTable, likoIntervenceId);
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
