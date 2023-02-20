using EvitelApp2.Forms1.Ciselnik;
using EvitelApp2.Helper;
using EvitelLib2.Common;
using EvitelLib2.Model;
using EvitelLib2.Repository;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static EvitelApp2.frmMain;

namespace EvitelApp2.Controls
{
  public partial class ucIntervents : UserControl, IctrlWithDGW
  {

    private CRepositoryDB DB;
    private DataTable _dataTable;
    private DataSet _dataSet;
    private List<WIntervent> winterventi = null;
    BindingSource bindingSource1;
    private ColumnLayoutDB cldb;

    public bool isData { get { return winterventi != null; } }       // info zda uz data byla nactena
    private bool isEditModeAllowed { get { return Program.myLoggedUser.HasAccess(eLoginAccess.PowerUser); } }
    private List<MyColumn> myColumns;
    public event RowInformation ShowRowInformation;
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


    public ucIntervents()
    {
      InitializeComponent();
    }

    private void ucIntervents_Load(object sender, EventArgs e)
    {
      if (!DesignMode)
      {
        DB = new CRepositoryDB(Program.myLoggedUser.LoginUserId);
      }
      myColumns = new List<MyColumn>()
            {    new MyColumn { Name = "ID", DataPropertyName = "InterventId", Type = 4 },
                 new MyColumn { Name = "Region", DataPropertyName = "RegionName" },
                 new MyColumn { Name = "Hodnost", DataPropertyName = "Rank" },
                 new MyColumn { Name = "Titul", DataPropertyName = "Title" },
                 new MyColumn { Name = "Jméno", DataPropertyName = "Name" },
                 new MyColumn { Name = "Přijmení", DataPropertyName = "SurName" },
                 new MyColumn { Name = "Telefon", DataPropertyName = "Phone" },
                 new MyColumn { Name = "Mobilní tf.", DataPropertyName = "MobilPhone"},
                 new MyColumn { Name = "Soukromý tf.", DataPropertyName = "PrivatePhone" },
                 new MyColumn { Name = "Mail", DataPropertyName = "Email"},
                 new MyColumn { Name = "Vytvořeno", DataPropertyName = "DtCreate" },
                 new MyColumn { Name = "Jméno2", DataPropertyName = "InterventShortName" },
                 new MyColumn { Name = "Jméno3", DataPropertyName = "CmbName"},
                 new MyColumn { Name = "Smazáno", DataPropertyName = "IsDeleted", Type=2 },
           };
      _dataTable = new DataTable();
      _dataSet = new DataSet();
      bindingSource1 = new BindingSource();
      bindingSource1.DataSource = _dataSet;
      dgw.SetDoubleBuffered();
      dgw.DataSource = bindingSource1;
      CreateTable();
      btnAdd.Visible = btnEdit.Visible = btnDelete.Visible = isEditModeAllowed;
    }

    public void ReadDataFirstTime()
    {
      winterventi = DB.GetWIntervents(null, "", "");
      AddDataToTable();
      cldb = new ColumnLayoutDB(DB, dgw, this.Name + _dataTable.TableName);
      cldb.SetColumnLayout();
    }

    private void CreateTable()
    {
      _dataTable = _dataSet.Tables.Add("Intervents");
      foreach (var col in myColumns)
      {
        _dataTable.Columns.Add(col.Name, col.GetMyType());
      }
      bindingSource1.DataMember = _dataTable.TableName;
    }

    private void AddDataToTable()
    {
      _dataTable.Rows.Clear();
      foreach (var p in winterventi)
      {
        DataRow newRow = _dataTable.NewRow();
        foreach (var col in myColumns)
        {
          newRow[col.Name] = p.GetType().GetProperty(col.DataPropertyName).GetValue(p, null) ?? DBNull.Value; ;
        }
        //          
        _dataTable.Rows.Add(newRow);
      }
    }

    public void RefreshMyData()
    {
      winterventi = DB.GetWIntervents(null, "", "");
      bindingSource1.DataSource = winterventi;
      dgw.DataSource = bindingSource1;
    }

    public void MyResize()
    {
      dgw.Top = dgw.Left = 0;
      dgw.Width = this.ClientSize.Width - (5);
      dgw.Height = this.ClientSize.Height - (btnAdd.Height + 20);

      btnAdd.Top = this.ClientSize.Height - 55; btnAdd.Left = 40;
      btnDelete.Top = this.ClientSize.Height - 55; btnDelete.Left = this.ClientSize.Width - (btnAdd.Width + 40);
      btnEdit.Top = this.ClientSize.Height - 55; btnEdit.Left = (this.ClientSize.Width / 2) - (btnAdd.Width / 2);

    }

    public void MyResize(Size ClientSize)
    {
      this.Top = this.Left = 0;
      this.Width = ClientSize.Width;
      this.Height = ClientSize.Height;
      MyResize();
    }


    private void ucIntervents_Resize(object sender, EventArgs e)
    {
      MyResize();
    }

    private void dgw_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
    {
      if (dgw.Rows[e.RowIndex].Cells[1].Value != null && dgw.Rows[e.RowIndex].Cells[1].Value.ToString() == "True")
      {
        dgw.Rows[e.RowIndex].DefaultCellStyle.Font = new Font(this.Font, FontStyle.Strikeout);
      }
    }

    public void SetColumns()
    {
      cldb.SaveColumnLayout();
    }

    public void InitColumns()
    {
      cldb.DeleteColumnOrder();
      cldb.InitializeColumns();
    }

    public void RemoveOrders()
    {
      dgw.CleanSort();
    }

    public void RemoveFilters()
    {
      dgw.CleanFilter();
    }

    private void btnAdd_Click(object sender, EventArgs e)
    {
      frmIntervent frmU = new frmIntervent();
      frmIntervent frm = new frmIntervent();
      frm.oneRow = new Intervent();
      frm.TypeForm = eModifyRow.addRow;
      frm.ShowDialog();
      if (frm.isReturnOK)
      {
        if (DB.UniversalModifyIntervent(frm.TypeForm, frm.oneRow) == -1)
        {
          MessageBox.Show(DB.sErr,"Chyba Databáze",MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }
        winterventi = DB.GetWIntervents(null, "", "");
        AddDataToTable();
      }

    }

    private void btnEdit_Click(object sender, EventArgs e)
    {
      int RowIndex = GetAktRow();
      if (RowIndex < 0)
        return;
      frmIntervent frm = new frmIntervent();
      int id = (int)dgw.Rows[RowIndex].Cells["ID"].Value;
      frm.oneRow = DB.GetIntervent(id);
      frm.TypeForm = eModifyRow.modifyRow;
      frm.ShowDialog();
      if (frm.isReturnOK)
      {
        DB.UniversalModifyIntervent(frm.TypeForm, frm.oneRow);
        winterventi = DB.GetWIntervents(null, "", "");
        AddDataToTable();
      }

    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
      int RowIndex = GetAktRow();
      if (RowIndex < 0)
        return;
      frmIntervent frm = new frmIntervent();
      int id = (int)dgw.Rows[RowIndex].Cells["ID"].Value;
      frm.oneRow = DB.GetIntervent(id);
      frm.TypeForm = (((bool?)dgw.Rows[RowIndex].Cells["Smazáno"].Value) ?? false) == true ? eModifyRow.undeleteRow : eModifyRow.deleteRow;
      frm.ShowDialog();
      if (frm.isReturnOK)
      {
        DB.UniversalModifyIntervent(frm.TypeForm, frm.oneRow);
        winterventi = DB.GetWIntervents(null,"","");
        AddDataToTable();
      }



    }

    private int GetAktRow()
    {
      if (dgw.SelectedCells.Count == 0)
      {
        MessageBox.Show("Není vybrána žádná věta k editaci", "Intervent", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        return -1;
      }
      return dgw.SelectedCells[0].RowIndex;
    }

    private void dgw_RowEnter(object sender, DataGridViewCellEventArgs e)
    {
      ShowRowInformation?.Invoke(e.RowIndex + 1, _dataTable.Rows.Count);

    }

    private void ucIntervents_VisibleChanged(object sender, EventArgs e)
    {
      if (this.Visible == true)
      {
        ShowRowInformation?.Invoke(1, _dataTable.Rows.Count);
      }
    }
  }
}
