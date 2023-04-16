using EvitelLib2.Business;
using EvitelLib2.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EvitelApp2.Forms1
{
  public partial class frmUser : Form
  {
    public LoginUser loginUser;
    public List<LoginAccess> loginAccessList;
    public int Type = 1;    // 1 NEW, 2 Edit

    private ErrorProvider errFirstName;
    private ErrorProvider errLastName;
    private ErrorProvider errLoginName;
    private ErrorProvider errPassword;
    public bool isOK = false;
    public bool isLastAdmin = false;

    public frmUser()
    {
      InitializeComponent();
    }

    private void frmUser_Load(object sender, EventArgs e)
    {
      for (int i = 0; i < loginAccessList.Count(); i++)
      {
        chkBoxAccess.Items.Add(loginAccessList[i].AccessName, loginUser.LoginAccessUsers.Where(x => x.LoginAccessId == loginAccessList[i].LoginAccessId).Count() > 0);
      }
      errFirstName = InitializeErrorProvider(1, txtFirstName);
      errLastName = InitializeErrorProvider(1, txtLastName);
      errLoginName = InitializeErrorProvider(1, txtLoginName);
      errPassword = InitializeErrorProvider(1, txtPassword);

      if (Type == 1)
      {
        btnSave.Text = "Nový uživatel";
        chkChangePassword.Visible = false;
        chkChangePassword.Checked = true;
      }
      else
      {
        txtFirstName.Text = loginUser.FirstName;
        txtLastName.Text = loginUser.LastName;
        txtLoginName.Text = loginUser.LoginName;
        txtPassword.Text = "******";
        txtPassword.ReadOnly = true;
        lblId.Text = "Id: " + loginUser.LoginUserId.ToString();
        btnSave.Text = "Uložit změny";
      }
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
      if (ValidateChildren())
      {
        isOK = true;
        SaveValues();
        this.Close();
      }
      else
      {
        MessageBox.Show("Validation failed.");
      }
    }

    private ErrorProvider InitializeErrorProvider(int type, Control myControl)
    {
      var x = new System.Windows.Forms.ErrorProvider();
      x.SetIconAlignment(myControl, ErrorIconAlignment.MiddleRight);
      x.SetIconPadding(myControl, 2);
      x.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
      x.Icon = (type == 1 ? Resource.error_Icon : Resource.warning_Icon);
      return x;
    }

    private void txtFirstName_Validating(object sender, CancelEventArgs e)
    {
      if (txtFirstName.Text.Length < 3)
      {
        errFirstName.SetError(this.txtFirstName, "Položka Jméno musí mít alespoň 3 znaky");
        e.Cancel = true;
      }
      else
      {
        errFirstName.SetError(this.txtFirstName, "");
        e.Cancel = false;
      }
    }

    private void txtLastName_Validating(object sender, CancelEventArgs e)
    {
      if (txtLastName.Text.Length < 3)
      {
        errLastName.SetError(this.txtLastName, "Položka Příjmení musí mít alespoň 3 znaky");
        e.Cancel = true;
      }
      else
      {
        errLastName.SetError(this.txtLastName, "");
        e.Cancel = false;
      }

    }
    private void txtLoginName_Validating(object sender, CancelEventArgs e)
    {
      if (txtLoginName.Text.Length < 3)
      {
        errLoginName.SetError(this.txtLoginName, "Položka 'Přihlašovací jméno' musí mít alespoň 3 znaky");
        e.Cancel = true;
      }
      else
      {
        errLoginName.SetError(this.txtLoginName, "");
        e.Cancel = false;
      }

    }

    private void txtPassword_Validating(object sender, CancelEventArgs e)
    {
      if (Type == 1 || chkChangePassword.Checked)
      {
        CLoginManipulation clm = new CLoginManipulation(Program.myLoggedUser.LoginUserId);
        string errString = "";
        if (clm.CheckPassword(txtPassword.Text, out errString))
        {
          errPassword.SetError(this.txtPassword, "");
          e.Cancel = false;
        }
        else
        {
          errPassword.SetError(this.txtPassword, errString);
          e.Cancel = true;
        }


      }
      else
      {
        errPassword.SetError(this.txtPassword, "");
        e.Cancel = false;

      }

    }

    private void chkChangePassword_CheckedChanged(object sender, EventArgs e)
    {
      if (chkChangePassword.Checked)
      {
        txtPassword.ReadOnly = false;
        txtPassword.Text = string.Empty;
      }
      else
      {
        txtPassword.ReadOnly = true; ;
        txtPassword.Text = "******";
      }
    }

    private void SaveValues()
    {
      List<LoginAccess> newLoginAccessesList = new List<LoginAccess>();

      for (int i = 0; i < chkBoxAccess.Items.Count; i++)
      {
        var value = chkBoxAccess.GetItemChecked(i);
        var loginAccess = loginAccessList.Where(x => x.AccessName == chkBoxAccess.Items[i].ToString()).FirstOrDefault();
        var loginAccessUser = loginUser.LoginAccessUsers.Where(x => x.LoginAccessId == loginAccess.LoginAccessId).FirstOrDefault();
        if (value && loginAccessUser == null)
          loginUser.LoginAccessUsers.Add(new LoginAccessUser() { LoginUserId = loginUser.LoginUserId, LoginAccessId = loginAccess.LoginAccessId });
        if (!value && loginAccessUser != null)
          loginUser.LoginAccessUsers.Remove(loginAccessUser);
      }
      loginUser.LoginName = txtLoginName.Text;
      loginUser.FirstName = txtFirstName.Text;
      loginUser.LastName = txtLastName.Text;
      if ((Type == 1) || chkChangePassword.Checked)
      {
        loginUser.LoginPassword = txtPassword.Text;
      }
    }

    private void groupBox1_Enter(object sender, EventArgs e)
    {

    }


    private void chkBoxAccess_SelectedValueChanged(object sender, EventArgs e)
    {
      if (isLastAdmin)
      {
        var value = chkBoxAccess.GetItemChecked(0);   // admin je vždy zobrazen jako první
        if (!value)
        {
          MessageBox.Show("Nelze odtranit Administrátora. Alespoň jeden Administrátor musí zůstat.", "Odstranění Administrátora", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }
        chkBoxAccess.SetItemChecked(0, true);
      }

    }
  }
}
