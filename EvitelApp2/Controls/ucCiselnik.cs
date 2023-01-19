using EvitelApp2.Forms1.Ciselnik;
using EvitelApp2.Helper;
using EvitelLib2.Model;
using EvitelLib2.Repository;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static EvitelApp2.Controls.ucCiselnik;
using static EvitelApp2.frmMain;

namespace EvitelApp2.Controls
{

  public enum eAllCodeBooks
  {
    eSex = 1,
    eSubTypeIncident,
    eTypeIncident,
    eTypeParty,
    eRegions,
    eIntervents,
    eDruhIntervence
  }



  public partial class ucCiselnik : UserControl, IctrlWithDGW
  {



    public class EnumData
    {
      public string Title { get; set; }
      public List<MyColumn> myColumns = new List<MyColumn>();
    }


    private CRepositoryDB DB;
    private DataTable _dataTable;
    private System.Data.DataSet _dataSet;
    private ColumnLayoutDB cldb;


    public eAllCodeBooks aktCodeBook;
    public bool isData { get { return bindingSource1 != null; } }       // info zda uz data byla nactena
    public string Titulek { get { return edt?.Title; } }                // info pro hlavni okno - jmeno číselníku pro zobrazení

    EnumData edt;
    List<ESex> sexDataList;
    List<ETypeParty> typePartyDataList;
    List<EDruhIntervence> druhIntervenceDataList;
    List<ESubTypeIncident> subTypeIncidentDataList;
    List<EvitelLib2.Model.Region> regionDataList;

    public event RowInformation ShowRowInformation;

    BindingSource bindingSource1;

    public DataTable dataTable
    {
      get
      {
        return _dataTable;
      }
    }

    public ucCiselnik()
    {
      InitializeComponent();
      dgw.AllowUserToAddRows = false;
      dgw.AllowUserToDeleteRows = false;
    }

    private void ucCiselnik2_Load(object sender, EventArgs e)
    {
      if (DesignMode == false)
      {
        DB = new CRepositoryDB(Program.myLoggedUser.LoginUserId);
        MyResize();
      }
    }

    public void ReadDataFirstTime()
    {
      bindingSource1 = new BindingSource();
      _dataTable = new DataTable();
      _dataSet = new DataSet();
      bindingSource1 = new BindingSource();
      bindingSource1.DataSource = _dataSet;

      edt = new EnumData();
      switch (aktCodeBook)
      {
        case eAllCodeBooks.eSex:
          edt.myColumns = new List<MyColumn>()
          {
             new MyColumn { Name = "ID", DataPropertyName = "SexId", Type=11  },
             new MyColumn { Name = "Text", DataPropertyName = "Text"},
             new MyColumn { Name = "Smazáno", DataPropertyName = "DtDeleted", Type=12},
          };
          edt.Title = "Pohlaví";
          sexDataList = DB.GetSex();
          CreateTable();
          AddDataToTableSex();
          break;
        case eAllCodeBooks.eTypeParty:
          edt.myColumns = new List<MyColumn>()
          {
             new MyColumn { Name = "ID", DataPropertyName = "TypePartyId", Type=11  },
             new MyColumn { Name = "Text", DataPropertyName = "Text"},
             new MyColumn { Name = "Smazáno", DataPropertyName = "DtDeleted", Type=12},
          };
          edt.Title = "Forma účasti";
          typePartyDataList = DB.GetTypeParty();
          CreateTable();
          AddDataToTableTypeParty();
          break;
        case eAllCodeBooks.eDruhIntervence:
          edt.myColumns = new List<MyColumn>()
          {
             new MyColumn { Name = "ID", DataPropertyName = "DruhIntervenceId", Type=11  },
             new MyColumn { Name = "Text", DataPropertyName = "Text"},
             new MyColumn { Name = "Smazáno", DataPropertyName = "DtDeleted", Type=12},
          };
          edt.Title = "Druh intervence";
          druhIntervenceDataList = DB.GetDruhIntervence();
          CreateTable();
          AddDataToTableDruhIntervence();
          break;

        case eAllCodeBooks.eSubTypeIncident:
          edt.myColumns = new List<MyColumn>()
          {
             new MyColumn { Name = "ID", DataPropertyName = "SubTypeIncidentId", Type=11  },
             new MyColumn { Name = "Text", DataPropertyName = "Text"},
             new MyColumn { Name = "Kategorie", DataPropertyName = "Kategorie"},
             new MyColumn { Name = "Smazáno", DataPropertyName = "DtDeleted", Type=12},
          };
          edt.Title = "Typ Incidentu";
          subTypeIncidentDataList = DB.GetSubTypeIncident();
          CreateTable();
          AddDataToTableSubTypeIncident();
          break;

        case eAllCodeBooks.eRegions:
          edt.myColumns = new List<MyColumn>()
          {
             new MyColumn { Name = "ID", DataPropertyName = "RegionId", Type=11  },
             new MyColumn { Name = "Name", DataPropertyName = "Name"},
             new MyColumn { Name = "Zkratka", DataPropertyName = "ShortName"},
             new MyColumn { Name = "Name2", DataPropertyName = "Name2"},
          };
          edt.Title = "Kraje";
          regionDataList = DB.GetRegions();
          CreateTable();
          AddDataToTableRegion();
          break;

        default: break;
      }
      dgw.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
      dgw.BorderStyle = BorderStyle.Fixed3D;
      dgw.EditMode = DataGridViewEditMode.EditProgrammatically;
      dgw.DataSource = bindingSource1;
      cldb = new ColumnLayoutDB(DB, dgw, this.Name + _dataTable.TableName);
      cldb.SetColumnLayout();

    }


    private void CreateTable()
    {
      _dataTable = _dataSet.Tables.Add("Enum-" + edt.Title);
      foreach (var col in edt.myColumns)
      {
        _dataTable.Columns.Add(col.Name, col.GetMyType());
      }
      bindingSource1.DataMember = _dataTable.TableName;
    }

    private void AddDataToTableSex()
    {
      _dataTable.Rows.Clear();
      foreach (var p in sexDataList)
      {
        DataRow newRow = _dataTable.NewRow();
        foreach (var col in edt.myColumns)
        {
          newRow[col.Name] = p.GetType().GetProperty(col.DataPropertyName).GetValue(p, null) ?? DBNull.Value;
        }
        //          
        _dataTable.Rows.Add(newRow);
      }
    }
    private void AddDataToTableTypeParty()
    {
      _dataTable.Rows.Clear();
      foreach (var p in typePartyDataList)
      {
        DataRow newRow = _dataTable.NewRow();
        foreach (var col in edt.myColumns)
        {
          newRow[col.Name] = p.GetType().GetProperty(col.DataPropertyName).GetValue(p, null) ?? DBNull.Value;
        }
        //          
        _dataTable.Rows.Add(newRow);
      }
    }

    private void AddDataToTableDruhIntervence()
    {
      _dataTable.Rows.Clear();
      foreach (var p in druhIntervenceDataList)
      {
        DataRow newRow = _dataTable.NewRow();
        foreach (var col in edt.myColumns)
        {
          newRow[col.Name] = p.GetType().GetProperty(col.DataPropertyName).GetValue(p, null) ?? DBNull.Value;
        }
        //          
        _dataTable.Rows.Add(newRow);
      }
    }

    private void AddDataToTableSubTypeIncident()
    {
      _dataTable.Rows.Clear();
      foreach (var p in subTypeIncidentDataList)
      {
        DataRow newRow = _dataTable.NewRow();
        foreach (var col in edt.myColumns)
        {
          newRow[col.Name] = p.GetType().GetProperty(col.DataPropertyName).GetValue(p, null) ?? DBNull.Value;
        }
        //          
        _dataTable.Rows.Add(newRow);
      }
    }

    private void AddDataToTableRegion()
    {
      _dataTable.Rows.Clear();
      foreach (var p in regionDataList)
      {
        DataRow newRow = _dataTable.NewRow();
        foreach (var col in edt.myColumns)
        {
          newRow[col.Name] = p.GetType().GetProperty(col.DataPropertyName).GetValue(p, null) ?? DBNull.Value;
        }
        //          
        _dataTable.Rows.Add(newRow);
      }
    }


    public void MyResize()
    {
      dgw.Top = dgw.Left = 0;
      dgw.Width = this.ClientSize.Width - (5);
      dgw.Height = this.ClientSize.Height - 70;

      btnAdd.Top = this.ClientSize.Height - 55; btnAdd.Left = 40;
      btnDelete.Top = this.ClientSize.Height - 55; btnDelete.Left = this.ClientSize.Width - (btnAdd.Width + 40);
      btnEdit.Top = this.ClientSize.Height - 55; btnEdit.Left = (this.ClientSize.Width / 2) - (btnAdd.Width + 20);

    }

    private void ucCiselnik_Resize(object sender, EventArgs e)
    {
      MyResize();
    }

    private void btnEdit_Click(object sender, EventArgs e)
    {
      int RowIndex = GetAktRow();
      if (RowIndex < 0)
        return;
      frmCiselnik frmU = new frmCiselnik();
      switch (aktCodeBook)
      {
        case eAllCodeBooks.eSex:
          frmU.aktCodeBook = aktCodeBook;
          frmU.ID = (int)dgw.Rows[RowIndex].Cells["ID"].Value;
          frmU.Text1 = (string)dgw.Rows[RowIndex].Cells["Text"].Value;
          frmU.Text = "Číselník " + edt.Title + " --- Věta " + (RowIndex + 1).ToString();
          frmU.TypeForm = eModifyRow.modifyRow;
          frmU.ShowDialog();
          if (frmU.isReturnOK)
          {
            DB.UniversalModifySex(eModifyRow.modifyRow, frmU.ID, frmU.Text1);
            sexDataList = DB.GetSex();
            AddDataToTableSex();
          }
          break;
        case eAllCodeBooks.eTypeParty:
          frmU.aktCodeBook = aktCodeBook;
          frmU.ID = (int)dgw.Rows[RowIndex].Cells["ID"].Value;
          frmU.Text1 = (string)dgw.Rows[RowIndex].Cells["Text"].Value;
          frmU.Text = "Číselník " + edt.Title + " --- Věta " + (RowIndex + 1).ToString();
          frmU.TypeForm = eModifyRow.modifyRow;
          frmU.ShowDialog();
          if (frmU.isReturnOK)
          {
            DB.UniversalModifyTypeParty(eModifyRow.modifyRow, frmU.ID, frmU.Text1);
            typePartyDataList = DB.GetTypeParty();
            AddDataToTableTypeParty();
          }
          break;
        case eAllCodeBooks.eSubTypeIncident:
          frmU.aktCodeBook = aktCodeBook;
          frmU.ID = (int)dgw.Rows[RowIndex].Cells["ID"].Value;
          frmU.Text1 = (string)dgw.Rows[RowIndex].Cells["Text"].Value;
          frmU.Text2 = (string)dgw.Rows[RowIndex].Cells["Kategorie"].Value;
          frmU.Label2 = "Kategorie";
          frmU.ExtensionItem = 1;
          frmU.Text = "Číselník " + edt.Title + " --- Věta " + (RowIndex + 1).ToString();
          frmU.TypeForm = eModifyRow.modifyRow;
          frmU.ShowDialog();
          if (frmU.isReturnOK)
          {
            DB.UniversalModifySubTypeIncident(eModifyRow.modifyRow, frmU.ID, frmU.Text1, frmU.Text2);
            subTypeIncidentDataList = DB.GetSubTypeIncident();
            AddDataToTableSubTypeIncident();
          }
          break;
        case eAllCodeBooks.eRegions:
          frmU.aktCodeBook = aktCodeBook;
          frmU.ID = (int)dgw.Rows[RowIndex].Cells["ID"].Value;
          frmU.Text1 = (string)dgw.Rows[RowIndex].Cells["Name"].Value;
          frmU.Text2 = (string)dgw.Rows[RowIndex].Cells["Zkratka"].Value;
          frmU.Label2 = "Kategorie";
          frmU.Text3 = (string)dgw.Rows[RowIndex].Cells["Name2"].Value;
          frmU.Label3 = "Jméno";
          frmU.ExtensionItem = 2;
          frmU.Text = "Číselník " + edt.Title + " --- Věta " + (RowIndex + 1).ToString();
          frmU.TypeForm = eModifyRow.modifyRow;
          frmU.ShowDialog();
          if (frmU.isReturnOK)
          {
            DB.UniversalModifyRegion(eModifyRow.modifyRow, frmU.ID, frmU.Text1, frmU.Text2, frmU.Text3);
            regionDataList = DB.GetRegions();
            AddDataToTableRegion();
          }
          break;
      }
    }

    private void btnAdd_Click(object sender, EventArgs e)
    {
      int RowIndex = GetAktRow();
      if (RowIndex < 0)
        return;
      frmCiselnik frmU = new frmCiselnik();
      frmU.aktCodeBook = aktCodeBook;
      frmU.ID = 0;
      frmU.Text1 = "";
      frmU.Text = "Číselník " + edt.Title;
      frmU.TypeForm = eModifyRow.addRow;

      switch (aktCodeBook)
      {
        case eAllCodeBooks.eSex:
          frmU.ShowDialog();
          if (frmU.isReturnOK)
          {
            DB.UniversalModifySex(frmU.TypeForm, frmU.ID, frmU.Text1);
            sexDataList = DB.GetSex();
            AddDataToTableSex();
          }
          break;
        case eAllCodeBooks.eTypeParty:
          frmU.ShowDialog();
          if (frmU.isReturnOK)
          {
            DB.UniversalModifyTypeParty(frmU.TypeForm, frmU.ID, frmU.Text1);
            typePartyDataList = DB.GetTypeParty();
            AddDataToTableTypeParty();
          }
          break;
        case eAllCodeBooks.eDruhIntervence:
          frmU.ShowDialog();
          if (frmU.isReturnOK)
          {
            DB.UniversalModifyDruhIntervence(frmU.TypeForm, frmU.ID, frmU.Text1);
            druhIntervenceDataList = DB.GetDruhIntervence();
            AddDataToTableDruhIntervence();
          }
          break;
        case eAllCodeBooks.eSubTypeIncident:
          frmU.Text2 = "";
          frmU.Label2 = "Kategorie";
          frmU.ExtensionItem = 1;
          frmU.ShowDialog();
          if (frmU.isReturnOK)
          {
            DB.UniversalModifySubTypeIncident(frmU.TypeForm, frmU.ID, frmU.Text1, frmU.Text2);
            subTypeIncidentDataList = DB.GetSubTypeIncident();
            AddDataToTableSubTypeIncident();
          }
          break;
        case eAllCodeBooks.eRegions:
          frmU.Text2 = "";
          frmU.Label2 = "Zkratka";
          frmU.Text3 = "";
          frmU.Label3 = "Name2";
          frmU.ExtensionItem = 2;
          frmU.ShowDialog();
          if (frmU.isReturnOK)
          {
            DB.UniversalModifyRegion(frmU.TypeForm, frmU.ID, frmU.Text1, frmU.Text2, frmU.Text3);
            regionDataList = DB.GetRegions();
            AddDataToTableRegion();
          }
          break;

        default:
          break;
      }
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
      int RowIndex = GetAktRow();
      if (RowIndex < 0)
        return;

      frmCiselnik frmU = new frmCiselnik();

      switch (aktCodeBook)
      {
        case eAllCodeBooks.eSex:
          frmU.aktCodeBook = aktCodeBook;
          frmU.ID = (int)dgw.Rows[RowIndex].Cells["ID"].Value;
          frmU.Text1 = (string)dgw.Rows[RowIndex].Cells["Text"].Value;
          frmU.Text = "Číselník " + edt.Title + " --- Věta " + (RowIndex + 1).ToString();
          frmU.TypeForm = dgw.Rows[RowIndex].Cells["Smazáno"].Value == DBNull.Value ? eModifyRow.deleteRow : eModifyRow.undeleteRow;
          frmU.ShowDialog();
          if (frmU.isReturnOK)
          {
            DB.UniversalModifySex(frmU.TypeForm, frmU.ID, frmU.Text1);
            sexDataList = DB.GetSex();
            AddDataToTableSex();
          }
          break;
        case eAllCodeBooks.eTypeParty:
          frmU.aktCodeBook = aktCodeBook;
          frmU.ID = (int)dgw.Rows[RowIndex].Cells["ID"].Value;
          frmU.Text1 = (string)dgw.Rows[RowIndex].Cells["Text"].Value;
          frmU.Text = "Číselník " + edt.Title + " --- Věta " + (RowIndex + 1).ToString();
          frmU.TypeForm = dgw.Rows[RowIndex].Cells["Smazáno"].Value == DBNull.Value ? eModifyRow.deleteRow : eModifyRow.undeleteRow;
          frmU.ShowDialog();
          if (frmU.isReturnOK)
          {
            DB.UniversalModifyTypeParty(frmU.TypeForm, frmU.ID, frmU.Text1);
            typePartyDataList = DB.GetTypeParty();
            AddDataToTableTypeParty();
          }
          break;
        case eAllCodeBooks.eDruhIntervence:
          frmU.aktCodeBook = aktCodeBook;
          frmU.ID = (int)dgw.Rows[RowIndex].Cells["ID"].Value;
          frmU.Text1 = (string)dgw.Rows[RowIndex].Cells["Text"].Value;
          frmU.Text = "Číselník " + edt.Title + " --- Věta " + (RowIndex + 1).ToString();
          frmU.TypeForm = dgw.Rows[RowIndex].Cells["Smazáno"].Value == DBNull.Value ? eModifyRow.deleteRow : eModifyRow.undeleteRow;
          frmU.ShowDialog();
          if (frmU.isReturnOK)
          {
            DB.UniversalModifyDruhIntervence(eModifyRow.addRow, frmU.ID, frmU.Text1);
            druhIntervenceDataList = DB.GetDruhIntervence();
            AddDataToTableDruhIntervence();
          }
          break;
        case eAllCodeBooks.eSubTypeIncident:
          frmU.aktCodeBook = aktCodeBook;
          frmU.ID = (int)dgw.Rows[RowIndex].Cells["ID"].Value;
          frmU.Text1 = (string)dgw.Rows[RowIndex].Cells["Text"].Value;
          frmU.Text = "Číselník " + edt.Title + " --- Věta " + (RowIndex + 1).ToString();
          frmU.TypeForm = dgw.Rows[RowIndex].Cells["Smazáno"].Value == DBNull.Value ? eModifyRow.deleteRow : eModifyRow.undeleteRow;
          frmU.ShowDialog();
          if (frmU.isReturnOK)
          {
            DB.UniversalModifyDruhIntervence(eModifyRow.addRow, frmU.ID, frmU.Text1);
            druhIntervenceDataList = DB.GetDruhIntervence();
            AddDataToTableDruhIntervence();
          }
          break;
        case eAllCodeBooks.eRegions:
          MessageBox.Show("Region nelze mazat", "Číselník", MessageBoxButtons.OK, MessageBoxIcon.Information);
          break;
        default:
          break;

      }
    }

    private int GetAktRow()
    {
      if (dgw.SelectedCells.Count == 0)
      {
        MessageBox.Show("Není vybrána žádná věta k editaci", "Číselník " + edt.Title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        return -1;
      }
      return dgw.SelectedCells[0].RowIndex;
    }


    private void dgw_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
      if (e.RowIndex >= 0)
        btnEdit_Click(null, null);
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
      throw new NotImplementedException();
    }

    public void RemoveFilters()
    {
      throw new NotImplementedException();
    }

    private void dgw_RowEnter(object sender, DataGridViewCellEventArgs e)
    {
         ShowRowInformation?.Invoke(e.RowIndex + 1, _dataTable.Rows.Count);
     }
  }
}



