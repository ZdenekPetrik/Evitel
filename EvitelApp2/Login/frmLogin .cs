﻿using EvitelLib2.Business;
using EvitelLib2.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EvitelApp2.Login
{
  public partial class frmLogin : System.Windows.Forms.Form
  {
    public CLoggedUser myLoggedUser;
    public int Mode = 1;


    public frmLogin()
    {
      InitializeComponent();
      myLoggedUser = null;
    }

    private void btnLogin_Click(object sender, EventArgs e)
    {
      CLoginManipulation l = new CLoginManipulation();
      myLoggedUser = l.CheckLogin(this.userName.Text, this.userPassword.Text);
      if (myLoggedUser != null)
      {
        if (myLoggedUser.LoginUserId > 0)
        {
          this.DialogResult = DialogResult.OK;
          this.Close();
        }
        else
        {
          MessageBox.Show("Nelze přihlásit žádného systémového uživatele", "No-Login", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
          this.userName.Text = "";
          this.userPassword.Text = "";
        }
      }
      else
      {
        MessageBox.Show("Uživatel '" + this.userName.Text + "' neexistuje, nebo nemá práva pro přihlášení do systému Evitel", "No-Login", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
//        this.userName.Text = "";
        this.userPassword.Text = "";
      }

    }

    private void frmLogin_Load(object sender, EventArgs e)
    {
      if (Mode == 2)
      {
        this.userPassword.Visible = false;
        this.lblUserPassword.Visible = false;
        this.btnLogin.Top = this.btnLogin.Top - 30;
        this.Height = this.Height - 30;
      }

    }

    private void userPassword_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (e.KeyChar == 13)
      {
        btnLogin_Click(null, null);
      }
      if (e.KeyChar == 27)
      {
        this.DialogResult = DialogResult.Cancel;
        this.Close();
      }
    }


    private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
    {
    }

    private void userName_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (e.KeyChar == 27)
      {
        this.DialogResult = DialogResult.Cancel;
        this.Close();
      }

    }
  }
}
