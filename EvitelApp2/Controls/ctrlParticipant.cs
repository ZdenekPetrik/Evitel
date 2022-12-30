using EvitelLib2.Model;
using EvitelLib2.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace EvitelApp2.Controls
{
  public partial class ctrlParticipant : UserControl
  {
    private CRepositoryDB DB;
    private DataTable _dataTable;
    private DataSet _dataSet;
    List<WParticipant> participants = new List<WParticipant>();
    List<People> peoples = new List<People>();
    BindingSource bindingSource1;
    public List<MyColumn> myColumns;


    public ctrlParticipant()
    {
      InitializeComponent();
    }

    private void ctrlParticipation_Load(object sender, EventArgs e)
    {
      if (DesignMode == false)
      {
        DB = new CRepositoryDB(Program.myLoggedUser.LoginUserId);
        MyResize();
      }

      myColumns = new List<MyColumn>()
      {
         new MyColumn { Name = "LIKOParticipantId", DataPropertyName = "LikoparticipantId", isVisible = false },
         new MyColumn { Name = "LIKOIntervenceId", DataPropertyName = "LikointervenceId", isVisible = false },
         new MyColumn { Name = "Forma účasti", DataPropertyName = "TypePartyText" },
         new MyColumn { Name = "Pohlaví", DataPropertyName = "SexText"},
         new MyColumn { Name = "Věk", DataPropertyName = "Age" },
         new MyColumn { Name = "Smrt", DataPropertyName = "IsDead", Type = 2 },
         new MyColumn { Name = "Zranění", DataPropertyName = "IsInjury", Type = 2 },
         new MyColumn { Name = "Intervence", DataPropertyName = "IsIntervence", Type = 2 },
         new MyColumn { Name = "První Int.", DataPropertyName = "IsFirstIntervence", Type = 2 },
         new MyColumn { Name = "Druh Int.", DataPropertyName = "DruhIntervenceText" },
         new MyColumn { Name = "Intervent", DataPropertyName = "InterventName"},
         new MyColumn { Name = "Poznámka", DataPropertyName = "Note" },
         new MyColumn { Name = "Souhlas", DataPropertyName = "IsAgreement", Type = 2 },
         new MyColumn { Name = "Kontakt", DataPropertyName = "IsContact", Type = 2 },
         new MyColumn { Name = "Policista", DataPropertyName = "IsPolicement", Type = 2 },
         new MyColumn { Name = "Blízká polic.", DataPropertyName = "IsPolicementClosePerson", Type = 2 },
         new MyColumn { Name = "Senior", DataPropertyName = "IsSenior", Type = 2 },
         new MyColumn { Name = "Mladiství", DataPropertyName = "IsChildJuvenile", Type = 2 },
         new MyColumn { Name = "ZPT", DataPropertyName = "IsHandyCappedMedical", Type = 2 },
         new MyColumn { Name = "Duševní por.", DataPropertyName = "IsHandyCappedMentally", Type = 2 },
         new MyColumn { Name = "Minorita", DataPropertyName = "IsMemberMinorityGroup", Type = 2 },
         new MyColumn { Name = "Call", DataPropertyName = "DtStartCall" },
         new MyColumn { Name = "Datum intervence", DataPropertyName = "DtStartIntervence" },
         new MyColumn { Name = "Organizace", DataPropertyName = "Organization" },
         new MyColumn { Name = "Author", DataPropertyName = "UsrLastName" }
       };
      

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
      participants = DB.GetParticipant(true);

      CreateTable();
      AddDataToTable();
      AddSortColumn();

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
      DataRowCollection rowCollection = _dataTable.Rows;
      foreach (var p in participants)
      {
        DataRow newRow = _dataTable.NewRow();
        foreach (var col in myColumns)
        {
          newRow[col.Name] = p.GetType().GetProperty(col.DataPropertyName).GetValue(p, null); ;
        }
        //          
        _dataTable.Rows.Add(newRow);
        //      object[] newrow = new object[] { p.Id, p.Name, p.SurName, p.Age };
      }
    }
    private void AddSortColumn()
    {
      {/*
        dgw.SetSortEnabled(dgw.Columns["Id"], true);
        dgw.SetSortEnabled(dgw.Columns["Příjmení"], true);
        dgw.SetSortEnabled(dgw.Columns["Věk"], true);
        dgw.SortASC(dgw.Columns["Jméno"]);
        */

      }
      foreach (var col in myColumns)
      {
        dgw.Columns[col.Name].Visible = col.isVisible;
      }


    }

  }


  public class People
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string SurName { get; set; }
    public int Age { get; set; }
    public People() { Name = ""; SurName = ""; }

  }
}
