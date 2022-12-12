namespace WinFormsApp1
{
    partial class Form1
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
            this.dgw = new System.Windows.Forms.DataGridView();
            this.btnEditMode = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnFind = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblPocet = new System.Windows.Forms.Label();
            this.lblKontakt = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblRegion = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgw)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgw
            // 
            this.dgw.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgw.Location = new System.Drawing.Point(12, 12);
            this.dgw.Name = "dgw";
            this.dgw.RowTemplate.Height = 25;
            this.dgw.Size = new System.Drawing.Size(1248, 426);
            this.dgw.TabIndex = 0;
            this.dgw.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgw_CellBeginEdit);
            this.dgw.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgw_CellContentClick);
            this.dgw.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgw_CellEndEdit);
            this.dgw.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgw_CellEnter);
            this.dgw.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgw_CellLeave);
            // 
            // btnEditMode
            // 
            this.btnEditMode.Location = new System.Drawing.Point(1185, 456);
            this.btnEditMode.Name = "btnEditMode";
            this.btnEditMode.Size = new System.Drawing.Size(75, 23);
            this.btnEditMode.TabIndex = 2;
            this.btnEditMode.Text = " ";
            this.btnEditMode.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1185, 485);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Delete Row";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(866, 31);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(75, 23);
            this.btnFind.TabIndex = 5;
            this.btnFind.Text = "Hledej";
            this.btnFind.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.lblPocet);
            this.groupBox1.Controls.Add(this.lblKontakt);
            this.groupBox1.Controls.Add(this.btnFind);
            this.groupBox1.Controls.Add(this.lblName);
            this.groupBox1.Controls.Add(this.lblRegion);
            this.groupBox1.Location = new System.Drawing.Point(12, 444);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(963, 74);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Vyhledávání";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(509, 34);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(149, 23);
            this.textBox2.TabIndex = 12;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(280, 34);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(149, 23);
            this.textBox1.TabIndex = 11;
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
            this.lblKontakt.Location = new System.Drawing.Point(509, 16);
            this.lblKontakt.Name = "lblKontakt";
            this.lblKontakt.Size = new System.Drawing.Size(48, 15);
            this.lblKontakt.TabIndex = 9;
            this.lblKontakt.Text = "Kontakt";
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
            this.lblRegion.Location = new System.Drawing.Point(119, 16);
            this.lblRegion.Name = "lblRegion";
            this.lblRegion.Size = new System.Drawing.Size(27, 15);
            this.lblRegion.TabIndex = 7;
            this.lblRegion.Text = "Kraj";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1272, 520);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnEditMode);
            this.Controls.Add(this.dgw);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgw)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView dgw;
        private Button btnEditMode;
        private Button button2;
        private Button btnFind;
        private GroupBox groupBox1;
        private TextBox textBox2;
        private TextBox textBox1;
        private Label lblPocet;
        private Label lblKontakt;
        private Label lblName;
        private Label lblRegion;
    }
}