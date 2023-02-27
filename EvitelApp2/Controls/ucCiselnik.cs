using EvitelApp2.Forms1.Ciselnik;
using EvitelApp2.Helper;
using EvitelLib2.Model;
using EvitelLib2.Repository;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.VisualBasic.ApplicationServices;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
    eDruhIntervence,
    eNick,
    eEndOfSpeech,
    eSubEndOfSpeech,
    eClientCurrentStatus,
    eSubClientCurrentStatus,
    eContactTopic,
    eSubContactTopic,
    eContactType,
    eAge,
    eClientFrom,
    eTypeService

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
    List<ENick> nickDataList;
    List<EEndOfSpeech> endOfSpeechDataList;
    List<ESubEndOfSpeech> subEndOfSpeechDataList;
    List<EClientCurrentStatus> clientCurrentStatusDataList;
    List<ESubClientCurrentStatus> subClientCurrentStatusDataList;
    List<EContactTopic> topicDataList;
    List<ESubContactTopic> subTopicDataList;
    List<EContactType> contactTypeDataList;
    List<EAge> ageDataList;
    List<EClientFrom> clientFromDataList;
    List<ETypeService> typeServiceDataList;






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
      if (Program.myLoggedUser.HasAccess(EvitelLib2.Common.eLoginAccess.PowerUser)==false){
        btnAdd.Enabled= false;
        btnEdit.Enabled= false;
        btnDelete.Enabled= false;
      }
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
             new MyColumn { Name = "Text", DataPropertyName = "Name"},
             new MyColumn { Name = "Zkratka", DataPropertyName = "ShortName"},
             new MyColumn { Name = "Jméno2", DataPropertyName = "Name2"},
          };
          edt.Title = "Kraje";
          regionDataList = DB.GetRegions();
          CreateTable();
          AddDataToTableRegion();
          break;
        case eAllCodeBooks.eNick:
          edt.myColumns = new List<MyColumn>()
          {
             new MyColumn { Name = "ID", DataPropertyName = "NickId", Type=11  },
             new MyColumn { Name = "Text", DataPropertyName = "Text"},
             new MyColumn { Name = "Smazáno", DataPropertyName = "DtDeleted", Type=12, isVisible = false},
          };
          edt.Title = "Přezdívky";
          nickDataList = DB.GetNick();
          CreateTable();
          AddDataToTableNick();
          break;
        case eAllCodeBooks.eEndOfSpeech:
          edt.myColumns = new List<MyColumn>()
          {
             new MyColumn { Name = "ID", DataPropertyName = "EndOfSpeechId", Type=11  },
             new MyColumn { Name = "Text", DataPropertyName = "Text"},
             new MyColumn { Name = "Smazáno", DataPropertyName = "DtDeleted", Type=12},
          };
          edt.Title = "Závěr hovoru";
          endOfSpeechDataList = DB.GetEndOfSpeech();
          CreateTable();
          AddDataToTableEndOfSpeech();
          break;
        case eAllCodeBooks.eSubEndOfSpeech:
          edt.myColumns = new List<MyColumn>()
          {
             new MyColumn { Name = "ID", DataPropertyName = "SubEndOfSpeechId", Type=11  },
             new MyColumn { Name = "Text", DataPropertyName = "Text"},
             new MyColumn { Name = "Kategorie", DataPropertyName = "Kategorie"},
             new MyColumn { Name = "Smazáno", DataPropertyName = "DtDeleted", Type=12},
          };
          edt.Title = "Závěr hovoru detail";
          endOfSpeechDataList = DB.GetEndOfSpeech();
          subEndOfSpeechDataList = DB.GetSubEndOfSpeech();
          CreateTable();
          AddDataToTableSubEndOfSpeech();
          break;
        case eAllCodeBooks.eClientCurrentStatus:
          edt.myColumns = new List<MyColumn>()
          {
             new MyColumn { Name = "ID", DataPropertyName = "ClientCurrentStatusId", Type=11  },
             new MyColumn { Name = "Text", DataPropertyName = "Text"},
             new MyColumn { Name = "Smazáno", DataPropertyName = "DtDeleted", Type=12},
          };
          edt.Title = "Aktuální status klienta";
          clientCurrentStatusDataList = DB.GetClientCurrentStatus();
          CreateTable();
          AddDataToTableClientCurrentStatus();
          break;
        case eAllCodeBooks.eSubClientCurrentStatus:
          edt.myColumns = new List<MyColumn>()
          {
             new MyColumn { Name = "ID", DataPropertyName = "SubClientCurrentStatusId", Type=11  },
             new MyColumn { Name = "Text", DataPropertyName = "Text"},
             new MyColumn { Name = "Kategorie", DataPropertyName = "Kategorie"},
             new MyColumn { Name = "Smazáno", DataPropertyName = "DtDeleted", Type=12},
          };
          edt.Title = "Aktuální status klienta-detail";
          clientCurrentStatusDataList = DB.GetClientCurrentStatus();
          subClientCurrentStatusDataList = DB.GetSubClientCurrentStatus();
          CreateTable();
          AddDataToTableSubClientCurrentStatus();
          break;
        case eAllCodeBooks.eContactTopic:
          edt.myColumns = new List<MyColumn>()
          {
             new MyColumn { Name = "ID", DataPropertyName = "ContactTopicId", Type=11  },
             new MyColumn { Name = "Text", DataPropertyName = "Text"},
             new MyColumn { Name = "Smazáno", DataPropertyName = "DtDeleted", Type=12},
          };
          edt.Title = "Téma kontaktu";
          topicDataList = DB.GetContactTopic();
          CreateTable();
          AddDataToTableTopic();
          break;
        case eAllCodeBooks.eSubContactTopic:
          edt.myColumns = new List<MyColumn>()
          {
             new MyColumn { Name = "ID", DataPropertyName = "SubContactTopicId", Type=11  },
             new MyColumn { Name = "Text", DataPropertyName = "Text"},
             new MyColumn { Name = "Kategorie", DataPropertyName = "Kategorie"},
             new MyColumn { Name = "Smazáno", DataPropertyName = "DtDeleted", Type=12},
          };
          edt.Title = "Téma kontaktu-detail";
          topicDataList = DB.GetContactTopic();
          subTopicDataList = DB.GetSubContactTopic();
          CreateTable();
          AddDataToTableSubTopic();
          break;

        case eAllCodeBooks.eContactType:
          edt.myColumns = new List<MyColumn>()
          {
             new MyColumn { Name = "ID", DataPropertyName = "ContactTypeId", Type=11  },
             new MyColumn { Name = "Text", DataPropertyName = "Text"},
             new MyColumn { Name = "Smazáno", DataPropertyName = "DtDeleted", Type=12},
          };
          edt.Title = "Typ kontaktu ";
          contactTypeDataList = DB.GetContactType();
          CreateTable();
          AddDataToTableContactType();
          break;

        case eAllCodeBooks.eAge:
          edt.myColumns = new List<MyColumn>()
          {
             new MyColumn { Name = "ID", DataPropertyName = "AgeId", Type=11  },
             new MyColumn { Name = "Text", DataPropertyName = "Text"},
             new MyColumn { Name = "Smazáno", DataPropertyName = "DtDeleted", Type=12},
          };
          edt.Title = "Věk ";
          ageDataList = DB.GetContactAge();
          CreateTable();
          AddDataToTableAge();
          break;
        case eAllCodeBooks.eClientFrom:
          edt.myColumns = new List<MyColumn>()
          {
             new MyColumn { Name = "ID", DataPropertyName = "ClientFromId", Type=11  },
             new MyColumn { Name = "Text", DataPropertyName = "Text"},
             new MyColumn { Name = "Smazáno", DataPropertyName = "DtDeleted", Type=12},
          };
          edt.Title = "Odkud je klient";
          clientFromDataList = DB.GetClientFrom();
          CreateTable();
          AddDataToTableClientFrom();
          break;
        case eAllCodeBooks.eTypeService:
          edt.myColumns = new List<MyColumn>()
          {
             new MyColumn { Name = "ID", DataPropertyName = "TypeServiceId", Type=11  },
             new MyColumn { Name = "Text", DataPropertyName = "Text"},
             new MyColumn { Name = "Smazáno", DataPropertyName = "DtDeleted", Type=12},
          };
          edt.Title = "Typ služby";
          typeServiceDataList = DB.GetTypeService();
          CreateTable();
          AddDataToTableTypeService();
          break;


        default:
          throw new NotImplementedException();
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

    private void AddDataToTableNick()
    {
      _dataTable.Rows.Clear();
      foreach (var p in nickDataList)
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
    private void AddDataToTableEndOfSpeech()
    {
      _dataTable.Rows.Clear();
      foreach (var p in endOfSpeechDataList)
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
    private void AddDataToTableSubEndOfSpeech()
    {
      _dataTable.Rows.Clear();
      foreach (var p in subEndOfSpeechDataList)
      {
        DataRow newRow = _dataTable.NewRow();
        foreach (var col in edt.myColumns)
        {
          if (col.Name == "Kategorie")
            newRow[col.Name] = endOfSpeechDataList.Where(x => x.EndOfSpeechId == p.EndOfSpeechId).Select(x => x.Text).First();
          else
            newRow[col.Name] = p.GetType().GetProperty(col.DataPropertyName).GetValue(p, null) ?? DBNull.Value;
        }
        //          
        _dataTable.Rows.Add(newRow);
      }
    }
    private void AddDataToTableClientCurrentStatus()
    {
      _dataTable.Rows.Clear();
      foreach (var p in clientCurrentStatusDataList)
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
    private void AddDataToTableSubClientCurrentStatus()
    {
      _dataTable.Rows.Clear();
      foreach (var p in subClientCurrentStatusDataList)
      {
        DataRow newRow = _dataTable.NewRow();
        foreach (var col in edt.myColumns)
        {
          if (col.Name == "Kategorie")
            newRow[col.Name] = clientCurrentStatusDataList.Where(x => x.ClientCurrentStatusId == p.ClientCurrentStatusId).Select(x => x.Text).First();
          else
            newRow[col.Name] = p.GetType().GetProperty(col.DataPropertyName).GetValue(p, null) ?? DBNull.Value;
        }
        //          
        _dataTable.Rows.Add(newRow);
      }
    }

    private void AddDataToTableTopic()
    {
      _dataTable.Rows.Clear();
      foreach (var p in topicDataList)
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
    private void AddDataToTableSubTopic()
    {
      _dataTable.Rows.Clear();
      foreach (var p in subTopicDataList)
      {
        DataRow newRow = _dataTable.NewRow();
        foreach (var col in edt.myColumns)
        {
          if (col.Name == "Kategorie")
            newRow[col.Name] = topicDataList.Where(x => x.ContactTopicId == p.ContactTopicId).Select(x => x.Text).First();
          else
            newRow[col.Name] = p.GetType().GetProperty(col.DataPropertyName).GetValue(p, null) ?? DBNull.Value;
        }
        //          
        _dataTable.Rows.Add(newRow);
      }
    }
    private void AddDataToTableAge()
    {
      _dataTable.Rows.Clear();
      foreach (var p in ageDataList)
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
    private void AddDataToTableContactType()
    {
      _dataTable.Rows.Clear();
      foreach (var p in contactTypeDataList)
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
    private void AddDataToTableClientFrom()
    {
      _dataTable.Rows.Clear();
      foreach (var p in clientFromDataList)
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
    
  private void AddDataToTableTypeService()
    {
      _dataTable.Rows.Clear();
      foreach (var p in typeServiceDataList)
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


    private void btnAdd_Click(object sender, EventArgs e)
    {
      frmCiselnik frmU = new frmCiselnik();
      frmU.aktCodeBook = aktCodeBook;
      frmU.ID = 0;
      frmU.Text1 = "";
      frmU.Text = "Číselník " + edt.Title;
      frmU.TypeForm = eModifyRow.addRow;

      switch (aktCodeBook)
      {
        case eAllCodeBooks.eSex:
        case eAllCodeBooks.eTypeParty:
        case eAllCodeBooks.eDruhIntervence:
        case eAllCodeBooks.eNick:
        case eAllCodeBooks.eEndOfSpeech:
        case eAllCodeBooks.eClientCurrentStatus:
        case eAllCodeBooks.eContactTopic:
        case eAllCodeBooks.eAge:
        case eAllCodeBooks.eContactType:
        case eAllCodeBooks.eClientFrom:
        case eAllCodeBooks.eTypeService:
          frmU.ShowDialog();
          if (frmU.isReturnOK)
          {
            RefreshData(eModifyRow.addRow, frmU.ID, frmU.Text1);
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
        case eAllCodeBooks.eSubEndOfSpeech:
          foreach (var r in endOfSpeechDataList)
          {
            frmU.cmb.Items.Add(new ComboItem(r.Text, r.EndOfSpeechId.ToString()));
          }
          if (endOfSpeechDataList.Count() > 0)
            frmU.cmb.SelectedIndex = 0;
          frmU.isCombo = true;
          frmU.Label2 = "Kategorie";
          frmU.ShowDialog();
          if (frmU.isReturnOK)
          {
            RefreshData(frmU.TypeForm, frmU.ID, frmU.Text1, "", ((ComboItem)frmU.cmb.SelectedItem).iValue);
          }
          break;
        case eAllCodeBooks.eSubClientCurrentStatus:
          foreach (var r in clientCurrentStatusDataList)
          {
            frmU.cmb.Items.Add(new ComboItem(r.Text, r.ClientCurrentStatusId.ToString()));
          }
          if (clientCurrentStatusDataList.Count() > 0)
            frmU.cmb.SelectedIndex = 0;
          frmU.isCombo = true;
          frmU.Label2 = "Kategorie";
          frmU.ShowDialog();
          if (frmU.isReturnOK)
          {
            RefreshData(frmU.TypeForm, frmU.ID, frmU.Text1, "", ((ComboItem)frmU.cmb.SelectedItem).iValue);
          }
          break;
        case eAllCodeBooks.eSubContactTopic:
          foreach (var r in topicDataList)
          {
            frmU.cmb.Items.Add(new ComboItem(r.Text, r.ContactTopicId.ToString()));
          }
          if (topicDataList.Count() > 0)
            frmU.cmb.SelectedIndex = 0;
          frmU.isCombo = true;
          frmU.Label2 = "Kategorie";
          frmU.ShowDialog();
          if (frmU.isReturnOK)
          {
            RefreshData(frmU.TypeForm, frmU.ID, frmU.Text1, "",((ComboItem)frmU.cmb.SelectedItem).iValue);
          }
          break;

        default:
          throw new NotImplementedException();
      }
    }


    private void btnEdit_Click(object sender, EventArgs e)
    {
      int RowIndex = GetAktRow();
      if (RowIndex < 0)
        return;
      frmCiselnik frmU = new frmCiselnik();
      frmU.aktCodeBook = aktCodeBook;
      frmU.ID = (int)dgw.Rows[RowIndex].Cells["ID"].Value;
      frmU.Text1 = (string)dgw.Rows[RowIndex].Cells["Text"].Value;
      frmU.Text = "Číselník " + edt.Title + " --- Věta " + (RowIndex + 1).ToString();
      frmU.TypeForm = eModifyRow.modifyRow;

      switch (aktCodeBook)
      {
        case eAllCodeBooks.eSex:
        case eAllCodeBooks.eTypeParty:
        case eAllCodeBooks.eDruhIntervence:
        case eAllCodeBooks.eNick:
        case eAllCodeBooks.eEndOfSpeech:
        case eAllCodeBooks.eClientCurrentStatus:
        case eAllCodeBooks.eContactTopic:
        case eAllCodeBooks.eAge:
        case eAllCodeBooks.eContactType:
        case eAllCodeBooks.eClientFrom:
        case eAllCodeBooks.eTypeService:

          frmU.ShowDialog();
          if (frmU.isReturnOK)
          {
            RefreshData(eModifyRow.modifyRow, frmU.ID, frmU.Text1);
          }
          break;
        case eAllCodeBooks.eSubTypeIncident:
          frmU.Text2 = (string)dgw.Rows[RowIndex].Cells["Kategorie"].Value;
          frmU.Label2 = "Kategorie";
          frmU.ExtensionItem = 1;
          frmU.ShowDialog();
          if (frmU.isReturnOK)
          {
            DB.UniversalModifySubTypeIncident(eModifyRow.modifyRow, frmU.ID, frmU.Text1, frmU.Text2);
            subTypeIncidentDataList = DB.GetSubTypeIncident();
            AddDataToTableSubTypeIncident();
          }
          break;
        case eAllCodeBooks.eRegions:
          frmU.Text2 = (string)dgw.Rows[RowIndex].Cells["Zkratka"].Value;
          frmU.Label2 = "Zkratka";
          frmU.Text3 = (string)dgw.Rows[RowIndex].Cells["Jméno2"].Value;
          frmU.Label3 = "Jméno2";
          frmU.ExtensionItem = 2;
          frmU.ShowDialog();
          if (frmU.isReturnOK)
          {
            DB.UniversalModifyRegion(eModifyRow.modifyRow, frmU.ID, frmU.Text1, frmU.Text2, frmU.Text3);
            regionDataList = DB.GetRegions();
            AddDataToTableRegion();
          }
          break;
        case eAllCodeBooks.eSubEndOfSpeech:
          foreach (var r in endOfSpeechDataList)
          {
            frmU.cmb.Items.Add(new ComboItem(r.Text, r.EndOfSpeechId.ToString()));
            int endOfSpeechId = subEndOfSpeechDataList.Where(x => x.SubEndOfSpeechId == (int)dgw.Rows[RowIndex].Cells["ID"].Value).Select(x => x.EndOfSpeechId).First() ?? 0;
            if (endOfSpeechId == r.EndOfSpeechId)
              frmU.cmb.SelectedIndex = frmU.cmb.Items.Count - 1;
          }
          frmU.isCombo = true;
          frmU.Label2 = "Kategorie";
          frmU.ShowDialog();
          if (frmU.isReturnOK)
            RefreshData(eModifyRow.modifyRow, frmU.ID, frmU.Text1,"", ((ComboItem)frmU.cmb.SelectedItem).iValue);
          break;
        case eAllCodeBooks.eSubClientCurrentStatus:
          foreach (var r in clientCurrentStatusDataList)
          {
            frmU.cmb.Items.Add(new ComboItem(r.Text, r.ClientCurrentStatusId.ToString()));
            int clientCurrentStatusId = subClientCurrentStatusDataList.Where(x => x.SubClientCurrentStatusId == (int)dgw.Rows[RowIndex].Cells["ID"].Value).Select(x => x.ClientCurrentStatusId).First() ?? 0;
            if (clientCurrentStatusId == r.ClientCurrentStatusId)
              frmU.cmb.SelectedIndex = frmU.cmb.Items.Count - 1;
          }
          frmU.isCombo = true;
          frmU.Label2 = "Kategorie";
          frmU.ShowDialog();
          if (frmU.isReturnOK)
            RefreshData(eModifyRow.modifyRow, frmU.ID, frmU.Text1, "", ((ComboItem)frmU.cmb.SelectedItem).iValue);
          break;
        case eAllCodeBooks.eSubContactTopic:
          foreach (var r in topicDataList)
          {
            frmU.cmb.Items.Add(new ComboItem(r.Text, r.ContactTopicId.ToString()));
            int CurrenttopicId = subTopicDataList.Where(x => x.SubContactTopicId == (int)dgw.Rows[RowIndex].Cells["ID"].Value).Select(x => x.ContactTopicId).First() ?? 0;
            if (CurrenttopicId == r.ContactTopicId)
              frmU.cmb.SelectedIndex = frmU.cmb.Items.Count - 1;
          }
          frmU.isCombo = true;
          frmU.Label2 = "Kategorie";
          frmU.ShowDialog();
          if (frmU.isReturnOK)
            RefreshData(eModifyRow.modifyRow, frmU.ID, frmU.Text1, "", ((ComboItem)frmU.cmb.SelectedItem).iValue);
          break;
        default:
          throw new NotImplementedException();
      }
    }



    private void btnDelete_Click(object sender, EventArgs e)
    {
      if (aktCodeBook == eAllCodeBooks.eRegions)
      {
        MessageBox.Show("Kraje nelze mazat", "Evitel", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        return;
      }

      int RowIndex = GetAktRow();
      if (RowIndex < 0)
        return;

      frmCiselnik frmU = new frmCiselnik();
      frmU.aktCodeBook = aktCodeBook;
      frmU.ID = (int)dgw.Rows[RowIndex].Cells["ID"].Value;
      frmU.Text1 = (string)dgw.Rows[RowIndex].Cells["Text"].Value;
      frmU.Text = "Číselník " + edt.Title + " --- Věta " + (RowIndex + 1).ToString();
      frmU.TypeForm = dgw.Rows[RowIndex].Cells["Smazáno"].Value == DBNull.Value ? eModifyRow.deleteRow : eModifyRow.undeleteRow;
      frmU.ShowDialog();
      if (frmU.isReturnOK)
        RefreshData(frmU.TypeForm, frmU.ID, frmU.Text1, "", 0);
    }

    private void RefreshData(eModifyRow typeForm, int id, string text, string text2= "",int idMaster = 0)
    {
      switch (aktCodeBook)
      {
        case eAllCodeBooks.eSex:
          DB.UniversalModifySex(typeForm, id, text);
          sexDataList = DB.GetSex();
          AddDataToTableSex();
          break;
        case eAllCodeBooks.eTypeParty:
          DB.UniversalModifyTypeParty(typeForm, id, text);
          typePartyDataList = DB.GetTypeParty();
          AddDataToTableTypeParty();
          break;
        case eAllCodeBooks.eDruhIntervence:
          DB.UniversalModifyDruhIntervence(typeForm, id, text);
          druhIntervenceDataList = DB.GetDruhIntervence();
          AddDataToTableDruhIntervence();
          break;
        case eAllCodeBooks.eSubTypeIncident:
          DB.UniversalModifySubTypeIncident(typeForm, id, text,text2);
          subTypeIncidentDataList = DB.GetSubTypeIncident();
          AddDataToTableSubTypeIncident();
          break;
        case eAllCodeBooks.eEndOfSpeech:
          DB.UniversalModifyEndOfSpeech(typeForm, id, text);
          endOfSpeechDataList = DB.GetEndOfSpeech();
          AddDataToTableEndOfSpeech();
          break;
        case eAllCodeBooks.eSubEndOfSpeech:
          DB.UniversalModifySubEndOfSpeech(typeForm, id, text, idMaster);
          subEndOfSpeechDataList = DB.GetSubEndOfSpeech();
          AddDataToTableSubEndOfSpeech();
          break;
        case eAllCodeBooks.eClientCurrentStatus:
          DB.UniversalModifyClientCurrentStatus(typeForm, id, text);
          clientCurrentStatusDataList = DB.GetClientCurrentStatus();
          AddDataToTableClientCurrentStatus();
          break;
        case eAllCodeBooks.eSubClientCurrentStatus:
          DB.UniversalModifySubClientCurrentStatus(typeForm, id, text, idMaster);
          subClientCurrentStatusDataList = DB.GetSubClientCurrentStatus();
          AddDataToTableSubClientCurrentStatus();
          break;
        case eAllCodeBooks.eContactTopic:
          DB.UniversalModifyContactTopic(typeForm, id, text);
          topicDataList = DB.GetContactTopic();
          AddDataToTableTopic();
          break;
        case eAllCodeBooks.eSubContactTopic:
          DB.UniversalModifySubContactTopic(typeForm, id, text, idMaster);
          subTopicDataList = DB.GetSubContactTopic();
          AddDataToTableSubTopic();
          break;
        case eAllCodeBooks.eAge:
          DB.UniversalModifyAge(typeForm, id, text);
          ageDataList = DB.GetContactAge();
          AddDataToTableAge();
          break;
        case eAllCodeBooks.eContactType:
          DB.UniversalModifyContactType(typeForm, id, text);
          contactTypeDataList = DB.GetContactType();
          AddDataToTableContactType();
          break;
        case eAllCodeBooks.eTypeService:
          DB.UniversalModifyTypeService(typeForm, id, text);
          typeServiceDataList = DB.GetTypeService();
          AddDataToTableTypeService();
          break;
        case eAllCodeBooks.eClientFrom:
          DB.UniversalModifyClientFrom(typeForm, id, text);
          clientFromDataList = DB.GetClientFrom();
          AddDataToTableClientFrom();
          break;
        case eAllCodeBooks.eNick:
          DB.UniversalModifyNick(typeForm, id, text);
          nickDataList = DB.GetNick();
          AddDataToTableNick();
          break;


        default:
          throw new NotImplementedException();
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



