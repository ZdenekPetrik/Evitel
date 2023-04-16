namespace EvitelApp2.Forms1
{
  partial class frmUser
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUser));
      txtFirstName = new System.Windows.Forms.TextBox();
      label21 = new System.Windows.Forms.Label();
      txtLastName = new System.Windows.Forms.TextBox();
      label1 = new System.Windows.Forms.Label();
      txtLoginName = new System.Windows.Forms.TextBox();
      label2 = new System.Windows.Forms.Label();
      txtPassword = new System.Windows.Forms.TextBox();
      label3 = new System.Windows.Forms.Label();
      groupBox1 = new System.Windows.Forms.GroupBox();
      chkChangePassword = new System.Windows.Forms.CheckBox();
      chkBoxAccess = new System.Windows.Forms.CheckedListBox();
      label4 = new System.Windows.Forms.Label();
      btnSave = new System.Windows.Forms.Button();
      lblId = new System.Windows.Forms.Label();
      groupBox1.SuspendLayout();
      SuspendLayout();
      // 
      // txtFirstName
      // 
      txtFirstName.Location = new System.Drawing.Point(99, 42);
      txtFirstName.Name = "txtFirstName";
      txtFirstName.Size = new System.Drawing.Size(142, 23);
      txtFirstName.TabIndex = 28;
      txtFirstName.Validating += txtFirstName_Validating;
      // 
      // label21
      // 
      label21.AutoSize = true;
      label21.Location = new System.Drawing.Point(28, 45);
      label21.Name = "label21";
      label21.Size = new System.Drawing.Size(42, 15);
      label21.TabIndex = 27;
      label21.Text = "Jméno";
      // 
      // txtLastName
      // 
      txtLastName.Location = new System.Drawing.Point(99, 71);
      txtLastName.Name = "txtLastName";
      txtLastName.Size = new System.Drawing.Size(142, 23);
      txtLastName.TabIndex = 30;
      txtLastName.Validating += txtLastName_Validating;
      // 
      // label1
      // 
      label1.AutoSize = true;
      label1.Location = new System.Drawing.Point(28, 74);
      label1.Name = "label1";
      label1.Size = new System.Drawing.Size(51, 15);
      label1.TabIndex = 29;
      label1.Text = "Přijmení";
      // 
      // txtLoginName
      // 
      txtLoginName.Location = new System.Drawing.Point(88, 44);
      txtLoginName.Name = "txtLoginName";
      txtLoginName.Size = new System.Drawing.Size(142, 23);
      txtLoginName.TabIndex = 32;
      txtLoginName.Validating += txtLoginName_Validating;
      // 
      // label2
      // 
      label2.AutoSize = true;
      label2.Location = new System.Drawing.Point(17, 47);
      label2.Name = "label2";
      label2.Size = new System.Drawing.Size(42, 15);
      label2.TabIndex = 31;
      label2.Text = "Jméno";
      // 
      // txtPassword
      // 
      txtPassword.Location = new System.Drawing.Point(407, 42);
      txtPassword.Name = "txtPassword";
      txtPassword.Size = new System.Drawing.Size(142, 23);
      txtPassword.TabIndex = 34;
      txtPassword.Validating += txtPassword_Validating;
      // 
      // label3
      // 
      label3.AutoSize = true;
      label3.Location = new System.Drawing.Point(298, 47);
      label3.Name = "label3";
      label3.Size = new System.Drawing.Size(37, 15);
      label3.TabIndex = 33;
      label3.Text = "Heslo";
      // 
      // groupBox1
      // 
      groupBox1.Controls.Add(txtLoginName);
      groupBox1.Controls.Add(txtPassword);
      groupBox1.Controls.Add(label3);
      groupBox1.Controls.Add(label2);
      groupBox1.Location = new System.Drawing.Point(12, 182);
      groupBox1.Name = "groupBox1";
      groupBox1.Size = new System.Drawing.Size(586, 100);
      groupBox1.TabIndex = 35;
      groupBox1.TabStop = false;
      groupBox1.Text = "Údaje pro přihlášení do systému";
      groupBox1.Enter += groupBox1_Enter;
      // 
      // chkChangePassword
      // 
      chkChangePassword.AutoSize = true;
      chkChangePassword.Location = new System.Drawing.Point(514, 329);
      chkChangePassword.Name = "chkChangePassword";
      chkChangePassword.Size = new System.Drawing.Size(95, 19);
      chkChangePassword.TabIndex = 35;
      chkChangePassword.Text = "Změnit heslo";
      chkChangePassword.UseVisualStyleBackColor = true;
      chkChangePassword.CheckedChanged += chkChangePassword_CheckedChanged;
      // 
      // chkBoxAccess
      // 
      chkBoxAccess.FormattingEnabled = true;
      chkBoxAccess.Location = new System.Drawing.Point(310, 37);
      chkBoxAccess.Name = "chkBoxAccess";
      chkBoxAccess.Size = new System.Drawing.Size(251, 130);
      chkBoxAccess.TabIndex = 36;
      chkBoxAccess.SelectedValueChanged += chkBoxAccess_SelectedValueChanged;
      // 
      // label4
      // 
      label4.AutoSize = true;
      label4.Location = new System.Drawing.Point(310, 19);
      label4.Name = "label4";
      label4.Size = new System.Drawing.Size(50, 15);
      label4.TabIndex = 37;
      label4.Text = "Přístupy";
      // 
      // btnSave
      // 
      btnSave.Location = new System.Drawing.Point(262, 301);
      btnSave.Name = "btnSave";
      btnSave.Size = new System.Drawing.Size(75, 23);
      btnSave.TabIndex = 38;
      btnSave.Text = "___";
      btnSave.UseVisualStyleBackColor = true;
      btnSave.Click += btnSave_Click;
      // 
      // lblId
      // 
      lblId.AutoSize = true;
      lblId.Location = new System.Drawing.Point(12, 305);
      lblId.Name = "lblId";
      lblId.Size = new System.Drawing.Size(17, 15);
      lblId.TabIndex = 39;
      lblId.Text = "id";
      // 
      // frmUser
      // 
      AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
      AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      ClientSize = new System.Drawing.Size(610, 349);
      Controls.Add(chkChangePassword);
      Controls.Add(lblId);
      Controls.Add(btnSave);
      Controls.Add(label4);
      Controls.Add(chkBoxAccess);
      Controls.Add(groupBox1);
      Controls.Add(txtLastName);
      Controls.Add(label1);
      Controls.Add(txtFirstName);
      Controls.Add(label21);
      Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
      Name = "frmUser";
      Text = "Uživatel";
      Load += frmUser_Load;
      groupBox1.ResumeLayout(false);
      groupBox1.PerformLayout();
      ResumeLayout(false);
      PerformLayout();
    }

    #endregion

    private System.Windows.Forms.TextBox txtFirstName;
    private System.Windows.Forms.Label label21;
    private System.Windows.Forms.TextBox txtLastName;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox txtLoginName;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox txtPassword;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.CheckedListBox chkBoxAccess;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Button btnSave;
    private System.Windows.Forms.Label lblId;
    private System.Windows.Forms.CheckBox chkChangePassword;
  }
}