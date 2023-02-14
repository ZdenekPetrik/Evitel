using EvitelLib2.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EvitelApp2.Forms
{
  public partial class frmSetting : Form
  {
    CRepositoryDB DB;

    public frmSetting()
    {
      InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
      DB.SetSetting("CisloJednaci", txtCisloJednaci.Text);
      Close();
    }

    private void frmSetting_Load(object sender, EventArgs e)
    {
      DB = new CRepositoryDB(Program.myLoggedUser.LoginUserId);
      txtCisloJednaci.Text = DB.GetSettingS("CisloJednaci");
    }
  }
}
