namespace EvitelApp2.Forms
{
  partial class frmSetting
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSetting));
      label1 = new System.Windows.Forms.Label();
      txtCisloJednaci = new System.Windows.Forms.TextBox();
      button1 = new System.Windows.Forms.Button();
      SuspendLayout();
      // 
      // label1
      // 
      label1.AutoSize = true;
      label1.Location = new System.Drawing.Point(31, 30);
      label1.Name = "label1";
      label1.Size = new System.Drawing.Size(155, 15);
      label1.TabIndex = 0;
      label1.Text = "Číslo Jednací (PDF Protokol)";
      // 
      // txtCisloJednaci
      // 
      txtCisloJednaci.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      txtCisloJednaci.Location = new System.Drawing.Point(227, 27);
      txtCisloJednaci.Name = "txtCisloJednaci";
      txtCisloJednaci.Size = new System.Drawing.Size(287, 27);
      txtCisloJednaci.TabIndex = 1;
      // 
      // button1
      // 
      button1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      button1.Location = new System.Drawing.Point(215, 95);
      button1.Name = "button1";
      button1.Size = new System.Drawing.Size(97, 36);
      button1.TabIndex = 2;
      button1.Text = "Uložit";
      button1.UseVisualStyleBackColor = true;
      button1.Click += button1_Click;
      // 
      // frmSetting
      // 
      AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
      AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      ClientSize = new System.Drawing.Size(1134, 532);
      Controls.Add(button1);
      Controls.Add(txtCisloJednaci);
      Controls.Add(label1);
      Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
      Name = "frmSetting";
      Text = "Nastavení - Proměnné aplikace";
      TopMost = true;
      Load += frmSetting_Load;
      ResumeLayout(false);
      PerformLayout();
    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox txtCisloJednaci;
    private System.Windows.Forms.Button button1;
  }
}