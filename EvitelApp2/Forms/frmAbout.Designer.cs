namespace EvitelApp2.Forms
{
  partial class frmAbout
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAbout));
      pictureBox2 = new System.Windows.Forms.PictureBox();
      lblTitulek = new System.Windows.Forms.Label();
      label1 = new System.Windows.Forms.Label();
      pictureBox1 = new System.Windows.Forms.PictureBox();
      label2 = new System.Windows.Forms.Label();
      label3 = new System.Windows.Forms.Label();
      label4 = new System.Windows.Forms.Label();
      lblVersion = new System.Windows.Forms.Label();
      lblDate = new System.Windows.Forms.Label();
      ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
      ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
      SuspendLayout();
      // 
      // pictureBox2
      // 
      pictureBox2.BackgroundImage = (System.Drawing.Image)resources.GetObject("pictureBox2.BackgroundImage");
      pictureBox2.InitialImage = (System.Drawing.Image)resources.GetObject("pictureBox2.InitialImage");
      pictureBox2.Location = new System.Drawing.Point(12, 3);
      pictureBox2.Name = "pictureBox2";
      pictureBox2.Size = new System.Drawing.Size(90, 90);
      pictureBox2.TabIndex = 1;
      pictureBox2.TabStop = false;
      // 
      // lblTitulek
      // 
      lblTitulek.AutoSize = true;
      lblTitulek.Font = new System.Drawing.Font("Segoe UI Semibold", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      lblTitulek.ForeColor = System.Drawing.SystemColors.Highlight;
      lblTitulek.Location = new System.Drawing.Point(213, 26);
      lblTitulek.Name = "lblTitulek";
      lblTitulek.Size = new System.Drawing.Size(103, 46);
      lblTitulek.TabIndex = 27;
      lblTitulek.Text = "Evitel";
      // 
      // label1
      // 
      label1.AutoSize = true;
      label1.Location = new System.Drawing.Point(184, 87);
      label1.Name = "label1";
      label1.Size = new System.Drawing.Size(158, 15);
      label1.TabIndex = 28;
      label1.Text = "Evidence telefonních hovorů";
      // 
      // pictureBox1
      // 
      pictureBox1.BackgroundImage = (System.Drawing.Image)resources.GetObject("pictureBox1.BackgroundImage");
      pictureBox1.InitialImage = (System.Drawing.Image)resources.GetObject("pictureBox1.InitialImage");
      pictureBox1.Location = new System.Drawing.Point(443, 12);
      pictureBox1.Name = "pictureBox1";
      pictureBox1.Size = new System.Drawing.Size(90, 101);
      pictureBox1.TabIndex = 29;
      pictureBox1.TabStop = false;
      // 
      // label2
      // 
      label2.AutoSize = true;
      label2.Location = new System.Drawing.Point(171, 114);
      label2.Name = "label2";
      label2.Size = new System.Drawing.Size(187, 15);
      label2.TabIndex = 30;
      label2.Text = "pro linku pomoci v krizi Policie ČR";
      // 
      // label3
      // 
      label3.AutoSize = true;
      label3.Location = new System.Drawing.Point(481, 148);
      label3.Name = "label3";
      label3.Size = new System.Drawing.Size(52, 15);
      label3.TabIndex = 31;
      label3.Text = "Karia sro";
      // 
      // label4
      // 
      label4.AutoSize = true;
      label4.Location = new System.Drawing.Point(448, 166);
      label4.Name = "label4";
      label4.Size = new System.Drawing.Size(85, 15);
      label4.TabIndex = 32;
      label4.Text = "evitel@karia.cz";
      // 
      // lblVersion
      // 
      lblVersion.AutoSize = true;
      lblVersion.Location = new System.Drawing.Point(12, 148);
      lblVersion.Name = "lblVersion";
      lblVersion.Size = new System.Drawing.Size(52, 15);
      lblVersion.TabIndex = 33;
      lblVersion.Text = "Karia sro";
      // 
      // lblDate
      // 
      lblDate.Location = new System.Drawing.Point(12, 166);
      lblDate.Name = "lblDate";
      lblDate.Size = new System.Drawing.Size(148, 15);
      lblDate.TabIndex = 34;
      lblDate.Text = "Karia sro";
      // 
      // frmAbout
      // 
      AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
      AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      ClientSize = new System.Drawing.Size(545, 187);
      Controls.Add(lblDate);
      Controls.Add(lblVersion);
      Controls.Add(label4);
      Controls.Add(label3);
      Controls.Add(label2);
      Controls.Add(pictureBox1);
      Controls.Add(label1);
      Controls.Add(lblTitulek);
      Controls.Add(pictureBox2);
      Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
      MaximizeBox = false;
      MinimizeBox = false;
      Name = "frmAbout";
      Text = "Evitel - O aplikace";
      Load += frmAbout_Load;
      ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
      ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
      ResumeLayout(false);
      PerformLayout();
    }

    #endregion

    private System.Windows.Forms.PictureBox pictureBox2;
    private System.Windows.Forms.Label lblTitulek;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.PictureBox pictureBox1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label lblVersion;
    private System.Windows.Forms.Label lblDate;
  }
}