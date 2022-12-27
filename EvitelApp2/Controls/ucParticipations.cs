using EvitelLib2.Model;
using EvitelLib2.Repository;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EvitelApp2.Controls
{
  public partial class ucParticipations : UserControl
  {

    CRepositoryDB DB;
    public List<MyColumn> myColumns;
    public List<ESex> sex;
    public List<ETypeParty> typeParty;
    public List<WIntervent> winterventi;
    public List<EDruhIntervence> druhIntervence;
    public List<Likoparticipant> participantsList;
    BindingSource source = new BindingSource();
    public int IntervenceId = -1;

    public delegate void HandlerParticipantsRowChanged();
    public event HandlerParticipantsRowChanged RowChanged_Event;





    public ucParticipations()
    {
      InitializeComponent();
      dgw.AutoGenerateColumns = false;
    }

    private void dgw_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {

    }

    private void ucParticipations_Load(object sender, EventArgs e)
    {
      if (!DesignMode)
      {
        DB = new CRepositoryDB(Program.myLoggedUser.LoginUserId);
      }
      myColumns = new List<MyColumn>()
      {
         new MyColumn { Name = "LIKOParticipantId", DataPropertyName = "LIKOParticipantId", isVisible = false },
         new MyColumn { Name = "LIKOIncidentId", DataPropertyName = "LIKOIncidentId", isVisible = false },
         new MyColumn { Name = "IsDeleted", DataPropertyName = "IsDeleted", isVisible = false },
         new MyColumn { Name = "Forma účasti", DataPropertyName = "TypePartyEid", Type = 3 },
         new MyColumn { Name = "Pohlaví", DataPropertyName = "SexEid" , Type = 3},
         new MyColumn { Name = "Věk", DataPropertyName = "Age" },
         new MyColumn { Name = "Smrt", DataPropertyName = "IsDead",Type = 2 },
         new MyColumn { Name = "Zranění", DataPropertyName = "IsInjury",Type = 2 },
         new MyColumn { Name = "Intervence", DataPropertyName = "IsIntervence" ,Type = 2},
         new MyColumn { Name = "První Int.", DataPropertyName = "IsFirstIntervence" ,Type = 2},
         new MyColumn { Name = "Druh Int.", DataPropertyName = "DruhIntervenceEid" , Type = 3},
         new MyColumn { Name = "Intervent", DataPropertyName = "InterventId", Type = 3},
         new MyColumn { Name = "Poznámka", DataPropertyName = "Note" },
         new MyColumn { Name = "Souhlas", DataPropertyName = "IsAgreement",Type = 2 },
         new MyColumn { Name = "Kontakt", DataPropertyName = "IsContact",Type = 2 },
         new MyColumn { Name = "Policista", DataPropertyName = "IsPolicement",Type = 2 },
         new MyColumn { Name = "Blízká polic.", DataPropertyName = "IsPolicementClosePerson",Type = 2 },
         new MyColumn { Name = "Senior", DataPropertyName = "IsSenior",Type = 2 },
         new MyColumn { Name = "Mladiství", DataPropertyName = "IsChildJuvenile",Type = 2 },
         new MyColumn { Name = "ZPT", DataPropertyName = "IsHandyCappedMedical" ,Type = 2},
         new MyColumn { Name = "Duševní por.", DataPropertyName = "IsHandyCappedMentally" ,Type = 2},
         new MyColumn { Name = "Minorita", DataPropertyName = "IsMemberMinorityGroup" ,Type = 2},
         new MyColumn { Name = "Organizace", DataPropertyName = "Organization" }
       };
    }

    public void ReadDataFirstTime()
    {
      sex = DB.GetSex();
      typeParty = DB.GetTypeParty();
      winterventi = DB.GetWIntervents(null, "", "");
      druhIntervence = DB.GetDruhIntervence();
      participantsList = new List<Likoparticipant>();
      LoadDgw();
      source.DataSource = participantsList;
      dgw.DataSource = source;
      dgw.SetColumnOrderExt(this.Name, DB);
      MyResize();
    }

    public void LoadDgw()
    {
      for (int i = 0; i < myColumns.Count(); i++)
      {
        if (myColumns[i].Type == 3)
        {
          DataGridViewComboBoxColumn col2 = new DataGridViewComboBoxColumn();
          col2.Name = myColumns[i].Name;
          col2.DataPropertyName = myColumns[i].DataPropertyName;

          if (myColumns[i].DataPropertyName == "TypePartyEid")
          {
            col2.DataSource = typeParty;
            col2.DisplayMember = "Text";
            col2.ValueMember = "TypePartyId";
            col2.Width = 200;
            col2.DropDownWidth = 250;
          }

          else if (myColumns[i].DataPropertyName == "SexEid")
          {
            col2.DataSource = sex;
            col2.DisplayMember = "Text";
            col2.ValueMember = "SexId";
          }
          else if (myColumns[i].DataPropertyName == "DruhIntervenceEid")
          {
            col2.DataSource = druhIntervence;
            col2.DisplayMember = "Text";
            col2.ValueMember = "DruhIntervenceId";
          }

          else if (myColumns[i].DataPropertyName == "InterventId")
          {
            col2.DataSource = winterventi;
            col2.DisplayMember = "CmbName";
            col2.ValueMember = "InterventId";
          }
          dgw.Columns.Add(col2);
        }
        else if (myColumns[i].Type == 2)
        {
          var cl = new DataGridViewCheckBoxColumn();
          cl.Name = myColumns[i].Name;
          cl.DataPropertyName = myColumns[i].DataPropertyName;
          cl.Visible = myColumns[i].isVisible;
          cl.ReadOnly = myColumns[i].isReadOnly;
          dgw.Columns.Add(cl);
        }
        else
        {
          var cl = new DataGridViewTextBoxColumn();
          cl.Name = myColumns[i].Name;
          cl.DataPropertyName = myColumns[i].DataPropertyName;
          cl.Visible = myColumns[i].isVisible;
          cl.ReadOnly = myColumns[i].isReadOnly;
          dgw.Columns.Add(cl);
        }
      }
    }

    private void btnAddParticipant_Click(object sender, EventArgs e)
    {
      frmParticipant f = new frmParticipant();
      f.master = this;
      f.aktRow = new Likoparticipant();
      f.TypOkna = 'C';
      f.ShowDialog();
      if (f.isOK)
      {
        participantsList.Add(f.aktRow);
        source.ResetBindings(false);
        if (RowChanged_Event != null)
          RowChanged_Event();
      }
    }

    private void btnDeleteParticipant_Click(object sender, EventArgs e)
    {
      if (dgw.SelectedRows.Count != 1)
      {
        MessageBox.Show("Musí být vybrát jeden Účastník. (Click on left gray column Row)");
        return;
      }
      int index = dgw.SelectedRows[0].Index;
      frmParticipant f = new frmParticipant();
      f.master = this;
      f.aktRow = participantsList.ElementAt(index);
      f.TypOkna = 'D';
      f.ShowDialog();
      if (f.isOK)
      {
        participantsList.RemoveAt(index);
        source.ResetBindings(false);
        if (RowChanged_Event != null)
          RowChanged_Event();
      }

    }

    private void btnEditParticipant_Click(object sender, EventArgs e)
    {
      if (dgw.SelectedRows.Count != 1)
      {
        MessageBox.Show("Musí být vybrát jeden Účastník. (Click on left gray column Row)");
        return;
      }

      int index = dgw.SelectedRows[0].Index;
      frmParticipant f = new frmParticipant();
      f.master = this;
      f.aktRow = participantsList.ElementAt(index);
      f.TypOkna = 'U';
      f.ShowDialog();
      if (f.isOK)
      {
        participantsList[index] = f.aktRow;
        source.ResetBindings(false);
        if (RowChanged_Event != null)
          RowChanged_Event();
      }
    }

    private void btnUpParticipant_Click(object sender, EventArgs e)
    {
      if (dgw.SelectedRows.Count != 1)
      {
        MessageBox.Show("Musí být vybrát jeden Účastník. (Click on left gray column Row)");
        return;
      }
      int index = dgw.SelectedRows[0].Index;
      if (index > 0)
      {
        var tmprow = participantsList.ElementAt(index);
        participantsList[index] = participantsList.ElementAt(index - 1);
        participantsList[index - 1] = tmprow;
        source.ResetBindings(false);
        if (RowChanged_Event != null)
          RowChanged_Event();
      }


    }

    private void btnDownParticipant_Click(object sender, EventArgs e)
    {
      if (dgw.SelectedRows.Count != 1)
      {
        MessageBox.Show("Musí být vybrát jeden Účastník. (Click on left gray column Row)");
        return;
      }
      int index = dgw.SelectedRows[0].Index;
      if (index < dgw.Rows.Count - 1)
      {
        var tmprow = participantsList.ElementAt(index);
        participantsList[index] = participantsList.ElementAt(index + 1);
        participantsList[index + 1] = tmprow;
        source.ResetBindings(false);
        if (RowChanged_Event != null)
          RowChanged_Event();
      }



    }

    private void ucParticipations_Resize(object sender, EventArgs e)
    {
      MyResize();
    }
    public void MyResize()
    {
      gb_Participation.Top = 0;
      gb_Participation.Width = this.ClientSize.Width - 2;
      dgw.Width = gb_Participation.ClientSize.Width - (btnAddParticipant.Width + 10);
    }

    private void gb_Participation_Enter(object sender, EventArgs e)
    {

    }

    public void EmptyAllRow()
    {
      participantsList.Clear();
      source.ResetBindings(false);
      if (RowChanged_Event != null)
        RowChanged_Event();
    }

  }
}

