using EvitelApp2.Helper;
using EvitelApp2.MyUserControl;
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
  public partial class ctrlParticipant : UserControl, IctrlWithDGW
  {
    private CRepositoryDB DB;

    private DataTable _dataTable;
    private DataSet _dataSet;
    List<WLikoparticipant> participants = new List<WLikoparticipant>();
    BindingSource bindingSource1;
    public List<MyColumn> myColumns;
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


    public ctrlParticipant()
    {
      InitializeComponent();
    }

    private void ctrlParticipation_Load(object sender, EventArgs e)
    {
      if (DesignMode == false)
      {
        DB = new CRepositoryDB(Program.myLoggedUser.LoginUserId);
      }
      myColumns = new List<MyColumn>()
      {
         new MyColumn { Name = "ID", DataPropertyName = "LikoparticipantId" , Type = 3},
         new MyColumn { Name = "IntervenceId", DataPropertyName = "LikointervenceId", Type = 3 },
         new MyColumn { Name = "Intervence datum", DataPropertyName = "DtIntervStart",  Type=5},
         new MyColumn { Name = "Čas int.", DataPropertyName = "TmIntervStart", Type=6},
         new MyColumn { Name = "Rok", DataPropertyName = "Year" , Type=3},
         new MyColumn { Name = "Měsíc", DataPropertyName = "Month" , Type=3},
         new MyColumn { Name = "Forma účasti", DataPropertyName = "TypePartyText" },
         new MyColumn { Name = "Pohlaví", DataPropertyName = "SexText"},
         new MyColumn { Name = "Věk", DataPropertyName = "Age" },
         new MyColumn { Name = "Smrt", DataPropertyName = "IsDead", Type = 2 },
         new MyColumn { Name = "Zranění", DataPropertyName = "IsInjury", Type = 2 },
         new MyColumn { Name = "Intervence", DataPropertyName = "IsIntervence", Type = 2 },
         new MyColumn { Name = "První Int.", DataPropertyName = "IsFirstIntervence", Type = 2 },
         new MyColumn { Name = "Druh Int.", DataPropertyName = "DruhIntervenceText" },
         new MyColumn { Name = "Poznámka", DataPropertyName = "Note" },
         new MyColumn { Name = "Souhlas", DataPropertyName = "IsAgreement", Type = 2 },
         new MyColumn { Name = "Kontakt", DataPropertyName = "IsContact", Type = 2 },
         new MyColumn { Name = "Policista", DataPropertyName = "IsPolicement", Type = 2 },
         new MyColumn { Name = "Blízká polic.", DataPropertyName = "IsPolicementClosePerson", Type = 2 },
         new MyColumn { Name = "Senior", DataPropertyName = "IsSenior", Type = 2 },
         new MyColumn { Name = "Mladiství", DataPropertyName = "IsChildJuvenile", Type = 2 },
         new MyColumn { Name = "ZTP", DataPropertyName = "IsHandyCappedMedical", Type = 2 },
         new MyColumn { Name = "Duševní por.", DataPropertyName = "IsHandyCappedMentally", Type = 2 },
         new MyColumn { Name = "Minorita", DataPropertyName = "IsMemberMinorityGroup", Type = 2 },
         new MyColumn { Name = "Intervent1", DataPropertyName = "InterventName" },
         new MyColumn { Name = "Intervent2", DataPropertyName = "InterventName2" },
         new MyColumn { Name = "Organizace", DataPropertyName = "Organization" },
         new MyColumn { Name = "Datum Intervence", DataPropertyName = "DtStartIntervence" },
         new MyColumn { Name = "Pořadí", DataPropertyName = "Poradi" , Type = 3},
         new MyColumn { Name = "Region", DataPropertyName = "UdalostRegion" },
         new MyColumn { Name = "Zapsal", DataPropertyName = "UserLastName" }
       };
      MyResize();
    }

    public void MyResize()
    {
      dgw.Top = dgw.Left = 0;
      dgw.Width = this.ClientSize.Width - 5;
      dgw.Height = this.ClientSize.Height;
    }
    private void ctrlParticipant_Resize(object sender, EventArgs e)
    {
      MyResize();
    }


    public void ReadDataFirstTime()
    {
      _dataTable = new DataTable();
      _dataSet = new DataSet();
      bindingSource1 = new BindingSource();
      bindingSource1.DataSource = _dataSet;
      dgw.SetDoubleBuffered();
      dgw.DataSource = bindingSource1;
      participants = DB.GeWLIKOParticipant(true);

      CreateTable();
      AddDataToTable();
      UpdateColumn();
      cldb = new ColumnLayoutDB(DB, dgw, this.Name + _dataTable.TableName);
      cldb.SetColumnLayout();
    }

    private void CreateTable()
    {
      _dataTable = _dataSet.Tables.Add("wParticipants");
      foreach (var col in myColumns)
      {
        _dataTable.Columns.Add(col.Name, col.GetMyType());
      }
      bindingSource1.DataMember = _dataTable.TableName;
    }


    private void AddDataToTable()
    {
      foreach (var p in participants)
      {
        DataRow newRow = _dataTable.NewRow();
        foreach (var col in myColumns)
        {
          var x = p.GetType().GetProperty(col.DataPropertyName).GetValue(p, null);
          if (x != null)
            newRow[col.Name] = x;
        }
        _dataTable.Rows.Add(newRow);
      }
    }

    private void UpdateColumn()
    {
      foreach (var col in myColumns)
      {
        dgw.Columns[col.Name].Visible = col.isVisible;
      }
      dgw.SortDESC(dgw.Columns["Intervence datum"]);
      dgw.SortDESC(dgw.Columns["Čas int."]);

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
      int ParticipantId = (int)dgw.Rows[mouseLocation.RowIndex].Cells["ID"].Value;
      int? likoIntervenceId = participants.Where(x => x.LikoparticipantId == ParticipantId)?.First().LikointervenceId;
      ShowDetailUserControl?.Invoke(4, likoIntervenceId);
    }

    private void toolStripItem1_Click(object sender, EventArgs args)
    {
      JumpToIntervence();
    }

    private void dgw_CellMouseEnter(object sender, DataGridViewCellEventArgs location)
    {
      mouseLocation = location;
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

  }
}
