namespace EvitelApp2.Controls
{
  partial class ucCallLPK
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

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
            this.btnBack = new System.Windows.Forms.Button();
            this.boxCall = new System.Windows.Forms.GroupBox();
            this.cmbTypeService = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbContactType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblCallTimeSum = new System.Windows.Forms.Label();
            this.txtVolajici = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tmCallTo = new System.Windows.Forms.DateTimePicker();
            this.btnWrite = new System.Windows.Forms.Button();
            this.dtCall = new System.Windows.Forms.DateTimePicker();
            this.lblDatumACas = new System.Windows.Forms.Label();
            this.lblVolajici = new System.Windows.Forms.Label();
            this.lblZapsal = new System.Windows.Forms.Label();
            this.txtLoginUser = new System.Windows.Forms.TextBox();
            this.tmCall = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbFrom = new System.Windows.Forms.ComboBox();
            this.cmbSex = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.boxClient = new System.Windows.Forms.GroupBox();
            this.cmbAge = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.boxResult = new System.Windows.Forms.GroupBox();
            this.lblEndOfSpeech = new System.Windows.Forms.Label();
            this.lblCurrentClientStatus = new System.Windows.Forms.Label();
            this.lblContactTopic = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tvEndOfSpeech = new System.Windows.Forms.TreeView();
            this.label8 = new System.Windows.Forms.Label();
            this.tvCurrentClientStatus = new System.Windows.Forms.TreeView();
            this.label7 = new System.Windows.Forms.Label();
            this.tvContactTopic = new System.Windows.Forms.TreeView();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.boxCall.SuspendLayout();
            this.boxClient.SuspendLayout();
            this.boxResult.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(15, 17);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 23;
            this.btnBack.Text = "<< Zpět";
            this.btnBack.UseVisualStyleBackColor = true;
            // 
            // boxCall
            // 
            this.boxCall.Controls.Add(this.cmbTypeService);
            this.boxCall.Controls.Add(this.label5);
            this.boxCall.Controls.Add(this.cmbContactType);
            this.boxCall.Controls.Add(this.label4);
            this.boxCall.Controls.Add(this.lblCallTimeSum);
            this.boxCall.Controls.Add(this.txtVolajici);
            this.boxCall.Controls.Add(this.label1);
            this.boxCall.Controls.Add(this.tmCallTo);
            this.boxCall.Controls.Add(this.btnWrite);
            this.boxCall.Controls.Add(this.dtCall);
            this.boxCall.Controls.Add(this.lblDatumACas);
            this.boxCall.Controls.Add(this.lblVolajici);
            this.boxCall.Controls.Add(this.lblZapsal);
            this.boxCall.Controls.Add(this.txtLoginUser);
            this.boxCall.Controls.Add(this.tmCall);
            this.boxCall.Location = new System.Drawing.Point(3, 55);
            this.boxCall.Name = "boxCall";
            this.boxCall.Size = new System.Drawing.Size(1415, 104);
            this.boxCall.TabIndex = 24;
            this.boxCall.TabStop = false;
            this.boxCall.Text = "Údaje o Hovoru";
            // 
            // cmbTypeService
            // 
            this.cmbTypeService.FormattingEnabled = true;
            this.cmbTypeService.Location = new System.Drawing.Point(715, 67);
            this.cmbTypeService.Name = "cmbTypeService";
            this.cmbTypeService.Size = new System.Drawing.Size(176, 23);
            this.cmbTypeService.TabIndex = 55;
            this.cmbTypeService.Validating += new System.ComponentModel.CancelEventHandler(this.cmbTypeService_Validating);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(592, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 17);
            this.label5.TabIndex = 56;
            this.label5.Text = "Typ služby";
            // 
            // cmbContactType
            // 
            this.cmbContactType.FormattingEnabled = true;
            this.cmbContactType.Location = new System.Drawing.Point(158, 67);
            this.cmbContactType.Name = "cmbContactType";
            this.cmbContactType.Size = new System.Drawing.Size(181, 23);
            this.cmbContactType.TabIndex = 54;
            this.cmbContactType.Validating += new System.ComponentModel.CancelEventHandler(this.cmbContactType_Validating);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(6, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 17);
            this.label4.TabIndex = 54;
            this.label4.Text = "Typ kontaktu";
            // 
            // lblCallTimeSum
            // 
            this.lblCallTimeSum.AutoSize = true;
            this.lblCallTimeSum.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblCallTimeSum.Location = new System.Drawing.Point(498, 32);
            this.lblCallTimeSum.Name = "lblCallTimeSum";
            this.lblCallTimeSum.Size = new System.Drawing.Size(39, 17);
            this.lblCallTimeSum.TabIndex = 49;
            this.lblCallTimeSum.Text = "00:00";
            // 
            // txtVolajici
            // 
            this.txtVolajici.Location = new System.Drawing.Point(715, 27);
            this.txtVolajici.Name = "txtVolajici";
            this.txtVolajici.Size = new System.Drawing.Size(176, 23);
            this.txtVolajici.TabIndex = 33;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(390, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 17);
            this.label1.TabIndex = 32;
            this.label1.Text = "do:";
            // 
            // tmCallTo
            // 
            this.tmCallTo.CustomFormat = "HH:mm";
            this.tmCallTo.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tmCallTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.tmCallTo.Location = new System.Drawing.Point(423, 22);
            this.tmCallTo.Name = "tmCallTo";
            this.tmCallTo.ShowUpDown = true;
            this.tmCallTo.Size = new System.Drawing.Size(60, 27);
            this.tmCallTo.TabIndex = 31;
            this.tmCallTo.ValueChanged += new System.EventHandler(this.tmCallTo_ValueChanged);
            // 
            // btnWrite
            // 
            this.btnWrite.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnWrite.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnWrite.Image = global::EvitelApp2.Properties.Resources.save_close24;
            this.btnWrite.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnWrite.Location = new System.Drawing.Point(1314, 18);
            this.btnWrite.Name = "btnWrite";
            this.btnWrite.Size = new System.Drawing.Size(95, 39);
            this.btnWrite.TabIndex = 10;
            this.btnWrite.Text = "Uložit";
            this.btnWrite.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnWrite.UseVisualStyleBackColor = true;
            this.btnWrite.Click += new System.EventHandler(this.btnWrite_Click);
            // 
            // dtCall
            // 
            this.dtCall.CalendarFont = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dtCall.CustomFormat = "dd-MM-yyyy";
            this.dtCall.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dtCall.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtCall.Location = new System.Drawing.Point(158, 22);
            this.dtCall.Name = "dtCall";
            this.dtCall.Size = new System.Drawing.Size(102, 27);
            this.dtCall.TabIndex = 0;
            // 
            // lblDatumACas
            // 
            this.lblDatumACas.AutoSize = true;
            this.lblDatumACas.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblDatumACas.Location = new System.Drawing.Point(6, 28);
            this.lblDatumACas.Name = "lblDatumACas";
            this.lblDatumACas.Size = new System.Drawing.Size(148, 17);
            this.lblDatumACas.TabIndex = 1;
            this.lblDatumACas.Text = "Datum a čas hovoru od:";
            // 
            // lblVolajici
            // 
            this.lblVolajici.AutoSize = true;
            this.lblVolajici.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblVolajici.Location = new System.Drawing.Point(612, 30);
            this.lblVolajici.Name = "lblVolajici";
            this.lblVolajici.Size = new System.Drawing.Size(48, 17);
            this.lblVolajici.TabIndex = 2;
            this.lblVolajici.Text = "Volající";
            // 
            // lblZapsal
            // 
            this.lblZapsal.AutoSize = true;
            this.lblZapsal.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblZapsal.Location = new System.Drawing.Point(952, 29);
            this.lblZapsal.Name = "lblZapsal";
            this.lblZapsal.Size = new System.Drawing.Size(61, 17);
            this.lblZapsal.TabIndex = 4;
            this.lblZapsal.Text = "Zapsal(a)";
            // 
            // txtLoginUser
            // 
            this.txtLoginUser.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtLoginUser.Location = new System.Drawing.Point(1019, 25);
            this.txtLoginUser.Name = "txtLoginUser";
            this.txtLoginUser.ReadOnly = true;
            this.txtLoginUser.Size = new System.Drawing.Size(277, 27);
            this.txtLoginUser.TabIndex = 7;
            // 
            // tmCall
            // 
            this.tmCall.CustomFormat = "HH:mm";
            this.tmCall.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tmCall.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.tmCall.Location = new System.Drawing.Point(266, 22);
            this.tmCall.Name = "tmCall";
            this.tmCall.ShowUpDown = true;
            this.tmCall.Size = new System.Drawing.Size(73, 27);
            this.tmCall.TabIndex = 9;
            this.tmCall.ValueChanged += new System.EventHandler(this.tmCall_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(6, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 17);
            this.label2.TabIndex = 50;
            this.label2.Text = "Odkud je klient";
            // 
            // cmbFrom
            // 
            this.cmbFrom.FormattingEnabled = true;
            this.cmbFrom.Location = new System.Drawing.Point(147, 29);
            this.cmbFrom.Name = "cmbFrom";
            this.cmbFrom.Size = new System.Drawing.Size(210, 23);
            this.cmbFrom.TabIndex = 51;
            this.cmbFrom.Validating += new System.ComponentModel.CancelEventHandler(this.cmbFrom_Validating);
            // 
            // cmbSex
            // 
            this.cmbSex.FormattingEnabled = true;
            this.cmbSex.Location = new System.Drawing.Point(526, 29);
            this.cmbSex.Name = "cmbSex";
            this.cmbSex.Size = new System.Drawing.Size(210, 23);
            this.cmbSex.TabIndex = 53;
            this.cmbSex.Validating += new System.ComponentModel.CancelEventHandler(this.cmbSex_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(451, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 17);
            this.label3.TabIndex = 52;
            this.label3.Text = "Pohlaví";
            // 
            // boxClient
            // 
            this.boxClient.Controls.Add(this.cmbAge);
            this.boxClient.Controls.Add(this.label6);
            this.boxClient.Controls.Add(this.cmbFrom);
            this.boxClient.Controls.Add(this.cmbSex);
            this.boxClient.Controls.Add(this.label3);
            this.boxClient.Controls.Add(this.label2);
            this.boxClient.Location = new System.Drawing.Point(5, 165);
            this.boxClient.Name = "boxClient";
            this.boxClient.Size = new System.Drawing.Size(1105, 75);
            this.boxClient.TabIndex = 54;
            this.boxClient.TabStop = false;
            this.boxClient.Text = "Klient";
            // 
            // cmbAge
            // 
            this.cmbAge.FormattingEnabled = true;
            this.cmbAge.Location = new System.Drawing.Point(876, 28);
            this.cmbAge.Name = "cmbAge";
            this.cmbAge.Size = new System.Drawing.Size(210, 23);
            this.cmbAge.TabIndex = 55;
            this.cmbAge.Validating += new System.ComponentModel.CancelEventHandler(this.cmbAge_Validating);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(811, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 17);
            this.label6.TabIndex = 54;
            this.label6.Text = "Věk";
            // 
            // boxResult
            // 
            this.boxResult.Controls.Add(this.lblEndOfSpeech);
            this.boxResult.Controls.Add(this.lblCurrentClientStatus);
            this.boxResult.Controls.Add(this.lblContactTopic);
            this.boxResult.Controls.Add(this.label12);
            this.boxResult.Controls.Add(this.label11);
            this.boxResult.Controls.Add(this.label10);
            this.boxResult.Controls.Add(this.label9);
            this.boxResult.Controls.Add(this.tvEndOfSpeech);
            this.boxResult.Controls.Add(this.label8);
            this.boxResult.Controls.Add(this.tvCurrentClientStatus);
            this.boxResult.Controls.Add(this.label7);
            this.boxResult.Controls.Add(this.tvContactTopic);
            this.boxResult.Location = new System.Drawing.Point(5, 272);
            this.boxResult.Name = "boxResult";
            this.boxResult.Size = new System.Drawing.Size(1103, 478);
            this.boxResult.TabIndex = 55;
            this.boxResult.TabStop = false;
            this.boxResult.Text = "Hodnocení hovoru";
            // 
            // lblEndOfSpeech
            // 
            this.lblEndOfSpeech.AutoSize = true;
            this.lblEndOfSpeech.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblEndOfSpeech.Location = new System.Drawing.Point(145, 458);
            this.lblEndOfSpeech.Name = "lblEndOfSpeech";
            this.lblEndOfSpeech.Size = new System.Drawing.Size(95, 17);
            this.lblEndOfSpeech.TabIndex = 66;
            this.lblEndOfSpeech.Text = "Téma kontaktu:";
            // 
            // lblCurrentClientStatus
            // 
            this.lblCurrentClientStatus.AutoSize = true;
            this.lblCurrentClientStatus.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblCurrentClientStatus.Location = new System.Drawing.Point(145, 430);
            this.lblCurrentClientStatus.Name = "lblCurrentClientStatus";
            this.lblCurrentClientStatus.Size = new System.Drawing.Size(95, 17);
            this.lblCurrentClientStatus.TabIndex = 65;
            this.lblCurrentClientStatus.Text = "Téma kontaktu:";
            // 
            // lblContactTopic
            // 
            this.lblContactTopic.AutoSize = true;
            this.lblContactTopic.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblContactTopic.Location = new System.Drawing.Point(145, 402);
            this.lblContactTopic.Name = "lblContactTopic";
            this.lblContactTopic.Size = new System.Drawing.Size(95, 17);
            this.lblContactTopic.TabIndex = 64;
            this.lblContactTopic.Text = "Téma kontaktu:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label12.Location = new System.Drawing.Point(10, 458);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(88, 17);
            this.label12.TabIndex = 63;
            this.label12.Text = "Závěr hovoru:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label11.Location = new System.Drawing.Point(10, 430);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(124, 17);
            this.label11.TabIndex = 62;
            this.label11.Text = "Aktuální stav klienta:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label10.Location = new System.Drawing.Point(10, 402);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(95, 17);
            this.label10.TabIndex = 61;
            this.label10.Text = "Téma kontaktu:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(975, 13);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(85, 17);
            this.label9.TabIndex = 60;
            this.label9.Text = "Závěr hovoru";
            // 
            // tvEndOfSpeech
            // 
            this.tvEndOfSpeech.Location = new System.Drawing.Point(777, 33);
            this.tvEndOfSpeech.Name = "tvEndOfSpeech";
            this.tvEndOfSpeech.Size = new System.Drawing.Size(290, 357);
            this.tvEndOfSpeech.TabIndex = 59;
            this.tvEndOfSpeech.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvEndOfSpeech_AfterCheck);
            this.tvEndOfSpeech.DrawNode += new System.Windows.Forms.DrawTreeNodeEventHandler(this.tvEndOfSpeech_DrawNode);
            this.tvEndOfSpeech.Validating += new System.ComponentModel.CancelEventHandler(this.tvEndOfSpeech_Validating);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(590, 13);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(121, 17);
            this.label8.TabIndex = 58;
            this.label8.Text = "Aktuální stav klienta";
            // 
            // tvCurrentClientStatus
            // 
            this.tvCurrentClientStatus.Location = new System.Drawing.Point(392, 33);
            this.tvCurrentClientStatus.Name = "tvCurrentClientStatus";
            this.tvCurrentClientStatus.Size = new System.Drawing.Size(290, 357);
            this.tvCurrentClientStatus.TabIndex = 57;
            this.tvCurrentClientStatus.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvCurrentClientStatus_AfterCheck);
            this.tvCurrentClientStatus.DrawNode += new System.Windows.Forms.DrawTreeNodeEventHandler(this.tvCurrentClientStatus_DrawNode);
            this.tvCurrentClientStatus.Validating += new System.ComponentModel.CancelEventHandler(this.tvCurrentClientStatus_Validating);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(208, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 17);
            this.label7.TabIndex = 56;
            this.label7.Text = "Téma kontaktu";
            // 
            // tvContactTopic
            // 
            this.tvContactTopic.Location = new System.Drawing.Point(10, 33);
            this.tvContactTopic.Name = "tvContactTopic";
            this.tvContactTopic.Size = new System.Drawing.Size(290, 357);
            this.tvContactTopic.TabIndex = 0;
            this.tvContactTopic.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvContactTopic_AfterCheck);
            this.tvContactTopic.DrawNode += new System.Windows.Forms.DrawTreeNodeEventHandler(this.tvContactTopic_DrawNode);
            this.tvContactTopic.Validating += new System.ComponentModel.CancelEventHandler(this.tvContactTopic_Validating);
            // 
            // txtNote
            // 
            this.txtNote.Location = new System.Drawing.Point(1114, 185);
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtNote.Size = new System.Drawing.Size(304, 562);
            this.txtNote.TabIndex = 57;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label13.Location = new System.Drawing.Point(1114, 165);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(122, 17);
            this.label13.TabIndex = 56;
            this.label13.Text = "Poznámka k hovoru";
            // 
            // ucCallLPK
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtNote);
            this.Controls.Add(this.boxResult);
            this.Controls.Add(this.boxClient);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.boxCall);
            this.Name = "ucCallLPK";
            this.Size = new System.Drawing.Size(1429, 753);
            this.Load += new System.EventHandler(this.ucCallLPK_Load);
            this.boxCall.ResumeLayout(false);
            this.boxCall.PerformLayout();
            this.boxClient.ResumeLayout(false);
            this.boxClient.PerformLayout();
            this.boxResult.ResumeLayout(false);
            this.boxResult.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button btnBack;
    private System.Windows.Forms.GroupBox boxCall;
    private System.Windows.Forms.Button btnWrite;
    private System.Windows.Forms.DateTimePicker dtCall;
    private System.Windows.Forms.Label lblDatumACas;
    private System.Windows.Forms.Label lblVolajici;
    private System.Windows.Forms.Label lblZapsal;
    private System.Windows.Forms.TextBox txtLoginUser;
    private System.Windows.Forms.DateTimePicker tmCall;
    private System.Windows.Forms.TextBox txtVolajici;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.DateTimePicker tmCallTo;
    private System.Windows.Forms.Label lblCallTimeSum;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.ComboBox cmbFrom;
    private System.Windows.Forms.ComboBox cmbSex;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.ComboBox cmbTypeService;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.ComboBox cmbContactType;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.GroupBox boxClient;
    private System.Windows.Forms.ComboBox cmbAge;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.GroupBox boxResult;
    private System.Windows.Forms.Label lblEndOfSpeech;
    private System.Windows.Forms.Label lblCurrentClientStatus;
    private System.Windows.Forms.Label lblContactTopic;
    private System.Windows.Forms.Label label12;
    private System.Windows.Forms.Label label11;
    private System.Windows.Forms.Label label10;
    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.TreeView tvEndOfSpeech;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.TreeView tvCurrentClientStatus;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.TreeView tvContactTopic;
    private System.Windows.Forms.TextBox txtNote;
    private System.Windows.Forms.Label label13;
  }
}
