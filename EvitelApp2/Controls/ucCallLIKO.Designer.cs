
namespace EvitelApp2.Controls
{
  partial class ucCallLIKO
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucCallLIKO));
      dtCall = new System.Windows.Forms.DateTimePicker();
      lblDatumACas = new System.Windows.Forms.Label();
      lblVolajici = new System.Windows.Forms.Label();
      lblZapsal = new System.Windows.Forms.Label();
      txtLoginUser = new System.Windows.Forms.TextBox();
      cmbIntervent = new System.Windows.Forms.ComboBox();
      tmCall = new System.Windows.Forms.DateTimePicker();
      btnWrite = new System.Windows.Forms.Button();
      tmIncident = new System.Windows.Forms.DateTimePicker();
      lblUdalost = new System.Windows.Forms.Label();
      dtIncident = new System.Windows.Forms.DateTimePicker();
      cmbSubTypeIncident = new System.Windows.Forms.ComboBox();
      lblDruhUdalosti = new System.Windows.Forms.Label();
      txtEventNote = new System.Windows.Forms.TextBox();
      lblNoteEvent = new System.Windows.Forms.Label();
      lblPocetPoskozenychObeti = new System.Windows.Forms.Label();
      cmbRegion = new System.Windows.Forms.ComboBox();
      lblRegion = new System.Windows.Forms.Label();
      boxCall = new System.Windows.Forms.GroupBox();
      boxEvent = new System.Windows.Forms.GroupBox();
      txtSupposedId = new System.Windows.Forms.TextBox();
      lblSupposeId = new System.Windows.Forms.Label();
      txtPocetObeti = new System.Windows.Forms.NumericUpDown();
      txtPlace = new System.Windows.Forms.TextBox();
      lblPlace = new System.Windows.Forms.Label();
      lblregion1 = new System.Windows.Forms.Label();
      boxIntervence = new System.Windows.Forms.GroupBox();
      lblIntervenceSum = new System.Windows.Forms.Label();
      label7 = new System.Windows.Forms.Label();
      txtSecondIncidentID = new System.Windows.Forms.NumericUpDown();
      btnDruhaIntervence = new System.Windows.Forms.Button();
      chkSecondIntervence = new System.Windows.Forms.CheckBox();
      label6 = new System.Windows.Forms.Label();
      dtIntervenceEnd = new System.Windows.Forms.DateTimePicker();
      tmIntervenceEnd = new System.Windows.Forms.DateTimePicker();
      label5 = new System.Windows.Forms.Label();
      txtNrCelkem = new System.Windows.Forms.NumericUpDown();
      txtNrOstatnimOsobam = new System.Windows.Forms.NumericUpDown();
      label4 = new System.Windows.Forms.Label();
      label3 = new System.Windows.Forms.Label();
      txtNrPozustalymBlizkym = new System.Windows.Forms.NumericUpDown();
      lbl88 = new System.Windows.Forms.Label();
      txtNrObetemPoskozenym = new System.Windows.Forms.NumericUpDown();
      label2 = new System.Windows.Forms.Label();
      lblIntervenceNote = new System.Windows.Forms.Label();
      txtIntervenceNote = new System.Windows.Forms.TextBox();
      dtIntervence = new System.Windows.Forms.DateTimePicker();
      label1 = new System.Windows.Forms.Label();
      tmIntervence = new System.Windows.Forms.DateTimePicker();
      ucParticipations1 = new ucParticipations();
      btnBack = new System.Windows.Forms.Button();
      lblTitulek = new System.Windows.Forms.Label();
      btnQuickLPvK = new System.Windows.Forms.Button();
      btnDelete = new System.Windows.Forms.Button();
      boxCall.SuspendLayout();
      boxEvent.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)txtPocetObeti).BeginInit();
      boxIntervence.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)txtSecondIncidentID).BeginInit();
      ((System.ComponentModel.ISupportInitialize)txtNrCelkem).BeginInit();
      ((System.ComponentModel.ISupportInitialize)txtNrOstatnimOsobam).BeginInit();
      ((System.ComponentModel.ISupportInitialize)txtNrPozustalymBlizkym).BeginInit();
      ((System.ComponentModel.ISupportInitialize)txtNrObetemPoskozenym).BeginInit();
      SuspendLayout();
      // 
      // dtCall
      // 
      dtCall.CalendarFont = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      dtCall.CustomFormat = "dd-MM-yyyy";
      dtCall.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      dtCall.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
      dtCall.Location = new System.Drawing.Point(158, 22);
      dtCall.Name = "dtCall";
      dtCall.Size = new System.Drawing.Size(102, 27);
      dtCall.TabIndex = 0;
      // 
      // lblDatumACas
      // 
      lblDatumACas.AutoSize = true;
      lblDatumACas.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      lblDatumACas.Location = new System.Drawing.Point(2, 28);
      lblDatumACas.Name = "lblDatumACas";
      lblDatumACas.Size = new System.Drawing.Size(125, 17);
      lblDatumACas.TabIndex = 1;
      lblDatumACas.Text = "Datum a čas hovoru";
      // 
      // lblVolajici
      // 
      lblVolajici.AutoSize = true;
      lblVolajici.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      lblVolajici.Location = new System.Drawing.Point(426, 29);
      lblVolajici.Name = "lblVolajici";
      lblVolajici.Size = new System.Drawing.Size(48, 17);
      lblVolajici.TabIndex = 2;
      lblVolajici.Text = "Volající";
      // 
      // lblZapsal
      // 
      lblZapsal.AutoSize = true;
      lblZapsal.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      lblZapsal.Location = new System.Drawing.Point(810, 30);
      lblZapsal.Name = "lblZapsal";
      lblZapsal.Size = new System.Drawing.Size(61, 17);
      lblZapsal.TabIndex = 4;
      lblZapsal.Text = "Zapsal(a)";
      // 
      // txtLoginUser
      // 
      txtLoginUser.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      txtLoginUser.Location = new System.Drawing.Point(899, 24);
      txtLoginUser.Name = "txtLoginUser";
      txtLoginUser.ReadOnly = true;
      txtLoginUser.Size = new System.Drawing.Size(240, 27);
      txtLoginUser.TabIndex = 7;
      // 
      // cmbIntervent
      // 
      cmbIntervent.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      cmbIntervent.FormattingEnabled = true;
      cmbIntervent.Location = new System.Drawing.Point(503, 23);
      cmbIntervent.Name = "cmbIntervent";
      cmbIntervent.Size = new System.Drawing.Size(247, 28);
      cmbIntervent.TabIndex = 8;
      cmbIntervent.Validating += cmbIntervent_Validating;
      // 
      // tmCall
      // 
      tmCall.CustomFormat = "HH:mm";
      tmCall.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      tmCall.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
      tmCall.Location = new System.Drawing.Point(266, 22);
      tmCall.Name = "tmCall";
      tmCall.ShowUpDown = true;
      tmCall.Size = new System.Drawing.Size(73, 27);
      tmCall.TabIndex = 9;
      // 
      // btnWrite
      // 
      btnWrite.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
      btnWrite.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      btnWrite.Image = Properties.Resources.save_close24;
      btnWrite.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
      btnWrite.Location = new System.Drawing.Point(1167, 17);
      btnWrite.Name = "btnWrite";
      btnWrite.Size = new System.Drawing.Size(95, 39);
      btnWrite.TabIndex = 10;
      btnWrite.Text = "Uložit";
      btnWrite.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      btnWrite.UseVisualStyleBackColor = true;
      btnWrite.Click += btnWrite_Click;
      // 
      // tmIncident
      // 
      tmIncident.CustomFormat = "HH:mm";
      tmIncident.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      tmIncident.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
      tmIncident.Location = new System.Drawing.Point(266, 17);
      tmIncident.Name = "tmIncident";
      tmIncident.ShowUpDown = true;
      tmIncident.Size = new System.Drawing.Size(73, 27);
      tmIncident.TabIndex = 13;
      // 
      // lblUdalost
      // 
      lblUdalost.AutoSize = true;
      lblUdalost.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      lblUdalost.Location = new System.Drawing.Point(7, 23);
      lblUdalost.Name = "lblUdalost";
      lblUdalost.Size = new System.Drawing.Size(130, 17);
      lblUdalost.TabIndex = 12;
      lblUdalost.Text = "Datum a čas události";
      // 
      // dtIncident
      // 
      dtIncident.CustomFormat = "dd-MM-yyyy";
      dtIncident.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      dtIncident.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
      dtIncident.Location = new System.Drawing.Point(158, 17);
      dtIncident.Name = "dtIncident";
      dtIncident.Size = new System.Drawing.Size(102, 27);
      dtIncident.TabIndex = 11;
      // 
      // cmbSubTypeIncident
      // 
      cmbSubTypeIncident.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      cmbSubTypeIncident.FormattingEnabled = true;
      cmbSubTypeIncident.Location = new System.Drawing.Point(158, 56);
      cmbSubTypeIncident.Name = "cmbSubTypeIncident";
      cmbSubTypeIncident.Size = new System.Drawing.Size(262, 28);
      cmbSubTypeIncident.TabIndex = 15;
      cmbSubTypeIncident.Validating += cmbSubTypeIncident_Validating;
      // 
      // lblDruhUdalosti
      // 
      lblDruhUdalosti.AutoSize = true;
      lblDruhUdalosti.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      lblDruhUdalosti.Location = new System.Drawing.Point(7, 60);
      lblDruhUdalosti.Name = "lblDruhUdalosti";
      lblDruhUdalosti.Size = new System.Drawing.Size(86, 17);
      lblDruhUdalosti.TabIndex = 14;
      lblDruhUdalosti.Text = "Druh události";
      // 
      // txtEventNote
      // 
      txtEventNote.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      txtEventNote.Location = new System.Drawing.Point(765, 31);
      txtEventNote.Multiline = true;
      txtEventNote.Name = "txtEventNote";
      txtEventNote.ScrollBars = System.Windows.Forms.ScrollBars.Both;
      txtEventNote.Size = new System.Drawing.Size(509, 118);
      txtEventNote.TabIndex = 16;
      // 
      // lblNoteEvent
      // 
      lblNoteEvent.AutoSize = true;
      lblNoteEvent.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      lblNoteEvent.Location = new System.Drawing.Point(1147, 11);
      lblNoteEvent.Name = "lblNoteEvent";
      lblNoteEvent.Size = new System.Drawing.Size(127, 17);
      lblNoteEvent.TabIndex = 17;
      lblNoteEvent.Text = "Poznámka k události";
      // 
      // lblPocetPoskozenychObeti
      // 
      lblPocetPoskozenychObeti.AutoSize = true;
      lblPocetPoskozenychObeti.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      lblPocetPoskozenychObeti.Location = new System.Drawing.Point(6, 89);
      lblPocetPoskozenychObeti.Name = "lblPocetPoskozenychObeti";
      lblPocetPoskozenychObeti.Size = new System.Drawing.Size(154, 17);
      lblPocetPoskozenychObeti.TabIndex = 18;
      lblPocetPoskozenychObeti.Text = "Počet poškozených/obětí";
      // 
      // cmbRegion
      // 
      cmbRegion.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      cmbRegion.FormattingEnabled = true;
      cmbRegion.Location = new System.Drawing.Point(503, 15);
      cmbRegion.Name = "cmbRegion";
      cmbRegion.Size = new System.Drawing.Size(247, 28);
      cmbRegion.TabIndex = 21;
      cmbRegion.Validating += cmbRegion_Validating;
      // 
      // lblRegion
      // 
      lblRegion.AutoSize = true;
      lblRegion.Location = new System.Drawing.Point(372, 74);
      lblRegion.Name = "lblRegion";
      lblRegion.Size = new System.Drawing.Size(27, 15);
      lblRegion.TabIndex = 20;
      lblRegion.Text = "Kraj";
      // 
      // boxCall
      // 
      boxCall.Controls.Add(btnWrite);
      boxCall.Controls.Add(dtCall);
      boxCall.Controls.Add(lblDatumACas);
      boxCall.Controls.Add(lblVolajici);
      boxCall.Controls.Add(lblZapsal);
      boxCall.Controls.Add(txtLoginUser);
      boxCall.Controls.Add(cmbIntervent);
      boxCall.Controls.Add(tmCall);
      boxCall.Location = new System.Drawing.Point(3, 36);
      boxCall.Name = "boxCall";
      boxCall.Size = new System.Drawing.Size(1280, 66);
      boxCall.TabIndex = 22;
      boxCall.TabStop = false;
      boxCall.Text = "Údaje o Hovoru";
      // 
      // boxEvent
      // 
      boxEvent.Controls.Add(txtSupposedId);
      boxEvent.Controls.Add(lblSupposeId);
      boxEvent.Controls.Add(txtPocetObeti);
      boxEvent.Controls.Add(txtPlace);
      boxEvent.Controls.Add(lblPlace);
      boxEvent.Controls.Add(lblregion1);
      boxEvent.Controls.Add(lblNoteEvent);
      boxEvent.Controls.Add(dtIncident);
      boxEvent.Controls.Add(cmbRegion);
      boxEvent.Controls.Add(lblUdalost);
      boxEvent.Controls.Add(tmIncident);
      boxEvent.Controls.Add(lblDruhUdalosti);
      boxEvent.Controls.Add(lblPocetPoskozenychObeti);
      boxEvent.Controls.Add(cmbSubTypeIncident);
      boxEvent.Controls.Add(txtEventNote);
      boxEvent.Location = new System.Drawing.Point(3, 108);
      boxEvent.Name = "boxEvent";
      boxEvent.Size = new System.Drawing.Size(1280, 155);
      boxEvent.TabIndex = 23;
      boxEvent.TabStop = false;
      boxEvent.Text = "Údaje o události";
      // 
      // txtSupposedId
      // 
      txtSupposedId.Enabled = false;
      txtSupposedId.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      txtSupposedId.Location = new System.Drawing.Point(335, 117);
      txtSupposedId.Name = "txtSupposedId";
      txtSupposedId.Size = new System.Drawing.Size(85, 27);
      txtSupposedId.TabIndex = 29;
      // 
      // lblSupposeId
      // 
      lblSupposeId.AutoSize = true;
      lblSupposeId.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      lblSupposeId.Location = new System.Drawing.Point(7, 122);
      lblSupposeId.Name = "lblSupposeId";
      lblSupposeId.Size = new System.Drawing.Size(162, 17);
      lblSupposeId.TabIndex = 28;
      lblSupposeId.Text = "Předpokládané ID události";
      // 
      // txtPocetObeti
      // 
      txtPocetObeti.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      txtPocetObeti.Location = new System.Drawing.Point(335, 86);
      txtPocetObeti.Name = "txtPocetObeti";
      txtPocetObeti.Size = new System.Drawing.Size(85, 27);
      txtPocetObeti.TabIndex = 24;
      // 
      // txtPlace
      // 
      txtPlace.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      txtPlace.Location = new System.Drawing.Point(503, 45);
      txtPlace.Name = "txtPlace";
      txtPlace.Size = new System.Drawing.Size(247, 27);
      txtPlace.TabIndex = 23;
      txtPlace.Validating += txtPlace_Validating;
      // 
      // lblPlace
      // 
      lblPlace.AutoSize = true;
      lblPlace.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      lblPlace.Location = new System.Drawing.Point(426, 52);
      lblPlace.Name = "lblPlace";
      lblPlace.Size = new System.Drawing.Size(77, 17);
      lblPlace.TabIndex = 22;
      lblPlace.Text = "Místo/Obec";
      // 
      // lblregion1
      // 
      lblregion1.AutoSize = true;
      lblregion1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      lblregion1.Location = new System.Drawing.Point(426, 23);
      lblregion1.Name = "lblregion1";
      lblregion1.Size = new System.Drawing.Size(31, 17);
      lblregion1.TabIndex = 11;
      lblregion1.Text = "Kraj";
      // 
      // boxIntervence
      // 
      boxIntervence.Controls.Add(lblIntervenceSum);
      boxIntervence.Controls.Add(label7);
      boxIntervence.Controls.Add(txtSecondIncidentID);
      boxIntervence.Controls.Add(btnDruhaIntervence);
      boxIntervence.Controls.Add(chkSecondIntervence);
      boxIntervence.Controls.Add(label6);
      boxIntervence.Controls.Add(dtIntervenceEnd);
      boxIntervence.Controls.Add(tmIntervenceEnd);
      boxIntervence.Controls.Add(label5);
      boxIntervence.Controls.Add(txtNrCelkem);
      boxIntervence.Controls.Add(txtNrOstatnimOsobam);
      boxIntervence.Controls.Add(label4);
      boxIntervence.Controls.Add(label3);
      boxIntervence.Controls.Add(txtNrPozustalymBlizkym);
      boxIntervence.Controls.Add(lbl88);
      boxIntervence.Controls.Add(txtNrObetemPoskozenym);
      boxIntervence.Controls.Add(label2);
      boxIntervence.Controls.Add(lblIntervenceNote);
      boxIntervence.Controls.Add(txtIntervenceNote);
      boxIntervence.Controls.Add(dtIntervence);
      boxIntervence.Controls.Add(label1);
      boxIntervence.Controls.Add(tmIntervence);
      boxIntervence.Location = new System.Drawing.Point(3, 269);
      boxIntervence.Name = "boxIntervence";
      boxIntervence.Size = new System.Drawing.Size(1280, 169);
      boxIntervence.TabIndex = 24;
      boxIntervence.TabStop = false;
      boxIntervence.Text = "Základní údaje o intervenci";
      boxIntervence.Enter += boxIntervence_Enter;
      // 
      // lblIntervenceSum
      // 
      lblIntervenceSum.AutoSize = true;
      lblIntervenceSum.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      lblIntervenceSum.Location = new System.Drawing.Point(309, 95);
      lblIntervenceSum.Name = "lblIntervenceSum";
      lblIntervenceSum.Size = new System.Drawing.Size(39, 17);
      lblIntervenceSum.TabIndex = 48;
      lblIntervenceSum.Text = "00:00";
      // 
      // label7
      // 
      label7.AutoSize = true;
      label7.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      label7.Location = new System.Drawing.Point(154, 95);
      label7.Name = "label7";
      label7.Size = new System.Drawing.Size(48, 17);
      label7.TabIndex = 47;
      label7.Text = "celkem";
      // 
      // txtSecondIncidentID
      // 
      txtSecondIncidentID.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      txtSecondIncidentID.Location = new System.Drawing.Point(203, 127);
      txtSecondIncidentID.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
      txtSecondIncidentID.Name = "txtSecondIncidentID";
      txtSecondIncidentID.Size = new System.Drawing.Size(61, 27);
      txtSecondIncidentID.TabIndex = 45;
      // 
      // btnDruhaIntervence
      // 
      btnDruhaIntervence.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
      btnDruhaIntervence.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      btnDruhaIntervence.Location = new System.Drawing.Point(274, 127);
      btnDruhaIntervence.Name = "btnDruhaIntervence";
      btnDruhaIntervence.Size = new System.Drawing.Size(95, 27);
      btnDruhaIntervence.TabIndex = 11;
      btnDruhaIntervence.Text = "Vyber událost";
      btnDruhaIntervence.UseVisualStyleBackColor = true;
      btnDruhaIntervence.Click += btnDruhaIntervence_Click;
      // 
      // chkSecondIntervence
      // 
      chkSecondIntervence.AutoSize = true;
      chkSecondIntervence.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      chkSecondIntervence.Location = new System.Drawing.Point(7, 131);
      chkSecondIntervence.Name = "chkSecondIntervence";
      chkSecondIntervence.Size = new System.Drawing.Size(190, 21);
      chkSecondIntervence.TabIndex = 30;
      chkSecondIntervence.Text = "Druhá nebo další intervence";
      chkSecondIntervence.UseVisualStyleBackColor = true;
      chkSecondIntervence.CheckedChanged += chkSecondIntervence_CheckedChanged;
      // 
      // label6
      // 
      label6.AutoSize = true;
      label6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      label6.Location = new System.Drawing.Point(153, 62);
      label6.Name = "label6";
      label6.Size = new System.Drawing.Size(24, 17);
      label6.TabIndex = 44;
      label6.Text = "do\r\n";
      // 
      // dtIntervenceEnd
      // 
      dtIntervenceEnd.CustomFormat = "dd-MM-yyyy";
      dtIntervenceEnd.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      dtIntervenceEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
      dtIntervenceEnd.Location = new System.Drawing.Point(199, 55);
      dtIntervenceEnd.Name = "dtIntervenceEnd";
      dtIntervenceEnd.Size = new System.Drawing.Size(97, 27);
      dtIntervenceEnd.TabIndex = 43;
      dtIntervenceEnd.ValueChanged += dtIntervenceEnd_ValueChanged;
      // 
      // tmIntervenceEnd
      // 
      tmIntervenceEnd.CustomFormat = "HH:mm";
      tmIntervenceEnd.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      tmIntervenceEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
      tmIntervenceEnd.Location = new System.Drawing.Point(308, 55);
      tmIntervenceEnd.Name = "tmIntervenceEnd";
      tmIntervenceEnd.ShowUpDown = true;
      tmIntervenceEnd.Size = new System.Drawing.Size(61, 27);
      tmIntervenceEnd.TabIndex = 42;
      tmIntervenceEnd.ValueChanged += tmIntervenceEnd_ValueChanged;
      // 
      // label5
      // 
      label5.AutoSize = true;
      label5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      label5.Location = new System.Drawing.Point(477, 135);
      label5.Name = "label5";
      label5.Size = new System.Drawing.Size(56, 17);
      label5.TabIndex = 41;
      label5.Text = "CELKEM";
      // 
      // txtNrCelkem
      // 
      txtNrCelkem.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      txtNrCelkem.Location = new System.Drawing.Point(665, 131);
      txtNrCelkem.Name = "txtNrCelkem";
      txtNrCelkem.Size = new System.Drawing.Size(85, 27);
      txtNrCelkem.TabIndex = 40;
      // 
      // txtNrOstatnimOsobam
      // 
      txtNrOstatnimOsobam.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      txtNrOstatnimOsobam.Location = new System.Drawing.Point(665, 98);
      txtNrOstatnimOsobam.Name = "txtNrOstatnimOsobam";
      txtNrOstatnimOsobam.Size = new System.Drawing.Size(85, 27);
      txtNrOstatnimOsobam.TabIndex = 39;
      // 
      // label4
      // 
      label4.AutoSize = true;
      label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      label4.Location = new System.Drawing.Point(477, 102);
      label4.Name = "label4";
      label4.Size = new System.Drawing.Size(128, 17);
      label4.TabIndex = 38;
      label4.Text = "OSTATNÍM OSOBÁM";
      // 
      // label3
      // 
      label3.AutoSize = true;
      label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      label3.Location = new System.Drawing.Point(477, 70);
      label3.Name = "label3";
      label3.Size = new System.Drawing.Size(141, 17);
      label3.TabIndex = 37;
      label3.Text = "POZŮSTALÝM/BLÍZKÝM";
      // 
      // txtNrPozustalymBlizkym
      // 
      txtNrPozustalymBlizkym.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      txtNrPozustalymBlizkym.Location = new System.Drawing.Point(665, 66);
      txtNrPozustalymBlizkym.Name = "txtNrPozustalymBlizkym";
      txtNrPozustalymBlizkym.Size = new System.Drawing.Size(85, 27);
      txtNrPozustalymBlizkym.TabIndex = 36;
      // 
      // lbl88
      // 
      lbl88.AutoSize = true;
      lbl88.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      lbl88.Location = new System.Drawing.Point(477, 37);
      lbl88.Name = "lbl88";
      lbl88.Size = new System.Drawing.Size(147, 17);
      lbl88.TabIndex = 35;
      lbl88.Text = "OBĚTEM/POŠKOZENÝM";
      // 
      // txtNrObetemPoskozenym
      // 
      txtNrObetemPoskozenym.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      txtNrObetemPoskozenym.Location = new System.Drawing.Point(665, 32);
      txtNrObetemPoskozenym.Name = "txtNrObetemPoskozenym";
      txtNrObetemPoskozenym.Size = new System.Drawing.Size(85, 27);
      txtNrObetemPoskozenym.TabIndex = 34;
      // 
      // label2
      // 
      label2.AutoSize = true;
      label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      label2.Location = new System.Drawing.Point(469, 12);
      label2.Name = "label2";
      label2.Size = new System.Drawing.Size(281, 17);
      label2.TabIndex = 33;
      label2.Text = "Počet osob, kterým byla poskytnuta intervence:";
      // 
      // lblIntervenceNote
      // 
      lblIntervenceNote.AutoSize = true;
      lblIntervenceNote.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      lblIntervenceNote.Location = new System.Drawing.Point(1138, 12);
      lblIntervenceNote.Name = "lblIntervenceNote";
      lblIntervenceNote.Size = new System.Drawing.Size(136, 17);
      lblIntervenceNote.TabIndex = 32;
      lblIntervenceNote.Text = "Poznámka k intervenci";
      // 
      // txtIntervenceNote
      // 
      txtIntervenceNote.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      txtIntervenceNote.Location = new System.Drawing.Point(765, 32);
      txtIntervenceNote.Multiline = true;
      txtIntervenceNote.Name = "txtIntervenceNote";
      txtIntervenceNote.ScrollBars = System.Windows.Forms.ScrollBars.Both;
      txtIntervenceNote.Size = new System.Drawing.Size(509, 120);
      txtIntervenceNote.TabIndex = 31;
      // 
      // dtIntervence
      // 
      dtIntervence.CustomFormat = "dd-MM-yyyy";
      dtIntervence.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      dtIntervence.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
      dtIntervence.Location = new System.Drawing.Point(199, 22);
      dtIntervence.Name = "dtIntervence";
      dtIntervence.Size = new System.Drawing.Size(97, 27);
      dtIntervence.TabIndex = 28;
      dtIntervence.ValueChanged += dtIntervence_ValueChanged;
      // 
      // label1
      // 
      label1.AutoSize = true;
      label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      label1.Location = new System.Drawing.Point(7, 28);
      label1.Name = "label1";
      label1.Size = new System.Drawing.Size(170, 17);
      label1.TabIndex = 29;
      label1.Text = "Datum a čas intervence  od:";
      // 
      // tmIntervence
      // 
      tmIntervence.CustomFormat = "HH:mm";
      tmIntervence.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      tmIntervence.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
      tmIntervence.Location = new System.Drawing.Point(309, 22);
      tmIntervence.Name = "tmIntervence";
      tmIntervence.ShowUpDown = true;
      tmIntervence.Size = new System.Drawing.Size(60, 27);
      tmIntervence.TabIndex = 30;
      tmIntervence.ValueChanged += tmIntervence_ValueChanged;
      // 
      // ucParticipations1
      // 
      ucParticipations1.Location = new System.Drawing.Point(0, 433);
      ucParticipations1.Name = "ucParticipations1";
      ucParticipations1.Size = new System.Drawing.Size(1141, 375);
      ucParticipations1.TabIndex = 25;
      // 
      // btnBack
      // 
      btnBack.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      btnBack.Image = (System.Drawing.Image)resources.GetObject("btnBack.Image");
      btnBack.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
      btnBack.Location = new System.Drawing.Point(9, 5);
      btnBack.Name = "btnBack";
      btnBack.Size = new System.Drawing.Size(86, 39);
      btnBack.TabIndex = 11;
      btnBack.Text = "Zpět";
      btnBack.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      btnBack.UseVisualStyleBackColor = true;
      btnBack.Click += btnBack_Click;
      // 
      // lblTitulek
      // 
      lblTitulek.AutoSize = true;
      lblTitulek.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      lblTitulek.ForeColor = System.Drawing.SystemColors.Highlight;
      lblTitulek.Location = new System.Drawing.Point(269, 5);
      lblTitulek.Name = "lblTitulek";
      lblTitulek.Size = new System.Drawing.Size(88, 32);
      lblTitulek.TabIndex = 26;
      lblTitulek.Text = "Titulek";
      // 
      // btnQuickLPvK
      // 
      btnQuickLPvK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
      btnQuickLPvK.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      btnQuickLPvK.Image = (System.Drawing.Image)resources.GetObject("btnQuickLPvK.Image");
      btnQuickLPvK.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
      btnQuickLPvK.Location = new System.Drawing.Point(1320, 0);
      btnQuickLPvK.Name = "btnQuickLPvK";
      btnQuickLPvK.Size = new System.Drawing.Size(63, 69);
      btnQuickLPvK.TabIndex = 11;
      btnQuickLPvK.Text = "LPvK";
      btnQuickLPvK.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
      btnQuickLPvK.UseVisualStyleBackColor = true;
      btnQuickLPvK.Click += btnQuickLPvK_Click;
      // 
      // btnDelete
      // 
      btnDelete.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      btnDelete.Image = (System.Drawing.Image)resources.GetObject("btnDelete.Image");
      btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
      btnDelete.Location = new System.Drawing.Point(1204, 652);
      btnDelete.Name = "btnDelete";
      btnDelete.Size = new System.Drawing.Size(92, 47);
      btnDelete.TabIndex = 60;
      btnDelete.Text = "Delete";
      btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      btnDelete.UseVisualStyleBackColor = true;
      btnDelete.Click += btnDelete_Click;
      // 
      // ucCallLIKO
      // 
      AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
      AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      Controls.Add(btnDelete);
      Controls.Add(btnQuickLPvK);
      Controls.Add(lblTitulek);
      Controls.Add(btnBack);
      Controls.Add(ucParticipations1);
      Controls.Add(boxIntervence);
      Controls.Add(boxEvent);
      Controls.Add(boxCall);
      Controls.Add(lblRegion);
      Name = "ucCallLIKO";
      Size = new System.Drawing.Size(1308, 702);
      Load += ucCallLIKO_Load;
      VisibleChanged += ucCallLIKO_VisibleChanged;
      Resize += ucCallLIKO_Resize;
      boxCall.ResumeLayout(false);
      boxCall.PerformLayout();
      boxEvent.ResumeLayout(false);
      boxEvent.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)txtPocetObeti).EndInit();
      boxIntervence.ResumeLayout(false);
      boxIntervence.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)txtSecondIncidentID).EndInit();
      ((System.ComponentModel.ISupportInitialize)txtNrCelkem).EndInit();
      ((System.ComponentModel.ISupportInitialize)txtNrOstatnimOsobam).EndInit();
      ((System.ComponentModel.ISupportInitialize)txtNrPozustalymBlizkym).EndInit();
      ((System.ComponentModel.ISupportInitialize)txtNrObetemPoskozenym).EndInit();
      ResumeLayout(false);
      PerformLayout();
    }

    #endregion

    private System.Windows.Forms.DateTimePicker dtCall;
    private System.Windows.Forms.Label lblDatumACas;
    private System.Windows.Forms.Label lblVolajici;
    private System.Windows.Forms.Label lblZapsal;
    private System.Windows.Forms.TextBox txtLoginUser;
    private System.Windows.Forms.ComboBox cmbIntervent;
    private System.Windows.Forms.DateTimePicker tmCall;
    private System.Windows.Forms.Button btnWrite;
    private System.Windows.Forms.DateTimePicker tmIncident;
    private System.Windows.Forms.Label lblUdalost;
    private System.Windows.Forms.DateTimePicker dtIncident;
    private System.Windows.Forms.Label lblDruhUdalosti;
    private System.Windows.Forms.TextBox txtEventNote;
    private System.Windows.Forms.Label lblNoteEvent;
    private System.Windows.Forms.Label lblPocetPoskozenychObeti;
    private System.Windows.Forms.ComboBox cmbSubTypeIncident;
    private System.Windows.Forms.Label lblRegion;
    private System.Windows.Forms.GroupBox boxCall;
    private System.Windows.Forms.GroupBox boxEvent;
    private System.Windows.Forms.TextBox txtPlace;
    private System.Windows.Forms.Label lblPlace;
    private System.Windows.Forms.Label lblregion1;
    private System.Windows.Forms.NumericUpDown txtPocetObeti;
    private System.Windows.Forms.GroupBox boxIntervence;
    private System.Windows.Forms.Label lblIntervenceNote;
    private System.Windows.Forms.TextBox txtIntervenceNote;
    private System.Windows.Forms.DateTimePicker dtIntervence;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.DateTimePicker tmIntervence;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.NumericUpDown txtNrCelkem;
    private System.Windows.Forms.NumericUpDown txtNrOstatnimOsobam;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.NumericUpDown txtNrPozustalymBlizkym;
    private System.Windows.Forms.Label lbl88;
    private System.Windows.Forms.NumericUpDown txtNrObetemPoskozenym;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.ComboBox cmbRegion;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.DateTimePicker dtIntervenceEnd;
    private System.Windows.Forms.DateTimePicker tmIntervenceEnd;
    private ucParticipations ucParticipations1;
    private System.Windows.Forms.Button btnBack;
    private System.Windows.Forms.TextBox txtSupposedId;
    private System.Windows.Forms.Label lblSupposeId;
    private System.Windows.Forms.CheckBox chkSecondIntervence;
    private System.Windows.Forms.Button btnDruhaIntervence;
    private System.Windows.Forms.NumericUpDown txtSecondIncidentID;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.Label lblIntervenceSum;
    private System.Windows.Forms.Label lblTitulek;
    private System.Windows.Forms.Button btnQuickLPvK;
    private System.Windows.Forms.Button btnDelete;
  }

}
