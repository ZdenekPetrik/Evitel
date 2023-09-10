namespace EvitelApp2.Forms
{
  partial class frmExportDenniProtokol
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExportDenniProtokol));
      label1 = new System.Windows.Forms.Label();
      label2 = new System.Windows.Forms.Label();
      dateTimePickerFrom = new System.Windows.Forms.DateTimePicker();
      btnGenerate = new System.Windows.Forms.Button();
      label3 = new System.Windows.Forms.Label();
      numIncrement = new System.Windows.Forms.NumericUpDown();
      label4 = new System.Windows.Forms.Label();
      txtCisloJednaci = new System.Windows.Forms.TextBox();
      dtTo = new System.Windows.Forms.DateTimePicker();
      ((System.ComponentModel.ISupportInitialize)numIncrement).BeginInit();
      SuspendLayout();
      // 
      // label1
      // 
      label1.AutoSize = true;
      label1.Location = new System.Drawing.Point(37, 33);
      label1.Name = "label1";
      label1.Size = new System.Drawing.Size(71, 15);
      label1.TabIndex = 0;
      label1.Text = "Protokol Od";
      // 
      // label2
      // 
      label2.AutoSize = true;
      label2.Location = new System.Drawing.Point(38, 69);
      label2.Name = "label2";
      label2.Size = new System.Drawing.Size(70, 15);
      label2.TabIndex = 1;
      label2.Text = "Protokol Do";
      // 
      // dateTimePickerFrom
      // 
      dateTimePickerFrom.CalendarFont = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      dateTimePickerFrom.CustomFormat = "dd-MM-yyyy HH:mm";
      dateTimePickerFrom.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      dateTimePickerFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
      dateTimePickerFrom.Location = new System.Drawing.Point(138, 24);
      dateTimePickerFrom.Name = "dateTimePickerFrom";
      dateTimePickerFrom.Size = new System.Drawing.Size(228, 27);
      dateTimePickerFrom.TabIndex = 2;
      // 
      // btnGenerate
      // 
      btnGenerate.Location = new System.Drawing.Point(152, 171);
      btnGenerate.Name = "btnGenerate";
      btnGenerate.Size = new System.Drawing.Size(75, 23);
      btnGenerate.TabIndex = 4;
      btnGenerate.Text = "Generuj Protokol";
      btnGenerate.UseVisualStyleBackColor = true;
      btnGenerate.Click += btnGenerate_Click;
      // 
      // label3
      // 
      label3.AutoSize = true;
      label3.Location = new System.Drawing.Point(37, 114);
      label3.Name = "label3";
      label3.Size = new System.Drawing.Size(73, 15);
      label3.TabIndex = 5;
      label3.Text = "ID Protokolu";
      // 
      // numIncrement
      // 
      numIncrement.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      numIncrement.Location = new System.Drawing.Point(138, 109);
      numIncrement.Maximum = new decimal(new int[] { 99999999, 0, 0, 0 });
      numIncrement.Name = "numIncrement";
      numIncrement.Size = new System.Drawing.Size(86, 27);
      numIncrement.TabIndex = 6;
      // 
      // label4
      // 
      label4.AutoSize = true;
      label4.Location = new System.Drawing.Point(37, 145);
      label4.Name = "label4";
      label4.Size = new System.Drawing.Size(74, 15);
      label4.TabIndex = 7;
      label4.Text = "Číslo jednací";
      // 
      // txtCisloJednaci
      // 
      txtCisloJednaci.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      txtCisloJednaci.Location = new System.Drawing.Point(138, 138);
      txtCisloJednaci.Name = "txtCisloJednaci";
      txtCisloJednaci.ReadOnly = true;
      txtCisloJednaci.Size = new System.Drawing.Size(228, 27);
      txtCisloJednaci.TabIndex = 8;
      // 
      // dtTo
      // 
      dtTo.CalendarFont = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      dtTo.CustomFormat = "dd-MM-yyyy  HH:mm";
      dtTo.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      dtTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
      dtTo.Location = new System.Drawing.Point(138, 60);
      dtTo.Name = "dtTo";
      dtTo.Size = new System.Drawing.Size(228, 27);
      dtTo.TabIndex = 3;
      // 
      // frmExportDenniProtokol
      // 
      AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
      AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      ClientSize = new System.Drawing.Size(378, 206);
      Controls.Add(dtTo);
      Controls.Add(txtCisloJednaci);
      Controls.Add(label4);
      Controls.Add(numIncrement);
      Controls.Add(label3);
      Controls.Add(btnGenerate);
      Controls.Add(dateTimePickerFrom);
      Controls.Add(label2);
      Controls.Add(label1);
      Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
      Name = "frmExportDenniProtokol";
      Text = "Evitel - Protokol událostí";
      Load += frmExportDenniProtokol_Load;
      ((System.ComponentModel.ISupportInitialize)numIncrement).EndInit();
      ResumeLayout(false);
      PerformLayout();
    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.DateTimePicker dateTimePickerFrom;
    private System.Windows.Forms.Button btnGenerate;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.NumericUpDown numIncrement;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.TextBox txtCisloJednaci;
    private System.Windows.Forms.DateTimePicker dtTo;
  }
}