namespace EvitelApp2.Forms
{
  partial class frmStatisticsLPvK
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
      dtFrom = new System.Windows.Forms.DateTimePicker();
      lblDatumACas = new System.Windows.Forms.Label();
      dtTo = new System.Windows.Forms.DateTimePicker();
      lblregion1 = new System.Windows.Forms.Label();
      cmbGrouping = new System.Windows.Forms.ComboBox();
      label1 = new System.Windows.Forms.Label();
      btnWrite = new System.Windows.Forms.Button();
      cmbInterval = new System.Windows.Forms.ComboBox();
      groupBox1 = new System.Windows.Forms.GroupBox();
      chkAge = new System.Windows.Forms.CheckBox();
      chkSex = new System.Windows.Forms.CheckBox();
      chkTypZdroje = new System.Windows.Forms.CheckBox();
      chkTypSluzby = new System.Windows.Forms.CheckBox();
      chkVolajici = new System.Windows.Forms.CheckBox();
      chkTypKontaktu = new System.Windows.Forms.CheckBox();
      chkZapsal = new System.Windows.Forms.CheckBox();
      chkVcetneDniBezHovoru = new System.Windows.Forms.CheckBox();
      groupBox2 = new System.Windows.Forms.GroupBox();
      radioButton4 = new System.Windows.Forms.RadioButton();
      radioButton3 = new System.Windows.Forms.RadioButton();
      radioButton2 = new System.Windows.Forms.RadioButton();
      radioButton1 = new System.Windows.Forms.RadioButton();
      groupBox1.SuspendLayout();
      groupBox2.SuspendLayout();
      SuspendLayout();
      // 
      // dtFrom
      // 
      dtFrom.CalendarFont = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      dtFrom.CustomFormat = "dd-MM-yyyy";
      dtFrom.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      dtFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
      dtFrom.Location = new System.Drawing.Point(110, 36);
      dtFrom.Name = "dtFrom";
      dtFrom.Size = new System.Drawing.Size(102, 27);
      dtFrom.TabIndex = 2;
      // 
      // lblDatumACas
      // 
      lblDatumACas.AutoSize = true;
      lblDatumACas.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      lblDatumACas.Location = new System.Drawing.Point(29, 40);
      lblDatumACas.Name = "lblDatumACas";
      lblDatumACas.Size = new System.Drawing.Size(75, 17);
      lblDatumACas.TabIndex = 3;
      lblDatumACas.Text = "Hovory Od:";
      // 
      // dtTo
      // 
      dtTo.CalendarFont = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      dtTo.CustomFormat = "dd-MM-yyyy";
      dtTo.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      dtTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
      dtTo.Location = new System.Drawing.Point(268, 35);
      dtTo.Name = "dtTo";
      dtTo.Size = new System.Drawing.Size(102, 27);
      dtTo.TabIndex = 4;
      // 
      // lblregion1
      // 
      lblregion1.AutoSize = true;
      lblregion1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      lblregion1.Location = new System.Drawing.Point(611, 40);
      lblregion1.Name = "lblregion1";
      lblregion1.Size = new System.Drawing.Size(80, 17);
      lblregion1.TabIndex = 22;
      lblregion1.Text = "Seskupování";
      // 
      // cmbGrouping
      // 
      cmbGrouping.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      cmbGrouping.FormattingEnabled = true;
      cmbGrouping.Location = new System.Drawing.Point(709, 36);
      cmbGrouping.Name = "cmbGrouping";
      cmbGrouping.Size = new System.Drawing.Size(253, 28);
      cmbGrouping.TabIndex = 23;
      // 
      // label1
      // 
      label1.AutoSize = true;
      label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      label1.Location = new System.Drawing.Point(234, 40);
      label1.Name = "label1";
      label1.Size = new System.Drawing.Size(28, 17);
      label1.TabIndex = 24;
      label1.Text = "Do:";
      // 
      // btnWrite
      // 
      btnWrite.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
      btnWrite.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      btnWrite.Image = Properties.Resources.save_close24;
      btnWrite.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
      btnWrite.Location = new System.Drawing.Point(734, 212);
      btnWrite.Name = "btnWrite";
      btnWrite.Size = new System.Drawing.Size(228, 39);
      btnWrite.TabIndex = 32;
      btnWrite.Text = "Generuj statistiku";
      btnWrite.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      btnWrite.UseVisualStyleBackColor = true;
      btnWrite.Click += btnWrite_Click;
      // 
      // cmbInterval
      // 
      cmbInterval.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      cmbInterval.FormattingEnabled = true;
      cmbInterval.Location = new System.Drawing.Point(388, 35);
      cmbInterval.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
      cmbInterval.Name = "cmbInterval";
      cmbInterval.Size = new System.Drawing.Size(183, 28);
      cmbInterval.TabIndex = 33;
      cmbInterval.SelectedIndexChanged += cmbInterval_SelectedIndexChanged;
      // 
      // groupBox1
      // 
      groupBox1.Controls.Add(chkAge);
      groupBox1.Controls.Add(chkSex);
      groupBox1.Controls.Add(chkTypZdroje);
      groupBox1.Controls.Add(chkTypSluzby);
      groupBox1.Controls.Add(chkVolajici);
      groupBox1.Controls.Add(chkTypKontaktu);
      groupBox1.Controls.Add(chkZapsal);
      groupBox1.Location = new System.Drawing.Point(29, 81);
      groupBox1.Name = "groupBox1";
      groupBox1.Size = new System.Drawing.Size(291, 169);
      groupBox1.TabIndex = 34;
      groupBox1.TabStop = false;
      groupBox1.Text = "Rozšíření statistiky";
      // 
      // chkAge
      // 
      chkAge.AutoSize = true;
      chkAge.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      chkAge.Location = new System.Drawing.Point(176, 57);
      chkAge.Name = "chkAge";
      chkAge.Size = new System.Drawing.Size(91, 21);
      chkAge.TabIndex = 39;
      chkAge.Text = "Podle Věku";
      chkAge.UseVisualStyleBackColor = true;
      // 
      // chkSex
      // 
      chkSex.AutoSize = true;
      chkSex.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      chkSex.Location = new System.Drawing.Point(176, 30);
      chkSex.Name = "chkSex";
      chkSex.Size = new System.Drawing.Size(105, 21);
      chkSex.TabIndex = 38;
      chkSex.Text = "Podle Pohlaví";
      chkSex.UseVisualStyleBackColor = true;
      // 
      // chkTypZdroje
      // 
      chkTypZdroje.AutoSize = true;
      chkTypZdroje.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      chkTypZdroje.Location = new System.Drawing.Point(32, 138);
      chkTypZdroje.Name = "chkTypZdroje";
      chkTypZdroje.Size = new System.Drawing.Size(132, 21);
      chkTypZdroje.TabIndex = 37;
      chkTypZdroje.Text = "Podle Typu zdroje";
      chkTypZdroje.UseVisualStyleBackColor = true;
      // 
      // chkTypSluzby
      // 
      chkTypSluzby.AutoSize = true;
      chkTypSluzby.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      chkTypSluzby.Location = new System.Drawing.Point(32, 111);
      chkTypSluzby.Name = "chkTypSluzby";
      chkTypSluzby.Size = new System.Drawing.Size(131, 21);
      chkTypSluzby.TabIndex = 36;
      chkTypSluzby.Text = "Podle Typu služby";
      chkTypSluzby.UseVisualStyleBackColor = true;
      // 
      // chkVolajici
      // 
      chkVolajici.AutoSize = true;
      chkVolajici.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      chkVolajici.Location = new System.Drawing.Point(32, 57);
      chkVolajici.Name = "chkVolajici";
      chkVolajici.Size = new System.Drawing.Size(119, 21);
      chkVolajici.TabIndex = 35;
      chkVolajici.Text = "Podle Volajícího";
      chkVolajici.UseVisualStyleBackColor = true;
      // 
      // chkTypKontaktu
      // 
      chkTypKontaktu.AutoSize = true;
      chkTypKontaktu.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      chkTypKontaktu.Location = new System.Drawing.Point(32, 84);
      chkTypKontaktu.Name = "chkTypKontaktu";
      chkTypKontaktu.Size = new System.Drawing.Size(144, 21);
      chkTypKontaktu.TabIndex = 34;
      chkTypKontaktu.Text = "Podle Typu kontaktu";
      chkTypKontaktu.UseVisualStyleBackColor = true;
      // 
      // chkZapsal
      // 
      chkZapsal.AutoSize = true;
      chkZapsal.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      chkZapsal.Location = new System.Drawing.Point(32, 30);
      chkZapsal.Name = "chkZapsal";
      chkZapsal.Size = new System.Drawing.Size(102, 21);
      chkZapsal.TabIndex = 32;
      chkZapsal.Text = "Podle Zapsal";
      chkZapsal.UseVisualStyleBackColor = true;
      // 
      // chkVcetneDniBezHovoru
      // 
      chkVcetneDniBezHovoru.AutoSize = true;
      chkVcetneDniBezHovoru.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      chkVcetneDniBezHovoru.Location = new System.Drawing.Point(37, 147);
      chkVcetneDniBezHovoru.Name = "chkVcetneDniBezHovoru";
      chkVcetneDniBezHovoru.Size = new System.Drawing.Size(157, 21);
      chkVcetneDniBezHovoru.TabIndex = 33;
      chkVcetneDniBezHovoru.Text = "Včetně dní bez hovoru";
      chkVcetneDniBezHovoru.UseVisualStyleBackColor = true;
      // 
      // groupBox2
      // 
      groupBox2.Controls.Add(radioButton4);
      groupBox2.Controls.Add(radioButton3);
      groupBox2.Controls.Add(chkVcetneDniBezHovoru);
      groupBox2.Controls.Add(radioButton2);
      groupBox2.Controls.Add(radioButton1);
      groupBox2.Location = new System.Drawing.Point(343, 85);
      groupBox2.Name = "groupBox2";
      groupBox2.Size = new System.Drawing.Size(291, 169);
      groupBox2.TabIndex = 36;
      groupBox2.TabStop = false;
      groupBox2.Text = "Typ statistiky";
      // 
      // radioButton4
      // 
      radioButton4.AutoSize = true;
      radioButton4.Location = new System.Drawing.Point(37, 123);
      radioButton4.Name = "radioButton4";
      radioButton4.Size = new System.Drawing.Size(95, 19);
      radioButton4.TabIndex = 3;
      radioButton4.TabStop = true;
      radioButton4.Text = "Závěr hovoru";
      radioButton4.UseVisualStyleBackColor = true;
      // 
      // radioButton3
      // 
      radioButton3.AutoSize = true;
      radioButton3.Location = new System.Drawing.Point(37, 93);
      radioButton3.Name = "radioButton3";
      radioButton3.Size = new System.Drawing.Size(103, 19);
      radioButton3.TabIndex = 2;
      radioButton3.TabStop = true;
      radioButton3.Text = "Téma kontaktu";
      radioButton3.UseVisualStyleBackColor = true;
      // 
      // radioButton2
      // 
      radioButton2.AutoSize = true;
      radioButton2.Location = new System.Drawing.Point(37, 63);
      radioButton2.Name = "radioButton2";
      radioButton2.Size = new System.Drawing.Size(131, 19);
      radioButton2.TabIndex = 1;
      radioButton2.TabStop = true;
      radioButton2.Text = "Aktuální stav klienta";
      radioButton2.UseVisualStyleBackColor = true;
      // 
      // radioButton1
      // 
      radioButton1.AutoSize = true;
      radioButton1.Location = new System.Drawing.Point(37, 33);
      radioButton1.Name = "radioButton1";
      radioButton1.Size = new System.Drawing.Size(131, 19);
      radioButton1.TabIndex = 0;
      radioButton1.TabStop = true;
      radioButton1.Text = "Pouze počet hovorů";
      radioButton1.UseVisualStyleBackColor = true;
      // 
      // frmStatisticsLPvK
      // 
      AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
      AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      ClientSize = new System.Drawing.Size(990, 266);
      Controls.Add(groupBox2);
      Controls.Add(groupBox1);
      Controls.Add(cmbInterval);
      Controls.Add(btnWrite);
      Controls.Add(label1);
      Controls.Add(lblregion1);
      Controls.Add(cmbGrouping);
      Controls.Add(dtTo);
      Controls.Add(dtFrom);
      Controls.Add(lblDatumACas);
      Name = "frmStatisticsLPvK";
      Text = "Statistika - LPvK (Linka Pomoci v Krizi)";
      Load += frm_Load;
      VisibleChanged += frmStatisticsLPvK_VisibleChanged;
      groupBox1.ResumeLayout(false);
      groupBox1.PerformLayout();
      groupBox2.ResumeLayout(false);
      groupBox2.PerformLayout();
      ResumeLayout(false);
      PerformLayout();
    }

    #endregion

    private System.Windows.Forms.DateTimePicker dtFrom;
    private System.Windows.Forms.Label lblDatumACas;
    private System.Windows.Forms.DateTimePicker dtTo;
    private System.Windows.Forms.Label lblregion1;
    private System.Windows.Forms.ComboBox cmbGrouping;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button btnWrite;
    private System.Windows.Forms.ComboBox cmbInterval;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.CheckBox chkPodleKraje;
    private System.Windows.Forms.CheckBox chkVcetneDniBezHovoru;
    private System.Windows.Forms.CheckBox chkVolajici;
    private System.Windows.Forms.CheckBox chkTypKontaktu;
    private System.Windows.Forms.CheckBox chkAge;
    private System.Windows.Forms.CheckBox chkSex;
    private System.Windows.Forms.CheckBox chkTypZdroje;
    private System.Windows.Forms.CheckBox chkTypSluzby;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.RadioButton radioButton4;
    private System.Windows.Forms.RadioButton radioButton3;
    private System.Windows.Forms.RadioButton radioButton2;
    private System.Windows.Forms.RadioButton radioButton1;
    private System.Windows.Forms.CheckBox chkZapsal;
  }
}