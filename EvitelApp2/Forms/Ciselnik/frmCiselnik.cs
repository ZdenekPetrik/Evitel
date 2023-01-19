using EvitelApp2.Controls;
using EvitelLib2.Model;
using EvitelLib2.Repository;
using Newtonsoft.Json;
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
  public partial class frmCiselnik : Form
  {
    public eAllCodeBooks aktCodeBook;
    public bool isReturnOK;

    public int ID;
    public string Text1 { get { return txtText.Text; } set { txtText.Text = value.ToString(); } }
    public string Text2 { get { return txtText2.Text; } set { txtText2.Text = value.ToString(); } }
    public string Label2 { get { return lbl2.Text; } set { lbl2.Text = value.ToString(); } }
    public string Text3 { get { return txtText3.Text; } set { txtText3.Text = value.ToString(); } }
    public string Label3 { get { return lbl3.Text; } set { lbl3.Text = value.ToString(); } }
    public eModifyRow TypeForm;
    public int ExtensionItem = 0;
    public frmCiselnik()
    {
      InitializeComponent();
      isReturnOK = false;
    }

    private void btnCokoliv_Click(object sender, EventArgs e)
    {
      isReturnOK = true;
      Close();
    }

    private void frmUniversal_Load(object sender, EventArgs e)
    {
      txtID.Text = ID.ToString();
      txtID.ReadOnly = true;
      btnCokoliv.Enabled = false;
      if (TypeForm == eModifyRow.addRow)
      {
        btnCokoliv.Enabled = false;
        btnCokoliv.Text = "Add";
      }
      else if (TypeForm == eModifyRow.modifyRow)
      {
        btnCokoliv.Enabled = false;
        btnCokoliv.Text = "Modify";
      }
      else if (TypeForm == eModifyRow.deleteRow)
      {
        btnCokoliv.Enabled = true;
        btnCokoliv.Text = "Delete";
      }
      else if (TypeForm == eModifyRow.undeleteRow)
      {
        btnCokoliv.Enabled = true;
        btnCokoliv.Text = "UnDelete";
      }
      if (ExtensionItem > 0) {
        lbl2.Visible = true;
        txtText2.Visible = true;
      }
      if (ExtensionItem == 2)
      {
        lbl3.Visible = true;
        txtText3.Visible = true;
        btnCokoliv.Top += 30;
        Height += 30;
      }

    }

    private void txtText_TextChanged(object sender, EventArgs e)
    {
      btnCokoliv.Enabled = true;
    }

    private void txtText2_TextChanged(object sender, EventArgs e)
    {
      btnCokoliv.Enabled = true;
    }

    private void txtText3_TextChanged(object sender, EventArgs e)
    {
      btnCokoliv.Enabled = true;

    }
  }
}
