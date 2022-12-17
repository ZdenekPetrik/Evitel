
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
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.lblUdalost = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.cmbSubTypeIntervence = new System.Windows.Forms.ComboBox();
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
            this.label5 = new System.Windows.Forms.Label();
            this.numericUpDown4 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.txtNrObet = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.lblIntervenceNote = new System.Windows.Forms.Label();
            this.txtIntervenceNote = new System.Windows.Forms.TextBox();
            this.dateTimePicker3 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker4 = new System.Windows.Forms.DateTimePicker();
            this.boxCall.SuspendLayout();
            this.boxEvent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPocetObeti)).BeginInit();
            this.gbIntervence.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
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
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "hh:mm";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(251, 17);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(87, 23);
            this.dateTimePicker1.TabIndex = 13;
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
            // dateTimePicker2
            // 
            this.dateTimePicker2.CustomFormat = "dd-MM-yyyy";
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker2.Location = new System.Drawing.Point(143, 17);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(87, 23);
            this.dateTimePicker2.TabIndex = 11;
            // 
            // cmbSubTypeIntervence
            // 
            this.cmbSubTypeIntervence.FormattingEnabled = true;
            this.cmbSubTypeIntervence.Location = new System.Drawing.Point(143, 57);
            this.cmbSubTypeIntervence.Name = "cmbSubTypeIntervence";
            this.cmbSubTypeIntervence.Size = new System.Drawing.Size(195, 23);
            this.cmbSubTypeIntervence.TabIndex = 15;
            this.cmbSubTypeIntervence.Validating += new System.ComponentModel.CancelEventHandler(this.cmbSubTypeIntervence_Validating);
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
            this.boxCall.Location = new System.Drawing.Point(3, 3);
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
            this.boxEvent.Controls.Add(this.dateTimePicker2);
            this.boxEvent.Controls.Add(this.cmbRegion);
            this.boxEvent.Controls.Add(this.lblUdalost);
            this.boxEvent.Controls.Add(this.dateTimePicker1);
            this.boxEvent.Controls.Add(this.lblDruhUdalosti);
            this.boxEvent.Controls.Add(this.lblPocetPoskozenychObeti);
            this.boxEvent.Controls.Add(this.cmbSubTypeIntervence);
            this.boxEvent.Controls.Add(this.txtEventNote);
            this.boxEvent.Location = new System.Drawing.Point(3, 74);
            this.boxEvent.Name = "boxEvent";
            this.boxEvent.Size = new System.Drawing.Size(1138, 142);
            this.boxEvent.TabIndex = 23;
            this.boxEvent.TabStop = false;
            this.boxEvent.Text = "Údaje o události";
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
            this.gbIntervence.Controls.Add(this.label5);
            this.gbIntervence.Controls.Add(this.numericUpDown4);
            this.gbIntervence.Controls.Add(this.numericUpDown3);
            this.gbIntervence.Controls.Add(this.label4);
            this.gbIntervence.Controls.Add(this.label3);
            this.gbIntervence.Controls.Add(this.numericUpDown2);
            this.gbIntervence.Controls.Add(this.txtNrObet);
            this.gbIntervence.Controls.Add(this.numericUpDown1);
            this.gbIntervence.Controls.Add(this.label2);
            this.gbIntervence.Controls.Add(this.lblIntervenceNote);
            this.gbIntervence.Controls.Add(this.txtIntervenceNote);
            this.gbIntervence.Controls.Add(this.dateTimePicker3);
            this.gbIntervence.Controls.Add(this.label1);
            this.gbIntervence.Controls.Add(this.dateTimePicker4);
            this.gbIntervence.Location = new System.Drawing.Point(3, 222);
            this.gbIntervence.Name = "gbIntervence";
            this.gbIntervence.Size = new System.Drawing.Size(1138, 131);
            this.gbIntervence.TabIndex = 24;
            this.gbIntervence.TabStop = false;
            this.gbIntervence.Text = "Základní údaje o intervenci";
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
            // numericUpDown4
            // 
            this.numericUpDown4.Location = new System.Drawing.Point(93, 80);
            this.numericUpDown4.Name = "numericUpDown4";
            this.numericUpDown4.Size = new System.Drawing.Size(85, 23);
            this.numericUpDown4.TabIndex = 40;
            // 
            // numericUpDown3
            // 
            this.numericUpDown3.Location = new System.Drawing.Point(579, 80);
            this.numericUpDown3.Name = "numericUpDown3";
            this.numericUpDown3.Size = new System.Drawing.Size(85, 23);
            this.numericUpDown3.TabIndex = 39;
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
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(455, 80);
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(85, 23);
            this.numericUpDown2.TabIndex = 36;
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
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(311, 80);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(85, 23);
            this.numericUpDown1.TabIndex = 34;
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
            // dateTimePicker3
            // 
            this.dateTimePicker3.CustomFormat = "dd-MM-yyyy";
            this.dateTimePicker3.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker3.Location = new System.Drawing.Point(143, 22);
            this.dateTimePicker3.Name = "dateTimePicker3";
            this.dateTimePicker3.Size = new System.Drawing.Size(87, 23);
            this.dateTimePicker3.TabIndex = 28;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 15);
            this.label1.TabIndex = 29;
            this.label1.Text = "Datum a čas intervence";
            // 
            // dateTimePicker4
            // 
            this.dateTimePicker4.CustomFormat = "hh:mm";
            this.dateTimePicker4.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker4.Location = new System.Drawing.Point(251, 22);
            this.dateTimePicker4.Name = "dateTimePicker4";
            this.dateTimePicker4.Size = new System.Drawing.Size(87, 23);
            this.dateTimePicker4.TabIndex = 30;
            // 
            // ucCallLIKO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbIntervence);
            this.Controls.Add(this.boxEvent);
            this.Controls.Add(this.boxCall);
            this.Controls.Add(this.lblRegion);
            this.Name = "ucCallLIKO";
            this.Size = new System.Drawing.Size(1141, 636);
            this.Load += new System.EventHandler(this.ucCallLIKO_Load);
            this.boxCall.ResumeLayout(false);
            this.boxCall.PerformLayout();
            this.boxEvent.ResumeLayout(false);
            this.boxEvent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPocetObeti)).EndInit();
            this.gbIntervence.ResumeLayout(false);
            this.gbIntervence.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
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
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label lblUdalost;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label lblDruhUdalosti;
        private System.Windows.Forms.TextBox txtEventNote;
        private System.Windows.Forms.Label lblNoteEvent;
        private System.Windows.Forms.Label lblPocetPoskozenychObeti;
        private System.Windows.Forms.ComboBox cmbSubTypeIntervence;
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
        private System.Windows.Forms.DateTimePicker dateTimePicker3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numericUpDown4;
        private System.Windows.Forms.NumericUpDown numericUpDown3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.Label txtNrObet;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbRegion;
    }

}
