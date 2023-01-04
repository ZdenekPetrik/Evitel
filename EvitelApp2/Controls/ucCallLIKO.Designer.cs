
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
            this.chkPokusPriprava = new System.Windows.Forms.CheckBox();
            this.chkDokonane = new System.Windows.Forms.CheckBox();
            this.chkNasledekSmrti = new System.Windows.Forms.CheckBox();
            this.txtPocetObeti = new System.Windows.Forms.NumericUpDown();
            this.txtPlace = new System.Windows.Forms.TextBox();
            this.lblPlace = new System.Windows.Forms.Label();
            this.lblregion1 = new System.Windows.Forms.Label();
            this.gbIntervence = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dtIntervenceEnd = new System.Windows.Forms.DateTimePicker();
            this.tmIntervenceEnd = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNrCelkem = new System.Windows.Forms.NumericUpDown();
            this.txtNrOstatnimOsobam = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNrPozustalymBlizkym = new System.Windows.Forms.NumericUpDown();
            this.txtNrObet = new System.Windows.Forms.Label();
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
            this.gbIntervence.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNrCelkem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNrOstatnimOsobam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNrPozustalymBlizkym)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNrObetemPoskozenym)).BeginInit();
            this.SuspendLayout();
            // 
            // dtCall
            // 
            this.dtCall.CustomFormat = "dd-MM-yyyy";
            this.dtCall.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtCall.Location = new System.Drawing.Point(143, 22);
            this.dtCall.Name = "dtCall";
            this.dtCall.Size = new System.Drawing.Size(87, 23);
            this.dtCall.TabIndex = 0;
            // 
            // lblDatumACas
            // 
            this.lblDatumACas.AutoSize = true;
            this.lblDatumACas.Location = new System.Drawing.Point(2, 28);
            this.lblDatumACas.Name = "lblDatumACas";
            this.lblDatumACas.Size = new System.Drawing.Size(113, 15);
            this.lblDatumACas.TabIndex = 1;
            this.lblDatumACas.Text = "Datum a čas hovoru";
            // 
            // lblVolajici
            // 
            this.lblVolajici.AutoSize = true;
            this.lblVolajici.Location = new System.Drawing.Point(359, 28);
            this.lblVolajici.Name = "lblVolajici";
            this.lblVolajici.Size = new System.Drawing.Size(44, 15);
            this.lblVolajici.TabIndex = 2;
            this.lblVolajici.Text = "Volající";
            // 
            // lblZapsal
            // 
            this.lblZapsal.AutoSize = true;
            this.lblZapsal.Location = new System.Drawing.Point(695, 28);
            this.lblZapsal.Name = "lblZapsal";
            this.lblZapsal.Size = new System.Drawing.Size(55, 15);
            this.lblZapsal.TabIndex = 4;
            this.lblZapsal.Text = "Zapsal(a)";
            // 
            // txtLoginUser
            // 
            this.txtLoginUser.Location = new System.Drawing.Point(784, 22);
            this.txtLoginUser.Name = "txtLoginUser";
            this.txtLoginUser.ReadOnly = true;
            this.txtLoginUser.Size = new System.Drawing.Size(211, 23);
            this.txtLoginUser.TabIndex = 7;
            // 
            // cmbIntervent
            // 
            this.cmbIntervent.FormattingEnabled = true;
            this.cmbIntervent.Location = new System.Drawing.Point(436, 22);
            this.cmbIntervent.Name = "cmbIntervent";
            this.cmbIntervent.Size = new System.Drawing.Size(195, 23);
            this.cmbIntervent.TabIndex = 8;
            this.cmbIntervent.Validating += new System.ComponentModel.CancelEventHandler(this.cmbIntervent_Validating);
            // 
            // tmCall
            // 
            this.tmCall.CustomFormat = "hh:mm";
            this.tmCall.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.tmCall.Location = new System.Drawing.Point(251, 22);
            this.tmCall.Name = "tmCall";
            this.tmCall.Size = new System.Drawing.Size(87, 23);
            this.tmCall.TabIndex = 9;
            // 
            // btnWrite
            // 
            this.btnWrite.Location = new System.Drawing.Point(1052, 21);
            this.btnWrite.Name = "btnWrite";
            this.btnWrite.Size = new System.Drawing.Size(75, 23);
            this.btnWrite.TabIndex = 10;
            this.btnWrite.Text = "Zapiš";
            this.btnWrite.UseVisualStyleBackColor = true;
            this.btnWrite.Click += new System.EventHandler(this.btnWrite_Click);
            // 
            // tmIncident
            // 
            this.tmIncident.CustomFormat = "hh:mm";
            this.tmIncident.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.tmIncident.Location = new System.Drawing.Point(251, 17);
            this.tmIncident.Name = "tmIncident";
            this.tmIncident.Size = new System.Drawing.Size(87, 23);
            this.tmIncident.TabIndex = 13;
            // 
            // lblUdalost
            // 
            this.lblUdalost.AutoSize = true;
            this.lblUdalost.Location = new System.Drawing.Point(2, 23);
            this.lblUdalost.Name = "lblUdalost";
            this.lblUdalost.Size = new System.Drawing.Size(117, 15);
            this.lblUdalost.TabIndex = 12;
            this.lblUdalost.Text = "Datum a čas události";
            // 
            // dtIncident
            // 
            this.dtIncident.CustomFormat = "dd-MM-yyyy";
            this.dtIncident.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtIncident.Location = new System.Drawing.Point(143, 17);
            this.dtIncident.Name = "dtIncident";
            this.dtIncident.Size = new System.Drawing.Size(87, 23);
            this.dtIncident.TabIndex = 11;
            // 
            // cmbSubTypeIncident
            // 
            this.cmbSubTypeIncident.FormattingEnabled = true;
            this.cmbSubTypeIncident.Location = new System.Drawing.Point(143, 57);
            this.cmbSubTypeIncident.Name = "cmbSubTypeIncident";
            this.cmbSubTypeIncident.Size = new System.Drawing.Size(195, 23);
            this.cmbSubTypeIncident.TabIndex = 15;
            this.cmbSubTypeIncident.Validating += new System.ComponentModel.CancelEventHandler(this.cmbSubTypeIntervence_Validating);
            // 
            // lblDruhUdalosti
            // 
            this.lblDruhUdalosti.AutoSize = true;
            this.lblDruhUdalosti.Location = new System.Drawing.Point(2, 60);
            this.lblDruhUdalosti.Name = "lblDruhUdalosti";
            this.lblDruhUdalosti.Size = new System.Drawing.Size(78, 15);
            this.lblDruhUdalosti.TabIndex = 14;
            this.lblDruhUdalosti.Text = "Druh události";
            // 
            // txtEventNote
            // 
            this.txtEventNote.Location = new System.Drawing.Point(704, 37);
            this.txtEventNote.Multiline = true;
            this.txtEventNote.Name = "txtEventNote";
            this.txtEventNote.Size = new System.Drawing.Size(421, 89);
            this.txtEventNote.TabIndex = 16;
            // 
            // lblNoteEvent
            // 
            this.lblNoteEvent.AutoSize = true;
            this.lblNoteEvent.Location = new System.Drawing.Point(1009, 19);
            this.lblNoteEvent.Name = "lblNoteEvent";
            this.lblNoteEvent.Size = new System.Drawing.Size(116, 15);
            this.lblNoteEvent.TabIndex = 17;
            this.lblNoteEvent.Text = "Poznámka k události";
            // 
            // lblPocetPoskozenychObeti
            // 
            this.lblPocetPoskozenychObeti.AutoSize = true;
            this.lblPocetPoskozenychObeti.Location = new System.Drawing.Point(0, 105);
            this.lblPocetPoskozenychObeti.Name = "lblPocetPoskozenychObeti";
            this.lblPocetPoskozenychObeti.Size = new System.Drawing.Size(141, 15);
            this.lblPocetPoskozenychObeti.TabIndex = 18;
            this.lblPocetPoskozenychObeti.Text = "Počet poškozených/obětí";
            // 
            // cmbRegion
            // 
            this.cmbRegion.FormattingEnabled = true;
            this.cmbRegion.Location = new System.Drawing.Point(436, 15);
            this.cmbRegion.Name = "cmbRegion";
            this.cmbRegion.Size = new System.Drawing.Size(195, 23);
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
            this.boxCall.Size = new System.Drawing.Size(1138, 66);
            this.boxCall.TabIndex = 22;
            this.boxCall.TabStop = false;
            this.boxCall.Text = "Údaje o Hovoru";
            // 
            // boxEvent
            // 
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
            this.boxEvent.Size = new System.Drawing.Size(1138, 142);
            this.boxEvent.TabIndex = 23;
            this.boxEvent.TabStop = false;
            this.boxEvent.Text = "Údaje o události";
            this.boxEvent.Enter += new System.EventHandler(this.boxEvent_Enter);
            // 
            // chkPokusPriprava
            // 
            this.chkPokusPriprava.AutoSize = true;
            this.chkPokusPriprava.Location = new System.Drawing.Point(436, 107);
            this.chkPokusPriprava.Name = "chkPokusPriprava";
            this.chkPokusPriprava.Size = new System.Drawing.Size(106, 19);
            this.chkPokusPriprava.TabIndex = 27;
            this.chkPokusPriprava.Text = "Pokus/příprava";
            this.chkPokusPriprava.UseVisualStyleBackColor = true;
            // 
            // chkDokonane
            // 
            this.chkDokonane.AutoSize = true;
            this.chkDokonane.Location = new System.Drawing.Point(436, 86);
            this.chkDokonane.Name = "chkDokonane";
            this.chkDokonane.Size = new System.Drawing.Size(80, 19);
            this.chkDokonane.TabIndex = 26;
            this.chkDokonane.Text = "Dokonané";
            this.chkDokonane.UseVisualStyleBackColor = true;
            // 
            // chkNasledekSmrti
            // 
            this.chkNasledekSmrti.AutoSize = true;
            this.chkNasledekSmrti.Location = new System.Drawing.Point(436, 66);
            this.chkNasledekSmrti.Name = "chkNasledekSmrti";
            this.chkNasledekSmrti.Size = new System.Drawing.Size(104, 19);
            this.chkNasledekSmrti.TabIndex = 25;
            this.chkNasledekSmrti.Text = "Následek smrti";
            this.chkNasledekSmrti.UseVisualStyleBackColor = true;
            // 
            // txtPocetObeti
            // 
            this.txtPocetObeti.Location = new System.Drawing.Point(251, 103);
            this.txtPocetObeti.Name = "txtPocetObeti";
            this.txtPocetObeti.Size = new System.Drawing.Size(85, 23);
            this.txtPocetObeti.TabIndex = 24;
            // 
            // txtPlace
            // 
            this.txtPlace.Location = new System.Drawing.Point(436, 37);
            this.txtPlace.Name = "txtPlace";
            this.txtPlace.Size = new System.Drawing.Size(195, 23);
            this.txtPlace.TabIndex = 23;
            this.txtPlace.Validating += new System.ComponentModel.CancelEventHandler(this.txtPlace_Validating);
            // 
            // lblPlace
            // 
            this.lblPlace.AutoSize = true;
            this.lblPlace.Location = new System.Drawing.Point(359, 45);
            this.lblPlace.Name = "lblPlace";
            this.lblPlace.Size = new System.Drawing.Size(70, 15);
            this.lblPlace.TabIndex = 22;
            this.lblPlace.Text = "Místo/Obec";
            // 
            // lblregion1
            // 
            this.lblregion1.AutoSize = true;
            this.lblregion1.Location = new System.Drawing.Point(359, 23);
            this.lblregion1.Name = "lblregion1";
            this.lblregion1.Size = new System.Drawing.Size(27, 15);
            this.lblregion1.TabIndex = 11;
            this.lblregion1.Text = "Kraj";
            // 
            // gbIntervence
            // 
            this.gbIntervence.Controls.Add(this.label6);
            this.gbIntervence.Controls.Add(this.dtIntervenceEnd);
            this.gbIntervence.Controls.Add(this.tmIntervenceEnd);
            this.gbIntervence.Controls.Add(this.label5);
            this.gbIntervence.Controls.Add(this.txtNrCelkem);
            this.gbIntervence.Controls.Add(this.txtNrOstatnimOsobam);
            this.gbIntervence.Controls.Add(this.label4);
            this.gbIntervence.Controls.Add(this.label3);
            this.gbIntervence.Controls.Add(this.txtNrPozustalymBlizkym);
            this.gbIntervence.Controls.Add(this.txtNrObet);
            this.gbIntervence.Controls.Add(this.txtNrObetemPoskozenym);
            this.gbIntervence.Controls.Add(this.label2);
            this.gbIntervence.Controls.Add(this.lblIntervenceNote);
            this.gbIntervence.Controls.Add(this.txtIntervenceNote);
            this.gbIntervence.Controls.Add(this.dtIntervence);
            this.gbIntervence.Controls.Add(this.label1);
            this.gbIntervence.Controls.Add(this.tmIntervence);
            this.gbIntervence.Location = new System.Drawing.Point(3, 256);
            this.gbIntervence.Name = "gbIntervence";
            this.gbIntervence.Size = new System.Drawing.Size(1138, 131);
            this.gbIntervence.TabIndex = 24;
            this.gbIntervence.TabStop = false;
            this.gbIntervence.Text = "Základní údaje o intervenci";
            this.gbIntervence.Enter += new System.EventHandler(this.gbIntervence_Enter);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(398, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(21, 15);
            this.label6.TabIndex = 44;
            this.label6.Text = "do\r\n";
            // 
            // dtIntervenceEnd
            // 
            this.dtIntervenceEnd.CustomFormat = "dd-MM-yyyy";
            this.dtIntervenceEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtIntervenceEnd.Location = new System.Drawing.Point(435, 22);
            this.dtIntervenceEnd.Name = "dtIntervenceEnd";
            this.dtIntervenceEnd.Size = new System.Drawing.Size(87, 23);
            this.dtIntervenceEnd.TabIndex = 43;
            // 
            // tmIntervenceEnd
            // 
            this.tmIntervenceEnd.CustomFormat = "hh:mm";
            this.tmIntervenceEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.tmIntervenceEnd.Location = new System.Drawing.Point(544, 22);
            this.tmIntervenceEnd.Name = "tmIntervenceEnd";
            this.tmIntervenceEnd.Size = new System.Drawing.Size(87, 23);
            this.tmIntervenceEnd.TabIndex = 42;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 88);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 15);
            this.label5.TabIndex = 41;
            this.label5.Text = "CELKEM";
            // 
            // txtNrCelkem
            // 
            this.txtNrCelkem.Location = new System.Drawing.Point(93, 80);
            this.txtNrCelkem.Name = "txtNrCelkem";
            this.txtNrCelkem.Size = new System.Drawing.Size(85, 23);
            this.txtNrCelkem.TabIndex = 40;
            this.txtNrCelkem.Validating += new System.ComponentModel.CancelEventHandler(this.txtNrCelkem_Validating);
            // 
            // txtNrOstatnimOsobam
            // 
            this.txtNrOstatnimOsobam.Location = new System.Drawing.Point(548, 80);
            this.txtNrOstatnimOsobam.Name = "txtNrOstatnimOsobam";
            this.txtNrOstatnimOsobam.Size = new System.Drawing.Size(85, 23);
            this.txtNrOstatnimOsobam.TabIndex = 39;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(548, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 15);
            this.label4.TabIndex = 38;
            this.label4.Text = "OSTATNÍM OSOBÁM";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(409, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 15);
            this.label3.TabIndex = 37;
            this.label3.Text = "POZŮSTALÝM/BLÍZKÝM";
            // 
            // txtNrPozustalymBlizkym
            // 
            this.txtNrPozustalymBlizkym.Location = new System.Drawing.Point(431, 80);
            this.txtNrPozustalymBlizkym.Name = "txtNrPozustalymBlizkym";
            this.txtNrPozustalymBlizkym.Size = new System.Drawing.Size(85, 23);
            this.txtNrPozustalymBlizkym.TabIndex = 36;
            // 
            // txtNrObet
            // 
            this.txtNrObet.AutoSize = true;
            this.txtNrObet.Location = new System.Drawing.Point(269, 62);
            this.txtNrObet.Name = "txtNrObet";
            this.txtNrObet.Size = new System.Drawing.Size(134, 15);
            this.txtNrObet.TabIndex = 35;
            this.txtNrObet.Text = "OBĚTEM/POŠKOZENÝM";
            // 
            // txtNrObetemPoskozenym
            // 
            this.txtNrObetemPoskozenym.Location = new System.Drawing.Point(311, 80);
            this.txtNrObetemPoskozenym.Name = "txtNrObetemPoskozenym";
            this.txtNrObetemPoskozenym.Size = new System.Drawing.Size(85, 23);
            this.txtNrObetemPoskozenym.TabIndex = 34;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(257, 15);
            this.label2.TabIndex = 33;
            this.label2.Text = "Počet osob, kterým byla poskytnuta intervence:";
            // 
            // lblIntervenceNote
            // 
            this.lblIntervenceNote.AutoSize = true;
            this.lblIntervenceNote.Location = new System.Drawing.Point(1003, 10);
            this.lblIntervenceNote.Name = "lblIntervenceNote";
            this.lblIntervenceNote.Size = new System.Drawing.Size(126, 15);
            this.lblIntervenceNote.TabIndex = 32;
            this.lblIntervenceNote.Text = "Poznámka k intervenci";
            // 
            // txtIntervenceNote
            // 
            this.txtIntervenceNote.Location = new System.Drawing.Point(704, 28);
            this.txtIntervenceNote.Multiline = true;
            this.txtIntervenceNote.Name = "txtIntervenceNote";
            this.txtIntervenceNote.Size = new System.Drawing.Size(421, 89);
            this.txtIntervenceNote.TabIndex = 31;
            // 
            // dtIntervence
            // 
            this.dtIntervence.CustomFormat = "dd-MM-yyyy";
            this.dtIntervence.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtIntervence.Location = new System.Drawing.Point(166, 22);
            this.dtIntervence.Name = "dtIntervence";
            this.dtIntervence.Size = new System.Drawing.Size(87, 23);
            this.dtIntervence.TabIndex = 28;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 15);
            this.label1.TabIndex = 29;
            this.label1.Text = "Datum a čas intervence  od:";
            // 
            // tmIntervence
            // 
            this.tmIntervence.CustomFormat = "hh:mm";
            this.tmIntervence.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.tmIntervence.Location = new System.Drawing.Point(259, 22);
            this.tmIntervence.Name = "tmIntervence";
            this.tmIntervence.Size = new System.Drawing.Size(87, 23);
            this.tmIntervence.TabIndex = 30;
            // 
            // ucParticipations1
            // 
            this.ucParticipations1.Location = new System.Drawing.Point(0, 393);
            this.ucParticipations1.Name = "ucParticipations1";
            this.ucParticipations1.Size = new System.Drawing.Size(1141, 388);
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
            this.Controls.Add(this.gbIntervence);
            this.Controls.Add(this.boxEvent);
            this.Controls.Add(this.boxCall);
            this.Controls.Add(this.lblRegion);
            this.Name = "ucCallLIKO";
            this.Size = new System.Drawing.Size(1144, 702);
            this.Load += new System.EventHandler(this.ucCallLIKO_Load);
            this.Resize += new System.EventHandler(this.ucCallLIKO_Resize);
            this.boxCall.ResumeLayout(false);
            this.boxCall.PerformLayout();
            this.boxEvent.ResumeLayout(false);
            this.boxEvent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPocetObeti)).EndInit();
            this.gbIntervence.ResumeLayout(false);
            this.gbIntervence.PerformLayout();
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
        private System.Windows.Forms.GroupBox gbIntervence;
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
        private System.Windows.Forms.Label txtNrObet;
        private System.Windows.Forms.NumericUpDown txtNrObetemPoskozenym;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbRegion;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.DateTimePicker dtIntervenceEnd;
    private System.Windows.Forms.DateTimePicker tmIntervenceEnd;
    private ucParticipations ucParticipations1;
    private System.Windows.Forms.Button btnBack;
  }

}
