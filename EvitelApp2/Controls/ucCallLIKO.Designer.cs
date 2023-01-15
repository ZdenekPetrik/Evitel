
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
            this.dtCall = new System.Windows.Forms.DateTimePicker();
            this.lblDatumACas = new System.Windows.Forms.Label();
            this.lblVolajici = new System.Windows.Forms.Label();
            this.lblZapsal = new System.Windows.Forms.Label();
            this.txtLoginUser = new System.Windows.Forms.TextBox();
            this.cmbIntervent = new System.Windows.Forms.ComboBox();
            this.tmCall = new System.Windows.Forms.DateTimePicker();
            this.btnWrite = new System.Windows.Forms.Button();
            this.tmIncident = new System.Windows.Forms.DateTimePicker();
            this.lblUdalost = new System.Windows.Forms.Label();
            this.dtIncident = new System.Windows.Forms.DateTimePicker();
            this.cmbSubTypeIncident = new System.Windows.Forms.ComboBox();
            this.lblDruhUdalosti = new System.Windows.Forms.Label();
            this.txtEventNote = new System.Windows.Forms.TextBox();
            this.lblNoteEvent = new System.Windows.Forms.Label();
            this.lblPocetPoskozenychObeti = new System.Windows.Forms.Label();
            this.cmbRegion = new System.Windows.Forms.ComboBox();
            this.lblRegion = new System.Windows.Forms.Label();
            this.boxCall = new System.Windows.Forms.GroupBox();
            this.boxEvent = new System.Windows.Forms.GroupBox();
            this.txtSupposedId = new System.Windows.Forms.TextBox();
            this.lblSupposeId = new System.Windows.Forms.Label();
            this.chkPokusPriprava = new System.Windows.Forms.CheckBox();
            this.chkDokonane = new System.Windows.Forms.CheckBox();
            this.chkNasledekSmrti = new System.Windows.Forms.CheckBox();
            this.txtPocetObeti = new System.Windows.Forms.NumericUpDown();
            this.txtPlace = new System.Windows.Forms.TextBox();
            this.lblPlace = new System.Windows.Forms.Label();
            this.lblregion1 = new System.Windows.Forms.Label();
            this.boxIntervence = new System.Windows.Forms.GroupBox();
            this.txtSecondIncidentID = new System.Windows.Forms.NumericUpDown();
            this.btnDruhaIntervence = new System.Windows.Forms.Button();
            this.chkSecondIntervence = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dtIntervenceEnd = new System.Windows.Forms.DateTimePicker();
            this.tmIntervenceEnd = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNrCelkem = new System.Windows.Forms.NumericUpDown();
            this.txtNrOstatnimOsobam = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNrPozustalymBlizkym = new System.Windows.Forms.NumericUpDown();
            this.lbl88 = new System.Windows.Forms.Label();
            this.txtNrObetemPoskozenym = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.lblIntervenceNote = new System.Windows.Forms.Label();
            this.txtIntervenceNote = new System.Windows.Forms.TextBox();
            this.dtIntervence = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.tmIntervence = new System.Windows.Forms.DateTimePicker();
            this.ucParticipations1 = new EvitelApp2.Controls.ucParticipations();
            this.btnBack = new System.Windows.Forms.Button();
            this.boxCall.SuspendLayout();
            this.boxEvent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPocetObeti)).BeginInit();
            this.boxIntervence.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecondIncidentID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNrCelkem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNrOstatnimOsobam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNrPozustalymBlizkym)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNrObetemPoskozenym)).BeginInit();
            this.SuspendLayout();
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
            this.lblDatumACas.Location = new System.Drawing.Point(2, 28);
            this.lblDatumACas.Name = "lblDatumACas";
            this.lblDatumACas.Size = new System.Drawing.Size(125, 17);
            this.lblDatumACas.TabIndex = 1;
            this.lblDatumACas.Text = "Datum a čas hovoru";
            // 
            // lblVolajici
            // 
            this.lblVolajici.AutoSize = true;
            this.lblVolajici.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblVolajici.Location = new System.Drawing.Point(426, 29);
            this.lblVolajici.Name = "lblVolajici";
            this.lblVolajici.Size = new System.Drawing.Size(48, 17);
            this.lblVolajici.TabIndex = 2;
            this.lblVolajici.Text = "Volající";
            // 
            // lblZapsal
            // 
            this.lblZapsal.AutoSize = true;
            this.lblZapsal.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblZapsal.Location = new System.Drawing.Point(810, 30);
            this.lblZapsal.Name = "lblZapsal";
            this.lblZapsal.Size = new System.Drawing.Size(61, 17);
            this.lblZapsal.TabIndex = 4;
            this.lblZapsal.Text = "Zapsal(a)";
            // 
            // txtLoginUser
            // 
            this.txtLoginUser.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtLoginUser.Location = new System.Drawing.Point(899, 24);
            this.txtLoginUser.Name = "txtLoginUser";
            this.txtLoginUser.ReadOnly = true;
            this.txtLoginUser.Size = new System.Drawing.Size(240, 27);
            this.txtLoginUser.TabIndex = 7;
            // 
            // cmbIntervent
            // 
            this.cmbIntervent.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbIntervent.FormattingEnabled = true;
            this.cmbIntervent.Location = new System.Drawing.Point(503, 23);
            this.cmbIntervent.Name = "cmbIntervent";
            this.cmbIntervent.Size = new System.Drawing.Size(247, 28);
            this.cmbIntervent.TabIndex = 8;
            this.cmbIntervent.Validating += new System.ComponentModel.CancelEventHandler(this.cmbIntervent_Validating);
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
            // 
            // btnWrite
            // 
            this.btnWrite.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnWrite.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnWrite.Image = global::EvitelApp2.Properties.Resources.save_close24;
            this.btnWrite.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnWrite.Location = new System.Drawing.Point(1167, 17);
            this.btnWrite.Name = "btnWrite";
            this.btnWrite.Size = new System.Drawing.Size(95, 39);
            this.btnWrite.TabIndex = 10;
            this.btnWrite.Text = "Uložit";
            this.btnWrite.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnWrite.UseVisualStyleBackColor = true;
            this.btnWrite.Click += new System.EventHandler(this.btnWrite_Click);
            // 
            // tmIncident
            // 
            this.tmIncident.CustomFormat = "HH:mm";
            this.tmIncident.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tmIncident.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.tmIncident.Location = new System.Drawing.Point(266, 17);
            this.tmIncident.Name = "tmIncident";
            this.tmIncident.ShowUpDown = true;
            this.tmIncident.Size = new System.Drawing.Size(73, 27);
            this.tmIncident.TabIndex = 13;
            // 
            // lblUdalost
            // 
            this.lblUdalost.AutoSize = true;
            this.lblUdalost.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblUdalost.Location = new System.Drawing.Point(7, 23);
            this.lblUdalost.Name = "lblUdalost";
            this.lblUdalost.Size = new System.Drawing.Size(130, 17);
            this.lblUdalost.TabIndex = 12;
            this.lblUdalost.Text = "Datum a čas události";
            // 
            // dtIncident
            // 
            this.dtIncident.CustomFormat = "dd-MM-yyyy";
            this.dtIncident.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dtIncident.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtIncident.Location = new System.Drawing.Point(158, 17);
            this.dtIncident.Name = "dtIncident";
            this.dtIncident.Size = new System.Drawing.Size(102, 27);
            this.dtIncident.TabIndex = 11;
            // 
            // cmbSubTypeIncident
            // 
            this.cmbSubTypeIncident.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbSubTypeIncident.FormattingEnabled = true;
            this.cmbSubTypeIncident.Location = new System.Drawing.Point(158, 56);
            this.cmbSubTypeIncident.Name = "cmbSubTypeIncident";
            this.cmbSubTypeIncident.Size = new System.Drawing.Size(262, 28);
            this.cmbSubTypeIncident.TabIndex = 15;
            this.cmbSubTypeIncident.Validating += new System.ComponentModel.CancelEventHandler(this.cmbSubTypeIncident_Validating);
            // 
            // lblDruhUdalosti
            // 
            this.lblDruhUdalosti.AutoSize = true;
            this.lblDruhUdalosti.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblDruhUdalosti.Location = new System.Drawing.Point(7, 60);
            this.lblDruhUdalosti.Name = "lblDruhUdalosti";
            this.lblDruhUdalosti.Size = new System.Drawing.Size(86, 17);
            this.lblDruhUdalosti.TabIndex = 14;
            this.lblDruhUdalosti.Text = "Druh události";
            // 
            // txtEventNote
            // 
            this.txtEventNote.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtEventNote.Location = new System.Drawing.Point(765, 31);
            this.txtEventNote.Multiline = true;
            this.txtEventNote.Name = "txtEventNote";
            this.txtEventNote.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtEventNote.Size = new System.Drawing.Size(509, 118);
            this.txtEventNote.TabIndex = 16;
            this.txtEventNote.TextChanged += new System.EventHandler(this.txtEventNote_TextChanged_1);
            // 
            // lblNoteEvent
            // 
            this.lblNoteEvent.AutoSize = true;
            this.lblNoteEvent.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblNoteEvent.Location = new System.Drawing.Point(1147, 11);
            this.lblNoteEvent.Name = "lblNoteEvent";
            this.lblNoteEvent.Size = new System.Drawing.Size(127, 17);
            this.lblNoteEvent.TabIndex = 17;
            this.lblNoteEvent.Text = "Poznámka k události";
            // 
            // lblPocetPoskozenychObeti
            // 
            this.lblPocetPoskozenychObeti.AutoSize = true;
            this.lblPocetPoskozenychObeti.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPocetPoskozenychObeti.Location = new System.Drawing.Point(6, 89);
            this.lblPocetPoskozenychObeti.Name = "lblPocetPoskozenychObeti";
            this.lblPocetPoskozenychObeti.Size = new System.Drawing.Size(154, 17);
            this.lblPocetPoskozenychObeti.TabIndex = 18;
            this.lblPocetPoskozenychObeti.Text = "Počet poškozených/obětí";
            // 
            // cmbRegion
            // 
            this.cmbRegion.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbRegion.FormattingEnabled = true;
            this.cmbRegion.Location = new System.Drawing.Point(503, 15);
            this.cmbRegion.Name = "cmbRegion";
            this.cmbRegion.Size = new System.Drawing.Size(247, 28);
            this.cmbRegion.TabIndex = 21;
            this.cmbRegion.Validating += new System.ComponentModel.CancelEventHandler(this.cmbRegion_Validating);
            // 
            // lblRegion
            // 
            this.lblRegion.AutoSize = true;
            this.lblRegion.Location = new System.Drawing.Point(372, 74);
            this.lblRegion.Name = "lblRegion";
            this.lblRegion.Size = new System.Drawing.Size(27, 15);
            this.lblRegion.TabIndex = 20;
            this.lblRegion.Text = "Kraj";
            // 
            // boxCall
            // 
            this.boxCall.Controls.Add(this.btnWrite);
            this.boxCall.Controls.Add(this.dtCall);
            this.boxCall.Controls.Add(this.lblDatumACas);
            this.boxCall.Controls.Add(this.lblVolajici);
            this.boxCall.Controls.Add(this.lblZapsal);
            this.boxCall.Controls.Add(this.txtLoginUser);
            this.boxCall.Controls.Add(this.cmbIntervent);
            this.boxCall.Controls.Add(this.tmCall);
            this.boxCall.Location = new System.Drawing.Point(3, 36);
            this.boxCall.Name = "boxCall";
            this.boxCall.Size = new System.Drawing.Size(1280, 66);
            this.boxCall.TabIndex = 22;
            this.boxCall.TabStop = false;
            this.boxCall.Text = "Údaje o Hovoru";
            // 
            // boxEvent
            // 
            this.boxEvent.Controls.Add(this.txtSupposedId);
            this.boxEvent.Controls.Add(this.lblSupposeId);
            this.boxEvent.Controls.Add(this.chkPokusPriprava);
            this.boxEvent.Controls.Add(this.chkDokonane);
            this.boxEvent.Controls.Add(this.chkNasledekSmrti);
            this.boxEvent.Controls.Add(this.txtPocetObeti);
            this.boxEvent.Controls.Add(this.txtPlace);
            this.boxEvent.Controls.Add(this.lblPlace);
            this.boxEvent.Controls.Add(this.lblregion1);
            this.boxEvent.Controls.Add(this.lblNoteEvent);
            this.boxEvent.Controls.Add(this.dtIncident);
            this.boxEvent.Controls.Add(this.cmbRegion);
            this.boxEvent.Controls.Add(this.lblUdalost);
            this.boxEvent.Controls.Add(this.tmIncident);
            this.boxEvent.Controls.Add(this.lblDruhUdalosti);
            this.boxEvent.Controls.Add(this.lblPocetPoskozenychObeti);
            this.boxEvent.Controls.Add(this.cmbSubTypeIncident);
            this.boxEvent.Controls.Add(this.txtEventNote);
            this.boxEvent.Location = new System.Drawing.Point(3, 108);
            this.boxEvent.Name = "boxEvent";
            this.boxEvent.Size = new System.Drawing.Size(1280, 155);
            this.boxEvent.TabIndex = 23;
            this.boxEvent.TabStop = false;
            this.boxEvent.Text = "Údaje o události";
            // 
            // txtSupposedId
            // 
            this.txtSupposedId.Enabled = false;
            this.txtSupposedId.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtSupposedId.Location = new System.Drawing.Point(335, 117);
            this.txtSupposedId.Name = "txtSupposedId";
            this.txtSupposedId.Size = new System.Drawing.Size(85, 27);
            this.txtSupposedId.TabIndex = 29;
            // 
            // lblSupposeId
            // 
            this.lblSupposeId.AutoSize = true;
            this.lblSupposeId.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblSupposeId.Location = new System.Drawing.Point(7, 122);
            this.lblSupposeId.Name = "lblSupposeId";
            this.lblSupposeId.Size = new System.Drawing.Size(162, 17);
            this.lblSupposeId.TabIndex = 28;
            this.lblSupposeId.Text = "Předpokládané ID události";
            // 
            // chkPokusPriprava
            // 
            this.chkPokusPriprava.AutoSize = true;
            this.chkPokusPriprava.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.chkPokusPriprava.Location = new System.Drawing.Point(503, 125);
            this.chkPokusPriprava.Name = "chkPokusPriprava";
            this.chkPokusPriprava.Size = new System.Drawing.Size(115, 21);
            this.chkPokusPriprava.TabIndex = 27;
            this.chkPokusPriprava.Text = "Pokus/příprava";
            this.chkPokusPriprava.UseVisualStyleBackColor = true;
            // 
            // chkDokonane
            // 
            this.chkDokonane.AutoSize = true;
            this.chkDokonane.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.chkDokonane.Location = new System.Drawing.Point(503, 102);
            this.chkDokonane.Name = "chkDokonane";
            this.chkDokonane.Size = new System.Drawing.Size(86, 21);
            this.chkDokonane.TabIndex = 26;
            this.chkDokonane.Text = "Dokonané";
            this.chkDokonane.UseVisualStyleBackColor = true;
            // 
            // chkNasledekSmrti
            // 
            this.chkNasledekSmrti.AutoSize = true;
            this.chkNasledekSmrti.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.chkNasledekSmrti.Location = new System.Drawing.Point(503, 77);
            this.chkNasledekSmrti.Name = "chkNasledekSmrti";
            this.chkNasledekSmrti.Size = new System.Drawing.Size(114, 21);
            this.chkNasledekSmrti.TabIndex = 25;
            this.chkNasledekSmrti.Text = "Následek smrti";
            this.chkNasledekSmrti.UseVisualStyleBackColor = true;
            // 
            // txtPocetObeti
            // 
            this.txtPocetObeti.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtPocetObeti.Location = new System.Drawing.Point(335, 86);
            this.txtPocetObeti.Name = "txtPocetObeti";
            this.txtPocetObeti.Size = new System.Drawing.Size(85, 27);
            this.txtPocetObeti.TabIndex = 24;
            // 
            // txtPlace
            // 
            this.txtPlace.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtPlace.Location = new System.Drawing.Point(503, 45);
            this.txtPlace.Name = "txtPlace";
            this.txtPlace.Size = new System.Drawing.Size(247, 27);
            this.txtPlace.TabIndex = 23;
            this.txtPlace.Validating += new System.ComponentModel.CancelEventHandler(this.txtPlace_Validating);
            // 
            // lblPlace
            // 
            this.lblPlace.AutoSize = true;
            this.lblPlace.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPlace.Location = new System.Drawing.Point(426, 52);
            this.lblPlace.Name = "lblPlace";
            this.lblPlace.Size = new System.Drawing.Size(77, 17);
            this.lblPlace.TabIndex = 22;
            this.lblPlace.Text = "Místo/Obec";
            // 
            // lblregion1
            // 
            this.lblregion1.AutoSize = true;
            this.lblregion1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblregion1.Location = new System.Drawing.Point(426, 23);
            this.lblregion1.Name = "lblregion1";
            this.lblregion1.Size = new System.Drawing.Size(31, 17);
            this.lblregion1.TabIndex = 11;
            this.lblregion1.Text = "Kraj";
            // 
            // boxIntervence
            // 
            this.boxIntervence.Controls.Add(this.txtSecondIncidentID);
            this.boxIntervence.Controls.Add(this.btnDruhaIntervence);
            this.boxIntervence.Controls.Add(this.chkSecondIntervence);
            this.boxIntervence.Controls.Add(this.label6);
            this.boxIntervence.Controls.Add(this.dtIntervenceEnd);
            this.boxIntervence.Controls.Add(this.tmIntervenceEnd);
            this.boxIntervence.Controls.Add(this.label5);
            this.boxIntervence.Controls.Add(this.txtNrCelkem);
            this.boxIntervence.Controls.Add(this.txtNrOstatnimOsobam);
            this.boxIntervence.Controls.Add(this.label4);
            this.boxIntervence.Controls.Add(this.label3);
            this.boxIntervence.Controls.Add(this.txtNrPozustalymBlizkym);
            this.boxIntervence.Controls.Add(this.lbl88);
            this.boxIntervence.Controls.Add(this.txtNrObetemPoskozenym);
            this.boxIntervence.Controls.Add(this.label2);
            this.boxIntervence.Controls.Add(this.lblIntervenceNote);
            this.boxIntervence.Controls.Add(this.txtIntervenceNote);
            this.boxIntervence.Controls.Add(this.dtIntervence);
            this.boxIntervence.Controls.Add(this.label1);
            this.boxIntervence.Controls.Add(this.tmIntervence);
            this.boxIntervence.Location = new System.Drawing.Point(3, 269);
            this.boxIntervence.Name = "boxIntervence";
            this.boxIntervence.Size = new System.Drawing.Size(1280, 169);
            this.boxIntervence.TabIndex = 24;
            this.boxIntervence.TabStop = false;
            this.boxIntervence.Text = "Základní údaje o intervenci";
            // 
            // txtSecondIncidentID
            // 
            this.txtSecondIncidentID.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtSecondIncidentID.Location = new System.Drawing.Point(203, 127);
            this.txtSecondIncidentID.Name = "txtSecondIncidentID";
            this.txtSecondIncidentID.Size = new System.Drawing.Size(61, 27);
            this.txtSecondIncidentID.TabIndex = 45;
            // 
            // btnDruhaIntervence
            // 
            this.btnDruhaIntervence.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnDruhaIntervence.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnDruhaIntervence.Location = new System.Drawing.Point(274, 127);
            this.btnDruhaIntervence.Name = "btnDruhaIntervence";
            this.btnDruhaIntervence.Size = new System.Drawing.Size(95, 27);
            this.btnDruhaIntervence.TabIndex = 11;
            this.btnDruhaIntervence.Text = "Vyber událost";
            this.btnDruhaIntervence.UseVisualStyleBackColor = true;
            this.btnDruhaIntervence.Click += new System.EventHandler(this.btnDruhaIntervence_Click);
            // 
            // chkSecondIntervence
            // 
            this.chkSecondIntervence.AutoSize = true;
            this.chkSecondIntervence.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.chkSecondIntervence.Location = new System.Drawing.Point(7, 131);
            this.chkSecondIntervence.Name = "chkSecondIntervence";
            this.chkSecondIntervence.Size = new System.Drawing.Size(190, 21);
            this.chkSecondIntervence.TabIndex = 30;
            this.chkSecondIntervence.Text = "Druhá nebo další intervence";
            this.chkSecondIntervence.UseVisualStyleBackColor = true;
            this.chkSecondIntervence.CheckedChanged += new System.EventHandler(this.chkSecondIntervence_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(153, 62);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(24, 17);
            this.label6.TabIndex = 44;
            this.label6.Text = "do\r\n";
            // 
            // dtIntervenceEnd
            // 
            this.dtIntervenceEnd.CustomFormat = "dd-MM-yyyy";
            this.dtIntervenceEnd.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dtIntervenceEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtIntervenceEnd.Location = new System.Drawing.Point(199, 55);
            this.dtIntervenceEnd.Name = "dtIntervenceEnd";
            this.dtIntervenceEnd.Size = new System.Drawing.Size(97, 27);
            this.dtIntervenceEnd.TabIndex = 43;
            // 
            // tmIntervenceEnd
            // 
            this.tmIntervenceEnd.CustomFormat = "HH:mm";
            this.tmIntervenceEnd.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tmIntervenceEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.tmIntervenceEnd.Location = new System.Drawing.Point(308, 55);
            this.tmIntervenceEnd.Name = "tmIntervenceEnd";
            this.tmIntervenceEnd.ShowUpDown = true;
            this.tmIntervenceEnd.Size = new System.Drawing.Size(61, 27);
            this.tmIntervenceEnd.TabIndex = 42;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(477, 135);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 17);
            this.label5.TabIndex = 41;
            this.label5.Text = "CELKEM";
            // 
            // txtNrCelkem
            // 
            this.txtNrCelkem.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtNrCelkem.Location = new System.Drawing.Point(665, 131);
            this.txtNrCelkem.Name = "txtNrCelkem";
            this.txtNrCelkem.Size = new System.Drawing.Size(85, 27);
            this.txtNrCelkem.TabIndex = 40;
            // 
            // txtNrOstatnimOsobam
            // 
            this.txtNrOstatnimOsobam.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtNrOstatnimOsobam.Location = new System.Drawing.Point(665, 98);
            this.txtNrOstatnimOsobam.Name = "txtNrOstatnimOsobam";
            this.txtNrOstatnimOsobam.Size = new System.Drawing.Size(85, 27);
            this.txtNrOstatnimOsobam.TabIndex = 39;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(477, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 17);
            this.label4.TabIndex = 38;
            this.label4.Text = "OSTATNÍM OSOBÁM";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(477, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(141, 17);
            this.label3.TabIndex = 37;
            this.label3.Text = "POZŮSTALÝM/BLÍZKÝM";
            // 
            // txtNrPozustalymBlizkym
            // 
            this.txtNrPozustalymBlizkym.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtNrPozustalymBlizkym.Location = new System.Drawing.Point(665, 66);
            this.txtNrPozustalymBlizkym.Name = "txtNrPozustalymBlizkym";
            this.txtNrPozustalymBlizkym.Size = new System.Drawing.Size(85, 27);
            this.txtNrPozustalymBlizkym.TabIndex = 36;
            // 
            // lbl88
            // 
            this.lbl88.AutoSize = true;
            this.lbl88.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl88.Location = new System.Drawing.Point(477, 37);
            this.lbl88.Name = "lbl88";
            this.lbl88.Size = new System.Drawing.Size(147, 17);
            this.lbl88.TabIndex = 35;
            this.lbl88.Text = "OBĚTEM/POŠKOZENÝM";
            // 
            // txtNrObetemPoskozenym
            // 
            this.txtNrObetemPoskozenym.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtNrObetemPoskozenym.Location = new System.Drawing.Point(665, 32);
            this.txtNrObetemPoskozenym.Name = "txtNrObetemPoskozenym";
            this.txtNrObetemPoskozenym.Size = new System.Drawing.Size(85, 27);
            this.txtNrObetemPoskozenym.TabIndex = 34;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(469, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(281, 17);
            this.label2.TabIndex = 33;
            this.label2.Text = "Počet osob, kterým byla poskytnuta intervence:";
            // 
            // lblIntervenceNote
            // 
            this.lblIntervenceNote.AutoSize = true;
            this.lblIntervenceNote.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblIntervenceNote.Location = new System.Drawing.Point(1138, 12);
            this.lblIntervenceNote.Name = "lblIntervenceNote";
            this.lblIntervenceNote.Size = new System.Drawing.Size(136, 17);
            this.lblIntervenceNote.TabIndex = 32;
            this.lblIntervenceNote.Text = "Poznámka k intervenci";
            // 
            // txtIntervenceNote
            // 
            this.txtIntervenceNote.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtIntervenceNote.Location = new System.Drawing.Point(765, 32);
            this.txtIntervenceNote.Multiline = true;
            this.txtIntervenceNote.Name = "txtIntervenceNote";
            this.txtIntervenceNote.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtIntervenceNote.Size = new System.Drawing.Size(509, 120);
            this.txtIntervenceNote.TabIndex = 31;
            // 
            // dtIntervence
            // 
            this.dtIntervence.CustomFormat = "dd-MM-yyyy";
            this.dtIntervence.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dtIntervence.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtIntervence.Location = new System.Drawing.Point(199, 22);
            this.dtIntervence.Name = "dtIntervence";
            this.dtIntervence.Size = new System.Drawing.Size(97, 27);
            this.dtIntervence.TabIndex = 28;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(7, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 17);
            this.label1.TabIndex = 29;
            this.label1.Text = "Datum a čas intervence  od:";
            // 
            // tmIntervence
            // 
            this.tmIntervence.CustomFormat = "HH:mm";
            this.tmIntervence.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tmIntervence.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.tmIntervence.Location = new System.Drawing.Point(309, 22);
            this.tmIntervence.Name = "tmIntervence";
            this.tmIntervence.ShowUpDown = true;
            this.tmIntervence.Size = new System.Drawing.Size(60, 27);
            this.tmIntervence.TabIndex = 30;
            // 
            // ucParticipations1
            // 
            this.ucParticipations1.Location = new System.Drawing.Point(0, 433);
            this.ucParticipations1.Name = "ucParticipations1";
            this.ucParticipations1.Size = new System.Drawing.Size(1141, 375);
            this.ucParticipations1.TabIndex = 25;
            this.ucParticipations1.Load += new System.EventHandler(this.ucParticipations1_Load);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(10, 7);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 11;
            this.btnBack.Text = "<< Zpět";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // ucCallLIKO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.ucParticipations1);
            this.Controls.Add(this.boxIntervence);
            this.Controls.Add(this.boxEvent);
            this.Controls.Add(this.boxCall);
            this.Controls.Add(this.lblRegion);
            this.Name = "ucCallLIKO";
            this.Size = new System.Drawing.Size(1397, 702);
            this.Load += new System.EventHandler(this.ucCallLIKO_Load);
            this.Resize += new System.EventHandler(this.ucCallLIKO_Resize);
            this.boxCall.ResumeLayout(false);
            this.boxCall.PerformLayout();
            this.boxEvent.ResumeLayout(false);
            this.boxEvent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPocetObeti)).EndInit();
            this.boxIntervence.ResumeLayout(false);
            this.boxIntervence.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecondIncidentID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNrCelkem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNrOstatnimOsobam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNrPozustalymBlizkym)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNrObetemPoskozenym)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.CheckBox chkPokusPriprava;
        private System.Windows.Forms.CheckBox chkDokonane;
        private System.Windows.Forms.CheckBox chkNasledekSmrti;
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
  }

}
