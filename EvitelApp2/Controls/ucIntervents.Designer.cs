
namespace EvitelApp2.Controls
{
    partial class ucIntervents
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
            this.components = new System.ComponentModel.Container();
            this.dgw = new EvitelApp2.MyUserControl.ucDataGridView(this.components);
            this.groupBoxVyhledavani = new System.Windows.Forms.GroupBox();
            this.cmbRegion = new System.Windows.Forms.ComboBox();
            this.txtFilterContact = new System.Windows.Forms.TextBox();
            this.txtFilterName = new System.Windows.Forms.TextBox();
            this.lblPocet = new System.Windows.Forms.Label();
            this.lblKontakt = new System.Windows.Forms.Label();
            this.btnFind = new System.Windows.Forms.Button();
            this.lblName = new System.Windows.Forms.Label();
            this.lblRegion = new System.Windows.Forms.Label();
            this.btnEditMode = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgw)).BeginInit();
            this.groupBoxVyhledavani.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgw
            // 
            this.dgw.AllowUserToOrderColumns = true;
            this.dgw.AllowUserToResizeRows = false;
            this.dgw.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgw.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgw.Location = new System.Drawing.Point(9, 3);
            this.dgw.Name = "dgw";
            this.dgw.RowTemplate.Height = 25;
            this.dgw.Size = new System.Drawing.Size(716, 357);
            this.dgw.TabIndex = 0;
            this.dgw.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgw_CellEndEdit);
            this.dgw.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgw_CellEnter);
            this.dgw.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgw_RowPrePaint);
            this.dgw.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgw_UserDeletingRow);
            // 
            // groupBoxVyhledavani
            // 
            this.groupBoxVyhledavani.Controls.Add(this.cmbRegion);
            this.groupBoxVyhledavani.Controls.Add(this.txtFilterContact);
            this.groupBoxVyhledavani.Controls.Add(this.txtFilterName);
            this.groupBoxVyhledavani.Controls.Add(this.lblPocet);
            this.groupBoxVyhledavani.Controls.Add(this.lblKontakt);
            this.groupBoxVyhledavani.Controls.Add(this.btnFind);
            this.groupBoxVyhledavani.Controls.Add(this.lblName);
            this.groupBoxVyhledavani.Controls.Add(this.lblRegion);
            this.groupBoxVyhledavani.Location = new System.Drawing.Point(3, 366);
            this.groupBoxVyhledavani.Name = "groupBoxVyhledavani";
            this.groupBoxVyhledavani.Size = new System.Drawing.Size(963, 74);
            this.groupBoxVyhledavani.TabIndex = 10;
            this.groupBoxVyhledavani.TabStop = false;
            this.groupBoxVyhledavani.Text = "Vyhledávání";
            // 
            // cmbRegion
            // 
            this.cmbRegion.FormattingEnabled = true;
            this.cmbRegion.Location = new System.Drawing.Point(68, 34);
            this.cmbRegion.Name = "cmbRegion";
            this.cmbRegion.Size = new System.Drawing.Size(187, 23);
            this.cmbRegion.TabIndex = 13;
            // 
            // txtFilterContact
            // 
            this.txtFilterContact.Location = new System.Drawing.Point(500, 34);
            this.txtFilterContact.Name = "txtFilterContact";
            this.txtFilterContact.Size = new System.Drawing.Size(149, 23);
            this.txtFilterContact.TabIndex = 12;
            // 
            // txtFilterName
            // 
            this.txtFilterName.Location = new System.Drawing.Point(280, 34);
            this.txtFilterName.Name = "txtFilterName";
            this.txtFilterName.Size = new System.Drawing.Size(187, 23);
            this.txtFilterName.TabIndex = 11;
            // 
            // lblPocet
            // 
            this.lblPocet.AutoSize = true;
            this.lblPocet.Location = new System.Drawing.Point(6, 52);
            this.lblPocet.Name = "lblPocet";
            this.lblPocet.Size = new System.Drawing.Size(38, 15);
            this.lblPocet.TabIndex = 10;
            this.lblPocet.Text = "label1";
            // 
            // lblKontakt
            // 
            this.lblKontakt.AutoSize = true;
            this.lblKontakt.Location = new System.Drawing.Point(500, 16);
            this.lblKontakt.Name = "lblKontakt";
            this.lblKontakt.Size = new System.Drawing.Size(48, 15);
            this.lblKontakt.TabIndex = 9;
            this.lblKontakt.Text = "Kontakt";
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(868, 34);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(75, 23);
            this.btnFind.TabIndex = 5;
            this.btnFind.Text = "Hledej";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(280, 16);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(91, 15);
            this.lblName.TabIndex = 8;
            this.lblName.Text = "Jméno/Přijmení";
            // 
            // lblRegion
            // 
            this.lblRegion.AutoSize = true;
            this.lblRegion.Location = new System.Drawing.Point(68, 19);
            this.lblRegion.Name = "lblRegion";
            this.lblRegion.Size = new System.Drawing.Size(27, 15);
            this.lblRegion.TabIndex = 7;
            this.lblRegion.Text = "Kraj";
            // 
            // btnEditMode
            // 
            this.btnEditMode.Location = new System.Drawing.Point(972, 414);
            this.btnEditMode.Name = "btnEditMode";
            this.btnEditMode.Size = new System.Drawing.Size(75, 23);
            this.btnEditMode.TabIndex = 11;
            this.btnEditMode.Text = " Edit Mode";
            this.btnEditMode.UseVisualStyleBackColor = true;
            this.btnEditMode.Click += new System.EventHandler(this.btnEditMode_Click);
            // 
            // ucIntervents
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnEditMode);
            this.Controls.Add(this.groupBoxVyhledavani);
            this.Controls.Add(this.dgw);
            this.Name = "ucIntervents";
            this.Size = new System.Drawing.Size(1064, 443);
            this.Load += new System.EventHandler(this.ucIntervents_Load);
            this.Resize += new System.EventHandler(this.ucIntervents_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dgw)).EndInit();
            this.groupBoxVyhledavani.ResumeLayout(false);
            this.groupBoxVyhledavani.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MyUserControl.ucDataGridView dgw;
        private System.Windows.Forms.GroupBox groupBoxVyhledavani;
        private System.Windows.Forms.TextBox txtFilterContact;
        private System.Windows.Forms.TextBox txtFilterName;
        private System.Windows.Forms.Label lblPocet;
        private System.Windows.Forms.Label lblKontakt;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblRegion;
        private System.Windows.Forms.Button btnEditMode;
        private System.Windows.Forms.ComboBox cmbRegion;
    }
}
