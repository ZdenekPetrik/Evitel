using EvitelApp2.Helper;

using EvitelLib2.Model;
using EvitelLib2.Repository;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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



namespace EvitelApp2.Controls
{
  public partial class ucIntervents : UserControl
  {
    public bool isEditModeAllowed { set { btnEditMode.Visible = value; } }
    public bool isData { get { return winterventi != null; } }       // info zda uz data byla nactena

    private List<WIntervent> winterventi = null;
    List<EvitelLib2.Model.Region> regions = null;
    private CRepositoryDB DB;
    private int Rows { get { return winterventi!.Count(); } }
    DataGridViewComboBoxColumn dgvCmb = new DataGridViewComboBoxColumn();
    private BindingSource bindingSource = new BindingSource();

    private List<MyColumn> myColumns;

    private class interventiShow
    {
      public int InterventId { get; set; }
      public string Hodnost { get; set; }
      public string Titul { get; set; }
      public string Jméno { get; set; }
      public string Přijmení { get; set; }
      public int IsDeleted { get; set; }
    };


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
            {    new MyColumn { Name = "InterventId", DataPropertyName = "InterventId", isVisible = false },
                 new MyColumn { Name = "IsDeleted", DataPropertyName = "IsDeleted", isVisible = false },
                 new MyColumn { Name = "RegionId", DataPropertyName = "RegionId", isVisible = false },
                 new MyColumn { Name = "Region", DataPropertyName = "RegionId" },
                 new MyColumn { Name = "Hodnost", DataPropertyName = "Rank" },
                 new MyColumn { Name = "Titul", DataPropertyName = "Title" },
                 new MyColumn { Name = "Jméno", DataPropertyName = "Name" },
                 new MyColumn { Name = "Přijmení", DataPropertyName = "SurName" },
                 new MyColumn { Name = "Telefon", DataPropertyName = "Phone" },
                 new MyColumn { Name = "Mobilní tf.", DataPropertyName = "MobilPhone"},
                 new MyColumn { Name = "Soukromý tf.", DataPropertyName = "PrivatePhone" },
                 new MyColumn { Name = "Mail", DataPropertyName = "Email"},
                 new MyColumn { Name = "Poznámka", DataPropertyName = "Note" },
                 new MyColumn { Name = "Vytvořeno", DataPropertyName = "dtCreate", isReadOnly = true },
            };
    }

    public void ReadDataFirstTime()
    {
      winterventi = DB.GetWIntervents(null, "", "");
      bindingSource.DataSource = winterventi;
      regions = DB.GetRegions();
      LoadFilter();
      LoadDgw();
      MyResize();
    }


    public void LoadFilter()
    {
      cmbRegion.Items.Add(new ComboItem("< ALL >", "-1"));
      foreach (var Any in regions)
      {
        cmbRegion.Items.Add(new ComboItem(Any.Name, Any.RegionId.ToString()));
        dgvCmb.Items.Add(Any.Name);
      }
      cmbRegion.SelectedIndex = 0;

    }

    public void LoadDgw()
    {
      dgw.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;

      dgw.AutoGenerateColumns = false;
      dgw.AllowUserToOrderColumns = true;
      DataGridViewTextBoxColumn[] Cl = new DataGridViewTextBoxColumn[7];
      for (int i = 0; i < myColumns.Count(); i++)
      {

        if (myColumns[i].Name != "Region")
        {
          var cl = new DataGridViewTextBoxColumn();
          cl.Name = myColumns[i].Name;
          cl.DataPropertyName = myColumns[i].DataPropertyName;
          cl.Visible = myColumns[i].isVisible;
          cl.ReadOnly = myColumns[i].isReadOnly;
          dgw.Columns.Add(cl);
        }
        else
        {
          DataGridViewComboBoxColumn col2 = new DataGridViewComboBoxColumn();
          col2.DataSource = regions;
          col2.DisplayMember = "Name";
          col2.DataPropertyName = "RegionId";
          col2.ValueMember = "regionId";
          dgw.Columns.Add(col2);
        }
      }
      dgw.DataSource = bindingSource;
      //            ChangeEditMode(false);
      MyResize();
    }

    public void RefreshMyData()
    {
      int? Region = ((ComboItem)cmbRegion.SelectedItem).iValue == -1 ? null : ((ComboItem)cmbRegion.SelectedItem).iValue;

      winterventi = DB.GetWIntervents(Region, txtFilterName.Text, txtFilterContact.Text);
      bindingSource.DataSource = winterventi;
      dgw.DataSource = bindingSource;
    }


    public void MyResize()
    {
      dgw.Top = dgw.Left = 0;
      dgw.Width = this.ClientSize.Width - (5);
      dgw.Height = this.ClientSize.Height - (groupBoxVyhledavani.Height + 5);
      groupBoxVyhledavani.Top = this.ClientSize.Height - (groupBoxVyhledavani.Height + 2);
      groupBoxVyhledavani.Left = 0;
      btnEditMode.Left = groupBoxVyhledavani.Width + 5;
      btnEditMode.Top = this.ClientSize.Height - (btnEditMode.Height + 2);
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

    private void btnEditMode_Click(object sender, EventArgs e)
    {
      ChangeEditMode(!dgw.AllowUserToAddRows);

    }
    private void ChangeEditMode(bool isOn)
    {
      dgw.AllowUserToAddRows = isOn;
      dgw.AllowUserToDeleteRows = isOn;
      dgw.EditMode = isOn ? DataGridViewEditMode.EditOnKeystrokeOrF2 : DataGridViewEditMode.EditProgrammatically;
      btnEditMode.Text = isOn ? "View Mode" : "Edit Mode";
      RefreshMyData();
      if (isOn)
      {
        btnEditMode.Visible = true;
      }
    }
    DataGridViewCellEventArgs lastAktCell;
    DataGridViewCellEventArgs lastEditCell;
    private void dgw_CellEnter(object sender, DataGridViewCellEventArgs e)
    {
      if (lastAktCell != null && (lastAktCell.RowIndex != e.RowIndex || e.RowIndex == 0))
        ShowRow(e.RowIndex + 1);
      else
        ShowRow(0);
      if (lastEditCell != null && lastEditCell.RowIndex != e.RowIndex)
      {
        if (lastEditCell.RowIndex < Rows)
        {
          MessageBox.Show("Edit ROW " + lastEditCell.RowIndex.ToString());

        }
        else
          MessageBox.Show("NEW ROW " + lastEditCell.RowIndex.ToString());
        lastEditCell = null;
      }
      lastAktCell = e;
    }

    private void dgw_CellEndEdit(object sender, DataGridViewCellEventArgs e)
    {
      lastEditCell = e;
    }


    private void ShowRow(int index)
    {
      lblPocet.Text = string.Format("{0}/{1}", index, Rows);
    }
    private void btnFind_Click(object sender, EventArgs e)
    {
      RefreshMyData();
    }



    private void dgw_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
    {
      string id = e.Row.Cells[0].Value.ToString();
      var toDelete = winterventi.First(x => x.InterventId.ToString() == id);
      if (DialogResult.Yes == MessageBox.Show("Opravdu " + ((toDelete.IsDeleted == false) ? "smazat " : "obnovit ") + toDelete.Name + " " + toDelete.SurName + " " + toDelete.RegionName + "?", "DeleteRow", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
        DB.InterventDeleteUnDelete(toDelete.InterventId, toDelete.IsDeleted == false);
      e.Cancel = true;
      RefreshMyData();
    }
  }
}
