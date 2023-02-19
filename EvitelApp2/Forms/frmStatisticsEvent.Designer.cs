namespace EvitelApp2.Forms
{
  partial class frmStatisticsEvent
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
            this.dtFrom = new System.Windows.Forms.DateTimePicker();
            this.lblDatumACas = new System.Windows.Forms.Label();
            this.dtTo = new System.Windows.Forms.DateTimePicker();
            this.lblregion1 = new System.Windows.Forms.Label();
            this.cmbGrouping = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnWrite = new System.Windows.Forms.Button();
            this.cmbInterval = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkVcetneDniBezHovoru = new System.Windows.Forms.CheckBox();
            this.chkPodleKraje = new System.Windows.Forms.CheckBox();
            this.chkPodleTrestneCinnostiPodrobne = new System.Windows.Forms.CheckBox();
            this.chkPodleTrestneCinnosti = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtFrom
            // 
            this.dtFrom.CalendarFont = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dtFrom.CustomFormat = "dd-MM-yyyy";
            this.dtFrom.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dtFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFrom.Location = new System.Drawing.Point(110, 36);
            this.dtFrom.Name = "dtFrom";
            this.dtFrom.Size = new System.Drawing.Size(102, 27);
            this.dtFrom.TabIndex = 2;
            // 
            // lblDatumACas
            // 
            this.lblDatumACas.AutoSize = true;
            this.lblDatumACas.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblDatumACas.Location = new System.Drawing.Point(29, 40);
            this.lblDatumACas.Name = "lblDatumACas";
            this.lblDatumACas.Size = new System.Drawing.Size(75, 17);
            this.lblDatumACas.TabIndex = 3;
            this.lblDatumACas.Text = "Hovory Od:";
            // 
            // dtTo
            // 
            this.dtTo.CalendarFont = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dtTo.CustomFormat = "dd-MM-yyyy";
            this.dtTo.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dtTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtTo.Location = new System.Drawing.Point(268, 35);
            this.dtTo.Name = "dtTo";
            this.dtTo.Size = new System.Drawing.Size(102, 27);
            this.dtTo.TabIndex = 4;
            // 
            // lblregion1
            // 
            this.lblregion1.AutoSize = true;
            this.lblregion1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblregion1.Location = new System.Drawing.Point(611, 40);
            this.lblregion1.Name = "lblregion1";
            this.lblregion1.Size = new System.Drawing.Size(80, 17);
            this.lblregion1.TabIndex = 22;
            this.lblregion1.Text = "Seskupování";
            // 
            // cmbGrouping
            // 
            this.cmbGrouping.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbGrouping.FormattingEnabled = true;
            this.cmbGrouping.Location = new System.Drawing.Point(709, 36);
            this.cmbGrouping.Name = "cmbGrouping";
            this.cmbGrouping.Size = new System.Drawing.Size(253, 28);
            this.cmbGrouping.TabIndex = 23;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(234, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 17);
            this.label1.TabIndex = 24;
            this.label1.Text = "Do:";
            // 
            // btnWrite
            // 
            this.btnWrite.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnWrite.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnWrite.Image = global::EvitelApp2.Properties.Resources.save_close24;
            this.btnWrite.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnWrite.Location = new System.Drawing.Point(598, 138);
            this.btnWrite.Name = "btnWrite";
            this.btnWrite.Size = new System.Drawing.Size(228, 39);
            this.btnWrite.TabIndex = 32;
            this.btnWrite.Text = "Generuj statistiku";
            this.btnWrite.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnWrite.UseVisualStyleBackColor = true;
            this.btnWrite.Click += new System.EventHandler(this.btnWrite_Click);
            // 
            // cmbInterval
            // 
            this.cmbInterval.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbInterval.FormattingEnabled = true;
            this.cmbInterval.Location = new System.Drawing.Point(388, 35);
            this.cmbInterval.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cmbInterval.Name = "cmbInterval";
            this.cmbInterval.Size = new System.Drawing.Size(183, 28);
            this.cmbInterval.TabIndex = 33;
            this.cmbInterval.SelectedIndexChanged += new System.EventHandler(this.cmbInterval_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkPodleTrestneCinnosti);
            this.groupBox1.Controls.Add(this.chkPodleTrestneCinnostiPodrobne);
            this.groupBox1.Controls.Add(this.chkVcetneDniBezHovoru);
            this.groupBox1.Controls.Add(this.chkPodleKraje);
            this.groupBox1.Location = new System.Drawing.Point(29, 81);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(291, 169);
            this.groupBox1.TabIndex = 34;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Rozšíření statistiky";
            // 
            // chkVcetneDniBezHovoru
            // 
            this.chkVcetneDniBezHovoru.AutoSize = true;
            this.chkVcetneDniBezHovoru.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.chkVcetneDniBezHovoru.Location = new System.Drawing.Point(32, 123);
            this.chkVcetneDniBezHovoru.Name = "chkVcetneDniBezHovoru";
            this.chkVcetneDniBezHovoru.Size = new System.Drawing.Size(157, 21);
            this.chkVcetneDniBezHovoru.TabIndex = 33;
            this.chkVcetneDniBezHovoru.Text = "Včetně dní bez hovoru";
            this.chkVcetneDniBezHovoru.UseVisualStyleBackColor = true;
            // 
            // chkPodleKraje
            // 
            this.chkPodleKraje.AutoSize = true;
            this.chkPodleKraje.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.chkPodleKraje.Location = new System.Drawing.Point(32, 30);
            this.chkPodleKraje.Name = "chkPodleKraje";
            this.chkPodleKraje.Size = new System.Drawing.Size(94, 21);
            this.chkPodleKraje.TabIndex = 32;
            this.chkPodleKraje.Text = "Podle Kraje";
            this.chkPodleKraje.UseVisualStyleBackColor = true;
            // 
            // chkPodleTrestneCinnostiPodrobne
            // 
            this.chkPodleTrestneCinnostiPodrobne.AutoSize = true;
            this.chkPodleTrestneCinnostiPodrobne.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.chkPodleTrestneCinnostiPodrobne.Location = new System.Drawing.Point(32, 84);
            this.chkPodleTrestneCinnostiPodrobne.Name = "chkPodleTrestneCinnostiPodrobne";
            this.chkPodleTrestneCinnostiPodrobne.Size = new System.Drawing.Size(217, 21);
            this.chkPodleTrestneCinnostiPodrobne.TabIndex = 34;
            this.chkPodleTrestneCinnostiPodrobne.Text = "Podle Trestné činnosti podrobně";
            this.chkPodleTrestneCinnostiPodrobne.UseVisualStyleBackColor = true;
            // 
            // chkPodleTrestneCinnosti
            // 
            this.chkPodleTrestneCinnosti.AutoSize = true;
            this.chkPodleTrestneCinnosti.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.chkPodleTrestneCinnosti.Location = new System.Drawing.Point(32, 57);
            this.chkPodleTrestneCinnosti.Name = "chkPodleTrestneCinnosti";
            this.chkPodleTrestneCinnosti.Size = new System.Drawing.Size(154, 21);
            this.chkPodleTrestneCinnosti.TabIndex = 35;
            this.chkPodleTrestneCinnosti.Text = "Podle Trestné činnosti";
            this.chkPodleTrestneCinnosti.UseVisualStyleBackColor = true;
            // 
            // frmStatisticsEvent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(990, 266);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cmbInterval);
            this.Controls.Add(this.btnWrite);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblregion1);
            this.Controls.Add(this.cmbGrouping);
            this.Controls.Add(this.dtTo);
            this.Controls.Add(this.dtFrom);
            this.Controls.Add(this.lblDatumACas);
            this.Name = "frmStatisticsEvent";
            this.Text = "Statistika - Počet Událostí";
            this.Load += new System.EventHandler(this.frmStatisticsCall_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
    private System.Windows.Forms.CheckBox chkPodleTrestneCinnosti;
    private System.Windows.Forms.CheckBox chkPodleTrestneCinnostiPodrobne;
  }
}