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
  public partial class ctrlLPK : UserControl, IctrlWithDGW
  {
    private CRepositoryDB DB;
    private DataTable _dataTable;
    private DataSet _dataSet;
    List<WLpk> wLpks = new List<WLpk>();
    BindingSource bindingSource1;
    private List<MyColumn> myColumns;
    private ColumnLayoutDB cldb;
    ToolStripMenuItem toolStripItem1 = new ToolStripMenuItem();
    public event RowInformation ShowRowInformation;
    public event DetailIntervence ShowDetailUserControl;
    private DataGridViewCellEventArgs mouseLocation;
    public DataTable dataTable { 
      get {
        DataView dv = new DataView(_dataTable);
        dv.RowFilter = dgw.FilterString; 
        dv.Sort= dgw.SortString;
        return dv.ToTable();
      }
    }
    public bool isEditMode = true;            // zobrazeni existujici intervence (tj. isNew == false). Tak ještě je třeba rozhodnout zdali smíme editovat.



    public ctrlLPK()
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
         new MyColumn { Name = "ID", DataPropertyName = "Lpkid", Type=3  },
         new MyColumn { Name = "Volání od", DataPropertyName = "DtStartCall",Type=5, isVisible = false},
         new MyColumn { Name = "Datum volání", DataPropertyName = "DtCall" , Type=5},
         new MyColumn { Name = "Začátek", DataPropertyName = "TmStartCall"  },
         new MyColumn { Name = "Konec", DataPropertyName = "TmEndCall"  },
         new MyColumn { Name = "Doba", DataPropertyName = "TmDuration"  },
         new MyColumn { Name = "Přezdívka", DataPropertyName = "Nick"},
         new MyColumn { Name = "Kontakt", DataPropertyName = "ContactType"},
         new MyColumn { Name = "Věk", DataPropertyName = "Age"},
         new MyColumn { Name = "Typ služby", DataPropertyName = "TypeService"},
         new MyColumn { Name = "Odkud je klient", DataPropertyName = "ClientFrom"},
         new MyColumn { Name = "Pohlaví", DataPropertyName = "Sex"},
         new MyColumn { Name = "Poznámka", DataPropertyName = "Note"},
         new MyColumn { Name = "Téma kontaktu", DataPropertyName = "ContactTopic"},
         new MyColumn { Name = "Aktuální stav klienta", DataPropertyName = "ClientCurrentStatus"},
         new MyColumn { Name = "Závěr hovoru", DataPropertyName = "EndOfSpeech"},
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
      wLpks = DB.GetWLPK();
      AddDataToTable();
      UpdateColumn();
      cldb = new ColumnLayoutDB(DB, dgw, this.Name + _dataTable.TableName);
      cldb.SetColumnLayout();
    }

    private void CreateTable()
    {
      _dataTable = _dataSet.Tables.Add("wLPK");
      foreach (var col in myColumns)
      {
        _dataTable.Columns.Add(col.Name, col.GetMyType());
      }
      bindingSource1.DataMember = _dataTable.TableName;
    }


    private void AddDataToTable()
    {
      _dataTable.Rows.Clear();
      foreach (var p in wLpks)
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
      dgw.SortASC(dgw.Columns["Volání od"]);

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

    private void dgw_RowEnter(object sender, DataGridViewCellEventArgs e)
    {
      ShowRowInformation?.Invoke(e.RowIndex + 1, wLpks.Count);
    }

    private void dgw_DoubleClick(object sender, EventArgs e)
    {
      JumpToIntervence();
    }

    private void JumpToIntervence()
    { int lpkId = (int)dgw.Rows[mouseLocation.RowIndex].Cells["ID"].Value;
      ShowDetailUserControl?.Invoke(11, lpkId);
    }

    private void dgw_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {

    }
  }
}
