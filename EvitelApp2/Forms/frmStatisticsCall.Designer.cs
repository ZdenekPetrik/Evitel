﻿namespace EvitelApp2.Forms
{
  partial class frmStatisticsCall
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
      chkVcetneDniBezHovoru = new System.Windows.Forms.CheckBox();
      chkPodleTypuHovoru = new System.Windows.Forms.CheckBox();
      chkUsers = new System.Windows.Forms.CheckBox();
      groupBox1.SuspendLayout();
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
      btnWrite.Location = new System.Drawing.Point(734, 100);
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
      groupBox1.Controls.Add(chkUsers);
      groupBox1.Controls.Add(chkVcetneDniBezHovoru);
      groupBox1.Controls.Add(chkPodleTypuHovoru);
      groupBox1.Location = new System.Drawing.Point(29, 81);
      groupBox1.Name = "groupBox1";
      groupBox1.Size = new System.Drawing.Size(291, 126);
      groupBox1.TabIndex = 34;
      groupBox1.TabStop = false;
      groupBox1.Text = "Rozšíření statistiky";
      // 
      // chkVcetneDniBezHovoru
      // 
      chkVcetneDniBezHovoru.AutoSize = true;
      chkVcetneDniBezHovoru.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      chkVcetneDniBezHovoru.Location = new System.Drawing.Point(32, 99);
      chkVcetneDniBezHovoru.Name = "chkVcetneDniBezHovoru";
      chkVcetneDniBezHovoru.Size = new System.Drawing.Size(157, 21);
      chkVcetneDniBezHovoru.TabIndex = 33;
      chkVcetneDniBezHovoru.Text = "Včetně dní bez hovoru";
      chkVcetneDniBezHovoru.UseVisualStyleBackColor = true;
      // 
      // chkPodleTypuHovoru
      // 
      chkPodleTypuHovoru.AutoSize = true;
      chkPodleTypuHovoru.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      chkPodleTypuHovoru.Location = new System.Drawing.Point(32, 30);
      chkPodleTypuHovoru.Name = "chkPodleTypuHovoru";
      chkPodleTypuHovoru.Size = new System.Drawing.Size(138, 21);
      chkPodleTypuHovoru.TabIndex = 32;
      chkPodleTypuHovoru.Text = "Podle Typu Hovoru";
      chkPodleTypuHovoru.UseVisualStyleBackColor = true;
      // 
      // chkUsers
      // 
      chkUsers.AutoSize = true;
      chkUsers.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      chkUsers.Location = new System.Drawing.Point(32, 57);
      chkUsers.Name = "chkUsers";
      chkUsers.Size = new System.Drawing.Size(114, 21);
      chkUsers.TabIndex = 34;
      chkUsers.Text = "Podle uživatelů";
      chkUsers.UseVisualStyleBackColor = true;
      // 
      // frmStatisticsCall
      // 
      AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
      AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      ClientSize = new System.Drawing.Size(990, 233);
      Controls.Add(groupBox1);
      Controls.Add(cmbInterval);
      Controls.Add(btnWrite);
      Controls.Add(label1);
      Controls.Add(lblregion1);
      Controls.Add(cmbGrouping);
      Controls.Add(dtTo);
      Controls.Add(dtFrom);
      Controls.Add(lblDatumACas);
      Name = "frmStatisticsCall";
      Text = "Statistika - Počet Volání";
      Load += frmStatisticsCall_Load;
      groupBox1.ResumeLayout(false);
      groupBox1.PerformLayout();
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
    private System.Windows.Forms.CheckBox chkPodleTypuHovoru;
    private System.Windows.Forms.CheckBox chkVcetneDniBezHovoru;
    private System.Windows.Forms.CheckBox chkUsers;
  }
}