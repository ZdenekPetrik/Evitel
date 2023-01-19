using EvitelApp2.Controls;
using EvitelApp2.Helper;
using EvitelLib2.Model;
using EvitelLib2.Repository;
using NPOI.SS.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EvitelApp2.Forms1.Ciselnik
{
  public partial class frmIntervent : Form
  {
    public bool isReturnOK;
    public eModifyRow TypeForm;
    public Intervent oneRow;
    CRepositoryDB DB;
    List<EvitelLib2.Model.Region> regionList; 

    public frmIntervent()
    {
      InitializeComponent();
      isReturnOK = false;
      txtHodnost.TextChanged += Any_TextChanged;
      txtTitle.TextChanged += Any_TextChanged;
      txtName.TextChanged += Any_TextChanged;
      txtSurName.TextChanged += Any_TextChanged;  
      txtPhone.TextChanged += Any_TextChanged;  
      txtPrivatePhone.TextChanged += Any_TextChanged;
      txtMobilPhone.TextChanged += Any_TextChanged; 
      txtEmail.TextChanged += Any_TextChanged;  

    }

    private void frmIntervent_Load(object sender, EventArgs e)
    {

      DB = new CRepositoryDB(Program.myLoggedUser.LoginUserId);
      regionList = DB.GetRegions();
      cmbRegion.Items.Clear();
      if (TypeForm == eModifyRow.addRow)
        cmbRegion.Items.Add(new ComboItem("<Nevybráno>", ""));
      foreach (EvitelLib2.Model.Region region in regionList)
      {
        cmbRegion.Items.Add(new ComboItem(region.ShortName + " - " + region.Name, region.RegionId.ToString()));
      }
      cmbRegion.SelectItemByValue(oneRow.RegionId ?? 0);


      lblId.Text = "ID: "+ oneRow.InterventId.ToString();
      txtHodnost.Text = oneRow.Rank;
      txtTitle.Text = oneRow.Title;
      txtName.Text = oneRow.Name;
      txtSurName.Text = oneRow.SurName;
      txtPhone.Text = oneRow.Phone;
      txtMobilPhone.Text = oneRow.MobilPhone;
      txtPrivatePhone.Text = oneRow.PrivatePhone;
      txtEmail.Text = oneRow.Email;

      btnCokoliv.Enabled = false;
      if (TypeForm == eModifyRow.addRow)
      {
        btnCokoliv.Enabled = false;
        btnCokoliv.Text = "Add";
        this.Text = "Intervent - Nový intervent";
      }
      else if (TypeForm == eModifyRow.modifyRow)
      {
        btnCokoliv.Enabled = false;
        btnCokoliv.Text = "Modify";
        this.Text = "Intervent - Modifikace";
      }
      else if (TypeForm == eModifyRow.deleteRow)
      {
        btnCokoliv.Enabled = true;
        btnCokoliv.Text = "Delete";
        this.Text = "Intervent - zneaktivnění interventa";
      }
      else if (TypeForm == eModifyRow.undeleteRow)
      {
        btnCokoliv.Enabled = true;
        btnCokoliv.Text = "Refresh";
        this.Text = "Intervent - Refresh -> opět aktivní";
      }

    }

    private void btnCokoliv_Click(object sender, EventArgs e)
    {
      if ((int)txtHodnost.Tag == 1) oneRow.Rank = txtHodnost.Text;
      if ((int)txtTitle.Tag == 1) oneRow.Title = txtTitle.Text;
      if ((int)txtName.Tag == 1) oneRow.Name = txtName.Text;
      if ((int)txtSurName.Tag == 1) oneRow.SurName = txtSurName.Text;
      if ((int)txtPhone.Tag == 1) oneRow.Phone = txtPhone.Text;
      if ((int)txtPrivatePhone.Tag == 1) oneRow.PrivatePhone = txtPrivatePhone.Text;
      if ((int)txtMobilPhone.Tag == 1) oneRow.MobilPhone = txtMobilPhone.Text;
      if ((int)txtEmail.Tag == 1) oneRow.Email = txtEmail.Text;
      if ((int)cmbRegion.Tag == 1) oneRow.RegionId = ((ComboItem)cmbRegion.SelectedItem).iValue;
      isReturnOK = true;
      Close();

    }

    private void Any_TextChanged(object sender, EventArgs e)
    {
      btnCokoliv.Enabled = true;
      ((TextBox)sender).Tag = 1;
    }

    private void cmbRegion_SelectedIndexChanged(object sender, EventArgs e)
    {
      btnCokoliv.Enabled = true;
      cmbRegion.Tag = 1;
    }
  }
}
