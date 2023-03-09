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
      components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucCallLPK));
      btnBack = new System.Windows.Forms.Button();
      boxCall = new System.Windows.Forms.GroupBox();
      pictureClock = new System.Windows.Forms.PictureBox();
      dtCall = new System.Windows.Forms.DateTimePicker();
      lblEditInfo = new System.Windows.Forms.Label();
      cmbTypeService = new System.Windows.Forms.ComboBox();
      label5 = new System.Windows.Forms.Label();
      cmbContactType = new System.Windows.Forms.ComboBox();
      label4 = new System.Windows.Forms.Label();
      lblCallTimeSum = new System.Windows.Forms.Label();
      txtVolajici = new System.Windows.Forms.TextBox();
      label1 = new System.Windows.Forms.Label();
      lblDatumACas = new System.Windows.Forms.Label();
      lblVolajici = new System.Windows.Forms.Label();
      lblZapsal = new System.Windows.Forms.Label();
      txtLoginUser = new System.Windows.Forms.TextBox();
      tmCall = new System.Windows.Forms.DateTimePicker();
      tmCallTo = new System.Windows.Forms.DateTimePicker();
      label2 = new System.Windows.Forms.Label();
      cmbFrom = new System.Windows.Forms.ComboBox();
      cmbSex = new System.Windows.Forms.ComboBox();
      label3 = new System.Windows.Forms.Label();
      boxClient = new System.Windows.Forms.GroupBox();
      cmbAge = new System.Windows.Forms.ComboBox();
      label6 = new System.Windows.Forms.Label();
      boxResult = new System.Windows.Forms.GroupBox();
      lblEndOfSpeech = new System.Windows.Forms.Label();
      lblCurrentClientStatus = new System.Windows.Forms.Label();
      lblContactTopic = new System.Windows.Forms.Label();
      lblEndOfSpeech1 = new System.Windows.Forms.Label();
      lblCurrentClientStatus1 = new System.Windows.Forms.Label();
      lblContactTopic1 = new System.Windows.Forms.Label();
      label9 = new System.Windows.Forms.Label();
      tvEndOfSpeech = new System.Windows.Forms.TreeView();
      label8 = new System.Windows.Forms.Label();
      tvClientCurrentStatus = new System.Windows.Forms.TreeView();
      label7 = new System.Windows.Forms.Label();
      tvContactTopic = new System.Windows.Forms.TreeView();
      txtNote = new System.Windows.Forms.TextBox();
      label13 = new System.Windows.Forms.Label();
      btnWrite = new System.Windows.Forms.Button();
      lblTitulek = new System.Windows.Forms.Label();
      btnQuickLPvK = new System.Windows.Forms.Button();
      timer1 = new System.Windows.Forms.Timer(components);
      boxCall.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)pictureClock).BeginInit();
      boxClient.SuspendLayout();
      boxResult.SuspendLayout();
      SuspendLayout();
      // 
      // btnBack
      // 
      btnBack.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      btnBack.Image = (System.Drawing.Image)resources.GetObject("btnBack.Image");
      btnBack.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
      btnBack.Location = new System.Drawing.Point(15, 3);
      btnBack.Name = "btnBack";
      btnBack.Size = new System.Drawing.Size(85, 36);
      btnBack.TabIndex = 0;
      btnBack.Text = "Zpět";
      btnBack.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      btnBack.UseVisualStyleBackColor = true;
      btnBack.Click += btnBack_Click;
      // 
      // boxCall
      // 
      boxCall.Controls.Add(pictureClock);
      boxCall.Controls.Add(dtCall);
      boxCall.Controls.Add(lblEditInfo);
      boxCall.Controls.Add(cmbTypeService);
      boxCall.Controls.Add(label5);
      boxCall.Controls.Add(cmbContactType);
      boxCall.Controls.Add(label4);
      boxCall.Controls.Add(lblCallTimeSum);
      boxCall.Controls.Add(txtVolajici);
      boxCall.Controls.Add(label1);
      boxCall.Controls.Add(lblDatumACas);
      boxCall.Controls.Add(lblVolajici);
      boxCall.Controls.Add(lblZapsal);
      boxCall.Controls.Add(txtLoginUser);
      boxCall.Controls.Add(tmCall);
      boxCall.Controls.Add(tmCallTo);
      boxCall.Location = new System.Drawing.Point(3, 45);
      boxCall.Name = "boxCall";
      boxCall.Size = new System.Drawing.Size(1303, 104);
      boxCall.TabIndex = 24;
      boxCall.TabStop = false;
      boxCall.Text = "Údaje o Hovoru";
      // 
      // pictureClock
      // 
      pictureClock.Image = Properties.Resources.ClockWhite;
      pictureClock.Location = new System.Drawing.Point(510, 23);
      pictureClock.Name = "pictureClock";
      pictureClock.Size = new System.Drawing.Size(48, 48);
      pictureClock.TabIndex = 58;
      pictureClock.TabStop = false;
      pictureClock.Click += pictureClock_Click;
      // 
      // dtCall
      // 
      dtCall.CalendarFont = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      dtCall.CustomFormat = "dd-MM-yyyy";
      dtCall.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      dtCall.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
      dtCall.Location = new System.Drawing.Point(158, 25);
      dtCall.Name = "dtCall";
      dtCall.Size = new System.Drawing.Size(102, 27);
      dtCall.TabIndex = 0;
      // 
      // lblEditInfo
      // 
      lblEditInfo.AutoSize = true;
      lblEditInfo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      lblEditInfo.Location = new System.Drawing.Point(1361, 84);
      lblEditInfo.Name = "lblEditInfo";
      lblEditInfo.Size = new System.Drawing.Size(0, 17);
      lblEditInfo.TabIndex = 57;
      // 
      // cmbTypeService
      // 
      cmbTypeService.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      cmbTypeService.FormattingEnabled = true;
      cmbTypeService.Location = new System.Drawing.Point(715, 67);
      cmbTypeService.Name = "cmbTypeService";
      cmbTypeService.Size = new System.Drawing.Size(176, 28);
      cmbTypeService.TabIndex = 5;
      cmbTypeService.Validating += cmbTypeService_Validating;
      // 
      // label5
      // 
      label5.AutoSize = true;
      label5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      label5.Location = new System.Drawing.Point(592, 68);
      label5.Name = "label5";
      label5.Size = new System.Drawing.Size(68, 17);
      label5.TabIndex = 56;
      label5.Text = "Typ služby";
      // 
      // cmbContactType
      // 
      cmbContactType.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      cmbContactType.FormattingEnabled = true;
      cmbContactType.Location = new System.Drawing.Point(158, 67);
      cmbContactType.Name = "cmbContactType";
      cmbContactType.Size = new System.Drawing.Size(181, 28);
      cmbContactType.TabIndex = 4;
      cmbContactType.Validating += cmbContactType_Validating;
      // 
      // label4
      // 
      label4.AutoSize = true;
      label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      label4.Location = new System.Drawing.Point(6, 67);
      label4.Name = "label4";
      label4.Size = new System.Drawing.Size(81, 17);
      label4.TabIndex = 54;
      label4.Text = "Typ kontaktu";
      // 
      // lblCallTimeSum
      // 
      lblCallTimeSum.AutoSize = true;
      lblCallTimeSum.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      lblCallTimeSum.Location = new System.Drawing.Point(510, 74);
      lblCallTimeSum.Name = "lblCallTimeSum";
      lblCallTimeSum.Size = new System.Drawing.Size(39, 17);
      lblCallTimeSum.TabIndex = 49;
      lblCallTimeSum.Text = "00:00";
      // 
      // txtVolajici
      // 
      txtVolajici.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      txtVolajici.Location = new System.Drawing.Point(715, 27);
      txtVolajici.Name = "txtVolajici";
      txtVolajici.Size = new System.Drawing.Size(176, 27);
      txtVolajici.TabIndex = 3;
      txtVolajici.Leave += txtVolajici_Leave;
      // 
      // label1
      // 
      label1.AutoSize = true;
      label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      label1.Location = new System.Drawing.Point(368, 32);
      label1.Name = "label1";
      label1.Size = new System.Drawing.Size(27, 17);
      label1.TabIndex = 32;
      label1.Text = "do:";
      // 
      // lblDatumACas
      // 
      lblDatumACas.AutoSize = true;
      lblDatumACas.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      lblDatumACas.Location = new System.Drawing.Point(6, 32);
      lblDatumACas.Name = "lblDatumACas";
      lblDatumACas.Size = new System.Drawing.Size(148, 17);
      lblDatumACas.TabIndex = 1;
      lblDatumACas.Text = "Datum a čas hovoru od:";
      // 
      // lblVolajici
      // 
      lblVolajici.AutoSize = true;
      lblVolajici.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      lblVolajici.Location = new System.Drawing.Point(612, 30);
      lblVolajici.Name = "lblVolajici";
      lblVolajici.Size = new System.Drawing.Size(48, 17);
      lblVolajici.TabIndex = 2;
      lblVolajici.Text = "Volající";
      // 
      // lblZapsal
      // 
      lblZapsal.AutoSize = true;
      lblZapsal.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      lblZapsal.Location = new System.Drawing.Point(952, 29);
      lblZapsal.Name = "lblZapsal";
      lblZapsal.Size = new System.Drawing.Size(61, 17);
      lblZapsal.TabIndex = 4;
      lblZapsal.Text = "Zapsal(a)";
      // 
      // txtLoginUser
      // 
      txtLoginUser.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      txtLoginUser.Location = new System.Drawing.Point(1019, 25);
      txtLoginUser.Name = "txtLoginUser";
      txtLoginUser.ReadOnly = true;
      txtLoginUser.Size = new System.Drawing.Size(277, 27);
      txtLoginUser.TabIndex = 30;
      txtLoginUser.TabStop = false;
      // 
      // tmCall
      // 
      tmCall.CustomFormat = "HH:mm:ss";
      tmCall.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      tmCall.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
      tmCall.Location = new System.Drawing.Point(266, 25);
      tmCall.Name = "tmCall";
      tmCall.ShowUpDown = true;
      tmCall.Size = new System.Drawing.Size(88, 27);
      tmCall.TabIndex = 1;
      tmCall.ValueChanged += tmCall_ValueChanged;
      // 
      // tmCallTo
      // 
      tmCallTo.CustomFormat = "HH:mm:ss";
      tmCallTo.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      tmCallTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
      tmCallTo.Location = new System.Drawing.Point(401, 25);
      tmCallTo.Name = "tmCallTo";
      tmCallTo.ShowUpDown = true;
      tmCallTo.Size = new System.Drawing.Size(81, 27);
      tmCallTo.TabIndex = 2;
      tmCallTo.ValueChanged += tmCallTo_ValueChanged;
      // 
      // label2
      // 
      label2.AutoSize = true;
      label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      label2.Location = new System.Drawing.Point(6, 29);
      label2.Name = "label2";
      label2.Size = new System.Drawing.Size(95, 17);
      label2.TabIndex = 50;
      label2.Text = "Odkud je klient";
      // 
      // cmbFrom
      // 
      cmbFrom.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      cmbFrom.FormattingEnabled = true;
      cmbFrom.Location = new System.Drawing.Point(147, 29);
      cmbFrom.Name = "cmbFrom";
      cmbFrom.Size = new System.Drawing.Size(210, 28);
      cmbFrom.TabIndex = 6;
      cmbFrom.Validating += cmbFrom_Validating;
      // 
      // cmbSex
      // 
      cmbSex.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      cmbSex.FormattingEnabled = true;
      cmbSex.Location = new System.Drawing.Point(526, 29);
      cmbSex.Name = "cmbSex";
      cmbSex.Size = new System.Drawing.Size(210, 28);
      cmbSex.TabIndex = 7;
      cmbSex.Validating += cmbSex_Validating;
      // 
      // label3
      // 
      label3.AutoSize = true;
      label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      label3.Location = new System.Drawing.Point(451, 30);
      label3.Name = "label3";
      label3.Size = new System.Drawing.Size(49, 17);
      label3.TabIndex = 52;
      label3.Text = "Pohlaví";
      // 
      // boxClient
      // 
      boxClient.Controls.Add(cmbAge);
      boxClient.Controls.Add(label6);
      boxClient.Controls.Add(cmbFrom);
      boxClient.Controls.Add(cmbSex);
      boxClient.Controls.Add(label3);
      boxClient.Controls.Add(label2);
      boxClient.Location = new System.Drawing.Point(0, 146);
      boxClient.Name = "boxClient";
      boxClient.Size = new System.Drawing.Size(1105, 75);
      boxClient.TabIndex = 54;
      boxClient.TabStop = false;
      boxClient.Text = "Klient";
      // 
      // cmbAge
      // 
      cmbAge.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      cmbAge.FormattingEnabled = true;
      cmbAge.Location = new System.Drawing.Point(876, 28);
      cmbAge.Name = "cmbAge";
      cmbAge.Size = new System.Drawing.Size(210, 28);
      cmbAge.TabIndex = 8;
      cmbAge.Validating += cmbAge_Validating;
      // 
      // label6
      // 
      label6.AutoSize = true;
      label6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      label6.Location = new System.Drawing.Point(811, 29);
      label6.Name = "label6";
      label6.Size = new System.Drawing.Size(28, 17);
      label6.TabIndex = 54;
      label6.Text = "Věk";
      // 
      // boxResult
      // 
      boxResult.Controls.Add(lblEndOfSpeech);
      boxResult.Controls.Add(lblCurrentClientStatus);
      boxResult.Controls.Add(lblContactTopic);
      boxResult.Controls.Add(lblEndOfSpeech1);
      boxResult.Controls.Add(lblCurrentClientStatus1);
      boxResult.Controls.Add(lblContactTopic1);
      boxResult.Controls.Add(label9);
      boxResult.Controls.Add(tvEndOfSpeech);
      boxResult.Controls.Add(label8);
      boxResult.Controls.Add(tvClientCurrentStatus);
      boxResult.Controls.Add(label7);
      boxResult.Controls.Add(tvContactTopic);
      boxResult.Location = new System.Drawing.Point(2, 227);
      boxResult.Name = "boxResult";
      boxResult.Size = new System.Drawing.Size(1103, 478);
      boxResult.TabIndex = 55;
      boxResult.TabStop = false;
      boxResult.Text = "Hodnocení hovoru";
      // 
      // lblEndOfSpeech
      // 
      lblEndOfSpeech.AutoSize = true;
      lblEndOfSpeech.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      lblEndOfSpeech.Location = new System.Drawing.Point(145, 458);
      lblEndOfSpeech.Name = "lblEndOfSpeech";
      lblEndOfSpeech.Size = new System.Drawing.Size(95, 17);
      lblEndOfSpeech.TabIndex = 66;
      lblEndOfSpeech.Text = "Téma kontaktu:";
      // 
      // lblCurrentClientStatus
      // 
      lblCurrentClientStatus.AutoSize = true;
      lblCurrentClientStatus.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      lblCurrentClientStatus.Location = new System.Drawing.Point(145, 430);
      lblCurrentClientStatus.Name = "lblCurrentClientStatus";
      lblCurrentClientStatus.Size = new System.Drawing.Size(95, 17);
      lblCurrentClientStatus.TabIndex = 65;
      lblCurrentClientStatus.Text = "Téma kontaktu:";
      // 
      // lblContactTopic
      // 
      lblContactTopic.AutoSize = true;
      lblContactTopic.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      lblContactTopic.Location = new System.Drawing.Point(145, 402);
      lblContactTopic.Name = "lblContactTopic";
      lblContactTopic.Size = new System.Drawing.Size(95, 17);
      lblContactTopic.TabIndex = 64;
      lblContactTopic.Text = "Téma kontaktu:";
      // 
      // lblEndOfSpeech1
      // 
      lblEndOfSpeech1.AutoSize = true;
      lblEndOfSpeech1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      lblEndOfSpeech1.Location = new System.Drawing.Point(10, 458);
      lblEndOfSpeech1.Name = "lblEndOfSpeech1";
      lblEndOfSpeech1.Size = new System.Drawing.Size(88, 17);
      lblEndOfSpeech1.TabIndex = 63;
      lblEndOfSpeech1.Text = "Závěr hovoru:";
      // 
      // lblCurrentClientStatus1
      // 
      lblCurrentClientStatus1.AutoSize = true;
      lblCurrentClientStatus1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      lblCurrentClientStatus1.Location = new System.Drawing.Point(10, 430);
      lblCurrentClientStatus1.Name = "lblCurrentClientStatus1";
      lblCurrentClientStatus1.Size = new System.Drawing.Size(124, 17);
      lblCurrentClientStatus1.TabIndex = 62;
      lblCurrentClientStatus1.Text = "Aktuální stav klienta:";
      // 
      // lblContactTopic1
      // 
      lblContactTopic1.AutoSize = true;
      lblContactTopic1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      lblContactTopic1.Location = new System.Drawing.Point(10, 402);
      lblContactTopic1.Name = "lblContactTopic1";
      lblContactTopic1.Size = new System.Drawing.Size(95, 17);
      lblContactTopic1.TabIndex = 61;
      lblContactTopic1.Text = "Téma kontaktu:";
      // 
      // label9
      // 
      label9.AutoSize = true;
      label9.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      label9.Location = new System.Drawing.Point(994, 13);
      label9.Name = "label9";
      label9.Size = new System.Drawing.Size(85, 17);
      label9.TabIndex = 60;
      label9.Text = "Závěr hovoru";
      // 
      // tvEndOfSpeech
      // 
      tvEndOfSpeech.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      tvEndOfSpeech.Location = new System.Drawing.Point(729, 33);
      tvEndOfSpeech.Name = "tvEndOfSpeech";
      tvEndOfSpeech.Size = new System.Drawing.Size(350, 360);
      tvEndOfSpeech.TabIndex = 11;
      tvEndOfSpeech.AfterCheck += tvEndOfSpeech_AfterCheck;
      tvEndOfSpeech.DrawNode += tvEndOfSpeech_DrawNode;
      tvEndOfSpeech.Validating += tvEndOfSpeech_Validating;
      // 
      // label8
      // 
      label8.AutoSize = true;
      label8.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      label8.Location = new System.Drawing.Point(598, 13);
      label8.Name = "label8";
      label8.Size = new System.Drawing.Size(121, 17);
      label8.TabIndex = 58;
      label8.Text = "Aktuální stav klienta";
      // 
      // tvClientCurrentStatus
      // 
      tvClientCurrentStatus.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      tvClientCurrentStatus.Location = new System.Drawing.Point(369, 33);
      tvClientCurrentStatus.Name = "tvClientCurrentStatus";
      tvClientCurrentStatus.Size = new System.Drawing.Size(350, 360);
      tvClientCurrentStatus.TabIndex = 10;
      tvClientCurrentStatus.AfterCheck += tvCurrentClientStatus_AfterCheck;
      tvClientCurrentStatus.DrawNode += tvCurrentClientStatus_DrawNode;
      tvClientCurrentStatus.Validating += tvCurrentClientStatus_Validating;
      // 
      // label7
      // 
      label7.AutoSize = true;
      label7.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      label7.Location = new System.Drawing.Point(264, 13);
      label7.Name = "label7";
      label7.Size = new System.Drawing.Size(92, 17);
      label7.TabIndex = 56;
      label7.Text = "Téma kontaktu";
      // 
      // tvContactTopic
      // 
      tvContactTopic.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      tvContactTopic.Location = new System.Drawing.Point(10, 33);
      tvContactTopic.Name = "tvContactTopic";
      tvContactTopic.Size = new System.Drawing.Size(350, 360);
      tvContactTopic.TabIndex = 9;
      tvContactTopic.AfterCheck += tvContactTopic_AfterCheck;
      tvContactTopic.DrawNode += tvContactTopic_DrawNode;
      tvContactTopic.Validating += tvContactTopic_Validating;
      // 
      // txtNote
      // 
      txtNote.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      txtNote.Location = new System.Drawing.Point(1111, 175);
      txtNote.Multiline = true;
      txtNote.Name = "txtNote";
      txtNote.ScrollBars = System.Windows.Forms.ScrollBars.Both;
      txtNote.Size = new System.Drawing.Size(304, 562);
      txtNote.TabIndex = 12;
      // 
      // label13
      // 
      label13.AutoSize = true;
      label13.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      label13.Location = new System.Drawing.Point(1111, 155);
      label13.Name = "label13";
      label13.Size = new System.Drawing.Size(122, 17);
      label13.TabIndex = 56;
      label13.Text = "Poznámka k hovoru";
      // 
      // btnWrite
      // 
      btnWrite.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
      btnWrite.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      btnWrite.Image = Properties.Resources.save_close24;
      btnWrite.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
      btnWrite.Location = new System.Drawing.Point(1323, 87);
      btnWrite.Name = "btnWrite";
      btnWrite.Size = new System.Drawing.Size(95, 39);
      btnWrite.TabIndex = 13;
      btnWrite.Text = "Uložit";
      btnWrite.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      btnWrite.UseVisualStyleBackColor = true;
      btnWrite.Click += btnWrite_Click;
      // 
      // lblTitulek
      // 
      lblTitulek.AutoSize = true;
      lblTitulek.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      lblTitulek.ForeColor = System.Drawing.SystemColors.Highlight;
      lblTitulek.Location = new System.Drawing.Point(269, 5);
      lblTitulek.Name = "lblTitulek";
      lblTitulek.Size = new System.Drawing.Size(88, 32);
      lblTitulek.TabIndex = 57;
      lblTitulek.Text = "Titulek";
      // 
      // btnQuickLPvK
      // 
      btnQuickLPvK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
      btnQuickLPvK.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      btnQuickLPvK.Image = (System.Drawing.Image)resources.GetObject("btnQuickLPvK.Image");
      btnQuickLPvK.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
      btnQuickLPvK.Location = new System.Drawing.Point(1486, 3);
      btnQuickLPvK.Name = "btnQuickLPvK";
      btnQuickLPvK.Size = new System.Drawing.Size(63, 69);
      btnQuickLPvK.TabIndex = 58;
      btnQuickLPvK.Text = "SKI";
      btnQuickLPvK.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
      btnQuickLPvK.UseVisualStyleBackColor = true;
      btnQuickLPvK.Click += btnQuickLPvK_Click;
      // 
      // timer1
      // 
      timer1.Interval = 1000;
      timer1.Tick += timer1_Tick;
      // 
      // ucCallLPK
      // 
      AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
      AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      Controls.Add(btnQuickLPvK);
      Controls.Add(lblTitulek);
      Controls.Add(btnWrite);
      Controls.Add(label13);
      Controls.Add(txtNote);
      Controls.Add(boxResult);
      Controls.Add(boxClient);
      Controls.Add(btnBack);
      Controls.Add(boxCall);
      Name = "ucCallLPK";
      Size = new System.Drawing.Size(1552, 753);
      Load += ucCallLPK_Load;
      VisibleChanged += ucCallLPK_VisibleChanged;
      Resize += ucCallLPK_Resize;
      boxCall.ResumeLayout(false);
      boxCall.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)pictureClock).EndInit();
      boxClient.ResumeLayout(false);
      boxClient.PerformLayout();
      boxResult.ResumeLayout(false);
      boxResult.PerformLayout();
      ResumeLayout(false);
      PerformLayout();
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
    private System.Windows.Forms.Label lblEndOfSpeech1;
    private System.Windows.Forms.Label lblCurrentClientStatus1;
    private System.Windows.Forms.Label lblContactTopic1;
    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.TreeView tvEndOfSpeech;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.TreeView tvClientCurrentStatus;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.TreeView tvContactTopic;
    private System.Windows.Forms.TextBox txtNote;
    private System.Windows.Forms.Label label13;
    private System.Windows.Forms.Label lblEditInfo;
    private System.Windows.Forms.Label lblTitulek;
    private System.Windows.Forms.Button btnQuickLPvK;
    private System.Windows.Forms.PictureBox pictureClock;
    private System.Windows.Forms.Timer timer1;
  }
}
